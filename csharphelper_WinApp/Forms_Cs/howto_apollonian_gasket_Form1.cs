using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Diagnostics;

 

using howto_apollonian_gasket;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_apollonian_gasket_Form1:Form
  { 


        public howto_apollonian_gasket_Form1()
        {
            InitializeComponent();
        }

        // Display the packing.
        private void howto_apollonian_gasket_Form1_Load(object sender, EventArgs e)
        {
            MakeImage();
        }
        private void picPacking_SizeChanged(object sender, EventArgs e)
        {
            MakeImage();
        }
        private void MakeImage()
        {
            int width = Math.Min(
                picPacking.ClientSize.Width,
                picPacking.ClientSize.Height);
            picPacking.Image = FindApollonianPacking(width);
        }

        // Find the Apollonian packing.
        private Bitmap FindApollonianPacking(int width)
        {
            Bitmap bm = new Bitmap(width, width);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.Clear(Color.LightGreen);

                // Create the three central tangent circles.
                float radius = width * 0.225f;
                float x = width / 2;
                float gasket_height = 2 * (float)(radius + 2 * radius / Math.Sqrt(3));
                float y = (width - gasket_height) / 2 + radius;
                Circle circle0 = new Circle(x, y, radius);

                // Draw a box around the gasket. (For debugging.)
                //gr.DrawRectangle(Pens.Orange,
                //    x - gasket_height / 2,
                //    y - radius,
                //    gasket_height,
                //    gasket_height);

                x -= radius;
                y += (float)(radius * Math.Sqrt(3));
                Circle circle1 = new Circle(x, y, radius);
                x += 2 * radius;
                Circle circle2 = new Circle(x, y, radius);

                // Draw the three central circles.
                circle0.Draw(gr, Pens.Blue);
                circle1.Draw(gr, Pens.Blue);
                circle2.Draw(gr, Pens.Blue);

                // Find the circle that contains them all.
                Circle big_circle = FindApollonianCircle(circle0, circle1, circle2, -1, -1, -1);
                big_circle.Draw(gr, Pens.Blue);

                // Set level to smaller values such as 3 to see partially drawn gaskets.
                int level = 10000;

                // Find the central circle.
                FindCircleOutsideAll(level, gr, circle0, circle1, circle2);

                // Find circles tangent to the big circle.
                FindCircleOutsideTwo(level, gr, circle0, circle1, big_circle);
                FindCircleOutsideTwo(level, gr, circle1, circle2, big_circle);
                FindCircleOutsideTwo(level, gr, circle2, circle0, big_circle);
            }
            return bm;
        }

        // Draw a circle tangent to these three circles and that is outside all three.
        private void FindCircleOutsideAll(int level, Graphics gr, Circle circle0, Circle circle1, Circle circle2)
        {
            Circle new_circle = FindApollonianCircle(circle0, circle1, circle2, 1, 1, 1);
            if (new_circle == null) return;
            if (new_circle.Radius < 0.1) return;

            new_circle.Draw(gr, Pens.Blue);

            if (--level > 0)
            {
                FindCircleOutsideAll(level, gr, circle0, circle1, new_circle);
                FindCircleOutsideAll(level, gr, circle0, circle2, new_circle);
                FindCircleOutsideAll(level, gr, circle1, circle2, new_circle);
            }
        }

        // Draw a circle tangent to these three circles and that is outside two of them.
        private void FindCircleOutsideTwo(int level, Graphics gr, Circle circle0, Circle circle1, Circle circle_contains)
        {
            Circle new_circle = FindApollonianCircle(circle0, circle1, circle_contains, 1, 1, -1);
            if (new_circle == null) return;
            if (new_circle.Radius < 0.1) return;

            new_circle.Draw(gr, Pens.Blue);

            if (--level > 0)
            {
                FindCircleOutsideTwo(level, gr, new_circle, circle0, circle_contains);
                FindCircleOutsideTwo(level, gr, new_circle, circle1, circle_contains);
                FindCircleOutsideAll(level, gr, circle0, circle1, new_circle);
            }
        }

        // Find the circles that touch each of the three input circles.
        private Circle[] FindApollonianCircles(Circle[] given_circles)
        {
            // Make a list for results.
            List<Circle> solution_circles = new List<Circle>();

            // Loop over all of the signs.
            foreach (int s0 in new int[] { -1, 1 })
            {
                foreach (int s1 in new int[] { -1, 1 })
                {
                    foreach (int s2 in new int[] { -1, 1 })
                    {
                        Circle new_circle = FindApollonianCircle(
                            given_circles[0], given_circles[1], given_circles[2],
                            s0, s1, s2);
                        if (new_circle != null) solution_circles.Add(new_circle);
                    }
                }
            }

            // Return the results.
            return solution_circles.ToArray();
        }

        // Find a solution to Apollonius' problem.
        // For discussion and method, see:
        //    http://mathworld.wolfram.com/ApolloniusProblem.html
        //    http://en.wikipedia.org/wiki/Problem_of_Apollonius#Algebraic_solutions
        // For most of a Java code implementation, see:
        //    http://www.diku.dk/hjemmesider/ansatte/rfonseca/implementations/apollonius.html
        private Circle FindApollonianCircle(Circle c1, Circle c2, Circle c3, int s1, int s2, int s3)
        {
            // Make sure c2 doesn't have the same X or Y coordinate as the others.
            const float tiny = 0.0001f;
            if ((Math.Abs(c2.Center.X - c1.Center.X) < tiny) ||
                (Math.Abs(c2.Center.Y - c1.Center.Y) < tiny))
            {
                Circle temp_circle = c2;
                c2 = c3;
                c3 = temp_circle;
                int temp_s = s2;
                s2 = s3;
                s3 = temp_s;
            }
            if ((Math.Abs(c2.Center.X - c3.Center.X) < tiny) ||
                (Math.Abs(c2.Center.Y - c3.Center.Y) < tiny))
            {
                Circle temp_circle = c2;
                c2 = c1;
                c1 = temp_circle;
                int temp_s = s2;
                s2 = s1;
                s1 = temp_s;
            }
            Debug.Assert(
                (c2.Center.X != c1.Center.X) && (c2.Center.Y != c1.Center.Y) &&
                (c2.Center.X != c3.Center.X) && (c2.Center.Y != c3.Center.Y),
                "Cannot find points without matching coordinates.");

            float x1 = c1.Center.X;
            float y1 = c1.Center.Y;
            float r1 = c1.Radius;
            float x2 = c2.Center.X;
            float y2 = c2.Center.Y;
            float r2 = c2.Radius;
            float x3 = c3.Center.X;
            float y3 = c3.Center.Y;
            float r3 = c3.Radius;

            float v11 = 2 * x2 - 2 * x1;
            float v12 = 2 * y2 - 2 * y1;
            float v13 = x1 * x1 - x2 * x2 + y1 * y1 - y2 * y2 - r1 * r1 + r2 * r2;
            float v14 = 2 * s2 * r2 - 2 * s1 * r1;

            float v21 = 2 * x3 - 2 * x2;
            float v22 = 2 * y3 - 2 * y2;
            float v23 = x2 * x2 - x3 * x3 + y2 * y2 - y3 * y3 - r2 * r2 + r3 * r3;
            float v24 = 2 * s3 * r3 - 2 * s2 * r2;

            float w12 = v12 / v11;
            float w13 = v13 / v11;
            float w14 = v14 / v11;

            float w22 = v22 / v21 - w12;
            float w23 = v23 / v21 - w13;
            float w24 = v24 / v21 - w14;

            float P = -w23 / w22;
            float Q = w24 / w22;
            float M = -w12 * P - w13;
            float N = w14 - w12 * Q;

            float a = N * N + Q * Q - 1;
            float b = 2 * M * N - 2 * N * x1 + 2 * P * Q - 2 * Q * y1 + 2 * s1 * r1;
            float c = x1 * x1 + M * M - 2 * M * x1 + P * P + y1 * y1 - 2 * P * y1 - r1 * r1;

            // Find roots of a quadratic equation
            double[] solutions = QuadraticSolutions(a, b, c);
            if (solutions.Length < 1) return null;
            float rs = (float)solutions[0];
            float xs = M + N * rs;
            float ys = P + Q * rs;

            Debug.Assert(!float.IsNaN(rs) && !float.IsNaN(xs) && !float.IsNaN(ys),
                "Error finding Apollonian circle.");

            if ((Math.Abs(xs) < tiny) || (Math.Abs(ys) < tiny) || (Math.Abs(rs) < tiny)) return null;
            return new Circle(xs, ys, rs);
        }

        // Return solutions to a quadratic equation.
        private double[] QuadraticSolutions(double a, double b, double c)
        {
            const double tiny = 0.000001;
            double discriminant = b * b - 4 * a * c;

            // See if there are no real solutions.
            if (discriminant < 0)
            {
                return new double[] { };
            }

            // See if there is one solution.
            if (discriminant < tiny)
            {
                return new double[] { -b / (2 * a) };
            }

            // There are two solutions.
            return new double[]
            {
                (-b + Math.Sqrt(discriminant)) / (2 * a),
                (-b - Math.Sqrt(discriminant)) / (2 * a),
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
            this.picPacking = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPacking)).BeginInit();
            this.SuspendLayout();
            // 
            // picPacking
            // 
            this.picPacking.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picPacking.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPacking.Location = new System.Drawing.Point(12, 12);
            this.picPacking.Name = "picPacking";
            this.picPacking.Size = new System.Drawing.Size(360, 360);
            this.picPacking.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picPacking.TabIndex = 2;
            this.picPacking.TabStop = false;
            this.picPacking.SizeChanged += new System.EventHandler(this.picPacking_SizeChanged);
            // 
            // howto_apollonian_gasket_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 384);
            this.Controls.Add(this.picPacking);
            this.Name = "howto_apollonian_gasket_Form1";
            this.Text = "howto_apollonian_gasket";
            this.Load += new System.EventHandler(this.howto_apollonian_gasket_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPacking)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picPacking;
    }
}

