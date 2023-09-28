using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Printing;
using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_print_text_file_Form1:Form
  { 


        public howto_print_text_file_Form1()
        {
            InitializeComponent();
        }

        // Populate the list of printers.
        private void howto_print_text_file_Form1_Load(object sender, EventArgs e)
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

            // Initially select the source code file.
            string file_path = Application.StartupPath;
            if (file_path.EndsWith(@"\bin\Debug"))
                file_path = file_path.Substring(0, file_path.Length - 10);
            if (file_path.EndsWith(@"\bin\Release"))
                file_path = file_path.Substring(0, file_path.Length - 12);
            if (file_path.EndsWith(@"\"))
                file_path = file_path.Substring(0, file_path.Length - 1);
            file_path += @"\howto_print_text_file_Form1.cs";
            txtFile.Text = file_path;
        }

        // Let the user select a file.
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            ofdTextFile.FileName = txtFile.Text;
            if (ofdTextFile.ShowDialog() == DialogResult.OK)
                txtFile.Text = ofdTextFile.FileName;
        }

        // The text contained in the file.
        private string FileContents;

        // Preview the selected file.
        private void btnPreview_Click(object sender, EventArgs e)
        {
            // Read the file's contents.
            try
            {
                FileContents = File.ReadAllText(txtFile.Text).Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading file " + txtFile.Text +
                    ".\n" + ex.Message);
                return;
            }

            // Display the print preview dialog.
            ppdTextFile.ShowDialog();
        }

        // Print a page of the text file.
        private void pdocTextFile_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Make a font for printing.
            using (Font font = new Font("Courier New", 10))
            {
                // Make a StringFormat to align text normally.
                using (StringFormat string_format = new StringFormat())
                {
                    // See how much of the remaining text will fit.
                    SizeF layout_area = new SizeF(
                        e.MarginBounds.Width, e.MarginBounds.Height);
                    int chars_fitted, lines_filled;
                    e.Graphics.MeasureString(FileContents, font,
                        layout_area, string_format,
                        out chars_fitted, out lines_filled);

                    // Print as much as will fit.
                    e.Graphics.DrawString(
                        FileContents.Substring(0, chars_fitted),
                        font, Brushes.Black, e.MarginBounds,
                        string_format);

                    // Remove the printed text from the string.
                    FileContents = FileContents.Substring(chars_fitted).Trim();
                }
            }

            // See if we are done.
            e.HasMorePages = FileContents.Length > 0;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_print_text_file_Form1));
            this.ppdTextFile = new System.Windows.Forms.PrintPreviewDialog();
            this.pdocTextFile = new System.Drawing.Printing.PrintDocument();
            this.btnPreview = new System.Windows.Forms.Button();
            this.ofdTextFile = new System.Windows.Forms.OpenFileDialog();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPrinter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ppdTextFile
            // 
            this.ppdTextFile.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppdTextFile.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppdTextFile.ClientSize = new System.Drawing.Size(400, 300);
            this.ppdTextFile.Document = this.pdocTextFile;
            this.ppdTextFile.Enabled = true;
            this.ppdTextFile.Icon = ((System.Drawing.Icon)(resources.GetObject("ppdTextFile.Icon")));
            this.ppdTextFile.Name = "ppdTextFile";
            this.ppdTextFile.Visible = false;
            // 
            // pdocTextFile
            // 
            this.pdocTextFile.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdocTextFile_PrintPage);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPreview.Location = new System.Drawing.Point(155, 62);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 11;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // ofdTextFile
            // 
            this.ofdTextFile.FileName = "openFileDialog1";
            this.ofdTextFile.Filter = "Text files|*.txt|All files|*.*";
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFile.Image = Properties.Resources.Ellipsis;
            this.btnSelectFile.Location = new System.Drawing.Point(346, 34);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(26, 23);
            this.btnSelectFile.TabIndex = 10;
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(58, 36);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(281, 20);
            this.txtFile.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "File:";
            // 
            // cboPrinter
            // 
            this.cboPrinter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrinter.FormattingEnabled = true;
            this.cboPrinter.Location = new System.Drawing.Point(58, 9);
            this.cboPrinter.Name = "cboPrinter";
            this.cboPrinter.Size = new System.Drawing.Size(314, 21);
            this.cboPrinter.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Printer:";
            // 
            // howto_print_text_file_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 94);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboPrinter);
            this.Controls.Add(this.label1);
            this.Name = "howto_print_text_file_Form1";
            this.Text = "howto_print_text_file";
            this.Load += new System.EventHandler(this.howto_print_text_file_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PrintPreviewDialog ppdTextFile;
        private System.Drawing.Printing.PrintDocument pdocTextFile;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.OpenFileDialog ofdTextFile;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboPrinter;
        private System.Windows.Forms.Label label1;
    }
}

