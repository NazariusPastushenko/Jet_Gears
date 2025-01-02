using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Jet_Gears.DataBases;

namespace Jet_Gears
{
    public partial class Registration_Form : Form
    {

        public Registration_Form()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Reg_Open_Eye.Visible = true;
            this.KeyPreview = true;
        }
        
        
        private void Reg_CloseEye_Click(object sender, EventArgs e)
        {
            Reg_Open_Eye.Visible = true;
            Reg_CloseEye.Visible = false;
            Registration_Password_Textbox.PasswordChar = default;
        }

        private void Reg_OpenEye_Click(object sender, EventArgs e)
        {
            Reg_Open_Eye.Visible = false;
            Reg_CloseEye.Visible = true;
            Registration_Password_Textbox.PasswordChar = '*';
            
        }

        private void Registration_Form_Load(object sender, EventArgs e)
        {
            Registration_Password_Textbox.PasswordChar = '*';
            Reg_Open_Eye.Visible = false;
            Registration_Name_Textbox.MaxLength = 50;
            Registration_Surname_Textbox.MaxLength = 50;
            Registration_Login_Textbox.MaxLength = 50;
            Registration_Password_Textbox.MaxLength = 50;
        }
        
        private void Registration_Button_Click(object sender, EventArgs e)
        { 
            DataBase users = new DataBase();
            
            var loginUser = Registration_Login_Textbox.Text;
            var passUser = Registration_Password_Textbox.Text;
            var SurnameUser = Registration_Surname_Textbox.Text;
            var nameUser = Registration_Name_Textbox.Text;

            if ( loginUser == "" || passUser == "" || SurnameUser == "" || nameUser == "")
            {
                MessageBox.Show("Схоже ви ввели не всі дані", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            SqlDataAdapter adapter = new SqlDataAdapter();

            DataTable table = new DataTable();
            var token = Categories.Curr_User_Token;

            string querystring =
                $"INSERT INTO register (login_user, password_user, Surname, Name,Token) VALUES ('{loginUser}','{passUser}','{SurnameUser}','{nameUser}','{token}')";
            
            SqlCommand command = new SqlCommand(querystring, users.getConnection());
            users.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт успішно створений", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Categories.Curr_User_Token = loginUser.GetHashCode();
            }
            Hide();
            Main_Form main = new Main_Form();
            main.Show();
        }


        private void Registration_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Registration_Button_Click(sender,e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }


        private void BackPanel_Click(object sender, EventArgs e)
        {
            Hide();
            Enter_Form enter = new Enter_Form();
            enter.Show();
        }
    }
}