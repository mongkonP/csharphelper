using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

using howto_convex_hull;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_convex_hull_Form1:Form
  { 


        public howto_convex_hull_Form1()
        {
            InitializeComponent();
        }

        private List<Point> m_Points = new List<Point>();

        private void btnClear_Click(object sender, EventArgs e)
        {
            m_Points = new List<Point>();
            this.Invalidate();
        }

        // Add a new Point.
        private void howto_convex_hull_Form1_MouseDown(object sender, MouseEventArgs e)
        {
            m_Points.Add(new Point(e.X, e.Y));
            this.Invalidate();
        }

        // Redraw.
        private void howto_convex_hull_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the convex hull.

            // Fill all of the points.
            foreach (Point pt in m_Points)
            {
                e.Graphics.FillEllipse(Brushes.Cyan, pt.X - 3, pt.Y - 3, 7, 7);
            }

            List<Point> hull = null;
            if (m_Points.Count >= 3)
            {
                // Get the convex hull.
                hull = Geometry.MakeConvexHull(m_Points);

                // Draw.
                // Fill the non-culled points.
                foreach (Point pt in Geometry.g_NonCulledPoints)
                {
                    e.Graphics.FillEllipse(Brushes.White, pt.X - 3, pt.Y - 3, 7, 7);
                }
            }

            // Draw all of the points.
            foreach (Point pt in m_Points)
            {
                e.Graphics.DrawEllipse(Pens.Black, pt.X - 3, pt.Y - 3, 7, 7);
            }

            if (m_Points.Count >= 3)
            {
                // Draw the MinMax quadrilateral.
                e.Graphics.DrawPolygon(Pens.Red, Geometry.g_MinMaxCorners);

                // Draw the culling box.
                e.Graphics.DrawRectangle(Pens.Orange, Geometry.g_MinMaxBox);

                // Draw the convex hull.
                Point[] hull_points = new Point[hull.Count];
                hull.CopyTo(hull_points);
                e.Graphics.DrawPolygon(Pens.Blue, hull_points);
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
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(2, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // howto_convex_hull_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.btnClear);
            this.Name = "howto_convex_hull_Form1";
            this.Text = "howto_convex_hull";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_convex_hull_Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.howto_convex_hull_Form1_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnClear;
    }
}

