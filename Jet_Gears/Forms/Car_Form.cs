using System;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.Design.WebControls;
using System.Windows.Forms;
using HtmlAgilityPack;
using Jet_Gears.Controls;
using Jet_Gears.Objects;

namespace Jet_Gears.Forms;

public partial class Car_Form : Form
{
    private Point Current_Location = new Point(5, 5);

    public Car_Form(string car_href)
    {
        
        InitializeComponent(); 
        Get_Cars_List(car_href);

    }

    
    

    private void Get_Cars_List(string car_href)
    {
        Categories.Cars.Clear();
        
        if (String.IsNullOrEmpty(car_href))
        {
            MessageBox.Show("Оберіть марку авто", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);;
            return;
        }
        Console.OutputEncoding = Encoding.Unicode;
        var web = new HtmlWeb();
        int i = 0;
        repeat:
        i++;
        try
        {
            var document = web.Load(car_href);

            // Знаходимо всі вузли продуктів
            // Знаходимо всі вузли з автомобілями
            var vehicleNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'col-12 col-md-6')]");

            if (vehicleNodes == null || vehicleNodes.Count == 0)
            {
                Console.WriteLine("No product nodes found.");
                if(i != 3) goto repeat;
                return;
            }

            foreach (var vehicleNode in vehicleNodes)
            {
                // Витягуємо href з top-auto-item__image
                var linkNode = vehicleNode.SelectSingleNode(".//a[contains(@class, 'title')]");
                var href = linkNode?.GetAttributeValue("href", "No link");
                
                
                var title = CleanText(linkNode?.InnerText);

                
                var kw = vehicleNode.SelectSingleNode(".//div[contains(@class, 'kw')]")?.InnerText.Trim();
                var ps = vehicleNode.SelectSingleNode(".//div[contains(@class, 'ps')]")?.InnerText.Trim();
                var ab = vehicleNode.SelectSingleNode(".//div[contains(@class, 'ab')]")?.InnerText.Trim();
                var bis = vehicleNode.SelectSingleNode(".//div[contains(@class, 'bis')]")?.InnerText.Trim();

                var subtitle = CleanText($"{kw} {ps} {ab} {bis}");

                Categories.Cars.Add(new Car(href,title,subtitle));
            }
            
            Write_Cars_Buttons();
        } 
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
            if(i != 3) goto repeat;
            MessageBox.Show("Авто не знайдено", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    
    
    private void Clean_Buttons()
    {
        Buttons_Panel.Controls.Clear();
    }
    
    private void Write_Cars_Buttons()
    {
        Clean_Buttons();
        Current_Location = new Point(5, 5);
        int i = 1;
        foreach (var vehicle in Categories.Cars)
        {
                button b = new button();
                b.Location = Current_Location;
                b.Text = vehicle.Title;
                b.Name = vehicle.Href;
                b.BackColor = Color.FromArgb(0, 36, 0);
                b.ForeColor = Color.Azure;
                b.RoundingEnable = false;
                b.Font = new Font("Bahnschrift SemiBold SemiConden", 10, FontStyle.Bold);
                b.Size = new Size(189, 50);
                Buttons_Panel.Controls.Add(b);
                b.Click += Open_Car_Nodes;
                b.Show();
                b.BringToFront();
                Current_Location.X += b.Width + 5;
                if (i == 6)
                {
                    Current_Location.X = 5;
                    Current_Location.Y += 50 + 5;
                    i = 1;
                }
                else
                {
                    i++;
                }
            }
        }


    private static string CleanText(string text)
    {
        if (string.IsNullOrEmpty(text))
            return string.Empty;

        // Замінюємо кілька пробілів чи нових рядків на один пробіл
        return Regex.Replace(text, @"\s+", " ").Trim();
    }
    
    
    private void Car_TextBox_TextChanged(object sender, EventArgs e)
    {
        TextBox t = sender as TextBox;

        if (t.Text == "")
        {
            Clean_Buttons();
            Current_Location = new Point(5, 5);
            Write_Cars_Buttons();
        }
        
        Clean_Buttons();
        Current_Location = new Point(5, 5);
        int i = 1;
        foreach (var vehicle in Categories.Cars)
        {
            if (!vehicle.Title.ToLower().Contains(t.Text)) continue;
            button b = new button();
            b.Location = Current_Location;
            b.Text = vehicle.Title;
            b.Name = vehicle.Href;
            b.BackColor = Color.FromArgb(0, 36, 0);
            b.ForeColor = Color.Azure;
            b.RoundingEnable = false;
            b.Font = new Font("Bahnschrift SemiBold SemiConden", 10, FontStyle.Bold);
            b.Size = new Size(189, 50);
            Buttons_Panel.Controls.Add(b);
            b.Click += Open_Car_Nodes;
            b.Show();
            b.BringToFront();
            Current_Location.X += b.Width + 5;
            if (i == 6)
            {
                Current_Location.X = 5;
                Current_Location.Y += 50 + 5;
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
        button b = sender as button;
        Categories.ChoosenCarHref = b.Name;
        Categories.CurrentMainForm.OpenChildForm(new Car_Nodes_Form(Categories.ChoosenCarHref),false);
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Categories.CurrentMainForm.OpenChildForm(new Makers_Form());
    }
    
    private void button2_Click(object sender, EventArgs e)
    {
        Categories.CurrentMainForm.OpenChildForm(new Models_Form(Categories.ChoosenModelHref),false);
    }

    private void button3_Click(object sender, EventArgs e)
    {
        Categories.CurrentMainForm.OpenChildForm(new Mark_Form(Categories.ChoosenModelHref),false);
    }


}