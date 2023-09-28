using System;
using System.Collections.Generic;
using System.Windows.Forms;

// Add a reference to System.Web.Extensions.dll.
// C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\v3.5\System.Web.Extensions.dll
using System.Web.Script.Serialization;

using System.IO;
using System.Net;

 

using howto_parse_unknown_json;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_parse_unknown_json_Form1:Form
  { 


        public howto_parse_unknown_json_Form1()
        {
            InitializeComponent();
        }

        private void howto_parse_unknown_json_Form1_Load(object sender, EventArgs e)
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
                        carrier_info.Emails.Add(email.Replace("{number}", ""));
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
            this.label3 = new System.Windows.Forms.Label();
            this.cboEmail = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCarrier = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCountry = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Email:";
            // 
            // cboEmail
            // 
            this.cboEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboEmail.FormattingEnabled = true;
            this.cboEmail.Location = new System.Drawing.Point(64, 66);
            this.cboEmail.Name = "cboEmail";
            this.cboEmail.Size = new System.Drawing.Size(248, 21);
            this.cboEmail.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Carrier:";
            // 
            // cboCarrier
            // 
            this.cboCarrier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCarrier.FormattingEnabled = true;
            this.cboCarrier.Location = new System.Drawing.Point(64, 39);
            this.cboCarrier.Name = "cboCarrier";
            this.cboCarrier.Size = new System.Drawing.Size(248, 21);
            this.cboCarrier.TabIndex = 8;
            this.cboCarrier.SelectedIndexChanged += new System.EventHandler(this.cboCarrier_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Country:";
            // 
            // cboCountry
            // 
            this.cboCountry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCountry.FormattingEnabled = true;
            this.cboCountry.Location = new System.Drawing.Point(64, 12);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(248, 21);
            this.cboCountry.TabIndex = 6;
            this.cboCountry.SelectedIndexChanged += new System.EventHandler(this.cboCountry_SelectedIndexChanged);
            // 
            // howto_parse_unknown_json_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 161);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboCarrier);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboCountry);
            this.Name = "howto_parse_unknown_json_Form1";
            this.Text = "howto_parse_unknown_json";
            this.Load += new System.EventHandler(this.howto_parse_unknown_json_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCarrier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCountry;
    }
}

