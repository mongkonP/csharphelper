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
     public partial class howto_drawn_char_under_mouse_Form1:Form
  { 


        public howto_drawn_char_under_mouse_Form1()
        {
            InitializeComponent();
        }

        // The text.
        private string TheText =
            "When in the course of human events it " +
            "becomes necessary for the quick brown " +
            "fox to jump over the lazy dog...";

        // The character locations.
        private List<RectangleF> TheRects;

        // Draw the text.
        private void howto_drawn_char_under_mouse_Form1_Load(object sender, EventArgs e)
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
                    gr.DrawString(TheText, font, Brushes.Blue, 4, 4);

                    // Measure the characters.
                    TheRects = MeasureCharacters(gr, font, TheText);
                }
            }

            // Display the result.
            picText.Image = bm;
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
                for (int i = 0; i < rects.Count + 1 - 1; i++)
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

        private void picText_MouseMove(object sender, MouseEventArgs e)
        {
            // See if the mouse is over one of the character rectangles.
            string new_text = "";
            for (int i = 0; i < TheText.Length; i++)
            {
                if (TheRects[i].Contains(e.Location))
                {
                    new_text =
                        "Character " + i.ToString() + ": " + TheText[i];
                    break;
                }
            }
            if (lblChar.Text != new_text) lblChar.Text = new_text;
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
            this.lblChar = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.picText.Size = new System.Drawing.Size(1010, 74);
            this.picText.TabIndex = 0;
            this.picText.TabStop = false;
            this.picText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picText_MouseMove);
            // 
            // lblChar
            // 
            this.lblChar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblChar.AutoSize = true;
            this.lblChar.Location = new System.Drawing.Point(12, 89);
            this.lblChar.Name = "lblChar";
            this.lblChar.Size = new System.Drawing.Size(56, 13);
            this.lblChar.TabIndex = 1;
            this.lblChar.Text = "Character:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(74, 239);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // howto_drawn_char_under_mouse_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 111);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblChar);
            this.Controls.Add(this.picText);
            this.Name = "howto_drawn_char_under_mouse_Form1";
            this.Text = "howto_drawn_char_under_mouse";
            this.Load += new System.EventHandler(this.howto_drawn_char_under_mouse_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picText)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picText;
        private System.Windows.Forms.Label lblChar;
        private System.Windows.Forms.TextBox textBox1;
    }
}

