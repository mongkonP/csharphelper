using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Text.RegularExpressions;
using Word = Microsoft.Office.Interop.Word;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_list_word_file_words_Form1:Form
  { 


        public howto_list_word_file_words_Form1()
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
            // Get the file's text.
            FileInfo file_info = new FileInfo(txtFile.Text);
            string extension = file_info.Extension.ToLower();
            string txt;
            if ((extension == ".doc") ||
                (extension == ".docx"))
            {
                txt = GrabWordFileWords(txtFile.Text);
            }
            else
            {
                txt = File.ReadAllText(txtFile.Text);
            }
            
            // Use regular expressions to replace characters
            // that are not letters or numbers with spaces.
            Regex reg_exp = new Regex("[^a-zA-Z0-9]");
            txt = reg_exp.Replace(txt, " ");

            // Split the text into words.
            string[] words = txt.Split(
                new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            // Use LINQ to get the unique words.
            var word_query =
                (from string word in words
                 orderby word
                 select word).Distinct();

            // Display the result.
            string[] result = word_query.ToArray();
            lstWords.DataSource = result;
            lblSummary.Text = result.Length + " words";
        }

        // Read the text contents of a Word file.
        private string GrabWordFileWords(string file_name)
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

            // Return the document's text.
            string result = word_doc.Content.Text;

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
            this.SuspendLayout();
            // 
            // lblSummary
            // 
            this.lblSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSummary.AutoSize = true;
            this.lblSummary.Location = new System.Drawing.Point(14, 239);
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
            this.lstWords.Location = new System.Drawing.Point(14, 67);
            this.lstWords.Name = "lstWords";
            this.lstWords.Size = new System.Drawing.Size(310, 160);
            this.lstWords.TabIndex = 10;
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(46, 12);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(249, 20);
            this.txtFile.TabIndex = 7;
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
            this.btnListWords.Location = new System.Drawing.Point(132, 38);
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
            this.btnPickFile.Image = Properties.Resources.Ellipsis;
            this.btnPickFile.Location = new System.Drawing.Point(301, 10);
            this.btnPickFile.Name = "btnPickFile";
            this.btnPickFile.Size = new System.Drawing.Size(23, 23);
            this.btnPickFile.TabIndex = 8;
            this.btnPickFile.UseVisualStyleBackColor = true;
            this.btnPickFile.Click += new System.EventHandler(this.btnPickFile_Click);
            // 
            // howto_list_word_file_words_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 261);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.lstWords);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnListWords);
            this.Controls.Add(this.btnPickFile);
            this.Name = "howto_list_word_file_words_Form1";
            this.Text = "howto_list_word_file_words";
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
    }
}

