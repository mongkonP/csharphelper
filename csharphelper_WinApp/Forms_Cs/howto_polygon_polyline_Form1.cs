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
     public partial class howto_polygon_polyline_Form1:Form
  { 


        public howto_polygon_polyline_Form1()
        {
            InitializeComponent();
        }

        // A series of points (not closed).
        private Point[] OpenPoints =
        {
            new Point(74, 20),
            new Point(97, 61),
            new Point(134, 41),
            new Point(100, 120),
            new Point(24, 87),
            new Point(9, 36),
            new Point(63, 57),
        };

        // Draw a polygon from a series of (not closed) points.
        private void picPolygon_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillPolygon(Brushes.Yellow, OpenPoints);

            using (Pen big_pen = new Pen(Color.Blue, 10))
            {
                e.Graphics.DrawPolygon(big_pen, OpenPoints);
            }
        }

        // Draw lines from a series of (not closed) points.
        private void picLines_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillPolygon(Brushes.Yellow, OpenPoints);

            using (Pen big_pen = new Pen(Color.Blue, 10))
            {
                e.Graphics.DrawLines(big_pen, OpenPoints);
            }
        }

        // A closed polygon.
        private Point[] ClosedPoints =
        {
            new Point(74, 20),
            new Point(97, 61),
            new Point(134, 41),
            new Point(100, 120),
            new Point(24, 87),
            new Point(9, 36),
            new Point(63, 57),
            new Point(74, 20),
        };

        // Draw a polygon from a series of (closed) points.
        private void picPolygon2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillPolygon(Brushes.Yellow, ClosedPoints);

            using (Pen big_pen = new Pen(Color.Blue, 10))
            {
                e.Graphics.DrawPolygon(big_pen, ClosedPoints);
            }
        }

        // Draw lines from a series of (closed) points.
        private void picLines2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillPolygon(Brushes.Yellow, ClosedPoints);

            using (Pen big_pen = new Pen(Color.Blue, 10))
            {
                e.Graphics.DrawLines(big_pen, ClosedPoints);
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
            this.picPolygon = new System.Windows.Forms.PictureBox();
            this.picLines = new System.Windows.Forms.PictureBox();
            this.picLines2 = new System.Windows.Forms.PictureBox();
            this.picPolygon2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPolygon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLines2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPolygon2)).BeginInit();
            this.SuspendLayout();
            // 
            // picPolygon
            // 
            this.picPolygon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPolygon.Location = new System.Drawing.Point(12, 12);
            this.picPolygon.Name = "picPolygon";
            this.picPolygon.Size = new System.Drawing.Size(150, 150);
            this.picPolygon.TabIndex = 0;
            this.picPolygon.TabStop = false;
            this.picPolygon.Paint += new System.Windows.Forms.PaintEventHandler(this.picPolygon_Paint);
            // 
            // picLines
            // 
            this.picLines.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picLines.Location = new System.Drawing.Point(168, 12);
            this.picLines.Name = "picLines";
            this.picLines.Size = new System.Drawing.Size(150, 150);
            this.picLines.TabIndex = 1;
            this.picLines.TabStop = false;
            this.picLines.Paint += new System.Windows.Forms.PaintEventHandler(this.picLines_Paint);
            // 
            // picLines2
            // 
            this.picLines2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picLines2.Location = new System.Drawing.Point(168, 168);
            this.picLines2.Name = "picLines2";
            this.picLines2.Size = new System.Drawing.Size(150, 150);
            this.picLines2.TabIndex = 3;
            this.picLines2.TabStop = false;
            this.picLines2.Paint += new System.Windows.Forms.PaintEventHandler(this.picLines2_Paint);
            // 
            // picPolygon2
            // 
            this.picPolygon2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPolygon2.Location = new System.Drawing.Point(12, 168);
            this.picPolygon2.Name = "picPolygon2";
            this.picPolygon2.Size = new System.Drawing.Size(150, 150);
            this.picPolygon2.TabIndex = 2;
            this.picPolygon2.TabStop = false;
            this.picPolygon2.Paint += new System.Windows.Forms.PaintEventHandler(this.picPolygon2_Paint);
            // 
            // howto_polygon_polyline_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 328);
            this.Controls.Add(this.picLines2);
            this.Controls.Add(this.picPolygon2);
            this.Controls.Add(this.picLines);
            this.Controls.Add(this.picPolygon);
            this.Name = "howto_polygon_polyline_Form1";
            this.Text = "howto_polygon_polyline";
            ((System.ComponentModel.ISupportInitialize)(this.picPolygon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLines2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPolygon2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picPolygon;
        private System.Windows.Forms.PictureBox picLines;
        private System.Windows.Forms.PictureBox picLines2;
        private System.Windows.Forms.PictureBox picPolygon2;
    }
}

