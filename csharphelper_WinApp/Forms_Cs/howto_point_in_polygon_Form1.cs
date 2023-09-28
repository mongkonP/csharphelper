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
     public partial class howto_point_in_polygon_Form1:Form
  { 


        public howto_point_in_polygon_Form1()
        {
            InitializeComponent();
        }

        // The polygon's points.
        Point[] Points = 
        {
            new Point(133,  14),
            new Point( 44, 228),
            new Point(255,  83),
            new Point( 16,  74),
            new Point(214, 246),
        };

        // Draw the polygon.
        private void howto_point_in_polygon_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillPolygon(Brushes.Yellow, Points);
            e.Graphics.DrawPolygon(Pens.Red, Points);
        }

        // Set the cursor depending on whether the mouse is over the polygon.
        private void howto_point_in_polygon_Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor new_cursor;
            if (PointIsInPolygon(Points, e.Location))
                new_cursor = Cursors.Cross;
            else new_cursor = Cursors.Default;

            // Update the cursor.
            if (this.Cursor != new_cursor) this.Cursor = new_cursor;
        }

        // Return true if the point is inside the polygon.
        private bool PointIsInPolygon(Point[] polygon, Point target_point)
        {
            // Make a GraphicsPath containing the polygon.
            GraphicsPath path = new GraphicsPath();
            path.AddPolygon(polygon);

            // See if the point is inside the path.
            return path.IsVisible(target_point);            
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
            // howto_point_in_polygon_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 286);
            this.Name = "howto_point_in_polygon_Form1";
            this.Text = "howto_point_in_polygon";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_point_in_polygon_Form1_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.howto_point_in_polygon_Form1_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

