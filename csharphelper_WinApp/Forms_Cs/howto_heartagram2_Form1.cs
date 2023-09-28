using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

using howto_heartagram2;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_heartagram2_Form1:Form
  { 


        public howto_heartagram2_Form1()
        {
            InitializeComponent();
        }

        private void picHeartagram_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            PointF center = new PointF(80, 80);
            float radius = 70;
            RectangleF rect = new RectangleF(
                center.X - radius,
                center.Y - radius,
                2 * radius,
                2 * radius);

            // Make a gradient brush that fills the rectangle.
            using (LinearGradientBrush brush =
                new LinearGradientBrush(
                    new PointF(center.X - radius, center.Y),
                    new PointF(center.X + radius, center.Y),
                    Color.Black, Color.Black))
            {
                ColorBlend color_blend = new ColorBlend();
                color_blend.Colors = new Color[] 
                {
                    Color.Magenta,
                    Color.White,
                    Color.Magenta,
                };
                color_blend.Positions = new float[]
                {
                    0.0f, 0.5f, 1.0f
                };
                brush.InterpolationColors = color_blend;

                // Make a pen that is colored by the brush.
                using (Pen pen = new Pen(Color.Black, 8))
                {
                    // Draw the heartagram.
                    DrawHeartagram(e.Graphics, center, radius, brush, pen);
                }
            }
        }

        private void DrawHeartagram(Graphics gr, PointF center,
            float radius, Brush brush, Pen pen)
        {
            gr.FillEllipse(brush,
                center.X - radius,
                center.Y - radius,
                2 * radius,
                2 * radius);
            gr.DrawEllipse(pen,
                center.X - radius,
                center.Y - radius,
                2 * radius,
                2 * radius);

            // Make a GraphicsPath to represent the heartagram.
            GraphicsPath path = MakeHeartagram2(center, radius, pen.Width);

            // Draw the GraphicsPath.
            gr.DrawPath(pen, path);

            // Optionally draw the control points.
            //using (Font font = new Font("Times New Romann", 10))
            //{
            //    PointF[] points = GetControlPoints(center, radius, pen.Width);
            //    for (int i = 0; i < points.Length; i++)
            //    {
            //        gr.LabelPoint(Brushes.Lime, Brushes.Black, Pens.Black,
            //            font, points[i], 8, i.ToString());
            //    }
            //}
        }

        // Return a GraphicsPath representing a heartagram.
        private GraphicsPath MakeHeartagram2(PointF center,
            float radius, float pen_width)
        {
            // Get the control points.
            PointF[] control_points =
                GetControlPoints(center, radius, pen_width);

            // Build the GraphicsPath.
            GraphicsPath path = new GraphicsPath();
            path.AddLine(control_points[0], control_points[4]);

            // Find the first arc.
            RectangleF arc1_rect;
            float arc1_start_angle, arc1_sweep_angle;
            PointF s1_far, s1_close, s2_far, s2_close;
            FindArcFromSegments(
                control_points[0], control_points[4],
                control_points[2], control_points[3],
                out arc1_rect, out arc1_start_angle, out arc1_sweep_angle,
                out s1_far, out s1_close, out s2_far, out s2_close);
            path.AddArc(arc1_rect, arc1_start_angle, arc1_sweep_angle);

            path.AddLine(control_points[2], control_points[3]);
            path.AddLine(control_points[3], control_points[1]);
            path.AddLine(control_points[1], control_points[2]);

            // Find the second arc.
            RectangleF arc2_rect;
            float arc2_start_angle, arc2_sweep_angle;
            FindArcFromSegments(
                control_points[1], control_points[2],
                control_points[5], control_points[0],
                out arc2_rect, out arc2_start_angle, out arc2_sweep_angle,
                out s1_far, out s1_close, out s2_far, out s2_close);
            path.AddArc(arc2_rect, arc2_start_angle, arc2_sweep_angle);

            path.AddLine(control_points[5], control_points[0]);

            // Close the figure so the last corner is mitered.
            path.CloseFigure();

            return path;
        }

        // Return a list of the heartagram's control points.
        private PointF[] GetControlPoints(PointF center,
            float radius, float pen_width)
        {
            // Define the control points.
            double pi_over_2 = Math.PI / 2;
            double dtheta = 2 * Math.PI / 5;
            double[] control_angles =
            {
                pi_over_2,
                pi_over_2 + dtheta,
                pi_over_2 + 2.5 * dtheta,
                pi_over_2 + 4 * dtheta,
            };
            double[] control_radii =
            {
                0.90 * radius - pen_width / 2f,
                0.90 * radius - pen_width / 2f,
                0.75 * radius - pen_width / 2f,
                0.90 * radius - pen_width / 2f,
            };
            PointF[] control_points =
                new PointF[control_angles.Length + 2];
            for (int i = 0; i < control_angles.Length; i++)
            {
                double x = center.X + control_radii[i] * Math.Cos(control_angles[i]);
                double y = center.Y + control_radii[i] * Math.Sin(control_angles[i]);
                control_points[i] = new PointF((float)x, (float)y);
            }

            // Find the end points of the arcs.
            control_points[4] = PointAtFraction(
                control_points[1], control_points[2], 0.4f);
            control_points[5] = PointAtFraction(
                control_points[3], control_points[2], 0.4f);

            return control_points;
        }

        // Find the point of intersection between
        // the lines p1 --> p2 and p3 --> p4. This method
        // assumes that they do intersect.
        private PointF FindIntersection(
            PointF p1, PointF p2, PointF p3, PointF p4)
        {
            bool lines_intersect, segments_intersect;
            PointF intersection, close_p1, close_p2;
            FindIntersection(
                p1, p2, p3, p4,
                out lines_intersect, out segments_intersect,
                out intersection,
                out close_p1, out close_p2);
            return intersection;
        }

        // Return a point that is the given fraction of
        // the distance from start_point to to_point.
        public static PointF PointAtFraction(PointF start_point,
            PointF to_point, float fraction)
        {
            float dx = (to_point.X - start_point.X);
            float dy = (to_point.Y - start_point.Y);
            return new PointF(
                start_point.X + dx * fraction,
                start_point.Y + dy * fraction);
        }

        // Find a circular arc connecting the segments.
        // Return the arc's parameters. Also return new points
        // to define the segments so you can draw
        // s1_far -> s1_close -> arc -> s2_close -> s2_far.
        // Three os those points will be original segments points.
        private void FindArcFromSegments(
            PointF s1p1, PointF s1p2,
            PointF s2p1, PointF s2p2,
            out RectangleF rect,
            out float start_angle, out float sweep_angle,
            out PointF s1_far, out PointF s1_close,
            out PointF s2_far, out PointF s2_close)
        {
            // See where the segments intersect.
            PointF poi;
            bool lines_intersect, segments_intersect;
            PointF close1, close2;
            FindIntersection(s1p1, s1p2, s2p1, s2p2,
                out lines_intersect, out segments_intersect,
                out poi, out close1, out close2);
#if TEST
            LinesPoi = poi;
#endif

            // See if the lines intersect.
            if (!lines_intersect)
            {
                // The lines are parallel. Find the 180 degree arc.
                throw new NotImplementedException("The segments are parallel.");
            }

            // Find the point on each segment that is closest to the poi.
            float close_dist1, close_dist2, far_dist1, far_dist2;

            // Make s1_close be the closer of the points.
            if (s1p1.Distance(poi) < s1p2.Distance(poi))
            {
                s1_close = s1p1;
                s1_far = s1p2;
                close_dist1 = s1p1.Distance(poi);
                far_dist1 = s1p2.Distance(poi);
            }
            else
            {
                s1_close = s1p2;
                s1_far = s1p1;
                close_dist1 = s1p2.Distance(poi);
                far_dist1 = s1p1.Distance(poi);
            }

            // Make s2_close be the closer of the points.
            if (s2p1.Distance(poi) < s2p2.Distance(poi))
            {
                s2_close = s2p1;
                s2_far = s2p2;
                close_dist2 = s2p1.Distance(poi);
                far_dist2 = s1p2.Distance(poi);
            }
            else
            {
                s2_close = s2p2;
                s2_far = s2p1;
                close_dist2 = s2p2.Distance(poi);
                far_dist2 = s1p1.Distance(poi);
            }

            // See which of the close points is closer to the poi.
            if (close_dist1 < close_dist2)
            {
                // s1_close is closer to the poi than s2_close.
                // Find the point on seg2 that is distance
                // close_dist1 from the poi.
                s2_close = PointAtDistance(poi, s2_far, close_dist1);
                close_dist2 = close_dist1;
            }
            else
            {
                // s2_close is closer to the poi than s1_close.
                // Find the point on seg1 that is distance
                // close_dist2 from the poi.
                s1_close = PointAtDistance(poi, s1_far, close_dist2);
                close_dist1 = close_dist2;
            }

            // Find the arc.
            FindArcFromTangents(
                s1_close, s1_far,
                s2_close, s2_far,
                out rect, out start_angle, out sweep_angle);
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

        // Find a point on the line p1 --> p2 that
        // is distance dist from point p1.
        private PointF PointAtDistance(PointF p1, PointF p2, float dist)
        {
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;
            float p1p2_dist = (float)Math.Sqrt(dx * dx + dy * dy);
            return new PointF(
                p1.X + dx / p1p2_dist * dist,
                p1.Y + dy / p1p2_dist * dist);
        }

        // Find the arc that connects points s1p2 and s2p2.
        private void FindArcFromTangents(
            PointF s1_close, PointF s1_far,
            PointF s2_close, PointF s2_far,
            out RectangleF rect,
            out float start_angle, out float sweep_angle)
        {
            // Find the perpendicular lines.
            PointF perp_point1, perp_point2;

            float dx1 = s1_close.X - s1_far.X;
            float dy1 = s1_close.Y - s1_far.Y;
            perp_point1 = new PointF(
                s1_close.X - dy1,
                s1_close.Y + dx1);
#if TEST
            PerpPoint1 = perp_point1;
#endif

            float dx2 = s2_close.X - s2_far.X;
            float dy2 = s2_close.Y - s2_far.Y;
            perp_point2 = new PointF(
                s2_close.X + dy2,
                s2_close.Y - dx2);
#if TEST
            PerpPoint2 = perp_point2;
#endif

            // Find the point of intersection between segments
            // s1_close --> perp_point1 and
            // s2_close --> perp_point2.
            bool lines_intersect, segments_intersect;
            PointF poi, close_p1, close_p2;
            FindIntersection(
                s1_close, perp_point1,
                s2_close, perp_point2,
                out lines_intersect, out segments_intersect,
                out poi, out close_p1, out close_p2);
#if TEST
            PerpPoi = poi;
#endif

            // Find the radius.
            float dx = s1_close.X - poi.X;
            float dy = s1_close.Y - poi.Y;
            float radius = (float)Math.Sqrt(dx * dx + dy * dy);

            // Create the rectangle.
            rect = new RectangleF(
                poi.X - radius,
                poi.Y - radius,
                2 * radius, 2 * radius);

            // Find the start, end, and sweep angles.
            start_angle = (float)(Math.Atan2(dy, dx) * 180 / Math.PI);
            dx = s2_close.X - poi.X;
            dy = s2_close.Y - poi.Y;
            float end_angle = (float)(Math.Atan2(dy, dx) * 180 / Math.PI);

            // Make the angle less than 180 degrees.
            sweep_angle = end_angle - start_angle;
            if (sweep_angle > 180)
                sweep_angle = sweep_angle - 360;
            if (sweep_angle < -180)
                sweep_angle = 360 + sweep_angle;
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
            this.picHeartagram = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picHeartagram)).BeginInit();
            this.SuspendLayout();
            // 
            // picHeartagram
            // 
            this.picHeartagram.Location = new System.Drawing.Point(12, 12);
            this.picHeartagram.Name = "picHeartagram";
            this.picHeartagram.Size = new System.Drawing.Size(160, 157);
            this.picHeartagram.TabIndex = 0;
            this.picHeartagram.TabStop = false;
            this.picHeartagram.Paint += new System.Windows.Forms.PaintEventHandler(this.picHeartagram_Paint);
            // 
            // howto_heartagram2_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 181);
            this.Controls.Add(this.picHeartagram);
            this.Name = "howto_heartagram2_Form1";
            this.Text = "howto_heartagram2";
            ((System.ComponentModel.ISupportInitialize)(this.picHeartagram)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picHeartagram;
    }
}

