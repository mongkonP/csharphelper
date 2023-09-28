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
     public partial class howto_how_much_text_fits_Form1:Form
  { 


        public howto_how_much_text_fits_Form1()
        {
            InitializeComponent();
        }

        private void howto_how_much_text_fits_Form1_Load(object sender, EventArgs e)
        {
            DrawText();
        }
        private void howto_how_much_text_fits_Form1_Resize(object sender, EventArgs e)
        {
            DrawText();
        }

        // Draw as much text as possible in picText1.
        // Draw the remainder in picText2.
        private void DrawText()
        {
            string text = "    This is a fairly long piece of text that won't necessarily fit in the left PictureBox." +
                "\n    When you change the form's height, that changes the amount of text that fits in the left PictureBox. " +
                "The program draws as much text as will fit in the left PictureBox and then draws the remainder of the text in the right PictureBox.";

            // Make a font for printing.
            using (Font font = new Font("Times New Roman", 12))
            {
                // Make a StringFormat to align text normally.
                using (StringFormat string_format = new StringFormat())
                {
                    // Stop drawing at a word boundary.
                    string_format.Trimming = StringTrimming.Word;

                    // Make a Bitmap for picText1.
                    Bitmap bm1 = new Bitmap(
                        picText1.ClientSize.Width,
                        picText1.ClientSize.Height);
                    using (Graphics gr = Graphics.FromImage(bm1))
                    {
                        gr.Clear(picText1.BackColor);

                        // Make a Rectangle representing where
                        // the text should be drawn.
                        const int margin = 5;
                        Rectangle rect = new Rectangle(margin, margin,
                            picText1.ClientSize.Width - 2 * margin,
                            picText1.ClientSize.Height - 2 * margin);
                        gr.DrawRectangle(Pens.LightGreen, rect);

                        // See how much of the text will fit in picText1.
                        int chars_fitted, lines_filled;
                        SizeF avail_size = new SizeF(rect.Width, rect.Height);
                        gr.MeasureString(text, font,
                            avail_size, string_format,
                            out chars_fitted, out lines_filled);

                        // Draw the text that will fit.
                        string text_that_fits = text.Substring(0, chars_fitted);
                        gr.DrawString(text_that_fits, font,
                            Brushes.Black, rect, string_format);

                        // Display the result.
                        picText1.Image = bm1;

                        // Remove the printed text from the total text.
                        text = text.Substring(chars_fitted);
                    } // End drawing on picText1

                    // Draw the remaining text on picText2.
                    // Make a Bitmap for picText2.
                    Bitmap bm2 = new Bitmap(
                        picText2.ClientSize.Width,
                        picText2.ClientSize.Height);
                    using (Graphics gr = Graphics.FromImage(bm2))
                    {
                        gr.Clear(picText2.BackColor);

                        // Make a Rectangle representing where
                        // the text should be drawn.
                        const int margin = 5;
                        Rectangle rect = new Rectangle(margin, margin,
                            picText2.ClientSize.Width - 2 * margin,
                            picText2.ClientSize.Height - 2 * margin);
                        gr.DrawRectangle(Pens.LightGreen, rect);

                        // Draw the text.
                        gr.DrawString(text, font,
                            Brushes.Black, rect, string_format);
                    } // End drawing on picText2

                    // Display the result.
                    picText2.Image = bm2;
                } // End using string_format
            } // End using font
        } // End DrawText
    

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
            this.picText1 = new System.Windows.Forms.PictureBox();
            this.picText2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picText1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picText2)).BeginInit();
            this.SuspendLayout();
            // 
            // picText1
            // 
            this.picText1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.picText1.BackColor = System.Drawing.Color.White;
            this.picText1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picText1.Location = new System.Drawing.Point(12, 12);
            this.picText1.Name = "picText1";
            this.picText1.Size = new System.Drawing.Size(207, 162);
            this.picText1.TabIndex = 4;
            this.picText1.TabStop = false;
            // 
            // picText2
            // 
            this.picText2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picText2.BackColor = System.Drawing.Color.White;
            this.picText2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picText2.Location = new System.Drawing.Point(225, 12);
            this.picText2.Name = "picText2";
            this.picText2.Size = new System.Drawing.Size(181, 162);
            this.picText2.TabIndex = 3;
            this.picText2.TabStop = false;
            // 
            // howto_how_much_text_fits_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 186);
            this.Controls.Add(this.picText1);
            this.Controls.Add(this.picText2);
            this.Name = "howto_how_much_text_fits_Form1";
            this.Text = "howto_how_much_text_fits";
            this.Load += new System.EventHandler(this.howto_how_much_text_fits_Form1_Load);
            this.Resize += new System.EventHandler(this.howto_how_much_text_fits_Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picText1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picText2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picText1;
        private System.Windows.Forms.PictureBox picText2;
    }
}

