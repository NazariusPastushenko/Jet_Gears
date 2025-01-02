using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;
using Jet_Gears.Controls;
using Jet_Gears.DataBases;
using Jet_Gears.Objects;
using Jet_Gears.Parser;
using Jet_Gears.Properties;

namespace Jet_Gears
{
    public partial class Search_Shelf_Form : Form
    {
        private int latest_X_Shelf = 12;
        private int latest_Y_Shelf = 170;
        private DataBase Gears_Base = new DataBase();
        public Search_Shelf_Form()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        private void Search_Panel_Click(object sender, EventArgs e)
        {
            Delete_Cards();
            var Gear_Code = SearchTextBox.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select * from Gears";
            var token = Categories.Curr_User_Token;
            if (Gear_Code != "all"){
                querystring = $"select id,gear_code,count_of,maker,price,description,picture,user_Token from Gears where gear_code = '{Gear_Code}'";
            }


            SqlCommand command = new SqlCommand(querystring, Gears_Base.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 0) {MessageBox.Show("Деталі не знайдено", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information); return;};
            
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
                            Create_Card(int.Parse(id),gearcode, count_of, maker, price, description, image);
                        }
                    }
                    else
                    {
                        Create_Card(int.Parse(id), gearcode, count_of, maker, price, description, null); 
                    }

            }
        }
        
        private void Create_Card(int id,string gearcode, string count_of, string maker, string price, string description, Image image)
        {
            GearCard card = new GearCard();
            card.BorderColor = Color.Black;
            card.RoundedCorners = false;
            card.Location = new Point(latest_X_Shelf, latest_Y_Shelf);
            card.Size = new Size(1170, 60);
            card.NameLabel = gearcode + "    " + maker;
            card.DescriptionLabel = description;
            card.RightBottomImage = Resources._3737369;
            card.PriceLabel = "Ціна: " + price;
            card.RightLabel2Text = "Кількість: " + count_of;
            latest_Y_Shelf = latest_Y_Shelf + 10 + card.Height;
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
            Categories.Busket_Array.Add(clickedCard.Card_object);
            Console.WriteLine("Масив");
            foreach (Gear g in Categories.Busket_Array)
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
            p.Location = new Point(gearCard.Location.X + 50, gearCard.Location.Y + 20);
            p.BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(p);
            Controls.SetChildIndex(p, 0);
            p.Tag = "ZoomPicture";
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
        }
        
        
        
        
        private void Delete_Cards()
        {
            latest_X_Shelf = 12;
             latest_Y_Shelf = 170;
            for (int i = Controls.Count - 1; i >= 0; i--)
            {
                if (Controls[i] is GearCard)
                {
                    Controls.RemoveAt(i);
                }
            }
        }

        private void Search_Form_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
            if (e.KeyCode == Keys.Enter)
            {
                Search_Panel_Click(sender,e);
                
            }
        }
    }
}