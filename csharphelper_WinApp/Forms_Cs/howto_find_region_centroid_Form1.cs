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
     public partial class howto_find_region_centroid_Form1:Form
  { 


        public howto_find_region_centroid_Form1()
        {
            InitializeComponent();
        }

        // The circles.
        List<PointF> Centers = new List<PointF>();
        List<float> Radii = new List<float>();

        // The index of a new circle we are drawing.
        int NewCircle = -1;

        // Remove all circles.
        private void btnClear_Click(object sender, EventArgs e)
        {
            Centers = new List<PointF>();
            Radii = new List<float>();
            this.Invalidate();
        }

        // Draw the circles.
        private void howto_find_region_centroid_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Find the intersection of all circles.
            Region intersection = FindCircleIntersections(Centers, Radii);

            // Draw the region.
            if (intersection != null)
            {
                e.Graphics.FillRegion(Brushes.LightGreen, intersection);

                // Get the region's centroid.
                PointF centroid = RegionCentroid(intersection, e.Graphics.Transform);
                e.Graphics.FillEllipse(Brushes.Red,
                    centroid.X - 3, centroid.Y - 3, 7, 7);
            }

            // Draw the circles.
            for (int i = 0; i < Centers.Count; i++)
            {
                e.Graphics.DrawEllipse(Pens.Blue,
                    Centers[i].X - Radii[i], Centers[i].Y - Radii[i],
                    2 * Radii[i], 2 * Radii[i]);
            }
        }

        // Start drawing a new circle.
        private void howto_find_region_centroid_Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Centers.Add(e.Location);
            Radii.Add(0);
            NewCircle = Centers.Count - 1;
        }

        // Update the new circle.
        private void howto_find_region_centroid_Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (NewCircle < 0) return;
            float dx = e.X - Centers[NewCircle].X;
            float dy = e.Y - Centers[NewCircle].Y;
            Radii[NewCircle] = (float)Math.Sqrt(dx * dx + dy * dy);
            this.Invalidate();
        }

        // Finish drawing a new circle.
        private void howto_find_region_centroid_Form1_MouseUp(object sender, MouseEventArgs e)
        {
            // If the radius is 0, remove the new circle.
            if (Radii[NewCircle] < 1)
            {
                Centers.RemoveAt(NewCircle);
                Radii.RemoveAt(NewCircle);
            }

            NewCircle = -1;
            this.Invalidate();
        }

        // Find the intersection of all of the circles.
        private Region FindCircleIntersections(List<PointF> centers, List<float> radii)
        {
            if (centers.Count < 1) return null;

            // Make a region.
            Region result_region = new Region();

            // Intersect the region with the circles.
            for (int i = 0; i < centers.Count; i++)
            {
                using (GraphicsPath circle_path = new GraphicsPath())
                {
                    circle_path.AddEllipse(
                        centers[i].X - radii[i], centers[i].Y - radii[i],
                        2 * radii[i], 2 * radii[i]);
                    result_region.Intersect(circle_path);
                }
            }

            return result_region;
        }

        // Return the centroid of the region.
        private PointF RegionCentroid(Region region, Matrix transform)
        {
            float mx = 0;
            float my = 0;
            float total_weight = 0;
            foreach (RectangleF rect in region.GetRegionScans(transform))
            {
                float rect_weight = rect.Width * rect.Height;
                mx += rect_weight * (rect.Left + rect.Width / 2f);
                my += rect_weight * (rect.Top + rect.Height / 2f);
                total_weight += rect_weight;
            }

            return new PointF(mx / total_weight, my / total_weight);
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
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // howto_find_region_centroid_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.btnClear);
            this.Name = "howto_find_region_centroid_Form1";
            this.Text = "howto_find_region_centroid";
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.howto_find_region_centroid_Form1_MouseUp);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_find_region_centroid_Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.howto_find_region_centroid_Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.howto_find_region_centroid_Form1_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
    }
}

