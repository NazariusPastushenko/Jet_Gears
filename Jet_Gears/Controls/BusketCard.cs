using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Jet_Gears.Objects;

namespace Jet_Gears.Controls
{
    [DesignerCategory("Code")]
    public class BusketCard : Control
    {
        [Category("Images")]
        public Image LeftImage { get; set; }

        [Category("Images")]
        public int LeftImageWidth { get; set; } = 40;

        [Category("Images")]
        public int LeftImageHeight { get; set; } = 40;

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

        // CheckBox
        private Size CheckBoxSize = new Size(20, 20);
        private Point CheckBoxLocation = new Point(5, 20);

        [Category("Layout")]
        public CheckBox LeftCheckBox { get; private set; }

        // Дві квадратні кнопки
        public Button TopButton { get; private set; }
        public Button BottomButton { get; private set; }
        
        public event EventHandler TopButtonClicked;
        public event EventHandler BottomButtonClicked;

        private Size _actionButtonSize = new Size(30, 30);
        private Image _topButtonImage;
        private Image _bottomButtonImage;

        [Category("Images")]
        public Image TopButtonImage
        {
            get => _topButtonImage;
            set
            {
                _topButtonImage = value;
                if (TopButton != null)
                    TopButton.BackgroundImage = value;
            }
        }

        [Category("Images")]
        public Image BottomButtonImage
        {
            get => _bottomButtonImage;
            set
            {
                _bottomButtonImage = value;
                if (BottomButton != null)
                    BottomButton.BackgroundImage = value;
            }
        }

        [Category("Layout")]
        public Size ActionButtonSize
        {
            get => _actionButtonSize;
            set
            {
                _actionButtonSize = value;
                UpdateButtonLayout();
            }
        }

        public event EventHandler LeftImageMouseEnter;
        public event EventHandler LeftImageMouseLeave;
        public event EventHandler CheckBoxClicked;

        public Shelf_Gear Card_Gear;

        private bool isMouseOverLeftImage = false;

        private bool _isChecked;
        public bool Is_Checked
        {
            get => _isChecked;
            set
            {
                if (_isChecked != value)
                {
                    _isChecked = value;
                    LeftCheckBox.Checked = value; // Update the checkbox visually
                    OnCheckBoxStateChanged();
                }
            }
        }

        public BusketCard()
        {
            Size = new Size(1200, 60);
            DoubleBuffered = true;
            BackColor = Color.White;
            MinimumSize = new Size(100, 40);

            LeftCheckBox = new CheckBox
            {
                Location = CheckBoxLocation,
                Size = CheckBoxSize
            };
            LeftCheckBox.CheckedChanged += LeftCheckBox_CheckedChanged;
            Controls.Add(LeftCheckBox);

            TopButton = new Button
            {
                Size = ActionButtonSize,
                BackgroundImageLayout = ImageLayout.Stretch,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent
            };
            TopButton.FlatAppearance.BorderSize = 0;
            Controls.Add(TopButton);

            BottomButton = new Button
            {
                Size = ActionButtonSize,
                BackgroundImageLayout = ImageLayout.Stretch,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent
            };
            BottomButton.FlatAppearance.BorderSize = 0;
            Controls.Add(BottomButton);

            MouseMove += BusketCard_MouseMove;
            MouseLeave += BusketCard_MouseLeave;

            TopButton.Click += (s, e) => TopButtonClicked?.Invoke(this, EventArgs.Empty);
            BottomButton.Click += (s, e) => BottomButtonClicked?.Invoke(this, EventArgs.Empty);
            
            RepositionDynamicControls();
        }

        private void RepositionDynamicControls()
        {
            if (LeftCheckBox != null)
            {
                LeftCheckBox.Location = CheckBoxLocation;
                LeftCheckBox.Size = CheckBoxSize;
            }

            if (TopButton != null)
            {
                TopButton.Size = ActionButtonSize;
                TopButton.Location = new Point(Width - ActionButtonSize.Width - 10, 10);
            }

            if (BottomButton != null)
            {
                BottomButton.Size = ActionButtonSize;
                BottomButton.Location = new Point(Width - ActionButtonSize.Width - 10, 10 + ActionButtonSize.Height + 5);
            }
        }

        private void UpdateButtonLayout()
        {
            if (TopButton != null && BottomButton != null)
            {
                TopButton.Size = ActionButtonSize;
                TopButton.BackgroundImage = TopButtonImage;

                BottomButton.Size = ActionButtonSize;
                BottomButton.BackgroundImage = BottomButtonImage;

                RepositionDynamicControls();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (TopButton != null && BottomButton != null && LeftCheckBox != null)
                RepositionDynamicControls();
            Invalidate();
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

            int leftImageOffset = LeftCheckBox.Right + 10;
            if (LeftImage != null)
            {
                g.DrawImage(LeftImage, new Rectangle(leftImageOffset, 10, LeftImageWidth, LeftImageHeight));
            }

            using var mainFont = new Font("Bahnschrift SemiBold SemiConden", MainTextSize);
            using var textBrush = new SolidBrush(ForeColor);
            g.DrawString(NameLabel, mainFont, textBrush, new PointF(leftImageOffset + LeftImageWidth + 10, 10));
            g.DrawString(DescriptionLabel, mainFont, textBrush, new PointF(leftImageOffset + LeftImageWidth + 10, 30));

            using var rightFont= new Font("Bahnschrift SemiBold SemiConden", MainTextSize);
            SizeF sizeRightLabel1 = g.MeasureString(PriceLabel, rightFont);
            SizeF sizeRightLabel2 = g.MeasureString(RightLabel2Text, rightFont);
            g.DrawString(PriceLabel, rightFont, Brushes.Black, new PointF(Width - sizeRightLabel1.Width - 60, 10));
            g.DrawString(RightLabel2Text, rightFont, Brushes.Black, new PointF(Width - sizeRightLabel2.Width - 60, 30));
        }

        private void BusketCard_MouseMove(object sender, MouseEventArgs e)
        {
            Rectangle leftImageBounds = new Rectangle(LeftCheckBox.Right + 5, 10, LeftImageWidth, LeftImageHeight);
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

        private void BusketCard_MouseLeave(object sender, EventArgs e)
        {
            if (isMouseOverLeftImage)
            {
                isMouseOverLeftImage = false;
                LeftImageMouseLeave?.Invoke(this, EventArgs.Empty);
            }
        }

        private void LeftCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (LeftCheckBox.Checked)
            {
                // Дії при виборі чекбокса
                Is_Checked = true;
            }
            else
            {
                // Дії при знятті вибору
                Is_Checked = false;
            }

            // Сповіщаємо про натискання на чекбокс
            CheckBoxClicked?.Invoke(this, EventArgs.Empty);
        }

        private void OnCheckBoxStateChanged()
        {
            // Тепер це можна викликати при зміні стану чекбокса програмно
            CheckBoxClicked?.Invoke(this, EventArgs.Empty);
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
