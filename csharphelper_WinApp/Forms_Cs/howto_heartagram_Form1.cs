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
     public partial class howto_heartagram_Form1:Form
  { 


        public howto_heartagram_Form1()
        {
            InitializeComponent();
        }

        private void picHeartagram_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            PointF center = new PointF(80, 80);
            float radius = 70;
            RectangleF rect = new RectangleF(
                center.X - radius,
                center.Y - radius,
                2 * radius,
                2 * radius);

            // Make a gradient brush that fills the rectangle.
            using (LinearGradientBrush brush =
                new LinearGradientBrush(
                    new PointF(center.X - radius, center.Y),
                    new PointF(center.X + radius, center.Y),
                    Color.Black, Color.Black))
            {
                ColorBlend color_blend = new ColorBlend();
                color_blend.Colors = new Color[] 
                {
                    Color.Magenta,
                    Color.White,
                    Color.Magenta,
                };
                color_blend.Positions = new float[]
                {
                    0.0f, 0.5f, 1.0f
                };
                brush.InterpolationColors = color_blend;

                // Make a pen that is colored by the brush.
                using (Pen pen = new Pen(Color.Black, 8))
                {
                    // Draw the heartagram.
                    DrawHeartagram(e.Graphics, center, radius, brush, pen);
                }
            }
        }

        private void DrawHeartagram(Graphics gr, PointF center,
            float radius, Brush brush, Pen pen)
        {
            gr.FillEllipse(brush,
                center.X - radius,
                center.Y - radius,
                2 * radius,
                2 * radius);
            gr.DrawEllipse(pen,
                center.X - radius,
                center.Y - radius,
                2 * radius,
                2 * radius);

            // Make a GraphicsPath to represent the heartagram.
            GraphicsPath path = MakeHeartagram(center, radius, pen.Width);

            // Draw the GraphicsPath.
            gr.DrawPath(pen, path);
        }

        // Return a GraphicsPath representing a heartagram.
        private GraphicsPath MakeHeartagram(PointF center,
            float radius, float pen_width)
        {
            // Define scales to place the points the right
            // distances from the edges of the circle.
            float[] scales =
            {
                1 - 1.75f * pen_width / radius,
                1 - 1.75f * pen_width / radius,
                0.9f,
                0.9f,
                1 - 1.75f * pen_width / radius,
            };

            // Find the points of a pentagon within the area.
            double angle = Math.PI / 2.0;
            double dtheta = Math.PI * 2.0 / 5.0;

            PointF[] points = new PointF[5];
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new PointF(
                    (float)(center.X + radius * Math.Cos(angle) * scales[i]),
                    (float)(center.Y + radius * Math.Sin(angle) * scales[i]));
                angle += dtheta;
            }

            // Build the GraphicsPath.
            GraphicsPath path = new GraphicsPath();
            path.AddLine(points[4], points[1]);

            float tension = 1f;
            PointF[] curve1_points =
            {
                points[1],
                points[3],
                points[0],
            };
            path.AddCurve(curve1_points, tension);

            PointF[] curve2_points =
            {
                points[0],
                points[2],
                points[4],
            };
            path.AddCurve(curve2_points, tension);

            // Close the figure so the last corner is mitered.
            path.CloseFigure();

            return path;
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
            this.picHeartagram = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picHeartagram)).BeginInit();
            this.SuspendLayout();
            // 
            // picHeartagram
            // 
            this.picHeartagram.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picHeartagram.Location = new System.Drawing.Point(30, 18);
            this.picHeartagram.Name = "picHeartagram";
            this.picHeartagram.Size = new System.Drawing.Size(175, 175);
            this.picHeartagram.TabIndex = 0;
            this.picHeartagram.TabStop = false;
            this.picHeartagram.Paint += new System.Windows.Forms.PaintEventHandler(this.picHeartagram_Paint);
            // 
            // howto_heartagram_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 211);
            this.Controls.Add(this.picHeartagram);
            this.Name = "howto_heartagram_Form1";
            this.Text = "howto_heartagram";
            ((System.ComponentModel.ISupportInitialize)(this.picHeartagram)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picHeartagram;
    }
}

