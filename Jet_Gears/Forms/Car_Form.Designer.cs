using System.ComponentModel;

namespace Jet_Gears.Forms;

partial class Car_Form
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
        this.button4 = new System.Windows.Forms.Button();
        this.button3 = new System.Windows.Forms.Button();
        this.button2 = new System.Windows.Forms.Button();
        this.button1 = new System.Windows.Forms.Button();
        this.Buttons_Panel = new System.Windows.Forms.Panel();
        this.Modification_TextBox = new yt_DesignUI.EgoldsGoogleTextBox();
        this.SuspendLayout();
        // 
        // button4
        // 
        this.button4.BackColor = System.Drawing.Color.Silver;
        this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Black;
        this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.button4.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold);
        this.button4.Location = new System.Drawing.Point(513, 6);
        this.button4.Name = "button4";
        this.button4.Size = new System.Drawing.Size(168, 40);
        this.button4.TabIndex = 20;
        this.button4.Text = "Модифікація";
        this.button4.UseVisualStyleBackColor = false;
        // 
        // button3
        // 
        this.button3.BackColor = System.Drawing.SystemColors.ControlLightLight;
        this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
        this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.button3.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold);
        this.button3.Location = new System.Drawing.Point(345, 6);
        this.button3.Name = "button3";
        this.button3.Size = new System.Drawing.Size(168, 40);
        this.button3.TabIndex = 19;
        this.button3.Text = "Марка";
        this.button3.UseVisualStyleBackColor = false;
        this.button3.Click += new System.EventHandler(this.button3_Click);
        // 
        // button2
        // 
        this.button2.BackColor = System.Drawing.SystemColors.ControlLightLight;
        this.button2.Cursor = System.Windows.Forms.Cursors.Default;
        this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
        this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.button2.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold);
        this.button2.ForeColor = System.Drawing.Color.Black;
        this.button2.Location = new System.Drawing.Point(177, 6);
        this.button2.Name = "button2";
        this.button2.Size = new System.Drawing.Size(168, 40);
        this.button2.TabIndex = 18;
        this.button2.Text = "Модель";
        this.button2.UseVisualStyleBackColor = false;
        this.button2.Click += new System.EventHandler(this.button2_Click);
        // 
        // button1
        // 
        this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
        this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.button1.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold);
        this.button1.Location = new System.Drawing.Point(9, 6);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(168, 40);
        this.button1.TabIndex = 17;
        this.button1.Text = "Виробник";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.button1_Click);
        // 
        // Buttons_Panel
        // 
        this.Buttons_Panel.AutoScroll = true;
        this.Buttons_Panel.Location = new System.Drawing.Point(12, 106);
        this.Buttons_Panel.Name = "Buttons_Panel";
        this.Buttons_Panel.Size = new System.Drawing.Size(1193, 492);
        this.Buttons_Panel.TabIndex = 16;
        // 
        // Modification_TextBox
        // 
        this.Modification_TextBox.BackColor = System.Drawing.Color.White;
        this.Modification_TextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(59)))), ((int)(((byte)(9)))));
        this.Modification_TextBox.BorderColorNotActive = System.Drawing.Color.DarkGray;
        this.Modification_TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.Modification_TextBox.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold);
        this.Modification_TextBox.FontTextPreview = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 10F, System.Drawing.FontStyle.Bold);
        this.Modification_TextBox.ForeColor = System.Drawing.Color.Black;
        this.Modification_TextBox.Location = new System.Drawing.Point(12, 50);
        this.Modification_TextBox.Name = "Modification_TextBox";
        this.Modification_TextBox.SelectionStart = 0;
        this.Modification_TextBox.Size = new System.Drawing.Size(1193, 50);
        this.Modification_TextBox.TabIndex = 15;
        this.Modification_TextBox.TextInput = "";
        this.Modification_TextBox.TextPreview = "Пошук";
        this.Modification_TextBox.UseSystemPasswordChar = false;
        this.Modification_TextBox.TextChanged += new System.EventHandler(this.Car_TextBox_TextChanged);
        // 
        // Car_Form
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
        this.Controls.Add(this.Modification_TextBox);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Name = "Car_Form";
        this.Text = "Car_Form";
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Panel Buttons_Panel;
    private yt_DesignUI.EgoldsGoogleTextBox Modification_TextBox;

    #endregion
}