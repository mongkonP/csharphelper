using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

using howto_3d_pie_slices;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_3d_pie_slices_Form1:Form
  { 


        public howto_3d_pie_slices_Form1()
        {
            InitializeComponent();
        }

        // Represents a pie slice.
        private struct Slice : IComparable
        {
            public Brush TopBrush, SideBrush;
            public Pen TopPen;
            public float StartAngle, SweepAngle, ExplodeDistance;
            public float ZDistance
            {
                get
                {
                    // Right half of the ellipse.
                    if (StartAngle <= 90)
                    {
                        if (StartAngle + SweepAngle > 90)
                        {
                            // It spans the bottom of the
                            // ellipse so should be last.
                            return 181;
                        }
                        return 90 + StartAngle + SweepAngle;
                    }

                    // Left half of the ellipse.
                    return 270 - StartAngle;
                }
            }

            #region IComparable Members

            // Compare by ZDistance.
            public int CompareTo(object obj)
            {
                Slice other = (Slice)obj;
                return ZDistance.CompareTo(other.ZDistance);
            }

            #endregion
        }

        // Colors.
        private Color[] TopColors =
        {
            Color.FromArgb(255, 128, 128),
            Color.FromArgb(128, 255, 128),
            Color.Red,
            Color.FromArgb(128, 128, 255),
            Color.Orange,
            Color.FromArgb(255, 255, 128),
            Color.Blue,
            Color.FromArgb(128, 255, 255),
            Color.FromArgb(255, 128, 255),
            Color.Yellow,
        };
        private Brush[] TopBrushes;
        private Pen[] TopPens;
        private Brush[] SideBrushes;

        // The data values.
        private const int NumSlices = 10;
        private float[] Values = new float[NumSlices];

        // The slice data.
        private Slice[] Slices = new Slice[NumSlices];

        // Make some random data.
        private void howto_3d_pie_slices_Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            ResizeRedraw = true;

            // Make the random data.
            Random rand = new Random();
            for (int i = 0; i < Values.Length; i++)
            {
                Values[i] = rand.Next(1, 5);
            }

            // Make the pens and brushes.
            TopBrushes = new Brush[TopColors.Length];
            SideBrushes = new Brush[TopColors.Length];
            TopPens = new Pen[TopColors.Length];
            for (int i = 0; i < TopColors.Length; i++)
            {
                TopBrushes[i] = new SolidBrush(TopColors[i]);
                TopPens[i] = new Pen(TopColors[i]);
                Color side_color = Color.FromArgb(
                    TopColors[i].R / 2,
                    TopColors[i].G / 2,
                    TopColors[i].B / 2);
                SideBrushes[i] = new SolidBrush(side_color);
            }

            // Calculate slice drawing information.
            Slices = new Slice[Values.Length];
            float total = Values.Sum();
            float start_angle = -90;
            for (int i = 0; i < Values.Length; i++)
            {
                Slices[i].TopBrush = TopBrushes[i % TopBrushes.Length];
                Slices[i].TopPen = TopPens[i % TopPens.Length];
                Slices[i].SideBrush = SideBrushes[i % SideBrushes.Length];

                if ((i == 2) || (i == 7))
                    Slices[i].ExplodeDistance = 20;

                Slices[i].StartAngle = start_angle;
                Slices[i].SweepAngle = 360f * Values[i] / total;

                start_angle += Slices[i].SweepAngle;
            }

            // Sort by ZDistance.
            Array.Sort(Slices);
        }

        // Draw.
        private void howto_3d_pie_slices_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            PointF offset_3d = new PointF(0, 20);
            RectangleF rect = new RectangleF(30, 30,
                ClientSize.Width - 60 - offset_3d.X,
                ClientSize.Height - 60 - offset_3d.Y);

            // Draw the pie slices in sorted order.
            foreach (Slice slice in Slices)
            {
                PieSlice3D(e.Graphics,
                    slice.TopBrush, slice.TopPen, slice.SideBrush,
                    offset_3d, slice.ExplodeDistance, rect,
                    slice.StartAngle, slice.SweepAngle);
            }
        }

        // Draw a 3-D pie slice.
        private void PieSlice3D(Graphics gr, Brush top_brush, Pen top_pen,
            Brush side_brush, PointF offset_3d, float explode_distance,
            RectangleF rect, float start_angle, float sweep_angle)
        {
            // Calculate the explode offset.
            double explode_angle = (start_angle + sweep_angle / 2f) * Math.PI / 180f;
            float dx = explode_distance * (float)Math.Cos(explode_angle);
            float dy = explode_distance * (float)Math.Sin(explode_angle);

            // Create the top of the side.
            RectangleF top_rect = new RectangleF(
                rect.X + dx, rect.Y + dy,
                rect.Width, rect.Height);
            GraphicsPath path = new GraphicsPath();
            path.AddPie(top_rect, start_angle, sweep_angle);

            // Create the bottom of the side.
            RectangleF bottom_rect = new RectangleF(
                top_rect.X + offset_3d.X,
                top_rect.Y + offset_3d.Y,
                rect.Width, rect.Height);
            path.AddPie(bottom_rect, start_angle, sweep_angle);

            // Convert the GraphicsPath into a list of points.
            path.Flatten();
            PointF[] path_points = path.PathPoints;
            List<PointF> points_list = new List<PointF>(path_points);

            // Make a convex hull.
            List<PointF> hull_points = Geometry.MakeConvexHull(points_list);

            // Fill the convex hull.
            gr.FillPolygon(side_brush, hull_points.ToArray());

            // Draw the top.
            gr.FillPie(top_brush, top_rect, start_angle, sweep_angle);
            gr.DrawPie(top_pen, top_rect, start_angle, sweep_angle);
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
            // howto_3d_pie_slices_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 227);
            this.Name = "howto_3d_pie_slices_Form1";
            this.Text = "howto_3d_pie_slices";
            this.Load += new System.EventHandler(this.howto_3d_pie_slices_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_3d_pie_slices_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

