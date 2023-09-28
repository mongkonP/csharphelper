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
     public partial class howto_straighten_image_Form1:Form
  { 


        public howto_straighten_image_Form1()
        {
            InitializeComponent();
        }

        private Bitmap OriginalBitmap = null;
        private Bitmap RotatedBitmap = null;
        private float Angle = 0;
        private Point StartPoint = new Point(50, 100);
        private Point EndPoint = new Point(210, 100);
        private bool Drawing = false;

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                OriginalBitmap = LoadBitmapUnlocked(ofdImage.FileName);
                Angle = 0;
                DrawImage();
            }
        }

        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (sfdImage.ShowDialog() == DialogResult.OK)
            {
                SaveImage(RotatedBitmap, sfdImage.FileName);
            }
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
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

        // Display the image rotated by the current amount.
        private void DrawImage()
        {
            if (OriginalBitmap == null)
            {
                picImage.Refresh();
                return;
            }

            // Get the image's dimensions.
            int wid = OriginalBitmap.Width;
            int hgt = OriginalBitmap.Height;

            // Make a Matrix representing the rotation.
            Matrix matrix = new Matrix();
            matrix.Rotate(Angle);

            // Rotate the image's corners to see
            // how large the rotated image must be.
            PointF[] points =
            {
                new PointF(0, 0),
                new PointF(wid, 0),
                new PointF(0, hgt),
                new PointF(wid, hgt),
            };
            matrix.TransformPoints(points);

            // Get the rotated bounds.
            float xmin = points[0].X;
            float xmax = xmin;
            float ymin = points[0].Y;
            float ymax = ymin;
            for (int i = 1; i < points.Length; i++)
            {
                if (xmin > points[i].X) xmin = points[i].X;
                if (xmax < points[i].X) xmax = points[i].X;
                if (ymin > points[i].Y) ymin = points[i].Y;
                if (ymax < points[i].Y) ymax = points[i].Y;
            }

            // Get the new image's dimensions.
            float new_wid = xmax - xmin;
            float new_hgt = ymax - ymin;

            // Add a translation to move the rotated image
            // to the center of the new bitmap.
            matrix.Translate(new_wid / 2, new_hgt / 2, MatrixOrder.Append);

            // Make the new bitmap.
            RotatedBitmap = new Bitmap((int)new_wid, (int)new_hgt);
            using (Graphics gr = Graphics.FromImage(RotatedBitmap))
            {
                gr.InterpolationMode = InterpolationMode.High;
                gr.Clear(Color.White);
                gr.Transform = matrix;

                // Draw the image centered at the origin.
                PointF[] dest_points =
                {
                    new PointF(-wid / 2, -hgt / 2),
                    new PointF(wid / 2, -hgt / 2),
                    new PointF(-wid / 2, hgt / 2),
                };
                gr.DrawImage(OriginalBitmap, dest_points);
            }

            // Display the result.
            picImage.Image = RotatedBitmap;
        }

        // Let the use select an orientation line.
        private void picImage_MouseDown(object sender, MouseEventArgs e)
        {
            StartPoint = e.Location;
            EndPoint = e.Location;
            Drawing = true;
        }

        private void picImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Drawing) return;
            EndPoint = e.Location;
            picImage.Refresh();
        }

        private void picImage_MouseUp(object sender, MouseEventArgs e)
        {
            Drawing = false;

            // Calculate the line's angle.
            int dx = EndPoint.X - StartPoint.X;
            int dy = EndPoint.Y - StartPoint.Y;
            double new_angle = Math.Atan2(dy, dx) * 180.0 / Math.PI;
            
            // Subtract this angle from the total angle so far.
            Angle -= (float)new_angle;

            // Make the new rotated image.
            DrawImage();
        }

        // Draw the horizon line and alignment grid.
        private void picImage_Paint(object sender, PaintEventArgs e)
        {
            if (Drawing)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawLine(Pens.Yellow, StartPoint, EndPoint);
                using (Pen pen = new Pen(Color.Red))
                {
                    pen.DashPattern = new float[] { 5, 5 };
                    e.Graphics.DrawLine(pen, StartPoint, EndPoint);
                }
            }

            if (mnuFormatDrawGrid.Checked)
            {
                const int dx = 50;
                int xmax = picImage.ClientSize.Width;
                int ymax = picImage.ClientSize.Height;
                for (int x = 0; x < xmax; x += dx)
                    e.Graphics.DrawLine(Pens.Silver, x, 0, x, ymax);
                for (int y = 0; y < ymax; y += dx)
                    e.Graphics.DrawLine(Pens.Silver, 0, y, xmax, y);
            }
        }

        // Reset the angle to 0.
        private void mnuFormatReset_Click(object sender, EventArgs e)
        {
            Angle = 0;
            StartPoint = new Point(50, 100);
            EndPoint = new Point(210, 100);
            DrawImage();
        }

        private void mnuFormatDrawGrid_Click(object sender, EventArgs e)
        {
            picImage.Refresh();
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
            this.angleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormatResetAngle = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormatDrawGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdImage = new System.Windows.Forms.OpenFileDialog();
            this.sfdImage = new System.Windows.Forms.SaveFileDialog();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.angleToolStripMenuItem});
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
            // angleToolStripMenuItem
            // 
            this.angleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFormatResetAngle,
            this.mnuFormatDrawGrid});
            this.angleToolStripMenuItem.Name = "angleToolStripMenuItem";
            this.angleToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.angleToolStripMenuItem.Text = "F&ormat";
            // 
            // mnuFormatResetAngle
            // 
            this.mnuFormatResetAngle.Name = "mnuFormatResetAngle";
            this.mnuFormatResetAngle.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mnuFormatResetAngle.Size = new System.Drawing.Size(197, 22);
            this.mnuFormatResetAngle.Text = "&Reset Angle = 0";
            this.mnuFormatResetAngle.Click += new System.EventHandler(this.mnuFormatReset_Click);
            // 
            // mnuFormatDrawGrid
            // 
            this.mnuFormatDrawGrid.CheckOnClick = true;
            this.mnuFormatDrawGrid.Name = "mnuFormatDrawGrid";
            this.mnuFormatDrawGrid.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.mnuFormatDrawGrid.Size = new System.Drawing.Size(197, 22);
            this.mnuFormatDrawGrid.Text = "Draw &Grid";
            this.mnuFormatDrawGrid.Click += new System.EventHandler(this.mnuFormatDrawGrid_Click);
            // 
            // ofdImage
            // 
            this.ofdImage.FileName = "openFileDialog1";
            this.ofdImage.Filter = "Picture files|*.bmp;*.jpg;*.gif;*.png;*.tif|All Files|*.*";
            // 
            // sfdImage
            // 
            this.sfdImage.DefaultExt = "png";
            this.sfdImage.Filter = "Picture files|*.bmp;*.jpg;*.gif;*.png;*.tif|All Files|*.*";
            // 
            // picImage
            // 
            this.picImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picImage.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picImage.Location = new System.Drawing.Point(12, 27);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(260, 222);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 1;
            this.picImage.TabStop = false;
            this.picImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseMove);
            this.picImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseDown);
            this.picImage.Paint += new System.Windows.Forms.PaintEventHandler(this.picImage_Paint);
            this.picImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseUp);
            // 
            // howto_straighten_image_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_straighten_image_Form1";
            this.Text = "howto_straighten_image";
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
        private System.Windows.Forms.OpenFileDialog ofdImage;
        private System.Windows.Forms.SaveFileDialog sfdImage;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.ToolStripMenuItem angleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFormatResetAngle;
        private System.Windows.Forms.ToolStripMenuItem mnuFormatDrawGrid;
    }
}

