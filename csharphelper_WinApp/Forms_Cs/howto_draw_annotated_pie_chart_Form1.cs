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
     public partial class howto_draw_annotated_pie_chart_Form1:Form
  { 


        public howto_draw_annotated_pie_chart_Form1()
        {
            InitializeComponent();
        }

        private void howto_draw_annotated_pie_chart_Form1_Load(object sender, EventArgs e)
        {
            ResizeRedraw = true;
        }

        // Brushes used to fill pie slices.
        private Brush[] SliceBrushes =
        {
            Brushes.Red,
            Brushes.LightGreen,
            Brushes.Blue,
            Brushes.LightBlue,
            Brushes.Green,
            Brushes.Lime,
            Brushes.Orange,
            Brushes.Fuchsia,
            Brushes.Yellow,
            Brushes.Cyan,
        };

        // Pens used to outline pie slices.
        private Pen[] SlicePens = { Pens.Black };

        // Top 10 languages on September 13, 2012 according to:
        //      http://www.tiobe.com/index.php/content/paperinfo/tpci/index.html
        // The data values to chart.
        private float[] Values = 
        {
            19.295f,
            16.267f,
            9.770f,
            9.147f,
            6.596f,
            5.614f,
            5.528f,
            3.861f,
            2.267f,
            1.724f,
        };

        // The values' annotations.
        private string[] Annotations = new string[]
        {
            "C",
            "Java",
            "Objective-C",
            "C++",
            "C#",
            "PHP",
            "(Visual) Basic",
            "Python",
            "Perl",
            "Ruby",
        };

        // Draw the pie chart.
        private void howto_draw_annotated_pie_chart_Form1_Paint(object sender, PaintEventArgs e)
        {
            const int top_margin = 30;
            const int left_margin = 15;
            e.Graphics.Clear(BackColor);
            if ((ClientSize.Width < 2 * top_margin) || (ClientSize.Height < 2 * top_margin)) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int circle_width = ClientSize.Height - 2 * top_margin;
            int annotation_width = (ClientSize.Width - circle_width) / 2 - 2 * left_margin;
            int annotation_height = ClientSize.Height - 2 * left_margin;
            Rectangle left_rect = new Rectangle(
                left_margin, left_margin, annotation_width, annotation_height);
            Rectangle ellipse_rect = new Rectangle(
                left_rect.Right + left_margin, top_margin, circle_width, circle_width);
            Rectangle right_rect = new Rectangle(
                ellipse_rect.Right + left_margin, left_rect.Top,
                left_rect.Width, left_rect.Height);
            using (Font annotation_font = new Font("Times New Roman", 12))
            {
                DrawAnnotatedPieChart(e.Graphics,
                    ellipse_rect, left_rect, right_rect, 1.1f, 0,
                    SliceBrushes, SlicePens,
                    Values, Annotations, "0.0", Font, Brushes.Black,
                    annotation_font, Pens.Blue, Brushes.Green,
                    Brushes.LightBlue, null);
            }
        }

        // Draw a pie chart.
        private static void DrawAnnotatedPieChart(Graphics gr, Rectangle ellipse_rect, Rectangle left_rect, Rectangle right_rect, float annotation_radius_scale, float initial_angle, Brush[] brushes, Pen[] pens, float[] values, string[] annotations, string label_format, Font label_font, Brush label_brush, Font annotation_font, Pen annotation_pen, Brush annotation_brush, Brush rectangle_brush, Pen rectangle_pen)
        {
            // Get the total of all angles.
            float total = values.Sum();

            // Draw the slices.
            float start_angle = initial_angle;
            for (int i = 0; i < values.Length; i++)
            {
                float sweep_angle = values[i] * 360f / total;

                // Fill and outline the pie slice.
                gr.FillPie(brushes[i % brushes.Length], ellipse_rect, start_angle, sweep_angle);
                gr.DrawPie(pens[i % pens.Length], ellipse_rect, start_angle, sweep_angle);

                start_angle += sweep_angle;
            }

            // Draw the rectangles if desired.
            if (rectangle_brush != null)
            {
                gr.FillRectangle(rectangle_brush, left_rect);
                gr.FillRectangle(rectangle_brush, right_rect);
            }
            if (rectangle_pen != null)
            {
                gr.DrawRectangle(rectangle_pen, left_rect);
                gr.DrawRectangle(rectangle_pen, right_rect);
            }

            // Label and annotate the slices.
            // We label the slices after drawing them all so one
            // slice doesn't cover the label on another very thin slice.
            using (StringFormat string_format = new StringFormat())
            {
                // Find the center of the rectangle.
                float cx = (ellipse_rect.Left + ellipse_rect.Right) / 2;
                float cy = (ellipse_rect.Top + ellipse_rect.Bottom) / 2;

                // Place the label about 2/3 of the way out to the edge.
                float radius = (ellipse_rect.Width + ellipse_rect.Height) / 2f * 0.33f;

                // Distances for annotation lines.
                float annotation_rx1 = ellipse_rect.Width / 2;
                float annotation_ry1 = ellipse_rect.Height / 2;
                float annotation_rx2 = annotation_rx1 * annotation_radius_scale;
                float annotation_ry2 = annotation_ry1 * annotation_radius_scale;

                start_angle = start_angle = initial_angle;
                for (int i = 0; i < values.Length; i++)
                {
                    float sweep_angle = values[i] * 360f / total;

                    // Label the slice.
                    string_format.Alignment = StringAlignment.Center;
                    string_format.LineAlignment = StringAlignment.Center;
                    double label_angle = Math.PI * (start_angle + sweep_angle / 2) / 180;
                    float x = cx + (float)(radius * Math.Cos(label_angle));
                    float y = cy + (float)(radius * Math.Sin(label_angle));
                    gr.DrawString(values[i].ToString(label_format),
                        label_font, label_brush, x, y, string_format);

                    // Draw a radial line to connect to the annotation.
                    float x1 = cx + (float)(annotation_rx1 * Math.Cos(label_angle));
                    float y1 = cy + (float)(annotation_rx1 * Math.Sin(label_angle));
                    float x2 = cx + (float)(annotation_rx2 * Math.Cos(label_angle));
                    float y2 = cy + (float)(annotation_rx2 * Math.Sin(label_angle));
                    gr.DrawLine(annotation_pen, x1, y1, x2, y2);

                    // Draw a horizontal line to the annotation.
                    if (x2 < x1)
                    {
                        // Draw to the left.
                        gr.DrawLine(annotation_pen, x2, y2, left_rect.Right, y2);

                        // Draw the annotation right justified.
                        string_format.Alignment = StringAlignment.Far;
                        gr.DrawString(annotations[i], annotation_font, annotation_brush,
                            left_rect.Right, y2, string_format);
                    }
                    else
                    {
                        // Draw to the right.
                        gr.DrawLine(annotation_pen, x2, y2, right_rect.Left, y2);

                        // Draw the annotation left justified.
                        string_format.Alignment = StringAlignment.Near;
                        gr.DrawString(annotations[i], annotation_font, annotation_brush,
                            right_rect.Left, y2, string_format);
                    }

                    start_angle += sweep_angle;
                }
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
            this.SuspendLayout();
            // 
            // howto_draw_annotated_pie_chart_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Name = "howto_draw_annotated_pie_chart_Form1";
            this.Text = "howto_draw_annotated_pie_chart";
            this.Load += new System.EventHandler(this.howto_draw_annotated_pie_chart_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_draw_annotated_pie_chart_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

