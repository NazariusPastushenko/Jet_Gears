using System.ComponentModel;

namespace Jet_Gears.Forms;

partial class HistoryForm
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
        this.Card_Panel = new System.Windows.Forms.Panel();
        this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
        this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
        this.SuspendLayout();
        // 
        // Card_Panel
        // 
        this.Card_Panel.AutoScroll = true;
        this.Card_Panel.Location = new System.Drawing.Point(12, 68);
        this.Card_Panel.Name = "Card_Panel";
        this.Card_Panel.Size = new System.Drawing.Size(1176, 520);
        this.Card_Panel.TabIndex = 0;
        // 
        // dateTimePicker2
        // 
        this.dateTimePicker2.CalendarFont = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 20F, System.Drawing.FontStyle.Bold);
        this.dateTimePicker2.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold);
        this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this.dateTimePicker2.Location = new System.Drawing.Point(202, 12);
        this.dateTimePicker2.Name = "dateTimePicker2";
        this.dateTimePicker2.Size = new System.Drawing.Size(221, 39);
        this.dateTimePicker2.TabIndex = 2;
        this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
        // 
        // dateTimePicker1
        // 
        this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Book Antiqua", 5.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.Black;
        this.dateTimePicker1.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(144)))), ((int)(((byte)(75)))));
        this.dateTimePicker1.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(59)))), ((int)(((byte)(9)))));
        this.dateTimePicker1.CalendarTrailingForeColor = System.Drawing.Color.Green;
        this.dateTimePicker1.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this.dateTimePicker1.Location = new System.Drawing.Point(12, 12);
        this.dateTimePicker1.Name = "dateTimePicker1";
        this.dateTimePicker1.Size = new System.Drawing.Size(184, 39);
        this.dateTimePicker1.TabIndex = 1;
        this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
        // 
        // HistoryForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.ClientSize = new System.Drawing.Size(1200, 600);
        this.Controls.Add(this.dateTimePicker2);
        this.Controls.Add(this.Card_Panel);
        this.Controls.Add(this.dateTimePicker1);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Name = "HistoryForm";
        this.Text = "HistoryForm";
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.DateTimePicker dateTimePicker2;

    private System.Windows.Forms.Panel Card_Panel;
    private System.Windows.Forms.DateTimePicker dateTimePicker1;

    #endregion
}