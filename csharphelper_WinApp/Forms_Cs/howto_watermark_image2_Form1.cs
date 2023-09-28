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
     public partial class howto_watermark_image2_Form1:Form
  { 


        public howto_watermark_image2_Form1()
        {
            InitializeComponent();
        }

        private void howto_watermark_image2_Form1_Load(object sender, EventArgs e)
        {
            Bitmap result_bm = new Bitmap(picImage.Image);

            using (Bitmap watermark_bm = new Bitmap(picWatermark.Image))
            {
                int x = (result_bm.Width - watermark_bm.Width) / 2;
                int y = (result_bm.Height - watermark_bm.Height) / 2;
                DrawWatermark(watermark_bm, result_bm, x, y);
            }

            picImage.Image = result_bm;
        }

        // Copy the watermark image over the result image.
        private void DrawWatermark(Bitmap watermark_bm, Bitmap result_bm, int x, int y)
        {
            // Make a ColorMatrix that multiplies
            // the alpha component by 0.5.
            ColorMatrix color_matrix = new ColorMatrix();
            color_matrix.Matrix33 = 0.5f;

            // Make an ImageAttributes that uses the ColorMatrix.
            ImageAttributes image_attributes = new ImageAttributes();
            image_attributes.SetColorMatrices(color_matrix, null);

            // Make pixels that are the same color as the
            // one in the upper left transparent.
            watermark_bm.MakeTransparent(watermark_bm.GetPixel(0, 0));

            // Draw the image using the ColorMatrix.
            using (Graphics gr = Graphics.FromImage(result_bm))
            {
                Rectangle rect = new Rectangle(x, y, watermark_bm.Width, watermark_bm.Height);
                gr.DrawImage(watermark_bm, rect, 0, 0,
                    watermark_bm.Width, watermark_bm.Height,
                    GraphicsUnit.Pixel, image_attributes);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_watermark_image2_Form1));
            this.picWatermark = new System.Windows.Forms.PictureBox();
            this.picImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picWatermark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picWatermark
            // 
            this.picWatermark.Image = ((System.Drawing.Image)(resources.GetObject("picWatermark.Image")));
            this.picWatermark.Location = new System.Drawing.Point(12, 8);
            this.picWatermark.Name = "picWatermark";
            this.picWatermark.Size = new System.Drawing.Size(226, 76);
            this.picWatermark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picWatermark.TabIndex = 6;
            this.picWatermark.TabStop = false;
            this.picWatermark.Visible = false;
            // 
            // picImage
            // 
            this.picImage.Image = ((System.Drawing.Image)(resources.GetObject("picImage.Image")));
            this.picImage.Location = new System.Drawing.Point(0, 1);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(412, 270);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImage.TabIndex = 5;
            this.picImage.TabStop = false;
            // 
            // howto_watermark_image2_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 273);
            this.Controls.Add(this.picWatermark);
            this.Controls.Add(this.picImage);
            this.Name = "howto_watermark_image2_Form1";
            this.Text = "howto_watermark_image2";
            this.Load += new System.EventHandler(this.howto_watermark_image2_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picWatermark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox picWatermark;
        internal System.Windows.Forms.PictureBox picImage;
    }
}

