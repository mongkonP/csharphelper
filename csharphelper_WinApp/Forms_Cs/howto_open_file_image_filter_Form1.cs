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
     public partial class howto_open_file_image_filter_Form1:Form
  { 


        public howto_open_file_image_filter_Form1()
        {
            InitializeComponent();
        }

        // Use many filters.
        private void btnDifferentTypes_Click(object sender, EventArgs e)
        {
            ofdImage.Filter =
                "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|" +
                "Bitmaps|*.bmp|PNG files|*.png|" +
                "JPEG files|*.jpg|GIF files|*.gif|TIFF files|*.tif|" +
                "All files|*.*";
            ofdImage.FilterIndex = 0;
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    picImage.Image = new Bitmap(ofdImage.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Use only the Image files and All files filters.
        private void btnAllImages_Click(object sender, EventArgs e)
        {
            ofdImage.Filter =
                "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|" +
                "All files|*.*";
            ofdImage.FilterIndex = 0;
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    picImage.Image = new Bitmap(ofdImage.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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
            this.btnDifferentTypes = new System.Windows.Forms.Button();
            this.btnAllImages = new System.Windows.Forms.Button();
            this.ofdImage = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(0, 0);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(260, 208);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImage.TabIndex = 5;
            this.picImage.TabStop = false;
            // 
            // btnDifferentTypes
            // 
            this.btnDifferentTypes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDifferentTypes.Location = new System.Drawing.Point(22, 12);
            this.btnDifferentTypes.Name = "btnDifferentTypes";
            this.btnDifferentTypes.Size = new System.Drawing.Size(113, 23);
            this.btnDifferentTypes.TabIndex = 3;
            this.btnDifferentTypes.Text = "Different Types";
            this.btnDifferentTypes.UseVisualStyleBackColor = true;
            this.btnDifferentTypes.Click += new System.EventHandler(this.btnDifferentTypes_Click);
            // 
            // btnAllImages
            // 
            this.btnAllImages.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAllImages.Location = new System.Drawing.Point(150, 12);
            this.btnAllImages.Name = "btnAllImages";
            this.btnAllImages.Size = new System.Drawing.Size(113, 23);
            this.btnAllImages.TabIndex = 4;
            this.btnAllImages.Text = "All Images";
            this.btnAllImages.UseVisualStyleBackColor = true;
            this.btnAllImages.Click += new System.EventHandler(this.btnAllImages_Click);
            // 
            // ofdImage
            // 
            this.ofdImage.FileName = "openFileDialog1";
            this.ofdImage.Filter = "Bitmaps|*.bmp|PNG files|*.png|JPEG files|*.jpg|Picture files|*.bmp;*.jpg;*.gif;*." +
                "png;*.tif|All Files|*.*";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.picImage);
            this.panel1.Location = new System.Drawing.Point(12, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 208);
            this.panel1.TabIndex = 6;
            // 
            // howto_open_file_image_filter_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDifferentTypes);
            this.Controls.Add(this.btnAllImages);
            this.Name = "howto_open_file_image_filter_Form1";
            this.Text = "howto_open_file_image_filter";
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Button btnDifferentTypes;
        private System.Windows.Forms.Button btnAllImages;
        private System.Windows.Forms.OpenFileDialog ofdImage;
        private System.Windows.Forms.Panel panel1;
    }
}

