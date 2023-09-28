using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Add a reference to System.Management.
using System.Management;

// For more information on the Win32_PnPEntity class, see:
// http://msdn.microsoft.com/en-us/library/windows/desktop/aa394353%28v=vs.85%29.aspx

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_list_usb_devices_Form1:Form
  { 


        public howto_list_usb_devices_Form1()
        {
            InitializeComponent();
        }

        private void howto_list_usb_devices_Form1_Load(object sender, EventArgs e)
        {
            ManagementObjectSearcher device_searcher =
                new ManagementObjectSearcher("SELECT * FROM Win32_USBHub");
            foreach (ManagementObject usb_device in device_searcher.Get())
            {
                ListViewItem new_item = lvwDevices.Items.Add(usb_device.Properties["DeviceID"].Value.ToString());
                new_item.SubItems.Add(usb_device.Properties["PNPDeviceID"].Value.ToString());
                new_item.SubItems.Add(usb_device.Properties["Description"].Value.ToString());
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
            this.colPnPDeviceId = new System.Windows.Forms.ColumnHeader();
            this.lvwDevices = new System.Windows.Forms.ListView();
            this.colDevice = new System.Windows.Forms.ColumnHeader();
            this.colDescription = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // colPnPDeviceId
            // 
            this.colPnPDeviceId.Text = "PnP Device ID";
            this.colPnPDeviceId.Width = 250;
            // 
            // lvwDevices
            // 
            this.lvwDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwDevices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDevice,
            this.colPnPDeviceId,
            this.colDescription});
            this.lvwDevices.Location = new System.Drawing.Point(12, 12);
            this.lvwDevices.Name = "lvwDevices";
            this.lvwDevices.Size = new System.Drawing.Size(628, 159);
            this.lvwDevices.TabIndex = 1;
            this.lvwDevices.UseCompatibleStateImageBehavior = false;
            this.lvwDevices.View = System.Windows.Forms.View.Details;
            // 
            // colDevice
            // 
            this.colDevice.Text = "Device";
            this.colDevice.Width = 250;
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 100;
            // 
            // howto_list_usb_devices_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 183);
            this.Controls.Add(this.lvwDevices);
            this.Name = "howto_list_usb_devices_Form1";
            this.Text = "howto_list_usb_devices";
            this.Load += new System.EventHandler(this.howto_list_usb_devices_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader colPnPDeviceId;
        private System.Windows.Forms.ListView lvwDevices;
        private System.Windows.Forms.ColumnHeader colDevice;
        private System.Windows.Forms.ColumnHeader colDescription;
    }
}

