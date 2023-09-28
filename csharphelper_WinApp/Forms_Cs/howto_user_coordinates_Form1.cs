using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_user_coordinates_Form1:Form
  { 


        public howto_user_coordinates_Form1()
        {
            InitializeComponent();
        }

        // The user's ellipses.
        private List<RectangleF> Ellipses = new List<RectangleF>();
        private List<Color> Colors = new List<Color>();

        // Used while drawing a new ellipse.
        private bool Drawing = false;
        private PointF StartPoint, EndPoint;

        // The transformations.
        private Matrix Transform = null, InverseTransform = null;
        private const float DrawingScale = 50;

        // The world coordinate bounds.
        private float Wxmin, Wxmax, Wymin, Wymax;

        // Create new transformations to center the drawing.
        private void howto_user_coordinates_Form1_Resize(object sender, EventArgs e)
        {
            CreateTransforms();
            picCanvas.Refresh();
        }

        // Create the transforms.
        private void CreateTransforms()
        {
            // Make the draw transformation. (World --> Device)
            Transform = new Matrix();
            Transform.Scale(DrawingScale, DrawingScale);
            float cx = picCanvas.ClientSize.Width / 2;
            float cy = picCanvas.ClientSize.Height / 2;
            Transform.Translate(cx, cy, MatrixOrder.Append);

            // Make the inverse transformation. (Device --> World)
            InverseTransform = Transform.Clone();
            InverseTransform.Invert();

            // Calculate the world coordinate bounds.
            Wxmin = -cx / DrawingScale;
            Wxmax = cx / DrawingScale;
            Wymin = -cy / DrawingScale;
            Wymax = cy / DrawingScale;
        }

        // Draw.
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            // If we don't have the transforms yet, get them.
            if (Transform == null) CreateTransforms();

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Transform = Transform;

            // Use a pen that isn't scaled.
            using (Pen thin_pen = new Pen(Color.Black, 0))
            {
                // Draw the axes.
                float tic = 0.25f;
                thin_pen.Width = 2 / DrawingScale;
                e.Graphics.DrawLine(thin_pen, Wxmin, 0, Wxmax, 0);
                for (int x = (int)Wxmin; x <= Wxmax; x++)
                    e.Graphics.DrawLine(thin_pen, x, -tic, x, tic);
                e.Graphics.DrawLine(thin_pen, 0, Wymin, 0, Wymax);
                for (int y = (int)Wymin; y <= Wymax; y++)
                    e.Graphics.DrawLine(thin_pen, -tic, y, tic, y);

                // Draw the ellipses.
                thin_pen.Width = 0;
                for (int i = 0; i < Ellipses.Count; i++)
                {
                    using (Brush brush = new SolidBrush(Color.FromArgb(128, Colors[i])))
                    {
                        e.Graphics.FillEllipse(brush, Ellipses[i]);
                    }
                    thin_pen.Color = Colors[i];
                    e.Graphics.DrawEllipse(thin_pen, Ellipses[i]);
                }

                // Draw the new ellipse.
                if (Drawing)
                {
                    thin_pen.Color = Color.Black;
                    e.Graphics.DrawEllipse(thin_pen,
                        Math.Min(StartPoint.X, EndPoint.X),
                        Math.Min(StartPoint.Y, EndPoint.Y),
                        Math.Abs(StartPoint.X - EndPoint.X),
                        Math.Abs(StartPoint.Y - EndPoint.Y));
                }
            }
        }

        // Let the user draw a new ellipse.
        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            Drawing = true;

            // Get the start and end points.
            StartPoint = DeviceToWorld(e.Location);
            EndPoint = StartPoint;
        }

        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Drawing) return;

            // Get the end point.
            EndPoint = DeviceToWorld(e.Location);
            Refresh();
        }

        private void picCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!Drawing) return;
            Drawing = false;

            // Get the end point.
            EndPoint = DeviceToWorld(e.Location);

            // If the ellipse has non-zero size, add it to the list.
            if ((StartPoint.X != EndPoint.X) && (StartPoint.Y != EndPoint.Y))
            {
                Ellipses.Add(new RectangleF(
                    Math.Min(StartPoint.X, EndPoint.X),
                    Math.Min(StartPoint.Y, EndPoint.Y),
                    Math.Abs(StartPoint.X - EndPoint.X),
                    Math.Abs(StartPoint.Y - EndPoint.Y)));
                Colors.Add(RandomColor());
            }

            Refresh();
        }

        // Convert from device coordinates to world coordinates.
        private PointF DeviceToWorld(PointF point)
        {
            PointF[] points = { point };
            InverseTransform.TransformPoints(points);
            return points[0];
        }

        // Return a random color.
        private Random rand = new Random();
        private Color[] RandomColors =
        {
            Color.Red,
            Color.ForestGreen,
            Color.Blue,
            Color.BlueViolet,
            Color.Cyan,
            Color.DeepPink,
            Color.DarkOrange,
            Color.Maroon,
            Color.Purple,
            Color.SaddleBrown,
        };
        private Color RandomColor()
        {
            return RandomColors[rand.Next(0, RandomColors.Length)];
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
            this.picCanvas.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picCanvas.Location = new System.Drawing.Point(12, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(280, 257);
            this.picCanvas.TabIndex = 2;
            this.picCanvas.TabStop = false;
            this.picCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseMove);
            this.picCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseDown);
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            this.picCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseUp);
            // 
            // howto_user_coordinates_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 281);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_user_coordinates_Form1";
            this.Text = "howto_user_coordinates";
            this.Resize += new System.EventHandler(this.howto_user_coordinates_Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
    }
}

