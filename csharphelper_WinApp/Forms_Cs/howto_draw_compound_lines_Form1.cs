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
     public partial class howto_draw_compound_lines_Form1:Form
  { 


        public howto_draw_compound_lines_Form1()
        {
            InitializeComponent();
        }

        // Raise a Paint event when we resize.
        private void howto_draw_compound_lines_Form1_Load(object sender, EventArgs e)
        {
            this.ResizeRedraw = true;
        }

        // Draw with a compound pen.
        private void howto_draw_compound_lines_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen the_pen = new Pen(Color.Blue, 20))
            {
                the_pen.CompoundArray =
                    new float[] { 0.0f, 0.1f, 0.2f, 0.8f, 0.9f, 1.0f };

                // Draw the star.
                Rectangle rect = new Rectangle(
                    35, 40,
                    ClientSize.Width - 70,
                    ClientSize.Height - 50);
                DrawStar(e.Graphics, the_pen,
                    Brushes.White, 5, 2, rect);
            }
        }

        // Draw the indicated star in the rectangle.
        private void DrawStar(Graphics gr, Pen the_pen, Brush the_brush, int num_points, int skip, Rectangle rect)
        {
            // Get the star's points.
            PointF[] star_points = MakeStarPoints(-Math.PI / 2, num_points, skip, rect);

            // Draw the star.
            gr.FillPolygon(the_brush, star_points);
            gr.DrawPolygon(the_pen, star_points);
        }

        // Generate the points for a star.
        private PointF[] MakeStarPoints(double start_theta, int num_points, int skip, Rectangle rect)
        {
            double theta, dtheta;
            PointF[] result;
            float rx = rect.Width / 2f;
            float ry = rect.Height / 2f;
            float cx = rect.X + rx;
            float cy = rect.Y + ry;

            // If this is a polygon, don't bother with concave points.
            if (skip == 1)
            {
                result = new PointF[num_points];
                theta = start_theta;
                dtheta = 2 * Math.PI / num_points;
                for (int i = 0; i < num_points; i++)
                {
                    result[i] = new PointF(
                        (float)(cx + rx * Math.Cos(theta)),
                        (float)(cy + ry * Math.Sin(theta)));
                    theta += dtheta;
                }
                return result;
            }

            // Find the radius for the concave vertices.
            double concave_radius = CalculateConcaveRadius(num_points, skip);

            // Make the points.
            result = new PointF[2 * num_points];
            theta = start_theta;
            dtheta = Math.PI / num_points;
            for (int i = 0; i < num_points; i++)
            {
                result[2 * i] = new PointF(
                    (float)(cx + rx * Math.Cos(theta)),
                    (float)(cy + ry * Math.Sin(theta)));
                theta += dtheta;
                result[2 * i + 1] = new PointF(
                    (float)(cx + rx * Math.Cos(theta) * concave_radius),
                    (float)(cy + ry * Math.Sin(theta) * concave_radius));
                theta += dtheta;
            }
            return result;
        }

        // Calculate the inner star radius.
        private double CalculateConcaveRadius(int num_points, int skip)
        {
            // For really small numbers of points.
            if (num_points < 5) return 0.33f;

            // Calculate angles to key points.
            double dtheta = 2 * Math.PI / num_points;
            double theta00 = -Math.PI / 2;
            double theta01 = theta00 + dtheta * skip;
            double theta10 = theta00 + dtheta;
            double theta11 = theta10 - dtheta * skip;

            // Find the key points.
            PointF pt00 = new PointF(
                (float)Math.Cos(theta00),
                (float)Math.Sin(theta00));
            PointF pt01 = new PointF(
                (float)Math.Cos(theta01),
                (float)Math.Sin(theta01));
            PointF pt10 = new PointF(
                (float)Math.Cos(theta10),
                (float)Math.Sin(theta10));
            PointF pt11 = new PointF(
                (float)Math.Cos(theta11),
                (float)Math.Sin(theta11));

            // See where the segments connecting the points intersect.
            bool lines_intersect, segments_intersect;
            PointF intersection, close_p1, close_p2;
            FindIntersection(pt00, pt01, pt10, pt11,
                out lines_intersect, out segments_intersect,
                out intersection, out close_p1, out close_p2);

            // Calculate the distance between the
            // point of intersection and the center.
            return Math.Sqrt(
                intersection.X * intersection.X +
                intersection.Y * intersection.Y);
        }

        // Find the point of intersection between
        // the lines p1 --> p2 and p3 --> p4.
        private void FindIntersection(
            PointF p1, PointF p2, PointF p3, PointF p4,
            out bool lines_intersect, out bool segments_intersect,
            out PointF intersection,
            out PointF close_p1, out PointF close_p2)
        {
            // Get the segments' parameters.
            float dx12 = p2.X - p1.X;
            float dy12 = p2.Y - p1.Y;
            float dx34 = p4.X - p3.X;
            float dy34 = p4.Y - p3.Y;

            // Solve for t1 and t2
            float denominator = (dy12 * dx34 - dx12 * dy34);

            float t1 =
                ((p1.X - p3.X) * dy34 + (p3.Y - p1.Y) * dx34)
                    / denominator;
            if (float.IsInfinity(t1))
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

            float t2 =
                ((p3.X - p1.X) * dy12 + (p1.Y - p3.Y) * dx12)
                    / -denominator;

            // Find the point of intersection.
            intersection = new PointF(p1.X + dx12 * t1, p1.Y + dy12 * t1);

            // The segments intersect if t1 and t2 are between 0 and 1.
            segments_intersect =
                ((t1 >= 0) && (t1 <= 1) &&
                 (t2 >= 0) && (t2 <= 1));

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
            // howto_draw_compound_lines_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 264);
            this.Name = "howto_draw_compound_lines_Form1";
            this.Text = "howto_draw_compound_lines";
            this.Load += new System.EventHandler(this.howto_draw_compound_lines_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_draw_compound_lines_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

