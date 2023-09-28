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
     public partial class howto_zoom_picture_Form1:Form
  { 


        public howto_zoom_picture_Form1()
        {
            InitializeComponent();
        }

        // Set the menus' Tag values.
        private void howto_zoom_picture_Form1_Load(object sender, EventArgs e)
        {
            picZoom.SizeMode = PictureBoxSizeMode.StretchImage;

            mnuScale1_2.Tag = 0.5f;
            mnuScale1.Tag = 1f;
            mnuScale2.Tag = 2f;
            mnuScale4.Tag = 4f;
            mnuScale6.Tag = 6f;
        }

        // Exit the program.
        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Open a file.
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdPicture.ShowDialog() == DialogResult.OK)
            {
                Bitmap bm = LoadBitmapUnlocked(ofdPicture.FileName);
                picZoom.ClientSize = new Size(bm.Width, bm.Height);
                picZoom.Image = bm;

                CheckMenuItem(mnuScale1);

                picZoom.Visible = true;
            }
        }

        // Check this menu item and uncheck the others.
        private void CheckMenuItem(ToolStripMenuItem mnu)
        {
            ToolStripMenuItem[] items =
            {
                mnuScale1_2, mnuScale1, mnuScale2, mnuScale4, mnuScale6
            };
            foreach (ToolStripMenuItem item in items)
            {
                item.Checked = (item == mnu);
            }
        }

        // Save the current file.
        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            if (sfdPicture.ShowDialog() == DialogResult.OK)
            {
                // Make a bitmap of the correct size.
                using (Bitmap bm = new Bitmap(
                    picZoom.ClientSize.Width,
                    picZoom.ClientSize.Height))
                {
                    // Copy the original image onto the new bitmap.
                    using (Graphics gr = Graphics.FromImage(bm))
                    {
                        Rectangle source_rect = new Rectangle(
                            0, 0, picZoom.Image.Width, picZoom.Image.Height);
                        Rectangle dest_rect = new Rectangle(
                            0, 0, bm.Width, bm.Height);
                        gr.DrawImage(picZoom.Image,
                            dest_rect, source_rect, GraphicsUnit.Pixel);
                    }

                    // Save the bitmap.
                    SaveImage(bm, sfdPicture.FileName);
                }
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

        // Load a bitmap without locking it.
        private Bitmap LoadBitmapUnlocked(string file_name)
        {
            using (Bitmap bm = new Bitmap(file_name))
            {
                return new Bitmap(bm);
            }
        }

        // Scale the image.
        private void mnuScale_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mnu = sender as ToolStripMenuItem;
            float scale = (float)mnu.Tag;
            picZoom.ClientSize = new Size(
                (int)(scale * picZoom.Image.Width),
                (int)(scale * picZoom.Image.Height));
            CheckMenuItem(mnu);
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
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale1_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale4 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale6 = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdPicture = new System.Windows.Forms.OpenFileDialog();
            this.picZoom = new System.Windows.Forms.PictureBox();
            this.sfdPicture = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.pictureToolStripMenuItem});
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
            this.mnuFileSave,
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
            this.mnuFileOpen.Size = new System.Drawing.Size(155, 22);
            this.mnuFileOpen.Text = "&Open...";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSave.Size = new System.Drawing.Size(155, 22);
            this.mnuFileSave.Text = "&Save...";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(155, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // pictureToolStripMenuItem
            // 
            this.pictureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuScale1_2,
            this.mnuScale1,
            this.mnuScale2,
            this.mnuScale4,
            this.mnuScale6});
            this.pictureToolStripMenuItem.Name = "pictureToolStripMenuItem";
            this.pictureToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.pictureToolStripMenuItem.Text = "&Scale";
            // 
            // mnuScale1_2
            // 
            this.mnuScale1_2.Name = "mnuScale1_2";
            this.mnuScale1_2.Size = new System.Drawing.Size(152, 22);
            this.mnuScale1_2.Tag = "";
            this.mnuScale1_2.Text = "x 1/2";
            this.mnuScale1_2.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuScale1
            // 
            this.mnuScale1.Name = "mnuScale1";
            this.mnuScale1.Size = new System.Drawing.Size(152, 22);
            this.mnuScale1.Text = "x &1";
            this.mnuScale1.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuScale2
            // 
            this.mnuScale2.Name = "mnuScale2";
            this.mnuScale2.Size = new System.Drawing.Size(152, 22);
            this.mnuScale2.Text = "x &2";
            this.mnuScale2.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuScale4
            // 
            this.mnuScale4.Name = "mnuScale4";
            this.mnuScale4.Size = new System.Drawing.Size(152, 22);
            this.mnuScale4.Text = "x &4";
            this.mnuScale4.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuScale6
            // 
            this.mnuScale6.Name = "mnuScale6";
            this.mnuScale6.Size = new System.Drawing.Size(152, 22);
            this.mnuScale6.Text = "x &6";
            this.mnuScale6.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // ofdPicture
            // 
            this.ofdPicture.FileName = "openFileDialog1";
            this.ofdPicture.Filter = "Bitmaps|*.bmp|PNG files|*.png|JPEG files|*.jpg|Picture Files|*.bmp;*.jpg;*.gif;*." +
                "png;*.tif";
            // 
            // picZoom
            // 
            this.picZoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picZoom.Location = new System.Drawing.Point(12, 27);
            this.picZoom.Name = "picZoom";
            this.picZoom.Size = new System.Drawing.Size(260, 225);
            this.picZoom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picZoom.TabIndex = 1;
            this.picZoom.TabStop = false;
            this.picZoom.Visible = false;
            // 
            // sfdPicture
            // 
            this.sfdPicture.Filter = "Bitmaps|*.bmp|PNG files|*.png|JPEG files|*.jpg|Picture Files|*.bmp;*.jpg;*.gif;*." +
                "png;*.tif";
            // 
            // howto_zoom_picture_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.picZoom);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_zoom_picture_Form1";
            this.Text = "howto_zoom_picture";
            this.Load += new System.EventHandler(this.howto_zoom_picture_Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picZoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.OpenFileDialog ofdPicture;
        private System.Windows.Forms.PictureBox picZoom;
        private System.Windows.Forms.ToolStripMenuItem pictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuScale1_2;
        private System.Windows.Forms.ToolStripMenuItem mnuScale1;
        private System.Windows.Forms.ToolStripMenuItem mnuScale2;
        private System.Windows.Forms.ToolStripMenuItem mnuScale4;
        private System.Windows.Forms.ToolStripMenuItem mnuScale6;
        private System.Windows.Forms.SaveFileDialog sfdPicture;
    }
}

