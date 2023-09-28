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
     public partial class howto_heart_Form1:Form
  { 


        public howto_heart_Form1()
        {
            InitializeComponent();
        }

        // Draw the curve.
        private void howto_heart_Form1_Load(object sender, EventArgs e)
        {
            picGraph.Image = DrawHeart(
                picGraph.ClientSize.Width,
                picGraph.ClientSize.Height);
        }

        // Redraw the curve.
        private void howto_heart_Form1_Resize(object sender, EventArgs e)
        {
            picGraph.Image = DrawHeart(
                picGraph.ClientSize.Width,
                picGraph.ClientSize.Height);
        }

        // Draw the curve on a bitmap.
        private Bitmap DrawHeart(int width, int height)
        {
            Bitmap bm = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                // Generate the points.
                const int num_points = 100;
                List<PointF> points = new List<PointF>();
                float dt = (float)(2 * Math.PI / num_points);
                for (float t = 0; t <= 2 * Math.PI; t += dt)
                    points.Add(new PointF(X(t), Y(t)));

                // Get the coordinate bounds.
                float wxmin = points[0].X;
                float wxmax = wxmin;
                float wymin = points[0].Y;
                float wymax = wymin;
                foreach (PointF point in points)
                {
                    if (wxmin > point.X) wxmin = point.X;
                    if (wxmax < point.X) wxmax = point.X;
                    if (wymin > point.Y) wymin = point.Y;
                    if (wymax < point.Y) wymax = point.Y;
                }

                // Make the world coordinate rectangle.
                RectangleF world_rect = new RectangleF(
                    wxmin, wymin, wxmax - wxmin, wymax - wymin);

                // Make the device coordinate rectangle with a margin.
                const int margin = 5;
                Rectangle device_rect = new Rectangle(
                    margin, margin,
                    picGraph.ClientSize.Width - 2 * margin,
                    picGraph.ClientSize.Height - 2 * margin);

                // Map world to device coordinates without distortion.
                // Flip vertically so Y increases downward.
                SetTransformationWithoutDisortion(gr, world_rect, device_rect, false, true);

                // Draw the curve.
                gr.FillPolygon(Brushes.Pink, points.ToArray());
                using (Pen pen = new Pen(Color.Red, 0))
                {
                    gr.DrawPolygon(pen, points.ToArray());

                    //// Draw a rectangle around the coordinate bounds.
                    //pen.Color = Color.Blue;
                    //gr.DrawRectangle(pen, Rectangle.Round( world_rect));

                    //// Draw the X and Y axes.
                    //pen.Color = Color.Green;
                    //gr.DrawLine(pen, -20, 0, 20, 0);
                    //gr.DrawLine(pen, 0, -20, 0, 20);
                    //for (int x = -20; x <= 20; x++)
                    //    gr.DrawLine(pen, x, -0.3f, x, 0.3f);
                    //for (int y = -20; y <= 20; y++)
                    //    gr.DrawLine(pen, -0.3f, y, 0.3f, y);
                }
            }
            return bm;
        }

        // The curve's parametric equations.
        private float X(float t)
        {
            double sin_t = Math.Sin(t);
            return (float)(16 * sin_t * sin_t * sin_t);
        }
        private float Y(float t)
        {
            return (float)(
                13 * Math.Cos(t) -
                5 * Math.Cos(2 * t) -
                2 * Math.Cos(3 * t) -
                Math.Cos(4 * t));
        }

        // Map from world coordinates to device coordinates
        // without distortion.
        private void SetTransformationWithoutDisortion(Graphics gr,
            RectangleF world_rect, RectangleF device_rect,
            bool invert_x, bool invert_y)
        {
            // Get the aspect ratios.
            float world_aspect = world_rect.Width / world_rect.Height;
            float device_aspect = device_rect.Width / device_rect.Height;

            // Asjust the world rectangle to maintain the aspect ratio.
            float world_cx = world_rect.X + world_rect.Width / 2f;
            float world_cy = world_rect.Y + world_rect.Height / 2f;
            if (world_aspect > device_aspect)
            {
                // The world coordinates are too short and width.
                // Make them taller.
                float world_height = world_rect.Width / device_aspect;
                world_rect = new RectangleF(
                    world_rect.Left,
                    world_cy - world_height / 2f,
                    world_rect.Width,
                    world_height);
            }
            else
            {
                // The world coordinates are too tall and thin.
                // Make them wider.
                float world_width = device_aspect * world_rect.Height;
                world_rect = new RectangleF(
                    world_cx - world_width / 2f,
                    world_rect.Top,
                    world_width,
                    world_rect.Height);
            }

            // Map the new world coordinates into the device coordinates.
            SetTransformation(gr, world_rect, device_rect, invert_x, invert_y);
        }

        // Map from world coordinates to device coordinates.
        private void SetTransformation(Graphics gr,
            RectangleF world_rect, RectangleF device_rect,
            bool invert_x, bool invert_y)
        {
            PointF[] device_points =
            {
                new PointF(device_rect.Left, device_rect.Top),      // Upper left.
                new PointF(device_rect.Right, device_rect.Top),     // Upper right.
                new PointF(device_rect.Left, device_rect.Bottom),   // Lower left.
            };

            if (invert_x)
            {
                device_points[0].X = device_rect.Right;
                device_points[1].X = device_rect.Left;
                device_points[2].X = device_rect.Right;
            }
            if (invert_y)
            {
                device_points[0].Y = device_rect.Bottom;
                device_points[1].Y = device_rect.Bottom;
                device_points[2].Y = device_rect.Top;
            }

            gr.Transform = new Matrix(world_rect, device_points);
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picGraph = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = Properties.Resources.howto_heart_eq;
            this.pictureBox1.Location = new System.Drawing.Point(13, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(310, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // picGraph
            // 
            this.picGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraph.BackColor = System.Drawing.Color.White;
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraph.Location = new System.Drawing.Point(12, 67);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(313, 231);
            this.picGraph.TabIndex = 1;
            this.picGraph.TabStop = false;
            // 
            // howto_heart_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 310);
            this.Controls.Add(this.picGraph);
            this.Controls.Add(this.pictureBox1);
            this.Name = "howto_heart_Form1";
            this.Text = "howto_heart";
            this.Load += new System.EventHandler(this.howto_heart_Form1_Load);
            this.Resize += new System.EventHandler(this.howto_heart_Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picGraph;
    }
}

