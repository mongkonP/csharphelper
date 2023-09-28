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
     public partial class howto_map_without_distortion_Form1:Form
  { 


        public howto_map_without_distortion_Form1()
        {
            InitializeComponent();
        }

        private void picCanvas_Resize(object sender, EventArgs e)
        {
            picCanvas.Refresh();
        }

        // Draw the smiley as big as possible without distortion.
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Set the transformation. Flip vertically.
            RectangleF drawing_rect = new RectangleF(-1, -1, 2, 2);
            const int margin = 4;
            Rectangle device_rect = new Rectangle(
                margin, margin,
                picCanvas.ClientSize.Width - 2 * margin,
                picCanvas.ClientSize.Height - 2 * margin);
            SetTransformationWithoutDisortion(e.Graphics,
                drawing_rect, device_rect, false, true);

            // Draw the smiley.
            DrawSmiley(e.Graphics);

            // Reset the transformation and draw a box around it.
            e.Graphics.ResetTransform();
            e.Graphics.DrawRectangle(Pens.Red, device_rect);
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

        // Draw a smiley right side up in the
        // rectangle (-1, -1) - (1, 1).
        private void DrawSmiley(Graphics gr)
        {
            using (Pen black_pen = new Pen(Color.Black, 0))
            {
                // Face.
                gr.FillEllipse(Brushes.Yellow, -1, -1, 2, 2);
                gr.DrawEllipse(black_pen, -1, -1, 2, 2);

                // Nose.
                gr.FillEllipse(Brushes.LightBlue, -0.2f, -0.3f, 0.4f, 0.6f);
                using (Pen blue_pen = new Pen(Color.Blue, 0))
                {
                    gr.DrawEllipse(blue_pen, -0.2f, -0.3f, 0.4f, 0.6f);
                }

                // Left eye.
                gr.FillEllipse(Brushes.White, -0.6f, 0.1f, 0.3f, 0.4f);
                gr.DrawEllipse(black_pen, -0.6f, 0.1f, 0.3f, 0.4f);
                gr.FillEllipse(Brushes.Black, -0.5f, 0.15f, 0.2f, 0.3f);

                // Right eye.
                gr.FillEllipse(Brushes.White, 0.3f, 0.1f, 0.3f, 0.4f);
                gr.DrawEllipse(black_pen, 0.3f, 0.1f, 0.3f, 0.4f);
                gr.FillEllipse(Brushes.Black, 0.4f, 0.15f, 0.2f, 0.3f);

                // Smile.
                gr.DrawArc(black_pen, -0.7f, -0.7f, 1.4f, 1.4f, 200, 120);
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
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(12, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(310, 187);
            this.picCanvas.TabIndex = 1;
            this.picCanvas.TabStop = false;
            this.picCanvas.Resize += new System.EventHandler(this.picCanvas_Resize);
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // howto_map_without_distortion_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 211);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_map_without_distortion_Form1";
            this.Text = "howto_map_without_distortion";
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
    }
}

