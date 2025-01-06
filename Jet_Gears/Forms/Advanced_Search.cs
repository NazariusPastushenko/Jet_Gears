using System;
using System.Drawing;
using System.Windows.Forms;
using Jet_Gears.Controls;
using Jet_Gears.Objects;
using Jet_Gears.Parser;
using Jet_Gears.Properties;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace Jet_Gears
{
    public partial class Advanced_Search : Form
    {
        
        public Advanced_Search()
        {
            InitializeComponent();
        }
        
        
        private void Advanced_Search_Load(object sender, EventArgs e)
        {
            Show_Cards(0);
            Child_Form_Panel.Hide();
        }

        private int last_card_i = 0;
        public int latest_x_Search = 30;
        public int latest_y_Search = 125;

        private async void Advance_Search_Button_Click(object sender, EventArgs e)
        {
            Delete_Cards();
            InitialSearch.Initial_Search(Advanced_Search_TextBox.Text);
            Show_Cards(0);
        }

        private void Create_Search_Card(string gearcode, string price, string description, Image image, string link)
        {
            GearCard card = new GearCard();
            card.link = link;
            card.Anchor = AnchorStyles.Left;
            card.BorderColor = Color.Black;
            card.RoundedCorners = false;
            card.Location = new Point(latest_x_Search, latest_y_Search);
            card.Size = new Size(1150, 60);
            card.NameLabel = gearcode;
            card.MainTextSize = 15;
            card.RightTextSize = 15;
            card.DescriptionLabel = description;
            card.RightBottomImage = Resources._3737369;
            card.PriceLabel = "Ціна: " + price + "\u20b4";
            card.RightLabel2Text = "";
            latest_y_Search = latest_y_Search + 10 + card.Height;
            Controls.Add(card);
            if (image == null)
            {
                card.LeftImage = Resources.Picture_Icon;}
            else
            {

                card.LeftImage = image;
            }
            card.LeftImageMouseEnter += Search_Card_LeftImageMouseEnter;
            card.LeftImageMouseLeave += Search_Card_LeftImageMouseLeave;
            card.Click += Search_Card_Click;
        }
        
        private void Search_Card_Click(object sender, EventArgs e)
        {
            GearCard gearCard = sender as GearCard;
            Search_Part_Overview overview_form = new Search_Part_Overview(Part_Search_By_Code_Parse.Part_URL_Search(gearCard.link));
            
            openChildForm(overview_form);

        }
        
        
        private void Search_Card_LeftImageMouseEnter(object sender, EventArgs e)
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
        
        private void Search_Card_LeftImageMouseLeave(object sender, EventArgs e)
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
        
        private async void Show_Cards(int start_i)
        {
            Search_Gear item = null;
            Image img = null;
            for (int i = start_i; i <= start_i+5; i++)
            {
                try
                {
                    item = Categories.Search_Gears[i];
                }
                catch (Exception e)
                {
                    return;
                }
                if (Categories.Search_Gears[i].ImgURL != null)
                {
                    
                    img = await LoadImageFromUrlAsync(Categories.Search_Gears[i].ImgURL);
                }
                Create_Search_Card(item.title,item.price,item.description,img,item.title_link);
            }
        }
        private void Delete_Cards()
        {
            latest_x_Search = 30;
            latest_y_Search = 125;
            for (int i = Controls.Count - 1; i >= 0; i--)
            {
                if (Controls[i] is GearCard)
                {
                    Controls.RemoveAt(i);
                }
            }
        }
        
        
        private async Task<Image> LoadImageFromUrlAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                using (Stream stream = await response.Content.ReadAsStreamAsync())
                {
                    return Image.FromStream(stream);
                }
            }
        }


        private void LeftArrow_Button_Click(object sender, EventArgs e)
        {
            if (last_card_i == 0)
            {
                return;
            }
            else
            {
                last_card_i -= 6;
            }
            Delete_Cards();
            Show_Cards(last_card_i);
        }

        private void RightArrow_Button_Click(object sender, EventArgs e)
        {
            last_card_i += 6;
            if (last_card_i > Categories.Search_Gears.Count)
            {
                last_card_i -= 6;
                return;
                
            }
            Delete_Cards();
            Show_Cards(last_card_i);
        }
        
        private Form activeForm = null;
        public void openChildForm(Form childform)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childform;
            
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            Child_Form_Panel.Controls.Clear();


            Child_Form_Panel.Controls.Add(childform);
            Child_Form_Panel.Tag = childform;
            
            childform.BringToFront();
            Child_Form_Panel.Show();
            childform.Show();

            
        }
        }
}