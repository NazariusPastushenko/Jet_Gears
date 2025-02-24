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
        private readonly DataBase Gears_Base = new DataBase();
        public Search_Shelf_Form(string tag)
        {
            InitializeComponent();
            KeyPreview = true;
            Show_User_Parts(tag);
        }

        

        private void Create_Card(int id,string gearcode, string count_of, string maker, string price, string description, Image image)
        {
            GearCard card = new GearCard();
            card.BorderColor = Color.Black;
            card.RoundedCorners = false;
            card.Location = new Point(_latestXShelf, _latestYShelf);
            card.Size = new Size(1170, 60);
            card.NameLabel = gearcode + "    " + maker;
            card.DescriptionLabel = description;
            card.RightBottomImage = Resources._3737369;
            card.MainTextSize = 15;
            card.RightTextSize = 15;
            card.PriceLabel = "Ціна: " + price;
            card.RightLabel2Text = "Кількість: " + count_of;
            _latestYShelf = _latestYShelf + 10 + card.Height;
            Controls.Add(card);
            if (image == null)
            {
                card.LeftImage = Resources.Picture_Icon;}
            else
            {

                card.LeftImage = image;
            }

            card.Card_object = new Gear(id, gearcode, int.Parse(count_of), maker, int.Parse(price), description, image);
            card.LeftImageMouseEnter += GearCard_LeftImageMouseEnter;
            card.LeftImageMouseLeave += GearCard_LeftImageMouseLeave;
            card.BusketIcon_ImageClick += BusketIcon_Click;
        }

        private void BusketIcon_Click(object sender, EventArgs e)
        {
            GearCard clickedCard = sender as GearCard;
            Categories.BusketArray.Add(clickedCard.Card_object);
            Console.WriteLine("Масив");
            foreach (Gear g in Categories.BusketArray)
            {
                Console.WriteLine(g);
            }
            
            
            
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
            string querystring = $"select id,gear_code,count_of,maker,price,description,picture,user_Token,Shelf_Placement from Gears where user_Token = '{Categories.CurrUserToken}' and Shelf_Placement = '{tag}'";
   


            SqlCommand command = new SqlCommand(querystring, Gears_Base.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 0) {
                MessageBox.Show($"Полиця |{tag}| пуста ", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                
            };
            
            foreach (DataRow row in table.Rows)
            {
                var id = row["id"].ToString();
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
                        Categories.ShelfGears.Add(new Shelf_Gear(int.Parse(id),gearcode, count_of, maker, price, description, image));
                    }
                }
                else
                {
                    Categories.ShelfGears.Add(new Shelf_Gear(int.Parse(id),gearcode, count_of, maker, price, description, null));
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
            for (int i = start_i; i <= start_i+5; i++)
            {
                try
                {
                    item = Categories.ShelfGears[i];
                }
                catch (Exception e)
                {
                    return;
                }
                Create_Card(item.id,item.gearcode,item.count_of,item.maker,item.price,item.description,item.image);
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
    }
}