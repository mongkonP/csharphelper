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
     public partial class howto_monocolor_Form1:Form
  { 


        public howto_monocolor_Form1()
        {
            InitializeComponent();
        }

        // Convert the image into red, green, and blue monochrome.
        private void howto_monocolor_Form1_Load(object sender, EventArgs e)
        {
            picRed.Image = ScaleColorComponents(picOriginal.Image, 1, 0, 0, 1);
            picGreen.Image = ScaleColorComponents(picOriginal.Image, 0, 1, 0, 1);
            picBlue.Image = ScaleColorComponents(picOriginal.Image, 0, 0, 1, 1);
        }

        // Scale an image's color components.
        private Bitmap ScaleColorComponents(Image image, float r, float g, float b, float a)
        {
            // Make the ColorMatrix.
            ColorMatrix cm = new ColorMatrix(new float[][]
                {
                    new float[] {r, 0, 0, 0, 0},
                    new float[] {0, g, 0, 0, 0},
                    new float[] {0, 0, b, 0, 0},
                    new float[] {0, 0, 0, a, 0},
                    new float[] {0, 0, 0, 0, 1},
                });
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
            this.picBlue = new System.Windows.Forms.PictureBox();
            this.picGreen = new System.Windows.Forms.PictureBox();
            this.picRed = new System.Windows.Forms.PictureBox();
            this.picOriginal = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            this.SuspendLayout();
            // 
            // picBlue
            // 
            this.picBlue.Location = new System.Drawing.Point(243, 318);
            this.picBlue.Name = "picBlue";
            this.picBlue.Size = new System.Drawing.Size(225, 300);
            this.picBlue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBlue.TabIndex = 7;
            this.picBlue.TabStop = false;
            // 
            // picGreen
            // 
            this.picGreen.Location = new System.Drawing.Point(12, 318);
            this.picGreen.Name = "picGreen";
            this.picGreen.Size = new System.Drawing.Size(225, 300);
            this.picGreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picGreen.TabIndex = 6;
            this.picGreen.TabStop = false;
            // 
            // picRed
            // 
            this.picRed.Location = new System.Drawing.Point(243, 12);
            this.picRed.Name = "picRed";
            this.picRed.Size = new System.Drawing.Size(225, 300);
            this.picRed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picRed.TabIndex = 5;
            this.picRed.TabStop = false;
            // 
            // picOriginal
            // 
            this.picOriginal.Image = Properties.Resources.JackOLanterns;
            this.picOriginal.Location = new System.Drawing.Point(12, 12);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(225, 300);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picOriginal.TabIndex = 4;
            this.picOriginal.TabStop = false;
            // 
            // howto_monocolor_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 631);
            this.Controls.Add(this.picBlue);
            this.Controls.Add(this.picGreen);
            this.Controls.Add(this.picRed);
            this.Controls.Add(this.picOriginal);
            this.Name = "howto_monocolor_Form1";
            this.Text = "howto_monocolor";
            this.Load += new System.EventHandler(this.howto_monocolor_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBlue;
        private System.Windows.Forms.PictureBox picGreen;
        private System.Windows.Forms.PictureBox picRed;
        private System.Windows.Forms.PictureBox picOriginal;
    }
}

