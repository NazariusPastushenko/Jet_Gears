using System.ComponentModel;

namespace Jet_Gears
{
    partial class Supply_Form
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
            this.CodeTextBox = new yt_DesignUI.EgoldsGoogleTextBox();
            this.MakerTextbox = new yt_DesignUI.EgoldsGoogleTextBox();
            this.PriceTextBox = new yt_DesignUI.EgoldsGoogleTextBox();
            this.DescribtionTextBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AmountControl = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.Supply_Button = new Jet_Gears.Controls.button();
            this.openPictureDialog = new System.Windows.Forms.OpenFileDialog();
            this.ChoosePicturePanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ChoosePictureLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AmountControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // CodeTextBox
            // 
            this.CodeTextBox.BackColor = System.Drawing.Color.White;
            this.CodeTextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(144)))), ((int)(((byte)(75)))));
            this.CodeTextBox.BorderColorNotActive = System.Drawing.Color.Black;
            this.CodeTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CodeTextBox.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CodeTextBox.FontTextPreview = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CodeTextBox.ForeColor = System.Drawing.Color.Black;
            this.CodeTextBox.Location = new System.Drawing.Point(47, 78);
            this.CodeTextBox.Name = "CodeTextBox";
            this.CodeTextBox.SelectionStart = 0;
            this.CodeTextBox.Size = new System.Drawing.Size(389, 52);
            this.CodeTextBox.TabIndex = 4;
            this.CodeTextBox.TextInput = "";
            this.CodeTextBox.TextPreview = "Артикул деталі";
            this.CodeTextBox.UseSystemPasswordChar = false;
            // 
            // MakerTextbox
            // 
            this.MakerTextbox.BackColor = System.Drawing.Color.White;
            this.MakerTextbox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(144)))), ((int)(((byte)(75)))));
            this.MakerTextbox.BorderColorNotActive = System.Drawing.Color.Black;
            this.MakerTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.MakerTextbox.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MakerTextbox.FontTextPreview = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Bold);
            this.MakerTextbox.ForeColor = System.Drawing.Color.Black;
            this.MakerTextbox.Location = new System.Drawing.Point(47, 171);
            this.MakerTextbox.Name = "MakerTextbox";
            this.MakerTextbox.SelectionStart = 0;
            this.MakerTextbox.Size = new System.Drawing.Size(389, 52);
            this.MakerTextbox.TabIndex = 6;
            this.MakerTextbox.TextInput = "";
            this.MakerTextbox.TextPreview = "Виробник";
            this.MakerTextbox.UseSystemPasswordChar = false;
            // 
            // PriceTextBox
            // 
            this.PriceTextBox.BackColor = System.Drawing.Color.White;
            this.PriceTextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(144)))), ((int)(((byte)(75)))));
            this.PriceTextBox.BorderColorNotActive = System.Drawing.Color.Black;
            this.PriceTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PriceTextBox.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PriceTextBox.FontTextPreview = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Bold);
            this.PriceTextBox.ForeColor = System.Drawing.Color.Black;
            this.PriceTextBox.Location = new System.Drawing.Point(47, 229);
            this.PriceTextBox.Name = "PriceTextBox";
            this.PriceTextBox.SelectionStart = 0;
            this.PriceTextBox.Size = new System.Drawing.Size(389, 52);
            this.PriceTextBox.TabIndex = 7;
            this.PriceTextBox.TextInput = "";
            this.PriceTextBox.TextPreview = "Ціна";
            this.PriceTextBox.UseSystemPasswordChar = false;
            // 
            // DescribtionTextBox
            // 
            this.DescribtionTextBox.Location = new System.Drawing.Point(47, 337);
            this.DescribtionTextBox.Name = "DescribtionTextBox";
            this.DescribtionTextBox.Size = new System.Drawing.Size(389, 179);
            this.DescribtionTextBox.TabIndex = 8;
            this.DescribtionTextBox.Text = "";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(47, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(389, 40);
            this.label2.TabIndex = 9;
            this.label2.Text = "Коментарі";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AmountControl
            // 
            this.AmountControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AmountControl.Location = new System.Drawing.Point(144, 139);
            this.AmountControl.Name = "AmountControl";
            this.AmountControl.Size = new System.Drawing.Size(92, 29);
            this.AmountControl.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(48, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 29);
            this.label3.TabIndex = 11;
            this.label3.Text = "Кількість";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Supply_Button
            // 
            this.Supply_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(100)))), ((int)(((byte)(29)))));
            this.Supply_Button.BackColorAdditional = System.Drawing.Color.Gray;
            this.Supply_Button.BackColorGradientEnabled = false;
            this.Supply_Button.BackColorGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.Supply_Button.BorderColor = System.Drawing.Color.Tomato;
            this.Supply_Button.BorderColorEnabled = false;
            this.Supply_Button.BorderColorOnHover = System.Drawing.Color.Tomato;
            this.Supply_Button.BorderColorOnHoverEnabled = false;
            this.Supply_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Supply_Button.Dock = System.Windows.Forms.DockStyle.Top;
            this.Supply_Button.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 14.25F, System.Drawing.FontStyle.Bold);
            this.Supply_Button.ForeColor = System.Drawing.Color.White;
            this.Supply_Button.Location = new System.Drawing.Point(0, 0);
            this.Supply_Button.Name = "Supply_Button";
            this.Supply_Button.RippleColor = System.Drawing.Color.Black;
            this.Supply_Button.RoundingEnable = false;
            this.Supply_Button.Size = new System.Drawing.Size(1200, 44);
            this.Supply_Button.TabIndex = 12;
            this.Supply_Button.Text = "Додати деталь";
            this.Supply_Button.TextHover = null;
            this.Supply_Button.UseDownPressEffectOnClick = false;
            this.Supply_Button.UseRippleEffect = true;
            this.Supply_Button.UseVisualStyleBackColor = false;
            this.Supply_Button.UseZoomEffectOnHover = false;
            this.Supply_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // openPictureDialog
            // 
            this.openPictureDialog.FileName = "openPictureDialog";
            // 
            // ChoosePicturePanel
            // 
            this.ChoosePicturePanel.BackColor = System.Drawing.Color.Transparent;
            this.ChoosePicturePanel.BackgroundImage = global::Jet_Gears.Properties.Resources.Picture_Icon;
            this.ChoosePicturePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ChoosePicturePanel.Location = new System.Drawing.Point(773, 214);
            this.ChoosePicturePanel.Name = "ChoosePicturePanel";
            this.ChoosePicturePanel.Size = new System.Drawing.Size(142, 147);
            this.ChoosePicturePanel.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(553, 78);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(540, 438);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ChoosePictureLabel
            // 
            this.ChoosePictureLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChoosePictureLabel.ForeColor = System.Drawing.Color.Black;
            this.ChoosePictureLabel.Location = new System.Drawing.Point(655, 171);
            this.ChoosePictureLabel.Name = "ChoosePictureLabel";
            this.ChoosePictureLabel.Size = new System.Drawing.Size(389, 40);
            this.ChoosePictureLabel.TabIndex = 14;
            this.ChoosePictureLabel.Text = "Обери своє зображення";
            this.ChoosePictureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Supply_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ChoosePictureLabel);
            this.Controls.Add(this.ChoosePicturePanel);
            this.Controls.Add(this.Supply_Button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AmountControl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DescribtionTextBox);
            this.Controls.Add(this.PriceTextBox);
            this.Controls.Add(this.MakerTextbox);
            this.Controls.Add(this.CodeTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Supply_Form";
            this.Text = "Supply_Form";
            ((System.ComponentModel.ISupportInitialize)(this.AmountControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox pictureBox1;

        private System.Windows.Forms.Label ChoosePictureLabel;

        private System.Windows.Forms.Panel ChoosePicturePanel;

        private System.Windows.Forms.OpenFileDialog openPictureDialog;

        private Jet_Gears.Controls.button Supply_Button;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.NumericUpDown AmountControl;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.RichTextBox DescribtionTextBox;

        private yt_DesignUI.EgoldsGoogleTextBox MakerTextbox;
        private yt_DesignUI.EgoldsGoogleTextBox PriceTextBox;

        private yt_DesignUI.EgoldsGoogleTextBox CodeTextBox;

        #endregion
    }
}