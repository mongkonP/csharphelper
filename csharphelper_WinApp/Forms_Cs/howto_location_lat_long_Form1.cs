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

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_location_lat_long_Form1:Form
  { 


        public howto_location_lat_long_Form1()
        {
            InitializeComponent();
        }

        // The coordinate watcher.
        private GeoCoordinateWatcher Watcher = null;

        // Create and start the watcher.
        private void howto_location_lat_long_Form1_Load(object sender, EventArgs e)
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
                    txtLat.Text = "Cannot find location data";
                }
                else
                {
                    GeoCoordinate location =
                        Watcher.Position.Location;
                    txtLat.Text = location.Latitude.ToString();
                    txtLong.Text = location.Longitude.ToString();
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.txtLong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Latitude:";
            // 
            // txtLat
            // 
            this.txtLat.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLat.Location = new System.Drawing.Point(136, 12);
            this.txtLat.Name = "txtLat";
            this.txtLat.Size = new System.Drawing.Size(100, 20);
            this.txtLat.TabIndex = 1;
            this.txtLat.Text = "waiting...";
            this.txtLat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLong
            // 
            this.txtLong.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLong.Location = new System.Drawing.Point(136, 38);
            this.txtLong.Name = "txtLong";
            this.txtLong.Size = new System.Drawing.Size(100, 20);
            this.txtLong.TabIndex = 3;
            this.txtLong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Longitude:";
            // 
            // howto_location_lat_long_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 71);
            this.Controls.Add(this.txtLong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLat);
            this.Controls.Add(this.label1);
            this.Name = "howto_location_lat_long_Form1";
            this.Text = "howto_location_lat_long";
            this.Load += new System.EventHandler(this.howto_location_lat_long_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.TextBox txtLong;
        private System.Windows.Forms.Label label2;
    }
}

