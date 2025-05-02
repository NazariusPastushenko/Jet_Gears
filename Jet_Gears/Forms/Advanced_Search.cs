using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Jet_Gears.Controls;
using Jet_Gears.Objects;
using Jet_Gears.Parser;
using Jet_Gears.Properties;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Text;
using Jet_Gears.DataBases;
using Jet_Gears.Forms;

namespace Jet_Gears
{
    public partial class Advanced_Search : Form
    {
        private Animation slideAnimation;
        private Timer animationTimer;
        private byte[] imageBytes {get; set;}

        public Advanced_Search()
        {
            InitializeComponent();
            
            animationTimer = new Timer
            {
                Interval = 16 // 60 FPS (~16 мс на кадр)
            };
            animationTimer.Tick += OnAnimationTick;
            KeyPreview = true;
        }

        private void Advanced_Search_Load(object sender, EventArgs e)
        {
            Show_Cards(0);
        }

        private int last_card_i = 0;
        public int latest_x_Search = 30;
        public int latest_y_Search = 125;

        private async void Advance_Search_Button_Click(object sender, EventArgs e)
        {
            // Видаляємо попередні картки
            Delete_Cards();
            // Показуємо лоадінг-екран
            using (var loadingForm = new Loading_Form()) // Лоадінг-екран
            {
                loadingForm.BackColor = Color.FromArgb(123, 144, 75);
                loadingForm.Show();
                loadingForm.Refresh();
                await Task.Delay(100); // Додатковий час для оновлення UI

                
                await InitialSearchZvukAsync(Advanced_Search_TextBox.Text, "");
                // Виконуємо пошук
                Show_Cards(0);
                    
                    
                loadingForm.Close();

                if (Categories.SearchGears.Count == 0) 
                {
                    MessageBox.Show("Деталі не знайдено", "Помилка", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }

        private async Task InitialSearchAsync(string searchText, string additionalParam)
        {
            // Ваш метод Initial_Search, який виконується асинхронно
            await Task.Run(() => InitialSearch.Initial_Search(searchText, additionalParam));
        }
        
        private async Task InitialSearchZvukAsync(string searchText, string additionalParam)
        {
            // Ваш метод Initial_Search, який виконується асинхронно
            await Task.Run(() => InitialSearch_AvtoZvuk.Initial_Search_Zvuk(searchText,""));
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
            card.RightBottomButtonImage = Resources._3737369;
            card.PriceLabel = "Ціна: " + price;
            card.RightLabel2Text = "Корзина: ";
            card.RightBottomButtonSize = new Size(25, 25);
            latest_y_Search = latest_y_Search + 10 + card.Height;
            Controls.Add(card);
            if (image == null)
            {
                card.LeftImage = Resources.Picture_Icon;
            }
            else
            {
                card.LeftImage = image;
            }
            card.LeftImageMouseEnter += Search_Card_LeftImageMouseEnter;
            card.LeftImageMouseLeave += Search_Card_LeftImageMouseLeave;
            card.right_Bottom_Button_Click += Search_Card_AddToCart;

            if (link.Contains("zvuk"))
            {
                card.Click += Search_CardZvuk_Click;
            }
            else
            {
                card.Click += Search_Card_Click;
            }
        }

        private void Search_Card_AddToCart(object sender, EventArgs e)
        {
            GearCard gearCard = sender as GearCard;
            Part_Search_By_Code_Parse.PartZvuk_URL_Search(gearCard.link);
            Ask_Amount_ToCart toCartForm = new Ask_Amount_ToCart();
            toCartForm.StartPosition = FormStartPosition.CenterScreen;
            toCartForm.Show();
        }

        private void Search_Card_Click(object sender, EventArgs e)
        {
            GearCard gearCard = sender as GearCard;
        }
        
        private void Search_CardZvuk_Click(object sender, EventArgs e)
        {
            GearCard gearCard = sender as GearCard;
            Part_Search_By_Code_Parse.PartZvuk_URL_Search(gearCard.link);
            Search_Part_Overview overviewForm = new Search_Part_Overview();

            OpenChildFormWithAnimation(overviewForm);
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
            for (int i = start_i; i <= start_i + 5; i++)
            {
                try
                {
                    item = Categories.SearchGears[i];
                }
                catch (Exception e)
                {
                    return;
                }
                if (Categories.SearchGears[i].ImgURL != null)
                {

                    img = await LoadImageFromUrlAsync(Categories.SearchGears[i].ImgURL);
                }
                Create_Search_Card(item.title, item.price, item.description, img, item.title_link);
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
            if (last_card_i > Categories.SearchGears.Count)
            {
                last_card_i -= 6;
                return;

            }
            Delete_Cards();
            Show_Cards(last_card_i);
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
        

        private void Advanced_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Advance_Search_Button_Click(sender,e);
            }
        }
    }
}
