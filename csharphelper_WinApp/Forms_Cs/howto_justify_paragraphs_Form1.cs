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
     public partial class howto_justify_paragraphs_Form1:Form
  { 


        public howto_justify_paragraphs_Form1()
        {
            InitializeComponent();
        }

        // Text justification.
        public enum TextJustification
        {
            Left,
            Right,
            Center,
            Justified,
        }

        // Arrangement parameters.
        private Padding TextMargin = new Padding(5);
        private const float ParagraphIndent = 10f;
        private const float LineSpacing = 1f;
        private const float ExtraParagraphSpacing = 0.5f;

        // The text to display.
        private const string MessageText =
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse lobortis blandit mauris, a sagittis libero. Proin a posuere justo, vel scelerisque risus.\n" +
            "Sed condimentum suscipit est in sagittis. Maecenas ac nulla in metus gravida feugiat nec vel odio. Aenean vulputate urna vel gravida rhoncus.\n" +
            "Etiam vel lacinia urna, non ultrices arcu. Curabitur eget neque nec felis facilisis lacinia. Donec sit amet neque vel ligula scelerisque cursus et quis nisl.\n" +
            "Proin convallis metus elit, eu condimentum nunc ultrices vel. Maecenas elementum orci tellus, quis pretium risus fringilla non.\n" +
            "Quisque eget diam a erat vestibulum cursus ut nec nisi. Duis non velit quis augue mattis consectetur pharetra sed dolor.\n" +
            "Pellentesque luctus tempor ornare.\n" +
            "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Proin pellentesque dolor in leo porttitor, dignissim sollicitudin nulla bibendum.\n" +
            "Nullam sit amet faucibus nunc, nec laoreet orci. Etiam nec rutrum mauris. Integer sapien felis, placerat id orci eu, fermentum porta dui.\n" +
            "Nam in pharetra orci, sed sollicitudin urna. Suspendisse sit amet tellus sagittis, lobortis ante quis, consectetur est.\n" +
            "Aliquam tempor ligula in augue facilisis, vehicula fermentum sem elementum. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.";

        // Draw justified text on the PictureBox.
        private void picText_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(picText.BackColor);
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            // Draw within a rectangle excluding the margins.
            RectangleF rect = new RectangleF(
                TextMargin.Left, TextMargin.Top,
                picText.ClientSize.Width - TextMargin.Left - TextMargin.Right,
                picText.ClientSize.Height - TextMargin.Top - TextMargin.Bottom);

            // Get the desired alignment.
            TextJustification justification = TextJustification.Left;
            if (chkCenter.Checked) justification = TextJustification.Center;
            else if (chkRight.Checked) justification = TextJustification.Right;
            else if (chkJustify.Checked) justification = TextJustification.Justified;

            // Draw the text.
            using (Font font = new Font("Times New Roman", 10))
            {
                rect = DrawParagraphs(e.Graphics, rect, font,
                    Brushes.Green, MessageText, justification,
                    LineSpacing, ParagraphIndent,
                    ExtraParagraphSpacing);
            }

            // Show the text drawing area.
            rect = new RectangleF(
                TextMargin.Left, TextMargin.Top,
                picText.ClientSize.Width - TextMargin.Left - TextMargin.Right,
                picText.ClientSize.Height - TextMargin.Top - TextMargin.Bottom);
            e.Graphics.DrawRectangle(Pens.Silver, Rectangle.Round(rect));
        }
        private void picText_Resize(object sender, EventArgs e)
        {
            picText.Refresh();
        }

        // Draw justified text on the Graphics object in the indicated Rectangle.
        private RectangleF DrawParagraphs(Graphics gr, RectangleF rect,
            Font font, Brush brush, string text,
            TextJustification justification, float line_spacing,
            float indent, float paragraph_spacing)
        {
            // Split the text into paragraphs.
            string[] paragraphs = text.Split('\n');

            // Draw each paragraph.
            foreach (string paragraph in paragraphs)
            {
                // Draw the paragraph and keep track of the rmaining space.
                rect = DrawParagraph(gr, rect, font, brush, paragraph,
                    justification, line_spacing, indent, paragraph_spacing);

                // See if there's any room left.
                if (rect.Height < font.Size) break;
            }

            return rect;
        }

        // Draw a paragraph by lines inside the Rectangle.
        // Return a RectangleF representing any unused
        // space in the original RectangleF.
        private RectangleF DrawParagraph(Graphics gr, RectangleF rect,
            Font font, Brush brush, string text,
            TextJustification justification, float line_spacing,
            float indent, float extra_paragraph_spacing)
        {
            // Get the coordinates for the first line.
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

                // If this is the end of the paragraph and
                // we're justifying, align on the left.
                if ((end_word == words.Length) &&
                    (justification == TextJustification.Justified))
                {
                    DrawLine(gr, line, font, brush,
                        rect.Left + indent,
                        y,
                        rect.Width - indent,
                        TextJustification.Left);
                }
                else
                {
                    DrawLine(gr, line, font, brush,
                        rect.Left + indent,
                        y,
                        rect.Width - indent,
                        justification);
                }

                // Move down to draw the next line.
                y += font.Height * line_spacing;

                // Make sure there's room for another line.
                if (font.Size > rect.Height) break;

                // Start the next line at the next word.
                start_word = end_word + 1;
                if (start_word >= words.Length) break;

                // Don't indent subsequent lines in this paragraph.
                indent = 0;
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
            Brush brush, float x, float y, float width,
            TextJustification justification)
        {
            // Make a rectangle to hold the text.
            RectangleF rect = new RectangleF(x, y, width, font.Height);

            // See if we should justify the text.
            if (justification == TextJustification.Justified)
                DrawJustifiedLine(gr, rect, font, brush, line);
            else
            {
                // Make a StringFormat to align the text.
                using (StringFormat sf = new StringFormat())
                {
                    // Use the appropriate alignment.
                    switch (justification)
                    {
                        case TextJustification.Left:
                            sf.Alignment = StringAlignment.Near;
                            break;
                        case TextJustification.Right:
                            sf.Alignment = StringAlignment.Far;
                            break;
                        case TextJustification.Center:
                            sf.Alignment = StringAlignment.Center;
                            break;
                    }

                    gr.DrawString(line, font, brush, rect, sf);
                }
            }
        }

        // Draw justified text on the Graphics object
        // in the indicated Rectangle.
        private void DrawJustifiedLine(Graphics gr, RectangleF rect,
            Font font, Brush brush, string text)
        {
            // Break the text into words.
            string[] words = text.Split(' ');

            // Add a space to each word and get their lengths.
            float[] word_width = new float[words.Length];
            float total_width = 0;
            for (int i = 0; i < words.Length; i++)
            {
                // See how wide this word is.
                SizeF size = gr.MeasureString(words[i], font);
                word_width[i] = size.Width;
                total_width += word_width[i];
            }

            // Get the additional spacing between words.
            float extra_space = rect.Width - total_width;
            int num_spaces = words.Length - 1;
            if (words.Length > 1) extra_space /= num_spaces;

            // Draw the words.
            float x = rect.Left;
            float y = rect.Top;
            for (int i = 0; i < words.Length; i++)
            {
                // Draw the word.
                gr.DrawString(words[i], font, brush, x, y);

                // Move right to draw the next word.
                x += word_width[i] + extra_space;
            }
        }

        // Uncheck the othuer ToolStripButtons and redraw the text.
        private void chkAlignment_Click(object sender, EventArgs e)
        {
            // Uncheck the other buttons.
            ToolStripButton btn = sender as ToolStripButton;
            ToolStripButton[] buttons = { chkLeft, chkCenter, chkRight, chkJustify };
            foreach (ToolStripButton test_button in buttons)
            {
                if (test_button != btn) test_button.Checked = false;
            }

            // Redraw the text.
            picText.Refresh();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_justify_paragraphs_Form1));
            this.chkRight = new System.Windows.Forms.ToolStripButton();
            this.picText = new System.Windows.Forms.PictureBox();
            this.chkLeft = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.chkCenter = new System.Windows.Forms.ToolStripButton();
            this.chkJustify = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.picText)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkRight
            // 
            this.chkRight.CheckOnClick = true;
            this.chkRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.chkRight.Image = ((System.Drawing.Image)(resources.GetObject("chkRight.Image")));
            this.chkRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.chkRight.Name = "chkRight";
            this.chkRight.Size = new System.Drawing.Size(23, 22);
            this.chkRight.Text = "toolStripButton3";
            this.chkRight.Click += new System.EventHandler(this.chkAlignment_Click);
            // 
            // picText
            // 
            this.picText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picText.BackColor = System.Drawing.Color.White;
            this.picText.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picText.Location = new System.Drawing.Point(12, 34);
            this.picText.Name = "picText";
            this.picText.Size = new System.Drawing.Size(285, 221);
            this.picText.TabIndex = 6;
            this.picText.TabStop = false;
            this.picText.Resize += new System.EventHandler(this.picText_Resize);
            this.picText.Paint += new System.Windows.Forms.PaintEventHandler(this.picText_Paint);
            // 
            // chkLeft
            // 
            this.chkLeft.Checked = true;
            this.chkLeft.CheckOnClick = true;
            this.chkLeft.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.chkLeft.Image = ((System.Drawing.Image)(resources.GetObject("chkLeft.Image")));
            this.chkLeft.ImageTransparentColor = System.Drawing.Color.Red;
            this.chkLeft.Name = "chkLeft";
            this.chkLeft.Size = new System.Drawing.Size(23, 22);
            this.chkLeft.Text = "toolStripButton1";
            this.chkLeft.Click += new System.EventHandler(this.chkAlignment_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chkLeft,
            this.chkCenter,
            this.chkRight,
            this.chkJustify});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(309, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // chkCenter
            // 
            this.chkCenter.CheckOnClick = true;
            this.chkCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.chkCenter.Image = ((System.Drawing.Image)(resources.GetObject("chkCenter.Image")));
            this.chkCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.chkCenter.Name = "chkCenter";
            this.chkCenter.Size = new System.Drawing.Size(23, 22);
            this.chkCenter.Text = "toolStripButton2";
            this.chkCenter.Click += new System.EventHandler(this.chkAlignment_Click);
            // 
            // chkJustify
            // 
            this.chkJustify.CheckOnClick = true;
            this.chkJustify.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.chkJustify.Image = ((System.Drawing.Image)(resources.GetObject("chkJustify.Image")));
            this.chkJustify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.chkJustify.Name = "chkJustify";
            this.chkJustify.Size = new System.Drawing.Size(23, 22);
            this.chkJustify.Text = "toolStripButton1";
            this.chkJustify.Click += new System.EventHandler(this.chkAlignment_Click);
            // 
            // howto_justify_paragraphs_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 261);
            this.Controls.Add(this.picText);
            this.Controls.Add(this.toolStrip1);
            this.Name = "howto_justify_paragraphs_Form1";
            this.Text = "howto_justify_paragraphs";
            ((System.ComponentModel.ISupportInitialize)(this.picText)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton chkRight;
        private System.Windows.Forms.PictureBox picText;
        private System.Windows.Forms.ToolStripButton chkLeft;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton chkCenter;
        private System.Windows.Forms.ToolStripButton chkJustify;
    }
}

