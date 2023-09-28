using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_to_grayscale;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_to_grayscale_Form1:Form
  { 


        public howto_to_grayscale_Form1()
        {
            InitializeComponent();
        }

        private void howto_to_grayscale_Form1_Load(object sender, EventArgs e)
        {
            // Average.
            Bitmap average_bm = new Bitmap(picAverage.Image);
            ConvertBitmapToGrayscale(average_bm, true);
            picAverage.Image = average_bm;

            // Convert to grayscale.
            Bitmap grayscale_bm = new Bitmap(picGrayscale.Image);
            ConvertBitmapToGrayscale(grayscale_bm, false);
            picGrayscale.Image = grayscale_bm;
        }

        // Convert the Bitmap to grayscale.
        private void ConvertBitmapToGrayscale(Bitmap bm, bool use_average)
        {
            // Make a Bitmap24 object.
            Bitmap32 bm32 = new Bitmap32(bm);

            // Lock the bitmap.
            bm32.LockBitmap();

            // Process the pixels.
            for (int x = 0; x < bm.Width; x++)
            {
                for (int y = 0; y < bm.Height; y++)
                {
                    byte r = bm32.GetRed(x, y);
                    byte g = bm32.GetGreen(x, y);
                    byte b = bm32.GetBlue(x, y);
                    byte gray = (use_average ?
                        (byte)((r + g + b) / 3) :
                        (byte)(0.3 * r + 0.5 * g + 0.2 * b));
                    bm32.SetPixel(x, y, gray, gray, gray, 255);
                }
            }

            // Unlock the bitmap.
            bm32.UnlockBitmap();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_to_grayscale_Form1));
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.picAverage = new System.Windows.Forms.PictureBox();
            this.picGrayscale = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGrayscale)).BeginInit();
            this.SuspendLayout();
            // 
            // picOriginal
            // 
            this.picOriginal.Image = ((System.Drawing.Image)(resources.GetObject("picOriginal.Image")));
            this.picOriginal.Location = new System.Drawing.Point(12, 12);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(185, 232);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picOriginal.TabIndex = 2;
            this.picOriginal.TabStop = false;
            // 
            // picAverage
            // 
            this.picAverage.Image = ((System.Drawing.Image)(resources.GetObject("picAverage.Image")));
            this.picAverage.Location = new System.Drawing.Point(203, 12);
            this.picAverage.Name = "picAverage";
            this.picAverage.Size = new System.Drawing.Size(185, 232);
            this.picAverage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picAverage.TabIndex = 3;
            this.picAverage.TabStop = false;
            // 
            // picGrayscale
            // 
            this.picGrayscale.Image = ((System.Drawing.Image)(resources.GetObject("picGrayscale.Image")));
            this.picGrayscale.Location = new System.Drawing.Point(394, 12);
            this.picGrayscale.Name = "picGrayscale";
            this.picGrayscale.Size = new System.Drawing.Size(185, 232);
            this.picGrayscale.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picGrayscale.TabIndex = 4;
            this.picGrayscale.TabStop = false;
            // 
            // howto_to_grayscale_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 256);
            this.Controls.Add(this.picGrayscale);
            this.Controls.Add(this.picAverage);
            this.Controls.Add(this.picOriginal);
            this.Name = "howto_to_grayscale_Form1";
            this.Text = "howto_to_grayscale";
            this.Load += new System.EventHandler(this.howto_to_grayscale_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGrayscale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox picOriginal;
        internal System.Windows.Forms.PictureBox picAverage;
        internal System.Windows.Forms.PictureBox picGrayscale;
    }
}

