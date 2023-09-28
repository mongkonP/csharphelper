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
     public partial class howto_circle_pattern_Form1:Form
  { 


        public howto_circle_pattern_Form1()
        {
            InitializeComponent();
        }

        private void howto_circle_pattern_Form1_Load(object sender, EventArgs e)
        {
            picCanvas.Image = DrawPattern(
                picCanvas.ClientSize.Width,
                picCanvas.ClientSize.Height);
        }
        private void howto_circle_pattern_Form1_Resize(object sender, EventArgs e)
        {
            picCanvas.Image = DrawPattern(
                picCanvas.ClientSize.Width,
                picCanvas.ClientSize.Height);
        }

        // Draw the pattern.
        private Bitmap DrawPattern(int wid, int hgt)
        {
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                float margin = 10;
                float diameter1 = (hgt - margin) / 5f;
                float diameter2 = (wid - margin) / (float)(1 + 2 * Math.Sqrt(3));
                float diameter = Math.Min(diameter1, diameter2);

                float radius = diameter / 2f;
                float cx = wid / 2f;
                float cy = hgt / 2f;

                // Find the center circle's center.
                List<PointF> centers = new List<PointF>();
                centers.Add(new PointF(cx, cy));

                // Add the other circles.
                for (int ring_num = 0; ring_num < 2; ring_num++)
                {
                    float ring_radius = diameter * (ring_num + 1);
                    double theta = Math.PI / 2.0;
                    double dtheta = Math.PI / 3.0;
                    for (int i = 0; i < 6; i++)
                    {
                        double x = cx + ring_radius * Math.Cos(theta);
                        double y = cy + ring_radius * Math.Sin(theta);
                        centers.Add(new PointF((float)x, (float)y));
                        theta += dtheta;
                    }
                }

                // Fill and outline the circles.
                foreach (PointF center in centers)
                {
                    float x = center.X - radius;
                    float y = center.Y - radius;
                    gr.FillEllipse(Brushes.LightBlue, x, y, diameter, diameter);
                    gr.DrawEllipse(Pens.Blue, x, y, diameter, diameter);
                }

                // Connect the circle centers.
                int num_circles = centers.Count;
                for (int i = 0; i < num_circles; i++)
                {
                    for (int j = i + 1; j < num_circles; j++)
                    {
                        gr.DrawLine(Pens.Blue, centers[i], centers[j]);
                    }
               }
            }

            return bm;
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
            this.picCanvas.Size = new System.Drawing.Size(260, 287);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            // 
            // howto_circle_pattern_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 311);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_circle_pattern_Form1";
            this.Text = "howto_circle_pattern";
            this.Load += new System.EventHandler(this.howto_circle_pattern_Form1_Load);
            this.Resize += new System.EventHandler(this.howto_circle_pattern_Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
    }
}

