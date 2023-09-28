using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;

 

using howto_find_file_locker;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_find_file_locker_Form1:Form
  { 


        public howto_find_file_locker_Form1()
        {
            InitializeComponent();
        }

        // Select the executable file.
        private void howto_find_file_locker_Form1_Load(object sender, EventArgs e)
        {
            txtFile.Text = Application.ExecutablePath;
        }

        // Let the user pick a file to study.
        private void btnPickFile_Click(object sender, EventArgs e)
        {
            if (ofdLockedFile.ShowDialog() == DialogResult.OK)
                txtFile.Text = ofdLockedFile.FileName;
        }

        // Find any locks on the indicated file.
        private void btnFindLocks_Click(object sender, EventArgs e)
        {
            try
            {
                lstLockers.Items.Clear();

                // Get the processes.
                List<Process> lockers = LockTools.FindLockers(txtFile.Text);

                // Display the process names.
                foreach (Process process in lockers)
                    lstLockers.Items.Add(process.ProcessName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnPickFile = new System.Windows.Forms.Button();
            this.ofdLockedFile = new System.Windows.Forms.OpenFileDialog();
            this.btnFindLocks = new System.Windows.Forms.Button();
            this.lstLockers = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File:";
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(44, 12);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(227, 20);
            this.txtFile.TabIndex = 1;
            // 
            // btnPickFile
            // 
            this.btnPickFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickFile.Image = Properties.Resources.Ellipsis;
            this.btnPickFile.Location = new System.Drawing.Point(277, 12);
            this.btnPickFile.Name = "btnPickFile";
            this.btnPickFile.Size = new System.Drawing.Size(20, 20);
            this.btnPickFile.TabIndex = 2;
            this.btnPickFile.UseVisualStyleBackColor = true;
            this.btnPickFile.Click += new System.EventHandler(this.btnPickFile_Click);
            // 
            // ofdLockedFile
            // 
            this.ofdLockedFile.FileName = "openFileDialog1";
            this.ofdLockedFile.Filter = "All Files|*.*";
            // 
            // btnFindLocks
            // 
            this.btnFindLocks.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFindLocks.Location = new System.Drawing.Point(117, 38);
            this.btnFindLocks.Name = "btnFindLocks";
            this.btnFindLocks.Size = new System.Drawing.Size(75, 23);
            this.btnFindLocks.TabIndex = 3;
            this.btnFindLocks.Text = "Find Locks";
            this.btnFindLocks.UseVisualStyleBackColor = true;
            this.btnFindLocks.Click += new System.EventHandler(this.btnFindLocks_Click);
            // 
            // lstLockers
            // 
            this.lstLockers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLockers.FormattingEnabled = true;
            this.lstLockers.IntegralHeight = false;
            this.lstLockers.Location = new System.Drawing.Point(12, 67);
            this.lstLockers.Name = "lstLockers";
            this.lstLockers.Size = new System.Drawing.Size(285, 82);
            this.lstLockers.TabIndex = 4;
            // 
            // howto_find_file_locker_Form1
            // 
            this.AcceptButton = this.btnFindLocks;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 161);
            this.Controls.Add(this.lstLockers);
            this.Controls.Add(this.btnFindLocks);
            this.Controls.Add(this.btnPickFile);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label1);
            this.Name = "howto_find_file_locker_Form1";
            this.Text = "howto_find_file_locker";
            this.Load += new System.EventHandler(this.howto_find_file_locker_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnPickFile;
        private System.Windows.Forms.OpenFileDialog ofdLockedFile;
        private System.Windows.Forms.Button btnFindLocks;
        private System.Windows.Forms.ListBox lstLockers;
    }
}

