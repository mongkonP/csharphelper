using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Imaging;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_sepia_tone_Form1:Form
  { 


        public howto_sepia_tone_Form1()
        {
            InitializeComponent();
        }

        // Display the image converted to sepia tone.
        private void howto_sepia_tone_Form1_Load(object sender, EventArgs e)
        {
            picSepia.Image = ToSepiaTone(picOriginal.Image);
        }

        // Convert an image to sepia tone.
        private Bitmap ToSepiaTone(Image image)
        {
            // Make the ColorMatrix.
            ColorMatrix cm = new ColorMatrix(new float[][]
            {
                new float[] {0.393f, 0.349f, 0.272f, 0, 0},
                new float[] {0.769f, 0.686f, 0.534f, 0, 0},
                new float[] {0.189f, 0.168f, 0.131f, 0, 0},
                new float[] { 0, 0, 0, 1, 0},
                new float[] { 0, 0, 0, 0, 1}
            });
            //ColorMatrix cm = new ColorMatrix(new float[][]
            //{
            //    new float[] {0.300f, 0.066f, 0.300f, 0, 0},
            //    new float[] {0.500f, 0.350f, 0.600f, 0, 0},
            //    new float[] {0.100f, 0.000f, 0.200f, 0, 0},
            //    new float[] { 0, 0, 0, 1, 0},
            //    new float[] { 0, 0, 0, 0, 1}
            //});
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(cm);

            // Draw the image onto the new bitmap while applying the new ColorMatrix.
            Point[] points =
            {
                new Point(0, 0),
                new Point(image.Width - 1, 0),
                new Point(0, image.Height - 1),
            };
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

            // Make the result bitmap.
            Bitmap bm = new Bitmap(image.Width, image.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawImage(image, points, rect, GraphicsUnit.Pixel, attributes);
            }

            // Return the result.
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
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.picSepia = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSepia)).BeginInit();
            this.SuspendLayout();
            // 
            // picOriginal
            // 
            this.picOriginal.Image = Properties.Resources.JackOLanterns;
            this.picOriginal.Location = new System.Drawing.Point(12, 12);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(300, 400);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picOriginal.TabIndex = 1;
            this.picOriginal.TabStop = false;
            // 
            // picSepia
            // 
            this.picSepia.Location = new System.Drawing.Point(318, 12);
            this.picSepia.Name = "picSepia";
            this.picSepia.Size = new System.Drawing.Size(300, 400);
            this.picSepia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSepia.TabIndex = 2;
            this.picSepia.TabStop = false;
            // 
            // howto_sepia_tone_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 424);
            this.Controls.Add(this.picSepia);
            this.Controls.Add(this.picOriginal);
            this.Name = "howto_sepia_tone_Form1";
            this.Text = "howto_sepia_tone";
            this.Load += new System.EventHandler(this.howto_sepia_tone_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSepia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.PictureBox picSepia;
    }
}

