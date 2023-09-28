using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

// See https://en.wikipedia.org/wiki/Weierstrass_function

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_weierstrass_function_Form1:Form
  { 


        public howto_weierstrass_function_Form1()
        {
            InitializeComponent();
        }

        private float A = 0.5f;
        private int B, MinB;

        private void howto_weierstrass_function_Form1_Load(object sender, EventArgs e)
        {
            scrA.Maximum = 99 + scrA.LargeChange - 1;
            SetMinB();
            DrawGraph();
        }

        private void SetMinB()
        {
            MinB = (int)Math.Ceiling((1 + 1.5 * Math.PI) / A);
            if (MinB % 2  == 0) MinB++;
            lblB.Text = "(odd ≥ " + MinB.ToString() + ")";
            if (B < MinB)
            {
                B = MinB;
                txtB.Text = B.ToString();
            }
        }

        private void scrA_Scroll(object sender, ScrollEventArgs e)
        {
            A = scrA.Value / 100f;  
            lblA.Text = A.ToString("0.00");

            SetMinB();
            DrawGraph();
        }

        private void txtB_TextChanged(object sender, EventArgs e)
        {
            int b;
            if ((int.TryParse(txtB.Text, out b)) &&
                (b >= MinB) &&
                (b % 2 == 1))
            {
                B = b;
                DrawGraph();
            }
        }

        // Draw the graph.
        private void DrawGraph()
        {
            const float wxmin = -2;
            const float wxmax = 2;
            const float wymin = -2;
            const float wymax = 2;

            int wid = picGraph.ClientSize.Width;
            int hgt = picGraph.ClientSize.Height;
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                RectangleF rect = new RectangleF(
                    wxmin, wymin, (wxmax - wxmin), (wymax - wymin));
                PointF[] points =
                {
                    new PointF(0, hgt),
                    new PointF(wid, hgt),
                    new PointF(0, 0),
                };
                gr.Transform = new Matrix(rect, points);
                Matrix inverse = gr.Transform;
                inverse.Invert();

                // Draw the axes.
                using (Pen pen = new Pen(Color.Red, 0))
                {
                    gr.DrawLine(pen, wxmin, 0, wxmax, 0);
                    gr.DrawLine(pen, 0, wymin, 0, wymax);
                }

                // Plot the function.
                // Convert X coordinates for each pixel into world coordinates.
                PointF[] values = new PointF[wid];
                for (int i = 0; i < wid; i++) values[i].X = i;
                inverse.TransformPoints(values);

                // Generate Y values.
                for (int i = 0; i < wid; i++)
                    values[i].Y = F(values[i].X, A, B);

                // Plot.
                using (Pen pen = new Pen(Color.Black, 0))
                {
                    gr.DrawLines(pen, values);
                }
            }

            picGraph.Image = bm;
        }

        // Return a value of the Weierstrass function.
        private float F(float x, float A, float B)
        {
            const int iterations = 100;
            double total = 0;
            for (int n = 0; n < iterations; n++)
            {
                double cos = Math.Cos(Math.Pow(B, n) * Math.PI * x);
                if (cos > 1) cos = 0;
                else if (cos < -1) cos = 0;

                total += Math.Pow(A, n) * cos;
            }
            return (float)total;
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
            this.label1 = new System.Windows.Forms.Label();
            this.scrA = new System.Windows.Forms.HScrollBar();
            this.lblA = new System.Windows.Forms.Label();
            this.txtB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.picGraph = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "A:";
            // 
            // scrA
            // 
            this.scrA.Location = new System.Drawing.Point(32, 17);
            this.scrA.Maximum = 99;
            this.scrA.Minimum = 1;
            this.scrA.Name = "scrA";
            this.scrA.Size = new System.Drawing.Size(130, 15);
            this.scrA.TabIndex = 1;
            this.scrA.Value = 50;
            this.scrA.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrA_Scroll);
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(164, 17);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(28, 13);
            this.lblA.TabIndex = 2;
            this.lblA.Text = "0.50";
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(241, 14);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(32, 20);
            this.txtB.TabIndex = 4;
            this.txtB.Text = "7";
            this.txtB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtB.TextChanged += new System.EventHandler(this.txtB_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "B:";
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(279, 17);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(55, 13);
            this.lblB.TabIndex = 6;
            this.lblB.Text = "(odd >= 7)";
            // 
            // picGraph
            // 
            this.picGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraph.BackColor = System.Drawing.Color.White;
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraph.Location = new System.Drawing.Point(15, 41);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(357, 208);
            this.picGraph.TabIndex = 8;
            this.picGraph.TabStop = false;
            // 
            // howto_weierstrass_function_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.picGraph);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.lblA);
            this.Controls.Add(this.scrA);
            this.Controls.Add(this.label1);
            this.Name = "howto_weierstrass_function_Form1";
            this.Text = "howto_weierstrass_function";
            this.Load += new System.EventHandler(this.howto_weierstrass_function_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.HScrollBar scrA;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.PictureBox picGraph;
    }
}

