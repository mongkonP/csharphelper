using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_make_random_polygon;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_make_random_polygon_Form1:Form
  { 


        public howto_make_random_polygon_Form1()
        {
            InitializeComponent();
        }

        // The polygon.
        private PointF[] Points = null;

        // Draw the polygon.
        private void howto_make_random_polygon_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            if (Points == null) return;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.DrawPolygon(Pens.Blue, Points);

            // For debugging: Draw a bounding ellipse.
            //Rectangle bounds = new Rectangle(
            //    10, btnGo.Bottom + 10,
            //    ClientSize.Width - 20,
            //    ClientSize.Height - btnGo.Bottom - 20);
            //e.Graphics.DrawEllipse(Pens.Red, bounds);
        }

        // Make a random polygon.
        private void btnGo_Click(object sender, EventArgs e)
        {
            // Make the polygon.
            Rectangle bounds = new Rectangle(
                10, btnGo.Bottom + 10,
                ClientSize.Width - 20,
                ClientSize.Height - btnGo.Bottom - 20);
            Points = MakeRandomPolygon(
                (int)nudVertices.Value,
                bounds);

            // Redraw.
            Refresh();
        }

        // Make a random polygon inside the bounding rectangle.
        private static Random rand = new Random();
        public static PointF[] MakeRandomPolygon(int num_vertices, Rectangle bounds)
        {
            // Pick random radii.
            double[] radii = new double[num_vertices];
            const double min_radius = 0.5;
            const double max_radius = 1.0;
            for (int i = 0; i < num_vertices; i++)
            {
                radii[i] = rand.NextDouble(min_radius, max_radius);
            }

            // Pick random angle weights.
            double[] angle_weights = new double[num_vertices];
            const double min_weight = 1.0;
            const double max_weight = 10.0;
            double total_weight = 0;
            for (int i = 0; i < num_vertices; i++)
            {
                angle_weights[i] = rand.NextDouble(min_weight, max_weight);
                total_weight += angle_weights[i];
            }

            // Convert the weights into fractions of 2 * Pi radians.
            double[] angles = new double[num_vertices];
            double to_radians = 2 * Math.PI / total_weight;
            for (int i = 0; i < num_vertices; i++)
            {
                angles[i] = angle_weights[i] * to_radians;
            }

            // Calculate the points' locations.
            PointF[] points = new PointF[num_vertices];
            float rx = bounds.Width / 2f;
            float ry = bounds.Height / 2f;
            float cx = bounds.MidX();
            float cy = bounds.MidY();
            double theta = 0;
            for (int i = 0; i < num_vertices; i++)
            {
                points[i] = new PointF(
                    cx + (int)(rx * radii[i] * Math.Cos(theta)),
                    cy + (int)(ry * radii[i] * Math.Sin(theta)));
                theta += angles[i];
            }

            // Return the points.
            return points;
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
            this.btnGo = new System.Windows.Forms.Button();
            this.nudVertices = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudVertices)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(257, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 5;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // nudVertices
            // 
            this.nudVertices.Location = new System.Drawing.Point(66, 15);
            this.nudVertices.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudVertices.Name = "nudVertices";
            this.nudVertices.Size = new System.Drawing.Size(50, 20);
            this.nudVertices.TabIndex = 4;
            this.nudVertices.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Vertices:";
            // 
            // howto_make_random_polygon_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 261);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.nudVertices);
            this.Controls.Add(this.label1);
            this.Name = "howto_make_random_polygon_Form1";
            this.Text = "howto_make_random_polygon";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_make_random_polygon_Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.nudVertices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.NumericUpDown nudVertices;
        private System.Windows.Forms.Label label1;
    }
}

