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
     public partial class howto_color_threshold_Form1:Form
  { 


        public howto_color_threshold_Form1()
        {
            InitializeComponent();
        }

        // Set an initial value.
        private void howto_color_threshold_Form1_Load(object sender, EventArgs e)
        {
            scrThreshold.Value = 50;
            AdjustImage();
        }

        // Perform the adjustment.
        private void scrThreshold_Scroll(object sender, ScrollEventArgs e)
        {
            AdjustImage();
        }

        // Perform the threshold adjustment and display the result.
        private void AdjustImage()
        {
            lblThreshold.Text = "Threshold = " + (scrThreshold.Value / 100.0).ToString();
            picAdjusted.Image = AdjustThreshold(picOriginal.Image, (float)(scrThreshold.Value / 100.0));
        }

        // Perform threshold adjustment on the image.
        private Bitmap AdjustThreshold(Image image, float threshold)
        {
            // Make the result bitmap.
            Bitmap bm = new Bitmap(image.Width, image.Height);

            // Make the ImageAttributes object and set the threshold.
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetThreshold(threshold);

            // Draw the image onto the new bitmap while applying the new ColorMatrix.
            Point[] points =
            {
                new Point(0, 0),
                new Point(image.Width, 0),
                new Point(0, image.Height),
            };
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
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
            this.scrThreshold = new System.Windows.Forms.HScrollBar();
            this.label2 = new System.Windows.Forms.Label();
            this.picAdjusted = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.lblThreshold = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picAdjusted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            this.SuspendLayout();
            // 
            // scrThreshold
            // 
            this.scrThreshold.Location = new System.Drawing.Point(9, 241);
            this.scrThreshold.Maximum = 109;
            this.scrThreshold.Name = "scrThreshold";
            this.scrThreshold.Size = new System.Drawing.Size(424, 17);
            this.scrThreshold.TabIndex = 22;
            this.scrThreshold.Value = 1;
            this.scrThreshold.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrThreshold_Scroll);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(225, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 19);
            this.label2.TabIndex = 21;
            this.label2.Text = "Adjusted";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picAdjusted
            // 
            this.picAdjusted.Location = new System.Drawing.Point(225, 30);
            this.picAdjusted.Name = "picAdjusted";
            this.picAdjusted.Size = new System.Drawing.Size(208, 208);
            this.picAdjusted.TabIndex = 20;
            this.picAdjusted.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 19);
            this.label1.TabIndex = 19;
            this.label1.Text = "Original";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picOriginal
            // 
            this.picOriginal.Image = Properties.Resources.Rod;
            this.picOriginal.Location = new System.Drawing.Point(11, 30);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(208, 208);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picOriginal.TabIndex = 18;
            this.picOriginal.TabStop = false;
            // 
            // lblThreshold
            // 
            this.lblThreshold.Location = new System.Drawing.Point(8, 258);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(425, 19);
            this.lblThreshold.TabIndex = 24;
            this.lblThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_color_threshold_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 289);
            this.Controls.Add(this.lblThreshold);
            this.Controls.Add(this.scrThreshold);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picAdjusted);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picOriginal);
            this.Name = "howto_color_threshold_Form1";
            this.Text = "howto_color_threshold";
            this.Load += new System.EventHandler(this.howto_color_threshold_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAdjusted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HScrollBar scrThreshold;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picAdjusted;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.Label lblThreshold;
    }
}

