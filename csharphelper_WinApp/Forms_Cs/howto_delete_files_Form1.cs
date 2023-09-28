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
     public partial class howto_delete_files_Form1:Form
  { 


        public howto_delete_files_Form1()
        {
            InitializeComponent();
        }

        // Sort the files.
        private void howto_delete_files_Form1_Load(object sender, EventArgs e)
        {
            txtPath.Text = Application.StartupPath;
            clstFiles.Sorted = true;
        }

        // List the selected files.
        private void btnListFiles_Click(object sender, EventArgs e)
        {
            clstFiles.Items.Clear();
            try
            {
                DirectoryInfo dir_info = new DirectoryInfo(txtPath.Text);
                foreach (FileInfo file_info in dir_info.GetFiles(
                    txtPattern.Text, SearchOption.AllDirectories))
                {
                    int index = clstFiles.Items.Add(file_info.FullName);
                    clstFiles.SetItemChecked(index, true);
                }
                lblNumFiles.Text = clstFiles.Items.Count + " files";
                btnDelete.Enabled = clstFiles.CheckedIndices.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Delete the checked files.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string[] filenames = new string[clstFiles.CheckedItems.Count];
            clstFiles.CheckedItems.CopyTo(filenames, 0);
            foreach (string filename in filenames)
            {
                Console.WriteLine(filename);
                try
                {
                    File.Delete(filename);
                    clstFiles.Items.Remove(filename);
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

            lblNumFiles.Text = clstFiles.CheckedItems.Count + " files";
            btnDelete.Enabled = clstFiles.CheckedItems.Count > 0;
        }

        // Disable the Delete button.
        private void txt_TextChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
        }

        // Enable the Delete button if any item is checked.
        private void clstFiles_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int num_checked = clstFiles.CheckedItems.Count;
            if (e.NewValue != e.CurrentValue)
            {
                if (e.NewValue == CheckState.Checked) num_checked++;
                else if (e.NewValue == CheckState.Unchecked) num_checked--;
            }

            lblNumFiles.Text = num_checked + " files";
            btnDelete.Enabled = num_checked > 0;
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
            this.clstFiles = new System.Windows.Forms.CheckedListBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtPattern = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnListFiles = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNumFiles
            // 
            this.lblNumFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNumFiles.AutoSize = true;
            this.lblNumFiles.Location = new System.Drawing.Point(15, 220);
            this.lblNumFiles.Name = "lblNumFiles";
            this.lblNumFiles.Size = new System.Drawing.Size(0, 13);
            this.lblNumFiles.TabIndex = 14;
            // 
            // clstFiles
            // 
            this.clstFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.clstFiles.FormattingEnabled = true;
            this.clstFiles.HorizontalScrollbar = true;
            this.clstFiles.IntegralHeight = false;
            this.clstFiles.Location = new System.Drawing.Point(15, 93);
            this.clstFiles.Name = "clstFiles";
            this.clstFiles.Size = new System.Drawing.Size(257, 124);
            this.clstFiles.TabIndex = 13;
            this.clstFiles.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clstFiles_ItemCheck);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(105, 236);
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
            this.txtPattern.Location = new System.Drawing.Point(62, 38);
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.Size = new System.Drawing.Size(210, 20);
            this.txtPattern.TabIndex = 9;
            this.txtPattern.Text = "*Upgrade*";
            this.txtPattern.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Pattern:";
            // 
            // btnListFiles
            // 
            this.btnListFiles.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnListFiles.Location = new System.Drawing.Point(105, 64);
            this.btnListFiles.Name = "btnListFiles";
            this.btnListFiles.Size = new System.Drawing.Size(75, 23);
            this.btnListFiles.TabIndex = 10;
            this.btnListFiles.Text = "List Files";
            this.btnListFiles.UseVisualStyleBackColor = true;
            this.btnListFiles.Click += new System.EventHandler(this.btnListFiles_Click);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(62, 12);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(210, 20);
            this.txtPath.TabIndex = 7;
            this.txtPath.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Path:";
            // 
            // howto_delete_files_Form1
            // 
            this.AcceptButton = this.btnListFiles;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 271);
            this.Controls.Add(this.lblNumFiles);
            this.Controls.Add(this.clstFiles);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtPattern);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnListFiles);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.Name = "howto_delete_files_Form1";
            this.Text = "howto_delete_files";
            this.Load += new System.EventHandler(this.howto_delete_files_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumFiles;
        private System.Windows.Forms.CheckedListBox clstFiles;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtPattern;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnListFiles;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label1;
    }
}

