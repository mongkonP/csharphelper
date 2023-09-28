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
     public partial class howto_fill_rule_Form1:Form
  { 


        public howto_fill_rule_Form1()
        {
            InitializeComponent();
        }

        private List<Point> Points = new List<Point>();
        private bool Drawing = false;

        private void rad_Click(object sender, EventArgs e)
        {
            picCanvas.Refresh();
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(picCanvas.BackColor);

            // See if we are drawing a new polygon.
            if (Drawing)
            {
                // Draw the polygon so far.
                if (Points.Count > 1)
                    e.Graphics.DrawLines(Pens.Blue, Points.ToArray());
                DrawLineArrows(e.Graphics, Pens.Blue, Points, Points.Count - 1);
            }
            else
            {
                // Draw the finished polygon.
                if (Points.Count > 2)
                {
                    FillMode fill_mode;
                    if (radWinding.Checked)
                        fill_mode = FillMode.Winding;
                    else
                        fill_mode = FillMode.Alternate;
                    e.Graphics.FillPolygon(Brushes.LightBlue, Points.ToArray(), fill_mode);
                    e.Graphics.DrawPolygon(Pens.Blue, Points.ToArray());
                }

                DrawLineArrows(e.Graphics, Pens.Blue, Points, Points.Count);
            }

            foreach (Point point in Points)
            {
                DrawDot(e.Graphics, Brushes.White, Pens.Black, point);
            }
        }

        // Draw a sequence of line arrowheads.
        private void DrawLineArrows(Graphics gr, Pen pen,
            List<Point> points, int num_segments)
        {
            for (int i = 0; i < num_segments; i++)
            {
                int j = (i + 1) % points.Count;
                DrawArrowhead(gr, pen, points[i], points[j]);
            }
        }

        // Draw an arrowhead in the middle of the
        // line segment showing its direction.
        private void DrawArrowhead(Graphics gr, Pen pen, Point p1, Point p2)
        {
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;
            float dist = (float)Math.Sqrt(dx * dx + dy * dy);
            dx /= dist;
            dy /= dist;
            const float scale = 4;
            dx *= scale;
            dy *= scale;
            float p1x = -dy;
            float p1y = dx;
            float p2x = dy;
            float p2y = -dx;
            float cx = (p1.X + p2.X) / 2f;
            float cy = (p1.Y + p2.Y) / 2f;
            PointF[] points =
            {
                new PointF(cx - dx + p1x, cy - dy + p1y),
                new PointF(cx, cy),
                new PointF(cx - dx + p2x, cy - dy + p2y),
            };
            gr.DrawLines(pen, points);
        }

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            // See if this is a left or right click.
            if (e.Button == MouseButtons.Left)
            {
                // Left click.
                if (!Drawing)
                {
                    // Start a new polygon.
                    Points = new List<Point>();
                    Drawing = true;
                }

                // Add the point to the polygon.
                Points.Add(e.Location);
            }
            else
            {
                // Right click.
                Drawing = false;
            }

            // Redraw.
            picCanvas.Refresh();
        }

        // Draw a dot at this point.
        private void DrawDot(Graphics gr, Brush brush, Pen pen, PointF point)
        {
            const float radius = 3;
            RectangleF rectf = new RectangleF(
                point.X - radius,
                point.Y - radius,
                2 * radius, 2 * radius);
            gr.FillEllipse(brush, rectf);
            gr.DrawEllipse(pen, rectf);
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
            this.radAlternate = new System.Windows.Forms.RadioButton();
            this.radWinding = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(12, 35);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(260, 214);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseClick);
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // radAlternate
            // 
            this.radAlternate.AutoSize = true;
            this.radAlternate.Location = new System.Drawing.Point(12, 12);
            this.radAlternate.Name = "radAlternate";
            this.radAlternate.Size = new System.Drawing.Size(126, 17);
            this.radAlternate.TabIndex = 1;
            this.radAlternate.TabStop = true;
            this.radAlternate.Text = "Alternate (Odd/Even)";
            this.radAlternate.UseVisualStyleBackColor = true;
            this.radAlternate.Click += new System.EventHandler(this.rad_Click);
            // 
            // radWinding
            // 
            this.radWinding.AutoSize = true;
            this.radWinding.Location = new System.Drawing.Point(154, 12);
            this.radWinding.Name = "radWinding";
            this.radWinding.Size = new System.Drawing.Size(118, 17);
            this.radWinding.TabIndex = 2;
            this.radWinding.TabStop = true;
            this.radWinding.Text = "Winding (Non-Zero)";
            this.radWinding.UseVisualStyleBackColor = true;
            this.radWinding.Click += new System.EventHandler(this.rad_Click);
            // 
            // howto_fill_rule_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.radWinding);
            this.Controls.Add(this.radAlternate);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_fill_rule_Form1";
            this.Text = "howto_fill_rule";
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.RadioButton radAlternate;
        private System.Windows.Forms.RadioButton radWinding;
    }
}

