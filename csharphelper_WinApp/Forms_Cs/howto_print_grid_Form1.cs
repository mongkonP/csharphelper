using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Printing;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_print_grid_Form1:Form
  { 


        public howto_print_grid_Form1()
        {
            InitializeComponent();
        }

        private const int HeaderMargin = 5;
        private const int ColMargin = 5;
        private const int RowMargin = 30;

        // Display the print preview.
        private void btnPreview_Click(object sender, EventArgs e)
        {
            ppdGrid.ClientSize = new Size(500, 600);
            ppdGrid.ShowDialog();
        }

        // Draw the grid.
        private void pdocGrid_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Make some sample data.
            string[] headers;
            object[][] values;
            MakeSampleData(out headers, out values);

            // See how wide the columns need to be.
            using (Font header_font =
                new Font("Times New Roman", 18, FontStyle.Bold))
            {
                using (Font body_font =
                    new Font("Times New Roman", 18, FontStyle.Regular))
                {
                    int[] col_wid = FindColumnSizes(e.Graphics, header_font, body_font, headers, values);

                    // Define the column alignments.
                    StringAlignment[] alignments = FindColumnAlignments(values);

                    // Get the total width.
                    int grid_wid = 0;
                    for (int i = 0; i < col_wid.Length; i++)
                    {
                        grid_wid += col_wid[i] + 2 * ColMargin;
                    }

                    // Print the data.
                    Rectangle grid_bounds = new Rectangle(
                        e.MarginBounds.Left, e.MarginBounds.Top, grid_wid, e.MarginBounds.Bottom);
                    PrintGrid(grid_bounds, e.Graphics, col_wid, alignments,
                        header_font, body_font, headers, values);
                }
            }
        }

        // Make some sample data.
        private void MakeSampleData(out string[] headers, out object[][] values)
        {
            headers = new string[] { "Fruit", "Vegetable", "Price" };
            values = new object[][] {
                new object[] {"Apple", "Artichoke", 12.45M},
                new object[] {"Banana", "Bean", 19.95M},
                new object[] {"Cherry", "Corn", 1.23M},
                new object[] {"Date", "Donut", 0.45M},
                new object[] {"Egg", "Eclair", 19.95M},
                new object[] {"Fig", "Fruit cup", 1.23M}
            };
        }

        // Calculate column sizes.
        private int[] FindColumnSizes(Graphics gr, Font header_font, Font body_font, string[] headers, object[][] values)
        {
            int num_rows = values.Length;
            int num_cols = values[0].Length;

            // Check the header widths.
            int[] col_wid = new int[num_cols];
            CheckColWidths(col_wid, gr, header_font, headers);

            // Check the data widths.
            foreach (object[] row in values)
            {
                CheckColWidths(col_wid, gr, body_font, row);
            }

            // Add a margin.
            for (int i = 0; i < num_cols; i++)
            {
                col_wid[i] += 20;
            }

            // Return the result.
            return col_wid;
        }

        // Update the column widths for the values in this array.
        private void CheckColWidths(int[] col_wid, Graphics gr, Font the_font, object[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                SizeF txt_size = gr.MeasureString(values[i].ToString(), the_font);
                if (col_wid[i] < txt_size.Width) col_wid[i] = (int)txt_size.Width;
            }
        }

        // Define the column alignments.
        private StringAlignment[] FindColumnAlignments(object[][] values)
        {
            StringAlignment[] alignments = new StringAlignment[values.Length];
            for (int i = 0; i < values[0].Length; i++)
            {
                if (values[0][i].GetType() == typeof(int) ||
                    values[0][i].GetType() == typeof(float) ||
                    values[0][i].GetType() == typeof(double) ||
                    values[0][i].GetType() == typeof(decimal))
                {
                    alignments[i] = StringAlignment.Far;
                }
                else
                {
                    alignments[i] = StringAlignment.Near;
                }
            }

            return alignments;
        }

        // Print the grid.
        private void PrintGrid(Rectangle grid_bounds, Graphics gr,
            int[] col_wid, StringAlignment[] alignments,
            Font header_font, Font body_font, string[] headers, object[][] values)
        {
            // Print the headers.
            int x = grid_bounds.Left;
            int y = grid_bounds.Top;

            // Fill the header's background.
            Rectangle bg_rect = new Rectangle(
                x, y, grid_bounds.Width, RowMargin + HeaderMargin);
            gr.FillRectangle(Brushes.Blue, bg_rect);

            // Draw the header text.
            using (StringFormat string_format = new StringFormat())
            {
                for (int i = 0; i < headers.Length; i++)
                {
                    RectangleF layout_rect = new
                        RectangleF(x + ColMargin, y, col_wid[i], RowMargin);
                    string_format.Alignment = alignments[i];
                    string_format.LineAlignment = StringAlignment.Near;
                    gr.DrawString(headers[i],
                        header_font, Brushes.White,
                        layout_rect, string_format);
                    x += col_wid[i] + 2 * ColMargin;
                }
            }
            bg_rect.Height -= HeaderMargin;
            y += HeaderMargin;

            // Print the values.
            int max_x = x;
            for (int r = 0; r < values.Length; r++)
            {
                x = grid_bounds.Left;
                y += RowMargin;

                // Fill the row's background.
                bg_rect.Y = y;
                if (r % 2 == 0)
                {
                    gr.FillRectangle(Brushes.LightGreen, bg_rect);
                }
                else
                {
                    gr.FillRectangle(Brushes.LightBlue, bg_rect);
                }

                using (StringFormat string_format = new StringFormat())
                {
                    for (int i = 0; i < values[r].Length; i++)
                    {
                        // Draw the text.
                        RectangleF layout_rect = new
                            RectangleF(x + ColMargin, y, col_wid[i], RowMargin);
                        string_format.Alignment = alignments[i];
                        string_format.LineAlignment = StringAlignment.Near;
                        gr.DrawString(values[r][i].ToString(),
                            body_font, Brushes.Black,
                            layout_rect, string_format);

                        x += col_wid[i] + 2 * ColMargin;
                    }
                }
                gr.DrawLine(Pens.Black, grid_bounds.X, y, max_x, y);
            }

            // Outline the grid.
            grid_bounds = new Rectangle(
                grid_bounds.X, grid_bounds.Y, grid_bounds.Width,
                (values.Length + 1) * RowMargin + HeaderMargin);
            gr.DrawRectangle(Pens.Black, grid_bounds);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_print_grid_Form1));
            this.btnPreview = new System.Windows.Forms.Button();
            this.pdocGrid = new System.Drawing.Printing.PrintDocument();
            this.ppdGrid = new System.Windows.Forms.PrintPreviewDialog();
            this.SuspendLayout();
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(105, 43);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 0;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // pdocGrid
            // 
            this.pdocGrid.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdocGrid_PrintPage);
            // 
            // ppdGrid
            // 
            this.ppdGrid.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppdGrid.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppdGrid.ClientSize = new System.Drawing.Size(400, 300);
            this.ppdGrid.Document = this.pdocGrid;
            this.ppdGrid.Enabled = true;
            this.ppdGrid.Icon = ((System.Drawing.Icon)(resources.GetObject("ppdGrid.Icon")));
            this.ppdGrid.Name = "ppdGrid";
            this.ppdGrid.Visible = false;
            // 
            // howto_print_grid_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 108);
            this.Controls.Add(this.btnPreview);
            this.Name = "howto_print_grid_Form1";
            this.Text = "howto_print_grid";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPreview;
        private System.Drawing.Printing.PrintDocument pdocGrid;
        private System.Windows.Forms.PrintPreviewDialog ppdGrid;
    }
}

