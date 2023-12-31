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
     public partial class howto_line_ellipse_intersection_Form1:Form
  { 


        public howto_line_ellipse_intersection_Form1()
        {
            InitializeComponent();
        }

        private Point LinePt1, LinePt2;

        // Start with a default ellipse and line.
        private void howto_line_ellipse_intersection_Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;

            LinePt1 = new Point(20, 30);
            LinePt2 = new Point(170, 100);
            EllipsePt1 = new Point(20, 30);
            EllipsePt2 = new Point(ClientSize.Width - 40, ClientSize.Height - 60);
        }

        // Draw the current ellipse and line.
        private void howto_line_ellipse_intersection_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the ellipse.
            using (Pen ellipse_pen = new Pen(Color.Blue))
            {
                // If we're selecting it now,
                // draw it with a dashed line.
                if (SelectingEllipse)
                    ellipse_pen.DashPattern = new float[] { 5, 5 };
                Rectangle ellipse_rect = new Rectangle(
                    EllipsePt1.X, EllipsePt1.Y,
                    EllipsePt2.X - EllipsePt1.X,
                    EllipsePt2.Y - EllipsePt1.Y);
                e.Graphics.DrawEllipse(ellipse_pen, ellipse_rect);
            }

            // Draw the line segment.
            using (Pen line_pen = new Pen(Color.Green))
            {
                // If we're selecting it now,
                // draw it with a dashed line.
                if (SelectingLine)
                    line_pen.DashPattern = new float[] { 5, 5 };
                e.Graphics.DrawLine(line_pen, LinePt1, LinePt2);
            }

            // If we are not selecting anything,
            // draw the points of intersection.
            if (!SelectingEllipse && !SelectingLine)
            {
                Rectangle ellipse_rect = new Rectangle(
                    EllipsePt1.X, EllipsePt1.Y,
                    EllipsePt2.X - EllipsePt1.X,
                    EllipsePt2.Y - EllipsePt1.Y);
                PointF[] points = FindEllipseSegmentIntersections(
                    ellipse_rect, LinePt1, LinePt2,
                    chkSegmentOnly.Checked);
                foreach (PointF pt in points)
                {
                    e.Graphics.DrawEllipse(Pens.Red, pt.X - 3, pt.Y - 3, 6, 6);
                }
            }
        }

        // Let the user select a line.
        private bool SelectingLine = false;
        private void btnSelectLine_Click(object sender, EventArgs e)
        {
            btnSelectLine.Enabled = false;
            btnSelectEllipse.Enabled = false;
            this.MouseDown += SelectLine_MouseDown;
            this.Cursor = Cursors.Cross;
        }
        private void SelectLine_MouseDown(object sender, MouseEventArgs e)
        {
            SelectingLine = true;
            this.MouseDown -= SelectLine_MouseDown;
            this.MouseMove += SelectLine_MouseMove;
            this.MouseUp += SelectLine_MouseUp;

            LinePt1 = e.Location;
            LinePt2 = e.Location;
        }
        private void SelectLine_MouseMove(object sender, MouseEventArgs e)
        {
            LinePt2 = e.Location;
            Refresh();
        }
        private void SelectLine_MouseUp(object sender, MouseEventArgs e)
        {
            SelectingLine = false;
            this.MouseMove -= SelectLine_MouseMove;
            this.MouseUp -= SelectLine_MouseUp;
            this.Cursor = Cursors.Default;
            btnSelectLine.Enabled = true;
            btnSelectEllipse.Enabled = true;
            Refresh();
        }

        // Let the user select an ellipse.
        private bool SelectingEllipse = false;
        private Point EllipsePt1, EllipsePt2;
        private void btnSelectEllipse_Click(object sender, EventArgs e)
        {
            btnSelectLine.Enabled = false;
            btnSelectEllipse.Enabled = false;
            this.MouseDown += SelectEllipse_MouseDown;
            this.Cursor = Cursors.Cross;
        }
        private void SelectEllipse_MouseDown(object sender, MouseEventArgs e)
        {
            SelectingEllipse = true;
            this.MouseDown -= SelectEllipse_MouseDown;
            this.MouseMove += SelectEllipse_MouseMove;
            this.MouseUp += SelectEllipse_MouseUp;

            EllipsePt1 = e.Location;
            EllipsePt2 = e.Location;
        }
        private void SelectEllipse_MouseMove(object sender, MouseEventArgs e)
        {
            EllipsePt2 = e.Location;
            Refresh();
        }
        private void SelectEllipse_MouseUp(object sender, MouseEventArgs e)
        {
            SelectingEllipse = false;
            this.MouseMove -= SelectEllipse_MouseMove;
            this.MouseUp -= SelectEllipse_MouseUp;
            this.Cursor = Cursors.Default;
            btnSelectLine.Enabled = true;
            btnSelectEllipse.Enabled = true;
            Refresh();
        }

        // Find the points of intersection between
        // an ellipse and a line segment.
        private PointF[] FindEllipseSegmentIntersections(RectangleF rect, PointF pt1, PointF pt2, bool segment_only)
        {
            // If the ellipse or line segment are empty, return no intersections.
            if ((rect.Width == 0) || (rect.Height == 0) ||
                ((pt1.X == pt2.X) && (pt1.Y == pt2.Y)))
                return new PointF[] { };

            // Make sure the rectangle has non-negative width and height.
            if (rect.Width < 0)
            {
                rect.X = rect.Right;
                rect.Width = -rect.Width;
            }
            if (rect.Height < 0)
            {
                rect.Y = rect.Bottom;
                rect.Height = -rect.Height;
            }

            // Translate so the ellipse is centered at the origin.
            float cx = rect.Left + rect.Width / 2f;
            float cy = rect.Top + rect.Height / 2f;
            rect.X -= cx;
            rect.Y -= cy;
            pt1.X -= cx;
            pt1.Y -= cy;
            pt2.X -= cx;
            pt2.Y -= cy;

            // Get the semimajor and semiminor axes.
            float a = rect.Width / 2;
            float b = rect.Height / 2;

            // Calculate the quadratic parameters.
            float A = (pt2.X - pt1.X) * (pt2.X - pt1.X) / a / a +
                      (pt2.Y - pt1.Y) * (pt2.Y - pt1.Y) / b / b;
            float B = 2 * pt1.X * (pt2.X - pt1.X) / a / a +
                      2 * pt1.Y * (pt2.Y - pt1.Y) / b / b;
            float C = pt1.X * pt1.X / a / a + pt1.Y * pt1.Y / b / b - 1;

            // Make a list of t values.
            List<float> t_values = new List<float>();

            // Calculate the discriminant.
            float discriminant = B * B - 4 * A * C;
            if (discriminant == 0)
            {
                // One real solution.
                t_values.Add(-B / 2 / A);
            }
            else if (discriminant > 0)
            {
                // Two real solutions.
                t_values.Add((float)((-B + Math.Sqrt(discriminant)) / 2 / A));
                t_values.Add((float)((-B - Math.Sqrt(discriminant)) / 2 / A));
            }

            // Convert the t values into points.
            List<PointF> points = new List<PointF>();
            foreach (float t in t_values)
            {
                // If the points are on the segment (or we
                // don't care if they are), add them to the list.
                if (!segment_only || ((t >= 0f) && (t <= 1f)))
                {
                    float x = pt1.X + (pt2.X - pt1.X) * t + cx;
                    float y = pt1.Y + (pt2.Y - pt1.Y) * t + cy;
                    points.Add(new PointF(x, y));
                }
            }

            // Return the points.
            return points.ToArray();
        }

        // Redraw.
        private void chkSegmentOnly_CheckedChanged(object sender, EventArgs e)
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
            this.chkSegmentOnly = new System.Windows.Forms.CheckBox();
            this.btnSelectEllipse = new System.Windows.Forms.Button();
            this.btnSelectLine = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkSegmentOnly
            // 
            this.chkSegmentOnly.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkSegmentOnly.AutoSize = true;
            this.chkSegmentOnly.Location = new System.Drawing.Point(217, 7);
            this.chkSegmentOnly.Name = "chkSegmentOnly";
            this.chkSegmentOnly.Size = new System.Drawing.Size(92, 17);
            this.chkSegmentOnly.TabIndex = 5;
            this.chkSegmentOnly.Text = "Segment Only";
            this.chkSegmentOnly.UseVisualStyleBackColor = true;
            this.chkSegmentOnly.CheckedChanged += new System.EventHandler(this.chkSegmentOnly_CheckedChanged);
            // 
            // btnSelectEllipse
            // 
            this.btnSelectEllipse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSelectEllipse.Location = new System.Drawing.Point(125, 3);
            this.btnSelectEllipse.Name = "btnSelectEllipse";
            this.btnSelectEllipse.Size = new System.Drawing.Size(86, 23);
            this.btnSelectEllipse.TabIndex = 4;
            this.btnSelectEllipse.Text = "Select Ellipse";
            this.btnSelectEllipse.UseVisualStyleBackColor = true;
            this.btnSelectEllipse.Click += new System.EventHandler(this.btnSelectEllipse_Click);
            // 
            // btnSelectLine
            // 
            this.btnSelectLine.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSelectLine.Location = new System.Drawing.Point(33, 3);
            this.btnSelectLine.Name = "btnSelectLine";
            this.btnSelectLine.Size = new System.Drawing.Size(86, 23);
            this.btnSelectLine.TabIndex = 3;
            this.btnSelectLine.Text = "Select Line";
            this.btnSelectLine.UseVisualStyleBackColor = true;
            this.btnSelectLine.Click += new System.EventHandler(this.btnSelectLine_Click);
            // 
            // howto_line_ellipse_intersection_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 221);
            this.Controls.Add(this.chkSegmentOnly);
            this.Controls.Add(this.btnSelectEllipse);
            this.Controls.Add(this.btnSelectLine);
            this.Name = "howto_line_ellipse_intersection_Form1";
            this.Text = "howto_line_ellipse_intersection";
            this.Load += new System.EventHandler(this.howto_line_ellipse_intersection_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_line_ellipse_intersection_Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSegmentOnly;
        private System.Windows.Forms.Button btnSelectEllipse;
        private System.Windows.Forms.Button btnSelectLine;
    }
}

