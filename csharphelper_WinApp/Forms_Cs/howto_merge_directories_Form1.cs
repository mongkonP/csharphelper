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
     public partial class howto_merge_directories_Form1:Form
  { 


        public howto_merge_directories_Form1()
        {
            InitializeComponent();
        }

        // Restore the previous directories.
        private void howto_merge_directories_Form1_Load(object sender, EventArgs e)
        {
            txtFrom.Text = Properties.Settings.Default.FromDir;
            txtTo.Text = Properties.Settings.Default.ToDir;
        }

        // Save the current directory paths.
        private void howto_merge_directories_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.FromDir = txtFrom.Text;
            Properties.Settings.Default.ToDir = txtTo.Text;
            Properties.Settings.Default.Save();
        }

        private void btnFrom_Click(object sender, EventArgs e)
        {
            if (fbdDirectory.ShowDialog() == DialogResult.OK)
                txtFrom.Text = fbdDirectory.SelectedPath;
        }

        private void btnTo_Click(object sender, EventArgs e)
        {
            if (fbdDirectory.ShowDialog() == DialogResult.OK)
                txtTo.Text = fbdDirectory.SelectedPath;
        }

        // Move files in the From directory into the To directory. 
        private void btnMerge_Click(object sender, EventArgs e)
        {
            // Get the From directory..
            string from_dir = txtFrom.Text;
            if (from_dir.Length == 0)
            {
                MessageBox.Show("Please enter a From directory",
                    "Missing Directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Directory.Exists(from_dir))
            {
                MessageBox.Show("From directory " + from_dir + " doesn't exist",
                    "No Such Directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the To directory..
            string to_dir = txtTo.Text;
            if (to_dir.Length == 0)
            {
                MessageBox.Show("Please enter a To directory",
                    "Missing Directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Directory.Exists(to_dir))
            {
                MessageBox.Show("To directory " + to_dir + " doesn't exist",
                    "No Such Directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Make sure the directories are different.
            if (from_dir.ToLower() == to_dir.ToLower())
            {
                MessageBox.Show("The From and To directories must be different",
                    "Duplicate Directories", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Make sure the directory names end with \.
            if (!from_dir.EndsWith("\\")) from_dir += "\\";
            if (!to_dir.EndsWith("\\")) to_dir += "\\";

            // Move the files.
            Cursor = Cursors.WaitCursor;
            Refresh();
            int num_moved = 0;
            int num_renamed = 0;
            foreach (string old_name in Directory.GetFiles(from_dir))
            {
                // Compose the new file name.
                FileInfo info = new FileInfo(old_name);
                string new_name = to_dir + info.Name;

                // As long as the file already exists, append an increasing number.
                if (File.Exists(new_name))
                {
                    string extension = info.Extension;
                    string short_name = info.Name.Substring(0,
                        info.Name.Length - extension.Length);

                    for (int i = 1; File.Exists(new_name); i++)
                    {
                        new_name = to_dir + short_name +
                            " (" + i.ToString() + ")" + extension;
                    }
                    num_renamed++;
                }

                // Move the file.
                File.Move(old_name, new_name);
                num_moved++;
            }

            // Display results.
            Cursor = Cursors.Default;
            MessageBox.Show("Moved " + num_moved + " files\nRenamed " + num_renamed + " files");
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
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.btnFrom = new System.Windows.Forms.Button();
            this.btnTo = new System.Windows.Forms.Button();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMerge = new System.Windows.Forms.Button();
            this.fbdDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Move From:";
            // 
            // txtFrom
            // 
            this.txtFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFrom.Location = new System.Drawing.Point(81, 14);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(262, 20);
            this.txtFrom.TabIndex = 1;
            // 
            // btnFrom
            // 
            this.btnFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFrom.Image = Properties.Resources.Ellipsis;
            this.btnFrom.Location = new System.Drawing.Point(349, 12);
            this.btnFrom.Name = "btnFrom";
            this.btnFrom.Size = new System.Drawing.Size(23, 23);
            this.btnFrom.TabIndex = 2;
            this.btnFrom.TabStop = false;
            this.btnFrom.UseVisualStyleBackColor = true;
            this.btnFrom.Click += new System.EventHandler(this.btnFrom_Click);
            // 
            // btnTo
            // 
            this.btnTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTo.Image = Properties.Resources.Ellipsis;
            this.btnTo.Location = new System.Drawing.Point(349, 39);
            this.btnTo.Name = "btnTo";
            this.btnTo.Size = new System.Drawing.Size(23, 23);
            this.btnTo.TabIndex = 5;
            this.btnTo.TabStop = false;
            this.btnTo.UseVisualStyleBackColor = true;
            this.btnTo.Click += new System.EventHandler(this.btnTo_Click);
            // 
            // txtTo
            // 
            this.txtTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTo.Location = new System.Drawing.Point(81, 41);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(262, 20);
            this.txtTo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Move To:";
            // 
            // btnMerge
            // 
            this.btnMerge.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMerge.Location = new System.Drawing.Point(155, 67);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(75, 23);
            this.btnMerge.TabIndex = 6;
            this.btnMerge.Text = "Merge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // howto_merge_directories_Form1
            // 
            this.AcceptButton = this.btnMerge;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 100);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.btnTo);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFrom);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.label1);
            this.Name = "howto_merge_directories_Form1";
            this.Text = "howto_merge_directories";
            this.Load += new System.EventHandler(this.howto_merge_directories_Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_merge_directories_Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Button btnFrom;
        private System.Windows.Forms.Button btnTo;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.FolderBrowserDialog fbdDirectory;
    }
}

