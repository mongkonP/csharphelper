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
     public partial class howto_line_filled_ellipse_Form1:Form
  { 


        public howto_line_filled_ellipse_Form1()
        {
            InitializeComponent();
        }

        // Drawing objects.
        private const int EllipseMargin = 10;
        private int EllipseCx, EllipseCy, EllipseWidth, EllipseHeight;
        private List<PointF> LinePoints = null;

        // Redraw on resize.
        private void howto_line_filled_ellipse_Form1_Load(object sender, EventArgs e)
        {
            this.ResizeRedraw = true;

            // Make the initial drawing objects.
            MakeDrawingObjects();
        }

        // The form has resized. Generate the drawing objects.
        private void howto_line_filled_ellipse_Form1_Resize(object sender, EventArgs e)
        {
            MakeDrawingObjects();
        }

        // Make the drawing objects.
        private void MakeDrawingObjects()
        {
            // Calculate the ellipse parameters.
            EllipseWidth = this.ClientSize.Width - 2 * EllipseMargin;
            EllipseHeight = this.ClientSize.Height - 2 * EllipseMargin;

            // Make random lines connecting points
            // on the edge of the ellipse.
            EllipseCx = this.ClientSize.Width / 2;
            EllipseCy = this.ClientSize.Height / 2;
            Random rand = new Random();
            double circumference = 2 * Math.PI * Math.Sqrt(
                (EllipseWidth * EllipseWidth + EllipseHeight * EllipseHeight) / 2);
            int num_points = (int)(circumference / 40);
            LinePoints = new List<PointF>();
            for (int i = 0; i < num_points; i++)
            {
                double theta1 = 2 * Math.PI * rand.NextDouble();
                float x1 = (float)(EllipseCx + Math.Cos(theta1) * EllipseWidth / 2);
                float y1 = (float)(EllipseCy + Math.Sin(theta1) * EllipseHeight / 2);
                LinePoints.Add(new PointF(x1, y1));

                double theta2 = 2 * Math.PI * rand.NextDouble();
                float x2 = (float)(EllipseCx + Math.Cos(theta2) * EllipseWidth / 2);
                float y2 = (float)(EllipseCy + Math.Sin(theta2) * EllipseHeight / 2);
                LinePoints.Add(new PointF(x2, y2));
            }
        }

        // Draw the ellipse and lines.
        private void howto_line_filled_ellipse_Form1_Paint(object sender, PaintEventArgs e)
        {
            if ((EllipseWidth <= 0) || (EllipseHeight <= 0)) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Fill and outline the ellipse.
            e.Graphics.FillEllipse(Brushes.LightBlue,
                EllipseMargin, EllipseMargin, EllipseWidth, EllipseHeight);
            e.Graphics.DrawEllipse(Pens.Blue,
                EllipseMargin, EllipseMargin, EllipseWidth, EllipseHeight);

            // Draw the lines.
            e.Graphics.DrawLines(Pens.Blue, LinePoints.ToArray());
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
            // howto_line_filled_ellipse_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Name = "howto_line_filled_ellipse_Form1";
            this.Text = "howto_line_filled_ellipse";
            this.Load += new System.EventHandler(this.howto_line_filled_ellipse_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_line_filled_ellipse_Form1_Paint);
            this.Resize += new System.EventHandler(this.howto_line_filled_ellipse_Form1_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

