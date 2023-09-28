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
     public partial class howto_print_grid_data_Form1:Form
  { 


        public howto_print_grid_data_Form1()
        {
            InitializeComponent();
        }

        // The sample data.
        private string[] Headers = {"Name", "Street", "City", "State", "Zip"};
        private string[,] Data =
            {
                {"Alice Archer", "1276 Ash Ave", "Ann Arbor", "MI", "12893"},
                {"Bill Blaze", "26157 Beach Blvd", "Boron", "CA", "23617"},
                {"Cindy Carruthers", "352 Cherry Ct", "Chicago", "IL", "35271"},
                {"Dean Dent", "4526 Deerfield Dr", "Denver", "CO", "47848"},
            };

        // Display a print preview.
        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            ppdGrid.ShowDialog();
        }

        // Print the document's page.
        // Note that this version doesn't handle multiple pages.
        private void pdocGrid_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Use this font.
            using (Font header_font = new Font("Times New Roman", 16, FontStyle.Bold))
            {
                using (Font body_font = new Font("Times New Roman", 12))
                {
                    // We'll skip this much space between rows.
                    int line_spacing = 20;

                    // See how wide the columns must be.
                    int[] column_widths = FindColumnWidths(
                        e.Graphics, header_font, body_font, Headers, Data);

                    // Start at the left margin.
                    int x = e.MarginBounds.Left;

                    // Print by columns.
                    for (int col = 0; col < Headers.Length; col++)
                    {
                        // Print the header.
                        int y = e.MarginBounds.Top;
                        e.Graphics.DrawString(Headers[col],
                            header_font, Brushes.Blue, x, y);
                        y += (int)(line_spacing * 1.5);

                        // Print the items in the column.
                        for (int row = 0; row <= Data.GetUpperBound(0); row++)
                        {
                            e.Graphics.DrawString(Data[row, col],
                                body_font, Brushes.Black, x, y);
                            y += line_spacing;
                        }

                        // Move to the next column.
                        x += column_widths[col];
                    } // Looping over columns
                } // using body_font
            } // using header_font

            //DrawGrid(e, y)
            e.HasMorePages = false;
        }

        // Figure out how wide each column should be.
        private int[] FindColumnWidths(Graphics gr, Font header_font, Font body_font, string[] headers, string[,] values)
        {
            // Make room for the widths.
            int[] widths = new int[headers.Length];

            // Find the width for each column.
            for (int col = 0; col < widths.Length; col++)
            {
                // Check the column header.
                widths[col] = (int)gr.MeasureString(headers[col], header_font).Width;

                // Check the items.
                for (int row = 0; row <= values.GetUpperBound(0); row++)
                {
                    int value_width = (int)gr.MeasureString(values[row, col], body_font).Width;
                    if (widths[col] < value_width) widths[col] = value_width;
                }

                // Add some extra space.
                widths[col] += 20;
            }

            return widths;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_print_grid_data_Form1));
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.pdocGrid = new System.Drawing.Printing.PrintDocument();
            this.ppdGrid = new System.Windows.Forms.PrintPreviewDialog();
            this.SuspendLayout();
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrintPreview.Location = new System.Drawing.Point(91, 51);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(102, 23);
            this.btnPrintPreview.TabIndex = 0;
            this.btnPrintPreview.Text = "Print Preview";
            this.btnPrintPreview.UseVisualStyleBackColor = true;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
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
            // howto_print_grid_data_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 124);
            this.Controls.Add(this.btnPrintPreview);
            this.Name = "howto_print_grid_data_Form1";
            this.Text = "howto_print_grid_data";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrintPreview;
        internal System.Drawing.Printing.PrintDocument pdocGrid;
        internal System.Windows.Forms.PrintPreviewDialog ppdGrid;
    }
}

