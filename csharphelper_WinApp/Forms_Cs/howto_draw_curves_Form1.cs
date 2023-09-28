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
     public partial class howto_draw_curves_Form1:Form
  { 


        public howto_draw_curves_Form1()
        {
            InitializeComponent();
        }

        // True when we are drawing.
        private bool Drawing = true;

        // The currently selected points.
        private List<Point> Points = new List<Point>();

        // The curve's tension.
        private float Tension = 0.5f;

        // The user clicked. Add a point,
        // stop drawing, or start a new curve.
        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            // See if we are currently drawing.
            if (Drawing)
            {
                // See if this is the left or right mouse button.
                if (e.Button == MouseButtons.Left)
                {
                    // Left button. Add a new point.
                    Points.Add(e.Location);
                }
                else
                {
                    // Right button. Stop drawing.
                    Drawing = false;
                }
            }
            else
            {
                // We are not drawing. Start a new curve.
                Drawing = true;
                Points = new List<Point>();

                // Add a new point.
                Points.Add(e.Location);
            }

            // Redraw.
            picCanvas.Refresh();
        }

        // Draw the curve and its points.
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the curve.
            if (Points.Count > 1)
            {
                // Make a pen to use.
                using (Pen pen = new Pen(Color.Blue))
                {
                    // See if we're currently drawing.
                    if (Drawing)
                    {
                        // Use a dashed pen.
                        pen.DashPattern = new float[] { 5, 5 };
                    }

                    // Draw the curve.
                    e.Graphics.DrawCurve(pen, Points.ToArray(), Tension);
                }
            }

            // Draw the points.
            if (Drawing && (Points.Count > 0))
            {
                const int r = 4;
                foreach (Point point in Points)
                {
                    Rectangle rect = new Rectangle(
                        point.X - r, point.Y - r, 2 * r, 2 * r);
                    e.Graphics.FillRectangle(Brushes.White, rect);
                    e.Graphics.DrawRectangle(Pens.Black, rect);
                }
            }
        }

        // Adjust the curve's tension.
        private void scrTension_Scroll(object sender, ScrollEventArgs e)
        {
            Tension = scrTension.Value / 10f;
            lblTension.Text = Tension.ToString();
            picCanvas.Refresh();
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
            this.scrTension = new System.Windows.Forms.HScrollBar();
            this.lblTension = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(12, 38);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(260, 211);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseClick);
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // scrTension
            // 
            this.scrTension.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scrTension.Location = new System.Drawing.Point(12, 12);
            this.scrTension.Maximum = 59;
            this.scrTension.Name = "scrTension";
            this.scrTension.Size = new System.Drawing.Size(228, 20);
            this.scrTension.TabIndex = 3;
            this.scrTension.Value = 5;
            this.scrTension.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrTension_Scroll);
            // 
            // lblTension
            // 
            this.lblTension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTension.Location = new System.Drawing.Point(243, 12);
            this.lblTension.Name = "lblTension";
            this.lblTension.Size = new System.Drawing.Size(29, 20);
            this.lblTension.TabIndex = 4;
            this.lblTension.Text = "0.5";
            this.lblTension.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // howto_draw_curves_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblTension);
            this.Controls.Add(this.scrTension);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_draw_curves_Form1";
            this.Text = "howto_draw_curves";
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.HScrollBar scrTension;
        private System.Windows.Forms.Label lblTension;
    }
}

