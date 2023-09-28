using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.Net.Mail;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_send_email_Form1:Form
  { 


        public howto_send_email_Form1()
        {
            InitializeComponent();
        }

        // Send the message.
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                SendEmail(txtToName.Text, txtToEmail.Text,
                    txtFromName.Text, txtFromEmail.Text,
                    txtHost.Text, int.Parse(txtPort.Text),
                    chkEnableSSL.Checked, txtPassword.Text,
                    txtSubject.Text, txtBody.Text);
                MessageBox.Show("Message sent");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Send an email message.
        private void SendEmail(string to_name, string to_email,
            string from_name, string from_email,
            string host, int port, bool enable_ssl, string password,
            string subject, string body)
        {
            // Make the mail message.
            MailAddress from_address = new MailAddress(from_email, from_name);
            MailAddress to_address = new MailAddress(to_email, to_name);
            MailMessage message = new MailMessage(from_address, to_address);
            message.Subject = subject;
            message.Body = body;

            // Get the SMTP client.
            SmtpClient client = new SmtpClient()
            {
                Host = host,
                Port = port,
                EnableSsl = enable_ssl,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(from_address.Address, password),
            };

            // Send the message.
            client.Send(message);
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
            this.btnSend = new System.Windows.Forms.Button();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.chkEnableSSL = new System.Windows.Forms.CheckBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFromEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtToEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFromName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtToName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSend.Location = new System.Drawing.Point(156, 357);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 10;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtBody
            // 
            this.txtBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBody.Location = new System.Drawing.Point(15, 261);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(359, 90);
            this.txtBody.TabIndex = 9;
            this.txtBody.Text = "This is a test email message.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Body:";
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.Location = new System.Drawing.Point(84, 216);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(290, 20);
            this.txtSubject.TabIndex = 8;
            this.txtSubject.Text = "Test message";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Subject:";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(84, 190);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(290, 20);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.Text = "Password";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 193);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Password:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 170);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Enable SSL:";
            // 
            // chkEnableSSL
            // 
            this.chkEnableSSL.AutoSize = true;
            this.chkEnableSSL.Checked = true;
            this.chkEnableSSL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableSSL.Location = new System.Drawing.Point(84, 170);
            this.chkEnableSSL.Name = "chkEnableSSL";
            this.chkEnableSSL.Size = new System.Drawing.Size(15, 14);
            this.chkEnableSSL.TabIndex = 6;
            this.chkEnableSSL.UseVisualStyleBackColor = true;
            // 
            // txtPort
            // 
            this.txtPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPort.Location = new System.Drawing.Point(84, 142);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(290, 20);
            this.txtPort.TabIndex = 5;
            this.txtPort.Text = "587";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Port:";
            // 
            // txtHost
            // 
            this.txtHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHost.Location = new System.Drawing.Point(84, 116);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(290, 20);
            this.txtHost.TabIndex = 4;
            this.txtHost.Text = "smtp.live.com";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Host:";
            // 
            // txtFromEmail
            // 
            this.txtFromEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromEmail.Location = new System.Drawing.Point(84, 90);
            this.txtFromEmail.Name = "txtFromEmail";
            this.txtFromEmail.Size = new System.Drawing.Size(290, 20);
            this.txtFromEmail.TabIndex = 3;
            this.txtFromEmail.Text = "ben_baker@gmail.com";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "From Email:";
            // 
            // txtToEmail
            // 
            this.txtToEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToEmail.Location = new System.Drawing.Point(84, 38);
            this.txtToEmail.Name = "txtToEmail";
            this.txtToEmail.Size = new System.Drawing.Size(290, 20);
            this.txtToEmail.TabIndex = 1;
            this.txtToEmail.Text = "aarcher@somewhere.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "To Email:";
            // 
            // txtFromName
            // 
            this.txtFromName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromName.Location = new System.Drawing.Point(84, 64);
            this.txtFromName.Name = "txtFromName";
            this.txtFromName.Size = new System.Drawing.Size(290, 20);
            this.txtFromName.TabIndex = 2;
            this.txtFromName.Text = "Ben Baker";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "From Name:";
            // 
            // txtToName
            // 
            this.txtToName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToName.Location = new System.Drawing.Point(84, 12);
            this.txtToName.Name = "txtToName";
            this.txtToName.Size = new System.Drawing.Size(290, 20);
            this.txtToName.TabIndex = 0;
            this.txtToName.Text = "Ann Archer";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "To Name:";
            // 
            // howto_send_email_Form1
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 392);
            this.Controls.Add(this.txtToName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtFromName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtToEmail);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.chkEnableSSL);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtFromEmail);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Name = "howto_send_email_Form1";
            this.Text = "howto_send_email";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkEnableSSL;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFromEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtToEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFromName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtToName;
        private System.Windows.Forms.Label label7;

    }
}

