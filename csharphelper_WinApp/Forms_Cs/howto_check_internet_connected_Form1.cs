using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net.NetworkInformation;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_check_internet_connected_Form1:Form
  { 


        public howto_check_internet_connected_Form1()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (IsInternetConnected())
                lblResult.Text = "The internet is available";
            else
                lblResult.Text = "The internet is not available";
        }

        // Return true if a ping to Google works.
        private bool IsInternetConnected()
        {
            return IsInternetConnected(1000);
        }
        private bool IsInternetConnected(int timeout)
        {
            try
            {
                Ping ping = new Ping();
                String host = "google.com";
                PingReply reply = ping.Send(host, timeout);
                return (reply.Status == IPStatus.Success);
            }
            catch
            {
                return false;
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
            this.lblResult = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblResult.Location = new System.Drawing.Point(12, 53);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(330, 23);
            this.lblResult.TabIndex = 3;
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCheck.Location = new System.Drawing.Point(140, 13);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // howto_check_internet_connected_Form1
            // 
            this.AcceptButton = this.btnCheck;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 91);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnCheck);
            this.Name = "howto_check_internet_connected_Form1";
            this.Text = "howto_check_internet_connected";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnCheck;
    }
}

