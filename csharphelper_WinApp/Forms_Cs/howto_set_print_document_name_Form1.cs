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
     public partial class howto_set_print_document_name_Form1:Form
  { 


        public howto_set_print_document_name_Form1()
        {
            InitializeComponent();
        }

        private void howto_set_print_document_name_Form1_Load(object sender, EventArgs e)
        {
            // Find all of the installed printers.
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                cboPrinter.Items.Add(printer);
            }

            // Find and select the default printer.
            try
            {
                PrinterSettings settings = new PrinterSettings();
                cboPrinter.Text = settings.PrinterName;
            }
            catch
            {
            }
        }

        // Print the document.
        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Select the printer.
            pdocFile.PrinterSettings.PrinterName = cboPrinter.Text;

            // Set the print document name.
            pdocFile.DocumentName = txtDocumentName.Text;

            // Print.
            pdocFile.Print();
        }

        // Just draw some sample text.
        private void pdocFile_PrintPage(object sender, PrintPageEventArgs e)
        {
            using (Font font = new Font("Times New Roman", 30))
            {
                e.Graphics.DrawString("Sample text", font, Brushes.Black,
                    e.MarginBounds.Left, e.MarginBounds.Top);
            }
            e.HasMorePages = false;
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pdocFile = new System.Drawing.Printing.PrintDocument();
            this.txtDocumentName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cboPrinter
            // 
            this.cboPrinter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrinter.FormattingEnabled = true;
            this.cboPrinter.Location = new System.Drawing.Point(108, 11);
            this.cboPrinter.Name = "cboPrinter";
            this.cboPrinter.Size = new System.Drawing.Size(234, 21);
            this.cboPrinter.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Printer:";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPrint.Location = new System.Drawing.Point(140, 64);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 19;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Document Name:";
            // 
            // pdocFile
            // 
            this.pdocFile.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdocFile_PrintPage);
            // 
            // txtDocumentName
            // 
            this.txtDocumentName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocumentName.Location = new System.Drawing.Point(108, 38);
            this.txtDocumentName.Name = "txtDocumentName";
            this.txtDocumentName.Size = new System.Drawing.Size(234, 20);
            this.txtDocumentName.TabIndex = 18;
            this.txtDocumentName.Text = "Test document";
            // 
            // howto_set_print_document_name_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 98);
            this.Controls.Add(this.cboPrinter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDocumentName);
            this.Name = "howto_set_print_document_name_Form1";
            this.Text = "howto_set_print_document_name";
            this.Load += new System.EventHandler(this.howto_set_print_document_name_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPrinter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label1;
        private System.Drawing.Printing.PrintDocument pdocFile;
        private System.Windows.Forms.TextBox txtDocumentName;
    }
}

