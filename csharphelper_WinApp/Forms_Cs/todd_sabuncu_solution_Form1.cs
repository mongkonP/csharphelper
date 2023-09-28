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
     public partial class todd_sabuncu_solution_Form1:Form
  { 


        public todd_sabuncu_solution_Form1()
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
        private void todd_sabuncu_solution_Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;

            // Define the points.
            float dx = Math.Min(ClientSize.Width, ClientSize.Height) / 4;
            float dy = dx;
            float x0 = (ClientSize.Width - 3 * dx) / 2;
            float y0 = (ClientSize.Height - 3 * dy) / 2;
            Points = new PointF[]
            {
                new PointF(x0 + dx, y0),                //  0
                new PointF(x0 + 2 * dx, y0),            //  1
                new PointF(x0, y0 + dy),                //  2
                new PointF(x0 + dx, y0 + dy),           //  3
                new PointF(x0 + 2 * dx, y0 + dy),       //  4
                new PointF(x0 + 3 * dx, y0 + dy),       //  5
                new PointF(x0, y0 + 2 * dy),            //  6
                new PointF(x0 + dx, y0 + 2 * dy),       //  7
                new PointF(x0 + 2 * dx, y0 + 2 * dy),   //  8
                new PointF(x0 + 3 * dx, y0 + 2 * dy),   //  9
                new PointF(x0 + dx, y0 + 3 * dy),       // 10
                new PointF(x0 + 2 * dx, y0 + 3 * dy),   // 11
            };

            // Define the solutions.
            Solutions = new List<int[]>();

            // Find the solutions.
            FindSolutions();

            // Display the number of solutions.
            lblResults.Text = Solutions.Count.ToString() + " squares.";
        }

        // Find the solutions.
        private void FindSolutions()
        {
            // Insert your code here.
            // Solutions.Add(new int[] { 0, 1, 4, 3 });

            // ...

            PointF cornerAPrime = new PointF();
            PointF cornerBPrime = new PointF();
            int zCornerAPrime = 0, zCornerBPrime = 0;   // Indexes corresponding to above points.

            // Maintain a list parallel to Solutions where each solution's indexes are kept in sorted order.
            List<int[]> sortedSolutions = new List<int[]>();

            // We select a point (for x... loop) then select a second point (for... y loop).  This gives us an edge.  We then calculate the locations
            // of the two other corners that would result in a square.  Then, within the inner-most loop (for z... loop), we test whether actual points are
            // defined in the Points array that correspond to our calculated corners.

            for (int x = 0; x < Points.Length; x++)
            {
                PointF cornerA = Points[x];         // Start of edge (first corner of square).

                // For point B, consider all remaining points in the Points array.

                for (int y = x + 1; y < Points.Length; y++)
                {
                    PointF cornerB = Points[y];     // End of edge (second corner of square).

                    // Calculate length of edge.

                    double edgeAB = Math.Round(Math.Sqrt(Math.Pow((cornerA.X - cornerB.X), 2) + Math.Pow((cornerA.Y - cornerB.Y), 2)), 0);

                    // Calculate coordinates for cornerAPrime (third corner of square), opposite cornerA.

                    cornerAPrime.X = cornerA.X + Math.Abs((cornerA.Y - cornerB.Y));
                    cornerAPrime.Y = cornerA.Y + Math.Abs((cornerA.X - cornerB.X));

                    if (checkForPoint(x, y, cornerAPrime, ref zCornerAPrime) == false)
                        continue;  // cornerAPrime does not exist; discard this edge.

                    // cornerAPrime exists; check the fourth corner.

                    // Calculate coordinates for cornerBPrime (fourth/final corner of square), opposite cornerB.

                    cornerBPrime.X = cornerB.X + Math.Abs((cornerB.Y - cornerA.Y));
                    cornerBPrime.Y = cornerB.Y + Math.Abs((cornerB.X - cornerA.X));

                    if (checkForPoint(x, y, cornerBPrime, ref zCornerBPrime) == false)
                        continue;  // cornerBPrime does not exist; discard this edge.

                    // cornerBPrime exists; we have a valid square.  Now we need to check whether we have
                    // already discovered this square before.  First we normalize our indexes by sorting them.

                    int[] sortedIndexes = new int[] { x, y, zCornerAPrime, zCornerBPrime };
                    Array.Sort(sortedIndexes);

                    // Check sorted list of solutions.

                    Boolean solutionExists = false;

                    if (sortedSolutions.Count > 0)
                        for (int ii = 0; ii < sortedSolutions.Count; ii++)
                            if (sortedSolutions[ii][0] == sortedIndexes[0] &&
                                sortedSolutions[ii][1] == sortedIndexes[1] &&
                                sortedSolutions[ii][2] == sortedIndexes[2] &&
                                sortedSolutions[ii][3] == sortedIndexes[3])
                                solutionExists = true;

                    if (!solutionExists)
                    {
                        sortedSolutions.Add(sortedIndexes);
                        Solutions.Add(new int[] { x, y, zCornerBPrime, zCornerAPrime });    // Note: Order of indexes is important
                        // to draw the square in proper sequence.
                    }

                } // for y...

            } // for x...

        } // end FindSolutions()

        // Check whether Points array contains corner.

        private Boolean checkForPoint(int x, int y, PointF corner, ref int zCorner)
        {
            Boolean found = false;
            zCorner = 0;

            for (int z = 0; z < Points.Length; z++) // Check all points (start z from 0).
            {
                if (z == x || z == y)   // Skip indexes corresponding to two original corners (see calling routine).
                    continue;

                if (Points[z].Equals(corner))
                {
                    found = true;
                    zCorner = z;
                    break;
                }
            }

            return found;
        }

        // Draw the circles and any triangles currently defined.
        private void todd_sabuncu_solution_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the points.
            const float radius = 5;
            foreach (PointF pt in Points)
            {
                e.Graphics.FillEllipse(Brushes.Red,
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
            btnShowSolutions.Enabled = (!tmrChangeSolution.Enabled);

            // Redraw.
            Refresh();
        }

        // Show all of the solutions.
        private void btnShowAllSolutions_Click(object sender, EventArgs e)
        {
            CurrentSolution = -1;
            tmrChangeSolution.Enabled = false;
            btnShowSolutions.Enabled = true;
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
            this.btnShowSolutions = new System.Windows.Forms.Button();
            this.tmrChangeSolution = new System.Windows.Forms.Timer(this.components);
            this.btnShowAllSolutions = new System.Windows.Forms.Button();
            this.lblResults = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnShowSolutions
            // 
            this.btnShowSolutions.Location = new System.Drawing.Point(0, 0);
            this.btnShowSolutions.Name = "btnShowSolutions";
            this.btnShowSolutions.Size = new System.Drawing.Size(98, 23);
            this.btnShowSolutions.TabIndex = 0;
            this.btnShowSolutions.Text = "Show Solutions";
            this.btnShowSolutions.UseVisualStyleBackColor = true;
            this.btnShowSolutions.Click += new System.EventHandler(this.btnShowSolutions_Click);
            // 
            // tmrChangeSolution
            // 
            this.tmrChangeSolution.Interval = 500;
            this.tmrChangeSolution.Tick += new System.EventHandler(this.tmrChangeSolution_Tick);
            // 
            // btnShowAllSolutions
            // 
            this.btnShowAllSolutions.Location = new System.Drawing.Point(0, 29);
            this.btnShowAllSolutions.Name = "btnShowAllSolutions";
            this.btnShowAllSolutions.Size = new System.Drawing.Size(98, 23);
            this.btnShowAllSolutions.TabIndex = 2;
            this.btnShowAllSolutions.Text = "Show All";
            this.btnShowAllSolutions.UseVisualStyleBackColor = true;
            this.btnShowAllSolutions.Click += new System.EventHandler(this.btnShowAllSolutions_Click);
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(0, 250);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(0, 13);
            this.lblResults.TabIndex = 3;
            // 
            // todd_sabuncu_solution_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 264);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.btnShowAllSolutions);
            this.Controls.Add(this.btnShowSolutions);
            this.Name = "todd_sabuncu_solution_Form1";
            this.Text = "howto_find_squares";
            this.Load += new System.EventHandler(this.todd_sabuncu_solution_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.todd_sabuncu_solution_Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowSolutions;
        private System.Windows.Forms.Timer tmrChangeSolution;
        private System.Windows.Forms.Button btnShowAllSolutions;
        private System.Windows.Forms.Label lblResults;
    }
}

