using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using Jet_Gears.Controls;
using Jet_Gears.Objects;
using Newtonsoft.Json;

namespace Jet_Gears.Forms;

public partial class Mark_Form : Form
{
    private Point Current_Location = new Point(5, 5);
    private string Mark_href;

    public Mark_Form(string mark_href)
    {
        
        InitializeComponent();
        Mark_href = mark_href;
    }

    
    

private async Task Get_Mark_ListAsync(string mark_href)
{
    Console.OutputEncoding = Encoding.Unicode;
    var web = new HtmlWeb();
    int i = 0;
    Categories.CarMarks.Clear();

    if (string.IsNullOrEmpty(mark_href))
    {
        MessageBox.Show("Оберіть модель авто", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
    }

    // Створюємо та показуємо лоадінг-скрін
    using (var loadingForm = new Loading_Form())
    {
        loadingForm.Show();
        loadingForm.Refresh(); // Щоб UI оновився перед виконанням важкої задачі
        await Task.Delay(100); // Додатковий час для оновлення UI

        // Виконуємо завантаження у фоновому потоці
        List<Car_Mark> tempList = await Task.Run(() =>
        {
            List<Car_Mark> list = new List<Car_Mark>();

            repeat:
            i++;

            try
            {
                var document = web.Load(mark_href); // Синхронне завантаження у фоновому потоці

                var productNodes = document.DocumentNode.SelectNodes("//div[@class='col-12 col-md-6 col-lg-4 col-xxl-3']");
                if (productNodes == null || productNodes.Count == 0)
                {
                    if (i != 3) { goto repeat; }
                    return list;
                }

                foreach (var productCard in productNodes)
                {
                    var titleNode = productCard.SelectSingleNode(".//a[contains(@class, 'vehicle-list__link')]/span[contains(@class, 'title')]");
                    var title = CleanText(titleNode?.InnerText);

                    var linkNode = productCard.SelectSingleNode(".//a[contains(@class, 'vehicle-list__link')]");
                    var href = linkNode?.GetAttributeValue("href", "No link");

                    list.Add(new Car_Mark(href, title));
                }
            }
            catch
            {
                if (i != 3) { goto repeat; }
            }

            return list;
        });

        // Оновлюємо UI одним викликом
        if (tempList.Count > 0)
        {
            Categories.CarMarks.AddRange(tempList);
            Write_Marks_Buttons(); // Оновлюємо кнопки один раз після додавання всіх елементів
        }
    }

    // Лоадінг-екран автоматично закриється після виходу з using
}


    
    
    private void Clean_Buttons()
    {
        Buttons_Panel.Controls.Clear();
    }
    
    private void Write_Marks_Buttons()
    {
        Clean_Buttons();
        Current_Location = new Point(5, 5);
        int i = 1;
        foreach (var vehicle in Categories.CarMarks)
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
                b.Click += Get_Car;
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

    private void Get_Car(object sender, EventArgs e)
    {
        button b = sender as button;
        Categories.ChoosenMarkHref = b.Name;
        Categories.CurrentMainForm.OpenChildForm(new Car_Form(Categories.ChoosenMarkHref));
    }


    private static string CleanText(string text)
    {
        if (string.IsNullOrEmpty(text))
            return string.Empty;

        // Замінюємо кілька пробілів чи нових рядків на один пробіл
        return Regex.Replace(text, @"\s+", " ").Trim();
    }
    
    
    private void Marks_TextBox_TextChanged(object sender, EventArgs e)
    {
        TextBox t = sender as TextBox;

        if (t.Text == "")
        {
            Clean_Buttons();
            Current_Location = new Point(5, 5);
            Write_Marks_Buttons();
        }
        
        Clean_Buttons();
        Current_Location = new Point(5, 5);
        int i = 1;
        foreach (var vehicle in Categories.CarMarks)
        {
            if (!vehicle.Title.ToLower().Contains(t.Text.ToLower()))continue;
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
            b.Click += Get_Car;
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

    private void button1_Click(object sender, EventArgs e)
    {
        Categories.CurrentMainForm.OpenChildForm(new Makers_Form(),false);
    }

    private void button2_Click(object sender, EventArgs e)
    {
        Categories.CurrentMainForm.OpenChildForm(new Models_Form(Categories.ChoosenMaker),false);
    }

    private void button4_Click(object sender, EventArgs e)
    {
        Categories.CurrentMainForm.OpenChildForm(new Car_Form(Categories.ChoosenMarkHref),false);
    }

    private async void Mark_Form_Load(object sender, EventArgs e)
    {

            await Get_Mark_ListAsync(Mark_href);
    }
}