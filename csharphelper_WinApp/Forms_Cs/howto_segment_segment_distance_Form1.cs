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
     public partial class howto_segment_segment_distance_Form1:Form
  { 


        public howto_segment_segment_distance_Form1()
        {
            InitializeComponent();
        }

        // The points.
        List<PointF> Points = new List<PointF>();

        // The closest points.
        PointF Close1, Close2;
        bool HaveSolution = false;

        // Save a new point.
        private void howto_segment_segment_distance_Form1_MouseClick(object sender, MouseEventArgs e)
        {
            // If we have 4 points now, start over.
            if (Points.Count == 4)
            {
                Points = new List<PointF>();
                HaveSolution = false;
            }

            // Save the new point.
            Points.Add(new PointF(e.X, e.Y));

            // If we have 4 points now, find the closest point.
            if (Points.Count == 4)
            {
                FindDistanceBetweenSegments(
                    Points[0], Points[1], Points[2], Points[3],
                    out Close1, out Close2);
                HaveSolution = true;
            }

            // Redraw.
            this.Invalidate();
        }

        // Draw existing points and segments if any.
        private void howto_segment_segment_distance_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the segments.
            if (Points.Count == 4)
            {
                e.Graphics.DrawLine(Pens.Green, Points[2], Points[3]);
            }
            if (Points.Count >= 2)
            {
                e.Graphics.DrawLine(Pens.Blue, Points[0], Points[1]);
            }

            // Draw the closest segment.
            if (HaveSolution)
            {
                using (Pen dash_pen = new Pen(Color.Red))
                {
                    dash_pen.DashStyle = DashStyle.Custom;
                    dash_pen.DashPattern = new float[] { 4, 4 };
                    e.Graphics.DrawLine(dash_pen, Close1, Close2);
                }
            }

            // Draw the points.
            foreach (PointF pt in Points)
            {
                DrawPoint(e.Graphics, pt, Brushes.White, Pens.Black);
            }

            // Draw the closest points.
            if (HaveSolution)
            {
                DrawPoint(e.Graphics, Close1, Brushes.LightBlue, Pens.Blue);
                DrawPoint(e.Graphics, Close2, Brushes.LightBlue, Pens.Blue);
            }
        }

        // Draw a point.
        private void DrawPoint(Graphics gr, PointF pt, Brush brush, Pen pen)
        {
            const int RADIUS = 3;
            gr.FillEllipse(brush,
                pt.X - RADIUS, pt.Y - RADIUS,
                2 * RADIUS, 2 * RADIUS);
            gr.DrawEllipse(pen,
                pt.X - RADIUS, pt.Y - RADIUS,
                2 * RADIUS, 2 * RADIUS);
        }

        // Return the shortest distance between the two segments
        // p1 --> p2 and p3 --> p4.
        private double FindDistanceBetweenSegments(PointF p1, PointF p2, PointF p3, PointF p4,
            out PointF close1, out PointF close2)
        {
            // See if the segments intersect.
            bool lines_intersect, segments_intersect;
            PointF intersection;
            FindIntersection(p1, p2, p3, p4,
                out lines_intersect, out segments_intersect,
                out intersection, out close1, out close2);
            if (segments_intersect)
            {
                // They intersect.
                close1 = intersection;
                close2 = intersection;
                return 0;
            }

            // Find the other possible distances.
            PointF closest;
            double best_dist = double.MaxValue, test_dist;

            // Try p1.
            test_dist = FindDistanceToSegment(p1, p3, p4, out closest);
            if (test_dist < best_dist)
            {
                best_dist = test_dist;
                close1 = p1;
                close2 = closest;
            }

            // Try p2.
            test_dist = FindDistanceToSegment(p2, p3, p4, out closest);
            if (test_dist < best_dist)
            {
                best_dist = test_dist;
                close1 = p2;
                close2 = closest;
            }

            // Try p3.
            test_dist = FindDistanceToSegment(p3, p1, p2, out closest);
            if (test_dist < best_dist)
            {
                best_dist = test_dist;
                close1 = closest;
                close2 = p3;
            }

            // Try p4.
            test_dist = FindDistanceToSegment(p4, p1, p2, out closest);
            if (test_dist < best_dist)
            {
                best_dist = test_dist;
                close1 = closest;
                close2 = p4;
            }

            return best_dist;
        }

        // Find the point of intersection between
        // the lines p1 --> p2 and p3 --> p4.
        private void FindIntersection(PointF p1, PointF p2, PointF p3, PointF p4,
            out bool lines_intersect, out bool segments_intersect,
            out PointF intersection, out PointF close_p1, out PointF close_p2)
        {
            // Get the segments' parameters.
            float dx12 = p2.X - p1.X;
            float dy12 = p2.Y - p1.Y;
            float dx34 = p4.X - p3.X;
            float dy34 = p4.Y - p3.Y;

            // Solve for t1 and t2
            float denominator = (dy12 * dx34 - dx12 * dy34);

            float t1;
            try
            {
                t1 = ((p1.X - p3.X) * dy34 + (p3.Y - p1.Y) * dx34) / denominator;
            }
            catch
            {
                // The lines are parallel (or close enough to it).
                lines_intersect = false;
                segments_intersect = false;
                intersection = new PointF(float.NaN, float.NaN);
                close_p1 = new PointF(float.NaN, float.NaN);
                close_p2 = new PointF(float.NaN, float.NaN);
                return;
            }
            lines_intersect = true;

            float t2 = ((p3.X - p1.X) * dy12 + (p1.Y - p3.Y) * dx12) / -denominator;

            // Find the point of intersection.
            intersection = new PointF(p1.X + dx12 * t1, p1.Y + dy12 * t1);

            // The segments intersect if t1 and t2 are between 0 and 1.
            segments_intersect = ((t1 >= 0) && (t1 <= 1) && (t2 >= 0) && (t2 <= 1));

            // Find the closest points on the segments.
            if (t1 < 0)
            {
                t1 = 0;
            }
            else if (t1 > 1)
            {
                t1 = 1;
            }

            if (t2 < 0)
            {
                t2 = 0;
            }
            else if (t2 > 1)
            {
                t2 = 1;
            }

            close_p1 = new PointF(p1.X + dx12 * t1, p1.Y + dy12 * t1);
            close_p2 = new PointF(p3.X + dx34 * t2, p3.Y + dy34 * t2);
        }

        // Calculate the distance between
        // point pt and the segment p1 --> p2.
        private double FindDistanceToSegment(PointF pt, PointF p1, PointF p2, out PointF closest)
        {
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;
            if ((dx == 0) && (dy == 0))
            {
                // It's a point not a line segment.
                closest = p1;
                dx = pt.X - p1.X;
                dy = pt.Y - p1.Y;
                return Math.Sqrt(dx * dx + dy * dy);
            }

            // Calculate the t that minimizes the distance.
            float t = ((pt.X - p1.X) * dx + (pt.Y - p1.Y) * dy) / (dx * dx + dy * dy);

            // See if this represents one of the segment's
            // end points or a point in the middle.
            if (t < 0)
            {
                closest = new PointF(p1.X, p1.Y);
                dx = pt.X - p1.X;
                dy = pt.Y - p1.Y;
            }
            else if (t > 1)
            {
                closest = new PointF(p2.X, p2.Y);
                dx = pt.X - p2.X;
                dy = pt.Y - p2.Y;
            }
            else
            {
                closest = new PointF(p1.X + t * dx, p1.Y + t * dy);
                dx = pt.X - closest.X;
                dy = pt.Y - closest.Y;
            }

            return Math.Sqrt(dx * dx + dy * dy);
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
            this.SuspendLayout();
            // 
            // howto_segment_segment_distance_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 158);
            this.Name = "howto_segment_segment_distance_Form1";
            this.Text = "howto_segment_segment_distance";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_segment_segment_distance_Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.howto_segment_segment_distance_Form1_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

