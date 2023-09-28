using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_host_to_ip_address_Form1:Form
  { 


        public howto_host_to_ip_address_Form1()
        {
            InitializeComponent();
        }

        // Display the entered host's IP address.
        private void btnGo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            lstAddresses.Items.Clear();
            txtRecoveredHost.Clear();
            try
            {
                IPHostEntry ip_host_entry = Dns.GetHostEntry(txtHost.Text);
                foreach (IPAddress address in ip_host_entry.AddressList)
                {
                    lstAddresses.Items.Add(address.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;
        }

        // Look up the selected IP address's host.
        private void lstAddresses_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            IPHostEntry ip_host_entry = Dns.GetHostEntry(lstAddresses.SelectedItem.ToString());
            txtRecoveredHost.Text = ip_host_entry.HostName;
            this.Cursor = Cursors.Default;
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
            this.txtRecoveredHost = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstAddresses = new System.Windows.Forms.ListBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRecoveredHost
            // 
            this.txtRecoveredHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRecoveredHost.Location = new System.Drawing.Point(50, 257);
            this.txtRecoveredHost.Name = "txtRecoveredHost";
            this.txtRecoveredHost.Size = new System.Drawing.Size(252, 20);
            this.txtRecoveredHost.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Host:";
            // 
            // lstAddresses
            // 
            this.lstAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAddresses.FormattingEnabled = true;
            this.lstAddresses.IntegralHeight = false;
            this.lstAddresses.Location = new System.Drawing.Point(12, 67);
            this.lstAddresses.Name = "lstAddresses";
            this.lstAddresses.Size = new System.Drawing.Size(290, 186);
            this.lstAddresses.TabIndex = 9;
            this.lstAddresses.SelectedIndexChanged += new System.EventHandler(this.lstAddresses_SelectedIndexChanged);
            // 
            // btnGo
            // 
            this.btnGo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGo.Location = new System.Drawing.Point(120, 38);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 8;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtHost
            // 
            this.txtHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHost.Location = new System.Drawing.Point(50, 12);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(252, 20);
            this.txtHost.TabIndex = 7;
            this.txtHost.Text = "www.csharphelper.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Host:";
            // 
            // howto_host_to_ip_address_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 289);
            this.Controls.Add(this.txtRecoveredHost);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstAddresses);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.label1);
            this.Name = "howto_host_to_ip_address_Form1";
            this.Text = "howto_host_to_ip_address";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRecoveredHost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstAddresses;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label label1;
    }
}

