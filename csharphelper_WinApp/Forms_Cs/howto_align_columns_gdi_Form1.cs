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
     public partial class howto_align_columns_gdi_Form1:Form
  { 


        public howto_align_columns_gdi_Form1()
        {
            InitializeComponent();
        }

        // The values.
        private string[][] Values =
            {
                new string[] { "The C# Helper Top 100", "http://www.csharphelper.com/top100.htm", "380", "2017", "9/4/2017" },
                new string[] { "Interview Puzzles Dissected", "http://www.csharphelper.com/puzzles.htm", "300", "2016", "11/10/2016" },
                new string[] { "C# 24-Hour Trainer", "http://www.csharphelper.com/24hour.html", "600", "2015", "10/10/2015" },
                new string[] { "Beginning Software Engineering", "http://tinyurl.com/pz7bavo", "480", "2015", "3/10/2015" },
                new string[] { "C# 5.0 Programmer's Reference", "http://tinyurl.com/qzcefsp", "960", "2014", "4/15/2014" },
                new string[] { "Essential Algorithms", "http://www.csharphelper.com/algorithms.html", "624", "2013", "8/12/2013" },
                new string[] { "MCSD Certification Toolkit (C#)", "http://www.vb-helper.com/db_design.htm", "648", "2013", "5/21/2013" },

                new string[] { "Bogus Book", "http://www.noplace.com/bogus.htm", "100", "6", "1/09/1998" },
                new string[] { "Fakey", "http://www.skatepark.com/fakey.htm", "9", "700", "1/08/1998" },
            };

        // The column alignments.
        private StringAlignment[] VertAlignments =
        {
            StringAlignment.Center,
            StringAlignment.Center,
            StringAlignment.Center,
            StringAlignment.Center,
            StringAlignment.Center,
        };
        private StringAlignment[] HorzAlignments =
        {
            StringAlignment.Near,
            StringAlignment.Near,
            StringAlignment.Far,
            StringAlignment.Far,
            StringAlignment.Far,
        };

        // Display the data aligned in columns.
        private void picColumns_Paint(object sender, PaintEventArgs e)
        {
            using (Font font = new Font("Times New Roman", 12))
            {
                // Get the row and column sizes.
                float row_height;
                float[] col_widths;
                GetRowColumnSizes(e.Graphics, font, Values, out row_height, out col_widths);

                // Add column margins.
                const float margin = 10;
                for (int i = 0; i < col_widths.Length; i++) col_widths[i] += margin;

                // Draw.
                e.Graphics.Clear(Color.White);
                e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                DrawTextRowsColumns(e.Graphics, font, Brushes.Black, Pens.Blue,
                    margin / 2, margin / 2, row_height, col_widths,
                    VertAlignments, HorzAlignments, Values, true);
            }
        }

        // Return the items' sizes.
        private void GetRowColumnSizes(Graphics gr, Font font, string[][] values, out float max_height, out float[] col_widths)
        {
            // Make room for the column sizes.
            int num_cols = values[0].Length;
            col_widths = new float[num_cols];

            // Examine each row.
            max_height = 0;
            foreach (string[] row in values)
            {
                // Measure the row's columns.
                for (int col_num = 0; col_num < num_cols; col_num++)
                {
                    SizeF col_size = gr.MeasureString(row[col_num], font);
                    if (col_widths[col_num] < col_size.Width)
                        col_widths[col_num] = col_size.Width;
                    if (max_height < col_size.Height)
                        max_height = col_size.Height;
                }
            }
        }

        // Draw the items in columns.
        private void DrawTextRowsColumns(Graphics gr, Font font, Brush brush, Pen box_pen,
            float x0, float y0, float row_height, float[] col_widths,
            StringAlignment[] vert_alignments, StringAlignment[] horz_alignments,
            string[][] values, bool draw_box)
        {
            // Create a rectangle in which to draw.
            RectangleF rect = new RectangleF();
            rect.Height = row_height;

            using (StringFormat sf = new StringFormat())
            {
                foreach (string[] row in values)
                {
                    float x = x0;
                    for (int col_num = 0; col_num < row.Length; col_num++)
                    {
                        // Prepare the StringFormat and drawing rectangle.
                        sf.Alignment = horz_alignments[col_num];
                        sf.LineAlignment = vert_alignments[col_num];
                        rect.X = x;
                        rect.Y = y0;
                        rect.Width = col_widths[col_num];

                        // Draw.
                        gr.DrawString(row[col_num], font, brush, rect, sf);

                        // Draw the box if desired.
                        if (draw_box) gr.DrawRectangle(box_pen,
                            rect.X, rect.Y, rect.Width, rect.Height);

                        // Move to the next column.
                        x += col_widths[col_num];
                    }

                    // Move to the next line.
                    y0 += row_height;
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
            this.picColumns.Size = new System.Drawing.Size(746, 198);
            this.picColumns.TabIndex = 1;
            this.picColumns.TabStop = false;
            this.picColumns.Paint += new System.Windows.Forms.PaintEventHandler(this.picColumns_Paint);
            // 
            // howto_align_columns_gdi_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 206);
            this.Controls.Add(this.picColumns);
            this.Name = "howto_align_columns_gdi_Form1";
            this.Text = "howto_align_columns_gdi";
            ((System.ComponentModel.ISupportInitialize)(this.picColumns)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picColumns;
    }
}

