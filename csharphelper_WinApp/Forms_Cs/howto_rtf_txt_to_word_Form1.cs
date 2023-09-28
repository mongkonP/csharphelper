using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Add a reference to Microsoft.Office.Interop.Word. 
using Word = Microsoft.Office.Interop.Word;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_rtf_txt_to_word_Form1:Form
  { 


        public howto_rtf_txt_to_word_Form1()
        {
            InitializeComponent();
        }

        private void howto_rtf_txt_to_word_Form1_Load(object sender, EventArgs e)
        {
            txtInputFile.Text = Application.StartupPath + "\\RtfTest.rtf";
            txtOutputFile.Text = Application.StartupPath + "\\RtfTest.docx";
        }

        // Open a file and save it as a .doc file.
        private void btnConvert_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            // Get the Word application object.
            Word._Application word_app = new Word.ApplicationClass();

            // Make Word visible (optional).
            //word_app.Visible = true;

            // Open the file.
            object input_file = txtInputFile.Text;
            object missing = Type.Missing;
            word_app.Documents.Open(ref input_file, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing,
                ref missing, ref missing, ref missing, ref missing);

            // Save the output file.
            object output_file = txtOutputFile.Text;
            object format_doc = (int)16;    // 16 for docx, 0 for doc.
            Word._Document active_document = word_app.ActiveDocument;
            active_document.SaveAs(ref output_file, ref format_doc,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing);

            // Exit the server without prompting.
            object false_obj = false;
            active_document.Close(ref false_obj, ref missing, ref missing);
            word_app.Quit(ref missing, ref missing, ref missing);

            Cursor = Cursors.Default;
            MessageBox.Show("Done");
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
            this.txtOutputFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtOutputFile
            // 
            this.txtOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputFile.Location = new System.Drawing.Point(79, 36);
            this.txtOutputFile.Name = "txtOutputFile";
            this.txtOutputFile.Size = new System.Drawing.Size(243, 20);
            this.txtOutputFile.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Output File:";
            // 
            // txtInputFile
            // 
            this.txtInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputFile.Location = new System.Drawing.Point(79, 10);
            this.txtInputFile.Name = "txtInputFile";
            this.txtInputFile.Size = new System.Drawing.Size(243, 20);
            this.txtInputFile.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Input File:";
            // 
            // btnConvert
            // 
            this.btnConvert.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnConvert.Location = new System.Drawing.Point(130, 66);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 7;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // howto_rtf_txt_to_word_Form1
            // 
            this.AcceptButton = this.btnConvert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 101);
            this.Controls.Add(this.txtOutputFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInputFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConvert);
            this.Name = "howto_rtf_txt_to_word_Form1";
            this.Text = "howto_rtf_txt_to_word";
            this.Load += new System.EventHandler(this.howto_rtf_txt_to_word_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOutputFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInputFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConvert;
    }
}

