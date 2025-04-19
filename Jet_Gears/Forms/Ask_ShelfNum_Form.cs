using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Jet_Gears.DataBases;
using Jet_Gears.Objects;

namespace Jet_Gears.Forms;

public partial class Ask_ShelfNum_Form : Form
{
    
    private  Shelf_Form _shelfForm;
    private ShelfControl Preview_Shelf;
    private readonly DataBase Gears_Base = new DataBase();
    public Ask_ShelfNum_Form(Shelf_Form shelfForm)
    {
        InitializeComponent();
        _shelfForm = shelfForm;
        StartPosition = FormStartPosition.CenterScreen;
        Preview_Shelf = new ShelfControl();
        Preview_Shelf.Location = new Point(291, 53);
        Preview_Shelf.ShelfWidth = 250;
        Preview_Shelf.LineThickness = 10;
        Preview_Shelf.Size = new Size(263,310);
        Preview_Shelf.Show();
        Preview_Shelf.BringToFront();
        Controls.Add(Preview_Shelf);
    }
    private void ShelfPrefix_TextBox_TextChanged(object sender, EventArgs e)
    {
        Preview_Shelf.ShelfLabelPrefix = ShelfPrefix_TextBox.Text;
        Preview_Shelf.Refresh();
    }

    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
        Preview_Shelf.ShelfCount = (int)numericUpDown1.Value;
        Preview_Shelf.Refresh();
    }

    private void Ask_ShelfNum_Form_Load(object sender, EventArgs e)
    {
        ShelfPrefix_TextBox.Text = "A";
        numericUpDown1.Value = 4;
        
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (!ShelfPrefix_TextBox.Text.Any(char.IsLetter))
        {
            MessageBox.Show("Позначеня полиці повинно містити хоча б одну літеру.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        string Max_Shelf = Preview_Shelf.ShelfLabelPrefix + Preview_Shelf.ShelfCount + "|";
        UpdateTextColumn(Categories.CurrUserLogin,Max_Shelf);
        Get_Shelves_List(Categories.CurrUserLogin);
        _shelfForm.Write_Shelves();
    }
    
    
    
    
    public void UpdateTextColumn(string userLogin, string newText)
    {
        
        try
        {
            if (Check_Availability(SplitLetter(newText)) == false)
            {
                MessageBox.Show("Таблиця з таким позначенням вже існує", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var connection = Gears_Base.getConnection();
            // Підключення до бази даних
            
            // Запит на оновлення значення
            string querystring = "UPDATE register SET Shelves = CAST(ISNULL(Shelves, '') AS NVARCHAR(MAX)) + @NewValue WHERE login_user = @UserId";

            
            
            
            // Команда для виконання запиту
            SqlCommand command = new SqlCommand(querystring,connection);
            command.Parameters.AddWithValue("@NewValue", newText);
            command.Parameters.AddWithValue("@UserId", userLogin);
            // Додаємо параметри, щоб уникнути SQL-ін'єкцій
            

            // SqlDataAdapter для виконання команди
            SqlDataAdapter adapter = new SqlDataAdapter
            {
                UpdateCommand = command
            };

            // Відкрити з'єднання, виконати команду
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            // Перевірка результату
            if (rowsAffected > 0)
            {
                MessageBox.Show("Значення успішно оновлено.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Рядок не знайдено.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    
    private bool Check_Availability(string newText)
    {
        foreach (var s in Categories.ShelvesList)
        {
            if (SplitLetter(s) == newText)
            {
                return false;
            }
        }

        return true;
    }
    
    
    public string SplitLetter(string input)
    {
        // Регулярний вираз для виділення букв та чисел
        string pattern = @"([a-zA-Z]+)(\d+)";
        Regex regex = new Regex(pattern);

        Match match = regex.Match(input); 
        return match.Groups[1].Value;  // Літери
            
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
    
    private void button2_Click(object sender, EventArgs e)
    {
        Close();
    }
}