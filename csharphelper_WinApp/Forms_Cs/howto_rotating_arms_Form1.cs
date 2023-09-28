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
     public partial class howto_rotating_arms_Form1:Form
  { 


        public howto_rotating_arms_Form1()
        {
            InitializeComponent();
        }

        // Geometry.
        private float Ax = 100;
        private float Ay = 150;
        private float Cx = 200;
        private float Cy = 150;
        private float D = 100;
        private float L1 = 100;
        private float L2 = 110;
        private float L3 = 60;
        private float Radius = 30;

        // The wheel's current angle of rotation.
        private const double Dtheta = Math.PI / 10;
        private double Theta = 0;

        // For displaying the current image.
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

        // Rotate the wheel.
        private void tmrTurnWheel_Tick(object sender, EventArgs e)
        {
            Theta += Dtheta;
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

                // Find the ends of the linkage.
                float linkage_x1 = (float)(Cx + Math.Cos(Theta) * Radius);
                float linkage_y1 = (float)(Cy + Math.Sin(Theta) * Radius);
                PointF pt1, pt2;
                FindCircleCircleIntersections(
                    Ax, Ay, L2,
                    linkage_x1, linkage_y1, L1,
                    out pt1, out pt2);
                float linkage_x2 = pt1.X;
                float linkage_y2 = pt1.Y;

                // Draw the linkage.
                custom_pen.Color = Color.Green;
                custom_pen.Width = 5;
                Gr.DrawLine(custom_pen, linkage_x1, linkage_y1, linkage_x2, linkage_y2);
                custom_pen.Color = Color.Lime;
                custom_pen.Width = 2;
                Gr.DrawLine(custom_pen, linkage_x1, linkage_y1, linkage_x2, linkage_y2);

                // Draw the upper arm.
                custom_pen.Color = Color.Blue;
                custom_pen.Width = 5;
                Gr.DrawLine(custom_pen, Ax, Ay, linkage_x2, linkage_y2);
                custom_pen.Color = Color.LightBlue;
                custom_pen.Width = 2;
                Gr.DrawLine(custom_pen, Ax, Ay, linkage_x2, linkage_y2);

                // Draw the lower arm.
                float dx = Ax - linkage_x2;
                float dy = Ay - linkage_y2;
                double length = Math.Sqrt(dx * dx + dy * dy);
                float lower_x1 = (float)(Ax + dx * L3 / length);
                float lower_y1 = (float)(Ay + dy * L3 / length);
                custom_pen.Color = Color.Blue;
                custom_pen.Width = 5;
                Gr.DrawLine(custom_pen, Ax, Ay, lower_x1, lower_y1);
                custom_pen.Color = Color.LightBlue;
                custom_pen.Width = 2;
                Gr.DrawLine(custom_pen, Ax, Ay, lower_x1, lower_y1);

                // Draw joints.
                Gr.FillEllipse(Brushes.Black, Cx - 4, Cy - 4, 8, 8);
                Gr.FillEllipse(Brushes.Green,
                    linkage_x1 - 4, linkage_y1 - 4, 8, 8);
                Gr.FillEllipse(Brushes.Green,
                    linkage_x2 - 4, linkage_y2 - 4, 8, 8);
                Gr.FillEllipse(Brushes.Black, Ax - 4, Ay - 4, 8, 8);
                Gr.FillEllipse(Brushes.Blue, lower_x1 - 4, lower_y1 - 4, 8, 8);
            }
        }

        // Start or stop the timer.
        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (btnStartStop.Text == "Start")
            {
                btnStartStop.Text = "Stop";
                D = float.Parse(txtD.Text);
                L1 = float.Parse(txtL1.Text);
                L2 = float.Parse(txtL2.Text);
                L3 = float.Parse(txtL3.Text);
                Cx = Ax + D;
                Radius = float.Parse(txtRadius.Text);
                Theta = 0;
                Picture = new Bitmap(
                    picCanvas.ClientSize.Width,
                    picCanvas.ClientSize.Height);
                Gr = Graphics.FromImage(Picture);
                picCanvas.Image = Picture;

                tmrTurnWheel.Enabled = true;
            }
            else
            {
                btnStartStop.Text = "Start";
                tmrTurnWheel.Enabled = false;
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
            this.txtD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRadius = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtL3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tmrTurnWheel = new System.Windows.Forms.Timer(this.components);
            this.txtL2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtL1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartStop = new System.Windows.Forms.Button();
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
            this.picCanvas.Size = new System.Drawing.Size(273, 240);
            this.picCanvas.TabIndex = 22;
            this.picCanvas.TabStop = false;
            // 
            // txtD
            // 
            this.txtD.Location = new System.Drawing.Point(43, 12);
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(50, 20);
            this.txtD.TabIndex = 11;
            this.txtD.Text = "100";
            this.txtD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "D:";
            // 
            // txtRadius
            // 
            this.txtRadius.Location = new System.Drawing.Point(43, 116);
            this.txtRadius.Name = "txtRadius";
            this.txtRadius.Size = new System.Drawing.Size(50, 20);
            this.txtRadius.TabIndex = 17;
            this.txtRadius.Text = "30";
            this.txtRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "R:";
            // 
            // txtL3
            // 
            this.txtL3.Location = new System.Drawing.Point(43, 90);
            this.txtL3.Name = "txtL3";
            this.txtL3.Size = new System.Drawing.Size(50, 20);
            this.txtL3.TabIndex = 15;
            this.txtL3.Text = "60";
            this.txtL3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "L3:";
            // 
            // tmrTurnWheel
            // 
            this.tmrTurnWheel.Tick += new System.EventHandler(this.tmrTurnWheel_Tick);
            // 
            // txtL2
            // 
            this.txtL2.Location = new System.Drawing.Point(43, 64);
            this.txtL2.Name = "txtL2";
            this.txtL2.Size = new System.Drawing.Size(50, 20);
            this.txtL2.TabIndex = 14;
            this.txtL2.Text = "110";
            this.txtL2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "L2:";
            // 
            // txtL1
            // 
            this.txtL1.Location = new System.Drawing.Point(43, 38);
            this.txtL1.Name = "txtL1";
            this.txtL1.Size = new System.Drawing.Size(50, 20);
            this.txtL1.TabIndex = 13;
            this.txtL1.Text = "100";
            this.txtL1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "L1:";
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(15, 142);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(78, 23);
            this.btnStartStop.TabIndex = 19;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // howto_rotating_arms_Form1
            // 
            this.AcceptButton = this.btnStartStop;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 264);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.txtD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRadius);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtL3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtL2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtL1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStartStop);
            this.Name = "howto_rotating_arms_Form1";
            this.Text = "howto_rotating_arms";
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRadius;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtL3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer tmrTurnWheel;
        private System.Windows.Forms.TextBox txtL2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtL1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartStop;
    }
}

