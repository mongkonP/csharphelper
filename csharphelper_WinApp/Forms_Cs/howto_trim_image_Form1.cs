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

 

using howto_trim_image;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_trim_image_Form1:Form
  { 


        public howto_trim_image_Form1()
        {
            InitializeComponent();
        }

        // The original and processed image.
        private Bitmap OriginalImage = null, CurrentImage = null;

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (sfdImage.ShowDialog() == DialogResult.OK)
            {
                SaveImage(CurrentImage, sfdImage.FileName);
            }
        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                OriginalImage = LoadBitmapUnlocked(ofdImage.FileName);
                ProcessImage();

                mnuFileSaveAs.Enabled = true;
                btnGo.Enabled = true;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Refresh();

            ProcessImage();

            Cursor = Cursors.Default;
        }

        private void ProcessImage()
        {
            int margin = int.Parse(txtMargin.Text);
            CurrentImage = TrimImage(OriginalImage, margin);
            picImage.Image = CurrentImage;
        }

        // Trim the image to its non-white pixels plus a margin.
        private Bitmap TrimImage(Bitmap image, int margin)
        {
            // Make a Bitmap32.
            Bitmap32 bm32 = new Bitmap32(image);
            bm32.LockBitmap();

            // Find the pixel bounds.
            Rectangle src_rect = ImageBounds(bm32);
            bm32.UnlockBitmap();

            // Copy the non-white area.
            int wid = src_rect.Width + 2 * margin;
            int hgt = src_rect.Height + 2 * margin;
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(Color.White);
                Rectangle dest_rect = new Rectangle(
                    margin, margin, src_rect.Width, src_rect.Height);
                gr.DrawImage(image, dest_rect, src_rect, GraphicsUnit.Pixel);
            }

            return bm;
        }

        // Get the image's bounds.
        private Rectangle ImageBounds(Bitmap32 bm32)
        {
            // ymin.
            int ymin = bm32.Height - 1;
            for (int y = 0; y < bm32.Height; y++)
            {
                if (!RowIsWhite(bm32, y))
                {
                    ymin = y;
                    break;
                }
            }

            // ymax.
            int ymax = 0;
            for (int y = bm32.Height - 1; y >= ymin; y--)
            {
                if (!RowIsWhite(bm32, y))
                {
                    ymax = y;
                    break;
                }
            }

            // xmin.
            int xmin = bm32.Width - 1;
            for (int x = 0; x < bm32.Width; x++)
            {
                if (!ColumnIsWhite(bm32, x))
                {
                    xmin = x;
                    break;
                }
            }

            // xmax.
            int xmax = 0;
            for (int x = bm32.Width - 1; x >= xmin; x--)
            {
                if (!ColumnIsWhite(bm32, x))
                {
                    xmax = x;
                    break;
                }
            }

            // Build the rectangle.
            return new Rectangle(xmin, ymin,
                xmax - xmin + 1, ymax - ymin + 1);
        }

        // Return true if this row is all white.
        private bool RowIsWhite(Bitmap32 bm32, int y)
        {
            byte r, g, b, a;
            for (int x = 0; x < bm32.Width; x++)
            {
                bm32.GetPixel(x, y, out r, out g, out b, out a);
                if ((r != 255) || (g != 255) || (b != 255)) return false;
            }
            return true;
        }

        // Return true if this column is all white.
        private bool ColumnIsWhite(Bitmap32 bm32, int x)
        {
            byte r, g, b, a;
            for (int y = 0; y < bm32.Height; y++)
            {
                bm32.GetPixel(x, y, out r, out g, out b, out a);
                if ((r != 255) || (g != 255) || (b != 255)) return false;
            }
            return true;
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
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMargin = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.ofdImage = new System.Windows.Forms.OpenFileDialog();
            this.sfdImage = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
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
            this.toolStripMenuItem1,
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
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(163, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(12, 56);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(114, 73);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImage.TabIndex = 1;
            this.picImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Margin:";
            // 
            // txtMargin
            // 
            this.txtMargin.Location = new System.Drawing.Point(60, 29);
            this.txtMargin.Name = "txtMargin";
            this.txtMargin.Size = new System.Drawing.Size(31, 20);
            this.txtMargin.TabIndex = 3;
            this.txtMargin.Text = "1";
            this.txtMargin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGo
            // 
            this.btnGo.Enabled = false;
            this.btnGo.Location = new System.Drawing.Point(116, 27);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // ofdImage
            // 
            this.ofdImage.FileName = "openFileDialog1";
            this.ofdImage.Filter = "Picture files|\r\n    *.bmp;*.jpg;*.gif;*.png;*.tif";
            // 
            // sfdImage
            // 
            this.sfdImage.Filter = "Picture files|\r\n    *.bmp;*.jpg;*.gif;*.png;*.tif";
            // 
            // howto_trim_image_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtMargin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_trim_image_Form1";
            this.Text = "howto_trim_image";
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
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMargin;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.OpenFileDialog ofdImage;
        private System.Windows.Forms.SaveFileDialog sfdImage;
    }
}

