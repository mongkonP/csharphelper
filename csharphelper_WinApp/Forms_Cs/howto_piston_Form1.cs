using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_piston_Form1:Form
  { 


        public howto_piston_Form1()
        {
            InitializeComponent();
        }

        // Geometry.
        private float Ax = 10;
        private float Cx = 200;
        private float Cy;
        private float L1 = 100;
        private float L2 = 100;
        private float Radius = 30;
        private float X, Xmin, Xmax, Dx;
        private const float PistonLength = 30;
        private const float PistonRadius = 30;
        private const float ArmLength = 20;
        private const float ArmRadius = 10;
        private const float Gap = 4;

        // For displCying the current image.
        private Bitmap Picture = null;
        private Graphics Gr;

        // Find the points where the two circles intersect.
        private int FindCircleCircleIntersections(
            float cx0, float cy0, float radius0,
            float cx1, float cy1, float radius1,
            out PointF intersection1, out PointF intersection2)
        {
            // Find the distance between the centers.
            float dx = cx0 - cx1;
            float dy = cy0 - cy1;
            double dist = Math.Sqrt(dx * dx + dy * dy);

            // See how manhym solutions there are.
            if (dist > radius0 + radius1)
            {
                // No solutions, the circles are too far apart.
                intersection1 = new PointF(float.NaN, float.NaN);
                intersection2 = new PointF(float.NaN, float.NaN);
                return 0;
            }
            else if (dist < Math.Abs(radius0 - radius1))
            {
                // No solutions, one circle contains the other.
                intersection1 = new PointF(float.NaN, float.NaN);
                intersection2 = new PointF(float.NaN, float.NaN);
                return 0;
            }
            else if ((dist == 0) && (radius0 == radius1))
            {
                // No solutions, the circles coincide.
                intersection1 = new PointF(float.NaN, float.NaN);
                intersection2 = new PointF(float.NaN, float.NaN);
                return 0;
            }
            else
            {
                // Find a and h.
                double a = (radius0 * radius0 -
                    radius1 * radius1 + dist * dist) / (2 * dist);
                double h = Math.Sqrt(radius0 * radius0 - a * a);

                // Find P2.
                double cx2 = cx0 + a * (cx1 - cx0) / dist;
                double cy2 = cy0 + a * (cy1 - cy0) / dist;

                // Get the points P3.
                intersection1 = new PointF(
                    (float)(cx2 + h * (cy1 - cy0) / dist),
                    (float)(cy2 - h * (cx1 - cx0) / dist));
                intersection2 = new PointF(
                    (float)(cx2 - h * (cy1 - cy0) / dist),
                    (float)(cy2 + h * (cx1 - cx0) / dist));

                // See if we have 1 or 2 solutions.
                if (dist == radius0 + radius1) return 1;
                return 2;
            }
        }

        // Move the piston.
        private void tmrMovePiston_Tick(object sender, EventArgs e)
        {
            X += Dx;

            if ((X < Xmin) || (X > Xmax))
            {
                Dx = -Dx;
                X += 2 * Dx;
            }

            DrawSystem();
            picCanvas.Refresh();
        }

        // Draw everything.
        private void DrawSystem()
        {
            Gr.Clear(this.BackColor);
            Gr.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen custom_pen = new Pen(Color.Blue, 2))
            {
                // Draw the wheel.
                RectangleF wheel_rect = new RectangleF(
                    Cx - Radius, Cy - Radius,
                    2 * Radius, 2 * Radius);
                Gr.FillEllipse(Brushes.LightBlue, wheel_rect);
                custom_pen.Color = Color.Blue;
                custom_pen.Width = 2;
                Gr.DrawEllipse(custom_pen, wheel_rect);

                // Draw the cylinder.
                float cylinder_length = L2 + PistonLength + 2 * Gap;
                float cylinder_radius = PistonRadius + 2 * Gap;
                PointF[] cylinder_lines = new PointF[]
                {
                    new PointF(Ax + cylinder_length, Cy - cylinder_radius / 2 + Gap),
                    new PointF(Ax + cylinder_length, Cy - cylinder_radius / 2),
                    new PointF(Ax, Cy - cylinder_radius / 2),
                    new PointF(Ax, Cy + cylinder_radius / 2),
                    new PointF(Ax + cylinder_length, Cy + cylinder_radius / 2),
                    new PointF(Ax + cylinder_length, Cy + cylinder_radius / 2 - Gap),
                };
                Gr.DrawLines(custom_pen, cylinder_lines);

                // Draw the piston.
                GraphicsPath piston_path = new GraphicsPath();
                PointF[] piston_lines = new PointF[]
                {
                    new PointF(X + PistonLength, Cy - PistonRadius / 2),
                    new PointF(X, Cy - PistonRadius / 2),
                    new PointF(X, Cy + PistonRadius / 2),
                    new PointF(X + PistonLength, Cy + PistonRadius / 2),
                    new PointF(X + PistonLength, Cy + ArmRadius / 2),
                    new PointF(X + PistonLength + ArmLength, Cy + ArmRadius / 2),
                    new PointF(X + PistonLength + ArmLength, Cy - ArmRadius / 2),
                    new PointF(X + PistonLength, Cy - ArmRadius / 2),
                };
                piston_path.AddPolygon(piston_lines);
                Gr.FillPath(Brushes.LightGreen, piston_path);
                custom_pen.Color = Color.Green;
                Gr.DrawPath(custom_pen, piston_path);
                Gr.DrawLine(custom_pen, X + Gap, Cy - PistonRadius / 2, X + Gap, Cy + PistonRadius / 2);
                Gr.DrawLine(custom_pen, X + 2 * Gap, Cy - PistonRadius / 2, X + 2 * Gap, Cy + PistonRadius / 2);

                // Find the ends of the linkage.
                float linkage_x1 = X + PistonLength + ArmLength;
                float linkage_y1 = Cy;
                PointF pt1, pt2;
                FindCircleCircleIntersections(
                    linkage_x1, linkage_y1, L1,
                    Cx, Cy, Radius,
                    out pt1, out pt2);
                float linkage_x2, linkage_y2;
                if (Dx > 0)
                {
                    linkage_x2 = pt1.X;
                    linkage_y2 = pt1.Y;
                }
                else
                {
                    linkage_x2 = pt2.X;
                    linkage_y2 = pt2.Y;
                }

                // Draw the linkage.
                custom_pen.Color = Color.Green;
                custom_pen.Width = 5;
                Gr.DrawLine(custom_pen, linkage_x1, linkage_y1, linkage_x2, linkage_y2);
                custom_pen.Color = Color.LightGreen;
                custom_pen.Width = 2;
                Gr.DrawLine(custom_pen, linkage_x1, linkage_y1, linkage_x2, linkage_y2);

                // Draw joints.
                Gr.FillEllipse(Brushes.Black, Cx - 4, Cy - 4, 8, 8);
                Gr.FillEllipse(Brushes.Green,
                    linkage_x1 - 4, linkage_y1 - 4, 8, 8);
                Gr.FillEllipse(Brushes.Green,
                    linkage_x2 - 4, linkage_y2 - 4, 8, 8);
            }
        }

        // Start or stop the timer.
        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (btnStartStop.Text == "Start")
            {
                btnStartStop.Text = "Stop";
                L1 = float.Parse(txtL1.Text);
                Radius = float.Parse(txtRadius.Text);

                Cy = picCanvas.ClientSize.Height / 2;
                L2 = 2 * Radius;
                Xmin = Ax + Gap;
                Xmax = Xmin + L2;
                X = Xmin;
                Dx = 6;

                Cx = Xmin + PistonLength + ArmLength + L1 + Radius;

                Picture = new Bitmap(
                    picCanvas.ClientSize.Width,
                    picCanvas.ClientSize.Height);
                Gr = Graphics.FromImage(Picture);
                picCanvas.Image = Picture;

                tmrMovePiston.Enabled = true;
            }
            else
            {
                btnStartStop.Text = "Start";
                tmrMovePiston.Enabled = false;
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
            this.components = new System.ComponentModel.Container();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.txtRadius = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.tmrMovePiston = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtL1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(99, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(273, 190);
            this.picCanvas.TabIndex = 28;
            this.picCanvas.TabStop = false;
            // 
            // txtRadius
            // 
            this.txtRadius.Location = new System.Drawing.Point(43, 38);
            this.txtRadius.Name = "txtRadius";
            this.txtRadius.Size = new System.Drawing.Size(50, 20);
            this.txtRadius.TabIndex = 24;
            this.txtRadius.Text = "30";
            this.txtRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "L:";
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(15, 64);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(78, 23);
            this.btnStartStop.TabIndex = 25;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // tmrMovePiston
            // 
            this.tmrMovePiston.Tick += new System.EventHandler(this.tmrMovePiston_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "R:";
            // 
            // txtL1
            // 
            this.txtL1.Location = new System.Drawing.Point(43, 12);
            this.txtL1.Name = "txtL1";
            this.txtL1.Size = new System.Drawing.Size(50, 20);
            this.txtL1.TabIndex = 23;
            this.txtL1.Text = "100";
            this.txtL1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // howto_piston_Form1
            // 
            this.AcceptButton = this.btnStartStop;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 214);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.txtRadius);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtL1);
            this.Name = "howto_piston_Form1";
            this.Text = "howto_piston";
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.TextBox txtRadius;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Timer tmrMovePiston;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtL1;
    }
}

