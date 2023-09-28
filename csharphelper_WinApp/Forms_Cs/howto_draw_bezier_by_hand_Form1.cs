using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

using howto_draw_bezier_by_hand;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_draw_bezier_by_hand_Form1:Form
  { 


        public howto_draw_bezier_by_hand_Form1()
        {
            InitializeComponent();
        }

        // The end points are points 0 and 3. 
        // The interior control points are points 1 and 2.
        private PointF[] Points = new PointF[4];

        // The index of the next point to define.
        private int NextPoint = 0;

        // Select a point.
        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            // If we're starting a new set of four points,
            // get the first point.
            if (NextPoint > 3) NextPoint = 0;

            // Save this point.
            Points[NextPoint].X = e.X;
            Points[NextPoint].Y = e.Y;

            // Move to the next point.
            NextPoint++;

            // Redraw.
            picCanvas.Refresh();
        }

        // Draw the currently selected points. 
        // If we have four points, draw the Bezier curve.
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(picCanvas.BackColor);
            if (NextPoint >= 4)
            {
                // Draw a spline the easy way.
                using (Pen thick_pen = new Pen(Color.Yellow, 7))
                {
                    e.Graphics.DrawBezier(thick_pen,
                        Points[0], Points[1], Points[2], Points[3]);
                }

                // Draw a spline the hard way.
                BezierStuff.DrawBezier(e.Graphics, Pens.Black, 0.01f,
                    Points[0], Points[1], Points[2], Points[3]);
            }

            // Draw the control points.
            for (int i = 0; i < NextPoint; i++)
            {
                e.Graphics.FillRectangle(Brushes.White, Points[i].X - 3, Points[i].Y - 3, 6, 6);
                e.Graphics.DrawRectangle(Pens.Black, Points[i].X - 3, Points[i].Y - 3, 6, 6);
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
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(12, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(310, 237);
            this.picCanvas.TabIndex = 1;
            this.picCanvas.TabStop = false;
            this.picCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseClick);
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // howto_draw_bezier_by_hand_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 261);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_draw_bezier_by_hand_Form1";
            this.Text = "howto_draw_bezier_by_hand";
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
    }
}

