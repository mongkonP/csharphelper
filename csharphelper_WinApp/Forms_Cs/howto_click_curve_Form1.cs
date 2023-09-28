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
     public partial class howto_click_curve_Form1:Form
  { 


        public howto_click_curve_Form1()
        {
            InitializeComponent();
        }

        // The points that define the curve.
        private Point[] Points =
        {
            new Point(213, 204),
            new Point(63, 143),
            new Point(227, 60),
            new Point(123, 222),
            new Point(72, 64),
        };

        // A GraphicsPath to represent the curve.
        GraphicsPath Path = new GraphicsPath();

        // Hits and misses.
        private List<Point> Hits = new List<Point>();
        private List<Point> Misses = new List<Point>();

        // Make a GraphicsPath for the curve.
        private void howto_click_curve_Form1_Load(object sender, EventArgs e)
        {
            Path = new GraphicsPath();
            Path.AddCurve(Points);
        }

        // Draw the curve.
        private void howto_click_curve_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the curve.
            e.Graphics.DrawCurve(Pens.Blue, Points);

            // Draw the hits and misses.
            foreach (Point point in Misses)
                DrawPoint(e.Graphics, Brushes.Pink, Pens.Red, point);
            foreach (Point point in Hits)
                DrawPoint(e.Graphics, Brushes.Lime, Pens.Green, point);
        }

        // Return true if the point is over the curve.
        private bool PointIsOverCurve(Point point)
        {
            // Use a three pixel wide pen.
            using (Pen thick_pen = new Pen(Color.Black, 3))
            {
                return Path.IsOutlineVisible(point, thick_pen);
            }
        }

        // See if the mouse is over the curve's GraphicsPath.
        private void howto_click_curve_Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (PointIsOverCurve(e.Location))
                Cursor = Cursors.Cross;
            else
                Cursor = Cursors.Default;
        }

        private void howto_click_curve_Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (PointIsOverCurve(e.Location))
                Hits.Add(e.Location);
            else
                Misses.Add(e.Location);
            Refresh();
        }

        // Draw a point.
        private void DrawPoint(Graphics gr, Brush brush, Pen pen, Point point)
        {
            const int radius = 3;
            const int diameter = 2 * radius;
            Rectangle rect = new Rectangle(
                point.X - radius, point.Y - radius,
                diameter, diameter);
            gr.FillEllipse(brush, rect);
            gr.DrawEllipse(pen, rect);
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
            // howto_click_curve_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "howto_click_curve_Form1";
            this.Text = "howto_click_curve";
            this.Load += new System.EventHandler(this.howto_click_curve_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_click_curve_Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.howto_click_curve_Form1_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.howto_click_curve_Form1_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

    }
}

