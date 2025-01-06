using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jet_Gears.DataBases;
using Jet_Gears.Objects;

namespace Jet_Gears;

public partial class Search_Part_Overview : Form
{
    private Image brand_img {get; set;}
    private Image part_img {get; set;}
    private OverviewPart Current_Part {get; set;}
    private byte[] imageBytes {get; set;}
    public Search_Part_Overview(OverviewPart part)
    {
        InitializeComponent();
        Current_Part = part;
        Title_Label.Text =  part.Title;
        Description_Label.Text = part.Description;
        Price_Label.Text = part.Price + "\u20b4";
        Part_PictureBox.ImageLocation = part.Part_PictureURL;
        Part_PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        Brand_PictureBox.ImageLocation = part.Brand_PictureURL;
        Brand_PictureBox.SizeMode = PictureBoxSizeMode.Zoom;

        foreach (var Spec in part.Table)
        {
            Specs_Label.Text += Spec.Key + Spec.Value + "\n";
        }

    }

    private void button2_Click(object sender, EventArgs e)
    {
        this.Parent.Hide();
        this.Close();
    }

    private void button1_Click(object sender, EventArgs e)
    {
            try
    {
        DataBase users = new DataBase();
        
        // Отримання значень з форми
        string gear_code = Current_Part.Article;
        int count_of = 1;
        string maker = Current_Part.Manufacturer;
        decimal price = decimal.Parse(Current_Part.Price);
        string description = Current_Part.Description;
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

            string someUrl = Current_Part.Part_PictureURL; 
            using (var webClient = new WebClient()) { 
                 imageBytes = webClient.DownloadData(someUrl);
            }
            
            // Перевірка наявності зображення
            if (imageBytes == null || imageBytes.Length == 0)
            {
                command.Parameters.Add("@ImageData", SqlDbType.VarBinary).Value = DBNull.Value; // Якщо зображення немає
            }
            else
            {
                command.Parameters.Add("@ImageData", SqlDbType.VarBinary).Value = imageBytes; // Якщо зображення є
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
}