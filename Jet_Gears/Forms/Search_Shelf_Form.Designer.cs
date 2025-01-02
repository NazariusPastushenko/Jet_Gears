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
            this.Search_Panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
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
            this.SearchTextBox.Location = new System.Drawing.Point(57, 66);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.SelectionStart = 0;
            this.SearchTextBox.Size = new System.Drawing.Size(1000, 64);
            this.SearchTextBox.TabIndex = 0;
            this.SearchTextBox.TextInput = "";
            this.SearchTextBox.TextPreview = "Пошук  |  Введіть артикул";
            this.SearchTextBox.UseSystemPasswordChar = false;
            // 
            // Search_Panel
            // 
            this.Search_Panel.BackgroundImage = global::Jet_Gears.Properties.Resources._0a41b1c83a9f2;
            this.Search_Panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Search_Panel.Location = new System.Drawing.Point(1093, 66);
            this.Search_Panel.Name = "Search_Panel";
            this.Search_Panel.Size = new System.Drawing.Size(70, 70);
            this.Search_Panel.TabIndex = 1;
            this.Search_Panel.Click += new System.EventHandler(this.Search_Panel_Click);
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
            // Search_Shelf_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Search_Panel);
            this.Controls.Add(this.SearchTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Search_Shelf_Form";
            this.Text = "Search_Form";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Search_Form_KeyDown);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Panel panel2;

        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.Panel Search_Panel;

        private yt_DesignUI.EgoldsGoogleTextBox SearchTextBox;

        #endregion
    }
}