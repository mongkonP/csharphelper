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
     public partial class howto_triangle_puzzle_solution_Form1:Form
  { 


        public howto_triangle_puzzle_solution_Form1()
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
        private void howto_triangle_puzzle_solution_Form1_Load(object sender, EventArgs e)
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
            Solutions.Add(new int[] { 0, 2, 3 });
            Solutions.Add(new int[] { 0, 3, 1 });
            Solutions.Add(new int[] { 1, 3, 4 });
            Solutions.Add(new int[] { 2, 5, 6 });
            Solutions.Add(new int[] { 2, 6, 3 });
            Solutions.Add(new int[] { 3, 6, 7 });
            Solutions.Add(new int[] { 3, 7, 4 });
            Solutions.Add(new int[] { 4, 7, 8 });
            Solutions.Add(new int[] { 5, 9, 6 });
            Solutions.Add(new int[] { 6, 9, 10 });
            Solutions.Add(new int[] { 6, 10, 7 });
            Solutions.Add(new int[] { 7, 10, 11 });
            Solutions.Add(new int[] { 7, 11, 8 });

            Solutions.Add(new int[] { 0, 5, 7 });
            Solutions.Add(new int[] { 1, 6, 8 });
            Solutions.Add(new int[] { 3, 9, 11 });
            Solutions.Add(new int[] { 10, 2, 4 });

            Solutions.Add(new int[] { 5, 10, 3 });
            Solutions.Add(new int[] { 2, 7, 1 });
            Solutions.Add(new int[] { 6, 11, 4 });
            Solutions.Add(new int[] { 8, 3, 10 });
            Solutions.Add(new int[] { 4, 6, 0 });
            Solutions.Add(new int[] { 7, 9, 2 });

            Solutions.Add(new int[] { 0, 9, 8 });
            Solutions.Add(new int[] { 1, 5, 11 });
        }

        // Draw the circles and any triangles currently defined.
        private void howto_triangle_puzzle_solution_Form1_Paint(object sender, PaintEventArgs e)
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
                lblCount.Text = Solutions.Count.ToString();
            }
            else
            {
                // Draw the current solution.
                DrawSolution(e.Graphics, CurrentSolution);
                if (CurrentSolution < Solutions.Count)
                    lblCount.Text = (CurrentSolution + 1).ToString();
            }
        }

        // Draw a solution.
        private void DrawSolution(Graphics gr, int solution_num)
        {
            if (solution_num >= Solutions.Count) return;

            // Get the right color for this solution.
            Pen the_pen;
            if (solution_num < 13) the_pen = Pens.Red;
            else if (solution_num < 17) the_pen = Pens.Green;
            else if (solution_num < 23) the_pen = Pens.Purple;
            else the_pen = Pens.Orange;

            // Make a list of the points in this solution.
            List<PointF> pts = new List<PointF>();
            foreach (int i in Solutions[solution_num]) pts.Add(Points[i]);
            gr.DrawPolygon(the_pen, pts.ToArray());
        }

        // Start showing solutions.
        private void btnShowSolutions_Click(object sender, EventArgs e)
        {
            // Disable the button.
            btnShowSolutions.Enabled = false;
            lblCount.Text = "";

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
            this.tmrChangeSolution = new System.Windows.Forms.Timer(this.components);
            this.btnShowAllSolutions = new System.Windows.Forms.Button();
            this.btnShowSolutions = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tmrChangeSolution
            // 
            this.tmrChangeSolution.Interval = 500;
            this.tmrChangeSolution.Tick += new System.EventHandler(this.tmrChangeSolution_Tick);
            // 
            // btnShowAllSolutions
            // 
            this.btnShowAllSolutions.Location = new System.Drawing.Point(4, 32);
            this.btnShowAllSolutions.Name = "btnShowAllSolutions";
            this.btnShowAllSolutions.Size = new System.Drawing.Size(98, 23);
            this.btnShowAllSolutions.TabIndex = 4;
            this.btnShowAllSolutions.Text = "Show All";
            this.btnShowAllSolutions.UseVisualStyleBackColor = true;
            this.btnShowAllSolutions.Click += new System.EventHandler(this.btnShowAllSolutions_Click);
            // 
            // btnShowSolutions
            // 
            this.btnShowSolutions.Location = new System.Drawing.Point(4, 3);
            this.btnShowSolutions.Name = "btnShowSolutions";
            this.btnShowSolutions.Size = new System.Drawing.Size(98, 23);
            this.btnShowSolutions.TabIndex = 3;
            this.btnShowSolutions.Text = "Show Solutions";
            this.btnShowSolutions.UseVisualStyleBackColor = true;
            this.btnShowSolutions.Click += new System.EventHandler(this.btnShowSolutions_Click);
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(307, 8);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 13);
            this.lblCount.TabIndex = 5;
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // howto_triangle_puzzle_solution_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 264);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnShowAllSolutions);
            this.Controls.Add(this.btnShowSolutions);
            this.Name = "howto_triangle_puzzle_solution_Form1";
            this.Text = "howto_triangle_puzzle_solution";
            this.Load += new System.EventHandler(this.howto_triangle_puzzle_solution_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_triangle_puzzle_solution_Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrChangeSolution;
        private System.Windows.Forms.Button btnShowAllSolutions;
        private System.Windows.Forms.Button btnShowSolutions;
        private System.Windows.Forms.Label lblCount;
    }
}

