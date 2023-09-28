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
     public partial class howto_round_image_corners_Form1:Form
  { 


        public howto_round_image_corners_Form1()
        {
            InitializeComponent();
        }

        private Bitmap OriginalImage = null;

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdOriginal.ShowDialog() == DialogResult.OK)
            {
                OriginalImage = new Bitmap(ofdOriginal.FileName);
                picImage.Image = OriginalImage;
                picImage.Visible = true;
                mnuFileSaveAs.Enabled = true;
                ShowImage();
            }
        }

        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (sfdResult.ShowDialog() == DialogResult.OK)
            {
                SaveImage(picImage.Image, sfdResult.FileName);
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

        private void scrXRadius_Scroll(object sender, ScrollEventArgs e)
        {
            lblXRadius.Text = scrXRadius.Value.ToString();
            ShowImage();
        }

        private void scrYRadius_Scroll(object sender, ScrollEventArgs e)
        {
            lblYRadius.Text = scrYRadius.Value.ToString();
            ShowImage();
        }

        // Make and display the image with rounded corners.
        private void ShowImage()
        {
            // If the corners are not rounded,
            // just use the original image.
            if ((scrXRadius.Value == 0) || (scrYRadius.Value == 0))
            {
                picImage.Image = OriginalImage;
                return;
            }

            // Make a bitmap of the proper size.
            int width = OriginalImage.Width;
            int height = OriginalImage.Height;
            Bitmap bm = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                // Clear with a transparent background.
                gr.Clear(Color.Transparent);
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.InterpolationMode = InterpolationMode.High;

                // Make the rounded rectangle path.
                GraphicsPath path = MakeRoundedRect(
                    new Rectangle(0, 0, width, height),
                    scrXRadius.Value, scrYRadius.Value,
                    true, true, true, true);

                // Fill with the original image.
                using (TextureBrush brush = new TextureBrush(OriginalImage))
                {
                    gr.FillPath(brush, path);
                }
            }
            picImage.Image = bm;
        }

        // Draw a rectangle in the indicated Rectangle
        // rounding the indicated corners.
        private GraphicsPath MakeRoundedRect(
            RectangleF rect, float xradius, float yradius,
            bool round_ul, bool round_ur, bool round_lr, bool round_ll)
        {
            // Make a GraphicsPath to draw the rectangle.
            PointF point1, point2;
            GraphicsPath path = new GraphicsPath();

            // Upper left corner.
            if (round_ul)
            {
                RectangleF corner = new RectangleF(
                    rect.X, rect.Y,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 180, 90);
                point1 = new PointF(rect.X + xradius, rect.Y);
            }
            else point1 = new PointF(rect.X, rect.Y);

            // Top side.
            if (round_ur)
                point2 = new PointF(rect.Right - xradius, rect.Y);
            else
                point2 = new PointF(rect.Right, rect.Y);
            path.AddLine(point1, point2);

            // Upper right corner.
            if (round_ur)
            {
                RectangleF corner = new RectangleF(
                    rect.Right - 2 * xradius, rect.Y,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 270, 90);
                point1 = new PointF(rect.Right, rect.Y + yradius);
            }
            else point1 = new PointF(rect.Right, rect.Y);

            // Right side.
            if (round_lr)
                point2 = new PointF(rect.Right, rect.Bottom - yradius);
            else
                point2 = new PointF(rect.Right, rect.Bottom);
            path.AddLine(point1, point2);

            // Lower right corner.
            if (round_lr)
            {
                RectangleF corner = new RectangleF(
                    rect.Right - 2 * xradius,
                    rect.Bottom - 2 * yradius,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 0, 90);
                point1 = new PointF(rect.Right - xradius, rect.Bottom);
            }
            else point1 = new PointF(rect.Right, rect.Bottom);

            // Bottom side.
            if (round_ll)
                point2 = new PointF(rect.X + xradius, rect.Bottom);
            else
                point2 = new PointF(rect.X, rect.Bottom);
            path.AddLine(point1, point2);

            // Lower left corner.
            if (round_ll)
            {
                RectangleF corner = new RectangleF(
                    rect.X, rect.Bottom - 2 * yradius,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 90, 90);
                point1 = new PointF(rect.X, rect.Bottom - yradius);
            }
            else point1 = new PointF(rect.X, rect.Bottom);

            // Left side.
            if (round_ul)
                point2 = new PointF(rect.X, rect.Y + yradius);
            else
                point2 = new PointF(rect.X, rect.Y);
            path.AddLine(point1, point2);

            // Join with the start point.
            path.CloseFigure();

            return path;
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
            this.ofdOriginal = new System.Windows.Forms.OpenFileDialog();
            this.sfdResult = new System.Windows.Forms.SaveFileDialog();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.scrXRadius = new System.Windows.Forms.HScrollBar();
            this.lblXRadius = new System.Windows.Forms.Label();
            this.lblYRadius = new System.Windows.Forms.Label();
            this.scrYRadius = new System.Windows.Forms.HScrollBar();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
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
            this.mnuFileSaveAs});
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
            // mnuFileSaveAs
            // 
            this.mnuFileSaveAs.Enabled = false;
            this.mnuFileSaveAs.Name = "mnuFileSaveAs";
            this.mnuFileSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSaveAs.Size = new System.Drawing.Size(155, 22);
            this.mnuFileSaveAs.Text = "&Save...";
            this.mnuFileSaveAs.Click += new System.EventHandler(this.mnuFileSaveAs_Click);
            // 
            // ofdOriginal
            // 
            this.ofdOriginal.Filter = "Picture Files|*.bmp;*.jpg;*.gif;*.png;*.tif";
            // 
            // sfdResult
            // 
            this.sfdResult.DefaultExt = "png";
            this.sfdResult.Filter = "Picture Files|*.bmp;*.jpg;*.gif;*.png;*.tif";
            // 
            // picImage
            // 
            this.picImage.BackColor = System.Drawing.Color.Transparent;
            this.picImage.Location = new System.Drawing.Point(12, 70);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(68, 59);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImage.TabIndex = 1;
            this.picImage.TabStop = false;
            this.picImage.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "X Radius:";
            // 
            // scrXRadius
            // 
            this.scrXRadius.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scrXRadius.Location = new System.Drawing.Point(68, 26);
            this.scrXRadius.Maximum = 109;
            this.scrXRadius.Name = "scrXRadius";
            this.scrXRadius.Size = new System.Drawing.Size(166, 17);
            this.scrXRadius.TabIndex = 3;
            this.scrXRadius.Value = 20;
            this.scrXRadius.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrXRadius_Scroll);
            // 
            // lblXRadius
            // 
            this.lblXRadius.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblXRadius.Location = new System.Drawing.Point(237, 28);
            this.lblXRadius.Name = "lblXRadius";
            this.lblXRadius.Size = new System.Drawing.Size(35, 13);
            this.lblXRadius.TabIndex = 5;
            this.lblXRadius.Text = "20";
            this.lblXRadius.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblYRadius
            // 
            this.lblYRadius.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblYRadius.Location = new System.Drawing.Point(237, 52);
            this.lblYRadius.Name = "lblYRadius";
            this.lblYRadius.Size = new System.Drawing.Size(35, 13);
            this.lblYRadius.TabIndex = 8;
            this.lblYRadius.Text = "20";
            this.lblYRadius.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // scrYRadius
            // 
            this.scrYRadius.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scrYRadius.Location = new System.Drawing.Point(68, 50);
            this.scrYRadius.Maximum = 109;
            this.scrYRadius.Name = "scrYRadius";
            this.scrYRadius.Size = new System.Drawing.Size(166, 17);
            this.scrYRadius.TabIndex = 7;
            this.scrYRadius.Value = 20;
            this.scrYRadius.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrYRadius_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Y Radius:";
            // 
            // howto_round_image_corners_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblYRadius);
            this.Controls.Add(this.scrYRadius);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblXRadius);
            this.Controls.Add(this.scrXRadius);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_round_image_corners_Form1";
            this.Text = "howto_round_image_corners";
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
        private System.Windows.Forms.OpenFileDialog ofdOriginal;
        private System.Windows.Forms.SaveFileDialog sfdResult;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.HScrollBar scrXRadius;
        private System.Windows.Forms.Label lblXRadius;
        private System.Windows.Forms.Label lblYRadius;
        private System.Windows.Forms.HScrollBar scrYRadius;
        private System.Windows.Forms.Label label3;
    }
}

