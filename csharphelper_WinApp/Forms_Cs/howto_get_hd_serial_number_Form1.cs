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
     public partial class howto_get_hd_serial_number_Form1:Form
  { 


        public howto_get_hd_serial_number_Form1()
        {
            InitializeComponent();
        }

        private void howto_get_hd_serial_number_Form1_Load(object sender, EventArgs e)
        {
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

            foreach (ManagementObject info in searcher.Get())
            {
                TreeNode node = trvInfo.Nodes.Add(info["DeviceID"].ToString());
                node.Nodes.Add("Model: " + info["Model"].ToString());
                node.Nodes.Add("Interface: " + info["InterfaceType"].ToString());
                node.Nodes.Add("Serial#: " + info["SerialNumber"].ToString());
            }
            trvInfo.ExpandAll();
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
            this.trvInfo = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // trvInfo
            // 
            this.trvInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trvInfo.Location = new System.Drawing.Point(12, 12);
            this.trvInfo.Name = "trvInfo";
            this.trvInfo.Size = new System.Drawing.Size(310, 137);
            this.trvInfo.TabIndex = 0;
            // 
            // howto_get_hd_serial_number_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 161);
            this.Controls.Add(this.trvInfo);
            this.Name = "howto_get_hd_serial_number_Form1";
            this.Text = "howto_get_hd_serial_number";
            this.Load += new System.EventHandler(this.howto_get_hd_serial_number_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trvInfo;
    }
}

