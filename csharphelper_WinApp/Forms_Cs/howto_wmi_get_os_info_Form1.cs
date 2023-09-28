using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Add a reference to the System.Management.
using System.Management;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_wmi_get_os_info_Form1:Form
  { 


        public howto_wmi_get_os_info_Form1()
        {
            InitializeComponent();
        }

        // Get and display OS properties.
        private void howto_wmi_get_os_info_Form1_Load(object sender, EventArgs e)
        {
            ManagementObjectSearcher os_searcher = 
                new ManagementObjectSearcher(
                    "SELECT * FROM Win32_OperatingSystem");
            foreach (ManagementObject mobj in os_searcher.Get())
            {
                GetValue(mobj, "BootDevice");
                GetValue(mobj, "BuildNumber");
                GetValue(mobj, "BuildType");
                GetValue(mobj, "Caption");
                GetValue(mobj, "CodeSet");
                GetValue(mobj, "CountryCode");
                GetValue(mobj, "CreationClassName");
                GetValue(mobj, "CSCreationClassName");
                GetValue(mobj, "CSDVersion");
                GetValue(mobj, "CSName");
                GetValue(mobj, "CurrentTimeZone");
                GetValue(mobj, "DataExecutionPrevention_Available");
                GetValue(mobj, "DataExecutionPrevention_32BitApplications");
                GetValue(mobj, "DataExecutionPrevention_Drivers");
                GetValue(mobj, "DataExecutionPrevention_SupportPolicy");
                GetValue(mobj, "Debug");
                GetValue(mobj, "Description");
                GetValue(mobj, "Distributed");
                GetValue(mobj, "EncryptionLevel");
                GetValue(mobj, "ForegroundApplicationBoost");
                GetValue(mobj, "FreePhysicalMemory");
                GetValue(mobj, "FreeSpaceInPagingFiles");
                GetValue(mobj, "FreeVirtualMemory");
                GetValue(mobj, "InstallDate");
                GetValue(mobj, "LargeSystemCache");
                GetValue(mobj, "LastBootUpTime");
                GetValue(mobj, "LocalDateTime");
                GetValue(mobj, "Locale");
                GetValue(mobj, "Manufacturer");
                GetValue(mobj, "MaxNumberOfProcesses");
                GetValue(mobj, "MaxProcessMemorySize");
                GetValue(mobj, "MUILanguages[]");
                GetValue(mobj, "Name");
                GetValue(mobj, "NumberOfLicensedUsers");
                GetValue(mobj, "NumberOfProcesses");
                GetValue(mobj, "NumberOfUsers");
                GetValue(mobj, "OperatingSystemSKU");
                GetValue(mobj, "Organization");
                GetValue(mobj, "OSArchitecture");
                GetValue(mobj, "OSLanguage");
                GetValue(mobj, "OSProductSuite");
                GetValue(mobj, "OSType");
                GetValue(mobj, "OtherTypeDescription");
                GetValue(mobj, "PAEEnabled");
                GetValue(mobj, "PlusProductID");
                GetValue(mobj, "PlusVersionNumber");
                GetValue(mobj, "Primary");
                GetValue(mobj, "ProductType");
                GetValue(mobj, "QuantumLength");
                GetValue(mobj, "QuantumType");
                GetValue(mobj, "RegisteredUser");
                GetValue(mobj, "SerialNumber");
                GetValue(mobj, "ServicePackMajorVersion");
                GetValue(mobj, "ServicePackMinorVersion");
                GetValue(mobj, "SizeStoredInPagingFiles");
                GetValue(mobj, "Status");
                GetValue(mobj, "SuiteMask");
                GetValue(mobj, "SystemDevice");
                GetValue(mobj, "SystemDirectory");
                GetValue(mobj, "SystemDrive");
                GetValue(mobj, "TotalSwapSpaceSize");
                GetValue(mobj, "TotalVirtualMemorySize");
                GetValue(mobj, "TotalVisibleMemorySize");
                GetValue(mobj, "Version");
                GetValue(mobj, "WindowsDirectory");
            }

            // Auto-size the columns.
            foreach (ColumnHeader col in lvwResults.Columns)
            {
                col.Width = -2;
            }
        }

        // Get a value from the ManagementObject.
        private void GetValue(ManagementObject mobj, string property_name)
        {
            string value;
            try
            {
                value = mobj[property_name].ToString();
            }
            catch (Exception ex)
            {
                value = "*** Error: " + ex.Message;
            }

            lvwResults.Items.Add(property_name).SubItems.Add(value);
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
            this.lvwResults = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lvwResults
            // 
            this.lvwResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lvwResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwResults.Location = new System.Drawing.Point(0, 0);
            this.lvwResults.Name = "lvwResults";
            this.lvwResults.Size = new System.Drawing.Size(484, 264);
            this.lvwResults.TabIndex = 2;
            this.lvwResults.UseCompatibleStateImageBehavior = false;
            this.lvwResults.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Property";
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Value";
            // 
            // howto_wmi_get_os_info_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 264);
            this.Controls.Add(this.lvwResults);
            this.Name = "howto_wmi_get_os_info_Form1";
            this.Text = "howto_wmi_get_os_info";
            this.Load += new System.EventHandler(this.howto_wmi_get_os_info_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListView lvwResults;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader2;
    }
}

