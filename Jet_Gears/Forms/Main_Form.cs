using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;
using Jet_Gears;
using Jet_Gears.Controls;
using Jet_Gears.DataBases;
using Jet_Gears.Parser;
using Jet_Gears.Properties;


namespace Jet_Gears
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
            var Card = new GearCard();
            Controls.Add(Card);
            Console.WriteLine(Categories.Curr_User_Token);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }


        private Form activeForm = null;

        public void openChildForm(Form childform)
        {
            if (activeForm !=null) activeForm.Close();
            activeForm = childform;
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
            openChildForm(new Advanced_Search());
        }

        private void Supply_Button_Click(object sender, EventArgs e)
        {
            openChildForm(new Supply_Form());
        }

        private void Shelf_Button_Click(object sender, EventArgs e)
        {
            openChildForm(new Search_Shelf_Form());
        }
        private void Basket_Button_Click(object sender, EventArgs e)
        {
            openChildForm(new Basket_Form());
        }


        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.Ask_Closing(sender,e);
        }

        private void Main_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        
    }
}