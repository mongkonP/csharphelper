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
     public partial class howto_recursive_replace_Form1:Form
  { 


        public howto_recursive_replace_Form1()
        {
            InitializeComponent();
        }

        // Restore previous settings.
        private void howto_recursive_replace_Form1_Load(object sender, EventArgs e)
        {
            txtStartDirectory.Text = Properties.Settings.Default.StartDirectory;
            cboPattern.Text = Properties.Settings.Default.Pattern;
        }

        // Save current settings.
        private void howto_recursive_replace_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.StartDirectory = txtStartDirectory.Text;
            Properties.Settings.Default.Pattern = cboPattern.Text;
            Properties.Settings.Default.Save();
        }

        // Let the user browse for a start directory.
        private void btnPickStartDirectory_Click(object sender, EventArgs e)
        {
            fbdStartDirectory.SelectedPath = txtStartDirectory.Text;
            if (fbdStartDirectory.ShowDialog() == DialogResult.OK)
            {
                txtStartDirectory.Text = fbdStartDirectory.SelectedPath;
            }
        }

        // If it's Ctrl+A, select all of the control's text.
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                TextBox txt = sender as TextBox;
                txt.SelectAll();
                e.Handled = true;
            }
        }

        // Find files matching the pattern that contain the target string.
        // If the button is the Find and Replace button, make replacements.
        private void btnFind_Click(object sender, EventArgs e)
        {
            SearchForFiles(lstFiles, txtStartDirectory.Text,
                cboPattern.Text, txtFind.Text, null);
        }
        private void btnFindAndReplace_Click(object sender, EventArgs e)
        {
            SearchForFiles(lstFiles, txtStartDirectory.Text,
                cboPattern.Text, txtFind.Text, txtReplaceWith.Text);
        }

        // Find files matching the pattern that contain the target string
        // and make the replacement if appropriate.
        private void SearchForFiles(ListBox lst, string start_dir,
            string pattern, string from_string, string to_string)
        {
            try
            {
                // Clear the result ListBox.
                lstFiles.Items.Clear();

                // Parse the patterns.
                string[] patterns = ParsePatterns(pattern);

                // If from_string is blank, don't replace.
                if (from_string.Length < 1) from_string = null;

                DirectoryInfo dir_info = new DirectoryInfo(start_dir);
                SearchDirectory(lst, dir_info, patterns, from_string, to_string);

                if (from_string == null)
                {
                    MessageBox.Show("Found " + lst.Items.Count + " files.");
                }
                else
                {
                    MessageBox.Show("Made replacements in " + lst.Items.Count + " files.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Find files matching the pattern that contain the target string
        // and make the replacement if appropriate.
        private void SearchDirectory(ListBox lst, DirectoryInfo dir_info,
            string[] patterns, string from_string, string to_string)
        {
            // Search this directory.
            foreach (string pattern in patterns)
            {
                // Check this pattern.
                foreach (FileInfo file_info in dir_info.GetFiles(pattern))
                {
                    // Process this file.
                    ProcessFile(lst, file_info, from_string, to_string);
                }
            }

            // Search subdirectories.
            foreach (DirectoryInfo subdir_info in dir_info.GetDirectories())
            {
                SearchDirectory(lst, subdir_info, patterns, from_string, to_string);
            }
        }

        // Replace all occurrences of from_string with to_string.
        // Return true if there was a problem and we should stop.
        private void ProcessFile(ListBox lst, FileInfo file_info, string from_string, string to_string)
        {
            try
            {
                if (from_string == null)
                {
                    // Add the file to the list.
                    lst.Items.Add(file_info.FullName);
                }
                else
                {
                    // See if the file contains from_string.
                    string txt = File.ReadAllText(file_info.FullName);
                    if (txt.Contains(from_string))
                    {
                        // Add the file to the list.
                        lst.Items.Add(file_info.FullName);

                        // See if we should make a replacement.
                        if (to_string != null)
                        {
                            File.WriteAllText(file_info.FullName,
                                txt.Replace(from_string, to_string));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing file " +
                    file_info.FullName + "\n" + ex.Message);
            }
        }

        // Take whatever is between parentheses (if there are any),
        // separate them, and return them in an array.
        private string[] ParsePatterns(string pattern_string)
        {
            // Take whatever is between the parentheses (if there are any).
            if (pattern_string.Contains("("))
            {
                pattern_string = TextBetween(pattern_string, "(", ")");
            }

            // Split the string at semi-colons.
            string[] result = pattern_string.Split(';');

            // Trim all of the patterns to remove extra space.
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = result[i].Trim();
            }

            return result;
        }

        // Get the text between two delimiters.
        // Let the code throw an error if a delimiter is not found.
        private string TextBetween(string txt, string delimiter1, string delimiter2)
        {
            // Find the starting delimiter.
            int pos1 = txt.IndexOf(delimiter1);
            int text_start = pos1 + delimiter1.Length;
            int pos2 = txt.IndexOf(delimiter2, text_start);
            return txt.Substring(text_start, pos2 - text_start);
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
            this.txtStartDirectory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReplaceWith = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnPickStartDirectory = new System.Windows.Forms.Button();
            this.cboPattern = new System.Windows.Forms.ComboBox();
            this.fbdStartDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.btnFindAndReplace = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start Directory:";
            // 
            // txtStartDirectory
            // 
            this.txtStartDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartDirectory.Location = new System.Drawing.Point(95, 12);
            this.txtStartDirectory.Name = "txtStartDirectory";
            this.txtStartDirectory.Size = new System.Drawing.Size(682, 20);
            this.txtStartDirectory.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "File Pattern:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtFind);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtReplaceWith);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Size = new System.Drawing.Size(230, 361);
            this.splitContainer1.SplitterDistance = 190;
            this.splitContainer1.TabIndex = 4;
            this.splitContainer1.TabStop = false;
            // 
            // txtFind
            // 
            this.txtFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFind.Location = new System.Drawing.Point(0, 13);
            this.txtFind.Multiline = true;
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(230, 177);
            this.txtFind.TabIndex = 0;
            this.txtFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Find:";
            // 
            // txtReplaceWith
            // 
            this.txtReplaceWith.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReplaceWith.Location = new System.Drawing.Point(0, 13);
            this.txtReplaceWith.Multiline = true;
            this.txtReplaceWith.Name = "txtReplaceWith";
            this.txtReplaceWith.Size = new System.Drawing.Size(230, 154);
            this.txtReplaceWith.TabIndex = 0;
            this.txtReplaceWith.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Replace With:";
            // 
            // btnFind
            // 
            this.btnFind.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnFind.Location = new System.Drawing.Point(301, 432);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(93, 23);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "&Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnPickStartDirectory
            // 
            this.btnPickStartDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickStartDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPickStartDirectory.Image = Properties.Resources.Ellipsis;
            this.btnPickStartDirectory.Location = new System.Drawing.Point(783, 10);
            this.btnPickStartDirectory.Name = "btnPickStartDirectory";
            this.btnPickStartDirectory.Size = new System.Drawing.Size(23, 23);
            this.btnPickStartDirectory.TabIndex = 5;
            this.btnPickStartDirectory.UseVisualStyleBackColor = true;
            this.btnPickStartDirectory.Click += new System.EventHandler(this.btnPickStartDirectory_Click);
            // 
            // cboPattern
            // 
            this.cboPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPattern.FormattingEnabled = true;
            this.cboPattern.Items.AddRange(new object[] {
            "HTML (*.htm;*.html)",
            "Text (*.txt)",
            "All Files (*.*)",
            "C# files (*.cs)",
            "VB .NET modules (*.vb)",
            "VB 6 Forms (*.frm)",
            "VB 6 Modules (*.bas)",
            "VB 6 Classes (*.cls)",
            "All VB Files (*.frm;*.bas;*.cls, *.vb)",
            "C Header Files (*.h)",
            "All C Files (*.h;*.cpp;*.cxx)"});
            this.cboPattern.Location = new System.Drawing.Point(95, 38);
            this.cboPattern.Name = "cboPattern";
            this.cboPattern.Size = new System.Drawing.Size(682, 21);
            this.cboPattern.TabIndex = 1;
            this.cboPattern.Text = "HTML (*.htm;*.html)";
            // 
            // fbdStartDirectory
            // 
            this.fbdStartDirectory.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // btnFindAndReplace
            // 
            this.btnFindAndReplace.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnFindAndReplace.Location = new System.Drawing.Point(424, 432);
            this.btnFindAndReplace.Name = "btnFindAndReplace";
            this.btnFindAndReplace.Size = new System.Drawing.Size(93, 23);
            this.btnFindAndReplace.TabIndex = 4;
            this.btnFindAndReplace.Text = "Find && &Replace";
            this.btnFindAndReplace.UseVisualStyleBackColor = true;
            this.btnFindAndReplace.Click += new System.EventHandler(this.btnFindAndReplace_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(15, 65);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lstFiles);
            this.splitContainer2.Panel2.Controls.Add(this.label5);
            this.splitContainer2.Size = new System.Drawing.Size(791, 361);
            this.splitContainer2.SplitterDistance = 230;
            this.splitContainer2.TabIndex = 2;
            this.splitContainer2.TabStop = false;
            // 
            // lstFiles
            // 
            this.lstFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.HorizontalScrollbar = true;
            this.lstFiles.IntegralHeight = false;
            this.lstFiles.Location = new System.Drawing.Point(0, 13);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(557, 348);
            this.lstFiles.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Files:";
            // 
            // howto_recursive_replace_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 467);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.btnFindAndReplace);
            this.Controls.Add(this.cboPattern);
            this.Controls.Add(this.btnPickStartDirectory);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStartDirectory);
            this.Controls.Add(this.label1);
            this.Name = "howto_recursive_replace_Form1";
            this.Text = "howto_recursive_replace";
            this.Load += new System.EventHandler(this.howto_recursive_replace_Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_recursive_replace_Form1_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStartDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtReplaceWith;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnPickStartDirectory;
        private System.Windows.Forms.ComboBox cboPattern;
        private System.Windows.Forms.FolderBrowserDialog fbdStartDirectory;
        private System.Windows.Forms.Button btnFindAndReplace;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Label label5;
    }
}

