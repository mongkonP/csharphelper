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
     public partial class howto_curly_tree_Form1:Form
  { 


        public howto_curly_tree_Form1()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                float length_scaleA = float.Parse(txtLengthScale1.Text);
                float length_scaleB = float.Parse(txtLengthScale2.Text);
                float angleA = (float)((double)nudAngle1.Value * Math.PI / 180.0);
                float angleB = (float)((double)nudAngle2.Value * Math.PI / 180.0);
                picCanvas.Image = MakeTree(
                    picCanvas.ClientSize.Width,
                    picCanvas.ClientSize.Height,
                    (int)nudLevel.Value,
                    angleA, angleB,
                    length_scaleA, length_scaleB);
            }
            catch
            {
            }
            Cursor = Cursors.Default;
        }

        // Make the tree. The angles are in radians.
        private Bitmap MakeTree(int width, int height, int level,
            float angleA, float angleB,
            float length_scaleA, float length_scaleB)
        {
            // Make the line segments.
            List<PointF> start_points = new List<PointF>();
            List<PointF> end_points = new List<PointF>();
            float start_length = picCanvas.ClientSize.Height * 0.33f;
            const float start_thickness = 10;
            const float start_direction = (float)(Math.PI * 0.5);
            FindTreePoints(start_points, end_points,
                0, 0, start_direction, level, start_length,
                angleA, angleB, length_scaleA, length_scaleB);

            // Find the tree's bounds.
            float xmin = start_points[0].X;
            float xmax = xmin;
            float ymin = start_points[0].Y;
            float ymax = ymin;
            foreach (PointF point in end_points)
            {
                if (xmin > point.X) xmin = point.X;
                if (xmax < point.X) xmax = point.X;
                if (ymin > point.Y) ymin = point.Y;
                if (ymax < point.Y) ymax = point.Y;
            }

            // Make the bitmap.
            Bitmap bm = new Bitmap(
                picCanvas.ClientSize.Width,
                picCanvas.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(picCanvas.BackColor);
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                // Map the tree onto the PictureBox.
                xmin -= start_thickness;
                xmax += start_thickness;
                ymin -= start_thickness;
                ymax += start_thickness;
                RectangleF world_rect = new RectangleF(
                    xmin, ymin, xmax - xmin, ymax - ymin);
                const int margin = 4;
                RectangleF device_rect = new RectangleF(
                    margin, margin,
                    picCanvas.ClientSize.Width - 2 * margin,
                    picCanvas.ClientSize.Height - 2 * margin);
                SetTransformationWithoutDisortion(gr,
                    world_rect, device_rect, false, true);

                // Draw the tree.
                using (Pen pen = new Pen(Color.Blue, 1))
                {
                    for (int i = 0; i < start_points.Count; i++)
                    {
                        pen.Width = Distance(start_points[i], end_points[i]) / 10f;
                        gr.DrawLine(pen, start_points[i], end_points[i]);
                    }
                }

                //// Mark the root (for debugging).
                //float thickness = start_length / 10f;
                //gr.FillEllipse(Brushes.Red,
                //    start_points[0].X - thickness,
                //    start_points[0].Y - thickness,
                //    2 * thickness,
                //    2 * thickness);
            }
            return bm;
        }

        // Calculate the distance between the points.
        private float Distance(PointF point1, PointF point2)
        {
            float dx = point1.X - point2.X;
            float dy = point1.Y - point2.Y;
            return (float)(Math.Sqrt(dx * dx + dy * dy));
        }

        // Generate segments for the tree.
        // The direction parameter is in radians.
        private void FindTreePoints(
            List<PointF> start_points, List<PointF> end_points,
            float x, float y, float direction, int level,
            float length, float angleA, float angleB,
            float length_scaleA, float length_scaleB)
        {
            // Find the new segment.
            if (length < 0.1) return;
            start_points.Add(new PointF(x, y));
            x += (float)(length * Math.Cos(direction));
            y += (float)(length * Math.Sin(direction));
            end_points.Add(new PointF(x, y));

            if (level > 0)
            {
                FindTreePoints(start_points, end_points,
                    x, y, direction + angleA, level - 1,
                    length * length_scaleA, angleA, angleB,
                    length_scaleA, length_scaleB);
                FindTreePoints(start_points, end_points,
                    x, y, direction + angleB, level - 1,
                    length * length_scaleB, angleA, angleB,
                    length_scaleA, length_scaleB);
            }
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
            SetTransformation(gr, world_rect, device_rect,
                invert_x, invert_y);
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
            this.label1 = new System.Windows.Forms.Label();
            this.nudLevel = new System.Windows.Forms.NumericUpDown();
            this.nudAngle1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudAngle2 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.btnDraw = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLengthScale1 = new System.Windows.Forms.TextBox();
            this.txtLengthScale2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngle1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngle2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Level:";
            // 
            // nudLevel
            // 
            this.nudLevel.Location = new System.Drawing.Point(101, 12);
            this.nudLevel.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudLevel.Name = "nudLevel";
            this.nudLevel.Size = new System.Drawing.Size(53, 20);
            this.nudLevel.TabIndex = 0;
            this.nudLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLevel.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // nudAngle1
            // 
            this.nudAngle1.Location = new System.Drawing.Point(101, 38);
            this.nudAngle1.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudAngle1.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.nudAngle1.Name = "nudAngle1";
            this.nudAngle1.Size = new System.Drawing.Size(53, 20);
            this.nudAngle1.TabIndex = 1;
            this.nudAngle1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudAngle1.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Angle A:";
            // 
            // nudAngle2
            // 
            this.nudAngle2.Location = new System.Drawing.Point(101, 90);
            this.nudAngle2.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudAngle2.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.nudAngle2.Name = "nudAngle2";
            this.nudAngle2.Size = new System.Drawing.Size(53, 20);
            this.nudAngle2.TabIndex = 3;
            this.nudAngle2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudAngle2.Value = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Angle B:";
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(160, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(279, 223);
            this.picCanvas.TabIndex = 6;
            this.picCanvas.TabStop = false;
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(45, 160);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 5;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Length Scale A:";
            // 
            // txtLengthScale1
            // 
            this.txtLengthScale1.Location = new System.Drawing.Point(101, 64);
            this.txtLengthScale1.Name = "txtLengthScale1";
            this.txtLengthScale1.Size = new System.Drawing.Size(53, 20);
            this.txtLengthScale1.TabIndex = 2;
            this.txtLengthScale1.Text = "0.9";
            this.txtLengthScale1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLengthScale2
            // 
            this.txtLengthScale2.Location = new System.Drawing.Point(101, 116);
            this.txtLengthScale2.Name = "txtLengthScale2";
            this.txtLengthScale2.Size = new System.Drawing.Size(53, 20);
            this.txtLengthScale2.TabIndex = 4;
            this.txtLengthScale2.Text = "0.5";
            this.txtLengthScale2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Length Scale B:";
            // 
            // howto_curly_tree_Form1
            // 
            this.AcceptButton = this.btnDraw;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 247);
            this.Controls.Add(this.txtLengthScale2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLengthScale1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.nudAngle2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudAngle1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudLevel);
            this.Controls.Add(this.label1);
            this.Name = "howto_curly_tree_Form1";
            this.Text = "howto_curly_tree";
            ((System.ComponentModel.ISupportInitialize)(this.nudLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngle1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngle2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudLevel;
        private System.Windows.Forms.NumericUpDown nudAngle1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudAngle2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLengthScale1;
        private System.Windows.Forms.TextBox txtLengthScale2;
        private System.Windows.Forms.Label label6;
    }
}

