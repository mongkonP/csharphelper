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
     public partial class howto_draw_polygons_Form1:Form
  { 


        public howto_draw_polygons_Form1()
        {
            InitializeComponent();
        }

        // Each polygon is represented by a List<Point>.
        private List<List<Point>> Polygons = new List<List<Point>>();

        // Points for the new polygon.
        private List<Point> NewPolygon = null;

        // The current mouse position while drawing a new polygon.
        private Point NewPoint;

        // Start or continue drawing a new polygon.
        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            // See if we are already drawing a polygon.
            if (NewPolygon != null)
            {
                // We are already drawing a polygon.
                // If it's the right mouse button, finish this polygon.
                if (e.Button == MouseButtons.Right)
                {
                    // Finish this polygon.
                    if (NewPolygon.Count > 2) Polygons.Add(NewPolygon);
                    NewPolygon = null;
                }
                else
                {
                    // Add a point to this polygon.
                    if (NewPolygon[NewPolygon.Count - 1] != e.Location)
                    {
                        NewPolygon.Add(e.Location);
                    }
                }
            }
            else
            {
                // Start a new polygon.
                NewPolygon = new List<Point>();
                NewPoint = e.Location;
                NewPolygon.Add(e.Location);
            }

            // Redraw.
            picCanvas.Invalidate();
        }

        // Move the next point in the new polygon.
        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (NewPolygon == null) return;
            NewPoint = e.Location;
            picCanvas.Invalidate();
        }

        // Redraw old polygons in blue. Draw the new polygon in green.
        // Draw the final segment dashed.
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(picCanvas.BackColor);

            // Draw the old polygons.
            foreach (List<Point> polygon in Polygons)
            {
                e.Graphics.FillPolygon(Brushes.White, polygon.ToArray());
                e.Graphics.DrawPolygon(Pens.Blue, polygon.ToArray());
            }

            // Draw the new polygon.
            if (NewPolygon != null)
            {
                // Draw the new polygon.
                if (NewPolygon.Count > 1)
                {
                    e.Graphics.DrawLines(Pens.Green, NewPolygon.ToArray());
                }

                // Draw the newest edge.
                if (NewPolygon.Count > 0)
                {
                    using (Pen dashed_pen = new Pen(Color.Green))
                    {
                        dashed_pen.DashPattern = new float[] { 3, 3 };
                        e.Graphics.DrawLine(dashed_pen, 
                            NewPolygon[NewPolygon.Count - 1],
                            NewPoint);
                    }
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
            this.picCanvas = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(12, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(260, 240);
            this.picCanvas.TabIndex = 1;
            this.picCanvas.TabStop = false;
            this.picCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseMove);
            this.picCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseDown);
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // howto_draw_polygons_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_draw_polygons_Form1";
            this.Text = "howto_draw_polygons";
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
    }
}

