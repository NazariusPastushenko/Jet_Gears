using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HtmlAgilityPack;
using Jet_Gears.Controls;
using Jet_Gears.Objects;

namespace Jet_Gears.Forms;

public partial class Car_Nodes_Form : Form
{
    
    private Animation slideAnimation;
    private Timer animationTimer;
    
    private List <Node> _currNodes = new List<Node>();
    private Point Current_Location = new Point(5, 5);

    public Car_Nodes_Form(string carHref)
    {
        InitializeComponent();
        Get_Car_Nodes(carHref);
        
        animationTimer = new Timer
        {
            Interval = 16 // 60 FPS (~16 мс на кадр)
        };
        animationTimer.Tick += OnAnimationTick;
    }
    
    
    
    
    public void Get_Car_Nodes( string carHref)
        {
            var url = carHref; // вкажіть URL вашої сторінки
        var web = new HtmlWeb();
        var doc =  web.Load(url);
        
        var nodes = new List<Node>();


        var nodeElements = doc.DocumentNode.SelectNodes("//div[contains(@class, 'col-6 col-sm-4 col-md-4 col-lg-3 col-xl-2')]");
        
        if (nodeElements != null)
        {
            foreach (var nodeElement in nodeElements)
            {
                var node = new Node
                {
                    ImageUrl = nodeElement.SelectSingleNode(".//div[@class='catalog-grid-item__image']/img")?.GetAttributeValue("src", ""),
                    Name = nodeElement.SelectSingleNode(".//div[@class='catalog-grid-item__name']/span")?.InnerText,
                    Parts = new List<AutoPart>()
                };

                var partElements = nodeElement.SelectNodes(".//div[contains(@class, 'row')]//div[contains(@class, 'col-12 col-sm-6 col-lg-4 col-xxl-3')]");

                if (partElements != null)
                {
                    foreach (var partElement in partElements)
                    {
                        var part = new AutoPart
                        {
                            ImageUrl = partElement.SelectSingleNode(".//span[@class='catalog-subcats__image']/img")?.GetAttributeValue("src", ""),
                            Name = partElement.SelectSingleNode(".//span[@class='catalog-subcats__name']")?.InnerText
                        };

                        var linkNode = partElement.SelectSingleNode(".//a[@href]");
                        if (linkNode != null)
                        {
                            part.Link = linkNode.GetAttributeValue("href", "");
                        }
                        else
                        {

                            var spanNode = partElement.SelectSingleNode(".//span[@data-link]");
                            if (spanNode != null)
                            {
                                part.Link = spanNode.GetAttributes().FirstOrDefault(x=> x is { Name: "data-link", ValueLength: >0 })?.Value;
                            }
                        }

                        node.Parts.Add(part);
                    }
                }

                nodes.Add(node);
            }
        }

        _currNodes = nodes;

        Write_Nodes_Buttons();

        }
    
    private void Write_Nodes_Buttons()
    {
        Clean_Buttons();
        Current_Location = new Point(5, 5);
        int i = 1;
        foreach (var node in _currNodes)
        {
            if (node.Parts.Count == 0){continue;}
            ImageTextButton b = new ImageTextButton();
            b.Location = Current_Location;
            b.Text = node.Name;
            b.Name = node.Name;
            b.ImageUrl = node.ImageUrl;
            b.ImageSize = new Size(150, 150);
            b.BackColor = Color.FromArgb(0, 36, 0);
            b.ForeColor = Color.Azure;
            b.Font = new Font("Bahnschrift SemiBold SemiConden", 15, FontStyle.Bold);
            b.Size = new Size(387, 120);
            b.Click += Open_Car_Nodes;
            Nodes_Panel.Controls.Add(b);
            b.Show();
            b.BringToFront();
            Current_Location.X += b.Width + 5;
            if (i == 3)
            {
                Current_Location.X = 5;
                Current_Location.Y += 120 + 5;
                i = 1;
            }
            else
            {
                i++;
            }
        }
        
    }

    private void Open_Car_Nodes(object sender, EventArgs e)
    {
        ImageTextButton b = sender as ImageTextButton;
        foreach (var node in _currNodes)
        {
            if (node.Name == b.Name)
            {
                OpenChildFormWithAnimation(new PartsFromNode_Form(node.Parts));
                break;
            }
        }
        
    }


    private Form activeForm = null;
    
    public void OpenChildFormWithAnimation(Form childForm)
    {
        if (activeForm != null)
        {
            activeForm.Close();
        }

        activeForm = childForm;
        childForm.TopLevel = false;
        childForm.FormBorderStyle = FormBorderStyle.None;
        childForm.Left = Width; // Початкова позиція за межами правої сторони
        childForm.Top = 0;
        childForm.Height = ClientSize.Height;
        childForm.Width = 500; // Ширина форми огляду
        Controls.Add(childForm);
        Controls.SetChildIndex(childForm, 0);

        slideAnimation = new Animation(
            "SlideIn",
            () => childForm.Invalidate(),
            childForm.Left,
            Width - childForm.Width
        );

        animationTimer.Start();
        childForm.Show();
    }
    
    private void OnAnimationTick(object sender, EventArgs e)
    {
        if (slideAnimation.Status != Animation.AnimationStatus.Completed)
        {
            slideAnimation.UpdateFrame();
            activeForm.Left = (int)slideAnimation.Value;
        }
        else
        {
            animationTimer.Stop();
        }
    }
    
    private void Clean_Buttons()
    {
        Nodes_Panel.Controls.Clear();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Categories.CurrentMainForm.OpenChildForm(new Car_Form(Categories.ChoosenMarkHref),false);
    }
}
