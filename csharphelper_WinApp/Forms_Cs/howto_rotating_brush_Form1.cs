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
     public partial class howto_rotating_brush_Form1:Form
  { 


        public howto_rotating_brush_Form1()
        {
            InitializeComponent();
        }

        // The polygon's points.
        private PointF[] PolygonPoints;

        // The path.
        private GraphicsPath Path;

        // The rectangle where we will draw.
        private Rectangle DrawingArea;

        // Offset when assigning colors.
        private int ColorOffset = 0;

        // Make points that define a polygon.
        private void howto_rotating_brush_Form1_Load(object sender, EventArgs e)
        {
            // Double buffer to prevent flicker.
            this.DoubleBuffered = true;

            // Make the drawing area rectangle.
            const int margin = 10;
            DrawingArea = new Rectangle(
                margin, margin,
                ClientSize.Width - 2 * margin,
                ClientSize.Height - 2 * margin);

            // Make the polygon's points.
            PolygonPoints = MakePolygon(22, DrawingArea);

            // Make the brush's path.
            Path = new GraphicsPath();
            Path.AddPolygon(DoublePoints(PolygonPoints));
        }

        // Return PointFs to define a polygon.
        private PointF[] MakePolygon(int num_points, Rectangle bounds)
        {
            // Make room for the points.
            PointF[] pts = new PointF[num_points];

            float sqrt2 = (float)Math.Sqrt(2.0);
            float rx = bounds.Width / 2f *sqrt2;
            float ry = bounds.Height / 2f * sqrt2;
            float cx = bounds.X + bounds.Width / 2f;
            float cy = bounds.Y + bounds.Height / 2f;

            // Start at the top.
            float theta = (float)(-Math.PI / 2.0);
            float dtheta = (float)(2.0 * Math.PI / num_points);
            for (int i = 0; i < num_points; i++)
            {
                pts[i] = new PointF(
                    (float)(cx + rx * Math.Cos(theta)),
                    (float)(cy + ry * Math.Sin(theta)));
                theta += dtheta;
            }

            return pts;
        }

        // Insert a point between each of the polygon's points.
        private PointF[] DoublePoints(PointF[] points)
        {
            List<PointF> new_points = new List<PointF>();
            for (int i = 0; i < points.Length - 1; i++)
            {
                new_points.Add(points[i]);
                new_points.Add(PointBetween(points[i], points[i + 1]));
            }
            new_points.Add(points[points.Length - 1]);
            new_points.Add(PointBetween(points[0], points[points.Length - 1]));

            // Return the new points.
            return new_points.ToArray();
        }

        // Return a point between two points.
        private PointF PointBetween(PointF point1, PointF point2)
        {
            return new PointF(
                (point1.X + point2.X) / 2,
                (point1.Y + point2.Y) / 2);
        }

        // Draw the polygon.
        private void howto_rotating_brush_Form1_Paint(object sender, PaintEventArgs e)
        {
            // Make a path gradient brush.
            using (PathGradientBrush br = new PathGradientBrush(Path))
            {
                // Define edge colors.
                Color[] edge_colors = new Color[PolygonPoints.Length * 2];
                Color[] color_series = new Color[]
                {
                    Color.Green,
                    Color.LightGreen,
                    Color.White,
                    Color.LightGreen,
                };
                for (int i = 0; i < edge_colors.Length; i++)
                    edge_colors[i] =
                        color_series[(i + ColorOffset) % color_series.Length];
                br.SurroundColors = edge_colors;
                br.CenterColor = Color.White;
                ColorOffset++;

                // Fill the polygon.
                //e.Graphics.FillPolygon(br, PolygonPoints);
                e.Graphics.FillRectangle(br, DrawingArea);

                // Draw text over the background.
                using (Font font = new Font("Times New Roman", 50, FontStyle.Bold))
                {
                    using (StringFormat sf = new StringFormat())
                    {
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        e.Graphics.DrawString("C# Helper", font,
                            Brushes.Blue, DrawingArea, sf);
                    }
                }
            }
        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            this.Refresh();
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
            this.components = new System.ComponentModel.Container();
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Enabled = true;
            this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // howto_rotating_brush_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 186);
            this.Name = "howto_rotating_brush_Form1";
            this.Text = "howto_rotating_brush";
            this.Load += new System.EventHandler(this.howto_rotating_brush_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_rotating_brush_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrRefresh;
    }
}

