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
     public partial class howto_plot_heart2_Form1:Form
  { 


        public howto_plot_heart2_Form1()
        {
            InitializeComponent();
        }

        // Plot the equations.
        private void howto_plot_heart2_Form1_Load(object sender, EventArgs e)
        {
            // Make the Bitmap.
            Bitmap bm = new Bitmap(picGraph.ClientSize.Width, picGraph.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                // Clear.
                gr.Clear(Color.White);

                Rectangle rect = new Rectangle(-2, -2, 4, 4);
                Point[] pts = new Point[] 
                { 
                    new Point(0, picGraph.ClientSize.Height),
                    new Point(picGraph.ClientSize.Width, picGraph.ClientSize.Height), 
                    new Point(0, 0)
                };
                gr.Transform = new Matrix(rect, pts);

                // Draw axes.
                using (Pen axis_pen = new Pen(Color.Gray, 0))
                {
                    gr.DrawLine(axis_pen, -2, 0, 2, 0);
                    gr.DrawLine(axis_pen, 0, -2, 0, 2);
                    for (int i = -2; i <= 2; i++)
                    {
                        gr.DrawLine(axis_pen, i, -0.1f, i, 0.1f);
                        gr.DrawLine(axis_pen, -0.1f, i, 0.1f, i);
                    }
                }

                // Graph the equations.
                float dx = 2f / bm.Width;
                float dy = 2f / bm.Height;
                PlotFunction(gr, HeartFunc, dx, dy);
            } // using gr.

            // Display the result.
            picGraph.Image = bm;
        }

        private delegate float FofXY(float x, float y);

        // Plot a function.
        private void PlotFunction(Graphics gr, FofXY func, float dx, float dy)
        {
            // Plot the function.
            using (Pen thin_pen = new Pen(Color.Black, 0))
            {
                // Horizontal comparisons.
                for (float x = -2f; x <= 2f; x += dx)
                {
                    float last_y = func(x, -2f);
                    for (float y = -2f + dy; y <= 2f; y += dy)
                    {
                        float next_y = func(x, y);
                        if (
                            ((last_y <= 0f) && (next_y >= 0f)) ||
                            ((last_y >= 0f) && (next_y <= 0f))
                           )
                        {
                            // Plot this point.
                            gr.DrawLine(thin_pen, x, y - dy, x, y);
                        }
                        last_y = next_y;
                    }
                } // Horizontal comparisons.

                // Vertical comparisons.
                for (float y = -2f + dy; y <= 2f; y += dy)
                {
                    float last_x = func(-2f, y);
                    for (float x = -2f; x <= 2f; x += dx)
                    {
                        float next_x = func(x, y);
                        if (
                            ((last_x <= 0f) && (next_x >= 0f)) ||
                            ((last_x >= 0f) && (next_x <= 0f))
                           )
                        {
                            // Plot this point.
                            gr.DrawLine(thin_pen, x - dx, y, x, y);
                        }
                        last_x = next_x;
                    }
                } // Vertical comparisons.
            } // using thin_pen.
        }

        // The function.
        private float HeartFunc(float x, float y)
        {
            double a = x * x;
            double b = y - Math.Pow(x * x, (double)1 / 3);
            return (float)(a + b * b - 1);
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
            this.picGraph.Location = new System.Drawing.Point(12, 12);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(260, 260);
            this.picGraph.TabIndex = 3;
            this.picGraph.TabStop = false;
            // 
            // howto_plot_heart2_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 284);
            this.Controls.Add(this.picGraph);
            this.Name = "howto_plot_heart2_Form1";
            this.Text = "howto_plot_heart2";
            this.Load += new System.EventHandler(this.howto_plot_heart2_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picGraph;
    }
}

