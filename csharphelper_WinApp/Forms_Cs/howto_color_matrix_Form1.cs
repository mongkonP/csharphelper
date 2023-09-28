using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Imaging;
using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_color_matrix_Form1:Form
  { 


        public howto_color_matrix_Form1()
        {
            InitializeComponent();
        }

        // The original and transformed images.
        private Image OriginalImage = null;
        private Image TransformedImage = null;

        // Disable the items in the Picture menu. (Even though
        // that menu is already disabled, the items' shortcut
        // keys still work if they are enabled.)
        private void howto_color_matrix_Form1_Load(object sender, EventArgs e)
        {
            EnableMenu(mnuPicture, false);
        }

        private Image ApplyColorMatrix(Image image, ColorMatrix color_matrix)
        {
            // Make the result bitmap.
            Bitmap bm = new Bitmap(image.Width, image.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                // Create an ImageAttributes object and use it to
                // draw the original image onto the result image.
                ImageAttributes attr = new ImageAttributes();
                attr.SetColorMatrix(color_matrix);

                Point[] dest_points =
                {
                    new Point(0, 0),
                    new Point(image.Width, 0),
                    new Point(0, image.Height),
                };
                Rectangle source_rect = new Rectangle(
                    0, 0, image.Width, image.Height);
                gr.DrawImage(image, dest_points,
                    source_rect, GraphicsUnit.Pixel, attr);
            }
            return bm;
        }

        private void mnuPictureReset_Click(object sender, EventArgs e)
        {
            TransformedImage = OriginalImage;
            ShowImage();
        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdOriginal.ShowDialog() == DialogResult.OK)
            {
                OriginalImage =
                    LoadBitmapUnlocked(ofdOriginal.FileName);
                TransformedImage = OriginalImage;
                ShowImage();
                picImage.Visible = true;

                ClientSize = new Size(
                    picImage.Right + picImage.Left,
                    picImage.Bottom + picImage.Left);

                // Ensable the Picture menu and the Save As command.
                mnuPicture.Enabled = true;
                mnuFileSaveAs.Enabled = true;
                EnableMenu(mnuPicture, true);
            }
        }

        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (sfdResult.ShowDialog() == DialogResult.OK)
            {
                SaveImage(TransformedImage, sfdResult.FileName);
            }
        }

        // Multiply red, green, and blue color components by -1.
        private void mnuPictureInvert_Click(object sender, EventArgs e)
        {
            ColorMatrix color_matrix = new ColorMatrix(
                new float[][]
                {
                    new float[] {-1,  0,  0,  0,  0},
                    new float[] { 0, -1,  0,  0,  0},
                    new float[] { 0,  0, -1,  0,  0},
                    new float[] { 0,  0,  0,  1,  0},
                    new float[] { 1,  1,  1,  0,  1}
                });
            TransformedImage = ApplyColorMatrix(TransformedImage, color_matrix);
            ShowImage();
        }

        // Remove the red component.
        private void mnuPictureRemoveRed_Click(object sender, EventArgs e)
        {
            ColorMatrix color_matrix = new ColorMatrix(
                new float[][]
                {
                    new float[] {0, 0, 0, 0, 0},
                    new float[] {0, 1, 0, 0, 0},
                    new float[] {0, 0, 1, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                });
            TransformedImage = ApplyColorMatrix(TransformedImage, color_matrix);
            ShowImage();
        }

        // Remove the green component.
        private void mnuPictureRemoveGreen_Click(object sender, EventArgs e)
        {
            ColorMatrix color_matrix = new ColorMatrix(
                new float[][]
                {
                    new float[] {1, 0, 0, 0, 0},
                    new float[] {0, 0, 0, 0, 0},
                    new float[] {0, 0, 1, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                });
            TransformedImage = ApplyColorMatrix(TransformedImage, color_matrix);
            ShowImage();
        }

        // Remove the blue component.
        private void mnuPictureRemoveBlue_Click(object sender, EventArgs e)
        {
            ColorMatrix color_matrix = new ColorMatrix(
                new float[][]
                {
                    new float[] {1, 0, 0, 0, 0},
                    new float[] {0, 1, 0, 0, 0},
                    new float[] {0, 0, 0, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                });
            TransformedImage = ApplyColorMatrix(TransformedImage, color_matrix);
            ShowImage();
        }

        private void mnuPictureDecreaseAlpha_Click(object sender, EventArgs e)
        {
            ColorMatrix color_matrix = new ColorMatrix(
                new float[][]
                {
                    new float[] {1, 0, 0,    0, 0},
                    new float[] {0, 1, 0,    0, 0},
                    new float[] {0, 0, 1,    0, 0},
                    new float[] {0, 0, 0, 0.8f, 0},
                    new float[] {0, 0, 0,    0, 1}
                });
            TransformedImage = ApplyColorMatrix(TransformedImage, color_matrix);
            ShowImage();
        }

        private void mnuPictureIncreaseAlpha_Click(object sender, EventArgs e)
        {
            ColorMatrix color_matrix = new ColorMatrix(
                new float[][]
                {
                    new float[] {1, 0, 0,     0, 0},
                    new float[] {0, 1, 0,     0, 0},
                    new float[] {0, 0, 1,     0, 0},
                    new float[] {0, 0, 0, 1.25f, 0},
                    new float[] {0, 0, 0,     0, 1}
                });
            TransformedImage = ApplyColorMatrix(TransformedImage, color_matrix);
            ShowImage();
        }

        // Convert the image to grayscale using weighted component values.
        private void mnuPictureGrayscale_Click(object sender, EventArgs e)
        {
            ColorMatrix color_matrix = new ColorMatrix(
                new float[][]
                {
                    new float[] {0.299f, 0.299f, 0.299f, 0, 0},
                    new float[] {0.587f, 0.587f, 0.587f, 0, 0},
                    new float[] {0.114f, 0.114f, 0.114f, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1},
                });
            TransformedImage = ApplyColorMatrix(TransformedImage, color_matrix);
            ShowImage();
        }

        // Convert the image to grayscale by averaging the component values.
        private void mnuPictureAverage_Click(object sender, EventArgs e)
        {
            ColorMatrix color_matrix = new ColorMatrix(
                new float[][]
                {
                    new float[] {0.333f, 0.333f, 0.333f, 0, 0},
                    new float[] {0.333f, 0.333f, 0.333f, 0, 0},
                    new float[] {0.333f, 0.333f, 0.333f, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1},
                });
            TransformedImage = ApplyColorMatrix(TransformedImage, color_matrix);
            ShowImage();
        }

        // Increase the color components.
        private void mnuPictureBrighten_Click(object sender, EventArgs e)
        {
            ColorMatrix color_matrix = new ColorMatrix(
                new float[][]
                {
                    new float[] {1.2f,    0,    0, 0, 0},
                    new float[] {   0, 1.2f,    0, 0, 0},
                    new float[] {   0,    0, 1.2f, 0, 0},
                    new float[] {   0,    0,    0, 1, 0},
                    new float[] {   0,    0,    0, 0, 1}
                });
            TransformedImage = ApplyColorMatrix(TransformedImage, color_matrix);
            ShowImage();
        }

        // Decrease the color components.
        private void mnuPictureDarken_Click(object sender, EventArgs e)
        {
            ColorMatrix color_matrix = new ColorMatrix(
                new float[][]
                {
                    new float[] {0.8f,    0,    0, 0, 0},
                    new float[] {   0, 0.8f,    0, 0, 0},
                    new float[] {   0,    0, 0.8f, 0, 0},
                    new float[] {   0,    0,    0, 1, 0},
                    new float[] {   0,    0,    0, 0, 1}
                });
            TransformedImage = ApplyColorMatrix(TransformedImage, color_matrix);
            ShowImage();
        }

        // Display the transformed image drawn on top of a checkerboard.
        private void ShowImage()
        {
            int wid = TransformedImage.Width;
            int hgt = TransformedImage.Height;
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                // Draw the checkerboard.
                const int step = 20;
                for (int x = 0; x < wid; x += step)
                {
                    for (int y = 0; y < hgt; y += step)
                    {
                        if (((x / step) + (y / step)) % 2 == 0)
                            gr.FillRectangle(Brushes.Red,
                                x, y, step, step);
                        else
                            gr.FillRectangle(Brushes.Yellow,
                                x, y, step, step);
                    }
                }

                // Draw the image on top.
                gr.DrawImage(TransformedImage, new Point(0, 0));
            }

            picImage.Image = bm;
        }

        // Load a bitmap without locking it.
        private Bitmap LoadBitmapUnlocked(string file_name)
        {
            using (Bitmap bm = new Bitmap(file_name))
            {
                return new Bitmap(bm);
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

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Enable or disable the items in a menu.
        private void EnableMenu(ToolStripMenuItem mnu, bool enable)
        {
            foreach (ToolStripItem item in mnu.DropDownItems)
                item.Enabled = enable;
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPicture = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPictureReset = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPictureInvert = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPictureRemoveRed = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPictureRemoveGreen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPictureRemoveBlue = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPictureDecreaseAlpha = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPictureIncreaseAlpha = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPictureGrayscale = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPictureAverage = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdOriginal = new System.Windows.Forms.OpenFileDialog();
            this.sfdResult = new System.Windows.Forms.SaveFileDialog();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPictureBrighten = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPictureDarken = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mnuPicture});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.mnuFileSaveAs,
            this.mnuFileExit});
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
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(163, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuPicture
            // 
            this.mnuPicture.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPictureReset,
            this.toolStripSeparator1,
            this.mnuPictureInvert,
            this.toolStripSeparator2,
            this.mnuPictureRemoveRed,
            this.mnuPictureRemoveGreen,
            this.mnuPictureRemoveBlue,
            this.toolStripMenuItem1,
            this.mnuPictureDecreaseAlpha,
            this.mnuPictureIncreaseAlpha,
            this.toolStripMenuItem2,
            this.mnuPictureGrayscale,
            this.mnuPictureAverage,
            this.toolStripMenuItem3,
            this.mnuPictureDarken,
            this.mnuPictureBrighten});
            this.mnuPicture.Name = "mnuPicture";
            this.mnuPicture.Size = new System.Drawing.Size(56, 20);
            this.mnuPicture.Text = "&Picture";
            // 
            // mnuPictureReset
            // 
            this.mnuPictureReset.Name = "mnuPictureReset";
            this.mnuPictureReset.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuPictureReset.Size = new System.Drawing.Size(212, 22);
            this.mnuPictureReset.Text = "R&eset";
            this.mnuPictureReset.Click += new System.EventHandler(this.mnuPictureReset_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(209, 6);
            // 
            // mnuPictureInvert
            // 
            this.mnuPictureInvert.Name = "mnuPictureInvert";
            this.mnuPictureInvert.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.mnuPictureInvert.Size = new System.Drawing.Size(212, 22);
            this.mnuPictureInvert.Text = "&Invert";
            this.mnuPictureInvert.Click += new System.EventHandler(this.mnuPictureInvert_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(209, 6);
            // 
            // mnuPictureRemoveRed
            // 
            this.mnuPictureRemoveRed.Name = "mnuPictureRemoveRed";
            this.mnuPictureRemoveRed.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mnuPictureRemoveRed.Size = new System.Drawing.Size(212, 22);
            this.mnuPictureRemoveRed.Text = "Remove &Red";
            this.mnuPictureRemoveRed.Click += new System.EventHandler(this.mnuPictureRemoveRed_Click);
            // 
            // mnuPictureRemoveGreen
            // 
            this.mnuPictureRemoveGreen.Name = "mnuPictureRemoveGreen";
            this.mnuPictureRemoveGreen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.mnuPictureRemoveGreen.Size = new System.Drawing.Size(212, 22);
            this.mnuPictureRemoveGreen.Text = "Remove &Green";
            this.mnuPictureRemoveGreen.Click += new System.EventHandler(this.mnuPictureRemoveGreen_Click);
            // 
            // mnuPictureRemoveBlue
            // 
            this.mnuPictureRemoveBlue.Name = "mnuPictureRemoveBlue";
            this.mnuPictureRemoveBlue.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.mnuPictureRemoveBlue.Size = new System.Drawing.Size(212, 22);
            this.mnuPictureRemoveBlue.Text = "Remove &Blue";
            this.mnuPictureRemoveBlue.Click += new System.EventHandler(this.mnuPictureRemoveBlue_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(209, 6);
            // 
            // mnuPictureDecreaseAlpha
            // 
            this.mnuPictureDecreaseAlpha.Name = "mnuPictureDecreaseAlpha";
            this.mnuPictureDecreaseAlpha.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F11)));
            this.mnuPictureDecreaseAlpha.Size = new System.Drawing.Size(212, 22);
            this.mnuPictureDecreaseAlpha.Text = "Decrease Alpha";
            this.mnuPictureDecreaseAlpha.Click += new System.EventHandler(this.mnuPictureDecreaseAlpha_Click);
            // 
            // mnuPictureIncreaseAlpha
            // 
            this.mnuPictureIncreaseAlpha.Name = "mnuPictureIncreaseAlpha";
            this.mnuPictureIncreaseAlpha.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F12)));
            this.mnuPictureIncreaseAlpha.Size = new System.Drawing.Size(212, 22);
            this.mnuPictureIncreaseAlpha.Text = "Increase Alpha";
            this.mnuPictureIncreaseAlpha.Click += new System.EventHandler(this.mnuPictureIncreaseAlpha_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(209, 6);
            // 
            // mnuPictureGrayscale
            // 
            this.mnuPictureGrayscale.Name = "mnuPictureGrayscale";
            this.mnuPictureGrayscale.Size = new System.Drawing.Size(212, 22);
            this.mnuPictureGrayscale.Text = "Gra&yscale";
            this.mnuPictureGrayscale.Click += new System.EventHandler(this.mnuPictureGrayscale_Click);
            // 
            // mnuPictureAverage
            // 
            this.mnuPictureAverage.Name = "mnuPictureAverage";
            this.mnuPictureAverage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mnuPictureAverage.Size = new System.Drawing.Size(212, 22);
            this.mnuPictureAverage.Text = "&Average";
            this.mnuPictureAverage.Click += new System.EventHandler(this.mnuPictureAverage_Click);
            // 
            // ofdOriginal
            // 
            this.ofdOriginal.DefaultExt = "png";
            this.ofdOriginal.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All FIles|*.*";
            // 
            // sfdResult
            // 
            this.sfdResult.DefaultExt = "png";
            this.sfdResult.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All FIles|*.*";
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(12, 27);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(100, 50);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImage.TabIndex = 1;
            this.picImage.TabStop = false;
            this.picImage.Visible = false;
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(209, 6);
            // 
            // mnuPictureBrighten
            // 
            this.mnuPictureBrighten.Name = "mnuPictureBrighten";
            this.mnuPictureBrighten.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.mnuPictureBrighten.Size = new System.Drawing.Size(212, 22);
            this.mnuPictureBrighten.Text = "Brighten";
            this.mnuPictureBrighten.Click += new System.EventHandler(this.mnuPictureBrighten_Click);
            // 
            // mnuPictureDarken
            // 
            this.mnuPictureDarken.Name = "mnuPictureDarken";
            this.mnuPictureDarken.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.mnuPictureDarken.Size = new System.Drawing.Size(212, 22);
            this.mnuPictureDarken.Text = "&Darken";
            this.mnuPictureDarken.Click += new System.EventHandler(this.mnuPictureDarken_Click);
            // 
            // howto_color_matrix_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_color_matrix_Form1";
            this.Text = "howto_color_matrix";
            this.Load += new System.EventHandler(this.howto_color_matrix_Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        private System.Windows.Forms.OpenFileDialog ofdOriginal;
        private System.Windows.Forms.SaveFileDialog sfdResult;
        private System.Windows.Forms.ToolStripMenuItem mnuPicture;
        private System.Windows.Forms.ToolStripMenuItem mnuPictureInvert;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.ToolStripMenuItem mnuPictureRemoveRed;
        private System.Windows.Forms.ToolStripMenuItem mnuPictureRemoveGreen;
        private System.Windows.Forms.ToolStripMenuItem mnuPictureRemoveBlue;
        private System.Windows.Forms.ToolStripMenuItem mnuPictureReset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuPictureDecreaseAlpha;
        private System.Windows.Forms.ToolStripMenuItem mnuPictureIncreaseAlpha;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuPictureGrayscale;
        private System.Windows.Forms.ToolStripMenuItem mnuPictureAverage;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuPictureBrighten;
        private System.Windows.Forms.ToolStripMenuItem mnuPictureDarken;
    }
}

