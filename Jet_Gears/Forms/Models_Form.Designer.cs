using System.ComponentModel;

namespace Jet_Gears.Forms;

partial class Models_Form
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
        this.Buttons_Panel = new System.Windows.Forms.Panel();
        this.Models_TextBox = new yt_DesignUI.EgoldsGoogleTextBox();
        this.button1 = new System.Windows.Forms.Button();
        this.button2 = new System.Windows.Forms.Button();
        this.button3 = new System.Windows.Forms.Button();
        this.button4 = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // Buttons_Panel
        // 
        this.Buttons_Panel.AutoScroll = true;
        this.Buttons_Panel.Location = new System.Drawing.Point(3, 104);
        this.Buttons_Panel.Name = "Buttons_Panel";
        this.Buttons_Panel.Size = new System.Drawing.Size(1193, 492);
        this.Buttons_Panel.TabIndex = 4;
        // 
        // Models_TextBox
        // 
        this.Models_TextBox.BackColor = System.Drawing.Color.White;
        this.Models_TextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(59)))), ((int)(((byte)(9)))));
        this.Models_TextBox.BorderColorNotActive = System.Drawing.Color.DarkGray;
        this.Models_TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.Models_TextBox.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold);
        this.Models_TextBox.FontTextPreview = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 10F, System.Drawing.FontStyle.Bold);
        this.Models_TextBox.ForeColor = System.Drawing.Color.Black;
        this.Models_TextBox.Location = new System.Drawing.Point(3, 48);
        this.Models_TextBox.Name = "Models_TextBox";
        this.Models_TextBox.SelectionStart = 0;
        this.Models_TextBox.Size = new System.Drawing.Size(1193, 50);
        this.Models_TextBox.TabIndex = 3;
        this.Models_TextBox.TextInput = "";
        this.Models_TextBox.TextPreview = "Пошук";
        this.Models_TextBox.UseSystemPasswordChar = false;
        this.Models_TextBox.TextChanged += new System.EventHandler(this.Models_TextBox_TextChanged);
        // 
        // button1
        // 
        this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
        this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.button1.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold);
        this.button1.Location = new System.Drawing.Point(8, 8);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(168, 40);
        this.button1.TabIndex = 5;
        this.button1.Text = "Виробник";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.button1_Click);
        // 
        // button2
        // 
        this.button2.BackColor = System.Drawing.Color.Silver;
        this.button2.Cursor = System.Windows.Forms.Cursors.Default;
        this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
        this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.button2.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold);
        this.button2.ForeColor = System.Drawing.Color.Black;
        this.button2.Location = new System.Drawing.Point(176, 8);
        this.button2.Name = "button2";
        this.button2.Size = new System.Drawing.Size(168, 40);
        this.button2.TabIndex = 6;
        this.button2.Text = "Модель";
        this.button2.UseVisualStyleBackColor = false;
        // 
        // button3
        // 
        this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
        this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.button3.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold);
        this.button3.Location = new System.Drawing.Point(344, 8);
        this.button3.Name = "button3";
        this.button3.Size = new System.Drawing.Size(168, 40);
        this.button3.TabIndex = 7;
        this.button3.Text = "Марка";
        this.button3.UseVisualStyleBackColor = true;
        this.button3.Click += new System.EventHandler(this.button3_Click);
        // 
        // button4
        // 
        this.button4.BackColor = System.Drawing.SystemColors.ControlLightLight;
        this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Black;
        this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.button4.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold);
        this.button4.Location = new System.Drawing.Point(512, 8);
        this.button4.Name = "button4";
        this.button4.Size = new System.Drawing.Size(168, 40);
        this.button4.TabIndex = 15;
        this.button4.Text = "Модифікація";
        this.button4.UseVisualStyleBackColor = false;
        this.button4.Click += new System.EventHandler(this.button4_Click);
        // 
        // Models_Form
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.SystemColors.ControlLightLight;
        this.ClientSize = new System.Drawing.Size(1200, 600);
        this.Controls.Add(this.button4);
        this.Controls.Add(this.button3);
        this.Controls.Add(this.button2);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.Buttons_Panel);
        this.Controls.Add(this.Models_TextBox);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Name = "Models_Form";
        this.Text = "Models_Form";
        this.Load += new System.EventHandler(this.Models_Form_Load);
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.Button button4;

    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.Panel Buttons_Panel;
    private yt_DesignUI.EgoldsGoogleTextBox Models_TextBox;

    #endregion
}