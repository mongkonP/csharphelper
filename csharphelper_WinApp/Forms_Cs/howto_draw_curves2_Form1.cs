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
     public partial class howto_draw_curves2_Form1:Form
  { 


        public howto_draw_curves2_Form1()
        {
            InitializeComponent();
        }

        // True when we are drawing.
        private bool Drawing = true;

        // The currently selected points.
        private List<Point> Points = new List<Point>();

        // The curve's tension.
        private float Tension = 0.5f;

        // The user clicked. Add a point,
        // stop drawing, or start a new curve.
        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            // See if we are currently drawing.
            if (Drawing)
            {
                // See if this is the left or right mouse button.
                if (e.Button == MouseButtons.Left)
                {
                    // Left button. Add a new point.
                    Points.Add(e.Location);
                }
                else
                {
                    // Right button. Stop drawing.
                    Drawing = false;
                }
            }
            else
            {
                // We are not drawing. Start a new curve.
                Drawing = true;
                Points = new List<Point>();

                // Add a new point.
                Points.Add(e.Location);
            }

            // Redraw.
            picCanvas.Refresh();
        }

        // Draw the curve and its points.
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            DrawTheCurve(e.Graphics, true);
        }

        // Draw the curve.
        private void DrawTheCurve(Graphics gr, bool draw_points)
        {
            gr.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the curve.
            if (Points.Count > 1)
            {
                // Make a pen to use.
                using (Pen pen = new Pen(Color.Blue))
                {
                    // See if we're currently drawing.
                    if (Drawing)
                    {
                        // Use a dashed pen.
                        pen.DashPattern = new float[] { 5, 5 };
                    }

                    // Draw the curve.
                    gr.DrawCurve(pen, Points.ToArray(), Tension);
                }
            }

            // Draw the points.
            if (draw_points && Drawing && (Points.Count > 0))
            {
                const int r = 4;
                foreach (Point point in Points)
                {
                    Rectangle rect = new Rectangle(
                        point.X - r, point.Y - r, 2 * r, 2 * r);
                    gr.FillRectangle(Brushes.White, rect);
                    gr.DrawRectangle(Pens.Black, rect);
                }
            }
        }

        // Adjust the curve's tension.
        private void scrTension_Scroll(object sender, ScrollEventArgs e)
        {
            Tension = scrTension.Value / 10f;
            lblTension.Text = Tension.ToString();
            picCanvas.Refresh();
        }

        // Save an image of the PictureBox.
        private void mnuFileSaveImage_Click(object sender, EventArgs e)
        {
            if (sfdPicture.ShowDialog() == DialogResult.OK)
            {
                // Get an image of the PictureBox.
                using (Bitmap bm = GetControlImage(picCanvas))
                {
                    // Save the image.
                    SaveImage(bm, sfdPicture.FileName);
                }
            }
        }

        // Draw the curve onto a bitmap and save it.
        private void mnuFileSaveDrawing_Click(object sender, EventArgs e)
        {
            if (sfdPicture.ShowDialog() == DialogResult.OK)
            {
                // Make a Bitmap.
                int wid = picCanvas.ClientSize.Width;
                int hgt = picCanvas.ClientSize.Height;
                using (Bitmap bm = new Bitmap(wid, hgt))
                {
                    // Draw the curve on the bitmap.
                    using (Graphics gr = Graphics.FromImage(bm))
                    {
                        DrawTheCurve(gr, false);
                    }

                    // Save the image.
                    SaveImage(bm, sfdPicture.FileName);
                }
            }
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Return a Bitmap holding an image of the control.
        // See: http://csharphelper.com/blog/2014/09/get-the-image-of-a-control-or-form-or-a-forms-client-area-in-c/
        private Bitmap GetControlImage(Control ctl)
        {
            Bitmap bm = new Bitmap(ctl.Width, ctl.Height);
            ctl.DrawToBitmap(bm,
                new Rectangle(0, 0, ctl.Width, ctl.Height));
            return bm;
        }

        // Save the file with the appropriate format.
        // See http://csharphelper.com/blog/2014/07/save-images-with-an-appropriate-format-depending-on-the-file-names-extension-in-c/
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
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.scrTension = new System.Windows.Forms.HScrollBar();
            this.lblTension = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveImage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveDrawing = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdPicture = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(12, 47);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(260, 202);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseClick);
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // scrTension
            // 
            this.scrTension.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scrTension.Location = new System.Drawing.Point(12, 24);
            this.scrTension.Maximum = 59;
            this.scrTension.Name = "scrTension";
            this.scrTension.Size = new System.Drawing.Size(228, 20);
            this.scrTension.TabIndex = 3;
            this.scrTension.Value = 5;
            this.scrTension.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrTension_Scroll);
            // 
            // lblTension
            // 
            this.lblTension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTension.Location = new System.Drawing.Point(243, 24);
            this.lblTension.Name = "lblTension";
            this.lblTension.Size = new System.Drawing.Size(29, 20);
            this.lblTension.TabIndex = 4;
            this.lblTension.Text = "0.5";
            this.lblTension.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fIleToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fIleToolStripMenuItem
            // 
            this.fIleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileSaveImage,
            this.mnuFileSaveDrawing,
            this.toolStripMenuItem1,
            this.mnuFileExit});
            this.fIleToolStripMenuItem.Name = "fIleToolStripMenuItem";
            this.fIleToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fIleToolStripMenuItem.Text = "&FIle";
            // 
            // mnuFileSaveImage
            // 
            this.mnuFileSaveImage.Name = "mnuFileSaveImage";
            this.mnuFileSaveImage.Size = new System.Drawing.Size(154, 22);
            this.mnuFileSaveImage.Text = "&Save Image...";
            this.mnuFileSaveImage.Click += new System.EventHandler(this.mnuFileSaveImage_Click);
            // 
            // mnuFileSaveDrawing
            // 
            this.mnuFileSaveDrawing.Name = "mnuFileSaveDrawing";
            this.mnuFileSaveDrawing.Size = new System.Drawing.Size(154, 22);
            this.mnuFileSaveDrawing.Text = "Save &Drawing...";
            this.mnuFileSaveDrawing.Click += new System.EventHandler(this.mnuFileSaveDrawing_Click);
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
            // sfdPicture
            // 
            this.sfdPicture.DefaultExt = "png";
            this.sfdPicture.Filter = "PNG files|*.png|Bitmaps|*.bmp|JPEG files|*.jpg|Picture files|*.bmp;*.jpg;*.png";
            // 
            // howto_draw_curves2_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblTension);
            this.Controls.Add(this.scrTension);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_draw_curves2_Form1";
            this.Text = "howto_draw_curves2";
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.HScrollBar scrTension;
        private System.Windows.Forms.Label lblTension;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fIleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveImage;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveDrawing;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.SaveFileDialog sfdPicture;
    }
}

