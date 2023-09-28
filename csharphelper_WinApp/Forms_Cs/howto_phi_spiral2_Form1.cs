using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_phi_spiral2_Form1:Form
  { 


        public howto_phi_spiral2_Form1()
        {
            InitializeComponent();
        }

        // Orientations for the rectangles.
        private enum RectOrientations
        {
            RemoveLeft,
            RemoveTop,
            RemoveRight,
            RemoveBottom
        }

        // Draw the rectangles.
        private void howto_phi_spiral2_Form1_Load(object sender, EventArgs e)
        {
            DrawBitmap();
        }
        private void howto_phi_spiral2_Form1_Resize(object sender, EventArgs e)
        {
            DrawBitmap();
        }

        // Redraw.
        private void Options_CheckedChanged(object sender, EventArgs e)
        {
            DrawBitmap();
        }

        // Draw the bitmap.
        private void DrawBitmap()
        {
            Bitmap bm;

            // Determine the first rectangle's orientation and dimensions.
            double phi = (1 + Math.Sqrt(5)) / 2;
            RectOrientations orientation;
            int client_wid = picRectangles.ClientSize.Width;
            int client_hgt = picRectangles.ClientSize.Height;
            double wid, hgt;                // The rectangle's size.
            if (client_wid > client_hgt)
            {
                // Horizontal rectangle.
                orientation = RectOrientations.RemoveLeft;
                if (client_wid / (double)client_hgt > phi)
                {
                    hgt = client_hgt;
                    wid = hgt * phi;
                }
                else
                {
                    wid = client_wid;
                    hgt = wid / phi;
                }
            }
            else
            {
                // Vertical rectangle.
                orientation = RectOrientations.RemoveTop;
                if (client_hgt / (double)client_wid > phi)
                {
                    wid = client_wid;
                    hgt = wid * phi;
                }
                else
                {
                    hgt = client_hgt;
                    wid = hgt / phi;
                }
            }

            // Allow a margin.
            wid *= 0.95f;
            hgt *= 0.95f;

            // Center it.
            double x = (client_wid - wid) / 2;
            double y = (client_hgt - hgt) / 2;

            // Make the Bitmap.
            bm = new Bitmap(client_wid, client_hgt);

            // Draw the rectangles.
            using (Graphics gr = Graphics.FromImage(bm))
            {
                // Draw the rectangles.
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                List<PointF> points = new List<PointF>();
                DrawPhiRectanglesOnGraphics(gr, points, x, y, wid, hgt, orientation);

                // Draw the square spiral.
                if (chkSquareSpiral.Checked) gr.DrawLines(Pens.Green, points.ToArray());
                // Smoothed square spiral:
                //gr.DrawCurve(Pens.Green, points.ToArray());

                if (chkTrueSpiral.Checked && points.Count > 1)
                {
                    // Draw the true spiral.
                    PointF start = points[0];
                    PointF origin = points[points.Count - 1];
                    float dx = start.X - origin.X;
                    float dy = start.Y - origin.Y;
                    double radius = Math.Sqrt(dx * dx + dy * dy);

                    double theta = Math.Atan2(dy, dx);
                    const int num_slices = 1000;
                    double dtheta = Math.PI / 2 / num_slices;
                    double factor = 1 - (1 / phi) / num_slices * 0.78; //@
                    List<PointF> new_points = new List<PointF>();

                    // Repeat until dist is too small to see.
                    while (radius > 0.1)
                    {
                        PointF new_point = new PointF(
                            (float)(origin.X + radius * Math.Cos(theta)),
                            (float)(origin.Y + radius * Math.Sin(theta)));
                        new_points.Add(new_point);
                        theta += dtheta;
                        radius *= factor;
                    }
                    gr.DrawLines(Pens.Blue, new_points.ToArray());
                }
            }

            // Display the result.
            picRectangles.Image = bm;
            picRectangles.Refresh();
        }

        // Draw rectangles on a Graphics object.
        private void DrawPhiRectanglesOnGraphics(Graphics gr, List<PointF> points, double x, double y, double wid, double hgt, RectOrientations orientation)
        {
            if ((wid < 1) || (hgt < 1)) return;

            // Draw this rectangle.
            if (chkRectangles.Checked) gr.DrawRectangle(Pens.Blue,
                (float)x, (float)y, (float)wid, (float)hgt);

            if (chkCircularSpiral.Checked)
            {
                // Draw a circular arc from the spiral.
                RectangleF rect;
                switch (orientation)
                {
                    case RectOrientations.RemoveLeft:
                        rect = new RectangleF(
                            (float)x, (float)y, (float)(2 * hgt), (float)(2 * hgt));
                        gr.DrawArc(Pens.Red, rect, 180, 90);
                        break;
                    case RectOrientations.RemoveTop:
                        rect = new RectangleF(
                            (float)(x - wid), (float)y, (float)(2 * wid), (float)(2 * wid));
                        gr.DrawArc(Pens.Red, rect, -90, 90);
                        break;
                    case RectOrientations.RemoveRight:
                        rect = new RectangleF(
                            (float)(x + wid - 2 * hgt),
                            (float)(y - hgt), (float)(2 * hgt), (float)(2 * hgt));
                        gr.DrawArc(Pens.Red, rect, 0, 90);
                        break;
                    case RectOrientations.RemoveBottom:
                        rect = new RectangleF((float)x, (float)(y + hgt - 2 * wid),
                            (float)(2 * wid), (float)(2 * wid));
                        gr.DrawArc(Pens.Red, rect, 90, 90);
                        break;
                }
            }

            // Recursively draw the next rectangle.
            switch (orientation)
            {
                case RectOrientations.RemoveLeft:
                    points.Add(new PointF((float)x, (float)(y + hgt)));
                    x += hgt;
                    wid -= hgt;
                    orientation = RectOrientations.RemoveTop;
                    break;
                case RectOrientations.RemoveTop:
                    points.Add(new PointF((float)x, (float)y));
                    y += wid;
                    hgt -= wid;
                    orientation = RectOrientations.RemoveRight;
                    break;
                case RectOrientations.RemoveRight:
                    points.Add(new PointF((float)(x + wid), (float)y));
                    wid -= hgt;
                    orientation = RectOrientations.RemoveBottom;
                    break;
                case RectOrientations.RemoveBottom:
                    points.Add(new PointF((float)(x + wid), (float)(y + hgt)));
                    hgt -= wid;
                    orientation = RectOrientations.RemoveLeft;
                    break;
            }
            DrawPhiRectanglesOnGraphics(gr, points, x, y, wid, hgt, orientation);
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
            this.chkTrueSpiral = new System.Windows.Forms.CheckBox();
            this.chkCircularSpiral = new System.Windows.Forms.CheckBox();
            this.chkSquareSpiral = new System.Windows.Forms.CheckBox();
            this.chkRectangles = new System.Windows.Forms.CheckBox();
            this.picRectangles = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picRectangles)).BeginInit();
            this.SuspendLayout();
            // 
            // chkTrueSpiral
            // 
            this.chkTrueSpiral.AutoSize = true;
            this.chkTrueSpiral.Checked = true;
            this.chkTrueSpiral.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrueSpiral.ForeColor = System.Drawing.Color.Blue;
            this.chkTrueSpiral.Location = new System.Drawing.Point(301, 12);
            this.chkTrueSpiral.Name = "chkTrueSpiral";
            this.chkTrueSpiral.Size = new System.Drawing.Size(77, 17);
            this.chkTrueSpiral.TabIndex = 9;
            this.chkTrueSpiral.Text = "True Spiral";
            this.chkTrueSpiral.UseVisualStyleBackColor = true;
            this.chkTrueSpiral.CheckedChanged += new System.EventHandler(this.Options_CheckedChanged);
            // 
            // chkCircularSpiral
            // 
            this.chkCircularSpiral.AutoSize = true;
            this.chkCircularSpiral.ForeColor = System.Drawing.Color.Red;
            this.chkCircularSpiral.Location = new System.Drawing.Point(201, 12);
            this.chkCircularSpiral.Name = "chkCircularSpiral";
            this.chkCircularSpiral.Size = new System.Drawing.Size(90, 17);
            this.chkCircularSpiral.TabIndex = 8;
            this.chkCircularSpiral.Text = "Circular Spiral";
            this.chkCircularSpiral.UseVisualStyleBackColor = true;
            this.chkCircularSpiral.CheckedChanged += new System.EventHandler(this.Options_CheckedChanged);
            // 
            // chkSquareSpiral
            // 
            this.chkSquareSpiral.AutoSize = true;
            this.chkSquareSpiral.ForeColor = System.Drawing.Color.Green;
            this.chkSquareSpiral.Location = new System.Drawing.Point(102, 12);
            this.chkSquareSpiral.Name = "chkSquareSpiral";
            this.chkSquareSpiral.Size = new System.Drawing.Size(89, 17);
            this.chkSquareSpiral.TabIndex = 7;
            this.chkSquareSpiral.Text = "Square Spiral";
            this.chkSquareSpiral.UseVisualStyleBackColor = true;
            this.chkSquareSpiral.CheckedChanged += new System.EventHandler(this.Options_CheckedChanged);
            // 
            // chkRectangles
            // 
            this.chkRectangles.AutoSize = true;
            this.chkRectangles.Checked = true;
            this.chkRectangles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRectangles.Location = new System.Drawing.Point(12, 12);
            this.chkRectangles.Name = "chkRectangles";
            this.chkRectangles.Size = new System.Drawing.Size(80, 17);
            this.chkRectangles.TabIndex = 6;
            this.chkRectangles.Text = "Rectangles";
            this.chkRectangles.UseVisualStyleBackColor = true;
            this.chkRectangles.CheckedChanged += new System.EventHandler(this.Options_CheckedChanged);
            // 
            // picRectangles
            // 
            this.picRectangles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picRectangles.BackColor = System.Drawing.Color.White;
            this.picRectangles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picRectangles.Location = new System.Drawing.Point(12, 35);
            this.picRectangles.Name = "picRectangles";
            this.picRectangles.Size = new System.Drawing.Size(435, 288);
            this.picRectangles.TabIndex = 5;
            this.picRectangles.TabStop = false;
            // 
            // howto_phi_spiral2_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 336);
            this.Controls.Add(this.chkTrueSpiral);
            this.Controls.Add(this.chkCircularSpiral);
            this.Controls.Add(this.chkSquareSpiral);
            this.Controls.Add(this.chkRectangles);
            this.Controls.Add(this.picRectangles);
            this.Name = "howto_phi_spiral2_Form1";
            this.Text = "howto_phi_spiral";
            this.Load += new System.EventHandler(this.howto_phi_spiral2_Form1_Load);
            this.Resize += new System.EventHandler(this.howto_phi_spiral2_Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picRectangles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkTrueSpiral;
        private System.Windows.Forms.CheckBox chkCircularSpiral;
        private System.Windows.Forms.CheckBox chkSquareSpiral;
        private System.Windows.Forms.CheckBox chkRectangles;
        private System.Windows.Forms.PictureBox picRectangles;
    }
}

