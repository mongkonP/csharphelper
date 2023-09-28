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
     public partial class howto_epitrochoid_animated_Form1:Form
  { 


        public howto_epitrochoid_animated_Form1()
        {
            InitializeComponent();
        }

        // The curve's parameters.
        private float a, b, h, dt;

        // The curve's points.
        private PointF[] Points = null;
        private float[] Thetas = null;

        // The maximum index we should draw.
        private int MaxPointToDraw = 0;

        // Redraw on resize.
        private void howto_epitrochoid_animated_Form1_Load(object sender, EventArgs e)
        {
            this.ResizeRedraw = true;
        }

        // Redraw.
        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (tmrDraw.Enabled)
            {
                Cursor = Cursors.Default;
                tmrDraw.Enabled = false;
            }
            else
            {
                Cursor = Cursors.WaitCursor;

                // Make the points.
                a = float.Parse(txtA.Text);
                b = float.Parse(txtB.Text);
                h = float.Parse(txtH.Text);
                dt = float.Parse(txtDt.Text);
                MakeEpitrochoidPoints(a, b, h, dt);

                // Start drawing.
                MaxPointToDraw = 0;
                tmrDraw.Enabled = true;
            }
        }

        // Draw the epitrochoid.
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(picCanvas.BackColor);
            if (Points == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Scale and center.
            float scale = Math.Min(
                picCanvas.ClientSize.Width * 0.45f,
                picCanvas.ClientSize.Height * 0.45f);
            e.Graphics.ScaleTransform(scale / (a + b + h), scale / (a + b + h));
            e.Graphics.TranslateTransform(
                picCanvas.ClientSize.Width / 2,
                picCanvas.ClientSize.Height / 2,
                MatrixOrder.Append);

            // Draw the circles.
            using (Pen black_pen = new Pen(Color.Black, 0))
            {
                // Inner circle.
                e.Graphics.DrawEllipse(black_pen, -a, -a, 2 * a, 2 * a);

                // Outer circle.
                float theta = Thetas[MaxPointToDraw];
                float cx = (float)((a + b) * Math.Cos(theta));
                float cy = (float)((a + b) * Math.Sin(theta));

                e.Graphics.DrawEllipse(black_pen, cx - b, cy - b, 2 * b, 2 * b);

                // The line segment.
                e.Graphics.DrawLine(black_pen, cx, cy, Points[MaxPointToDraw].X, Points[MaxPointToDraw].Y);
            }

            // Draw the curve.
            using (Pen white_pen = new Pen(Color.White, 0))
            {
                for (int i = 0; i < MaxPointToDraw; i++)
                {
                    e.Graphics.DrawLine(white_pen, Points[i], Points[i + 1]);
                }
            }
        }

        // Make the curve's points.
        private void MakeEpitrochoidPoints(float a, float b, float h, float dt)
        {
            // Calculate the stop value for t.
            float stop_t = (float)(b * 2 * Math.PI);

            // Find the points.
            List<PointF> point_list = new List<PointF>();
            List<float> theta_list = new List<float>();

            point_list.Add(new PointF(X(a, b, h, 0), Y(a, b, h, 0)));
            theta_list.Add(0);
            for (float t = dt; t <= stop_t; t += dt)
            {
                point_list.Add(new PointF(X(a, b, h, t), Y(a, b, h, t)));
                theta_list.Add(t);
            }
            point_list.Add(new PointF(X(a, b, h, 0), Y(a, b, h, 0)));
            theta_list.Add(0);

            Points = point_list.ToArray();
            Thetas = theta_list.ToArray();
        }

        // The parametric function X(t).
        private float X(float a, float b, float h, float t)
        {
            return (float)((a + b) * Math.Cos(t) - h * Math.Cos(t * (a + b) / b));
        }

        // The parametric function Y(t).
        private float Y(float a, float b, float h, float t)
        {
            return (float)((a + b) * Math.Sin(t) - h * Math.Sin(t * (a + b) / b));
        }

        // Draw another point.
        private void tmrDraw_Tick(object sender, EventArgs e)
        {
            MaxPointToDraw++;
            if (MaxPointToDraw >= Points.Length - 1)
            {
                tmrDraw.Enabled = false;
                Cursor = Cursors.Default;
            }
            picCanvas.Refresh();
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
            this.txtDt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDraw = new System.Windows.Forms.Button();
            this.txtH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.tmrDraw = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDt
            // 
            this.txtDt.Location = new System.Drawing.Point(299, 14);
            this.txtDt.Name = "txtDt";
            this.txtDt.Size = new System.Drawing.Size(44, 20);
            this.txtDt.TabIndex = 15;
            this.txtDt.Text = "0.05";
            this.txtDt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(274, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "dt:";
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(358, 12);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 17;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // txtH
            // 
            this.txtH.Location = new System.Drawing.Point(208, 14);
            this.txtH.Name = "txtH";
            this.txtH.Size = new System.Drawing.Size(44, 20);
            this.txtH.TabIndex = 14;
            this.txtH.Text = "4";
            this.txtH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "h:";
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(120, 14);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(44, 20);
            this.txtB.TabIndex = 13;
            this.txtB.Text = "3";
            this.txtB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "b:";
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(32, 14);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(44, 20);
            this.txtA.TabIndex = 12;
            this.txtA.Text = "5";
            this.txtA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "a:";
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BackColor = System.Drawing.Color.Navy;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(13, 40);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(421, 272);
            this.picCanvas.TabIndex = 16;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // tmrDraw
            // 
            this.tmrDraw.Interval = 10;
            this.tmrDraw.Tick += new System.EventHandler(this.tmrDraw_Tick);
            // 
            // howto_epitrochoid_animated_Form1
            // 
            this.AcceptButton = this.btnDraw;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 324);
            this.Controls.Add(this.txtDt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.txtH);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_epitrochoid_animated_Form1";
            this.Text = "howto_epitrochoid_animated";
            this.Load += new System.EventHandler(this.howto_epitrochoid_animated_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.TextBox txtH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Timer tmrDraw;
    }
}

