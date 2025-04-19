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
        public string link { get; set; }
        public Gear Card_object { get; set; }

        [Category("Images")]
        [Description("Image displayed on the left side.")]
        public Image LeftImage { get; set; }

        [Category("Images")]
        [Description("Background image for the right bottom button.")]
        public Image RightBottomButtonImage
        {
            get => rightBottomButton.BackgroundImage;
            set => rightBottomButton.BackgroundImage = value;
        }

        [Category("Images")]
        [Description("Width of the left image.")]
        public int LeftImageWidth { get; set; } = 40;

        [Category("Images")]
        [Description("Height of the left image.")]
        public int LeftImageHeight { get; set; } = 40;

        [Category("Images")]
        [Description("Size of the right bottom button.")]
        public Size RightBottomButtonSize
        {
            get => rightBottomButton.Size;
            set
            {
                rightBottomButton.Size = value;
                Invalidate(); // перемалювати при зміні
                UpdateButtonPosition();
            }
        }

        [Category("Text")]
        public float MainTextSize { get; set; } = 10;

        [Category("Text")]
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
        private readonly Button rightBottomButton;

        public GearCard()
        {
            Size = new Size(1200, 60);
            DoubleBuffered = true;
            BackColor = Color.White;
            MinimumSize = new Size(100, 40);

            rightBottomButton = new Button
            {
                Size = new Size(20, 20),
                FlatStyle = FlatStyle.Flat,
                BackgroundImageLayout = ImageLayout.Stretch,
                TabStop = false
            };
            rightBottomButton.FlatAppearance.BorderSize = 0;
            rightBottomButton.Click += (s, e) => BusketIcon_ImageClick?.Invoke(this, EventArgs.Empty);
            Controls.Add(rightBottomButton);

            MouseMove += GearCard_MouseMove;
            MouseLeave += GearCard_MouseLeave;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateButtonPosition();
        }

        private void UpdateButtonPosition()
        {
                if (rightBottomButton == null)
                    return;
                rightBottomButton.Location = new Point(this.Width - rightBottomButton.Width - 10, this.Height - rightBottomButton.Height - 10);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            if (RoundedCorners)
            {
                using var path = GetRoundedRectanglePath(rect, CornerRadius);
                using var brush = new SolidBrush(BackColor);
                g.FillPath(brush, path);
                using var pen = new Pen(BorderColor);
                g.DrawPath(pen, path);
            }
            else
            {
                using var brush = new SolidBrush(BackColor);
                g.FillRectangle(brush, rect);
                using var pen = new Pen(BorderColor);
                g.DrawRectangle(pen, rect);
            }

            // Ліва картинка
            if (LeftImage != null)
            {
                g.DrawImage(LeftImage, new Rectangle(10, 10, LeftImageWidth, LeftImageHeight));
            }

            // Тексти зліва
            using var mainFont = new Font("Bahnschrift SemiBold SemiConden", MainTextSize);
            using var textBrush = new SolidBrush(ForeColor);
            g.DrawString(NameLabel, mainFont, textBrush, new PointF(LeftImageWidth + 10, 10));
            g.DrawString(DescriptionLabel, mainFont, textBrush, new PointF(LeftImageWidth + 10, 30));

            // Тексти справа
            using var rightFont = new Font("Bahnschrift SemiBold SemiConden", RightTextSize);
            var sizeRightLabel1 = g.MeasureString(PriceLabel, rightFont);
            var sizeRightLabel2 = g.MeasureString(RightLabel2Text, rightFont);
            g.DrawString(PriceLabel, rightFont, Brushes.Black, new PointF(Width - 500, 10));
            g.DrawString(RightLabel2Text, rightFont, Brushes.Black, new PointF(Width - sizeRightLabel2.Width - 40, 30));
        }

        private void GearCard_MouseMove(object sender, MouseEventArgs e)
        {
            Rectangle leftImageBounds = new Rectangle(10, 10, LeftImageWidth, LeftImageHeight);
            if (LeftImage != null && leftImageBounds.Contains(e.Location))
            {
                if (!isMouseOverLeftImage)
                {
                    isMouseOverLeftImage = true;
                    LeftImageMouseEnter?.Invoke(this, EventArgs.Empty);
                }
            }
            else if (isMouseOverLeftImage)
            {
                isMouseOverLeftImage = false;
                LeftImageMouseLeave?.Invoke(this, EventArgs.Empty);
            }
        }

        private void GearCard_MouseLeave(object sender, EventArgs e)
        {
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
