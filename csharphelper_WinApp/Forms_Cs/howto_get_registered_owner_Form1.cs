using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Win32;

 

using howto_get_registered_owner;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_get_registered_owner_Form1:Form
  { 


        public howto_get_registered_owner_Form1()
        {
            InitializeComponent();
        }

        private void howto_get_registered_owner_Form1_Load(object sender, EventArgs e)
        {
            object owner_string = "", company_string = "";
            OperatingSystem os_info = System.Environment.OSVersion;
            if (os_info.Platform == PlatformID.Win32Windows)
            {
                // Windows 98?
                owner_string = RegistryTools.GetRegistryValue(
                    Registry.LocalMachine,
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\",
                    "RegisteredOwner", "Unknown");
                company_string = RegistryTools.GetRegistryValue(
                    Registry.LocalMachine,
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\",
                    "RegisteredOrganization", "Unknown");
            }
            else if (os_info.Platform == PlatformID.Win32NT)
            {
                // Windows NT.
                owner_string = RegistryTools.GetRegistryValue(
                    Registry.LocalMachine,
                    @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\",
                    "RegisteredOwner", "Unknown");
                company_string = RegistryTools.GetRegistryValue(
                    Registry.LocalMachine,
                    @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\",
                    "RegisteredOrganization", "Unknown");
            }

            txtOwner.Text = owner_string.ToString();
            txtCompany.Text = company_string.ToString();
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
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCompany
            // 
            this.txtCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompany.Location = new System.Drawing.Point(72, 43);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.ReadOnly = true;
            this.txtCompany.Size = new System.Drawing.Size(240, 20);
            this.txtCompany.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Company:";
            // 
            // txtOwner
            // 
            this.txtOwner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOwner.Location = new System.Drawing.Point(72, 17);
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.ReadOnly = true;
            this.txtOwner.Size = new System.Drawing.Size(240, 20);
            this.txtOwner.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Owner:";
            // 
            // howto_get_registered_owner_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 81);
            this.Controls.Add(this.txtCompany);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOwner);
            this.Controls.Add(this.label1);
            this.Name = "howto_get_registered_owner_Form1";
            this.Text = "howto_get_registered_owner";
            this.Load += new System.EventHandler(this.howto_get_registered_owner_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.Label label1;
    }
}

