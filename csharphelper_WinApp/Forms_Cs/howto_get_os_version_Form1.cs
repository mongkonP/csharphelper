using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_get_os_version_Form1:Form
  { 


        public howto_get_os_version_Form1()
        {
            InitializeComponent();
        }

        private void howto_get_os_version_Form1_Load(object sender, EventArgs e)
        {
            OperatingSystem os_info = System.Environment.OSVersion;
            lblOs.Text = os_info.VersionString +
                "\n\nWindows " + GetOsName(os_info);
        }

        // Return the OS name.
        private string GetOsName(OperatingSystem os_info)
        {
            string version =
                os_info.Version.Major.ToString() + "." +
                os_info.Version.Minor.ToString();
            switch (version)
            {
                case "10.0": return "10/Server 2016";
                case "6.3": return "8.1/Server 2012 R2";
                case "6.2": return "8/Server 2012";
                case "6.1": return "7/Server 2008 R2";
                case "6.0": return "Server 2008/Vista";
                case "5.2": return "Server 2003 R2/Server 2003/XP 64-Bit Edition";
                case "5.1": return "XP";
                case "5.0": return "2000";
            }
            return "Unknown";
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
            this.lblOs = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblOs
            // 
            this.lblOs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOs.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOs.Location = new System.Drawing.Point(0, 0);
            this.lblOs.Name = "lblOs";
            this.lblOs.Size = new System.Drawing.Size(294, 150);
            this.lblOs.TabIndex = 1;
            this.lblOs.Text = "label1";
            this.lblOs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_get_os_version_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 150);
            this.Controls.Add(this.lblOs);
            this.Name = "howto_get_os_version_Form1";
            this.Text = "howto_get_os_version";
            this.Load += new System.EventHandler(this.howto_get_os_version_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblOs;
    }
}

