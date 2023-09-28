// #define DRAW_BG

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
     public partial class howto_print_value_grid_Form1:Form
  { 


        public howto_print_value_grid_Form1()
        {
            InitializeComponent();
        }

        // Display the print preview dialog.
        private void btnPreview_Click(object sender, EventArgs e)
        {
            ppdInvoice.ShowDialog();
        }

        // Generate the print out.
        private void pdocItems_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            const int inch = 100;       // 100 print units per inch.
            RectangleF bounds = new RectangleF(
                e.MarginBounds.X,
                e.MarginBounds.Y,
                4 * inch, 2 * inch);
            float header_hgt = 50;
            float margin = 0.05f * inch;
            string[] headers = { "Item", "Price Each", "Quantity", "Total" };
            string[,] values =
            {
                {"Pencils, dozen", "$1.24", "4", "$4.96"},
                {"Paper, ream", "$3.75", "3", "$11.25"},
                {"Cookies, box", "$2.17", "12", "$26.04"},
                {"Notebook", "$1.95", "2", "$3.90"},
                {"Pencil sharpener", "$12.95", "1", "$12.95"},
                {"Paper clips, 100", "$0.75", "1", "$0.75"},
            };
            StringAlignment[] header_alignments = 
            {
                StringAlignment.Center,
                StringAlignment.Far,
                StringAlignment.Far,
                StringAlignment.Far,
            };
            StringAlignment[] value_alignments = 
            {
                StringAlignment.Near,
                StringAlignment.Far,
                StringAlignment.Far,
                StringAlignment.Far,
            };
            StringAlignment[] line_alignments = 
            {
                StringAlignment.Center,
                StringAlignment.Center,
                StringAlignment.Center,
                StringAlignment.Center,
            };
            using (Font header_font = new Font("Times New Roman", 12, FontStyle.Bold))
            {
                using (Font roman10 = new Font("Times New Roman", 10, FontStyle.Regular))
                {
                    using (Font courier8 = new Font("Courier New", 8, FontStyle.Regular))
                    {
                        Font[] value_fonts = { roman10, courier8, courier8, courier8 };
                        DrawValueGrid(e.Graphics, bounds, header_hgt, margin,
                            headers, values,
                            header_alignments, line_alignments,
                            value_alignments, line_alignments,
                            header_font, value_fonts,
                            Brushes.Blue, Brushes.Black,
                            Pens.Green, Pens.Blue, Pens.Red);
                    }
                }
            }

            e.HasMorePages = false;
        }

        // Draw a grid containing the indicated values.
        private void DrawValueGrid(Graphics gr, RectangleF bounds,
            float header_hgt, float margin,
            string[] headers, string[,] values,
            StringAlignment[] header_alignments, StringAlignment[] header_line_alignments,
            StringAlignment[] column_alignments, StringAlignment[] column_line_alignments,
            Font header_font, Font[] value_fonts,
            Brush header_brush, Brush value_brush,
            Pen row_line_pen, Pen column_line_pen, Pen box_pen)
        {
            // See how many rows and columns of data there are.
            int num_rows = values.GetUpperBound(0);
            int num_cols = values.GetUpperBound(1);

            // Calculate the row height and column width.
            float row_hgt = (bounds.Height - header_hgt) / (float)num_rows;
            float col_wid = bounds.Width / num_cols;

            // Make a StringFormat to align text.
            using (StringFormat sf = new StringFormat())
            {
                float y = bounds.Y;
                float x = bounds.X;

                // Draw the headers.
                if (header_hgt > 0)
                {
                    for (int col = 0; col < num_cols; col++)
                    {
                        // Get the string's layout rectangle.
                        sf.Alignment = header_alignments[col];
                        sf.LineAlignment = header_line_alignments[col];
                        RectangleF rect = new RectangleF(
                            x + margin, y + margin,
                            col_wid - 2 * margin,
                            header_hgt - 2 * margin);

#if DRAW_BG
                        // For debugging purposes.
                        gr.FillRectangle(Brushes.Silver, rect);
#endif

                        // Draw the string.
                        gr.DrawString(headers[col], header_font, header_brush, rect, sf);

                        x += col_wid;
                    }

                    y += header_hgt;
                }

                // Draw the values.
                for (int row = 0; row < num_rows; row++)
                {
                    x = bounds.X;
                    for (int col = 0; col < num_cols; col++)
                    {
                        // Get the string's layout rectangle.
                        sf.Alignment = column_alignments[col];
                        sf.LineAlignment = column_line_alignments[col];
                        RectangleF rect = new RectangleF(
                            x + margin, y + margin,
                            col_wid - 2 * margin,
                            row_hgt - 2 * margin);

#if DRAW_BG
                        // For debugging purposes.
                        gr.FillRectangle(Brushes.Silver, rect);
#endif

                        // Draw the string.
                        gr.DrawString(values[row, col], value_fonts[col], value_brush, rect, sf);
                        x += col_wid;
                    }
                    y += row_hgt;
                }

                // Draw row lines.
                if (row_line_pen.Color.A > 0)
                {
                    y = bounds.Y;
                    if (header_hgt > 0)
                    {
                        y += header_hgt;
                        gr.DrawLine(row_line_pen, bounds.Left, y, bounds.Right, y);
                    }

                    for (int r = 1; r < num_rows; r++)
                    {
                        y += row_hgt;
                        gr.DrawLine(row_line_pen, bounds.Left, y, bounds.Right, y);
                    }
                }

                // Draw column lines.
                if (column_line_pen.Color.A > 0)
                {
                    x = bounds.X;
                    for (int c = 1; c < num_cols; c++)
                    {
                        x += col_wid;
                        gr.DrawLine(column_line_pen, x, bounds.Top, x, bounds.Bottom);
                    }
                }

                // Draw a box around it all if desired.
                if (box_pen.Color.A > 0)
                    gr.DrawRectangle(box_pen, Rectangle.Round(bounds));
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_print_value_grid_Form1));
            this.pdocItems = new System.Drawing.Printing.PrintDocument();
            this.btnPreview = new System.Windows.Forms.Button();
            this.ppdInvoice = new System.Windows.Forms.PrintPreviewDialog();
            this.SuspendLayout();
            // 
            // pdocItems
            // 
            this.pdocItems.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdocItems_PrintPage);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPreview.Location = new System.Drawing.Point(125, 44);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 1;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // ppdInvoice
            // 
            this.ppdInvoice.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppdInvoice.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppdInvoice.ClientSize = new System.Drawing.Size(400, 300);
            this.ppdInvoice.Document = this.pdocItems;
            this.ppdInvoice.Enabled = true;
            this.ppdInvoice.Icon = ((System.Drawing.Icon)(resources.GetObject("ppdInvoice.Icon")));
            this.ppdInvoice.Name = "ppdInvoice";
            this.ppdInvoice.Visible = false;
            // 
            // howto_print_value_grid_Form1
            // 
            this.AcceptButton = this.btnPreview;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 111);
            this.Controls.Add(this.btnPreview);
            this.Name = "howto_print_value_grid_Form1";
            this.Text = "howto_print_value_grid";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Drawing.Printing.PrintDocument pdocItems;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.PrintPreviewDialog ppdInvoice;
    }
}

