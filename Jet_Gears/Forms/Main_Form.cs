using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using Jet_Gears.Controls;
using Jet_Gears.DataBases;
using Jet_Gears.Objects;
using Newtonsoft.Json;

namespace Jet_Gears.Forms
{
    public partial class Main_Form : Form
    {
        
        private Animation slideAnimation;
        private Timer animationTimer;

        private readonly DataBase Gears_Base = new DataBase();
        public Main_Form()
        {
            InitializeComponent();
            
            var card = new GearCard();
            Controls.Add(card);
            Console.WriteLine(Categories.CurrUserToken);
            Get_Shelves_List(Categories.CurrUserLogin);
            animationTimer = new Timer
            {
                Interval = 16 // 60 FPS (~16 мс на кадр)
            };
            animationTimer.Tick += OnAnimationTick;
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {
            Categories.CurrentMainForm = this;
        }


        private Form _activeForm;

        public void OpenChildForm(Form childForm, bool useAnimation = true)
        {
            if (_activeForm != null)
            {
                _activeForm.Close();
            }

            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Left = useAnimation ? Width : 0; // Якщо без анімації, одразу ставимо Left = 0
            childForm.Top = 0;
            childForm.Height = panelChildForm.Height;
            childForm.Width = panelChildForm.Width;

            panelChildForm.Controls.Add(childForm);
            panelChildForm.Controls.SetChildIndex(childForm, 0);
            childForm.Show();

            if (useAnimation)
            {
                // Запускаємо анімацію
                slideAnimation = new Animation(
                    "SlideIn",
                    () => childForm.Invalidate(),
                    childForm.Left,
                    0
                );

                animationTimer.Tick += OnAnimationTick;
                animationTimer.Interval = 10;
                animationTimer.Start();
            }
            else
            {
                // Якщо анімація вимкнена, одразу закріплюємо вікно
                _activeForm.Dock = DockStyle.Fill;
            }
        }

        private void OnAnimationTick(object sender, EventArgs e)
        {
            if (slideAnimation.Status != Animation.AnimationStatus.Completed)
            {
                slideAnimation.UpdateFrame();
                _activeForm.Left = (int)slideAnimation.Value;
            }
            else
            {
                animationTimer.Stop();
                animationTimer.Tick -= OnAnimationTick;

                _activeForm.Dock = DockStyle.Fill;
            }
        }
        
        
        

        


        private void Search_Button_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Advanced_Search());
        }

        private void Supply_Button_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Supply_Form());
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Categories.ChoosenCarHref))
            {
                OpenChildForm(new Car_Nodes_Form(Categories.ChoosenCarHref),false);
            }
            else
            {
                OpenChildForm(new Makers_Form(),false);
            }
        }
        
        private void Basket_Button_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Basket_Form());
        }


        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.Ask_Closing(sender,e);
        }

        private void Main_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Shelf_Form());
        }
        
        
        public void Get_Shelves_List(string user_login)
        {
            try
            {
                var connection = Gears_Base.getConnection();
                // Підключення до бази даних
                string querystring = "SELECT Shelves FROM register WHERE login_user = @UserId";

                SqlCommand command = new SqlCommand(querystring, connection);
                command.Parameters.AddWithValue("@UserId", user_login);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string shelvesText = reader["Shelves"].ToString();
                    // Розділення тексту на список за допомогою Split і додавання в List
                    Categories.ShelvesList = shelvesText
                        .Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();  // Перетворюємо масив в List
                
                    // Використовуємо список для подальших дій
                    foreach (string shelf in Categories.ShelvesList)
                    {
                        Console.WriteLine(shelf); // Можна працювати з кожним елементом
                    }
                }
                else
                {
                    MessageBox.Show("Рядок не знайдено.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        
    }
}