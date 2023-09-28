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
     public partial class howto_means_by_age_Form1:Form
  { 


        public howto_means_by_age_Form1()
        {
            InitializeComponent();
        }

        // The mean and standard deviation data.
        private const int MinAge = 6;
        private float[] Means =
            { 62, 56, 43, 42, 39, 36, 32, 31, };
        private float[] StdDevs =
            { 15, 9, 8, 8, 7, 5, 5, 6, };

        // Some test points.
        private PointF[] TestPoints =
        {
            new PointF(6, 58),
            new PointF(7, 63),
            new PointF(9, 55),
            new PointF(11, 39),
            new PointF(13, 29),
        };

        // Draw the graph.
        private void howto_means_by_age_Form1_Load(object sender, EventArgs e)
        {
            DrawGraph(MinAge, Means, StdDevs);
        }

        // Draw the graph.
        private void DrawGraph(int min_age, float[] means, float[] stddevs)
        {
            int max_age = min_age + means.Length - 1;

            // Get the minimum and maximum values.
            const float max_dev = 2.5f;
            float min_value = means[0] - max_dev * stddevs[0];
            float max_value = means[0] + max_dev * stddevs[0];
            for (int i = 0; i < means.Length; i++)
            {
                if (min_value > means[i] - max_dev * stddevs[i])
                    min_value = means[i] - max_dev * stddevs[i];
                if (max_value < means[i] + max_dev * stddevs[i])
                    max_value = means[i] + max_dev * stddevs[i];
            }
            if (min_value > 0) min_value = 0;

            float hgt = 1.2f * (max_value - min_value);
            float middle = (max_value + min_value) / 2f;
            min_value = middle - hgt / 2f;
            max_value = middle + hgt / 2f;

            // Make a transformation for drawing.
            RectangleF world = new RectangleF(
                min_age - 1f, min_value,
                max_age - min_age + 1.5f, max_value - min_value);
            PointF[] device_points =
            {
                new PointF(0, picGraph.ClientSize.Height),
                new PointF(picGraph.ClientSize.Width, picGraph.ClientSize.Height),
                new PointF(0, 0),
            };
            Matrix transform = new Matrix(world, device_points);

            Bitmap bm = new Bitmap(
                picGraph.ClientSize.Width,
                picGraph.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                using (Pen pen = new Pen(Color.Red, 0))
                {
                    gr.SmoothingMode = SmoothingMode.AntiAlias;
                    gr.Transform = transform;

                    // Draw the standard deviation envelopes.
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(255, 128, 128)))
                    {
                        pen.Color = brush.Color;
                        DrawEnvelope(gr, min_age, means, stddevs,
                            2.5f, brush, pen);
                    }
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 128)))
                    {
                        pen.Color = brush.Color;
                        DrawEnvelope(gr, min_age, means, stddevs,
                            1.5f, brush, pen);
                    }
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(128, 255, 128)))
                    {
                        pen.Color = brush.Color;
                        DrawEnvelope(gr, min_age, means, stddevs,
                            0.5f, brush, pen);
                    }

                    // Draw the curve.
                    List<PointF> points = new List<PointF>();
                    for (int i = 0; i < means.Length; i++)
                        points.Add(new PointF(i + min_age, means[i]));
                    pen.Color = Color.Black;
                    gr.DrawLines(pen, points.ToArray());

                    // Draw and label the axes.
                    pen.Color = Color.Black;
                    using (Font font = new Font("Arial", 8))
                    {
                        gr.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                        using (StringFormat sf = new StringFormat())
                        {
                            sf.Alignment = StringAlignment.Center;
                            sf.LineAlignment = StringAlignment.Near;

                            // Draw the X axis.
                            // Draw the axis.
                            gr.DrawLine(pen, min_age, 0, max_age, 0);

                            // Draw the tick marks.
                            for (int x = min_age; x <= max_age; x++)
                                gr.DrawLine(pen, x, 0, x, max_value);

                            // Label the ages.
                            List<PointF> tick_points = new List<PointF>();
                            List<string> tick_labels = new List<string>();
                            PointF[] label_points_array;
                            for (int x = min_age; x <= max_age; x++)
                            {
                                tick_points.Add(new PointF(x, 0));
                                tick_labels.Add(x.ToString());
                            }
                            label_points_array = tick_points.ToArray();
                            transform.TransformPoints(label_points_array);
                            gr.Transform = new Matrix();
                            for (int i = 0; i < label_points_array.Length; i++)
                            {
                                gr.DrawString(tick_labels[i], font,
                                    Brushes.Black, label_points_array[i], sf);
                            }

                            // Draw the Y axis.
                            // Draw the axis.
                            gr.Transform = transform;
                            gr.DrawLine(pen, 0, min_value, 0, max_value);

                            // Draw the tick marks.
                            int start_y = 10;
                            int stop_y = 10 * (int)(max_value / 10f);
                            int num_y = stop_y - start_y + 1;
                            for (int y = start_y; y <= stop_y; y += 10)
                                gr.DrawLine(pen, min_age - 0.15f, y, min_age + 0.15f, y);

                            // Label the Y axis.
                            sf.Alignment = StringAlignment.Far;
                            sf.LineAlignment = StringAlignment.Center;

                            tick_points.Clear();
                            tick_labels.Clear();
                            for (int y = start_y; y <= stop_y; y += 10)
                            {
                                tick_points.Add(new PointF(min_age - 0.2f, y));
                                tick_labels.Add(y.ToString());
                            }
                            label_points_array = tick_points.ToArray();
                            transform.TransformPoints(label_points_array);

                            gr.Transform = new Matrix();
                            for (int y = 0; y < label_points_array.Length; y++)
                            {
                                gr.DrawString(tick_labels[y], font,
                                    Brushes.Black, label_points_array[y], sf);
                            }
                        } // StringFormat
                    } // Font

                    // Plot test points.
                    transform.TransformPoints(TestPoints);
                    gr.Transform = new Matrix();
                    foreach (PointF point in TestPoints)
                    {
                        gr.FillRectangle(Brushes.Red,
                            point.X - 3, point.Y - 3, 6, 6);
                    }
                } // Pen
            } // Graphics

            picGraph.Image = bm;
        }

        // Draw an envelope for dev_mult times the standard deviations.
        private void DrawEnvelope(Graphics gr, int min_age,
            float[] means, float[] stddevs,
            float dev_mult, Brush brush, Pen pen)
        {
            List<PointF> points = new List<PointF>();
            for (int i = 0; i < means.Length; i++)
                points.Add(new PointF(i + min_age, means[i] + dev_mult * stddevs[i]));
            for (int i = means.Length - 1; i >= 0; i--)
                points.Add(new PointF(i + min_age, means[i] - dev_mult * stddevs[i]));

            gr.FillPolygon(brush, points.ToArray());
            gr.DrawPolygon(pen, points.ToArray());
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
            this.picGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraph.BackColor = System.Drawing.Color.White;
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraph.Location = new System.Drawing.Point(12, 12);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(260, 237);
            this.picGraph.TabIndex = 0;
            this.picGraph.TabStop = false;
            // 
            // howto_means_by_age_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.picGraph);
            this.Name = "howto_means_by_age_Form1";
            this.Text = "howto_means_by_age";
            this.Load += new System.EventHandler(this.howto_means_by_age_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picGraph;
    }
}

