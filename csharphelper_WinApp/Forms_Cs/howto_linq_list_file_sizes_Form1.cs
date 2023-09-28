using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

 

using howto_linq_list_file_sizes;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_linq_list_file_sizes_Form1:Form
  { 


        public howto_linq_list_file_sizes_Form1()
        {
            InitializeComponent();
        }

        // Start at the startup directory.
        private void howto_linq_list_file_sizes_Form1_Load(object sender, EventArgs e)
        {
            txtDirectory.Text = Application.StartupPath;
        }

        // List the files in the selected directory and their sizes.
        private void btnListFiles_Click(object sender, EventArgs e)
        {
            // Search for the files.
            DirectoryInfo dirinfo = new DirectoryInfo(txtDirectory.Text);
            var fileQuery =
                from FileInfo fileinfo in dirinfo.GetFiles()
                orderby fileinfo.Length descending
                select String.Format("{0,10}  {1}",
                    fileinfo.Length.ToFileSizeApi(), fileinfo.Name);

            // Display the result.
            lstFiles.DataSource = fileQuery.ToArray();
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
            this.btnListFiles = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.ListBox();
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
            this.txtDirectory.Location = new System.Drawing.Point(70, 12);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(402, 20);
            this.txtDirectory.TabIndex = 1;
            // 
            // btnListFiles
            // 
            this.btnListFiles.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnListFiles.Location = new System.Drawing.Point(205, 38);
            this.btnListFiles.Name = "btnListFiles";
            this.btnListFiles.Size = new System.Drawing.Size(75, 23);
            this.btnListFiles.TabIndex = 2;
            this.btnListFiles.Text = "List Files";
            this.btnListFiles.UseVisualStyleBackColor = true;
            this.btnListFiles.Click += new System.EventHandler(this.btnListFiles_Click);
            // 
            // lstFiles
            // 
            this.lstFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFiles.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.ItemHeight = 14;
            this.lstFiles.Location = new System.Drawing.Point(12, 77);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(460, 172);
            this.lstFiles.TabIndex = 3;
            // 
            // howto_linq_list_file_sizes_Form1
            // 
            this.AcceptButton = this.btnListFiles;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 264);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.btnListFiles);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.label1);
            this.Name = "howto_linq_list_file_sizes_Form1";
            this.Text = "howto_linq_list_file_sizes";
            this.Load += new System.EventHandler(this.howto_linq_list_file_sizes_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Button btnListFiles;
        private System.Windows.Forms.ListBox lstFiles;
    }
}

