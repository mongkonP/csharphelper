using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Open the Add Reference dialog and on the COM tab add a reference to 
// "Microsoft Word 14.0 Object Library" (or whatever version you have
// installed on your system). 
using Word = Microsoft.Office.Interop.Word;
using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_load_word_pictures_Form1:Form
  { 


        public howto_load_word_pictures_Form1()
        {
            InitializeComponent();
        }

        // Load the directory setting.
        private void howto_load_word_pictures_Form1_Load(object sender, EventArgs e)
        {
            clbFiles.Sorted = true;
            clbFiles.CheckOnClick = true;
            clbFiles.HorizontalScrollbar = true;
            txtDirectory.Text = Properties.Settings.Default.Directory;
            cboPattern.Text = Properties.Settings.Default.Patterns;
            txtFilename.Text = Properties.Settings.Default.WordFile;

            if (txtDirectory.Text.Length == 0)
                txtDirectory.Text = Application.StartupPath;
            if (cboPattern.Text.Length == 0) cboPattern.SelectedIndex = 0;
            if (txtFilename.Text.Length == 0)
                txtFilename.Text = Application.StartupPath + "\\Pictures.docx";
        }

        // Save the directory setting.
        private void howto_load_word_pictures_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Directory = txtDirectory.Text;
            Properties.Settings.Default.Patterns = cboPattern.Text;
            Properties.Settings.Default.WordFile = txtFilename.Text;
            Properties.Settings.Default.Save();
        }

        // Let the user select a folder.
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            fbdDirectory.SelectedPath = txtDirectory.Text;
            if (fbdDirectory.ShowDialog() == DialogResult.OK)
            {
                txtDirectory.Text = fbdDirectory.SelectedPath;
            }
        }

        // List files that match the pattern.
        private void btnListFiles_Click(object sender, EventArgs e)
        {
            // Get the directory.
            string path = txtDirectory.Text.Trim();
            if (path.Length == 0)
            {
                MessageBox.Show("Please enter a directory name");
                return;
            }

            // Get the file pattern text without parentheses.
            string pattern_text = cboPattern.Text;
            if (pattern_text.Contains("("))
            {
                int pos1 = pattern_text.IndexOf("(");
                int pos2 = pattern_text.IndexOf(")");
                pattern_text = pattern_text.Substring(pos1 + 1, pos2 - pos1 - 1);
            }

            // Get individual file matching patterns.
            List<string> patterns = new List<string>();
            foreach (string pattern in pattern_text.Split(
                new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                patterns.Add(pattern.Trim());
            }

            // Get the files.
            SearchOption search_option = SearchOption.TopDirectoryOnly;
            if (chkIncludeSubdirectories.Checked)
                search_option = SearchOption.AllDirectories;
            clbFiles.Items.Clear();
            chkAll.Checked = false;
            foreach (string pattern in patterns)
            {
                // Get files matching this pattern.
                foreach (string filename in
                    Directory.GetFiles(path, pattern, search_option))
                {
                    // See if we not yet listed this file.
                    if (!clbFiles.Items.Contains(filename))
                    {
                        // Add the filename to the list.
                        clbFiles.Items.Add(filename);
                    }
                }
            }

            // Initially select all files.
            chkAll.Checked = true;
        }

        // Check or uncheck all of the files.
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            bool is_checked = chkAll.Checked;
            for (int i = 0; i < clbFiles.Items.Count; i++)
                clbFiles.SetItemChecked(i, is_checked);
        }

        // Create the Word document.
        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            // Get the file name.
            string filename = txtFilename.Text.Trim();
            if (filename.Length == 0)
            {
                MessageBox.Show("Please enter a document name");
                return;
            }

            // Get the Word application object.
            Word._Application word_app = new Word.ApplicationClass();

            // Make Word visible (optional).
            word_app.Visible = true;

            // Create the Word document.
            object missing = Type.Missing;
            Word._Document word_doc = word_app.Documents.Add(
                ref missing, ref missing, ref missing, ref missing);

            // Add the image files.
            Word.Paragraph para;
            foreach (string picture_file in clbFiles.CheckedItems)
            {
                // Make a paragraph.
                para = word_doc.Paragraphs.Add(ref missing);

                // Add the picture to the paragraph.
                Word.InlineShape inline_shape = para.Range.InlineShapes.AddPicture(
                    picture_file, ref missing, ref missing, ref missing);

                // Format the picture.
                Word.Shape shape = inline_shape.ConvertToShape();

                // Scale uniformly by 50%.
                shape.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoTrue;
                shape.ScaleHeight(0.5f, Microsoft.Office.Core.MsoTriState.msoTrue,
                    Microsoft.Office.Core.MsoScaleFrom.msoScaleFromTopLeft);
                shape.WrapFormat.Type = Word.WdWrapType.wdWrapInline;

                // Add the file's name.
                para.Range.InsertParagraphAfter();
                para.Range.InsertAfter(picture_file);
            }

            // Save the document.
            object filename_obj = filename;
            word_doc.SaveAs(ref filename_obj, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing);

            // Close.
            object save_changes = false;
            word_doc.Close(ref save_changes, ref missing, ref missing);
            word_app.Quit(ref save_changes, ref missing, ref missing);

            MessageBox.Show("Done");
        }

        // Let the user sleect the Word document.
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            sfdWordDoc.FileName = txtFilename.Text;
            if (sfdWordDoc.ShowDialog() == DialogResult.OK)
            {
                txtFilename.Text = sfdWordDoc.FileName;
            }
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
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.fbdDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.chkIncludeSubdirectories = new System.Windows.Forms.CheckBox();
            this.btnCreateFile = new System.Windows.Forms.Button();
            this.clbFiles = new System.Windows.Forms.CheckedListBox();
            this.btnListFiles = new System.Windows.Forms.Button();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sfdWordDoc = new System.Windows.Forms.SaveFileDialog();
            this.cboPattern = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFile.Image = Properties.Resources.EllipsisTransparent;
            this.btnSelectFile.Location = new System.Drawing.Point(283, 281);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(27, 20);
            this.btnSelectFile.TabIndex = 25;
            this.btnSelectFile.TabStop = false;
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(15, 97);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(15, 14);
            this.chkAll.TabIndex = 21;
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkIncludeSubdirectories
            // 
            this.chkIncludeSubdirectories.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkIncludeSubdirectories.AutoSize = true;
            this.chkIncludeSubdirectories.Location = new System.Drawing.Point(96, 65);
            this.chkIncludeSubdirectories.Name = "chkIncludeSubdirectories";
            this.chkIncludeSubdirectories.Size = new System.Drawing.Size(131, 17);
            this.chkIncludeSubdirectories.TabIndex = 17;
            this.chkIncludeSubdirectories.Text = "Include Subdirectories";
            this.chkIncludeSubdirectories.UseVisualStyleBackColor = true;
            // 
            // btnCreateFile
            // 
            this.btnCreateFile.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCreateFile.Location = new System.Drawing.Point(105, 308);
            this.btnCreateFile.Name = "btnCreateFile";
            this.btnCreateFile.Size = new System.Drawing.Size(113, 23);
            this.btnCreateFile.TabIndex = 24;
            this.btnCreateFile.Text = "Create Document";
            this.btnCreateFile.UseVisualStyleBackColor = true;
            this.btnCreateFile.Click += new System.EventHandler(this.btnCreateFile_Click);
            // 
            // clbFiles
            // 
            this.clbFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.clbFiles.FormattingEnabled = true;
            this.clbFiles.Location = new System.Drawing.Point(15, 117);
            this.clbFiles.Name = "clbFiles";
            this.clbFiles.Size = new System.Drawing.Size(295, 154);
            this.clbFiles.Sorted = true;
            this.clbFiles.TabIndex = 20;
            // 
            // btnListFiles
            // 
            this.btnListFiles.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnListFiles.Location = new System.Drawing.Point(105, 88);
            this.btnListFiles.Name = "btnListFiles";
            this.btnListFiles.Size = new System.Drawing.Size(113, 23);
            this.btnListFiles.TabIndex = 19;
            this.btnListFiles.Text = "List Files";
            this.btnListFiles.UseVisualStyleBackColor = true;
            this.btnListFiles.Click += new System.EventHandler(this.btnListFiles_Click);
            // 
            // txtFilename
            // 
            this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilename.Location = new System.Drawing.Point(79, 282);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(198, 20);
            this.txtFilename.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Output File:";
            // 
            // sfdWordDoc
            // 
            this.sfdWordDoc.Filter = "Word Documents|*.docx;*.doc";
            // 
            // cboPattern
            // 
            this.cboPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPattern.FormattingEnabled = true;
            this.cboPattern.Items.AddRange(new object[] {
            "Picture Files (*.png; *.jpg; *.gif; *.bmp)",
            "PNG (*.png)",
            "JPEG (*.jpg)",
            "GIF (*.gif)",
            "BMP (*.bmp)",
            "All Files (*.*)"});
            this.cboPattern.Location = new System.Drawing.Point(70, 38);
            this.cboPattern.Name = "cboPattern";
            this.cboPattern.Size = new System.Drawing.Size(207, 21);
            this.cboPattern.TabIndex = 15;
            this.cboPattern.Text = "Picture Files (*.png; *.jpg; *.gif; *.bmp)\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Pattern:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Image = Properties.Resources.EllipsisTransparent;
            this.btnBrowse.Location = new System.Drawing.Point(283, 12);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(27, 20);
            this.btnBrowse.TabIndex = 16;
            this.btnBrowse.TabStop = false;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Location = new System.Drawing.Point(70, 12);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(207, 20);
            this.txtDirectory.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Directory:";
            // 
            // howto_load_word_pictures_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 343);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.chkIncludeSubdirectories);
            this.Controls.Add(this.btnCreateFile);
            this.Controls.Add(this.clbFiles);
            this.Controls.Add(this.btnListFiles);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboPattern);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.label1);
            this.Name = "howto_load_word_pictures_Form1";
            this.Text = "howto_load_word_pictures";
            this.Load += new System.EventHandler(this.howto_load_word_pictures_Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_load_word_pictures_Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.FolderBrowserDialog fbdDirectory;
        private System.Windows.Forms.CheckBox chkIncludeSubdirectories;
        private System.Windows.Forms.Button btnCreateFile;
        private System.Windows.Forms.CheckedListBox clbFiles;
        private System.Windows.Forms.Button btnListFiles;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SaveFileDialog sfdWordDoc;
        private System.Windows.Forms.ComboBox cboPattern;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Label label1;
    }
}

