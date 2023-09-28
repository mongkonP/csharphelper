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
     public partial class howto_draw_hypotrochoid_Form1:Form
  { 


        public howto_draw_hypotrochoid_Form1()
        {
            InitializeComponent();
        }

        // Draw the hypotrochoid.
        private void btnDraw_Click(object sender, EventArgs e)
        {
            int A = int.Parse(txtA.Text);
            int B = int.Parse(txtB.Text);
            int C = int.Parse(txtC.Text);
            int iter = int.Parse(txtIter.Text);

            int wid = picCanvas.ClientSize.Width;
            int hgt = picCanvas.ClientSize.Height;
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                int cx = wid / 2;
                int cy = hgt / 2;
                double t = 0;
                double dt = Math.PI / iter;
                double max_t = 2 * Math.PI * B / GCD(A, B);
                double x1 = cx + X(t, A, B, C);
                double y1 = cy + Y(t, A, B, C);
                List<PointF> points = new List<PointF>();
                points.Add(new PointF((float)x1, (float)y1));
                while (t <= max_t)
                {
                    t += dt;
                    x1 = cx + X(t, A, B, C);
                    y1 = cy + Y(t, A, B, C);
                    points.Add(new PointF((float)x1, (float)y1));
                }
                // Draw the polygon.
                gr.DrawPolygon(Pens.Red, points.ToArray());
            }

            picCanvas.Image = bm;
        }

        // The parametric function X(t).
        private double X(double t, double A, double B, double C)
        {
            return (A - B) * Math.Cos(t) + C * Math.Cos((A - B) / B * t);
        }

        // The parametric function Y(t).
        private double Y(double t, double A, double B, double C)
        {
            return (A - B) * Math.Sin(t) - C * Math.Sin((A - B) / B * t);
        }

        // Use Euclid's algorithm to calculate the
        // greatest common divisor (GCD) of two numbers.
        private long GCD(long a, long b)
        {
            // Make a >= b.
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a < b)
            {
                long tmp = a;
                a = b;
                b = tmp;
            }

            // Pull out remainders.
            for (;;)
            {
                long remainder = a % b;
                if (remainder == 0) return b;
                a = b;
                b = remainder;
            };
        }

        // Return the least common multiple
        // (LCM) of two numbers.
        private long LCM(long a, long b)
        {
            return a * b / GCD(a, b);
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
            this.txtA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtC = new System.Windows.Forms.TextBox();
            this.btnDraw = new System.Windows.Forms.Button();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIter = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(35, 12);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(49, 20);
            this.txtA.TabIndex = 0;
            this.txtA.Text = "80";
            this.txtA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "A:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "B:";
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(122, 12);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(49, 20);
            this.txtB.TabIndex = 2;
            this.txtB.Text = "14";
            this.txtB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "C:";
            // 
            // txtC
            // 
            this.txtC.Location = new System.Drawing.Point(210, 12);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(49, 20);
            this.txtC.TabIndex = 4;
            this.txtC.Text = "30";
            this.txtC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnDraw
            // 
            this.btnDraw.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDraw.Location = new System.Drawing.Point(146, 49);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 6;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(12, 90);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(342, 262);
            this.picCanvas.TabIndex = 7;
            this.picCanvas.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(274, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Iter:";
            // 
            // txtIter
            // 
            this.txtIter.Location = new System.Drawing.Point(305, 12);
            this.txtIter.Name = "txtIter";
            this.txtIter.Size = new System.Drawing.Size(49, 20);
            this.txtIter.TabIndex = 8;
            this.txtIter.Text = "100";
            this.txtIter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // howto_draw_hypotrochoid_Form1
            // 
            this.AcceptButton = this.btnDraw;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 364);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIter);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtA);
            this.Name = "howto_draw_hypotrochoid_Form1";
            this.Text = "howto_draw_hypotrochoid";
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIter;
    }
}

