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
     public partial class howto_point_on_arc_Form1:Form
  { 


        public howto_point_on_arc_Form1()
        {
            InitializeComponent();
        }

        // The arc's geometry.
        private RectangleF ArcBounds;
        private float StartAngle, SweepAngle;
        private PointF[] EndPoints;

        // Define the arc.
        private void howto_point_on_arc_Form1_Load(object sender, EventArgs e)
        {
            // Define the arc.
            ArcBounds = new RectangleF(20, 20,
                picCanvas.ClientSize.Width - 40,
                picCanvas.ClientSize.Height - 40);
            StartAngle = 45;
            SweepAngle = 255;

            // Get the arc's end points.
            EndPoints = FindArcEndPoints(ArcBounds,
                StartAngle, StartAngle + SweepAngle);
        }

        // See what's under the mouse.
        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            switch (ArcPartAtPoint(ArcBounds,
                EndPoints[0], EndPoints[1], e.Location, 3))
            {
                case Part.None:
                    picCanvas.Cursor = Cursors.Default;
                    break;
                case Part.Body:
                    picCanvas.Cursor = Cursors.SizeAll;
                    break;
                case Part.StartPoint:
                    picCanvas.Cursor = Cursors.PanWest;
                    break;
                case Part.EndPoint:
                    picCanvas.Cursor = Cursors.PanEast;
                    break;
                default:
                    throw new Exception("Unknown arc part");
            }
        }

        // Draw the arc.
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(picCanvas.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the arc.
            using (Pen pen = new Pen(Color.Blue, 6))
            {
                e.Graphics.DrawArc(pen, ArcBounds,
                    StartAngle, SweepAngle);
            }

            // Draw the arc's end points.
            for (int i = 0; i < 2; i++)
            {
                RectangleF rect = new RectangleF(
                    EndPoints[i].X - 3,
                    EndPoints[i].Y - 3,
                    6, 6);
                e.Graphics.FillRectangle(
                    Brushes.White, rect);
                e.Graphics.DrawRectangle(
                    Pens.Black, Rectangle.Round(rect));
            }
        }

        // Pieces of the arc that the mouse might be over.
        public enum Part
        {
            None,
            StartPoint,
            EndPoint,
            Body,
        }

        // Return the part of the arc that is at the given point.
        public Part ArcPartAtPoint(RectangleF arc_bounds,
            PointF start_point, PointF end_point,
            Point target, float radius)
        {
            // See if the mouse is at the start or end point.
            if (Distance(target, start_point) < radius)
                return Part.StartPoint;
            if (Distance(target, end_point) < radius)
                return Part.EndPoint;

            // Find the angle from the ellipse's center to the point.
            float cx = (arc_bounds.Left + arc_bounds.Right) / 2f;
            float cy = (arc_bounds.Top + arc_bounds.Bottom) / 2f;
            float dx = target.X - cx;
            float dy = target.Y - cy;
            float radians = (float)Math.Atan2(dy, dx);
            float degrees = (float)(radians * 180 / Math.PI);
            while (degrees < 0) degrees += 360;

            // See if the angle is within the ellipse's sweep.
            if ((degrees < StartAngle) ||
                (degrees > StartAngle + SweepAngle))
                return Part.None;

            // Find the point on the ellipse at this angle.
            PointF center = new PointF(cx, cy);
            PointF[] intersections =
                FindEllipseSegmentIntersections(
                    arc_bounds, center, target, false);
            for (int i = 0; i < intersections.Length; i++)
                if (Distance(target, intersections[i]) < radius)
                    return Part.Body;

            // It's not on the arc.
            return Part.None;
        }

        // Return the distance between two points.
        private float Distance(PointF p1, PointF p2)
        {
            float dx = p1.X - p2.X;
            float dy = p1.Y - p2.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        // Find the points of intersection between
        // an ellipse and a line segment.
        private static PointF[] FindEllipseSegmentIntersections(
            RectangleF rect, PointF pt1, PointF pt2, bool segment_only)
        {
            // If the ellipse or line segment are empty, return no intersections.
            if ((rect.Width == 0) || (rect.Height == 0) ||
                ((pt1.X == pt2.X) && (pt1.Y == pt2.Y)))
                return new PointF[] { };

            // Make sure the rectangle has non-negative width and height.
            if (rect.Width < 0)
            {
                rect.X = rect.Right;
                rect.Width = -rect.Width;
            }
            if (rect.Height < 0)
            {
                rect.Y = rect.Bottom;
                rect.Height = -rect.Height;
            }

            // Translate so the ellipse is centered at the origin.
            float cx = rect.Left + rect.Width / 2f;
            float cy = rect.Top + rect.Height / 2f;
            rect.X -= cx;
            rect.Y -= cy;
            pt1.X -= cx;
            pt1.Y -= cy;
            pt2.X -= cx;
            pt2.Y -= cy;

            // Get the semimajor and semiminor axes.
            float a = rect.Width / 2;
            float b = rect.Height / 2;

            // Calculate the quadratic parameters.
            float A = (pt2.X - pt1.X) * (pt2.X - pt1.X) / a / a +
                       (pt2.Y - pt1.Y) * (pt2.Y - pt1.Y) / b / b;
            float B = 2 * pt1.X * (pt2.X - pt1.X) / a / a +
                       2 * pt1.Y * (pt2.Y - pt1.Y) / b / b;
            float C = pt1.X * pt1.X / a / a + pt1.Y * pt1.Y / b / b - 1;

            // Make a list of t values.
            List<float> t_values = new List<float>();

            // Calculate the discriminant.
            float discriminant = B * B - 4 * A * C;
            if (discriminant == 0)
            {
                // One real solution.
                t_values.Add(-B / 2 / A);
            }
            else if (discriminant > 0)
            {
                // Two real solutions.
                t_values.Add((float)((-B + Math.Sqrt(discriminant)) / 2 / A));
                t_values.Add((float)((-B - Math.Sqrt(discriminant)) / 2 / A));
            }

            // Convert the t values into points.
            List<PointF> points = new List<PointF>();
            foreach (float t in t_values)
            {
                // If the points are on the segment (or we
                // don't care if they are), add them to the list.
                if (!segment_only || ((t >= 0f) && (t <= 1f)))
                {
                    float x = pt1.X + (pt2.X - pt1.X) * t + cx;
                    float y = pt1.Y + (pt2.Y - pt1.Y) * t + cy;
                    points.Add(new PointF(x, y));
                }
            }

            // Return the points.
            return points.ToArray();
        }

        // Find the points on an ellipse
        // at the indicated angles from is center.
        private PointF[] FindArcEndPoints(
            RectangleF rect, double degrees1, double degrees2)
        {
            // Find the ellipse's center.
            PointF center = new PointF(
                rect.X + rect.Width / 2f,
                rect.Y + rect.Height / 2f);

            // Find segments from the center in the
            // desired directions and long enough to
            // cut the ellipse.
            float dist = rect.Width + rect.Height;
            double radians1 = degrees1 * Math.PI / 180;
            PointF pt1 = new PointF(
                (float)(center.X + dist * Math.Cos(radians1)),
                (float)(center.Y + dist * Math.Sin(radians1)));
            double radians2 = degrees2 * Math.PI / 180;
            PointF pt2 = new PointF(
                (float)(center.X + dist * Math.Cos(radians2)),
                (float)(center.Y + dist * Math.Sin(radians2)));

            // Find the points of intersection.
            PointF[] intersections1 =
                FindEllipseSegmentIntersections(
                    rect, center, pt1, true);
            PointF[] intersections2 =
                FindEllipseSegmentIntersections(
                    rect, center, pt2, true);
            return new PointF[]
                {
                    intersections1[0],
                    intersections2[0]
                };
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
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(12, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(361, 239);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseMove);
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // howto_point_on_arc_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 263);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_point_on_arc_Form1";
            this.Text = "howto_point_on_arc";
            this.Load += new System.EventHandler(this.howto_point_on_arc_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
    }
}

