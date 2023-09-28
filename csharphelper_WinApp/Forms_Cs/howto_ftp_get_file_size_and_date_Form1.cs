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
     public partial class howto_ftp_get_file_size_and_date_Form1:Form
  { 


        public howto_ftp_get_file_size_and_date_Form1()
        {
            InitializeComponent();
        }

        private void btnGetInfo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                lblStatus.Text = "Working...";
                txtSize.Clear();
                txtTimeStamp.Clear();
                Refresh();

                txtSize.Text = FtpGetFileSize(txtUri.Text,
                    txtUsername.Text, txtPassword.Text).ToString();
                txtTimeStamp.Text = FtpGetFileTimestamp(txtUri.Text,
                    txtUsername.Text, txtPassword.Text).ToString();

                lblStatus.Text = "Done";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error";
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        // Use FTP to get a remote file's size.
        private long FtpGetFileSize(string uri, string user_name, string password)
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
            request.Method = WebRequestMethods.Ftp.GetFileSize;

            // Get network credentials.
            request.Credentials = new NetworkCredential(user_name, password);

            try
            {
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    // Return the size.
                    return response.ContentLength;
                }
            }
            catch (Exception ex)
            {
                // If the file doesn't exist, return -1.
                // Otherwise rethrow the error.
                if (ex.Message.Contains("File unavailable")) return -1;
                throw;
            }
        }

        // Use FTP to get a remote file's timestamp.
        private DateTime FtpGetFileTimestamp(string uri, string user_name, string password)
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);
            request.Method = WebRequestMethods.Ftp.GetDateTimestamp;

            // Get network credentials.
            request.Credentials = new NetworkCredential(user_name, password);

            try
            {
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    // Return the size.
                    return response.LastModified;
                }
            }
            catch (Exception ex)
            {
                // If the file doesn't exist, return Jan 1, 3000.
                // Otherwise rethrow the error.
                if (ex.Message.Contains("File unavailable")) return new DateTime(3000, 1, 1);
                throw;
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtTimeStamp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGetInfo = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUri = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.Location = new System.Drawing.Point(12, 177);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(360, 23);
            this.lblStatus.TabIndex = 41;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTimeStamp
            // 
            this.txtTimeStamp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimeStamp.Location = new System.Drawing.Point(82, 144);
            this.txtTimeStamp.Name = "txtTimeStamp";
            this.txtTimeStamp.ReadOnly = true;
            this.txtTimeStamp.Size = new System.Drawing.Size(290, 20);
            this.txtTimeStamp.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Timestamp:";
            // 
            // txtSize
            // 
            this.txtSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSize.Location = new System.Drawing.Point(82, 118);
            this.txtSize.Name = "txtSize";
            this.txtSize.ReadOnly = true;
            this.txtSize.Size = new System.Drawing.Size(290, 20);
            this.txtSize.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Size:";
            // 
            // btnGetInfo
            // 
            this.btnGetInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGetInfo.Location = new System.Drawing.Point(155, 89);
            this.btnGetInfo.Name = "btnGetInfo";
            this.btnGetInfo.Size = new System.Drawing.Size(75, 23);
            this.btnGetInfo.TabIndex = 36;
            this.btnGetInfo.Text = "Get Info";
            this.btnGetInfo.UseVisualStyleBackColor = true;
            this.btnGetInfo.Click += new System.EventHandler(this.btnGetInfo_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(82, 63);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(290, 20);
            this.txtPassword.TabIndex = 33;
            this.txtPassword.Text = "visitor@someplace.com";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Password:";
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Location = new System.Drawing.Point(82, 37);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(290, 20);
            this.txtUsername.TabIndex = 32;
            this.txtUsername.Text = "anonymous";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Username:";
            // 
            // txtUri
            // 
            this.txtUri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUri.Location = new System.Drawing.Point(82, 11);
            this.txtUri.Name = "txtUri";
            this.txtUri.Size = new System.Drawing.Size(290, 20);
            this.txtUri.TabIndex = 30;
            this.txtUri.Text = "ftp://www.somewhere.com/test.txt";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "URL:";
            // 
            // howto_ftp_get_file_size_and_date_Form1
            // 
            this.AcceptButton = this.btnGetInfo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 211);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtTimeStamp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnGetInfo);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUri);
            this.Controls.Add(this.label1);
            this.Name = "howto_ftp_get_file_size_and_date_Form1";
            this.Text = "howto_ftp_get_file_size_and_date";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtTimeStamp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGetInfo;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUri;
        private System.Windows.Forms.Label label1;
    }
}

