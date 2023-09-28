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
     public partial class howto_draw_gear_Form1:Form
  { 


        public howto_draw_gear_Form1()
        {
            InitializeComponent();
        }

        // Draw the gear.
        private void picGears_Paint(object sender, PaintEventArgs e)
        {
            // Draw smoothly.
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            const float radius = 50;
            const float tooth_length = 10;
            float x = picGears.ClientSize.Width / 2 - radius - tooth_length - 1;
            float y = picGears.ClientSize.Height / 3;
            DrawGear(e.Graphics, Brushes.Black, Brushes.LightBlue, Pens.Blue, new PointF(x, y),
                radius, tooth_length, 10, 5, true);

            x += 2 * radius + tooth_length + 2;
            DrawGear(e.Graphics, Brushes.Black, Brushes.LightGreen, Pens.Green, new PointF(x, y),
                radius, tooth_length, 10, 5, false);

            y += 2 * radius + tooth_length + 2;
            DrawGear(e.Graphics, Brushes.Black, Brushes.Pink, Pens.Red, new PointF(x, y),
                radius, tooth_length, 10, 5, true);
        }

        // Draw a gear.
        private void DrawGear(Graphics gr, Brush axle_brush, Brush gear_brush, Pen gear_pen, PointF center, float radius, float tooth_length, int num_teeth, float axle_radius, bool start_with_tooth)
        {
            float dtheta = (float)(Math.PI / num_teeth);
            float dtheta_degrees = (float)(dtheta * 180 / Math.PI);     // dtheta in degrees.

            const float chamfer = 2;
            float tooth_width = radius * dtheta - chamfer;
            float alpha = tooth_width / (radius + tooth_length);
            float alpha_degrees = (float)(alpha * 180 / Math.PI);
            float phi = (dtheta - alpha) / 2;

            // Set theta for the beginning of the first tooth.
            float theta;
            if (start_with_tooth) theta = dtheta / 2;
            else theta = -dtheta / 2;

            // Make rectangles to represent the gear's inner and outer arcs.
            RectangleF inner_rect = new RectangleF(
                center.X - radius, center.Y - radius,
                2 * radius, 2 * radius);
            RectangleF outer_rect = new RectangleF(
                center.X - radius - tooth_length, center.Y - radius - tooth_length,
                2 * (radius + tooth_length), 2 * (radius + tooth_length));

            // Make a path representing the gear.
            GraphicsPath path = new GraphicsPath();
            for (int i = 0; i < num_teeth; i++)
            {
                // Move across the gap between teeth.
                float degrees = (float)(theta * 180 / Math.PI);
                path.AddArc(inner_rect, degrees, dtheta_degrees);
                theta += dtheta;

                // Move across the tooth's outer edge.
                degrees = (float)((theta + phi) * 180 / Math.PI);
                path.AddArc(outer_rect, degrees, alpha_degrees);
                theta += dtheta;
            }

            path.CloseFigure();

            // Draw the gear.
            gr.FillPath(gear_brush, path);
            gr.DrawPath(gear_pen, path);
            gr.FillEllipse(axle_brush,
                center.X - axle_radius, center.Y - axle_radius,
                2 * axle_radius, 2 * axle_radius);
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
            this.picGears = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picGears)).BeginInit();
            this.SuspendLayout();
            // 
            // picGears
            // 
            this.picGears.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGears.Location = new System.Drawing.Point(1, 1);
            this.picGears.Name = "picGears";
            this.picGears.Size = new System.Drawing.Size(281, 272);
            this.picGears.TabIndex = 3;
            this.picGears.TabStop = false;
            this.picGears.Paint += new System.Windows.Forms.PaintEventHandler(this.picGears_Paint);
            // 
            // howto_draw_gear_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 274);
            this.Controls.Add(this.picGears);
            this.Name = "howto_draw_gear_Form1";
            this.Text = "howto_draw_gear";
            ((System.ComponentModel.ISupportInitialize)(this.picGears)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picGears;
    }
}

