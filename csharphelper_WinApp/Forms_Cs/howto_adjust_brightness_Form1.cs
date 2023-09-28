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
     public partial class howto_adjust_brightness_Form1:Form
  { 


        public howto_adjust_brightness_Form1()
        {
            InitializeComponent();
        }

        // Set an initial value.
        private void howto_adjust_brightness_Form1_Load(object sender, EventArgs e)
        {
            scrBrightness.Value = 150;
            AdjustImage();
        }

        // Perform the adjustment.
        private void scrBrightness_Scroll(object sender, ScrollEventArgs e)
        {
            AdjustImage();
        }

        // Perform the brightness adjustment and display the result.
        private void AdjustImage()
        {
            lblBrightness.Text = "Brightness = " + (scrBrightness.Value / 100.0).ToString();
            picAdjusted.Image = AdjustBrightness(picOriginal.Image,  (float)(scrBrightness.Value / 100.0));
        }

        // Adjust the image's brightness.
        private Bitmap AdjustBrightness(Image image, float brightness)
        {
            // Make the ColorMatrix.
            float b = brightness;
            ColorMatrix cm = new ColorMatrix(new float[][]
                {
                    new float[] {b, 0, 0, 0, 0},
                    new float[] {0, b, 0, 0, 0},
                    new float[] {0, 0, b, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
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
            this.lblBrightness = new System.Windows.Forms.Label();
            this.scrBrightness = new System.Windows.Forms.HScrollBar();
            this.label2 = new System.Windows.Forms.Label();
            this.picAdjusted = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picOriginal = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picAdjusted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBrightness
            // 
            this.lblBrightness.Location = new System.Drawing.Point(315, 460);
            this.lblBrightness.Name = "lblBrightness";
            this.lblBrightness.Size = new System.Drawing.Size(303, 19);
            this.lblBrightness.TabIndex = 11;
            this.lblBrightness.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scrBrightness
            // 
            this.scrBrightness.Location = new System.Drawing.Point(318, 434);
            this.scrBrightness.Maximum = 500;
            this.scrBrightness.Minimum = 1;
            this.scrBrightness.Name = "scrBrightness";
            this.scrBrightness.Size = new System.Drawing.Size(300, 17);
            this.scrBrightness.TabIndex = 10;
            this.scrBrightness.Value = 1;
            this.scrBrightness.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrBrightness_Scroll);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(318, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(303, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Adjusted";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picAdjusted
            // 
            this.picAdjusted.Location = new System.Drawing.Point(318, 31);
            this.picAdjusted.Name = "picAdjusted";
            this.picAdjusted.Size = new System.Drawing.Size(300, 400);
            this.picAdjusted.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picAdjusted.TabIndex = 8;
            this.picAdjusted.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Original";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picOriginal
            // 
            this.picOriginal.Image = Properties.Resources.JackOLanterns;
            this.picOriginal.Location = new System.Drawing.Point(12, 31);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(300, 400);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picOriginal.TabIndex = 6;
            this.picOriginal.TabStop = false;
            // 
            // howto_adjust_brightness_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 487);
            this.Controls.Add(this.lblBrightness);
            this.Controls.Add(this.scrBrightness);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picAdjusted);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picOriginal);
            this.Name = "howto_adjust_brightness_Form1";
            this.Text = "howto_adjust_brightness";
            this.Load += new System.EventHandler(this.howto_adjust_brightness_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAdjusted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBrightness;
        private System.Windows.Forms.HScrollBar scrBrightness;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picAdjusted;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picOriginal;
    }
}

