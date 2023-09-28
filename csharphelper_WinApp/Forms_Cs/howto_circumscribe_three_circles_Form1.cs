// #define DRAW_DIAGRAM

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
     public partial class howto_circumscribe_three_circles_Form1:Form
  { 


        public howto_circumscribe_three_circles_Form1()
        {
            InitializeComponent();
        }

        // Redraw on resize.
        private void howto_circumscribe_three_circles_Form1_Load(object sender, EventArgs e)
        {
#if DRAW_DIAGRAM
            ClientSize = new Size(300, 300);
#endif
            ResizeRedraw = true;
        }

        // Draw the circles.
        private void howto_circumscribe_three_circles_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
#if DRAW_DIAGRAM
            e.Graphics.Clear(Color.White);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
#endif

            // Get the available area.
            float R = Math.Min(ClientSize.Width - 1, ClientSize.Height - 1) / 2;
            float cx = ClientSize.Width / 2;
            float cy = ClientSize.Height / 2;

            // Calculate the radius for the inner circles.
            float B = (float)(R / (1 + 2 / Math.Sqrt(3)));
            float A = (float)(2 * B / Math.Sqrt(3));
            float C = A / 2;

            // Draw the big circle.
            e.Graphics.DrawEllipse(Pens.Black,
                cx - R, cy - R, 2 * R, 2 * R);

            // Draw the top inner circle.
            float cx1 = cx;
            float cy1 = cy - A;
            e.Graphics.DrawEllipse(Pens.Red,
                cx1 - B, cy1 - B, 2 * B, 2 * B);

            // Draw the left inner circle.
            float cx2 = cx - B;
            float cy2 = cy + (float)(B / Math.Sqrt(3));
            e.Graphics.DrawEllipse(Pens.Green,
                cx2 - B, cy2 - B, 2 * B, 2 * B);

            // Draw the right inner circle.
            float cx3 = cx + B;
            float cy3 = cy2;
            e.Graphics.DrawEllipse(Pens.Blue,
                cx3 - B, cy3 - B, 2 * B, 2 * B);

#if DRAW_DIAGRAM
            DrawDiagram(e.Graphics, cx, cy, cx1, cy1, cx2, cy2, cx3, cy3, A, B, C);
#endif
        }

        // Draw the diagram.
        private void DrawDiagram(Graphics gr, float cx, float cy, float cx1, float cy1, float cx2, float cy2, float cx3, float cy3, float A, float B, float C)
        {
            // Draw the diagram.
            using (Pen dashed_pen = new Pen(Color.Gray, 0))
            {
                dashed_pen.DashStyle = DashStyle.Custom;
                dashed_pen.DashPattern = new float[] { 5, 5 };
                gr.DrawLine(dashed_pen, cx1, cy1, cx2, cy2);
                gr.DrawLine(dashed_pen, cx2, cy2, cx3, cy3);
                gr.DrawLine(dashed_pen, cx3, cy3, cx1, cy1);
            }

            gr.DrawLine(Pens.Orange, cx2, cy2, cx2 + B, cy2);
            gr.DrawLine(Pens.Orange, cx2, cy2, cx, cy);
            gr.DrawLine(Pens.Orange, cx, cy, cx2 + B, cy2);

            // Draw the line from the triangle to the edge of the outer circle.
            // Get a unit vector in the correct direction.
            float nx = B;
            float ny = C;
            float dist = (float)Math.Sqrt(nx * nx + ny * ny);
            nx /= dist;
            ny /= dist;
            float rx = cx2 - B * nx;
            float ry = cy2 + B * ny;
            gr.DrawLine(Pens.Green, cx2, cy2, rx, ry);

            using (Font font = new Font("Times New Roman", 14))
            {
                using (StringFormat string_format = new StringFormat())
                {
                    string_format.Alignment = StringAlignment.Center;
                    string_format.LineAlignment = StringAlignment.Far;
                    float tx = (cx2 + cx) / 2;
                    float ty = (cy2 + cy) / 2;
                    gr.RotateTransform(-30);
                    gr.TranslateTransform(tx, ty, MatrixOrder.Append);
                    gr.DrawString("A", font, Brushes.Black, 0, 0, string_format);

                    gr.ResetTransform();
                    gr.RotateTransform(-30);
                    tx = (cx2 + rx) / 2;
                    ty = (cy2 + ry) / 2;
                    gr.TranslateTransform(tx, ty, MatrixOrder.Append);
                    gr.DrawString("r", font, Brushes.Black, 0, 0, string_format);

                    gr.ResetTransform();
                    string_format.LineAlignment = StringAlignment.Near;
                    tx = (cx2 + cx) / 2;
                    ty = cy2;
                    gr.DrawString("B", font, Brushes.Black, tx, ty, string_format);

                    tx = cx;
                    ty = (cy3 + cy) / 2;
                    gr.RotateTransform(-90);
                    gr.TranslateTransform(tx, ty, MatrixOrder.Append);
                    gr.DrawString("C", font, Brushes.Black, 0, 0, string_format);
                }
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
            // howto_circumscribe_three_circles_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 211);
            this.Name = "howto_circumscribe_three_circles_Form1";
            this.Text = "howto_circumscribe_three_circles";
            this.Load += new System.EventHandler(this.howto_circumscribe_three_circles_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_circumscribe_three_circles_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

