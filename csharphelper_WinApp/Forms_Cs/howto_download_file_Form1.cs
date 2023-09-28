using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_download_file_Form1:Form
  { 


        public howto_download_file_Form1()
        {
            InitializeComponent();
        }

        private void howto_download_file_Form1_Load(object sender, EventArgs e)
        {
            string filename = Application.StartupPath;
            if (!filename.EndsWith("\\")) filename += "\\";
            txtLocalFile.Text = filename + "howto_download_file.zip";
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            try
            {
                // Make a WebClient.
                WebClient web_client = new WebClient();

                // Download the file.
                web_client.DownloadFile(txtRemoteFile.Text, txtLocalFile.Text);

                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Download Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            this.Cursor = Cursors.Default;
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
            this.btnDownload = new System.Windows.Forms.Button();
            this.txtLocalFile = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtRemoteFile = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDownload.Location = new System.Drawing.Point(269, 65);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 9;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // txtLocalFile
            // 
            this.txtLocalFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocalFile.Location = new System.Drawing.Point(84, 39);
            this.txtLocalFile.Name = "txtLocalFile";
            this.txtLocalFile.Size = new System.Drawing.Size(517, 20);
            this.txtLocalFile.TabIndex = 8;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(12, 42);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(55, 13);
            this.Label2.TabIndex = 7;
            this.Label2.Text = "Local File:";
            // 
            // txtRemoteFile
            // 
            this.txtRemoteFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemoteFile.Location = new System.Drawing.Point(84, 13);
            this.txtRemoteFile.Name = "txtRemoteFile";
            this.txtRemoteFile.Size = new System.Drawing.Size(517, 20);
            this.txtRemoteFile.TabIndex = 6;
            this.txtRemoteFile.Text = "http://www.csharphelper.com/examples/howto_download_file.zip";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(66, 13);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "Remote File:";
            // 
            // howto_download_file_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 101);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.txtLocalFile);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtRemoteFile);
            this.Controls.Add(this.Label1);
            this.Name = "howto_download_file_Form1";
            this.Text = "howto_download_file";
            this.Load += new System.EventHandler(this.howto_download_file_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnDownload;
        internal System.Windows.Forms.TextBox txtLocalFile;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtRemoteFile;
        internal System.Windows.Forms.Label Label1;
    }
}

