using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using Word = Microsoft.Office.Interop.Word;

// Add a reference to the Word library.
// I used: Microsoft.Office.Interop.Word 12.0.0.0

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_convert_doc_to_docx_Form1:Form
  { 


        public howto_convert_doc_to_docx_Form1()
        {
            InitializeComponent();
        }

        // Start in the executable directory.
        private void howto_convert_doc_to_docx_Form1_Load(object sender, EventArgs e)
        {
            txtDirectory.Text = Application.StartupPath;
        }

        // Let the user browse for a folder.
        private void btnBrowseForDirectory_Click(object sender, EventArgs e)
        {
            fbdSourceDirectory.SelectedPath = txtDirectory.Text;
            if (fbdSourceDirectory.ShowDialog() == DialogResult.OK)
            {
                txtDirectory.Text = fbdSourceDirectory.SelectedPath;
            }
        }

        // Convert the files in the directory.
        private void btnConvert_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            // Open the Word server.
            Word._Application word_app = new Word.ApplicationClass();

            // Make a couple of objects used inside and outside of the loop.
            object missing = System.Reflection.Missing.Value;
            object save_changes = false;

            // Loop through the files.
            int num_converted = 0;
            lstFiles.Items.Clear();
            DirectoryInfo dir_info = new DirectoryInfo(txtDirectory.Text);
            foreach (FileInfo file_info in dir_info.GetFiles("*.doc"))
            {
                // Skip .docx files.
                if (file_info.Extension.ToLower() == ".docx") continue;

                // Get the converted file's name.
                int name_length = file_info.FullName.Length - file_info.Extension.Length;
                string new_filename = file_info.FullName.Substring(0, name_length) + ".docx";

                // See if this file has already been converted.
                if (File.Exists(new_filename))
                {
                    lstFiles.Items.Add("Skipped " + file_info.Name);
                }
                else
                {
                    lstFiles.Items.Add("Converted " + file_info.Name);
                    num_converted++;

                    // Open the file.
                    object filename = file_info.FullName;
                    object confirm_conversions = false;
                    object read_only = true;
                    object add_to_recent_files = false;
                    object format = 0;
                    Word._Document word_doc =
                        word_app.Documents.Open(ref filename, ref confirm_conversions,
                            ref read_only, ref add_to_recent_files,
                            ref missing, ref missing, ref missing, ref missing,
                            ref missing, ref format, ref missing, ref missing,
                            ref missing, ref missing, ref missing, ref missing);

                    // Save as a .docx file.
                    filename = new_filename;
                    object file_format = Word.WdSaveFormat.wdFormatDocumentDefault;
                    word_doc.SaveAs(ref filename, ref file_format, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing);

                    // Close the document without prompting.
                    word_doc.Close(ref save_changes, ref missing, ref missing);
                }
            }

            // Close the word application.
            word_app.Quit(ref save_changes, ref missing, ref missing);

            int num_skipped = lstFiles.Items.Count - num_converted;
            MessageBox.Show("Converted " + num_converted.ToString() + " files.\n" +
                "Skipped " + num_skipped.ToString() + " files.",
                "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Cursor = Cursors.Default;
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
            this.fbdSourceDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnBrowseForDirectory = new System.Windows.Forms.Button();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fbdSourceDirectory
            // 
            this.fbdSourceDirectory.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // lstFiles
            // 
            this.lstFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.IntegralHeight = false;
            this.lstFiles.Location = new System.Drawing.Point(12, 68);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(310, 181);
            this.lstFiles.TabIndex = 9;
            // 
            // btnConvert
            // 
            this.btnConvert.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnConvert.Location = new System.Drawing.Point(130, 39);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 8;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnBrowseForDirectory
            // 
            this.btnBrowseForDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseForDirectory.Image = Properties.Resources.Ellipsis;
            this.btnBrowseForDirectory.Location = new System.Drawing.Point(296, 13);
            this.btnBrowseForDirectory.Name = "btnBrowseForDirectory";
            this.btnBrowseForDirectory.Size = new System.Drawing.Size(26, 20);
            this.btnBrowseForDirectory.TabIndex = 7;
            this.btnBrowseForDirectory.UseVisualStyleBackColor = true;
            this.btnBrowseForDirectory.Click += new System.EventHandler(this.btnBrowseForDirectory_Click);
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Location = new System.Drawing.Point(70, 13);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(220, 20);
            this.txtDirectory.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Directory:";
            // 
            // howto_convert_doc_to_docx_Form1
            // 
            this.AcceptButton = this.btnConvert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 261);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnBrowseForDirectory);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.label1);
            this.Name = "howto_convert_doc_to_docx_Form1";
            this.Text = "howto_convert_doc_to_docx";
            this.Load += new System.EventHandler(this.howto_convert_doc_to_docx_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fbdSourceDirectory;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnBrowseForDirectory;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Label label1;
    }
}

