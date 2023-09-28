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

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_list_file_words_Form1:Form
  { 


        public howto_list_file_words_Form1()
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
            string txt = File.ReadAllText(txtFile.Text);

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
                 orderby word select word).Distinct();
            
            // Display the result.
            string[] result = word_query.ToArray();
            lstWords.DataSource = result;
            lblSummary.Text = result.Length + " words";
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnPickFile = new System.Windows.Forms.Button();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.btnListWords = new System.Windows.Forms.Button();
            this.lstWords = new System.Windows.Forms.ListBox();
            this.lblSummary = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File:";
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(44, 12);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(249, 20);
            this.txtFile.TabIndex = 1;
            // 
            // btnPickFile
            // 
            this.btnPickFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickFile.Image = Properties.Resources.Ellipsis;
            this.btnPickFile.Location = new System.Drawing.Point(299, 10);
            this.btnPickFile.Name = "btnPickFile";
            this.btnPickFile.Size = new System.Drawing.Size(23, 23);
            this.btnPickFile.TabIndex = 2;
            this.btnPickFile.UseVisualStyleBackColor = true;
            this.btnPickFile.Click += new System.EventHandler(this.btnPickFile_Click);
            // 
            // ofdFile
            // 
            this.ofdFile.FileName = "openFileDialog1";
            // 
            // btnListWords
            // 
            this.btnListWords.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnListWords.Location = new System.Drawing.Point(130, 38);
            this.btnListWords.Name = "btnListWords";
            this.btnListWords.Size = new System.Drawing.Size(75, 23);
            this.btnListWords.TabIndex = 3;
            this.btnListWords.Text = "List Words";
            this.btnListWords.UseVisualStyleBackColor = true;
            this.btnListWords.Click += new System.EventHandler(this.btnListWords_Click);
            // 
            // lstWords
            // 
            this.lstWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstWords.FormattingEnabled = true;
            this.lstWords.IntegralHeight = false;
            this.lstWords.Location = new System.Drawing.Point(12, 67);
            this.lstWords.Name = "lstWords";
            this.lstWords.Size = new System.Drawing.Size(310, 182);
            this.lstWords.TabIndex = 4;
            // 
            // lblSummary
            // 
            this.lblSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSummary.AutoSize = true;
            this.lblSummary.Location = new System.Drawing.Point(12, 239);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(0, 13);
            this.lblSummary.TabIndex = 5;
            // 
            // howto_list_file_words_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 261);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.lstWords);
            this.Controls.Add(this.btnListWords);
            this.Controls.Add(this.btnPickFile);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label1);
            this.Name = "howto_list_file_words_Form1";
            this.Text = "howto_list_file_words";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnPickFile;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.Button btnListWords;
        private System.Windows.Forms.ListBox lstWords;
        private System.Windows.Forms.Label lblSummary;
    }
}

