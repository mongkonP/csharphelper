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
     public partial class howto_get_files_multiple_patterns_Form1:Form
  { 


        public howto_get_files_multiple_patterns_Form1()
        {
            InitializeComponent();
        }

        // Start in the source directory.
        private void howto_get_files_multiple_patterns_Form1_Load(object sender, EventArgs e)
        {
            DirectoryInfo dir_info = new DirectoryInfo(
                Path.Combine(Application.StartupPath, "..\\..\\"));
            txtDirectory.Text = dir_info.FullName;
        }

        // Search for the files.
        private void btnGo_Click(object sender, EventArgs e)
        {
            List<string> filenames = FindFiles(
                txtDirectory.Text, txtPatterns.Text, chkSearchSubdirectories.Checked);
            lstFiles.Items.Clear();
            foreach (string filename in filenames)
            {
                lstFiles.Items.Add(filename);
            }
        }

        // Search for files matching the patterns.
        private List<string> FindFiles(string dir_name, string patterns, bool search_subdirectories)
        {
            // Make the result list.
            List<string> files = new List<string>();

            // Get the patterns.
            string[] pattern_array = patterns.Split(';');

            // Search.
            SearchOption search_option = SearchOption.TopDirectoryOnly;
            if (search_subdirectories) search_option = SearchOption.AllDirectories;
            foreach (string pattern in pattern_array)
            {
                foreach (string filename in Directory.GetFiles(dir_name, pattern, search_option))
                {
                    if (!files.Contains(filename)) files.Add(filename);
                }
            }

            // Sort.
            files.Sort();

            // Return the result.
            return files;
        }

        // Let the user select a directory.
        private void btnPickDirectory_Click(object sender, EventArgs e)
        {
            fbdDirectory.SelectedPath = txtDirectory.Text;
            if (fbdDirectory.ShowDialog() == DialogResult.OK)
            {
                txtDirectory.Text = fbdDirectory.SelectedPath;
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
            this.btnPickDirectory = new System.Windows.Forms.Button();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPatterns = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.fbdDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.chkSearchSubdirectories = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnPickDirectory
            // 
            this.btnPickDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPickDirectory.Image = Properties.Resources.Ellipsis;
            this.btnPickDirectory.Location = new System.Drawing.Point(340, 10);
            this.btnPickDirectory.Name = "btnPickDirectory";
            this.btnPickDirectory.Size = new System.Drawing.Size(23, 23);
            this.btnPickDirectory.TabIndex = 4;
            this.btnPickDirectory.UseVisualStyleBackColor = true;
            this.btnPickDirectory.Click += new System.EventHandler(this.btnPickDirectory_Click);
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Location = new System.Drawing.Point(70, 12);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(264, 20);
            this.txtDirectory.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Directory:";
            // 
            // txtPatterns
            // 
            this.txtPatterns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPatterns.Location = new System.Drawing.Point(70, 38);
            this.txtPatterns.Name = "txtPatterns";
            this.txtPatterns.Size = new System.Drawing.Size(264, 20);
            this.txtPatterns.TabIndex = 6;
            this.txtPatterns.Text = "*.cs;*.sln";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Patterns:";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGo.Location = new System.Drawing.Point(150, 87);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 7;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lstFiles
            // 
            this.lstFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.HorizontalScrollbar = true;
            this.lstFiles.Location = new System.Drawing.Point(15, 119);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(348, 134);
            this.lstFiles.TabIndex = 8;
            // 
            // chkSearchSubdirectories
            // 
            this.chkSearchSubdirectories.AutoSize = true;
            this.chkSearchSubdirectories.Location = new System.Drawing.Point(70, 64);
            this.chkSearchSubdirectories.Name = "chkSearchSubdirectories";
            this.chkSearchSubdirectories.Size = new System.Drawing.Size(130, 17);
            this.chkSearchSubdirectories.TabIndex = 9;
            this.chkSearchSubdirectories.Text = "Search Subdirectories";
            this.chkSearchSubdirectories.UseVisualStyleBackColor = true;
            // 
            // howto_get_files_multiple_patterns_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 264);
            this.Controls.Add(this.chkSearchSubdirectories);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtPatterns);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPickDirectory);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.label1);
            this.Name = "howto_get_files_multiple_patterns_Form1";
            this.Text = "howto_get_files_multiple_patterns";
            this.Load += new System.EventHandler(this.howto_get_files_multiple_patterns_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPickDirectory;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPatterns;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.FolderBrowserDialog fbdDirectory;
        private System.Windows.Forms.CheckBox chkSearchSubdirectories;
    }
}

