using System.ComponentModel;

namespace Jet_Gears.Forms;

partial class AI_Assistant_Chat
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
        this.panel2 = new System.Windows.Forms.Panel();
        this.label1 = new System.Windows.Forms.Label();
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.Chat_Panel = new System.Windows.Forms.Panel();
        this.Send_Message_Button = new System.Windows.Forms.Button();
        this.panel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // panel1
        // 
        this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(59)))), ((int)(((byte)(9)))));
        this.panel1.Controls.Add(this.panel2);
        this.panel1.Controls.Add(this.label1);
        this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
        this.panel1.Location = new System.Drawing.Point(0, 0);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(1200, 73);
        this.panel1.TabIndex = 0;
        // 
        // panel2
        // 
        this.panel2.BackColor = System.Drawing.Color.White;
        this.panel2.Location = new System.Drawing.Point(0, 79);
        this.panel2.Name = "panel2";
        this.panel2.Size = new System.Drawing.Size(1200, 73);
        this.panel2.TabIndex = 2;
        // 
        // label1
        // 
        this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 30F, System.Drawing.FontStyle.Bold);
        this.label1.ForeColor = System.Drawing.Color.White;
        this.label1.Location = new System.Drawing.Point(400, 9);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(382, 51);
        this.label1.TabIndex = 1;
        this.label1.Text = "Віртуальний помічник";
        // 
        // textBox1
        // 
        this.textBox1.Font = new System.Drawing.Font("Bahnschrift", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.textBox1.Location = new System.Drawing.Point(12, 558);
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(1119, 36);
        this.textBox1.TabIndex = 1;
        // 
        // Chat_Panel
        // 
        this.Chat_Panel.AutoScroll = true;
        this.Chat_Panel.Location = new System.Drawing.Point(3, 79);
        this.Chat_Panel.Name = "Chat_Panel";
        this.Chat_Panel.Size = new System.Drawing.Size(1194, 473);
        this.Chat_Panel.TabIndex = 2;
        // 
        // Send_Message_Button
        // 
        this.Send_Message_Button.BackgroundImage = global::Jet_Gears.Properties.Resources.Send_Button;
        this.Send_Message_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.Send_Message_Button.FlatAppearance.BorderSize = 0;
        this.Send_Message_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.Send_Message_Button.Location = new System.Drawing.Point(1128, 558);
        this.Send_Message_Button.Name = "Send_Message_Button";
        this.Send_Message_Button.Size = new System.Drawing.Size(60, 36);
        this.Send_Message_Button.TabIndex = 0;
        this.Send_Message_Button.UseVisualStyleBackColor = true;
        this.Send_Message_Button.Click += new System.EventHandler(this.Send_Message_Button_Click);
        // 
        // AI_Assistant_Chat
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.SystemColors.ControlLightLight;
        this.ClientSize = new System.Drawing.Size(1200, 600);
        this.Controls.Add(this.Send_Message_Button);
        this.Controls.Add(this.Chat_Panel);
        this.Controls.Add(this.textBox1);
        this.Controls.Add(this.panel1);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Name = "AI_Assistant_Chat";
        this.Text = "AI_Assistant";
        this.panel1.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Button Send_Message_Button;

    private System.Windows.Forms.Panel Chat_Panel;

    private System.Windows.Forms.Panel panel2;

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBox1;

    private System.Windows.Forms.Panel panel1;

    #endregion
}