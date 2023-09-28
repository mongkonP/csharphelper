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
     public partial class howto_justify_line_of_text_Form1:Form
  { 


        public howto_justify_line_of_text_Form1()
        {
            InitializeComponent();
        }

        // The text to display.
        private const string MessageText =
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";

        // Draw justified text on the PictureBox.
        private void picText_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(picText.BackColor);
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            // Make a rectangle to draw in.
            RectangleF rect = new RectangleF(
                5, 5,
                picText.ClientSize.Width - 10,
                picText.ClientSize.Height - 10);

            // Draw the text.
            using (Font font = new Font("Times New Roman", 10))
            {
                DrawJustifiedLine(e.Graphics, rect,
                    font, Brushes.Blue, MessageText);
            }

            // Show the text drawing area.
            e.Graphics.DrawRectangle(Pens.Silver, Rectangle.Round(rect));
        }
        private void picText_Resize(object sender, EventArgs e)
        {
            picText.Refresh();
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
            this.picText.Size = new System.Drawing.Size(360, 29);
            this.picText.TabIndex = 1;
            this.picText.TabStop = false;
            this.picText.Resize += new System.EventHandler(this.picText_Resize);
            this.picText.Paint += new System.Windows.Forms.PaintEventHandler(this.picText_Paint);
            // 
            // howto_justify_line_of_text_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 53);
            this.Controls.Add(this.picText);
            this.Name = "howto_justify_line_of_text_Form1";
            this.Text = "howto_justify_line_of_text";
            ((System.ComponentModel.ISupportInitialize)(this.picText)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picText;
    }
}

