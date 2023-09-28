using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

using howto_exponential_curve_fit;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_exponential_curve_fit_Form1:Form
  { 


        public howto_exponential_curve_fit_Form1()
        {
            InitializeComponent();
        }

        // Drawing constants.
        private const float Xmin =  -0.1f;
        private const float Xmax =   4.1f;
        private const float Ymin = -10.0f;
        private const float Ymax = 100.0f;
        private Matrix DrawingTransform;
        private Matrix InverseTransform;

        private bool HasSolution = false;
        private double BestA, BestB, BestC;
        private List<PointF> Points = new List<PointF>();

        // Make a drawing transformation.
        private void howto_exponential_curve_fit_Form1_Load(object sender, EventArgs e)
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

            rchEquation.Select(9, 2);
            rchEquation.SelectionCharOffset = 15;
        }

        // Save a new point.
        private void picGraph_MouseClick(object sender, MouseEventArgs e)
        {
            // Transform the point to world coordinates.
            PointF[] pts = { new PointF(e.X, e.Y) };
            InverseTransform.TransformPoints(pts);
            // Console.WriteLine(pts[0].ToString());

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
                const double Xstep = 0.01;
                double x0 = Xmin;
                double y0 = CurveFunctions.F(Xmin, BestA, BestB, BestC);
                using (Pen thin_pen = new Pen(Color.Blue, 0))
                {
                    for (double x = Xmin + Xstep; x <= Xmax; x += Xstep)
                    {
                        double y1 = CurveFunctions.F(x, BestA, BestB, BestC);
                        e.Graphics.DrawLine(thin_pen,
                            (float)x0, (float)y0, (float)x, (float)y1);
                        x0 = x;
                        y0 = y1;
                        if (y0 > 1e8) break;
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
                const float xthick = 0.05f;
                const float ythick = 2f;
                
                gr.DrawLine(thin_pen, Xmin, 0, Xmax, 0);
                for (float x = 0.5f; x < Xmax; x += 0.5f)
                {
                    gr.DrawLine(thin_pen, x, -ythick, x, ythick);
                }

                gr.DrawLine(thin_pen, 0, Ymin, 0, Ymax);
                for (float y = 10f; y < Ymax; y += 10f)
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

            txtA.Clear();
            txtB.Clear();
            txtC.Clear();
            txtError.Clear();
            txtPercentError.Clear();
        }

        // Find parameters for a weibull curve fit.
        private void btnFit_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            txtA.Clear();
            txtB.Clear();
            txtC.Clear();
            txtError.Clear();
            txtPercentError.Clear();
            Application.DoEvents();
            DateTime start_time = DateTime.Now;

            // Find a good fit.
            // The final parameter, num_steps, determines how many initial
            // values are tested for a, b, c, and d. For example, if num_steps = 4,
            // then a, b, c, and d each take on 4 values for 4 ^ 4 = 256 initial points.
            double error = CurveFunctions.FindGoodFit(Points,
                out BestA, out BestB, out BestC, 10, 100);

            DateTime stop_time = DateTime.Now;
            TimeSpan elapsed = stop_time - start_time;
            Console.WriteLine("Time: " +
                elapsed.TotalSeconds.ToString("0.00") + " seconds");

            txtA.Text = BestA.ToString();
            txtB.Text = BestB.ToString();
            txtC.Text = BestC.ToString();

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
            BestA = double.Parse(txtA.Text);
            BestB = double.Parse(txtB.Text);
            BestC = double.Parse(txtC.Text);
            ShowError();
            picGraph.Refresh();
        }

        // Display the error.
        private void ShowError()
        {
            // Get the error.
            double error = Math.Sqrt(CurveFunctions.ErrorSquared(
                Points, BestA, BestB, BestC));
            txtError.Text = error.ToString();

            // Get the total of the function's values to
            // calculate a percentage.
            double total = 0;
            foreach (PointF pt in Points)
            {
                total += CurveFunctions.F(pt.X, BestA, BestB, BestC);
            }
            total = error / total * 100;
            txtPercentError.Text = total.ToString();
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtPercentError = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtError = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnFit = new System.Windows.Forms.Button();
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.rchEquation = new System.Windows.Forms.RichTextBox();
            this.btnGraph = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtC = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(246, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "%:";
            // 
            // txtPercentError
            // 
            this.txtPercentError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPercentError.Location = new System.Drawing.Point(284, 193);
            this.txtPercentError.Name = "txtPercentError";
            this.txtPercentError.Size = new System.Drawing.Size(118, 20);
            this.txtPercentError.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(246, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Error:";
            // 
            // txtError
            // 
            this.txtError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtError.Location = new System.Drawing.Point(284, 167);
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(118, 20);
            this.txtError.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "B:";
            // 
            // txtB
            // 
            this.txtB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtB.Location = new System.Drawing.Point(284, 115);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(118, 20);
            this.txtB.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "A:";
            // 
            // txtA
            // 
            this.txtA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtA.Location = new System.Drawing.Point(284, 89);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(118, 20);
            this.txtA.TabIndex = 2;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(326, 60);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnFit
            // 
            this.btnFit.Location = new System.Drawing.Point(245, 60);
            this.btnFit.Name = "btnFit";
            this.btnFit.Size = new System.Drawing.Size(75, 23);
            this.btnFit.TabIndex = 0;
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
            this.picGraph.TabIndex = 11;
            this.picGraph.TabStop = false;
            this.picGraph.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picGraph_MouseClick);
            this.picGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.picGraph_Paint);
            // 
            // rchEquation
            // 
            this.rchEquation.BackColor = System.Drawing.SystemColors.Control;
            this.rchEquation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rchEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rchEquation.Location = new System.Drawing.Point(269, 12);
            this.rchEquation.Multiline = false;
            this.rchEquation.Name = "rchEquation";
            this.rchEquation.Size = new System.Drawing.Size(132, 46);
            this.rchEquation.TabIndex = 22;
            this.rchEquation.Text = "a + b * ecx";
            // 
            // btnGraph
            // 
            this.btnGraph.Location = new System.Drawing.Point(284, 219);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(75, 23);
            this.btnGraph.TabIndex = 7;
            this.btnGraph.Text = "Graph";
            this.btnGraph.UseVisualStyleBackColor = true;
            this.btnGraph.Click += new System.EventHandler(this.btnGraph_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(246, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "C:";
            // 
            // txtC
            // 
            this.txtC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtC.Location = new System.Drawing.Point(284, 141);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(118, 20);
            this.txtC.TabIndex = 4;
            // 
            // howto_exponential_curve_fit_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 254);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.btnGraph);
            this.Controls.Add(this.rchEquation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPercentError);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnFit);
            this.Controls.Add(this.picGraph);
            this.Name = "howto_exponential_curve_fit_Form1";
            this.Text = "howto_exponential_curve_fit";
            this.Load += new System.EventHandler(this.howto_exponential_curve_fit_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPercentError;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnFit;
        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.RichTextBox rchEquation;
        private System.Windows.Forms.Button btnGraph;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtC;
    }
}

