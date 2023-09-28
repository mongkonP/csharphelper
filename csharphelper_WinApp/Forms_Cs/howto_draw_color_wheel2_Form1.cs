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
     public partial class howto_draw_color_wheel2_Form1:Form
  { 


        public howto_draw_color_wheel2_Form1()
        {
            InitializeComponent();
        }

        // Draw a color wheel.
        private void howto_draw_color_wheel2_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            DrawColorWheel(e.Graphics, this.BackColor, 10, 10,
                ClientSize.Width - 20, ClientSize.Height - 20);
        }

        // Draw a color wheel in the indicated area.
        private void DrawColorWheel(Graphics gr, Color outline_color,
            int xmin, int ymin, int wid, int hgt)
        {
            Rectangle rect = new Rectangle(xmin, ymin, wid, hgt);
            GraphicsPath wheel_path = new GraphicsPath();
            wheel_path.AddEllipse(rect);
            wheel_path.Flatten();

            float num_pts = (wheel_path.PointCount - 1) / 6;
            Color[] surround_colors = new Color[wheel_path.PointCount];

            int index = 0;
            InterpolateColors(surround_colors, ref index,
                1 * num_pts, 255, 255, 0, 0, 255, 255, 0, 255);
            InterpolateColors(surround_colors, ref index,
                2 * num_pts, 255, 255, 0, 255, 255, 0, 0, 255);
            InterpolateColors(surround_colors, ref index,
                3 * num_pts, 255, 0, 0, 255, 255, 0, 255, 255);
            InterpolateColors(surround_colors, ref index,
                4 * num_pts, 255, 0, 255, 255, 255, 0, 255, 0);
            InterpolateColors(surround_colors, ref index,
                5 * num_pts, 255, 0, 255, 0, 255, 255, 255, 0);
            InterpolateColors(surround_colors, ref index,
                wheel_path.PointCount, 255, 255, 255, 0, 255, 255, 0, 0);

            using (PathGradientBrush path_brush =
                new PathGradientBrush(wheel_path))
            {
                path_brush.CenterColor = Color.White;
                path_brush.SurroundColors = surround_colors;

                gr.FillPath(path_brush, wheel_path);

                // It looks better if we outline the wheel.
                using (Pen thick_pen = new Pen(outline_color, 2))
                {
                    gr.DrawPath(thick_pen, wheel_path);
                }
            }

            //// Uncomment the following to draw the path's points.
            //for (int i = 0; i < wheel_path.PointCount; i++)
            //{
            //    gr.FillEllipse(Brushes.Black,
            //        wheel_path.PathPoints[i].X - 2,
            //        wheel_path.PathPoints[i].Y - 2,
            //        4, 4);
            //}
        }

        // Fill in colors interpolating between the from and to values.
        private void InterpolateColors(Color[] surround_colors,
            ref int index, float stop_pt,
            int from_a, int from_r, int from_g, int from_b,
            int to_a, int to_r, int to_g, int to_b)
        {
            int num_pts = (int)stop_pt - index;
            float a = from_a, r = from_r, g = from_g, b = from_b;
            float da = (to_a - from_a) / (num_pts - 1);
            float dr = (to_r - from_r) / (num_pts - 1);
            float dg = (to_g - from_g) / (num_pts - 1);
            float db = (to_b - from_b) / (num_pts - 1);

            for (int i = 0; i < num_pts; i++)
            {
                surround_colors[index++] =
                    Color.FromArgb((int)a, (int)r, (int)g, (int)b);
                a += da;
                r += dr;
                g += dg;
                b += db;
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
            // howto_draw_color_wheel2_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 311);
            this.Name = "howto_draw_color_wheel2_Form1";
            this.Text = "howto_draw_color_wheel2";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_draw_color_wheel2_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

