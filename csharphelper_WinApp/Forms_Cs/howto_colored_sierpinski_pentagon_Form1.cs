using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

using howto_colored_sierpinski_pentagon;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_colored_sierpinski_pentagon_Form1:Form
  { 


        public howto_colored_sierpinski_pentagon_Form1()
        {
            InitializeComponent();
        }

        // The Pentagon objects.
        private List<Pentagon> Pentagons = new List<Pentagon>();

        // Set the selected color.
        private void colorLabel_Click(object sender, EventArgs e)
        {
            Label clicked_label = sender as Label;
            lblSelected.BackColor = clicked_label.BackColor;
        }

        // Redraw.
        private void nudDepth_ValueChanged(object sender, EventArgs e)
        {
            MakePentagons();
        }

        // Make the Pentagon objects and redraw.
        private void MakePentagons()
        {
            // Build a new list of Pentagons.
            int depth = (int)nudDepth.Value;
            PointF center = new PointF(
                picPentagon.ClientSize.Width / 2,
                picPentagon.ClientSize.Height / 2);
            float radius = (float)Math.Min(center.X, center.Y);
            Pentagons = new List<Pentagon>();
            MakePentagons(depth, center, radius);

            // Redraw.
            picPentagon.Refresh();
        }

        // Scale factor for moving to smaller pentagons.
        private float size_scale = (float)(1.0 / (2.0 * (1 + Math.Cos(Math.PI / 180 * 72))));

        // Recursively generate the Pentagons.
        private void MakePentagons(int depth, PointF center, float radius)
        {
            // If we are done recursing, add a new Pentagon to the list.
            if (depth <= 0)
            {
                // Find the pentagon's corners.
                Pentagons.Add(new Pentagon(
                    GetPentagonPoints(center, radius),
                    lblSelected.BackColor));
            }
            else
            {
                // Find the smaller pentagons' centers.
                float d = radius - radius * size_scale;
                PointF[] centers = GetPentagonPoints(center, d);

                // Recursively draw the smaller pentagons.
                foreach (PointF point in centers)
                {
                    MakePentagons(depth - 1, point, radius * size_scale);
                }
            }
        }

        // Find the pentagon's corners.
        private PointF[] GetPentagonPoints(PointF center, float radius)
        {
            PointF[] points = new PointF[5];
            double theta = -Math.PI / 2.0;
            double dtheta = 2.0 * Math.PI / 5.0;
            for (int i = 0; i < 5; i++)
            {
                points[i] = new PointF(
                    center.X + (float)(radius * Math.Cos(theta)),
                    center.Y + (float)(radius * Math.Sin(theta)));
                theta += dtheta;
            }
            return points;
        }

        // Draw.
        private void picPentagon_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(picPentagon.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            foreach (Pentagon pentagon in Pentagons)
                pentagon.Draw(e.Graphics);
        }

        // Color the clicked Pentagon.
        private void picPentagon_MouseClick(object sender, MouseEventArgs e)
        {
            // Get the clicked point.
            PointF point = e.Location;

            // Find the clicked Pentagon.
            foreach (Pentagon pentagon in Pentagons)
            {
                if (pentagon.Contains(point))
                {
                    // Color this pentagon and redraw.
                    pentagon.FillColor = lblSelected.BackColor;
                    picPentagon.Refresh();
                    return;
                }
            }
        }

        // Draw the initial pentagon.
        private void howto_colored_sierpinski_pentagon_Form1_Load(object sender, EventArgs e)
        {
            MakePentagons();
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
            this.picPentagon = new System.Windows.Forms.PictureBox();
            this.nudDepth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSelected = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picPentagon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDepth)).BeginInit();
            this.SuspendLayout();
            // 
            // picPentagon
            // 
            this.picPentagon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picPentagon.BackColor = System.Drawing.Color.White;
            this.picPentagon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPentagon.Location = new System.Drawing.Point(64, 38);
            this.picPentagon.Name = "picPentagon";
            this.picPentagon.Size = new System.Drawing.Size(258, 261);
            this.picPentagon.TabIndex = 5;
            this.picPentagon.TabStop = false;
            this.picPentagon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picPentagon_MouseClick);
            this.picPentagon.Paint += new System.Windows.Forms.PaintEventHandler(this.picPentagon_Paint);
            // 
            // nudDepth
            // 
            this.nudDepth.Location = new System.Drawing.Point(57, 12);
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
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Depth:";
            // 
            // lblSelected
            // 
            this.lblSelected.BackColor = System.Drawing.Color.Black;
            this.lblSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSelected.Location = new System.Drawing.Point(119, 12);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(20, 20);
            this.lblSelected.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 20);
            this.label2.TabIndex = 7;
            this.label2.Click += new System.EventHandler(this.colorLabel_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(38, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 20);
            this.label3.TabIndex = 8;
            this.label3.Click += new System.EventHandler(this.colorLabel_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(38, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 20);
            this.label4.TabIndex = 10;
            this.label4.Click += new System.EventHandler(this.colorLabel_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Red;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(12, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 20);
            this.label5.TabIndex = 9;
            this.label5.Click += new System.EventHandler(this.colorLabel_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(38, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 20);
            this.label6.TabIndex = 14;
            this.label6.Click += new System.EventHandler(this.colorLabel_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Yellow;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(12, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 20);
            this.label7.TabIndex = 13;
            this.label7.Click += new System.EventHandler(this.colorLabel_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(38, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 20);
            this.label8.TabIndex = 12;
            this.label8.Click += new System.EventHandler(this.colorLabel_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(12, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 20);
            this.label9.TabIndex = 11;
            this.label9.Click += new System.EventHandler(this.colorLabel_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(38, 220);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 20);
            this.label10.TabIndex = 22;
            this.label10.Click += new System.EventHandler(this.colorLabel_Click);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Fuchsia;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(12, 220);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 20);
            this.label11.TabIndex = 21;
            this.label11.Click += new System.EventHandler(this.colorLabel_Click);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Location = new System.Drawing.Point(38, 194);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 20);
            this.label12.TabIndex = 20;
            this.label12.Click += new System.EventHandler(this.colorLabel_Click);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Blue;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Location = new System.Drawing.Point(12, 194);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 20);
            this.label13.TabIndex = 19;
            this.label13.Click += new System.EventHandler(this.colorLabel_Click);
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Location = new System.Drawing.Point(38, 168);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(20, 20);
            this.label14.TabIndex = 18;
            this.label14.Click += new System.EventHandler(this.colorLabel_Click);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Cyan;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Location = new System.Drawing.Point(12, 168);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(20, 20);
            this.label15.TabIndex = 17;
            this.label15.Click += new System.EventHandler(this.colorLabel_Click);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Location = new System.Drawing.Point(38, 142);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(20, 20);
            this.label16.TabIndex = 16;
            this.label16.Click += new System.EventHandler(this.colorLabel_Click);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Lime;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Location = new System.Drawing.Point(12, 142);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(20, 20);
            this.label17.TabIndex = 15;
            this.label17.Click += new System.EventHandler(this.colorLabel_Click);
            // 
            // howto_colored_sierpinski_pentagon_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 311);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.picPentagon);
            this.Controls.Add(this.nudDepth);
            this.Controls.Add(this.label1);
            this.Name = "howto_colored_sierpinski_pentagon_Form1";
            this.Text = "howto_colored_sierpinski_pentagon";
            this.Load += new System.EventHandler(this.howto_colored_sierpinski_pentagon_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPentagon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDepth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPentagon;
        private System.Windows.Forms.NumericUpDown nudDepth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
    }
}

