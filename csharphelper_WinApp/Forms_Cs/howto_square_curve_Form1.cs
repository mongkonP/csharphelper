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
     public partial class howto_square_curve_Form1:Form
  { 


        public howto_square_curve_Form1()
        {
            InitializeComponent();
        }

        private void btnGraph_Click(object sender, EventArgs e)
        {
            // Make the Bitmap and associated Graphics object.
            int wid = picGraph.ClientSize.Width;
            int hgt = picGraph.ClientSize.Height;
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(Color.White);

                // Set up a transformation to map
                // the region onto the  Bitmap.
                const float xmin = -1.6f;
                const float xmax = 1.6f;
                const float ymin = -1.6f;
                const float ymax = 1.6f;
                RectangleF rect = new RectangleF(xmin, ymin,
                    xmax - xmin, ymax - ymin);
                PointF[] pts =
                    {
                        new PointF(0, hgt),
                        new PointF(wid, hgt),
                        new PointF(0, 0),
                    };
                gr.Transform = new Matrix(rect, pts);
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                using (Pen thin_pen = new Pen(Color.Blue, 0))
                {
                    // Draw the X and Y axes.
                    thin_pen.Color = Color.Blue;
                    gr.DrawLine(thin_pen, xmin, 0, xmax, 0);
                    const float big_tick = 0.1f;
                    const float small_tick = 0.05f;
                    for (float x = (int)xmin - 1; x <= xmax; x += 1)
                        gr.DrawLine(thin_pen, x, -big_tick, x, big_tick);
                    for (float x = (int)xmin - 0.5f; x <= xmax; x += 1)
                        gr.DrawLine(thin_pen, x, -small_tick, x, small_tick);

                    gr.DrawLine(thin_pen, 0, ymin, 0, ymax);
                    for (float y = (int)ymin - 1; y <= ymax; y += 1)
                        gr.DrawLine(thin_pen, -big_tick, y, big_tick, y);
                    for (float y = (int)ymin - 0.5f; y <= ymax; y += 1)
                        gr.DrawLine(thin_pen, -small_tick, y, small_tick, y);

                    // Draw a square.
                    //gr.DrawRectangle(thin_pen, -1, -1, 2, 2);

                    // Draw the graph.
                    thin_pen.Color = Color.Red;
                    DrawGraph(gr, thin_pen, xmin);
                }
            }

            // Display the result.
            picGraph.Image = bm;
        }

        // Draw the curve.
        private void DrawGraph(Graphics gr, Pen pen, float wxmin)
        {
            // Get the power.
            int power = int.Parse(txtPower.Text);
            float root = 1f / power;

            // Even integer power. -1 <= x, y <= 1
            List<PointF> points1 = new List<PointF>();
            List<PointF> points2 = new List<PointF>();
            for (float x = -1f; x <= 1f; x += 0.001f)
            {
                float y = -(float)Math.Pow(1 - Math.Pow(x, power), root);
                points1.Add(new PointF(x, y));
                points2.Add(new PointF(x, -y));
            }

            // Combine the lists.
            points2.Reverse();
            points1.AddRange(points2);

            // Draw the curve.
            gr.DrawPolygon(pen, points1.ToArray());
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
            this.btnGraph = new System.Windows.Forms.Button();
            this.txtPower = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // picGraph
            // 
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraph.Location = new System.Drawing.Point(12, 41);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(276, 276);
            this.picGraph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picGraph.TabIndex = 2;
            this.picGraph.TabStop = false;
            // 
            // btnGraph
            // 
            this.btnGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGraph.Location = new System.Drawing.Point(213, 12);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(75, 23);
            this.btnGraph.TabIndex = 5;
            this.btnGraph.Text = "Graph";
            this.btnGraph.UseVisualStyleBackColor = true;
            this.btnGraph.Click += new System.EventHandler(this.btnGraph_Click);
            // 
            // txtPower
            // 
            this.txtPower.Location = new System.Drawing.Point(86, 14);
            this.txtPower.Name = "txtPower";
            this.txtPower.Size = new System.Drawing.Size(57, 20);
            this.txtPower.TabIndex = 4;
            this.txtPower.Text = "10";
            this.txtPower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Even Power:";
            // 
            // howto_square_curve_Form1
            // 
            this.AcceptButton = this.btnGraph;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 330);
            this.Controls.Add(this.btnGraph);
            this.Controls.Add(this.txtPower);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picGraph);
            this.Name = "howto_square_curve_Form1";
            this.Text = "howto_square_curve";
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.Button btnGraph;
        private System.Windows.Forms.TextBox txtPower;
        private System.Windows.Forms.Label label1;
    }
}

