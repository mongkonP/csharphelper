using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_download_apotd_Form1:Form
  { 


        public howto_download_apotd_Form1()
        {
            InitializeComponent();
        }

        // Download the Astronomy Picture of the Day.
        private void howto_download_apotd_Form1_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            wbrApotd.Visible = false;

            const string url = "http://antwrp.gsfc.nasa.gov/apod/";
            try
            {
                // Load the web page.
                wbrApotd.Navigate(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error navigating to " + url);
            }
        }

        // The web page has loaded. Get the APOTD image.
        private void wbrApotd_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlDocument doc = wbrApotd.Document;
            string src = doc.Images[0].GetAttribute("src");
            Image img = GetPicture(src);
            picApotd.Image = img;

            Cursor = Cursors.Default;
            Console.WriteLine(src);
        }

        // Download a file from the internet.
        // Get the picture at a given URL.
        private Image GetPicture(string url)
        {
            try
            {
                WebClient web_client = new WebClient();

                // Use one of the following.
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

                MemoryStream image_stream =
                    new MemoryStream(web_client.DownloadData(url));
                return Image.FromStream(image_stream);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error downloading picture " +
                    url + '\n' + ex.Message);
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
            this.picApotd = new System.Windows.Forms.PictureBox();
            this.wbrApotd = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.picApotd)).BeginInit();
            this.SuspendLayout();
            // 
            // picApotd
            // 
            this.picApotd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picApotd.Location = new System.Drawing.Point(0, 0);
            this.picApotd.Name = "picApotd";
            this.picApotd.Size = new System.Drawing.Size(334, 261);
            this.picApotd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picApotd.TabIndex = 4;
            this.picApotd.TabStop = false;
            // 
            // wbrApotd
            // 
            this.wbrApotd.Location = new System.Drawing.Point(24, 26);
            this.wbrApotd.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbrApotd.Name = "wbrApotd";
            this.wbrApotd.Size = new System.Drawing.Size(122, 104);
            this.wbrApotd.TabIndex = 5;
            this.wbrApotd.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbrApotd_DocumentCompleted);
            // 
            // howto_download_apotd_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 261);
            this.Controls.Add(this.wbrApotd);
            this.Controls.Add(this.picApotd);
            this.Name = "howto_download_apotd_Form1";
            this.Text = "howto_download_apotd";
            this.Load += new System.EventHandler(this.howto_download_apotd_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picApotd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picApotd;
        private System.Windows.Forms.WebBrowser wbrApotd;
    }
}

