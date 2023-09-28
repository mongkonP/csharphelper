using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_make_metafile_Form1:Form
  { 


        public howto_make_metafile_Form1()
        {
            InitializeComponent();
        }

        // Make and then load a metafile.
        private void howto_make_metafile_Form1_Load(object sender, EventArgs e)
        {
            // Make the metafile.
            string filename = "Epitrochoid.wmf";
            MakeMetafile(filename);

            // Display the metafile.
            picMetafile.Image = new Metafile(filename);
        }

        // Make a metafile containing an epitrochoid.
        private void MakeMetafile(string filename)
        {
            // Get a Graphics object representing the form (for reference).
            using (Graphics gr = CreateGraphics())
            {
                // Get the Graphics object's hDC. (Released later.)
                IntPtr hDC = gr.GetHdc();

                // Make a metafile that can work with the hDC.
                Rectangle rect = new Rectangle(0, 0, 100, 100);
                Metafile mf = new Metafile(filename,
                    hDC, rect, MetafileFrameUnit.Pixel);

                // Make a Graphics object to draw on the Metafile.
                using (Graphics mf_gr = Graphics.FromImage(mf))
                {
                    // Smooth.
                    mf_gr.SmoothingMode = SmoothingMode.AntiAlias;

                    // Translate and scale to make the
                    // image fill the metafile's area.
                    mf_gr.ScaleTransform(45, 45);
                    mf_gr.TranslateTransform(50, 50, MatrixOrder.Append);
                    using (Pen pen = new Pen(Color.Red, 0))
                    {
                        DrawEpitrochoid(mf_gr, pen, 13, 7, 9, 0.05f);
                    }
                }

                // Release the hDC.
                gr.ReleaseHdc(hDC);
            }
        }

        // Draw the curve on the indicated Graphics object.
        private void DrawEpitrochoid(Graphics gr, Pen pen, float a, float b, float h, float dt)
        {
            // Calculate the stop value for t.
            float stop_t = (float)(b * 2 * Math.PI);

            // Find the points.
            PointF pt0, pt1;
            pt0 = new PointF(X(a, b, h, 0), Y(a, b, h, 0));
            for (float t = dt; t <= stop_t; t += dt)
            {
                pt1 = new PointF(X(a, b, h, t), Y(a, b, h, t));
                gr.DrawLine(pen, pt0, pt1);
                pt0 = pt1;
            }
        }

        // The parametric function X(t).
        private float X(float a, float b, float h, float t)
        {
            float value = (float)((a + b) * Math.Cos(t) - h * Math.Cos(t * (a + b) / b));
            return value / (a + b + h);
        }

        // The parametric function Y(t).
        private float Y(float a, float b, float h, float t)
        {
            float value = (float)((a + b) * Math.Sin(t) - h * Math.Sin(t * (a + b) / b));
            return value / (a + b + h);
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
            this.picMetafile = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picMetafile)).BeginInit();
            this.SuspendLayout();
            // 
            // picMetafile
            // 
            this.picMetafile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picMetafile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picMetafile.Location = new System.Drawing.Point(12, 12);
            this.picMetafile.Name = "picMetafile";
            this.picMetafile.Size = new System.Drawing.Size(260, 237);
            this.picMetafile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMetafile.TabIndex = 1;
            this.picMetafile.TabStop = false;
            // 
            // howto_make_metafile_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.picMetafile);
            this.Name = "howto_make_metafile_Form1";
            this.Text = "howto_make_metafile";
            this.Load += new System.EventHandler(this.howto_make_metafile_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMetafile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picMetafile;
    }
}

