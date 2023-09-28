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
     public partial class howto_sierpinski_triangle_Form1:Form
  { 


        public howto_sierpinski_triangle_Form1()
        {
            InitializeComponent();
        }

        private int Level = 3;

        private void howto_sierpinski_triangle_Form1_Load(object sender, EventArgs e)
        {
            DrawGasket();
        }
        private void btnDraw_Click(object sender, EventArgs e)
        {
            DrawGasket();
        }
        private void howto_sierpinski_triangle_Form1_Resize(object sender, EventArgs e)
        {
            DrawGasket();
        }

        // Draw the triangle.
        private void DrawGasket()
        {
            Level = int.Parse(txtLevel.Text);

            Bitmap bm = new Bitmap(
                picGasket.ClientSize.Width,
                picGasket.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(Color.White);
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                // Draw the top-level triangle.
                const float margin = 10;
                PointF top_point = new PointF(
                    picGasket.ClientSize.Width / 2f,
                    margin);
                PointF left_point = new PointF(
                    margin,
                    picGasket.ClientSize.Height - margin);
                PointF right_point = new PointF(
                    picGasket.ClientRectangle.Right - margin,
                    picGasket.ClientRectangle.Bottom - margin);
                DrawTriangle(gr, Level, top_point, left_point, right_point);
            }

            // Display the result.
            picGasket.Image = bm;

            // Save the bitmap into a file.
            bm.Save("Triangle " + Level + ".bmp");
        }

        // Draw a triangle between the points.
        private void DrawTriangle(Graphics gr, int level,
            PointF top_point, PointF left_point, PointF right_point)
        {
            // See if we should stop.
            if (level == 0)
            {
                // Fill the triangle.
                PointF[] points =
                {
                    top_point, right_point, left_point
                };
                gr.FillPolygon(Brushes.Red, points);
            }
            else
            {
                // Find the edge midpoints.
                PointF left_mid = new PointF(
                    (top_point.X + left_point.X) / 2f,
                    (top_point.Y + left_point.Y) / 2f);
                PointF right_mid = new PointF(
                    (top_point.X + right_point.X) / 2f,
                    (top_point.Y + right_point.Y) / 2f);
                PointF bottom_mid = new PointF(
                    (left_point.X + right_point.X) / 2f,
                    (left_point.Y + right_point.Y) / 2f);

                // Recursively draw smaller triangles.
                DrawTriangle(gr, level - 1, top_point, left_mid, right_mid);
                DrawTriangle(gr, level - 1, left_mid, left_point, bottom_mid);
                DrawTriangle(gr, level - 1, right_mid, bottom_mid, right_point);
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtLevel = new System.Windows.Forms.TextBox();
            this.btnDraw = new System.Windows.Forms.Button();
            this.picGasket = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picGasket)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Level:";
            // 
            // txtLevel
            // 
            this.txtLevel.Location = new System.Drawing.Point(54, 14);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new System.Drawing.Size(31, 20);
            this.txtLevel.TabIndex = 1;
            this.txtLevel.Text = "4";
            this.txtLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(91, 12);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 2;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // picGasket
            // 
            this.picGasket.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGasket.BackColor = System.Drawing.Color.White;
            this.picGasket.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGasket.Location = new System.Drawing.Point(12, 41);
            this.picGasket.Name = "picGasket";
            this.picGasket.Size = new System.Drawing.Size(285, 208);
            this.picGasket.TabIndex = 3;
            this.picGasket.TabStop = false;
            // 
            // howto_sierpinski_triangle_Form1
            // 
            this.AcceptButton = this.btnDraw;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 261);
            this.Controls.Add(this.picGasket);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.txtLevel);
            this.Controls.Add(this.label1);
            this.Name = "howto_sierpinski_triangle_Form1";
            this.Text = "howto_sierpinski_triangle";
            this.Load += new System.EventHandler(this.howto_sierpinski_triangle_Form1_Load);
            this.Resize += new System.EventHandler(this.howto_sierpinski_triangle_Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picGasket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLevel;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.PictureBox picGasket;
    }
}

