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
     public partial class howto_wheel_zoom_Form1:Form
  { 


        public howto_wheel_zoom_Form1()
        {
            InitializeComponent();
        }

        // The image's original size.
        private int ImageWidth, ImageHeight;

        // The current scale.
        private float ImageScale = 1.0f;

        private void howto_wheel_zoom_Form1_Load(object sender, EventArgs e)
        {
            ImageWidth = picImage.Image.Width;
            ImageHeight = picImage.Image.Height;
            picImage.SizeMode = PictureBoxSizeMode.Zoom;
            picImage.Size = new Size(ImageWidth, ImageHeight);
            this.MouseWheel += new MouseEventHandler(picImage_MouseWheel);
        }

        // Respond to the mouse wheel.
        private void picImage_MouseWheel(object sender, MouseEventArgs e)
        {
            // The amount by which we adjust scale per wheel click.
            const float scale_per_delta = 0.1f / 120;

            // Update the drawing based upon the mouse wheel scrolling.
            ImageScale += e.Delta * scale_per_delta;
            if (ImageScale < 0) ImageScale = 0;

            // Size the image.
            picImage.Size = new Size(
                (int)(ImageWidth * ImageScale),
                (int)(ImageHeight * ImageScale));

            // Display the new scale.
            lblScale.Text = ImageScale.ToString("p0");
        }

        // Open the book's web page.
        private void lnkPuzzles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.csharphelper.com/puzzles.htm");
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
            this.lnkPuzzles = new System.Windows.Forms.LinkLabel();
            this.lblScale = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.Image = Properties.Resources.interview_puzzles_350_433;
            this.picImage.Location = new System.Drawing.Point(12, 25);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(112, 101);
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            // 
            // lnkPuzzles
            // 
            this.lnkPuzzles.AutoSize = true;
            this.lnkPuzzles.Location = new System.Drawing.Point(9, 9);
            this.lnkPuzzles.Name = "lnkPuzzles";
            this.lnkPuzzles.Size = new System.Drawing.Size(139, 13);
            this.lnkPuzzles.TabIndex = 0;
            this.lnkPuzzles.TabStop = true;
            this.lnkPuzzles.Text = "Interview Puzzles Dissected";
            this.lnkPuzzles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPuzzles_LinkClicked);
            // 
            // lblScale
            // 
            this.lblScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScale.AutoSize = true;
            this.lblScale.Location = new System.Drawing.Point(239, 9);
            this.lblScale.Name = "lblScale";
            this.lblScale.Size = new System.Drawing.Size(33, 13);
            this.lblScale.TabIndex = 1;
            this.lblScale.Text = "100%";
            // 
            // howto_wheel_zoom_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 321);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.lblScale);
            this.Controls.Add(this.lnkPuzzles);
            this.Name = "howto_wheel_zoom_Form1";
            this.Text = "howto_wheel_zoom";
            this.Load += new System.EventHandler(this.howto_wheel_zoom_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkPuzzles;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Label lblScale;
    }
}

