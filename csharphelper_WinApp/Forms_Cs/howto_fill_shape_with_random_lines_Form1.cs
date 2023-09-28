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
     public partial class howto_fill_shape_with_random_lines_Form1:Form
  { 


        public howto_fill_shape_with_random_lines_Form1()
        {
            InitializeComponent();
        }

        // The points selected by the user.
        private List<Point> ShapePoints = new List<Point>();
        private GraphicsPath ShapePath = null;
        private GraphicsPath LinesPath = null;
        private bool IsDrawing = false;

        // Start drawing.
        private void howto_fill_shape_with_random_lines_Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ShapePoints = new List<Point>();
            ShapePoints.Add(e.Location);
            IsDrawing = true;
            Refresh();
        }

        // Continue drawing.
        private void howto_fill_shape_with_random_lines_Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!IsDrawing) return;
            ShapePoints.Add(e.Location);
            Refresh();

            this.DoubleBuffered = true;
        }

        // Finish drawing.
        private void howto_fill_shape_with_random_lines_Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!IsDrawing) return;
            IsDrawing = false;

            // Generate the random lines to fill the shape.
            GenerateLines();

            Refresh();
        }

        // Generate the random lines to fill the shape.
        private void GenerateLines()
        {
            if (ShapePoints.Count < 3)
            {
                ShapePath = null;
                LinesPath = null;
                return;
            }

            // Make the shape's path.
            ShapePath = new GraphicsPath();
            ShapePath.AddPolygon(ShapePoints.ToArray());

            // Get the shape's bounds.
            RectangleF bounds = ShapePath.GetBounds();
            int xmin = (int)(bounds.Left);
            int xmax = (int)(bounds.Right) + 1;
            int ymin = (int)(bounds.Top);
            int ymax = (int)(bounds.Bottom) + 1;

            // Generate random lines.
            LinesPath = new GraphicsPath();
            int num_lines = (int)((bounds.Width + bounds.Height) / 8);
            Random rand = new Random();
            int x1, y1, x2, y2;
            for (int i = 1; i <= num_lines / 2; i++)
            {
                x1 = rand.Next(xmin, xmax);
                y1 = ymin;
                x2 = rand.Next(xmin, xmax);
                y2 = ymax;
                LinesPath.AddLine(x1, y1, x2, y2);

                x1 = xmin;
                y1 = rand.Next(ymin, ymax);
                x2 = xmax;
                y2 = rand.Next(ymin, ymax);
                LinesPath.AddLine(x1, y1, x2, y2);
            }
        }

        // Draw the shape.
        private void howto_fill_shape_with_random_lines_Form1_Paint(object sender, PaintEventArgs e)
        {
            // Draw the shape.
            if (IsDrawing)
            {
                // Draw the lines so far.
                if (ShapePoints.Count > 1)
                {
                    e.Graphics.DrawLines(Pens.Green, ShapePoints.ToArray());
                }
            }
            else
            {
                // Fill and outline the finished shape.
                if (ShapePath != null)
                {
                    if (chkAntiAlias.Checked)
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    e.Graphics.FillPath(Brushes.LightGreen, ShapePath);
                    e.Graphics.DrawPath(Pens.Green, ShapePath);

                    // Fill with the lines.
                    e.Graphics.SetClip(ShapePath);
                    e.Graphics.DrawPath(Pens.Green, LinesPath);
                }
            }
        }

        // Redraw.
        private void chkAntiAlias_CheckedChanged(object sender, EventArgs e)
        {
            Refresh();
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
            this.chkAntiAlias = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkAntiAlias
            // 
            this.chkAntiAlias.AutoSize = true;
            this.chkAntiAlias.Location = new System.Drawing.Point(0, 0);
            this.chkAntiAlias.Name = "chkAntiAlias";
            this.chkAntiAlias.Size = new System.Drawing.Size(69, 17);
            this.chkAntiAlias.TabIndex = 0;
            this.chkAntiAlias.Text = "Anti Alias";
            this.chkAntiAlias.UseVisualStyleBackColor = true;
            this.chkAntiAlias.CheckedChanged += new System.EventHandler(this.chkAntiAlias_CheckedChanged);
            // 
            // howto_fill_shape_with_random_lines_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.chkAntiAlias);
            this.Name = "howto_fill_shape_with_random_lines_Form1";
            this.Text = "howto_fill_shape_with_random_lines";
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.howto_fill_shape_with_random_lines_Form1_MouseUp);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_fill_shape_with_random_lines_Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.howto_fill_shape_with_random_lines_Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.howto_fill_shape_with_random_lines_Form1_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAntiAlias;
    }
}

