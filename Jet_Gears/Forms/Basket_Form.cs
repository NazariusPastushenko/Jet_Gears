using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Jet_Gears.Controls;
using Jet_Gears.DataBases;
using Jet_Gears.Forms;
using Jet_Gears.Objects;
using Jet_Gears.Properties;

namespace Jet_Gears
{
    public partial class Basket_Form : Form
    {
        private readonly DataBase Gears_Base = new DataBase();
        
        private Animation _slideAnimation;
        private readonly Timer _animationTimer;
        private byte[] New_Image;
        private int latest_X = 5;
        private int latest_Y = 5;
        int sellCount;
        int sellPrice;
        
        
        

        public Basket_Form()
        {
            InitializeComponent();
            Load_Busket_Gears();
            Clear_Busket_Cards();
            Create_Busket_Cards();
            Refresh_Price();
            _animationTimer = new Timer
            {
                Interval = 16 // 60 FPS (~16 мс на кадр)
            };
            _animationTimer.Tick += OnAnimationTick;
            KeyPreview = true;
        }
        
        public void Refresh_Price()
        {
            sellCount = 0;
            sellPrice = 0;
            foreach (Shelf_Gear g in Categories.BusketArray)
            {
                if (g.Check)
                {
                    sellCount++;
                    sellPrice += int.Parse(g.price);
                }
            }

            Price_Label.Text = $"Буде продано {sellCount} одиниць на суму {sellPrice} \u20B4.";
        }
        

