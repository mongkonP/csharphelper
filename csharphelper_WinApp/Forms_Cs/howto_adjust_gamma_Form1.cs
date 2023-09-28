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
     public partial class howto_adjust_gamma_Form1:Form
  { 


        public howto_adjust_gamma_Form1()
        {
            InitializeComponent();
        }

        // Set an initial value.
        private void howto_adjust_gamma_Form1_Load(object sender, EventArgs e)
        {
            scrGamma.Value = 7;
            AdjustImage();
        }

        // Perform the adjustment.
        private void scrGamma_Scroll(object sender, ScrollEventArgs e)
        {
            AdjustImage();
        }

        // Perform the gamma adjustment and display the result.
        private void AdjustImage()
        {
            lblGamma.Text = "Gamma = " + (scrGamma.Value / 10.0).ToString();
            picAdjusted.Image = AdjustGamma(picOriginal.Image, (float)(scrGamma.Value / 10.0));
        }

        // Perform gamma correction on the image.
        private Bitmap AdjustGamma(Image image, float gamma)
        {
            // Set the ImageAttributes object's gamma value.
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetGamma(gamma);

            // Draw the image onto the new bitmap while applying the new gamma value.
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picAdjusted = new System.Windows.Forms.PictureBox();
            this.scrGamma = new System.Windows.Forms.HScrollBar();
            this.lblGamma = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAdjusted)).BeginInit();
            this.SuspendLayout();
            // 
            // picOriginal
            // 
            this.picOriginal.Image = Properties.Resources.JackOLanterns;
            this.picOriginal.Location = new System.Drawing.Point(12, 31);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(300, 400);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picOriginal.TabIndex = 0;
            this.picOriginal.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Original";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(315, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(303, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Adjusted";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picAdjusted
            // 
            this.picAdjusted.Image = Properties.Resources.JackOLanterns;
            this.picAdjusted.Location = new System.Drawing.Point(318, 31);
            this.picAdjusted.Name = "picAdjusted";
            this.picAdjusted.Size = new System.Drawing.Size(300, 400);
            this.picAdjusted.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picAdjusted.TabIndex = 2;
            this.picAdjusted.TabStop = false;
            // 
            // scrGamma
            // 
            this.scrGamma.Location = new System.Drawing.Point(318, 434);
            this.scrGamma.Maximum = 50;
            this.scrGamma.Minimum = 1;
            this.scrGamma.Name = "scrGamma";
            this.scrGamma.Size = new System.Drawing.Size(300, 17);
            this.scrGamma.TabIndex = 4;
            this.scrGamma.Value = 1;
            this.scrGamma.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrGamma_Scroll);
            // 
            // lblGamma
            // 
            this.lblGamma.Location = new System.Drawing.Point(315, 460);
            this.lblGamma.Name = "lblGamma";
            this.lblGamma.Size = new System.Drawing.Size(303, 19);
            this.lblGamma.TabIndex = 5;
            this.lblGamma.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_adjust_gamma_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 487);
            this.Controls.Add(this.lblGamma);
            this.Controls.Add(this.scrGamma);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picAdjusted);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picOriginal);
            this.Name = "howto_adjust_gamma_Form1";
            this.Text = "howto_adjust_gamma";
            this.Load += new System.EventHandler(this.howto_adjust_gamma_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAdjusted)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picAdjusted;
        private System.Windows.Forms.HScrollBar scrGamma;
        private System.Windows.Forms.Label lblGamma;
    }
}

