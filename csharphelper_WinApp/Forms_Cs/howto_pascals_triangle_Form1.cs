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
     public partial class howto_pascals_triangle_Form1:Form
  { 


        public howto_pascals_triangle_Form1()
        {
            InitializeComponent();
        }

        // Display the print preview.
        private void btnGo_Click(object sender, EventArgs e)
        {
            // pdocTriangle.PrinterSettings.PrinterName = "Dell Photo AIO Printer 926";

            pdocTriangle.DefaultPageSettings.Margins =
                new System.Drawing.Printing.Margins(50, 50, 50, 50);
            pdocTriangle.DefaultPageSettings.Landscape = true;
            ppdTriangle.ShowDialog();
        }

        // Draw the triangle.
        private void pdocTriangle_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            using (Font font = new Font("Courier New", 4))
            {
                using (StringFormat format = new StringFormat())
                {
                    // Center each line.
                    format.Alignment = StringAlignment.Center;

                    const float width_factor = 6.5f;
                    int num_wid = (int)(width_factor * e.Graphics.MeasureString("0", font).Width);
                    int num_hgt = (int)e.Graphics.MeasureString("0", font).Height;
                    int y = e.MarginBounds.Top;
                    int xmid = (e.MarginBounds.Left + e.MarginBounds.Right) / 2;

                    // Make the first row.
                    List<int> numbers = new List<int>();
                    numbers.Add(1);
  
                    // Display rows.
                    while (y < e.MarginBounds.Height)
                    {
                        int x = xmid - (num_wid * numbers.Count) / 2;
                        if (x < e.MarginBounds.Left) break;

                        // Display the current list of numbers.
                        foreach (int num in numbers)
                        {
                            e.Graphics.DrawString(num.ToString(),
                                font, Brushes.Black, x, y, format);
                            x += num_wid;
                        }

                        // Add the next number to the list.
                        List<int> new_numbers = new List<int>();
                        new_numbers.Add(1);
                        for (int i = 1; i < numbers.Count; i++)
                        {
                            new_numbers.Add(numbers[i - 1] + numbers[i]);
                        }
                        new_numbers.Add(1);
                        numbers = new_numbers;

                        y += num_hgt;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_pascals_triangle_Form1));
            this.btnGo = new System.Windows.Forms.Button();
            this.ppdTriangle = new System.Windows.Forms.PrintPreviewDialog();
            this.pdocTriangle = new System.Drawing.Printing.PrintDocument();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGo.Location = new System.Drawing.Point(105, 31);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // ppdTriangle
            // 
            this.ppdTriangle.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppdTriangle.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppdTriangle.ClientSize = new System.Drawing.Size(400, 300);
            this.ppdTriangle.Document = this.pdocTriangle;
            this.ppdTriangle.Enabled = true;
            this.ppdTriangle.Icon = ((System.Drawing.Icon)(resources.GetObject("ppdTriangle.Icon")));
            this.ppdTriangle.Name = "ppdTriangle";
            this.ppdTriangle.Visible = false;
            // 
            // pdocTriangle
            // 
            this.pdocTriangle.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdocTriangle_PrintPage);
            // 
            // howto_pascals_triangle_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 84);
            this.Controls.Add(this.btnGo);
            this.Name = "howto_pascals_triangle_Form1";
            this.Text = "howto_pascals_triangle";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.PrintPreviewDialog ppdTriangle;
        private System.Drawing.Printing.PrintDocument pdocTriangle;
    }
}

