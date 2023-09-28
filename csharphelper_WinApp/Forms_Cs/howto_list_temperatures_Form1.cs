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

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_list_temperatures_Form1:Form
  { 


        public howto_list_temperatures_Form1()
        {
            InitializeComponent();
        }

        // Enter your API key here.
        // Get an API key by making a free account at:
        //      http://home.openweathermap.org/users/sign_in
        private const string API_KEY = "9749874xw2kfiq9029j092m0j9kfj07e";

        // Query URLs. Replace @LOC@ with the location.
        private const string CurrentUrl =
            "http://api.openweathermap.org/data/2.5/weather?" +
            "q=@LOC@&mode=xml&units=imperial&APPID=" + API_KEY;
        private const string ForecastUrl =
            "http://api.openweathermap.org/data/2.5/forecast?" +
            "q=@LOC@&mode=xml&units=imperial&APPID=" + API_KEY;

        // List the temperature forecast.
        private void btnForecast_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            // Compose the query URL.
            string url = ForecastUrl.Replace("@LOC@", txtLocation.Text);

            // Create a web client.
            XmlDocument xml_doc;
            using (WebClient client = new WebClient())
            {
                // Get the response string from the URL.
                string xml = client.DownloadString(url);

                // Load the response into an XML document.
                xml_doc = new XmlDocument();
                xml_doc.LoadXml(xml);
            }

            // List the temperatures.
            ListTemperatures(xml_doc);

            Cursor = Cursors.Default;
        }

        // List the temperatures.
        private void ListTemperatures(XmlDocument xml_doc)
        {
            lvwTemps.Items.Clear();

            // Loop throuh the time entries.
            string last_day = "";
            foreach (XmlNode time_node in xml_doc.SelectNodes("//time"))
            {
                // Get the start date and time.
                XmlAttribute time_attr = time_node.Attributes["from"];
                DateTime start_time = DateTime.Parse(time_attr.Value);

                // Convert from UTC to local time.
                start_time = start_time.ToLocalTime();

                // Add 90 minutes to get to the middle of the interval.
                start_time += new TimeSpan(1, 30, 0);

                // Get the temperature node.
                XmlNode temp_node = time_node.SelectSingleNode("temperature");
                XmlAttribute temp_attr = temp_node.Attributes["value"];
                float temp = 0;
                if (temp_attr != null)
                    temp = float.Parse(temp_attr.Value.ToString());

                ListViewItem item;
                if (start_time.DayOfWeek.ToString() == last_day)
                    item = lvwTemps.Items.Add("");
                else
                {
                    last_day = start_time.DayOfWeek.ToString();
                    item = lvwTemps.Items.Add(last_day);
                }
                item.SubItems.Add(start_time.ToShortTimeString());
                item.SubItems.Add(temp.ToString("0.00"));
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.btnForecast = new System.Windows.Forms.Button();
            this.lvwTemps = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Temperature:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Location:";
            // 
            // txtLocation
            // 
            this.txtLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocation.Location = new System.Drawing.Point(69, 10);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(219, 20);
            this.txtLocation.TabIndex = 20;
            this.txtLocation.Text = "Denver, CO";
            // 
            // btnForecast
            // 
            this.btnForecast.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnForecast.Location = new System.Drawing.Point(113, 36);
            this.btnForecast.Name = "btnForecast";
            this.btnForecast.Size = new System.Drawing.Size(75, 23);
            this.btnForecast.TabIndex = 21;
            this.btnForecast.Text = "Forecast";
            this.btnForecast.UseVisualStyleBackColor = true;
            this.btnForecast.Click += new System.EventHandler(this.btnForecast_Click);
            // 
            // lvwTemps
            // 
            this.lvwTemps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwTemps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwTemps.Location = new System.Drawing.Point(15, 79);
            this.lvwTemps.Name = "lvwTemps";
            this.lvwTemps.Size = new System.Drawing.Size(273, 116);
            this.lvwTemps.TabIndex = 24;
            this.lvwTemps.UseCompatibleStateImageBehavior = false;
            this.lvwTemps.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Day";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Time";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Temperature";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 86;
            // 
            // howto_list_temperatures_Form1
            // 
            this.AcceptButton = this.btnForecast;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 207);
            this.Controls.Add(this.lvwTemps);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.btnForecast);
            this.Name = "howto_list_temperatures_Form1";
            this.Text = "howto_list_temperatures";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Button btnForecast;
        private System.Windows.Forms.ListView lvwTemps;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

