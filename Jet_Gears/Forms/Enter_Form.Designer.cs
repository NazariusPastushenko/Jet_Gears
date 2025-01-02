using System.ComponentModel;

namespace Jet_Gears
{
    partial class Enter_Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new Jet_Gears.Controls.button();
            this.textBox_Login = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RegLink = new System.Windows.Forms.LinkLabel();
            this.Close_Eye = new System.Windows.Forms.Panel();
            this.Open_Eye = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(119, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 90);
            this.label1.TabIndex = 1;
            this.label1.Text = "Вхід";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F);
            this.label2.Location = new System.Drawing.Point(49, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 38);
            this.label2.TabIndex = 4;
            this.label2.Text = "Логін";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F);
            this.label3.Location = new System.Drawing.Point(35, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 38);
            this.label3.TabIndex = 5;
            this.label3.Text = "Пароль";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(75)))), ((int)(((byte)(114)))));
            this.button1.BackColorAdditional = System.Drawing.Color.Gray;
            this.button1.BackColorGradientEnabled = false;
            this.button1.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.button1.BorderColor = System.Drawing.Color.Tomato;
            this.button1.BorderColorEnabled = false;
            this.button1.BorderColorOnHover = System.Drawing.Color.Tomato;
            this.button1.BorderColorOnHoverEnabled = false;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 349);
            this.button1.Name = "button1";
            this.button1.RippleColor = System.Drawing.Color.Black;
            this.button1.RoundingEnable = false;
            this.button1.Size = new System.Drawing.Size(435, 56);
            this.button1.TabIndex = 6;
            this.button1.Text = "Ввійти";
            this.button1.TextHover = null;
            this.button1.UseDownPressEffectOnClick = false;
            this.button1.UseRippleEffect = true;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.UseZoomEffectOnHover = false;
            this.button1.Click += new System.EventHandler(this.Registration_Button_Click);
            // 
            // textBox_Login
            // 
            this.textBox_Login.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Login.Location = new System.Drawing.Point(119, 157);
            this.textBox_Login.Name = "textBox_Login";
            this.textBox_Login.Size = new System.Drawing.Size(253, 40);
            this.textBox_Login.TabIndex = 7;
            // 
            // textBox_password
            // 
            this.textBox_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_password.Location = new System.Drawing.Point(119, 210);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(253, 40);
            this.textBox_password.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Jet_Gears.Properties.Resources.free_user_icon_3296_thumb;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.ErrorImage = global::Jet_Gears.Properties.Resources.free_user_icon_3296_thumb;
            this.pictureBox1.Image = global::Jet_Gears.Properties.Resources.free_user_icon_3296_thumb;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.InitialImage = global::Jet_Gears.Properties.Resources.free_user_icon_3296_thumb;
            this.pictureBox1.Location = new System.Drawing.Point(23, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 90);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // RegLink
            // 
            this.RegLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegLink.LinkColor = System.Drawing.Color.Black;
            this.RegLink.Location = new System.Drawing.Point(88, 270);
            this.RegLink.Name = "RegLink";
            this.RegLink.Size = new System.Drawing.Size(284, 39);
            this.RegLink.TabIndex = 14;
            this.RegLink.TabStop = true;
            this.RegLink.Text = "Немає аккаунта? Зареєструйтесь";
            this.RegLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RegLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RegLink_LinkClicked);
            // 
            // Close_Eye
            // 
            this.Close_Eye.BackgroundImage = global::Jet_Gears.Properties.Resources.Closed_Eye;
            this.Close_Eye.Location = new System.Drawing.Point(386, 210);
            this.Close_Eye.Name = "Close_Eye";
            this.Close_Eye.Size = new System.Drawing.Size(40, 40);
            this.Close_Eye.TabIndex = 15;
            this.Close_Eye.Click += new System.EventHandler(this.Close_Eye_Click);
            // 
            // Open_Eye
            // 
            this.Open_Eye.BackgroundImage = global::Jet_Gears.Properties.Resources.Open_Eye;
            this.Open_Eye.Location = new System.Drawing.Point(386, 210);
            this.Open_Eye.Name = "Open_Eye";
            this.Open_Eye.Size = new System.Drawing.Size(40, 40);
            this.Open_Eye.TabIndex = 16;
            this.Open_Eye.Click += new System.EventHandler(this.Open_Eye_Click);
            // 
            // Enter_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(435, 405);
            this.Controls.Add(this.Open_Eye);
            this.Controls.Add(this.Close_Eye);
            this.Controls.Add(this.RegLink);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_Login);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Enter_Form";
            this.Load += new System.EventHandler(this.Registration_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_Form_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel Close_Eye;
        private System.Windows.Forms.Panel Open_Eye;

        private System.Windows.Forms.LinkLabel RegLink;

        private System.Windows.Forms.PictureBox pictureBox1;

        private System.Windows.Forms.TextBox textBox_password;

        private System.Windows.Forms.TextBox textBox_Login;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Jet_Gears.Controls.button button1;

        private System.Windows.Forms.Label label1;

        #endregion
    }
}