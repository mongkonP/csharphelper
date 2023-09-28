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
     public partial class howto_diagonal_split_text_Form1:Form
  { 


        public howto_diagonal_split_text_Form1()
        {
            InitializeComponent();
        }

        // Draw the split text.
        private void picText_Paint(object sender, PaintEventArgs e)
        {
            using (Font font = new Font("Times New Roman", 40, FontStyle.Bold))
            {
                DrawSplitText(e.Graphics, "C# Helper",
                    font, picText.ClientRectangle,
                    Brushes.Black, Brushes.White);
            }
        }

        // Repaint on resize.
        private void picText_Resize(object sender, EventArgs e)
        {
            picText.Refresh();
        }

        // Draw split text centered in the indicated rectangle.
        private void DrawSplitText(Graphics gr,
            string text, Font font, Rectangle rect,
            Brush top_fg_brush, Brush bottom_fg_brush)
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
                    gr_top.FillRectangle(bottom_fg_brush, rect);
                    gr_top.DrawString(text, font, top_fg_brush, rect, sf);
                }

                using (Graphics gr_bottom = Graphics.FromImage(bm_bottom))
                {
                    gr_bottom.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                    gr_bottom.FillRectangle(top_fg_brush, rect);
                    gr_bottom.DrawString(text, font, bottom_fg_brush, rect, sf);
                }
            }

            // Fill the entire rectangle with the top version.
            using (TextureBrush brush = new TextureBrush(bm_top))
            {
                gr.FillRectangle(brush, rect);
            }

            // Fill the lower left corner with the bottom version.
            Point[] points = 
            {
                new Point(rect.X, rect.Y),
                new Point(rect.X, rect.Bottom),
                new Point(rect.Right, rect.Bottom),
                //new Point(rect.X, rect.Bottom),
                //new Point(rect.Right, rect.Bottom),
                //new Point(rect.Right, rect.Y),
            };
            using (TextureBrush brush = new TextureBrush(bm_bottom))
            {
                gr.FillPolygon(brush, points);
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
            // howto_diagonal_split_text_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 111);
            this.Controls.Add(this.picText);
            this.Name = "howto_diagonal_split_text_Form1";
            this.Text = "howto_diagonal_split_text";
            ((System.ComponentModel.ISupportInitialize)(this.picText)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picText;
    }
}

