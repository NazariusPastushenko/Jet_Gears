using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Jet_Gears.DataBases;
using System.Security.Cryptography;
using System.Text;

namespace Jet_Gears
{
    public partial class Enter_Form : Form
    {
        private DataBase users = new DataBase();
        public Enter_Form()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            KeyPreview = true;
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            textBox_password.PasswordChar = '*';
            Open_Eye.Visible = false;
            textBox_Login.MaxLength = 50;
            textBox_password.MaxLength = 50;
        }

        private void Registration_Button_Click(object sender, EventArgs e)
        {
            var loginUser = textBox_Login.Text;
            var passUser = textBox_password.Text;


            SqlDataAdapter adapter = new SqlDataAdapter();

            DataTable table = new DataTable();

            string querystring =
                $"select id_user, login_user, password_user,Surname,Name,Shelves from register where login_user = '{loginUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(querystring, users.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Ви успішно зайшли", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Categories.Curr_User_Token = loginUser.GetHashCode().ToString();
                Categories.Curr_User_Login = loginUser;
                Forms.Main_Form frm1 = new Forms.Main_Form();
                Hide();
                frm1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Такого аккаунта не існує", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        
        private void Close_Eye_Click(object sender, EventArgs e)
        {
            Open_Eye.Visible = true;
            Close_Eye.Visible = false;
            textBox_password.PasswordChar = default;
        }

        private void Open_Eye_Click(object sender, EventArgs e)
        {
            Open_Eye.Visible = false;
            Close_Eye.Visible = true;
            textBox_password.PasswordChar = '*';
            
        }

        private void RegLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            Registration_Form reg = new Registration_Form();
            reg.Show();
        }
        
        
        private void Enter_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Registration_Button_Click(sender,e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
            if (e.KeyCode == Keys.F1)
            {
                textBox_Login.Text = "admin";
                textBox_password.Text = "admin";
                Registration_Button_Click(sender,e);
            }
        }
    }
}