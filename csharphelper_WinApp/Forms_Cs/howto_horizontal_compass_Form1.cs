using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Drawing.Text;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_horizontal_compass_Form1:Form
  { 


        public howto_horizontal_compass_Form1()
        {
            InitializeComponent();
        }

        private int CurrentValue = 1;

        private void picCompass_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            DrawCompass(e.Graphics, CurrentValue);
        }

        private void DrawCompass(Graphics gr, int value)
        {
            // Draw the background.
            DrawBackground(gr);

            // Draw tick marks.
            using (Font nsew_font = new Font("Arial", 14,
                FontStyle.Italic | FontStyle.Bold))
            {
                using (Font degrees_font = new Font("Arial", 12, FontStyle.Italic))
                {
                    DrawTickMarks(gr, CurrentValue, nsew_font, degrees_font);
                }
            }

            // Draw the pointer.
            DrawPointer(gr);
        }

        private void DrawBackground(Graphics gr)
        {
            int wid = picCompass.ClientSize.Width;
            int hgt = picCompass.ClientSize.Height;
            using (LinearGradientBrush brush =
                new LinearGradientBrush(
                    picCompass.ClientRectangle,
                    Color.White, Color.Gray, 90))
            {
                ColorBlend color_blend = new ColorBlend();
                color_blend.Colors = new Color[]
                {
                    Color.White, Color.Black, Color.Black, Color.White,
                };
                color_blend.Positions = new float[]
                {
                    0.0f, 0.3f, 0.8f, 1.0f, 
                };
                brush.InterpolationColors = color_blend;
                gr.FillRectangle(brush, picCompass.ClientRectangle);
            }
        }

        private void DrawTickMarks(Graphics gr, float center_value,
            Font nsew_font, Font degrees_font)
        {
            // Set the number of degrees that are visible.
            const int width_in_degrees = 180;

            // Calculate tick geometry.
            const int letter_freq = 90;     // Draw a letter every 90 degrees.
            const int large_tick_freq = 30; // Draw a large tick mark every 30 degrees.
            const int small_tick_freq = 15; // Draw a small tick mark every 15 degrees.
            float large_tick_hgt = picCompass.ClientSize.Height / 5f;
            float small_tick_hgt = large_tick_hgt / 2f;
            float large_tick_y0 = picCompass.ClientSize.Height / 10f;
            float large_tick_y1 = large_tick_y0 + large_tick_hgt;
            float small_tick_y0 = large_tick_y0;
            float small_tick_y1 = small_tick_y0 + small_tick_hgt;

            // Find the center.
            int wid = picCompass.ClientSize.Width;
            float x_mid = wid / 2f;
            float letter_y = large_tick_y1 * 1.2f;

            // Find the width of one degree on the control.
            float pix_per_degree = (float)picCompass.ClientSize.Width / width_in_degrees;

            // Find the value at the left edge of the control.
            float left_value = center_value - (wid / 2f) / pix_per_degree;

            // Find the next smaller multiple of small_tick_freq.
            int degrees = small_tick_freq * (int)(left_value / small_tick_freq);
            degrees -= small_tick_freq;

            // Find the corresponding X position.
            float x = x_mid - (center_value - degrees) * pix_per_degree;

            // Adjust degrees so it is between 1 and 360.
            if (degrees <= 0) degrees += 360;

            // Draw tick marks.
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;

                for (int i = 0; i <= width_in_degrees; i += small_tick_freq)
                {
                    // See what we should draw.
                    string letter = "";
                    if (degrees % letter_freq == 0)
                    {
                        switch (degrees / letter_freq)
                        {
                            case 1:
                                letter = "E";
                                break;
                            case 2:
                                letter = "S";
                                break;
                            case 3:
                                letter = "W";
                                break;
                            case 4:
                                letter = "N";
                                break;
                        }
                        gr.DrawLine(Pens.White, x, large_tick_y0, x, large_tick_y1);
                        gr.DrawString(letter, nsew_font,
                            Brushes.White, new PointF(x, letter_y), sf);
                    }
                    else if (degrees % large_tick_freq == 0)
                    {
                        gr.DrawLine(Pens.White, x, large_tick_y0, x, large_tick_y1);
                        gr.DrawString(degrees.ToString(), degrees_font,
                            Brushes.White, new PointF(x, letter_y), sf);
                    }
                    else
                    {
                        gr.DrawLine(Pens.White, x, small_tick_y0, x, small_tick_y1);
                    }

                    degrees += small_tick_freq;
                    if (degrees > 360) degrees -= 360;

                    x += small_tick_freq * pix_per_degree;
                }
            }
        }

        private void DrawPointer(Graphics gr)
        {
            float y0 = 0;
            float y2 = picCompass.ClientSize.Height / 10f;
            float y1 = y2 / 2f;
            float half_wid = y2;

            // Find the center.
            int wid = picCompass.ClientSize.Width;
            float x_mid = wid / 2f;

            // Define the points.
            PointF[] points =
            {
                new PointF(x_mid - half_wid, y0),
                new PointF(x_mid + half_wid, y0),
                new PointF(x_mid + half_wid, y1),
                new PointF(x_mid, y2),
                new PointF(x_mid - half_wid, y1),
            };
            gr.FillPolygon(Brushes.LightBlue, points);
            gr.DrawPolygon(Pens.Black, points);
        }

        private void hbarDegrees_Scroll(object sender, ScrollEventArgs e)
        {
            CurrentValue = hbarDegrees.Value;
            lblDegrees.Text = CurrentValue.ToString() + "°";
            picCompass.Refresh();
            picHeading.Refresh();
        }

        private void picHeading_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(picHeading.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            // Draw the heading picture.
            using (Font nsew_font = new Font("Times New Roman", 18,
                FontStyle.Bold))
            {
                DrawHeading(e.Graphics, CurrentValue, nsew_font);
            }
        }

        private void DrawHeading(Graphics gr, int value, Font font)
        {
            float cx = picHeading.ClientSize.Width / 2f;
            float cy = picHeading.ClientSize.Height / 2f;

            // Draw NSEW.
            float letter_r = Math.Min(cx, cy) * 0.85f;
            string[] letters = { "N", "E", "S", "W" };
            int[] degrees = { 270, 0, 90, 180 };
            for (int i = 0; i < 4; i++)
            {
                float letter_x = letter_r * (float)Math.Cos(DegreesToRadians(degrees[i]));
                float letter_y = letter_r * (float)Math.Sin(DegreesToRadians(degrees[i]));
                PointF point = new PointF(cx + letter_x, cy + letter_y);
                DrawRotatedText(gr, font, Brushes.Black,
                    letters[i], point, degrees[i] + 90);
            }

            // Draw tick marks.
            const int large_tick_freq = 30; // Draw a large tick mark every 30 degrees.
            const int small_tick_freq = 15; // Draw a small tick mark every 15 degrees.
            const int tiny_tick_freq = 3;   // Draw a tiny tick mark every 3 degrees.
            float outer_r = letter_r * 0.9f;
            float large_r = outer_r * 0.8f;
            float small_r = outer_r * 0.9f;
            float tiny_r = outer_r * 0.95f;
            using (Pen pen = new Pen(Color.Blue, 3))
            {
                for (int i = tiny_tick_freq; i <= 360; i += tiny_tick_freq)
                {
                    float cos = (float)Math.Cos(DegreesToRadians(i));
                    float sin = (float)Math.Sin(DegreesToRadians(i));
                    float x0 = cx + outer_r * cos;
                    float y0 = cy + outer_r * sin;

                    float x1, y1;
                    if (i % large_tick_freq == 0)
                    {
                        pen.Width = 3;
                        x1 = cx + large_r * cos;
                        y1 = cy + large_r * sin;
                    }
                    else if (i % small_tick_freq == 0)
                    {
                        pen.Width = 2;
                        x1 = cx + small_r * cos;
                        y1 = cy + small_r * sin;
                    }
                    else
                    {
                        pen.Width = 1;
                        x1 = cx + tiny_r * cos;
                        y1 = cy + tiny_r * sin;
                    }
                    gr.DrawLine(pen, x0, y0, x1, y1);
                }
            }

            // Draw the pointer.
            // Rotate 90 degrees so North is at 0.
            double radians = DegreesToRadians(value - 90);

            const int tip_r = 4;
            float pointer_r = large_r * 1.0f;
            float tip_x = cx + pointer_r * (float)Math.Cos(radians);
            float tip_y = cx + pointer_r * (float)Math.Sin(radians);
            float tip_x1 = cx + tip_r * (float)Math.Cos(radians + Math.PI / 2.0);
            float tip_y1 = cy + tip_r * (float)Math.Sin(radians + Math.PI / 2.0);
            float tip_x2 = cx + tip_r * (float)Math.Cos(radians - Math.PI / 2.0);
            float tip_y2 = cy + tip_r * (float)Math.Sin(radians - Math.PI / 2.0);
            PointF[] points =
            {
                new PointF(tip_x, tip_y),
                new PointF(tip_x1, tip_y1),
                new PointF(tip_x2, tip_y2),
            };
            gr.FillPolygon(Brushes.Black, points);

            // Draw the center.
            const int center_r = 6;
            RectangleF rect = new RectangleF(
                cx - center_r, cy - center_r,
                2 * center_r, 2 * center_r);
            gr.FillEllipse(Brushes.LightBlue, rect);
            gr.DrawEllipse(Pens.Black, rect);
        }

        private double DegreesToRadians(float degrees)
        {
            return degrees * Math.PI / 180;
        }

        private void DrawRotatedText(Graphics gr, Font font, Brush brush,
            string text, PointF location, float degrees)
        {
            GraphicsState state = gr.Save();
            gr.ResetTransform();
            gr.RotateTransform(degrees);
            gr.TranslateTransform(location.X, location.Y, MatrixOrder.Append);
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                gr.DrawString(text, font, brush, 0, 0, sf);
            }
            gr.Restore(state);
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
            this.picCompass = new System.Windows.Forms.PictureBox();
            this.hbarDegrees = new System.Windows.Forms.HScrollBar();
            this.lblDegrees = new System.Windows.Forms.Label();
            this.picHeading = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCompass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeading)).BeginInit();
            this.SuspendLayout();
            // 
            // picCompass
            // 
            this.picCompass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCompass.BackColor = System.Drawing.Color.White;
            this.picCompass.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCompass.Location = new System.Drawing.Point(12, 295);
            this.picCompass.Name = "picCompass";
            this.picCompass.Size = new System.Drawing.Size(260, 80);
            this.picCompass.TabIndex = 0;
            this.picCompass.TabStop = false;
            this.picCompass.Paint += new System.Windows.Forms.PaintEventHandler(this.picCompass_Paint);
            // 
            // hbarDegrees
            // 
            this.hbarDegrees.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hbarDegrees.Location = new System.Drawing.Point(12, 9);
            this.hbarDegrees.Maximum = 369;
            this.hbarDegrees.Minimum = 1;
            this.hbarDegrees.Name = "hbarDegrees";
            this.hbarDegrees.Size = new System.Drawing.Size(214, 17);
            this.hbarDegrees.TabIndex = 1;
            this.hbarDegrees.Value = 1;
            this.hbarDegrees.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hbarDegrees_Scroll);
            // 
            // lblDegrees
            // 
            this.lblDegrees.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDegrees.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDegrees.Location = new System.Drawing.Point(229, 9);
            this.lblDegrees.Name = "lblDegrees";
            this.lblDegrees.Size = new System.Drawing.Size(43, 17);
            this.lblDegrees.TabIndex = 2;
            this.lblDegrees.Text = "1";
            this.lblDegrees.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picHeading
            // 
            this.picHeading.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picHeading.BackColor = System.Drawing.Color.White;
            this.picHeading.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picHeading.Location = new System.Drawing.Point(12, 29);
            this.picHeading.Name = "picHeading";
            this.picHeading.Size = new System.Drawing.Size(260, 260);
            this.picHeading.TabIndex = 3;
            this.picHeading.TabStop = false;
            this.picHeading.Paint += new System.Windows.Forms.PaintEventHandler(this.picHeading_Paint);
            // 
            // howto_horizontal_compass_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 380);
            this.Controls.Add(this.picHeading);
            this.Controls.Add(this.lblDegrees);
            this.Controls.Add(this.hbarDegrees);
            this.Controls.Add(this.picCompass);
            this.Name = "howto_horizontal_compass_Form1";
            this.Text = "howto_horizontal_compass";
            ((System.ComponentModel.ISupportInitialize)(this.picCompass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCompass;
        private System.Windows.Forms.HScrollBar hbarDegrees;
        private System.Windows.Forms.Label lblDegrees;
        private System.Windows.Forms.PictureBox picHeading;
    }
}

