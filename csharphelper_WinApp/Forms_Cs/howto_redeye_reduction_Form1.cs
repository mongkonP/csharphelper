using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_redeye_reduction_Form1:Form
  { 


        public howto_redeye_reduction_Form1()
        {
            InitializeComponent();
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Open a file.
        Bitmap TheBitmap;
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                using (Bitmap bm = new Bitmap(ofdImage.FileName))
                {
                    TheBitmap = new Bitmap(bm);
                }
                picImage.Image = TheBitmap;
                this.ClientSize = new Size(
                    picImage.Right + picImage.Left,
                    picImage.Bottom + picImage.Left);
                picImage.Visible = true;
            }
        }

        // Save the file.
        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (sfdImage.ShowDialog() == DialogResult.OK)
            {
                SaveBitmapUsingExtension(TheBitmap, sfdImage.FileName);
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

        // Let the user click and drag to select an area.
        private int StartX, StartY;
        private bool Drawing = false;
        private void picImage_MouseDown(object sender, MouseEventArgs e)
        {
            Drawing = true;
            StartX = e.X;
            StartY = e.Y;
        }
        private void picImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Drawing) return;
            Bitmap temp_bm = new Bitmap(TheBitmap);
            using (Graphics gr = Graphics.FromImage(temp_bm))
            {
                using (Pen dashed_pen = new Pen(Color.Black, 0))
                {
                    dashed_pen.DashStyle = DashStyle.Dash;
                    gr.DrawRectangle(dashed_pen,
                        Math.Min(StartX, e.X),
                        Math.Min(StartY, e.Y),
                        Math.Abs(StartX - e.X),
                        Math.Abs(StartY - e.Y));
                }
            }
            picImage.Image = temp_bm;
        }
        private void picImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (!Drawing) return;
            Drawing = false;

            // Process the selected area.
            Rectangle rect = new Rectangle(
                Math.Min(StartX, e.X),
                Math.Min(StartY, e.Y),
                Math.Abs(StartX - e.X),
                Math.Abs(StartY - e.Y));
            RemoveRedEye(TheBitmap, rect);
            picImage.Image = TheBitmap;
            picImage.Refresh();
        }

        // Remove redeye in the rectangle.
        private void RemoveRedEye(Bitmap bm, Rectangle rect)
        {
            for (int y = rect.Top; y <= rect.Bottom; y++)
            {
                for (int x = rect.Left; x <= rect.Right; x++)
                {
                    // See if it has more red than green and blue.
                    Color clr = bm.GetPixel(x, y);
                    if ((clr.R > clr.G) && (clr.R > clr.B))
                    {
                        // Convert to grayscale.
                        byte new_clr = (byte)((clr.R + clr.G + clr.B) / 3);
                        bm.SetPixel(x, y, Color.FromArgb(new_clr, new_clr, new_clr));
                    }
                }
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.sfdImage = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ofdImage
            // 
            this.ofdImage.FileName = "openFileDialog1";
            this.ofdImage.Filter = "Image Files|*.bmp;*.gif;*.jpg;*.png;*.tif|All Files|*.*";
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
            this.mnuFileOpen.Text = "&Open";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSaveAs
            // 
            this.mnuFileSaveAs.Name = "mnuFileSaveAs";
            this.mnuFileSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSaveAs.Size = new System.Drawing.Size(163, 22);
            this.mnuFileSaveAs.Text = "Save &As...";
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
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picImage.Location = new System.Drawing.Point(12, 27);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(100, 50);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImage.TabIndex = 1;
            this.picImage.TabStop = false;
            this.picImage.Visible = false;
            this.picImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseMove);
            this.picImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseDown);
            this.picImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseUp);
            // 
            // sfdImage
            // 
            this.sfdImage.Filter = "Image Files|*.bmp;*.gif;*.jpg;*.png;*.tif|All Files|*.*";
            // 
            // howto_redeye_reduction_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_redeye_reduction_Form1";
            this.Text = "howto_redeye_reduction";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdImage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.SaveFileDialog sfdImage;
    }
}

