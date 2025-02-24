using System;
using System.Drawing;
using System.Windows.Forms;
using Jet_Gears.Controls;
using Jet_Gears.Objects;
using Jet_Gears.Properties;

namespace Jet_Gears
{
    public partial class Basket_Form : Form
    {
        private int latest_X = 12;
        private int latest_Y = 88;
        public Basket_Form()
        {
            InitializeComponent();
        }
        
        
        private void Create_Busket_Card(int id,string gearcode, string count_of, string maker, string price, string description, Image image)
        {
            BusketCard card = new BusketCard();
            card.BorderColor = Color.Black;
            card.RoundedCorners = false;
            card.Location = new Point(latest_X, latest_Y);
            card.Size = new Size(1170, 60);
            card.NameLabel = gearcode + "    " + maker;
            card.DescriptionLabel = description;
            card.PriceLabel = "Ціна: " + price;
            card.RightLabel2Text = "Кількість: " + count_of;
            latest_Y = latest_Y + 10 + card.Height;
            
            if (image == null)
            {
                card.LeftImage = Resources.Picture_Icon;}
            else
            {

                card.LeftImage = image;
            }
            Controls.Add(card);
        }

        private void Basket_Form_Load(object sender, EventArgs e)
        {
            foreach (Gear g in Categories.BusketArray)
            {
                Create_Busket_Card(g.id,g.gear_code,g.count_of.ToString(),g.maker,g.price.ToString(),g.description,g.picture);   
            }
        }
    }
}