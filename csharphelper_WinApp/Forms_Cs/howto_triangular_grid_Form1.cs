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
     public partial class howto_triangular_grid_Form1:Form
  { 


        public howto_triangular_grid_Form1()
        {
            InitializeComponent();
        }

        // The height of a triangle.
        private const float TriangleHeight = 50;

        // Selected triangles.
        private List<PointF> Triangles = new List<PointF>();

        // Redraw the grid.
        private void picGrid_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the selected triangles.
            foreach (PointF point in Triangles)
            {
                e.Graphics.FillPolygon(Brushes.LightBlue,
                    TriangleToPoints(TriangleHeight, point.X, point.Y));
            }

            // Draw the grid.
            DrawTriangularGrid(e.Graphics, Pens.Black,
                0, picGrid.ClientSize.Width,
                0, picGrid.ClientSize.Height,
                TriangleHeight);

            //// Used to draw Figure 1.
            //PointF[] tri_points = TriangleToPoints(TriangleHeight, 2, 1.5f);
            //using (Pen pen = new Pen(Color.Red, 3))
            //{
            //    pen.DashStyle = DashStyle.Dash;
            //    var xquery =
            //        from PointF point in tri_points
            //        select point.X;
            //    float x = xquery.Min();
            //    var yquery =
            //        from PointF point in tri_points
            //        select point.Y;
            //    float y = yquery.Min();
            //    e.Graphics.DrawRectangle(pen, x, y,
            //        TriangleWidth(TriangleHeight),
            //        TriangleHeight);
            //}
        }

        // Draw a triangular grid for the indicated area.
        private void DrawTriangularGrid(Graphics gr, Pen pen,
            float xmin, float xmax, float ymin, float ymax,
            float height)
        {
            float width = TriangleWidth(height);
            int row = 0;
            for (float y = 0; y <= ymax + width / 2; y += height)
            {
                float x = 0;
                if (row % 2 == 0) x = width / 2;

                PointF[] points =
                {
                    new PointF(x, y),
                    new PointF(x + width / 2, y + height),
                    new PointF(x - width / 2, y + height),
                };
                for (; x <= xmax; x += width)
                {
                    gr.DrawPolygon(pen, points);
                    points[0].X += width;
                    points[1].X += width;
                    points[2].X += width;
                }
                row++;
            }
        }

        private void picGrid_Resize(object sender, EventArgs e)
        {
            picGrid.Refresh();
        }

        // Display the row and column under the mouse.
        private void picGrid_MouseMove(object sender, MouseEventArgs e)
        {
            float row, col;
            PointToTriangle(e.X, e.Y, TriangleHeight, out row, out col);
            this.Text = "(" + row + ", " + col + ")";
        }

        // Add the clicked triangle to the Triangles list.
        private void picGrid_MouseClick(object sender, MouseEventArgs e)
        {
            float row, col;
            PointToTriangle(e.X, e.Y, TriangleHeight, out row, out col);
            Triangles.Add(new PointF(row, col));
            picGrid.Refresh();
        }

        // Return the width of a triangle.
        private float TriangleWidth(float height)
        {
            return (float)(2 * height / Math.Sqrt(3));
        }

        // Return the row and column of the triangle at this point.
        private void PointToTriangle(float x, float y, float height, out float row, out float col)
        {
            float width = TriangleWidth(height);
            row = (int)(y / height);
            col = (int)(x / width);

            float dy = (row + 1) * height - y;
            float dx = x - col * width;
            if (row % 2 == 1) dy = height - dy;
            if (dy > 1)
            {
                if (dx < width / 2)
                {
                    // Left half of triangle.
                    float ratio = dx / dy;
                    if (ratio < 1f / Math.Sqrt(3)) col -= 0.5f;
                }
                else
                {
                    // Right half of triangle.
                    float ratio = (width - dx) / dy;
                    if (ratio < 1f / Math.Sqrt(3)) col += 0.5f;
                }
            }
        }

        // Return the points that define the indicated triangle.
        private PointF[] TriangleToPoints(float height, float row, float col)
        {
            float width = TriangleWidth(height);
            float y = row * height;
            float x = (col + 0.5f) * width;

            // See if this triangle should be drawn
            // right-side up or upside down.
            bool whole_col = (Math.Abs(col - (int)col) < 0.1);
            bool rightside_up;
            if ((int)row % 2 == 0)
            {
                // Even row.
                rightside_up = whole_col;
            }
            else
            {
                // Odd row.
                rightside_up = !whole_col;
            }

            // Draw the triangle.
            if (rightside_up)
                return new PointF[]
                    {
                        new PointF(x, y),
                        new PointF(x + width / 2, y + height),
                        new PointF(x - width / 2, y + height),
                    };
            else
                return new PointF[]
                    {
                        new PointF(x, y + height),
                        new PointF(x + width / 2, y),
                        new PointF(x - width / 2, y),
                    };
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
            this.picGrid = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // picGrid
            // 
            this.picGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGrid.BackColor = System.Drawing.Color.White;
            this.picGrid.Location = new System.Drawing.Point(12, 12);
            this.picGrid.Name = "picGrid";
            this.picGrid.Size = new System.Drawing.Size(260, 237);
            this.picGrid.TabIndex = 0;
            this.picGrid.TabStop = false;
            this.picGrid.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picGrid_MouseMove);
            this.picGrid.Resize += new System.EventHandler(this.picGrid_Resize);
            this.picGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picGrid_MouseClick);
            this.picGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.picGrid_Paint);
            // 
            // howto_triangular_grid_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.picGrid);
            this.Name = "howto_triangular_grid_Form1";
            this.Text = "howto_triangular_grid";
            ((System.ComponentModel.ISupportInitialize)(this.picGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picGrid;
    }
}

