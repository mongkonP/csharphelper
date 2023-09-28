using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Imaging;
using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_get_screen_image_Form1:Form
  { 


        public howto_get_screen_image_Form1()
        {
            InitializeComponent();
        }

        private void btnGetScreenImage_Click(object sender, EventArgs e)
        {
            // Hide this form.
            this.Hide();

            // Let the user pick a file to hold the image.
            if (sfdScreenImage.ShowDialog() == DialogResult.OK)
            {
                // Get the screen's image.
                using (Bitmap bm = GetScreenImage())
                {
                    // Save the bitmap in the selected file.
                    SaveImage(bm, sfdScreenImage.FileName);
                }
            }

            // Show this form again.
            this.Show();
        }

        // Grab the screen's image.
        private Bitmap GetScreenImage()
        {
            // Make a bitmap to hold the result.
            Bitmap bm = new Bitmap(
                Screen.PrimaryScreen.Bounds.Width, 
                Screen.PrimaryScreen.Bounds.Height, 
                PixelFormat.Format24bppRgb);

            // Copy the image into the bitmap.
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.CopyFromScreen(
                    Screen.PrimaryScreen.Bounds.X,
                    Screen.PrimaryScreen.Bounds.Y,
                    0, 0,
                    Screen.PrimaryScreen.Bounds.Size,
                    CopyPixelOperation.SourceCopy);
            }

            // Return the result.
            return bm;
        }

        // Save the file with the appropriate format.
        public void SaveImage(Image image, string filename)
        {
            string extension = Path.GetExtension(filename);
            switch (extension.ToLower())
            {
                case ".bmp":
                    image.Save(filename, ImageFormat.Bmp);
                    break;
                case ".exif":
                    image.Save(filename, ImageFormat.Exif);
                    break;
                case ".gif":
                    image.Save(filename, ImageFormat.Gif);
                    break;
                case ".jpg":
                case ".jpeg":
                    image.Save(filename, ImageFormat.Jpeg);
                    break;
                case ".png":
                    image.Save(filename, ImageFormat.Png);
                    break;
                case ".tif":
                case ".tiff":
                    image.Save(filename, ImageFormat.Tiff);
                    break;
                default:
                    throw new NotSupportedException(
                        "Unknown file extension " + extension);
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
            this.btnGetScreenImage = new System.Windows.Forms.Button();
            this.sfdScreenImage = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // btnGetScreenImage
            // 
            this.btnGetScreenImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGetScreenImage.Location = new System.Drawing.Point(107, 40);
            this.btnGetScreenImage.Name = "btnGetScreenImage";
            this.btnGetScreenImage.Size = new System.Drawing.Size(124, 23);
            this.btnGetScreenImage.TabIndex = 0;
            this.btnGetScreenImage.Text = "Get Screen Image";
            this.btnGetScreenImage.UseVisualStyleBackColor = true;
            this.btnGetScreenImage.Click += new System.EventHandler(this.btnGetScreenImage_Click);
            // 
            // sfdScreenImage
            // 
            this.sfdScreenImage.Filter = "Graphic Files|*.bmp;*.gif;*.jpg;*.png|All Files|*.*";
            // 
            // howto_get_screen_image_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 102);
            this.Controls.Add(this.btnGetScreenImage);
            this.Name = "howto_get_screen_image_Form1";
            this.Text = "howto_get_screen_image";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetScreenImage;
        private System.Windows.Forms.SaveFileDialog sfdScreenImage;
    }
}

