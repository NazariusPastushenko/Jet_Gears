using System.ComponentModel;

namespace Jet_Gears;

partial class Search_Part_Overview
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.Title_Label = new System.Windows.Forms.Label();
        this.Description_Label = new System.Windows.Forms.Label();
        this.Specs_Label = new System.Windows.Forms.Label();
        this.Price_Label = new System.Windows.Forms.Label();
        this.Part_PictureBox = new System.Windows.Forms.PictureBox();
        this.button1 = new Jet_Gears.Controls.button();
        this.Brand_PictureBox = new System.Windows.Forms.PictureBox();
        this.button2 = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.Part_PictureBox)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.Brand_PictureBox)).BeginInit();
        this.SuspendLayout();
        // 
        // Title_Label
        // 
        this.Title_Label.BackColor = System.Drawing.Color.Transparent;
        this.Title_Label.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 30F, System.Drawing.FontStyle.Bold);
        this.Title_Label.ForeColor = System.Drawing.Color.Black;
        this.Title_Label.Location = new System.Drawing.Point(12, 9);
        this.Title_Label.Name = "Title_Label";
        this.Title_Label.Size = new System.Drawing.Size(412, 71);
        this.Title_Label.TabIndex = 1;
        this.Title_Label.Text = "Назва деталі";
        // 
        // Description_Label
        // 
        this.Description_Label.BackColor = System.Drawing.Color.Transparent;
        this.Description_Label.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 20F, System.Drawing.FontStyle.Bold);
        this.Description_Label.ForeColor = System.Drawing.Color.Black;
        this.Description_Label.Location = new System.Drawing.Point(12, 80);
        this.Description_Label.Name = "Description_Label";
        this.Description_Label.Size = new System.Drawing.Size(213, 36);
        this.Description_Label.TabIndex = 2;
        this.Description_Label.Text = "Опис";
        // 
        // Specs_Label
        // 
        this.Specs_Label.BackColor = System.Drawing.Color.Transparent;
        this.Specs_Label.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15F, System.Drawing.FontStyle.Bold);
        this.Specs_Label.ForeColor = System.Drawing.Color.DimGray;
        this.Specs_Label.Location = new System.Drawing.Point(12, 121);
        this.Specs_Label.Name = "Specs_Label";
        this.Specs_Label.Size = new System.Drawing.Size(236, 249);
        this.Specs_Label.TabIndex = 3;
        this.Specs_Label.Text = "Характеристики\r\n";
        // 
        // Price_Label
        // 
        this.Price_Label.BackColor = System.Drawing.Color.Transparent;
        this.Price_Label.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 30F, System.Drawing.FontStyle.Bold);
        this.Price_Label.ForeColor = System.Drawing.Color.Black;
        this.Price_Label.Location = new System.Drawing.Point(340, 420);
        this.Price_Label.Name = "Price_Label";
        this.Price_Label.Size = new System.Drawing.Size(135, 60);
        this.Price_Label.TabIndex = 4;
        this.Price_Label.Text = "Ціна";
        // 
        // Part_PictureBox
        // 
        this.Part_PictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.Part_PictureBox.Location = new System.Drawing.Point(254, 121);
        this.Part_PictureBox.Name = "Part_PictureBox";
        this.Part_PictureBox.Size = new System.Drawing.Size(234, 206);
        this.Part_PictureBox.TabIndex = 5;
        this.Part_PictureBox.TabStop = false;
        // 
        // button1
        // 
        this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(59)))), ((int)(((byte)(9)))));
        this.button1.BackColorAdditional = System.Drawing.Color.Gray;
        this.button1.BackColorGradientEnabled = false;
        this.button1.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
        this.button1.BorderColor = System.Drawing.Color.Transparent;
        this.button1.BorderColorEnabled = false;
        this.button1.BorderColorOnHover = System.Drawing.Color.Transparent;
        this.button1.BorderColorOnHoverEnabled = false;
        this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
        this.button1.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15F, System.Drawing.FontStyle.Bold);
        this.button1.ForeColor = System.Drawing.Color.White;
        this.button1.Location = new System.Drawing.Point(12, 433);
        this.button1.Name = "button1";
        this.button1.RippleColor = System.Drawing.Color.Black;
        this.button1.Rounding = 90;
        this.button1.RoundingEnable = true;
        this.button1.Size = new System.Drawing.Size(213, 47);
        this.button1.TabIndex = 6;
        this.button1.Text = "Додати в наявність";
        this.button1.TextHover = null;
        this.button1.UseCompatibleTextRendering = true;
        this.button1.UseDownPressEffectOnClick = false;
        this.button1.UseMnemonic = false;
        this.button1.UseRippleEffect = true;
        this.button1.UseVisualStyleBackColor = false;
        this.button1.UseZoomEffectOnHover = false;
        this.button1.Click += new System.EventHandler(this.button1_Click);
        // 
        // Brand_PictureBox
        // 
        this.Brand_PictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.Brand_PictureBox.Location = new System.Drawing.Point(373, 342);
        this.Brand_PictureBox.Name = "Brand_PictureBox";
        this.Brand_PictureBox.Size = new System.Drawing.Size(115, 66);
        this.Brand_PictureBox.TabIndex = 7;
        this.Brand_PictureBox.TabStop = false;
        // 
        // button2
        // 
        this.button2.BackgroundImage = global::Jet_Gears.Properties.Resources.Right_Arrow;
        this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
        this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.button2.Location = new System.Drawing.Point(430, 12);
        this.button2.Name = "button2";
        this.button2.Size = new System.Drawing.Size(58, 48);
        this.button2.TabIndex = 8;
        this.button2.Text = "button2";
        this.button2.UseVisualStyleBackColor = true;
        this.button2.Click += new System.EventHandler(this.button2_Click);
        // 
        // Search_Part_Overview
        // 
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        this.BackColor = System.Drawing.Color.White;
        this.ClientSize = new System.Drawing.Size(500, 492);
        this.Controls.Add(this.button2);
        this.Controls.Add(this.Brand_PictureBox);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.Part_PictureBox);
        this.Controls.Add(this.Price_Label);
        this.Controls.Add(this.Specs_Label);
        this.Controls.Add(this.Description_Label);
        this.Controls.Add(this.Title_Label);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Name = "Search_Part_Overview";
        this.Text = "Search_Part_Overview";
        ((System.ComponentModel.ISupportInitialize)(this.Part_PictureBox)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.Brand_PictureBox)).EndInit();
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.Button button2;

    private System.Windows.Forms.PictureBox Brand_PictureBox;

    private Jet_Gears.Controls.button button1;

    private System.Windows.Forms.PictureBox Part_PictureBox;

    private System.Windows.Forms.Label Specs_Label;
    private System.Windows.Forms.Label Price_Label;

    private System.Windows.Forms.Label Description_Label;

    private System.Windows.Forms.Label Title_Label;

    #endregion
}