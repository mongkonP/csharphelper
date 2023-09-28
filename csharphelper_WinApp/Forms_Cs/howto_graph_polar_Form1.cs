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
     public partial class howto_graph_polar_Form1:Form
  { 


        public howto_graph_polar_Form1()
        {
            InitializeComponent();
        }

        // Draw the graph.
        private void howto_graph_polar_Form1_Load(object sender, EventArgs e)
        {
            // Make the Bitmap and associated Graphics object.
            Bitmap bm = new Bitmap(300, 300);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(Color.White);

                // Set up a transformation to map the region
                // -2.1 <= X <= 2.1, -2.1 <= Y <= 2.1 onto the  Bitmap.
                RectangleF rect = new RectangleF(-2.1f, -2.1f, 4.2f, 4.2f);
                PointF[] pts =
                    {
                        new PointF(0, bm.Height),
                        new PointF(bm.Width, bm.Height),
                        new PointF(0, 0),
                    };
                gr.Transform = new Matrix(rect, pts);
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                using (Pen thin_pen = new Pen(Color.Blue, 0))
                {
                    // Draw the X and Y axes.
                    thin_pen.Color = Color.Blue;
                    gr.DrawLine(thin_pen, -2.1f, 0, 2.1f, 0);
                    const float big_tick = 0.1f;
                    const float small_tick = 0.05f;
                    for (float x = (int)-2.1f; x <= 2.1f; x += 1)
                        gr.DrawLine(thin_pen, x, -small_tick, x, small_tick);
                    for (float x = (int)-2.1f + 0.5f; x <= 2.1f; x += 1)
                        gr.DrawLine(thin_pen, x, -big_tick, x, big_tick);

                    gr.DrawLine(thin_pen, 0, -2.1f, 0, 2.1f);
                    for (float y = (int)-2.1f; y <= 2.1f; y += 1)
                        gr.DrawLine(thin_pen, -small_tick, y, small_tick, y);
                    for (float y = (int)-2.1f + 0.5f; y <= 2.1f; y += 1)
                        gr.DrawLine(thin_pen, -big_tick, y, big_tick, y);

                    // Draw the graph.
                    DrawGraph(gr);
                }
            }

            // Display the result and size the form to fit.
            picGraph.Image = bm;
            this.ClientSize = new Size(
                picGraph.Width + 2 * picGraph.Left,
                picGraph.Height + 2 * picGraph.Top);
        }

        // Draw the graph on a Bitmap.
        private void DrawGraph(Graphics gr)
        {
            // Generate the points.
            double t = 0;
            const double dt = Math.PI / 100.0;
            const double two_pi = 2 * Math.PI;
            List<PointF> points = new List<PointF>();
            while (t <= two_pi)
            {
                double r = 2 * Math.Sin(5 * t);
                float x = (float)(r * Math.Cos(t));
                float y = (float)(r * Math.Sin(t));
                points.Add(new PointF(x, y));
                t += dt;
            }

            // Draw the curve.
            using (Pen thin_pen = new Pen(Color.Red, 0))
            {
                gr.DrawPolygon(thin_pen, points.ToArray());
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
            this.picGraph = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // picGraph
            // 
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraph.Location = new System.Drawing.Point(12, 10);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(260, 240);
            this.picGraph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picGraph.TabIndex = 1;
            this.picGraph.TabStop = false;
            // 
            // howto_graph_polar_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.picGraph);
            this.Name = "howto_graph_polar_Form1";
            this.Text = "howto_graph_polar";
            this.Load += new System.EventHandler(this.howto_graph_polar_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picGraph;
    }
}

