using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Add a reference to:
//      Microsoft Word 14.0 Object Library

using Word = Microsoft.Office.Interop.Word;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_list_words_with_style_Form1:Form
  { 


        public howto_list_words_with_style_Form1()
        {
            InitializeComponent();
        }

        // Let the user pick a file.
        private void btnPickFile_Click(object sender, EventArgs e)
        {
            ofdFile.FileName = txtFile.Text;
            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = ofdFile.FileName;
            }
        }

        // List the words in the file.
        private void btnListWords_Click(object sender, EventArgs e)
        {
            lstWords.DataSource = null;
            Cursor = Cursors.WaitCursor;
            Refresh();

            // Get the words.
            List<string> words = FindWordsWithStyle(txtFile.Text, txtStyle.Text);

            // Display the result.
            lstWords.DataSource = words;
            lblSummary.Text = words.Count + " words";
            Cursor = Cursors.Default;
        }

        // Find words with the given style in the Word file.
        private List<string> FindWordsWithStyle(string file_name, string word_style)
        {
            // Get the Word application object.
            Word._Application word_app = new Word.ApplicationClass();

            // Make Word visible (optional).
            word_app.Visible = false;

            // Open the file.
            object filename = file_name;
            object confirm_conversions = false;
            object read_only = true;
            object add_to_recent_files = false;
            object format = 0;
            object missing = System.Reflection.Missing.Value;

            Word._Document word_doc =
                word_app.Documents.Open(ref filename, ref confirm_conversions,
                    ref read_only, ref add_to_recent_files,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref format, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing);

            // Search.
            List<string> result = new List<string>();
            object style = word_style;
            word_app.Selection.Find.ClearFormatting();
            word_app.Selection.Find.set_Style(ref style);
            object obj_true = true;
            for (;;)
            {
                word_app.Selection.Find.Execute(ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref obj_true,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing);
                if (!word_app.Selection.Find.Found) break;
                result.Add(word_app.Selection.Text);
            }

            // Close the document without prompting.
            object save_changes = false;
            word_doc.Close(ref save_changes, ref missing, ref missing);
            word_app.Quit(ref save_changes, ref missing, ref missing);

            // Return the result.
            return result;
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
            this.lblSummary = new System.Windows.Forms.Label();
            this.lstWords = new System.Windows.Forms.ListBox();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.btnListWords = new System.Windows.Forms.Button();
            this.btnPickFile = new System.Windows.Forms.Button();
            this.txtStyle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSummary
            // 
            this.lblSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSummary.AutoSize = true;
            this.lblSummary.Location = new System.Drawing.Point(14, 327);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(0, 13);
            this.lblSummary.TabIndex = 11;
            // 
            // lstWords
            // 
            this.lstWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstWords.FormattingEnabled = true;
            this.lstWords.IntegralHeight = false;
            this.lstWords.Location = new System.Drawing.Point(14, 93);
            this.lstWords.Name = "lstWords";
            this.lstWords.Size = new System.Drawing.Size(310, 231);
            this.lstWords.TabIndex = 10;
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(50, 12);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(245, 20);
            this.txtFile.TabIndex = 7;
            this.txtFile.Text = "C:\\Users\\rod\\Work\\Writing\\Books\\Essential Algorithms 2e\\AR\\9561453_c01_AR.docx";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "File:";
            // 
            // ofdFile
            // 
            this.ofdFile.FileName = "openFileDialog1";
            // 
            // btnListWords
            // 
            this.btnListWords.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnListWords.Location = new System.Drawing.Point(130, 64);
            this.btnListWords.Name = "btnListWords";
            this.btnListWords.Size = new System.Drawing.Size(75, 23);
            this.btnListWords.TabIndex = 9;
            this.btnListWords.Text = "List Words";
            this.btnListWords.UseVisualStyleBackColor = true;
            this.btnListWords.Click += new System.EventHandler(this.btnListWords_Click);
            // 
            // btnPickFile
            // 
            this.btnPickFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickFile.Image = Properties.Resources.EllipsisTransparent;
            this.btnPickFile.Location = new System.Drawing.Point(301, 10);
            this.btnPickFile.Name = "btnPickFile";
            this.btnPickFile.Size = new System.Drawing.Size(23, 23);
            this.btnPickFile.TabIndex = 8;
            this.btnPickFile.UseVisualStyleBackColor = true;
            this.btnPickFile.Click += new System.EventHandler(this.btnPickFile_Click);
            // 
            // txtStyle
            // 
            this.txtStyle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStyle.Location = new System.Drawing.Point(50, 38);
            this.txtStyle.Name = "txtStyle";
            this.txtStyle.Size = new System.Drawing.Size(245, 20);
            this.txtStyle.TabIndex = 13;
            this.txtStyle.Text = "KeyTerm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Style:";
            // 
            // howto_list_words_with_style_Form1
            // 
            this.AcceptButton = this.btnListWords;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 349);
            this.Controls.Add(this.txtStyle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.lstWords);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnListWords);
            this.Controls.Add(this.btnPickFile);
            this.Name = "howto_list_words_with_style_Form1";
            this.Text = "howto_list_words_with_style";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.ListBox lstWords;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.Button btnListWords;
        private System.Windows.Forms.Button btnPickFile;
        private System.Windows.Forms.TextBox txtStyle;
        private System.Windows.Forms.Label label2;
    }
}

