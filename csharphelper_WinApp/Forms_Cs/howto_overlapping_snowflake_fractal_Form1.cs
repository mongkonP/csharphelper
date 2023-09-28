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
     public partial class howto_overlapping_snowflake_fractal_Form1:Form
  { 


        public howto_overlapping_snowflake_fractal_Form1()
        {
            InitializeComponent();
        }

        // Coordinates of the points in the initiator.
        private List<PointF> Initiator;

        // Angles and distances for the generator.
        private float ScaleFactor;
        private List<float> GeneratorDTheta;

        private void btnGo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            // Define an initiator and generator.
            Initiator = new List<PointF>();
            float sqrt_3 = (float)Math.Sqrt(3.0);
            float side1 = (picCanvas.ClientSize.Height - 10f) / 2f;
            float side2 = (picCanvas.ClientSize.Width - 10f) / 2f / sqrt_3 * 2f;
            float side = Math.Min(side1, side2);
            float height = side * sqrt_3 / 2f;
            float y1 = (picCanvas.ClientSize.Height - 2 * side) / 2;
            float y2 = y1 + side / 2;
            float y3 = y2 + side;
            float y4 = y1 + 2 * side;
            float x1 = (picCanvas.ClientSize.Width - 2 * height) / 2;
            float x2 = x1 + height;
            float x3 = x2 + height;
            Initiator.Add(new PointF(x1, y2));
            Initiator.Add(new PointF(x2, y1));
            Initiator.Add(new PointF(x3, y2));
            Initiator.Add(new PointF(x3, y3));
            Initiator.Add(new PointF(x2, y4));
            Initiator.Add(new PointF(x1, y3));
            Initiator.Add(new PointF(x1, y2));

            //// Initiator for drawing a single generator.
            //Initiator = new List<PointF>();
            //Initiator.Add(new PointF(5, picCanvas.ClientSize.Height / 3));
            //Initiator.Add(new PointF(
            //    picCanvas.ClientSize.Width - 5,
            //    picCanvas.ClientSize.Height / 3));

            ScaleFactor = (float)(1.0 / 3.0);

            GeneratorDTheta = new List<float>();
            float pi_over_3 = (float)(Math.PI / 3f);
            GeneratorDTheta.Add(0);
            GeneratorDTheta.Add(pi_over_3);
            GeneratorDTheta.Add(pi_over_3);
            GeneratorDTheta.Add(-2 * pi_over_3);
            GeneratorDTheta.Add(-pi_over_3);
            GeneratorDTheta.Add(-pi_over_3);
            GeneratorDTheta.Add(2 * pi_over_3);

            // Get the parameters.
            int depth = int.Parse(txtDepth.Text);

            Bitmap bm = new Bitmap(
                picCanvas.ClientSize.Width,
                picCanvas.ClientSize.Height);
            picCanvas.Image = bm;

            // Draw the snowflake.
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                DrawSnowflake(gr, depth);
            }

            this.Cursor = Cursors.Default;
        }

        // Draw the complete snowflake.
        private void DrawSnowflake(Graphics gr, int depth)
        {
            gr.Clear(picCanvas.BackColor);

            // Draw the snowflake.
            for (int i = 1; i < Initiator.Count; i++)
            {
                PointF p1 = Initiator[i - 1];
                PointF p2 = Initiator[i];

                float dx = p2.X - p1.X;
                float dy = p2.Y - p1.Y;
                float length = (float)Math.Sqrt(dx * dx + dy * dy);
                float theta = (float)Math.Atan2(dy, dx);
                DrawSnowflakeEdge(gr, depth, ref p1, theta, length);
            }
        }

        // Recursively draw a snowflake edge starting at
        // (x1, y1) in direction theta and distance dist.
        // Leave the coordinates of the endpoint in
        // (x1, y1).
        private void DrawSnowflakeEdge(Graphics gr, int depth, ref PointF p1, float theta, float dist)
        {
            if (depth == 0)
            {
                PointF p2 = new PointF(
                    (float)(p1.X + dist * Math.Cos(theta)),
                    (float)(p1.Y + dist * Math.Sin(theta)));
                gr.DrawLine(Pens.Blue, p1, p2);
                p1 = p2;
                return;
            }

            // Recursively draw the edge.
            dist *= ScaleFactor;
            for (int i = 0; i < GeneratorDTheta.Count; i++)
            {
                theta += GeneratorDTheta[i];
                DrawSnowflakeEdge(gr, depth - 1, ref p1, theta, dist);
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
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtDepth = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(2, 35);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(272, 272);
            this.picCanvas.TabIndex = 18;
            this.picCanvas.TabStop = false;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(107, 6);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(40, 24);
            this.btnGo.TabIndex = 17;
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtDepth
            // 
            this.txtDepth.Location = new System.Drawing.Point(57, 9);
            this.txtDepth.Name = "txtDepth";
            this.txtDepth.Size = new System.Drawing.Size(32, 20);
            this.txtDepth.TabIndex = 16;
            this.txtDepth.Text = "3";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 12);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(39, 13);
            this.Label1.TabIndex = 15;
            this.Label1.Text = "Depth:";
            // 
            // howto_overlapping_snowflake_fractal_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 313);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtDepth);
            this.Controls.Add(this.Label1);
            this.Name = "howto_overlapping_snowflake_fractal_Form1";
            this.Text = "howto_overlapping_snowflake_fractal";
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox picCanvas;
        internal System.Windows.Forms.Button btnGo;
        internal System.Windows.Forms.TextBox txtDepth;
        internal System.Windows.Forms.Label Label1;
    }
}

