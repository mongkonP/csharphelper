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
     public partial class howto_rose_curves_Form1:Form
  { 


        public howto_rose_curves_Form1()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            float A = float.Parse(txtA.Text);
            int n = int.Parse(txtN.Text);
            int d = int.Parse(txtD.Text);

            // Make the Bitmap and associated Graphics object.
            Bitmap bm = new Bitmap(300, 300);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(Color.White);
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                // Set up a transformation to map the region
                // x/y = A +/- 0.1 onto the Bitmap.
                RectangleF rect = new RectangleF(
                    -A - 0.1f, -A - 0.1f, 2 * A + 0.2f, 2 * A + 0.2f);
                PointF[] pts =
                {
                    new PointF(0, bm.Height),
                    new PointF(bm.Width, bm.Height),
                    new PointF(0, 0),
                };
                gr.Transform = new Matrix(rect, pts);

                // Draw the curve.
                DrawCurve(gr, A, n, d);

                // Draw the axes.
                DrawAxes(gr, rect.Right);

                // Display the result and size the form to fit.
                picCurve.Image = bm;
                picCurve.SizeMode = PictureBoxSizeMode.AutoSize;
                this.ClientSize = new Size(
                    picCurve.Right + picCurve.Top,
                    picCurve.Bottom + picCurve.Top);
            }
        }

        private void DrawAxes(Graphics gr, float wxmax)
        {
            int xmax = (int)wxmax;
            using (Pen pen = new Pen(Color.Black, 0))
            {
                // Draw the X and Y axes.
                gr.DrawLine(pen, -wxmax, 0, wxmax, 0);
                gr.DrawLine(pen, 0, -wxmax, 0, wxmax);

                float tic = 0.1f;
                for (int x = -xmax; x <= xmax; x++)
                {
                    gr.DrawLine(pen, x, -tic, x, tic);
                    gr.DrawLine(pen, -tic, x, tic, x);
                }
            }
        }

        // Draw the curve.
        // n and d should be relatively prime.
        private void DrawCurve(Graphics gr, float A, int n, int d)
        {
            const int num_points = 1000;

            // Period is Pi * d if n and d are both odd. 2 * Pi * d otherwise.
            double period = Math.PI * d;
            if ((n % 2 == 0) || (d % 2 == 0)) period *= 2;

            double dtheta = period / num_points;
            List<PointF> points = new List<PointF>();
            double k = (double)n / d;
            for (int i = 0; i < num_points; i++)
            {
                double theta = i * dtheta;
                double r = A * Math.Cos(k * theta);
                float x = (float)(r * Math.Cos(theta));
                float y = (float)(r * Math.Sin(theta));

                points.Add(new PointF(x, y));
            }

            gr.FillPolygon(Brushes.LightBlue, points.ToArray());

            // Draw the curve.
            using (Pen pen = new Pen(Color.Red, 0))
            {
                gr.DrawLines(pen, points.ToArray());
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
            this.txtN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDraw = new System.Windows.Forms.Button();
            this.picCurve = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCurve)).BeginInit();
            this.SuspendLayout();
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(35, 38);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(52, 20);
            this.txtN.TabIndex = 3;
            this.txtN.Text = "3";
            this.txtN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "n:";
            // 
            // txtD
            // 
            this.txtD.Location = new System.Drawing.Point(35, 64);
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(52, 20);
            this.txtD.TabIndex = 5;
            this.txtD.Text = "4";
            this.txtD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "d:";
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(15, 150);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(72, 23);
            this.btnDraw.TabIndex = 6;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // picCurve
            // 
            this.picCurve.BackColor = System.Drawing.Color.White;
            this.picCurve.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCurve.Location = new System.Drawing.Point(93, 12);
            this.picCurve.Name = "picCurve";
            this.picCurve.Size = new System.Drawing.Size(300, 300);
            this.picCurve.TabIndex = 7;
            this.picCurve.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "A:";
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(35, 12);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(52, 20);
            this.txtA.TabIndex = 1;
            this.txtA.Text = "2.0";
            this.txtA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // howto_rose_curves_Form1
            // 
            this.AcceptButton = this.btnDraw;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 322);
            this.Controls.Add(this.picCurve);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.txtD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.label1);
            this.Name = "howto_rose_curves_Form1";
            this.Text = "howto_rose_curves";
            ((System.ComponentModel.ISupportInitialize)(this.picCurve)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.PictureBox picCurve;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtA;
    }
}

