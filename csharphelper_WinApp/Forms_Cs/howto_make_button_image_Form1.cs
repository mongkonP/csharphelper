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
     public partial class howto_make_button_image_Form1:Form
  { 


        public howto_make_button_image_Form1()
        {
            InitializeComponent();
        }

        // Save the image into a file.
        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (sfdButtonFile.ShowDialog() == DialogResult.OK)
            {
                SaveBitmapUsingExtension(TheBitmap, sfdButtonFile.FileName);
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

        // The bitmap.
        Bitmap TheBitmap = new Bitmap(16, 16);

        // Draw the image to save.
        private void howto_make_button_image_Form1_Load(object sender, EventArgs e)
        {
            // Fit the picture we draw.
            picCanvas.SizeMode = PictureBoxSizeMode.AutoSize;

            // Make the bitmap.
            TheBitmap = new Bitmap(16, 16);

            using (Graphics gr = Graphics.FromImage(TheBitmap))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                // Give it a transparent background.
                gr.Clear(Color.Transparent);

                // Draw.
                using (Pen the_pen = new Pen(Color.Blue, 3))
                {
                    the_pen.EndCap = LineCap.Round;
                    the_pen.StartCap = LineCap.Round;
                    the_pen.LineJoin = LineJoin.Round;

                    // Down expander.
                    Point[] points =
                    {
                        new Point(3, 2),
                        new Point(8, 7),
                        new Point(13, 2),
                    };
                    gr.DrawLines(the_pen, points);

                    for (int i = 0; i < points.Length; i++)
                    {
                        points[i].Y += 6;
                    }
                    gr.DrawLines(the_pen, points);

                    //// Up expander.
                    //Point[] points =
                    //{
                    //    new Point(3, 13),
                    //    new Point(8, 8),
                    //    new Point(13, 13),
                    //};
                    //gr.DrawLines(the_pen, points);

                    //for (int i = 0; i < points.Length; i++)
                    //{
                    //    points[i].Y -= 6;
                    //}
                    //gr.DrawLines(the_pen, points);
                }
            }

            // Display the result.
            picCanvas.Image = TheBitmap;
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
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdButtonFile = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuFileSaveAs
            // 
            this.mnuFileSaveAs.Name = "mnuFileSaveAs";
            this.mnuFileSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSaveAs.Size = new System.Drawing.Size(154, 22);
            this.mnuFileSaveAs.Text = "Save &As";
            this.mnuFileSaveAs.Click += new System.EventHandler(this.mnuFileSaveAs_Click);
            // 
            // picCanvas
            // 
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(12, 27);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(100, 50);
            this.picCanvas.TabIndex = 3;
            this.picCanvas.TabStop = false;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileSaveAs});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // sfdButtonFile
            // 
            this.sfdButtonFile.Filter = "PNG Files|*.png|Graphic FIles|*.bmp;*.jpg;*.gif;*.png|All Files|*.*";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(334, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // howto_make_button_image_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 111);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.menuStrip1);
            this.Name = "howto_make_button_image_Form1";
            this.Text = "howto_make_button_image";
            this.Load += new System.EventHandler(this.howto_make_button_image_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfdButtonFile;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

