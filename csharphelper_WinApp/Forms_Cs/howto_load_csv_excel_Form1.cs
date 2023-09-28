using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Open the Add Reference dialog. On the COM tab,
// add a reference to "Microsoft.Office.Interop.Excel"
using Excel = Microsoft.Office.Interop.Excel;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_load_csv_excel_Form1:Form
  { 


        public howto_load_csv_excel_Form1()
        {
            InitializeComponent();
        }

        private void howto_load_csv_excel_Form1_Load(object sender, EventArgs e)
        {
            txtFile.Text = Application.StartupPath + "\\comma.txt";
        }

        // Open a delimited file in Excel.
        private void btnLoad_Click(object sender, EventArgs e)
        {
            // Get the Excel application object.
            Excel.Application excel_app = new Excel.ApplicationClass();

            // Make Excel visible (optional).
            excel_app.Visible = true;

            // Open the file.
            excel_app.Workbooks.Open(
                txtFile.Text,               // Filename
                Type.Missing,
                Type.Missing,
                Excel.XlFileFormat.xlCSV,   // Format
                Type.Missing,
                Type.Missing,
                Type.Missing,
                Type.Missing,
                txtDelimiter.Text,          // Delimiter
                Type.Missing,
                Type.Missing,
                Type.Missing,
                Type.Missing,
                Type.Missing,
                Type.Missing);
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
            this.txtDelimiter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDelimiter
            // 
            this.txtDelimiter.Location = new System.Drawing.Point(68, 37);
            this.txtDelimiter.Name = "txtDelimiter";
            this.txtDelimiter.Size = new System.Drawing.Size(31, 20);
            this.txtDelimiter.TabIndex = 6;
            this.txtDelimiter.Text = ",";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Delimiter:";
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLoad.Location = new System.Drawing.Point(112, 70);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(68, 11);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(219, 20);
            this.txtFile.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "File:";
            // 
            // howto_load_csv_excel_Form1
            // 
            this.AcceptButton = this.btnLoad;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 105);
            this.Controls.Add(this.txtDelimiter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label1);
            this.Name = "howto_load_csv_excel_Form1";
            this.Text = "howto_load_csv_excel";
            this.Load += new System.EventHandler(this.howto_load_csv_excel_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDelimiter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label1;
    }
}

