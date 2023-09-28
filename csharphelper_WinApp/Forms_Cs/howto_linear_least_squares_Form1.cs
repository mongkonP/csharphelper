using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

using howto_linear_least_squares;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_linear_least_squares_Form1:Form
  { 


        public howto_linear_least_squares_Form1()
        {
            InitializeComponent();
        }

        // Drawing constants.
        private const float Xmin = -10.0f;
        private const float Xmax =  10.0f;
        private const float Ymin = -10.0f;
        private const float Ymax =  10.0f;
        private Matrix DrawingTransform;
        private Matrix InverseTransform;

        private bool HasSolution = false;
        private double BestM, BestB;
        private List<PointF> Points = new List<PointF>();

        // Make a drawing transformation.
        private void howto_linear_least_squares_Form1_Load(object sender, EventArgs e)
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

            // Draw the axes.
            DrawAxes(e.Graphics);

            // Draw the curve.
            if (HasSolution)
            {
                using (Pen thin_pen = new Pen(Color.Blue, 0))
                {
                    double y0 = BestM * Xmin + BestB;
                    double y1 = BestM * Xmax + BestB;
                    e.Graphics.DrawLine(thin_pen,
                        (float)Xmin, (float)y0, (float)Xmax, (float)y1);
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

            txtM.Clear();
            txtB.Clear();
            txtError.Clear();
        }

        // Find parameters for a weibull curve fit.
        private void btnFit_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            txtM.Clear();
            txtB.Clear();
            txtError.Clear();
            Application.DoEvents();
            DateTime start_time = DateTime.Now;

            // Find a good fit.
            CurveFunctions.FindLinearLeastSquaresFit(Points, out BestM, out BestB);
            HasSolution = true;

            DateTime stop_time = DateTime.Now;
            TimeSpan elapsed = stop_time - start_time;
            Console.WriteLine("Time: " +
                elapsed.TotalSeconds.ToString("0.00") + " seconds");

            txtM.Text = BestM.ToString();
            txtB.Text = BestB.ToString();

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
            BestM = double.Parse(txtM.Text);
            BestB = double.Parse(txtB.Text);
            ShowError();
            picGraph.Refresh();
        }

        // Display the error.
        private void ShowError()
        {
            // Get the error.
            double error = Math.Sqrt(CurveFunctions.ErrorSquared(
                Points, BestM, BestB));
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
            this.txtB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtM = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnFit = new System.Windows.Forms.Button();
            this.picGraph = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGraph
            // 
            this.btnGraph.Location = new System.Drawing.Point(284, 219);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(75, 23);
            this.btnGraph.TabIndex = 33;
            this.btnGraph.Text = "Graph";
            this.btnGraph.UseVisualStyleBackColor = true;
            this.btnGraph.Click += new System.EventHandler(this.btnGraph_Click);
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
            this.rchEquation.TabIndex = 39;
            this.rchEquation.Text = "y = m * x + b";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(246, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Error:";
            // 
            // txtError
            // 
            this.txtError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtError.Location = new System.Drawing.Point(284, 141);
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(118, 20);
            this.txtError.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "b:";
            // 
            // txtB
            // 
            this.txtB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtB.Location = new System.Drawing.Point(284, 115);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(118, 20);
            this.txtB.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "m:";
            // 
            // txtM
            // 
            this.txtM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtM.Location = new System.Drawing.Point(284, 89);
            this.txtM.Name = "txtM";
            this.txtM.Size = new System.Drawing.Size(118, 20);
            this.txtM.TabIndex = 28;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(326, 60);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 27;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnFit
            // 
            this.btnFit.Location = new System.Drawing.Point(245, 60);
            this.btnFit.Name = "btnFit";
            this.btnFit.Size = new System.Drawing.Size(75, 23);
            this.btnFit.TabIndex = 26;
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
            this.picGraph.TabIndex = 34;
            this.picGraph.TabStop = false;
            this.picGraph.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picGraph_MouseClick);
            this.picGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.picGraph_Paint);
            // 
            // howto_linear_least_squares_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 254);
            this.Controls.Add(this.btnGraph);
            this.Controls.Add(this.rchEquation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtM);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnFit);
            this.Controls.Add(this.picGraph);
            this.Name = "howto_linear_least_squares_Form1";
            this.Text = "howto_linear_least_squares";
            this.Load += new System.EventHandler(this.howto_linear_least_squares_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGraph;
        private System.Windows.Forms.RichTextBox rchEquation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtM;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnFit;
        private System.Windows.Forms.PictureBox picGraph;
    }
}

