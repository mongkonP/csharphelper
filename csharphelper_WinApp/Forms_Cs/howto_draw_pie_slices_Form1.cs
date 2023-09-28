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
     public partial class howto_draw_pie_slices_Form1:Form
  { 


        public howto_draw_pie_slices_Form1()
        {
            InitializeComponent();
        }

        // Draw pie slices.
        private void howto_draw_pie_slices_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            const int margin = 10;
            const int width = 100;
            Graphics gr = e.Graphics;
            Pen outline_pen = Pens.Red;
            Brush fill_brush = Brushes.LightGreen;

            using (Pen ellipse_pen = new Pen(Color.Blue))
            {
                ellipse_pen.DashPattern = new float[] { 5, 5 };

                // Northeast wedge.
                Rectangle rect = new Rectangle(margin + 30, 10, width, width);
                gr.DrawEllipse(ellipse_pen, rect);
                gr.FillPie(fill_brush, rect, 300, 30);
                gr.DrawPie(outline_pen, rect, 300, 30);

                // Everything else.
                rect.X += width + margin;
                gr.DrawEllipse(ellipse_pen, rect);
                gr.FillPie(fill_brush, rect, 300, -330);
                gr.DrawPie(outline_pen, rect, 300, -330);

                // East wedge.
                rect.Y += width + margin;
                rect.X = margin + 30;
                gr.DrawEllipse(ellipse_pen, rect);
                gr.FillPie(fill_brush, rect, 315, 90);
                gr.DrawPie(outline_pen, rect, 315, 90);

                // Everything else.
                rect.X += width + margin;
                gr.DrawEllipse(ellipse_pen, rect);
                gr.FillPie(fill_brush, rect, 315, -270);
                gr.DrawPie(outline_pen, rect, 315, -270);

                // Northwest quadrant.
                rect.Y += width + margin;
                rect.X = margin + 30;
                gr.DrawEllipse(ellipse_pen, rect);
                gr.FillPie(fill_brush, rect, 180, 90);
                gr.DrawPie(outline_pen, rect, 180, 90);

                // Everything else.
                rect.X += width + margin;
                gr.DrawEllipse(ellipse_pen, rect);
                gr.FillPie(fill_brush, rect, 180, -270);
                gr.DrawPie(outline_pen, rect, 180, -270);
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
            // howto_draw_pie_slices_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 345);
            this.Name = "howto_draw_pie_slices_Form1";
            this.Text = "howto_draw_pie_slices";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_draw_pie_slices_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

