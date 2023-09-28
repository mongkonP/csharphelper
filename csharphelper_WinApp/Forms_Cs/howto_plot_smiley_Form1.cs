using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_plot_smiley_Form1:Form
  { 


        public howto_plot_smiley_Form1()
        {
            InitializeComponent();
        }

        private delegate float FofXY(float x, float y);

        // Plot the equations.
        private void howto_plot_smiley_Form1_Load(object sender, EventArgs e)
        {
            // Make the Bitmap.
            Bitmap bm = new Bitmap(picGraph.ClientSize.Width, picGraph.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                // Clear.
                gr.Clear(Color.White);
                gr.ScaleTransform(24f, -24f, System.Drawing.Drawing2D.MatrixOrder.Append);
                gr.TranslateTransform(bm.Width * 0.5f, bm.Height * 0.5f,
                    System.Drawing.Drawing2D.MatrixOrder.Append);

                // Draw axes.
                using (Pen axis_pen = new Pen(Color.Blue, 0))
                {
                    gr.DrawLine(axis_pen, -6, 0, 6, 0);
                    gr.DrawLine(axis_pen, 0, -6, 0, 6);
                    for (int i = -6; i <= 6; i++)
                    {
                        gr.DrawLine(axis_pen, i, -0.1f, i, 0.1f);
                        gr.DrawLine(axis_pen, -0.1f, i, 0.1f, i);
                    }
                }

                // Graph the equations.
                float dx = 2f / bm.Width;
                float dy = 2f / bm.Height;
                PlotFunction(gr, F1, -6, -6, 6, 6, dx, dy);
                PlotFunction(gr, F2, -6, -6, 6, 6, dx, dy);
            } // using gr.

            // Display the result.
            picGraph.Image = bm;
        }

        // Plot a function.
        private void PlotFunction(Graphics gr, FofXY func,
            float xmin, float ymin, float xmax, float ymax,
            float dx, float dy)
        {
            // Plot the function.
            using (Pen thin_pen = new Pen(Color.Black, 0))
            {
                // Horizontal comparisons.
                for (float x = xmin; x <= xmax; x += dx)
                {
                    float last_y = func(x, ymin);
                    for (float y = ymin + dy; y <= ymax; y += dy)
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
                for (float y = ymin + dy; y <= ymax; y += dy)
                {
                    float last_x = func(xmin, y);
                    for (float x = xmin + dx; x <= xmax; x += dx)
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

        // Calculate:
        //   [x^2 + y^2 - 225] *
        //   [x^2 + y^2 - 10000] *
        //   [(x - 45)^2 + (y - 35)^2 - 225] *
        //   [(x + 45)^2 + (y - 35)^2 - 225]
        private float F1(float x, float y)
        {
            // Flip y to make the image appear right side up.
            return
                (x * x + y * y - 25f) *
                (x * x + y * y - 1f) *
                ((x - 2.5f) * (x - 2.5f) + (y - 2.0f) * (y - 2.0f) - 1f) *
                ((x + 2.5f) * (x + 2.5f) + (y - 2.0f) * (y - 2.0f) - 1f);
        }

        // Calculate:
        //   y + Sqrt(16 - x^2)
        private float F2(float x, float y)
        {
            return (float)(y + Math.Sqrt(12.25f - x * x));
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
            this.picGraph.TabIndex = 1;
            this.picGraph.TabStop = false;
            // 
            // howto_plot_smiley_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 284);
            this.Controls.Add(this.picGraph);
            this.Name = "howto_plot_smiley_Form1";
            this.Text = "howto_plot_smiley";
            this.Load += new System.EventHandler(this.howto_plot_smiley_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picGraph;
    }
}

