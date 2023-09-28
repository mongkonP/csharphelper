using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

// For information on star polygons, see:
// http://en.wikipedia.org/wiki/Star_polygon

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_draw_star2_Form1:Form
  { 


        public howto_draw_star2_Form1()
        {
            InitializeComponent();
        }

        // Redraw the star with the new parameters.
        private void nudPoints_ValueChanged(object sender, EventArgs e)
        {
            nudSkip.Maximum = (int)(((int)nudPoints.Value - 1) / 2.0);
            picStar.Refresh();
        }
        private void nudSkip_ValueChanged(object sender, EventArgs e)
        {
            picStar.Refresh();
        }

        // Draw the star.
        private void picStar_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the star.
            DrawStar(e.Graphics, Pens.Red, Brushes.Yellow,
                (int)nudPoints.Value, (int)nudSkip.Value, picStar.ClientRectangle);
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
            this.nudPoints = new System.Windows.Forms.NumericUpDown();
            this.nudSkip = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picStar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSkip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStar)).BeginInit();
            this.SuspendLayout();
            // 
            // nudPoints
            // 
            this.nudPoints.Location = new System.Drawing.Point(67, 12);
            this.nudPoints.Name = "nudPoints";
            this.nudPoints.Size = new System.Drawing.Size(42, 20);
            this.nudPoints.TabIndex = 0;
            this.nudPoints.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.nudPoints.ValueChanged += new System.EventHandler(this.nudPoints_ValueChanged);
            // 
            // nudSkip
            // 
            this.nudSkip.Location = new System.Drawing.Point(67, 38);
            this.nudSkip.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudSkip.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSkip.Name = "nudSkip";
            this.nudSkip.Size = new System.Drawing.Size(42, 20);
            this.nudSkip.TabIndex = 1;
            this.nudSkip.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudSkip.ValueChanged += new System.EventHandler(this.nudSkip_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "# Points:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Skip:";
            // 
            // picStar
            // 
            this.picStar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picStar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picStar.Location = new System.Drawing.Point(115, 12);
            this.picStar.Name = "picStar";
            this.picStar.Size = new System.Drawing.Size(244, 240);
            this.picStar.TabIndex = 4;
            this.picStar.TabStop = false;
            this.picStar.Paint += new System.Windows.Forms.PaintEventHandler(this.picStar_Paint);
            // 
            // howto_draw_star2_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 264);
            this.Controls.Add(this.picStar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudSkip);
            this.Controls.Add(this.nudPoints);
            this.Name = "howto_draw_star2_Form1";
            this.Text = "howto_draw_star2";
            ((System.ComponentModel.ISupportInitialize)(this.nudPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSkip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudPoints;
        private System.Windows.Forms.NumericUpDown nudSkip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picStar;
    }
}

