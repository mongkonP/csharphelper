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
     public partial class targets_Form1:Form
  { 


        public targets_Form1()
        {
            InitializeComponent();
        }

        // Add the target folders to the folder text box.
       private void targets_Form1_Load(object sender, EventArgs e)
        {
            string path = Path.GetFullPath(
                Path.Combine(Application.StartupPath, "..\\.."));
            txtFolders.Text =
                path + "\\Targets\r\n" +
                path + "\\Targets\\TargetFolder1\r\n" +
                path + "\\Targets\\TargetFolder2";

            clbFiles.Sorted = true;
            clbFiles.CheckOnClick = true;
        }

        // List the selected files.
        private void btnListFiles_Click(object sender, EventArgs e)
        {
            clbFiles.Items.Clear();

            // Loop through the folders.
            char[] separators = { '\r', '\n' };
            string[] folders = txtFolders.Text.Split(
                separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string folder in folders)
            {
                // Find files in this folder.
                try
                {
                    DirectoryInfo dir_info = new DirectoryInfo(folder);
                    foreach (FileInfo file_info in dir_info.GetFiles(
                        txtPattern.Text, SearchOption.AllDirectories))
                    {
                        string file_name = file_info.FullName;
                        if (clbFiles.Items.Contains(file_name))
                            Console.WriteLine("Skipped " + file_name);
                        else
                            clbFiles.Items.Add(file_name);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            // Check all items.
            for (int i = 0; i < clbFiles.Items.Count; i++)
                clbFiles.SetItemChecked(i, true);
            lblNumFiles.Text = clbFiles.Items.Count + " files";
            btnDelete.Enabled = clbFiles.CheckedIndices.Count > 0;
        }

        // Delete the checked files.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string[] strings = new string[clbFiles.CheckedItems.Count];
            clbFiles.CheckedItems.CopyTo(strings, 0);
            foreach (string file_name in strings)
            {
                Console.WriteLine(file_name);
                try
                {
                    File.Delete(file_name);
                    clbFiles.Items.Remove(file_name);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting file. " + ex.Message);
                    if (MessageBox.Show("Error deleting file. " + ex.Message +
                        Environment.NewLine + Environment.NewLine +
                        "Continue?", "Continue?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.No)
                        break;
                }
            }

            lblNumFiles.Text = clbFiles.CheckedItems.Count + " files";
            btnDelete.Enabled = clbFiles.CheckedItems.Count > 0;
        }

        // Disable the Delete button.
        private void txt_TextChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
        }

        // Enable the Delete button if any item is checked.
        private void clstFiles_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int num_checked = clbFiles.CheckedItems.Count;
            if (e.NewValue != e.CurrentValue)
            {
                if (e.NewValue == CheckState.Checked) num_checked++;
                else if (e.NewValue == CheckState.Unchecked) num_checked--;
            }

            lblNumFiles.Text = num_checked + " files";
            btnDelete.Enabled = num_checked > 0;
        }

        // Select all files.
        private void btnAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbFiles.Items.Count; i++)
                clbFiles.SetItemChecked(i, true);
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbFiles.Items.Count; i++)
                clbFiles.SetItemChecked(i, false);
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
            this.lblNumFiles = new System.Windows.Forms.Label();
            this.clbFiles = new System.Windows.Forms.CheckedListBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtPattern = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnListFiles = new System.Windows.Forms.Button();
            this.txtFolders = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnNone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNumFiles
            // 
            this.lblNumFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNumFiles.AutoSize = true;
            this.lblNumFiles.Location = new System.Drawing.Point(12, 326);
            this.lblNumFiles.Name = "lblNumFiles";
            this.lblNumFiles.Size = new System.Drawing.Size(0, 13);
            this.lblNumFiles.TabIndex = 14;
            // 
            // clbFiles
            // 
            this.clbFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.clbFiles.FormattingEnabled = true;
            this.clbFiles.HorizontalScrollbar = true;
            this.clbFiles.IntegralHeight = false;
            this.clbFiles.Location = new System.Drawing.Point(15, 164);
            this.clbFiles.Name = "clbFiles";
            this.clbFiles.Size = new System.Drawing.Size(357, 156);
            this.clbFiles.TabIndex = 13;
            this.clbFiles.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clstFiles_ItemCheck);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(297, 326);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtPattern
            // 
            this.txtPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPattern.Location = new System.Drawing.Point(62, 109);
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.Size = new System.Drawing.Size(310, 20);
            this.txtPattern.TabIndex = 9;
            this.txtPattern.Text = "*.cs";
            this.txtPattern.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Pattern:";
            // 
            // btnListFiles
            // 
            this.btnListFiles.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnListFiles.Location = new System.Drawing.Point(155, 135);
            this.btnListFiles.Name = "btnListFiles";
            this.btnListFiles.Size = new System.Drawing.Size(75, 23);
            this.btnListFiles.TabIndex = 10;
            this.btnListFiles.Text = "List Files";
            this.btnListFiles.UseVisualStyleBackColor = true;
            this.btnListFiles.Click += new System.EventHandler(this.btnListFiles_Click);
            // 
            // txtFolders
            // 
            this.txtFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolders.Location = new System.Drawing.Point(62, 12);
            this.txtFolders.Multiline = true;
            this.txtFolders.Name = "txtFolders";
            this.txtFolders.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFolders.Size = new System.Drawing.Size(310, 91);
            this.txtFolders.TabIndex = 7;
            this.txtFolders.WordWrap = false;
            this.txtFolders.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Folders:";
            // 
            // btnAll
            // 
            this.btnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAll.Location = new System.Drawing.Point(89, 326);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(45, 23);
            this.btnAll.TabIndex = 15;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnNone
            // 
            this.btnNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNone.Location = new System.Drawing.Point(140, 326);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(45, 23);
            this.btnNone.TabIndex = 16;
            this.btnNone.Text = "None";
            this.btnNone.UseVisualStyleBackColor = true;
            this.btnNone.Click += new System.EventHandler(this.btnNone_Click);
            // 
            // targets_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.btnNone);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.lblNumFiles);
            this.Controls.Add(this.clbFiles);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtPattern);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnListFiles);
            this.Controls.Add(this.txtFolders);
            this.Controls.Add(this.label1);
            this.Name = "targets_Form1";
            this.Text = "howto_delete_files";
            this.Load += new System.EventHandler(this.targets_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumFiles;
        private System.Windows.Forms.CheckedListBox clbFiles;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtPattern;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnListFiles;
        private System.Windows.Forms.TextBox txtFolders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnNone;
    }
}

