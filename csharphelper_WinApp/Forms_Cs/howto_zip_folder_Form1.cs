using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Add a reference to System.IO.Compression.FileSystem.
using System.IO.Compression;
using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_zip_folder_Form1:Form
  { 


        public howto_zip_folder_Form1()
        {
            InitializeComponent();
        }

        // Start with the source folder.
        private void howto_zip_folder_Form1_Load(object sender, EventArgs e)
        {
            txtFolder.Text = Application.StartupPath;
            txtZipFile.Text = Path.GetFullPath(
                Path.Combine(Application.StartupPath, "..\\howto_zip_folder.zip"));
        }

        // Let the user browse for the folder.
        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            fbdFolder.SelectedPath = txtFolder.Text;
            if (fbdFolder.ShowDialog() == DialogResult.OK)
                txtFolder.Text = fbdFolder.SelectedPath;
        }

        // Let the user browse for the Zip file.
        private void btnBrowseForFile_Click(object sender, EventArgs e)
        {
            sfdZipFile.FileName = txtZipFile.Text;
            if (sfdZipFile.ShowDialog() == DialogResult.OK)
                txtZipFile.Text = sfdZipFile.FileName;
        }

        // Zip the directory.
        private void btnZip_Click(object sender, EventArgs e)
        {
            try
            {
                ZipFile.CreateFromDirectory(txtFolder.Text, txtZipFile.Text);
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Unzip the zip file.
        private void btnUnzip_Click(object sender, EventArgs e)
        {
            try
            {
                ZipFile.ExtractToDirectory(txtZipFile.Text, txtFolder.Text);
                MessageBox.Show("Done");
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
            this.btnUnzip = new System.Windows.Forms.Button();
            this.btnBrowseForFile = new System.Windows.Forms.Button();
            this.txtZipFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnZip = new System.Windows.Forms.Button();
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fbdFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.sfdZipFile = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // btnUnzip
            // 
            this.btnUnzip.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUnzip.Location = new System.Drawing.Point(145, 64);
            this.btnUnzip.Name = "btnUnzip";
            this.btnUnzip.Size = new System.Drawing.Size(75, 23);
            this.btnUnzip.TabIndex = 15;
            this.btnUnzip.Text = "Unzip";
            this.btnUnzip.UseVisualStyleBackColor = true;
            this.btnUnzip.Click += new System.EventHandler(this.btnUnzip_Click);
            // 
            // btnBrowseForFile
            // 
            this.btnBrowseForFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseForFile.Image = Properties.Resources.EllipsisTransparent;
            this.btnBrowseForFile.Location = new System.Drawing.Point(248, 36);
            this.btnBrowseForFile.Name = "btnBrowseForFile";
            this.btnBrowseForFile.Size = new System.Drawing.Size(30, 23);
            this.btnBrowseForFile.TabIndex = 14;
            this.btnBrowseForFile.TabStop = false;
            this.btnBrowseForFile.UseVisualStyleBackColor = true;
            this.btnBrowseForFile.Click += new System.EventHandler(this.btnBrowseForFile_Click);
            // 
            // txtZipFile
            // 
            this.txtZipFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtZipFile.Location = new System.Drawing.Point(64, 38);
            this.txtZipFile.Name = "txtZipFile";
            this.txtZipFile.Size = new System.Drawing.Size(178, 20);
            this.txtZipFile.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Zip File:";
            // 
            // btnZip
            // 
            this.btnZip.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnZip.Location = new System.Drawing.Point(64, 64);
            this.btnZip.Name = "btnZip";
            this.btnZip.Size = new System.Drawing.Size(75, 23);
            this.btnZip.TabIndex = 11;
            this.btnZip.Text = "Zip";
            this.btnZip.UseVisualStyleBackColor = true;
            this.btnZip.Click += new System.EventHandler(this.btnZip_Click);
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseFolder.Image = Properties.Resources.EllipsisTransparent;
            this.btnBrowseFolder.Location = new System.Drawing.Point(248, 10);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(30, 23);
            this.btnBrowseFolder.TabIndex = 10;
            this.btnBrowseFolder.TabStop = false;
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // txtFolder
            // 
            this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolder.Location = new System.Drawing.Point(64, 12);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(178, 20);
            this.txtFolder.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Folder:";
            // 
            // sfdZipFile
            // 
            this.sfdZipFile.Filter = "Zip Files|*.zip|All Files|*.*";
            // 
            // howto_zip_folder_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 100);
            this.Controls.Add(this.btnUnzip);
            this.Controls.Add(this.btnBrowseForFile);
            this.Controls.Add(this.txtZipFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnZip);
            this.Controls.Add(this.btnBrowseFolder);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.label1);
            this.Name = "howto_zip_folder_Form1";
            this.Text = "howto_zip_folder";
            this.Load += new System.EventHandler(this.howto_zip_folder_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUnzip;
        private System.Windows.Forms.Button btnBrowseForFile;
        private System.Windows.Forms.TextBox txtZipFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnZip;
        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog fbdFolder;
        private System.Windows.Forms.SaveFileDialog sfdZipFile;

    }
}

