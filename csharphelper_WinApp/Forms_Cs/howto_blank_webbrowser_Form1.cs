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
     public partial class howto_blank_webbrowser_Form1:Form
  { 


        public howto_blank_webbrowser_Form1()
        {
            InitializeComponent();
        }

        // Enable the Blank button.
        private void wbrCSharpHelper_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            btnBlank.Enabled = true;
        }

        // Blank the WebBrowser.
        private void btnBlank_Click(object sender, EventArgs e)
        {
            wbrCSharpHelper.Navigate("about:blank");
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
            this.btnBlank = new System.Windows.Forms.Button();
            this.wbrCSharpHelper = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // btnBlank
            // 
            this.btnBlank.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnBlank.Enabled = false;
            this.btnBlank.Location = new System.Drawing.Point(155, 226);
            this.btnBlank.Name = "btnBlank";
            this.btnBlank.Size = new System.Drawing.Size(75, 23);
            this.btnBlank.TabIndex = 3;
            this.btnBlank.Text = "Blank";
            this.btnBlank.UseVisualStyleBackColor = true;
            this.btnBlank.Click += new System.EventHandler(this.btnBlank_Click);
            // 
            // wbrCSharpHelper
            // 
            this.wbrCSharpHelper.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wbrCSharpHelper.Location = new System.Drawing.Point(12, 12);
            this.wbrCSharpHelper.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbrCSharpHelper.Name = "wbrCSharpHelper";
            this.wbrCSharpHelper.Size = new System.Drawing.Size(360, 208);
            this.wbrCSharpHelper.TabIndex = 2;
            this.wbrCSharpHelper.Url = new System.Uri("http://www.csharphelper.com/books.html", System.UriKind.Absolute);
            this.wbrCSharpHelper.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbrCSharpHelper_DocumentCompleted);
            // 
            // howto_blank_webbrowser_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.btnBlank);
            this.Controls.Add(this.wbrCSharpHelper);
            this.Name = "howto_blank_webbrowser_Form1";
            this.Text = "howto_blank_webbrowser";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBlank;
        private System.Windows.Forms.WebBrowser wbrCSharpHelper;
    }
}

