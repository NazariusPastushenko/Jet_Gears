using System.ComponentModel;

namespace Jet_Gears.Forms;

partial class Account_Form
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
        this.panel2 = new System.Windows.Forms.Panel();
        this.label1 = new System.Windows.Forms.Label();
        this.Password_TextBox = new System.Windows.Forms.TextBox();
        this.Password_label = new System.Windows.Forms.Label();
        this.Login_Label = new System.Windows.Forms.Label();
        this.Login_TextBox = new System.Windows.Forms.TextBox();
        this.ShopName_Label = new System.Windows.Forms.Label();
        this.ShopName_TextBox = new System.Windows.Forms.TextBox();
        this.Address_Label = new System.Windows.Forms.Label();
        this.Address_TextBox = new System.Windows.Forms.TextBox();
        this.Phone_Label = new System.Windows.Forms.Label();
        this.Phone_TextBox = new System.Windows.Forms.TextBox();
        this.radioButton1 = new System.Windows.Forms.RadioButton();
        this.Save_Button = new Jet_Gears.Controls.button();
        this.panel2.SuspendLayout();
        this.SuspendLayout();
        // 
        // panel2
        // 
        this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(59)))), ((int)(((byte)(9)))));
        this.panel2.Controls.Add(this.label1);
        this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
        this.panel2.Location = new System.Drawing.Point(0, 0);
        this.panel2.Name = "panel2";
        this.panel2.Size = new System.Drawing.Size(566, 60);
        this.panel2.TabIndex = 6;
        // 
        // label1
        // 
        this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 30F, System.Drawing.FontStyle.Bold);
        this.label1.ForeColor = System.Drawing.Color.White;
        this.label1.Location = new System.Drawing.Point(0, 0);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(566, 60);
        this.label1.TabIndex = 0;
        this.label1.Text = "Управління аккаунтом";
        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // Password_TextBox
        // 
        this.Password_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.Password_TextBox.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15F, System.Drawing.FontStyle.Bold);
        this.Password_TextBox.Location = new System.Drawing.Point(206, 133);
        this.Password_TextBox.Name = "Password_TextBox";
        this.Password_TextBox.Size = new System.Drawing.Size(343, 32);
        this.Password_TextBox.TabIndex = 7;
        // 
        // Password_label
        // 
        this.Password_label.BackColor = System.Drawing.Color.Transparent;
        this.Password_label.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 20F, System.Drawing.FontStyle.Bold);
        this.Password_label.ForeColor = System.Drawing.Color.Black;
        this.Password_label.Location = new System.Drawing.Point(12, 128);
        this.Password_label.Name = "Password_label";
        this.Password_label.Size = new System.Drawing.Size(188, 42);
        this.Password_label.TabIndex = 8;
        this.Password_label.Text = "Змінити пароль:";
        // 
        // Login_Label
        // 
        this.Login_Label.BackColor = System.Drawing.Color.Transparent;
        this.Login_Label.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 20F, System.Drawing.FontStyle.Bold);
        this.Login_Label.ForeColor = System.Drawing.Color.Black;
        this.Login_Label.Location = new System.Drawing.Point(12, 78);
        this.Login_Label.Name = "Login_Label";
        this.Login_Label.Size = new System.Drawing.Size(188, 42);
        this.Login_Label.TabIndex = 10;
        this.Login_Label.Text = "Змінити логін:";
        // 
        // Login_TextBox
        // 
        this.Login_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.Login_TextBox.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15F, System.Drawing.FontStyle.Bold);
        this.Login_TextBox.Location = new System.Drawing.Point(206, 82);
        this.Login_TextBox.Name = "Login_TextBox";
        this.Login_TextBox.Size = new System.Drawing.Size(343, 32);
        this.Login_TextBox.TabIndex = 9;
        this.Login_TextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
        // 
        // ShopName_Label
        // 
        this.ShopName_Label.BackColor = System.Drawing.Color.Transparent;
        this.ShopName_Label.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 20F, System.Drawing.FontStyle.Bold);
        this.ShopName_Label.ForeColor = System.Drawing.Color.Black;
        this.ShopName_Label.Location = new System.Drawing.Point(12, 185);
        this.ShopName_Label.Name = "ShopName_Label";
        this.ShopName_Label.Size = new System.Drawing.Size(205, 42);
        this.ShopName_Label.TabIndex = 11;
        this.ShopName_Label.Text = "Назва магазину:";
        // 
        // ShopName_TextBox
        // 
        this.ShopName_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.ShopName_TextBox.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15F, System.Drawing.FontStyle.Bold);
        this.ShopName_TextBox.Location = new System.Drawing.Point(223, 190);
        this.ShopName_TextBox.Name = "ShopName_TextBox";
        this.ShopName_TextBox.Size = new System.Drawing.Size(326, 32);
        this.ShopName_TextBox.TabIndex = 12;
        // 
        // Address_Label
        // 
        this.Address_Label.BackColor = System.Drawing.Color.Transparent;
        this.Address_Label.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 20F, System.Drawing.FontStyle.Bold);
        this.Address_Label.ForeColor = System.Drawing.Color.Black;
        this.Address_Label.Location = new System.Drawing.Point(12, 234);
        this.Address_Label.Name = "Address_Label";
        this.Address_Label.Size = new System.Drawing.Size(205, 42);
        this.Address_Label.TabIndex = 13;
        this.Address_Label.Text = "Адреса магазину:";
        // 
        // Address_TextBox
        // 
        this.Address_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.Address_TextBox.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15F, System.Drawing.FontStyle.Bold);
        this.Address_TextBox.Location = new System.Drawing.Point(223, 239);
        this.Address_TextBox.Name = "Address_TextBox";
        this.Address_TextBox.Size = new System.Drawing.Size(326, 32);
        this.Address_TextBox.TabIndex = 14;
        // 
        // Phone_Label
        // 
        this.Phone_Label.BackColor = System.Drawing.Color.Transparent;
        this.Phone_Label.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 20F, System.Drawing.FontStyle.Bold);
        this.Phone_Label.ForeColor = System.Drawing.Color.Black;
        this.Phone_Label.Location = new System.Drawing.Point(12, 283);
        this.Phone_Label.Name = "Phone_Label";
        this.Phone_Label.Size = new System.Drawing.Size(205, 42);
        this.Phone_Label.TabIndex = 15;
        this.Phone_Label.Text = "Номер телефону:";
        // 
        // Phone_TextBox
        // 
        this.Phone_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.Phone_TextBox.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15F, System.Drawing.FontStyle.Bold);
        this.Phone_TextBox.Location = new System.Drawing.Point(223, 288);
        this.Phone_TextBox.Name = "Phone_TextBox";
        this.Phone_TextBox.Size = new System.Drawing.Size(326, 32);
        this.Phone_TextBox.TabIndex = 16;
        // 
        // radioButton1
        // 
        this.radioButton1.AllowDrop = true;
        this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.radioButton1.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15F, System.Drawing.FontStyle.Bold);
        this.radioButton1.Location = new System.Drawing.Point(-30, 326);
        this.radioButton1.Name = "radioButton1";
        this.radioButton1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        this.radioButton1.Size = new System.Drawing.Size(314, 33);
        this.radioButton1.TabIndex = 17;
        this.radioButton1.Text = "Зробити мій аккаунт публічним";
        this.radioButton1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
        this.radioButton1.UseVisualStyleBackColor = false;
        // 
        // Save_Button
        // 
        this.Save_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(59)))), ((int)(((byte)(9)))));
        this.Save_Button.BackColorAdditional = System.Drawing.Color.Gray;
        this.Save_Button.BackColorGradientEnabled = false;
        this.Save_Button.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
        this.Save_Button.BorderColor = System.Drawing.Color.Transparent;
        this.Save_Button.BorderColorEnabled = false;
        this.Save_Button.BorderColorOnHover = System.Drawing.Color.Transparent;
        this.Save_Button.BorderColorOnHoverEnabled = false;
        this.Save_Button.Cursor = System.Windows.Forms.Cursors.Hand;
        this.Save_Button.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.Save_Button.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 18F, System.Drawing.FontStyle.Bold);
        this.Save_Button.ForeColor = System.Drawing.Color.White;
        this.Save_Button.Location = new System.Drawing.Point(0, 363);
        this.Save_Button.Name = "Save_Button";
        this.Save_Button.RippleColor = System.Drawing.Color.Black;
        this.Save_Button.Rounding = 90;
        this.Save_Button.RoundingEnable = false;
        this.Save_Button.Size = new System.Drawing.Size(566, 56);
        this.Save_Button.TabIndex = 18;
        this.Save_Button.Text = "Підтвердити зміни";
        this.Save_Button.TextHover = null;
        this.Save_Button.UseCompatibleTextRendering = true;
        this.Save_Button.UseDownPressEffectOnClick = false;
        this.Save_Button.UseMnemonic = false;
        this.Save_Button.UseRippleEffect = true;
        this.Save_Button.UseVisualStyleBackColor = false;
        this.Save_Button.UseZoomEffectOnHover = false;
        this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click_1);
        // 
        // Account_Form
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.ClientSize = new System.Drawing.Size(566, 419);
        this.Controls.Add(this.Save_Button);
        this.Controls.Add(this.radioButton1);
        this.Controls.Add(this.Phone_TextBox);
        this.Controls.Add(this.Phone_Label);
        this.Controls.Add(this.Address_TextBox);
        this.Controls.Add(this.Address_Label);
        this.Controls.Add(this.ShopName_TextBox);
        this.Controls.Add(this.ShopName_Label);
        this.Controls.Add(this.Login_Label);
        this.Controls.Add(this.Login_TextBox);
        this.Controls.Add(this.Password_label);
        this.Controls.Add(this.Password_TextBox);
        this.Controls.Add(this.panel2);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Name = "Account_Form";
        this.Text = "Account_Form";
        this.panel2.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Label Password_label;

    private Jet_Gears.Controls.button Save_Button;

    private System.Windows.Forms.RadioButton radioButton1;
    
    private System.Windows.Forms.TextBox Phone_TextBox;
    private System.Windows.Forms.TextBox textBox5;

    private System.Windows.Forms.TextBox ShopName_TextBox;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.TextBox Address_TextBox;

    private System.Windows.Forms.Label Login_Label;
    private System.Windows.Forms.Label Phone_Label ;
    private System.Windows.Forms.Label Password_Label;
    private System.Windows.Forms.Label ShopName_Label;
    
    private System.Windows.Forms.Label Address_Label;
    private System.Windows.Forms.TextBox Login_TextBox;

    private System.Windows.Forms.TextBox Password_TextBox;

    private System.Windows.Forms.TextBox textBox1;

    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label1;

    #endregion
}