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
     public partial class howto_draw_epitrochoid_Form1:Form
  { 


        public howto_draw_epitrochoid_Form1()
        {
            InitializeComponent();
        }

        // Redraw on resize.
        private void howto_draw_epitrochoid_Form1_Load(object sender, EventArgs e)
        {
            this.ResizeRedraw = true;
        }

        // Redraw.
        private void btnRedraw_Click(object sender, EventArgs e)
        {
            picCanvas.Invalidate();
        }

        // Draw the epitrochoid.
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(picCanvas.BackColor);

            // Scale and center.
            float scale = Math.Min(
                picCanvas.ClientSize.Width * 0.45f,
                picCanvas.ClientSize.Height * 0.45f);
            e.Graphics.ScaleTransform(scale, scale);
            e.Graphics.TranslateTransform(
                picCanvas.ClientSize.Width / 2,
                picCanvas.ClientSize.Height / 2,
                System.Drawing.Drawing2D.MatrixOrder.Append);

            // Draw the curve.
            float a = float.Parse(txtA.Text);
            float b = float.Parse(txtB.Text);
            float h = float.Parse(txtH.Text);
            float dt = float.Parse(txtDt.Text);
            DrawEpitrochoid(e.Graphics, a, b, h, dt);
        }

        // Draw the curve on the indicated Graphics object.
        private void DrawEpitrochoid(Graphics gr, float a, float b, float h, float dt)
        {
            // Calculate the stop value for t.
            float stop_t = (float)(b * 2 * Math.PI);

            // Find the points.
            using (Pen the_pen = new Pen(Color.White, 0))
            {
                PointF pt0, pt1;
                pt0 = new PointF(X(a, b, h, 0), Y(a, b, h, 0));
                for (float t = dt; t <= stop_t; t += dt)
                {
                    pt1 = new PointF(X(a, b, h, t), Y(a, b, h, t));
                    gr.DrawLine(the_pen, pt0, pt1);
                    pt0 = pt1;
                }
            }
        }

        // The parametric function X(t).
        private float X(float a, float b, float h, float t)
        {
            float value = (float)((a + b) * Math.Cos(t) - h * Math.Cos(t * (a + b) / b));
            return value / (a + b + h);
        }

        // The parametric function Y(t).
        private float Y(float a, float b, float h, float t)
        {
            float value = (float)((a + b) * Math.Sin(t) - h * Math.Sin(t * (a + b) / b));
            return value / (a + b + h);
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
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRedraw = new System.Windows.Forms.Button();
            this.txtDt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BackColor = System.Drawing.Color.Navy;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(12, 40);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(421, 272);
            this.picCanvas.TabIndex = 4;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "a:";
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(31, 14);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(44, 20);
            this.txtA.TabIndex = 0;
            this.txtA.Text = "17";
            this.txtA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(119, 14);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(44, 20);
            this.txtB.TabIndex = 1;
            this.txtB.Text = "11";
            this.txtB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "b:";
            // 
            // txtH
            // 
            this.txtH.Location = new System.Drawing.Point(207, 14);
            this.txtH.Name = "txtH";
            this.txtH.Size = new System.Drawing.Size(44, 20);
            this.txtH.TabIndex = 2;
            this.txtH.Text = "13";
            this.txtH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "h:";
            // 
            // btnRedraw
            // 
            this.btnRedraw.Location = new System.Drawing.Point(357, 12);
            this.btnRedraw.Name = "btnRedraw";
            this.btnRedraw.Size = new System.Drawing.Size(75, 23);
            this.btnRedraw.TabIndex = 4;
            this.btnRedraw.Text = "Redraw";
            this.btnRedraw.UseVisualStyleBackColor = true;
            this.btnRedraw.Click += new System.EventHandler(this.btnRedraw_Click);
            // 
            // txtDt
            // 
            this.txtDt.Location = new System.Drawing.Point(298, 14);
            this.txtDt.Name = "txtDt";
            this.txtDt.Size = new System.Drawing.Size(44, 20);
            this.txtDt.TabIndex = 3;
            this.txtDt.Text = "0.05";
            this.txtDt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(273, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "dt:";
            // 
            // howto_draw_epitrochoid_Form1
            // 
            this.AcceptButton = this.btnRedraw;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 324);
            this.Controls.Add(this.txtDt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRedraw);
            this.Controls.Add(this.txtH);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_draw_epitrochoid_Form1";
            this.Text = "howto_draw_epitrochoid";
            this.Load += new System.EventHandler(this.howto_draw_epitrochoid_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRedraw;
        private System.Windows.Forms.TextBox txtDt;
        private System.Windows.Forms.Label label4;
    }
}

