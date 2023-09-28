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
     public partial class howto_weather_forecast_Form1:Form
  { 


        public howto_weather_forecast_Form1()
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

        // Get current conditions.
        private void btnConditions_Click(object sender, EventArgs e)
        {
            // Compose the query URL.
            string url = CurrentUrl.Replace("@LOC@", txtLocation.Text);
            txtXml.Text = GetFormattedXml(url);
        }

        // Get a forecast.
        private void btnForecast_Click(object sender, EventArgs e)
        {
            // Compose the query URL.
            string url = ForecastUrl.Replace("@LOC@", txtLocation.Text);
            txtXml.Text = GetFormattedXml(url);
        }

        // Return the XML result of the URL.
        private string GetFormattedXml(string url)
        {
            // Create a web client.
            using (WebClient client = new WebClient())
            {
                // Get the response string from the URL.
                string xml = client.DownloadString(url);

                // Load the response into an XML document.
                XmlDocument xml_document = new XmlDocument();
                xml_document.LoadXml(xml);

                // Format the XML.
                using (StringWriter string_writer = new StringWriter())
                {
                    XmlTextWriter xml_text_writer = new XmlTextWriter(string_writer);
                    xml_text_writer.Formatting = Formatting.Indented;
                    xml_document.WriteTo(xml_text_writer);

                    // Return the result.
                    return string_writer.ToString();
                }
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
            this.btnForecast = new System.Windows.Forms.Button();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtXml = new System.Windows.Forms.TextBox();
            this.btnConditions = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnForecast
            // 
            this.btnForecast.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnForecast.Location = new System.Drawing.Point(195, 38);
            this.btnForecast.Name = "btnForecast";
            this.btnForecast.Size = new System.Drawing.Size(75, 23);
            this.btnForecast.TabIndex = 2;
            this.btnForecast.Text = "Forecast";
            this.btnForecast.UseVisualStyleBackColor = true;
            this.btnForecast.Click += new System.EventHandler(this.btnForecast_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocation.Location = new System.Drawing.Point(69, 12);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(303, 20);
            this.txtLocation.TabIndex = 0;
            this.txtLocation.Text = "London";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "XML:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Location:";
            // 
            // txtXml
            // 
            this.txtXml.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtXml.Location = new System.Drawing.Point(12, 95);
            this.txtXml.Multiline = true;
            this.txtXml.Name = "txtXml";
            this.txtXml.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtXml.Size = new System.Drawing.Size(360, 154);
            this.txtXml.TabIndex = 3;
            this.txtXml.WordWrap = false;
            // 
            // btnConditions
            // 
            this.btnConditions.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnConditions.Location = new System.Drawing.Point(114, 38);
            this.btnConditions.Name = "btnConditions";
            this.btnConditions.Size = new System.Drawing.Size(75, 23);
            this.btnConditions.TabIndex = 1;
            this.btnConditions.Text = "Conditions";
            this.btnConditions.UseVisualStyleBackColor = true;
            this.btnConditions.Click += new System.EventHandler(this.btnConditions_Click);
            // 
            // howto_weather_forecast_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.btnConditions);
            this.Controls.Add(this.txtXml);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.btnForecast);
            this.Name = "howto_weather_forecast_Form1";
            this.Text = "howto_weather_forecast";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnForecast;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtXml;
        private System.Windows.Forms.Button btnConditions;
    }
}

