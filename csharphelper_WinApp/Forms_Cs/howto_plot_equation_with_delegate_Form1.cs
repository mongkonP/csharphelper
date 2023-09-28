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
     public partial class howto_plot_equation_with_delegate_Form1:Form
  { 


        public howto_plot_equation_with_delegate_Form1()
        {
            InitializeComponent();
        }

        // Define a delegate type named FofXY.
        private delegate float FofXY(float x, float y);

        // Draw the indicated function.
        private void DrawGraph(FofXY func)
        {
            this.Cursor = Cursors.WaitCursor;

            // Make the Bitmap.
            Bitmap bm = new Bitmap(picGraph.ClientSize.Width, picGraph.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                // Clear.
                gr.Clear(Color.White);
                gr.ScaleTransform(15f, -15f, System.Drawing.Drawing2D.MatrixOrder.Append);
                gr.TranslateTransform(bm.Width * 0.5f, bm.Height * 0.5f,
                    System.Drawing.Drawing2D.MatrixOrder.Append);

                // Draw axes.
                using (Pen axis_pen = new Pen(Color.LightGray, 0))
                {
                    gr.DrawLine(axis_pen, -8, 0, 8, 0);
                    gr.DrawLine(axis_pen, 0, -8, 0, 8);
                    for (int i = -8; i <= 8; i++)
                    {
                        gr.DrawLine(axis_pen, i, -0.1f, i, 0.1f);
                        gr.DrawLine(axis_pen, -0.1f, i, 0.1f, i);
                    }
                }

                // Graph the equation.
                float dx = 2f / bm.Width;
                float dy = 2f / bm.Height;
                PlotFunction(gr, func, -8, -8, 8, 8, dx, dy);
            } // using gr.

            // Display the result.
            picGraph.Image = bm;
            this.Cursor = Cursors.Default;
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

        // The functions.
        // x^2 + x*y - y = 0
        private float F1(float x, float y)
        {
            return (x * x + x * y - y);
        }

        // y - 1 / x^2 = 0
        private float F2(float x, float y)
        {
            return (y - 1 / (x * x));
        }

        // x^2 + (2 * y)^2 - 49 = 0
        private float F3(float x, float y)
        {
            return (x * x + (2 * y) * (2 * y) - 49);
        }

        // y - 3 * Cos(x) / x
        private float F4(float x, float y)
        {
            return (float)(y - 3 * Math.Cos(x) / x);
        }

        // Draw the appropriate graph.
        private void radF1_CheckedChanged(object sender, EventArgs e)
        {
            DrawGraph(F1);
        }

        private void radF2_CheckedChanged(object sender, EventArgs e)
        {
            DrawGraph(F2);
        }

        private void radF3_CheckedChanged(object sender, EventArgs e)
        {
            DrawGraph(F3);
        }

        private void radF4_CheckedChanged(object sender, EventArgs e)
        {
            DrawGraph(F4);
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
            this.radF1 = new System.Windows.Forms.RadioButton();
            this.radF2 = new System.Windows.Forms.RadioButton();
            this.radF4 = new System.Windows.Forms.RadioButton();
            this.radF3 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // picGraph
            // 
            this.picGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraph.Location = new System.Drawing.Point(178, 12);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(260, 260);
            this.picGraph.TabIndex = 4;
            this.picGraph.TabStop = false;
            // 
            // radF1
            // 
            this.radF1.AutoSize = true;
            this.radF1.Location = new System.Drawing.Point(12, 12);
            this.radF1.Name = "radF1";
            this.radF1.Size = new System.Drawing.Size(100, 17);
            this.radF1.TabIndex = 5;
            this.radF1.TabStop = true;
            this.radF1.Text = "x^2 + x*y - y = 0";
            this.radF1.UseVisualStyleBackColor = true;
            this.radF1.CheckedChanged += new System.EventHandler(this.radF1_CheckedChanged);
            // 
            // radF2
            // 
            this.radF2.AutoSize = true;
            this.radF2.Location = new System.Drawing.Point(12, 35);
            this.radF2.Name = "radF2";
            this.radF2.Size = new System.Drawing.Size(91, 17);
            this.radF2.TabIndex = 6;
            this.radF2.TabStop = true;
            this.radF2.Text = "y - 1 / x^2 = 0";
            this.radF2.UseVisualStyleBackColor = true;
            this.radF2.CheckedChanged += new System.EventHandler(this.radF2_CheckedChanged);
            // 
            // radF4
            // 
            this.radF4.AutoSize = true;
            this.radF4.Location = new System.Drawing.Point(12, 81);
            this.radF4.Name = "radF4";
            this.radF4.Size = new System.Drawing.Size(100, 17);
            this.radF4.TabIndex = 8;
            this.radF4.TabStop = true;
            this.radF4.Text = "y - 3 * Cos(x) / x";
            this.radF4.UseVisualStyleBackColor = true;
            this.radF4.CheckedChanged += new System.EventHandler(this.radF4_CheckedChanged);
            // 
            // radF3
            // 
            this.radF3.AutoSize = true;
            this.radF3.Location = new System.Drawing.Point(12, 58);
            this.radF3.Name = "radF3";
            this.radF3.Size = new System.Drawing.Size(127, 17);
            this.radF3.TabIndex = 7;
            this.radF3.TabStop = true;
            this.radF3.Text = "x^2 + (y/2)^2 - 49 = 0";
            this.radF3.UseVisualStyleBackColor = true;
            this.radF3.CheckedChanged += new System.EventHandler(this.radF3_CheckedChanged);
            // 
            // howto_plot_equation_with_delegate_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 284);
            this.Controls.Add(this.radF4);
            this.Controls.Add(this.radF3);
            this.Controls.Add(this.radF2);
            this.Controls.Add(this.radF1);
            this.Controls.Add(this.picGraph);
            this.Name = "howto_plot_equation_with_delegate_Form1";
            this.Text = "howto_plot_equation_with_delegate";
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.RadioButton radF1;
        private System.Windows.Forms.RadioButton radF2;
        private System.Windows.Forms.RadioButton radF4;
        private System.Windows.Forms.RadioButton radF3;
    }
}

