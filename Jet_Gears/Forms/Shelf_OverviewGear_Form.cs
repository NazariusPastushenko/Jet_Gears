using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Jet_Gears.DataBases;
using Jet_Gears.Objects;

namespace Jet_Gears.Forms;

public partial class Shelf_OverviewGear_Form : Form
{
    private readonly Shelf_OverviewPart _shelfOverviewPart;
    private readonly string _currPartShelfTag;
    private readonly Form _parentForm;
    private readonly DataBase _gearsBase = new DataBase();
    public Shelf_OverviewGear_Form(Shelf_OverviewPart partOverview,string currShelfTag,Form parentform)
    {
        _shelfOverviewPart = partOverview;
        _currPartShelfTag = currShelfTag;
        
        _parentForm = parentform;
        InitializeComponent();
        Title_Label.Text = _shelfOverviewPart.Title;
        Specs_Label.Text = _shelfOverviewPart.Description;
        Part_PictureBox.Image = _shelfOverviewPart.Part_Picture;
        Part_PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        Price_Label.Text = "Ціна: " + _shelfOverviewPart.Price + "\u20B4";
        if (parentform == null && currShelfTag == null)
        {
            button1.Hide();
        }
    }


    private void button2_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void Ask_Ai_Button_Click(object sender, EventArgs e)
    {
            Categories.CurrentMainForm.OpenChildForm(new AI_Assistant_Chat($"Розкажи мені про цю деталь {Title_Label.Text}, яку функцію вона виконує, для чого вона в автомобілі та куди встановлюється"));
    }

    private void button1_Click(object sender, EventArgs e)
    {
        
                string querystring = @"UPDATE Gears SET Cart = 1, Checked = 0 WHERE gear_code = @Gearcode and user_Token = @Token and price = @Price and description = @description";

                using SqlCommand command = new SqlCommand(querystring, _gearsBase.getConnection());
                command.Parameters.AddWithValue("@Gearcode", _shelfOverviewPart.Title);
                command.Parameters.AddWithValue("@Token", Categories.CurrUserToken);
                command.Parameters.AddWithValue("@description", _shelfOverviewPart.Description);
                command.Parameters.AddWithValue("@Price", int.Parse(_shelfOverviewPart.Price));

                _gearsBase.openConnection();
                if (command.ExecuteNonQuery() != 1)
                {
                    MessageBox.Show("Помилка при додаванні деталі", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Деталь додано до кошику", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                
                Categories.ShelfGears.RemoveAll(g => g.gearcode == _shelfOverviewPart.Title && g.price == _shelfOverviewPart.Price);
                _parentForm.Close();
                if (Categories.ShelfGears.Count != 0)
                {
                    Categories.CurrentMainForm.OpenChildForm(new Search_Shelf_Form(_currPartShelfTag),false);
                }
                else
                {
                    Categories.CurrentMainForm.OpenChildForm(new Shelf_Form(),false);
                }
                
                
    }
}