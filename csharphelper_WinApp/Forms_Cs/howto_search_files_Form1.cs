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
     public partial class howto_search_files_Form1:Form
  { 


        public howto_search_files_Form1()
        {
            InitializeComponent();
        }

        // If we launched from the Send To menu,
        // use the argument as our directory.
        private void howto_search_files_Form1_Load(object sender, EventArgs e)
        {
            if (System.Environment.GetCommandLineArgs().Length > 1)
            {
                txtDirectory.Text = System.Environment.GetCommandLineArgs()[1];
                txtTarget.Focus();
            }
        }

        // Search.
        private void btnSearch_Click(object sender, EventArgs e)
        {
            lstResults.Items.Clear();
            DirectoryInfo dir_info = new DirectoryInfo(txtDirectory.Text);

            ListFiles(lstResults, cboPattern.Text, dir_info, txtTarget.Text);

            System.Media.SystemSounds.Beep.Play();
        }

        // Add the files in this directory's subtree 
        // that match the pattern to the ListBox.
        private void ListFiles(ListBox lst, string pattern, DirectoryInfo dir_info, string target)
        {
            // Get the files in this directory.
            FileInfo[] fs_infos = dir_info.GetFiles(pattern);
            foreach (FileInfo fs_info in fs_infos)
            {
                if (target.Length == 0)
                {
                    lstResults.Items.Add(fs_info.FullName);
                } 
                else
                {
                    string txt = File.ReadAllText(fs_info.FullName);
                    if (txt.IndexOf(target, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        lstResults.Items.Add(fs_info.FullName);
                    }
                }
            }

            // Search subdirectories.
            DirectoryInfo[] subdirs = dir_info.GetDirectories();
            foreach (DirectoryInfo subdir in subdirs)
            {
                ListFiles(lst, pattern, subdir, target);
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
            this.cboPattern = new System.Windows.Forms.ComboBox();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboPattern
            // 
            this.cboPattern.FormattingEnabled = true;
            this.cboPattern.Items.AddRange(new object[] {
            "*.vb",
            "*.cs",
            "*.txt",
            "*.*"});
            this.cboPattern.Location = new System.Drawing.Point(66, 40);
            this.cboPattern.Name = "cboPattern";
            this.cboPattern.Size = new System.Drawing.Size(121, 21);
            this.cboPattern.TabIndex = 1;
            this.cboPattern.Text = "*.*";
            // 
            // lstResults
            // 
            this.lstResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstResults.FormattingEnabled = true;
            this.lstResults.Location = new System.Drawing.Point(12, 142);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(400, 108);
            this.lstResults.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSearch.Location = new System.Drawing.Point(175, 104);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtTarget
            // 
            this.txtTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTarget.Location = new System.Drawing.Point(66, 66);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(346, 20);
            this.txtTarget.TabIndex = 2;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(12, 69);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(41, 13);
            this.Label3.TabIndex = 11;
            this.Label3.Text = "Target:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(12, 43);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(44, 13);
            this.Label2.TabIndex = 9;
            this.Label2.Text = "Pattern:";
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Location = new System.Drawing.Point(66, 14);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(346, 20);
            this.txtDirectory.TabIndex = 0;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 17);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(48, 13);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "Start Dir:";
            // 
            // howto_search_files_Form1
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 264);
            this.Controls.Add(this.cboPattern);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtTarget);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.Label1);
            this.Name = "howto_search_files_Form1";
            this.Text = "howto_search_files";
            this.Load += new System.EventHandler(this.howto_search_files_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox cboPattern;
        internal System.Windows.Forms.ListBox lstResults;
        internal System.Windows.Forms.Button btnSearch;
        internal System.Windows.Forms.TextBox txtTarget;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtDirectory;
        internal System.Windows.Forms.Label Label1;
    }
}

