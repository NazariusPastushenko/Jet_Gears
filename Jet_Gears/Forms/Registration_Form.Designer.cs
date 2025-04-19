using System.ComponentModel;

namespace Jet_Gears
{
    partial class Registration_Form
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
            this.Registration_Password_Textbox = new System.Windows.Forms.TextBox();
            this.Registration_Login_Textbox = new System.Windows.Forms.TextBox();
            this.Registration_Button = new Jet_Gears.Controls.button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Registration_Name_Textbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Reg_Open_Eye = new System.Windows.Forms.Panel();
            this.Reg_CloseEye = new System.Windows.Forms.Panel();
            this.BackPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Registration_Password_Textbox
            // 
            this.Registration_Password_Textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Registration_Password_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Registration_Password_Textbox.Location = new System.Drawing.Point(296, 180);
            this.Registration_Password_Textbox.Name = "Registration_Password_Textbox";
            this.Registration_Password_Textbox.Size = new System.Drawing.Size(253, 40);
            this.Registration_Password_Textbox.TabIndex = 22;
            // 
            // Registration_Login_Textbox
            // 
            this.Registration_Login_Textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Registration_Login_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Registration_Login_Textbox.Location = new System.Drawing.Point(37, 180);
            this.Registration_Login_Textbox.Name = "Registration_Login_Textbox";
            this.Registration_Login_Textbox.Size = new System.Drawing.Size(253, 40);
            this.Registration_Login_Textbox.TabIndex = 21;
            // 
            // Registration_Button
            // 
            this.Registration_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(75)))), ((int)(((byte)(114)))));
            this.Registration_Button.BackColorAdditional = System.Drawing.Color.Gray;
            this.Registration_Button.BackColorGradientEnabled = false;
            this.Registration_Button.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.Registration_Button.BorderColor = System.Drawing.Color.Tomato;
            this.Registration_Button.BorderColorEnabled = false;
            this.Registration_Button.BorderColorOnHover = System.Drawing.Color.Tomato;
            this.Registration_Button.BorderColorOnHoverEnabled = false;
            this.Registration_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Registration_Button.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Registration_Button.Font = new System.Drawing.Font("Bahnschrift", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Registration_Button.ForeColor = System.Drawing.Color.White;
            this.Registration_Button.Location = new System.Drawing.Point(0, 242);
            this.Registration_Button.Name = "Registration_Button";
            this.Registration_Button.RippleColor = System.Drawing.Color.Black;
            this.Registration_Button.RoundingEnable = false;
            this.Registration_Button.Size = new System.Drawing.Size(615, 55);
            this.Registration_Button.TabIndex = 20;
            this.Registration_Button.Text = "Зареєструватись";
            this.Registration_Button.TextHover = null;
            this.Registration_Button.UseDownPressEffectOnClick = false;
            this.Registration_Button.UseRippleEffect = true;
            this.Registration_Button.UseVisualStyleBackColor = false;
            this.Registration_Button.UseZoomEffectOnHover = false;
            this.Registration_Button.Click += new System.EventHandler(this.Registration_Button_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F);
            this.label3.Location = new System.Drawing.Point(389, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 38);
            this.label3.TabIndex = 19;
            this.label3.Text = "Пароль";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F);
            this.label2.Location = new System.Drawing.Point(132, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 38);
            this.label2.TabIndex = 18;
            this.label2.Text = "Логін";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(615, 82);
            this.label1.TabIndex = 17;
            this.label1.Text = "Реєстрація";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Registration_Name_Textbox
            // 
            this.Registration_Name_Textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Registration_Name_Textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Registration_Name_Textbox.Location = new System.Drawing.Point(202, 85);
            this.Registration_Name_Textbox.Name = "Registration_Name_Textbox";
            this.Registration_Name_Textbox.Size = new System.Drawing.Size(359, 40);
            this.Registration_Name_Textbox.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F);
            this.label4.Location = new System.Drawing.Point(37, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 38);
            this.label4.TabIndex = 25;
            this.label4.Text = "Назва магазину";
            // 
            // Reg_Open_Eye
            // 
            this.Reg_Open_Eye.BackgroundImage = global::Jet_Gears.Properties.Resources.Open_Eye;
            this.Reg_Open_Eye.Location = new System.Drawing.Point(555, 180);
            this.Reg_Open_Eye.Name = "Reg_Open_Eye";
            this.Reg_Open_Eye.Size = new System.Drawing.Size(40, 40);
            this.Reg_Open_Eye.TabIndex = 28;
            this.Reg_Open_Eye.Click += new System.EventHandler(this.Reg_OpenEye_Click);
            // 
            // Reg_CloseEye
            // 
            this.Reg_CloseEye.BackgroundImage = global::Jet_Gears.Properties.Resources.Closed_Eye;
            this.Reg_CloseEye.Location = new System.Drawing.Point(555, 180);
            this.Reg_CloseEye.Name = "Reg_CloseEye";
            this.Reg_CloseEye.Size = new System.Drawing.Size(40, 40);
            this.Reg_CloseEye.TabIndex = 29;
            this.Reg_CloseEye.Click += new System.EventHandler(this.Reg_CloseEye_Click);
            // 
            // BackPanel
            // 
            this.BackPanel.BackgroundImage = global::Jet_Gears.Properties.Resources.Arrow_Left;
            this.BackPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackPanel.Location = new System.Drawing.Point(12, 12);
            this.BackPanel.Name = "BackPanel";
            this.BackPanel.Size = new System.Drawing.Size(40, 40);
            this.BackPanel.TabIndex = 30;
            this.BackPanel.Click += new System.EventHandler(this.BackPanel_Click);
            // 
            // Registration_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(615, 297);
            this.Controls.Add(this.BackPanel);
            this.Controls.Add(this.Reg_Open_Eye);
            this.Controls.Add(this.Reg_CloseEye);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Registration_Name_Textbox);
            this.Controls.Add(this.Registration_Password_Textbox);
            this.Controls.Add(this.Registration_Login_Textbox);
            this.Controls.Add(this.Registration_Button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Registration_Form";
            this.Text = "Registration_Form";
            this.Load += new System.EventHandler(this.Registration_Form_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Registration_Form_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel BackPanel;

        private System.Windows.Forms.Panel Reg_CloseEye;

        private System.Windows.Forms.Panel Reg_Open_Eye;

        private System.Windows.Forms.TextBox Registration_Name_Textbox;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.TextBox Registration_Password_Textbox;
        private System.Windows.Forms.TextBox Registration_Login_Textbox;
        private Jet_Gears.Controls.button Registration_Button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

        #endregion
    }
}