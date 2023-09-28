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
     public partial class howto_double_buffer_picturebox_Form1:Form
  { 


        public howto_double_buffer_picturebox_Form1()
        {
            InitializeComponent();
        }

        private const int period = 24;
        private Color[] Colors;

        // Initialize the colors.
        private void howto_double_buffer_picturebox_Form1_Load(object sender, EventArgs e)
        {
            // Redraw when resized.
            this.ResizeRedraw = true;

            Colors = new Color[] 
            {
                Color.Pink,
                Color.Red,
                Color.Orange,
                Color.Yellow,
                Color.Lime,
                Color.Cyan,
                Color.Blue,
                Color.Violet,
                Color.Pink,
                Color.Red,
                Color.Orange,
                Color.Yellow,
                Color.Lime,
                Color.Cyan,
                Color.Blue,
                Color.Violet,
                Color.Pink,
                Color.Red,
                Color.Orange,
                Color.Yellow,
                Color.Lime,
                Color.Cyan,
                Color.Blue,
                Color.Violet
            };

            // Draw the initial curves.
            DrawCurves();
        }

        // Redraw the butterfly curve.
        private void btnRedraw_Click(object sender, EventArgs e)
        {
            DrawCurves();
        }

        // Draw butterfly curves on both PictureBoxes.
        private void DrawCurves()
        {
            // Clear both images.
            picCanvas1.Image = null;
            picCanvas2.Refresh();
            picCanvas1.Refresh();

            int wid = picCanvas2.ClientSize.Width;
            int hgt = picCanvas2.ClientSize.Height;

            // Draw with double-buffering.
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                DrawButterfly(gr, wid, hgt);
            }
            picCanvas1.Image = bm;
            picCanvas1.Refresh();

            // Draw without double-buffering.
            DrawButterfly(picCanvas2.CreateGraphics(), wid, hgt);
        }

        // Draw the butterfly curve on this Graphics object.
        private void DrawButterfly(Graphics gr, int wid, int hgt)
        {
            gr.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            gr.Clear(Color.Black);

            // Scale and translate.
            RectangleF world_rect =
                new RectangleF(-4.0f, -4.4f, 8.0f, 7.3f);
            float cx = (world_rect.Left + world_rect.Right) / 2;
            float cy = (world_rect.Top + world_rect.Bottom) / 2;

            // Center the world coordinates at origin.
            gr.TranslateTransform(-cx, -cy);

            // Scale to fill the form.
            float scale = Math.Min(
                wid / world_rect.Width,
                hgt / world_rect.Height);
            gr.ScaleTransform(scale, scale,
                System.Drawing.Drawing2D.MatrixOrder.Append);

            // Move the result to center on the form.
            gr.TranslateTransform(
                wid / 2,
                hgt / 2,
                System.Drawing.Drawing2D.MatrixOrder.Append);

            // Generate the points.
            PointF pt0, pt1;
            double t = 0;
            double expr =
                Math.Exp(Math.Cos(t))
                - 2 * Math.Cos(4 * t)
                - Math.Pow(Math.Sin(t / 12), 5);
            pt1 = new PointF(
                (float)(Math.Sin(t) * expr),
                (float)(-Math.Cos(t) * expr));
            using (Pen the_pen = new Pen(Color.Blue, 0))
            {
                const long num_lines = 5000;
                for (long i = 0; i < num_lines; i++)
                {
                    t = i * period * Math.PI / num_lines;
                    expr =
                        Math.Exp(Math.Cos(t))
                        - 2 * Math.Cos(4 * t)
                        - Math.Pow(Math.Sin(t / 12), 5);
                    pt0 = pt1;
                    pt1 = new PointF(
                        (float)(Math.Sin(t) * expr),
                        (float)(-Math.Cos(t) * expr));
                    the_pen.Color = GetColor(t);
                    gr.DrawLine(the_pen, pt0, pt1);
                }
            }
        }

        // Redraw the non-buffered butterfly curve.
        private void picCanvas2_Paint(object sender, PaintEventArgs e)
        {
            DrawButterfly(e.Graphics,
                picCanvas2.ClientSize.Width,
                picCanvas2.ClientSize.Height);
        }

        // Return an appropriate color for this segment.
        private Color GetColor(double t)
        {
            return Colors[(int)(t / Math.PI)];
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
            this.picCanvas2 = new System.Windows.Forms.PictureBox();
            this.btnRedraw = new System.Windows.Forms.Button();
            this.picCanvas1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas1)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas2
            // 
            this.picCanvas2.Location = new System.Drawing.Point(229, 41);
            this.picCanvas2.Name = "picCanvas2";
            this.picCanvas2.Size = new System.Drawing.Size(211, 211);
            this.picCanvas2.TabIndex = 0;
            this.picCanvas2.TabStop = false;
            this.picCanvas2.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas2_Paint);
            // 
            // btnRedraw
            // 
            this.btnRedraw.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRedraw.Location = new System.Drawing.Point(189, 12);
            this.btnRedraw.Name = "btnRedraw";
            this.btnRedraw.Size = new System.Drawing.Size(75, 23);
            this.btnRedraw.TabIndex = 1;
            this.btnRedraw.Text = "Redraw";
            this.btnRedraw.UseVisualStyleBackColor = true;
            this.btnRedraw.Click += new System.EventHandler(this.btnRedraw_Click);
            // 
            // picCanvas1
            // 
            this.picCanvas1.Location = new System.Drawing.Point(12, 41);
            this.picCanvas1.Name = "picCanvas1";
            this.picCanvas1.Size = new System.Drawing.Size(211, 211);
            this.picCanvas1.TabIndex = 2;
            this.picCanvas1.TabStop = false;
            // 
            // howto_double_buffer_picturebox_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 264);
            this.Controls.Add(this.picCanvas1);
            this.Controls.Add(this.btnRedraw);
            this.Controls.Add(this.picCanvas2);
            this.Name = "howto_double_buffer_picturebox_Form1";
            this.Text = "howto_double_buffer_picturebox";
            this.Load += new System.EventHandler(this.howto_double_buffer_picturebox_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas2;
        private System.Windows.Forms.Button btnRedraw;
        private System.Windows.Forms.PictureBox picCanvas1;
    }
}

