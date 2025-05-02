using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Jet_Gears.Controls;
using Jet_Gears.DataBases;
using Jet_Gears.Objects;
using Jet_Gears.Properties;

namespace Jet_Gears.Forms
{
    
    public partial class Search_Shelf_Form : Form
    {
        private int _latestXShelf = 12;
        private int _latestYShelf = 20;
        private int _lastCardI = 0;
        private readonly DataBase _gearsBase = new DataBase();
        private Animation _slideAnimation;
        private readonly Timer _animationTimer;
        public readonly string _shelfTag;
        private readonly Form _parentForm;

        public Search_Shelf_Form(string tag)
        {
            InitializeComponent();
            KeyPreview = true;
            Show_User_Parts(tag);
            _shelfTag = tag;
            _parentForm = this;
            _animationTimer = new Timer
            {
                Interval = 16 // 60 FPS (~16 мс на кадр)
            };
            _animationTimer.Tick += OnAnimationTick;
            KeyPreview = true;
        }

        private void Create_Card(string gearcode, string count_of, string maker, string price, string description,
            Image image)
        {
            GearCard card = new GearCard();
            card.BorderColor = Color.Black;
            card.RoundedCorners = false;
            card.Location = new Point(_latestXShelf, _latestYShelf);
            card.Size = new Size(1170, 60);
            card.NameLabel = gearcode;
            card.link = description;
            card.MainTextSize = 15;
            card.DescriptionLabel = "";
            card.RightTextSize = 15;
            card.PriceLabel = "Ціна: " + price + "\u20B4";
            card.RightLabel2Text = "Кількість: " + count_of;


            card.RightBottomButtonImage = Resources.Pen_Icon;
            card.RightTopButtonImage = Resources.Black_X;
            
            _latestYShelf = _latestYShelf + 10 + card.Height;
            Controls.Add(card);
            if (image == null)
            {
                card.LeftImage = Resources.Picture_Icon;
            }
            else
            {

                card.LeftImage = image;
            }

            card.Card_object = new Shelf_Gear(gearcode, count_of, maker, price, description, image,false);
            card.LeftImageMouseEnter += GearCard_LeftImageMouseEnter;
            card.LeftImageMouseLeave += GearCard_LeftImageMouseLeave;
            card.Click += GearCard_Click;
            card.right_Top_Button_Click += GearDB_Delete;
            card.right_Bottom_Button_Click += GearDB_Edit;
        }

        private void GearDB_Edit(object sender, EventArgs e)
        {
            GearCard card = sender as GearCard;
            OpenChildFormWithAnimation(new Edit_Gear_Form(card.Card_object,_shelfTag));
        }

