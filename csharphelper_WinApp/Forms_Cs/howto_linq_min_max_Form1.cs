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
     public partial class howto_linq_min_max_Form1:Form
  { 


        public howto_linq_min_max_Form1()
        {
            InitializeComponent();
        }

        // The points.
        private List<Point> Points = new List<Point>();

        // Add a point to the list.
        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            Points.Add(e.Location);
            picCanvas.Refresh();
        }

        // Draw the points and the bounding box.
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            // Draw the points.
            foreach (Point point in Points)
                e.Graphics.DrawEllipse(Pens.Red,
                    point.X - 2, point.Y - 2, 5, 5);

            // Draw the bounding box.
            if (Points.Count > 1)
                e.Graphics.DrawRectangle(Pens.Green,
                    BoundingBox(Points));
        }

        // Find the list's bounding box.
        private Rectangle BoundingBox(IEnumerable<Point> points)
        {
            // Find the minimum and maximum X and Y values.
            // Note: You could find these values in a single step as in:
            //      float xmin = (from Point p in Values select p.X).Min();
            // But that would make the program build the list of X values twice.
            var x_query = from Point p in points select p.X;
            int xmin = x_query.Min();
            int xmax = x_query.Max();

            var y_query = from Point p in points select p.Y;
            int ymin = y_query.Min();
            int ymax = y_query.Max();

            return new Rectangle(xmin, ymin, xmax - xmin, ymax - ymin);
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
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.Location = new System.Drawing.Point(12, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(260, 137);
            this.picCanvas.TabIndex = 8;
            this.picCanvas.TabStop = false;
            this.picCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseClick);
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // howto_linq_min_max_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_linq_min_max_Form1";
            this.Text = "howto_linq_min_max";
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;

    }
}

