using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Jet_Gears.Forms;

public partial class Ask_ShelfPlace_Form : Form
{
    private Search_Part_Overview _parent;
    private string Shelf_Letter;
    private string Shelf_Number;
    public Ask_ShelfPlace_Form(Search_Part_Overview parent)
    {
        InitializeComponent();
        _parent = parent;
        StartPosition = FormStartPosition.CenterScreen;
        textBox1.Text = Categories.Current_OverviewPart.Price;
        foreach (var Shelf in Categories.ShelvesList)
        {
            SplitString(Shelf);
            TreeNode LettersNode = new TreeNode(Shelf_Letter);
            for (int i = 0; i < int.Parse(Shelf_Number); i++)
            {
                LettersNode.Nodes.Add(new TreeNode(Shelf_Letter + (i+1)));
            }
            treeView1.Nodes.Add(LettersNode);
        }
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
            Shelf_Number = match.Groups[2].Value;  // Число
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (!treeView1.SelectedNode.Text.Any(char.IsNumber))
        {
            MessageBox.Show("Виберіть полицю а не стелаж!.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        Categories.Current_OverviewPart.Price = textBox1.Text;
        _parent.Add_Part_to_DataBase(treeView1.SelectedNode.Text,(int)numericUpDown1.Value);
        Close();
    }
}