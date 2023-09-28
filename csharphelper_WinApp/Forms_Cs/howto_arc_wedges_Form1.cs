using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

using howto_arc_wedges;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_arc_wedges_Form1:Form
  { 


        public howto_arc_wedges_Form1()
        {
            InitializeComponent();
        }

        // Display arrow samples.
        private void howto_arc_wedges_Form1_Load(object sender, EventArgs e)
        {
            howto_arc_wedges_ArrowsForm frm = new  howto_arc_wedges_ArrowsForm();
            frm.Show();
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw inner arc tics.
            Point center = new Point(173, 89);
            float radius = 40;
            float start_angle = 40;
            float sweep_angle = 360 - 2 * start_angle;
            int num_tics = 24;
            float skip_angle = sweep_angle / num_tics;
            e.Graphics.DrawArcTics(
                Pens.Yellow, Pens.Yellow,
                center, radius, 10,
                start_angle, sweep_angle,
                skip_angle, 1, 1);

            // Draw outer wedges.
            float inner_radius2 = 60;
            float outer_radius2 = inner_radius2 + 40;
            int num_wedges = 12;
            float skip_degrees = sweep_angle /
                (2 * num_wedges + (num_wedges - 1));
            float draw_degrees = skip_degrees * 2;
            e.Graphics.DrawArcWedges(
                null, Pens.Black,
                center, inner_radius2, outer_radius2,
                start_angle, num_wedges,
                draw_degrees, skip_degrees);

            // Highlight one arc wedge.
            using (Pen pen = new Pen(Color.Purple, 2))
            {
                using (Brush brush = new SolidBrush(
                    Color.FromArgb(80, pen.Color)))
                {
                    start_angle += 3 * (draw_degrees + skip_degrees);
                    e.Graphics.DrawArcWedges(
                        brush, pen,
                        center, inner_radius2, outer_radius2,
                        start_angle, 1,
                        draw_degrees, skip_degrees);
                }
            }

            // Draw the arrow pointing to the center.
            Brush arrow_brush = Brushes.Orange;
            PointF start_point = new PointF(center.X + 80, center.Y);
            e.Graphics.DrawSegment(
                start_point, center, Pens.Orange,
                Pens.Orange, 10, 10, 1, 2,
                Extensions.ArrowheadTypes.None,
                null, 0,
                Extensions.ArrowheadTypes.TriangleHead,
                Brushes.Orange, 8);

            // Draw the ticks above the pupil.
            PointF p1 = new PointF(center.X - 75, center.Y - 50);
            PointF p2 = new PointF(center.X + 75, center.Y - 50);
            e.Graphics.DrawSegment(
                p1, p2, Pens.White,
                Pens.White, 10, 15, 1, 1,
                Extensions.ArrowheadTypes.None, null, 0,
                Extensions.ArrowheadTypes.None, null, 0);
            PointF p3 = new PointF(center.X - 25, p1.Y - 20);
            PointF p4 = new PointF(center.X - 25, p1.Y - 10);
            e.Graphics.DrawArrowhead(Brushes.White, p3, p4, 10,
                Extensions.ArrowheadTypes.VHead);

            // Draw tic marks to the left.
            PointF p5 = new PointF(center.X - 75, center.Y - 50);
            PointF p6 = new PointF(center.X - 75, p5.Y + 15 * 7);
            e.Graphics.DrawSegment(
                p5, p6, Pens.White,
                Pens.White, 10, 15, 1, 1,
                Extensions.ArrowheadTypes.None, null, 0,
                Extensions.ArrowheadTypes.None, null, 0);
            PointF p7 = new PointF(p5.X - 20, center.Y + 20);
            PointF p8 = new PointF(p5.X - 10, center.Y + 20);
            e.Graphics.DrawArrowhead(Brushes.White, p7, p8, 10,
                Extensions.ArrowheadTypes.VHead);
        }

        // Display the mouse's location.
        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine(e.Location.ToString());
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
            this.picCanvas = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Image = Properties.Resources.eye;
            this.picCanvas.Location = new System.Drawing.Point(12, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(320, 192);
            this.picCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseClick);
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // howto_arc_wedges_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 218);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_arc_wedges_Form1";
            this.Text = "howto_arc_wedges";
            this.Load += new System.EventHandler(this.howto_arc_wedges_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
    }
}

