using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_files_comments_Form1:Form
  { 


        public howto_files_comments_Form1()
        {
            InitializeComponent();
        }

        private string OutputFile = "";

        // Load the directory setting.
        private void howto_files_comments_Form1_Load(object sender, EventArgs e)
        {
            clbFiles.Sorted = true;
            clbFiles.CheckOnClick = true;
            clbFiles.HorizontalScrollbar = true;
            txtDirectory.Text = Properties.Settings.Default.Directory;
            cboPattern.Text = Properties.Settings.Default.Patterns;
            txtFilename.Text = Properties.Settings.Default.OutputFile;

            string app_path = System.Windows.Forms.Application.StartupPath;
            if (txtDirectory.Text.Length == 0)
                txtDirectory.Text = app_path;
            if (cboPattern.Text.Length == 0) cboPattern.SelectedIndex = 0;
            if (txtFilename.Text.Length == 0)
                txtFilename.Text = app_path + "\\Comments.txt";
        }

        // Save the directory setting.
        private void howto_files_comments_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Directory = txtDirectory.Text;
            Properties.Settings.Default.Patterns = cboPattern.Text;
            Properties.Settings.Default.OutputFile = txtFilename.Text;
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
            Cursor = Cursors.WaitCursor;

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
            Cursor = Cursors.Default;
        }

        // Check or uncheck all of the files.
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            bool is_checked = chkAll.Checked;
            for (int i = 0; i < clbFiles.Items.Count; i++)
                clbFiles.SetItemChecked(i, is_checked);
        }

        // Extract all of the files' comments.
        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            // Get the file name.
            OutputFile = txtFilename.Text.Trim();
            if (OutputFile.Length == 0)
            {
                MessageBox.Show("Please enter an output file name");
                return;
            }
            Cursor = Cursors.WaitCursor;
            lblNumProcessed.Text = "";
            lblNumProcessed.Visible = true;

            // Loop through the selected files and get their comments.
            int i = 0;
            HashSet<string> comments = new HashSet<string>();
            char[] separators = { '\r', '\n' };
            foreach (string input_file in clbFiles.CheckedItems)
            {
                lblNumProcessed.Text = i.ToString() + " files processed";
                lblNumProcessed.Refresh();
                i++;

                // Get this file's comments.
                string file_comments = ExtractComments(input_file);

                // Split the file's comments by line and
                // add new ones to the HashSet.
                foreach (string comment in
                    file_comments.Split(separators, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (!comments.Contains(comment)) comments.Add(comment);
                }
            }

            // Sort the comments.
            string[] lines = comments.ToArray();
            Array.Sort(lines);

            // Write the comments into the output file.
            File.WriteAllLines(OutputFile, lines);

            Cursor = Cursors.Default;
            lblNumProcessed.Visible = false;
            btnOpen.Enabled = true;
            MessageBox.Show("Saved " + lines.Length + " comments");
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

        // Return a file's comments.
        private string ExtractComments(string filename)
        {
            // Get the file's contents.
            string all_text = File.ReadAllText(filename);

            // Get rid of \" escape sequences.
            all_text = all_text.Replace("\\\"", "");

            // Process the file.
            string comments = "";
            while (all_text.Length > 0)
            {
                // Find the next string or comment.
                int string_pos = all_text.IndexOf("\"");
                int end_line_pos = all_text.IndexOf("//");
                int multi_line_pos = all_text.IndexOf("/*");

                // If there are none of these, we're done.
                if ((string_pos < 0) && (end_line_pos < 0) && (multi_line_pos < 0)) break;

                if (string_pos < 0) string_pos = all_text.Length;
                if (end_line_pos < 0) end_line_pos = all_text.Length;
                if (multi_line_pos < 0) multi_line_pos = all_text.Length;

                // See which comes first.
                if ((string_pos < end_line_pos) && (string_pos < multi_line_pos))
                {
                    // String.
                    // Find its end.
                    int end_pos = all_text.IndexOf("\"", string_pos + 1);

                    // Extract and discard everything up to the string.
                    if (end_pos < 0)
                    {
                        all_text = "";
                    }
                    else
                    {
                        all_text = all_text.Substring(end_pos + 1);
                    }
                }
                else if (end_line_pos < multi_line_pos)
                {
                    // End of line comment.
                    // Find its end.
                    int end_pos = all_text.IndexOf("\r\n", end_line_pos + 2);

                    // Extract the comment.
                    if (end_pos < 0)
                    {
                        comments += all_text.Substring(end_line_pos) + "\r\n";
                        all_text = "";
                    }
                    else
                    {
                        comments += all_text.Substring(end_line_pos, end_pos - end_line_pos) + "\r\n";
                        all_text = all_text.Substring(end_pos + 2);
                    }
                }
                else
                {
                    // Multi-line comment.
                    // Find its end.
                    int end_pos = all_text.IndexOf("*/", multi_line_pos + 2);

                    // Extract the comment.
                    if (end_pos < 0)
                    {
                        comments += all_text.Substring(multi_line_pos) + "\r\n";
                        all_text = "";
                    }
                    else
                    {
                        comments += all_text.Substring(multi_line_pos, end_pos - multi_line_pos + 2) + "\r\n";
                        all_text = all_text.Substring(end_pos + 2);
                    }
                }
            }

            return comments;
        }

        // Update the number of checked items.
        private void clbFiles_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int num_checked = clbFiles.CheckedItems.Count;
            if (e.NewValue == CheckState.Checked) num_checked++;
            else num_checked--;
            lblNumFiles.Text = num_checked.ToString() + " files selected";
        }

        // Open the created comment file.
        private void btnOpen_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(OutputFile);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_files_comments_Form1));
            this.chkIncludeSubdirectories = new System.Windows.Forms.CheckBox();
            this.btnCreateFile = new System.Windows.Forms.Button();
            this.clbFiles = new System.Windows.Forms.CheckedListBox();
            this.sfdWordDoc = new System.Windows.Forms.SaveFileDialog();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnListFiles = new System.Windows.Forms.Button();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPattern = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.fbdDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumFiles = new System.Windows.Forms.Label();
            this.lblNumProcessed = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkIncludeSubdirectories
            // 
            this.chkIncludeSubdirectories.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkIncludeSubdirectories.AutoSize = true;
            this.chkIncludeSubdirectories.Checked = true;
            this.chkIncludeSubdirectories.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeSubdirectories.Location = new System.Drawing.Point(112, 65);
            this.chkIncludeSubdirectories.Name = "chkIncludeSubdirectories";
            this.chkIncludeSubdirectories.Size = new System.Drawing.Size(131, 17);
            this.chkIncludeSubdirectories.TabIndex = 30;
            this.chkIncludeSubdirectories.Text = "Include Subdirectories";
            this.chkIncludeSubdirectories.UseVisualStyleBackColor = true;
            // 
            // btnCreateFile
            // 
            this.btnCreateFile.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCreateFile.Location = new System.Drawing.Point(121, 306);
            this.btnCreateFile.Name = "btnCreateFile";
            this.btnCreateFile.Size = new System.Drawing.Size(113, 23);
            this.btnCreateFile.TabIndex = 37;
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
            this.clbFiles.IntegralHeight = false;
            this.clbFiles.Location = new System.Drawing.Point(15, 140);
            this.clbFiles.Name = "clbFiles";
            this.clbFiles.Size = new System.Drawing.Size(327, 116);
            this.clbFiles.Sorted = true;
            this.clbFiles.TabIndex = 33;
            this.clbFiles.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbFiles_ItemCheck);
            // 
            // sfdWordDoc
            // 
            this.sfdWordDoc.Filter = "Word Documents|*.docx;*.doc";
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFile.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectFile.Image")));
            this.btnSelectFile.Location = new System.Drawing.Point(315, 281);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(27, 20);
            this.btnSelectFile.TabIndex = 38;
            this.btnSelectFile.TabStop = false;
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(18, 117);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(117, 17);
            this.chkAll.TabIndex = 34;
            this.chkAll.Text = "Select/Deselect All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // btnListFiles
            // 
            this.btnListFiles.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnListFiles.Location = new System.Drawing.Point(121, 88);
            this.btnListFiles.Name = "btnListFiles";
            this.btnListFiles.Size = new System.Drawing.Size(113, 23);
            this.btnListFiles.TabIndex = 32;
            this.btnListFiles.Text = "List Files";
            this.btnListFiles.UseVisualStyleBackColor = true;
            this.btnListFiles.Click += new System.EventHandler(this.btnListFiles_Click);
            // 
            // txtFilename
            // 
            this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilename.Location = new System.Drawing.Point(79, 280);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(230, 20);
            this.txtFilename.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Output File:";
            // 
            // cboPattern
            // 
            this.cboPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPattern.FormattingEnabled = true;
            this.cboPattern.Items.AddRange(new object[] {
            "C# Files (*.cs)",
            "All Files (*.*)"});
            this.cboPattern.Location = new System.Drawing.Point(70, 38);
            this.cboPattern.Name = "cboPattern";
            this.cboPattern.Size = new System.Drawing.Size(239, 21);
            this.cboPattern.TabIndex = 28;
            this.cboPattern.Text = "C# Files (*.cs)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Pattern:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowse.Image")));
            this.btnBrowse.Location = new System.Drawing.Point(315, 12);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(27, 20);
            this.btnBrowse.TabIndex = 29;
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
            this.txtDirectory.Size = new System.Drawing.Size(239, 20);
            this.txtDirectory.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Directory:";
            // 
            // lblNumFiles
            // 
            this.lblNumFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNumFiles.AutoSize = true;
            this.lblNumFiles.Location = new System.Drawing.Point(12, 259);
            this.lblNumFiles.Name = "lblNumFiles";
            this.lblNumFiles.Size = new System.Drawing.Size(77, 13);
            this.lblNumFiles.TabIndex = 39;
            this.lblNumFiles.Text = "0 files selected";
            // 
            // lblNumProcessed
            // 
            this.lblNumProcessed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumProcessed.AutoSize = true;
            this.lblNumProcessed.Location = new System.Drawing.Point(232, 259);
            this.lblNumProcessed.Name = "lblNumProcessed";
            this.lblNumProcessed.Size = new System.Drawing.Size(110, 13);
            this.lblNumProcessed.TabIndex = 40;
            this.lblNumProcessed.Text = "10000 files processed";
            this.lblNumProcessed.Visible = false;
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Enabled = false;
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.Location = new System.Drawing.Point(315, 307);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(27, 20);
            this.btnOpen.TabIndex = 41;
            this.btnOpen.TabStop = false;
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // howto_files_comments_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 341);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.lblNumProcessed);
            this.Controls.Add(this.lblNumFiles);
            this.Controls.Add(this.chkIncludeSubdirectories);
            this.Controls.Add(this.btnCreateFile);
            this.Controls.Add(this.clbFiles);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.btnListFiles);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboPattern);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.label1);
            this.Name = "howto_files_comments_Form1";
            this.Text = "howto_files_comments";
            this.Load += new System.EventHandler(this.howto_files_comments_Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_files_comments_Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkIncludeSubdirectories;
        private System.Windows.Forms.Button btnCreateFile;
        private System.Windows.Forms.CheckedListBox clbFiles;
        private System.Windows.Forms.SaveFileDialog sfdWordDoc;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btnListFiles;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboPattern;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.FolderBrowserDialog fbdDirectory;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNumFiles;
        private System.Windows.Forms.Label lblNumProcessed;
        private System.Windows.Forms.Button btnOpen;

    }
}

