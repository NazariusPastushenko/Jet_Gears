using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Jet_Gears.DataBases;

namespace Jet_Gears.Forms;

public partial class Account_Form : Form
{
    public Account_Form()
    {
        InitializeComponent();
        LoadUserData();
    }

    private void LoadUserData()
    {
        DataBase db = new DataBase();
        SqlConnection connection = db.getConnection();

        string query = "SELECT Name, Address, Phone, login_user, password_user FROM register WHERE login_user = @login";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@login", Categories.CurrUserLogin);

        db.openConnection();

        SqlDataAdapter adapter = new SqlDataAdapter(command);
        DataTable table = new DataTable();
        adapter.Fill(table);

        if (table.Rows.Count == 1)
        {
            DataRow row = table.Rows[0];
            ShopName_TextBox.Text = row["Name"].ToString();
            Address_TextBox.Text = row["Address"].ToString();
            Phone_TextBox.Text = row["Phone"].ToString();
            Login_TextBox.Text = row["login_user"].ToString();
            Password_TextBox.Text = row["password_user"].ToString();
        }

        db.closeConnection();
    }
    
    
    

    
    private void textBox2_TextChanged(object sender, EventArgs e)
    {
        
    }

   private void Save_Button_Click_1(object sender, EventArgs e)
{
    string name = ShopName_TextBox.Text.Trim();
    string address = Address_TextBox.Text.Trim();
    string phone = Phone_TextBox.Text.Trim();
    string login = Login_TextBox.Text.Trim();
    string password = Password_TextBox.Text.Trim();

    if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
    {
        MessageBox.Show("Заповніть усі обов'язкові поля", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }

    DataBase db = new DataBase();
    SqlConnection connection = db.getConnection();

    // Новий токен
    string newToken = login.GetHashCode().ToString();
    string oldToken = Categories.CurrUserToken;

    db.openConnection();
    SqlTransaction transaction = connection.BeginTransaction();

    try
    {
        // Оновлення користувача
        string updateUserQuery = @"
            UPDATE register 
            SET Name = @name, login_user = @login, password_user = @password, Phone = @phone, Address = @address 
            WHERE login_user = @currentLogin";

        SqlCommand updateUserCmd = new SqlCommand(updateUserQuery, connection, transaction);
        updateUserCmd.Parameters.AddWithValue("@name", name);
        updateUserCmd.Parameters.AddWithValue("@address", address);
        updateUserCmd.Parameters.AddWithValue("@phone", phone);
        updateUserCmd.Parameters.AddWithValue("@login", login);
        updateUserCmd.Parameters.AddWithValue("@password", password);
        updateUserCmd.Parameters.AddWithValue("@currentLogin", Categories.CurrUserLogin);

        if (updateUserCmd.ExecuteNonQuery() != 1)
            throw new Exception("Не вдалося оновити користувача");

        // Оновлення user_Token у Gears
        string updateTokenQuery = "UPDATE Gears SET user_Token = @newToken WHERE user_Token = @oldToken";
        SqlCommand updateTokenCmd = new SqlCommand(updateTokenQuery, connection, transaction);
        updateTokenCmd.Parameters.AddWithValue("@newToken", newToken);
        updateTokenCmd.Parameters.AddWithValue("@oldToken", oldToken);
        updateTokenCmd.ExecuteNonQuery();

        // Оновлення глобальних змінних
        Categories.CurrUserLogin = login;
        Categories.CurrUserToken = newToken;

        transaction.Commit();

        MessageBox.Show("Дані оновлено успішно", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
        this.Close();
    }
    catch (Exception ex)
    {
        transaction.Rollback();
        MessageBox.Show("Помилка при оновленні: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    db.closeConnection();
}

}