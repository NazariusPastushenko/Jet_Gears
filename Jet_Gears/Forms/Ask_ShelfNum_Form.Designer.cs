using System.ComponentModel;

namespace Jet_Gears.Forms;

partial class Ask_ShelfNum_Form
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
        this.label2 = new System.Windows.Forms.Label();
        this.label1 = new System.Windows.Forms.Label();
        this.ShelfPrefix_TextBox = new yt_DesignUI.EgoldsGoogleTextBox();
        this.button1 = new Jet_Gears.Controls.button();
        this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
        this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
        this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
        this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
        this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
        this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
        this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
        this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
        this.flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
        this.button2 = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
        this.flowLayoutPanel1.SuspendLayout();
        this.flowLayoutPanel3.SuspendLayout();
        this.flowLayoutPanel5.SuspendLayout();
        this.flowLayoutPanel6.SuspendLayout();
        this.SuspendLayout();
        // 
        // label2
        // 
        this.label2.BackColor = System.Drawing.Color.Transparent;
        this.label2.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label2.ForeColor = System.Drawing.Color.Black;
        this.label2.Location = new System.Drawing.Point(0, 3);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(583, 40);
        this.label2.TabIndex = 10;
        this.label2.Text = "Конструктор";
        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label1
        // 
        this.label1.BackColor = System.Drawing.Color.Transparent;
        this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label1.ForeColor = System.Drawing.Color.Black;
        this.label1.Location = new System.Drawing.Point(12, 69);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(180, 40);
        this.label1.TabIndex = 11;
        this.label1.Text = "Кількість полиць :";
        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // ShelfPrefix_TextBox
        // 
        this.ShelfPrefix_TextBox.BackColor = System.Drawing.Color.White;
        this.ShelfPrefix_TextBox.BorderColor = System.Drawing.Color.Navy;
        this.ShelfPrefix_TextBox.BorderColorNotActive = System.Drawing.Color.Black;
        this.ShelfPrefix_TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ShelfPrefix_TextBox.Font = new System.Drawing.Font("Arial", 11.25F);
        this.ShelfPrefix_TextBox.FontTextPreview = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
        this.ShelfPrefix_TextBox.ForeColor = System.Drawing.Color.Black;
        this.ShelfPrefix_TextBox.Location = new System.Drawing.Point(12, 141);
        this.ShelfPrefix_TextBox.Name = "ShelfPrefix_TextBox";
        this.ShelfPrefix_TextBox.SelectionStart = 0;
        this.ShelfPrefix_TextBox.Size = new System.Drawing.Size(256, 48);
        this.ShelfPrefix_TextBox.TabIndex = 13;
        this.ShelfPrefix_TextBox.TextInput = "";
        this.ShelfPrefix_TextBox.TextPreview = "Введіть позначення полиць";
        this.ShelfPrefix_TextBox.UseSystemPasswordChar = false;
        this.ShelfPrefix_TextBox.TextChanged += new System.EventHandler(this.ShelfPrefix_TextBox_TextChanged);
        // 
        // button1
        // 
        this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
        this.button1.BackColorAdditional = System.Drawing.Color.Gray;
        this.button1.BackColorGradientEnabled = false;
        this.button1.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
        this.button1.BorderColor = System.Drawing.Color.Tomato;
        this.button1.BorderColorEnabled = false;
        this.button1.BorderColorOnHover = System.Drawing.Color.Tomato;
        this.button1.BorderColorOnHoverEnabled = false;
        this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
        this.button1.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F);
        this.button1.ForeColor = System.Drawing.Color.White;
        this.button1.Location = new System.Drawing.Point(43, 284);
        this.button1.Name = "button1";
        this.button1.RippleColor = System.Drawing.Color.Black;
        this.button1.RoundingEnable = false;
        this.button1.Size = new System.Drawing.Size(193, 47);
        this.button1.TabIndex = 14;
        this.button1.Text = "Додати";
        this.button1.TextHover = null;
        this.button1.UseDownPressEffectOnClick = false;
        this.button1.UseRippleEffect = true;
        this.button1.UseVisualStyleBackColor = false;
        this.button1.UseZoomEffectOnHover = false;
        this.button1.Click += new System.EventHandler(this.button1_Click);
        // 
        // numericUpDown1
        // 
        this.numericUpDown1.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F);
        this.numericUpDown1.Location = new System.Drawing.Point(198, 71);
        this.numericUpDown1.Name = "numericUpDown1";
        this.numericUpDown1.Size = new System.Drawing.Size(70, 40);
        this.numericUpDown1.TabIndex = 15;
        this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
        // 
        // flowLayoutPanel1
        // 
        this.flowLayoutPanel1.BackColor = System.Drawing.Color.Black;
        this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
        this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 393);
        this.flowLayoutPanel1.Name = "flowLayoutPanel1";
        this.flowLayoutPanel1.Size = new System.Drawing.Size(578, 5);
        this.flowLayoutPanel1.TabIndex = 16;
        // 
        // flowLayoutPanel2
        // 
        this.flowLayoutPanel2.BackColor = System.Drawing.Color.Black;
        this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
        this.flowLayoutPanel2.Name = "flowLayoutPanel2";
        this.flowLayoutPanel2.Size = new System.Drawing.Size(583, 5);
        this.flowLayoutPanel2.TabIndex = 17;
        // 
        // flowLayoutPanel3
        // 
        this.flowLayoutPanel3.BackColor = System.Drawing.Color.Black;
        this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel4);
        this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Right;
        this.flowLayoutPanel3.Location = new System.Drawing.Point(578, 0);
        this.flowLayoutPanel3.Name = "flowLayoutPanel3";
        this.flowLayoutPanel3.Size = new System.Drawing.Size(5, 398);
        this.flowLayoutPanel3.TabIndex = 18;
        // 
        // flowLayoutPanel4
        // 
        this.flowLayoutPanel4.BackColor = System.Drawing.Color.Black;
        this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 3);
        this.flowLayoutPanel4.Name = "flowLayoutPanel4";
        this.flowLayoutPanel4.Size = new System.Drawing.Size(583, 5);
        this.flowLayoutPanel4.TabIndex = 17;
        // 
        // flowLayoutPanel5
        // 
        this.flowLayoutPanel5.BackColor = System.Drawing.Color.Black;
        this.flowLayoutPanel5.Controls.Add(this.flowLayoutPanel6);
        this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
        this.flowLayoutPanel5.Location = new System.Drawing.Point(0, 0);
        this.flowLayoutPanel5.Name = "flowLayoutPanel5";
        this.flowLayoutPanel5.Size = new System.Drawing.Size(578, 5);
        this.flowLayoutPanel5.TabIndex = 19;
        // 
        // flowLayoutPanel6
        // 
        this.flowLayoutPanel6.BackColor = System.Drawing.Color.Black;
        this.flowLayoutPanel6.Controls.Add(this.flowLayoutPanel7);
        this.flowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.flowLayoutPanel6.Location = new System.Drawing.Point(3, 3);
        this.flowLayoutPanel6.Name = "flowLayoutPanel6";
        this.flowLayoutPanel6.Size = new System.Drawing.Size(583, 5);
        this.flowLayoutPanel6.TabIndex = 17;
        // 
        // flowLayoutPanel7
        // 
        this.flowLayoutPanel7.BackColor = System.Drawing.Color.Black;
        this.flowLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.flowLayoutPanel7.Location = new System.Drawing.Point(3, 3);
        this.flowLayoutPanel7.Name = "flowLayoutPanel7";
        this.flowLayoutPanel7.Size = new System.Drawing.Size(583, 5);
        this.flowLayoutPanel7.TabIndex = 18;
        // 
        // flowLayoutPanel8
        // 
        this.flowLayoutPanel8.BackColor = System.Drawing.Color.Black;
        this.flowLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Left;
        this.flowLayoutPanel8.Location = new System.Drawing.Point(0, 5);
        this.flowLayoutPanel8.Name = "flowLayoutPanel8";
        this.flowLayoutPanel8.Size = new System.Drawing.Size(5, 388);
        this.flowLayoutPanel8.TabIndex = 20;
        // 
        // button2
        // 
        this.button2.BackgroundImage = global::Jet_Gears.Properties.Resources.Left_Arrow;
        this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
        this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.button2.Location = new System.Drawing.Point(12, 14);
        this.button2.Name = "button2";
        this.button2.Size = new System.Drawing.Size(80, 41);
        this.button2.TabIndex = 21;
        this.button2.UseVisualStyleBackColor = true;
        this.button2.Click += new System.EventHandler(this.button2_Click);
        // 
        // Ask_ShelfNum_Form
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.SystemColors.ControlLightLight;
        this.ClientSize = new System.Drawing.Size(583, 398);
        this.Controls.Add(this.button2);
        this.Controls.Add(this.flowLayoutPanel8);
        this.Controls.Add(this.flowLayoutPanel1);
        this.Controls.Add(this.flowLayoutPanel5);
        this.Controls.Add(this.flowLayoutPanel3);
        this.Controls.Add(this.numericUpDown1);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.ShelfPrefix_TextBox);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.label2);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Name = "Ask_ShelfNum_Form";
        this.Text = "Ask_ShelfNum_Form";
        this.Load += new System.EventHandler(this.Ask_ShelfNum_Form_Load);
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
        this.flowLayoutPanel1.ResumeLayout(false);
        this.flowLayoutPanel3.ResumeLayout(false);
        this.flowLayoutPanel5.ResumeLayout(false);
        this.flowLayoutPanel6.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.Button button2;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel8;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

    private System.Windows.Forms.NumericUpDown numericUpDown1;

    private Jet_Gears.Controls.button button1;

    private yt_DesignUI.EgoldsGoogleTextBox ShelfPrefix_TextBox;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Label label2;

    #endregion
}