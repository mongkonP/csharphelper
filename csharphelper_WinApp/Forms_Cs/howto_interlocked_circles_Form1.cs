//#define DRAW_IMPOSSIBLE
#define TEST5

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// See: http://csharphelper.com/blog/2014/09/determine-where-two-circles-intersect-in-c/

using System.Drawing.Drawing2D;

 

using howto_interlocked_circles;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_interlocked_circles_Form1:Form
  { 


        public howto_interlocked_circles_Form1()
        {
            InitializeComponent();
        }

        private Circle[] Circles = null;

        // See where the circles intersect.
        private void howto_interlocked_circles_Form1_Load(object sender, EventArgs e)
        {
            // Make some circles.
#if TEST1
            // Three all interlocked.
            Circles = new Circle[]
            {
                new Circle(new PointF(125, 100), 50, 10, 2, Color.Orange, Color.Black),
                new Circle(new PointF(100, 150), 50, 10, 2, Color.Red, Color.Black),
                new Circle(new PointF(150, 150), 50, 10, 2, Color.Blue, Color.Black),
            };
#elif TEST2
            // A chain of four interlocked with neighbors.
            Circles = new Circle[]
            {
                new Circle(new PointF(60, 100), 30, 10, 2, Color.Orange, Color.Black),
                new Circle(new PointF(100, 100), 30, 10, 2, Color.Red, Color.Black),
                new Circle(new PointF(140, 100), 30, 10, 2, Color.Green, Color.Black),
                new Circle(new PointF(180, 100), 30, 10, 2, Color.Blue, Color.Black),
            };
#elif TEST3
            // Four linked through a central fifth.
            Circles = new Circle[]
            {
                new Circle(new PointF(70, 70), 40, 10, 2, Color.Orange, Color.Black),
                new Circle(new PointF(180, 70), 40, 10, 2, Color.Green, Color.Black),
                new Circle(new PointF(70, 180), 40, 10, 2, Color.Red, Color.Black),
                new Circle(new PointF(180, 180), 40, 10, 2, Color.Blue, Color.Black),
                new Circle(new PointF(125, 125), 60, 10, 2, Color.Yellow, Color.Black),
            };
#elif TEST4
            // Two sets of three.
            Circles = new Circle[]
            {
                new Circle(new PointF(90, 75), 30, 7, 2, Color.Orange, Color.Black),
                new Circle(new PointF(75, 100), 30, 7, 2, Color.Red, Color.Black),
                new Circle(new PointF(105, 100), 30, 7, 2, Color.Blue, Color.Black),

                new Circle(new PointF(170, 155), 30, 7, 2, Color.Orange, Color.Black),
                new Circle(new PointF(155, 180), 30, 7, 2, Color.Red, Color.Black),
                new Circle(new PointF(185, 180), 30, 7, 2, Color.Blue, Color.Black),
            };
#elif TEST5
            // Four all interlocked.
            Circles = new Circle[]
            {
                new Circle(new PointF(100, 100), 50, 10, 2, Color.Orange, Color.Black),
                new Circle(new PointF(150, 100), 50, 10, 2, Color.Green, Color.Black),
                new Circle(new PointF(100, 150), 50, 10, 2, Color.Red, Color.Black),
                new Circle(new PointF(150, 150), 50, 10, 2, Color.Blue, Color.Black),
            };
#elif TEST6
            // Olymic rings.
            float x = 60;
            float y = 100;
            List<Circle> circle_list = new List<Circle>();
            circle_list.Add(new Circle(new PointF(x, y), 40, 7, 2, Color.SteelBlue, Color.Transparent));
            x += 46;
            y += 46;
            circle_list.Add(new Circle(new PointF(x, y), 40, 7, 2, Color.Orange, Color.Transparent));
            x += 46;
            y -= 46;
            circle_list.Add(new Circle(new PointF(x, y), 40, 7, 2, Color.Black, Color.Transparent));
            x += 46;
            y += 46;
            circle_list.Add(new Circle(new PointF(x, y), 40, 7, 2, Color.Green, Color.Transparent));
            x += 46;
            y -= 46;
            circle_list.Add(new Circle(new PointF(x, y), 40, 7, 2, Color.Red, Color.Transparent));
            Circles = circle_list.ToArray();
#elif TEST7
            // Five interlocked with neighbors and a center ring.
            Color[] colors =
            {
                Color.Red,
                Color.Green,
                Color.Orange,
                Color.Yellow,
                Color.Blue,
                Color.Black,
            };
            Circles = new Circle[6];
            float cx = ClientSize.Width / 2f;
            float cy = ClientSize.Height / 2f;
            float r = 60;
            double theta = -Math.PI / 2;
            double dtheta = 2 * Math.PI / 5;
            for (int i = 0; i < 5; i++)
            {
                PointF center = new PointF(
                    (float)(cx + r * Math.Cos(theta)),
                    (float)(cy + r * Math.Sin(theta)));
                Circles[i] = new Circle(center, 45, 8, 2, colors[i], Color.Black);
                theta += dtheta;
            }
            Circles[5] = new Circle(new PointF(cx, cy), 50, 8, 2, colors[5], Color.Black);
#endif

            // Find the circles' POIs.
            Circle.FindPois(Circles);
        }

        // Draw the circles.
        private void howto_interlocked_circles_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

#if DRAW_IMPOSSIBLE
            DrawImpossible(e.Graphics);
#else
            // Draw the circles.
            foreach (Circle circle in Circles) circle.Draw(e.Graphics);

            // Draw the on top POIs.
            foreach (Circle circle in Circles) circle.DrawPois(e.Graphics);
#endif
        }

        // Draw three circles that cannot be arranged
        // so they all alternate above and below.
        private void DrawImpossible(Graphics gr)
        {
            gr.Clear(BackColor);

            int r = 50;
            float x1 = ClientSize.Width / 2 + r * 1.5f / 2;
            float y1 = ClientSize.Height / 2 - r;
            float x2 = x1 - r * 1.5f;
            float y2 = y1;
            float x3 = x1;
            float y3 = y1 + 2 * r;

            using (Pen outline_pen = new Pen(Color.Black, 2))
            {
                using (Pen hoop_pen = new Pen(Color.Red, 10))
                {
                    gr.DrawThickArc(new PointF(x1, y1), r, 0, 360, hoop_pen, outline_pen);

                    hoop_pen.Color = Color.Blue;
                    gr.DrawThickArc(new PointF(x2, y2), r, 0, 360, hoop_pen, outline_pen);
                    hoop_pen.Color = Color.Red;
                    gr.DrawThickArc(new PointF(x1, y1), r, 180, 180, hoop_pen, outline_pen);

                    hoop_pen.Color = Color.Green;
                    gr.DrawThickArc(new PointF(x3, y3), r, 0, 360, hoop_pen, outline_pen);
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
            // howto_interlocked_circles_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 250);
            this.Name = "howto_interlocked_circles_Form1";
            this.Text = "howto_interlocked_circles";
            this.Load += new System.EventHandler(this.howto_interlocked_circles_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_interlocked_circles_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion


    }
}

