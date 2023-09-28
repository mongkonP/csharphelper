using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Add a reference to System.Web.
using System.Web;
using Microsoft.Win32;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_address_integrated_map_Form1:Form
  { 


        public howto_address_integrated_map_Form1()
        {
            InitializeComponent();
        }

        // Make the WebBrowser emulate Internet Explorer 11.
        // Select a default map type.
        private void howto_address_integrated_map_Form1_Load(object sender, EventArgs e)
        {
            SetWebBrowserVersion(11001);
            cboGoogle.SelectedIndex = 0;
        }

        // Display a Google map.
        private void btnGoogle_Click(object sender, EventArgs e)
        {
            // Get the Google maps URL with defult zoom.
            string url = GoogleMapUrl(txtAddress.Text, cboGoogle.Text, 0);

            // Display the URL in the WebBrowser control.
            wbrMap.Navigate(url);
        }

        // Return a Google map URL.
        // The URL format is:
        //      http://maps.google.com/maps?q=QUERY&t=TYPE&z=ZOOM
        //  Where:
        //      QUERY is the query. If it begins with "loc:" then its latitude+longitude.
        //      TYPE is map type:
        //          m = Map
        //          k = Satellite
        //          h = Hybrid
        //          p = Terrain
        //          e = Google Earth
        //      ZOOM is the zoom level, usually 1 - 20.
        private string GoogleMapUrl(string query, string map_type, int zoom)
        {
            // Start with the base map URL.
            string url = "http://maps.google.com/maps?";

            // Add the query.
            url += "q=" + HttpUtility.UrlEncode(query, Encoding.UTF8);

            // Add the type.
            map_type = GoogleMapTypeCode(map_type);
            if (map_type != null) url += "&t=" + map_type;

            // Add the zoom level.
            if (zoom > 0) url += "&z=" + zoom.ToString();

            return url;
        }

        // Return a Google map type code.
        private string GoogleMapTypeCode(string map_type)
        {
            // Insert the proper type.
            switch (map_type)
            {
                case "Map":
                    return "m";
                case "Satellite":
                    return "k";
                case "Hybrid":
                    return "h";
                case "Terrain":
                    return "p";
                case "Google Earth":
                    return "e";
                default:
                    return null;
            }
        }

        // Make the WebBrowser control emulate the indicated IE version.
        // See:
        //      https://msdn.microsoft.com/library/ee330730.aspx#browser_emulation
        private void SetWebBrowserVersion(int ie_version)
        {
            // For testing:
            //DeleteRegistryValue(key64bit, app_name);
            //DeleteRegistryValue(key32bit, app_name);

            const string key64bit =
                @"SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION";
            const string key32bit =
                @"SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION";
            string app_name = System.AppDomain.CurrentDomain.FriendlyName;

            // You can do both if you like.
            //SetRegistryDword(key64bit, app_name, ie_version);
            SetRegistryDword(key32bit, app_name, ie_version);
        }

        // Set a registry DWORD value.
        private void SetRegistryDword(string key_name, string value_name, int value)
        {
            // Open the key.
            RegistryKey key =
                Registry.CurrentUser.OpenSubKey(key_name, true);
            if (key == null)
                key = Registry.CurrentUser.CreateSubKey(key_name,
                    RegistryKeyPermissionCheck.ReadWriteSubTree);

            // Set the desired value.
            key.SetValue(value_name, value, RegistryValueKind.DWord);

            key.Close();
        }

        // Delete a registry value.
        private void DeleteRegistryValue(string key_name, string value_name)
        {
            // Open the key.
            RegistryKey key =
                Registry.CurrentUser.OpenSubKey(key_name, true);
            if (key == null) return;

            // Delete the desired value.
            key.DeleteValue(value_name, false);

            key.Close();
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
            this.cboGoogle = new System.Windows.Forms.ComboBox();
            this.btnGoogle = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.wbrMap = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // cboGoogle
            // 
            this.cboGoogle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboGoogle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGoogle.FormattingEnabled = true;
            this.cboGoogle.Items.AddRange(new object[] {
            "Map",
            "Satellite",
            "Hybrid",
            "Terrain",
            "Google Earth"});
            this.cboGoogle.Location = new System.Drawing.Point(323, 12);
            this.cboGoogle.Name = "cboGoogle";
            this.cboGoogle.Size = new System.Drawing.Size(115, 21);
            this.cboGoogle.TabIndex = 1;
            // 
            // btnGoogle
            // 
            this.btnGoogle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGoogle.Location = new System.Drawing.Point(444, 12);
            this.btnGoogle.Name = "btnGoogle";
            this.btnGoogle.Size = new System.Drawing.Size(65, 21);
            this.btnGoogle.TabIndex = 2;
            this.btnGoogle.Text = "Google";
            this.btnGoogle.UseVisualStyleBackColor = true;
            this.btnGoogle.Click += new System.EventHandler(this.btnGoogle_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(66, 12);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(251, 20);
            this.txtAddress.TabIndex = 0;
            this.txtAddress.Text = "1600 Pennsylvania Avenue; NW Washington, D.C. 20500";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 15);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(48, 13);
            this.Label1.TabIndex = 17;
            this.Label1.Text = "Address:";
            // 
            // wbrMap
            // 
            this.wbrMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wbrMap.Location = new System.Drawing.Point(12, 38);
            this.wbrMap.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbrMap.Name = "wbrMap";
            this.wbrMap.Size = new System.Drawing.Size(497, 331);
            this.wbrMap.TabIndex = 3;
            // 
            // howto_address_integrated_map_Form1
            // 
            this.AcceptButton = this.btnGoogle;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 381);
            this.Controls.Add(this.cboGoogle);
            this.Controls.Add(this.btnGoogle);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.wbrMap);
            this.Name = "howto_address_integrated_map_Form1";
            this.Text = "howto_address_integrated_map";
            this.Load += new System.EventHandler(this.howto_address_integrated_map_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox cboGoogle;
        internal System.Windows.Forms.Button btnGoogle;
        internal System.Windows.Forms.TextBox txtAddress;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.WebBrowser wbrMap;
    }
}

