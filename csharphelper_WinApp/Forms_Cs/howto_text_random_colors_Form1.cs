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
     public partial class howto_text_random_colors_Form1:Form
  { 


        public howto_text_random_colors_Form1()
        {
            InitializeComponent();
        }

        // Draw some text with each letter in a random color.
        private void howto_text_random_colors_Form1_Paint(object sender, PaintEventArgs e)
        {
            const string txt = "C# Helper!";

            // Make the font.
            using (Font the_font = new Font("Times New Roman", 40,
                FontStyle.Bold | FontStyle.Italic))
            {
                // Make a StringFormat object to use for text layout.
                using (StringFormat string_format = new StringFormat())
                {
                    // Center the text.
                    string_format.Alignment = StringAlignment.Center;
                    string_format.LineAlignment = StringAlignment.Center;
                    string_format.FormatFlags = StringFormatFlags.NoClip;

                    // Make CharacterRanges to indicate which
                    // ranges we want to measure.
                    CharacterRange[] ranges = new CharacterRange[txt.Length];
                    for (int i = 0; i < txt.Length; i++)
                    {
                        ranges[i] = new CharacterRange(i, 1);
                    }
                    string_format.SetMeasurableCharacterRanges(ranges);

                    // Measure the text to see where each character range goes.
                    Region[] regions =
                        e.Graphics.MeasureCharacterRanges(
                            txt, the_font, this.ClientRectangle,
                            string_format);

                    // Draw the characters one at a time.
                    for (int i = 0; i < txt.Length; i++)
                    {
                        // See where this character would be drawn.
                        RectangleF rectf = regions[i].GetBounds(e.Graphics);
                        Rectangle rect = new Rectangle(
                            (int)rectf.X, (int)rectf.Y,
                            (int)rectf.Width, (int)rectf.Height);

                        // Make a brush with a random color.
                        using (Brush the_brush = new SolidBrush(RandomColor()))
                        {
                            // Draw the character.
                            e.Graphics.DrawString(txt.Substring(i, 1),
                                the_font, the_brush, rectf, string_format);
                        }
                    }
                }
            }
        }

        // Return a random color.
        private Random rand = new Random();
        private Color[] colors =
        {
            Color.Red,
            Color.Green,
            Color.Blue,
            Color.Lime,
            Color.Orange,
            Color.Fuchsia,
        };
        private Color RandomColor()
        {
            return colors[rand.Next(0, colors.Length)];
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
            // howto_text_random_colors_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 120);
            this.Name = "howto_text_random_colors_Form1";
            this.Text = "howto_text_random_colors";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_text_random_colors_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

