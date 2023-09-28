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
     public partial class howto_user_select_printer_Form1:Form
  { 


        public howto_user_select_printer_Form1()
        {
            InitializeComponent();
        }

        // List the available printers.
        private void howto_user_select_printer_Form1_Load(object sender, EventArgs e)
        {
            foreach (string printer in PrinterSettings.InstalledPrinters)
                cboPrinter.Items.Add(printer);
        }

        // Print.
        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Select the printer.
            pdocSmiley.PrinterSettings.PrinterName = cboPrinter.Text;

            // Print.
            pdocSmiley.Print();
        }

        // Draw the smiley face.
        private void pdocSmiley_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            e.Graphics.TranslateTransform(1, 1);
            e.Graphics.ScaleTransform(100, 100,
                System.Drawing.Drawing2D.MatrixOrder.Append);
            e.Graphics.TranslateTransform(
                e.MarginBounds.X,
                e.MarginBounds.Y,
                System.Drawing.Drawing2D.MatrixOrder.Append);
            DrawSmiley(e.Graphics);
        }

        // Draw a smiley face in the area (-1, -1)-(1, 1).
        private void DrawSmiley(Graphics gr)
        {
            using (Pen thin_pen = new Pen(Color.Black, 0))
            {
                gr.FillEllipse(Brushes.Yellow, -1, -1, 2, 2);
                gr.DrawEllipse(thin_pen, -1, -1, 2, 2);

                gr.FillEllipse(Brushes.LightGreen, -0.5F, -0.5F, 0.3F, 0.5F);
                gr.DrawEllipse(thin_pen, -0.5F, -0.5F, 0.3F, 0.5F);
                gr.FillEllipse(Brushes.Black, -0.4F, -0.4F, 0.2F, 0.3F);

                gr.FillEllipse(Brushes.LightGreen, 0.2F, -0.5F, 0.3F, 0.5F);
                gr.DrawEllipse(thin_pen, 0.2F, -0.5F, 0.3F, 0.5F);
                gr.FillEllipse(Brushes.Black, 0.3F, -0.4F, 0.2F, 0.3F);

                gr.FillEllipse(Brushes.LightBlue, -0.2F, -0.1F, 0.4F, 0.6F);
                gr.DrawEllipse(thin_pen, -0.2F, -0.1F, 0.4F, 0.6F);

                gr.DrawArc(thin_pen, -0.75F, -0.75F, 1.5F, 1.5F, 20, 120);
            }
        }

        // Enable the Print button if a printer is selected.
        private void cboPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPrint.Enabled = (cboPrinter.SelectedIndex > -1);
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
            this.cboPrinter = new System.Windows.Forms.ComboBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pdocSmiley = new System.Drawing.Printing.PrintDocument();
            this.SuspendLayout();
            // 
            // cboPrinter
            // 
            this.cboPrinter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrinter.FormattingEnabled = true;
            this.cboPrinter.Location = new System.Drawing.Point(12, 12);
            this.cboPrinter.Name = "cboPrinter";
            this.cboPrinter.Size = new System.Drawing.Size(309, 21);
            this.cboPrinter.TabIndex = 0;
            this.cboPrinter.SelectedIndexChanged += new System.EventHandler(this.cboPrinter_SelectedIndexChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(129, 39);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // howto_user_select_printer_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 74);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.cboPrinter);
            this.Name = "howto_user_select_printer_Form1";
            this.Text = "howto_user_select_printer";
            this.Load += new System.EventHandler(this.howto_user_select_printer_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPrinter;
        private System.Windows.Forms.Button btnPrint;
        private System.Drawing.Printing.PrintDocument pdocSmiley;
    }
}

