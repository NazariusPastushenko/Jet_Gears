using System.ComponentModel;

namespace Jet_Gears.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search_Shelf_Form));
            this.LeftArrow_Button = new System.Windows.Forms.Button();
            this.RightArrow_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.LeftArrow_Button.Visible = false;
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
            // Search_Shelf_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.LeftArrow_Button);
            this.Controls.Add(this.RightArrow_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Search_Shelf_Form";
            this.Text = "Search_Form";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button LeftArrow_Button;
        private System.Windows.Forms.Button RightArrow_Button;

        #endregion
    }
}