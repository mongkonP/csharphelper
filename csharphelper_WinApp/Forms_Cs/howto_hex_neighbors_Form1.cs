//#define FIG1
//#define FIG34

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
     public partial class howto_hex_neighbors_Form1:Form
  { 


        public howto_hex_neighbors_Form1()
        {
            InitializeComponent();
        }

        // The height of a hexagon.
        private const float HexHeight = 50;

        // Selected hexagons.
        private List<PointF> Hexagons = new List<PointF>();

#if FIG34
        // The selected search rectangle.
        // Used to draw Figures 3 and 4.
        private List<RectangleF> TestRects = new List<RectangleF>();
#endif

        // Redraw the grid.
        private void picGrid_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the selected hexagons.
            foreach (PointF point in Hexagons)
            {
                e.Graphics.FillPolygon(Brushes.LightBlue,
                    HexToPoints(HexHeight, point.X, point.Y));
            }

            // Draw the grid.
            DrawHexGrid(e.Graphics, Pens.Black,
                0, picGrid.ClientSize.Width,
                0, picGrid.ClientSize.Height,
                HexHeight);

#if FIG34
            // Draw the selected rectangles for Figures 3 and 4.
            using (Pen pen = new Pen(Color.Red, 3))
            {
                pen.DashStyle = DashStyle.Dash;
                foreach (RectangleF rect in TestRects)
                {
                    e.Graphics.DrawRectangle(pen, Rectangle.Round(rect));
                }
            }
#endif
        }

        // Draw a hexagonal grid for the indicated area.
        // (You might be able to draw the hexagons without
        // drawing any duplicate edges, but this is a lot easier.)
        private void DrawHexGrid(Graphics gr, Pen pen,
            float xmin, float xmax, float ymin, float ymax,
            float height)
        {
            // Loop until a hexagon won't fit.
            for (int row = 0; ; row++)
            {
                // Get the points for the row's first hexagon.
                PointF[] points = HexToPoints(height, row, 0);

                // If it doesn't fit, we're done.
                if (points[4].Y > ymax) break;

                // Draw the row.
                for (int col = 0; ; col++)
                {
                    // Get the points for the row's next hexagon.
                    points = HexToPoints(height, row, col);

                    // If it doesn't fit horizontally,
                    // we're done with this row.
                    if (points[3].X > xmax) break;

                    // If it fits vertically, draw it.
                    if (points[4].Y <= ymax)
                    {
                        gr.DrawPolygon(pen, points);

#if FIG1
                        // Label the hexagon (for Figure 1).
                        using (StringFormat sf = new StringFormat())
                        {
                            sf.Alignment = StringAlignment.Center;
                            sf.LineAlignment = StringAlignment.Center;
                            float x = (points[0].X + points[3].X) / 2;
                            float y = (points[1].Y + points[4].Y) / 2;
                            string label = "(" + row.ToString() + ", " +
                                col.ToString() + ")";
                            gr.DrawString(label, this.Font,
                                Brushes.Black, x, y, sf);
                        }
#endif
                    }
                }
            }
        }

        private void picGrid_Resize(object sender, EventArgs e)
        {
            picGrid.Refresh();
        }

        // Display the row and column under the mouse.
        private void picGrid_MouseMove(object sender, MouseEventArgs e)
        {
            int row, col;
            PointToHex(e.X, e.Y, HexHeight, out row, out col);
            this.Text = "(" + row + ", " + col + ")";
        }

        // Add the clicked hexagon to the Hexagons list.
        private void picGrid_MouseClick(object sender, MouseEventArgs e)
        {
            int row, col;
            PointToHex(e.X, e.Y, HexHeight, out row, out col);
            
            int range = int.Parse(txtRange.Text);
            Hexagons = FindAtRange(row, col, range);

            string txt = "";
            foreach (PointF point in Hexagons)
            {
                txt += "(" + point.X.ToString("0") +
                    ", " + point.Y.ToString("0") + ") ";
            }
            txtCells.Text = txt;

#if FIG34
            // Used to draw Figures 3 and 4.
            PointF[] points = HexToPoints(HexHeight, row, col);
            TestRects.Add(new RectangleF(
                points[0].X, points[1].Y,
                0.75f * (points[3].X - points[0].X),
                points[4].Y - points[1].Y));
#endif

            picGrid.Refresh();
        }

        // Return the width of a hexagon.
        private float HexWidth(float height)
        {
            return (float)(4 * (height / 2 / Math.Sqrt(3)));
        }

        // Return the row and column of the hexagon at this point.
        private void PointToHex(float x, float y, float height,
            out int row, out int col)
        {
            // Find the test rectangle containing the point.
            float width = HexWidth(height);
            col = (int)(x / (width * 0.75f));

            if (col % 2 == 0)
                row = (int)(y / height);
            else
                row = (int)((y - height / 2) / height);

            // Find the test area.
            float testx = col * width * 0.75f;
            float testy = row * height;
            if (col % 2 == 1) testy += height / 2;

            // See if the point is above or
            // below the test hexagon on the left.
            bool is_above = false, is_below = false;
            float dx = x - testx;
            if (dx < width / 4)
            {
                float dy = y - (testy + height / 2);
                if (dx < 0.001)
                {
                    // The point is on the left edge of the test rectangle.
                    if (dy < 0) is_above = true;
                    if (dy > 0) is_below = true;
                }
                else if (dy < 0)
                {
                    // See if the point is above the test hexagon.
                    if (-dy / dx > Math.Sqrt(3)) is_above = true;
                }
                else
                {
                    // See if the point is below the test hexagon.
                    if (dy / dx > Math.Sqrt(3)) is_below = true;
                }
            }

            // Adjust the row and column if necessary.
            if (is_above)
            {
                if (col % 2 == 0) row--;
                col--;
            }
            else if (is_below)
            {
                if (col % 2 == 1) row++;
                col--;
            }
        }

        // Return the points that define the indicated hexagon.
        private PointF[] HexToPoints(float height, float row, float col)
        {
            // Start with the leftmost corner of the upper left hexagon.
            float width = HexWidth(height);
            float y = height / 2;
            float x = 0;

            // Move down the required number of rows.
            y += row * height;

            // If the column is odd, move down half a hex more.
            if (col % 2 == 1) y += height / 2;

            // Move over for the column number.
            x += col * (width * 0.75f);

            // Generate the points.
            return new PointF[]
                {
                    new PointF(x, y),
                    new PointF(x + width * 0.25f, y - height / 2),
                    new PointF(x + width * 0.75f, y - height / 2),
                    new PointF(x + width, y),
                    new PointF(x + width * 0.75f, y + height / 2),
                    new PointF(x + width * 0.25f, y + height / 2),
                };
        }

        // Return a list of hexes that are a given
        // distance from the target hex.
        private List<PointF> FindAtRange(int row, int col, int range)
        {
            List<PointF> neighbors = new List<PointF>();

            // Start in the south.
            row += range;

            // Move northeast.
            for (int i = 0; i < range; i++)
            {
                MoveNE(ref row, ref col);
                neighbors.Add(new PointF(row, col));
            }

            // Move north.
            for (int i = 0; i < range; i++)
            {
                MoveN(ref row, ref col);
                neighbors.Add(new PointF(row, col));
            }

            // Move northwest.
            for (int i = 0; i < range; i++)
            {
                MoveNW(ref row, ref col);
                neighbors.Add(new PointF(row, col));
            }

            // Move southwest.
            for (int i = 0; i < range; i++)
            {
                MoveSW(ref row, ref col);
                neighbors.Add(new PointF(row, col));
            }

            // Move south.
            for (int i = 0; i < range; i++)
            {
                MoveS(ref row, ref col);
                neighbors.Add(new PointF(row, col));
            }

            // Move southeast.
            for (int i = 0; i < range; i++)
            {
                MoveSE(ref row, ref col);
                neighbors.Add(new PointF(row, col));
            }

            return neighbors;
        }

        // Adjust the row and column to move
        // to the northeast neighbor.
        private void MoveNE(ref int row, ref int col)
        {
            if (col % 2 == 0) row--;
            col++;
        }

        // Adjust the row and column to move
        // to the southeast neighbor.
        private void MoveSE(ref int row, ref int col)
        {
            if (col % 2 == 1) row++;
            col++;
        }

        // Adjust the row and column to move
        // to the northwest neighbor.
        private void MoveNW(ref int row, ref int col)
        {
            if (col % 2 == 0) row--;
            col--;
        }

        // Adjust the row and column to move
        // to the southwest neighbor.
        private void MoveSW(ref int row, ref int col)
        {
            if (col % 2 == 1) row++;
            col--;
        }

        // Adjust the row and column to move
        // to the north neighbor.
        private void MoveN(ref int row, ref int col)
        {
            row--;
        }

        // Adjust the row and column to move
        // to the south neighbor.
        private void MoveS(ref int row, ref int col)
        {
            row++;
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtRange = new System.Windows.Forms.TextBox();
            this.txtCells = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // picGrid
            // 
            this.picGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGrid.BackColor = System.Drawing.Color.White;
            this.picGrid.Location = new System.Drawing.Point(12, 35);
            this.picGrid.Name = "picGrid";
            this.picGrid.Size = new System.Drawing.Size(376, 357);
            this.picGrid.TabIndex = 1;
            this.picGrid.TabStop = false;
            this.picGrid.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picGrid_MouseMove);
            this.picGrid.Resize += new System.EventHandler(this.picGrid_Resize);
            this.picGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picGrid_MouseClick);
            this.picGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.picGrid_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Range:";
            // 
            // txtRange
            // 
            this.txtRange.Location = new System.Drawing.Point(57, 9);
            this.txtRange.Name = "txtRange";
            this.txtRange.Size = new System.Drawing.Size(35, 20);
            this.txtRange.TabIndex = 3;
            this.txtRange.Text = "3";
            this.txtRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCells
            // 
            this.txtCells.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCells.Location = new System.Drawing.Point(130, 9);
            this.txtCells.Name = "txtCells";
            this.txtCells.ReadOnly = true;
            this.txtCells.Size = new System.Drawing.Size(258, 20);
            this.txtCells.TabIndex = 4;
            // 
            // howto_hex_neighbors_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 404);
            this.Controls.Add(this.txtCells);
            this.Controls.Add(this.txtRange);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picGrid);
            this.Name = "howto_hex_neighbors_Form1";
            this.Text = "howto_hex_neighbors";
            ((System.ComponentModel.ISupportInitialize)(this.picGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRange;
        private System.Windows.Forms.TextBox txtCells;
    }
}

