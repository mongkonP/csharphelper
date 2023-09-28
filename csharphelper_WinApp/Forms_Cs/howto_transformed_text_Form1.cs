using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Drawing.Text;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_transformed_text_Form1:Form
  { 


        public howto_transformed_text_Form1()
        {
            InitializeComponent();
        }

        // Draw some transformed text.
        private void howto_transformed_text_Form1_Paint(object sender, PaintEventArgs e)
        {
            // Transform.
            e.Graphics.ScaleTransform(1.5f, 1.5f, MatrixOrder.Append);
            e.Graphics.RotateTransform(25, MatrixOrder.Append);
            e.Graphics.TranslateTransform(80, 30, MatrixOrder.Append);

            // Make a font.
            using (Font the_font = new Font("Times New Roman", 20,
                FontStyle.Regular, GraphicsUnit.Pixel))
            {
                // See how big the text will be when drawn.
                string the_text = "WYSIWYG";
                SizeF text_size = e.Graphics.MeasureString(the_text, the_font);

                // Draw a rectangle and two ellipses.
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawRectangle(Pens.Blue, 0, 0,
                    text_size.Width, text_size.Height);
                e.Graphics.DrawEllipse(Pens.Red, -3, -3, 6, 6);
                e.Graphics.DrawEllipse(Pens.Green,
                    text_size.Width - 3, text_size.Height - 3, 6, 6);

                // Draw the text.
                e.Graphics.TextRenderingHint =
                    TextRenderingHint.AntiAliasGridFit;
                e.Graphics.DrawString(the_text, the_font,
                    Brushes.Brown, 0, 0);
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
            // howto_transformed_text_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 171);
            this.Name = "howto_transformed_text_Form1";
            this.Text = "howto_transformed_text";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_transformed_text_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