        private void GearDB_Delete(object sender, EventArgs e)
        {
            GearCard gearCard = sender as GearCard;
            Shelf_Gear gear = gearCard.Card_object;
            string querystring = @"DELETE FROM Gears WHERE user_Token = @Token and gear_code = @Gearcode and price = @Price and count_of = @Count;";

            using SqlCommand command = new SqlCommand(querystring, _gearsBase.getConnection());
            command.Parameters.AddWithValue("@Price", gear.price);
            command.Parameters.AddWithValue("@Gearcode", gear.gearcode);
            command.Parameters.AddWithValue("@Token", Categories.CurrUserToken);
            command.Parameters.AddWithValue("@Count", gear.count_of);

            _gearsBase.openConnection();
            if (command.ExecuteNonQuery() != 1)
            {
                MessageBox.Show("Помилка при видаленні деталі", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Деталь видалено з наявності", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Categories.ShelfGears.RemoveAll(g => g.gearcode == gear.gearcode && g.price == gear.price.ToString() && g.description == gear.description);
            _parentForm.Close();
            if (Categories.ShelfGears.Count != 0)
            {
                Categories.CurrentMainForm.OpenChildForm(new Search_Shelf_Form(_shelfTag),false);
            }
            else
            {
                Categories.CurrentMainForm.OpenChildForm(new Shelf_Form(),false);
            }

        }

        private void GearCard_Click(object sender, EventArgs e)
        {
            GearCard gearCard = sender as GearCard;
            Shelf_Gear item = gearCard.Card_object;
            Shelf_OverviewPart shelfOverviewPart = new Shelf_OverviewPart(item.gearcode, int.Parse(item.count_of), item.maker,
                item.description, item.image, "", item.price.ToString());
            Shelf_OverviewGear_Form overviewGearForm = new Shelf_OverviewGear_Form(shelfOverviewPart,_shelfTag,_parentForm);
            OpenChildFormWithAnimation(overviewGearForm);
        }

        private void GearCard_LeftImageMouseEnter(object sender, EventArgs e)
        {
            GearCard gearCard = sender as GearCard;

            Panel p = new Panel();
            p.BackgroundImage = gearCard.LeftImage;
            p.BackgroundImageLayout = ImageLayout.Stretch;
            p.Size = new Size(300, 300);
            p.Location = new Point(80, 150);

            p.BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(p);
            Controls.SetChildIndex(p, 0);
            p.Tag = "ZoomPicture";
            SuspendLayout();
        }

        private void GearCard_LeftImageMouseLeave(object sender, EventArgs e)
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

        private void Show_User_Parts(string tag)
        {
            Delete_Cards();
            Categories.ShelfGears.Clear();


            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            var token = Categories.CurrUserToken;
            string querystring =
                $"select gear_code,count_of,maker,price,picture,description,user_Token,Shelf_Placement from Gears where user_Token = '{Categories.CurrUserToken}' and Shelf_Placement = '{tag}' AND (Cart IS NULL OR Cart = 0)";



            SqlCommand command = new SqlCommand(querystring, _gearsBase.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 0)
            {
                MessageBox.Show($"Полиця |{tag}| пуста ", "Помилка", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Categories.CurrentMainForm.OpenChildForm(new Shelf_Form(),false);
            }

            ;

            foreach (DataRow row in table.Rows)
            {
                var gearcode = row["gear_code"].ToString();
                var count_of = row["count_of"].ToString();
                var maker = row["maker"].ToString();
                var price = row["price"].ToString();
                var description = row["description"].ToString();

                byte[] imageData = row["picture"] as byte[];
                if (imageData != null)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        Image image = Image.FromStream(ms);
                        Categories.ShelfGears.Add(new Shelf_Gear(gearcode, count_of, maker, price,
                            description, image,false));
                    }
                }
                else
                {
                    Categories.ShelfGears.Add(new Shelf_Gear(gearcode, count_of, maker, price,
                        description, null,false));
                }
            }
            
            Show_Cards(0);
        }

        private void Show_Cards(int start_i)
        {
            if (Categories.ShelfGears.Count > 6)
            {
                LeftArrow_Button.Visible = true;
                RightArrow_Button.Visible = true;
            }
            else
            {
                LeftArrow_Button.Visible = false;
                RightArrow_Button.Visible = false;
            }

            Shelf_Gear item = null;
            Image img = null;
            for (int i = start_i; i <= start_i + 5; i++)
            {
                try
                {
                    item = Categories.ShelfGears[i];
                }
                catch (Exception e)
                {
                    return;
                }

                Create_Card(item.gearcode, item.count_of, item.maker, item.price, item.description, item.image);
            }
        }

        private void Delete_Cards()
        {
            _latestXShelf = 12;
            _latestYShelf = 20;
            for (int i = Controls.Count - 1; i >= 0; i--)
            {
                if (Controls[i] is GearCard)
                {
                    Controls.RemoveAt(i);
                }
            }
        }

        private void LeftArrow_Button_Click(object sender, EventArgs e)
        {
            if (_lastCardI == 0)
            {
                return;
            }
            else
            {
                _lastCardI -= 6;
            }

            Delete_Cards();
            Show_Cards(_lastCardI);
        }

        private void RightArrow_Button_Click(object sender, EventArgs e)
        {
            _lastCardI += 6;
            if (_lastCardI > Categories.ShelfGears.Count)
            {
                _lastCardI -= 6;
                return;

            }

            Delete_Cards();
            Show_Cards(_lastCardI);
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
    }
}