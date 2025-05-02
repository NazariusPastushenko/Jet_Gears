using System.ComponentModel;

namespace Jet_Gears.Forms;

partial class Order_Details_Form
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Order_Details_Form));
        this.panel1 = new System.Windows.Forms.Panel();
        this.button1 = new System.Windows.Forms.Button();
        this.label1 = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // panel1
        // 
        this.panel1.AutoScroll = true;
        this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.panel1.Location = new System.Drawing.Point(0, 68);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(1200, 532);
        this.panel1.TabIndex = 0;
        // 
        // button1
        // 
        this.button1.BackgroundImage = global::Jet_Gears.Properties.Resources.Arrow_Left;
        this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.button1.FlatAppearance.BorderSize = 0;
        this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.button1.Location = new System.Drawing.Point(12, 12);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(60, 50);
        this.button1.TabIndex = 1;
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.button1_Click);
        // 
        // label1
        // 
        this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 30F, System.Drawing.FontStyle.Bold);
        this.label1.Location = new System.Drawing.Point(95, 12);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(1093, 50);
        this.label1.TabIndex = 2;
        // 
        // Order_Details_Form
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.ClientSize = new System.Drawing.Size(1200, 600);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.panel1);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Name = "Order_Details_Form";
        this.Text = "Order_Details_Form";
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.Panel panel1;

    #endregion
}