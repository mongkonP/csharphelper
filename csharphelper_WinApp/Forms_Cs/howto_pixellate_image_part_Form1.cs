using System;
using System.Drawing;
using System.Windows.Forms;

using System.Drawing.Imaging;
using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_pixellate_image_part_Form1:Form
  { 


        public howto_pixellate_image_part_Form1()
        {
            InitializeComponent();
        }

        // The current image without the rubberband rectangle.
        private Bitmap CurrentBitmap = null;

        // Open a file.
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofdImage.ShowDialog() == DialogResult.OK)
                {
                    using (Bitmap bm = new Bitmap(ofdImage.FileName))
                    {
                        CurrentBitmap = bm.Clone() as Bitmap;
                        picImage.Image = bm.Clone() as Image;
                    }
                    ClientSize = new Size(
                        picImage.Right + picImage.Left,
                        picImage.Bottom + picImage.Left);
                    picImage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Save the image into a file.
        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (sfdImage.ShowDialog() == DialogResult.OK)
            {
                Bitmap bm = (Bitmap)picImage.Image;
                SaveBitmapUsingExtension(bm, sfdImage.FileName);
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

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Select an area.
        private int StartX = -1, StartY = -1;
        private Bitmap BoxBitmap = null;
        private Graphics BoxGraphics = null;
        private void picImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (CurrentBitmap == null) return;
            StartX = e.X;
            StartY = e.Y;

            // Make the selected image.
            BoxBitmap = new Bitmap(CurrentBitmap);
            BoxGraphics = Graphics.FromImage(BoxBitmap);
            picImage.Image = BoxBitmap;
        }

        // Continue selecting the area.
        private void picImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (StartX < 0) return;

            // Restore the current image.
            BoxGraphics.DrawImage(CurrentBitmap, 0, 0);

            // Draw the selection rectangle.
            using (Pen select_pen = new Pen(Color.Red))
            {
                select_pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                Rectangle rect = MakeRectangle(StartX, StartY, e.X, e.Y);
                BoxGraphics.DrawRectangle(select_pen, rect);
            }
            picImage.Refresh();
        }

        // Return a Rectangle with these points as corners.
        private Rectangle MakeRectangle(int x0, int y0, int x1, int y1)
        {
            return new Rectangle(
                Math.Min(x0, x1),
                Math.Min(y0, y1),
                Math.Abs(x0 - x1),
                Math.Abs(y0 - y1));
        }

        // Pixellate the selected area and save the result.
        private void picImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (StartX < 0) return;

            PixellateRectangle(MakeRectangle(StartX, StartY, e.X, e.Y));

            // Remember we're not selecting any more.
            StartX = -1;
            StartY = -1;
            BoxGraphics.Dispose();
            BoxGraphics = null;
            BoxBitmap.Dispose();
            BoxBitmap = null;
        }

        // Pixellate the indicated rectangle.
        private void PixellateRectangle(Rectangle rect)
        {
            // Restrict the rectangle to fit on the image.
            int bm_wid = CurrentBitmap.Width;
            int bm_hgt = CurrentBitmap.Height;
            rect = Rectangle.Intersect(rect,
                new Rectangle(0, 0, bm_wid, bm_hgt));

            // Process the rectangle.
            const int box_wid = 8;
            using (Graphics gr = Graphics.FromImage(CurrentBitmap))
            {
                int start_y = box_wid * (int)(rect.Top / box_wid);
                int start_x = box_wid * (int)(rect.Left / box_wid);
                for (int y = start_y; y <= rect.Bottom; y += box_wid)
                {
                    for (int x = start_x; x <= rect.Right; x += box_wid)
                    {
                        // Pixellate the area with upper left corner (x, y).

                        // Get the average of the pixels' color component values.
                        int total_r = 0, total_g = 0, total_b = 0, num_pixels = 0;
                        for (int dy = 0; dy < box_wid; dy++)
                        {
                            if (y + dy >= bm_hgt) break;
                            for (int dx = 0; dx < box_wid; dx++)
                            {
                                if (x + dx >= bm_wid) break;
                                Color pixel_color = 
                                    CurrentBitmap.GetPixel(x + dx, y + dy);
                                total_r += pixel_color.R;
                                total_g += pixel_color.G;
                                total_b += pixel_color.B;
                                num_pixels++;
                            }
                        }
                        byte r = (byte)(total_r / num_pixels);
                        byte g = (byte)(total_g / num_pixels);
                        byte b = (byte)(total_b / num_pixels);
                        Color new_color = Color.FromArgb(255, r, g, b);

                        // Give all pixels in the box this color.
                        using (Brush br = new SolidBrush(new_color))
                        {
                            gr.FillRectangle(br, x, y, box_wid, box_wid);
                        }
                    }
                }

                // Refresh to show the new image.
                picImage.Image = CurrentBitmap;
                picImage.Refresh();
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
            this.picImage = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdImage = new System.Windows.Forms.SaveFileDialog();
            this.ofdImage = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picImage.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picImage.Location = new System.Drawing.Point(12, 27);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(100, 100);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImage.TabIndex = 23;
            this.picImage.TabStop = false;
            this.picImage.Visible = false;
            this.picImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseMove);
            this.picImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseDown);
            this.picImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 24;
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
            this.mnuFileOpen.Size = new System.Drawing.Size(165, 22);
            this.mnuFileOpen.Text = "&Open...";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSaveAs
            // 
            this.mnuFileSaveAs.Name = "mnuFileSaveAs";
            this.mnuFileSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mnuFileSaveAs.Size = new System.Drawing.Size(165, 22);
            this.mnuFileSaveAs.Text = "Save &As...";
            this.mnuFileSaveAs.Click += new System.EventHandler(this.mnuFileSaveAs_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(162, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(165, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // sfdImage
            // 
            this.sfdImage.Filter = "Image Files|*.bmp;*.jpg;*.gif;*.png;*.tif|All Files|*.*";
            // 
            // ofdImage
            // 
            this.ofdImage.FileName = "openFileDialog1";
            this.ofdImage.Filter = "Image Files|*.bmp;*.jpg;*.gif;*.png;*.tif|All Files|*.*";
            // 
            // howto_pixellate_image_part_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.picImage);
            this.Name = "howto_pixellate_image_part_Form1";
            this.Text = "howto_pixellate_image_part";
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.SaveFileDialog sfdImage;
        private System.Windows.Forms.OpenFileDialog ofdImage;
    }
}

