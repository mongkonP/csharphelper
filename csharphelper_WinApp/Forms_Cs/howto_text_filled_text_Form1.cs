using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_text_filled_text_Form1:Form
  { 


        public howto_text_filled_text_Form1()
        {
            InitializeComponent();
        }

        // Redraw on resize.
        private void howto_text_filled_text_Form1_Load(object sender, EventArgs e)
        {
            this.ResizeRedraw = true;
        }

        private void howto_text_filled_text_Form1_Paint(object sender, PaintEventArgs e)
        {
            // Make things smoother.
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Create the text path.
            GraphicsPath path = new GraphicsPath(FillMode.Alternate);

            // Draw text using a StringFormat to center it on the form.
            using (FontFamily font_family = new FontFamily("Times New Roman"))
            {
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    path.AddString("Text", font_family,
                        (int)FontStyle.Bold, 200,
                        this.ClientRectangle, sf);
                }
            }

            // Make a bitmap containing the small brush's text.
            using (Font small_font = new Font("Times New Roman", 8))
            {
                // See how big the text will be.
                SizeF text_size = e.Graphics.MeasureString("Text", small_font);

                // Make a Bitmap to hold the text.
                Bitmap bm = new Bitmap(
                    (int)(2 * text_size.Width),
                    (int)(2 * text_size.Height));
                using (Graphics gr = Graphics.FromImage(bm))
                {
                    gr.Clear(Color.LightBlue);
                    gr.DrawString("Text", small_font, Brushes.Red, 0, 0);
                    gr.DrawString("Text", small_font, Brushes.Green, 
                        text_size.Width, 0);
                    gr.DrawString("Text", small_font, Brushes.Blue,
                        -text_size.Width / 2,
                        text_size.Height);
                    gr.DrawString("Text", small_font, Brushes.DarkOrange, 
                        text_size.Width / 2,
                        text_size.Height);
                    gr.DrawString("Text", small_font, Brushes.Blue,
                        1.5f * text_size.Width,
                        text_size.Height);
                }

                // Fill the path.
                using (TextureBrush br = new TextureBrush(bm))
                {
                    e.Graphics.FillPath(br, path);
                }
            }

            // Outline the path.
            using (Pen pen = new Pen(Color.Black, 3))
            {
                e.Graphics.DrawPath(pen, path);
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
            this.SuspendLayout();
            // 
            // howto_text_filled_text_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 217);
            this.Name = "howto_text_filled_text_Form1";
            this.Text = "howto_text_filled_text";
            this.Load += new System.EventHandler(this.howto_text_filled_text_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_text_filled_text_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

