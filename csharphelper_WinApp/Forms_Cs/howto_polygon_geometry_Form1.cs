using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

using howto_polygon_geometry;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_polygon_geometry_Form1:Form
  { 


        public howto_polygon_geometry_Form1()
        {
            InitializeComponent();
        }

        const int PT_RAD = 2;
        const int PT_WID = PT_RAD * 2 + 1;

        private List<PointF> m_Points = new List<PointF>();

        // Draw the polygon.
        private void howto_polygon_geometry_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the lines.
            if (m_Points.Count >= 3)
            {
                // Draw the polygon.
                e.Graphics.DrawPolygon(Pens.Blue, m_Points.ToArray());
            }
            else if (m_Points.Count == 2)
            {
                // Draw the line.
                e.Graphics.DrawLines(Pens.Blue, m_Points.ToArray());
            }

            // Draw the points.
            if (m_Points.Count > 0)
            {
                foreach (PointF pt in m_Points)
                {
                    e.Graphics.FillRectangle(Brushes.White, pt.X - PT_RAD, pt.Y - PT_RAD, PT_WID, PT_WID);
                    e.Graphics.DrawRectangle(Pens.Black, pt.X - PT_RAD, pt.Y - PT_RAD, PT_WID, PT_WID);
                }
            }

            // Enable menu items appropriately.
            EnableMenus();
        }

        // Enable menu items appropriately.
        private void EnableMenus()
        {
            bool enabled = (m_Points.Count >= 3);
            mnuTestsConvex.Enabled = enabled;
            mnuTestsPointInPolygon.Enabled = enabled;
            mnuTestsArea.Enabled = enabled;
            mnuTestsCentroid.Enabled = enabled;
            mnuTestsOrientation.Enabled = enabled;
            mnuTestsReverse.Enabled = enabled;
            mnuTestsTriangulate.Enabled = enabled;
            mnuTestsBoundingRectangle.Enabled = enabled;
        }

        // Remove all points.
        private void mnuTestsClear_Click(object sender, EventArgs e)
        {
            m_Points = new List<PointF>();
            EnableMenus();
            this.Invalidate();
        }

        // Save a new point.
        private void howto_polygon_geometry_Form1_MouseClick(object sender, MouseEventArgs e)
        {
            m_Points.Add(new PointF(e.X, e.Y));

            // Redraw.
            this.Invalidate();
        }

        // See if the polygon is convex.
        private void mnuTestsConvex_Click(object sender, EventArgs e)
        {
            // Make a Polygon.
            Polygon pgon = new Polygon(m_Points.ToArray());

            if (pgon.PolygonIsConvex())
            {
                MessageBox.Show("The polygon is convex", "Convex",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The polygon is not convex", "Not Convex",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // See if the mouse's current position is inside the polygon.
        private void mnuTestsPointInPolygon_Click(object sender, EventArgs e)
        {
            // Get the current mouse position.
            Point pt = Cursor.Position;

            // Convert into form coordinates.
            pt = this.PointToClient(pt);

            Rectangle rect = new Rectangle(pt.X - 3, pt.Y - 3, 7, 7);
            using (Graphics gr = this.CreateGraphics())
            {
                // Make a Polygon.
                Polygon pgon = new Polygon(m_Points.ToArray());

                // See if the point is in the polygon.
                if (pgon.PointInPolygon(pt.X, pt.Y))
                {
                    gr.FillEllipse(Brushes.Lime, rect);
                }
                else
                {
                    gr.FillEllipse(Brushes.Red, rect);
                }
                gr.DrawEllipse(Pens.Black, rect);
            }
        }

        // Find the polygon's area.
        private void mnuTestsArea_Click(object sender, EventArgs e)
        {
            // Make a Polygon.
            Polygon pgon = new Polygon(m_Points.ToArray());

            MessageBox.Show("Area: " + pgon.PolygonArea().ToString(), "Area",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Display the centroid.
        private void mnuTestsCentroid_Click(object sender, EventArgs e)
        {
            // Make a Polygon.
            Polygon pgon = new Polygon(m_Points.ToArray());

            PointF pt = pgon.FindCentroid();

            Rectangle rect = new Rectangle((int)pt.X - 3, (int)pt.Y - 3, 7, 7);
            using (Graphics gr = this.CreateGraphics())
            {
                gr.FillEllipse(Brushes.Yellow, rect);
                gr.DrawEllipse(Pens.Black, rect);
            }
        }

        // See if the polygon is oriented clockwise or counterclockwise.
        private void mnuTestsOrientation_Click(object sender, EventArgs e)
        {
            // Make a Polygon.
            Polygon pgon = new Polygon(m_Points.ToArray());

            if (pgon.PolygonIsOrientedClockwise())
            {
                MessageBox.Show("Clockwise", "Clockwise",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Counterclockwise", "Counterclockwise",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Reverse the polygon's orientation.
        private void mnuTestsReverse_Click(object sender, EventArgs e)
        {
            m_Points.Reverse();
        }

        // Triangulate the polygon.
        private void mnuTestsTriangulate_Click(object sender, EventArgs e)
        {
            // Make a Polygon.
            Polygon pgon = new Polygon(m_Points.ToArray());

            // Triangulate.
            List<Triangle> triangles = pgon.Triangulate();

            // Draw the triangles.
            using (Graphics gr = this.CreateGraphics())
            {
                foreach (Triangle tri in triangles)
                {
                    gr.DrawPolygon(Pens.Red, tri.Points);
                }

                // Redraw the polygon.
                if (m_Points.Count >= 3)
                {
                    // Draw the polygon.
                    gr.DrawPolygon(Pens.Blue, m_Points.ToArray());
                }
            }
        }

        // Find the polygon's bounding rectangle.
        private void mnuTestsBoundingRectangle_Click(object sender, EventArgs e)
        {
            // Make a Polygon.
            Polygon pgon = new Polygon(m_Points.ToArray());

            // Make sure it's oriented counter-clockwise.
            if (pgon.PolygonIsOrientedClockwise())
            {
                Array.Reverse(pgon.Points);
            }

            // Find the polygon's bounding rectangle.
            PointF[] pts = pgon.FindSmallestBoundingRectangle();

            // Draw it.
            using (Graphics gr = this.CreateGraphics())
            {
                gr.DrawPolygon(Pens.Orange, pts);
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
            this.components = new System.ComponentModel.Container();
            this.MainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.mnuTests = new System.Windows.Forms.MenuItem();
            this.mnuTestsClear = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuTestsConvex = new System.Windows.Forms.MenuItem();
            this.mnuTestsPointInPolygon = new System.Windows.Forms.MenuItem();
            this.mnuTestsArea = new System.Windows.Forms.MenuItem();
            this.mnuTestsCentroid = new System.Windows.Forms.MenuItem();
            this.mnuTestsOrientation = new System.Windows.Forms.MenuItem();
            this.mnuTestsReverse = new System.Windows.Forms.MenuItem();
            this.mnuTestsTriangulate = new System.Windows.Forms.MenuItem();
            this.mnuTestsBoundingRectangle = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // MainMenu1
            // 
            this.MainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuTests});
            // 
            // mnuTests
            // 
            this.mnuTests.Index = 0;
            this.mnuTests.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuTestsClear,
            this.menuItem1,
            this.mnuTestsConvex,
            this.mnuTestsPointInPolygon,
            this.mnuTestsArea,
            this.mnuTestsCentroid,
            this.mnuTestsOrientation,
            this.mnuTestsReverse,
            this.mnuTestsTriangulate,
            this.mnuTestsBoundingRectangle});
            this.mnuTests.Text = "&Tests";
            // 
            // mnuTestsClear
            // 
            this.mnuTestsClear.Index = 0;
            this.mnuTestsClear.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.mnuTestsClear.Text = "Clear";
            this.mnuTestsClear.Click += new System.EventHandler(this.mnuTestsClear_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 1;
            this.menuItem1.Text = "-";
            // 
            // mnuTestsConvex
            // 
            this.mnuTestsConvex.Enabled = false;
            this.mnuTestsConvex.Index = 2;
            this.mnuTestsConvex.Shortcut = System.Windows.Forms.Shortcut.F2;
            this.mnuTestsConvex.Text = "&Convex";
            this.mnuTestsConvex.Click += new System.EventHandler(this.mnuTestsConvex_Click);
            // 
            // mnuTestsPointInPolygon
            // 
            this.mnuTestsPointInPolygon.Enabled = false;
            this.mnuTestsPointInPolygon.Index = 3;
            this.mnuTestsPointInPolygon.Shortcut = System.Windows.Forms.Shortcut.F3;
            this.mnuTestsPointInPolygon.Text = "&Point in Polygon";
            this.mnuTestsPointInPolygon.Click += new System.EventHandler(this.mnuTestsPointInPolygon_Click);
            // 
            // mnuTestsArea
            // 
            this.mnuTestsArea.Enabled = false;
            this.mnuTestsArea.Index = 4;
            this.mnuTestsArea.Shortcut = System.Windows.Forms.Shortcut.F4;
            this.mnuTestsArea.Text = "&Area";
            this.mnuTestsArea.Click += new System.EventHandler(this.mnuTestsArea_Click);
            // 
            // mnuTestsCentroid
            // 
            this.mnuTestsCentroid.Enabled = false;
            this.mnuTestsCentroid.Index = 5;
            this.mnuTestsCentroid.Shortcut = System.Windows.Forms.Shortcut.F5;
            this.mnuTestsCentroid.Text = "Centroi&d";
            this.mnuTestsCentroid.Click += new System.EventHandler(this.mnuTestsCentroid_Click);
            // 
            // mnuTestsOrientation
            // 
            this.mnuTestsOrientation.Enabled = false;
            this.mnuTestsOrientation.Index = 6;
            this.mnuTestsOrientation.Shortcut = System.Windows.Forms.Shortcut.F6;
            this.mnuTestsOrientation.Text = "&Orientation";
            this.mnuTestsOrientation.Click += new System.EventHandler(this.mnuTestsOrientation_Click);
            // 
            // mnuTestsReverse
            // 
            this.mnuTestsReverse.Enabled = false;
            this.mnuTestsReverse.Index = 7;
            this.mnuTestsReverse.Text = "&Reverse";
            this.mnuTestsReverse.Click += new System.EventHandler(this.mnuTestsReverse_Click);
            // 
            // mnuTestsTriangulate
            // 
            this.mnuTestsTriangulate.Enabled = false;
            this.mnuTestsTriangulate.Index = 8;
            this.mnuTestsTriangulate.Shortcut = System.Windows.Forms.Shortcut.F7;
            this.mnuTestsTriangulate.Text = "&Triangulate";
            this.mnuTestsTriangulate.Click += new System.EventHandler(this.mnuTestsTriangulate_Click);
            // 
            // mnuTestsBoundingRectangle
            // 
            this.mnuTestsBoundingRectangle.Enabled = false;
            this.mnuTestsBoundingRectangle.Index = 9;
            this.mnuTestsBoundingRectangle.Shortcut = System.Windows.Forms.Shortcut.F8;
            this.mnuTestsBoundingRectangle.Text = "Bounding Rectangle";
            this.mnuTestsBoundingRectangle.Click += new System.EventHandler(this.mnuTestsBoundingRectangle_Click);
            // 
            // howto_polygon_geometry_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 285);
            this.Menu = this.MainMenu1;
            this.Name = "howto_polygon_geometry_Form1";
            this.Text = "howto_polygon_geometry";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_polygon_geometry_Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.howto_polygon_geometry_Form1_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.MainMenu MainMenu1;
        internal System.Windows.Forms.MenuItem mnuTests;
        private System.Windows.Forms.MenuItem mnuTestsClear;
        private System.Windows.Forms.MenuItem menuItem1;
        internal System.Windows.Forms.MenuItem mnuTestsConvex;
        internal System.Windows.Forms.MenuItem mnuTestsPointInPolygon;
        internal System.Windows.Forms.MenuItem mnuTestsArea;
        internal System.Windows.Forms.MenuItem mnuTestsCentroid;
        internal System.Windows.Forms.MenuItem mnuTestsOrientation;
        internal System.Windows.Forms.MenuItem mnuTestsReverse;
        internal System.Windows.Forms.MenuItem mnuTestsTriangulate;
        private System.Windows.Forms.MenuItem mnuTestsBoundingRectangle;
    }
}

