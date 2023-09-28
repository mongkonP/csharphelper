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
     public partial class howto_optional_parameters_Form1:Form
  { 


        public howto_optional_parameters_Form1()
        {
            InitializeComponent();
        }

        // Draw two diamonds.
        private void howto_optional_parameters_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw diamonds on the form.
            RectangleF rect1 = new RectangleF(4, 4,
                this.ClientSize.Width / 2 - 6,
                this.ClientSize.Height - 8);
            RectangleF rect2 = new RectangleF(
                rect1.Right + 4, 4,
                this.ClientSize.Width / 2 - 6,
                this.ClientSize.Height - 8);
            DrawDiamond(e.Graphics, rect1, Pens.Red, Brushes.Yellow);
            DrawDiamond(e.Graphics, rect2);
        }

        // Draw a diamond, optionally filling it.
        private void DrawDiamond(Graphics gr, RectangleF bounds)
        {
            DrawDiamond(gr, bounds, Pens.Black);
        }
        private void DrawDiamond(Graphics gr, RectangleF bounds, Pen diamond_pen)
        {
            DrawDiamond(gr, bounds, diamond_pen, Brushes.Transparent);
        }
        private void DrawDiamond(Graphics gr, RectangleF bounds, Brush diamond_brush)
        {
            DrawDiamond(gr, bounds, Pens.Transparent, diamond_brush);
        }
        private void DrawDiamond(Graphics gr, RectangleF bounds, Pen diamond_pen, Brush diamond_brush)
        {
            // Make the diamond's points.
            PointF[] points = new PointF[4];
            float xmid = (bounds.Left + bounds.Right) / 2;
            float ymid = (bounds.Top + bounds.Bottom) / 2;
            points[0] = new PointF(xmid, bounds.Top);
            points[1] = new PointF(bounds.Right, ymid);
            points[2] = new PointF(xmid, bounds.Bottom);
            points[3] = new PointF(bounds.Left, ymid);

            // Fill the diamond.
            gr.FillPolygon(diamond_brush, points);

            // Draw the diamond.
            gr.DrawPolygon(diamond_pen, points);
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
            // howto_optional_parameters_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 176);
            this.Name = "howto_optional_parameters_Form1";
            this.Text = "howto_optional_parameters";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_optional_parameters_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

