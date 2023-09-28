using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;

// At design time set:
//      ppdShapes.Document = pdocShapes

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_control_print_preview_Form1:Form
  { 


        public howto_control_print_preview_Form1()
        {
            InitializeComponent();
        }

        // Display a print preview.
        private void btnPreview_Click(object sender, EventArgs e)
        {
            // Set the size.
            Form frm = ppdShapes as Form;
            if (chkMaximized.Checked)
            {
                // Display maximized.
                frm.WindowState = FormWindowState.Maximized;
            }
            else
            {
                // Make the client area 400 x 400.
                frm.WindowState = FormWindowState.Normal;
                frm.StartPosition = FormStartPosition.CenterScreen;
                ppdShapes.ClientSize = new Size(400, 400);
            }

            // Set the dialog's title.
            frm.Text = "Numbers";

            // Set the zoom level.
            if (chkZoom100.Checked)
            {
                // 100%.
                ppdShapes.PrintPreviewControl.Zoom = 1.0;
            }
            else
            {
                // Auto.
                ppdShapes.PrintPreviewControl.AutoZoom = true;
            }

            // Set anti-aliasing.
            ppdShapes.PrintPreviewControl.UseAntiAlias = chkAntiAlias.Checked;

            // Set other properties.
            ppdShapes.PrintPreviewControl.Columns = 3;
            ppdShapes.PrintPreviewControl.Rows = 3;
            ppdShapes.PrintPreviewControl.BackColor = Color.Orange; // Background color.
            ppdShapes.PrintPreviewControl.ForeColor = Color.Yellow; // Paper color.
            ppdShapes.PrintPreviewControl.StartPage = 3;            // Page 3 in the upper left.
            
            // Display the dialog.
            ppdShapes.ShowDialog();
        }

        // Print the document's pages.
        private int m_NextPage = 0;
        private void pdocShapes_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Draw the margins.
            using (Pen dashed_pen = new Pen(Color.Red, 5))
            {
                dashed_pen.DashPattern = new float[] { 10, 10 };
                e.Graphics.DrawRectangle(dashed_pen, e.MarginBounds);
            }

            // Draw an ellipse.
            e.Graphics.DrawEllipse(Pens.Blue, e.MarginBounds);

            // Draw the page number.
            // Center it inside the margins.
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            using (Font the_font = new Font("Times New Roman", 200, FontStyle.Bold))
            {
                using (Brush the_brush = new SolidBrush(Color.Black))
                {
                    e.Graphics.DrawString(String.Format("{0}", m_NextPage + 1),
                        the_font, the_brush, e.MarginBounds, sf);
                }
            }

            // Next time print the next page.
            m_NextPage += 1;

            // We have more pages if wee have not yet printed page 10.
            e.HasMorePages = (m_NextPage <= 10);
        }

        // Get ready to print.
        private void pdocShapes_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            // Start with page 0.
            m_NextPage = 0;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_control_print_preview_Form1));
            this.btnPreview = new System.Windows.Forms.Button();
            this.pdocShapes = new System.Drawing.Printing.PrintDocument();
            this.ppdShapes = new System.Windows.Forms.PrintPreviewDialog();
            this.chkMaximized = new System.Windows.Forms.CheckBox();
            this.chkZoom100 = new System.Windows.Forms.CheckBox();
            this.chkAntiAlias = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(152, 31);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 3;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // pdocShapes
            // 
            this.pdocShapes.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdocShapes_PrintPage);
            this.pdocShapes.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.pdocShapes_BeginPrint);
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
            // chkMaximized
            // 
            this.chkMaximized.AutoSize = true;
            this.chkMaximized.Location = new System.Drawing.Point(12, 12);
            this.chkMaximized.Name = "chkMaximized";
            this.chkMaximized.Size = new System.Drawing.Size(75, 17);
            this.chkMaximized.TabIndex = 11;
            this.chkMaximized.Text = "Maximized";
            this.chkMaximized.UseVisualStyleBackColor = true;
            // 
            // chkZoom100
            // 
            this.chkZoom100.AutoSize = true;
            this.chkZoom100.Location = new System.Drawing.Point(12, 35);
            this.chkZoom100.Name = "chkZoom100";
            this.chkZoom100.Size = new System.Drawing.Size(82, 17);
            this.chkZoom100.TabIndex = 12;
            this.chkZoom100.Text = "Zoom 100%";
            this.chkZoom100.UseVisualStyleBackColor = true;
            // 
            // chkAntiAlias
            // 
            this.chkAntiAlias.AutoSize = true;
            this.chkAntiAlias.Location = new System.Drawing.Point(12, 58);
            this.chkAntiAlias.Name = "chkAntiAlias";
            this.chkAntiAlias.Size = new System.Drawing.Size(69, 17);
            this.chkAntiAlias.TabIndex = 13;
            this.chkAntiAlias.Text = "Anti-Alias";
            this.chkAntiAlias.UseVisualStyleBackColor = true;
            // 
            // howto_control_print_preview_Form1
            // 
            this.AcceptButton = this.btnPreview;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 92);
            this.Controls.Add(this.chkAntiAlias);
            this.Controls.Add(this.chkZoom100);
            this.Controls.Add(this.chkMaximized);
            this.Controls.Add(this.btnPreview);
            this.Name = "howto_control_print_preview_Form1";
            this.Text = "howto_control_print_preview";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPreview;
        private System.Drawing.Printing.PrintDocument pdocShapes;
        private System.Windows.Forms.PrintPreviewDialog ppdShapes;
        private System.Windows.Forms.CheckBox chkMaximized;
        private System.Windows.Forms.CheckBox chkZoom100;
        private System.Windows.Forms.CheckBox chkAntiAlias;
    }
}

