// #define SHOW_ADJUSTMENTS

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

using howto_rounded_polygon;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_rounded_polygon_Form1:Form
  { 


        public howto_rounded_polygon_Form1()
        {
            InitializeComponent();
        }

        private List<PointF> Points = new List<PointF>();
        private bool Drawing = false;
        private int Radius = 5;

#if SHOW_ADJUSTMENTS
        SegmentInfo seg1, seg2;
#endif

        private void howto_rounded_polygon_Form1_Load(object sender, EventArgs e)
        {
            Radius = int.Parse(txtRadius.Text);
        }

        // Add a point to the Points list
        // or stop defining the polygon.
        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Add a point.
                if (!Drawing)
                {
                    // Start a new Points list.
                    Points = new List<PointF>();
                    Points.Add(e.Location);
                    Drawing = true;
                }

                // Add the new point.
                Points.Add(e.Location);
            }
            else
            {
                // If we're not drawing, ignore this click.
                if (!Drawing) return;

                // Remove the last point and finish the polygon.
                Points.RemoveAt(Points.Count - 1);
                Drawing = false;
            }

            // Redraw.
            picCanvas.Refresh();
        }

        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Drawing) return;

            // Update the last point's position.
            Points[Points.Count - 1] = e.Location;

            // Redraw.
            picCanvas.Refresh();
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(picCanvas.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (Drawing && (Points.Count >= 2))
            {
                GraphicsPath path =
                    RoundedPolyline(Points, Radius, false);
                if (path != null)
                {
                    using (Pen pen = new Pen(Color.Red, 3))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            }
            else if (!Drawing && (Points.Count >= 3))
            {
                GraphicsPath path =
                    RoundedPolyline(Points, Radius, true);
                if (path != null)
                {
                    e.Graphics.FillPath(Brushes.LightGreen, path);
                    using (Pen pen = new Pen(Color.Green, 3))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            }

#if SHOW_ADJUSTMENTS
            if (seg1 != null)
            {
                e.Graphics.FillPoint(Brushes.Red, seg1.StartPoint, 5);
                e.Graphics.FillPoint(Brushes.Blue, seg2.StartPoint, 5);

                using (Pen pen = new Pen(Color.Red, 3))
                {
                    e.Graphics.DrawLine(pen, seg1.StartPoint, seg1.EndPoint);
                    pen.Color = Color.Blue;
                    e.Graphics.DrawLine(pen, seg2.StartPoint, seg2.EndPoint);
                }
            }
#endif
        }

        // Redraw with the new radius.
        private void txtRadius_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int new_radius = int.Parse(txtRadius.Text);
                if (new_radius > 0)
                {
                    Radius = new_radius;
                    picCanvas.Refresh();
                }
            }
            catch
            {
            }
        }

        // Copy a list of points into a new list
        // with no adjacent duplicates.
        private List<T> RemoveDuplicates<T>(List<T> original_list)
        {
            // Make the result list.
            List<T> new_list = new List<T>();

            // Keep track of the last item we added.
            // Initially compare the first item with the last one.
            int num_items = original_list.Count;
            T last_item = original_list[num_items - 1];

            // Loop through the items.
            foreach (T item in original_list)
            {
                // If this is not the same as the previous item, add it.
                if (!item.Equals(last_item))
                {
                    new_list.Add(item);
                    last_item = item;
                }
            }

            return new_list;
        }

        // Convert an array of points into a GraphicsPath
        // that connects the points with segments joined
        // by circular arcs.
        private GraphicsPath RoundedPolyline(
            List<PointF> point_list,
            int radius, bool is_closed)
        {
            // Remove adjacent duplicates from the list.
            point_list = RemoveDuplicates(point_list);
            int num_points = point_list.Count;
            if (num_points < 2) return null;

            // Convert into an array.
            PointF[] points = point_list.ToArray();

            // segments[i] is the segment from points[i] to points[i + 1];
            SegmentInfo[] segments = new SegmentInfo[num_points];

            // Initially the segments are the polygon's sides.
            for (int i = 0; i < num_points; i++)
            {
                int j = (i + 1) % num_points;
                segments[i] = new SegmentInfo(points[i], points[j]);
            }

            // arcs[i] is the arc at points[i].
            ArcInfo[] arcs = new ArcInfo[num_points];

            // Get arc and segment info between the points.
            for (int i = 0; i < num_points; i++)
            {
                // Find the arc at points[i].
                int j = i - 1;
                if (j < 0) j += num_points;
                PointF s1p1 = points[j];
                PointF s1p2 = points[i];
                PointF s2p1 = points[(i + 1) % num_points];
                PointF s2p2 = points[i];

                RectangleF rect;
                float start_angle, sweep_angle;
                PointF s1_far, s1_close, s2_far, s2_close;

                // Find the arc.
                if (Arcs.FindArcWithRadius(s1p1, s1p2, s2p1, s2p2, radius,
                    out rect, out start_angle, out sweep_angle,
                    out s1_far, out s1_close, out s2_far, out s2_close))
                {
                    // Save the arc info.
                    arcs[i] = new ArcInfo(rect, start_angle, sweep_angle);

                    // Update the adjacent segment infos.
                    j = i - 1;
                    if (j < 0) j += num_points;
                    segments[j].EndPoint = s1_close;
                    segments[i].StartPoint = s2_close;
                }
            }

#if SHOW_ADJUSTMENTS
            seg1 = new SegmentInfo(points[0], segments[0].StartPoint);
            seg2 = new SegmentInfo(points[num_points - 1], segments[num_points - 2].EndPoint);
#endif

            // If the path should not be closed,
            // reset the first segment's start point
            // and the second-to-last segment's end point.
            if (!is_closed)
            {
                segments[0].StartPoint = points[0];
                segments[num_points - 2].EndPoint =
                    points[num_points - 1];
            }

            // Create the GraphicsPath.
            GraphicsPath path = new GraphicsPath();

            // Add the middle segments and arcs.
            for (int i = 0; i < num_points - 1; i++)
            {
                // Add the arc at points[i].
                if (is_closed || i > 0)
                {
                    path.AddArc(arcs[i].Rect,
                        arcs[i].StartAngle, arcs[i].SweepAngle);
                }

                // Add the segment between points[i] and points[i + 1];
                path.AddLine(segments[i].StartPoint, segments[i].EndPoint);
            }

            // If the path should be closed, add the final arc and segment.
            if (is_closed)
            {
                // Add the final arc.
                path.AddArc(arcs[num_points - 1].Rect,
                    arcs[num_points - 1].StartAngle,
                    arcs[num_points - 1].SweepAngle);

                // Add the final segment;
                path.AddLine(
                    segments[num_points - 1].StartPoint,
                    segments[num_points - 1].EndPoint);

                // Close the path.
                path.CloseFigure();
            }
            return path;
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtRadius = new System.Windows.Forms.TextBox();
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
            this.picCanvas.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picCanvas.Location = new System.Drawing.Point(12, 38);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(260, 211);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseMove);
            this.picCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseClick);
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Radius:";
            // 
            // txtRadius
            // 
            this.txtRadius.Location = new System.Drawing.Point(58, 12);
            this.txtRadius.Name = "txtRadius";
            this.txtRadius.Size = new System.Drawing.Size(35, 20);
            this.txtRadius.TabIndex = 2;
            this.txtRadius.Text = "20";
            this.txtRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRadius.TextChanged += new System.EventHandler(this.txtRadius_TextChanged);
            // 
            // howto_rounded_polygon_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txtRadius);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_rounded_polygon_Form1";
            this.Text = "howto_rounded_polygon";
            this.Load += new System.EventHandler(this.howto_rounded_polygon_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRadius;
    }
}

