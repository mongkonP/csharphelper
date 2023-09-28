using System;
using System.Drawing;
using System.Windows.Forms;

using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_rotate_scrolled_Form1:Form
  { 


        public howto_rotate_scrolled_Form1()
        {
            InitializeComponent();
        }

        // The original image.
        private Bitmap OriginalBitmap;

        // The rotated image.
        private Bitmap RotatedBitmap;

        // The center of the bitmap.
        private PointF ImageCenter;

        // The current angle of rotation during a drag.
        private float CurrentAngle = 0;

        // The total angle rotated so far in previous drags.
        private float TotalAngle = 0;

        // Load an image file.
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                // Start with no rotation.
                CurrentAngle = 0;
                TotalAngle = 0;

                // Load the bitmap.
                Bitmap bm = new Bitmap(ofdFile.FileName);
                picRotated.Image = OriginalBitmap;
                picRotated.Visible = true;

                // See how big the rotated bitmap must be.
                int wid = (int)Math.Sqrt(bm.Width * bm.Width + bm.Height * bm.Height);

                // Make the original unrotated bitmap.
                OriginalBitmap = new Bitmap(wid, wid);

                // Save the center of the image for calculating rotation angles.
                ImageCenter = new PointF(wid / 2f, wid / 2f);

                // Copy the image into the middle of the bitmap.
                using (Graphics gr = Graphics.FromImage(OriginalBitmap))
                {
                    // Clear with the color in the image's upper left corner.
                    gr.Clear(bm.GetPixel(0, 0));

                    //// For debugging. (Easier to see the background.)
                    //gr.Clear(Color.LightBlue);

                    // Draw the image centered.
                    gr.DrawImage(bm, (wid - bm.Width) / 2, (wid - bm.Height) / 2);
                }

                // Display the original image.
                picRotated.Image = OriginalBitmap;

                // Size the form to fit.
                SizeForm();

                // Enable Save As.
                mnuFileSaveAs.Enabled = true;
            }
        }

        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (sfdFile.ShowDialog() == DialogResult.OK)
            {
                SaveBitmapUsingExtension(RotatedBitmap, sfdFile.FileName);
            }
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Save the file with the appropriate format.
        // Throw a NotSupportedException if the file
        // has an unknown extension.
        public void SaveBitmapUsingExtension(Bitmap bm,
            string filename)
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

        // Return a bitmap rotated around its center.
        private Bitmap RotateBitmap(Bitmap bm, float angle)
        {
            // Make a bitmap to hold the rotated result.
            Bitmap result = new Bitmap(bm.Width, bm.Height);

            // Create the real rotation transformation.
            Matrix rotate_at_center = new Matrix();
            rotate_at_center.RotateAt(angle,
                new PointF(bm.Width / 2f, bm.Height / 2f));

            // Draw the image onto the new bitmap rotated.
            using (Graphics gr = Graphics.FromImage(result))
            {
                // Use smooth image interpolation.
                gr.InterpolationMode = InterpolationMode.High;

                // Clear with the color in the image's upper left corner.
                gr.Clear(OriginalBitmap.GetPixel(0, 0));

                //// For debugging. (Makes it easier to see the background.)
                //gr.Clear(Color.LightBlue);

                // Set up the transformation to rotate.
                gr.Transform = rotate_at_center;

                // Draw the image centered on the bitmap.
                gr.DrawImage(bm, 0, 0);
            }

            // Return the result bitmap.
            return result;
        }

        // Find the bounding rectangle for an array of points.
        private void GetPointBounds(PointF[] points, out float xmin, out float xmax, out float ymin, out float ymax)
        {
            xmin = points[0].X;
            xmax = xmin;
            ymin = points[0].Y;
            ymax = ymin;
            foreach (PointF point in points)
            {
                if (xmin > point.X) xmin = point.X;
                if (xmax < point.X) xmax = point.X;
                if (ymin > point.Y) ymin = point.Y;
                if (ymax < point.Y) ymax = point.Y;
            }
        }

        // Make sure the form is big enough to show the rotated image.
        private void SizeForm()
        {
            int wid = picRotated.Right + picRotated.Left;
            int hgt = picRotated.Bottom + picRotated.Left;
            if (wid > 900) wid = 900;
            if (hgt > 600) hgt = 600;
            this.ClientSize = new Size(
                Math.Max(wid, this.ClientSize.Width),
                Math.Max(hgt, this.ClientSize.Height));
        }

        // Let the user click and drag to rotate.
        private float StartAngle;
        private bool DragInProgress = false;
        private void picRotated_MouseDown(object sender, MouseEventArgs e)
        {
            // Do nothing if there's no image loaded.
            if (OriginalBitmap == null) return;
            DragInProgress = true;

            // Get the initial angle from horizontal to the
            // vector between the center and the drag start point.
            float dx = e.X - ImageCenter.X;
            float dy = e.Y - ImageCenter.Y;
            StartAngle = (float)Math.Atan2(dy, dx);
        }

        private void picRotated_MouseMove(object sender, MouseEventArgs e)
        {
            // Do nothing if there's no drag in progress.
            if (!DragInProgress) return;

            // Get the angle from horizontal to the
            // vector between the center and the current point.
            float dx = e.X - ImageCenter.X;
            float dy = e.Y - ImageCenter.Y;
            float new_angle = (float)Math.Atan2(dy, dx);

            // Calculate the change in angle.
            CurrentAngle = new_angle - StartAngle;

            // Convert to degrees.
            CurrentAngle *= 180 / (float)Math.PI;

            // Add to the previous total angle rotated.
            CurrentAngle += TotalAngle;
            txtAngle.Text = CurrentAngle.ToString("0.00") + "°";

            // Rotate the original image to make the result bitmap.
            RotatedBitmap = RotateBitmap(OriginalBitmap, CurrentAngle);

            // Display the result.
            picRotated.Image = RotatedBitmap;
            picRotated.Refresh();
        }

        private void picRotated_MouseUp(object sender, MouseEventArgs e)
        {
            DragInProgress = false;

            // Save the new total angle of rotation.
            TotalAngle = CurrentAngle;
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
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.sfdFile = new System.Windows.Forms.SaveFileDialog();
            this.picRotated = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAngle = new System.Windows.Forms.TextBox();
            this.panScroller = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picRotated)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panScroller.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdFile
            // 
            this.ofdFile.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            // 
            // sfdFile
            // 
            this.sfdFile.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            // 
            // picRotated
            // 
            this.picRotated.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picRotated.Location = new System.Drawing.Point(3, 3);
            this.picRotated.Name = "picRotated";
            this.picRotated.Size = new System.Drawing.Size(54, 50);
            this.picRotated.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picRotated.TabIndex = 6;
            this.picRotated.TabStop = false;
            this.picRotated.Visible = false;
            this.picRotated.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picRotated_MouseMove);
            this.picRotated.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picRotated_MouseDown);
            this.picRotated.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picRotated_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(384, 24);
            this.menuStrip1.TabIndex = 5;
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
            this.mnuFileOpen.Size = new System.Drawing.Size(154, 22);
            this.mnuFileOpen.Text = "&Open";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSaveAs
            // 
            this.mnuFileSaveAs.Enabled = false;
            this.mnuFileSaveAs.Name = "mnuFileSaveAs";
            this.mnuFileSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSaveAs.Size = new System.Drawing.Size(154, 22);
            this.mnuFileSaveAs.Text = "&Save As";
            this.mnuFileSaveAs.Click += new System.EventHandler(this.mnuFileSaveAs_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(151, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(154, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Angle:";
            // 
            // txtAngle
            // 
            this.txtAngle.Location = new System.Drawing.Point(50, 27);
            this.txtAngle.Name = "txtAngle";
            this.txtAngle.ReadOnly = true;
            this.txtAngle.Size = new System.Drawing.Size(53, 20);
            this.txtAngle.TabIndex = 8;
            this.txtAngle.TabStop = false;
            // 
            // panScroller
            // 
            this.panScroller.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panScroller.AutoScroll = true;
            this.panScroller.BackColor = System.Drawing.Color.White;
            this.panScroller.Controls.Add(this.picRotated);
            this.panScroller.Location = new System.Drawing.Point(0, 53);
            this.panScroller.Name = "panScroller";
            this.panScroller.Size = new System.Drawing.Size(384, 207);
            this.panScroller.TabIndex = 9;
            // 
            // howto_rotate_scrolled_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.panScroller);
            this.Controls.Add(this.txtAngle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "howto_rotate_scrolled_Form1";
            this.Text = "howto_rotate_scrolled";
            ((System.ComponentModel.ISupportInitialize)(this.picRotated)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panScroller.ResumeLayout(false);
            this.panScroller.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.SaveFileDialog sfdFile;
        private System.Windows.Forms.PictureBox picRotated;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAngle;
        private System.Windows.Forms.Panel panScroller;
    }
}

