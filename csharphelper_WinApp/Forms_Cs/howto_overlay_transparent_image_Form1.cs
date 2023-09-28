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

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_overlay_transparent_image_Form1:Form
  { 


        public howto_overlay_transparent_image_Form1()
        {
            InitializeComponent();
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // The background image.
        private Bitmap BackgroundBitmap = null;

        // The overlay image.
        private Bitmap OverlayBitmap = null;

        // The current combined image.
        private Bitmap CombinedBitmap = null;

        // The location of the overlay image.
        private Point OverlayLocation = new Point(0, 0);

        // Reduce flicker.
        private void howto_overlay_transparent_image_Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
        }

        // Let the user open a file.
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Open the file.
                    BackgroundBitmap = new Bitmap(ofdFile.FileName);
                    picImage.Image = BackgroundBitmap;
                    picImage.Visible = true;
                    ClientSize = new Size(
                        picImage.Right + picImage.Left,
                        picImage.Bottom + picImage.Left);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening file.\n" + ex.Message,
                        "Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Load the overlay image.
        private void mnuFileOverlay_Click(object sender, EventArgs e)
        {
            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Open the file.
                    OverlayBitmap = new Bitmap(ofdFile.FileName);
                    picImage.Cursor = Cursors.Cross;

                    // Display the combined image.
                    ShowCombinedImage();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening file.\n" + ex.Message,
                        "Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Display the combined image.
        private void ShowCombinedImage()
        {
            // If there's no background image, do nothing.
            if (BackgroundBitmap == null) return;

            // Copy the background.
            CombinedBitmap = new Bitmap(BackgroundBitmap);

            // Add the overlay.
            if (OverlayBitmap != null)
            {
                using (Graphics gr = Graphics.FromImage(CombinedBitmap))
                {
                    gr.DrawImage(OverlayBitmap, OverlayLocation);
                }
            }

            // Display the result.
            picImage.Image = CombinedBitmap;
        }

        // Drag the overlay image.
        private void picImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (OverlayBitmap == null) return;
            OverlayLocation = new Point(
                e.X - OverlayBitmap.Width / 2,
                e.Y - OverlayBitmap.Height / 2);
            ShowCombinedImage();
        }

        // Finish dragging the overlay image.
        private void picImage_MouseClick(object sender, MouseEventArgs e)
        {
            if (OverlayBitmap == null) return;
            OverlayBitmap = null;
            picImage.Cursor = Cursors.Default;

            // Make the overlay permanent.
            BackgroundBitmap = CombinedBitmap;
        }

        // Save the current result image.
        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            if (CombinedBitmap == null) return;
            if (sfdFile.ShowDialog() == DialogResult.OK)
            {
                SaveBitmapUsingExtension(CombinedBitmap, sfdFile.FileName);
            }
        }

        // Save the file with the appropriate format.
        // Throw a NotSupportedException if the file
        // has an unknown extension.
        public void SaveBitmapUsingExtension(Bitmap bm, string filename)
        {
            string extension = Path.GetExtension(filename);
            switch (extension.ToLower())
            {
                case ".bmp":
                    bm.Save(filename, ImageFormat.Bmp);
                    break;
                case ".exif":
                    bm.Save(filename, ImageFormat.Exif);
                    break;
                case ".gif":
                    bm.Save(filename, ImageFormat.Gif);
                    break;
                case ".jpg":
                case ".jpeg":
                    bm.Save(filename, ImageFormat.Jpeg);
                    break;
                case ".png":
                    bm.Save(filename, ImageFormat.Png);
                    break;
                case ".tif":
                case ".tiff":
                    bm.Save(filename, ImageFormat.Tiff);
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sfdFile = new System.Windows.Forms.SaveFileDialog();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOverlay = new System.Windows.Forms.ToolStripMenuItem();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // sfdFile
            // 
            this.sfdFile.Filter = "Image Files|*.bmp;*.png;*.jpg;*.gif;*.tif|All Files|*.*";
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(155, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSave.Size = new System.Drawing.Size(155, 22);
            this.mnuFileSave.Text = "&Save";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // ofdFile
            // 
            this.ofdFile.FileName = "openFileDialog1";
            this.ofdFile.Filter = "Image Files|*.bmp;*.png;*.jpg;*.gif;*.tif|All Files|*.*";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(364, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.mnuFileOverlay,
            this.mnuFileSave,
            this.toolStripSeparator1,
            this.mnuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(155, 22);
            this.mnuFileOpen.Text = "&Open";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileOverlay
            // 
            this.mnuFileOverlay.Name = "mnuFileOverlay";
            this.mnuFileOverlay.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mnuFileOverlay.Size = new System.Drawing.Size(155, 22);
            this.mnuFileOverlay.Text = "O&verlay";
            this.mnuFileOverlay.Click += new System.EventHandler(this.mnuFileOverlay_Click);
            // 
            // picImage
            // 
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(12, 27);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(100, 50);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImage.TabIndex = 3;
            this.picImage.TabStop = false;
            this.picImage.Visible = false;
            this.picImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseMove);
            this.picImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseClick);
            // 
            // howto_overlay_transparent_image_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 211);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.picImage);
            this.Name = "howto_overlay_transparent_image_Form1";
            this.Text = "howto_overlay_transparent_image";
            this.Load += new System.EventHandler(this.howto_overlay_transparent_image_Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SaveFileDialog sfdFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOverlay;
        private System.Windows.Forms.PictureBox picImage;
    }
}

