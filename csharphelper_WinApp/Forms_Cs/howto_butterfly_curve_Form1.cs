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
     public partial class howto_butterfly_curve_Form1:Form
  { 


        public howto_butterfly_curve_Form1()
        {
            InitializeComponent();
        }

        private const int period = 24;
        private Color[] Colors;

        // Initialize the colors.
        private void howto_butterfly_curve_Form1_Load(object sender, EventArgs e)
        {
            // Redraw when resized.
            this.ResizeRedraw = true;

            Colors = new Color[] 
            {
                Color.Pink,
                Color.Red,
                Color.Orange,
                Color.Yellow,
                Color.Lime,
                Color.Cyan,
                Color.Blue,
                Color.Violet,
                Color.Pink,
                Color.Red,
                Color.Orange,
                Color.Yellow,
                Color.Lime,
                Color.Cyan,
                Color.Blue,
                Color.Violet,
                Color.Pink,
                Color.Red,
                Color.Orange,
                Color.Yellow,
                Color.Lime,
                Color.Cyan,
                Color.Blue,
                Color.Violet
            };
        }

        // Draw the butterfly.
        private void howto_butterfly_curve_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(this.BackColor);

            // Scale and translate.
            RectangleF world_rect =
                new RectangleF(-4.0f, -4.4f, 8.0f, 7.3f);
            float cx = (world_rect.Left + world_rect.Right) / 2;
            float cy = (world_rect.Top + world_rect.Bottom) / 2;

            // Center the world coordinates at origin.
            e.Graphics.TranslateTransform(-cx, -cy);

            // Scale to fill the form.
            float scale = Math.Min(
                this.ClientSize.Width / world_rect.Width,
                this.ClientSize.Height / world_rect.Height);
            e.Graphics.ScaleTransform(scale, scale, MatrixOrder.Append);

            // Move the result to center on the form.
            e.Graphics.TranslateTransform(
                this.ClientSize.Width / 2,
                this.ClientSize.Height / 2,  MatrixOrder.Append);

            // Generate the points.
            PointF pt0, pt1;
            double t = 0;
            double expr = 
                Math.Exp(Math.Cos(t))
                - 2 * Math.Cos(4 * t)
                - Math.Pow(Math.Sin(t / 12), 5);
            pt1 = new PointF(
                (float)(Math.Sin(t) * expr), 
                (float)(-Math.Cos(t) * expr));
            using (Pen the_pen = new Pen(Color.Blue, 0))
            {
                const long num_lines = 5000;
                for (long i = 0; i < num_lines; i++)
                {
                    t = i * period * Math.PI / num_lines;
                    expr = 
                        Math.Exp(Math.Cos(t))
                        - 2 * Math.Cos(4 * t)
                        - Math.Pow(Math.Sin(t / 12), 5);
                    pt0 = pt1;
                    pt1 = new PointF(
                        (float)(Math.Sin(t) * expr), 
                        (float)(-Math.Cos(t) * expr));
                    the_pen.Color = GetColor(t);
                    e.Graphics.DrawLine(the_pen, pt0, pt1);
                }
            }
        }

        // Return an appropriate color for this segment.
        private Color GetColor(double t)
        {
            return Colors[(int)(t / Math.PI)];
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
            // howto_butterfly_curve_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(408, 341);
            this.DoubleBuffered = true;
            this.Name = "howto_butterfly_curve_Form1";
            this.Text = "howto_butterfly_curve";
            this.Load += new System.EventHandler(this.howto_butterfly_curve_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_butterfly_curve_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

