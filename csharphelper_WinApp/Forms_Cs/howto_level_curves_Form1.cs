using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Add a reference to PresentationCore.
using System.Windows.Media.Media3D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_level_curves_Form1:Form
  { 


        public howto_level_curves_Form1()
        {
            InitializeComponent();
        }

        // The function delegate.
        private delegate double FofXY(double x, double y);

        // The data.
        private const int Xmax = 10;
        private Point3D[,] Values;
        private double Zmin = double.MaxValue;
        private double Zmax = double.MinValue;

        // Make the data.
        private void MakeData(FofXY func)
        {
            // Make data.
            Values = new Point3D[2 * Xmax + 1, 2 * Xmax + 1];

            Zmin = double.MaxValue;
            Zmax = double.MinValue;
            for (int x = -Xmax; x <= Xmax; x++)
            {
                for (int y = -Xmax; y <= Xmax; y++)
                {
                    double z = func(x, y);

                    // Make the new point.
                    Values[x + Xmax, y + Xmax] = new Point3D(x, y, z);

                    // Update the min and max values.
                    if (Zmin > z) Zmin = z;
                    if (Zmax < z) Zmax = z;
                }
            }

            // Console.WriteLine(zmin.ToString() + " <= z <= " + zmax.ToString());
        }

        // Draw level curves for the function.
        private void DrawLevelCurves()
        {
            // Make the Bitmap.
            Bitmap bm = new Bitmap(picGraph.ClientSize.Width, picGraph.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                // Clear.
                gr.Clear(Color.White);
                gr.ScaleTransform(
                    bm.Width / Xmax / 2,
                    -bm.Height / Xmax / 2,
                    System.Drawing.Drawing2D.MatrixOrder.Append);
                gr.TranslateTransform(bm.Width * 0.5f, bm.Height * 0.5f,
                    System.Drawing.Drawing2D.MatrixOrder.Append);

                // Draw axes.
                using (Pen axis_pen = new Pen(Color.LightGray, 0))
                {
                    gr.DrawLine(axis_pen, -Xmax, 0, Xmax, 0);
                    gr.DrawLine(axis_pen, 0, -Xmax, 0, Xmax);
                    for (int i = -Xmax; i <= Xmax; i++)
                    {
                        gr.DrawLine(axis_pen, i, -0.1f, i, 0.1f);
                        gr.DrawLine(axis_pen, -0.1f, i, 0.1f, i);
                    }
                }

                // Draw level curves.
                double dz = (Zmax - Zmin) / 20;
                for (double z = Zmin; z <= Zmax; z += dz)
                {
                    // Draw this level curve;
                    DrawLevelCurve(gr, Values, z);
                }
            } // using gr.

            // Display the result.
            picGraph.Image = bm;
        }

        // Draw this level curve.
        private void DrawLevelCurve(Graphics gr, Point3D[,] values, double z)
        {
            using (Pen thin_pen = new Pen(Color.Black, 0))
            {
                if (z > 0)
                {
                    thin_pen.Color = Color.Blue;
                }
                else if (z < 0)
                {
                    thin_pen.Color = Color.Red;
                }

                for (int x = 0; x < values.GetUpperBound(0); x++)
                {
                    for (int y = 0; y < values.GetUpperBound(1); y++)
                    {
                        // Intersect this triangle with the level plane.
                        DrawPlaneTriangleIntersections(
                            gr, thin_pen,
                            new Point3D(0, 0, z),
                            new Vector3D(0, 0, 1),
                            values[x, y],
                            values[x, y + 1],
                            values[x + 1, y + 1]);

                        // Intersect this triangle with the level plane.
                        DrawPlaneTriangleIntersections(
                            gr, thin_pen,
                            new Point3D(0, 0, z),
                            new Vector3D(0, 0, 1),
                            values[x, y],
                            values[x + 1, y + 1],
                            values[x + 1, y]);
                    }
                }
            }
        }

        // Draw the line segment of intersection
        // between a triangle and a plane.
        private void DrawPlaneTriangleIntersections(
            Graphics gr, Pen pen,
            Point3D p0, Vector3D N,
            Point3D p1, Point3D p2, Point3D p3)
        {
            List<Point3D> points = new List<Point3D>();
            IntersectPlaneAndTriangle(
                points, p0, N, p1, p2, p3);
            if (points.Count == 2)
            {
                // The triangle intersects the plane.
                gr.DrawLine(pen,
                    (float)points[0].X, (float)points[0].Y,
                    (float)points[1].X, (float)points[1].Y);
            }
            if (points.Count > 2)
            {
                gr.DrawLine(pen,
                    (float)points[0].X, (float)points[0].Y,
                    (float)points[2].X, (float)points[2].Y);
                gr.DrawLine(pen,
                    (float)points[1].X, (float)points[1].Y,
                    (float)points[2].X, (float)points[2].Y);
            }
        }
        
        // Return the line segment of intersection
        // between a triangle and a plane.
        private void IntersectPlaneAndTriangle(
            List<Point3D>points,
            Point3D p0, Vector3D N,
            Point3D p1, Point3D p2, Point3D p3)
        {
            // Find points of intersection between
            // the triangle's edges and the plane.
            IntersectPlaneAndSegment(points, p0, N, p1, p2);
            IntersectPlaneAndSegment(points, p0, N, p2, p3);
            IntersectPlaneAndSegment(points, p0, N, p3, p1);
        }

        // If the plane and line segment intersect, add the
        // points of intersection to points and return true.
        //
        // The equation of the plane is:
        //      N dot (p - p0) = 0
        //
        // The equation of the line is:
        //      p1 + t * <p2 - p1> where 0 <= t <= 1
        //
        // The plane and line intersect where:
        //      t = [N dot <p0 - p1>] / [N dot <p2 - p1>]
        private void IntersectPlaneAndSegment(List<Point3D> points,
            Point3D p0, Vector3D N,
            Point3D p1, Point3D p2)
        {
            // Get the denominator. If it's 0, the plane and line are parallel.
            Vector3D v12 = p2 - p1;
            double denominator = Vector3D.DotProduct(N, v12);
            if (Math.Abs(denominator) < -0.0001) return;

            // Get the numerator.
            Vector3D v10 = p0 - p1;
            double numerator = Vector3D.DotProduct(N, v10);

            // Calculate t and see if the segment intersects the plane.
            double t = numerator / denominator;
            if ((t >= 0) && (t <= 1))
            {
                // The segment intersects the plane at p1 + t * v12.
                points.Add(p1 + t * v12);
            }
        }

        private void radF1_Click(object sender, EventArgs e)
        {
            MakeData(F1);
            DrawLevelCurves();
        }
        private void radF2_Click(object sender, EventArgs e)
        {
            MakeData(F2);
            DrawLevelCurves();
        }
        private void radF3_Click(object sender, EventArgs e)
        {
            MakeData(F3);
            DrawLevelCurves();
        }
        private void radF4_Click(object sender, EventArgs e)
        {
            MakeData(F4);
            DrawLevelCurves();
        }

        // The functions.
        // Bowl.
        private double F1(double x, double y)
        {
            return x * x + (y * 2) * (y * 2) - 600;
        }

        // Monkey saddle.
        private double F2(double x, double y)
        {
            return x * (x * x - 3 * y * y);
        }

        // Crossed trough.
        private double F3(double x, double y)
        {
            return x * x * y * y - 30000;
        }

        // Hemisphere.
        private double F4(double x, double y)
        {
            return Math.Sqrt(400 - (x * x + y * y));
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
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.radF1 = new System.Windows.Forms.RadioButton();
            this.radF2 = new System.Windows.Forms.RadioButton();
            this.radF4 = new System.Windows.Forms.RadioButton();
            this.radF3 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // picGraph
            // 
            this.picGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraph.Location = new System.Drawing.Point(219, 12);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(260, 260);
            this.picGraph.TabIndex = 4;
            this.picGraph.TabStop = false;
            // 
            // radF1
            // 
            this.radF1.AutoSize = true;
            this.radF1.Location = new System.Drawing.Point(12, 12);
            this.radF1.Name = "radF1";
            this.radF1.Size = new System.Drawing.Size(160, 17);
            this.radF1.TabIndex = 5;
            this.radF1.TabStop = true;
            this.radF1.Text = "Bowl: z = x^2 + (y*2)^2 - 200";
            this.radF1.UseVisualStyleBackColor = true;
            this.radF1.Click += new System.EventHandler(this.radF1_Click);
            // 
            // radF2
            // 
            this.radF2.AutoSize = true;
            this.radF2.Location = new System.Drawing.Point(12, 35);
            this.radF2.Name = "radF2";
            this.radF2.Size = new System.Drawing.Size(183, 17);
            this.radF2.TabIndex = 6;
            this.radF2.TabStop = true;
            this.radF2.Text = "Monkey saddle: x * (x^2 - 3 * y^2)";
            this.radF2.UseVisualStyleBackColor = true;
            this.radF2.Click += new System.EventHandler(this.radF2_Click);
            // 
            // radF4
            // 
            this.radF4.AutoSize = true;
            this.radF4.Location = new System.Drawing.Point(12, 81);
            this.radF4.Name = "radF4";
            this.radF4.Size = new System.Drawing.Size(191, 17);
            this.radF4.TabIndex = 8;
            this.radF4.TabStop = true;
            this.radF4.Text = "Hemisphere: Sqrt(400 - (x^2 + y^2))";
            this.radF4.UseVisualStyleBackColor = true;
            this.radF4.Click += new System.EventHandler(this.radF4_Click);
            // 
            // radF3
            // 
            this.radF3.AutoSize = true;
            this.radF3.Location = new System.Drawing.Point(12, 58);
            this.radF3.Name = "radF3";
            this.radF3.Size = new System.Drawing.Size(185, 17);
            this.radF3.TabIndex = 7;
            this.radF3.TabStop = true;
            this.radF3.Text = "Crossed trough: x^2 * y^2 - 30000";
            this.radF3.UseVisualStyleBackColor = true;
            this.radF3.Click += new System.EventHandler(this.radF3_Click);
            // 
            // howto_level_curves_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 284);
            this.Controls.Add(this.radF4);
            this.Controls.Add(this.radF3);
            this.Controls.Add(this.radF2);
            this.Controls.Add(this.radF1);
            this.Controls.Add(this.picGraph);
            this.Name = "howto_level_curves_Form1";
            this.Text = "howto_level_curves";
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.RadioButton radF1;
        private System.Windows.Forms.RadioButton radF2;
        private System.Windows.Forms.RadioButton radF4;
        private System.Windows.Forms.RadioButton radF3;
    }
}

