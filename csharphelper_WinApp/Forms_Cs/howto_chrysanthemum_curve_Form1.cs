using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_chrysanthemum_curve_Form1:Form
  { 


        public howto_chrysanthemum_curve_Form1()
        {
            InitializeComponent();
        }

        private const int Period = 21;
        private Color[] Colors;

        // Initialize.
        private void howto_chrysanthemum_curve_Form1_Load(object sender, EventArgs e)
        {
            this.ResizeRedraw = true;
            this.DoubleBuffered = true;

            // Initialize the colors.
            Colors = new Color[] {
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

        // Draw the curve.
        private void howto_chrysanthemum_curve_Form1_Paint(object sender, PaintEventArgs e)
        {
            // Scale and translate.
            const float ymax = -11;
            const float ymin = 11;
            const float hgt = ymin - ymax;
            const float wid = hgt;
            float scale = Math.Min(
                this.ClientSize.Width / wid,
                this.ClientSize.Height / hgt);
            e.Graphics.ScaleTransform(scale, scale);
            e.Graphics.TranslateTransform(
                ClientSize.Width / 2, 
                ClientSize.Height / 2, 
                System.Drawing.Drawing2D.MatrixOrder.Append);

            // Draw the curve.
            const long num_lines = 5000;

            // Generate the points.
            double t = 0;
            double r = 5 * (1 + Math.Sin(11 * t / 5))
                - 4 * Math.Pow(Math.Sin(17 * t / 3), 4)
                * Math.Pow(Math.Sin(2 * Math.Cos(3 * t) - 28 * t), 8);
            PointF pt1 = new PointF((float)(r * Math.Sin(t)), (float)(-r * Math.Cos(t)));

            using (Pen the_pen = new Pen(Color.Blue, 0))
            {
                for (int i = 0; i <= num_lines; i++)
                {
                    t = i * Period * Math.PI / num_lines;
                    r = 5 * (1 + Math.Sin(11 * t / 5))
                        - 4 * Math.Pow(Math.Sin(17 * t / 3), 4)
                        * Math.Pow(Math.Sin(2 * Math.Cos(3 * t) - 28 * t), 8);
                    PointF pt0 = pt1;
                    pt1 = new PointF((float)(r * Math.Sin(t)), (float)(r * Math.Cos(t)));
                    the_pen.Color = GetColor(t);
                    e.Graphics.DrawLine(the_pen, pt0, pt1);
                }
            }
        }

        // Return a color from the Colors array.
        private Color GetColor(double t)
        {
            int index = (int)(t / Math.PI);
            return Colors[index % Colors.Length];
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
            // howto_chrysanthemum_curve_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(408, 341);
            this.Name = "howto_chrysanthemum_curve_Form1";
            this.Text = "howto_chrysanthemum_curve";
            this.Load += new System.EventHandler(this.howto_chrysanthemum_curve_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_chrysanthemum_curve_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

