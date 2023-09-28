using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

// Open the Add References dialog. On the COM tab, select:
//
//      Microsoft 12.0 Object Library
//
// (Or whatever version you have installed on your system.)

// More examples of automating Excel from C#:
//
//      http://support.microsoft.com/kb/302084
//      http://support.microsoft.com/default.aspx?scid=kb;en-us;311452

using Excel = Microsoft.Office.Interop.Excel;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_read_excel_Form1:Form
  { 


        public howto_read_excel_Form1()
        {
            InitializeComponent();
        }

        private void howto_read_excel_Form1_Load(object sender, EventArgs e)
        {
            txtFile.Text = Path.GetFullPath(
                Path.Combine(Application.StartupPath, @"..\..")) +
                @"\Items.xlsx";
        }

        // Read from the Excel workbook.
        private void btnRead_Click(object sender, EventArgs e)
        {
            // Get the Excel application object.
            Excel.Application excel_app = new Excel.ApplicationClass();

            // Make Excel visible (optional).
            excel_app.Visible = true;

            // Open the workbook read-only.
            Excel.Workbook workbook = excel_app.Workbooks.Open(txtFile.Text,
                Type.Missing, true, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);

            // Get the first worksheet.
            Excel.Worksheet sheet = (Excel.Worksheet)workbook.Sheets[1];

            // Get the titles and values.
            SetTitleAndListValues(sheet, 1, 1, lblTitle1, lstItems1);
            SetTitleAndListValues(sheet, 1, 2, lblTitle2, lstItems2);

            // Close the workbook without saving changes.
            workbook.Close(false, Type.Missing, Type.Missing);

            // Close the Excel server.
            excel_app.Quit();
        }

        // Set a title Label and the values in a ListBox.
        // Get the title from cell (row, col). Get the values from
        // cell (row + 1, col) to the end of the column.
        private void SetTitleAndListValues(Excel.Worksheet sheet, 
            int row, int col, Label lbl, ListBox lst)
        {
            Excel.Range range;

            // Set the title.
            range = (Excel.Range)sheet.Cells[row, col];
            lbl.Text = (string)range.Value2;
            lbl.ForeColor = System.Drawing.ColorTranslator.FromOle(
                (int)(double)range.Font.Color);
            lbl.BackColor = System.Drawing.ColorTranslator.FromOle(
                (int)(double)range.Interior.Color);

            // Get the values.
            // Find the last cell in the column.
            range = (Excel.Range)sheet.Columns[col, Type.Missing];
            Excel.Range last_cell = range.get_End(Excel.XlDirection.xlDown);

            // Get a Range holding the values.
            Excel.Range first_cell = (Excel.Range)sheet.Cells[row + 1, col];
            Excel.Range value_range = (Excel.Range)sheet.get_Range(first_cell, last_cell);

            // Get the values.
            object[,] range_values = (object[,])value_range.Value2;

            // Convert this into a 1-dimensional array.
            // Note that the Range's array has lower bounds 1.
            int num_items = range_values.GetUpperBound(0);
            string[] values1 = new string[num_items];
            for (int i = 0; i < num_items; i++)
            {
                values1[i] = (string)range_values[i + 1, 1];
            }

            // Display the values in the ListBox.
            lst.DataSource = values1;
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
            this.btnRead = new System.Windows.Forms.Button();
            this.lblTitle1 = new System.Windows.Forms.Label();
            this.lstItems1 = new System.Windows.Forms.ListBox();
            this.lstItems2 = new System.Windows.Forms.ListBox();
            this.lblTitle2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(44, 12);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(382, 20);
            this.txtFile.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "File:";
            // 
            // btnRead
            // 
            this.btnRead.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRead.Location = new System.Drawing.Point(182, 47);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 3;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // lblTitle1
            // 
            this.lblTitle1.Location = new System.Drawing.Point(88, 82);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(120, 18);
            this.lblTitle1.TabIndex = 5;
            this.lblTitle1.Text = "label2";
            this.lblTitle1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstItems1
            // 
            this.lstItems1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstItems1.FormattingEnabled = true;
            this.lstItems1.Location = new System.Drawing.Point(88, 103);
            this.lstItems1.Name = "lstItems1";
            this.lstItems1.Size = new System.Drawing.Size(120, 147);
            this.lstItems1.TabIndex = 6;
            // 
            // lstItems2
            // 
            this.lstItems2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstItems2.FormattingEnabled = true;
            this.lstItems2.Location = new System.Drawing.Point(231, 103);
            this.lstItems2.Name = "lstItems2";
            this.lstItems2.Size = new System.Drawing.Size(120, 147);
            this.lstItems2.TabIndex = 8;
            // 
            // lblTitle2
            // 
            this.lblTitle2.Location = new System.Drawing.Point(231, 82);
            this.lblTitle2.Name = "lblTitle2";
            this.lblTitle2.Size = new System.Drawing.Size(120, 18);
            this.lblTitle2.TabIndex = 7;
            this.lblTitle2.Text = "label2";
            this.lblTitle2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_read_excel_Form1
            // 
            this.AcceptButton = this.btnRead;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 259);
            this.Controls.Add(this.lstItems2);
            this.Controls.Add(this.lblTitle2);
            this.Controls.Add(this.lstItems1);
            this.Controls.Add(this.lblTitle1);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRead);
            this.Name = "howto_read_excel_Form1";
            this.Text = "howto_read_excel";
            this.Load += new System.EventHandler(this.howto_read_excel_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Label lblTitle1;
        private System.Windows.Forms.ListBox lstItems1;
        private System.Windows.Forms.ListBox lstItems2;
        private System.Windows.Forms.Label lblTitle2;
    }
}

