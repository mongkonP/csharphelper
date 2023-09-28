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
     public partial class howto_trominoes_Form1:Form
  { 


        public howto_trominoes_Form1()
        {
            InitializeComponent();
        }

        // The quadrant that holds the square to be ignored.
        private enum Quadrants { NW, NE, SE, SW };

        private int SquaresPerSide = 0;
        private float SquareWidth, BoardWidth, Xmin, Ymin;

        // The location of the missing square.
        private int MissingX, MissingY;

        private List<PointF[]> Chairs;

        // Make and solve a new board.
        private void howto_trominoes_Form1_Load(object sender, EventArgs e)
        {
            MakeBoard();
        }
        private void btnTile_Click(object sender, EventArgs e)
        {
            MakeBoard();
        }
        private void MakeBoard()
        {
            int n = int.Parse(txtN.Text);
            SquaresPerSide = (int)Math.Pow(2, n);

            // Set board parameters.
            SquareWidth = (picBoard.ClientSize.Width - 10f) / SquaresPerSide;
            float hgt = (picBoard.ClientSize.Height - 10f) / SquaresPerSide;
            if (SquareWidth > hgt) SquareWidth = hgt;
            BoardWidth = SquareWidth * SquaresPerSide;
            Xmin = (picBoard.ClientSize.Width - BoardWidth) / 2;
            Ymin = (picBoard.ClientSize.Height - BoardWidth) / 2;

            // Pick a random empty square.
            Random rand = new Random();
            MissingX = rand.Next(SquaresPerSide);
            MissingY = rand.Next(SquaresPerSide);

            // Solve the board.
            Chairs = new List<PointF[]>();
            SolveBoard(
                0, SquaresPerSide - 1,
                0, SquaresPerSide - 1,
                MissingX, MissingY);

            // Redraw.
            picBoard.Refresh();
        }

        // Solve the board.
        private void SolveBoard(int imin, int imax, int jmin, int jmax,
            int imissing, int jmissing)
        {
            // See if this is a 2x2 square.
            if (imax - imin == 1)
            {
                // It is a 2x2 square. Make its chair.
                Chairs.Add(MakeChair(imin, imax, jmin, jmax,
                    imissing, jmissing));
                return;
            }

            // Not a 2x2 square. Divide into 4 pieces and recurse.
            int imid = (imin + imax) / 2;
            int jmid = (jmin + jmax) / 2;
            switch (QuadrantToIgnore(imin, imax, jmin, jmax,
                imissing, jmissing))
            {
                case Quadrants.NW:
                    // Make the chair in the middle.
                    Chairs.Add(MakeChair(imid, imid + 1, jmid, jmid + 1, imid, jmid));

                    // Recurse.
                    SolveBoard(imin, imid, jmin, jmid, imissing, jmissing);         // NW
                    SolveBoard(imid + 1, imax, jmin, jmid, imid + 1, jmid);         // NE
                    SolveBoard(imid + 1, imax, jmid + 1, jmax, imid + 1, jmid + 1); // SE
                    SolveBoard(imin, imid, jmid + 1, jmax, imid, jmid + 1);         // SW
                    break;
                case Quadrants.NE:
                    // Make the chair in the middle.
                    Chairs.Add(MakeChair(imid, imid + 1, jmid, jmid + 1, imid + 1, jmid));

                    // Recurse.
                    SolveBoard(imin, imid, jmin, jmid, imid, jmid);                 // NW
                    SolveBoard(imid + 1, imax, jmin, jmid, imissing, jmissing);     // NE
                    SolveBoard(imid + 1, imax, jmid + 1, jmax, imid + 1, jmid + 1); // SE
                    SolveBoard(imin, imid, jmid + 1, jmax, imid, jmid + 1);         // SW
                    break;
                case Quadrants.SE:
                    // Make the chair in the middle.
                    Chairs.Add(MakeChair(imid, imid + 1, jmid, jmid + 1, imid + 1, jmid + 1));

                    // Recurse.
                    SolveBoard(imin, imid, jmin, jmid, imid, jmid);                 // NW
                    SolveBoard(imid + 1, imax, jmin, jmid, imid + 1, jmid);         // NE
                    SolveBoard(imid + 1, imax, jmid + 1, jmax, imissing, jmissing); // SE
                    SolveBoard(imin, imid, jmid + 1, jmax, imid, jmid + 1);         // SW
                    break;
                case Quadrants.SW:
                    // Make the chair in the middle.
                    Chairs.Add(MakeChair(imid, imid + 1, jmid, jmid + 1, imid, jmid + 1));

                    // Recurse.
                    SolveBoard(imin, imid, jmin, jmid, imid, jmid);                 // NW
                    SolveBoard(imid + 1, imax, jmin, jmid, imid + 1, jmid);         // NE
                    SolveBoard(imid + 1, imax, jmid + 1, jmax, imid + 1, jmid + 1); // SE
                    SolveBoard(imin, imid, jmid + 1, jmax, imissing, jmissing);     // SW
                    break;
            }
        }

        // Make a chair polygon.
        private PointF[] MakeChair(int imin, int imax,
            int jmin, int jmax, int imissing, int jmissing)
        {
            // Make the initial points.
            float xmin = Xmin + imin * SquareWidth;
            float ymin = Ymin + jmin * SquareWidth;
            PointF[] points =
            {
                new PointF(xmin, ymin),
                new PointF(xmin + SquareWidth, ymin),
                new PointF(xmin + SquareWidth * 2, ymin),
                new PointF(xmin + SquareWidth * 2, ymin + SquareWidth),
                new PointF(xmin + SquareWidth * 2, ymin + SquareWidth * 2),
                new PointF(xmin + SquareWidth, ymin + SquareWidth * 2),
                new PointF(xmin, ymin + SquareWidth * 2),
                new PointF(xmin, ymin + SquareWidth),
            };

            // Push in the appropriate corner.
            PointF middle = new PointF(
                xmin + SquareWidth,
                ymin + SquareWidth);
            switch (QuadrantToIgnore(imin, imax, jmin, jmax,
                imissing, jmissing))
            {
                case Quadrants.NW:
                    points[0] = middle;
                    break;
                case Quadrants.SW:
                    points[6] = middle;
                    break;
                case Quadrants.NE:
                    points[2] = middle;
                    break;
                case Quadrants.SE:
                    points[4] = middle;
                    break;
            }

            return points;
        }

        // Draw the board.
        private void picBoard_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(picBoard.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the chairs.
            foreach (PointF[] points in Chairs)
            {
                e.Graphics.DrawPolygon(Pens.Red, points);
            }

            // Draw the missing square.
            float x = Xmin + MissingX * SquareWidth;
            float y = Ymin + MissingY * SquareWidth;
            e.Graphics.FillRectangle(Brushes.Black,
                x, y, SquareWidth, SquareWidth);
        }

        // Return the quadrant holding the square to be ignored for this square.
        private Quadrants QuadrantToIgnore(int imin, int imax, int jmin, int jmax,
            int imissing, int jmissing)
        {
            int imid = (imin + imax) / 2;
            int jmid = (jmin + jmax) / 2;
            if (imissing <= imid)      // West.
            {
                if (jmissing <= jmid) return Quadrants.NW;
                return Quadrants.SW;
            }
            else                        // East.
            {
                if (jmissing <= jmid) return Quadrants.NE;
                return Quadrants.SE;
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtN = new System.Windows.Forms.TextBox();
            this.btnTile = new System.Windows.Forms.Button();
            this.picBoard = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "N:";
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(36, 14);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(47, 20);
            this.txtN.TabIndex = 1;
            this.txtN.Text = "3";
            this.txtN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnTile
            // 
            this.btnTile.Location = new System.Drawing.Point(104, 12);
            this.btnTile.Name = "btnTile";
            this.btnTile.Size = new System.Drawing.Size(75, 23);
            this.btnTile.TabIndex = 2;
            this.btnTile.Text = "Tile";
            this.btnTile.UseVisualStyleBackColor = true;
            this.btnTile.Click += new System.EventHandler(this.btnTile_Click);
            // 
            // picBoard
            // 
            this.picBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoard.BackColor = System.Drawing.Color.White;
            this.picBoard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBoard.Location = new System.Drawing.Point(12, 41);
            this.picBoard.Name = "picBoard";
            this.picBoard.Size = new System.Drawing.Size(260, 208);
            this.picBoard.TabIndex = 3;
            this.picBoard.TabStop = false;
            this.picBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.picBoard_Paint);
            // 
            // howto_trominoes_Form1
            // 
            this.AcceptButton = this.btnTile;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.picBoard);
            this.Controls.Add(this.btnTile);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.label1);
            this.Name = "howto_trominoes_Form1";
            this.Text = "howto_trominoes";
            this.Load += new System.EventHandler(this.howto_trominoes_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.Button btnTile;
        private System.Windows.Forms.PictureBox picBoard;
    }
}

