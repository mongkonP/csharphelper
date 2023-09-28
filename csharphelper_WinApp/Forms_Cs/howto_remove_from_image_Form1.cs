using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_remove_from_image_Form1:Form
  { 


        public howto_remove_from_image_Form1()
        {
            InitializeComponent();
        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdOriginal.ShowDialog() == DialogResult.OK)
                try
                {
                    // Load the image.
                    picSource.Image = LoadUnlocked(ofdOriginal.FileName);
                    picSource.Visible = true;
                    picArea.Image = null;
                    picWithoutArea.Image = null;

                    // Disable the Save menu items.
                    mnuFileSaveArea.Enabled = false;
                    mnuFileSaveWithoutArea.Enabled = false;

                    // Arrange the PictureBoxes.
                    int gap = picSource.Left;
                    picArea.Size = picSource.Size;
                    picArea.Left = picSource.Right + gap;
                    picArea.Visible = true;

                    picWithoutArea.Size = picSource.Size;
                    picWithoutArea.Left = picArea.Right + gap;
                    picWithoutArea.Visible = true;

                    // Make the form big enough.
                    int width = Math.Max(ClientSize.Width,
                        picWithoutArea.Right + gap);
                    int height = Math.Max(ClientSize.Height,
                        picSource.Bottom + gap);
                    this.ClientSize = new Size(width, height);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        // For selecting an area.
        private List<Point> Points = null;
        private bool Drawing = false;

        // Start selecting an area.
        private void picSource_MouseDown(object sender, MouseEventArgs e)
        {
            Points = new List<Point>();
            Drawing = true;
        }

        // Continue selecting the area.
        private void picSource_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Drawing) return;
            Points.Add(new Point(e.X, e.Y));
            picSource.Invalidate();
        }

        // Stop selecting the area.
        private void picSource_MouseUp(object sender, MouseEventArgs e)
        {
            Drawing = false;
            mnuFileSaveArea.Enabled = true;
            mnuFileSaveWithoutArea.Enabled = true;
            if (Points == null) return;

            // Make the image with only the area.
            Bitmap with_area_bitmap =
                MakeImageWithArea((Bitmap)picSource.Image, Points);
            picArea.Image = MakeSampleImage(with_area_bitmap);

            // Make the image without the area.
            Bitmap without_area_bitmap =
                MakeImageWithoutArea((Bitmap)picSource.Image, Points);
            picWithoutArea.Image = MakeSampleImage(without_area_bitmap);
        }

        // Make an image that includes only the selected area.
        private Bitmap MakeImageWithArea(Bitmap source_bm, List<Point> points)
        {
            // Copy the image.
            Bitmap bm = new Bitmap(source_bm.Width, source_bm.Height);
            
            // Clear the selected area.
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(Color.Transparent);

                // Make a brush that contains the original image.
                using (Brush brush = new TextureBrush(source_bm))
                {
                    // Fill the selected area.
                    gr.FillPolygon(brush, points.ToArray());
                }
            }
            return bm;
        }

        // Make an image that includes only the selected area.
        private Bitmap MakeImageWithoutArea(Bitmap source_bm, List<Point> points)
        {
            // Copy the image.
            Bitmap bm = new Bitmap(source_bm);

            // Clear the selected area.
            using (Graphics gr = Graphics.FromImage(bm))
            {
                GraphicsPath path = new GraphicsPath();
                path.AddPolygon(points.ToArray());
                gr.SetClip(path);
                gr.Clear(Color.Transparent);
                gr.ResetClip();
            }
            return bm;
        }

        // Make a sample showing transparent areas.
        private Bitmap MakeSampleImage(Bitmap bitmap)
        {
            const int box_wid = 20;
            const int box_hgt = 20;

            Bitmap bm = new Bitmap(bitmap.Width, bitmap.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                // Start with a checkerboard pattern.
                gr.Clear(Color.White);
                int num_rows = bm.Height / box_hgt;
                int num_cols = bm.Width / box_wid;
                for (int row = 0; row < num_rows; row++)
                {
                    int y = row * box_hgt;
                    for (int col = 0; col < num_cols; col++)
                    {
                        int x = 2 * col * box_wid;
                        if (row % 2 == 1) x += box_wid;
                        gr.FillRectangle(Brushes.LightBlue,
                            x, y, box_wid, box_hgt);
                    }
                }

                // Draw the image on top.
                gr.DrawImageUnscaled(bitmap, 0, 0);
            }
            return bm;
        }

        // Draw the current selection if there is one.
        private void picSource_Paint(object sender, PaintEventArgs e)
        {
            if ((Points != null) && (Points.Count > 1))
            {
                using (Pen dashed_pen = new Pen(Color.Black))
                {
                    dashed_pen.DashPattern = new float[] { 5, 5 };
                    e.Graphics.DrawLines(Pens.White, Points.ToArray());
                    e.Graphics.DrawLines(dashed_pen, Points.ToArray());
                }
            }
        }

        private void mnuFileSaveArea_Click(object sender, EventArgs e)
        {
            if (sfdResult.ShowDialog() == DialogResult.OK)
            {
                SaveBitmapUsingExtension((Bitmap)picArea.Image,
                    sfdResult.FileName);
            }
        }

        private void mnuFileSaveWithoutArea_Click(object sender, EventArgs e)
        {
            if (sfdResult.ShowDialog() == DialogResult.OK)
            {
                SaveBitmapUsingExtension((Bitmap)picWithoutArea.Image,
                    sfdResult.FileName);
            }
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
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
        // Return a bitmap without locking its file.
        private Bitmap LoadUnlocked(string file_name)
        {
            using (Bitmap bm = (Bitmap)Image.FromFile(file_name))
            {
                return new Bitmap(bm);
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
            this.picSource = new System.Windows.Forms.PictureBox();
            this.ofdOriginal = new System.Windows.Forms.OpenFileDialog();
            this.sfdResult = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveArea = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveWithoutArea = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.picArea = new System.Windows.Forms.PictureBox();
            this.picWithoutArea = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWithoutArea)).BeginInit();
            this.SuspendLayout();
            // 
            // picSource
            // 
            this.picSource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picSource.Location = new System.Drawing.Point(12, 27);
            this.picSource.Name = "picSource";
            this.picSource.Size = new System.Drawing.Size(100, 100);
            this.picSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSource.TabIndex = 10;
            this.picSource.TabStop = false;
            this.picSource.Visible = false;
            this.picSource.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picSource_MouseMove);
            this.picSource.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picSource_MouseDown);
            this.picSource.Paint += new System.Windows.Forms.PaintEventHandler(this.picSource_Paint);
            this.picSource.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picSource_MouseUp);
            // 
            // ofdOriginal
            // 
            this.ofdOriginal.Filter = "Image Files|*.bmp;*.jpg;*.gif;*.tif;*.png|All Files|*.*";
            // 
            // sfdResult
            // 
            this.sfdResult.Filter = "Image Files|*.bmp;*.jpg;*.gif;*.tif;*.png|All Files|*.*";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(333, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.mnuFileSaveArea,
            this.mnuFileSaveWithoutArea,
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
            this.mnuFileOpen.Size = new System.Drawing.Size(225, 22);
            this.mnuFileOpen.Text = "&Open...";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSaveArea
            // 
            this.mnuFileSaveArea.Enabled = false;
            this.mnuFileSaveArea.Name = "mnuFileSaveArea";
            this.mnuFileSaveArea.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mnuFileSaveArea.Size = new System.Drawing.Size(225, 22);
            this.mnuFileSaveArea.Text = "Save &Area...";
            this.mnuFileSaveArea.Click += new System.EventHandler(this.mnuFileSaveArea_Click);
            // 
            // mnuFileSaveWithoutArea
            // 
            this.mnuFileSaveWithoutArea.Enabled = false;
            this.mnuFileSaveWithoutArea.Name = "mnuFileSaveWithoutArea";
            this.mnuFileSaveWithoutArea.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.mnuFileSaveWithoutArea.Size = new System.Drawing.Size(225, 22);
            this.mnuFileSaveWithoutArea.Text = "Save &Without Area...";
            this.mnuFileSaveWithoutArea.Click += new System.EventHandler(this.mnuFileSaveWithoutArea_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(222, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(225, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // picArea
            // 
            this.picArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picArea.Location = new System.Drawing.Point(118, 27);
            this.picArea.Name = "picArea";
            this.picArea.Size = new System.Drawing.Size(100, 100);
            this.picArea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picArea.TabIndex = 12;
            this.picArea.TabStop = false;
            this.picArea.Visible = false;
            // 
            // picWithoutArea
            // 
            this.picWithoutArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picWithoutArea.Location = new System.Drawing.Point(224, 27);
            this.picWithoutArea.Name = "picWithoutArea";
            this.picWithoutArea.Size = new System.Drawing.Size(100, 100);
            this.picWithoutArea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picWithoutArea.TabIndex = 13;
            this.picWithoutArea.TabStop = false;
            this.picWithoutArea.Visible = false;
            // 
            // howto_remove_from_image_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 261);
            this.Controls.Add(this.picWithoutArea);
            this.Controls.Add(this.picArea);
            this.Controls.Add(this.picSource);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_remove_from_image_Form1";
            this.Text = "howto_remove_from_image";
            ((System.ComponentModel.ISupportInitialize)(this.picSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWithoutArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picSource;
        private System.Windows.Forms.OpenFileDialog ofdOriginal;
        private System.Windows.Forms.SaveFileDialog sfdResult;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveWithoutArea;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveArea;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.PictureBox picArea;
        private System.Windows.Forms.PictureBox picWithoutArea;
    }
}

