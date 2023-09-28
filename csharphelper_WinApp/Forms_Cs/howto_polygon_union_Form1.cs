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
     public partial class howto_polygon_union_Form1:Form
  { 


        public howto_polygon_union_Form1()
        {
            InitializeComponent();
        }

        // The two polygons' points.
        private List<PointF>[] Polygons =
        {
            new List<PointF>(),
            new List<PointF>(),
        };

        // The polygons' colors.
        private Color[] PolygonColors =
        {
            Color.Blue,
            Color.Green,
        };

        // The current mouse position while drawing a polygon.
        private PointF CurrentLocation;

        // The number of the polyon we are building if any.
        private int MakingIndex = -1;

        // The polygon checkboxes.
        private CheckBox[] PolygonCheckboxes;

        // Make two test polygons.
        private void howto_polygon_union_Form1_Load(object sender, EventArgs e)
        {
            PolygonCheckboxes = new CheckBox[]
            {
                chkPolygon1,
                chkPolygon2,
            };

            Polygons[0] = new List<PointF>(new PointF[]
                {
                    new PointF(136, 75),
                    new PointF(64, 125),
                    new PointF(171, 181),
                    new PointF(140, 97),
                    new PointF(199, 102),
                    new PointF(183, 158),
                    new PointF(242, 127),
                    new PointF(184, 44),
                    new PointF(60, 59),
                });
            Polygons[1] = new List<PointF>(new PointF[]
                {
                    new PointF(115, 34),
                    new PointF(146, 198),
                    new PointF(181, 114),
                    new PointF(217, 162),
                    new PointF(249, 73),
                    new PointF(179, 20),
                    new PointF(146, 69),
                });
        }

        // Start or continue defining a polygon.
        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (MakingIndex < 0)
            {
                // Start a new polygon.
                if (e.Button == MouseButtons.Left) MakingIndex = 0;
                else MakingIndex = 1;

                Polygons[MakingIndex] = new List<PointF>();
                Polygons[MakingIndex].Add(e.Location);
                CurrentLocation = e.Location;
            }
            else
            {
                // Add a new point to the current new polygon.
                if (Polygons[MakingIndex][Polygons[MakingIndex].Count-1] != e.Location)
                    Polygons[MakingIndex].Add(e.Location);
                CurrentLocation = e.Location;
            }

            // Redraw to show changes.
            picCanvas.Refresh();
        }

        // Continue defining a polygon.
        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (MakingIndex < 0) return;
            CurrentLocation = e.Location;
            picCanvas.Refresh();
        }

        // Finish defining this polygon.
        private void picCanvas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // See if we have a polygon.
            if (Polygons[MakingIndex].Count < 3)
            {
                // Discard this polygon.
                Polygons[MakingIndex] = new List<PointF>();
            }
            else
            {
                // Make sure the polygon is oriented
                // counter clockwise.
                OrientPolygonCounterclockwise(Polygons[MakingIndex]);
            }

            // We're no longer making a polygon.
            MakingIndex = -1;
            picCanvas.Refresh();
        }

        // Draw the polygons and their union.
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(picCanvas.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // If we have both polygons, draw the union.
            if ((MakingIndex < 0) &&
                (Polygons[0].Count > 2) &&
                (Polygons[1].Count > 2) &&
                (chkUnion.Checked))
            {
                // Find the union.
                List<PointF> union = FindPolygonUnion(Polygons);

                // Draw it.
                using (Pen pen = new Pen(Color.Black, 10))
                {
                    e.Graphics.DrawPolygon(pen, union.ToArray());
                }
            }

            // Draw the polygons.
            for (int i = 0; i < 2; i++)
            {
                if (PolygonCheckboxes[i].Checked)
                {
                    // See if we are making this polygon.
                    if (i == MakingIndex)
                    {
                        // We are. Draw the segments so far.
                        if (Polygons[i].Count > 1)
                            using (Pen pen = new Pen(PolygonColors[i], 3))
                            {
                                e.Graphics.DrawLines(pen,
                                    Polygons[i].ToArray());
                            }

                        // Draw to the mouse's current location.
                        if (Polygons[i].Count > 0)
                        {
                            PointF point1 = Polygons[i][Polygons[i].Count - 1];
                            e.Graphics.DrawLine(Pens.Green,
                                point1.X, point1.Y,
                                CurrentLocation.X, CurrentLocation.Y);
                        }
                    }
                    else
                    {
                        // We're not making this polygon. Draw it.
                        if (Polygons[i].Count > 2)
                        {
                            Color fill_color = Color.FromArgb(128, PolygonColors[i]);
                            using (Brush brush = new SolidBrush(fill_color))
                            {
                                e.Graphics.FillPolygon(brush,
                                    Polygons[i].ToArray());
                            }
                            using (Pen pen = new Pen(PolygonColors[i], 3))
                            {
                                e.Graphics.DrawPolygon(pen,
                                    Polygons[i].ToArray());
                            }
                        }
                    }
                }
            }
        }

        // Draw a polygon or a partial polygon.
        private void DrawPolygon(List<PointF> polygon, Color color)
        {
        }

        // Return the union of the two polygons.
        private List<PointF> FindPolygonUnion(List<PointF>[] polygons)
        {
            // Find the lower-leftmost point in either polygon.
            int cur_pgon = 0;
            int cur_index = 0;
            PointF cur_point = polygons[cur_pgon][cur_index];
            for (int pgon = 0; pgon < 2; pgon++)
            {
                for (int index = 0; index < polygons[pgon].Count; index++)
                {
                    PointF test_point = polygons[pgon][index];
                    if ((test_point.X < cur_point.X) ||
                        ((test_point.X == cur_point.X) &&
                         (test_point.Y > cur_point.Y)))
                    {
                        cur_pgon = pgon;
                        cur_index = index;
                        cur_point = polygons[cur_pgon][cur_index];
                    }
                }
            }

            // Create the result polygon.
            List<PointF> union = new List<PointF>();

            // Start here.
            PointF start_point = cur_point;
            union.Add(start_point);

            // Start traversing the polygons.
            // Repeat until we return to the starting point.
            for (; ; )
            {
                // Find the next point.
                int next_index = (cur_index + 1) % polygons[cur_pgon].Count;
                PointF next_point = polygons[cur_pgon][next_index];

                // Each time through the loop:
                //      cur_pgon is the index of the polygon we're following
                //      cur_point is the last point added to the union
                //      next_point is the next point in the current polygon
                //      next_index is the index of next_point

                // See if this segment intersects
                // any of the other polygon's segments.
                int other_pgon = (cur_pgon + 1) % 2;

                // Keep track of the closest intersection.
                PointF best_intersection = new PointF(0, 0);
                int best_index1 = -1;
                float best_t = 2f;

                for (int index1 = 0; index1 < polygons[other_pgon].Count; index1++)
                {
                    // Get the index of the next point in the polygon.
                    int index2 = (index1 + 1) % polygons[other_pgon].Count;

                    // See if the segment between points index1
                    // and index2 intersect the current segment.
                    PointF point1 = polygons[other_pgon][index1];
                    PointF point2 = polygons[other_pgon][index2];
                    bool lines_intersect, segments_intersect;
                    PointF intersection, close_p1, close_p2;
                    float t1, t2;
                    FindIntersection(cur_point, next_point, point1, point2,
                        out lines_intersect, out segments_intersect,
                        out intersection, out close_p1, out close_p2, out t1, out t2);

                    if ((segments_intersect) && // The segments intersect
                        (t1 > 0.001) &&         // Not at the previous intersection
                        (t1 < best_t))          // Better than the last intersection found
                    {
                        // See if this is an improvement.
                        if (t1 < best_t)
                        {
                            // Save this intersection.
                            best_t = t1;
                            best_index1 = index1;
                            best_intersection = intersection;
                        }
                    }
                }

                // See if we found any intersections.
                if (best_t < 2f)
                {
                    // We found an intersection. Use it.
                    union.Add(best_intersection);

                    // Prepare to search for the next point from here.
                    // Start following the other polygon.
                    cur_pgon = (cur_pgon + 1) % 2;
                    cur_point = best_intersection;
                    cur_index = best_index1;
                }
                else
                {
                    // We didn't find an intersection.
                    // Move to the next point in this polygon.
                    cur_point = next_point;
                    cur_index = next_index;

                    // If we've returned to the starting point, we're done.
                    if (cur_point == start_point) break;

                    // Add the current point to the union.
                    union.Add(cur_point);
                }
            }

            return union;
        }

        #region Geometry

        private float SignedPolygonArea(List<PointF> points)
        {
            // Add the first point to the end.
            int num_points = points.Count;
            PointF[] pts = new PointF[num_points + 1];
            points.CopyTo(pts, 0);
            pts[num_points] = points[0];

            // Get the areas.
            float area = 0;
            for (int i = 0; i < num_points; i++)
            {
                area +=
                    (pts[i + 1].X - pts[i].X) *
                    (pts[i + 1].Y + pts[i].Y) / 2;
            }

            // Return the result.
            return area;
        }

        // Return true if the polygon is convex.
        public bool PolygonIsConvex(List<PointF> points)
        {
            // For each set of three adjacent points A, B, C,
            // find the dot product AB · BC. If the sign of
            // all the dot products is the same, the angles
            // are all positive or negative (depending on the
            // order in which we visit them) so the polygon
            // is convex.
            bool got_negative = false;
            bool got_positive = false;
            int num_points = points.Count;
            int B, C;
            for (int A = 0; A < num_points; A++)
            {
                B = (A + 1) % num_points;
                C = (B + 1) % num_points;

                float cross_product =
                    CrossProductLength(
                        points[A].X, points[A].Y,
                        points[B].X, points[B].Y,
                        points[C].X, points[C].Y);
                if (cross_product < 0)
                {
                    got_negative = true;
                }
                else if (cross_product > 0)
                {
                    got_positive = true;
                }
                if (got_negative && got_positive) return false;
            }

            // If we got this far, the polygon is convex.
            return true;
        }

        // Return the cross product AB x BC.
        // The cross product is a vector perpendicular to AB
        // and BC having length |AB| * |BC| * Sin(theta) and
        // with direction given by the right-hand rule.
        // For two vectors in the X-Y plane, the result is a
        // vector with X and Y components 0 so the Z component
        // gives the vector's length and direction.
        public static float CrossProductLength(float Ax, float Ay,
            float Bx, float By, float Cx, float Cy)
        {
            // Get the vectors' coordinates.
            float BAx = Ax - Bx;
            float BAy = Ay - By;
            float BCx = Cx - Bx;
            float BCy = Cy - By;

            // Calculate the Z coordinate of the cross product.
            return (BAx * BCy - BAy * BCx);
        }

        // Return true if the polygon is oriented clockwise.
        public bool PolygonIsOrientedClockwise(List<PointF> points)
        {
            return (SignedPolygonArea(points) < 0);
        }

        // If the polygon is oriented counterclockwise,
        // reverse the order of its points.
        private void OrientPolygonCounterclockwise(List<PointF> points)
        {
            if (PolygonIsOrientedClockwise(points))
            {
                points.Reverse();
            }
        }

        // Find the point of intersection between
        // the lines p1 --> p2 and p3 --> p4.
        private void FindIntersection(PointF p1, PointF p2, PointF p3, PointF p4,
            out bool lines_intersect, out bool segments_intersect,
            out PointF intersection, out PointF close_p1, out PointF close_p2,
            out float t1, out float t2)
        {
            // Get the segments' parameters.
            float dx12 = p2.X - p1.X;
            float dy12 = p2.Y - p1.Y;
            float dx34 = p4.X - p3.X;
            float dy34 = p4.Y - p3.Y;

            // Solve for t1 and t2
            float denominator = (dy12 * dx34 - dx12 * dy34);
            t1 = ((p1.X - p3.X) * dy34 + (p3.Y - p1.Y) * dx34) / denominator;
            if (float.IsInfinity(t1))
            {
                // The lines are parallel (or close enough to it).
                lines_intersect = false;
                segments_intersect = false;
                intersection = new PointF(float.NaN, float.NaN);
                close_p1 = new PointF(float.NaN, float.NaN);
                close_p2 = new PointF(float.NaN, float.NaN);
                t2 = float.PositiveInfinity;
                return;
            }
            lines_intersect = true;

            t2 = ((p3.X - p1.X) * dy12 + (p1.Y - p3.Y) * dx12) / -denominator;

            // Find the point of intersection.
            intersection = new PointF(p1.X + dx12 * t1, p1.Y + dy12 * t1);

            // The segments intersect if t1 and t2 are between 0 and 1.
            segments_intersect = ((t1 >= 0) && (t1 <= 1) && (t2 >= 0) && (t2 <= 1));

            // Find the closest points on the segments.
            if (t1 < 0) t1 = 0;
            else if (t1 > 1) t1 = 1;

            if (t2 < 0) t2 = 0;
            else if (t2 > 1) t2 = 1;

            close_p1 = new PointF(p1.X + dx12 * t1, p1.Y + dy12 * t1);
            close_p2 = new PointF(p3.X + dx34 * t2, p3.Y + dy34 * t2);
        }

        #endregion Geometry

        // Display the polygon's points so we can recreate it later.
        private void ShowPolygon(List<PointF> polygon)
        {
            Console.WriteLine("            polygon = new List<PointF>(new PointF[]");
            Console.WriteLine("                {");
            foreach (PointF point in polygon)
            {
                Console.WriteLine("                    new PointF(" +
                    point.X.ToString("0") + ", " +
                    point.Y.ToString("0") + "),");
            }
            Console.WriteLine("                });");
        }

        // Redraw to show the selected polygons.
        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            picCanvas.Refresh();
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
            this.chkPolygon1 = new System.Windows.Forms.CheckBox();
            this.chkPolygon2 = new System.Windows.Forms.CheckBox();
            this.chkUnion = new System.Windows.Forms.CheckBox();
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
            this.picCanvas.Location = new System.Drawing.Point(12, 35);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(260, 214);
            this.picCanvas.TabIndex = 1;
            this.picCanvas.TabStop = false;
            this.picCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseMove);
            this.picCanvas.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseDoubleClick);
            this.picCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseDown);
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // chkPolygon1
            // 
            this.chkPolygon1.AutoSize = true;
            this.chkPolygon1.Checked = true;
            this.chkPolygon1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPolygon1.Location = new System.Drawing.Point(12, 12);
            this.chkPolygon1.Name = "chkPolygon1";
            this.chkPolygon1.Size = new System.Drawing.Size(73, 17);
            this.chkPolygon1.TabIndex = 2;
            this.chkPolygon1.Text = "Polygon 1";
            this.chkPolygon1.UseVisualStyleBackColor = true;
            this.chkPolygon1.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chkPolygon2
            // 
            this.chkPolygon2.AutoSize = true;
            this.chkPolygon2.Checked = true;
            this.chkPolygon2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPolygon2.Location = new System.Drawing.Point(115, 12);
            this.chkPolygon2.Name = "chkPolygon2";
            this.chkPolygon2.Size = new System.Drawing.Size(73, 17);
            this.chkPolygon2.TabIndex = 3;
            this.chkPolygon2.Text = "Polygon 2";
            this.chkPolygon2.UseVisualStyleBackColor = true;
            this.chkPolygon2.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chkUnion
            // 
            this.chkUnion.AutoSize = true;
            this.chkUnion.Checked = true;
            this.chkUnion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUnion.Location = new System.Drawing.Point(218, 12);
            this.chkUnion.Name = "chkUnion";
            this.chkUnion.Size = new System.Drawing.Size(54, 17);
            this.chkUnion.TabIndex = 4;
            this.chkUnion.Text = "Union";
            this.chkUnion.UseVisualStyleBackColor = true;
            this.chkUnion.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // howto_polygon_union_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.chkUnion);
            this.Controls.Add(this.chkPolygon2);
            this.Controls.Add(this.chkPolygon1);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_polygon_union_Form1";
            this.Text = "howto_polygon_union";
            this.Load += new System.EventHandler(this.howto_polygon_union_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.CheckBox chkPolygon1;
        private System.Windows.Forms.CheckBox chkPolygon2;
        private System.Windows.Forms.CheckBox chkUnion;
    }
}

