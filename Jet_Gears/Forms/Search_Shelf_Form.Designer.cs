using System.ComponentModel;

namespace Jet_Gears
{
    partial class Search_Shelf_Form
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
            this.SearchTextBox = new yt_DesignUI.EgoldsGoogleTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.LeftArrow_Button = new System.Windows.Forms.Button();
            this.RightArrow_Button = new System.Windows.Forms.Button();
            this.Shelf_Search_Button = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.BackColor = System.Drawing.Color.White;
            this.SearchTextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(144)))), ((int)(((byte)(75)))));
            this.SearchTextBox.BorderColorNotActive = System.Drawing.Color.Black;
            this.SearchTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SearchTextBox.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 14.25F, System.Drawing.FontStyle.Bold);
            this.SearchTextBox.FontTextPreview = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchTextBox.ForeColor = System.Drawing.Color.Black;
            this.SearchTextBox.Location = new System.Drawing.Point(0, 54);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.SelectionStart = 0;
            this.SearchTextBox.Size = new System.Drawing.Size(1200, 55);
            this.SearchTextBox.TabIndex = 0;
            this.SearchTextBox.TextInput = "";
            this.SearchTextBox.TextPreview = "";
            this.SearchTextBox.UseSystemPasswordChar = false;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Jet_Gears.Properties.Resources.star;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(1167, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(25, 25);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(59)))), ((int)(((byte)(9)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1200, 60);
            this.panel2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 30F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(502, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Наявність";
            // 
            // LeftArrow_Button
            // 
            this.LeftArrow_Button.BackColor = System.Drawing.Color.Transparent;
            this.LeftArrow_Button.BackgroundImage = global::Jet_Gears.Properties.Resources.Left_Arrow;
            this.LeftArrow_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LeftArrow_Button.FlatAppearance.BorderSize = 0;
            this.LeftArrow_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LeftArrow_Button.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.LeftArrow_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LeftArrow_Button.Location = new System.Drawing.Point(511, 538);
            this.LeftArrow_Button.Name = "LeftArrow_Button";
            this.LeftArrow_Button.Size = new System.Drawing.Size(71, 60);
            this.LeftArrow_Button.TabIndex = 8;
            this.LeftArrow_Button.UseVisualStyleBackColor = false;
            this.LeftArrow_Button.Click += new System.EventHandler(this.LeftArrow_Button_Click);
            // 
            // RightArrow_Button
            // 
            this.RightArrow_Button.BackColor = System.Drawing.Color.Transparent;
            this.RightArrow_Button.BackgroundImage = global::Jet_Gears.Properties.Resources.Right_Arrow;
            this.RightArrow_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RightArrow_Button.FlatAppearance.BorderSize = 0;
            this.RightArrow_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RightArrow_Button.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.RightArrow_Button.Location = new System.Drawing.Point(588, 538);
            this.RightArrow_Button.Name = "RightArrow_Button";
            this.RightArrow_Button.Size = new System.Drawing.Size(71, 59);
            this.RightArrow_Button.TabIndex = 7;
            this.RightArrow_Button.UseVisualStyleBackColor = false;
            this.RightArrow_Button.Click += new System.EventHandler(this.RightArrow_Button_Click);
            // 
            // Shelf_Search_Button
            // 
            this.Shelf_Search_Button.BackColor = System.Drawing.Color.White;
            this.Shelf_Search_Button.BackgroundImage = global::Jet_Gears.Properties.Resources._0a41b1c83a9f2;
            this.Shelf_Search_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Shelf_Search_Button.FlatAppearance.BorderSize = 0;
            this.Shelf_Search_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Shelf_Search_Button.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Shelf_Search_Button.Location = new System.Drawing.Point(1151, 59);
            this.Shelf_Search_Button.Name = "Shelf_Search_Button";
            this.Shelf_Search_Button.Size = new System.Drawing.Size(48, 48);
            this.Shelf_Search_Button.TabIndex = 9;
            this.Shelf_Search_Button.UseVisualStyleBackColor = false;
            this.Shelf_Search_Button.Click += new System.EventHandler(this.Shelf_Search_Button_Click);
            // 
            // Search_Shelf_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.Shelf_Search_Button);
            this.Controls.Add(this.LeftArrow_Button);
            this.Controls.Add(this.RightArrow_Button);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SearchTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Search_Shelf_Form";
            this.Text = "Search_Form";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Search_Form_KeyDown);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button Shelf_Search_Button;

        private System.Windows.Forms.Button LeftArrow_Button;
        private System.Windows.Forms.Button RightArrow_Button;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Panel panel2;

        private System.Windows.Forms.Panel panel1;

        private yt_DesignUI.EgoldsGoogleTextBox SearchTextBox;

        #endregion
    }
}