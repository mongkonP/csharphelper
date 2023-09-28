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
     public partial class howto_make_emf_Form1:Form
  { 


        public howto_make_emf_Form1()
        {
            InitializeComponent();
        }

        private void howto_make_emf_Form1_Load(object sender, EventArgs e)
        {
            // Make a metafile.
            Metafile mf = MakeMetafile(100, 100, "test.emf");

            // Draw on the metafile.
            DrawOnMetafile(mf);

            // Convert the metafile into a bitmap.
            Bitmap bm = MetafileToBitmap(mf);

            // Display in various ways.
            picCanvas1.Image = bm;  // Original size.
            picCanvas2.Image = bm;  // Stretches pixelated.
            picCanvas3.Image = mf;  // Stretches smoothly.
        }

        // Return a metafile with the indicated size.
        private Metafile MakeMetafile(float width, float height, string filename)
        {
            // Make a reference bitmap.
            using (Bitmap bm = new Bitmap(16, 16))
            {
                using (Graphics gr = Graphics.FromImage(bm))
                {
                    RectangleF bounds = new RectangleF(0, 0, width, height);

                    Metafile mf;
                    if ((filename != null) && (filename.Length > 0))
                        mf = new Metafile(filename, gr.GetHdc(), bounds, MetafileFrameUnit.Pixel);
                    else
                        mf = new Metafile(gr.GetHdc(), bounds, MetafileFrameUnit.Pixel);

                    gr.ReleaseHdc();
                    return mf;
                }
            }
        }

        // Draw on the metafile.
        private void DrawOnMetafile(Metafile mf)
        {
            using (Graphics gr = Graphics.FromImage(mf))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Color.Red, 5))
                {
                    gr.DrawEllipse(pen, 5, 5, 90, 90);
                }
                using (Brush brush = new SolidBrush(Color.FromArgb(255, 128, 255, 128)))
                {
                    gr.FillEllipse(brush, 5, 25, 90, 50);
                }
                using (Brush brush = new SolidBrush(Color.FromArgb(128, 128, 128, 255)))
                {
                    gr.FillEllipse(brush, 25, 5, 50, 90);
                }
                Point[] points =
                {
                    new Point(50, 5),
                    new Point(94, 50),
                    new Point(50, 94),
                    new Point(5, 50),
                };
                gr.DrawPolygon(Pens.Blue, points);
            }
        }

        // Draw the metafile onto a bitmap.
        private Bitmap MetafileToBitmap(Metafile mf)
        {
            Bitmap bm = new Bitmap(mf.Width, mf.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                GraphicsUnit unit = GraphicsUnit.Pixel;
                RectangleF source = mf.GetBounds(ref unit);

                PointF[] dest =
                {
                    new PointF(0, 0),
                    new PointF(source.Width, 0),
                    new PointF(0, source.Height),
                };
                gr.DrawImage(mf, dest, source, GraphicsUnit.Pixel);
            }
            return bm;
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
            this.picCanvas1 = new System.Windows.Forms.PictureBox();
            this.picCanvas2 = new System.Windows.Forms.PictureBox();
            this.picCanvas3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas3)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas1
            // 
            this.picCanvas1.BackColor = System.Drawing.Color.White;
            this.picCanvas1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas1.Location = new System.Drawing.Point(12, 12);
            this.picCanvas1.Name = "picCanvas1";
            this.picCanvas1.Size = new System.Drawing.Size(100, 100);
            this.picCanvas1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picCanvas1.TabIndex = 0;
            this.picCanvas1.TabStop = false;
            // 
            // picCanvas2
            // 
            this.picCanvas2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas2.BackColor = System.Drawing.Color.White;
            this.picCanvas2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas2.Location = new System.Drawing.Point(12, 118);
            this.picCanvas2.Name = "picCanvas2";
            this.picCanvas2.Size = new System.Drawing.Size(100, 100);
            this.picCanvas2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCanvas2.TabIndex = 1;
            this.picCanvas2.TabStop = false;
            // 
            // picCanvas3
            // 
            this.picCanvas3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas3.BackColor = System.Drawing.Color.White;
            this.picCanvas3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas3.Location = new System.Drawing.Point(12, 224);
            this.picCanvas3.Name = "picCanvas3";
            this.picCanvas3.Size = new System.Drawing.Size(100, 100);
            this.picCanvas3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCanvas3.TabIndex = 2;
            this.picCanvas3.TabStop = false;
            // 
            // howto_make_emf_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(124, 335);
            this.Controls.Add(this.picCanvas3);
            this.Controls.Add(this.picCanvas1);
            this.Controls.Add(this.picCanvas2);
            this.Name = "howto_make_emf_Form1";
            this.Text = "howto_make_emf";
            this.Load += new System.EventHandler(this.howto_make_emf_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas1;
        private System.Windows.Forms.PictureBox picCanvas2;
        private System.Windows.Forms.PictureBox picCanvas3;
    }
}

