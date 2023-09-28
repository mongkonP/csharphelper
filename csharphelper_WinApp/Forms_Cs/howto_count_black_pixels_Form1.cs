using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_count_black_pixels_Form1:Form
  { 


        public howto_count_black_pixels_Form1()
        {
            InitializeComponent();
        }

        // Count the black and white pixels.
        private void btnCount_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(picImage.Image);
            int black_pixels = CountPixels(bm, Color.FromArgb(255, 0, 0, 0));
            int white_pixels = CountPixels(bm, Color.FromArgb(255, 255, 255, 255));
            lblBlack.Text = black_pixels + " black pixels";
            lblWhite.Text = white_pixels + " white pixels";
            lblTotal.Text = white_pixels + black_pixels + " total pixels";
        }

        // Return the number of matching pixels.
        private int CountPixels(Bitmap bm, Color target_color)
        {
            // Loop through the pixels.
            int matches = 0;
            for (int y = 0; y < bm.Height; y++)
            {
                for (int x = 0; x < bm.Width; x++)
                {
                    if (bm.GetPixel(x, y) == target_color) matches++;
                }
            }
            return matches;
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
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblWhite = new System.Windows.Forms.Label();
            this.lblBlack = new System.Windows.Forms.Label();
            this.btnCount = new System.Windows.Forms.Button();
            this.picImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(12, 96);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 13);
            this.lblTotal.TabIndex = 9;
            // 
            // lblWhite
            // 
            this.lblWhite.AutoSize = true;
            this.lblWhite.Location = new System.Drawing.Point(12, 72);
            this.lblWhite.Name = "lblWhite";
            this.lblWhite.Size = new System.Drawing.Size(0, 13);
            this.lblWhite.TabIndex = 8;
            // 
            // lblBlack
            // 
            this.lblBlack.AutoSize = true;
            this.lblBlack.Location = new System.Drawing.Point(12, 48);
            this.lblBlack.Name = "lblBlack";
            this.lblBlack.Size = new System.Drawing.Size(0, 13);
            this.lblBlack.TabIndex = 7;
            // 
            // btnCount
            // 
            this.btnCount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCount.Location = new System.Drawing.Point(120, 12);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(75, 23);
            this.btnCount.TabIndex = 6;
            this.btnCount.Text = "Count";
            this.btnCount.UseVisualStyleBackColor = true;
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // picImage
            // 
            this.picImage.Image = Properties.Resources.TestImage;
            this.picImage.Location = new System.Drawing.Point(12, 12);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(16, 16);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImage.TabIndex = 5;
            this.picImage.TabStop = false;
            // 
            // howto_count_black_pixels_Form1
            // 
            this.AcceptButton = this.btnCount;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 121);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblWhite);
            this.Controls.Add(this.lblBlack);
            this.Controls.Add(this.btnCount);
            this.Controls.Add(this.picImage);
            this.Name = "howto_count_black_pixels_Form1";
            this.Text = "howto_count_black_pixels";
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblWhite;
        private System.Windows.Forms.Label lblBlack;
        private System.Windows.Forms.Button btnCount;
        private System.Windows.Forms.PictureBox picImage;
    }
}

