using System.ComponentModel;

namespace Jet_Gears.Forms;

partial class Shelf_Form
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
        this.button1 = new Jet_Gears.Controls.button();
        this.panel1 = new System.Windows.Forms.Panel();
        this.Shelf_Panel = new System.Windows.Forms.Panel();
        this.right_arrow_button = new System.Windows.Forms.Button();
        this.left_arrow_button = new System.Windows.Forms.Button();
        this.egoldsGoogleTextBox1 = new yt_DesignUI.EgoldsGoogleTextBox();
        this.panel1.SuspendLayout();
        this.Shelf_Panel.SuspendLayout();
        this.SuspendLayout();
        // 
        // button1
        // 
        this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(59)))), ((int)(((byte)(9)))));
        this.button1.BackColorAdditional = System.Drawing.Color.Gray;
        this.button1.BackColorGradientEnabled = false;
        this.button1.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
        this.button1.BorderColor = System.Drawing.Color.Tomato;
        this.button1.BorderColorEnabled = false;
        this.button1.BorderColorOnHover = System.Drawing.Color.Tomato;
        this.button1.BorderColorOnHoverEnabled = false;
        this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
        this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.button1.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15F, System.Drawing.FontStyle.Bold);
        this.button1.ForeColor = System.Drawing.Color.White;
        this.button1.Location = new System.Drawing.Point(0, 0);
        this.button1.Name = "button1";
        this.button1.RippleColor = System.Drawing.Color.Black;
        this.button1.RoundingEnable = false;
        this.button1.Size = new System.Drawing.Size(216, 55);
        this.button1.TabIndex = 1;
        this.button1.Text = "Додати новий стелаж";
        this.button1.TextHover = null;
        this.button1.UseDownPressEffectOnClick = false;
        this.button1.UseRippleEffect = true;
        this.button1.UseVisualStyleBackColor = false;
        this.button1.UseZoomEffectOnHover = false;
        this.button1.Click += new System.EventHandler(this.button1_Click);
        // 
        // panel1
        // 
        this.panel1.AutoScroll = true;
        this.panel1.Controls.Add(this.button1);
        this.panel1.Location = new System.Drawing.Point(972, 12);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(216, 55);
        this.panel1.TabIndex = 2;
        // 
        // Shelf_Panel
        // 
        this.Shelf_Panel.AutoScroll = true;
        this.Shelf_Panel.Controls.Add(this.right_arrow_button);
        this.Shelf_Panel.Controls.Add(this.left_arrow_button);
        this.Shelf_Panel.Location = new System.Drawing.Point(0, 96);
        this.Shelf_Panel.Name = "Shelf_Panel";
        this.Shelf_Panel.Size = new System.Drawing.Size(1197, 503);
        this.Shelf_Panel.TabIndex = 3;
        // 
        // right_arrow_button
        // 
        this.right_arrow_button.BackgroundImage = global::Jet_Gears.Properties.Resources.Right_Arrow;
        this.right_arrow_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.right_arrow_button.FlatAppearance.BorderSize = 0;
        this.right_arrow_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.right_arrow_button.Location = new System.Drawing.Point(603, 436);
        this.right_arrow_button.Name = "right_arrow_button";
        this.right_arrow_button.Size = new System.Drawing.Size(103, 56);
        this.right_arrow_button.TabIndex = 1;
        this.right_arrow_button.UseVisualStyleBackColor = true;
        // 
        // left_arrow_button
        // 
        this.left_arrow_button.BackgroundImage = global::Jet_Gears.Properties.Resources.Left_Arrow;
        this.left_arrow_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.left_arrow_button.FlatAppearance.BorderSize = 0;
        this.left_arrow_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.left_arrow_button.Location = new System.Drawing.Point(489, 439);
        this.left_arrow_button.Name = "left_arrow_button";
        this.left_arrow_button.Size = new System.Drawing.Size(108, 56);
        this.left_arrow_button.TabIndex = 0;
        this.left_arrow_button.UseVisualStyleBackColor = true;
        // 
        // egoldsGoogleTextBox1
        // 
        this.egoldsGoogleTextBox1.BackColor = System.Drawing.Color.White;
        this.egoldsGoogleTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(59)))), ((int)(((byte)(9)))));
        this.egoldsGoogleTextBox1.BorderColorNotActive = System.Drawing.Color.DarkGray;
        this.egoldsGoogleTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.egoldsGoogleTextBox1.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold);
        this.egoldsGoogleTextBox1.FontTextPreview = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 10F, System.Drawing.FontStyle.Bold);
        this.egoldsGoogleTextBox1.ForeColor = System.Drawing.Color.Black;
        this.egoldsGoogleTextBox1.Location = new System.Drawing.Point(12, 12);
        this.egoldsGoogleTextBox1.Name = "egoldsGoogleTextBox1";
        this.egoldsGoogleTextBox1.SelectionStart = 0;
        this.egoldsGoogleTextBox1.Size = new System.Drawing.Size(954, 50);
        this.egoldsGoogleTextBox1.TabIndex = 0;
        this.egoldsGoogleTextBox1.TextInput = "";
        this.egoldsGoogleTextBox1.TextPreview = "Пошук по артикулу";
        this.egoldsGoogleTextBox1.UseSystemPasswordChar = false;
        this.egoldsGoogleTextBox1.TextChanged += new System.EventHandler(this.egoldsGoogleTextBox1_TextChanged);
        // 
        // Shelf_Form
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.AutoScroll = true;
        this.BackColor = System.Drawing.Color.White;
        this.ClientSize = new System.Drawing.Size(1200, 600);
        this.Controls.Add(this.egoldsGoogleTextBox1);
        this.Controls.Add(this.Shelf_Panel);
        this.Controls.Add(this.panel1);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Name = "Shelf_Form";
        this.Text = "Shelf_Form";
        this.panel1.ResumeLayout(false);
        this.Shelf_Panel.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.Button left_arrow_button;
    private System.Windows.Forms.Button right_arrow_button;

    private yt_DesignUI.EgoldsGoogleTextBox egoldsGoogleTextBox1;

    private System.Windows.Forms.Panel Shelf_Panel;

    private System.Windows.Forms.Panel panel1;

    private Jet_Gears.Controls.button button1;

    #endregion
}