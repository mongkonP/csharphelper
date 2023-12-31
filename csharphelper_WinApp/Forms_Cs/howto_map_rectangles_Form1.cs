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
     public partial class howto_map_rectangles_Form1:Form
  { 


        public howto_map_rectangles_Form1()
        {
            InitializeComponent();
        }

        // Draw some smiley faces in different places.
        private void howto_map_rectangles_Form1_Paint(object sender, PaintEventArgs e)
        {
            // Draw smoothly.
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // **********
            // Method 1: Building the transformation from simple ones.
            // In the area (10, 10) - (110, 110).
            e.Graphics.ResetTransform();
            // Scale by a factor of 50.
            e.Graphics.ScaleTransform(50, 50);
            // Translate to position correctly.
            e.Graphics.TranslateTransform(60, 60, MatrixOrder.Append);
            // Draw.
            DrawSmiley(e.Graphics);

            // **********
            // Method 2: Mapping a rectangle to a parallelogram.
            // In the area (120, 10) - (220, 110).
            RectangleF from_rect = new RectangleF(-1, -1, 2, 2);
            PointF[] to_points =
            {
                new PointF(120, 10),    // Upper left.
                new PointF(220, 10),    // Upper right.
                new PointF(120, 110),   // Lower left.
            };
            Matrix map_matrix = new Matrix(from_rect, to_points);
            e.Graphics.Transform = map_matrix;
            // Draw.
            DrawSmiley(e.Graphics);

            // **********
            // Method 2b: Using a skewed parallelogram.
            from_rect = new RectangleF(-1, -1, 2, 2);
            to_points = new PointF[]
            {
                new PointF(30, 120),    // Upper left.
                new PointF(110, 120),   // Upper right.
                new PointF(10, 220),    // Lower left.
            };
            map_matrix = new Matrix(from_rect, to_points);
            e.Graphics.Transform = map_matrix;
            // Draw.
            DrawSmiley(e.Graphics);

            // **********
            // Method 2c: Using an inverted parallelogram.
            from_rect = new RectangleF(-1, -1, 2, 2);
            to_points = new PointF[]
            {
                new PointF(120, 220),   // Upper left.
                new PointF(220, 220),   // Upper right.
                new PointF(120, 120),   // Lower left.
            };
            map_matrix = new Matrix(from_rect, to_points);
            e.Graphics.Transform = map_matrix;
            // Draw.
            DrawSmiley(e.Graphics);
        }

        // Draw a smiley in the rectangle (-1, -1) - (1, 1).
        private void DrawSmiley(Graphics gr)
        {
            using (Pen black_pen = new Pen(Color.Black, 0))
            {
                // Face.
                gr.FillEllipse(Brushes.Yellow, -1, -1, 2, 2);
                gr.DrawEllipse(black_pen, -1, -1, 2, 2);

                // Nose.
                gr.FillEllipse(Brushes.LightBlue, -0.2f, -0.3f, 0.4f, 0.6f);
                using (Pen blue_pen = new Pen(Color.Blue, 0))
                {
                    gr.DrawEllipse(blue_pen, -0.2f, -0.3f, 0.4f, 0.6f);
                }

                // Left eye.
                gr.FillEllipse(Brushes.White, -0.6f, -0.5f, 0.3f, 0.4f);
                gr.DrawEllipse(black_pen, -0.6f, -0.5f, 0.3f, 0.4f);
                gr.FillEllipse(Brushes.Black, -0.5f, -0.45f, 0.2f, 0.3f);

                // Right eye.
                gr.FillEllipse(Brushes.White, 0.3f, -0.5f, 0.3f, 0.4f);
                gr.DrawEllipse(black_pen, 0.3f, -0.5f, 0.3f, 0.4f);
                gr.FillEllipse(Brushes.Black, 0.4f, -0.45f, 0.2f, 0.3f);

                // Smile.
                gr.DrawArc(black_pen, -0.7f, -0.7f, 1.4f, 1.4f, 20, 120);

                // Draw a rectangle around it all.
                gr.DrawRectangle(black_pen, -1, -1, 2, 2);
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
            // howto_map_rectangles_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 239);
            this.Name = "howto_map_rectangles_Form1";
            this.Text = "howto_map_rectangles";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_map_rectangles_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

    }
}

