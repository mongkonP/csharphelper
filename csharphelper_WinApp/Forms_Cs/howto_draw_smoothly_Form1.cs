using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Text;
using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_draw_smoothly_Form1:Form
  { 


        public howto_draw_smoothly_Form1()
        {
            InitializeComponent();
        }

        // Draw text, shapes, and pictures smoothly and not smoothly.
        private void howto_draw_smoothly_Form1_Paint(object sender, PaintEventArgs e)
        {
            using (Font the_font = new Font("Times New Roman", 16))
            {
                // Draw without smoothing.
                int x = 10, y = 10;
                e.Graphics.TextRenderingHint =
                    TextRenderingHint.SingleBitPerPixelGridFit;
                e.Graphics.DrawString("Without Smoothing",
                    the_font, Brushes.Blue, x, y);
                y += 25;
                e.Graphics.DrawImage(Properties.Resources.Smiley100x100,
                    x, y, 50, 50);
                y += 60;
                e.Graphics.DrawEllipse(Pens.Red, x, y, 100, 50);

                // Draw with smoothing.
                e.Graphics.SmoothingMode =
                    SmoothingMode.AntiAlias;
                e.Graphics.TextRenderingHint =
                    TextRenderingHint.AntiAliasGridFit;
                e.Graphics.InterpolationMode =
                    InterpolationMode.High;

                x = 200;
                y = 10;
                e.Graphics.DrawString("With Smoothing", the_font, Brushes.Blue, x, y);
                y += 25;
                e.Graphics.DrawImage(Properties.Resources.Smiley100x100,
                    x, y, 50, 50);
                y += 60;
                e.Graphics.DrawEllipse(Pens.Red, x, y, 100, 50);
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
            // howto_draw_smoothly_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 164);
            this.Name = "howto_draw_smoothly_Form1";
            this.Text = "howto_draw_smoothly";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_draw_smoothly_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

    }
}

