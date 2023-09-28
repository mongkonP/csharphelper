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

 

using howto_obscure_image_parts;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_obscure_image_parts_Form1:Form
  { 


        public howto_obscure_image_parts_Form1()
        {
            InitializeComponent();
        }

        // The original image.
        private Bitmap OriginalImage = null;

        // The image all fuzzy.
        private Bitmap ObscuredImage = null;

        // The current modified image.
        private Bitmap VisibleImage = null;

        // The style we should use.
        private string FuzzStyle = "Pixelated";

        // The filter.
        private Bitmap32.Filter Filter;

        // The kernel size.
        private int KernelSize = 3;

        // Open an image file.
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Load the image without locking its file.
                    OriginalImage = LoadBitmapUnlocked(ofdFile.FileName);
                }
                catch (Exception ex)
                {
                    OriginalImage = null;
                    picImage.Visible = false;
                    MessageBox.Show("Error opening file " +
                        ofdFile.FileName + "\n" + ex.Message);
                    return;
                }

                // Make the fuzzy version of the image.
                MakeFuzzyImage();

                // Display the current image.
                VisibleImage = new Bitmap(OriginalImage);
                picImage.Image = VisibleImage;
                picImage.Visible = true;
                picImage.Refresh();
            }
        }

        // Save the current image.
        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (sfdFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SaveImage(VisibleImage, sfdFile.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving file " +
                        sfdFile.FileName + "\n" + ex.Message);
                }
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

        // The rectangle being selected.
        private Point Point1, Point2;
        private bool Selecting = false;

        // Start selecting.
        private void picImage_MouseDown(object sender, MouseEventArgs e)
        {
            Selecting = true;
            Point1 = e.Location;
            Point2 = e.Location;
        }

        // Continue selecting.
        private void picImage_MouseMove(object sender, MouseEventArgs e)
        {
            Point2 = e.Location;
            picImage.Refresh();
        }

        // Finish selecting.
        private void picImage_MouseUp(object sender, MouseEventArgs e)
        {
            Selecting = false;
            FuzzImagePart();
        }

        // Draw the selection rectangle.
        private void picImage_Paint(object sender, PaintEventArgs e)
        {
            if (!Selecting) return;
            Rectangle rect = new Rectangle(
                (int)Math.Min(Point1.X, Point2.X),
                (int)Math.Min(Point1.Y, Point2.Y),
                (int)Math.Abs(Point1.X - Point2.X),
                (int)Math.Abs(Point1.Y - Point2.Y));
            e.Graphics.DrawRectangle(Pens.Yellow, rect);
            using (Pen pen = new Pen(Color.Red))
            {
                pen.DashStyle = DashStyle.Custom;
                pen.DashPattern = new float[] { 5, 5 };
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        // Make part of the image fuzzy.
        private void FuzzImagePart()
        {
            // Copy the selected part of the image from the fuzzy image.
            using (Graphics gr = Graphics.FromImage(VisibleImage))
            {
                Rectangle rect = new Rectangle(
                    (int)Math.Min(Point1.X, Point2.X),
                    (int)Math.Min(Point1.Y, Point2.Y),
                    (int)Math.Abs(Point1.X - Point2.X),
                    (int)Math.Abs(Point1.Y - Point2.Y));
                if (FuzzStyle == "Redacted")
                    gr.FillRectangle(Brushes.Black, rect);
                else
                    gr.DrawImage(ObscuredImage, rect, rect, GraphicsUnit.Pixel);
                picImage.Refresh();
            }
        }

        // Revert to the original image.
        private void mnuToolsRevert_Click(object sender, EventArgs e)
        {
            VisibleImage = new Bitmap(OriginalImage);
            picImage.Image = VisibleImage;
        }

        private void mnuToolsParameters_Click(object sender, EventArgs e)
        {
            howto_obscure_image_parts_ParametersForm dlg = new  howto_obscure_image_parts_ParametersForm();
            dlg.KernelSize = KernelSize;
            dlg.lblKernelSize.Text = KernelSize.ToString();
            dlg.cboStyle.Text = FuzzStyle;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                KernelSize = dlg.KernelSize;
                FuzzStyle = dlg.cboStyle.Text;

                // Make the fuzzy version of the image.
                MakeFuzzyImage();
            }
        }

        // Make the fuzzy version of the image.
        private void MakeFuzzyImage()
        {
            Cursor = Cursors.WaitCursor;
            Refresh();

            if (FuzzStyle == "Fuzzy")
            {
                FuzzImage();
            }
            else if (FuzzStyle == "Pixelated")
            {
                PixelateImage();
            }
            else if (FuzzStyle == "Redacted")
            {
            }
            else
            {
                MessageBox.Show("Unknown style " + FuzzStyle);
            }

            Cursor = Cursors.Default;
        }

        // Make a pixelated copy of the image.
        private void PixelateImage()
        {
            if (OriginalImage == null) return;

            try
            {
                // Make a Bitmap32 object.
                ObscuredImage = new Bitmap(OriginalImage);
                Bitmap32 bm32 = new Bitmap32(ObscuredImage);

                // Pixellate.
                bm32.Pixellate(KernelSize, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error pixelating image\n" + ex.Message);
            }
        }

        // Make a fuzzy copy of the image.
        private void FuzzImage()
        {
            if (OriginalImage == null) return;

            // Make a low pass filter.
            try
            {
                Filter = new Bitmap32.Filter();
                Filter.Offset = 0;
                Filter.Kernel = new float[KernelSize, KernelSize];
                for (int i = 0; i < KernelSize; i++)
                    for (int j = 0; j < KernelSize; j++)
                        Filter.Kernel[i, j] = 1;
                Filter.Normalize();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error making filter\n" + ex.Message);
            }

            // Apply the filter.
            try
            {
                Bitmap bm = new Bitmap(OriginalImage);

                // Make a Bitmap24 object.
                Bitmap32 bm32 = new Bitmap32(bm);

                // Apply the filter.
                Bitmap32 new_bm32 = bm32.ApplyFilter(Filter, false);

                // Save the result.
                ObscuredImage = new_bm32.Bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error applying filter\n" + ex.Message);
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
            this.sfdFile = new System.Windows.Forms.SaveFileDialog();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsRevert = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsParameters = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sfdFile
            // 
            this.sfdFile.DefaultExt = "png";
            this.sfdFile.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            this.sfdFile.Title = "Image File";
            // 
            // picImage
            // 
            this.picImage.BackColor = System.Drawing.Color.White;
            this.picImage.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picImage.Location = new System.Drawing.Point(12, 27);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(100, 100);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImage.TabIndex = 3;
            this.picImage.TabStop = false;
            this.picImage.Visible = false;
            this.picImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseMove);
            this.picImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseDown);
            this.picImage.Paint += new System.Windows.Forms.PaintEventHandler(this.picImage_Paint);
            this.picImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picImage_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
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
            this.mnuFileOpen.ToolTipText = "Open an image file";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSaveAs
            // 
            this.mnuFileSaveAs.Name = "mnuFileSaveAs";
            this.mnuFileSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSaveAs.Size = new System.Drawing.Size(163, 22);
            this.mnuFileSaveAs.Text = "&Save As...";
            this.mnuFileSaveAs.ToolTipText = "Save the result file";
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
            this.mnuFileExit.ToolTipText = "Exit the application";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuToolsRevert,
            this.mnuToolsParameters});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // mnuToolsRevert
            // 
            this.mnuToolsRevert.Name = "mnuToolsRevert";
            this.mnuToolsRevert.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mnuToolsRevert.Size = new System.Drawing.Size(183, 22);
            this.mnuToolsRevert.Text = "&Revert";
            this.mnuToolsRevert.ToolTipText = "Revert to the original image";
            this.mnuToolsRevert.Click += new System.EventHandler(this.mnuToolsRevert_Click);
            // 
            // mnuToolsParameters
            // 
            this.mnuToolsParameters.Name = "mnuToolsParameters";
            this.mnuToolsParameters.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.mnuToolsParameters.Size = new System.Drawing.Size(183, 22);
            this.mnuToolsParameters.Text = "&Parameters...";
            this.mnuToolsParameters.ToolTipText = "Set the fuzziness parameters";
            this.mnuToolsParameters.Click += new System.EventHandler(this.mnuToolsParameters_Click);
            // 
            // ofdFile
            // 
            this.ofdFile.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            this.ofdFile.Title = "Image File";
            // 
            // howto_obscure_image_parts_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.menuStrip1);
            this.Name = "howto_obscure_image_parts_Form1";
            this.Text = "howto_obscure_image_parts";
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog sfdFile;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsRevert;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsParameters;
        private System.Windows.Forms.OpenFileDialog ofdFile;
    }
}

