using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net;

 

using howto_security_protocols;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_security_protocols_Form1:Form
  { 


        public howto_security_protocols_Form1()
        {
            InitializeComponent();
        }

        private void howto_security_protocols_Form1_Load(object sender, EventArgs e)
        {
            cboUrl.SelectedIndex = 0;

            ServicePointManager.SecurityProtocol =
                Protocols.protocol_Tls11 | Protocols.protocol_Tls12;
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            txtResult.Clear();
            Cursor = Cursors.WaitCursor;
            txtResult.Text = DownloadUrl(cboUrl.Text);
            Cursor = Cursors.Default;
        }

        private string DownloadUrl(string url)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    return client.DownloadString(url);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
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
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnFetch = new System.Windows.Forms.Button();
            this.cboUrl = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL:";
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(15, 68);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(307, 181);
            this.txtResult.TabIndex = 2;
            // 
            // btnFetch
            // 
            this.btnFetch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFetch.Location = new System.Drawing.Point(130, 39);
            this.btnFetch.Name = "btnFetch";
            this.btnFetch.Size = new System.Drawing.Size(75, 23);
            this.btnFetch.TabIndex = 1;
            this.btnFetch.Text = "Fetch";
            this.btnFetch.UseVisualStyleBackColor = true;
            this.btnFetch.Click += new System.EventHandler(this.btnFetch_Click);
            // 
            // cboUrl
            // 
            this.cboUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboUrl.FormattingEnabled = true;
            this.cboUrl.Items.AddRange(new object[] {
            "http://www.csharphelper.com",
            "https://docs.microsoft.com/en-us/dotnet/api/system.net.securityprotocoltype?view=" +
                "netcore-3.1"});
            this.cboUrl.Location = new System.Drawing.Point(50, 12);
            this.cboUrl.Name = "cboUrl";
            this.cboUrl.Size = new System.Drawing.Size(272, 21);
            this.cboUrl.TabIndex = 0;
            // 
            // howto_security_protocols_Form1
            // 
            this.AcceptButton = this.btnFetch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 261);
            this.Controls.Add(this.cboUrl);
            this.Controls.Add(this.btnFetch);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label1);
            this.Name = "howto_security_protocols_Form1";
            this.Text = "howto_security_protocols";
            this.Load += new System.EventHandler(this.howto_security_protocols_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnFetch;
        private System.Windows.Forms.ComboBox cboUrl;
    }
}

