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
     public partial class howto_make_light_transparent_Form1:Form
  { 


        public howto_make_light_transparent_Form1()
        {
            InitializeComponent();
        }

        // The original image.
        Bitmap OriginalImage = null;

        // Load a file.
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                OriginalImage = new Bitmap(ofdImage.FileName);
                ShowImage();
                mnuFileSave.Enabled = true;
            }
        }

        // Make magenta pixels transparent and save the result.
        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            if (sfdImage.ShowDialog() == DialogResult.OK)
            {
                // Make a copy of the result image.
                using (Bitmap bm = (Bitmap)picResult.Image.Clone())
                {
                    bm.MakeTransparent(Color.Magenta);
                    
                    // Save the image.
                    SaveImage(bm, sfdImage.FileName);
                }
            }
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Rebuild the image.
        private void scrBrightness_Scroll(object sender, ScrollEventArgs e)
        {
            lblBrightness.Text = scrBrightness.Value.ToString();
            ShowImage();
        }

        // Make an image setting pixels brighter
        // than the cutoff value to magenta.
        private void ShowImage()
        {
            if (OriginalImage == null) return;

            // Get the cutoff.
            int cutoff = scrBrightness.Value;

            // Prepare the ImageAttributes.
            Color low_color = Color.FromArgb(cutoff, cutoff, cutoff);
            Color high_color = Color.FromArgb(255, 255, 255);
            ImageAttributes image_attr = new ImageAttributes();
            image_attr.SetColorKey(low_color, high_color);

            // Make the result image.
            int wid = OriginalImage.Width;
            int hgt  = OriginalImage.Height;
            Bitmap bm = new Bitmap(wid, hgt);

            // Process the image.
            using (Graphics gr = Graphics.FromImage(bm))
            {
                // Fill with magenta.
                gr.Clear(Color.Magenta);

                // Copy the original image onto the result
                // image while using the ImageAttributes.
                Rectangle dest_rect = new Rectangle(0, 0, wid, hgt);
                gr.DrawImage(OriginalImage, dest_rect,
                    0, 0, wid, hgt, GraphicsUnit.Pixel, image_attr);
            }

            // Display the image.
            picResult.Image = bm;
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
            this.ofdImage = new System.Windows.Forms.OpenFileDialog();
            this.sfdImage = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.scrBrightness = new System.Windows.Forms.HScrollBar();
            this.lblBrightness = new System.Windows.Forms.Label();
            this.picResult = new System.Windows.Forms.PictureBox();
            this.panScroller = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            this.panScroller.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdImage
            // 
            this.ofdImage.Filter = "Picture files|*.bmp;*.jpg;*.gif;*.png;*.tif|All Files|*.*";
            // 
            // sfdImage
            // 
            this.sfdImage.Filter = "PNG Files|*.png|Picture files|*.bmp;*.jpg;*.gif;*.png;*.tif|All Files|*.*";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(344, 24);
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
            this.mnuFileSave.Enabled = false;
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
            // scrBrightness
            // 
            this.scrBrightness.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scrBrightness.Location = new System.Drawing.Point(27, 24);
            this.scrBrightness.Maximum = 264;
            this.scrBrightness.Name = "scrBrightness";
            this.scrBrightness.Size = new System.Drawing.Size(315, 17);
            this.scrBrightness.TabIndex = 1;
            this.scrBrightness.Value = 128;
            this.scrBrightness.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrBrightness_Scroll);
            // 
            // lblBrightness
            // 
            this.lblBrightness.AutoSize = true;
            this.lblBrightness.Location = new System.Drawing.Point(-1, 26);
            this.lblBrightness.Name = "lblBrightness";
            this.lblBrightness.Size = new System.Drawing.Size(25, 13);
            this.lblBrightness.TabIndex = 2;
            this.lblBrightness.Text = "128";
            // 
            // picResult
            // 
            this.picResult.Location = new System.Drawing.Point(3, 3);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(100, 100);
            this.picResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picResult.TabIndex = 3;
            this.picResult.TabStop = false;
            // 
            // panScroller
            // 
            this.panScroller.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panScroller.AutoScroll = true;
            this.panScroller.Controls.Add(this.picResult);
            this.panScroller.Location = new System.Drawing.Point(2, 44);
            this.panScroller.Name = "panScroller";
            this.panScroller.Size = new System.Drawing.Size(340, 215);
            this.panScroller.TabIndex = 4;
            // 
            // howto_make_light_transparent_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 261);
            this.Controls.Add(this.panScroller);
            this.Controls.Add(this.lblBrightness);
            this.Controls.Add(this.scrBrightness);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_make_light_transparent_Form1";
            this.Text = "howto_make_light_transparent";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            this.panScroller.ResumeLayout(false);
            this.panScroller.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdImage;
        private System.Windows.Forms.SaveFileDialog sfdImage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.HScrollBar scrBrightness;
        private System.Windows.Forms.Label lblBrightness;
        private System.Windows.Forms.PictureBox picResult;
        private System.Windows.Forms.Panel panScroller;
    }
}

