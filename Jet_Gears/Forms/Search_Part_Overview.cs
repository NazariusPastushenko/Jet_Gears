using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jet_Gears.Objects;

namespace Jet_Gears;

public partial class Search_Part_Overview : Form
{
    public Search_Part_Overview()
    {
        InitializeComponent();
        Console.WriteLine(Categories.Current_Overview_Part.ToString());
        OverviewPart Current_Part = Categories.Current_Overview_Part;
        Title_Label.Text =  Current_Part.Title;
        Description_Label.Text = Current_Part.Description;
        Price_Label.Text = Current_Part.Price + " Фунтів";
        if (Current_Part.Part_Picture != null){Part_PictureBox.Image = Current_Part.Part_Picture;}
        if(Current_Part.Brand_Picture != null){Brand_PictureBox.Image = Current_Part.Brand_Picture;}
        foreach (var Spec in Current_Part.Table)
        {
            Specs_Label.Text += Spec.Key + Spec.Value + "\n";
        }


    }

    

}