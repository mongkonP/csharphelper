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
     public partial class howto_listbox_ownerdraw_columns_Form1:Form
  { 


        public howto_listbox_ownerdraw_columns_Form1()
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

        // Row and column sizes.
        private float RowHeight, RowWidth;
        private float[] ColWidths = null;

        // Make the ListBox owner-drawn and give it data.
        private void howto_listbox_ownerdraw_columns_Form1_Load(object sender, EventArgs e)
        {
            lstBooks.DrawMode = DrawMode.OwnerDrawVariable;
            lstBooks.Items.AddRange(Values);
        }

        private const float RowMargin = 10;
        private const float ColumnMargin = 10;

        // Return the desired size of an item.
        private void lstBooks_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            // Measure the data if we haven't already done so.
            if (ColWidths == null)
            {
                // Get the row and column sizes.
                GetRowColumnSizes(e.Graphics, lstBooks.Font, Values, out RowHeight, out ColWidths);

                // Add margins.
                for (int i = 0; i < ColWidths.Length; i++) ColWidths[i] += ColumnMargin;
                RowHeight += RowMargin;

                // Get the total row width.
                RowWidth = ColWidths.Sum();
            }

            // Set the desired size.
            e.ItemHeight = (int)RowHeight;
            e.ItemWidth = (int)RowWidth;
        }

        // Draw an item.
        private void lstBooks_DrawItem(object sender, DrawItemEventArgs e)
        {
            string[] values = (string[])lstBooks.Items[e.Index];
            e.DrawBackground();
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                DrawRow(e.Graphics, lstBooks.Font, SystemBrushes.HighlightText, null,
                    e.Bounds.X, e.Bounds.Y, RowHeight, ColWidths,
                    VertAlignments, HorzAlignments, values, false);
            }
            else
            {
                DrawRow(e.Graphics, lstBooks.Font, Brushes.Black, null,
                    e.Bounds.X, e.Bounds.Y, RowHeight, ColWidths,
                    VertAlignments, HorzAlignments, values, false);
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
        private void DrawRow(Graphics gr, Font font, Brush brush, Pen box_pen,
            float x0, float y0, float row_height, float[] col_widths,
            StringAlignment[] vert_alignments, StringAlignment[] horz_alignments,
            string[] values, bool draw_box)
        {
            // Create a rectangle in which to draw.
            RectangleF rect = new RectangleF();
            rect.Height = row_height;

            using (StringFormat sf = new StringFormat())
            {
                float x = x0;
                for (int col_num = 0; col_num < values.Length; col_num++)
                {
                    // Prepare the StringFormat and drawing rectangle.
                    sf.Alignment = horz_alignments[col_num];
                    sf.LineAlignment = vert_alignments[col_num];
                    rect.X = x;
                    rect.Y = y0;
                    rect.Width = col_widths[col_num];

                    // Draw.
                    gr.DrawString(values[col_num], font, brush, rect, sf);

                    // Draw the box if desired.
                    if (draw_box) gr.DrawRectangle(box_pen,
                        rect.X, rect.Y, rect.Width, rect.Height);

                    // Move to the next column.
                    x += col_widths[col_num];
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
            this.lstBooks = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstBooks
            // 
            this.lstBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBooks.FormattingEnabled = true;
            this.lstBooks.IntegralHeight = false;
            this.lstBooks.Location = new System.Drawing.Point(4, 4);
            this.lstBooks.Name = "lstBooks";
            this.lstBooks.Size = new System.Drawing.Size(579, 214);
            this.lstBooks.TabIndex = 1;
            this.lstBooks.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstBooks_DrawItem);
            this.lstBooks.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lstBooks_MeasureItem);
            // 
            // howto_listbox_ownerdraw_columns_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 222);
            this.Controls.Add(this.lstBooks);
            this.Name = "howto_listbox_ownerdraw_columns_Form1";
            this.Text = "howto_listbox_ownerdraw_columns";
            this.Load += new System.EventHandler(this.howto_listbox_ownerdraw_columns_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstBooks;
    }
}

