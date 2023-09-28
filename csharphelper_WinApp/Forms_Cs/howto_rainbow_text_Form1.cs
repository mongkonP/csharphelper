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

 

using howto_rainbow_text;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_rainbow_text_Form1:Form
  { 


        public howto_rainbow_text_Form1()
        {
            InitializeComponent();
        }

        // Redraw on resize.
        private void howto_rainbow_text_Form1_Load(object sender, EventArgs e)
        {
            this.ResizeRedraw = true;
        }

        // Draw the rainbow text.
        private void howto_rainbow_text_Form1_Paint(object sender, PaintEventArgs e)
        {
            const string Txt = "RAINBOW!";

            // Make the result smoother.
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            // Make a font.
            using (Font the_font = new Font("Times New Roman", 75,
                FontStyle.Bold, GraphicsUnit.Pixel))
            {
                // Get the font's metrics.
                FontInfo font_info = new FontInfo(e.Graphics, the_font);

                // See how big the text is.
                SizeF text_size = e.Graphics.MeasureString(Txt, the_font);
                int x0 = (int)((this.ClientSize.Width - text_size.Width) / 2);
                int y0 = (int)((this.ClientSize.Height - text_size.Height) / 2);

                // Get the Y coordinates that the brush should span.
                int brush_y0 = (int)(y0 + font_info.InternalLeadingPixels);
                int brush_y1 = (int)(y0 + font_info.AscentPixels);

                // Fudge the brush down a smidgen.
                brush_y0 += (int)(font_info.InternalLeadingPixels);
                brush_y1 += 5;

                // Make a brush to color the area.
                using (LinearGradientBrush the_brush = new LinearGradientBrush(
                    new Point(x0, brush_y0),
                    new Point(x0, brush_y1),
                    Color.Red, Color.Violet))
                {
                    Color[] colors = new Color[]
                    {
                        Color.FromArgb(255, 0, 0),
                        Color.FromArgb(255, 0, 0),
                        Color.FromArgb(255, 128, 0),
                        Color.FromArgb(255, 255, 0),
                        Color.FromArgb(0, 255, 0),
                        Color.FromArgb(0, 255, 128),
                        Color.FromArgb(0, 255, 255),
                        Color.FromArgb(0, 128, 255),
                        Color.FromArgb(0, 0, 255),
                        Color.FromArgb(0, 0, 255),
                    };
                    int num_colors = colors.Length;
                    float[] blend_positions = new float[num_colors];
                    for (int i = 0; i < num_colors; i++)
                    {
                        blend_positions[i] = i / (num_colors - 1f);
                    }

                    ColorBlend color_blend = new ColorBlend();
                    color_blend.Colors = colors;
                    color_blend.Positions = blend_positions;
                    the_brush.InterpolationColors = color_blend;

                    // Draw the text.
                    e.Graphics.DrawString(Txt, the_font, the_brush, x0, y0);
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
            this.SuspendLayout();
            // 
            // howto_rainbow_text_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 126);
            this.Name = "howto_rainbow_text_Form1";
            this.Text = "howto_rainbow_text";
            this.Load += new System.EventHandler(this.howto_rainbow_text_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_rainbow_text_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

