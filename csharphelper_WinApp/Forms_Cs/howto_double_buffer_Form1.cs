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
     public partial class howto_double_buffer_Form1:Form
  { 


        public howto_double_buffer_Form1()
        {
            InitializeComponent();
        }

        private const int period = 24;
        private Color[] Colors;

        // Initialize the colors.
        private void howto_double_buffer_Form1_Load(object sender, EventArgs e)
        {
            // Redraw when resized.
            this.ResizeRedraw = true;

            Colors = new Color[] 
            {
                Color.Pink,
                Color.Red,
                Color.Orange,
                Color.Yellow,
                Color.Lime,
                Color.Cyan,
                Color.Blue,
                Color.Violet,
                Color.Pink,
                Color.Red,
                Color.Orange,
                Color.Yellow,
                Color.Lime,
                Color.Cyan,
                Color.Blue,
                Color.Violet,
                Color.Pink,
                Color.Red,
                Color.Orange,
                Color.Yellow,
                Color.Lime,
                Color.Cyan,
                Color.Blue,
                Color.Violet
            };
        }

        // Draw the butterfly.
        private void howto_double_buffer_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.Clear(this.BackColor);

            // Scale and translate.
            RectangleF world_rect = 
                new RectangleF(-4.0f, -4.4f, 8.0f, 7.3f);
            float cx = (world_rect.Left + world_rect.Right) / 2;
            float cy = (world_rect.Top + world_rect.Bottom) / 2;

            // Center the world coordinates at origin.
            e.Graphics.TranslateTransform(-cx, -cy);

            // Scale to fill the form.
            float scale = Math.Min(
                this.ClientSize.Width / world_rect.Width,
                this.ClientSize.Height / world_rect.Height);
            e.Graphics.ScaleTransform(scale, scale,
                System.Drawing.Drawing2D.MatrixOrder.Append);

            // Move the result to center on the form.
            e.Graphics.TranslateTransform(
                this.ClientSize.Width / 2,
                this.ClientSize.Height / 2,
                System.Drawing.Drawing2D.MatrixOrder.Append);

            // Generate the points.
            PointF pt0, pt1;
            double t = 0;
            double expr =
                Math.Exp(Math.Cos(t))
                - 2 * Math.Cos(4 * t)
                - Math.Pow(Math.Sin(t / 12), 5);
            pt1 = new PointF(
                (float)(Math.Sin(t) * expr),
                (float)(-Math.Cos(t) * expr));
            using (Pen the_pen = new Pen(Color.Blue, 0))
            {
                const long num_lines = 5000;
                for (long i = 0; i < num_lines; i++)
                {
                    t = i * period * Math.PI / num_lines;
                    expr =
                        Math.Exp(Math.Cos(t))
                        - 2 * Math.Cos(4 * t)
                        - Math.Pow(Math.Sin(t / 12), 5);
                    pt0 = pt1;
                    pt1 = new PointF(
                        (float)(Math.Sin(t) * expr),
                        (float)(-Math.Cos(t) * expr));
                    the_pen.Color = GetColor(t);
                    e.Graphics.DrawLine(the_pen, pt0, pt1);
                }
            }
        }

        // Return an appropriate color for this segment.
        private Color GetColor(double t)
        {
            return Colors[(int)(t / Math.PI)];
        }

        // Turn double buffering on or off and redraw.
        private void chkDoubleBuffer_CheckedChanged(object sender, EventArgs e)
        {
            this.DoubleBuffered = chkDoubleBuffer.Checked;
            this.Refresh();
        }

        // Redraw.
        private void btnRedraw_Click(object sender, EventArgs e)
        {
            this.Invalidate();
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
            this.chkDoubleBuffer = new System.Windows.Forms.CheckBox();
            this.btnRedraw = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkDoubleBuffer
            // 
            this.chkDoubleBuffer.AutoSize = true;
            this.chkDoubleBuffer.ForeColor = System.Drawing.Color.White;
            this.chkDoubleBuffer.Location = new System.Drawing.Point(12, 12);
            this.chkDoubleBuffer.Name = "chkDoubleBuffer";
            this.chkDoubleBuffer.Size = new System.Drawing.Size(91, 17);
            this.chkDoubleBuffer.TabIndex = 0;
            this.chkDoubleBuffer.Text = "Double Buffer";
            this.chkDoubleBuffer.UseVisualStyleBackColor = true;
            this.chkDoubleBuffer.CheckedChanged += new System.EventHandler(this.chkDoubleBuffer_CheckedChanged);
            // 
            // btnRedraw
            // 
            this.btnRedraw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRedraw.Location = new System.Drawing.Point(321, 12);
            this.btnRedraw.Name = "btnRedraw";
            this.btnRedraw.Size = new System.Drawing.Size(75, 23);
            this.btnRedraw.TabIndex = 1;
            this.btnRedraw.Text = "Redraw";
            this.btnRedraw.UseVisualStyleBackColor = true;
            this.btnRedraw.Click += new System.EventHandler(this.btnRedraw_Click);
            // 
            // howto_double_buffer_Form1
            // 
            this.AcceptButton = this.btnRedraw;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(408, 341);
            this.Controls.Add(this.btnRedraw);
            this.Controls.Add(this.chkDoubleBuffer);
            this.Name = "howto_double_buffer_Form1";
            this.Text = "howto_double_buffer";
            this.Load += new System.EventHandler(this.howto_double_buffer_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_double_buffer_Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkDoubleBuffer;
        private System.Windows.Forms.Button btnRedraw;

    }
}

