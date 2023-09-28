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
     public partial class howto_print_lines_of_paragraph_Form1:Form
  { 


        public howto_print_lines_of_paragraph_Form1()
        {
            InitializeComponent();
        }

        // Arrangement parameters.
        private Padding TextMargin = new Padding(2, 2, 2, 2);
        private const float ParagraphIndent = 20f;
        private const float LineSpacing = 1f;
        private const float ExtraParagraphSpacing = 0.5f;

        // The paragraph of text to display.
        private const string MessageText =
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi suscipit suscipit quam, sit amet vestibulum libero ornare id. Nulla facilisi. Mauris egestas justo nec elementum venenatis. Curabitur bibendum interdum elit porttitor tincidunt. Quisque pretium pellentesque facilisis. Quisque in elementum mauris. Sed ullamcorper gravida congue. Mauris suscipit rhoncus magna id placerat. Suspendisse in leo at nisi consectetur lobortis. Duis venenatis tincidunt tellus nec dignissim. Proin fringilla laoreet nibh, at ultrices ante ultrices nec. Phasellus eget fringilla massa, non fermentum urna. Aliquam id lacus tincidunt dolor gravida mollis. Sed nulla dolor, volutpat in elementum et, rhoncus vitae risus. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aenean id erat vitae velit venenatis luctus.";

        // Draw the text one line at a time.
        private void picText_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(picText.BackColor);
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            // Draw within a rectangle excluding the margins.
            RectangleF rect = new RectangleF(
                TextMargin.Left, TextMargin.Top,
                picText.ClientSize.Width - TextMargin.Left - TextMargin.Right,
                picText.ClientSize.Height - TextMargin.Top - TextMargin.Bottom);

            // Draw the paragraph.
            using (Font font = new Font("Times New Roman", 10))
            {
                DrawParagraph(e.Graphics, rect, font,
                    Brushes.Blue, MessageText, LineSpacing,
                    ParagraphIndent, ExtraParagraphSpacing);
            }

            // Show the text area.
            e.Graphics.DrawRectangle(Pens.Silver, Rectangle.Round(rect));
        }
        private void picText_Resize(object sender, EventArgs e)
        {
            picText.Refresh();
        }

        // Draw a paragraph by lines inside the Rectangle.
        // Return a RectangleF representing any unused
        // space in the original RectangleF.
        private RectangleF DrawParagraph(Graphics gr, RectangleF rect,
            Font font, Brush brush, string text, float line_spacing,
            float indent, float extra_paragraph_spacing)
        {
            // Get the coordinates for the first line.
            float x = rect.Left + indent;
            float y = rect.Top;

            // Break the text into words.
            string[] words = text.Split(' ');
            int start_word = 0;

            // Repeat until we run out of text or room.
            for (; ; )
            {
                // See how many words will fit.
                // Start with just the next word.
                string line = words[start_word];

                // Add more words until the line won't fit.
                int end_word = start_word + 1;
                while (end_word < words.Length)
                {
                    // See if the next word fits.
                    string test_line = line + " " + words[end_word];
                    SizeF line_size = gr.MeasureString(test_line, font);
                    if (line_size.Width > rect.Width)
                    {
                        // The line is too wide. Don't use the last word.
                        end_word--;
                        break;
                    }
                    else
                    {
                        // The word fits. Save the test line.
                        line = test_line;
                    }

                    // Try the next word.
                    end_word++;
                }

                // Draw this line.
                DrawLine(gr, line, font, brush, x, y, rect.Width);

                // Move down to draw the next line.
                y += font.Height * line_spacing;

                // Make sure there's room for another line.
                if (y + font.Height > rect.Height) break;

                // Start the next line at the next word.
                start_word = end_word + 1;
                if (start_word >= words.Length) break;

                // Don't indent subsequent lines.
                x = rect.Left;
            }

            // Add a gap after the paragraph.
            y += font.Height * extra_paragraph_spacing;

            // Return a RectangleF representing any unused
            // space in the original RectangleF.
            float height = rect.Bottom - y;
            if (height < 0) height = 0;
            return new RectangleF(rect.X, y, rect.Width, height);
        }

        // Draw a line of text.
        private void DrawLine(Graphics gr, string line, Font font,
            Brush brush, float x, float y, float width)
        {
            gr.DrawString(line, font, brush, x, y);
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
            this.picText.Size = new System.Drawing.Size(320, 237);
            this.picText.TabIndex = 2;
            this.picText.TabStop = false;
            this.picText.Resize += new System.EventHandler(this.picText_Resize);
            this.picText.Paint += new System.Windows.Forms.PaintEventHandler(this.picText_Paint);
            // 
            // howto_print_lines_of_paragraph_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 261);
            this.Controls.Add(this.picText);
            this.Name = "howto_print_lines_of_paragraph_Form1";
            this.Text = "howto_print_lines_of_paragraph";
            ((System.ComponentModel.ISupportInitialize)(this.picText)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picText;
    }
}

