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
     public partial class howto_triangle_puzzle_Form1_1:Form
  { 


        public howto_triangle_puzzle_Form1_1()
        {
            InitializeComponent();
        }

        // The points.
        private PointF[] Points;

        // The solutions.
        private List<int[]> Solutions;

        private int Count = 0;

        // The solution we should display.
        private int CurrentSolution = 100;

        // Define the points and solutions.
        private void howto_triangle_puzzle_Form1_1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;

            // Define the points.
            float dy = ClientSize.Height / 4;
            float dx = (float)(dy / Math.Sqrt(3));
            float top_x = ClientSize.Width / 2;
            float top_y = -dy / 2;
            Points = new PointF[]
            {
                new PointF(top_x - dx, top_y + dy),
                new PointF(top_x + dx, top_y + dy),
                new PointF(top_x - 2 * dx, top_y + 2 * dy),
                new PointF(top_x - 0 * dx, top_y + 2 * dy),
                new PointF(top_x + 2 * dx, top_y + 2 * dy),
                new PointF(top_x - 3 * dx, top_y + 3 * dy),
                new PointF(top_x - 1 * dx, top_y + 3 * dy),
                new PointF(top_x + 1 * dx, top_y + 3 * dy),
                new PointF(top_x + 3 * dx, top_y + 3 * dy),
                new PointF(top_x - 2 * dx, top_y + 4 * dy),
                new PointF(top_x - 0 * dx, top_y + 4 * dy),
                new PointF(top_x + 2 * dx, top_y + 4 * dy),
            };

            // Define the solutions.
            Solutions = new List<int[]>();

            // Loop through each point for point A           
            for (int x = 0; x < Points.Length; x++)
            {
                PointF A = Points[x];

                // Loop through all subsequent points for point B 
                // as previous would make duplicates
                for (int y = x + 1; y < Points.Length; y++)
                {
                    PointF B = Points[y];

                    // Loop through all subsequent points for point C
                    for (int z = y + 1; z < Points.Length; z++)
                    {
                        PointF C = Points[z];

                        // Find the distance
                        // Precision creates different results
                        /* 
                         * Precision : triangles
                         * 0,1,2,3   : 25
                         * 4         : 23
                         * 5,6       : 20
                         * 7+        : 0
                         */
                        double legAB = Math.Round(Math.Sqrt(Math.Pow((A.X - B.X), 2) + Math.Pow((A.Y - B.Y), 2)), 0);
                        double legAC = Math.Round(Math.Sqrt(Math.Pow((A.X - C.X), 2) + Math.Pow((A.Y - C.Y), 2)), 0);
                        double legBC = Math.Round(Math.Sqrt(Math.Pow((C.X - B.X), 2) + Math.Pow((C.Y - B.Y), 2)), 0);

                        // Verify the distances are the same
                        if ((legAB == legAC) && (legAB == legBC) && (legBC == legAC))
                        {
                            Solutions.Add(new int[] { x, y, z });
                        }
                    }
                }
            }
        }

        // Draw the circles and any triangles currently defined.
        private void howto_triangle_puzzle_Form1_1_Paint(object sender, PaintEventArgs e)
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
            }
        }

        // Draw a solution.
        private void DrawSolution(Graphics gr, int solution_num)
        {
            if (solution_num >= Solutions.Count) return;

            // Make a list of the points in this solution.
            List<PointF> pts = new List<PointF>();
            foreach (int i in Solutions[solution_num]) pts.Add(Points[i]);
            gr.DrawPolygon(Pens.Red, pts.ToArray());            
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

            // Show the inital number
            Count = CurrentSolution + 1;
            lblNumOfAnswers.Text = Count.ToString();
            Count++;

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

            // Increment the solution number count, make sure it doesn't count past the number of solutions
            if (Count <= Solutions.Count)
            {
                lblNumOfAnswers.Text = Count.ToString();
                Count++;
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
            Refresh();
            lblNumOfAnswers.Text = Solutions.Count().ToString();
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
            this.lblNumOfAnswers = new System.Windows.Forms.Label();
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
            // lblNumOfAnswers
            // 
            this.lblNumOfAnswers.AutoSize = true;
            this.lblNumOfAnswers.Location = new System.Drawing.Point(268, 9);
            this.lblNumOfAnswers.Name = "lblNumOfAnswers";
            this.lblNumOfAnswers.Size = new System.Drawing.Size(0, 13);
            this.lblNumOfAnswers.TabIndex = 3;
            // 
            // howto_triangle_puzzle_Form1_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 264);
            this.Controls.Add(this.lblNumOfAnswers);
            this.Controls.Add(this.btnShowAllSolutions);
            this.Controls.Add(this.btnShowSolutions);
            this.Name = "howto_triangle_puzzle_Form1_1";
            this.Text = "howto_triangle_puzzle";
            this.Load += new System.EventHandler(this.howto_triangle_puzzle_Form1_1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_triangle_puzzle_Form1_1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowSolutions;
        private System.Windows.Forms.Timer tmrChangeSolution;
        private System.Windows.Forms.Button btnShowAllSolutions;
        private System.Windows.Forms.Label lblNumOfAnswers;
    }
}

