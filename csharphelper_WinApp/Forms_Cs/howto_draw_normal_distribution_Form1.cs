using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Drawing.Text;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_draw_normal_distribution_Form1:Form
  { 


        public howto_draw_normal_distribution_Form1()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            float mean = float.Parse(txtMean.Text);
            float stddev = float.Parse(txtStdDev.Text);
            float var = stddev * stddev;

            // Make a bitmap.
            Bitmap bm = new Bitmap(picGraph.ClientSize.Width, picGraph.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                // Define the mapping from world
                // coordinates onto the PictureBox.
                const float wxmin = -5.1f;
                const float wymin = -0.2f;
                const float wxmax = -wxmin;
                const float wymax = 1.1f;
                const float wwid = wxmax - wxmin;
                const float whgt = wymax - wymin;
                RectangleF world = new RectangleF(wxmin, wymin, wwid, whgt);
                PointF[] device_points =
                {
                    new PointF(0, picGraph.ClientSize.Height),
                    new PointF(picGraph.ClientSize.Width, picGraph.ClientSize.Height),
                    new PointF(0, 0),
                };
                Matrix transform = new Matrix(world, device_points);
 
                // Make a thin Pen to use.
                using (Pen pen = new Pen(Color.Red, 0))
                {
                    using (Font font = new Font("Arial", 8))
                    {
                        // Draw the X axis.
                        gr.Transform = transform;
                        pen.Color = Color.Black;
                        gr.DrawLine(pen, wxmin, 0, wxmax, 0);
                            for (int x = (int)wxmin; x <= wxmax; x++)
                        {
                            gr.DrawLine(pen, x, -0.05f, x, 0.05f);
                            gr.DrawLine(pen, x + 0.25f, -0.025f, x + 0.25f, 0.025f);
                            gr.DrawLine(pen, x + 0.50f, -0.025f, x + 0.50f, 0.025f);
                            gr.DrawLine(pen, x + 0.75f, -0.025f, x + 0.75f, 0.025f);
                        }

                        // Label the X axis.
                        gr.Transform = new Matrix();
                        gr.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                        List<PointF> ints = new List<PointF>();
                        for (int x = (int)wxmin; x <= wxmax; x++)
                            ints.Add(new PointF(x, -0.07f));
                        PointF[] ints_array = ints.ToArray();
                        transform.TransformPoints(ints_array);

                        using (StringFormat sf = new StringFormat())
                        {
                            sf.Alignment = StringAlignment.Center;
                            sf.LineAlignment = StringAlignment.Near;
                            int index = 0;
                            for (int x = (int)wxmin; x <= wxmax; x++)
                            {
                                gr.DrawString(x.ToString(), font, Brushes.Black,
                                    ints_array[index++], sf);
                            }
                        }
                   
                        // Draw the Y axis.
                        gr.Transform = transform;
                        pen.Color = Color.Black;
                        gr.DrawLine(pen, 0, wymin, 0, wymax);
                        for (int y = (int)wymin; y <= wymax; y++)
                        {
                            gr.DrawLine(pen, -0.2f, y, 0.2f, y);
                            gr.DrawLine(pen, -0.1f, y + 0.25f, 0.1f, y + 0.25f);
                            gr.DrawLine(pen, -0.1f, y + 0.50f, 0.1f, y + 0.50f);
                            gr.DrawLine(pen, -0.1f, y + 0.75f, 0.1f, y + 0.75f);
                        }

                        // Label the Y axis.
                        gr.Transform = new Matrix();
                        gr.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                        ints = new List<PointF>();
                        for (float y = 0.25f; y < 1.01; y += 0.25f)
                            ints.Add(new PointF(0.2f, y));
                        ints_array = ints.ToArray();
                        transform.TransformPoints(ints_array);

                        using (StringFormat sf = new StringFormat())
                        {
                            sf.Alignment = StringAlignment.Near;
                            sf.LineAlignment = StringAlignment.Center;
                            int index = 0;
                            foreach (float y in new float[] { 0.25f, 0.5f, 0.75f, 1.0f })
                            {
                                gr.DrawString(y.ToString("0.00"), font, Brushes.Black,
                                    ints_array[index++], sf);
                            }
                        }

                        // Draw the curve.
                        gr.Transform = transform;
                        List<PointF> points = new List<PointF>();
                        float one_over_2pi =
                            (float)(1.0 / (stddev * Math.Sqrt(2 * Math.PI)));

                        float dx = (wxmax - wxmin) / picGraph.ClientSize.Width;
                        for (float x = wxmin; x <= wxmax; x += dx)
                        {
                            float y = F(x, one_over_2pi, mean, stddev, var);
                            points.Add(new PointF(x, y));
                        }
                        pen.Color = Color.Red;
                        gr.DrawLines(pen, points.ToArray());
                    } // Font
                } // Pen

                picGraph.Image = bm;
            }
        }

        // The normal distribution function.
        private float F(float x, float one_over_2pi, float mean, float stddev, float var)
        {
            return (float)(one_over_2pi * Math.Exp(-(x - mean) * (x - mean) / (2 * var)));
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
            this.txtMean = new System.Windows.Forms.TextBox();
            this.txtStdDev = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDraw = new System.Windows.Forms.Button();
            this.picGraph = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mean:";
            // 
            // txtMean
            // 
            this.txtMean.Location = new System.Drawing.Point(67, 12);
            this.txtMean.Name = "txtMean";
            this.txtMean.Size = new System.Drawing.Size(43, 20);
            this.txtMean.TabIndex = 1;
            this.txtMean.Text = "0.0";
            this.txtMean.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtStdDev
            // 
            this.txtStdDev.Location = new System.Drawing.Point(67, 38);
            this.txtStdDev.Name = "txtStdDev";
            this.txtStdDev.Size = new System.Drawing.Size(43, 20);
            this.txtStdDev.TabIndex = 3;
            this.txtStdDev.Text = "0.5";
            this.txtStdDev.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Std Dev:";
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(116, 24);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 4;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // picGraph
            // 
            this.picGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraph.BackColor = System.Drawing.Color.White;
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraph.Location = new System.Drawing.Point(12, 64);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(471, 185);
            this.picGraph.TabIndex = 5;
            this.picGraph.TabStop = false;
            // 
            // howto_draw_normal_distribution_Form1
            // 
            this.AcceptButton = this.btnDraw;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 261);
            this.Controls.Add(this.picGraph);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.txtStdDev);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMean);
            this.Controls.Add(this.label1);
            this.Name = "howto_draw_normal_distribution_Form1";
            this.Text = "howto_draw_normal_distribution";
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMean;
        private System.Windows.Forms.TextBox txtStdDev;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.PictureBox picGraph;
    }
}

