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
     public partial class howto_colored_curves_Form1:Form
  { 


        public howto_colored_curves_Form1()
        {
            InitializeComponent();
        }

        private Point[] Points = null;

        private void howto_colored_curves_Form1_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            Points = new Point[20];
            for (int i = 0; i < Points.Length; i++)
            {
                Points[i] = new Point(
                    i * 5,
                    rand.Next(5, 96));
            }
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF world_rect = new RectangleF(0, 0, 100, 100);
            RectangleF device_rect = new RectangleF(5, 5,
                picCanvas.ClientSize.Width - 10,
                picCanvas.ClientSize.Height - 10);
            SetTransformation(e.Graphics, world_rect, device_rect, false, true);

            // Draw the axes.
            using (Pen pen = new Pen(Color.Black, 0))
            {
                for (int y = 10; y < 100; y += 10)
                    e.Graphics.DrawLine(pen, -2, y, 2, y);
                e.Graphics.DrawLine(pen, 0, 0, 0, 100);

                for (int x = 10; x < 100; x += 10)
                    e.Graphics.DrawLine(pen, x, -2, x, 2);
                e.Graphics.DrawLine(pen, 0, 0, 100, 0);
            }

            // Make a brush for the curve.
            using (LinearGradientBrush brush =
                new LinearGradientBrush(world_rect,
                    Color.Red, Color.Blue, 270))
            {
                ColorBlend blend = new ColorBlend();
                blend.Colors = new Color[]
                {
                    Color.Red,
                    Color.Orange,
                    Color.Yellow,
                    Color.Green,
                    Color.Blue,
                };
                blend.Positions =
                    new float[] { 0.0f, 0.2f, 0.4f, 0.6f, 1.0f, };
                brush.InterpolationColors = blend;

                // Make a thick pen defined by the brush.
                using (Pen pen = new Pen(brush, 3))
                {
                    pen.LineJoin = LineJoin.Bevel;

                    // Draw the curve.
                    if (chkCurved.Checked)
                        e.Graphics.DrawCurve(pen, Points);
                    else
                        e.Graphics.DrawLines(pen, Points);

                    //// Draw a vertical line on the edge to show the colors.
                    //e.Graphics.DrawLine(pen, 100, 0, 100, 100);
                }
            }
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

        private void chkCurved_CheckedChanged(object sender, EventArgs e)
        {
            picCanvas.Refresh();
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
            this.chkCurved = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(12, 35);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(260, 260);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // chkCurved
            // 
            this.chkCurved.AutoSize = true;
            this.chkCurved.Location = new System.Drawing.Point(12, 12);
            this.chkCurved.Name = "chkCurved";
            this.chkCurved.Size = new System.Drawing.Size(60, 17);
            this.chkCurved.TabIndex = 1;
            this.chkCurved.Text = "Curved";
            this.chkCurved.UseVisualStyleBackColor = true;
            this.chkCurved.CheckedChanged += new System.EventHandler(this.chkCurved_CheckedChanged);
            // 
            // howto_colored_curves_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 309);
            this.Controls.Add(this.chkCurved);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_colored_curves_Form1";
            this.Text = "howto_colored_curves";
            this.Load += new System.EventHandler(this.howto_colored_curves_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.CheckBox chkCurved;
    }
}

