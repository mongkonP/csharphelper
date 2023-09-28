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
     public partial class howto_rounded_rectangles_Form1:Form
  { 


        public howto_rounded_rectangles_Form1()
        {
            InitializeComponent();
        }

        private void picSamples_Resize(object sender, EventArgs e)
        {
            picSamples.Refresh();
        }
        
        private void picSamples_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(picSamples.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            const float xradius = 20;
            const float yradius = 20;

            // Top rectangle.
            const float margin = 10;
            float hgt = (picSamples.ClientSize.Height - 3 * margin) / 2f;
            RectangleF rect = new RectangleF(
                margin, margin,
                picSamples.ClientSize.Width - 2 * margin,
                hgt);
            using (Pen pen = new Pen(Color.Green, 5))
            {
                GraphicsPath path = MakeRoundedRect(
                    rect, xradius, yradius, true, true, true, true);
                e.Graphics.FillPath(Brushes.LightGreen, path);
                e.Graphics.DrawPath(pen, path);
            }

            // Bottom left rectangle.
            float wid = (picSamples.ClientSize.Width - 3 * margin) / 2f;
            rect = new RectangleF(
                margin, hgt + 2 * margin, wid, hgt);
            using (Pen pen = new Pen(Color.Green, 5))
            {
                GraphicsPath path = MakeRoundedRect(
                    rect, xradius, yradius, false, true, false, true);
                e.Graphics.FillPath(Brushes.LightGreen, path);
                e.Graphics.DrawPath(pen, path);
            }

            // Bottom right rectangle.
            rect = new RectangleF(
                wid + 2 * margin, hgt + 2 * margin, wid, hgt);
            using (Pen pen = new Pen(Color.Green, 5))
            {
                GraphicsPath path = MakeRoundedRect(
                    rect, xradius, yradius, true, false, true, false);
                e.Graphics.FillPath(Brushes.LightGreen, path);
                e.Graphics.DrawPath(pen, path);
            }
        }

        // Draw a rectangle in the indicated Rectangle
        // rounding the indicated corners.
        private GraphicsPath MakeRoundedRect(
            RectangleF rect, float xradius, float yradius,
            bool round_ul, bool round_ur, bool round_lr, bool round_ll)
        {
            // Make a GraphicsPath to draw the rectangle.
            PointF point1, point2;
            GraphicsPath path = new GraphicsPath();

            // Upper left corner.
            if (round_ul)
            {
                RectangleF corner = new RectangleF(
                    rect.X, rect.Y,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 180, 90);
                point1 = new PointF(rect.X + xradius, rect.Y);
            }
            else point1 = new PointF(rect.X, rect.Y);

            // Top side.
            if (round_ur)
                point2 = new PointF(rect.Right - xradius, rect.Y);
            else
                point2 = new PointF(rect.Right, rect.Y);
            path.AddLine(point1, point2);

            // Upper right corner.
            if (round_ur)
            {
                RectangleF corner = new RectangleF(
                    rect.Right - 2 * xradius, rect.Y,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 270, 90);
                point1 = new PointF(rect.Right, rect.Y + yradius);
            }
            else point1 = new PointF(rect.Right, rect.Y);

            // Right side.
            if (round_lr)
                point2 = new PointF(rect.Right, rect.Bottom - yradius);
            else
                point2 = new PointF(rect.Right, rect.Bottom);
            path.AddLine(point1, point2);

            // Lower right corner.
            if (round_lr)
            {
                RectangleF corner = new RectangleF(
                    rect.Right - 2 * xradius,
                    rect.Bottom - 2 * yradius,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 0, 90);
                point1 = new PointF(rect.Right - xradius, rect.Bottom);
            }
            else point1 = new PointF(rect.Right, rect.Bottom);

            // Bottom side.
            if (round_ll)
                point2 = new PointF(rect.X + xradius, rect.Bottom);
            else
                point2 = new PointF(rect.X, rect.Bottom);
            path.AddLine(point1, point2);

            // Lower left corner.
            if (round_ll)
            {
                RectangleF corner = new RectangleF(
                    rect.X, rect.Bottom - 2 * yradius,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 90, 90);
                point1 = new PointF(rect.X, rect.Bottom - yradius);
            }
            else point1 = new PointF(rect.X, rect.Bottom);

            // Left side.
            if (round_ul)
                point2 = new PointF(rect.X, rect.Y + yradius);
            else
                point2 = new PointF(rect.X, rect.Y);
            path.AddLine(point1, point2);

            // Join with the start point.
            path.CloseFigure();

            return path;
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
            this.picSamples = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSamples)).BeginInit();
            this.SuspendLayout();
            // 
            // picSamples
            // 
            this.picSamples.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picSamples.BackColor = System.Drawing.Color.LightBlue;
            this.picSamples.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picSamples.Location = new System.Drawing.Point(12, 12);
            this.picSamples.Name = "picSamples";
            this.picSamples.Size = new System.Drawing.Size(290, 137);
            this.picSamples.TabIndex = 0;
            this.picSamples.TabStop = false;
            this.picSamples.Resize += new System.EventHandler(this.picSamples_Resize);
            this.picSamples.Paint += new System.Windows.Forms.PaintEventHandler(this.picSamples_Paint);
            // 
            // howto_rounded_rectangles_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 161);
            this.Controls.Add(this.picSamples);
            this.Name = "howto_rounded_rectangles_Form1";
            this.Text = "howto_rounded_rectangles";
            ((System.ComponentModel.ISupportInitialize)(this.picSamples)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picSamples;
    }
}

