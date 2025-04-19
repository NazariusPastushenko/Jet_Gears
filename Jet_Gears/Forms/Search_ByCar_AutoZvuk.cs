using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using Jet_Gears.Controls;
using Jet_Gears.Objects;

namespace Jet_Gears.Forms;

public partial class Search_ByCar_AutoZvuk : Form
{
    
    private Animation slideAnimation;
    private Timer animationTimer;
    private Point Current_Location = new Point(5, 5);
    private Label Loading_Label = new Label();
    

    
    public Search_ByCar_AutoZvuk()
    {
        InitializeComponent();
        Get_Makers();
        animationTimer = new Timer
        {
            Interval = 16 // 60 FPS (~16 мс на кадр)
        };
        animationTimer.Tick += OnAnimationTick;

        Loading_Label.Font = new Font("Bahnschrift SemiBold SemiConden", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        Loading_Label.Text = "Завантаження";
        Loading_Label.Location = new Point(486, 210);
        Loading_Label.Size = new Size(179, 35);
    }
    
        
    private async void Get_Makers()
    {
        Clean_Buttons();
        Buttons_Panel.Controls.Add(Loading_Label);
        Loading_Label.Visible = true;              // показуємо індикатор
        Loading_Label.BringToFront();              // виводимо на передній план
        await Task.Delay(50);                      // щоб UI встиг перемалюватися
        
        
        Categories.Auto_Zvuk_Makers.Clear();

        try
        {
            string url = "https://avtozvuk.ua/ua";
            var web = new HtmlWeb();

            var document = await Task.Run(() => web.Load(url)); // парсимо в потоці

            var makerNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'autoselection-manufacturers__item')]");

            if (makerNodes != null)
            {
                foreach (var node in makerNodes)
                {
                    var aTag = node.SelectSingleNode(".//a[contains(@class, 'autoselection-manufacturers__link')]");
                    var imageTag = aTag?.SelectSingleNode(".//img");
                    var nameTag = aTag?.SelectSingleNode(".//span[contains(@class, 'autoselection-manufacturers__link-text')]");

                    var Link = "https://avtozvuk.ua" + aTag?.GetAttributeValue("href", "").Trim();
                    var ImageUrl = "https://avtozvuk.ua" + imageTag?.GetAttributeValue("src", "").Trim();
                    var Name = nameTag?.InnerText.Trim();

                    Console.WriteLine($"{Link} ---- {ImageUrl} ---- {Name}");
                    
                    Categories.Auto_Zvuk_Makers.Add(new AutoZvuk_Maker(Link, Name, ImageUrl));
                }
                Write_Makers_Buttons(); 
            }
        }
        catch
        {
            MessageBox.Show("Помилка, перезапустіть сторінку", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        finally
        {
            Loading_Label.Visible = false; // ховаємо індикатор у будь-якому випадку
        }
    }

    
    private void Clean_Buttons()
    {
        Buttons_Panel.Controls.Clear();
        
    }
    private void Write_Makers_Buttons()
    {
        Clean_Buttons();
        Current_Location = new Point(5, 5);
        int i = 1;
        foreach (var model in Categories.Auto_Zvuk_Makers)
        {
            ImageTextButton b = new ImageTextButton();
            b.Location = Current_Location;
            b.Text = model.Title;
            b.Name = model.Href;
            b.ImageUrl = model.ImgLink;
            b.BackColor = Color.FromArgb(0, 36, 0);
            b.ForeColor = Color.Azure;
            b.Font = new Font("Bahnschrift SemiBold SemiConden", 15, FontStyle.Bold);
            b.Size = new Size(387, 120);
            Buttons_Panel.Controls.Add(b);
            b.Click += Get_Models;
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
    
    private async void Get_Models(object sender, EventArgs e)
    {
        ImageTextButton b = sender as ImageTextButton;
        Clean_Buttons();
        Buttons_Panel.Controls.Add(Loading_Label);
        Loading_Label.Visible = true;              // показуємо індикатор
        Loading_Label.BringToFront();              // виводимо на передній план
        await Task.Delay(50);                      // щоб UI встиг перемалюватися
        Categories.Auto_Zvuk_Models.Clear();
        try
        {
            string url = b.Name;
            var web = new HtmlWeb();

            var document = await Task.Run(() => web.Load(url));
            var modelNodes = document.DocumentNode.SelectNodes("//a[contains(@class, 'models-list__link')]");

            if (modelNodes != null)
            {
                foreach (var node in modelNodes)
                {
                    var href = "https://avtozvuk.ua" + node.GetAttributeValue("href", "").Trim();
                    var nameNode = node.SelectSingleNode(".//span[contains(@class, 'models-list__link-name')]");
                    var name = nameNode?.InnerText.Trim();

                    if (!string.IsNullOrEmpty(href) && !string.IsNullOrEmpty(name))
                    {
                        Console.WriteLine($"Посилання:{href} Назва:{name}");
                        Categories.Auto_Zvuk_Models.Add(new AutoZvuk_Model(href, name));
                    }
                }
            }

            Write_Models_Buttons();

        }
        catch
        {
            MessageBox.Show("Помилка, перезапустіть сторінку", "Помилка", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        finally
        {
            Loading_Label.Visible = false; // ховаємо індикатор у будь-якому випадку
        }
    }
    
    
    private void Write_Models_Buttons()
    {
        Clean_Buttons();
        Current_Location = new Point(5, 5);
        int i = 1;
        foreach (var model in Categories.Auto_Zvuk_Models)
        {
            ImageTextButton b = new ImageTextButton();
            b.Location = Current_Location;
            b.Text = model.Title;
            b.Name = model.Href;
            b.ImageUrl = "";
            b.BackColor = Color.FromArgb(0, 36, 0);
            b.ForeColor = Color.Azure;
            b.Font = new Font("Bahnschrift SemiBold SemiConden", 15, FontStyle.Bold);
            b.Size = new Size(387, 120);
            Buttons_Panel.Controls.Add(b);
            b.Click += Get_Nodes;
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
    
    
    private async void Get_Nodes(object sender, EventArgs e)
    {
        ImageTextButton b = sender as ImageTextButton;
        Clean_Buttons();
        Buttons_Panel.Controls.Add(Loading_Label);
        Loading_Label.Visible = true;              // показуємо індикатор
        Loading_Label.BringToFront();              // виводимо на передній план
        await Task.Delay(50);               
        Categories.Auto_Zvuk_Nodes.Clear();
        try
        {
            string url = b.Name;
            var web = new HtmlWeb();

            var document = await Task.Run(() => web.Load(url));
            var categoryNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'categories-wrap__item')]");
            if (categoryNodes == null)
            {
                Console.WriteLine("Категорії не знайдено.");
                return;
            }

            foreach (var category in categoryNodes)
            {
                // Назва вузла
                var title = category.SelectSingleNode(".//h3[contains(@class, 'category-list__title')]")?.InnerText.Trim();

                // Зображення вузла
                var categoryImage = category.SelectSingleNode(".//div[contains(@class, 'category-list__image-wrap')]//img")?
                    .GetAttributeValue("src", "").Trim();

                Console.WriteLine($"🔧 Вузол: {title}");
                Console.WriteLine($"📷 Зображення вузла: {categoryImage}");
                AvtoZvuk_Node Node = new AvtoZvuk_Node(title, categoryImage);

                // Деталі всередині вузла
                var partNodes = category.SelectNodes(".//li[contains(@class, 'category-list__item')]");
                if (partNodes != null)
                {
                    foreach (var part in partNodes)
                    {
                        var partName = part.SelectSingleNode(".//div[contains(@class, 'category-list__item-name')]")?.InnerText.Trim();
                        var partImage = part.SelectSingleNode(".//img[contains(@class, 'category-list__item-image')]")?
                            .GetAttributeValue("src", "").Trim();
                        var partHref = "https://avtozvuk.ua" + part.SelectSingleNode(".//a[contains(@class, 'category-list__item-link')]")?
                            .GetAttributeValue("href", "").Trim();

                        Console.WriteLine($"  🔹 Назва деталі: {partName}");
                        Console.WriteLine($"     🌐 Посилання: {partHref}");
                        Console.WriteLine($"     🖼 Зображення: {partImage}");
                        Node.Parts.Add(new AvtoZvuk_Node.PartItem(partName,partImage,partHref));
                    }
                }
                Categories.Auto_Zvuk_Nodes.Add(Node);
                Console.WriteLine(new string('-', 60));
            }
            Write_Nodes_Buttons();
        } catch {
            MessageBox.Show("Помилка, перезапустіть сторінку", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        } finally
        {
            Loading_Label.Visible = false; // ховаємо індикатор у будь-якому випадку
        }
    }
    
    private void Write_Nodes_Buttons()
    {
        Clean_Buttons();
        Current_Location = new Point(5, 5);
        int i = 1;
        foreach (var node in Categories.Auto_Zvuk_Nodes)
        {
            if (node.Parts.Count == 0){continue;}
            ImageTextButton b = new ImageTextButton();
            b.Location = Current_Location;
            b.Text = node.Title;
            b.Name = node.Title;
            b.ImageUrl = node.CategoryImageUrl;
            b.ImageSize = new Size(150, 150);
            b.BackColor = Color.FromArgb(0, 36, 0);
            b.ForeColor = Color.Azure;
            b.Font = new Font("Bahnschrift SemiBold SemiConden", 15, FontStyle.Bold);
            b.Size = new Size(387, 120);
            b.Click += Open_Car_Nodes;
            Buttons_Panel.Controls.Add(b);
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
        foreach (var node in Categories.Auto_Zvuk_Nodes)
        {
            if (node.Title == b.Name)
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
}