using System.ComponentModel;

namespace Jet_Gears.Forms;

partial class Ask_Amount_ToCart
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
        this.Description_Label = new System.Windows.Forms.Label();
        this.label1 = new System.Windows.Forms.Label();
        this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.button1 = new Jet_Gears.Controls.button();
        this.button2 = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
        this.SuspendLayout();
        // 
        // Description_Label
        // 
        this.Description_Label.BackColor = System.Drawing.Color.Transparent;
        this.Description_Label.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 20F, System.Drawing.FontStyle.Bold);
        this.Description_Label.ForeColor = System.Drawing.Color.Black;
        this.Description_Label.Location = new System.Drawing.Point(78, 9);
        this.Description_Label.Name = "Description_Label";
        this.Description_Label.Size = new System.Drawing.Size(193, 41);
        this.Description_Label.TabIndex = 3;
        this.Description_Label.Text = "Кількість товару:";
        // 
        // label1
        // 
        this.label1.BackColor = System.Drawing.Color.Transparent;
        this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 20F, System.Drawing.FontStyle.Bold);
        this.label1.ForeColor = System.Drawing.Color.Black;
        this.label1.Location = new System.Drawing.Point(12, 58);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(202, 36);
        this.label1.TabIndex = 4;
        this.label1.Text = "Ціна за одиницю:";
        // 
        // numericUpDown1
        // 
        this.numericUpDown1.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 20F, System.Drawing.FontStyle.Bold);
        this.numericUpDown1.Location = new System.Drawing.Point(271, 10);
        this.numericUpDown1.Name = "numericUpDown1";
        this.numericUpDown1.Size = new System.Drawing.Size(70, 40);
        this.numericUpDown1.TabIndex = 5;
        // 
        // textBox1
        // 
        this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.textBox1.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 20F, System.Drawing.FontStyle.Bold);
        this.textBox1.Location = new System.Drawing.Point(210, 58);
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(119, 40);
        this.textBox1.TabIndex = 6;
        // 
        // button1
        // 
        this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(59)))), ((int)(((byte)(9)))));
        this.button1.BackColorAdditional = System.Drawing.Color.Gray;
        this.button1.BackColorGradientEnabled = false;
        this.button1.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
        this.button1.BorderColor = System.Drawing.Color.Tomato;
        this.button1.BorderColorEnabled = false;
        this.button1.BorderColorOnHover = System.Drawing.Color.Tomato;
        this.button1.BorderColorOnHoverEnabled = false;
        this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
        this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.button1.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 20F);
        this.button1.ForeColor = System.Drawing.Color.White;
        this.button1.Location = new System.Drawing.Point(0, 113);
        this.button1.Name = "button1";
        this.button1.RippleColor = System.Drawing.Color.Black;
        this.button1.RoundingEnable = false;
        this.button1.Size = new System.Drawing.Size(353, 44);
        this.button1.TabIndex = 7;
        this.button1.Text = "Додати у корзину";
        this.button1.TextHover = null;
        this.button1.UseDownPressEffectOnClick = false;
        this.button1.UseRippleEffect = true;
        this.button1.UseVisualStyleBackColor = false;
        this.button1.UseZoomEffectOnHover = false;
        this.button1.Click += new System.EventHandler(this.button1_Click);
        // 
        // button2
        // 
        this.button2.BackgroundImage = global::Jet_Gears.Properties.Resources.Left_Arrow;
        this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
        this.button2.FlatAppearance.BorderSize = 0;
        this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.button2.Location = new System.Drawing.Point(12, 3);
        this.button2.Name = "button2";
        this.button2.Size = new System.Drawing.Size(60, 52);
        this.button2.TabIndex = 8;
        this.button2.UseVisualStyleBackColor = true;
        this.button2.Click += new System.EventHandler(this.button2_Click);
        // 
        // Ask_Amount_ToCart
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.ClientSize = new System.Drawing.Size(353, 157);
        this.Controls.Add(this.button2);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.textBox1);
        this.Controls.Add(this.numericUpDown1);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.Description_Label);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Name = "Ask_Amount_ToCart";
        this.Text = "Ask_Amount_ToCart";
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Button button2;

    private Jet_Gears.Controls.button button1;

    private System.Windows.Forms.NumericUpDown numericUpDown1;
    private System.Windows.Forms.TextBox textBox1;

    private System.Windows.Forms.Label Description_Label;
    private System.Windows.Forms.Label label1;

    #endregion
}