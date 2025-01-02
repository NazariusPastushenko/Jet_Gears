using System.ComponentModel;

namespace Jet_Gears
{
    partial class Basket_Form
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new Jet_Gears.Controls.button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(59)))), ((int)(((byte)(9)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 73);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 30F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(210)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(518, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Корзина";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackColorAdditional = System.Drawing.Color.Gray;
            this.button1.BackColorGradientEnabled = false;
            this.button1.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.button1.BorderColor = System.Drawing.Color.Tomato;
            this.button1.BorderColorEnabled = false;
            this.button1.BorderColorOnHover = System.Drawing.Color.Tomato;
            this.button1.BorderColorOnHoverEnabled = false;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(993, 19);
            this.button1.Name = "button1";
            this.button1.RippleColor = System.Drawing.Color.Black;
            this.button1.RoundingEnable = false;
            this.button1.Size = new System.Drawing.Size(185, 45);
            this.button1.TabIndex = 1;
            this.button1.Text = "Продаж";
            this.button1.TextHover = null;
            this.button1.UseDownPressEffectOnClick = false;
            this.button1.UseRippleEffect = true;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.UseZoomEffectOnHover = false;
            // 
            // Basket_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(144)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Basket_Form";
            this.Text = "Basket_Form";
            this.Load += new System.EventHandler(this.Basket_Form_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private Jet_Gears.Controls.button button1;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Panel panel1;

        #endregion
    }
}