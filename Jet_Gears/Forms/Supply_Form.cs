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
    try
    {
        DataBase users = new DataBase();
        
        // Отримання значень з форми
        string gear_code = CodeTextBox.Text;
        int count_of = (int)AmountControl.Value;
        string maker = MakerTextbox.Text;
        decimal price = decimal.Parse(PriceTextBox.Text);
        string description = DescribtionTextBox.Text;
        string token = Categories.Curr_User_Token;

        // Запит з параметрами
        string querystring = @"
            INSERT INTO Gears (gear_code, count_of, maker, price, description, picture, user_Token) 
            VALUES (@GearCode, @CountOf, @Maker, @Price, @Description, @ImageData, @UserToken)";

        using (SqlCommand command = new SqlCommand(querystring, users.getConnection()))
        {
            // Додавання параметрів
            command.Parameters.AddWithValue("@GearCode", gear_code);
            command.Parameters.AddWithValue("@CountOf", count_of);
            command.Parameters.AddWithValue("@Maker", maker);
            command.Parameters.AddWithValue("@Price", price);
            command.Parameters.AddWithValue("@Description", description);
            command.Parameters.AddWithValue("@UserToken", token);

            // Перевірка наявності зображення
            if (imageData == null || imageData.Length == 0)
            {
                command.Parameters.Add("@ImageData", SqlDbType.VarBinary).Value = DBNull.Value; // Якщо зображення немає
            }
            else
            {
                command.Parameters.Add("@ImageData", SqlDbType.VarBinary).Value = imageData; // Якщо зображення є
            }

            // Відкриття підключення та виконання запиту
            users.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Деталь додана", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Помилка при додаванні деталі", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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