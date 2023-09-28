using System;
using System.Windows.Forms;

// Open the Add References dialog. On the COM tab, select:
//
//      Microsoft.Office.Interop.Excel 14.0.0.0
//
// Or whatever version you have installed on your system.

// More examples of automating Excel from C#:
//
//      http://support.microsoft.com/kb/302084
//      https://support.microsoft.com/help/311452/info-develop-microsoft-office-solutions-with-visual-studio--net

using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_save_excel_pdf_Form1:Form
  { 


        public howto_save_excel_pdf_Form1()
        {
            InitializeComponent();
        }

        private void howto_save_excel_pdf_Form1_Load(object sender, EventArgs e)
        {
            txtFile.Text = Path.GetFullPath(
            Path.Combine(Application.StartupPath, "..\\..")) +
            "\\Items.xlsx";
        }

        // Write into the Excel workbook.
        private void btnWrite_Click(object sender, EventArgs e)
        {
            // Get the Excel application object.
            Excel.ApplicationClass excel_app = new Excel.ApplicationClass();

            // Make Excel visible (optional).
            excel_app.Visible = true;

            // See if the workbook already exists.
            string filename = txtFile.Text;
            Excel.Workbook workbook = null;
            if (File.Exists(filename))
            {
                // Open the workbook.
                workbook = excel_app.Workbooks.Open(filename,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);
            }
            else
            {
                // Create the workbook.
                workbook = excel_app.Workbooks.Add(Type.Missing);
                workbook.SaveAs(filename, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing,
                    Excel.XlSaveAsAccessMode.xlShared, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }

            // See if the worksheet already exists.
            string sheet_name = DateTime.Now.ToString("MM-dd-yy");

            Excel.Worksheet sheet = FindSheet(workbook, sheet_name);
            if (sheet == null)
            {
                // Add the worksheet at the end.
                sheet = (Excel.Worksheet)workbook.Sheets.Add(
                    Type.Missing, workbook.Sheets[workbook.Sheets.Count],
                    1, Excel.XlSheetType.xlWorksheet);
                sheet.Name = sheet_name;
            }

            // Add some data to individual cells.
            sheet.Cells[1, 1] = "A";
            sheet.Cells[1, 2] = "B";
            sheet.Cells[1, 3] = "C";

            // Make that range of cells bold and red.
            Excel.Range header_range = sheet.get_Range("A1", "C1");
            header_range.Font.Bold = true;
            header_range.Font.Color =
                System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
            header_range.Interior.Color =
                System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Pink);

            // Add some data to a range of cells.
            int[,] values =
            {
                {2, 4, 6},
                {3, 6, 9},
                {4, 8, 12},
                {5, 10, 15},
            };
            Excel.Range value_range = sheet.get_Range("A2", "C5");
            value_range.Value2 = values;

            // Save into a PDF.
            filename = txtFile.Text.Replace(".xlsx", ".pdf");
            const int xlQualityStandard = 0;
            sheet.ExportAsFixedFormat(
                Excel.XlFixedFormatType.xlTypePDF,
                filename, xlQualityStandard, true, false,
                Type.Missing, Type.Missing, true, Type.Missing);

            // Save the changes and close the workbook.
            workbook.Close(true, Type.Missing, Type.Missing);

            // Close the Excel server.
            excel_app.Quit();

            MessageBox.Show("Done");
        }

        // Return the worksheet with the given name.
        private Excel.Worksheet FindSheet(Excel.Workbook workbook, string sheet_name)
        {
            foreach (Excel.Worksheet sheet in workbook.Sheets)
            {
                if (sheet.Name == sheet_name) return sheet;
            }

            return null;
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
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnWrite = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(44, 12);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(238, 20);
            this.txtFile.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "File:";
            // 
            // btnWrite
            // 
            this.btnWrite.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnWrite.Location = new System.Drawing.Point(110, 47);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(75, 23);
            this.btnWrite.TabIndex = 9;
            this.btnWrite.Text = "Write";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // howto_save_excel_pdf_Form1
            // 
            this.AcceptButton = this.btnWrite;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 86);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnWrite);
            this.Name = "howto_save_excel_pdf_Form1";
            this.Text = "howto_save_excel_pdf";
            this.Load += new System.EventHandler(this.howto_save_excel_pdf_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnWrite;
    }
}

