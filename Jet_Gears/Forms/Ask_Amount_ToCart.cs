using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Windows.Forms;
using Jet_Gears.DataBases;

namespace Jet_Gears.Forms;

public partial class Ask_Amount_ToCart : Form
{
    private byte[] imageBytes { get; set; }
    
    public Ask_Amount_ToCart()
    {
        InitializeComponent();
        textBox1.Text = Categories.Current_OverviewPart.Price;
    }

    
    
    private void button1_Click(object sender, EventArgs e)
    {
        Categories.Current_OverviewPart.Price = textBox1.Text;
        Add_Part_to_DataBase_Cart((int)numericUpDown1.Value);
        Close();
    }
    
        public void Add_Part_to_DataBase_Cart(int count_of)
    {
        try
    {
        DataBase users = new DataBase();

        string description = "";
        foreach (var VARIABLE in Categories.Current_OverviewPart.Table)
        {
            description += $"{VARIABLE.Key}: {VARIABLE.Value}\n";
        }
        // Отримання значень з форми
        string gearCode = Categories.Current_OverviewPart.Title;
        string maker = Categories.Current_OverviewPart.Manufacturer;
        string price = Categories.Current_OverviewPart.Price;
        string token = Categories.CurrUserToken;

        // Запит з параметрами
        string querystring = @"
            INSERT INTO Gears (gear_code, count_of, maker, price, description, picture, user_Token,Shelf_Placement,Cart,Checked) 
            VALUES (@GearCode, @CountOf, @Maker, @Price, @Description, @ImageData, @UserToken,@Shelf_Place, @Cart, @Checked)";

        using (SqlCommand command = new SqlCommand(querystring, users.getConnection()))
        {
            if(string.IsNullOrEmpty(gearCode))gearCode = "0";
            if(string.IsNullOrEmpty(maker))maker = "0";
            if(string.IsNullOrEmpty(description))description = "0";
            // Додавання параметрів
            command.Parameters.AddWithValue("@GearCode", gearCode);
            command.Parameters.AddWithValue("@CountOf", count_of);
            command.Parameters.AddWithValue("@Maker", maker);
            command.Parameters.AddWithValue("@Price", price);
            command.Parameters.AddWithValue("@Description", description);
            command.Parameters.AddWithValue("@UserToken", token);
            command.Parameters.AddWithValue("@Shelf_Place", "");
            command.Parameters.AddWithValue("@Cart", 1);
            command.Parameters.AddWithValue("@Checked", 0);

            string ImageUrl = Categories.Current_OverviewPart.Part_PictureURL; 
            using (var webClient = new WebClient()) { 
                 imageBytes = webClient.DownloadData(ImageUrl);
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


    private void button2_Click(object sender, EventArgs e)
    {
        Close();
    }
}