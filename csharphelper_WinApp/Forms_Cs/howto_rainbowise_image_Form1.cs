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
     public partial class howto_rainbowise_image_Form1:Form
  { 


        public howto_rainbowise_image_Form1()
        {
            InitializeComponent();
        }

        // Process the image.
        private void howto_rainbowise_image_Form1_Load(object sender, EventArgs e)
        {
            // Create the output image.
            Image original = picImage.Image;
            int wid = original.Width;
            int hgt = original.Height;
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                // Define target colors.
                Color[] color =
                {
                    //Color.Red, Color.Orange, Color.Yellow,
                    //Color.Green, Color.Blue, Color.Indigo,
                    //Color.Violet,

                    Color.Red, Color.OrangeRed, Color.Yellow,
                    Color.Green, Color.Blue, Color.Indigo,
                    Color.Fuchsia,
                };
                const float scale = 2.0f;

                // Draw.
                for (int i = 0; i < color.Length; i++)
                {
                    // Create the ColorMatrix.
                    ColorMatrix cm = new ColorMatrix(new float[][]
                    {
                        new float[] {color[i].R / 255f * scale, 0, 0, 0, 0},
                        new float[] {0, color[i].G / 255f * scale, 0, 0, 0},
                        new float[] {0, 0, color[i].B / 255f * scale, 0, 0},
                        new float[] {0, 0, 0, 1, 0},
                        new float[] {0, 0, 0, 0, 1},
                    });
                    ImageAttributes attr = new ImageAttributes();
                    attr.SetColorMatrix(cm);

                    // Draw the next part of the image.
                    int x = (int)(i * original.Width / color.Length);
                    Point[] points =
                    {
                        new Point(x, 0),
                        new Point(wid, 0),
                        new Point(x, hgt),
                    };
                    Rectangle rect = new Rectangle(x, 0, wid - x, hgt);
                    gr.DrawImage(original, points, rect, GraphicsUnit.Pixel, attr);
                }
            }

            // Display the result.
            picImage.Image = bm;

            // Save the result.
            bm.Save("Rainbow.png", ImageFormat.Png);
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
            this.picImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picImage.Image = Properties.Resources.Cool_Trees3_wide;
            this.picImage.Location = new System.Drawing.Point(12, 12);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(1004, 379);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            // 
            // howto_rainbowise_image_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 400);
            this.Controls.Add(this.picImage);
            this.Name = "howto_rainbowise_image_Form1";
            this.Text = "howto_rainbowise_image";
            this.Load += new System.EventHandler(this.howto_rainbowise_image_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picImage;
    }
}

