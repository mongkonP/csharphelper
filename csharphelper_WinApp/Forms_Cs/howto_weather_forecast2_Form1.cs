using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.Xml;
using System.IO;
using System.Globalization;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_weather_forecast2_Form1:Form
  { 


        public howto_weather_forecast2_Form1()
        {
            InitializeComponent();
        }

        // Enter your API key here.
        // Get an API key by making a free account at:
        //      http://home.openweathermap.org/users/sign_in
        private const string API_KEY = "12345678901234567890123456789012";

        // Query URLs. Replace @LOC@ with the location.
        private const string CurrentUrl =
            "http://api.openweathermap.org/data/2.5/weather?" +
            "@QUERY@=@LOC@&mode=xml&units=imperial&APPID=" + API_KEY;
        private const string ForecastUrl =
            "http://api.openweathermap.org/data/2.5/forecast?" +
            "@QUERY@=@LOC@&mode=xml&units=imperial&APPID=" + API_KEY;

        // Query codes.
        private string[] QueryCodes = { "q", "zip", "id", };

        // Fill in query types. These should match the QueryCodes.
        private void howto_weather_forecast2_Form1_Load(object sender, EventArgs e)
        {
            cboQuery.Items.Add("City");
            cboQuery.Items.Add("ZIP");
            cboQuery.Items.Add("ID");

            cboQuery.SelectedIndex = 1;
        }

        // Get a forecast.
        private void btnForecast_Click(object sender, EventArgs e)
        {
            // Compose the query URL.
            string url = ForecastUrl.Replace("@LOC@", txtLocation.Text);
            url = url.Replace("@QUERY@", QueryCodes[cboQuery.SelectedIndex]);

            // Create a web client.
            using (WebClient client = new WebClient())
            {
                // Get the response string from the URL.
                try
                {
                    DisplayForecast(client.DownloadString(url));
                }
                catch (WebException ex)
                {
                    DisplayError(ex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unknown error\n" + ex.Message);
                }
            }
        }

        // Display the forecast.
        private void DisplayForecast(string xml)
        {
            // Load the response into an XML document.
            XmlDocument xml_doc = new XmlDocument();
            xml_doc.LoadXml(xml);

            // Get the city, country, latitude, and longitude.
            XmlNode loc_node = xml_doc.SelectSingleNode("weatherdata/location");
            txtCity.Text = loc_node.SelectSingleNode("name").InnerText;
            txtCountry.Text = loc_node.SelectSingleNode("country").InnerText;
            XmlNode geo_node = loc_node.SelectSingleNode("location");
            txtLat.Text = geo_node.Attributes["latitude"].Value;
            txtLong.Text = geo_node.Attributes["longitude"].Value;
            txtId.Text = geo_node.Attributes["geobaseid"].Value;

            lvwForecast.Items.Clear();
            char degrees = (char)176;
            
            foreach (XmlNode time_node in xml_doc.SelectNodes("//time"))
            {
                // Get the time in UTC.
                DateTime time =
                    DateTime.Parse(time_node.Attributes["from"].Value,
                        null, DateTimeStyles.AssumeUniversal);

                // Get the temperature.
                XmlNode temp_node = time_node.SelectSingleNode("temperature");
                string temp = temp_node.Attributes["value"].Value;

                ListViewItem item = lvwForecast.Items.Add(time.DayOfWeek.ToString());
                item.SubItems.Add(time.ToShortTimeString());
                item.SubItems.Add(temp + degrees);
            }
        }

        // Display an error message.
        private void DisplayError(WebException exception)
        {
            try
            {
                StreamReader reader = new StreamReader(exception.Response.GetResponseStream());
                XmlDocument response_doc = new XmlDocument();
                response_doc.LoadXml(reader.ReadToEnd());
                XmlNode message_node = response_doc.SelectSingleNode("//message");
                MessageBox.Show(message_node.InnerText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unknown error\n" + ex.Message);
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.btnForecast = new System.Windows.Forms.Button();
            this.lvwForecast = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLong = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboQuery = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Forecast:";
            // 
            // txtLocation
            // 
            this.txtLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocation.Location = new System.Drawing.Point(91, 9);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(281, 20);
            this.txtLocation.TabIndex = 15;
            this.txtLocation.Text = "20500";
            // 
            // btnForecast
            // 
            this.btnForecast.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnForecast.Location = new System.Drawing.Point(155, 35);
            this.btnForecast.Name = "btnForecast";
            this.btnForecast.Size = new System.Drawing.Size(75, 23);
            this.btnForecast.TabIndex = 16;
            this.btnForecast.Text = "Forecast";
            this.btnForecast.UseVisualStyleBackColor = true;
            this.btnForecast.Click += new System.EventHandler(this.btnForecast_Click);
            // 
            // lvwForecast
            // 
            this.lvwForecast.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwForecast.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwForecast.Location = new System.Drawing.Point(12, 177);
            this.lvwForecast.Name = "lvwForecast";
            this.lvwForecast.Size = new System.Drawing.Size(360, 197);
            this.lvwForecast.TabIndex = 19;
            this.lvwForecast.UseCompatibleStateImageBehavior = false;
            this.lvwForecast.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Day";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Time";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Temperature";
            this.columnHeader3.Width = 100;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "City:";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(45, 74);
            this.txtCity.Name = "txtCity";
            this.txtCity.ReadOnly = true;
            this.txtCity.Size = new System.Drawing.Size(100, 20);
            this.txtCity.TabIndex = 21;
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(239, 74);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.ReadOnly = true;
            this.txtCountry.Size = new System.Drawing.Size(100, 20);
            this.txtCountry.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Country:";
            // 
            // txtLong
            // 
            this.txtLong.Location = new System.Drawing.Point(239, 100);
            this.txtLong.Name = "txtLong";
            this.txtLong.ReadOnly = true;
            this.txtLong.Size = new System.Drawing.Size(100, 20);
            this.txtLong.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(187, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Long:";
            // 
            // txtLat
            // 
            this.txtLat.Location = new System.Drawing.Point(45, 100);
            this.txtLat.Name = "txtLat";
            this.txtLat.ReadOnly = true;
            this.txtLat.Size = new System.Drawing.Size(100, 20);
            this.txtLat.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Lat:";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(45, 126);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "ID:";
            // 
            // cboQuery
            // 
            this.cboQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuery.FormattingEnabled = true;
            this.cboQuery.Location = new System.Drawing.Point(12, 8);
            this.cboQuery.Name = "cboQuery";
            this.cboQuery.Size = new System.Drawing.Size(73, 21);
            this.cboQuery.TabIndex = 30;
            // 
            // howto_weather_forecast2_Form1
            // 
            this.AcceptButton = this.btnForecast;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 386);
            this.Controls.Add(this.cboQuery);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtLong);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lvwForecast);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.btnForecast);
            this.Name = "howto_weather_forecast2_Form1";
            this.Text = "howto_weather_forecast2";
            this.Load += new System.EventHandler(this.howto_weather_forecast2_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Button btnForecast;
        private System.Windows.Forms.ListView lvwForecast;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboQuery;
    }
}

