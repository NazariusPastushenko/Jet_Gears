using System;
using System.Windows.Forms;
using Jet_Gears.Controls;

namespace Jet_Gears.Forms
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
            var card = new GearCard();
            Controls.Add(card);
            Console.WriteLine(Categories.Curr_User_Token);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }


        private Form _activeForm;

        private void OpenChildForm(Form childform)
        {
            if (_activeForm !=null) _activeForm.Close();
            _activeForm = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childform);
            panelChildForm.Tag = childform;
            childform.BringToFront();
            childform.Show();
        }


        private void Search_Button_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Advanced_Search());
        }

        private void Supply_Button_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Supply_Form());
        }

        private void Shelf_Button_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Search_Shelf_Form());
        }
        private void Basket_Button_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Basket_Form());
        }


        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.Ask_Closing(sender,e);
        }

        private void Main_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Shelf_Form());
        }
    }
}