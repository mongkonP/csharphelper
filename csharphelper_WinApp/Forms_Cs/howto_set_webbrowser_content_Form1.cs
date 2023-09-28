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
     public partial class howto_set_webbrowser_content_Form1:Form
  { 


        public howto_set_webbrowser_content_Form1()
        {
            InitializeComponent();
        }

        // Start at home.
        private void howto_set_webbrowser_content_Form1_Load(object sender, EventArgs e)
        {
            wbrDisplay.GoHome();
//            wbrDisplay.Navigate("about:blank");
        }

        // Set the HTML contents.
        private void btn_Click(object sender, EventArgs e)
        {
            HtmlDocument doc = wbrDisplay.Document;
            doc.Body.InnerHtml = txtHtml.Text;
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
            this.txtHtml = new System.Windows.Forms.TextBox();
            this.btn = new System.Windows.Forms.Button();
            this.wbrDisplay = new System.Windows.Forms.WebBrowser();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtHtml
            // 
            this.txtHtml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHtml.Location = new System.Drawing.Point(0, 0);
            this.txtHtml.Multiline = true;
            this.txtHtml.Name = "txtHtml";
            this.txtHtml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHtml.Size = new System.Drawing.Size(390, 93);
            this.txtHtml.TabIndex = 5;
            this.txtHtml.Text = "<HTML>\r\n  <BODY>\r\n    <H1>Hello World!</H1>\r\n    Go to <A HREF=\"http://www.csharp" +
                "helper.com\">C Sharp Helper</A>\r\n  </BODY>\r\n</HTML>";
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(12, 12);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(80, 24);
            this.btn.TabIndex = 4;
            this.btn.Text = "Set Contents";
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // wbrDisplay
            // 
            this.wbrDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbrDisplay.Location = new System.Drawing.Point(0, 0);
            this.wbrDisplay.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbrDisplay.Name = "wbrDisplay";
            this.wbrDisplay.Size = new System.Drawing.Size(390, 112);
            this.wbrDisplay.TabIndex = 6;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 42);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtHtml);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.wbrDisplay);
            this.splitContainer1.Size = new System.Drawing.Size(390, 209);
            this.splitContainer1.SplitterDistance = 93;
            this.splitContainer1.TabIndex = 7;
            // 
            // howto_set_webbrowser_content_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 263);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btn);
            this.Name = "howto_set_webbrowser_content_Form1";
            this.Text = "howto_set_webbrowser_content";
            this.Load += new System.EventHandler(this.howto_set_webbrowser_content_Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TextBox txtHtml;
        internal System.Windows.Forms.Button btn;
        private System.Windows.Forms.WebBrowser wbrDisplay;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

