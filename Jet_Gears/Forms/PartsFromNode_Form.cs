using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Jet_Gears.Controls;
using Jet_Gears.Objects;

namespace Jet_Gears.Forms;

public partial class PartsFromNode_Form : Form
{
    
    private Point Current_Location;

    
    public PartsFromNode_Form(List<AutoPart> list)
    {
        InitializeComponent();
        Write_Parts_Buttons(list);
    }
    
    
    
    
    private void Write_Parts_Buttons(List<AutoPart> parts)
    {
        Clean_Buttons();
        Current_Location = new Point(5, 5);
        foreach (var part in parts)
        {
            ImageTextButton b = new ImageTextButton();
            b.Location = Current_Location;
            b.Text = part.Name;
            b.Name = part.Link;
            b.ImageUrl = part.ImageUrl;
            b.ImageSize = new Size(100, 100);
            b.BackColor = Color.FromArgb(0, 36, 0);
            b.ForeColor = Color.Azure;
            b.Font = new Font("Bahnschrift SemiBold SemiConden", 15, FontStyle.Bold);
            b.Size = new Size(490, 80);
            b.Click += Find_Parts_By_Node;
            Controls.Add(b);
            b.Show();
            b.BringToFront();
            Current_Location.Y += 80 + 5;
            }
        }

    private void Find_Parts_By_Node(object sender, EventArgs e)
    {
        ImageTextButton b = sender as ImageTextButton;
        InitialSearch.Initial_Search(b.Name,"Node");
        Categories.CurrentMainForm.OpenChildForm(new Advanced_Search());
    }


    private void Clean_Buttons()
    {
        Controls.Clear();
    }
}