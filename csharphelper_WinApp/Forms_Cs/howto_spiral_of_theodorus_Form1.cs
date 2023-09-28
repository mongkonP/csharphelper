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
     public partial class howto_spiral_of_theodorus_Form1:Form
  { 


        public howto_spiral_of_theodorus_Form1()
        {
            InitializeComponent();
        }

        // Return an array of rainbow colors.
        private Color[] RainbowColors(byte alpha)
        {
            return new Color[]
            {
                Color.FromArgb(alpha, 255, 0, 0),
                Color.FromArgb(alpha, 255, 255, 0),
                Color.FromArgb(alpha, 255, 128, 0),
                Color.FromArgb(alpha, 0, 255, 0),
                Color.FromArgb(alpha, 0, 255, 255),
                Color.FromArgb(alpha, 0, 0, 255),
                Color.FromArgb(alpha, 255, 0, 255),
            };
        }

        // Convert colors to brushes.
        private Brush[] ColorsToBrushes(Color[] colors)
        {
            int num_colors = colors.Length;
            Brush[] brushes = new Brush[num_colors];
            for (int i = 0; i < num_colors; i++)
                brushes[i] = new SolidBrush(colors[i]);
            return brushes;
        }

        // Draw.
        private void btnDraw_Click(object sender, EventArgs e)
        {
            // Get the spiral of Theodorus's points.
            int num_triangles = int.Parse(txtNumTriangles.Text);
            List<PointF> edge_points = FindTheodorusPoints(num_triangles);

            // Draw the spiral of Theodorus.
            picSpiral.Image = DrawTheodorusSpiral(
                edge_points, picSpiral.ClientSize,
                chkOutline.Checked, chkFill.Checked);
        }

        // Find points on the spiral of Theodorus.
        private List<PointF> FindTheodorusPoints(int num_triangles)
        {
            // Find the edge points.
            List<PointF> edge_points = new List<PointF>();

            // Add the first point.
            float theta = 0;
            float radius = 1;
            for (int i = 1; i <= num_triangles + 1; i++)
            {
                radius = (float)Math.Sqrt(i);
                edge_points.Add(new PointF(
                    radius * (float)Math.Cos(theta),
                    radius * (float)Math.Sin(theta)));
                theta -= (float)Math.Atan2(1, radius);
            }

            return edge_points;
        }

        // Draw the spiral of Theodorus.
        private Bitmap DrawTheodorusSpiral(List<PointF> edge_points,
            Size size, bool outline_triangles, bool fill_triangles)
        {
            // Make the bitmap and associated Graphics object.
            int wid = size.Width;
            int hgt = size.Height;
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.Clear(Color.White);

                // Make brushes.
                Color[] colors = RainbowColors(255);
                Brush[] brushes = ColorsToBrushes(colors);

                // Scale and center.
                float xmin, xmax, ymin, ymax;
                GetBounds(edge_points, out xmin, out xmax, out ymin, out ymax);
                RectangleF drawing_rect = new RectangleF(
                    xmin, ymin, xmax - xmin, ymax - ymin);
                RectangleF target_rect = new RectangleF(
                    5, 5, wid - 10, hgt - 10);
                MapDrawing(gr, drawing_rect, target_rect, false);

                // Draw.
                using (Pen pen = new Pen(Color.Black, 0))
                {
                    int num_brushes = brushes.Length;
                    for (int i = edge_points.Count - 1; i > 0; i--)
                    {
                        PointF[] points =
                        {
                            new PointF(0, 0),
                            new PointF(edge_points[i].X, edge_points[i].Y),
                            new PointF(edge_points[i - 1].X, edge_points[i - 1].Y),
                        };
                        if (fill_triangles)
                            gr.FillPolygon(brushes[i % num_brushes], points);
                        if (outline_triangles)
                            gr.DrawPolygon(pen, points);
                    }
                }
            }

            return bm;
        }

        // Get the points' bounds.
        private void GetBounds(List<PointF> points,
            out float xmin, out float xmax,
            out float ymin, out float ymax)
        {
            // Find the bounds.
            xmin = points[0].X;
            xmax = xmin;
            ymin = points[0].Y;
            ymax = ymin;
            foreach (PointF point in points)
            {
                if (xmin > point.X) xmin = point.X;
                if (xmax < point.X) xmax = point.X;
                if (ymin > point.Y) ymin = point.Y;
                if (ymax < point.Y) ymax = point.Y;
            }
        }

        // Map a drawing coordinate rectangle to
        // a graphics object rectangle.
        // See http://csharphelper.com/blog/2014/11/scale-a-drawing-so-it-fits-a-target-area-in-c/
        private void MapDrawing(Graphics gr, RectangleF drawing_rect,
            RectangleF target_rect, bool stretch)
        {
            if ((target_rect.Width < 1) ||
                (target_rect.Height < 1)) return;

            gr.ResetTransform();

            // Center the drawing area at the origin.
            float drawing_cx = (drawing_rect.Left + drawing_rect.Right) / 2;
            float drawing_cy = (drawing_rect.Top + drawing_rect.Bottom) / 2;
            gr.TranslateTransform(-drawing_cx, -drawing_cy);

            // Scale.
            // Get scale factors for both directions.
            float scale_x = target_rect.Width / drawing_rect.Width;
            float scale_y = target_rect.Height / drawing_rect.Height;
            if (!stretch)
            {
                // To preserve the aspect ratio,
                // use the smaller scale factor.
                scale_x = Math.Min(scale_x, scale_y);
                scale_y = scale_x;
            }
            gr.ScaleTransform(scale_x, scale_y,
                System.Drawing.Drawing2D.MatrixOrder.Append);

            // Translate to center over the drawing area.
            float graphics_cx = (target_rect.Left + target_rect.Right) / 2;
            float graphics_cy = (target_rect.Top + target_rect.Bottom) / 2;
            gr.TranslateTransform(graphics_cx, graphics_cy,
                System.Drawing.Drawing2D.MatrixOrder.Append);
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
            this.chkFill = new System.Windows.Forms.CheckBox();
            this.txtNumTriangles = new System.Windows.Forms.TextBox();
            this.btnDraw = new System.Windows.Forms.Button();
            this.picSpiral = new System.Windows.Forms.PictureBox();
            this.chkOutline = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSpiral)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "# Triangles:";
            // 
            // chkFill
            // 
            this.chkFill.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFill.Checked = true;
            this.chkFill.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFill.Location = new System.Drawing.Point(15, 61);
            this.chkFill.Name = "chkFill";
            this.chkFill.Size = new System.Drawing.Size(83, 17);
            this.chkFill.TabIndex = 2;
            this.chkFill.Text = "Fill";
            this.chkFill.UseVisualStyleBackColor = true;
            // 
            // txtNumTriangles
            // 
            this.txtNumTriangles.Location = new System.Drawing.Point(81, 12);
            this.txtNumTriangles.Name = "txtNumTriangles";
            this.txtNumTriangles.Size = new System.Drawing.Size(49, 20);
            this.txtNumTriangles.TabIndex = 0;
            this.txtNumTriangles.Text = "16";
            this.txtNumTriangles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(29, 95);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 3;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // picSpiral
            // 
            this.picSpiral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picSpiral.BackColor = System.Drawing.Color.White;
            this.picSpiral.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picSpiral.Location = new System.Drawing.Point(136, 12);
            this.picSpiral.Name = "picSpiral";
            this.picSpiral.Size = new System.Drawing.Size(237, 237);
            this.picSpiral.TabIndex = 4;
            this.picSpiral.TabStop = false;
            // 
            // chkOutline
            // 
            this.chkOutline.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkOutline.Checked = true;
            this.chkOutline.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOutline.Location = new System.Drawing.Point(15, 38);
            this.chkOutline.Name = "chkOutline";
            this.chkOutline.Size = new System.Drawing.Size(83, 17);
            this.chkOutline.TabIndex = 1;
            this.chkOutline.Text = "Outline";
            this.chkOutline.UseVisualStyleBackColor = true;
            // 
            // howto_spiral_of_theodorus_Form1
            // 
            this.AcceptButton = this.btnDraw;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 261);
            this.Controls.Add(this.chkOutline);
            this.Controls.Add(this.picSpiral);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.txtNumTriangles);
            this.Controls.Add(this.chkFill);
            this.Controls.Add(this.label1);
            this.Name = "howto_spiral_of_theodorus_Form1";
            this.Text = "howto_spiral_of_theodorus";
            ((System.ComponentModel.ISupportInitialize)(this.picSpiral)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkFill;
        private System.Windows.Forms.TextBox txtNumTriangles;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.PictureBox picSpiral;
        private System.Windows.Forms.CheckBox chkOutline;
    }
}

