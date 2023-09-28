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

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_wmi_get_os_name_Form1:Form
  { 


        public howto_wmi_get_os_name_Form1()
        {
            InitializeComponent();
        }

        // Display the operating system's name.
        private void howto_wmi_get_os_name_Form1_Load(object sender, EventArgs e)
        {
            // Get the OS information.
            // For more information from this query, see:
            //      http://msdn.microsoft.com/library/aa394239.aspx
            string os_query = "SELECT * FROM Win32_OperatingSystem";
            ManagementObjectSearcher os_searcher =
                new ManagementObjectSearcher(os_query);
            foreach (ManagementObject info in os_searcher.Get())
            {
                lblCaption.Text = info.Properties["Caption"].Value.ToString().Trim();
                lblVersion.Text = "Version " +
                    info.Properties["Version"].Value.ToString() +
                    " SP " +
                    info.Properties["ServicePackMajorVersion"].Value.ToString() + "." +
                    info.Properties["ServicePackMinorVersion"].Value.ToString();
            }

            // Get number of processors.
            // For more information from this query, see:
            //      http://msdn.microsoft.com/library/aa394373.aspx
            string cpus_query = "SELECT * FROM Win32_ComputerSystem";
            ManagementObjectSearcher cpus_searcher =
                new ManagementObjectSearcher(cpus_query);
            foreach (ManagementObject info in cpus_searcher.Get())
            {
                lblCpus.Text = info.Properties["NumberOfLogicalProcessors"].Value.ToString()
                    + " processors";
            }

            // Get 32- versus 64-bit.
            // For more information from this query, see:
            //      http://msdn.microsoft.com/library/aa394373.aspx
            string proc_query = "SELECT * FROM Win32_Processor";
            ManagementObjectSearcher proc_searcher =
                new ManagementObjectSearcher(proc_query);
            foreach (ManagementObject info in proc_searcher.Get())
            {
                lblBits.Text = info.Properties["AddressWidth"].Value.ToString() + "-bit";
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
            this.lblCaption = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblBits = new System.Windows.Forms.Label();
            this.lblCpus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.Location = new System.Drawing.Point(12, 9);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(278, 23);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "Caption";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(12, 39);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(278, 23);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "Version";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBits
            // 
            this.lblBits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBits.Location = new System.Drawing.Point(12, 99);
            this.lblBits.Name = "lblBits";
            this.lblBits.Size = new System.Drawing.Size(278, 23);
            this.lblBits.TabIndex = 3;
            this.lblBits.Text = "Bits";
            this.lblBits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCpus
            // 
            this.lblCpus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCpus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCpus.Location = new System.Drawing.Point(12, 69);
            this.lblCpus.Name = "lblCpus";
            this.lblCpus.Size = new System.Drawing.Size(278, 23);
            this.lblCpus.TabIndex = 2;
            this.lblCpus.Text = "CPUs";
            this.lblCpus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_wmi_get_os_name_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 130);
            this.Controls.Add(this.lblBits);
            this.Controls.Add(this.lblCpus);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblCaption);
            this.Name = "howto_wmi_get_os_name_Form1";
            this.Text = "howto_wmi_get_os_name";
            this.Load += new System.EventHandler(this.howto_wmi_get_os_name_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblBits;
        private System.Windows.Forms.Label lblCpus;

    }
}

