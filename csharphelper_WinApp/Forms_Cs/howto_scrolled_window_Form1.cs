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
     public partial class howto_scrolled_window_Form1:Form
  { 


        public howto_scrolled_window_Form1()
        {
            InitializeComponent();
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
            this.panContents = new System.Windows.Forms.Panel();
            this.picBigImage = new System.Windows.Forms.PictureBox();
            this.panContents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBigImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panContents
            // 
            this.panContents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panContents.AutoScroll = true;
            this.panContents.BackColor = System.Drawing.Color.White;
            this.panContents.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panContents.Controls.Add(this.picBigImage);
            this.panContents.Location = new System.Drawing.Point(12, 10);
            this.panContents.Name = "panContents";
            this.panContents.Size = new System.Drawing.Size(310, 240);
            this.panContents.TabIndex = 1;
            // 
            // picBigImage
            // 
            this.picBigImage.Image = Properties.Resources.Wpf3dText;
            this.picBigImage.Location = new System.Drawing.Point(0, 0);
            this.picBigImage.Name = "picBigImage";
            this.picBigImage.Size = new System.Drawing.Size(616, 616);
            this.picBigImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBigImage.TabIndex = 0;
            this.picBigImage.TabStop = false;
            // 
            // howto_scrolled_window_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 261);
            this.Controls.Add(this.panContents);
            this.Name = "howto_scrolled_window_Form1";
            this.Text = "howto_scrolled_window";
            this.panContents.ResumeLayout(false);
            this.panContents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBigImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panContents;
        private System.Windows.Forms.PictureBox picBigImage;
    }
}

