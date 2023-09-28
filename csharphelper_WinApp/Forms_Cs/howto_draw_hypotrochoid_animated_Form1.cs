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
     public partial class howto_draw_hypotrochoid_animated_Form1:Form
  { 


        public howto_draw_hypotrochoid_animated_Form1()
        {
            InitializeComponent();
        }

        // The angle from one circle's center to the other.
        private float theta = 0;
        private float dtheta;

        // Drawing parameters.
        private int A, B, C, wid, hgt, cx, cy;
        private double max_t;
        private List<PointF> points;

        // Draw the hypotrochoid.
        private void btnDraw_Click(object sender, EventArgs e)
        {
            A = int.Parse(txtA.Text);
            B = int.Parse(txtB.Text);
            C = int.Parse(txtC.Text);
            max_t = 2 * Math.PI * B / GCD(A, B);

            wid = picCanvas.ClientSize.Width;
            hgt = picCanvas.ClientSize.Height;
            cx = wid / 2;
            cy = hgt / 2;

            points = new List<PointF>();
            points.Add(new PointF(cx + A - B + C, cy));
            theta = 0;
            dtheta = (float)(Math.PI * 2 / int.Parse(txtFrPerRev.Text));

            tmrDraw.Enabled = true;
        }

        // Redraw the curve.
        private void tmrDraw_Tick(object sender, EventArgs e)
        {
            theta += dtheta;
            DrawCurve();
        }

        // Draw the curve.
        private void DrawCurve()
        {
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                // Draw the outer circle.
                gr.DrawEllipse(Pens.Blue, cx - A, cy - A, 2 * A, 2 * A);

                // Draw the inner circle.
                int r = A - B;
                float cx1 = (float)(cx + r * Math.Cos(theta));
                float cy1 = (float)(cy + r * Math.Sin(theta));
                gr.DrawEllipse(Pens.Blue, cx1 - B, cy1 - B, 2 * B, 2 * B);

                // Add the next point.
                PointF new_point = new PointF(
                    (float)(cx + X(theta, A, B, C)),
                    (float)(cy + Y(theta, A, B, C)));
                points.Add(new_point);

                // Draw the line.
                gr.DrawLine(Pens.Blue, new PointF(cx1, cy1), new_point);

                // Draw the points.
                if (points.Count > 1) gr.DrawLines(Pens.Red, points.ToArray());
            }

            picCanvas.Image = bm;

            if (theta > max_t) tmrDraw.Enabled = false;
        }

        // The parametric function X(t).
        private double X(double t, double A, double B, double C)
        {
            return (A - B) * Math.Cos(t) + C * Math.Cos(t * (A - B) / B);
        }

        // The parametric function Y(t).
        private double Y(double t, double A, double B, double C)
        {
            return (A - B) * Math.Sin(t) - C * Math.Sin(t * (A - B) / B);
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
            this.components = new System.ComponentModel.Container();
            this.txtA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtC = new System.Windows.Forms.TextBox();
            this.btnDraw = new System.Windows.Forms.Button();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFrPerRev = new System.Windows.Forms.TextBox();
            this.tmrDraw = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(35, 12);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(49, 20);
            this.txtA.TabIndex = 0;
            this.txtA.Text = "50";
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
            this.label2.Location = new System.Drawing.Point(90, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "B:";
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(113, 12);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(49, 20);
            this.txtB.TabIndex = 2;
            this.txtB.Text = "30";
            this.txtB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "C:";
            // 
            // txtC
            // 
            this.txtC.Location = new System.Drawing.Point(192, 12);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(49, 20);
            this.txtC.TabIndex = 4;
            this.txtC.Text = "50";
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
            this.label4.Location = new System.Drawing.Point(247, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Fr/rev:";
            // 
            // txtFrPerRev
            // 
            this.txtFrPerRev.Location = new System.Drawing.Point(292, 12);
            this.txtFrPerRev.Name = "txtFrPerRev";
            this.txtFrPerRev.Size = new System.Drawing.Size(49, 20);
            this.txtFrPerRev.TabIndex = 8;
            this.txtFrPerRev.Text = "20";
            this.txtFrPerRev.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.txtFrPerRev, "Number of frames per revolution.");
            // 
            // tmrDraw
            // 
            this.tmrDraw.Tick += new System.EventHandler(this.tmrDraw_Tick);
            // 
            // howto_draw_hypotrochoid_animated_Form1
            // 
            this.AcceptButton = this.btnDraw;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 364);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFrPerRev);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtA);
            this.Name = "howto_draw_hypotrochoid_animated_Form1";
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
        private System.Windows.Forms.TextBox txtFrPerRev;
        private System.Windows.Forms.Timer tmrDraw;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

