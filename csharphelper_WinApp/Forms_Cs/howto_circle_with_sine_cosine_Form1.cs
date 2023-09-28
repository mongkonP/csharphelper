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
     public partial class howto_circle_with_sine_cosine_Form1:Form
  { 


        public howto_circle_with_sine_cosine_Form1()
        {
            InitializeComponent();
        }

        private void howto_circle_with_sine_cosine_Form1_Load(object sender, EventArgs e)
        {
            this.ResizeRedraw = true;
        }

        private void howto_circle_with_sine_cosine_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw a circle.
            float cx = ClientRectangle.Width / 2f;
            float cy = ClientRectangle.Height / 2f;
            float rx = Math.Min(cx, cy) - 10;
            float ry = rx;
            DrawTickedCircle(e.Graphics, Pens.Blue, Pens.Orange,
                cx, cy, rx, ry, 100, 12, 0.1f);

            // Draw an ellipse.
            rx *= 0.8f;
            ry *= 0.6f;
            DrawTickedCircle(e.Graphics, Pens.Red, Pens.Black,
                cx, cy, rx, ry, 16, 16, 0.1f);
        }

        // Draw an ellipse with tick marks.
        private void DrawTickedCircle(
            Graphics gr, Pen circle_pen, Pen tick_pen,
            float cx, float cy, float rx, float ry,
            float num_theta,
            float num_ticks, float tick_fraction)
        {
            // Draw the circle.
            List<PointF> points = new List<PointF>();
            float dtheta = (float)(2 * Math.PI / num_theta);
            float theta = 0;
            for (int i = 0; i < num_theta; i++)
            {
                float x = (float)(cx + rx * Math.Cos(theta));
                float y = (float)(cy + ry * Math.Sin(theta));
                points.Add(new PointF(x, y));
                theta += dtheta;
            }
            gr.DrawPolygon(circle_pen, points.ToArray());

            // Draw the tick marks.
            dtheta = (float)(2 * Math.PI / num_ticks);
            theta = 0;
            float rx1 = rx * (1 - tick_fraction);
            float ry1 = ry * (1 - tick_fraction);
            for (int i = 0; i < num_ticks; i++)
            {
                float x1 = (float)(cx + rx * Math.Cos(theta));
                float y1 = (float)(cy + ry * Math.Sin(theta));
                float x2 = (float)(cx + rx1 * Math.Cos(theta));
                float y2 = (float)(cy + ry1 * Math.Sin(theta));
                gr.DrawLine(tick_pen, x1, y1, x2, y2);
                theta += dtheta;
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
            this.SuspendLayout();
            // 
            // howto_circle_with_sine_cosine_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "howto_circle_with_sine_cosine_Form1";
            this.Text = "howto_circle_with_sine_cosine";
            this.Load += new System.EventHandler(this.howto_circle_with_sine_cosine_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_circle_with_sine_cosine_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

