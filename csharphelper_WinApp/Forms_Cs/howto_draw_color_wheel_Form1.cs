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
     public partial class howto_draw_color_wheel_Form1:Form
  { 


        public howto_draw_color_wheel_Form1()
        {
            InitializeComponent();
        }

        // Draw a color wheel.
        private void howto_draw_color_wheel_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            DrawColorWheel(e.Graphics, this.BackColor, 10, 10,
                ClientSize.Width - 20, ClientSize.Height - 20);
        }

        // Draw a color wheel in the indicated area.
        private void DrawColorWheel(Graphics gr, Color outline_color, int xmin, int ymin, int wid, int hgt)
        {
            Rectangle rect = new Rectangle(xmin, ymin, wid, hgt);
            GraphicsPath wheel_path = new GraphicsPath();
            wheel_path.AddEllipse(rect);
            wheel_path.Flatten();

            int num_pts = (wheel_path.PointCount - 1) / 3;
            Color[] surround_colors = new Color[wheel_path.PointCount];
            float r = 255, g = 0, b = 0;
            float dr, dg, db;
            dr = -255 / num_pts;
            db = 255 / num_pts;
            for (int i= 0; i < num_pts; i++)
            {
                surround_colors[i] = Color.FromArgb(255, (int)r, (int)g, (int)b);
                r += dr;
                b += db;
            }

            r = 0; g = 0; b = 255;
            dg = 255 / num_pts;
            db = -255 / num_pts;
            for (int i = num_pts; i < 2 * num_pts; i++)
            {
                surround_colors[i] = Color.FromArgb(255, (int)r, (int)g, (int)b);
                g += dg;
                b += db;
            }

            r = 0 ; g = 255 ; b = 0;
            dr = 255 / (wheel_path.PointCount - 2 * num_pts);
            dg = -255 / (wheel_path.PointCount - 2 * num_pts);
            for (int i = 2 * num_pts; i < wheel_path.PointCount; i++)
            {
                surround_colors[i] = Color.FromArgb(255, (int)r, (int)g, (int)b);
                r += dr; 
                g += dg;
            }

            using (PathGradientBrush path_brush = new PathGradientBrush(wheel_path))
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
            // howto_draw_color_wheel_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 311);
            this.Name = "howto_draw_color_wheel_Form1";
            this.Text = "howto_draw_color_wheel";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_draw_color_wheel_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

