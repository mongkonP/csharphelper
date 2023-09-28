using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_paste_png_Form1:Form
  { 


        public howto_paste_png_Form1()
        {
            InitializeComponent();
        }

        // Paste image data from the clipboard.
        private void picOriginal_MouseClick(object sender, MouseEventArgs e)
        {
            // Try to get an image.
            Image clipboard_image = GetClipboardImage();

            // If we failed. Beep to tell the user that
            // we cannot paste the available formats.
            if (clipboard_image == null)
            {
                System.Media.SystemSounds.Beep.Play();
                return;
            }

            // Draw on the image.
            using (Graphics gr = Graphics.FromImage(picOriginal.Image))
            {
                Rectangle source_rect = new Rectangle(0, 0,
                    clipboard_image.Width, clipboard_image.Height);
                int x = e.X - clipboard_image.Width / 2;
                int y = e.Y - clipboard_image.Height / 2;
                Rectangle dest_rect = new Rectangle(x, y,
                    clipboard_image.Width, clipboard_image.Height);
                gr.DrawImage(clipboard_image,
                    dest_rect, source_rect, GraphicsUnit.Pixel);
            }
            picOriginal.Refresh();
        }

        // Get a PNG from the clipboard if possible.
        // Otherwise try to get a bitmap.
        private Image GetClipboardImage()
        {
            // Try to paste PNG data.
            if (Clipboard.ContainsData("PNG"))
            {
                Object png_object = Clipboard.GetData("PNG");
                if (png_object is MemoryStream)
                {
                    MemoryStream png_stream = png_object as MemoryStream;
                    return Image.FromStream(png_stream);
                }
            }

            // Try to paste bitmap data.
            if (Clipboard.ContainsImage())
            {
                return Clipboard.GetImage();
            }

            // We couldn't find anything useful. Return null.
            return null;
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
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            this.SuspendLayout();
            // 
            // picOriginal
            // 
            this.picOriginal.Image = Properties.Resources.Deer;
            this.picOriginal.Location = new System.Drawing.Point(12, 12);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(339, 476);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picOriginal.TabIndex = 0;
            this.picOriginal.TabStop = false;
            this.picOriginal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picOriginal_MouseClick);
            // 
            // howto_paste_png_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 499);
            this.Controls.Add(this.picOriginal);
            this.Name = "howto_paste_png_Form1";
            this.Text = "howto_paste_png";
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picOriginal;
    }
}

