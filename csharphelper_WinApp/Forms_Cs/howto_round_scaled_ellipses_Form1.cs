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
     public partial class howto_round_scaled_ellipses_Form1:Form
  { 


        public howto_round_scaled_ellipses_Form1()
        {
            InitializeComponent();
        }

        // The drawing transformation and its inverse.
        private Matrix Transform, Inverse;

        // Initialize the drawing transformation.
        private const float XScale = 20;
        private const float YScale = 10;
        private void howto_round_scaled_ellipses_Form1_Load(object sender, EventArgs e)
        {
            // Make the drawing transformation.
            Transform = new Matrix();
            Transform.Scale(XScale, YScale);

            // Make the inverse transformation.
            Inverse = Transform.Clone();
            Inverse.Invert();
        }

        // Draw a scaled grid.
        private void DrawGrid(PictureBox pic, Graphics gr)
        {
            // Draw the grid.
            int hgt = (int)(1 + pic.ClientSize.Height / YScale);
            int wid = (int)(1 + pic.ClientSize.Width / XScale);
            using (Pen thin_pen = new Pen(Color.Blue, 0))
            {
                for (int x = 0; x < wid; x++)
                    gr.DrawLine(thin_pen, x, 0, x, hgt);
                for (int y = 0; y < hgt; y++)
                    gr.DrawLine(thin_pen, 0, y, wid, y);
            }
        }

        // The clicked points.
        private List<PointF> PointsClicked = new List<PointF>();

        // Draw the grid and any clicked points.
        private void picNormal_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Transform = Transform;

            // Draw the grid.
            DrawGrid(picNormal, e.Graphics);

            // If there are no points, do nothing else.
            if (PointsClicked.Count == 0) return;

            // Draw the points.
            foreach (PointF point in PointsClicked)
            {
                e.Graphics.DrawEllipse(Pens.Red, point.X - 1, point.Y - 1, 2, 2);
            }
        }

        // Draw the grid and any clicked points.
        private void picThinPen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Transform = Transform;

            // Draw the grid.
            DrawGrid(picThinPen, e.Graphics);

            // If there are no points, do nothing else.
            if (PointsClicked.Count == 0) return;

            // Draw the points.
            using (Pen thin_pen = new Pen(Color.Red, 0))
            {
                foreach (PointF point in PointsClicked)
                    e.Graphics.DrawEllipse(thin_pen,
                        point.X - 1, point.Y - 1, 2, 2);
            }
        }

        // Draw the grid and any clicked points.
        private void picRound_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Transform = Transform;

            // Draw the grid.
            DrawGrid(picNormal, e.Graphics);

            // If there are no points, do nothing else.
            if (PointsClicked.Count == 0) return;

            // Reset the Graphics object's transformation.
            e.Graphics.ResetTransform();

            // Draw the points.
            using (Pen thick_pen = new Pen(Color.Red, 3))
            {
                // Use the inverse transform to convert
                // from world coordinates to device coordinates.
                PointF[] points = PointsClicked.ToArray();
                Transform.TransformPoints(points);

                // Draw the points' circles in device coordinates.
                foreach (PointF point in points)
                {
                    e.Graphics.DrawEllipse(thick_pen,
                        point.X - 5, point.Y - 5, 10, 10);
                }
            }
        }

        // Save a clicked point.
        private void pic_MouseClick(object sender, MouseEventArgs e)
        {
            // Transform the point to convert it from
            // device coordinates to world coordinates.
            PointF[] points = { new PointF(e.X, e.Y) };
            Inverse.TransformPoints(points);

            // Save the point's world coordinates.
            PointsClicked.Add(points[0]);

            // Redraw to show the new point.
            picNormal.Refresh();
            picThinPen.Refresh();
            picRound.Refresh();
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
            this.picNormal = new System.Windows.Forms.PictureBox();
            this.picRound = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.picThinPen = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picNormal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThinPen)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scaled:";
            // 
            // picNormal
            // 
            this.picNormal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.picNormal.BackColor = System.Drawing.Color.White;
            this.picNormal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picNormal.Location = new System.Drawing.Point(12, 25);
            this.picNormal.Name = "picNormal";
            this.picNormal.Size = new System.Drawing.Size(150, 224);
            this.picNormal.TabIndex = 1;
            this.picNormal.TabStop = false;
            this.picNormal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pic_MouseClick);
            this.picNormal.Paint += new System.Windows.Forms.PaintEventHandler(this.picNormal_Paint);
            // 
            // picRound
            // 
            this.picRound.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.picRound.BackColor = System.Drawing.Color.White;
            this.picRound.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picRound.Location = new System.Drawing.Point(324, 25);
            this.picRound.Name = "picRound";
            this.picRound.Size = new System.Drawing.Size(150, 224);
            this.picRound.TabIndex = 3;
            this.picRound.TabStop = false;
            this.picRound.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pic_MouseClick);
            this.picRound.Paint += new System.Windows.Forms.PaintEventHandler(this.picRound_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Round:";
            // 
            // picThinPen
            // 
            this.picThinPen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.picThinPen.BackColor = System.Drawing.Color.White;
            this.picThinPen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picThinPen.Location = new System.Drawing.Point(168, 25);
            this.picThinPen.Name = "picThinPen";
            this.picThinPen.Size = new System.Drawing.Size(150, 224);
            this.picThinPen.TabIndex = 5;
            this.picThinPen.TabStop = false;
            this.picThinPen.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pic_MouseClick);
            this.picThinPen.Paint += new System.Windows.Forms.PaintEventHandler(this.picThinPen_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Thin Pen:";
            // 
            // howto_round_scaled_ellipses_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.picThinPen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picRound);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picNormal);
            this.Controls.Add(this.label1);
            this.Name = "howto_round_scaled_ellipses_Form1";
            this.Text = "howto_round_scaled_ellipses";
            this.Load += new System.EventHandler(this.howto_round_scaled_ellipses_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picNormal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThinPen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picNormal;
        private System.Windows.Forms.PictureBox picRound;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picThinPen;
        private System.Windows.Forms.Label label3;
    }
}

