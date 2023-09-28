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
     public partial class howto_fibonacci_phi_Form1:Form
  { 


        public howto_fibonacci_phi_Form1()
        {
            InitializeComponent();
        }

        // The Fibonacci values.
        private double[] Fibonacci;

        // Phi.
        private double Phi;

        // Make a list of Fibonacci numbers.
        private void howto_fibonacci_phi_Form1_Load(object sender, EventArgs e)
        {
            // Display phi.
            Phi = (1 + Math.Sqrt(5)) / 2;
            txtPhi.Text = Phi.ToString("n15");

            // Calculate Fibonacci values.
            Fibonacci = new double[45];
            Fibonacci[0] = 0;
            Fibonacci[1] = 1;
            for (int n = 2; n < Fibonacci.Length; n++)
            {
                Fibonacci[n] = Fibonacci[n - 1] + Fibonacci[n - 2];
            }

            // Display values.
            for (int n = 0; n < Fibonacci.Length; n++)
            {
                ListViewItem item = lvwValues.Items.Add(n.ToString());
                item.SubItems.Add(Fibonacci[n].ToString());
                if (n > 1)
                {
                    double ratio = Fibonacci[n] / Fibonacci[n - 1];
                    item.SubItems.Add(ratio.ToString("n15"));
                    double difference = ratio - Phi;
                    item.SubItems.Add(difference.ToString("e2"));
                }
            }

            lvwValues.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        // Draw the graph.
        private void picGraph_Paint(object sender, PaintEventArgs e)
        {
            DrawGraph(e.Graphics);
        }

        // Redraw the graph.
        private void picGraph_Resize(object sender, EventArgs e)
        {
            picGraph.Refresh();
        }

        // Draw the graph on a Graphics object.
        private void DrawGraph(Graphics gr)
        {
            gr.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen thin_pen = new Pen(Color.Black, 0))
            {
                // Make a trsnaformation matrix to make drawing easier.
                const float xmin = -0.1f;
                const float ymin = -0.1f;
                const float xmax = 9.1f;
                const float ymax = 2.2f;
                RectangleF src_rect = new RectangleF(
                    xmin, ymin, xmax - xmin, ymax - ymin);
                PointF[] pts = 
                {
                    new PointF(0, picGraph.ClientSize.Height),
                    new PointF(picGraph.ClientSize.Width, picGraph.ClientSize.Height),
                    new PointF(0, 0)
                };
                Matrix trans = new Matrix(src_rect, pts);

                // Draw numbers along the X-axis.
                List<PointF> x_pt_list = new List<PointF>();
                for (int x = (int)xmin; x <= xmax; x++)
                {
                    x_pt_list.Add(new PointF(x, 0.1f));
                }
                PointF[] x_pt_array = x_pt_list.ToArray();
                trans.TransformPoints(x_pt_array);
                using (StringFormat string_format = new StringFormat())
                {
                    string_format.Alignment = StringAlignment.Center;
                    string_format.LineAlignment = StringAlignment.Far;
                    int index = 0;
                    for (int x = (int)xmin; x <= xmax; x++)
                    {
                        gr.DrawString(x.ToString(), this.Font, Brushes.Black,
                            x_pt_array[index], string_format);
                        index++;
                    }
                }

                // Draw numbers along the Y-axis.
                List<PointF> y_pt_list = new List<PointF>();
                for (int y = (int)ymin; y <= ymax; y++)
                {
                    y_pt_list.Add(new PointF(0.2f, y));
                }
                PointF[] y_pt_array = y_pt_list.ToArray();
                trans.TransformPoints(y_pt_array);
                using (StringFormat string_format = new StringFormat())
                {
                    string_format.Alignment = StringAlignment.Near;
                    string_format.LineAlignment = StringAlignment.Center;
                    int index = 0;
                    for (int y = (int)ymin; y <= ymax; y++)
                    {
                        gr.DrawString(y.ToString(), this.Font, Brushes.Black,
                            y_pt_array[index], string_format);
                        index++;
                    }
                }

                // Transform the Graphics object for drawing.
                gr.Transform = new Matrix(src_rect, pts);

                // Draw the axes.
                gr.DrawLine(thin_pen, xmin, 0, xmax, 0);
                for (int y = (int)ymin; y <= ymax; y++)
                {
                    gr.DrawLine(thin_pen, -0.1f, y, 0.1f, y);
                }
                gr.DrawLine(thin_pen, 0, ymin, 0, ymax);
                for (int x = (int)xmin; x <= xmax; x++)
                {
                    gr.DrawLine(thin_pen, x, -0.1f, x, 0.1f);
                }

                // Draw phi.
                thin_pen.Color = Color.Green;
                gr.DrawLine(thin_pen, xmin, (float)Phi, xmax, (float)Phi);

                // Draw the points.
                List<PointF> fib_points = new List<PointF>();
                for (int n = 2; n <= xmax; n++)
                {
                    float ratio = (float)(Fibonacci[n] / Fibonacci[n - 1]);
                    fib_points.Add(new PointF(n, ratio));

                }
                thin_pen.Color = Color.Red;
                //gr.DrawLines(thin_pen, fib_points.ToArray());
                gr.DrawCurve(thin_pen, fib_points.ToArray());
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
            this.txtPhi = new System.Windows.Forms.TextBox();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.lvwValues = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.picGraph = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPhi
            // 
            this.txtPhi.Location = new System.Drawing.Point(45, 6);
            this.txtPhi.Name = "txtPhi";
            this.txtPhi.ReadOnly = true;
            this.txtPhi.Size = new System.Drawing.Size(121, 20);
            this.txtPhi.TabIndex = 6;
            this.txtPhi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Difference";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 83;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Phi:";
            // 
            // lvwValues
            // 
            this.lvwValues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwValues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvwValues.Location = new System.Drawing.Point(2, 32);
            this.lvwValues.Name = "lvwValues";
            this.lvwValues.Size = new System.Drawing.Size(381, 134);
            this.lvwValues.TabIndex = 4;
            this.lvwValues.UseCompatibleStateImageBehavior = false;
            this.lvwValues.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "n";
            this.columnHeader1.Width = 33;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Fib(n)";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 62;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Fib(n) / Fib(n-1)";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 108;
            // 
            // picGraph
            // 
            this.picGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraph.BackColor = System.Drawing.Color.White;
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraph.Location = new System.Drawing.Point(2, 172);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(381, 182);
            this.picGraph.TabIndex = 7;
            this.picGraph.TabStop = false;
            this.picGraph.Resize += new System.EventHandler(this.picGraph_Resize);
            this.picGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.picGraph_Paint);
            // 
            // howto_fibonacci_phi_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.txtPhi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvwValues);
            this.Controls.Add(this.picGraph);
            this.Name = "howto_fibonacci_phi_Form1";
            this.Text = "howto_fibonacci_phi";
            this.Load += new System.EventHandler(this.howto_fibonacci_phi_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPhi;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvwValues;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.PictureBox picGraph;
    }
}

