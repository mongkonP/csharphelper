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
     public partial class howto_copy_irregular_area_to_clipboard_Form1:Form
  { 


        public howto_copy_irregular_area_to_clipboard_Form1()
        {
            InitializeComponent();
        }

        // For selecting an area.
        private List<Point> Points = null;
        private bool Selecting = false;

        // Start selecting an area.
        private void picSource_MouseDown(object sender, MouseEventArgs e)
        {
            Points = new List<Point>();
            Selecting = true;
        }

        // Continue selecting the area.
        private void picSource_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Selecting) return;
            Points.Add(new Point(e.X, e.Y));
            picSource.Invalidate();
        }

        // Stop selecting the area.
        private void picSource_MouseUp(object sender, MouseEventArgs e)
        {
            Selecting = false;

            // Create a DataObject to hold data
            // in different formats.
            IDataObject data_object = new DataObject();

            // Add a BMP with a white background to the DataObject.
            Bitmap bm_white = GetSelectedArea(
                picSource.Image, Color.White, Points);
            data_object.SetData(DataFormats.Bitmap, bm_white);

            // Add a PNG with a transparent background to the DataObject.
            Bitmap bm_transparent = GetSelectedArea(
                picSource.Image, Color.Transparent, Points);
            MemoryStream ms = new MemoryStream();
            bm_transparent.Save(ms, ImageFormat.Png);
            data_object.SetData("PNG", false, ms);

            // Place the data on the clipboard.
            Clipboard.Clear();
            Clipboard.SetDataObject(data_object, true);

            // Let the user know we did something.
            System.Media.SystemSounds.Beep.Play();
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

        // Return the bounds of the list of points.
        private Rectangle GetPointListBounds(List<Point> points)
        {
            int xmin = points[0].X;
            int xmax = xmin;
            int ymin = points[0].Y;
            int ymax = ymin;

            for (int i = 1; i < points.Count; i++)
            {
                if (xmin > points[i].X) xmin = points[i].X;
                if (xmax < points[i].X) xmax = points[i].X;
                if (ymin > points[i].Y) ymin = points[i].Y;
                if (ymax < points[i].Y) ymax = points[i].Y;
            }

            return new Rectangle(xmin, ymin, xmax - xmin, ymax - ymin);
        }

        // Copy the selected piece of the image into a new bitmap.
        private Bitmap GetSelectedArea(Image source, Color bg_color, List<Point> points)
        {
            // Make a new bitmap that has the background
            // color except in the selected area.
            Bitmap big_bm = new Bitmap(source);
            using (Graphics gr = Graphics.FromImage(big_bm))
            {
                // Set the background color.
                gr.Clear(bg_color);

                // Make a brush out of the original image.
                using (Brush br = new TextureBrush(source))
                {
                    // Fill the selected area with the brush.
                    gr.FillPolygon(br, points.ToArray());

                    // Find the bounds of the selected area.
                    Rectangle source_rect = GetPointListBounds(points);

                    // Make a bitmap that only holds the selected area.
                    Bitmap result = new Bitmap(source_rect.Width, source_rect.Height);

                    // Copy the selected area to the result bitmap.
                    using (Graphics result_gr = Graphics.FromImage(result))
                    {
                        Rectangle dest_rect = new Rectangle(0, 0,
                            source_rect.Width, source_rect.Height);
                        result_gr.DrawImage(big_bm, dest_rect, source_rect,
                            GraphicsUnit.Pixel);
                    }

                    // Return the result.
                    return result;
                }
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
            ((System.ComponentModel.ISupportInitialize)(this.picSource)).BeginInit();
            this.SuspendLayout();
            // 
            // picSource
            // 
            this.picSource.Image = Properties.Resources.JackOLantern;
            this.picSource.Location = new System.Drawing.Point(12, 12);
            this.picSource.Name = "picSource";
            this.picSource.Size = new System.Drawing.Size(300, 400);
            this.picSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSource.TabIndex = 9;
            this.picSource.TabStop = false;
            this.picSource.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picSource_MouseMove);
            this.picSource.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picSource_MouseDown);
            this.picSource.Paint += new System.Windows.Forms.PaintEventHandler(this.picSource_Paint);
            this.picSource.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picSource_MouseUp);
            // 
            // howto_copy_irregular_area_to_clipboard_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 424);
            this.Controls.Add(this.picSource);
            this.Name = "howto_copy_irregular_area_to_clipboard_Form1";
            this.Text = "howto_copy_irregular_area_to_clipboard";
            ((System.ComponentModel.ISupportInitialize)(this.picSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picSource;
    }
}

