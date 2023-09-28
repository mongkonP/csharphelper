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
     public partial class howto_find_equilateral_triangles_Form1:Form
  { 


        public howto_find_equilateral_triangles_Form1()
        {
            InitializeComponent();
        }

        // The points.
        private PointF[] Points;

        // The solutions.
        private List<int[]> Solutions = new List<int[]>();

        // The solution we should display.
        private int CurrentSolution = 100;

        // Define the points and solutions.
        private void howto_find_equilateral_triangles_Form1_Load(object sender, EventArgs e)
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
        }

        // Find the solutions.
        private void btnFindSolutions_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Solutions = new List<int[]>();
            for (int i = 0; i < Points.Length; i++)
            {
                for (int j = i + 1; j < Points.Length; j++)
                {
                    double dx_ij = Points[j].X - Points[i].X;
                    double dy_ij = Points[j].Y - Points[i].Y;
                    double dist_ij = Math.Sqrt(dx_ij * dx_ij + dy_ij * dy_ij);
                    for (int k = j + 1; k < Points.Length; k++)
                    {
                        double dx_jk = Points[k].X - Points[j].X;
                        double dy_jk = Points[k].Y - Points[j].Y;
                        double dist_jk = Math.Sqrt(dx_jk * dx_jk + dy_jk * dy_jk);
                        const double tiny = 0.0001;
                        if (Math.Abs(dist_ij - dist_jk) < tiny)
                        {
                            double dx_ki = Points[i].X - Points[k].X;
                            double dy_ki = Points[i].Y - Points[k].Y;
                            double dist_ki = Math.Sqrt(dx_ki * dx_ki + dy_ki * dy_ki);
                            if (Math.Abs(dist_jk - dist_ki) < tiny)
                            {
                                // This is a solution.
                                Solutions.Add(new int[] { i, j, k });
                            }
                        }
                    }
                }
            }

            lblNumSolutions.Text = Solutions.Count.ToString() + " solutions";
            btnFindSolutions.Enabled = false;
            btnShowSolutions.Enabled = true;
            btnShowAllSolutions.Enabled = true;
            Refresh();
            Cursor = Cursors.Default;
        }

        // Draw the circles and any triangles currently defined.
        private void howto_find_equilateral_triangles_Form1_Paint(object sender, PaintEventArgs e)
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
            this.btnFindSolutions = new System.Windows.Forms.Button();
            this.btnShowAllSolutions = new System.Windows.Forms.Button();
            this.tmrChangeSolution = new System.Windows.Forms.Timer(this.components);
            this.lblNumSolutions = new System.Windows.Forms.Label();
            this.btnShowSolutions = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFindSolutions
            // 
            this.btnFindSolutions.Location = new System.Drawing.Point(4, 4);
            this.btnFindSolutions.Name = "btnFindSolutions";
            this.btnFindSolutions.Size = new System.Drawing.Size(98, 23);
            this.btnFindSolutions.TabIndex = 4;
            this.btnFindSolutions.Text = "Find Solutions";
            this.btnFindSolutions.UseVisualStyleBackColor = true;
            this.btnFindSolutions.Click += new System.EventHandler(this.btnFindSolutions_Click);
            // 
            // btnShowAllSolutions
            // 
            this.btnShowAllSolutions.Enabled = false;
            this.btnShowAllSolutions.Location = new System.Drawing.Point(4, 62);
            this.btnShowAllSolutions.Name = "btnShowAllSolutions";
            this.btnShowAllSolutions.Size = new System.Drawing.Size(98, 23);
            this.btnShowAllSolutions.TabIndex = 6;
            this.btnShowAllSolutions.Text = "Show All";
            this.btnShowAllSolutions.UseVisualStyleBackColor = true;
            this.btnShowAllSolutions.Click += new System.EventHandler(this.btnShowAllSolutions_Click);
            // 
            // tmrChangeSolution
            // 
            this.tmrChangeSolution.Interval = 500;
            this.tmrChangeSolution.Tick += new System.EventHandler(this.tmrChangeSolution_Tick);
            // 
            // lblNumSolutions
            // 
            this.lblNumSolutions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNumSolutions.AutoSize = true;
            this.lblNumSolutions.Location = new System.Drawing.Point(4, 253);
            this.lblNumSolutions.Name = "lblNumSolutions";
            this.lblNumSolutions.Size = new System.Drawing.Size(0, 13);
            this.lblNumSolutions.TabIndex = 7;
            // 
            // btnShowSolutions
            // 
            this.btnShowSolutions.Enabled = false;
            this.btnShowSolutions.Location = new System.Drawing.Point(4, 33);
            this.btnShowSolutions.Name = "btnShowSolutions";
            this.btnShowSolutions.Size = new System.Drawing.Size(98, 23);
            this.btnShowSolutions.TabIndex = 5;
            this.btnShowSolutions.Text = "Show Solutions";
            this.btnShowSolutions.UseVisualStyleBackColor = true;
            this.btnShowSolutions.Click += new System.EventHandler(this.btnShowSolutions_Click);
            // 
            // howto_find_equilateral_triangles_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 271);
            this.Controls.Add(this.btnFindSolutions);
            this.Controls.Add(this.btnShowAllSolutions);
            this.Controls.Add(this.lblNumSolutions);
            this.Controls.Add(this.btnShowSolutions);
            this.Name = "howto_find_equilateral_triangles_Form1";
            this.Text = "howto_find_equilateral_triangles";
            this.Load += new System.EventHandler(this.howto_find_equilateral_triangles_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_find_equilateral_triangles_Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFindSolutions;
        private System.Windows.Forms.Button btnShowAllSolutions;
        private System.Windows.Forms.Timer tmrChangeSolution;
        private System.Windows.Forms.Label lblNumSolutions;
        private System.Windows.Forms.Button btnShowSolutions;
    }
}

