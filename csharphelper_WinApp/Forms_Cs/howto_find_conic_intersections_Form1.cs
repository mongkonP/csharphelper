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

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_find_conic_intersections_Form1:Form
  { 


        public howto_find_conic_intersections_Form1()
        {
            InitializeComponent();
        }

        // The selected points that determine the conic sections.
        private List<PointF>[] Points =
        {
            new List<PointF>(),
            new List<PointF>(),
        };

        // A value close to 0.
        private const float small = 0.1f;

        // The conic sections' parameters.
        private float[] A = new float[2];
        private float[] B = new float[2];
        private float[] C = new float[2];
        private float[] D = new float[2];
        private float[] E = new float[2];
        private float[] F = new float[2];

        // The points of intersection.
        private List<PointF> PointsOfIntersection = new List<PointF>();

        // Save a point.
        private void picGraph_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                SavePoint(0, e.Location);
            else
                SavePoint(1, e.Location);
        }

        // Save a point.
        private void SavePoint(int conic_num, Point location)
        {
            // If we already had 5 points, start a new list.
            if (Points[conic_num].Count == 5) Points[conic_num] = new List<PointF>();

            // Save the point.
            Points[conic_num].Add(location);

            // If we now have 5 points, find the conic section.
            if (Points[conic_num].Count == 5)
            {
                // Find the conic section.
                FindConicSection(Points[conic_num],
                    out A[conic_num], out B[conic_num], out C[conic_num], out D[conic_num], out E[conic_num], out F[conic_num]);

                float min = Math.Abs(A[conic_num]);
                min = Math.Min(min, Math.Abs(B[conic_num]));
                min = Math.Min(min, Math.Abs(C[conic_num]));
                min = Math.Min(min, Math.Abs(D[conic_num]));
                min = Math.Min(min, Math.Abs(E[conic_num]));
                min = Math.Min(min, Math.Abs(F[conic_num]));
                float scale = 1 / min;
                A[conic_num] *= scale;
                B[conic_num] *= scale;
                C[conic_num] *= scale;
                D[conic_num] *= scale;
                E[conic_num] *= scale;
                F[conic_num] *= scale;

                // Display the parameters.
                Console.WriteLine("A[" + conic_num + "]: " + A[conic_num]);
                Console.WriteLine("B[" + conic_num + "]: " + B[conic_num]);
                Console.WriteLine("C[" + conic_num + "]: " + C[conic_num]);
                Console.WriteLine("D[" + conic_num + "]: " + D[conic_num]);
                Console.WriteLine("E[" + conic_num + "]: " + E[conic_num]);
                Console.WriteLine("F[" + conic_num + "]: " + F[conic_num]);

                // Calculate the determinant.
                const float tiny = 0.00001f;
                float determinant = B[conic_num] * B[conic_num] - 4 * A[conic_num] * C[conic_num];
                Console.WriteLine("Det: " + determinant);
                if (Math.Abs(determinant) < tiny) Console.WriteLine("Parabola");
                else if (determinant < 0)
                {
                    if ((Math.Abs(A[conic_num]) < tiny) && (Math.Abs(B[conic_num]) < tiny))
                        Console.WriteLine("Circle");
                    else
                        Console.WriteLine("Ellipse");
                }
                else
                {
                    if (Math.Abs(A[conic_num] + C[conic_num]) < tiny)
                        Console.WriteLine("Rectangular hyperbola");
                    else
                        Console.WriteLine("Hyperbola");
                }
            }

            // Find the points of intersection.
            PointsOfIntersection = new List<PointF>();
            if ((Points[0].Count == 5) && (Points[1].Count == 5))
            {
                FindPointsOfIntersection(0, picGraph.ClientSize.Width);
            }

            // Redraw.
            DrawGraph();
        }

        // Find the conic section.
        private void FindConicSection(List<PointF> points,
            out float A, out float B, out float C,
            out float D, out float E, out float F)
        {
            const int num_rows = 5;
            const int num_cols = 5;

            // Build the augmented matrix.
            float[,] arr = new float[num_rows, num_cols + 2];
            for (int row = 0; row < num_rows; row++)
            {
                arr[row, 0] = points[row].X * points[row].X;
                arr[row, 1] = points[row].X * points[row].Y;
                arr[row, 2] = points[row].Y * points[row].Y;
                arr[row, 3] = points[row].X;
                arr[row, 4] = points[row].Y;
                arr[row, 5] = -1;
                arr[row, 6] = 0;
            }
            Console.WriteLine("    Initial Array:");
            PrintArray(arr);

            // Perform Gaussian elmination.
            const float tiny = 0.001f;
            for (int r = 0; r < num_rows - 1; r++)
            {
                // Zero out all entries in column r after this row.
                // See if this row has a non-zero entry in column r.
                if (Math.Abs(arr[r, r]) < tiny)
                {
                    // Too close to zero. Try to swap with a later row.
                    for (int r2 = r + 1; r2 < num_rows; r2++)
                    {
                        if (Math.Abs(arr[r2, r]) > tiny)
                        {
                            // This row will work. Swap them.
                            for (int c = 0; c <= num_cols; c++)
                            {
                                float tmp = arr[r, c];
                                arr[r, c] = arr[r2, c];
                                arr[r2, c] = tmp;
                            }
                            break;
                        }
                    }
                }

                // If this row has a non-zero entry in column r, use it.
                if (Math.Abs(arr[r, r]) > tiny)
                {
                    // Zero out this column in later rows.
                    for (int r2 = r + 1; r2 < num_rows; r2++)
                    {
                        float factor = -arr[r2, r] / arr[r, r];
                        for (int c = r; c <= num_cols; c++)
                        {
                            arr[r2, c] = arr[r2, c] + factor * arr[r, c];
                        }
                    }
                }
                Console.WriteLine("    After eliminating column " + r + ":");
                PrintArray(arr);
            }
            Console.WriteLine("    After elimination:");
            PrintArray(arr);

            // See if we have a solution.
            if (arr[num_rows - 1, num_cols - 1] == 0)
            {
                // We have no solution.
                // See if all of the entries in this row are 0.
                bool all_zeros = true;
                for (int c = 0; c <= num_cols + 1; c++)
                {
                    if (arr[num_rows - 1, c] != 0)
                    {
                        all_zeros = false;
                        break;
                    }
                }
                if (all_zeros)
                {
                    MessageBox.Show("The solution is not unique");
                }
                else
                {
                    MessageBox.Show("There is no solution");
                }
                A = 0;
                B = 0;
                C = 0;
                D = 0;
                E = 0;
                F = 0;
            }
            else
            {
                // Backsolve.
                for (int r = num_rows - 1; r >= 0; r--)
                {
                    float tmp = arr[r, num_cols];
                    for (int r2 = r + 1; r2 < num_rows; r2++)
                    {
                        tmp -= arr[r, r2] * arr[r2, num_cols + 1];
                    }
                    arr[r, num_cols + 1] = tmp / arr[r, r];
                }

                // Save the results.
                A = arr[0, num_cols + 1];
                B = arr[1, num_cols + 1];
                C = arr[2, num_cols + 1];
                D = arr[3, num_cols + 1];
                E = arr[4, num_cols + 1];
                F = 1;
            }
            Console.WriteLine("    After backsolving:");
            PrintArray(arr);
        }

        // Draw the conic section.
        private void howto_find_conic_intersections_Form1_Resize(object sender, EventArgs e)
        {
            DrawGraph();
        }

        // Draw the conic section.
        private void DrawGraph()
        {
            const float radius = 4;

            Bitmap bm = new Bitmap(
                picGraph.ClientSize.Width,
                picGraph.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(picGraph.BackColor);
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                Pen[] curve_pen = { Pens.Blue, Pens.Green };
                for (int i = 0; i < 2; i++)
                {
                    // If we have 5 points, draw the conic section.
                    if (Points[i].Count == 5)
                        DrawConicSection(gr, curve_pen[i],
                            A[i], B[i], C[i], D[i], E[i], F[i]);
                    else
                    {
                        // Draw the points.
                        foreach (PointF pt in Points[i])
                        {
                            gr.DrawEllipse(curve_pen[i],
                                pt.X - radius, pt.Y - radius,
                                2 * radius, 2 * radius);
                        }
                    }
                }

                // Draw the points of intersection.
                foreach (PointF pt in PointsOfIntersection)
                {
                    RectangleF rect = new RectangleF(
                        pt.X - radius, pt.Y - radius,
                        2 * radius, 2 * radius);
                    gr.DrawEllipse(Pens.Red, rect);
                }
            }

            // Display the result.
            picGraph.Image = bm;
        }

        // Draw the conic section.
        private void DrawConicSection(Graphics gr, Pen pen,
            float A, float B, float C, float D, float E, float F)
        {
            // Get the X coordinate bounds.
            float xmin = 0;
            float xmax = xmin + picGraph.ClientSize.Width;

            // Find the smallest X coordinate with a real value.
            for (float x = xmin; x < xmax; x++)
            {
                float y = G1(x, A, B, C, D, E, F, -1f);
                if (IsNumber(y))
                {
                    xmin = x;
                    break;
                }
            }

            // Find the largest X coordinate with a real value.
            for (float x = xmax; x > xmin; x--)
            {
                float y = G1(x, A, B, C, D, E, F, -1f);
                if (IsNumber(y))
                {
                    xmax = x;
                    break;
                }
            }

            // Get points for the negative root on the left.
            List<PointF> ln_points = new List<PointF>();
            float xmid1 = xmax;
            for (float x = xmin; x < xmax; x++)
            {
                float y = G1(x, A, B, C, D, E, F, -1f);
                if (!IsNumber(y))
                {
                    xmid1 = x - 1;
                    break;
                }
                ln_points.Add(new PointF(x, y));
            }

            // Get points for the positive root on the left.
            List<PointF> lp_points = new List<PointF>();
            for (float x = xmid1; x >= xmin; x--)
            {
                float y = G1(x, A, B, C, D, E, F, +1f);
                if (IsNumber(y)) lp_points.Add(new PointF(x, y));
            }

            // Make the curves on the right if needed.
            List<PointF> rp_points = new List<PointF>();
            List<PointF> rn_points = new List<PointF>();
            float xmid2 = xmax;
            if (xmid1 < xmax)
            {
                // Get points for the positive root on the right.
                for (float x = xmax; x > xmid1; x--)
                {
                    float y = G1(x, A, B, C, D, E, F, +1f);
                    if (!IsNumber(y))
                    {
                        xmid2 = x + 1;
                        break;
                    }
                    rp_points.Add(new PointF(x, y));
                }

                // Get points for the negative root on the right.
                for (float x = xmid2; x <= xmax; x++)
                {
                    float y = G1(x, A, B, C, D, E, F, -1f);
                    if (IsNumber(y)) rn_points.Add(new PointF(x, y));
                }
            }

            // Connect curves if appropriate.
            // Connect the left curves on the left.
            if (xmin > 0) lp_points.Add(ln_points[0]);

            // Connect the left curves on the right.
            if (xmid1 < picGraph.ClientSize.Width) ln_points.Add(lp_points[0]);

            // Make sure we have the right curves.
            if (rp_points.Count > 0)
            {
                // Connect the right curves on the left.
                rp_points.Add(rn_points[0]);

                // Connect the right curves on the right.
                if (xmax < picGraph.ClientSize.Width) rn_points.Add(rp_points[0]);
            }

            // Draw the curves.
            if (ln_points.Count > 1)
                gr.DrawLines(pen, ln_points.ToArray());

            if (lp_points.Count > 1)
                gr.DrawLines(pen, lp_points.ToArray());

            if (rp_points.Count > 1)
                gr.DrawLines(pen, rp_points.ToArray());

            if (rn_points.Count > 1)
                gr.DrawLines(pen, rn_points.ToArray());
        }

        // Calculate G1(x).
        // root_sign is -1 or 1.
        private float G1(float x, float A, float B, float C, float D, float E, float F, float root_sign)
        {
            float result = B * x + E;
            result = result * result;
            result = result - 4 * C * (A * x * x + D * x + F);
            result = root_sign * (float)Math.Sqrt(result);
            result = -(B * x + E) + result;
            result = result / 2 / C;

            return result;
        }

        // Calculate G1'(x).
        // root_sign is -1 or 1.
        private float G1Prime(float x, float A, float B, float C, float D, float E, float F, float root_sign)
        {
            float numerator = 2 * (B * x + E) * B -
                4 * C * (2 * A * x + D);
            float denominator = 2 * (float)Math.Sqrt(
                (B * x + E) * (B * x + E) -
                4 * C * (A * x * x + D * x + F));
            float result = -B + root_sign * numerator / denominator;
            result = result / 2 / C;

            return result;
        }

        // Calculate G(x).
        private float G(float x,
            float A1, float B1, float C1, float D1, float E1, float F1, float sign1,
            float A2, float B2, float C2, float D2, float E2, float F2, float sign2)
        {
            return
                G1(x, A1, B1, C1, D1, E1, F1, sign1) -
                G1(x, A2, B2, C2, D2, E2, F2, sign2);
        }

        // Calculate G'(x).
        private float GPrime(float x,
            float A1, float B1, float C1, float D1, float E1, float F1, float sign1,
            float A2, float B2, float C2, float D2, float E2, float F2, float sign2)
        {
            return
                G1Prime(x, A1, B1, C1, D1, E1, F1, sign1) -
                G1Prime(x, A2, B2, C2, D2, E2, F2, sign2);
        }

        // Return true if the number is not infinity or NaN.
        private bool IsNumber(float number)
        {
            return !(float.IsNaN(number) || float.IsInfinity(number));
        }

        // Display the array's values in the Console window.
        private void PrintArray<T>(T[,] arr)
        {
            for (int r = arr.GetLowerBound(0); r <= arr.GetUpperBound(0); r++)
            {
                for (int c = arr.GetLowerBound(1); c <= arr.GetUpperBound(1); c++)
                {
                    Console.Write(arr[r, c] + "\t");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        // Find the points of intersection.
        private void FindPointsOfIntersection(float xmin, float xmax)
        {
            List<PointF> Roots = new List<PointF>();
            List<float> RootSign1 = new List<float>();
            List<float> RootSign2 = new List<float>();

            Roots = new List<PointF>();
            RootSign1 = new List<float>();
            RootSign2 = new List<float>();

            // Find roots for each of the difference equations.
            float[] signs = { +1f, -1f };
            foreach (float sign1 in signs)
            {
                foreach (float sign2 in signs)
                {
                    List<PointF> points = FindRootsUsingBinaryDivision(
                        xmin, xmax,
                        A[0], B[0], C[0], D[0], E[0], F[0], sign1,
                        A[1], B[1], C[1], D[1], E[1], F[1], sign2);
                    if (points.Count > 0)
                    {
                        Roots.AddRange(points);
                        for (int i = 0; i < points.Count; i++)
                        {
                            RootSign1.Add(sign1);
                            RootSign2.Add(sign2);
                        }
                    }
                }
            }

            // Find corresponding points of intersection.
            PointsOfIntersection = new List<PointF>();
            for (int i = 0; i < Roots.Count; i++)
            {
                float y1 = G1(Roots[i].X, A[0], B[0], C[0], D[0], E[0], F[0], RootSign1[i]);
                float y2 = G1(Roots[i].X, A[1], B[1], C[1], D[1], E[1], F[1], RootSign2[i]);
                PointsOfIntersection.Add(new PointF(Roots[i].X, y1));

                // Validation.
                Debug.Assert(Math.Abs(y1 - y2) < small);
            }
        }

        // Find roots by using binary division.
        private List<PointF> FindRootsUsingBinaryDivision(float xmin, float xmax,
            float A1, float B1, float C1, float D1, float E1, float F1, float sign1,
            float A2, float B2, float C2, float D2, float E2, float F2, float sign2)
        {
            List<PointF> roots = new List<PointF>();
            const int num_tests = 100;
            float delta_x = (xmax - xmin) / (num_tests - 1);

            // Loop over the possible x values looking for roots.
            float x0 = xmin;
            float x, y;
            for (int i = 0; i < num_tests; i++)
            {
                // Try to find a root in this range.
                UseBinaryDivision(x0, delta_x, out x, out y,
                    A1, B1, C1, D1, E1, F1, sign1,
                    A2, B2, C2, D2, E2, F2, sign2);

                // See if we have already found this root.
                if (IsNumber(y))
                {
                    bool is_new = true;
                    foreach (PointF pt in roots)
                    {
                        if (Math.Abs(pt.X - x) < small)
                        {
                            is_new = false;
                            break;
                        }
                    }

                    // If this is a new point, save it.
                    if (is_new)
                    {
                        roots.Add(new PointF(x, y));

                        // If we've found two roots, we won't find any more.
                        if (roots.Count > 1) return roots;
                    }
                }

                x0 += delta_x;
            }

            return roots;
        }

        // Find a root by using binary division.
        private void UseBinaryDivision(float x0, float delta_x,
            out float x, out float y,
            float A1, float B1, float C1, float D1, float E1, float F1, float sign1,
            float A2, float B2, float C2, float D2, float E2, float F2, float sign2)
        {
            const int num_trials = 200;
            const int sgn_nan = -2;

            // Get G(x) for the bounds.
            float xmin = x0;
            float g_xmin = G(xmin,
                A1, B1, C1, D1, E1, F1, sign1,
                A2, B2, C2, D2, E2, F2, sign2);
            if (Math.Abs(g_xmin) < small)
            {
                x = xmin;
                y = g_xmin;
                return;
            }

            float xmax = xmin + delta_x;
            float g_xmax = G(xmax,
                A1, B1, C1, D1, E1, F1, sign1,
                A2, B2, C2, D2, E2, F2, sign2);
            if (Math.Abs(g_xmax) < small)
            {
                x = xmax;
                y = g_xmax;
                return;
            }

            // Get the sign of the values.
            int sgn_min, sgn_max;
            if (IsNumber(g_xmin)) sgn_min = Math.Sign(g_xmin);
            else sgn_min = sgn_nan;
            if (IsNumber(g_xmax)) sgn_max = Math.Sign(g_xmax);
            else sgn_max = sgn_nan;

            // If the two values have the same sign,
            // then there is no root here.
            if (sgn_min == sgn_max)
            {
                x = 1;
                y = float.NaN;
                return;
            }

            // Use binary division to find the point of intersection.
            float xmid = 0, g_xmid = 0;
            int sgn_mid = 0;
            for (int i = 0; i < num_trials; i++)
            {
                // Get values for the midpoint.
                xmid = (xmin + xmax) / 2;
                g_xmid = G(xmid,
                    A1, B1, C1, D1, E1, F1, sign1,
                    A2, B2, C2, D2, E2, F2, sign2);
                if (IsNumber(g_xmid)) sgn_mid = Math.Sign(g_xmid);
                else sgn_mid = sgn_nan;

                // If sgn_mid is 0, gxmid is 0 so this is the root.
                if (sgn_mid == 0) break;

                // See which half contains the root.
                if (sgn_mid == sgn_min)
                {
                    // The min and mid values have the same sign.
                    // Search the right half.
                    xmin = xmid;
                    g_xmin = g_xmid;
                }
                else if (sgn_mid == sgn_max)
                {
                    // The max and mid values have the same sign.
                    // Search the left half.
                    xmax = xmid;
                    g_xmax = g_xmid;
                }
                else
                {
                    // The three values have different signs.
                    // Assume min or max is NaN.
                    if (sgn_min == sgn_nan)
                    {
                        // Value g_xmin is NaN. Use the right half.
                        xmin = xmid;
                        g_xmin = g_xmid;
                    }
                    else if (sgn_max == sgn_nan)
                    {
                        // Value g_xmax is NaN. Use the right half.
                        xmax = xmid;
                        g_xmax = g_xmid;
                    }
                    else
                    {
                        // This is a weird case. Just trap it.
                        //throw new InvalidOperationException(
                        //    "Unexpected difference curve. " +
                        //    "Cannot find a root between X = " +
                        //    xmin + " and X = " + xmax);
                    }
                }
            }

            if (IsNumber(g_xmid) && (Math.Abs(g_xmid) < small))
            {
                x = xmid;
                y = g_xmid;
            }
            else if (IsNumber(g_xmin) && (Math.Abs(g_xmin) < small))
            {
                x = xmin;
                y = g_xmin;
            }
            else if (IsNumber(g_xmax) && (Math.Abs(g_xmax) < small))
            {
                x = xmax;
                y = g_xmax;
            }
            else
            {
                x = xmid;
                y = float.NaN;
            }
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
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // picGraph
            // 
            this.picGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraph.BackColor = System.Drawing.Color.White;
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraph.Location = new System.Drawing.Point(9, 12);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(313, 287);
            this.picGraph.TabIndex = 1;
            this.picGraph.TabStop = false;
            this.picGraph.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picGraph_MouseClick);
            // 
            // howto_find_conic_intersections_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 311);
            this.Controls.Add(this.picGraph);
            this.Name = "howto_find_conic_intersections_Form1";
            this.Text = "howto_find_conic_intersections";
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picGraph;
    }
}

