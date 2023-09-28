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
     public partial class howto_crop_picture_Form1:Form
  { 


        public howto_crop_picture_Form1()
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

        // The cropped image with the selection rectangle.
        private Bitmap DisplayImage;
        private Graphics DisplayGraphics;

        // Open a file.
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdPicture.ShowDialog() == DialogResult.OK)
            {
                OriginalImage = LoadBitmapUnlocked(ofdPicture.FileName);
                CroppedImage = OriginalImage.Clone() as Bitmap;
                DisplayImage = CroppedImage.Clone() as Bitmap;
                DisplayGraphics = Graphics.FromImage(DisplayImage);

                picCropped.Image = DisplayImage;
                picCropped.Visible = true;
            }
        }

        // Let the user select an area.
        private bool Drawing = false;
        private Point StartPoint, EndPoint;
        private void picCropped_MouseDown(object sender, MouseEventArgs e)
        {
            Drawing = true;
            StartPoint = e.Location;

            // Draw the area selected.
            DrawSelectionBox(e.Location);
        }

        private void picCropped_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Drawing) return;

            // Draw the area selected.
            DrawSelectionBox(e.Location);
        }

        private void picCropped_MouseUp(object sender, MouseEventArgs e)
        {
            if (!Drawing) return;
            Drawing = false;

            // Crop.
            // Get the selected area's dimensions.
            int x = Math.Min(StartPoint.X, EndPoint.X);
            int y = Math.Min(StartPoint.Y, EndPoint.Y);
            int width = Math.Abs(StartPoint.X - EndPoint.X);
            int height = Math.Abs(StartPoint.Y - EndPoint.Y);
            Rectangle source_rect = new Rectangle(x, y, width, height);
            Rectangle dest_rect = new Rectangle(0, 0, width, height);

            // Copy that part of the image to a new bitmap.
            DisplayImage = new Bitmap(width, height);
            DisplayGraphics = Graphics.FromImage(DisplayImage);
            DisplayGraphics.DrawImage(CroppedImage, dest_rect, source_rect, GraphicsUnit.Pixel);

            // Display the new bitmap.
            CroppedImage = DisplayImage;
            DisplayImage = CroppedImage.Clone() as Bitmap;
            DisplayGraphics = Graphics.FromImage(DisplayImage);
            picCropped.Image = DisplayImage;
            picCropped.Refresh();
        }

        // Draw the area selected.
        private void DrawSelectionBox(Point end_point)
        {
            // Save the end point.
            EndPoint = end_point;
            if (EndPoint.X < 0) EndPoint.X = 0;
            if (EndPoint.X >= CroppedImage.Width) EndPoint.X = CroppedImage.Width - 1;
            if (EndPoint.Y < 0) EndPoint.Y = 0;
            if (EndPoint.Y >= CroppedImage.Height) EndPoint.Y = CroppedImage.Height - 1;

            // Reset the image.
            DisplayGraphics.DrawImageUnscaled(CroppedImage, 0, 0);

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
            DisplayImage = OriginalImage.Clone() as Bitmap;
            DisplayGraphics = Graphics.FromImage(DisplayImage);
            picCropped.Image = DisplayImage;
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
            this.picCropped = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPictureReset = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdPicture = new System.Windows.Forms.OpenFileDialog();
            this.sfdPicture = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picCropped)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picCropped
            // 
            this.picCropped.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCropped.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picCropped.Location = new System.Drawing.Point(12, 33);
            this.picCropped.Name = "picCropped";
            this.picCropped.Size = new System.Drawing.Size(260, 225);
            this.picCropped.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picCropped.TabIndex = 3;
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
            this.pictureToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 2;
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
            this.mnuPictureReset.Size = new System.Drawing.Size(152, 22);
            this.mnuPictureReset.Text = "&Reset";
            this.mnuPictureReset.Click += new System.EventHandler(this.mnuPictureReset_Click);
            // 
            // ofdPicture
            // 
            this.ofdPicture.FileName = "openFileDialog1";
            this.ofdPicture.Filter = "Bitmaps|*.bmp|PNG files|*.png|JPEG files|*.jpg|Picture Files|*.bmp;*.jpg;*.gif;*." +
                "png;*.tif";
            // 
            // sfdPicture
            // 
            this.sfdPicture.Filter = "Bitmaps|*.bmp|PNG files|*.png|JPEG files|*.jpg|Picture Files|*.bmp;*.jpg;*.gif;*." +
                "png;*.tif";
            // 
            // howto_crop_picture_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.picCropped);
            this.Controls.Add(this.menuStrip1);
            this.Name = "howto_crop_picture_Form1";
            this.Text = "howto_crop_picture";
            ((System.ComponentModel.ISupportInitialize)(this.picCropped)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCropped;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem pictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuPictureReset;
        private System.Windows.Forms.OpenFileDialog ofdPicture;
        private System.Windows.Forms.SaveFileDialog sfdPicture;
    }
}

