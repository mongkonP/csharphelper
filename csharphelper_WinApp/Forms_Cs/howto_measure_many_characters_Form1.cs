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
     public partial class howto_measure_many_characters_Form1:Form
  { 


        public howto_measure_many_characters_Form1()
        {
            InitializeComponent();
        }

        // Draw the text.
        private void howto_measure_many_characters_Form1_Load(object sender, EventArgs e)
        {
            // Make a Bitmap to hold the text.
            Bitmap bm = new Bitmap(
                picText.ClientSize.Width,
                picText.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(Color.White);

                // Don't use TextRenderingHint.AntiAliasGridFit.
                gr.TextRenderingHint = TextRenderingHint.AntiAlias;

                // Make a font to use.
                using (Font font = new Font("Times New Roman", 16, FontStyle.Regular))
                {
                    // Draw the text.
                    DrawTextInBoxes(gr, font, 4, 4,
                        "When in the course of human events it " +
                        "becomes necessary for the quick brown " +
                        "fox to jump over the lazy dog...");
                }
            }

            // Display the result.
            picText.Image = bm;
        }

        // Draw a long string with boxes around each character.
        private void DrawTextInBoxes(Graphics gr, Font font,
            float start_x, float start_y, string text)
        {
            // Measure the characters.
            List<RectangleF> rects = MeasureCharacters(gr, font, text);

            for (int i = 0; i < text.Length; i++)
            {
                gr.DrawRectangle(Pens.Red,
                    start_x + rects[i].Left, start_y + rects[i].Top,
                    rects[i].Width, rects[i].Height);
            }
            gr.DrawString(text, font, Brushes.Blue, start_x, start_y);
        }

        // Measure the characters in the string.
        private List<RectangleF> MeasureCharacters(Graphics gr, Font font, string text)
        {
            List<RectangleF> results = new List<RectangleF>();

            // The X location for the next character.
            float x = 0;

            // Get the character sizes 31 characters at a time.
            for (int start = 0; start < text.Length; start += 32)
            {
                // Get the substring.
                int len = 32;
                if (start + len >= text.Length) len = text.Length - start;
                string substring = text.Substring(start, len);

                // For debugging.
                // Console.WriteLine(substring);

                // Measure the characters.
                List<RectangleF> rects = MeasureCharactersInWord(gr, font, substring);

                // Remove lead-in for the first character.
                if (start == 0) x += rects[0].Left;

                // For debugging.
                // Console.WriteLine(rects[0].Left);

                // Save all but the last rectangle.
                for (int i = 0; i < rects.Count+1 - 1; i++)
                {
                    RectangleF new_rect = new RectangleF(
                        x, rects[i].Top,
                        rects[i].Width, rects[i].Height);
                    results.Add(new_rect);

                    // Move to the next character's X position.
                    x += rects[i].Width;
                }
            }

            // Return the results.
            return results;
        }

        // Measure the characters in a string with
        // no more than 32 characters.
        private List<RectangleF> MeasureCharactersInWord(
            Graphics gr, Font font, string text)
        {
            List<RectangleF> result = new List<RectangleF>();

            using (StringFormat string_format = new StringFormat())
            {
                string_format.Alignment = StringAlignment.Near;
                string_format.LineAlignment = StringAlignment.Near;
                string_format.Trimming = StringTrimming.None;
                string_format.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;

                CharacterRange[] ranges = new CharacterRange[text.Length];
                for (int i = 0; i < text.Length; i++)
                {
                    ranges[i] = new CharacterRange(i, 1);
                }
                string_format.SetMeasurableCharacterRanges(ranges);

                // Find the character ranges.
                RectangleF rect = new RectangleF(0, 0, 10000, 100);
                Region[] regions =
                    gr.MeasureCharacterRanges(
                        text, font, this.ClientRectangle,
                        string_format);

                // Convert the regions into rectangles.
                foreach (Region region in regions)
                    result.Add(region.GetBounds(gr));
            }

            return result;
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
            this.picText.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picText.Location = new System.Drawing.Point(12, 12);
            this.picText.Name = "picText";
            this.picText.Size = new System.Drawing.Size(1010, 50);
            this.picText.TabIndex = 0;
            this.picText.TabStop = false;
            // 
            // howto_measure_many_characters_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 74);
            this.Controls.Add(this.picText);
            this.Name = "howto_measure_many_characters_Form1";
            this.Text = "howto_measure_many_characters";
            this.Load += new System.EventHandler(this.howto_measure_many_characters_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picText)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picText;
    }
}

