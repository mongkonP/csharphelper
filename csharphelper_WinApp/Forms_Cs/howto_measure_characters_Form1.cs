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
     public partial class howto_measure_characters_Form1:Form
  { 


        public howto_measure_characters_Form1()
        {
            InitializeComponent();
        }

        // Redraw on resize.
        private void howto_measure_characters_Form1_Load(object sender, EventArgs e)
        {
            this.ResizeRedraw = true;
        }

        // Draw a string with character bounds.
        private void howto_measure_characters_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int wid = ClientSize.Width;
            int hgt = ClientSize.Height / 2;
            Rectangle rect = new Rectangle(0, 0, wid, hgt);
            using (Font font = new Font("Times New Roman", 60, FontStyle.Italic))
            {
                DrawStringWithCharacterBounds(e.Graphics, "C# Helper", font, rect);
            }

            wid /= 2;
            rect = new Rectangle(0, hgt, wid, hgt);
            using (Font font = new Font("Times New Roman", 60, FontStyle.Regular))
            {
                DrawStringWithCharacterBounds(e.Graphics, "jiffy", font, rect);
            }

            rect = new Rectangle(wid, hgt, wid, hgt);
            using (Font font = new Font("Times New Roman", 60, FontStyle.Italic))
            {
                DrawStringWithCharacterBounds(e.Graphics, "jiffy", font, rect);
            }
        }

        // Draw the string and the bounds for its characters.
        private void DrawStringWithCharacterBounds(Graphics gr, string text, Font font, Rectangle rect)
        {
            using (StringFormat string_format = new StringFormat())
            {
                string_format.Alignment = StringAlignment.Center;
                string_format.LineAlignment = StringAlignment.Center;

                // Draw the string.
                gr.DrawString(text, font, Brushes.Blue, rect, string_format);

                // Make a CharacterRange for the string's characters.
                List<CharacterRange> range_list = new List<CharacterRange>();
                for (int i = 0; i < text.Length; i++)
                {
                    range_list.Add(new CharacterRange(i, 1));
                }
                string_format.SetMeasurableCharacterRanges(range_list.ToArray());

                // Measure the string's character ranges.
                Region[] regions = gr.MeasureCharacterRanges(
                    text, font, rect, string_format);

                // Draw the character bounds.
                for (int i = 0; i < text.Length; i++)
                {
                    Rectangle char_rect = Rectangle.Round(regions[i].GetBounds(gr));
                    gr.DrawRectangle(Pens.Red, char_rect);
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
            // howto_measure_characters_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 214);
            this.Name = "howto_measure_characters_Form1";
            this.Text = "howto_measure_characters";
            this.Load += new System.EventHandler(this.howto_measure_characters_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_measure_characters_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

