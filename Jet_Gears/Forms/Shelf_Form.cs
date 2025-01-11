using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Jet_Gears.Controls;
using Jet_Gears.DataBases;

namespace Jet_Gears.Forms;

public partial class Shelf_Form : Form
{
    
    private readonly DataBase Gears_Base = new DataBase();
    private string Shelf_Letter;
    private int Shelf_Number;
    private int _latestShelfX = 20;
    public Shelf_Form()
    {
        InitializeComponent();
        Write_Shelves();
    }

    private void button1_Click(object sender, EventArgs e)
    {

        Ask_ShelfNum_Form f = new Ask_ShelfNum_Form(this);
        f.Show();
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
                Categories.Shelves_List = shelvesText
                    .Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();  // Перетворюємо масив в List
                
                // Використовуємо список для подальших дій
                foreach (string shelf in Categories.Shelves_List)
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

    public void SplitString(string input)
    {
        // Регулярний вираз для виділення букв та чисел
        string pattern = @"([a-zA-Z]+)(\d+)";
        Regex regex = new Regex(pattern);

        Match match = regex.Match(input);
        if (match.Success)
        {
            Shelf_Letter = match.Groups[1].Value;  // Літери
            Shelf_Number = Int32.Parse(match.Groups[2].Value);  // Число
        }
    }
    
    public void Write_Shelves()
    {
        _latestShelfX = 20;
        Shelf_Panel.Controls.Clear();
        Get_Shelves_List(Categories.Curr_User_Login);
        foreach (string shelf in Categories.Shelves_List)
        {
            SplitString(shelf);
            ShelfControl s = new ShelfControl();
            s.ShelfLabelPrefix = Shelf_Letter;
            s.ShelfCount = Shelf_Number;
            s.Size = new Size(265, 455);
            s.ShelfWidth = 240;
            s.LineThickness = 10;
            s.Location = new Point(_latestShelfX, 20);
            _latestShelfX += s.Size.Width + 15;
            s.BringToFront();
            s.Show();
            Shelf_Panel.Controls.Add(s);
        }
    }
}