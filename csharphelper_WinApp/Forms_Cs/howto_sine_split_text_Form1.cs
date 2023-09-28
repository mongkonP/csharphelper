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
     public partial class howto_sine_split_text_Form1:Form
  { 


        public howto_sine_split_text_Form1()
        {
            InitializeComponent();
        }

        // Draw the split text.
        private void picText_Paint(object sender, PaintEventArgs e)
        {
            using (Font font = new Font("Times New Roman", 40, FontStyle.Bold))
            {
                Color top_bg_color = Color.LightGreen;
                Color top_fg_color = Color.Fuchsia;
                Color bottom_bg_color = Color.FromArgb(255, 128, 255);
                Color bottom_fg_color = Color.FromArgb(0, 128, 0);

                SolidBrush top_bg_brush = new SolidBrush(top_bg_color);
                SolidBrush top_fg_brush = new SolidBrush(top_fg_color);
                SolidBrush bottom_bg_brush = new SolidBrush(bottom_bg_color);
                SolidBrush bottom_fg_brush = new SolidBrush(bottom_fg_color);
 
                DrawSineSplitText(e.Graphics, "C# Helper",
                    font, picText.ClientRectangle,
                    top_bg_brush, top_fg_brush,
                    bottom_bg_brush, bottom_fg_brush,
                    2.5f, 0.25f);

                top_bg_brush.Dispose();
                top_fg_brush.Dispose();
                bottom_bg_brush.Dispose();
                bottom_fg_brush.Dispose();
            }
        }

        // Repaint on resize.
        private void picText_Resize(object sender, EventArgs e)
        {
            picText.Refresh();
        }

        // Draw sine split text centered in the indicated rectangle.
        private void DrawSineSplitText(Graphics gr,
            string text, Font font, Rectangle rect,
            Brush top_bg_brush, Brush top_fg_brush,
            Brush bottom_bg_brush, Brush bottom_fg_brush,
            float num_waves, float y_scale)
        {
            // Make bitmaps holding the text in different colors.
            Bitmap bm_top = new Bitmap(rect.Width, rect.Height);
            Bitmap bm_bottom = new Bitmap(rect.Width, rect.Height);

            // Make a StringFormat to center text.
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                using (Graphics gr_top = Graphics.FromImage(bm_top))
                {
                    gr_top.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                    gr_top.FillRectangle(top_bg_brush, rect);
                    gr_top.DrawString(text, font, top_fg_brush, rect, sf);
                }

                using (Graphics gr_bottom = Graphics.FromImage(bm_bottom))
                {
                    gr_bottom.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                    gr_bottom.FillRectangle(bottom_bg_brush, rect);
                    gr_bottom.DrawString(text, font, bottom_fg_brush, rect, sf);
                }
            }

            // Fill the rectangle with the top bitmap.
            using (TextureBrush brush = new TextureBrush(bm_top))
            {
                gr.FillRectangle(brush, rect);
            }

            // Make a polygon to fill the bottom half.
            List<PointF> points = new List<PointF>();
            float mag = (font.Size * 96f / 72f) / 2 * y_scale;
            float y_offset = rect.Height / 2f;
            points.Add(new PointF(0, rect.Height));
            float x_scale = (float)(num_waves * 2 * Math.PI / rect.Width);
            for (int x = 0; x < rect.Width; x++)
            {
                float y = (float)(y_offset + mag * Math.Sin(x * x_scale));
                points.Add(new PointF(x, y));            
            }
            points.Add(new PointF(rect.Width - 1, rect.Height));

            // Fill the polygon.
            using (TextureBrush brush = new TextureBrush(bm_bottom))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.FillPolygon(brush, points.ToArray());
            }

            bm_top.Dispose();
            bm_bottom.Dispose();
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
            this.picText = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picText)).BeginInit();
            this.SuspendLayout();
            // 
            // picText
            // 
            this.picText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picText.BackColor = System.Drawing.Color.White;
            this.picText.Location = new System.Drawing.Point(12, 12);
            this.picText.Name = "picText";
            this.picText.Size = new System.Drawing.Size(280, 87);
            this.picText.TabIndex = 0;
            this.picText.TabStop = false;
            this.picText.Resize += new System.EventHandler(this.picText_Resize);
            this.picText.Paint += new System.Windows.Forms.PaintEventHandler(this.picText_Paint);
            // 
            // howto_sine_split_text_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 111);
            this.Controls.Add(this.picText);
            this.Name = "howto_sine_split_text_Form1";
            this.Text = "howto_sine_split_text";
            ((System.ComponentModel.ISupportInitialize)(this.picText)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picText;
    }
}

