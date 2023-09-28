// #define SAVE_FRAMES

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
     public partial class howto_animate_gear_Form1:Form
  { 


        public howto_animate_gear_Form1()
        {
            InitializeComponent();
        }

        // Reduce flicker.
        private void howto_animate_gear_Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
        }

        // The angle used as the gears' origins.
        private float StartAngle = 0;
#if SAVE_FRAMES
        private float dStartAngle = (float)(Math.PI / 45);
#else
        private float dStartAngle = (float)(Math.PI / 180);
#endif

        // Draw the gear.
        private void picGears_Paint(object sender, PaintEventArgs e)
        {
            // Draw smoothly.
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            const float radius = 50;
            const float tooth_length = 10;
            float x = picGears.ClientSize.Width / 2 - radius - tooth_length - 1;
            float y = picGears.ClientSize.Height / 3;
            DrawGear(StartAngle, e.Graphics, Brushes.Black, Brushes.LightBlue, Pens.Blue, new PointF(x, y),
                radius, tooth_length, 10, 5, true);

            x += 2 * radius + tooth_length + 2;
            DrawGear(-StartAngle, e.Graphics, Brushes.Black, Brushes.LightGreen, Pens.Green, new PointF(x, y),
                radius, tooth_length, 10, 5, false);

            y += 2f * radius + tooth_length + 2;
            DrawGear(StartAngle, e.Graphics, Brushes.Black, Brushes.Pink, Pens.Red, new PointF(x, y),
                radius, tooth_length, 10, 5, true);
        }
        
        // Draw a gear.
        private void DrawGear(float start_angle, Graphics gr, Brush axle_brush, Brush gear_brush, Pen gear_pen, PointF center, float radius, float tooth_length, int num_teeth, float axle_radius, bool start_with_tooth)
        {
            float dtheta = (float)(Math.PI / num_teeth);
            float dtheta_degrees = (float)(dtheta * 180 / Math.PI);     // dtheta in degrees.

            const float chamfer = 2;
            float tooth_width = radius * dtheta - chamfer;
            float alpha = tooth_width / (radius + tooth_length);
            float alpha_degrees = (float)(alpha * 180 / Math.PI);
            float phi = (dtheta - alpha) / 2;

            // Set theta for the beginning of the first tooth.
            float theta = start_angle;
            if (start_with_tooth) theta += dtheta / 2;
            else theta -= dtheta / 2;

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

        // Increment the gears' start angle and redraw.
        private void tmrRotate_Tick(object sender, EventArgs e)
        {
            StartAngle += dStartAngle;
            picGears.Refresh();

#if SAVE_FRAMES
            if (frame_num < 9)
            {
                Bitmap bm = GetControlImage(this);
                bm.Save("Frame" + frame_num.ToString() + ".png",
                    System.Drawing.Imaging.ImageFormat.Png);
                frame_num++;
            }
#endif
        }

        // Start or stop the animation.
        private void btnStartStop_Click(object sender, EventArgs e)
        {
            tmrRotate.Enabled = !tmrRotate.Enabled;
            if (tmrRotate.Enabled) btnStartStop.Text = "Stop";
            else btnStartStop.Text = "Start";
        }

#if SAVE_FRAMES
        private int frame_num = 0;

        // Return a Bitmap holding an image of the control.
        private Bitmap GetControlImage(Control ctl)
        {
            Bitmap bm = new Bitmap(ctl.Width, ctl.Height);
            ctl.DrawToBitmap(bm, new Rectangle(0, 0, ctl.Width, ctl.Height));
            return bm;
        }
#endif

    

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
            this.components = new System.ComponentModel.Container();
            this.tmrRotate = new System.Windows.Forms.Timer(this.components);
            this.btnStartStop = new System.Windows.Forms.Button();
            this.picGears = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picGears)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrRotate
            // 
            this.tmrRotate.Interval = 10;
            this.tmrRotate.Tick += new System.EventHandler(this.tmrRotate_Tick);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(0, 0);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(75, 23);
            this.btnStartStop.TabIndex = 0;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // picGears
            // 
            this.picGears.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGears.Location = new System.Drawing.Point(0, 29);
            this.picGears.Name = "picGears";
            this.picGears.Size = new System.Drawing.Size(283, 268);
            this.picGears.TabIndex = 1;
            this.picGears.TabStop = false;
            this.picGears.Paint += new System.Windows.Forms.PaintEventHandler(this.picGears_Paint);
            // 
            // howto_animate_gear_Form1
            // 
            this.AcceptButton = this.btnStartStop;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 297);
            this.Controls.Add(this.picGears);
            this.Controls.Add(this.btnStartStop);
            this.Name = "howto_animate_gear_Form1";
            this.Text = "howto_animate_gear";
            this.Load += new System.EventHandler(this.howto_animate_gear_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picGears)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrRotate;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.PictureBox picGears;
    }
}

