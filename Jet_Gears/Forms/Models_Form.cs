using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using Jet_Gears.Controls;
using Jet_Gears.Objects;

namespace Jet_Gears.Forms;

public partial class Models_Form : Form
{
    private Point _currentLocation = new Point(5, 5);
    private string _maker;

    public Models_Form(string maker)
    {
        InitializeComponent();
        _maker = maker;
    }



    private async Task Get_Models_ListAsync(string makerId)
{
    if (string.IsNullOrEmpty(makerId))
    {
        MessageBox.Show("Оберіть виробника авто", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
    }

    Categories.CarModels.Clear();
    Console.OutputEncoding = Encoding.Unicode;
    var web = new HtmlWeb();
    int i = 0;

    using (var loadingForm = new Loading_Form()) // Лоадінг-екран
    {
        loadingForm.Show();
        loadingForm.Refresh();
        await Task.Delay(100); // Додатковий час для оновлення UI

        List<Car_Model> tempList = await Task.Run(() =>
        {
            List<Car_Model> list = new List<Car_Model>();

            repeat:
            i++;

            try
            {
                var document = web.Load($"https://www.onlinecarparts.co.uk/car-brands/spare-parts-{makerId}.html");
                var productNodes = document.DocumentNode.SelectNodes("//div[@class='col-12 col-md-6 col-xl-4 col-xxl-3']");

                if (productNodes == null || productNodes.Count == 0)
                {
                    if (i != 3) { goto repeat; }
                    return list;
                }

                foreach (var productCard in productNodes)
                {
                    var titleNode = productCard.SelectSingleNode(".//div[contains(@class, 'top-auto-item__name')]/span");
                    var title = CleanText(titleNode?.InnerText);

                    var imageNode = productCard.SelectSingleNode(".//a[contains(@class, 'top-auto-item__image')]/img");
                    var imageUrl = imageNode?.GetAttributeValue("src", "No image");

                    var linkNode = productCard.SelectSingleNode(".//a[contains(@class, 'top-auto-item__image')]");
                    var href = linkNode?.GetAttributeValue("href", "No link");

                    list.Add(new Car_Model(href, title, imageUrl));
                }
            }
            catch
            {
                if (i != 3) { goto repeat; }
            }

            return list;
        });

        if (tempList.Count > 0)
        {
            Categories.CarModels.AddRange(tempList);
            Write_Models_Buttons(); // Оновлюємо UI одним викликом
        }
    }
}




    private void Clean_Buttons()
    {
        Buttons_Panel.Controls.Clear();
    }

    private void Write_Models_Buttons()
    {
        Clean_Buttons();
        _currentLocation = new Point(5, 5);
        int i = 1;
        foreach (var model in Categories.CarModels)
        {
            ImageTextButton b = new ImageTextButton();
            b.Location = _currentLocation;
            b.Text = model.Title;
            b.Name = model.Href;
            b.ImageUrl = model.ImgUrl;
            b.BackColor = Color.FromArgb(0, 36, 0);
            b.ForeColor = Color.Azure;
            b.Font = new Font("Bahnschrift SemiBold SemiConden", 15, FontStyle.Bold);
            b.Size = new Size(387, 120);
            Buttons_Panel.Controls.Add(b);
            b.Click += Get_Marks;
            b.Show();
            b.BringToFront();
            _currentLocation.X += b.Width + 5;
            if (i == 3)
            {
                _currentLocation.X = 5;
                _currentLocation.Y += 120 + 5;
                i = 1;
            }
            else
            {
                i++;
            }
        }
    }


    private void Get_Marks(object sender, EventArgs e)
    {
        button b = sender as button;
        Categories.ChoosenModelHref = b.Name;
        Categories.CurrentMainForm.OpenChildForm(new Mark_Form(Categories.ChoosenModelHref),false);
    }




    private void Models_TextBox_TextChanged(object sender, EventArgs e)
    {
        TextBox t = sender as TextBox;

        if (t.Text == "")
        {
            Clean_Buttons();
            _currentLocation = new Point(5, 5);
            Write_Models_Buttons();
        }

        Clean_Buttons();
        _currentLocation = new Point(5, 5);
        int i = 1;
        foreach (var model in Categories.CarModels)
        {
            if (!model.Title.Contains(t.Text.ToUpper())) continue;
            ImageTextButton b = new ImageTextButton();
            b.Location = _currentLocation;
            b.Text = model.Title;
            b.Name = model.Href;
            b.ImageUrl = model.ImgUrl;
            b.BackColor = Color.FromArgb(0, 36, 0);
            b.ForeColor = Color.Azure;
            b.Font = new Font("Bahnschrift SemiBold SemiConden", 15, FontStyle.Bold);
            b.TextAlign = ContentAlignment.MiddleRight;
            b.Size = new Size(387, 120);
            Buttons_Panel.Controls.Add(b);
            b.Click += Get_Marks;
            b.Show();
            b.BringToFront();
            _currentLocation.X += b.Width + 5;
            if (i == 3)
            {
                _currentLocation.X = 5;
                _currentLocation.Y += 120 + 5;
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
        Categories.CurrentMainForm.OpenChildForm(new Makers_Form(), false);
    }

    private void button3_Click(object sender, EventArgs e)
    {
        Categories.CurrentMainForm.OpenChildForm(new Mark_Form(Categories.ChoosenModelHref), false);
    }


    static string CleanText(string text)
    {
        if (string.IsNullOrEmpty(text))
            return string.Empty;

        // Замінюємо кілька пробілів чи нових рядків на один пробіл
        return Regex.Replace(text, @"\s+", " ").Trim();
    }

    private void button4_Click(object sender, EventArgs e)
    {
        Categories.CurrentMainForm.OpenChildForm(new Car_Form(Categories.ChoosenMarkHref), false);
    }

    private async void Models_Form_Load(object sender, EventArgs e)
    {

        await Get_Models_ListAsync(_maker);
    }
}