using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Imaging;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_make_transparent_png_Form1:Form
  { 


        public howto_make_transparent_png_Form1()
        {
            InitializeComponent();
        }

        // The image.
        private Bitmap Bm = null;

        // Offset for displaying the image.
        private const int Offset = 10;

        // Open a file.
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Bm = new Bitmap(ofdFile.FileName);
                    picImage.ClientSize = new Size(
                        Bm.Width + 2 * Offset,
                        Bm.Height + 2 * Offset);
                    picImage.Visible = true;
                    picImage.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Save the file.
        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            if (sfdFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Bm.Save(sfdFile.FileName, ImageFormat.Png);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Set the transparent pixel.
        private void picImage_MouseClick(object sender, MouseEventArgs e)
        {
            // Get the color clicked.
            Color color = Bm.GetPixel(e.X - Offset, e.Y - Offset);

            // Make that color transparent.
            Bm.MakeTransparent(color);

            // Show the result.
            picImage.Refresh();
        }

        // Draw the picture.
        private void picImage_Paint(object sender, PaintEventArgs e)
        {
            if (Bm == null) return;
            e.Graphics.DrawImage(Bm, Offset, Offset);
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
            this.picImage = new System.Windows.Forms.PictureBox();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sfdFile = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.BackgroundImage = Properties.Resources.Sky;
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picImage.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picImage.Location = new System.Drawing.Point(2, 28);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(99, 98);
            this.picImage.TabIndex = 3;
            this.picImage.TabStop = false;
            this.picImage.Visible = false;
            this.picImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseClick);
            this.picImage.Paint += new System.Windows.Forms.PaintEventHandler(this.picImage_Paint);
            // 
            // ofdFile
            // 
            this.ofdFile.FileName = "openFileDialog1";
            this.ofdFile.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|Bitmaps|*.bmp|PNG files|*.png|JPEG file" +
                "s|*.jpg|GIF files|*.gif";
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSave.Size = new System.Drawing.Size(155, 22);
            this.mnuFileSave.Text = "&Save...";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(155, 22);
            this.mnuFileOpen.Text = "&Open...";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.mnuFileSave});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(347, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sfdFile
            // 
            this.sfdFile.Filter = "PNG files|*.png|All Files|*.*";
            // 
            // howto_make_transparent_png_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 261);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.menuStrip1);
            this.Name = "howto_make_transparent_png_Form1";
            this.Text = "howto_make_transparent_png";
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SaveFileDialog sfdFile;
    }
}

