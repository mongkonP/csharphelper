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
     public partial class howto_watermark_image_Form1:Form
  { 


        public howto_watermark_image_Form1()
        {
            InitializeComponent();
        }

        private void howto_watermark_image_Form1_Load(object sender, EventArgs e)
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
            const byte ALPHA = 128;
            // Set the watermark's pixels' Alpha components.
            Color clr;
            for (int py = 0; py < watermark_bm.Height; py++)
            {
                for (int px = 0; px < watermark_bm.Width; px++)
                {
                    clr = watermark_bm.GetPixel(px, py);
                    watermark_bm.SetPixel(px, py, Color.FromArgb(ALPHA, clr.R, clr.G, clr.B));
                }
            }

            // Set the watermark's transparent color.
            watermark_bm.MakeTransparent(watermark_bm.GetPixel(0, 0));

            // Copy onto the result image.
            using (Graphics gr = Graphics.FromImage(result_bm))
            {
                gr.DrawImage(watermark_bm, x, y);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_watermark_image_Form1));
            this.picWatermark = new System.Windows.Forms.PictureBox();
            this.picImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picWatermark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picWatermark
            // 
            this.picWatermark.Image = ((System.Drawing.Image)(resources.GetObject("picWatermark.Image")));
            this.picWatermark.Location = new System.Drawing.Point(12, 10);
            this.picWatermark.Name = "picWatermark";
            this.picWatermark.Size = new System.Drawing.Size(226, 76);
            this.picWatermark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picWatermark.TabIndex = 4;
            this.picWatermark.TabStop = false;
            this.picWatermark.Visible = false;
            // 
            // picImage
            // 
            this.picImage.Image = ((System.Drawing.Image)(resources.GetObject("picImage.Image")));
            this.picImage.Location = new System.Drawing.Point(0, 3);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(412, 270);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImage.TabIndex = 3;
            this.picImage.TabStop = false;
            // 
            // howto_watermark_image_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 273);
            this.Controls.Add(this.picWatermark);
            this.Controls.Add(this.picImage);
            this.Name = "howto_watermark_image_Form1";
            this.Text = "howto_watermark_image";
            this.Load += new System.EventHandler(this.howto_watermark_image_Form1_Load);
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

