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
     public partial class howto_color_wheel_alpha_saturation_Form1:Form
  { 


        public howto_color_wheel_alpha_saturation_Form1()
        {
            InitializeComponent();
        }

        // The color wheel bitmap.
        private Bitmap WheelBm = null;

        // Draw the initial color wheel.
        private void howto_color_wheel_alpha_saturation_Form1_Load(object sender, EventArgs e)
        {
            DrawColorWheel();
        }

        // Draw the color wheel.
        private void DrawColorWheel()
        {
            // Create the color wheel bitmap.
            int width = picWheel.Width;
            int height = picWheel.Height;
            WheelBm = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(WheelBm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                // Draw the color wheel.
                DrawColorWheel(gr, Color.White,
                    0, 0, width, height);
            }

            // Create a display bitmap.
            Bitmap bm = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                // Fill with a grid.
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                DrawGrid(gr, width, height);

                // Draw the color wheel on top.
                DrawColorWheel(gr, Color.White,
                    0, 0, width, height);
            }

            // Display the result.
            picWheel.Image = bm;
        }

        // Draw a color wheel in the indicated area.
        private void DrawColorWheel(Graphics gr, Color outline_color,
            int xmin, int ymin, int wid, int hgt)
        {
            Rectangle rect = new Rectangle(xmin, ymin, wid, hgt);
            GraphicsPath wheel_path = new GraphicsPath();
            wheel_path.AddEllipse(rect);
            wheel_path.Flatten();

            // Get alpha and saturation.
            int alpha = hscrAlpha.Value;
            int sat = hscrSaturation.Value;

            float num_pts = (wheel_path.PointCount - 1) / 6;
            Color[] surround_colors = new Color[wheel_path.PointCount];

            int index = 0;
            InterpolateColors(surround_colors, ref index,
                1 * num_pts, alpha, sat, 0, 0, alpha, sat, 0, sat);
            InterpolateColors(surround_colors, ref index,
                2 * num_pts, alpha, sat, 0, sat, alpha, 0, 0, sat);
            InterpolateColors(surround_colors, ref index,
                3 * num_pts, alpha, 0, 0, sat, alpha, 0, sat, sat);
            InterpolateColors(surround_colors, ref index,
                4 * num_pts, alpha, 0, sat, sat, alpha, 0, sat, 0);
            InterpolateColors(surround_colors, ref index,
                5 * num_pts, alpha, 0, sat, 0, alpha, sat, sat, 0);
            InterpolateColors(surround_colors, ref index,
                wheel_path.PointCount, alpha, sat, sat, 0, alpha, sat, 0, 0);

            using (PathGradientBrush path_brush =
                new PathGradientBrush(wheel_path))
            {
                path_brush.CenterColor =
                    Color.FromArgb(alpha, 255, 255, 255);
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

        // Draw a black grid over a white background.
        private void DrawGrid(Graphics gr, int width, int height)
        {
            gr.Clear(Color.White);
            using (Pen pen = new Pen(Color.Black, 2))
            {
                for (int x = 10; x < width; x += 20)
                    gr.DrawLine(pen, x, 0, x, height - 1);
                for (int y = 10; y < height; y += 20)
                    gr.DrawLine(pen, 0, y, width - 1, y);
            }
        }

        // Update the color wheel.
        private void hscrAlpha_Scroll(object sender, ScrollEventArgs e)
        {
            txtAlpha.Text = hscrAlpha.Value.ToString();
            DrawColorWheel();
        }
        private void hscrSaturation_Scroll(object sender, ScrollEventArgs e)
        {
            txtSaturation.Text = hscrSaturation.Value.ToString();
            DrawColorWheel();
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
            this.picWheel = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hscrSaturation = new System.Windows.Forms.HScrollBar();
            this.hscrAlpha = new System.Windows.Forms.HScrollBar();
            this.txtAlpha = new System.Windows.Forms.TextBox();
            this.txtSaturation = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picWheel)).BeginInit();
            this.SuspendLayout();
            // 
            // picWheel
            // 
            this.picWheel.Location = new System.Drawing.Point(11, 11);
            this.picWheel.Name = "picWheel";
            this.picWheel.Size = new System.Drawing.Size(200, 200);
            this.picWheel.TabIndex = 18;
            this.picWheel.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Saturation:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Alpha:";
            // 
            // hscrSaturation
            // 
            this.hscrSaturation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hscrSaturation.Location = new System.Drawing.Point(73, 243);
            this.hscrSaturation.Maximum = 264;
            this.hscrSaturation.Name = "hscrSaturation";
            this.hscrSaturation.Size = new System.Drawing.Size(105, 16);
            this.hscrSaturation.TabIndex = 15;
            this.hscrSaturation.Value = 255;
            this.hscrSaturation.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hscrSaturation_Scroll);
            // 
            // hscrAlpha
            // 
            this.hscrAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hscrAlpha.Location = new System.Drawing.Point(73, 217);
            this.hscrAlpha.Maximum = 264;
            this.hscrAlpha.Name = "hscrAlpha";
            this.hscrAlpha.Size = new System.Drawing.Size(105, 16);
            this.hscrAlpha.TabIndex = 14;
            this.hscrAlpha.Value = 255;
            this.hscrAlpha.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hscrAlpha_Scroll);
            // 
            // txtAlpha
            // 
            this.txtAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAlpha.Location = new System.Drawing.Point(181, 215);
            this.txtAlpha.Name = "txtAlpha";
            this.txtAlpha.ReadOnly = true;
            this.txtAlpha.Size = new System.Drawing.Size(30, 20);
            this.txtAlpha.TabIndex = 19;
            this.txtAlpha.TabStop = false;
            this.txtAlpha.Text = "255";
            this.txtAlpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSaturation
            // 
            this.txtSaturation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaturation.Location = new System.Drawing.Point(181, 241);
            this.txtSaturation.Name = "txtSaturation";
            this.txtSaturation.ReadOnly = true;
            this.txtSaturation.Size = new System.Drawing.Size(30, 20);
            this.txtSaturation.TabIndex = 20;
            this.txtSaturation.TabStop = false;
            this.txtSaturation.Text = "255";
            this.txtSaturation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // howto_color_wheel_alpha_saturation_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 273);
            this.Controls.Add(this.txtSaturation);
            this.Controls.Add(this.txtAlpha);
            this.Controls.Add(this.picWheel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hscrSaturation);
            this.Controls.Add(this.hscrAlpha);
            this.Name = "howto_color_wheel_alpha_saturation_Form1";
            this.Text = "howto_color_wheel_alpha_saturation";
            this.Load += new System.EventHandler(this.howto_color_wheel_alpha_saturation_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picWheel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picWheel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.HScrollBar hscrSaturation;
        private System.Windows.Forms.HScrollBar hscrAlpha;
        private System.Windows.Forms.TextBox txtAlpha;
        private System.Windows.Forms.TextBox txtSaturation;
    }
}

