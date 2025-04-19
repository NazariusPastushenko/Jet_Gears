using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jet_Gears.Controls;
using Jet_Gears.Objects;
using Newtonsoft.Json;
using yt_DesignUI;

namespace Jet_Gears.Forms;

public partial class Makers_Form : Form
{


    private Point Current_Location = new Point(5, 5);

    public Makers_Form()
    {
        InitializeComponent();
        Get_Makers_ListAsync();
    }
    
    
    private void Write_Makers_Buttons()
    {
        Current_Location = new Point(5, 5);
        Clean_Buttons();
        int i = 1;
        foreach (var var in Categories.MakersRoot)
        {
            button b = new button();
            b.Location = Current_Location;
            b.Text = var.Name;
            b.Name = var.Id.ToString();
            b.BackColor = Color.FromArgb(0, 36, 0);
            b.ForeColor = Color.Azure;
            b.RoundingEnable = false;
            b.Font = new Font("Bahnschrift SemiBold SemiConden", 10, FontStyle.Bold);
            b.Size = new Size(189, 32);
            Buttons_Panel.Controls.Add(b);
            b.Show();
            b.BringToFront();
            b.Click += Get_Models;
            Current_Location.X += b.Width + 5;
            if (i == 6)
            {
                Current_Location.X = 5;
                Current_Location.Y += 32 + 5;
                i = 1;
            }
            else
            {
                i++;
            }
        }
    }

    private void Get_Models(object sender, EventArgs e)
    {
        button b = sender as button;
        Categories.ChoosenMaker = b.Text;
        Categories.CurrentMainForm.OpenChildForm(new Models_Form(Categories.ChoosenMaker),false);
    }

    
    private async void Get_Makers_ListAsync()
    {
        using (var loadingForm = new Loading_Form()) // Лоадінг-екран
        {
            loadingForm.Show();
            loadingForm.Refresh();
            await Task.Delay(100); // Додатковий час для оновлення UI

            List<Option> makersList = await Task.Run(async () =>
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        var request = new HttpRequestMessage(HttpMethod.Get, "https://www.onlinecarparts.co.uk/ajax/selector/vehicle");
                        request.Headers.Add("Referer", "https://www.onlinecarparts.co.uk/");

                        var response = await client.SendAsync(request);
                        response.EnsureSuccessStatusCode();
                        var json = await response.Content.ReadAsStringAsync();

                        var root = JsonConvert.DeserializeObject<RootMaker>(json);

                        return root?.Makers.SelectMany(m => m.Options).ToList() ?? new List<Option>();
                    }
                }
                catch
                {
                    return new List<Option>();
                }
            });

            if (makersList.Count > 0)
            {
                Categories.MakersRoot = makersList;
                Write_Makers_Buttons(); // Оновлений метод для асинхронного оновлення UI
            }
        }
    }

    private void Clean_Buttons()
    {
        Buttons_Panel.Controls.Clear();
    }

    private void Makers_TextBox_TextChanged(object sender, EventArgs e)
    {
        TextBox t = sender as TextBox;

        if (t.Text == "")
        {
            Clean_Buttons();
            Current_Location = new Point(5, 5);
            Write_Makers_Buttons();
        }
        
        Current_Location = new Point(5, 5);
        Clean_Buttons();
        int i = 1;
        foreach (var var in Categories.MakersRoot)
        {
            if(!var.Name.Contains(t.Text.ToUpper()))continue;
            button b = new button();
            b.Location = Current_Location;
            b.Text = $"{var.Name}";
            b.Name = var.Id.ToString();
            b.BackColor = Color.FromArgb(0, 36, 0);
            b.ForeColor = Color.Azure;
            b.RoundingEnable = false;
            b.Font = new Font("Bahnschrift SemiBold SemiConden", 10, FontStyle.Bold);
            b.Size = new Size(189, 32);
            Buttons_Panel.Controls.Add(b);
            b.Show();
            b.BringToFront();
            b.Click += Get_Models;
            Current_Location.X += b.Width + 5;
            if (i == 6)
            {
                Current_Location.X = 5;
                Current_Location.Y += 32 + 5;
                i = 1;
            }
            else
            {
                i++;
            }
        }
        
        
    }

    private void button2_Click(object sender, EventArgs e)
    {
        Categories.CurrentMainForm.OpenChildForm(new Models_Form(Categories.ChoosenMaker),false);
    }

    private void button3_Click(object sender, EventArgs e)
    {
        Categories.CurrentMainForm.OpenChildForm(new Mark_Form(Categories.ChoosenModelHref),false);
    }

    private void button4_Click(object sender, EventArgs e)
    {
        Categories.CurrentMainForm.OpenChildForm(new Car_Form(Categories.ChoosenMarkHref),false);
    }
}