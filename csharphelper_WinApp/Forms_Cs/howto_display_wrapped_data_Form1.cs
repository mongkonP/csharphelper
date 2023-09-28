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
     public partial class howto_display_wrapped_data_Form1:Form
  { 


        public howto_display_wrapped_data_Form1()
        {
            InitializeComponent();
        }

        // The values.
        private string[][] Values =
        {
            new string[] { "WPF 3d, Three-Dimensional Graphics with WPF and C#", "http://www.csharphelper.com/wpf3d.html", "426 pages", "2/2018", "978-1983905964" },
            new string[] { "The C# Helper Top 100", "http://www.csharphelper.com/top100.htm", "382 pages", "9/2017", "978-1546886716" },
            new string[] { "Interview Puzzles Dissected, Solving and Understanding Interview Puzzles", "http://www.csharphelper.com/puzzles.htm", "300 pages", "11/2016", "978-1539504887" },
            new string[] { "C# 24-Hour Trainer, 2nd Edition", "http://www.wrox.com/WileyCDA/WroxTitle/C-24-Hour-Trainer-2nd-Edition.productCd-1119065666.html", "600 pages", "11/2015", "978-1119065661" },
            new string[] { "Beginning Software Engineering", "http://www.wrox.com/WileyCDA/WroxTitle/Beginning-Software-Engineering.productCd-1118969146.html", "480 pages", "3/2015", "978-1118969144" },
            new string[] { "C# 5.0 Programmer's Reference", "http://www.wrox.com/WileyCDA/WroxTitle/C-5-0-Programmer-s-Reference.productCd-1118847288.html", "960 pages", "4/2014", "978-1118847282" },
            new string[] { "Essential Algorithms: A Practical Approach to Computer Algorithms", "http://www.csharphelper.com/algorithms.html", "624 pages", "8/2013", "978-1118612101" },
        };

        // The column sizes and alignments.
        private int[] ColWidths = { 200, 200, 90, 70, 130};
        private StringAlignment[] VertAlignments =
        {
            StringAlignment.Center,
            StringAlignment.Center,
            StringAlignment.Near,
            StringAlignment.Near,
            StringAlignment.Near,
        };
        private StringAlignment[] HorzAlignments =
        {
            StringAlignment.Near,
            StringAlignment.Near,
            StringAlignment.Far,
            StringAlignment.Center,
            StringAlignment.Near,
        };

        // Display the data aligned in columns.
        private void picColumns_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            using (StringFormat sf = new StringFormat())
            {
                using (Font font = new Font("Times New Roman", 12))
                {
                    const int margin = 4;
                    int y = margin;

                    // Display the rows.
                    foreach (string[] row in Values)
                    {
                        // Measure the row's entry heights.
                        int num_cols = row.Length;
                        int max_height = 0;
                        for (int col_num = 0; col_num < num_cols; col_num++)
                        {
                            SizeF col_size = e.Graphics.MeasureString(
                                row[col_num], font, ColWidths[col_num] - 2 * margin);
                            int new_height = (int)Math.Ceiling(col_size.Height);
                            if (max_height < new_height)
                                max_height = new_height;
                        }
                        max_height += 2 * margin;

                        // Draw the row's entries.
                        int x = margin;
                        for (int col_num = 0; col_num < num_cols; col_num++)
                        {
                            Rectangle box_rect = new Rectangle(x, y,
                                ColWidths[col_num], max_height);
                            Rectangle text_rect = box_rect;
                            text_rect.Inflate(-margin, -margin);

                            sf.Alignment = HorzAlignments[col_num];
                            sf.LineAlignment = VertAlignments[col_num];
                            e.Graphics.DrawString(row[col_num], font,
                                Brushes.Black, text_rect, sf);

                            e.Graphics.DrawRectangle(Pens.Blue, box_rect);

                            x += ColWidths[col_num];
                        }

                        y += max_height;
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
            this.picColumns = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // picColumns
            // 
            this.picColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picColumns.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picColumns.Location = new System.Drawing.Point(4, 4);
            this.picColumns.Name = "picColumns";
            this.picColumns.Size = new System.Drawing.Size(701, 343);
            this.picColumns.TabIndex = 2;
            this.picColumns.TabStop = false;
            this.picColumns.Paint += new System.Windows.Forms.PaintEventHandler(this.picColumns_Paint);
            // 
            // howto_display_wrapped_data_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 351);
            this.Controls.Add(this.picColumns);
            this.Name = "howto_display_wrapped_data_Form1";
            this.Text = "howto_display_wrapped_data";
            ((System.ComponentModel.ISupportInitialize)(this.picColumns)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picColumns;
    }
}

