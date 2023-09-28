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
     public partial class howto_zoom_and_crop_Form1:Form
  { 


        public howto_zoom_and_crop_Form1()
        {
            InitializeComponent();
        }

        // Exit the program.
        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // The original image.
        private Bitmap OriginalImage;

        // The currently cropped image.
        private Bitmap CroppedImage;

        // The currently scaled cropped image.
        private Bitmap ScaledImage;

        // The cropped image with the selection rectangle.
        private Bitmap DisplayImage;
        private Graphics DisplayGraphics;

        // The current scale.
        private float ImageScale = 1f;

        // Open a file.
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdPicture.ShowDialog() == DialogResult.OK)
            {
                OriginalImage = LoadBitmapUnlocked(ofdPicture.FileName);
                CroppedImage = OriginalImage.Clone() as Bitmap;

                MakeScaledImage();
            }
        }

        // Make the scaled cropped image.
        private void MakeScaledImage()
        {
            int wid = (int)(ImageScale * (CroppedImage.Width));
            int hgt = (int)(ImageScale * (CroppedImage.Height));
            ScaledImage = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(ScaledImage))
            {
                Rectangle src_rect = new Rectangle(0, 0,
                    CroppedImage.Width, CroppedImage.Height);
                Rectangle dest_rect = new Rectangle(0, 0, wid, hgt);
                gr.PixelOffsetMode = PixelOffsetMode.Half;
                gr.InterpolationMode = InterpolationMode.NearestNeighbor;
                gr.DrawImage(CroppedImage, dest_rect, src_rect,
                    GraphicsUnit.Pixel);
            }

            DisplayImage = ScaledImage.Clone() as Bitmap;
            if (DisplayGraphics != null) DisplayGraphics.Dispose();
            DisplayGraphics = Graphics.FromImage(DisplayImage);

            picCropped.Image = DisplayImage;
            picCropped.Visible = true;
        }

        // Let the user select an area.
        private bool Drawing = false;
        private Point StartPoint, EndPoint;
        private void picCropped_MouseDown(object sender, MouseEventArgs e)
        {
            Drawing = true;

            StartPoint = RoundPoint(e.Location);

            // Draw the area selected.
            DrawSelectionBox(StartPoint);
        }

        private void picCropped_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Drawing) return;

            // Draw the area selected.
            DrawSelectionBox(RoundPoint(e.Location));
        }

        private void picCropped_MouseUp(object sender, MouseEventArgs e)
        {
            if (!Drawing) return;
            Drawing = false;

            // Crop.
            // Get the selected area's dimensions.
            int x = (int)(Math.Min(StartPoint.X, EndPoint.X) / ImageScale);
            int y = (int)(Math.Min(StartPoint.Y, EndPoint.Y) / ImageScale);
            int width = (int)(Math.Abs(StartPoint.X - EndPoint.X) / ImageScale);
            int height = (int)(Math.Abs(StartPoint.Y - EndPoint.Y) / ImageScale);

            if ((width == 0) || (height == 0))
            {
                MessageBox.Show("Width and height must be greater than 0.");
                return;
            }

            Rectangle source_rect = new Rectangle(x, y, width, height);
            Rectangle dest_rect = new Rectangle(0, 0, width, height);

            // Copy that part of the image to a new bitmap.
            Bitmap new_image = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(new_image))
            {
                gr.DrawImage(CroppedImage, dest_rect, source_rect,
                    GraphicsUnit.Pixel);
            }
            CroppedImage = new_image;

            // Display the new scaled image.
            MakeScaledImage();
        }

        // Round the point to the nearest unscaled pixel location.
        private Point RoundPoint(Point point)
        {
            int x = (int)(ImageScale * (int)(point.X / ImageScale));
            int y = (int)(ImageScale * (int)(point.Y / ImageScale));
            return new Point(x, y);
        }

        // Draw the area selected.
        private void DrawSelectionBox(Point end_point)
        {
            // Save the end point.
            EndPoint = end_point;
            if (EndPoint.X < 0) EndPoint.X = 0;
            if (EndPoint.X >= ScaledImage.Width) EndPoint.X = ScaledImage.Width - 1;
            if (EndPoint.Y < 0) EndPoint.Y = 0;
            if (EndPoint.Y >= ScaledImage.Height) EndPoint.Y = ScaledImage.Height - 1;

            // Reset the image.
            DisplayGraphics.DrawImageUnscaled(ScaledImage, 0, 0);

            // Draw the selection area.
            int x = Math.Min(StartPoint.X, EndPoint.X);
            int y = Math.Min(StartPoint.Y, EndPoint.Y);
            int width = Math.Abs(StartPoint.X - EndPoint.X);
            int height = Math.Abs(StartPoint.Y - EndPoint.Y);
            DisplayGraphics.DrawRectangle(Pens.Red, x, y, width, height);
            picCropped.Refresh();
        }

        // Display the original image.
        private void mnuPictureReset_Click(object sender, EventArgs e)
        {
            CroppedImage = OriginalImage.Clone() as Bitmap;
            MakeScaledImage();
        }

        // Save the current file.
        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            if (sfdPicture.ShowDialog() == DialogResult.OK)
            {
                SaveBitmapUsingExtension(CroppedImage, sfdPicture.FileName);
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

        // Load the image into a Bitmap, clone it, and
        // set the PictureBox's Image property to the Bitmap.
        private Bitmap LoadBitmapUnlocked(string file_name)
        {
            using (Bitmap bm = new Bitmap(file_name))
            {
                Bitmap new_bitmap = new Bitmap(bm.Width, bm.Height);
                using (Graphics gr = Graphics.FromImage(new_bitmap))
                {
                    gr.DrawImage(bm, 0, 0);
                }
                return new_bitmap;
            }
        }

        // Change the scale.
        private void mnuScale_Click(object sender, EventArgs e)
        {
            // Get the scale percentage.
            ToolStripMenuItem mnu = sender as ToolStripMenuItem;
            int percent = int.Parse(mnu.Text.Replace("&", "").Replace("%", ""));
            ImageScale = percent / 100f;

            // Check the selected menu item.
            mnuScale50.Checked = false;
            mnuScale100.Checked = false;
            mnuScale200.Checked = false;
            mnuScale300.Checked = false;
            mnuScale400.Checked = false;
            mnuScale500.Checked = false;
            mnuScale1000.Checked = false;
            mnu.Checked = true;

            MakeScaledImage();
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
            this.ofdPicture = new System.Windows.Forms.OpenFileDialog();
            this.picCropped = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPictureReset = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale50 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale100 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale200 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale300 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale400 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale500 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale1000 = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdPicture = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picCropped)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdPicture
            // 
            this.ofdPicture.FileName = "openFileDialog1";
            this.ofdPicture.Filter = "Bitmaps|*.bmp|PNG files|*.png|JPEG files|*.jpg|Picture Files|*.bmp;*.jpg;*.gif;*." +
                "png;*.tif";
            // 
            // picCropped
            // 
            this.picCropped.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCropped.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picCropped.Location = new System.Drawing.Point(12, 27);
            this.picCropped.Name = "picCropped";
            this.picCropped.Size = new System.Drawing.Size(200, 200);
            this.picCropped.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picCropped.TabIndex = 5;
            this.picCropped.TabStop = false;
            this.picCropped.Visible = false;
            this.picCropped.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCropped_MouseMove);
            this.picCropped.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCropped_MouseDown);
            this.picCropped.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picCropped_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.pictureToolStripMenuItem,
            this.scaleToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 4;
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
            this.mnuPictureReset});
            this.pictureToolStripMenuItem.Name = "pictureToolStripMenuItem";
            this.pictureToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.pictureToolStripMenuItem.Text = "&Picture";
            // 
            // mnuPictureReset
            // 
            this.mnuPictureReset.Name = "mnuPictureReset";
            this.mnuPictureReset.Size = new System.Drawing.Size(102, 22);
            this.mnuPictureReset.Text = "&Reset";
            this.mnuPictureReset.Click += new System.EventHandler(this.mnuPictureReset_Click);
            // 
            // scaleToolStripMenuItem
            // 
            this.scaleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuScale50,
            this.mnuScale100,
            this.mnuScale200,
            this.mnuScale300,
            this.mnuScale400,
            this.mnuScale500,
            this.mnuScale1000});
            this.scaleToolStripMenuItem.Name = "scaleToolStripMenuItem";
            this.scaleToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.scaleToolStripMenuItem.Text = "&Scale";
            // 
            // mnuScale50
            // 
            this.mnuScale50.Name = "mnuScale50";
            this.mnuScale50.Size = new System.Drawing.Size(152, 22);
            this.mnuScale50.Text = "50%";
            this.mnuScale50.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuScale100
            // 
            this.mnuScale100.Checked = true;
            this.mnuScale100.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuScale100.Name = "mnuScale100";
            this.mnuScale100.Size = new System.Drawing.Size(152, 22);
            this.mnuScale100.Text = "&100%";
            this.mnuScale100.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuScale200
            // 
            this.mnuScale200.Name = "mnuScale200";
            this.mnuScale200.Size = new System.Drawing.Size(152, 22);
            this.mnuScale200.Text = "&200%";
            this.mnuScale200.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuScale300
            // 
            this.mnuScale300.Name = "mnuScale300";
            this.mnuScale300.Size = new System.Drawing.Size(152, 22);
            this.mnuScale300.Text = "&300%";
            this.mnuScale300.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuScale400
            // 
            this.mnuScale400.Name = "mnuScale400";
            this.mnuScale400.Size = new System.Drawing.Size(152, 22);
            this.mnuScale400.Text = "&400%";
            this.mnuScale400.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuScale500
            // 
            this.mnuScale500.Name = "mnuScale500";
            this.mnuScale500.Size = new System.Drawing.Size(152, 22);
            this.mnuScale500.Text = "&500%";
            this.mnuScale500.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuScale1000
            // 
            this.mnuScale1000.Name = "mnuScale1000";
            this.mnuScale1000.Size = new System.Drawing.Size(152, 22);
            this.mnuScale1000.Text = "1000%";
            this.mnuScale1000.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // sfdPicture
            // 
            this.sfdPicture.Filter = "Bitmaps|*.bmp|PNG files|*.png|JPEG files|*.jpg|Picture Files|*.bmp;*.jpg;*.gif;*." +
                "png;*.tif";
            // 
            // howto_zoom_and_crop_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.picCropped);
            this.Controls.Add(this.menuStrip1);
            this.Name = "howto_zoom_and_crop_Form1";
            this.Text = "howto_zoom_and_crop";
            ((System.ComponentModel.ISupportInitialize)(this.picCropped)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdPicture;
        private System.Windows.Forms.PictureBox picCropped;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem pictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuPictureReset;
        private System.Windows.Forms.SaveFileDialog sfdPicture;
        private System.Windows.Forms.ToolStripMenuItem scaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuScale50;
        private System.Windows.Forms.ToolStripMenuItem mnuScale100;
        private System.Windows.Forms.ToolStripMenuItem mnuScale200;
        private System.Windows.Forms.ToolStripMenuItem mnuScale300;
        private System.Windows.Forms.ToolStripMenuItem mnuScale400;
        private System.Windows.Forms.ToolStripMenuItem mnuScale500;
        private System.Windows.Forms.ToolStripMenuItem mnuScale1000;
    }
}

