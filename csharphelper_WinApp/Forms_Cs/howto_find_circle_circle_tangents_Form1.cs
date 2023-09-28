using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_find_circle_circle_tangents_Form1:Form
  { 


        public howto_find_circle_circle_tangents_Form1()
        {
            InitializeComponent();
        }

        // The point where the user pressed the mouse.
        PointF StartPoint = new PointF(-1, -1);

        // The mouse's current point.
        PointF CurrentPoint = new PointF(-1, -1);

        // Redraw on resize.
        private void howto_find_circle_circle_tangents_Form1_Load(object sender, EventArgs e)
        {
            this.ResizeRedraw = true;
        }

        // Record the starting point.
        private void howto_find_circle_circle_tangents_Form1_MouseDown(object sender, MouseEventArgs e)
        {
            StartPoint = e.Location;
            CurrentPoint = e.Location;
            this.Refresh();
        }

        // If the left mouse button is down, move the current point.
        private void howto_find_circle_circle_tangents_Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CurrentPoint = e.Location;
                this.Refresh();
            }
        }

        // Draw the circle, point, and tangent lines.
        private void howto_find_circle_circle_tangents_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Draw the circle.
            float radius = Math.Min(
                this.ClientSize.Width / 4f,
                this.ClientSize.Height / 4f);
            float cx = this.ClientSize.Width - radius - 20;
            float cy = this.ClientSize.Height - radius - 20;
            //e.Graphics.FillEllipse(Brushes.LightBlue,
            //    cx - radius, cy - radius,
            //    2 * radius, 2 * radius);
            e.Graphics.DrawEllipse(Pens.Blue,
                cx - radius, cy - radius,
                2 * radius, 2 * radius);

            if (StartPoint.X < 0) return;

            // Get the second circle's geometry.
            float dx = StartPoint.X - CurrentPoint.X;
            float dy = StartPoint.Y - CurrentPoint.Y;
            float radius2 = (float)Math.Sqrt(dx * dx + dy * dy);

            // Find the tangents.
            PointF outer1_p1, outer1_p2, outer2_p1, outer2_p2,
                   inner1_p1, inner1_p2, inner2_p1, inner2_p2;
            int num_tangents = FindCircleCircleTangents(
                new PointF(cx, cy), radius,
                StartPoint, radius2,
                out outer1_p1, out outer1_p2,
                out outer2_p1, out outer2_p2,
                out inner1_p1, out inner1_p2,
                out inner2_p1, out inner2_p2);

            if (num_tangents > 0)
            {
                Console.WriteLine(outer1_p1.ToString());

                // Draw the outer tangents.
                e.Graphics.DrawLine(Pens.Blue, outer1_p1, outer1_p2);
                e.Graphics.DrawLine(Pens.Blue, outer2_p1, outer2_p2);

                if (num_tangents > 2)
                {
                    // Draw the inner tangents.
                    e.Graphics.DrawLine(Pens.Red, inner1_p1, inner1_p2);
                    e.Graphics.DrawLine(Pens.Red, inner2_p1, inner2_p2);
                }
            }

            // Draw second circle.
            //e.Graphics.FillEllipse(Brushes.Pink,
            //    StartPoint.X - radius2, StartPoint.Y - radius2,
            //    2 * radius2, 2 * radius2);
            e.Graphics.DrawEllipse(Pens.Red,
                StartPoint.X - radius2, StartPoint.Y - radius2,
                2 * radius2, 2 * radius2);
        }

        // Find the tangent points for these two circles.
        // Return the number of tangents: 4, 2, or 0.
        private int FindCircleCircleTangents(
            PointF c1, float radius1, PointF c2, float radius2,
            out PointF outer1_p1, out PointF outer1_p2,
            out PointF outer2_p1, out PointF outer2_p2,
            out PointF inner1_p1, out PointF inner1_p2,
            out PointF inner2_p1, out PointF inner2_p2)
        {
            // Make sure radius1 <= radius2.
            if (radius1 > radius2)
            {
                // Call this method switching the circles.
                return FindCircleCircleTangents(
                    c2, radius2, c1, radius1,
                    out outer1_p2, out outer1_p1,
                    out outer2_p2, out outer2_p1,
                    out inner1_p2, out inner1_p1,
                    out inner2_p2, out inner2_p1);
            }

            // Initialize the return values in case
            // some tangents are missing.
            outer1_p1 = new PointF(-1, -1);
            outer1_p2 = new PointF(-1, -1);
            outer2_p1 = new PointF(-1, -1);
            outer2_p2 = new PointF(-1, -1);
            inner1_p1 = new PointF(-1, -1);
            inner1_p2 = new PointF(-1, -1);
            inner2_p1 = new PointF(-1, -1);
            inner2_p2 = new PointF(-1, -1);

            // ***************************
            // * Find the outer tangents *
            // ***************************
            {
                float radius2a = radius2 - radius1;
                if (!FindTangents(c2, radius2a, c1, out outer1_p2, out outer2_p2))
                {
                    // There are no tangents.
                    return 0;
                }

                // Get the vector perpendicular to the
                // first tangent with length radius1.
                float v1x = -(outer1_p2.Y - c1.Y);
                float v1y = outer1_p2.X - c1.X;
                float v1_length = (float)Math.Sqrt(v1x * v1x + v1y * v1y);
                v1x *= radius1 / v1_length;
                v1y *= radius1 / v1_length;
                // Offset the tangent vector's points.
                outer1_p1 = new PointF(c1.X + v1x, c1.Y + v1y);
                outer1_p2 = new PointF(outer1_p2.X + v1x, outer1_p2.Y + v1y);

                // Get the vector perpendicular to the
                // second tangent with length radius1.
                float v2x = outer2_p2.Y - c1.Y;
                float v2y = -(outer2_p2.X - c1.X);
                float v2_length = (float)Math.Sqrt(v2x * v2x + v2y * v2y);
                v2x *= radius1 / v2_length;
                v2y *= radius1 / v2_length;
                // Offset the tangent vector's points.
                outer2_p1 = new PointF(c1.X + v2x, c1.Y + v2y);
                outer2_p2 = new PointF(outer2_p2.X + v2x, outer2_p2.Y + v2y);
            }

            // If the circles intersect, then there are no inner tangents.
            float dx = c2.X - c1.X;
            float dy = c2.Y - c1.Y;
            double dist = Math.Sqrt(dx * dx + dy * dy);
            if (dist <= radius1 + radius2) return 2;

            // ***************************
            // * Find the inner tangents *
            // ***************************
            {
                float radius1a = radius1 + radius2;
                FindTangents(c1, radius1a, c2, out inner1_p2, out inner2_p2);

                // Get the vector perpendicular to the
                // first tangent with length radius2.
                float v1x = inner1_p2.Y - c2.Y;
                float v1y = -(inner1_p2.X - c2.X);
                float v1_length = (float)Math.Sqrt(v1x * v1x + v1y * v1y);
                v1x *= radius2 / v1_length;
                v1y *= radius2 / v1_length;
                // Offset the tangent vector's points.
                inner1_p1 = new PointF(c2.X + v1x, c2.Y + v1y);
                inner1_p2 = new PointF(inner1_p2.X + v1x, inner1_p2.Y + v1y);

                // Get the vector perpendicular to the
                // second tangent with length radius2.
                float v2x = -(inner2_p2.Y - c2.Y);
                float v2y = inner2_p2.X - c2.X;
                float v2_length = (float)Math.Sqrt(v2x * v2x + v2y * v2y);
                v2x *= radius2 / v2_length;
                v2y *= radius2 / v2_length;
                // Offset the tangent vector's points.
                inner2_p1 = new PointF(c2.X + v2x, c2.Y + v2y);
                inner2_p2 = new PointF(inner2_p2.X + v2x, inner2_p2.Y + v2y);
            }

            return 4;
        }

        // Find the tangent points for this circle and external point.
        // Return true if we find the tangents, false if the point is
        // inside the circle.
        private bool FindTangents(PointF center, float radius,
            PointF external_point, out PointF pt1, out PointF pt2)
        {
            // Find the distance squared from the
            // external point to the circle's center.
            double dx = center.X - external_point.X;
            double dy = center.Y - external_point.Y;
            double D_squared = dx * dx + dy * dy;
            if (D_squared < radius * radius)
            {
                pt1 = new PointF(-1, -1);
                pt2 = new PointF(-1, -1);
                return false;
            }

            // Find the distance from the external point
            // to the tangent points.
            double L = Math.Sqrt(D_squared - radius * radius);

            // Find the points of intersection between
            // the original circle and the circle with
            // center external_point and radius dist.
            FindCircleCircleIntersections(
                center.X, center.Y, radius,
                external_point.X, external_point.Y, (float)L,
                out pt1, out pt2);

            return true;
        }

        // Find the points where the two circles intersect.
        private int FindCircleCircleIntersections(
            float cx0, float cy0, float radius0,
            float cx1, float cy1, float radius1,
            out PointF intersection1, out PointF intersection2)
        {
            // Find the distance between the centers.
            float dx = cx0 - cx1;
            float dy = cy0 - cy1;
            double dist = Math.Sqrt(dx * dx + dy * dy);

            // See how many solutions there are.
            if (dist > radius0 + radius1)
            {
                // No solutions, the circles are too far apart.
                intersection1 = new PointF(float.NaN, float.NaN);
                intersection2 = new PointF(float.NaN, float.NaN);
                return 0;
            }
            else if (dist < Math.Abs(radius0 - radius1))
            {
                // No solutions, one circle contains the other.
                intersection1 = new PointF(float.NaN, float.NaN);
                intersection2 = new PointF(float.NaN, float.NaN);
                return 0;
            }
            else if ((dist == 0) && (radius0 == radius1))
            {
                // No solutions, the circles coincide.
                intersection1 = new PointF(float.NaN, float.NaN);
                intersection2 = new PointF(float.NaN, float.NaN);
                return 0;
            }
            else
            {
                // Find a and h.
                double a = (radius0 * radius0 -
                    radius1 * radius1 + dist * dist) / (2 * dist);
                double h = Math.Sqrt(radius0 * radius0 - a * a);

                // Find P2.
                double cx2 = cx0 + a * (cx1 - cx0) / dist;
                double cy2 = cy0 + a * (cy1 - cy0) / dist;

                // Get the points P3.
                intersection1 = new PointF(
                    (float)(cx2 + h * (cy1 - cy0) / dist),
                    (float)(cy2 - h * (cx1 - cx0) / dist));
                intersection2 = new PointF(
                    (float)(cx2 - h * (cy1 - cy0) / dist),
                    (float)(cy2 + h * (cx1 - cx0) / dist));

                // See if we have 1 or 2 solutions.
                if (dist == radius0 + radius1) return 1;
                return 2;
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
            this.SuspendLayout();
            // 
            // howto_find_circle_circle_tangents_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 311);
            this.Name = "howto_find_circle_circle_tangents_Form1";
            this.Text = "howto_find_circle_circle_tangents";
            this.Load += new System.EventHandler(this.howto_find_circle_circle_tangents_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_find_circle_circle_tangents_Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.howto_find_circle_circle_tangents_Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.howto_find_circle_circle_tangents_Form1_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

