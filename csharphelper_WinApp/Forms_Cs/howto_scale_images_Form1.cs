using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_scale_images_Form1:Form
  { 


        public howto_scale_images_Form1()
        {
            InitializeComponent();
        }

        // The loaded image.
        private Bitmap LoadedImage = null;

        // True if we should ignore change events.
        private bool IgnoreChanges = false;

        // Load an image file.
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    LoadedImage = LoadBitmap(ofdImage.FileName);
                    SetScale(1, true, true, true);
                    mnuFileSaveAs.Enabled = true;
                    txtWidth.Enabled = true;
                    txtHeight.Enabled = true;
                    txtPercent.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Load a bitmap without locking the file.
        private Bitmap LoadBitmap(string filename)
        {
            using (Bitmap bm = new Bitmap(filename))
            {
                return (Bitmap)bm.Clone();
            }
        }

        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (sfdImage.ShowDialog() == DialogResult.OK)
            {
                SaveImage(picBackground.Image, sfdImage.FileName);
            }
        }

        private void SetScale(double scale,
            bool show_width, bool show_height, bool show_percent)
        {
            int width = (int)(LoadedImage.Width * scale);
            int height = (int)(LoadedImage.Height * scale);
            if ((width < 1) || (height < 1)) return;

            Bitmap scaled_image = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(scaled_image))
            {
                gr.InterpolationMode = InterpolationMode.HighQualityBilinear;
                Rectangle source = new Rectangle(
                    0, 0, LoadedImage.Width, LoadedImage.Height);
                Point[] dest =
                {
                    new Point(0, 0),
                    new Point(width, 0),
                    new Point(0, height),
                };
                gr.DrawImage(LoadedImage, dest, source, GraphicsUnit.Pixel);
            }
            picBackground.Image = scaled_image;

            IgnoreChanges = true;
            if (show_width) txtWidth.Text = width.ToString("0");
            if (show_height) txtHeight.Text = height.ToString("0");
            if (show_percent)
            {
                int percent = (int)(scale * 100);
                txtPercent.Text = percent.ToString("0");
            }
            IgnoreChanges = false;
        }

        private void txtWidth_TextChanged(object sender, EventArgs e)
        {
            if (IgnoreChanges) return;

            double width;
            if (double.TryParse(txtWidth.Text, out width))
            {
                SetScale(width / LoadedImage.Width, false, true, true);
            }
        }

        private void txtHeight_TextChanged(object sender, EventArgs e)
        {
            if (IgnoreChanges) return;

            double height;
            if (double.TryParse(txtHeight.Text, out height))
            {
                SetScale(height / LoadedImage.Height, true, false, true);
            }
        }

        private void txtPercent_TextChanged(object sender, EventArgs e)
        {
            if (IgnoreChanges) return;

            double percent;
            if (double.TryParse(txtPercent.Text, out percent))
            {
                SetScale(percent / 100, true, true, false);
            }
        }

        // Save the file with the appropriate format.
        public void SaveImage(Image image, string filename)
        {
            string extension = Path.GetExtension(filename);
            switch (extension.ToLower())
            {
                case ".bmp":
                    image.Save(filename, ImageFormat.Bmp);
                    break;
                case ".exif":
                    image.Save(filename, ImageFormat.Exif);
                    break;
                case ".gif":
                    image.Save(filename, ImageFormat.Gif);
                    break;
                case ".jpg":
                case ".jpeg":
                    image.Save(filename, ImageFormat.Jpeg);
                    break;
                case ".png":
                    image.Save(filename, ImageFormat.Png);
                    break;
                case ".tif":
                case ".tiff":
                    image.Save(filename, ImageFormat.Tiff);
                    break;
                default:
                    throw new NotSupportedException(
                        "Unknown file extension " + extension);
            }
        }
    

/// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.label1 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.txtPercent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sfdImage = new System.Windows.Forms.SaveFileDialog();
            this.ofdImage = new System.Windows.Forms.OpenFileDialog();
            this.picBackground = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Width:";
            // 
            // txtWidth
            // 
            this.txtWidth.Enabled = false;
            this.txtWidth.Location = new System.Drawing.Point(59, 27);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(42, 20);
            this.txtWidth.TabIndex = 1;
            this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtWidth.TextChanged += new System.EventHandler(this.txtWidth_TextChanged);
            // 
            // txtHeight
            // 
            this.txtHeight.Enabled = false;
            this.txtHeight.Location = new System.Drawing.Point(59, 53);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(42, 20);
            this.txtHeight.TabIndex = 3;
            this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHeight.TextChanged += new System.EventHandler(this.txtHeight_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Height:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.mnuFileSaveAs});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(163, 22);
            this.mnuFileOpen.Text = "&Open...";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSaveAs
            // 
            this.mnuFileSaveAs.Enabled = false;
            this.mnuFileSaveAs.Name = "mnuFileSaveAs";
            this.mnuFileSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSaveAs.Size = new System.Drawing.Size(163, 22);
            this.mnuFileSaveAs.Text = "&Save As...";
            this.mnuFileSaveAs.Click += new System.EventHandler(this.mnuFileSaveAs_Click);
            // 
            // txtPercent
            // 
            this.txtPercent.Enabled = false;
            this.txtPercent.Location = new System.Drawing.Point(192, 40);
            this.txtPercent.Name = "txtPercent";
            this.txtPercent.Size = new System.Drawing.Size(42, 20);
            this.txtPercent.TabIndex = 6;
            this.txtPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPercent.TextChanged += new System.EventHandler(this.txtPercent_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Percent:";
            // 
            // sfdImage
            // 
            this.sfdImage.DefaultExt = "png";
            this.sfdImage.Filter = "Picture files|*.bmp;*.jpg;*.gif;*.png;*.tif|All Files|*.*";
            // 
            // ofdImage
            // 
            this.ofdImage.DefaultExt = "png";
            this.ofdImage.Filter = "Picture files|*.bmp;*.jpg;*.gif;*.png;*.tif|All Files|*.*";
            // 
            // picBackground
            // 
            this.picBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picBackground.BackgroundImage = Properties.Resources.Check;
            this.picBackground.Location = new System.Drawing.Point(0, 79);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(284, 183);
            this.picBackground.TabIndex = 7;
            this.picBackground.TabStop = false;
            // 
            // howto_scale_images_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.picBackground);
            this.Controls.Add(this.txtPercent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_scale_images_Form1";
            this.Text = "howto_scale_images";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        private System.Windows.Forms.TextBox txtPercent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SaveFileDialog sfdImage;
        private System.Windows.Forms.OpenFileDialog ofdImage;
        private System.Windows.Forms.PictureBox picBackground;
    }
}

