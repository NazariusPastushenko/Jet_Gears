using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Jet_Gears.Controls;

[DesignerCategory("Code")]
[DefaultProperty("ShelfCount")]
public class ShelfControl : Control
{
    private int shelfCount = 4;
    private int lineThickness = 4;
    private Color lineColor = Color.Black;
    private int shelfWidth = 100;
    private string shelfLabelPrefix = "A";
    
    [Category("Custom Properties"), Description("Number of shelves")]
    public int ShelfCount
    {
        get => shelfCount;
        set { shelfCount = Math.Max(1, value); Invalidate(); AddShelfButtons(); }
    }

    [Category("Custom Properties"), Description("Thickness of the lines")]
    public int LineThickness
    {
        get => lineThickness;
        set { lineThickness = Math.Max(1, value); Invalidate(); }
    }

    [Category("Custom Properties"), Description("Color of the lines")]
    public Color LineColor
    {
        get => lineColor;
        set { lineColor = value; Invalidate(); }
    }

    [Category("Custom Properties"), Description("Width of the shelves")]
    public int ShelfWidth
    {
        get => shelfWidth;
        set { shelfWidth = Math.Max(10, value); Invalidate(); }
    }

    [Category("Custom Properties"), Description("Prefix for shelf labels")]
    public string ShelfLabelPrefix
    {
        get => shelfLabelPrefix;
        set { shelfLabelPrefix = value; Invalidate(); AddShelfButtons(); }
    }

    public ShelfControl()
    {
        this.DoubleBuffered = true; // Enable double buffering for smooth rendering
        this.Size = new Size(150, 200);
        this.BackColor = Color.White;
        AddShelfButtons();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        using (Pen pen = new Pen(lineColor, lineThickness))
        {
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;

            // Position of vertical lines (sides)
            int leftX = Math.Max(0, (Width - shelfWidth) / 2);
            int rightX = leftX + shelfWidth;

            // Draw vertical lines
            g.DrawLine(pen, leftX, 0, leftX, Height);
            g.DrawLine(pen, rightX, 0, rightX, Height);

            // Calculate even spacing between shelves
            float totalSpacing = (float)Height / (shelfCount + 1);

            // Draw shelves
            for (int i = 1; i <= shelfCount; i++)
            {
                float y = i * totalSpacing;
                g.DrawLine(pen, leftX, y, rightX, y);
            }
        }
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        Invalidate(); // Refresh the drawing on resize
        AddShelfButtons();
    }

    private void AddShelfButtons()
    {
        Controls.Clear();

        float totalSpacing = (float)Height / (shelfCount + 1);
        int leftX = Math.Max(0, (Width - shelfWidth) / 2);

        for (int i = 1; i <= shelfCount; i++)
        {
            float y = i * totalSpacing;

            button button = new button()
            {
                Text = $"{shelfLabelPrefix}{i}",
                Tag = $"{shelfLabelPrefix}{i}",
                Location = new Point(leftX + (shelfWidth / 2) - 25, (int)y - 30), // Точно над полицею
                Size = new Size(70, 30),
                BackColor = Color.FromArgb(39, 59, 9)
            };
            button.ForeColor = Color.White;
            button.Font = new Font("Bahnschrift SemiBold SemiConden", 15,FontStyle.Bold);
            Controls.Add(button);
        }
    }

}
