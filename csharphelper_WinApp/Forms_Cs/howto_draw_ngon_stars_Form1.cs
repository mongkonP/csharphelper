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
     public partial class howto_draw_ngon_stars_Form1:Form
  { 


        public howto_draw_ngon_stars_Form1()
        {
            InitializeComponent();
        }

        private int NumPoints = 0;

        private void btnGo_Click(object sender, EventArgs e)
        {
            int num_points;
            if (!int.TryParse(txtNumPoints.Text, out num_points))
            {
                MessageBox.Show("The number of points must be an integer.");
            }
            else if (num_points< 3)
            {
                MessageBox.Show("The number of points must be at least 3.");
            }
            else
            {
                NumPoints = num_points;
                picCanvas.Refresh();
            }
        }

        // Draw the stars.
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (NumPoints < 3) return;
            e.Graphics.Clear(picCanvas.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Get the radii.
            int r1, r2, r3;
            r3 = Math.Min(picCanvas.ClientSize.Width, picCanvas.ClientSize.Height) / 2;
            r1 = r3 / 2;
            r2 = r3 / 4;
            r3 = r1 + r2;

            // Position variables.
            int cx = picCanvas.ClientSize.Width / 2;
            int cy = picCanvas.ClientSize.Height / 2;

            // Position the original points.
            PointF[] pts1 = new PointF[NumPoints];
            PointF[] pts2 = new PointF[NumPoints];
            double theta = -Math.PI / 2;
            double dtheta = 2 * Math.PI / NumPoints;
            for (int i = 0; i < NumPoints; i++)
            {
                pts1[i].X = (float)(r1 * Math.Cos(theta));
                pts1[i].Y = (float)(r1 * Math.Sin(theta));
                pts2[i].X = (float)(r2 * Math.Cos(theta));
                pts2[i].Y = (float)(r2 * Math.Sin(theta));
                theta += dtheta;
            }

            // Draw stars.
            int max = NumPoints - 1;
            if (chkHalfOnly.Checked) max = (int)(NumPoints / 2);
            for (int skip = 1; skip <= max; skip++)
            {
                // See if they are relatively prime.
                bool draw_all = !chkRelPrimeOnly.Checked;
                if (draw_all || GCD(skip, NumPoints) == 1)
                {
                    // Draw the big version of the star.
                    DrawStar(e.Graphics, cx, cy, pts1, skip);

                    // Draw the smaller version.
                    theta = -Math.PI / 2 + skip * 2 * Math.PI / NumPoints;
                    int x = (int)(cx + r3 * Math.Cos(theta));
                    int y = (int)(cy + r3 * Math.Sin(theta));

                    DrawStar(e.Graphics, x, y, pts2, skip);
                }
            }
        }

        // Return the greatest common divisor (GCD) of a and b.
        private long GCD(long a, long b)
        {
            long remainder;

            // Pull out remainders.
            for (;;)
            {
                remainder = a % b;
                if (remainder == 0) break;
                a = b;
                b = remainder;
            }

            return b;
        }

        // Draw a star centered at (x, y) using this skip value.
        private void DrawStar(Graphics gr, int x, int y, PointF[] orig_pts, int skip)
        {
            // Make a PointF array with the points in the proper order.
            PointF[] pts = new PointF[NumPoints];
            for (int i = 0; i < NumPoints; i++)
            {
                pts[i] = orig_pts[(i * skip) % NumPoints];
            }

            // Draw the star.
            gr.TranslateTransform(x, y);
            gr.DrawPolygon(Pens.Blue, pts);
            gr.ResetTransform();
        }

        // Redraw.
        private void picCanvas_Resize(object sender, EventArgs e)
        {
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
            this.btnGo = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtNumPoints = new System.Windows.Forms.TextBox();
            this.chkRelPrimeOnly = new System.Windows.Forms.CheckBox();
            this.chkHalfOnly = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(12, 39);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(466, 466);
            this.picCanvas.TabIndex = 7;
            this.picCanvas.TabStop = false;
            this.picCanvas.Resize += new System.EventHandler(this.picCanvas_Resize);
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(104, 10);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(48, 23);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(12, 15);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(48, 16);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "# Points";
            // 
            // txtNumPoints
            // 
            this.txtNumPoints.Location = new System.Drawing.Point(66, 12);
            this.txtNumPoints.Name = "txtNumPoints";
            this.txtNumPoints.Size = new System.Drawing.Size(32, 20);
            this.txtNumPoints.TabIndex = 4;
            this.txtNumPoints.Text = "7";
            // 
            // chkRelPrimeOnly
            // 
            this.chkRelPrimeOnly.AutoSize = true;
            this.chkRelPrimeOnly.Location = new System.Drawing.Point(192, 14);
            this.chkRelPrimeOnly.Name = "chkRelPrimeOnly";
            this.chkRelPrimeOnly.Size = new System.Drawing.Size(122, 17);
            this.chkRelPrimeOnly.TabIndex = 8;
            this.chkRelPrimeOnly.Text = "Relatively prime only";
            this.chkRelPrimeOnly.UseVisualStyleBackColor = true;
            // 
            // chkHalfOnly
            // 
            this.chkHalfOnly.AutoSize = true;
            this.chkHalfOnly.Location = new System.Drawing.Point(320, 14);
            this.chkHalfOnly.Name = "chkHalfOnly";
            this.chkHalfOnly.Size = new System.Drawing.Size(67, 17);
            this.chkHalfOnly.TabIndex = 9;
            this.chkHalfOnly.Text = "Half only";
            this.chkHalfOnly.UseVisualStyleBackColor = true;
            // 
            // howto_draw_ngon_stars_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 517);
            this.Controls.Add(this.chkHalfOnly);
            this.Controls.Add(this.chkRelPrimeOnly);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtNumPoints);
            this.Name = "howto_draw_ngon_stars_Form1";
            this.Text = "howto_draw_ngon_stars";
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox picCanvas;
        internal System.Windows.Forms.Button btnGo;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtNumPoints;
        private System.Windows.Forms.CheckBox chkRelPrimeOnly;
        private System.Windows.Forms.CheckBox chkHalfOnly;
    }
}

