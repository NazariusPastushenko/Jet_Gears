using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.Windows.Forms;

namespace Jet_Gears.Controls
{
    public class ImageTextButton : button
    {
        private Image _image;

        /// <summary>
        /// URL зображення, яке буде відображатися на кнопці.
        /// </summary>
        public string ImageUrl
        {
            get => _imageUrl;
            set
            {
                _imageUrl = value;
                LoadImageFromUrl(value);
            }
        }
        private string _imageUrl;

        /// <summary>
        /// Розмір зображення, що відображається на кнопці.
        /// </summary>
        public Size ImageSize { get; set; } = new Size(170, 100);

        /// <summary>
        /// Вирівнювання зображення.
        /// </summary>
        public ContentAlignment ImageAlignment { get; set; } = ContentAlignment.MiddleLeft;

        private void LoadImageFromUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) return;

            try
            {
                using (var client = new WebClient())
                {
                    var imageData = client.DownloadData(url);
                    using (var stream = new System.IO.MemoryStream(imageData))
                    {
                        _image = Image.FromStream(stream);
                    }
                }
                Invalidate(); // Оновлюємо відображення кнопки
            }
            catch
            {
                _image = null; // Якщо завантаження не вдалося
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            TextAlign = ContentAlignment.MiddleRight;
            base.OnPaint(e);
            var graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Визначення області для зображення
            Rectangle imageBounds = new Rectangle(
                Padding.Left,
                (Height - ImageSize.Height) / 2,
                ImageSize.Width,
                ImageSize.Height
            );

            // Малювання зображення
            if (_image != null)
            {
                graphics.DrawImage(_image, imageBounds);
            }

            // Визначення області для тексту
            int textOffset = ImageSize.Width + Padding.Left + 10;
            Rectangle textBounds = new Rectangle(
                textOffset,
                0,
                Width - textOffset - Padding.Right,
                Height
            );
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ImageTextButton
            // 
            this.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ResumeLayout(false);
        }
    }
}