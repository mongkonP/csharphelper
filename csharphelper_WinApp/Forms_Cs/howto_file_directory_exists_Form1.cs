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
     public partial class howto_file_directory_exists_Form1:Form
  { 


        public howto_file_directory_exists_Form1()
        {
            InitializeComponent();
        }

        private void howto_file_directory_exists_Form1_Load(object sender, EventArgs e)
        {
            txtDirectory.Text = Application.StartupPath;
            txtDirectory.Select(txtDirectory.Text.Length, 0);

            txtFile.Text = Application.ExecutablePath;
            txtFile.Select(txtFile.Text.Length, 0);
        }

        private void btnDirectoryExists_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtDirectory.Text))
                txtDirectoryResult.Text = "Yes";
            else txtDirectoryResult.Text = "No";
        }

        private void btnFileExists_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtFile.Text))
                txtFileResult.Text = "Yes";
            else txtFileResult.Text = "No";
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
            this.txtFileResult = new System.Windows.Forms.TextBox();
            this.txtDirectoryResult = new System.Windows.Forms.TextBox();
            this.btnFileExists = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDirectoryExists = new System.Windows.Forms.Button();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFileResult
            // 
            this.txtFileResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileResult.Location = new System.Drawing.Point(363, 43);
            this.txtFileResult.Name = "txtFileResult";
            this.txtFileResult.ReadOnly = true;
            this.txtFileResult.Size = new System.Drawing.Size(39, 20);
            this.txtFileResult.TabIndex = 15;
            this.txtFileResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDirectoryResult
            // 
            this.txtDirectoryResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectoryResult.Location = new System.Drawing.Point(363, 15);
            this.txtDirectoryResult.Name = "txtDirectoryResult";
            this.txtDirectoryResult.ReadOnly = true;
            this.txtDirectoryResult.Size = new System.Drawing.Size(39, 20);
            this.txtDirectoryResult.TabIndex = 14;
            this.txtDirectoryResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnFileExists
            // 
            this.btnFileExists.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFileExists.Location = new System.Drawing.Point(282, 41);
            this.btnFileExists.Name = "btnFileExists";
            this.btnFileExists.Size = new System.Drawing.Size(75, 23);
            this.btnFileExists.TabIndex = 13;
            this.btnFileExists.Text = "Exists?";
            this.btnFileExists.UseVisualStyleBackColor = true;
            this.btnFileExists.Click += new System.EventHandler(this.btnFileExists_Click);
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(70, 44);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(206, 20);
            this.txtFile.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "File:";
            // 
            // btnDirectoryExists
            // 
            this.btnDirectoryExists.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDirectoryExists.Location = new System.Drawing.Point(282, 13);
            this.btnDirectoryExists.Name = "btnDirectoryExists";
            this.btnDirectoryExists.Size = new System.Drawing.Size(75, 23);
            this.btnDirectoryExists.TabIndex = 10;
            this.btnDirectoryExists.Text = "Exists?";
            this.btnDirectoryExists.UseVisualStyleBackColor = true;
            this.btnDirectoryExists.Click += new System.EventHandler(this.btnDirectoryExists_Click);
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Location = new System.Drawing.Point(70, 15);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(206, 20);
            this.txtDirectory.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Directory:";
            // 
            // howto_file_directory_exists_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 76);
            this.Controls.Add(this.txtFileResult);
            this.Controls.Add(this.txtDirectoryResult);
            this.Controls.Add(this.btnFileExists);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDirectoryExists);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.label1);
            this.Name = "howto_file_directory_exists_Form1";
            this.Text = "howto_file_directory_exists";
            this.Load += new System.EventHandler(this.howto_file_directory_exists_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFileResult;
        private System.Windows.Forms.TextBox txtDirectoryResult;
        private System.Windows.Forms.Button btnFileExists;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDirectoryExists;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Label label1;
    }
}

