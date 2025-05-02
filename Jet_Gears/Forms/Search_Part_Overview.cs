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
using Jet_Gears.Forms;
using Jet_Gears.Objects;

namespace Jet_Gears;

public partial class Search_Part_Overview : Form
{
    private Image brand_img {get; set;}
    private Image part_img {get; set;}
    private OverviewPart Current_Part {get; set;}
    private byte[] imageBytes {get; set;}
    public Search_Part_Overview()
    {
        Current_Part = Categories.Current_OverviewPart;
        InitializeComponent();

        Title_Label.Text =  Current_Part.Title;
        Price_Label.Text += Current_Part.Price+"\u20B4";
        Part_PictureBox.ImageLocation = Current_Part.Part_PictureURL;
        Part_PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        
        foreach (var Spec in Current_Part.Table)
        {
            Specs_Label.Text += Spec.Key + "  " + Spec.Value + "\n";
        }

    }

    private void button2_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Ask_ShelfPlace_Form f = new Ask_ShelfPlace_Form(this);
        f.Show();
    }

    public void Add_Part_to_DataBase(string shelf_place,int count_of)
    {
        try
    {
        DataBase users = new DataBase();

        string description = "";
        foreach (var VARIABLE in Current_Part.Table)
        {
            description += $"{VARIABLE.Key}: {VARIABLE.Value}\n";
        }
        // Отримання значень з форми
        string gear_code = Current_Part.Title;
        string maker = Current_Part.Manufacturer;
        string price = Current_Part.Price;
        string token = Categories.CurrUserToken;

        // Запит з параметрами
        string querystring = @"
            INSERT INTO Gears (gear_code, count_of, maker, price, description, picture, user_Token,Shelf_Placement) 
            VALUES (@GearCode, @CountOf, @Maker, @Price, @Description, @ImageData, @UserToken,@Shelf_Place)";

        using (SqlCommand command = new SqlCommand(querystring, users.getConnection()))
        {
            
            
            
            
            if(string.IsNullOrEmpty(gear_code))gear_code = "0";
            if(string.IsNullOrEmpty(maker))maker = "0";
            if(string.IsNullOrEmpty(description))description = "0";
            // Додавання параметрів
            command.Parameters.AddWithValue("@GearCode", gear_code);
            command.Parameters.AddWithValue("@CountOf", count_of);
            command.Parameters.AddWithValue("@Maker", maker);
            command.Parameters.AddWithValue("@Price", price);
            command.Parameters.AddWithValue("@Description", description);
            command.Parameters.AddWithValue("@UserToken", token);
            command.Parameters.AddWithValue("@Shelf_Place", shelf_place);

            string ImageUrl = Current_Part.Part_PictureURL; 
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

    private void Ask_Ai_Button_Click(object sender, EventArgs e)
    {
        Categories.CurrentMainForm.OpenChildForm(new AI_Assistant_Chat($"Розкажи мені про цю деталь {Current_Part.Title}, яку функцію вона виконує, для чого вона в автомобілі та куди встановлюється"));
    }
}