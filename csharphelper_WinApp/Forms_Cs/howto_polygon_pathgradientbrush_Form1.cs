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
     public partial class howto_polygon_pathgradientbrush_Form1:Form
  { 


        public howto_polygon_pathgradientbrush_Form1()
        {
            InitializeComponent();
        }

        // Redraw on resize.
        private void howto_polygon_pathgradientbrush_Form1_Load(object sender, EventArgs e)
        {
            this.ResizeRedraw = true;
        }

        // Fill a polygon with a PathGradientBrush.
        private void howto_polygon_pathgradientbrush_Form1_Paint(object sender, PaintEventArgs e)
        {
            // Make the points for a hexagon.
            PointF[] pts = new PointF[6];
            int cx = (int)(this.ClientSize.Width / 2);
            int cy = (int)(this.ClientSize.Height / 2);
            double theta = 0;
            double dtheta = 2 * Math.PI / 6;
            for (int i = 0; i < pts.Length; i++)
            {
                pts[i].X = (int)(cx + cx * Math.Cos(theta));
                pts[i].Y = (int)(cy + cy * Math.Sin(theta));
                theta += dtheta;
            }

            // Make a path gradient brush.
            using (PathGradientBrush path_brush = new PathGradientBrush(pts))
            {
                // Define the center and surround colors.
                path_brush.CenterColor = Color.White;
                path_brush.SurroundColors = new Color[] {
                    Color.Red, Color.Yellow, Color.Lime,
                    Color.Cyan, Color.Blue, Color.Magenta
                };
                    
                // Fill the hexagon.
                e.Graphics.FillPolygon(path_brush, pts);
            }


            // Outline the hexagon.
            e.Graphics.DrawPolygon(Pens.Black, pts);
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
            // howto_polygon_pathgradientbrush_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 381);
            this.Name = "howto_polygon_pathgradientbrush_Form1";
            this.Text = "howto_polygon_pathgradientbrush";
            this.Load += new System.EventHandler(this.howto_polygon_pathgradientbrush_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_polygon_pathgradientbrush_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

