using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Windows;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_square_puzzle_solution_Form1:Form
  { 


        public howto_square_puzzle_solution_Form1()
        {
            InitializeComponent();
        }

        // The points.
        private PointF[] Points;

        // The solutions.
        private List<int[]> Solutions;

        // The solution we should display.
        private int CurrentSolution = 100;

        // Define the points and solutions.
        private void howto_square_puzzle_solution_Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;

            // Define the points.
            float dx = Math.Min(ClientSize.Width, ClientSize.Height) / 4;
            float dy = dx;
            float x0 = (ClientSize.Width - 3 * dx) / 2;
            float y0 = (ClientSize.Height - 3 * dy) / 2;
            Points = new PointF[]
            {
                new PointF(x0 + dx, y0),
                new PointF(x0 + 2 * dx, y0),
                new PointF(x0, y0 + dy),
                new PointF(x0 + dx, y0 + dy),
                new PointF(x0 + 2 * dx, y0 + dy),
                new PointF(x0 + 3 * dx, y0 + dy),
                new PointF(x0, y0 + 2 * dy),
                new PointF(x0 + dx, y0 + 2 * dy),
                new PointF(x0 + 2 * dx, y0 + 2 * dy),
                new PointF(x0 + 3 * dx, y0 + 2 * dy),
                new PointF(x0 + dx, y0 + 3 * dy),
                new PointF(x0 + 2 * dx, y0 + 3 * dy),
            };

            // Define the solutions.
            Solutions = new List<int[]>();

            // Find the solutions.
            FindSolutions();
        }

        // Find the solutions.
        private void FindSolutions()
        {
            // Small squares.
            Solutions.Add(new int[] { 0, 1, 4, 3 });
            Solutions.Add(new int[] { 2, 3, 7, 6 });
            Solutions.Add(new int[] { 3, 4, 8, 7 });
            Solutions.Add(new int[] { 4, 5, 9, 8 });
            Solutions.Add(new int[] { 7, 8, 11, 10 });

            // Medium squares.
            Solutions.Add(new int[] { 0, 4, 7, 2 });
            Solutions.Add(new int[] { 1, 5, 8, 3 });
            Solutions.Add(new int[] { 3, 8, 10, 6 });
            Solutions.Add(new int[] { 4, 9, 11, 7 });

            // Big squares.
            Solutions.Add(new int[] { 0, 6, 11, 5 });
            Solutions.Add(new int[] { 1, 2, 10, 9 });
        }

        // If these points make up a square, return an array holding
        // them in an order that makes a square.
        // If the points don't make up a square, return null.
        private int[] GetSquarePoints(int i, int j, int k, int m)
        {
            // A small value for equality testing.
            const double tiny = 0.001;

            // Store all but the first index in an array.
            int[] indexes = { j, k, m };

            // Get the distances from point i to the others.
            float[] distances =
            {
                PointFDistance(Points[i], Points[j]),
                PointFDistance(Points[i], Points[k]),
                PointFDistance(Points[i], Points[m]),
            };

            // Sort the distances and the corresponding indexes.
            Array.Sort(distances, indexes);

            // If the two smaller distances are not roughly
            // the same (the side length), then this isn't a square.
            if (Math.Abs(distances[0] - distances[1]) > tiny) return null;

            // If the longer distance isn't roughly Sqr(2) times
            // the side length (the diagonal length), then this isn't a square.
            float diagonal_length = (float)(Math.Sqrt(2) * distances[0]);
            if (Math.Abs(distances[2] - diagonal_length) > tiny) return null;

            // See if the distance between the farther point and
            // the two closer points is roughly the side length.
            float distance1 = PointFDistance(Points[indexes[2]], Points[indexes[0]]);
            if (Math.Abs(distances[0] - distance1) > tiny) return null;
            float distance2 = PointFDistance(Points[indexes[2]], Points[indexes[1]]);
            if (Math.Abs(distances[0] - distance2) > tiny) return null;

            // It's a square!
            return new int[] { i, indexes[0], indexes[2], indexes[1] };
        }

        // Return the distance between two PointFs.
        private float PointFDistance(PointF point1, PointF point2)
        {
            float dx = point1.X - point2.X;
            float dy = point1.Y - point2.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        // Draw the circles and any squares currently defined.
        private void howto_square_puzzle_solution_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the points.
            const float radius = 5;
            foreach (PointF pt in Points)
            {
                e.Graphics.FillEllipse(Brushes.Blue,
                    pt.X - radius, pt.Y - radius,
                    2 * radius, 2 * radius);
            }

            // Draw the current solution.
            if (CurrentSolution < 0)
            {
                // Draw all solutions.
                for (int i = 0; i < Solutions.Count; i++)
                {
                    DrawSolution(e.Graphics, i);
                }
            }
            else
            {
                // Draw the current solution.
                DrawSolution(e.Graphics, CurrentSolution);
                if (CurrentSolution < Solutions.Count)
                    lblResults.Text = "Square " + (CurrentSolution + 1).ToString();
            }
        }

        // Draw a solution.
        private void DrawSolution(Graphics gr, int solution_num)
        {
            if (solution_num >= Solutions.Count) return;

            // Make a list of the points in this solution.
            List<PointF> pts = new List<PointF>();
            foreach (int i in Solutions[solution_num]) pts.Add(Points[i]);
            gr.DrawPolygon(Pens.Green, pts.ToArray());
        }

        // Start showing solutions.
        private void btnShowSolutions_Click(object sender, EventArgs e)
        {
            // Disable the button.
            btnShowSolutions.Enabled = false;

            // Start at the first solution.
            CurrentSolution = 0;

            // Start the timer.
            tmrChangeSolution.Enabled = true;

            // Redraw.
            Refresh();
        }

        // Show the next solution.
        private void tmrChangeSolution_Tick(object sender, EventArgs e)
        {
            // Increment CurrentSolution. If the result is greater than the
            // last solution's index, disable the timer.
            tmrChangeSolution.Enabled = (++CurrentSolution < Solutions.Count);

            // If we're done drawing, enable the button.
            if (!tmrChangeSolution.Enabled)
            {
                btnShowSolutions.Enabled = true;
                lblResults.Text = "";
            }

            // Redraw.
            Refresh();
        }

        // Show all of the solutions.
        private void btnShowAllSolutions_Click(object sender, EventArgs e)
        {
            CurrentSolution = -1;
            tmrChangeSolution.Enabled = false;
            btnShowSolutions.Enabled = true;

            // Display the number of solutions.
            lblResults.Text = Solutions.Count.ToString() + " squares";

            // Redraw.
            Refresh();
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
            this.lblResults = new System.Windows.Forms.Label();
            this.tmrChangeSolution = new System.Windows.Forms.Timer(this.components);
            this.btnShowAllSolutions = new System.Windows.Forms.Button();
            this.btnShowSolutions = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(3, 244);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(0, 13);
            this.lblResults.TabIndex = 6;
            // 
            // tmrChangeSolution
            // 
            this.tmrChangeSolution.Interval = 500;
            this.tmrChangeSolution.Tick += new System.EventHandler(this.tmrChangeSolution_Tick);
            // 
            // btnShowAllSolutions
            // 
            this.btnShowAllSolutions.Location = new System.Drawing.Point(1, 30);
            this.btnShowAllSolutions.Name = "btnShowAllSolutions";
            this.btnShowAllSolutions.Size = new System.Drawing.Size(98, 23);
            this.btnShowAllSolutions.TabIndex = 5;
            this.btnShowAllSolutions.Text = "Show All";
            this.btnShowAllSolutions.UseVisualStyleBackColor = true;
            this.btnShowAllSolutions.Click += new System.EventHandler(this.btnShowAllSolutions_Click);
            // 
            // btnShowSolutions
            // 
            this.btnShowSolutions.Location = new System.Drawing.Point(1, 1);
            this.btnShowSolutions.Name = "btnShowSolutions";
            this.btnShowSolutions.Size = new System.Drawing.Size(98, 23);
            this.btnShowSolutions.TabIndex = 4;
            this.btnShowSolutions.Text = "Show Solutions";
            this.btnShowSolutions.UseVisualStyleBackColor = true;
            this.btnShowSolutions.Click += new System.EventHandler(this.btnShowSolutions_Click);
            // 
            // howto_square_puzzle_solution_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.btnShowAllSolutions);
            this.Controls.Add(this.btnShowSolutions);
            this.Name = "howto_square_puzzle_solution_Form1";
            this.Text = "howto_square_puzzle_solution";
            this.Load += new System.EventHandler(this.howto_square_puzzle_solution_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_square_puzzle_solution_Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.Timer tmrChangeSolution;
        private System.Windows.Forms.Button btnShowAllSolutions;
        private System.Windows.Forms.Button btnShowSolutions;
    }
}

