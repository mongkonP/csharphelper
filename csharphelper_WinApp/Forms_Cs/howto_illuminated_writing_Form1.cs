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
     public partial class howto_illuminated_writing_Form1:Form
  { 


        public howto_illuminated_writing_Form1()
        {
            InitializeComponent();
        }

        // The text to draw.
        private string[] paragraphs =
        {
            "Once there were three bats. They lived in a cave surrounded by three castles. One night the bats made a bet to see who could drink the most blood.",
            "The first bat comes home one night and has blood dripping off his fangs. The other two bats are amazed and asked how much blood he had drunk.",
            "The first bat said, \"See that castle over there? I drank the blood of three people.\" The second bat goes out on his night and comes back with blood around his mouth. The other two bats are astonished and ask how many people's blood had he drunk. The bat said, \"See that castle over there. I drank the blood of five people.\"",
            "The third bat goes out on his night and comes back covered in blood. This was totally amazing to the other two bats. They ask how much blood he drank. The 3rd bat said, \"See that castle over there?\" and the other bats nod. \"Well,\" says the third bat, \"I didn't.\"",
        };

        // Draw the text.
        private void picWriting_Paint(object sender, PaintEventArgs e)
        {
            // Get the available space.
            const int paragraph_spacing = 10;
            const int margin = 5;
            RectangleF rect = new RectangleF(margin, margin,
                picWriting.ClientSize.Width - 2 * margin,
                picWriting.ClientSize.Height - 2 * margin);

            // Make the fonts.
            using (Font lead_font = new Font("Times New Roman", 30, FontStyle.Bold))
            {
                using (Font body_font = new Font("Times New Roman", 12))
                {
                    // Draw the text.
                    foreach (string paragraph in paragraphs)
                        //DrawIlluminatedText(e.Graphics, 0, 0,
                        DrawIlluminatedText(e.Graphics, 50, 55,
                            lead_font, Brushes.Green, Pens.Green,
                            body_font, Brushes.Black,
                            ref rect, paragraph_spacing, paragraph);
                }
            }
        }

        // Force a redraw.
        private void picWriting_Resize(object sender, EventArgs e)
        {
            picWriting.Refresh();
        }

        // Draw an illuminated paragraph.
        private void DrawIlluminatedText(Graphics gr,
            float min_lead_width, float min_lead_height,
            Font lead_font, Brush lead_brush, Pen lead_pen,
            Font body_font, Brush body_brush,
            ref RectangleF rect, int paragraph_spacing, string paragraph)
        {
            // Get the lead character.
            string ch = paragraph.Substring(0, 1);
            paragraph = paragraph.Substring(1);

            // Size the lead character.
            SizeF lead_size = gr.MeasureString(ch, lead_font);
            if (lead_size.Width < min_lead_width)
                lead_size.Width = min_lead_width;
            if (lead_size.Height < min_lead_height)
                lead_size.Height = min_lead_height;

            // Make a StringFormat to align and trim the text.
            using (StringFormat string_format = new StringFormat())
            {
                // Stop drawing each line at a word boundary.
                string_format.Trimming = StringTrimming.Word;

                // See how much space is available for the side text.
                SizeF side_size = new SizeF(
                    rect.Width - lead_size.Width,
                    lead_size.Height);

                // See how much side text will fit
                // allowing a partial line at the end.
                int chars_fitted, lines_filled;
                side_size = gr.MeasureString(paragraph, body_font,
                    side_size, string_format,
                    out chars_fitted, out lines_filled);

                // Get the side text.
                string side_text = paragraph.Substring(0, chars_fitted);
                paragraph = paragraph.Substring(chars_fitted);

                // Draw only complete lines.
                string_format.FormatFlags = StringFormatFlags.LineLimit;

                // See how much space the side text needs.
                side_size.Height += 1000;
                side_size = gr.MeasureString(side_text, body_font,
                    side_size, string_format,
                    out chars_fitted, out lines_filled);
                if (side_size.Height < min_lead_height)
                    side_size.Height = min_lead_height;

                // Use at least that much height for the lead character.
                if (lead_size.Height < side_size.Height)
                    lead_size.Height = side_size.Height;

                // Illuminate the lead character.
                gr.DrawRectangle(lead_pen, rect.X, rect.Y,
                    lead_size.Width, lead_size.Height);

                // Draw the lead character.
                RectangleF lead_rect = new RectangleF(
                    rect.X, rect.Y, lead_size.Width, lead_size.Height);
                string_format.Alignment = StringAlignment.Center;
                string_format.LineAlignment = StringAlignment.Center;
                gr.DrawString(ch, lead_font, lead_brush, lead_rect, string_format);
                string_format.Alignment = StringAlignment.Near;
                string_format.LineAlignment = StringAlignment.Near;

                // Get the area available for the side text.
                RectangleF side_rect = new RectangleF(
                    rect.X + lead_size.Width,
                    rect.Y,
                    side_size.Width,
                    side_size.Height);

                // Draw the side text.
                gr.DrawString(side_text, body_font, body_brush,
                    side_rect, string_format);

                // Remove the space used by the side text.
                rect.Y += lead_size.Height;
                rect.Height -= lead_size.Height;

                // Draw the rest of the paragraph.
                gr.DrawString(paragraph, body_font, body_brush, rect, string_format);

                // See how much space that used.
                SizeF rect_size = new SizeF(rect.Width, rect.Height);
                SizeF size = gr.MeasureString(paragraph, body_font, rect_size);

                // Remove the used space.
                rect.Y += size.Height + paragraph_spacing;
                rect.Height -= size.Height + paragraph_spacing;
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
            this.picWriting = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picWriting)).BeginInit();
            this.SuspendLayout();
            // 
            // picWriting
            // 
            this.picWriting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picWriting.BackColor = System.Drawing.Color.White;
            this.picWriting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picWriting.Location = new System.Drawing.Point(12, 12);
            this.picWriting.Name = "picWriting";
            this.picWriting.Size = new System.Drawing.Size(460, 337);
            this.picWriting.TabIndex = 0;
            this.picWriting.TabStop = false;
            this.picWriting.Resize += new System.EventHandler(this.picWriting_Resize);
            this.picWriting.Paint += new System.Windows.Forms.PaintEventHandler(this.picWriting_Paint);
            // 
            // howto_illuminated_writing_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.picWriting);
            this.Name = "howto_illuminated_writing_Form1";
            this.Text = "howto_illuminated_writing";
            ((System.ComponentModel.ISupportInitialize)(this.picWriting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picWriting;
    }
}

