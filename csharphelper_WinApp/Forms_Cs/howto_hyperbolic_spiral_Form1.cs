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
     public partial class howto_hyperbolic_spiral_Form1:Form
  { 


        public howto_hyperbolic_spiral_Form1()
        {
            InitializeComponent();
        }

        private void picSpiral_Resize(object sender, EventArgs e)
        {
            picSpiral.Refresh();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            picSpiral.Refresh();
        }

        // Pens to use for different spirals.
        private Pen[] SpiralPens =
        {
            Pens.Red, Pens.Green, Pens.Purple,
            Pens.Blue, Pens.Magenta, 
        };

        // Draw the spiral(s).
        private void picSpiral_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(picSpiral.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            try
            {
                float A = float.Parse(txtA.Text);
                int num_spirals = int.Parse(txtNumSpirals.Text);

                // Angular spacing between different spirals.
                float d_start = (float)(2 * Math.PI / num_spirals);

                // The angle where the next spiral starts.
                float start_angle = 0;

                // Center point.
                PointF center = new PointF(
                    picSpiral.ClientSize.Width / 2,
                    picSpiral.ClientSize.Height / 2);

                // Draw axes.
                e.Graphics.DrawLine(Pens.Black,
                    center.X, 0,
                    center.X, picSpiral.ClientSize.Height);
                e.Graphics.DrawLine(Pens.Black,
                    0, center.Y,
                    picSpiral.ClientSize.Width, center.Y);

                // Draw the spiral on only part of the PictureBox.
                Rectangle rect = new Rectangle(25, 50, 150, 150);

                // Find the maximum distance to the rectangle's corners.
                float max_r = Distance(center, rect);

                // Draw the spirals.
                for (int i = 0; i < num_spirals; i++)
                {
                    List<PointF> points =
                        GetSpiralPoints(0.1f, center, A, start_angle, max_r);
                    e.Graphics.DrawLines(SpiralPens[i % SpiralPens.Length],
                        points.ToArray());
                    start_angle += d_start;
                }

                // Draw the target rectangle.
                e.Graphics.DrawRectangle(Pens.Black, rect);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Return points that define a spiral.
        private List<PointF> GetSpiralPoints(
            float dtheta, PointF center, float A,
            float angle_offset, float max_r)
        {
            // Get the points.
            float max_theta = A / 2f;
            List<PointF> points = new List<PointF>();
            for (float theta = max_theta; ; theta -= dtheta)
            {
                // Calculate r.
                float r = A / theta;

                // Convert to Cartesian coordinates.
                float x, y;
                PolarToCartesian(r, theta + angle_offset, out x, out y);

                // Center.
                x += center.X;
                y += center.Y;

                // Create the point.
                points.Add(new PointF((float)x, (float)y));

                // If we have gone far enough, stop.
                if (r > max_r) break;
            }
            return points;
        }

        // Draw a spiral.
        private void DrawHyperbolicSpiral(
            float min_theta, float max_theta, float dtheta,
            PointF center, float A,
            float angle_offset, Rectangle rect, Graphics gr, Pen pen)
        {
            // Find the maximum distance to the rectangle's corners.
            float max_dist = Distance(center, rect);

            // Draw.
            List<PointF> points = new List<PointF>();
            for (float theta = max_theta; theta >= min_theta; theta -= dtheta)
            {
                // Calculate r.
                float r = A / theta;

                // Convert to Cartesian coordinates.
                float x, y;
                PolarToCartesian(r, theta + angle_offset, out x, out y);

                // Center.
                x += center.X;
                y += center.Y;

                // Create the point.
                points.Add(new PointF((float)x, (float)y));

                // If we have gone far enough, stop.
                if (r > max_dist) break;
            }
            gr.DrawLines(pen, points.ToArray());
        }

        // Return the distance between two points.
        private float Distance(PointF point1, PointF point2)
        {
            float dx = point1.X - point2.X;
            float dy = point1.Y - point2.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        // Return the distance between the point
        // and the rectangle's farthest corner.
        private float Distance(PointF point, Rectangle rect)
        {
            float max_dist = Distance(point, new PointF(rect.Left, rect.Top));

            float test_dist = Distance(point, new PointF(rect.Left, rect.Bottom));
            if (max_dist < test_dist) max_dist = test_dist;

            test_dist = Distance(point, new PointF(rect.Right, rect.Top));
            if (max_dist < test_dist) max_dist = test_dist;

            test_dist = Distance(point, new PointF(rect.Right, rect.Bottom));
            if (max_dist < test_dist) max_dist = test_dist;

            return max_dist;
        }

        private void PolarToCartesian(float r, float theta, out float x, out float y)
        {
            x = (float)(r * Math.Cos(theta));
            y = (float)(r * Math.Sin(theta));
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
            this.txtNumSpirals = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDraw = new System.Windows.Forms.Button();
            this.txtA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picSpiral = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSpiral)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNumSpirals
            // 
            this.txtNumSpirals.Location = new System.Drawing.Point(69, 40);
            this.txtNumSpirals.Name = "txtNumSpirals";
            this.txtNumSpirals.Size = new System.Drawing.Size(67, 20);
            this.txtNumSpirals.TabIndex = 4;
            this.txtNumSpirals.Text = "1";
            this.txtNumSpirals.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "# Spirals:";
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(225, 12);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 5;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(69, 14);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(67, 20);
            this.txtA.TabIndex = 3;
            this.txtA.Text = "200";
            this.txtA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "A:";
            // 
            // picSpiral
            // 
            this.picSpiral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picSpiral.BackColor = System.Drawing.Color.White;
            this.picSpiral.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picSpiral.Location = new System.Drawing.Point(12, 66);
            this.picSpiral.Name = "picSpiral";
            this.picSpiral.Size = new System.Drawing.Size(288, 253);
            this.picSpiral.TabIndex = 21;
            this.picSpiral.TabStop = false;
            this.picSpiral.Resize += new System.EventHandler(this.picSpiral_Resize);
            this.picSpiral.Paint += new System.Windows.Forms.PaintEventHandler(this.picSpiral_Paint);
            // 
            // howto_hyperbolic_spiral_Form1
            // 
            this.AcceptButton = this.btnDraw;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 331);
            this.Controls.Add(this.txtNumSpirals);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picSpiral);
            this.Name = "howto_hyperbolic_spiral_Form1";
            this.Text = "howto_hyperbolic_spiral";
            ((System.ComponentModel.ISupportInitialize)(this.picSpiral)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumSpirals;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picSpiral;
    }
}

