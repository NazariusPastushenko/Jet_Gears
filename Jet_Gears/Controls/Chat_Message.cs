using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Jet_Gears.Controls
{
    public class ChatMessageControl : UserControl
    {
        public enum SenderType
        {
            User,
            Assistant
        }

        public string Message { get; set; }
        public SenderType Sender { get; set; }

        private int padding = 10;
        private int cornerRadius = 16;
        private Font messageFont = new Font("Bahnschrift", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));

        public ChatMessageControl(string message, int maxWidth, SenderType sender)
        {
            Message = message;
            Sender = sender;

            this.DoubleBuffered = true;
            this.BackColor = Color.Transparent;
            this.AutoSize = false;
            this.Width = Math.Min(maxWidth, 600); // за замовчуванням ширина

            AdjustSize();
        }

        private void AdjustSize()
        {
            if (string.IsNullOrEmpty(Message))
                return;

            int bubbleWidth = this.Width - 40;
            if (bubbleWidth < 50) bubbleWidth = 50;

            Size textSize = TextRenderer.MeasureText(
                Message,
                messageFont,
                new Size(bubbleWidth - padding * 2, 0),
                TextFormatFlags.WordBreak
            );

            int newHeight = textSize.Height + padding * 2 + 10;
            this.Height = newHeight;
        }

        

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            Rectangle bubbleRect;
            Point[] tail;

            Color bubbleColor = Sender == SenderType.User ? Color.FromArgb(0, 120, 215) : Color.DimGray;
            Color textColor = Sender == SenderType.User ? Color.White : SystemColors.ControlLightLight;

            if (Sender == SenderType.User)
            {
                bubbleRect = new Rectangle(20, 0, Width - 30, Height - 10);
                tail = new Point[]
                {
                    new Point(Width - 15, Height - 20),
                    new Point(Width, Height),
                    new Point(Width - 30, Height - 10)
                };
            }
            else
            {
                bubbleRect = new Rectangle(10, 0, Width - 30, Height - 10);
                tail = new Point[]
                {
                    new Point(12, Height - 20),
                    new Point(0, Height - 5),
                    new Point(30, Height - 10)
                };
            }

            using (GraphicsPath path = RoundedRect(bubbleRect, cornerRadius))
            using (SolidBrush brush = new SolidBrush(bubbleColor))
            using (SolidBrush textBrush = new SolidBrush(textColor))
            {
                g.FillPath(brush, path);
                g.FillPolygon(brush, tail);

                Rectangle textRect = new Rectangle(
                    bubbleRect.X + padding,
                    bubbleRect.Y + padding,
                    bubbleRect.Width - padding * 2,
                    bubbleRect.Height - padding * 2
                );

                TextRenderer.DrawText(g, Message, messageFont, textRect, textColor, TextFormatFlags.WordBreak);
            }
        }


        private GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            var path = new GraphicsPath();

            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ChatMessageControl
            // 
            this.Name = "ChatMessageControl";
            this.Size = new System.Drawing.Size(121, 112);
            this.ResumeLayout(false);
        }
    }
}
