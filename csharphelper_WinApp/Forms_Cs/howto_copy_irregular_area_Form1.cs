using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_copy_irregular_area_Form1:Form
  { 


        public howto_copy_irregular_area_Form1()
        {
            InitializeComponent();
        }

        // A bitmap holding the selected area.
        private Bitmap SelectedArea = null;

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

            // Copy the selected area.
            SelectedArea = GetSelectedArea(picSource.Image, Color.Transparent, Points);
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

        // Copy the selected area centered at the point clicked.
        private void picDestination_MouseClick(object sender, MouseEventArgs e)
        {
            // Do nothing if we haven't selected an area.
            if (SelectedArea == null) return;

            // See where to put it.
            int x = e.X - SelectedArea.Width / 2;
            int y = e.Y - SelectedArea.Height / 2;

            using (Graphics gr = Graphics.FromImage(picDestination.Image))
            {
                Rectangle source_rect = new Rectangle(0, 0,
                    SelectedArea.Width, SelectedArea.Height);
                Rectangle dest_rect = new Rectangle(x, y,
                    SelectedArea.Width, SelectedArea.Height);
                gr .DrawImage(SelectedArea, dest_rect, source_rect,
                    GraphicsUnit.Pixel);
            }

            picDestination.Refresh();
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
            this.picDestination = new System.Windows.Forms.PictureBox();
            this.picSource = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDestination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSource)).BeginInit();
            this.SuspendLayout();
            // 
            // picDestination
            // 
            this.picDestination.Image = Properties.Resources.Deer;
            this.picDestination.Location = new System.Drawing.Point(318, 12);
            this.picDestination.Name = "picDestination";
            this.picDestination.Size = new System.Drawing.Size(339, 476);
            this.picDestination.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picDestination.TabIndex = 4;
            this.picDestination.TabStop = false;
            this.picDestination.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picDestination_MouseClick);
            // 
            // picSource
            // 
            this.picSource.Image = Properties.Resources.JackOLantern;
            this.picSource.Location = new System.Drawing.Point(12, 12);
            this.picSource.Name = "picSource";
            this.picSource.Size = new System.Drawing.Size(300, 400);
            this.picSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSource.TabIndex = 3;
            this.picSource.TabStop = false;
            this.picSource.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picSource_MouseMove);
            this.picSource.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picSource_MouseDown);
            this.picSource.Paint += new System.Windows.Forms.PaintEventHandler(this.picSource_Paint);
            this.picSource.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picSource_MouseUp);
            // 
            // howto_copy_irregular_area_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 499);
            this.Controls.Add(this.picDestination);
            this.Controls.Add(this.picSource);
            this.Name = "howto_copy_irregular_area_Form1";
            this.Text = "howto_copy_irregular_area";
            ((System.ComponentModel.ISupportInitialize)(this.picDestination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDestination;
        private System.Windows.Forms.PictureBox picSource;
    }
}

