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
     public partial class howto_plot_level_curves_Form1:Form
  { 


        public howto_plot_level_curves_Form1()
        {
            InitializeComponent();
        }

        // The function type.
        private delegate float FofXY(float x, float y);

        // Draw level curves for this function.
        private void DrawLevelCurves(FofXY func, float zmin, float zmax, float dz)
        {
            this.Cursor = Cursors.WaitCursor;

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
                using (Pen axis_pen = new Pen(Color.Gray, 0))
                {
                    gr.DrawLine(axis_pen, -6, 0, 6, 0);
                    gr.DrawLine(axis_pen, 0, -6, 0, 6);
                    for (int i = -6; i <= 6; i++)
                    {
                        gr.DrawLine(axis_pen, i, -0.1f, i, 0.1f);
                        gr.DrawLine(axis_pen, -0.1f, i, 0.1f, i);
                    }
                }

                // Draw the level curves.
                float dx = 2f / bm.Width;
                float dy = 2f / bm.Height;
                for (float z = zmin; z <= zmax; z += dz)
                {
                    DrawLevelCurve(gr, func, z, dx, dy);
                }
            } // using gr.

            // Display the result.
            picGraph.Image = bm;
            this.Cursor = Cursors.Default;
        }

        // Plot a function.
        private void DrawLevelCurve(Graphics gr, FofXY func, float z, float dx, float dy)
        {
            // Console.WriteLine("z = " + z.ToString());

            // Plot the function.
            using (Pen thin_pen = new Pen(Color.Black, 0))
            {
                // Red for z < 0, blue for z > 0.
                if (z < 0)
                {
                    thin_pen.Color = Color.Red;
                }
                else if (z > 0)
                {
                    thin_pen.Color = Color.Blue;
                }

                // Horizontal comparisons.
                for (float x = -6f; x <= 6f; x += dx)
                {
                    float last_y = z - func(x, -6f);
                    for (float y = -6f + dy; y <= 6f; y += dy)
                    {
                        float next_y = z - func(x, y);
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
                for (float y = -6f + dy; y <= 6f; y += dy)
                {
                    float last_x = z - func(-6f, y);
                    for (float x = -6f; x <= 6f; x += dx)
                    {
                        float next_x = z - func(x, y);
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

        // Bowl.
        private float F1(float x, float y)
        {
            return x * x + (y * 2) * (y * 2) - 75;
        }

        // Monkey saddle.
        private float F2(float x, float y)
        {
            return x * (x * x - 3 * y * y);
        }

        // Crossed trough.
        private float F3(float x, float y)
        {
            return x * x * y * y;
        }

        // Hemisphere.
        private float F4(float x, float y)
        {
            return (float)Math.Sqrt(25 - (x * x + y * y));
        }

        // Bowl.
        private void radF1_Click(object sender, EventArgs e)
        {
            DrawLevelCurves(F1, -75, 65, 20);
        }

        private void radF2_Click(object sender, EventArgs e)
        {
            DrawLevelCurves(F2, -200, 200, 40);
        }

        private void radF3_Click(object sender, EventArgs e)
        {
            DrawLevelCurves(F3, 0, 800, 100);
        }

        private void radF4_Click(object sender, EventArgs e)
        {
            DrawLevelCurves(F4, 0, 5, 0.75f);
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
            this.radF4 = new System.Windows.Forms.RadioButton();
            this.radF3 = new System.Windows.Forms.RadioButton();
            this.radF2 = new System.Windows.Forms.RadioButton();
            this.radF1 = new System.Windows.Forms.RadioButton();
            this.picGraph = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // radF4
            // 
            this.radF4.AutoSize = true;
            this.radF4.Location = new System.Drawing.Point(12, 81);
            this.radF4.Name = "radF4";
            this.radF4.Size = new System.Drawing.Size(185, 17);
            this.radF4.TabIndex = 17;
            this.radF4.TabStop = true;
            this.radF4.Text = "Hemisphere: Sqrt(25 - (x^2 + y^2))";
            this.radF4.UseVisualStyleBackColor = true;
            this.radF4.Click += new System.EventHandler(this.radF4_Click);
            // 
            // radF3
            // 
            this.radF3.AutoSize = true;
            this.radF3.Location = new System.Drawing.Point(12, 58);
            this.radF3.Name = "radF3";
            this.radF3.Size = new System.Drawing.Size(146, 17);
            this.radF3.TabIndex = 16;
            this.radF3.TabStop = true;
            this.radF3.Text = "Crossed trough: x^2 * y^2";
            this.radF3.UseVisualStyleBackColor = true;
            this.radF3.Click += new System.EventHandler(this.radF3_Click);
            // 
            // radF2
            // 
            this.radF2.AutoSize = true;
            this.radF2.Location = new System.Drawing.Point(12, 35);
            this.radF2.Name = "radF2";
            this.radF2.Size = new System.Drawing.Size(183, 17);
            this.radF2.TabIndex = 15;
            this.radF2.TabStop = true;
            this.radF2.Text = "Monkey saddle: x * (x^2 - 3 * y^2)";
            this.radF2.UseVisualStyleBackColor = true;
            this.radF2.Click += new System.EventHandler(this.radF2_Click);
            // 
            // radF1
            // 
            this.radF1.AutoSize = true;
            this.radF1.Location = new System.Drawing.Point(12, 12);
            this.radF1.Name = "radF1";
            this.radF1.Size = new System.Drawing.Size(154, 17);
            this.radF1.TabIndex = 14;
            this.radF1.TabStop = true;
            this.radF1.Text = "Bowl: z = x^2 + (y*2)^2 - 75";
            this.radF1.UseVisualStyleBackColor = true;
            this.radF1.Click += new System.EventHandler(this.radF1_Click);
            // 
            // picGraph
            // 
            this.picGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraph.Location = new System.Drawing.Point(219, 12);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(260, 260);
            this.picGraph.TabIndex = 13;
            this.picGraph.TabStop = false;
            // 
            // howto_plot_level_curves_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 284);
            this.Controls.Add(this.radF4);
            this.Controls.Add(this.radF3);
            this.Controls.Add(this.radF2);
            this.Controls.Add(this.radF1);
            this.Controls.Add(this.picGraph);
            this.Name = "howto_plot_level_curves_Form1";
            this.Text = "howto_plot_level_curves";
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radF4;
        private System.Windows.Forms.RadioButton radF3;
        private System.Windows.Forms.RadioButton radF2;
        private System.Windows.Forms.RadioButton radF1;
        private System.Windows.Forms.PictureBox picGraph;

    }
}

