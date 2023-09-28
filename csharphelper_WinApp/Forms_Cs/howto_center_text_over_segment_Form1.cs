using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Text;
using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_center_text_over_segment_Form1:Form
  { 


        public howto_center_text_over_segment_Form1()
        {
            InitializeComponent();
        }

        // Draw some text centered above and below some segments.
        private void howto_center_text_over_segment_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (Font font = new Font("Segoe UI", 14))
            {
                PointF p1, p2;

                p1 = new PointF(20, 20);
                p2 = new PointF(350, 100);
                e.Graphics.DrawLine(Pens.Blue, p1, p2);
                DrawTextOverSegment(e.Graphics, Brushes.Blue,
                    font, "Above Segment 1", p1, p2, true);
                DrawTextOverSegment(e.Graphics, Brushes.Blue,
                    font, "Below Segment 1", p1, p2, false);

                p1 = new PointF(270, 250);
                p2 = new PointF(30, 60);
                e.Graphics.DrawLine(Pens.Red, p1, p2);
                DrawTextOverSegment(e.Graphics, Brushes.Red,
                    font, "Above Segment 2", p1, p2, true);
                DrawTextOverSegment(e.Graphics, Brushes.Red,
                    font, "Below Segment 2", p1, p2, false);
            }
        }

        // Draw text centered above or below the line segment p1 --> p2.
        private void DrawTextOverSegment(Graphics gr,
            Brush brush, Font font, string text,
            PointF p1, PointF p2,
            bool text_above_segment)
        {
            // Save the Graphics object's state.
            GraphicsState state = gr.Save();

            // Get the segment's angle.
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;
            float angle = (float)(180 * Math.Atan2(dy, dx) / Math.PI);

            // Find the center point.
            float cx = (p2.X + p1.X) / 2;
            float cy = (p2.Y + p1.Y) / 2;

            // Translate and rotate the origin
            // to the center of the segment.
            gr.RotateTransform(angle, MatrixOrder.Append);
            gr.TranslateTransform(cx, cy, MatrixOrder.Append);

            // Get the string's dimensions.
            SizeF size = gr.MeasureString(text, font);

            // Make a rectangle to contain the text.
            float y = 0;
            if (text_above_segment) y = -size.Height;
            RectangleF rect = new RectangleF(
                -size.Width / 2, y,
                size.Width, size.Height);

            // Draw the text centered in the rectangle.
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                gr.DrawString(text, font, brush, rect, sf);
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
            this.SuspendLayout();
            // 
            // howto_center_text_over_segment_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Name = "howto_center_text_over_segment_Form1";
            this.Text = "howto_center_text_over_segment";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_center_text_over_segment_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

