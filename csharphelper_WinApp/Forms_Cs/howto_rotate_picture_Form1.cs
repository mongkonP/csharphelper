using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_rotate_picture_Form1:Form
  { 


        public howto_rotate_picture_Form1()
        {
            InitializeComponent();
        }

        // The current scale.
        private float ImageScale = 1;

        // The original and rotated bitmaps.
        private Bitmap OriginalImage = null, RotatedImage = null;

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdPicture.ShowDialog() == DialogResult.OK)
            {
                using (Bitmap bm = new Bitmap(ofdPicture.FileName))
                {
                    OriginalImage = new Bitmap(bm);
                    mnuFileSaveAs.Enabled = true;
                }

                DisplayImage();
            }
        }

        // Save the rotated file.
        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (sfdPicture.ShowDialog() == DialogResult.OK)
            {
                SaveImage(RotatedImage, sfdPicture.FileName);
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

        // Redisplay the image.
        private void txtAngle_TextChanged(object sender, EventArgs e)
        {
            DisplayImage();
        }

        // Display the image at the current rotation and scale.
        private void DisplayImage()
        {
            if (OriginalImage == null) return;
            RotatedImage = null;
            picRotatedImage.Visible = false;

            float angle;
            if (!float.TryParse(txtAngle.Text, out angle)) return;

            // Find the size of the image's rotated bounding box.
            Matrix rotation = new Matrix();
            rotation.Rotate(angle);
            int old_wid = OriginalImage.Width;
            int old_hgt = OriginalImage.Height;
            PointF[] points =
            {
                new PointF(0, 0),
                new PointF(old_wid, 0),
                new PointF(0, old_hgt),
                new PointF(old_wid, old_hgt),
            };
            rotation.TransformPoints(points);
            float[] xs = { points[0].X, points[1].X, points[2].X, points[3].X };
            float[] ys = { points[0].Y, points[1].Y, points[2].Y, points[3].Y };
            int new_wid = (int)(xs.Max() - xs.Min());
            int new_hgt = (int)(ys.Max() - ys.Min());

            // Make the rotated image.
            RotatedImage = new Bitmap(new_wid, new_hgt);
            using (Graphics gr = Graphics.FromImage(RotatedImage))
            {
                gr.TranslateTransform(-old_wid / 2, -old_hgt / 2,
                    MatrixOrder.Append);
                gr.RotateTransform(angle, MatrixOrder.Append);
                gr.TranslateTransform(new_wid / 2, new_hgt / 2,
                    MatrixOrder.Append);
                RectangleF source_rect = new RectangleF(0, 0,
                    OriginalImage.Width, OriginalImage.Height);
                PointF[] dest_points =
                {
                    new PointF(0, 0),
                    new PointF(OriginalImage.Width, 0),
                    new PointF(0, OriginalImage.Height),
                };
                gr.DrawImage(OriginalImage, dest_points, source_rect, GraphicsUnit.Pixel);

                // Uncomment to draw a red box around the image.
                //using (Pen pen = new Pen(Color.Red, 10))
                //{
                //    gr.DrawRectangle(pen, 0, 0,
                //        OriginalImage.Width - 1,
                //        OriginalImage.Height - 1);
                //}
            }

            // Scale the output PictureBox.
            SetPictureBoxSize();

            // Display the result.
            picRotatedImage.Image = RotatedImage;
            picRotatedImage.Visible = true;
        }

        // Change the scale.
        private void mnuScale_Click(object sender, EventArgs e)
        {
            // Check this Scale menu item and uncheck the others.
            ToolStripMenuItem[] menu_items =
            {
                mnuScale1_4, mnuScale1_2, mnuScale1,
                mnuScale2, mnuScale3, mnuScale4
            };
            foreach (ToolStripMenuItem mnu in menu_items)
                mnu.Checked = (mnu == sender);

            // Get the new scale.
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            ImageScale = float.Parse(item.Tag.ToString());

            // If we have an image loaded, resize the PictureBox.
            SetPictureBoxSize();
        }

        // Set the PictureBox to display the image
        // at the desired scale.
        private void SetPictureBoxSize()
        {
            if (RotatedImage == null) return;
            picRotatedImage.ClientSize = new Size(
                (int)(RotatedImage.Width * ImageScale),
                (int)(RotatedImage.Height * ImageScale));
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.picRotatedImage = new System.Windows.Forms.PictureBox();
            this.ofdPicture = new System.Windows.Forms.OpenFileDialog();
            this.sfdPicture = new System.Windows.Forms.SaveFileDialog();
            this.txtAngle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale1_5 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale1_4 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale1_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale4 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRotatedImage)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.picRotatedImage);
            this.panel1.Location = new System.Drawing.Point(12, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 196);
            this.panel1.TabIndex = 10;
            // 
            // picRotatedImage
            // 
            this.picRotatedImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picRotatedImage.Location = new System.Drawing.Point(0, 0);
            this.picRotatedImage.Name = "picRotatedImage";
            this.picRotatedImage.Size = new System.Drawing.Size(87, 71);
            this.picRotatedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRotatedImage.TabIndex = 5;
            this.picRotatedImage.TabStop = false;
            this.picRotatedImage.Visible = false;
            // 
            // ofdPicture
            // 
            this.ofdPicture.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            // 
            // sfdPicture
            // 
            this.sfdPicture.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            // 
            // txtAngle
            // 
            this.txtAngle.Location = new System.Drawing.Point(55, 33);
            this.txtAngle.Name = "txtAngle";
            this.txtAngle.Size = new System.Drawing.Size(44, 20);
            this.txtAngle.TabIndex = 9;
            this.txtAngle.Text = "0";
            this.txtAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAngle.TextChanged += new System.EventHandler(this.txtAngle_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Angle:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.scaleToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(384, 24);
            this.menuStrip1.TabIndex = 7;
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
            // scaleToolStripMenuItem
            // 
            this.scaleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuScale1_5,
            this.mnuScale1_4,
            this.mnuScale1_2,
            this.mnuScale1,
            this.mnuScale2,
            this.mnuScale3,
            this.mnuScale4});
            this.scaleToolStripMenuItem.Name = "scaleToolStripMenuItem";
            this.scaleToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.scaleToolStripMenuItem.Text = "&Scale";
            // 
            // mnuScale1_5
            // 
            this.mnuScale1_5.Name = "mnuScale1_5";
            this.mnuScale1_5.Size = new System.Drawing.Size(91, 22);
            this.mnuScale1_5.Tag = "0.2";
            this.mnuScale1_5.Text = "1/5";
            this.mnuScale1_5.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuScale1_4
            // 
            this.mnuScale1_4.Name = "mnuScale1_4";
            this.mnuScale1_4.Size = new System.Drawing.Size(91, 22);
            this.mnuScale1_4.Tag = "0.25";
            this.mnuScale1_4.Text = "1/&4";
            this.mnuScale1_4.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuScale1_2
            // 
            this.mnuScale1_2.Name = "mnuScale1_2";
            this.mnuScale1_2.Size = new System.Drawing.Size(91, 22);
            this.mnuScale1_2.Tag = "0.5";
            this.mnuScale1_2.Text = "1/&2";
            this.mnuScale1_2.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuScale1
            // 
            this.mnuScale1.Checked = true;
            this.mnuScale1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuScale1.Name = "mnuScale1";
            this.mnuScale1.Size = new System.Drawing.Size(91, 22);
            this.mnuScale1.Tag = "1";
            this.mnuScale1.Text = "&1";
            this.mnuScale1.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuScale2
            // 
            this.mnuScale2.Name = "mnuScale2";
            this.mnuScale2.Size = new System.Drawing.Size(91, 22);
            this.mnuScale2.Tag = "2";
            this.mnuScale2.Text = "2";
            this.mnuScale2.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuScale3
            // 
            this.mnuScale3.Name = "mnuScale3";
            this.mnuScale3.Size = new System.Drawing.Size(91, 22);
            this.mnuScale3.Tag = "3";
            this.mnuScale3.Text = "3";
            this.mnuScale3.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuScale4
            // 
            this.mnuScale4.Name = "mnuScale4";
            this.mnuScale4.Size = new System.Drawing.Size(91, 22);
            this.mnuScale4.Tag = "4";
            this.mnuScale4.Text = "4";
            this.mnuScale4.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // howto_rotate_picture_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtAngle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "howto_rotate_picture_Form1";
            this.Text = "howto_rotate_picture";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picRotatedImage)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picRotatedImage;
        private System.Windows.Forms.OpenFileDialog ofdPicture;
        private System.Windows.Forms.SaveFileDialog sfdPicture;
        private System.Windows.Forms.TextBox txtAngle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        private System.Windows.Forms.ToolStripMenuItem scaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuScale1_5;
        private System.Windows.Forms.ToolStripMenuItem mnuScale1_4;
        private System.Windows.Forms.ToolStripMenuItem mnuScale1_2;
        private System.Windows.Forms.ToolStripMenuItem mnuScale1;
        private System.Windows.Forms.ToolStripMenuItem mnuScale2;
        private System.Windows.Forms.ToolStripMenuItem mnuScale3;
        private System.Windows.Forms.ToolStripMenuItem mnuScale4;
    }
}

