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
     public partial class howto_overlay_translucent_Form1:Form
  { 


        public howto_overlay_translucent_Form1()
        {
            InitializeComponent();
        }

        // Make the pictures.
        private void howto_overlay_translucent_Form1_Load(object sender, EventArgs e)
        {
            // Without translucency.
            Bitmap bm = new Bitmap(
                picOriginal.ClientSize.Width,
                picOriginal.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(Color.White);
                gr.DrawImage(Properties.Resources.McCaw, 0, 0);
                gr.DrawImage(Properties.Resources.banner, 20, 250);
            }
            picOriginal.Image = bm;

            // With translucency.
            bm = new Bitmap(
                picOriginal.ClientSize.Width,
                picOriginal.ClientSize.Height);

            // Make adjusted images.
            Image banner = AdjustAlpha(Properties.Resources.banner, 0.75f);

            // Draw the adjusted images.
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(Color.White);
                gr.DrawImage(Properties.Resources.McCaw, 0, 0);
                gr.DrawImage(banner, 20, 250);
            }
            picTranslucent.Image = bm;
        }

        // Adjust an image's translucency.
        private Bitmap AdjustAlpha(Image image, float translucency)
        {
            // Make the ColorMatrix.
            float t = translucency;
            ColorMatrix cm = new ColorMatrix(new float[][]
                {
                    new float[] {1, 0, 0, 0, 0},
                    new float[] {0, 1, 0, 0, 0},
                    new float[] {0, 0, 1, 0, 0},
                    new float[] {0, 0, 0, t, 0},
                    new float[] {0, 0, 0, 0, 1},
                });
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(cm);

            // Draw the image onto the new bitmap while applying the new ColorMatrix.
            Point[] points =
            {
                new Point(0, 0),
                new Point(image.Width, 0),
                new Point(0, image.Height),
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
            this.picTranslucent = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTranslucent)).BeginInit();
            this.SuspendLayout();
            // 
            // picOriginal
            // 
            this.picOriginal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picOriginal.Location = new System.Drawing.Point(12, 12);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(300, 350);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picOriginal.TabIndex = 7;
            this.picOriginal.TabStop = false;
            // 
            // picTranslucent
            // 
            this.picTranslucent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picTranslucent.Location = new System.Drawing.Point(319, 12);
            this.picTranslucent.Name = "picTranslucent";
            this.picTranslucent.Size = new System.Drawing.Size(300, 350);
            this.picTranslucent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picTranslucent.TabIndex = 8;
            this.picTranslucent.TabStop = false;
            // 
            // howto_overlay_translucent_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 373);
            this.Controls.Add(this.picTranslucent);
            this.Controls.Add(this.picOriginal);
            this.Name = "howto_overlay_translucent_Form1";
            this.Text = "howto_overlay_translucent";
            this.Load += new System.EventHandler(this.howto_overlay_translucent_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTranslucent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.PictureBox picTranslucent;
    }
}

