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
     public partial class howto_draw_text_along_curve_Form1:Form
  { 


        public howto_draw_text_along_curve_Form1()
        {
            InitializeComponent();
        }

        // Draw some text along a curve.
        private void howto_draw_text_along_curve_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.High;

            // Draw some text along some paths.
            GraphicsPath path = new GraphicsPath();
            path.AddArc(new RectangleF(40, 40, 320, 220), 180, 180);
            e.Graphics.DrawPath(Pens.Green, path);
            DrawTextOnPath(e.Graphics, Brushes.Blue, this.Font,
                "This is some text drawn along a path", path, true);
            DrawTextOnPath(e.Graphics, Brushes.Blue, this.Font,
                "This is some text drawn along a path", path, false);

            path = new GraphicsPath();
            path.AddArc(new RectangleF(40, 50, 320, 220), 0, 180);
            e.Graphics.DrawPath(Pens.Red, path);
            DrawTextOnPath(e.Graphics, Brushes.Blue, this.Font,
                "This is some text drawn along a path", path, true);
            DrawTextOnPath(e.Graphics, Brushes.Blue, this.Font,
                "This is some text drawn along a path", path, false);
        }

        // Draw some text along a GraphicsPath.
        private void DrawTextOnPath(Graphics gr, Brush brush, Font font, string txt, GraphicsPath path, bool text_above_path)
        {
            // Make a copy so we don't mess up the original.
            path = (GraphicsPath)path.Clone();

            // Flatten the path into segments.
            path.Flatten();

            // Draw characters.
            int start_ch = 0;
            PointF start_point = path.PathPoints[0];
            for (int i = 1; i < path.PointCount; i++)
            {
                PointF end_point = path.PathPoints[i];
                DrawTextOnSegment(gr, brush, font, txt, ref start_ch,
                    ref start_point, end_point, text_above_path);
                if (start_ch >= txt.Length) break;
            }
        }

        // Draw some text along a line segment.
        // Leave char_num pointing to the next character to be drawn.
        // Leave start_point holding the coordinates of the last point used.
        private void DrawTextOnSegment(Graphics gr, Brush brush, Font font, string txt, ref int first_ch, ref PointF start_point, PointF end_point, bool text_above_segment)
        {
            float dx = end_point.X - start_point.X;
            float dy = end_point.Y - start_point.Y;
            float dist = (float)Math.Sqrt(dx * dx + dy * dy);
            dx /= dist;
            dy /= dist;

            // See how many characters will fit.
            int last_ch = first_ch;
            while (last_ch < txt.Length)
            {
                string test_string = txt.Substring(first_ch, last_ch - first_ch + 1);
                if (gr.MeasureString(test_string, font).Width > dist)
                {
                    // This is one too many characters.
                    last_ch--;
                    break;
                }
                last_ch++;
            }
            if (last_ch < first_ch) return;
            if (last_ch >= txt.Length) last_ch = txt.Length - 1;
            string chars_that_fit = txt.Substring(first_ch, last_ch - first_ch + 1);

            // Rotate and translate to position the characters.
            GraphicsState state = gr.Save();
            if (text_above_segment)
            {
                gr.TranslateTransform(0,
                    -gr.MeasureString(chars_that_fit, font).Height,
                    MatrixOrder.Append);
            }
            float angle = (float)(180 * Math.Atan2(dy, dx) / Math.PI);
            gr.RotateTransform(angle, MatrixOrder.Append);
            gr.TranslateTransform(start_point.X, start_point.Y, MatrixOrder.Append);

            // Draw the characters that fit.
            gr.DrawString(chars_that_fit, font, brush, 0, 0);

            // Restore the saved state.
            gr.Restore(state);

            // Update first_ch and start_point.
            first_ch = last_ch + 1;
            float text_width = gr.MeasureString(chars_that_fit, font).Width;
            start_point = new PointF(
                start_point.X + dx * text_width,
                start_point.Y + dy * text_width);
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
            // howto_draw_text_along_curve_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 321);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "howto_draw_text_along_curve_Form1";
            this.Text = "howto_draw_text_along_curve";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_draw_text_along_curve_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

