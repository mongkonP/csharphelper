using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

using howto_randomly_colored_sierpinski_pentagon;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_randomly_colored_sierpinski_pentagon_Form1:Form
  { 


        public howto_randomly_colored_sierpinski_pentagon_Form1()
        {
            InitializeComponent();
        }

        // The root of the Pentagon object hierarchy.
        private Pentagon Root = null;

        // Redraw.
        private void nudDepth_ValueChanged(object sender, EventArgs e)
        {
            MakePentagons();
        }

        // Make the Pentagon objects and redraw.
        private void MakePentagons()
        {
            // Build the Root.
            int depth = (int)nudDepth.Value;
            PointF center = new PointF(
                picPentagon.ClientSize.Width / 2,
                picPentagon.ClientSize.Height / 2);
            float radius = (float)Math.Min(center.X, center.Y);
            Root = MakePentagon(depth, center, radius);

            // Redraw.
            picPentagon.Refresh();
        }

        // Scale factor for moving to smaller pentagons.
        private float size_scale = (float)(1.0 / (2.0 * (1 + Math.Cos(Math.PI / 180 * 72))));

        // Recursively generate a Pentagon and its descendants.
        private Pentagon MakePentagon(int depth, PointF center, float radius)
        {
            // Make the Pentagon.
            Pentagon parent = new Pentagon(GetPentagonPoints(center, radius));

            // If we are not done recursing, make children.
            if (depth > 0)
            {
                // Find the smaller pentagons' centers.
                float d = radius - radius * size_scale;
                PointF[] centers = GetPentagonPoints(center, d);

                // Recursively draw the smaller pentagons.
                foreach (PointF point in centers)
                {
                    parent.Children.Add(MakePentagon(
                        depth - 1, point, radius * size_scale));
                }
            }

            return parent;
        }

        // Find the pentagon's corners.
        private PointF[] GetPentagonPoints(PointF center, float radius)
        {
            PointF[] points = new PointF[5];
            double theta = -Math.PI / 2.0;
            double dtheta = 2.0 * Math.PI / 5.0;
            for (int i = 0; i < 5; i++)
            {
                points[i] = new PointF(
                    center.X + (float)(radius * Math.Cos(theta)),
                    center.Y + (float)(radius * Math.Sin(theta)));
                theta += dtheta;
            }
            return points;
        }

        // Draw.
        private void picPentagon_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(picPentagon.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            if (Root == null) return;

            Root.Draw(e.Graphics);
        }

        // Draw the initial pentagon.
        private void howto_randomly_colored_sierpinski_pentagon_Form1_Load(object sender, EventArgs e)
        {
            MakePentagons();
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
            this.picPentagon = new System.Windows.Forms.PictureBox();
            this.nudDepth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picPentagon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDepth)).BeginInit();
            this.SuspendLayout();
            // 
            // picPentagon
            // 
            this.picPentagon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picPentagon.BackColor = System.Drawing.Color.White;
            this.picPentagon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPentagon.Location = new System.Drawing.Point(12, 38);
            this.picPentagon.Name = "picPentagon";
            this.picPentagon.Size = new System.Drawing.Size(264, 261);
            this.picPentagon.TabIndex = 5;
            this.picPentagon.TabStop = false;
            this.picPentagon.Paint += new System.Windows.Forms.PaintEventHandler(this.picPentagon_Paint);
            // 
            // nudDepth
            // 
            this.nudDepth.Location = new System.Drawing.Point(57, 12);
            this.nudDepth.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.nudDepth.Name = "nudDepth";
            this.nudDepth.Size = new System.Drawing.Size(46, 20);
            this.nudDepth.TabIndex = 4;
            this.nudDepth.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudDepth.ValueChanged += new System.EventHandler(this.nudDepth_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Depth:";
            // 
            // howto_randomly_colored_sierpinski_pentagon_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 311);
            this.Controls.Add(this.picPentagon);
            this.Controls.Add(this.nudDepth);
            this.Controls.Add(this.label1);
            this.Name = "howto_randomly_colored_sierpinski_pentagon_Form1";
            this.Text = "howto_randomly_colored_sierpinski_pentagon";
            this.Load += new System.EventHandler(this.howto_randomly_colored_sierpinski_pentagon_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPentagon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDepth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPentagon;
        private System.Windows.Forms.NumericUpDown nudDepth;
        private System.Windows.Forms.Label label1;
    }
}

