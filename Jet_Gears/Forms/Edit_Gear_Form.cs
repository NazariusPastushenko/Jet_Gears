using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Jet_Gears.DataBases;
using Jet_Gears.Objects;

namespace Jet_Gears.Forms;

public partial class Edit_Gear_Form : Form
{
    private readonly Shelf_Gear _editGear;
    private DataBase _dataBase = new DataBase();
    private byte[] New_Image;
    private string _parenttag;

    public Edit_Gear_Form(Shelf_Gear Edit_Gear, string tag)
    {
        InitializeComponent();
        _editGear = Edit_Gear;
        _parenttag = tag;
        GearCode_Textbox.Text = _editGear.gearcode;
        Specs_Textbox.Text = _editGear.description;
        Price_Textbox.Text = _editGear.price.ToString();
        Part_PictureBox.Image = _editGear.image;
        
        if (_editGear.image != null)
        {
            Bitmap bmp = new Bitmap(_editGear.image); // Копія, уникнення блокування файлу
            ImageConverter converter = new ImageConverter();
            New_Image = (byte[])converter.ConvertTo(bmp, typeof(byte[]));
        }
    }

    private void Edit_Button_Click(object sender, EventArgs e)
    {
        try
        {

        
            string querystring = @"UPDATE Gears SET gear_code = @NewGearcode,description = @NewSpecs,price = @NewPrice,picture = @NewImageData  
                 WHERE gear_code = @Gearcode and user_Token = @Token and description = @Specs and price = @Price;";

            using SqlCommand command = new SqlCommand(querystring, _dataBase.getConnection());
            command.Parameters.AddWithValue("@Gearcode", _editGear.gearcode);
            command.Parameters.AddWithValue("@Token", Categories.CurrUserToken);
            command.Parameters.AddWithValue("@Specs", _editGear.description);
            command.Parameters.AddWithValue("@Price", _editGear.price);

            GearCode_Textbox.Text= Regex.Replace(GearCode_Textbox.Text, @"\r\n?|\n", "");;
            command.Parameters.AddWithValue("@NewGearcode",GearCode_Textbox.Text );
            command.Parameters.AddWithValue("@NewSpecs",Specs_Textbox.Text );
            command.Parameters.AddWithValue("@NewPrice",Price_Textbox.Text );
            if (New_Image == null || New_Image.Length == 0)
            {
                command.Parameters.Add("@NewImageData", SqlDbType.VarBinary).Value = DBNull.Value; // Якщо зображення немає
            }
            else
            {
                command.Parameters.Add("@NewImageData", SqlDbType.VarBinary).Value = New_Image; // Якщо зображення є
            }


            
            
            _dataBase.openConnection();
            command.ExecuteNonQuery();
                MessageBox.Show("Редагування успішне", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                if (_parenttag == null)
                {
                    Categories.CurrentMainForm.OpenChildForm(new Basket_Form(),false);
                }
                else
                {
                    Categories.CurrentMainForm.OpenChildForm(new Search_Shelf_Form(_parenttag),false);
                }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }


    private void Part_PictureBox_Click(object sender, EventArgs e)
    {
        using (openPictureDialog)
        {
            // Налаштування фільтра для відображення лише зображень
            openPictureDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";
            openPictureDialog.Title = "Виберіть картинку";

            // Відкриття діалогового вікна
            if (openPictureDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openPictureDialog.FileName;
                Part_PictureBox.Image = Image.FromFile(filePath);
                Part_PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                New_Image = File.ReadAllBytes(filePath);
            }
        }
    }
}