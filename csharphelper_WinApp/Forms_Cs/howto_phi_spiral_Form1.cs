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
     public partial class howto_phi_spiral_Form1:Form
  { 


        public howto_phi_spiral_Form1()
        {
            InitializeComponent();
        }

        // Orientations for the rectangles.
        private enum RectOrientations
        {
            RemoveLeft,
            RemoveTop,
            RemoveRight,
            RemoveBottom
        }

        // Draw the rectangles.
        private void howto_phi_spiral_Form1_Load(object sender, EventArgs e)
        {
            DrawBitmap();
        }
        private void howto_phi_spiral_Form1_Resize(object sender, EventArgs e)
        {
            DrawBitmap();
        }

        // Draw the bitmap.
        private void DrawBitmap()
        {
            Bitmap bm;

            // Determine the first rectangle's orientation and dimensions.
            float phi = (float)(1 + Math.Sqrt(5)) / 2;
            RectOrientations orientation;
            int client_wid = picRectangles.ClientSize.Width;
            int client_hgt = picRectangles.ClientSize.Height;
            float wid, hgt;                 // The rectangle's size.
            if (client_wid > client_hgt)
            {
                // Horizontal rectangle.
                orientation = RectOrientations.RemoveLeft;
                if (client_wid / (double)client_hgt > phi)
                {
                    hgt = client_hgt;
                    wid = hgt * phi;
                }
                else
                {
                    wid = client_wid;
                    hgt = wid / phi;
                }
            }
            else
            {
                // Vertical rectangle.
                orientation = RectOrientations.RemoveTop;
                if (client_hgt / (double)client_wid > phi)
                {
                    wid = client_wid;
                    hgt = wid * phi;
                }
                else
                {
                    hgt = client_hgt;
                    wid = hgt / phi;
                }
            }

            // Allow a margin.
            wid *= 0.95f;
            hgt *= 0.95f;

            // Center it.
            float x = (client_wid - wid) / 2;
            float y = (client_hgt - hgt) / 2;

            // Make the Bitmap.
            bm = new Bitmap(client_wid, client_hgt);

            // Draw the rectangles.
            using (Graphics gr = Graphics.FromImage(bm))
            {
                // Draw the rectangles.
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                List<PointF> points = new List<PointF>();
                DrawPhiRectanglesOnGraphics(gr, points, x, y, wid, hgt, orientation);

                // Draw the points.
                gr.DrawLines(Pens.Red, points.ToArray());
                //gr.DrawCurve(Pens.Green, points.ToArray());
            }

            // Display the result.
            picRectangles.Image = bm;
            picRectangles.Refresh();
        }

        // Draw rectangles on a Graphics object.
        private void DrawPhiRectanglesOnGraphics(Graphics gr, List<PointF> points, float x, float y, float wid, float hgt, RectOrientations orientation)
        {
            if ((wid < 1) || (hgt < 1)) return;

            // Draw this rectangle.
            gr.DrawRectangle(Pens.Blue, x, y, wid, hgt);

            // Recursively draw the next rectangle.
            switch (orientation)
            {
                case RectOrientations.RemoveLeft:
                    points.Add(new PointF(x, y + hgt));
                    x += hgt;
                    wid -= hgt;
                    orientation = RectOrientations.RemoveTop;
                    break;
                case RectOrientations.RemoveTop:
                    points.Add(new PointF(x, y));
                    y += wid;
                    hgt -= wid;
                    orientation = RectOrientations.RemoveRight;
                    break;
                case RectOrientations.RemoveRight:
                    points.Add(new PointF(x + wid, y));
                    wid -= hgt;
                    orientation = RectOrientations.RemoveBottom;
                    break;
                case RectOrientations.RemoveBottom:
                    points.Add(new PointF(x + wid, y + hgt));
                    hgt -= wid;
                    orientation = RectOrientations.RemoveLeft;
                    break;
            }
            DrawPhiRectanglesOnGraphics(gr, points, x, y, wid, hgt, orientation);
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
            this.picRectangles = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picRectangles)).BeginInit();
            this.SuspendLayout();
            // 
            // picRectangles
            // 
            this.picRectangles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picRectangles.BackColor = System.Drawing.Color.White;
            this.picRectangles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picRectangles.Location = new System.Drawing.Point(12, 12);
            this.picRectangles.Name = "picRectangles";
            this.picRectangles.Size = new System.Drawing.Size(398, 256);
            this.picRectangles.TabIndex = 1;
            this.picRectangles.TabStop = false;
            // 
            // howto_phi_spiral_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 280);
            this.Controls.Add(this.picRectangles);
            this.Name = "howto_phi_spiral_Form1";
            this.Text = "howto_phi_spiral";
            this.Load += new System.EventHandler(this.howto_phi_spiral_Form1_Load);
            this.Resize += new System.EventHandler(this.howto_phi_spiral_Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picRectangles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picRectangles;
    }
}

