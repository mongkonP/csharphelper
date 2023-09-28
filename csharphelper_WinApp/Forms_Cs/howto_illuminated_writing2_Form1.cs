using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_illuminated_writing2_Form1:Form
  { 


        public howto_illuminated_writing2_Form1()
        {
            InitializeComponent();
        }

        // The text to draw.
        string[] paragraphs =
        {
            "A math professor, John, is having problems with his sink so he calls a plumber. The plumber comes over and quickly fixes the sink. The professor is happy until he gets the bill. He tells the plumber, \"How can you charge this much? This is half of my paycheck.\" But he pays it anyways.",
            "The plumber tells him, \"Hey, we are looking for more plumbers. You could become a plumber and triple your salary. Just make sure you say you only made it to 6th grade, they don't like educated people.\"",
            "The professor takes him up on the offer and becomes a plumber. His salary triples and he doesn't have to work nearly as hard. But the company makes an announcement that all of their plumbers must get a 7th grade education. So they all go to night school.",
            "On the first day of night school they all attend math class. The teacher wants to gauge the class so he asks John, \"What is the formula for the area of a circle?\"",
            "John walks up to the board and is about to write the formula when he realizes he has forgotten it. So he begins to attempt to derive the formula, filling the board with complicated mathematics. He ends up figuring out it is negative pi times radius squared. He thinks the minus doesn't belong so he starts over, but again he comes up with the same equation. After staring at the board for a minute he looks out at the other plumbers and sees that they are all whispering, \"Switch the limits on the integral!\"",
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
                    // See how big to make the illuminated characters.
                    SizeF x_size = e.Graphics.MeasureString("W", lead_font);

                    // Draw the text.
                    foreach (string paragraph in paragraphs)
                    {
                        //DrawIlluminatedText(e.Graphics, 50, 55,
                        //    lead_font, Brushes.DarkRed, Pens.Green,
                        //    body_font, Brushes.Black,
                        //    ref rect, paragraph_spacing, paragraph,
                        //    DrawIlluminationBox1);

                        //DrawIlluminatedText(e.Graphics, 50, 55,
                        //    lead_font, Brushes.DarkBlue, Pens.Green,
                        //    body_font, Brushes.Black,
                        //    ref rect, paragraph_spacing, paragraph,
                        //    DrawIlluminationBox2);

                        DrawIlluminatedText(e.Graphics, 50, 55,
                            lead_font, Brushes.Black, Pens.Green,
                            body_font, Brushes.Black,
                            ref rect, paragraph_spacing, paragraph,
                            DrawIlluminationBox3);
                    }
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
            ref RectangleF rect, int paragraph_spacing, string paragraph,
            Action<Graphics, RectangleF> illuminator)
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
                RectangleF lead_rect = new RectangleF(
                    rect.X, rect.Y, lead_size.Width, lead_size.Height);
                illuminator(gr, lead_rect);

                // Draw the lead character.
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

        // Draw an illumination box with a elliptical gradient fill and outline.
        private void DrawIlluminationBox1(Graphics gr, RectangleF rectf)
        {
            gr.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = Rectangle.Round(rectf);
            Point point1 = new Point(rect.X, rect.Y);
            Point point2 = new Point(rect.Right, rect.Bottom);

            // Fill the center of the rectangle.
            using (Brush brush = new LinearGradientBrush(
                point1, point2, Color.Blue, Color.LightBlue))
            {
                gr.FillEllipse(brush, rect);
            }

            // Outline the rectangle.
            const int pen_half_width = 2;
            const int pen_width = 2 * pen_half_width;
            using (Brush brush = new LinearGradientBrush(
                point2, point1, Color.Blue, Color.LightBlue))
            {
                using (Pen pen = new Pen(brush, pen_width))
                {
                    gr.DrawEllipse(pen,
                        rect.X + pen_half_width,
                        rect.Y + pen_half_width,
                        rect.Width - pen_width,
                        rect.Height - pen_width);
                }
            }
        }

        // Draw an illumination box with a gradient fill and outline.
        private void DrawIlluminationBox2(Graphics gr, RectangleF rectf)
        {
            Rectangle rect = Rectangle.Round(rectf);
            Point point1 = new Point(rect.X, rect.Y);
            Point point2 = new Point(rect.Right, rect.Bottom);

            // Fill the center of the rectangle.
            using (Brush brush = new LinearGradientBrush(
                point1, point2, Color.Green, Color.LightGreen))
            {
                gr.FillRectangle(brush, rect);
            }

            // Outline the rectangle.
            const int pen_half_width = 2;
            const int pen_width = 2 * pen_half_width;
            using (Brush brush = new LinearGradientBrush(
                point2, point1, Color.Green, Color.LightGreen))
            {
                using (Pen pen = new Pen(brush, pen_width))
                {
                    gr.DrawRectangle(pen,
                        rect.X + pen_half_width,
                        rect.Y + pen_half_width,
                        rect.Width - pen_width,
                        rect.Height - pen_width);
                }
            }
        }

        // Fill an illumination box with an image.
        private void DrawIlluminationBox3(Graphics gr, RectangleF rectf)
        {
            // Make the rectangle a little smaller.
            const int margin = 5;
            rectf = new RectangleF(
                rectf.X + margin, rectf.Y + margin,
                rectf.Width - 2 * margin, rectf.Height - 2 * margin);

            // Fill the rectangle with an image.
            using (Brush brush = new TextureBrush(Properties.Resources.Butterflies))
            {
                gr.FillRectangle(brush, rectf);
            }

            // Outline the rectangle.
            using (Pen pen = new Pen(Color.Blue, 5))
            {
                gr.DrawRectangle(pen, Rectangle.Round(rectf));
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
            this.picWriting.Location = new System.Drawing.Point(2, 2);
            this.picWriting.Name = "picWriting";
            this.picWriting.Size = new System.Drawing.Size(180, 157);
            this.picWriting.TabIndex = 1;
            this.picWriting.TabStop = false;
            this.picWriting.Resize += new System.EventHandler(this.picWriting_Resize);
            this.picWriting.Paint += new System.Windows.Forms.PaintEventHandler(this.picWriting_Paint);
            // 
            // howto_illuminated_writing2_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 161);
            this.Controls.Add(this.picWriting);
            this.Name = "howto_illuminated_writing2_Form1";
            this.Text = "howto_illuminated_writing2";
            ((System.ComponentModel.ISupportInitialize)(this.picWriting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picWriting;
    }
}

