using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Jet_Gears.DataBases;

namespace Jet_Gears
{
    public partial class Supply_Form : Form
    {
        byte[] imageData = null;
        public Supply_Form()
        {
            InitializeComponent();
            ChoosePictureLabel.BringToFront();
            ChoosePicturePanel.BringToFront();
            Console.WriteLine(Categories.Curr_User_Token);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase users = new DataBase();
            
            var gear_code = CodeTextBox.Text;
            var count_of = AmountControl.Value;
            var maker = MakerTextbox.Text;
            var price = int.Parse(PriceTextBox.Text);
            var description = DescribtionTextBox.Text;
            var token = Categories.Curr_User_Token;
            
            
            SqlDataAdapter adapter = new SqlDataAdapter();

            DataTable table = new DataTable();
            

            string querystring =
                $"INSERT INTO Gears (gear_code,count_of,maker,price,description,picture,user_Token) VALUES ('{gear_code}','{count_of}','{maker}','{price}','{description}',@ImageData,'{token}')";
            
            SqlCommand command = new SqlCommand(querystring, users.getConnection());
            command.Parameters.AddWithValue("@ImageData", imageData);
            users.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Деталь додана", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }




        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (openPictureDialog)
            {
                // Налаштування фільтра для відображення лише зображень
                openPictureDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";
                openPictureDialog.Title = "Виберіть картинку";

                // Відкриття діалогового вікна
                if (openPictureDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openPictureDialog.FileName;
                    ChoosePictureLabel.Hide();
                    ChoosePicturePanel.Hide();
                    pictureBox1.Image = Image.FromFile(filePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    imageData = File.ReadAllBytes(filePath);
                }
            }
        }
    }
}