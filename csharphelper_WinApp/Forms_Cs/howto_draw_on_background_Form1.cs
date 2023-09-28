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
     public partial class howto_draw_on_background_Form1:Form
  { 


        public howto_draw_on_background_Form1()
        {
            InitializeComponent();
        }

        private bool SelectingArea = false;
        private Point StartPoint, EndPoint;

        // Start drawing.
        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            StartPoint = e.Location;
            EndPoint = e.Location;
            SelectingArea = true;
            picCanvas.Cursor = Cursors.Cross;

            // Refresh.
            picCanvas.Refresh();
        }

        // Continue drawing.
        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            // Update the end point.
            EndPoint = e.Location;

            // Refresh.
            picCanvas.Refresh();
        }

        // Continue drawing.
        private void picCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            SelectingArea = false;
            picCanvas.Cursor = Cursors.Default;

            // Do something with the selection rectangle.
            Rectangle rect = MakeRectangle(StartPoint, EndPoint);
            Console.WriteLine(rect.ToString());
        }

        // Draw the selection rectangle.
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (SelectingArea)
            {
                using (Pen pen = new Pen(Color.Yellow, 2))
                {
                    e.Graphics.DrawRectangle(pen,
                        MakeRectangle(StartPoint, EndPoint));

                    pen.Color = Color.Red;
                    pen.DashPattern = new float[] { 5, 5 };
                    e.Graphics.DrawRectangle(pen,
                        MakeRectangle(StartPoint, EndPoint));
                }
            }
            else
            {
                DrawSmiley(e.Graphics, EndPoint, 50);
            }
        }

        // Make a rectangle from two points.
        private Rectangle MakeRectangle(Point p1, Point p2)
        {
            int x = Math.Min(p1.X, p2.X);
            int y = Math.Min(p1.Y, p2.Y);
            int width = Math.Abs(p1.X - p2.X);
            int height = Math.Abs(p1.Y - p2.Y);
            return new Rectangle(x, y, width, height);
        }

        // Draw a smiley face.
        private void DrawSmiley(Graphics gr, PointF center, float radius)
        {
            gr.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen thick_pen = new Pen(Color.Red, 2))
            {
                // Draw the face.
                RectangleF rect = new RectangleF(
                    center.X - radius,
                    center.Y - radius,
                    2 * radius, 2 * radius);
                gr.FillEllipse(Brushes.Yellow, rect);
                gr.DrawEllipse(thick_pen, rect);

                // Left eye.
                rect = new RectangleF(
                    center.X - 0.6f * radius,
                    center.Y - 0.6f * radius,
                    0.4f * radius,
                    0.6f * radius);
                gr.FillEllipse(Brushes.White, rect);
                gr.DrawEllipse(Pens.Black, rect);

                // Left pupil.
                rect = new RectangleF(
                    center.X - 0.4f * radius,
                    center.Y - 0.5f * radius,
                    0.2f * radius,
                    0.4f * radius);
                gr.FillEllipse(Brushes.Black, rect);

                // Right eye.
                rect = new RectangleF(
                    center.X + 0.2f * radius,
                    center.Y - 0.6f * radius,
                    0.4f * radius,
                    0.6f * radius);
                gr.FillEllipse(Brushes.White, rect);
                gr.DrawEllipse(Pens.Black, rect);

                // Right pupil.
                rect = new RectangleF(
                    center.X + 0.4f * radius,
                    center.Y - 0.5f * radius,
                    0.2f * radius,
                    0.4f * radius);
                gr.FillEllipse(Brushes.Black, rect);

                // Nose.
                rect = new RectangleF(
                    center.X - 0.15f * radius,
                    center.Y - 0.15f * radius,
                    0.3f * radius,
                    0.5f * radius);
                gr.FillEllipse(Brushes.LightBlue, rect);
                gr.DrawEllipse(Pens.Blue, rect);

                // Smile.
                float smile_radius = radius * 0.7f;
                rect = new RectangleF(
                    center.X - smile_radius,
                    center.Y - smile_radius,
                    2 * smile_radius,
                    2 * smile_radius);
                thick_pen.Color = Color.Green;
                thick_pen.Width = 3;
                gr.DrawArc(thick_pen, rect, 20, 140);
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
            this.picCanvas.Image = Properties.Resources.pastries;
            this.picCanvas.Location = new System.Drawing.Point(12, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(400, 300);
            this.picCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseMove);
            this.picCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseDown);
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            this.picCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseUp);
            // 
            // howto_draw_on_background_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 323);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_draw_on_background_Form1";
            this.Text = "howto_draw_on_background";
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
    }
}

