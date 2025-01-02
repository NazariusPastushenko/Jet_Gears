using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Jet_Gears.Objects;

namespace Jet_Gears.Controls
{
    [DesignerCategory("Code")]
    public class GearCard : Control
    {
        public Gear Card_object { get; set; }
        [Category("Images")]
        [Description("Image displayed on the left side.")]
        public Image LeftImage { get; set; }

        [Category("Images")]
        [Description("Image displayed on the right bottom.")]
        public Image RightBottomImage { get; set; }

        [Category("Images")]
        [Browsable(true)]
        [Description("Width of the left image.")]
        public int LeftImageWidth { get; set; } = 40;

        [Category("Images")]
        [Browsable(true)]
        [Description("Height of the left image.")]
        public int LeftImageHeight { get; set; } = 40;

        [Category("Images")]
        [Browsable(true)]
        [Description("Width of the right bottom image.")]
        public int RightBottomImageWidth { get; set; } = 20;

        [Category("Images")]
        [Browsable(true)]
        [Description("Height of the right bottom image.")]
        public int RightBottomImageHeight { get; set; } = 20;

        [Category("Text")]
        [Description("Font size of the main text labels.")]
        public float MainTextSize { get; set; } = 10;

        [Category("Text")]
        [Description("Font size of the right labels.")]
        public float RightTextSize { get; set; } = 10;

        [Category("Text")]
        public string NameLabel { get; set; } = "Label 1";

        [Category("Text")]
        public string DescriptionLabel { get; set; } = "Label 2";

        [Category("Text")]
        public string PriceLabel { get; set; } = "Right Label 1";

        [Category("Text")]
        public string RightLabel2Text { get; set; } = "Right Label 2";

        [Category("Appearance")]
        public Color BorderColor { get; set; } = Color.DarkGray;

        [Category("Appearance")]
        public bool RoundedCorners { get; set; } = true;

        [Category("Appearance")]
        public int CornerRadius { get; set; } = 15;
        
        public event EventHandler LeftImageMouseEnter;
        
        public event EventHandler LeftImageMouseLeave;
        
        public event EventHandler BusketIcon_ImageClick;
        
        private bool isMouseOverLeftImage = false;

        public GearCard()
        {
            // Встановлюємо базові розміри контролу
            Size = new Size(1200, 60);
            DoubleBuffered = true;
            BackColor = Color.White;
            MinimumSize = new Size(100, 40); // Мінімальні розміри для правильного відображення
            
            this.MouseMove += GearCard_MouseMove;
            this.MouseLeave += GearCard_MouseLeave;
            this.MouseClick += GearCard_BusketIcon_MouseClick;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // Draw rounded background
            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            if (RoundedCorners)
            {
                using (GraphicsPath path = GetRoundedRectanglePath(rect, CornerRadius))
                {
                    using (SolidBrush brush = new SolidBrush(this.BackColor))
                    {
                        g.FillPath(brush, path);
                    }
                    using (Pen pen = new Pen(BorderColor))
                    {
                        g.DrawPath(pen, path);
                    }
                }
            }
            else
            {
                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    g.FillRectangle(brush, rect);
                }
                using (Pen pen = new Pen(BorderColor))
                {
                    g.DrawRectangle(pen, rect);
                }
            }

            // Draw left image if available
            if (LeftImage != null)
            {
                g.DrawImage(LeftImage, new Rectangle(10, 10, LeftImageWidth, LeftImageHeight));
            }

            // Draw main text labels
            using (Font font = new Font("Bahnschrift SemiBold SemiConden", MainTextSize))
            using (Brush textBrush = new SolidBrush(this.ForeColor))
            {
                g.DrawString(NameLabel, font, textBrush, new PointF(LeftImageWidth+10, 10));
                g.DrawString(DescriptionLabel, font, textBrush, new PointF(LeftImageWidth+10, 30));
            }

            // Draw right text labels
            using (Font font = new Font("Bahnschrift SemiBold SemiConden", RightTextSize))
            {
                SizeF sizeRightLabel1 = g.MeasureString(PriceLabel, font);
                SizeF sizeRightLabel2 = g.MeasureString(RightLabel2Text, font);

                g.DrawString(PriceLabel, font, Brushes.Black, new PointF(this.Width - sizeRightLabel1.Width - 60, 10));
                g.DrawString(RightLabel2Text, font, Brushes.Black, new PointF(this.Width - sizeRightLabel2.Width - 60, 30));
            }

            // Draw right bottom image if available
            if (RightBottomImage != null)
            {
                g.DrawImage(RightBottomImage, new Rectangle(this.Width - RightBottomImageWidth - 10, this.Height - RightBottomImageHeight - 10, RightBottomImageWidth, RightBottomImageHeight));
            }
        }
        
        
        private void GearCard_BusketIcon_MouseClick(object sender, MouseEventArgs e)
        {
            // Перевірка, чи був клік всередині області правого нижнього зображення
            Rectangle rightBottomImageBounds = new Rectangle(this.Width - RightBottomImageWidth - 10, this.Height - RightBottomImageHeight - 10, RightBottomImageWidth, RightBottomImageHeight);
            if (RightBottomImage != null && rightBottomImageBounds.Contains(e.Location))
            {
                // Якщо натискання в межах правого нижнього зображення, піднімаємо подію
                BusketIcon_ImageClick?.Invoke(this, EventArgs.Empty);
            }
        }
        
        private void GearCard_MouseMove(object sender, MouseEventArgs e)
        {
            // Перевірка, чи курсор всередині області лівого зображення
            Rectangle leftImageBounds = new Rectangle(10, 10, LeftImageWidth, LeftImageHeight);
            if (LeftImage != null && leftImageBounds.Contains(e.Location))
            {
                // Якщо наведено, і ми ще не підняли подію, викликаємо LeftImageMouseEnter
                if (!isMouseOverLeftImage)
                {
                    isMouseOverLeftImage = true;
                    LeftImageMouseEnter?.Invoke(this, EventArgs.Empty);
                }
            }
            else
            {
                // Якщо курсор виходить за межі зображення, піднімаємо подію LeftImageMouseLeave
                if (isMouseOverLeftImage)
                {
                    isMouseOverLeftImage = false;
                    LeftImageMouseLeave?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private void GearCard_MouseLeave(object sender, EventArgs e)
        {
            // Якщо курсор залишає контроль, піднімаємо подію LeftImageMouseLeave, якщо потрібно
            if (isMouseOverLeftImage)
            {
                isMouseOverLeftImage = false;
                LeftImageMouseLeave?.Invoke(this, EventArgs.Empty);
            }
        }
        
        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }
        
        
        
        
    }
}