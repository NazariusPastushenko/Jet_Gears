using System.ComponentModel;

namespace Jet_Gears.Forms;

partial class Ask_ShelfPlace_Form
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
        this.treeView1 = new System.Windows.Forms.TreeView();
        this.button1 = new Jet_Gears.Controls.button();
        this.label2 = new System.Windows.Forms.Label();
        this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
        this.label3 = new System.Windows.Forms.Label();
        this.textBox1 = new System.Windows.Forms.TextBox();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
        this.SuspendLayout();
        // 
        // label1
        // 
        this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(59)))), ((int)(((byte)(9)))));
        this.label1.Dock = System.Windows.Forms.DockStyle.Top;
        this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label1.ForeColor = System.Drawing.Color.White;
        this.label1.Location = new System.Drawing.Point(0, 0);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(266, 76);
        this.label1.TabIndex = 0;
        this.label1.Text = "На яку полицю ви хочете добавити дану деталь?";
        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // treeView1
        // 
        this.treeView1.Dock = System.Windows.Forms.DockStyle.Top;
        this.treeView1.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
        this.treeView1.Indent = 15;
        this.treeView1.ItemHeight = 25;
        this.treeView1.Location = new System.Drawing.Point(0, 76);
        this.treeView1.Name = "treeView1";
        this.treeView1.Size = new System.Drawing.Size(266, 198);
        this.treeView1.TabIndex = 1;
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
        this.button1.Location = new System.Drawing.Point(0, 356);
        this.button1.Name = "button1";
        this.button1.RippleColor = System.Drawing.Color.Black;
        this.button1.RoundingEnable = false;
        this.button1.Size = new System.Drawing.Size(266, 44);
        this.button1.TabIndex = 2;
        this.button1.Text = "Добавити";
        this.button1.TextHover = null;
        this.button1.UseDownPressEffectOnClick = false;
        this.button1.UseRippleEffect = true;
        this.button1.UseVisualStyleBackColor = false;
        this.button1.UseZoomEffectOnHover = false;
        this.button1.Click += new System.EventHandler(this.button1_Click);
        // 
        // label2
        // 
        this.label2.BackColor = System.Drawing.Color.Transparent;
        this.label2.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label2.ForeColor = System.Drawing.Color.Black;
        this.label2.Location = new System.Drawing.Point(0, 277);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(116, 33);
        this.label2.TabIndex = 3;
        this.label2.Text = "Кількість :";
        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // numericUpDown1
        // 
        this.numericUpDown1.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 17F);
        this.numericUpDown1.Location = new System.Drawing.Point(104, 277);
        this.numericUpDown1.Name = "numericUpDown1";
        this.numericUpDown1.Size = new System.Drawing.Size(59, 35);
        this.numericUpDown1.TabIndex = 4;
        // 
        // label3
        // 
        this.label3.BackColor = System.Drawing.Color.Transparent;
        this.label3.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label3.ForeColor = System.Drawing.Color.Black;
        this.label3.Location = new System.Drawing.Point(0, 313);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(170, 33);
        this.label3.TabIndex = 5;
        this.label3.Text = "Ціна за одиницю:";
        this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // textBox1
        // 
        this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.textBox1.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 18F, System.Drawing.FontStyle.Bold);
        this.textBox1.Location = new System.Drawing.Point(161, 314);
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(105, 36);
        this.textBox1.TabIndex = 7;
        // 
        // Ask_ShelfPlace_Form
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.ClientSize = new System.Drawing.Size(266, 400);
        this.Controls.Add(this.textBox1);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.numericUpDown1);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.treeView1);
        this.Controls.Add(this.label1);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Name = "Ask_ShelfPlace_Form";
        this.Text = "Ask_ShelfPlace_Form";
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.TextBox textBox1;

    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.NumericUpDown numericUpDown1;

    private System.Windows.Forms.Label label2;

    private Jet_Gears.Controls.button button1;

    private System.Windows.Forms.TreeView treeView1;

    private System.Windows.Forms.Label label1;

    #endregion
}