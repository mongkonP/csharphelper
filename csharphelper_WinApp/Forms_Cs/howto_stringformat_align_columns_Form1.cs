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
     public partial class howto_stringformat_align_columns_Form1:Form
  { 


        public howto_stringformat_align_columns_Form1()
        {
            InitializeComponent();
        }

        // Draw some text aligned in columns.
        private void howto_stringformat_align_columns_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            string headings = "Title\tPrice\t# Pages\tYear";
            string[] lines =
            {
                "WPF 3d\t$34.95\t430\t2018",
                "The C# Helper Top 100\t$24.95\t380\t2017",
                "Interview Puzzles Dissected\t$15.95\t300\t2016",
                "C# 24-Hour Trainer, Second Edition\t$45.00\t600\t2015",
                "Beginning Software Engineering\t$45.00\t480\t2015",
                "Essential Algorithms\t$60.00\t624\t2013",
                "Beginning Database Design Solutions\t$44.99\t552\t2008",
                "Powers of Two\t$2.04\t8\t16",
            };

            // Prepare a StringFormat to use the tabs.
            using (StringFormat string_format = new StringFormat())
            {
                // Define the columns' X coordinates.
                float[] xpos = { 10, 310, 400, 475 };

                // Define the column alignments.
                StringAlignment[] alignments =
                {
                    StringAlignment.Near,
                    StringAlignment.Far,
                    StringAlignment.Far,
                    StringAlignment.Far,
                };

                // Draw the headings.
                float margin = 10;
                float y = 10;
                using (Font font = new Font("Times New Roman", 13, FontStyle.Bold))
                {
                    string[] strings = headings.Split('\t');
                    for (int i = 0; i < strings.Length; i++)
                    {
                        string_format.Alignment = alignments[i];
                        e.Graphics.DrawString(strings[i], font, Brushes.Blue,
                            xpos[i], y, string_format);
                    }
                }

                // Draw a horizontal line.
                y += 1.4f * Font.Height;
                float width = xpos[xpos.Length - 1] + 5;
                e.Graphics.DrawLine(Pens.Blue, margin, y, width, y);
                y += 5;

                // Draw the book entries.
                using (Font font = new Font("Times New Roman", 11))
                {
                    foreach (string line in lines)
                    {
                        string[] strings = line.Split('\t');
                        for (int i = 0; i < strings.Length; i++)
                        {
                            string_format.Alignment = alignments[i];
                            e.Graphics.DrawString(strings[i], font, Brushes.Black,
                                xpos[i], y, string_format);
                        }
                        y += 1.2f * this.Font.Height;
                    }
                }
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
            this.SuspendLayout();
            // 
            // howto_stringformat_align_columns_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 171);
            this.Name = "howto_stringformat_align_columns_Form1";
            this.Text = "howto_stringformat_align_columns";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_stringformat_align_columns_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

