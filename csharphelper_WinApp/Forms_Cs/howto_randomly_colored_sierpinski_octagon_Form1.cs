using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

using howto_randomly_colored_sierpinski_octagon;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_randomly_colored_sierpinski_octagon_Form1:Form
  { 


        public howto_randomly_colored_sierpinski_octagon_Form1()
        {
            InitializeComponent();
        }

        // The root of the Octagon object hierarchy.
        private Octagon Root = null;

        // Redraw.
        private void nudDepth_ValueChanged(object sender, EventArgs e)
        {
            MakeOctagons();
        }
        //Refresh
        private void button_refresh_Click(object sender, EventArgs e)
        {
            MakeOctagons();
        }


        // Make the Octagon objects and redraw.
        private void MakeOctagons()
        {
            // Build the Root.
            int depth = (int)nudDepth.Value;

            PointF center = new PointF(
                picCanvas.ClientSize.Width / 2,
                picCanvas.ClientSize.Height / 2);
            float radius = (float)Math.Min(center.X, center.Y);
            radius -= 5;
            Root = MakeOctagon(depth, center, radius);

            // Redraw.
            picCanvas.Refresh();
        }

        // Scale factor for moving to smaller octagons.
        private float size_scale = (float)(1.0 /
            (2.0 * (1 + Math.Cos(Math.PI / 180 * 45))));

        // Recursively generate a Octagon and its descendants.
        private Octagon MakeOctagon(int depth, PointF center, float radius)
        {
            // Make the Octagon.
            Octagon parent = new Octagon(GetOctagonPoints(center, radius));

            // If we are not done recursing, make children.
            if (depth > 0)
            {
                // Find the smaller octagons' centers.
                float d = radius - radius * size_scale;
                PointF[] centers = GetOctagonPoints(center, d);

                // Recursively draw the smaller octagons.
                foreach (PointF point in centers)
                {
                    parent.Children.Add(MakeOctagon(
                        depth - 1, point, radius * size_scale));
                }
            }

            return parent;
        }

        // Find the octagon's corners.
        private PointF[] GetOctagonPoints(PointF center, float radius)
        {
            PointF[] points = new PointF[8];
            double theta = -Math.PI / 2.0;
            double dtheta = 2.0 * Math.PI / 8.0;
            for (int i = 0; i < 8; i++)
            {
                points[i] = new PointF(
                    center.X + (float)(radius * Math.Cos(theta)),
                    center.Y + (float)(radius * Math.Sin(theta)));
                theta += dtheta;
            }
            return points;
        }

        // Draw.
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(picCanvas.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            if (Root == null) return;

            Root.Draw(e.Graphics);
        }

        // Draw the initial octagon.
        private void howto_randomly_colored_sierpinski_octagon_Form1_Load(object sender, EventArgs e)
        {
            MakeOctagons();
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
            this.nudDepth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.button_refresh = new System.Windows.Forms.Button();
            this.sfdImage = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDepth)).BeginInit();
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
            this.picCanvas.Size = new System.Drawing.Size(608, 528);
            this.picCanvas.TabIndex = 5;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // nudDepth
            // 
            this.nudDepth.Location = new System.Drawing.Point(57, 15);
            this.nudDepth.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.nudDepth.Name = "nudDepth";
            this.nudDepth.Size = new System.Drawing.Size(46, 20);
            this.nudDepth.TabIndex = 4;
            this.nudDepth.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudDepth.ValueChanged += new System.EventHandler(this.nudDepth_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Depth:";
            // 
            // button_refresh
            // 
            this.button_refresh.Location = new System.Drawing.Point(109, 12);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(67, 22);
            this.button_refresh.TabIndex = 7;
            this.button_refresh.Text = "Refresh";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // sfdImage
            // 
            this.sfdImage.Filter = "Graphic FIles|*.bmp;*.jpg;*.gif;*.png|All Files|*.*";
            // 
            // howto_randomly_colored_sierpinski_octagon_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 578);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.nudDepth);
            this.Controls.Add(this.label1);
            this.Name = "howto_randomly_colored_sierpinski_octagon_Form1";
            this.Text = "howto_randomly_colored_sierpinski_octagon";
            this.Load += new System.EventHandler(this.howto_randomly_colored_sierpinski_octagon_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDepth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.NumericUpDown nudDepth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.SaveFileDialog sfdImage;
    }
}

