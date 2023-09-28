using System;
using System.Collections.Generic;
using System.Windows.Forms;

// Add a reference to System.Web.Extensions.dll.
using System.Web.Script.Serialization;

using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web;

 

using howto_send_sms;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_send_sms_Form1:Form
  { 


        public howto_send_sms_Form1()
        {
            InitializeComponent();
        }

        private void howto_send_sms_Form1_Load(object sender, EventArgs e)
        {
            // Get the data file.
            const string url = "https://raw.github.com/cubiclesoft/email_sms_mms_gateways/master/sms_mms_gateways.txt";
            string serialization = GetTextFile(url);

            // Add a reference to System.Web.Extensions.dll.
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Dictionary<string, object> dict =
                (Dictionary<string, object>)serializer.DeserializeObject(serialization);

            // Get the countries.
            Dictionary<string, CountryInfo> country_infos = new Dictionary<string, CountryInfo>();
            Dictionary<string, object> countries = (Dictionary<string, object>)dict["countries"];
            foreach (KeyValuePair<string, object> pair in countries)
            {
                CountryInfo country_info = new CountryInfo() { CountryAbbreviation = pair.Key, CountryName = (string)pair.Value };
                country_infos.Add(country_info.CountryAbbreviation, country_info);
            }

            // Get the SMS carriers.
            Dictionary<string, object> sms_carriers = (Dictionary<string, object>)dict["sms_carriers"];
            foreach (KeyValuePair<string, object> pair in sms_carriers)
            {
                // Get the corresponding CountryInfo.
                CountryInfo country_info = country_infos[pair.Key];

                // Get the country's carriers.
                Dictionary<string, object> carriers = (Dictionary<string, object>)pair.Value;
                foreach (KeyValuePair<string, object> carrier_pair in carriers)
                {
                    // Create a CarrierInfo for this carrier.
                    CarrierInfo carrier_info = new CarrierInfo() { CarrierAbbreviation = carrier_pair.Key };
                    country_info.Carriers.Add(carrier_info);
                    object[] carrier_values = (object[])carrier_pair.Value;
                    carrier_info.CarrierName = (string)carrier_values[0];
                    for (int email_index = 1; email_index < carrier_values.Length; email_index++)
                    {
                        string email = (string)carrier_values[email_index];
                        carrier_info.Emails.Add(email.Replace("{number}@", ""));
                    }
                }
            }

            // Display the countries.
            cboCountry.Items.Clear();
            foreach (CountryInfo country in country_infos.Values)
            {
                cboCountry.Items.Add(country);
            }

            // Make an initial selection.
            cboCountry.SelectedIndex = 0;
        }

        // Get the text file at a given URL.
        private string GetTextFile(string url)
        {
            try
            {
                url = url.Trim();
                if (!url.ToLower().StartsWith("http")) url = "http://" + url;
                WebClient web_client = new WebClient();
                MemoryStream image_stream = new MemoryStream(web_client.DownloadData(url));
                StreamReader reader = new StreamReader(image_stream);
                string result = reader.ReadToEnd();
                reader.Close();
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error downloading file " +
                    url + '\n' + ex.Message,
                    "Download Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            return "";
        }

        // Display the selected country's carriers.
        private void cboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCountry.SelectedIndex < 0)
            {
                cboCarrier.SelectedIndex = -1;
            }
            else
            {
                // Get the selected CountryInfo object.
                CountryInfo country = cboCountry.SelectedItem as CountryInfo;
                Console.WriteLine("Country: " + country.CountryAbbreviation + ": " + country.CountryName);

                // Display the CountryCarrier's carriers.
                cboCarrier.DataSource = country.Carriers;
            }
        }

        // Display the selected carrier's emails addresses.
        private void cboCarrier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCarrier.SelectedIndex < 0)
            {
                cboEmail.SelectedIndex = -1;
            }
            else
            {
                // Get the selected CarrierInfo object.
                CarrierInfo carrier = cboCarrier.SelectedItem as CarrierInfo;
                Console.WriteLine("Carrier: " + carrier.CarrierName);

                // Display the Carrier's email addresses.
                cboEmail.DataSource = carrier.Emails;
            }
        }

        // Send the message.
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string carrier_email = cboEmail.SelectedItem.ToString();
                string phone = txtPhone.Text.Trim().Replace("-", "");
                phone = phone.Replace("(", "").Replace(")", "").Replace("+", "");
                string to_email = phone + "@" + carrier_email;

                SendEmail(txtToName.Text, to_email,
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtToName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboEmail = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboCarrier = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboCountry = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFromName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Phone #:";
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone.Location = new System.Drawing.Point(94, 100);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(160, 20);
            this.txtPhone.TabIndex = 3;
            this.txtPhone.Text = "234-567-8901";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtToName);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboEmail);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboCarrier);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cboCountry);
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 154);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recipient";
            // 
            // txtToName
            // 
            this.txtToName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToName.Location = new System.Drawing.Point(94, 126);
            this.txtToName.Name = "txtToName";
            this.txtToName.Size = new System.Drawing.Size(160, 20);
            this.txtToName.TabIndex = 4;
            this.txtToName.Text = "Ann Archer";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 129);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "To Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Email:";
            // 
            // cboEmail
            // 
            this.cboEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboEmail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmail.FormattingEnabled = true;
            this.cboEmail.Location = new System.Drawing.Point(94, 73);
            this.cboEmail.Name = "cboEmail";
            this.cboEmail.Size = new System.Drawing.Size(160, 21);
            this.cboEmail.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Carrier:";
            // 
            // cboCarrier
            // 
            this.cboCarrier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCarrier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCarrier.FormattingEnabled = true;
            this.cboCarrier.Location = new System.Drawing.Point(94, 46);
            this.cboCarrier.Name = "cboCarrier";
            this.cboCarrier.Size = new System.Drawing.Size(160, 21);
            this.cboCarrier.TabIndex = 1;
            this.cboCarrier.SelectedIndexChanged += new System.EventHandler(this.cboCarrier_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Country:";
            // 
            // cboCountry
            // 
            this.cboCountry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCountry.FormattingEnabled = true;
            this.cboCountry.Location = new System.Drawing.Point(94, 19);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(160, 21);
            this.cboCountry.TabIndex = 0;
            this.cboCountry.SelectedIndexChanged += new System.EventHandler(this.cboCountry_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtFromName);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.chkEnableSSL);
            this.groupBox2.Controls.Add(this.txtPort);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtHost);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtFromEmail);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 172);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 174);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sender";
            // 
            // txtFromName
            // 
            this.txtFromName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromName.Location = new System.Drawing.Point(94, 19);
            this.txtFromName.Name = "txtFromName";
            this.txtFromName.Size = new System.Drawing.Size(160, 20);
            this.txtFromName.TabIndex = 0;
            this.txtFromName.Text = "Ben Baker";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "From Name:";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(94, 145);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(160, 20);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.Text = "Password";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 148);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Password:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 125);
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
            this.chkEnableSSL.Location = new System.Drawing.Point(94, 125);
            this.chkEnableSSL.Name = "chkEnableSSL";
            this.chkEnableSSL.Size = new System.Drawing.Size(15, 14);
            this.chkEnableSSL.TabIndex = 4;
            this.chkEnableSSL.UseVisualStyleBackColor = true;
            // 
            // txtPort
            // 
            this.txtPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPort.Location = new System.Drawing.Point(94, 97);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(160, 20);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "587";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Port:";
            // 
            // txtHost
            // 
            this.txtHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHost.Location = new System.Drawing.Point(94, 71);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(160, 20);
            this.txtHost.TabIndex = 2;
            this.txtHost.Text = "smtp.live.com";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Host:";
            // 
            // txtFromEmail
            // 
            this.txtFromEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromEmail.Location = new System.Drawing.Point(94, 45);
            this.txtFromEmail.Name = "txtFromEmail";
            this.txtFromEmail.Size = new System.Drawing.Size(160, 20);
            this.txtFromEmail.TabIndex = 1;
            this.txtFromEmail.Text = "ben_baker@gmail.com";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "From Email:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtBody);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtSubject);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(12, 352);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(260, 74);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Message";
            // 
            // txtBody
            // 
            this.txtBody.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBody.Location = new System.Drawing.Point(94, 45);
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(160, 20);
            this.txtBody.TabIndex = 1;
            this.txtBody.Text = "This is a test SMS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Body:";
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.Location = new System.Drawing.Point(94, 19);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(160, 20);
            this.txtSubject.TabIndex = 0;
            this.txtSubject.Text = "Test message";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Subject:";
            // 
            // btnSend
            // 
            this.btnSend.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSend.Location = new System.Drawing.Point(105, 432);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // howto_send_sms_Form1
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 461);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "howto_send_sms_Form1";
            this.Text = "howto_send_sms";
            this.Load += new System.EventHandler(this.howto_send_sms_Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFromEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboCarrier;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboCountry;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkEnableSSL;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFromName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtToName;
        private System.Windows.Forms.Label label13;
    }
}

