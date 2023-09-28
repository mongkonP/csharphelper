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
     public partial class howto_search_dropbox_Form1:Form
  { 


        public howto_search_dropbox_Form1()
        {
            InitializeComponent();
        }

        // Set the default dropbox directory.
        private void howto_search_dropbox_Form1_Load(object sender, EventArgs e)
        {
            string home = Environment.GetEnvironmentVariable("USERPROFILE");
            txtStart.Text = Path.Combine(home, "Dropbox");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            trvFiles.Nodes.Clear();
            SearchDir(trvFiles.Nodes, txtStart.Text);
        }

        // List the files and subdirectories of this directory.
        private void SearchDir(TreeNodeCollection nodes, string dir_name)
        {
            TreeNode dir_node = nodes.Add(dir_name);
            foreach (string filename in Directory.GetFiles(dir_name))
                dir_node.Nodes.Add(filename);
            foreach (string subdir in Directory.GetDirectories(dir_name))
                SearchDir(dir_node.Nodes, subdir);
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
            this.trvFiles = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // trvFiles
            // 
            this.trvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trvFiles.Location = new System.Drawing.Point(12, 41);
            this.trvFiles.Name = "trvFiles";
            this.trvFiles.Size = new System.Drawing.Size(408, 208);
            this.trvFiles.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start:";
            // 
            // txtStart
            // 
            this.txtStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStart.Location = new System.Drawing.Point(50, 14);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(289, 20);
            this.txtStart.TabIndex = 2;
            this.txtStart.Text = "c:\\users\\rod\\dropbox";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(345, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // howto_search_dropbox_Form1
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 261);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trvFiles);
            this.Name = "howto_search_dropbox_Form1";
            this.Text = "howto_search_dropbox";
            this.Load += new System.EventHandler(this.howto_search_dropbox_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView trvFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.Button btnSearch;

    }
}

