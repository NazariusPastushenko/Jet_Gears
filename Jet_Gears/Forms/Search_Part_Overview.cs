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
    public Search_Part_Overview(Search_Gear Part)
    {
        InitializeComponent();
        Title_Label.Text =  Part.title;
        Description_Label.Text = Part.description;
        Price_Label.Text = Part.price + " Фунтів";
        
        
    }

    

}