using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// At design time set:
//      ppdShapes.Document = pdocShapes

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_print_Form1:Form
  { 


        public howto_print_Form1()
        {
            InitializeComponent();
        }

        // Display a print preview.
        private void btnPreview_Click(object sender, EventArgs e)
        {
            ppdShapes.ShowDialog();
        }

        // Print.
        private void btnPrint_Click(object sender, EventArgs e)
        {
            pdocShapes.Print();
        }

        // Print the document's pages.
        private int NextPageNum = 0;
        private void pdocShapes_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Draw a shape depending on the page we are printing.
            switch (NextPageNum)
            {
                case 0: // Draw an ellipse.
                    using (Pen the_pen = new Pen(Color.Red, 10))
                    {
                        e.Graphics.DrawEllipse(the_pen, e.MarginBounds);
                    }
                    break;
                case 1: // Draw a triangle.
                    using (Pen the_pen = new Pen(Color.Green, 10))
                    {
                        int xmid = (int)(e.MarginBounds.X + e.MarginBounds.Width / 2);
                        Point[] pts = 
                        {
                            new Point(xmid, e.MarginBounds.Top),
                            new Point(e.MarginBounds.Right, e.MarginBounds.Bottom),
                            new Point(e.MarginBounds.Left, e.MarginBounds.Bottom),
                        };
                        e.Graphics.DrawPolygon(the_pen, pts);
                    }
                    break;
                case 2: // Draw a rectangle.
                    using (Pen the_pen = new Pen(Color.Blue, 10))
                    {
                        e.Graphics.DrawRectangle(the_pen, e.MarginBounds);
                    }
                    break;
                case 3: // Draw a diamond.
                    using (Pen the_pen = new Pen(Color.Orange, 10))
                    {
                        int xmid = (int)(e.MarginBounds.X + e.MarginBounds.Width / 2);
                        int ymid = (int)(e.MarginBounds.Y + e.MarginBounds.Height / 2);
                        Point[] pts = 
                        {
                            new Point(xmid, e.MarginBounds.Top),
                            new Point(e.MarginBounds.Right, ymid),
                            new Point(xmid, e.MarginBounds.Bottom),
                            new Point(e.MarginBounds.Left, ymid),
                        };
                        e.Graphics.DrawPolygon(the_pen, pts);
                    }
                    break;
            }

            // Draw the page number centered.
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                using (Font the_font = new Font("Times New Roman", 200, FontStyle.Bold))
                {
                    using (Brush the_brush = new SolidBrush(Color.Black))
                    {
                        e.Graphics.DrawString(String.Format("{0}", NextPageNum + 1),
                            the_font, the_brush, e.MarginBounds, sf);
                    }
                }
            }

            // Next time print the next page.
            NextPageNum += 1;

            // We have more pages if we have not yet printed page 3.
            e.HasMorePages = (NextPageNum <= 3);

            // If we have no more pages, reset for the next time we print.
            if (NextPageNum > 3) NextPageNum = 0;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_print_Form1));
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pdocShapes = new System.Drawing.Printing.PrintDocument();
            this.ppdShapes = new System.Windows.Forms.PrintPreviewDialog();
            this.SuspendLayout();
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPreview.Location = new System.Drawing.Point(55, 31);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 0;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrint.Location = new System.Drawing.Point(155, 31);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // pdocShapes
            // 
            this.pdocShapes.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdocShapes_PrintPage);
            // 
            // ppdShapes
            // 
            this.ppdShapes.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppdShapes.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppdShapes.ClientSize = new System.Drawing.Size(400, 300);
            this.ppdShapes.Document = this.pdocShapes;
            this.ppdShapes.Enabled = true;
            this.ppdShapes.Icon = ((System.Drawing.Icon)(resources.GetObject("ppdShapes.Icon")));
            this.ppdShapes.Name = "ppdShapes";
            this.ppdShapes.Visible = false;
            // 
            // howto_print_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 84);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPreview);
            this.Name = "howto_print_Form1";
            this.Text = "howto_print";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnPrint;
        private System.Drawing.Printing.PrintDocument pdocShapes;
        private System.Windows.Forms.PrintPreviewDialog ppdShapes;
    }
}

