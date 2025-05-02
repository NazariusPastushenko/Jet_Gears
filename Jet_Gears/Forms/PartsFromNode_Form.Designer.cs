using System.ComponentModel;

namespace Jet_Gears.Forms;

partial class PartsFromNode_Form
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
        this.button1 = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // panel1
        // 
        this.panel1.AutoScroll = true;
        this.panel1.Location = new System.Drawing.Point(12, 41);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(465, 576);
        this.panel1.TabIndex = 0;
        // 
        // button1
        // 
        this.button1.BackgroundImage = global::Jet_Gears.Properties.Resources.Right_Arrow;
        this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.button1.FlatAppearance.BorderSize = 0;
        this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.button1.Location = new System.Drawing.Point(376, 1);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(101, 34);
        this.button1.TabIndex = 0;
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.button1_Click);
        // 
        // PartsFromNode_Form
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.SystemColors.ControlLightLight;
        this.ClientSize = new System.Drawing.Size(481, 629);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.panel1);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Name = "PartsFromNode_Form";
        this.Text = "PartsFromNode_Form";
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.Panel panel1;

    #endregion
}