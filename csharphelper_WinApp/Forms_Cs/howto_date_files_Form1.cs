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
     public partial class howto_date_files_Form1:Form
  { 


        public howto_date_files_Form1()
        {
            InitializeComponent();
        }

        private void howto_date_files_Form1_Load(object sender, EventArgs e)
        {
            clbRenames.CheckOnClick = true;
        }

        // List the renames that we will perform.
        private void btnSearch_Click(object sender, EventArgs e)
        {
            clbRenames.Items.Clear();

            Directory.SetCurrentDirectory(txtDirectory.Text);

            List<string> new_names = new List<string>();
            string prefix = txtPrefix.Text;
            string format = txtFormat.Text;
            foreach (string filename in Directory.GetFiles(txtDirectory.Text))
            {
                // Get the file's creation date.
                FileInfo file_info = new FileInfo(filename);
                DateTime date = file_info.LastWriteTime.Date;
                string new_name = prefix + date.ToString(format) + file_info.Extension;

                int i = 1;
                while (new_names.Contains(new_name))
                {
                    new_name = prefix + date.ToString(format) +
                        " (" + i.ToString() + ")" + file_info.Extension;
                    i++;
                }
                new_names.Add(new_name);

                clbRenames.Items.Add(file_info.Name + " -> " + new_name);
            }
        }

        // Rename the files.
        private void btnRename_Click(object sender, EventArgs e)
        {
            foreach (object command in clbRenames.CheckedItems)
            {
                string rename = command as string;
                string[] separators = { " -> " };
                string[] names = rename.Split(separators,
                    StringSplitOptions.RemoveEmptyEntries);
                File.Move(names[0], names[1]);
            }

            int num_files = clbRenames.CheckedItems.Count;
            MessageBox.Show("Renamed " + num_files.ToString() + " files");
            clbRenames.Items.Clear();
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbRenames.Items.Count; i++)
                clbRenames.SetItemCheckState(i, CheckState.Checked);
        }

        private void btnUncheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbRenames.Items.Count; i++)
                clbRenames.SetItemCheckState(i, CheckState.Unchecked);
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
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFormat = new System.Windows.Forms.TextBox();
            this.btnRename = new System.Windows.Forms.Button();
            this.clbRenames = new System.Windows.Forms.CheckedListBox();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.btnUncheckAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Directory:";
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Location = new System.Drawing.Point(86, 12);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(186, 20);
            this.txtDirectory.TabIndex = 1;
            // 
            // txtPrefix
            // 
            this.txtPrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrefix.Location = new System.Drawing.Point(86, 38);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(186, 20);
            this.txtPrefix.TabIndex = 3;
            this.txtPrefix.Text = "File ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Prefix:";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSearch.Location = new System.Drawing.Point(105, 90);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Date Format:";
            // 
            // txtFormat
            // 
            this.txtFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFormat.Location = new System.Drawing.Point(86, 64);
            this.txtFormat.Name = "txtFormat";
            this.txtFormat.Size = new System.Drawing.Size(186, 20);
            this.txtFormat.TabIndex = 6;
            this.txtFormat.Text = "MM-dd-yy";
            // 
            // btnRename
            // 
            this.btnRename.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRename.Location = new System.Drawing.Point(105, 253);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(75, 23);
            this.btnRename.TabIndex = 8;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // clbRenames
            // 
            this.clbRenames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.clbRenames.FormattingEnabled = true;
            this.clbRenames.IntegralHeight = false;
            this.clbRenames.Location = new System.Drawing.Point(12, 119);
            this.clbRenames.Name = "clbRenames";
            this.clbRenames.Size = new System.Drawing.Size(260, 97);
            this.clbRenames.TabIndex = 9;
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCheckAll.Location = new System.Drawing.Point(64, 224);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(75, 23);
            this.btnCheckAll.TabIndex = 10;
            this.btnCheckAll.Text = "Check All";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // btnUncheckAll
            // 
            this.btnUncheckAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUncheckAll.Location = new System.Drawing.Point(145, 224);
            this.btnUncheckAll.Name = "btnUncheckAll";
            this.btnUncheckAll.Size = new System.Drawing.Size(75, 23);
            this.btnUncheckAll.TabIndex = 11;
            this.btnUncheckAll.Text = "Uncheck All";
            this.btnUncheckAll.UseVisualStyleBackColor = true;
            this.btnUncheckAll.Click += new System.EventHandler(this.btnUncheckAll_Click);
            // 
            // howto_date_files_Form1
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 288);
            this.Controls.Add(this.btnUncheckAll);
            this.Controls.Add(this.btnCheckAll);
            this.Controls.Add(this.clbRenames);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.txtFormat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtPrefix);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.label1);
            this.Name = "howto_date_files_Form1";
            this.Text = "howto_date_files";
            this.Load += new System.EventHandler(this.howto_date_files_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFormat;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.CheckedListBox clbRenames;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.Button btnUncheckAll;
    }
}

