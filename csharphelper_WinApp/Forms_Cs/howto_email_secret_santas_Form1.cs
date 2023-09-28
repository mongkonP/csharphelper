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

 

using howto_email_secret_santas;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_email_secret_santas_Form1:Form
  { 


        public howto_email_secret_santas_Form1()
        {
            InitializeComponent();
        }

        // Send the message.
        private void btnSend_Click(object sender, EventArgs e)
        {
            lstMessages.Items.Clear();
            Cursor = Cursors.WaitCursor;
            btnSend.Enabled = false;
            Refresh();

            // Get email parameters.
            string from_name = txtFromName.Text;
            string from_email = txtFromEmail.Text;
            string host = txtHost.Text;
            int port = int.Parse(txtPort.Text);
            bool enable_ssl = chkEnableSSL.Checked;
            string password = txtPassword.Text;
            string subject = "Secret Santa assignment";

            // Get the recipients.
            char[] separators = { '\n', '\r' };
            string[] people =
                txtPeople.Text.Split(separators,
                    StringSplitOptions.RemoveEmptyEntries);

            // Get the secret Santa assignments.
            int num_people = people.Length;
            int num_tries;
            int[] assignments =
                SecretSantaAssignment(num_people, out num_tries);

            // Send the emails.
            try
            {
                for (int i = 0; i < num_people; i++)
                {
                    // Send people[i] his or her assignment.
                    string to_name = people[i].Split(';')[0];
                    string to_email = people[i].Split(';')[1];
                    string body =
                        "Your Secret Santa assignment is " +
                        people[assignments[i]];

                    Console.WriteLine(
                        "Sending message to " + to_name);
                    lstMessages.Items.Add(
                        "Sending message to " + to_name);
                    lstMessages.Refresh();
                    Application.DoEvents();

                    SendEmail(to_name, to_email,
                        from_name, from_email, host, port,
                        enable_ssl, password, subject, body);
                }
                MessageBox.Show("Sent " + num_people + " messages");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Cursor = Cursors.Default;
        }

        // Generate a random derangement.
        private int[] SecretSantaAssignment(int N, out int num_tries)
        {
            // Make an array to hold the assignment.
            int[] assignments = new int[N];
            for (int i = 0; i < N; i++)
                assignments[i] = i;

            // Try random permutations until we find one that works.
            //Console.WriteLine();
            num_tries = 0;
            for (; ; )
            {
                // Randomize the assignment array.
                num_tries++;
                assignments.Randomize();

                // Display this permutation.
                //for (int i = 0; i < N; i++) Console.Write(assignments[i].ToString() + " ");
                //Console.WriteLine();

                // If this is an invalid assignment, try again.
                bool is_valid = true;
                for (int i = 0; i < N; i++)
                {
                    if (assignments[i] == i)
                    {
                        is_valid = false;
                        break;
                    }
                }

                // See if this is a valid assignment.
                if (is_valid) break;
            }

            return assignments;
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
            this.txtFromName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.chkEnableSSL = new System.Windows.Forms.CheckBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFromEmail = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPeople = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstMessages = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtFromName
            // 
            this.txtFromName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromName.Location = new System.Drawing.Point(84, 12);
            this.txtFromName.Name = "txtFromName";
            this.txtFromName.Size = new System.Drawing.Size(290, 20);
            this.txtFromName.TabIndex = 19;
            this.txtFromName.Text = "Ben Baker";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "From Name:";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(84, 138);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(290, 20);
            this.txtPassword.TabIndex = 27;
            this.txtPassword.Text = "Password";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 141);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Password:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Enable SSL:";
            // 
            // btnSend
            // 
            this.btnSend.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSend.Location = new System.Drawing.Point(156, 295);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 33;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // chkEnableSSL
            // 
            this.chkEnableSSL.AutoSize = true;
            this.chkEnableSSL.Checked = true;
            this.chkEnableSSL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableSSL.Location = new System.Drawing.Point(84, 118);
            this.chkEnableSSL.Name = "chkEnableSSL";
            this.chkEnableSSL.Size = new System.Drawing.Size(15, 14);
            this.chkEnableSSL.TabIndex = 26;
            this.chkEnableSSL.UseVisualStyleBackColor = true;
            // 
            // txtPort
            // 
            this.txtPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPort.Location = new System.Drawing.Point(84, 90);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(290, 20);
            this.txtPort.TabIndex = 24;
            this.txtPort.Text = "587";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Port:";
            // 
            // txtFromEmail
            // 
            this.txtFromEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromEmail.Location = new System.Drawing.Point(84, 38);
            this.txtFromEmail.Name = "txtFromEmail";
            this.txtFromEmail.Size = new System.Drawing.Size(290, 20);
            this.txtFromEmail.TabIndex = 20;
            this.txtFromEmail.Text = "ben_baker@gmail.com";
            // 
            // txtHost
            // 
            this.txtHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHost.Location = new System.Drawing.Point(84, 64);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(290, 20);
            this.txtHost.TabIndex = 21;
            this.txtHost.Text = "smtp.live.com";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "From Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Host:";
            // 
            // txtPeople
            // 
            this.txtPeople.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPeople.Location = new System.Drawing.Point(84, 164);
            this.txtPeople.Multiline = true;
            this.txtPeople.Name = "txtPeople";
            this.txtPeople.Size = new System.Drawing.Size(290, 125);
            this.txtPeople.TabIndex = 35;
            this.txtPeople.Text = "Ann Archer;AnnA@gmail.com\r\nBob Baker;Bob_Baker@hotmail.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "People:";
            // 
            // lstMessages
            // 
            this.lstMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMessages.FormattingEnabled = true;
            this.lstMessages.IntegralHeight = false;
            this.lstMessages.Location = new System.Drawing.Point(84, 324);
            this.lstMessages.Name = "lstMessages";
            this.lstMessages.Size = new System.Drawing.Size(290, 57);
            this.lstMessages.TabIndex = 37;
            // 
            // howto_email_secret_santas_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 392);
            this.Controls.Add(this.lstMessages);
            this.Controls.Add(this.txtPeople);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFromName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.chkEnableSSL);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtFromEmail);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Name = "howto_email_secret_santas_Form1";
            this.Text = "howto_email_secret_santas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFromName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.CheckBox chkEnableSSL;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFromEmail;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPeople;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstMessages;
    }
}

