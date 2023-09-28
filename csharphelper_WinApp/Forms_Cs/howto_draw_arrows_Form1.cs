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
     public partial class howto_draw_arrows_Form1:Form
  { 


        public howto_draw_arrows_Form1()
        {
            InitializeComponent();
        }

        private void howto_draw_arrows_Form1_Load(object sender, EventArgs e)
        {
            ResizeRedraw = true;
        }

        // Draw some arrows.
        private void howto_draw_arrows_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int x1 = 20;
            int x2 = ClientSize.Width - 20;

            using (Pen thick_pen = new Pen(Color.Blue, 3))
            {
                int y = 20;
                DrawArrow(e.Graphics, thick_pen,
                    new PointF(x1, y), new PointF(x2, y), 10,
                    EndpointStyle.Fletching,
                    EndpointStyle.ArrowHead);
                y += 30;
                DrawArrow(e.Graphics, thick_pen,
                    new PointF(x1, y), new PointF(x2, y), 10,
                    EndpointStyle.ArrowHead,
                    EndpointStyle.ArrowHead);
                y += 30;
                DrawArrow(e.Graphics, thick_pen,
                    new PointF(x1, y), new PointF(x2, y), 10,
                    EndpointStyle.ArrowHead,
                    EndpointStyle.Fletching);
                y += 30;
                DrawArrow(e.Graphics, thick_pen,
                    new PointF(x1, y), new PointF(x2, y), 10,
                    EndpointStyle.Fletching,
                    EndpointStyle.Fletching);
            }

            using (Pen thick_pen = new Pen(Color.Red, 3))
            {
                int y = 150;
                DrawArrow(e.Graphics, thick_pen,
                    new PointF(x1, y), new PointF(x2, y + 50), 10,
                    EndpointStyle.Fletching,
                    EndpointStyle.ArrowHead);
                y += 30;
                DrawArrow(e.Graphics, thick_pen,
                    new PointF(x1, y), new PointF(x2, y + 50), 10,
                    EndpointStyle.ArrowHead,
                    EndpointStyle.ArrowHead);
                y += 30;
                DrawArrow(e.Graphics, thick_pen,
                    new PointF(x1, y), new PointF(x2, y + 50), 10,
                    EndpointStyle.ArrowHead,
                    EndpointStyle.Fletching);
                y += 30;
                DrawArrow(e.Graphics, thick_pen,
                    new PointF(x1, y), new PointF(x2, y + 50), 10,
                    EndpointStyle.Fletching,
                    EndpointStyle.Fletching);
            }
        }

        // The end point style.
        private enum EndpointStyle
        {
            None,
            ArrowHead,
            Fletching
        }

        // Draw arrow heads or tails for the
        // segment from p1 to p2.
        private void DrawArrow(Graphics gr, Pen pen, PointF p1, PointF p2,
            float length, EndpointStyle style1, EndpointStyle style2)
        {
            // Draw the shaft.
            gr.DrawLine(pen, p1, p2);

            // Find the arrow shaft unit vector.
            float vx = p2.X - p1.X;
            float vy = p2.Y - p1.Y;
            float dist = (float)Math.Sqrt(vx * vx + vy * vy);
            vx /= dist;
            vy /= dist;

            // Draw the start.
            if (style1 == EndpointStyle.ArrowHead)
            {
                DrawArrowhead(gr, pen, p1, -vx, -vy, length);
            }
            else if (style1 == EndpointStyle.Fletching)
            {
                DrawArrowhead(gr, pen, p1, vx, vy, length);
            }

            // Draw the end.
            if (style2 == EndpointStyle.ArrowHead)
            {
                DrawArrowhead(gr, pen, p2, vx, vy, length);
            }
            else if (style2 == EndpointStyle.Fletching)
            {
                DrawArrowhead(gr, pen, p2, -vx, -vy, length);
            }
        }

        // Draw an arrowhead at the given point
        // in the normalized direction <nx, ny>.
        private void DrawArrowhead(Graphics gr, Pen pen,
            PointF p, float nx, float ny, float length)
        {
            float ax = length * (-ny - nx);
            float ay = length * (nx - ny);
            PointF[] points =
            {
                new PointF(p.X + ax, p.Y + ay),
                p,
                new PointF(p.X - ay, p.Y + ax)
            };
            gr.DrawLines(pen, points);
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
            // howto_draw_arrows_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 316);
            this.Name = "howto_draw_arrows_Form1";
            this.Text = "howto_draw_arrows";
            this.Load += new System.EventHandler(this.howto_draw_arrows_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_draw_arrows_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

    }
}

