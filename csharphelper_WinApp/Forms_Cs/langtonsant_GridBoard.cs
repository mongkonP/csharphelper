#region Copyright
/*
 * Copyright (c) 2011 Gregory L. Ables
 */
#endregion

using System;
using System.Drawing;
using System.Windows.Forms;

using LangtonsAnt;
namespace LangtonsAnt
{
    partial class langtonsant_GridBoard : Panel
    {
        private int cellDelta = 10;

        private int numCells;
        private int padWidth = 10;

        private int sideLength;

        private Rectangle currentCell;

        private int gridDelta()
        {
            return numCells * cellDelta;
        }

        private double dLineLength()
        {
            return ((double)(gridDelta() - cellDelta - padWidth) / cellDelta);
        }

        private int iLineLength()
        {
            return (int)dLineLength();
        }

        private Image[] antImages;
        public Image[] AntImages
        {
            get { return antImages; }
            set { antImages = value; }
        }

        GridVirtual gridVirtual;
        public GridVirtual GridVirtual
        {
            get { return gridVirtual; }
            set
            {
                if (gridVirtual != value)
                {
                    if (gridVirtual != null)
                    {
                        this.gridVirtual.Ant.PositionChanged -= new EventHandler<PositionArgs>(Ant_PositionChanged);
                    }
                    gridVirtual = value;
                    this.gridVirtual.Ant.PositionChanged += new EventHandler<PositionArgs>(Ant_PositionChanged);
                    this.numCells = gridVirtual.GridScale;
                    this.Refresh();
                }
            }
        }

        public langtonsant_GridBoard(GridVirtual gridVirtual)
        {
            InitializeComponent();
            this.GridVirtual = gridVirtual;

            CalculateDrawingSize();
        }

        private void Ant_PositionChanged(object sender, PositionArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(
                    new MethodInvoker(
                        delegate() { Ant_PositionChanged(sender, e); }));
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(this.gridVirtual.Ant.Position);
                this.Refresh();
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.LightGray, this.ClientRectangle);
            e.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);

            for (int i = 0; i < this.numCells; i++)
            {
                for (int j = 0; j < this.numCells; j++)
                {
                    // White cell.
                    if (gridVirtual.VirtualGrid[i, j] == 0)
                    {
                        currentCell =
                            new Rectangle((padWidth + (i * cellDelta)),
                                          (padWidth + (j * cellDelta)),
                                           cellDelta,
                                           cellDelta);

                        e.Graphics.FillRectangle(Brushes.White, currentCell);
                    }
                    // Black cell.
                    else if (gridVirtual.VirtualGrid[i, j] == 1)
                    {
                        currentCell =
                            new Rectangle((padWidth + (i * cellDelta)),
                                          (padWidth + (j * cellDelta)),
                                           cellDelta,
                                           cellDelta);

                        e.Graphics.FillRectangle(Brushes.Black, currentCell);
                    }
                }

                /*
                 * Draws:
                 *    (gridDelta() / cellDelta)
                 * vertical and horizontal lines.
                 *
                for (int x = padWidth; x <= (gridDelta() + cellDelta); x = x + cellDelta)
                {
                    gfx.DrawLine(redPen, x, padWidth, x, (gridDelta() + cellDelta));
                }
                for (int y = padWidth; y <= (gridDelta() + cellDelta); y = y + cellDelta)
                {
                    gfx.DrawLine(redPen, padWidth, y, (gridDelta() + cellDelta), y);
                }
                 */
            }

            Point antLocation =
                new Point((padWidth + (this.gridVirtual.Ant.Position.X * cellDelta)),
                          (padWidth + (this.gridVirtual.Ant.Position.Y * cellDelta)));

            e.Graphics.DrawImageUnscaled(Utilities.ImageResize(
                                            AntImages[(((int)this.gridVirtual.Ant.Direction / 10) - 1)],
                                            cellDelta,
                                            cellDelta),
                                         antLocation);
        }

        public void Scale(object sender, MouseEventArgs e)
        {
            if (e.Delta != 0)
            {
                if ((e.Delta / Math.Abs(e.Delta) < 0))
                {
                    if (cellDelta > 4)
                    {
                        cellDelta--;
                        while (dLineLength() - iLineLength() != 0)
                        {
                            cellDelta--;
                        }
                        CalculateDrawingSize();
                        this.Refresh();
                    }
                }
                else
                {
                    if (cellDelta < 10)
                    {
                        cellDelta++;
                        while (dLineLength() - iLineLength() != 0)
                        {
                            cellDelta++;
                        }
                        CalculateDrawingSize();
                        this.Refresh();
                    }
                }

            }
        }

        private void CalculateDrawingSize()
        {
            sideLength = ((this.padWidth * 2) + (cellDelta * numCells));
            this.AutoScrollMinSize = new Size(sideLength, sideLength);
        }

        private void langtonsant_GridBoard_SizeChanged(object sender,  EventArgs e)
        {
            this.Refresh();
        }
    

#region Copyright
/*
 * Copyright (c) 2011 Gregory L. Ables
 */
#endregion

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
        private void InitializeComponent()
        {
            this.SuspendLayout();
            //
            // langtonsant_GridBoard
            //
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.DoubleBuffered = true;
            this.SetStyle(System.Windows.Forms.ControlStyles.ResizeRedraw, true);
            this.SizeChanged += new System.EventHandler(langtonsant_GridBoard_SizeChanged);
            this.Text = "langtonsant_GridBoard";
            this.ResumeLayout(false);
        }
        #endregion
    }
}