        private void Load_Busket_Gears()
        {
            Categories.BusketArray.Clear();


            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            var token = Categories.CurrUserToken;
            string querystring =
                $"select gear_code,count_of,maker,price,picture,description,user_Token,Shelf_Placement,Checked from Gears where user_Token = @currentLogin and Cart = 1";


            SqlCommand command = new SqlCommand(querystring, Gears_Base.getConnection());

            command.Parameters.AddWithValue("@currentLogin", Categories.CurrUserToken);


            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 0)
            {
                MessageBox.Show($"Кошик пустий", "Помилка", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            ;

            foreach (DataRow row in table.Rows)
            {
                var gearcode = row["gear_code"].ToString();
                var count_of = row["count_of"].ToString();
                var maker = row["maker"].ToString();
                var price = row["price"].ToString();
                var description = row["description"].ToString();
                var check = row["Checked"].ToString();

                // ReSharper disable once ReplaceWithSingleAssignment.True
                bool GearChecked = true;
                
                if (check == "False")
                {
                    GearChecked = false;
                }


                if (row["picture"] is byte[] imageData)
                {
                    using MemoryStream ms = new MemoryStream(imageData);
                    Image image = Image.FromStream(ms);
                    Categories.BusketArray.Add(new Shelf_Gear(gearcode, count_of, maker, price,
                        description, image,GearChecked));
                }
                else
                {
                    Categories.BusketArray.Add(new Shelf_Gear(gearcode, count_of, maker, price,
                        description, null,GearChecked));
                }
            }
            
        }

        public void Clear_Busket_Cards()
        {
            Card_Panel.Controls.Clear();
        }
        private void Create_Busket_Cards()
        {
            foreach (Shelf_Gear busketGear in Categories.BusketArray)
            {
                BusketCard card = new BusketCard();
                card.Card_Gear = busketGear;
                card.BorderColor = Color.Black;
                card.RoundedCorners = false;
                card.Location = new Point(latest_X, latest_Y);
                card.Size = new Size(1170, 65);
                card.DescriptionLabel = "";
                card.NameLabel = busketGear.gearcode + "    " + busketGear.maker;
                card.PriceLabel = "Ціна: " + busketGear.price+"\u20B4";
                card.RightLabel2Text = "Кількість: " + busketGear.count_of;

                card.MainTextSize = 15;
                card.RightTextSize = 15;
                
                card.BottomButton.BackgroundImage = Resources.Pen_Icon;
                card.TopButton.BackgroundImage = Resources.Black_X;

                card.TopButton.Location = new Point(card.Width - card.TopButton.Width-5,2);
                card.BottomButton.Location = new Point(card.Width - card.BottomButton.Width-5,card.TopButton.Height + 2);
                card.TopButton.BackgroundImageLayout = ImageLayout.Zoom;
                card.BottomButton.BackgroundImageLayout = ImageLayout.Zoom;
                latest_Y = latest_Y + 10 + card.Height;
                
                if (busketGear.image == null)
                {
                    card.LeftImage = Resources.Picture_Icon;
                    
                }
                else
                {
                    card.LeftImage = busketGear.image;
                }

                if (card.Card_Gear.Check)
                {
                    
                    card.Is_Checked = true;
                }
                else
                {
                    card.Is_Checked = false;
                }
                
                card.LeftImageMouseEnter += BusketCard_LeftImageMouseEnter;
                card.LeftImageMouseLeave += BusketCard_LeftImageMouseLeave;
                card.CheckBoxClicked += Part_Checked;
                card.Click += Card_View;
                card.TopButtonClicked += Gear_Delete;
                card.BottomButtonClicked += Gear_Edit;
                Card_Panel.Controls.Add(card);
            }
            
        }

        private void Card_View(object sender, EventArgs e)
        {
            BusketCard gearCard = sender as BusketCard;
            Shelf_Gear item = gearCard.Card_Gear;
            Shelf_OverviewPart shelfOverviewPart = new Shelf_OverviewPart(item.gearcode, int.Parse(item.count_of), item.maker,
                item.description, item.image, "", item.price.ToString());
            Shelf_OverviewGear_Form overviewGearForm = new Shelf_OverviewGear_Form(shelfOverviewPart,null,null);
            OpenChildFormWithAnimation(overviewGearForm);
        }

        private void Gear_Edit(object sender, EventArgs e)
        {
            BusketCard card = sender as BusketCard;
            OpenChildFormWithAnimation(new Edit_Gear_Form(card.Card_Gear,null));
        }

        private void Gear_Delete(object sender, EventArgs e)
        {
            try
            {

            
            BusketCard busketCard = sender as BusketCard;
            Shelf_Gear gear = busketCard.Card_Gear;
            string querystring = @"DELETE FROM Gears WHERE user_Token = @Token and gear_code = @Gearcode and price = @Price and count_of = @Count;";

            using SqlCommand command = new SqlCommand(querystring, Gears_Base.getConnection());
            command.Parameters.AddWithValue("@Price", gear.price);
            command.Parameters.AddWithValue("@Gearcode", gear.gearcode);
            command.Parameters.AddWithValue("@Token", Categories.CurrUserToken);
            command.Parameters.AddWithValue("@Count", gear.count_of);

            Gears_Base.openConnection();
            command.ExecuteNonQuery();
            MessageBox.Show("Деталь видалено з наявності", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Categories.ShelfGears.RemoveAll(g => g.gearcode == gear.gearcode && g.price == gear.price.ToString() && g.description == gear.description);
            Categories.CurrentMainForm.OpenChildForm(new Basket_Form(),false);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Помилка при видаленні деталі" + exception, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void Part_Checked(object sender, EventArgs e)
        {
            BusketCard Card = sender as BusketCard;
            Shelf_Gear gear = Card.Card_Gear;

            int check = Card.Is_Checked ? 1 : 0;

            // Перевіряємо, чи змінився статус (змінено з попереднього значення)
            if (gear.Check != Card.Is_Checked)
            {
                string querystring = @"UPDATE Gears SET Checked = @checked WHERE gear_code = @Gearcode and user_Token = @Token;";

                using SqlCommand command = new SqlCommand(querystring, Gears_Base.getConnection());
                command.Parameters.AddWithValue("@checked", check);
                command.Parameters.AddWithValue("@Gearcode", gear.gearcode);
                command.Parameters.AddWithValue("@Token", Categories.CurrUserToken);

                Gears_Base.openConnection();
                if (command.ExecuteNonQuery() != 1)
                {
                    MessageBox.Show("Помилка при додаванні деталі", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Оновлюємо місцевий стан Gear після виконання запиту
                gear.Check = Card.Is_Checked;
            }
            Refresh_Price();
        }


        private void BusketCard_LeftImageMouseEnter(object sender, EventArgs e)
        {
            BusketCard BusketCard = sender as BusketCard;

            Panel p = new Panel();
            p.BackgroundImage = BusketCard.LeftImage;
            p.BackgroundImageLayout = ImageLayout.Stretch;
            p.Size = new Size(300, 300);
            p.Location = new Point(80, 150);

            p.BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(p);
            Controls.SetChildIndex(p, 0);
            p.Tag = "ZoomPicture";
            SuspendLayout();
        }

        private void BusketCard_LeftImageMouseLeave(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (c.Tag == "ZoomPicture")
                {
                    Controls.Remove(c);
                }
            }

            ResumeLayout();
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

            _slideAnimation = new Animation(
                "SlideIn",
                () => childForm.Invalidate(),
                childForm.Left,
                Width - childForm.Width
            );

            _animationTimer.Start();
            childForm.Show();
        }
        
        private void OnAnimationTick(object sender, EventArgs e)
        {
            if (_slideAnimation.Status != Animation.AnimationStatus.Completed)
            {
                _slideAnimation.UpdateFrame();
                activeForm.Left = (int)_slideAnimation.Value;
            }
            else
            {
                _animationTimer.Stop();
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                Load_Busket_Gears();

                List<Shelf_Gear> selectedGears = Categories.BusketArray.Where(g => g.Check).ToList();
                if (selectedGears.Count == 0) return;

                var totalPrice = selectedGears.Sum(g => int.Parse(g.price)).ToString();

// 1. Додаємо замовлення в Orders
                string insertOrderQuery =
                    "INSERT INTO Orders (Date, Price, User_Token) OUTPUT INSERTED.Order_Id VALUES (@Date, @Price, @UserToken)";
                int orderId = -1;

                using (SqlCommand cmd = new SqlCommand(insertOrderQuery, Gears_Base.getConnection()))
                {
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Price", totalPrice);
                    cmd.Parameters.AddWithValue("@UserToken", Categories.CurrUserToken);

                    Gears_Base.openConnection();
                    var result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("Помилка при створенні замовлення", "Помилка", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    orderId = (int)result;
                }

                // 2. Додаємо кожну деталь у OrderDetails
                foreach (var gear in selectedGears)
                {
                    const string insertDetailQuery = @"INSERT INTO OrderDetails 
                (OrderID, GearCode, Maker, CountOf, Price, Description, Picture)
                VALUES (@OrderID, @GearCode, @Maker, @CountOf, @Price, @Description, @Picture)";

                    using SqlCommand cmd = new SqlCommand(insertDetailQuery, Gears_Base.getConnection());
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    cmd.Parameters.AddWithValue("@GearCode", gear.gearcode);
                    cmd.Parameters.AddWithValue("@Maker", gear.maker);
                    cmd.Parameters.AddWithValue("@CountOf", int.Parse(gear.count_of));
                    cmd.Parameters.AddWithValue("@Price", int.Parse(gear.price));
                    cmd.Parameters.AddWithValue("@Description", gear.description);

                    // Конвертуємо картинку у byte[]
                    if (gear.image != null)
                    {
                        Bitmap bmp = new Bitmap(gear.image); // Копія, уникнення блокування файлу
                        ImageConverter converter = new ImageConverter();
                        New_Image = (byte[])converter.ConvertTo(bmp, typeof(byte[]));

                    }

                    cmd.Parameters.AddWithValue("@Picture", New_Image.ToArray());


                    Gears_Base.openConnection();
                    cmd.ExecuteNonQuery();
                }

                // 3. Видаляємо кожну деталь з бази деталей
                foreach (var gear in selectedGears)
                {
                    const string insertDetailQuery = @"DELETE FROM Gears WHERE 
                      user_Token = @Token and gear_code = @GearCode and price = @Price and Description = @Description";

                    using SqlCommand cmd = new SqlCommand(insertDetailQuery, Gears_Base.getConnection());
                    cmd.Parameters.AddWithValue("@GearCode", gear.gearcode);
                    cmd.Parameters.AddWithValue("@Token", Categories.CurrUserToken);
                    cmd.Parameters.AddWithValue("@Price", int.Parse(gear.price));
                    cmd.Parameters.AddWithValue("@Description", gear.description);

                    // Конвертуємо картинку у byte[]
                    if (gear.image != null)
                    {
                        Bitmap bmp = new Bitmap(gear.image); // Копія, уникнення блокування файлу
                        ImageConverter converter = new ImageConverter();
                        New_Image = (byte[])converter.ConvertTo(bmp, typeof(byte[]));

                    }

                    cmd.Parameters.AddWithValue("@Picture", New_Image.ToArray());


                    Gears_Base.openConnection();
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                MessageBox.Show($"Помилка при продажу деталей", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(
                $"Продаж успішний!\nБуло продано {sellCount} одиниць товару на сумму {sellPrice}.",
                "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
            Categories.CurrentMainForm.OpenChildForm(new Basket_Form(), false);
        }
    }
}