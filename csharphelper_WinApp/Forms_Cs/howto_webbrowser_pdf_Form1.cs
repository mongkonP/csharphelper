using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_webbrowser_pdf_Form1:Form
  { 


        public howto_webbrowser_pdf_Form1()
        {
            InitializeComponent();
        }

        // Display the PDF file.
        private void howto_webbrowser_pdf_Form1_Load(object sender, EventArgs e)
        {
            string filename = Application.StartupPath;
            filename = Path.GetFullPath(Path.Combine(filename, ".\\Test.pdf"));
            wbrPdf.Navigate(filename);
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
            this.wbrPdf = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbrPdf
            // 
            this.wbrPdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbrPdf.Location = new System.Drawing.Point(0, 0);
            this.wbrPdf.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbrPdf.Name = "wbrPdf";
            this.wbrPdf.Size = new System.Drawing.Size(435, 295);
            this.wbrPdf.TabIndex = 0;
            // 
            // howto_webbrowser_pdf_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 295);
            this.Controls.Add(this.wbrPdf);
            this.Name = "howto_webbrowser_pdf_Form1";
            this.Text = "howto_webbrowser_pdf";
            this.Load += new System.EventHandler(this.howto_webbrowser_pdf_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbrPdf;
    }
}

