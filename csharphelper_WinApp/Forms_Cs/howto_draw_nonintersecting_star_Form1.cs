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
     public partial class howto_draw_nonintersecting_star_Form1:Form
  { 


        public howto_draw_nonintersecting_star_Form1()
        {
            InitializeComponent();
        }

        // Raise a Paint event when we resize.
        private void howto_draw_nonintersecting_star_Form1_Load(object sender, EventArgs e)
        {
            this.ResizeRedraw = true;
        }

        // Draw a star.
        private void howto_draw_nonintersecting_star_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            PointF[] pts = NonIntersectingStarPoints(7, ClientRectangle);
            e.Graphics.DrawPolygon(Pens.Blue, pts);
        }

        // Return PointFs to define a non-intersecting star.
        private PointF[] NonIntersectingStarPoints(
            int num_points, Rectangle bounds)
        {
            // Make room for the points.
            PointF[] pts = new PointF[2 * num_points];

            double rx1 = bounds.Width / 2;
            double ry1 = bounds.Height / 2;
            double rx2 = rx1 * 0.5;
            double ry2 = ry1 * 0.5;
            double cx = bounds.X + rx1;
            double cy = bounds.Y + ry1;

            // Start at the top.
            double theta = -Math.PI / 2;
            double dtheta = Math.PI / num_points;
            for (int i = 0; i < 2 * num_points; i += 2)
            {
                pts[i] = new PointF(
                    (float)(cx + rx1 * Math.Cos(theta)),
                    (float)(cy + ry1 * Math.Sin(theta)));
                theta += dtheta;

                pts[i + 1] = new PointF(
                    (float)(cx + rx2 * Math.Cos(theta)),
                    (float)(cy + ry2 * Math.Sin(theta)));
                theta += dtheta;
            }

            return pts;
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
            // howto_draw_nonintersecting_star_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 261);
            this.Name = "howto_draw_nonintersecting_star_Form1";
            this.Text = "howto_draw_nonintersecting_star";
            this.Load += new System.EventHandler(this.howto_draw_nonintersecting_star_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_draw_nonintersecting_star_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

