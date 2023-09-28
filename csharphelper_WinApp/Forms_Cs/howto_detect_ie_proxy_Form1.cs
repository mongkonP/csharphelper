using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Win32;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_detect_ie_proxy_Form1:Form
  { 


        public howto_detect_ie_proxy_Form1()
        {
            InitializeComponent();
        }

        private void howto_detect_ie_proxy_Form1_Load(object sender, EventArgs e)
        {
            if (IsInternetProxyEnabled())
            {
                lblProxy.Text = "Uses a proxy server";
            }
            else
            {
                lblProxy.Text = "Does not use a proxy server";
            }
        }

        // Return True if the internet settings has ProxyEnable = true.
        private bool IsInternetProxyEnabled()
        {
            // See if Internet Explorer uses a proxy.
            RegistryKey key =
                Registry.CurrentUser.OpenSubKey(
                "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings");
            string[] keys = key.GetValueNames();
            bool result = (int)key.GetValue("ProxyEnable", 0) != 0;
            key.Close();

            return result;
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
            this.lblProxy = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblProxy
            // 
            this.lblProxy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProxy.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProxy.Location = new System.Drawing.Point(0, 0);
            this.lblProxy.Name = "lblProxy";
            this.lblProxy.Size = new System.Drawing.Size(359, 121);
            this.lblProxy.TabIndex = 1;
            this.lblProxy.Text = "label1";
            this.lblProxy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_detect_ie_proxy_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 121);
            this.Controls.Add(this.lblProxy);
            this.Name = "howto_detect_ie_proxy_Form1";
            this.Text = "howto_detect_ie_proxy";
            this.Load += new System.EventHandler(this.howto_detect_ie_proxy_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblProxy;
    }
}

