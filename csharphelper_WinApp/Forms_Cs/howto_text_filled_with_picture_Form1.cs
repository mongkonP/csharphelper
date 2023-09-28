using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Text;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_text_filled_with_picture_Form1:Form
  { 


        public howto_text_filled_with_picture_Form1()
        {
            InitializeComponent();
        }

        // Make the image.
        private void howto_text_filled_with_picture_Form1_Load(object sender, EventArgs e)
        {
            // Make the bitmap we will display.
            Bitmap bm = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                gr.Clear(this.BackColor);

                // Make text filled with a single big image.
                // Make a brush containing the picture.
                using (TextureBrush the_brush = new TextureBrush(Properties.Resources.ColoradoFlowers))
                {
                    // Draw the text.
                    using (Font the_font = new Font("Times New Roman", 150, FontStyle.Bold))
                    {
                        gr.DrawString("Flowers", the_font, the_brush, 0, 0);
                    }
                }

                // Make text filled with a tiled image.
                // Make a brush containing the picture.
                using (TextureBrush the_brush = new TextureBrush(Properties.Resources.Smiley))
                {
                    // Draw the text.
                    using (Font the_font = new Font("Times New Roman", 150, FontStyle.Bold))
                    {
                        gr.DrawString("Smile!", the_font, the_brush, 75, 175);
                    }
                }
            }

            // Display the result.
            this.BackgroundImage = bm;
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
            this.SuspendLayout();
            // 
            // howto_text_filled_with_picture_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 413);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "howto_text_filled_with_picture_Form1";
            this.Text = "howto_text_filled_with_picture";
            this.Load += new System.EventHandler(this.howto_text_filled_with_picture_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

