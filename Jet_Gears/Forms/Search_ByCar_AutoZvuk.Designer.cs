using System.ComponentModel;

namespace Jet_Gears.Forms;

partial class Search_ByCar_AutoZvuk
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
        this.panel2 = new System.Windows.Forms.Panel();
        this.label1 = new System.Windows.Forms.Label();
        this.Buttons_Panel = new System.Windows.Forms.Panel();
        this.label2 = new System.Windows.Forms.Label();
        this.panel2.SuspendLayout();
        this.Buttons_Panel.SuspendLayout();
        this.SuspendLayout();
        // 
        // panel2
        // 
        this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(59)))), ((int)(((byte)(9)))));
        this.panel2.Controls.Add(this.label1);
        this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
        this.panel2.Location = new System.Drawing.Point(0, 0);
        this.panel2.Name = "panel2";
        this.panel2.Size = new System.Drawing.Size(1200, 60);
        this.panel2.TabIndex = 5;
        // 
        // label1
        // 
        this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 30F, System.Drawing.FontStyle.Bold);
        this.label1.ForeColor = System.Drawing.Color.White;
        this.label1.Location = new System.Drawing.Point(0, 0);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(1200, 60);
        this.label1.TabIndex = 0;
        this.label1.Text = "Пошук деталей за автомобілем";
        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // Buttons_Panel
        // 
        this.Buttons_Panel.AutoScroll = true;
        this.Buttons_Panel.Controls.Add(this.label2);
        this.Buttons_Panel.Location = new System.Drawing.Point(0, 66);
        this.Buttons_Panel.Name = "Buttons_Panel";
        this.Buttons_Panel.Size = new System.Drawing.Size(1188, 534);
        this.Buttons_Panel.TabIndex = 7;
        // 
        // label2
        // 
        this.label2.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 20F, System.Drawing.FontStyle.Bold);
        this.label2.Location = new System.Drawing.Point(486, 210);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(179, 35);
        this.label2.TabIndex = 0;
        this.label2.Text = "Завантаження...";
        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // Search_ByCar_AutoZvuk
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.ClientSize = new System.Drawing.Size(1200, 600);
        this.Controls.Add(this.Buttons_Panel);
        this.Controls.Add(this.panel2);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Name = "Search_ByCar_AutoZvuk";
        this.Text = "Search_ByCar_AutoZvuk";
        this.panel2.ResumeLayout(false);
        this.Buttons_Panel.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.Panel Buttons_Panel;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label1;

    #endregion
}