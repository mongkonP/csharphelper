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
     public partial class howto_select_conic_Form1:Form
  { 


        public howto_select_conic_Form1()
        {
            InitializeComponent();
        }

        // The selected points that determine the conic section.
        private List<PointF> Points = new List<PointF>();

        // The conic section's parameters.
        private float A, B, C, D, E, F;

        // Save a point.
        private void picGraph_MouseClick(object sender, MouseEventArgs e)
        {
            // If we already had 5 points, start a new list.
            if (Points.Count == 5) Points = new List<PointF>();

            // Save the point.
            Points.Add(e.Location);

            // If we now have 5 points, find the conic section.
            if (Points.Count == 5)
            {
                // Find the conic section.
                FindConicSection(Points,
                    out A, out B, out C, out D, out E, out F);

                float min = Math.Abs(A);
                min = Math.Min(min, Math.Abs(B));
                min = Math.Min(min, Math.Abs(C));
                min = Math.Min(min, Math.Abs(D));
                min = Math.Min(min, Math.Abs(E));
                min = Math.Min(min, Math.Abs(F));
                float scale = 1 / min;
                A *= scale;
                B *= scale;
                C *= scale;
                D *= scale;
                E *= scale;
                F *= scale;

                // Display the parameters.
                lstParameters.Items.Clear();
                lstParameters.Items.Add("A: " + A);
                lstParameters.Items.Add("B: " + B);
                lstParameters.Items.Add("C: " + C);
                lstParameters.Items.Add("D: " + D);
                lstParameters.Items.Add("E: " + E);
                lstParameters.Items.Add("F: " + F);

                Console.WriteLine("A: " + A);
                Console.WriteLine("B: " + B);
                Console.WriteLine("C: " + C);
                Console.WriteLine("D: " + D);
                Console.WriteLine("E: " + E);
                Console.WriteLine("F: " + F);

                // Calculate the determinant.
                const float tiny = 0.00001f;
                float determinant = B * B - 4 * A * C;
                lstParameters.Items.Add("Det: " + determinant);
                if (Math.Abs(determinant) < tiny) lstParameters.Items.Add("Parabola");
                else if (determinant < 0)
                {
                    if ((Math.Abs(A) < tiny) && (Math.Abs(B) < tiny))
                        lstParameters.Items.Add("Circle");
                    else
                        lstParameters.Items.Add("Ellipse");
                }
                else
                {
                    if (Math.Abs(A + C) < tiny)
                        lstParameters.Items.Add("Rectangular hyperbola");
                    else
                        lstParameters.Items.Add("Hyperbola");
                }
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
        private void howto_select_conic_Form1_Resize(object sender, EventArgs e)
        {
            DrawGraph();
        }

        // Draw the conic section.
        private void DrawGraph()
        {
            Bitmap bm = new Bitmap(
                picGraph.ClientSize.Width,
                picGraph.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(picGraph.BackColor);
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                // If we have 5 points, draw the conic section.
                if (Points.Count == 5) DrawConicSection(gr, A, B, C, D, E, F);

                // Draw the points.
                const float radius = 3;
                foreach (PointF pt in Points)
                {
                    gr.DrawEllipse(Pens.Blue,
                        pt.X - radius, pt.Y - radius,
                        2 * radius, 2 * radius);
                }
            }

            // Display the result.
            picGraph.Image = bm;
        }

        // Draw the conic section.
        private void DrawConicSection(Graphics gr,
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
            using (Pen thick_pen = new Pen(Color.Red, 2))
            {
                thick_pen.Color = Color.Red;
                if (ln_points.Count > 1)
                    gr.DrawLines(thick_pen, ln_points.ToArray());

                thick_pen.Color = Color.Green;
                if (lp_points.Count > 1)
                    gr.DrawLines(thick_pen, lp_points.ToArray());

                thick_pen.Color = Color.Blue;
                if (rp_points.Count > 1)
                    gr.DrawLines(thick_pen, rp_points.ToArray());

                thick_pen.Color = Color.Orange;
                if (rn_points.Count > 1)
                    gr.DrawLines(thick_pen, rn_points.ToArray());
            }
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
            this.lstParameters = new System.Windows.Forms.ListBox();
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
            this.picGraph.Location = new System.Drawing.Point(12, 12);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(267, 240);
            this.picGraph.TabIndex = 0;
            this.picGraph.TabStop = false;
            this.picGraph.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picGraph_MouseClick);
            // 
            // lstParameters
            // 
            this.lstParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstParameters.FormattingEnabled = true;
            this.lstParameters.Location = new System.Drawing.Point(285, 12);
            this.lstParameters.Name = "lstParameters";
            this.lstParameters.Size = new System.Drawing.Size(127, 238);
            this.lstParameters.TabIndex = 1;
            // 
            // howto_select_conic_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 264);
            this.Controls.Add(this.lstParameters);
            this.Controls.Add(this.picGraph);
            this.Name = "howto_select_conic_Form1";
            this.Text = "howto_select_conic";
            this.Resize += new System.EventHandler(this.howto_select_conic_Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.ListBox lstParameters;
    }
}

