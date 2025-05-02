using System.ComponentModel;

namespace Jet_Gears.Forms;

partial class Edit_Gear_Form
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
        this.Part_PictureBox = new System.Windows.Forms.PictureBox();
        this.Edit_Button = new Jet_Gears.Controls.button();
        this.GearCode_Textbox = new System.Windows.Forms.RichTextBox();
        this.Specs_Textbox = new System.Windows.Forms.RichTextBox();
        this.label1 = new System.Windows.Forms.Label();
        this.Price_Textbox = new System.Windows.Forms.TextBox();
        this.label2 = new System.Windows.Forms.Label();
        this.openPictureDialog = new System.Windows.Forms.OpenFileDialog();
        ((System.ComponentModel.ISupportInitialize)(this.Part_PictureBox)).BeginInit();
        this.SuspendLayout();
        // 
        // Part_PictureBox
        // 
        this.Part_PictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.Part_PictureBox.Location = new System.Drawing.Point(227, 88);
        this.Part_PictureBox.Name = "Part_PictureBox";
        this.Part_PictureBox.Size = new System.Drawing.Size(248, 352);
        this.Part_PictureBox.TabIndex = 13;
        this.Part_PictureBox.TabStop = false;
        this.Part_PictureBox.Click += new System.EventHandler(this.Part_PictureBox_Click);
        // 
        // Edit_Button
        // 
        this.Edit_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(59)))), ((int)(((byte)(9)))));
        this.Edit_Button.BackColorAdditional = System.Drawing.Color.Gray;
        this.Edit_Button.BackColorGradientEnabled = false;
        this.Edit_Button.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
        this.Edit_Button.BorderColor = System.Drawing.Color.Tomato;
        this.Edit_Button.BorderColorEnabled = false;
        this.Edit_Button.BorderColorOnHover = System.Drawing.Color.Tomato;
        this.Edit_Button.BorderColorOnHoverEnabled = false;
        this.Edit_Button.Cursor = System.Windows.Forms.Cursors.Hand;
        this.Edit_Button.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.Edit_Button.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15F, System.Drawing.FontStyle.Bold);
        this.Edit_Button.ForeColor = System.Drawing.Color.White;
        this.Edit_Button.Location = new System.Drawing.Point(0, 495);
        this.Edit_Button.Name = "Edit_Button";
        this.Edit_Button.RippleColor = System.Drawing.Color.Black;
        this.Edit_Button.RoundingEnable = false;
        this.Edit_Button.Size = new System.Drawing.Size(485, 43);
        this.Edit_Button.TabIndex = 18;
        this.Edit_Button.Text = "Підтвердити";
        this.Edit_Button.TextHover = null;
        this.Edit_Button.UseDownPressEffectOnClick = false;
        this.Edit_Button.UseRippleEffect = true;
        this.Edit_Button.UseVisualStyleBackColor = false;
        this.Edit_Button.UseZoomEffectOnHover = false;
        this.Edit_Button.Click += new System.EventHandler(this.Edit_Button_Click);
        // 
        // GearCode_Textbox
        // 
        this.GearCode_Textbox.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 20F, System.Drawing.FontStyle.Bold);
        this.GearCode_Textbox.Location = new System.Drawing.Point(12, 12);
        this.GearCode_Textbox.Name = "GearCode_Textbox";
        this.GearCode_Textbox.Size = new System.Drawing.Size(463, 73);
        this.GearCode_Textbox.TabIndex = 20;
        this.GearCode_Textbox.Text = "";
        // 
        // Specs_Textbox
        // 
        this.Specs_Textbox.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.Specs_Textbox.ForeColor = System.Drawing.SystemColors.GrayText;
        this.Specs_Textbox.Location = new System.Drawing.Point(12, 112);
        this.Specs_Textbox.Name = "Specs_Textbox";
        this.Specs_Textbox.Size = new System.Drawing.Size(209, 328);
        this.Specs_Textbox.TabIndex = 21;
        this.Specs_Textbox.Text = "\n";
        // 
        // label1
        // 
        this.label1.BackColor = System.Drawing.Color.Transparent;
        this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15F, System.Drawing.FontStyle.Bold);
        this.label1.ForeColor = System.Drawing.Color.Black;
        this.label1.Location = new System.Drawing.Point(12, 88);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(209, 24);
        this.label1.TabIndex = 22;
        this.label1.Text = "Характеристики:";
        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // Price_Textbox
        // 
        this.Price_Textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.Price_Textbox.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15F, System.Drawing.FontStyle.Bold);
        this.Price_Textbox.Location = new System.Drawing.Point(77, 449);
        this.Price_Textbox.Name = "Price_Textbox";
        this.Price_Textbox.Size = new System.Drawing.Size(396, 32);
        this.Price_Textbox.TabIndex = 23;
        // 
        // label2
        // 
        this.label2.BackColor = System.Drawing.Color.Transparent;
        this.label2.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 18F, System.Drawing.FontStyle.Bold);
        this.label2.ForeColor = System.Drawing.Color.Black;
        this.label2.Location = new System.Drawing.Point(12, 443);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(61, 36);
        this.label2.TabIndex = 24;
        this.label2.Text = "Ціна:";
        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // openPictureDialog
        // 
        this.openPictureDialog.FileName = "openPictureDialog";
        // 
        // Edit_Gear_Form
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.ClientSize = new System.Drawing.Size(485, 538);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.Price_Textbox);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.Specs_Textbox);
        this.Controls.Add(this.GearCode_Textbox);
        this.Controls.Add(this.Edit_Button);
        this.Controls.Add(this.Part_PictureBox);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Name = "Edit_Gear_Form";
        this.Text = "Edit_Gear";
        ((System.ComponentModel.ISupportInitialize)(this.Part_PictureBox)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.OpenFileDialog openPictureDialog;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.TextBox Price_Textbox;

    private System.Windows.Forms.RichTextBox Specs_Textbox;
    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.RichTextBox GearCode_Textbox;

    private Jet_Gears.Controls.button Edit_Button;

    private System.Windows.Forms.PictureBox Part_PictureBox;

    #endregion
}