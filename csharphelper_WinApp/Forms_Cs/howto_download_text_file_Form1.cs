using System;
using System.Windows.Forms;

using System.IO;
using System.Net;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_download_text_file_Form1:Form
  { 


        public howto_download_text_file_Form1()
        {
            InitializeComponent();
        }

        // Download and display the text file.
        private void howto_download_text_file_Form1_Load(object sender, EventArgs e)
        {
            const string url = "https://raw.github.com/cubiclesoft/email_sms_mms_gateways/master/sms_mms_gateways.txt";
            txtFile.Text = GetTextFile(url);
            txtFile.Select(0, 0);
        }

        // Get the text file at a given URL.
        private string GetTextFile(string url)
        {
            try
            {
                url = url.Trim();
                if (!url.ToLower().StartsWith("http")) url = "http://" + url;
                WebClient web_client = new WebClient();
                MemoryStream image_stream = new MemoryStream(web_client.DownloadData(url));
                StreamReader reader = new StreamReader(image_stream);
                string result = reader.ReadToEnd();
                reader.Close();
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error downloading file " +
                    url + '\n' + ex.Message,
                    "Download Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            return "";
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
            this.txtFile = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtFile
            // 
            this.txtFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFile.Location = new System.Drawing.Point(0, 0);
            this.txtFile.Multiline = true;
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(334, 261);
            this.txtFile.TabIndex = 1;
            // 
            // howto_download_text_file_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 261);
            this.Controls.Add(this.txtFile);
            this.Name = "howto_download_text_file_Form1";
            this.Text = "howto_download_text_file";
            this.Load += new System.EventHandler(this.howto_download_text_file_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFile;
    }
}

