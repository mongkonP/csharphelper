using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This only works in .NET Framework 4.0 or later and Windows 7 or later.

// If the application is not allowed to use location services,
// the watcher's StatusChanged event never fires.

// Note that the CivicAddressResolver class's ResolveAddress method has not
// yet been implemented so you can't convert this into a street address.

// Add a reference to System.Device.
using System.Device.Location;

// Add a reference to System.Web.
using System.Web;

using Microsoft.Win32;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_map_computer_location_Form1:Form
  { 


        public howto_map_computer_location_Form1()
        {
            InitializeComponent();
        }

        // The coordinate watcher.
        private GeoCoordinateWatcher Watcher = null;

        // Create and start the watcher.
        private void howto_map_computer_location_Form1_Load(object sender, EventArgs e)
        {
            // Create the watcher.
            Watcher = new GeoCoordinateWatcher();

            // Catch the StatusChanged event.
            Watcher.StatusChanged += Watcher_StatusChanged;

            // Start the watcher.
            Watcher.Start();
        }

        // The watcher's status has change. See if it is ready.
        private void Watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            if (e.Status == GeoPositionStatus.Ready)
            {
                // Display the latitude and longitude.
                if (Watcher.Position.Location.IsUnknown)
                {
                    lblStatus.Text = "Cannot find location data";
                }
                else
                {
                    GeoCoordinate location =
                        Watcher.Position.Location;
                    DisplayMap(
                        location.Latitude,
                        location.Longitude);
                }
            }
        }

        // Display a map for this location.
        private void DisplayMap(double latitude, double longitude)
        {
            // Emulate Internet Explorer 11.
            SetWebBrowserVersion(11001);

            // Get the Google maps hybrid URL with defult zoom.
            string address = "loc:" +
                latitude.ToString() + "+" +
                longitude.ToString();
            string url = GoogleMapUrl(address, "Hybrid", 0);

            // Display the URL in the WebBrowser control.
            wbrMap.Navigate(url);

            // Hide the label and display the map.
            lblStatus.Hide();
            wbrMap.Show();
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
            // If the query starts with "loc:", don't encode.
            if (query.StartsWith("loc:"))
                url += "q=" + query;
            else
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
            this.wbrMap = new System.Windows.Forms.WebBrowser();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // wbrMap
            // 
            this.wbrMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbrMap.Location = new System.Drawing.Point(0, 0);
            this.wbrMap.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbrMap.Name = "wbrMap";
            this.wbrMap.Size = new System.Drawing.Size(484, 361);
            this.wbrMap.TabIndex = 0;
            this.wbrMap.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(187, 167);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(110, 26);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Working...";
            // 
            // howto_map_computer_location_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.wbrMap);
            this.Name = "howto_map_computer_location_Form1";
            this.Text = "howto_map_computer_location";
            this.Load += new System.EventHandler(this.howto_map_computer_location_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbrMap;
        private System.Windows.Forms.Label lblStatus;
    }
}

