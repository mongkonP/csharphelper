using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Download and unzip the DotNetZip library at: http://dotnetzip.codeplex.com/
// Add a reference to the Ionic.Zip.dll library.

using System.IO;
using Ionic.Zip;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_use_dotnetzip_Form1:Form
  { 


        public howto_use_dotnetzip_Form1()
        {
            InitializeComponent();
        }

        // Start with an initial file.
        private void howto_use_dotnetzip_Form1_Load(object sender, EventArgs e)
        {
            txtFileName.Text = Path.GetFullPath(
                Path.Combine(Application.StartupPath, "..\\..\\JackOLantern.bmp"));
            txtArchiveName.Text = Path.GetFullPath(
                Path.Combine(Application.StartupPath, "..\\..\\JackOLantern.zip"));
            txtExtractTo.Text = Path.GetFullPath(
                Path.Combine(Application.StartupPath, "..\\..\\ExtractedFiles\\"));
        }

        // Add the file to the archive.
        private void btnAddToArchive_Click(object sender, EventArgs e)
        {
            try
            {
                using (ZipFile zip = new ZipFile(txtArchiveName.Text))
                {
                    // Add the file to the Zip archive's root folder.
                    zip.AddFile(txtFileName.Text, txtPathInArchive.Text);

                    // Save the Zip file.
                    zip.Save();
                }

                // Display the file sizes.
                FileInfo old_fi = new FileInfo(txtFileName.Text);
                lblOriginalSize.Text = old_fi.Length.ToString("#,#");
                FileInfo new_fi = new FileInfo(txtArchiveName.Text);
                lblCompressedSize.Text = new_fi.Length.ToString("#,#");

                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding file to archive.\n" + ex.Message);
            }
        }

        // Extract the files from the archive.
        private void btnExtractArchive_Click(object sender, EventArgs e)
        {
            try
            {
                using (ZipFile zip = ZipFile.Read(txtArchiveName.Text))
                {
                    // Loop through the archive's files.
                    foreach (ZipEntry zip_entry in zip)
                    {
                        zip_entry.Extract(txtExtractTo.Text);
                    }
                }

                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error extracting archive.\n" + ex.Message);
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
            this.btnAddToArchive = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOriginalSize = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPathInArchive = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtArchiveName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCompressedSize = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtExtractTo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnExtractArchive = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddToArchive
            // 
            this.btnAddToArchive.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAddToArchive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToArchive.Location = new System.Drawing.Point(178, 84);
            this.btnAddToArchive.Name = "btnAddToArchive";
            this.btnAddToArchive.Size = new System.Drawing.Size(95, 23);
            this.btnAddToArchive.TabIndex = 2;
            this.btnAddToArchive.Text = "Add to Archive";
            this.btnAddToArchive.UseVisualStyleBackColor = true;
            this.btnAddToArchive.Click += new System.EventHandler(this.btnAddToArchive_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Location = new System.Drawing.Point(107, 19);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(334, 20);
            this.txtFileName.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Name:";
            // 
            // lblOriginalSize
            // 
            this.lblOriginalSize.AutoSize = true;
            this.lblOriginalSize.Location = new System.Drawing.Point(107, 42);
            this.lblOriginalSize.Name = "lblOriginalSize";
            this.lblOriginalSize.Size = new System.Drawing.Size(0, 13);
            this.lblOriginalSize.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Size:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtPathInArchive);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtFileName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnAddToArchive);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblOriginalSize);
            this.groupBox1.Location = new System.Drawing.Point(12, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 114);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File";
            // 
            // txtPathInArchive
            // 
            this.txtPathInArchive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPathInArchive.Location = new System.Drawing.Point(107, 58);
            this.txtPathInArchive.Name = "txtPathInArchive";
            this.txtPathInArchive.Size = new System.Drawing.Size(334, 20);
            this.txtPathInArchive.TabIndex = 1;
            this.txtPathInArchive.Text = "\\";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Path in Archive:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtArchiveName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblCompressedSize);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 67);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Archive";
            // 
            // txtArchiveName
            // 
            this.txtArchiveName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArchiveName.Location = new System.Drawing.Point(107, 19);
            this.txtArchiveName.Name = "txtArchiveName";
            this.txtArchiveName.Size = new System.Drawing.Size(334, 20);
            this.txtArchiveName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Size:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Name:";
            // 
            // lblCompressedSize
            // 
            this.lblCompressedSize.AutoSize = true;
            this.lblCompressedSize.Location = new System.Drawing.Point(107, 42);
            this.lblCompressedSize.Name = "lblCompressedSize";
            this.lblCompressedSize.Size = new System.Drawing.Size(0, 13);
            this.lblCompressedSize.TabIndex = 12;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnExtractArchive);
            this.groupBox3.Controls.Add(this.txtExtractTo);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(15, 205);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(450, 75);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Extract To";
            // 
            // txtExtractTo
            // 
            this.txtExtractTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExtractTo.Location = new System.Drawing.Point(107, 19);
            this.txtExtractTo.Name = "txtExtractTo";
            this.txtExtractTo.Size = new System.Drawing.Size(334, 20);
            this.txtExtractTo.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Path:";
            // 
            // btnExtractArchive
            // 
            this.btnExtractArchive.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnExtractArchive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtractArchive.Location = new System.Drawing.Point(175, 45);
            this.btnExtractArchive.Name = "btnExtractArchive";
            this.btnExtractArchive.Size = new System.Drawing.Size(95, 23);
            this.btnExtractArchive.TabIndex = 1;
            this.btnExtractArchive.Text = "Extract Archive";
            this.btnExtractArchive.UseVisualStyleBackColor = true;
            this.btnExtractArchive.Click += new System.EventHandler(this.btnExtractArchive_Click);
            // 
            // howto_use_dotnetzip_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 290);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "howto_use_dotnetzip_Form1";
            this.Text = "howto_use_dotnetzip";
            this.Load += new System.EventHandler(this.howto_use_dotnetzip_Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddToArchive;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblOriginalSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtArchiveName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCompressedSize;
        private System.Windows.Forms.TextBox txtPathInArchive;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtExtractTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnExtractArchive;
    }
}

