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
     public partial class howto_ransom_note_text_Form1:Form
  { 


        public howto_ransom_note_text_Form1()
        {
            InitializeComponent();
        }

        // Font names we may use.
        private string[] FontNames =
        {
            "Times New Roman",
            "Courier New",
            "Comic Sans MS",
            "Arial",
            "News Gothic MT",
            "AvantGarde Md BT",
            "Benguiat Bk BT",
            "Bookman Old Style",
            "Bremen Bd BT",
            "Century Gothic",
            "Dauphin",
            "Curlz MT",
            "GoudyHandtooled BT",
        };

        // Colors we may use.
        private Brush[] FontBrushes =
        {
            Brushes.Red,
            Brushes.Green,
            Brushes.Blue,
            Brushes.Orange,
            Brushes.Brown,
            Brushes.Magenta,
            Brushes.Purple,
            Brushes.BurlyWood,
            Brushes.HotPink,
        };

        // The random number generator we will use.
        private Random Rand = new Random();

        // Display the initial text.
        private void howto_ransom_note_text_Form1_Load(object sender, EventArgs e)
        {
            DrawText();
        }

        // Draw the text.
        private void txtText_TextChanged(object sender, EventArgs e)
        {
            DrawText();
        }

        // Draw the text in the PictureBox.
        private void DrawText()
        {
            if (picText.Image != null) picText.Image.Dispose();
            Bitmap bm = new Bitmap(picText.Width, picText.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.TextRenderingHint = TextRenderingHint.AntiAlias;
                gr.PageUnit = GraphicsUnit.Pixel;

                float x = 0;
                float y = 0;
                float max_y = 0;
                foreach (char ch in txtText.Text)
                {
                    DrawCharacter(gr, bm.Width - 10, ref x, ref y, ref max_y, ch);
                }
            }

            // Display the result.
            picText.Image = bm;
        }

        // Draw a character in a random font.
        private void DrawCharacter(Graphics gr, int right_margin, ref float x, ref float y, ref float max_y, char ch)
        {
            const float min_size = 25;
            const float max_size = 35;

            // Pick the random font characteristics.
            string font_name = FontNames[Rand.Next(0, FontNames.Length)];
            float font_size = (float)(min_size + Rand.NextDouble() * (max_size - min_size));
            FontStyle font_style = FontStyle.Regular;
            if (Rand.Next(0, 2) == 1) font_style |= FontStyle.Bold;
            if (Rand.Next(0, 2) == 1) font_style |= FontStyle.Italic;
            //if (Rand.Next(0,2) == 1) font_style |= FontStyle.Strikeout;
            //if (Rand.Next(0,2) == 1) font_style |= FontStyle.Underline;
            Brush brush = FontBrushes[Rand.Next(0, FontBrushes.Length)];

            // Draw the character.
            using (Font font = new Font(font_name, font_size, font_style))
            {
                // Measure the character.
                string text = "M" + ch + "M";
                SizeF size = gr.MeasureString(text, font);
                SizeF x_size = gr.MeasureString("MM", font);
                size.Width = size.Width - x_size.Width + 5;

                // See if we have room.
                if (x + size.Width * 0.75f > right_margin)
                {
                    // Start a new line.
                    x = 0;
                    y = max_y;
                }

                // Draw the character.
                gr.DrawString(ch.ToString(), font, brush, x, y);

                // Set the position for the next character.
                x += size.Width * 0.75f;
                if (max_y < y + size.Height) max_y = y + size.Height;
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
            this.txtText = new System.Windows.Forms.TextBox();
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
            this.picText.Location = new System.Drawing.Point(12, 38);
            this.picText.Name = "picText";
            this.picText.Size = new System.Drawing.Size(310, 261);
            this.picText.TabIndex = 3;
            this.picText.TabStop = false;
            // 
            // txtText
            // 
            this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtText.Location = new System.Drawing.Point(12, 12);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(310, 20);
            this.txtText.TabIndex = 2;
            this.txtText.Text = "When in worry or in doubt, run in circles scream and shout";
            this.txtText.TextChanged += new System.EventHandler(this.txtText_TextChanged);
            // 
            // howto_ransom_note_text_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 311);
            this.Controls.Add(this.picText);
            this.Controls.Add(this.txtText);
            this.Name = "howto_ransom_note_text_Form1";
            this.Text = "howto_ransom_note_text";
            this.Load += new System.EventHandler(this.howto_ransom_note_text_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picText)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picText;
        private System.Windows.Forms.TextBox txtText;
    }
}

