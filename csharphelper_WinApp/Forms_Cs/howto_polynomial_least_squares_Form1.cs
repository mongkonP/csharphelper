using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

using howto_polynomial_least_squares;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_polynomial_least_squares_Form1:Form
  { 


        public howto_polynomial_least_squares_Form1()
        {
            InitializeComponent();
        }

        // Drawing constants.
        private const float Xmin = -10.0f;
        private const float Xmax = 10.0f;
        private const float Ymin = -10.0f;
        private const float Ymax = 10.0f;
        private Matrix DrawingTransform;
        private Matrix InverseTransform;

        private bool HasSolution = false;
        private List<double> BestCoeffs;
        private List<PointF> Points = new List<PointF>();

        // Make a drawing transformation.
        private void howto_polynomial_least_squares_Form1_Load(object sender, EventArgs e)
        {
            RectangleF world_rect = new RectangleF(Xmin, Ymin, Xmax - Xmin, Ymax - Ymin);
            PointF[] pts =
            {
                new PointF(0, picGraph.ClientSize.Height),
                new PointF(picGraph.ClientSize.Width, picGraph.ClientSize.Height),
                new PointF(0, 0),
            };
            DrawingTransform = new Matrix(world_rect, pts);
            InverseTransform = DrawingTransform.Clone();
            InverseTransform.Invert();

            // Pretty up the sample equation.
            rchEquation.Select(5, 1);
            rchEquation.SelectionCharOffset = -7;
            rchEquation.Select(7, 1);
            rchEquation.SelectionCharOffset = 7;
            rchEquation.Select(12, 1);
            rchEquation.SelectionCharOffset = -7;
            rchEquation.Select(14, 1);
            rchEquation.SelectionCharOffset = 7;
            rchEquation.Select(19, 1);
            rchEquation.SelectionCharOffset = -7;
            rchEquation.Select(21, 1);
            rchEquation.SelectionCharOffset = 7;
            rchEquation.Select(26, 1);
            rchEquation.SelectionCharOffset = -7;
            rchEquation.Select(28, 1);
            rchEquation.SelectionCharOffset = 7;
        }

        // Save a new point.
        private void picGraph_MouseClick(object sender, MouseEventArgs e)
        {
            // Transform the point to world coordinates.
            PointF[] pts = { new PointF(e.X, e.Y) };
            InverseTransform.TransformPoints(pts);

            // Save the point.
            Points.Add(pts[0]);
            picGraph.Refresh();
        }

        // Draw the points and best fit curve.
        private void picGraph_Paint(object sender, PaintEventArgs e)
        {
            // Use the drawing transformation.
            e.Graphics.Transform = DrawingTransform;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the axes.
            DrawAxes(e.Graphics);

            // Draw the curve.
            if (HasSolution)
            {
                using (Pen thin_pen = new Pen(Color.Blue, 0))
                {
                    const double x_step = 0.1;
                    double y0 = CurveFunctions.F(BestCoeffs, Xmin);
                    for (double x = Xmin + x_step; x <= Xmax; x += x_step)
                    {
                        double y1 = CurveFunctions.F(BestCoeffs, x);
                        e.Graphics.DrawLine(thin_pen,
                            (float)(x - x_step), (float)y0, (float)x, (float)y1);
                        y0 = y1;
                    }
                }
            }

            // Draw the points.
            const float dx = (Xmax - Xmin) / 100;
            const float dy = (Ymax - Ymin) / 100;
            using (Pen thin_pen = new Pen(Color.Black, 0))
            {
                foreach (PointF pt in Points)
                {
                    e.Graphics.FillRectangle(Brushes.White,
                        pt.X - dx, pt.Y - dy, 2 * dx, 2 * dy);
                    e.Graphics.DrawRectangle(thin_pen,
                        pt.X - dx, pt.Y - dy, 2 * dx, 2 * dy);
                }
            }
        }

        // Draw the axes.
        private void DrawAxes(Graphics gr)
        {
            using (Pen thin_pen = new Pen(Color.Black, 0))
            {
                const float xthick = 0.2f;
                const float ythick = 0.2f;
                gr.DrawLine(thin_pen, Xmin, 0, Xmax, 0);
                for (float x = Xmin; x <= Xmax; x += 1.0f)
                {
                    gr.DrawLine(thin_pen, x, -ythick, x, ythick);
                }
                gr.DrawLine(thin_pen, 0, Ymin, 0, Ymax);
                for (float y = Ymin; y <= Ymax; y += 1.0f)
                {
                    gr.DrawLine(thin_pen, -xthick, y, xthick, y);
                }
            }
        }

        // Clear the points.
        private void btnClear_Click(object sender, EventArgs e)
        {
            Points = new List<PointF>();
            HasSolution = false;
            picGraph.Refresh();

            txtCoeffs.Clear();
            txtError.Clear();
        }

        // Find parameters for a weibull curve fit.
        private void btnFit_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            txtCoeffs.Clear();
            txtError.Clear();
            Application.DoEvents();
            DateTime start_time = DateTime.Now;

            // Find a good fit.
            int degree = (int)nudDegree.Value;
            BestCoeffs = CurveFunctions.FindPolynomialLeastSquaresFit(Points, degree);
            HasSolution = true;

            DateTime stop_time = DateTime.Now;
            TimeSpan elapsed = stop_time - start_time;
            Console.WriteLine("Time: " +
                elapsed.TotalSeconds.ToString("0.00") + " seconds");

            string txt = "";
            foreach (double coeff in BestCoeffs)
            {
                txt += " " + coeff.ToString();
            }
            txtCoeffs.Text = txt.Substring(1);

            // Display the error.
            ShowError();

            // We have a solution.
            HasSolution = true;
            picGraph.Refresh();

            this.Cursor = Cursors.Default;
        }

        // Regraph with the given parameters.
        private void btnGraph_Click(object sender, EventArgs e)
        {
            // Get the coefficients.
            string[] coeffs = txtCoeffs.Text.Split();
            BestCoeffs = new List<double>();
            foreach (string coeff in coeffs)
            {
                BestCoeffs.Add(double.Parse(coeff));
            }
            ShowError();
            picGraph.Refresh();
        }

        // Display the error.
        private void ShowError()
        {
            // Get the error.
            double error = Math.Sqrt(
                CurveFunctions.ErrorSquared(Points, BestCoeffs));
            txtError.Text = error.ToString();
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
            this.btnGraph = new System.Windows.Forms.Button();
            this.rchEquation = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtError = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCoeffs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnFit = new System.Windows.Forms.Button();
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.nudDegree = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDegree)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGraph
            // 
            this.btnGraph.Location = new System.Drawing.Point(284, 219);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(75, 23);
            this.btnGraph.TabIndex = 45;
            this.btnGraph.Text = "Graph";
            this.btnGraph.UseVisualStyleBackColor = true;
            this.btnGraph.Click += new System.EventHandler(this.btnGraph_Click);
            // 
            // rchEquation
            // 
            this.rchEquation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rchEquation.BackColor = System.Drawing.SystemColors.Control;
            this.rchEquation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rchEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rchEquation.Location = new System.Drawing.Point(249, 12);
            this.rchEquation.Multiline = false;
            this.rchEquation.Name = "rchEquation";
            this.rchEquation.Size = new System.Drawing.Size(210, 46);
            this.rchEquation.TabIndex = 50;
            this.rchEquation.Text = "y = A0X0 + A1X1 + A2X2 + A3X3 + ...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(246, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Error:";
            // 
            // txtError
            // 
            this.txtError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtError.Location = new System.Drawing.Point(297, 141);
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(162, 20);
            this.txtError.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "As:";
            // 
            // txtCoeffs
            // 
            this.txtCoeffs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCoeffs.Location = new System.Drawing.Point(297, 115);
            this.txtCoeffs.Name = "txtCoeffs";
            this.txtCoeffs.Size = new System.Drawing.Size(162, 20);
            this.txtCoeffs.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Degree:";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(326, 60);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 41;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnFit
            // 
            this.btnFit.Location = new System.Drawing.Point(245, 60);
            this.btnFit.Name = "btnFit";
            this.btnFit.Size = new System.Drawing.Size(75, 23);
            this.btnFit.TabIndex = 40;
            this.btnFit.Text = "Fit";
            this.btnFit.UseVisualStyleBackColor = true;
            this.btnFit.Click += new System.EventHandler(this.btnFit_Click);
            // 
            // picGraph
            // 
            this.picGraph.BackColor = System.Drawing.Color.White;
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraph.Location = new System.Drawing.Point(12, 12);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(228, 228);
            this.picGraph.TabIndex = 46;
            this.picGraph.TabStop = false;
            this.picGraph.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picGraph_MouseClick);
            this.picGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.picGraph_Paint);
            // 
            // nudDegree
            // 
            this.nudDegree.Location = new System.Drawing.Point(297, 90);
            this.nudDegree.Name = "nudDegree";
            this.nudDegree.Size = new System.Drawing.Size(41, 20);
            this.nudDegree.TabIndex = 51;
            this.nudDegree.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // howto_polynomial_least_squares_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 254);
            this.Controls.Add(this.nudDegree);
            this.Controls.Add(this.btnGraph);
            this.Controls.Add(this.rchEquation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCoeffs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnFit);
            this.Controls.Add(this.picGraph);
            this.Name = "howto_polynomial_least_squares_Form1";
            this.Text = "howto_polynomial_least_squares";
            this.Load += new System.EventHandler(this.howto_polynomial_least_squares_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDegree)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGraph;
        private System.Windows.Forms.RichTextBox rchEquation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCoeffs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnFit;
        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.NumericUpDown nudDegree;
    }
}

