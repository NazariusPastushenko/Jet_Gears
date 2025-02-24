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
        foreach (string shelf in Categories.ShelvesList)
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


            s.ShelfButtonClick += Show_Tag;
        }
    }


    
    private void Show_Tag(object sender, ShelfButtonClickEventArgs e)
    {
        Categories.CurrentMainForm.OpenChildForm(new Search_Shelf_Form(e.ShelfTag));
        if (Categories.ShelfGears.Count == 0)
        {
            Categories.CurrentMainForm.OpenChildForm(new Shelf_Form());
        }
    }


    private void egoldsGoogleTextBox1_TextChanged(object sender, EventArgs e)
    {
        
    }
}