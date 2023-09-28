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
     public partial class howto_point_over_pie_Form1:Form
  { 


        public howto_point_over_pie_Form1()
        {
            InitializeComponent();
        }

        // The pie chart's center.
        private Point EllipseCenter;

        // The pie chart's drawing area.
        private Rectangle EllipseRect;

        // The ellipse's X and Y radii.
        private float EllipseRx, EllipseRy;

        // The slices' ending angles in degrees.
        // The first angle is 0 and marks the start of the first slice.
        private float[] Angles = { 0, 45, 80, 110, 130, 170, 220, 245, 300, 360 };

        // The slices' colors.
        private Brush[] ChartBrushes =
        {
            Brushes.Red, Brushes.LightGreen, Brushes.LightBlue,
            Brushes.Yellow, Brushes.Orange, Brushes.White,
            Brushes.Cyan, Brushes.Pink, Brushes.Black,
        };

        // Initialize the pie chart data.
        private void howto_point_over_pie_Form1_Load(object sender, EventArgs e)
        {
            const int margin = 10;
            int wid = picPie.ClientSize.Width - 2 * margin;
            int hgt = picPie.ClientSize.Height - 2 * margin;
            EllipseRect = new Rectangle(margin, margin, wid, hgt);
            EllipseRx = wid / 2;
            EllipseRy = hgt / 2;
            EllipseCenter = new Point(
                picPie.ClientSize.Width / 2,
                picPie.ClientSize.Height / 2);
        }

        // Draw the pie slices.
        private void picPie_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            e.Graphics.FillEllipse(Brushes.Blue, EllipseRect);
            for (int i = 1; i < Angles.Length; i++)
            {
                e.Graphics.FillPie(ChartBrushes[i - 1],
                    EllipseRect, Angles[i], Angles[i - 1] - Angles[i]);
            }
            e.Graphics.DrawEllipse(Pens.Blue, EllipseRect);
        }

        // Display the number of the slice under the mouse.
        private void picPie_MouseMove(object sender, MouseEventArgs e)
        {
            // Get the slice number.
            int slice_number = GetSliceNumber(EllipseRect, Angles, e.Location);

            // Display the slice number.
            if (slice_number == -1) lblSliceNumber.Text = "";
            else lblSliceNumber.Text = slice_number.ToString();
        }

        // Return the slice number or -1 if the 
        // mouse isn't over a slice.
        private int GetSliceNumber(Rectangle rect, float[] angles, Point point)
        {
            // Get the position relative to the ellipse's center.
            float rx = rect.Width / 2;
            float ry = rect.Height / 2;
            float cx = rect.X + rx;
            float cy = rect.Y + ry;
            float dx = point.X - cx;
            float dy = point.Y - cy;
            float value =
                dx * dx / rx / rx +
                dy * dy / ry / ry;

            // See if the mouse is at the center.
            if (value < 0.0001) return -1;

            // See if the point is outside of the ellipse.
            if (value > 1) return -1;

            // The point is inside the ellipse.
            // Get the angle.
            double angle = Math.Atan2(dy, dx);
            if (angle < 0) angle += 2 * Math.PI;

            // Convert the angle into degrees.
            angle = angle * 180 / Math.PI;

            // Get the slice number.
            for (int i = 0; i < Angles.Length - 1; i++)
                if (angle <= Angles[i + 1]) return i;

            throw new Exception("Cannot find angle " + angle);
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
            this.picPie = new System.Windows.Forms.PictureBox();
            this.lblSliceNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picPie)).BeginInit();
            this.SuspendLayout();
            // 
            // picPie
            // 
            this.picPie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picPie.BackColor = System.Drawing.Color.White;
            this.picPie.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPie.Location = new System.Drawing.Point(12, 12);
            this.picPie.Name = "picPie";
            this.picPie.Size = new System.Drawing.Size(260, 124);
            this.picPie.TabIndex = 0;
            this.picPie.TabStop = false;
            this.picPie.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picPie_MouseMove);
            this.picPie.Paint += new System.Windows.Forms.PaintEventHandler(this.picPie_Paint);
            // 
            // lblSliceNumber
            // 
            this.lblSliceNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSliceNumber.AutoSize = true;
            this.lblSliceNumber.Location = new System.Drawing.Point(12, 139);
            this.lblSliceNumber.Name = "lblSliceNumber";
            this.lblSliceNumber.Size = new System.Drawing.Size(0, 13);
            this.lblSliceNumber.TabIndex = 1;
            // 
            // howto_point_over_pie_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.lblSliceNumber);
            this.Controls.Add(this.picPie);
            this.Name = "howto_point_over_pie_Form1";
            this.Text = "howto_point_over_pie";
            this.Load += new System.EventHandler(this.howto_point_over_pie_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPie;
        private System.Windows.Forms.Label lblSliceNumber;
    }
}

