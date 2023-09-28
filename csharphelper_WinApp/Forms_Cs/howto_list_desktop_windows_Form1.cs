using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_list_desktop_windows;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_list_desktop_windows_Form1:Form
  { 


        public howto_list_desktop_windows_Form1()
        {
            InitializeComponent();
        }

        private void howto_list_desktop_windows_Form1_Load(object sender, EventArgs e)
        {
            ShowDesktopWindows();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowDesktopWindows();
        }

        // Display a list of the desktop windows' titles.
        private void ShowDesktopWindows()
        {
            List<IntPtr> handles;
            List<string> titles;
            DesktopWindowsStuff.GetDesktopWindowHandlesAndTitles(out handles, out titles);

            lstWindows.DataSource = titles;
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
            this.lstWindows = new System.Windows.Forms.ListBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstWindows
            // 
            this.lstWindows.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstWindows.FormattingEnabled = true;
            this.lstWindows.IntegralHeight = false;
            this.lstWindows.Location = new System.Drawing.Point(12, 10);
            this.lstWindows.Name = "lstWindows";
            this.lstWindows.Size = new System.Drawing.Size(420, 210);
            this.lstWindows.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(357, 226);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // howto_list_desktop_windows_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 261);
            this.Controls.Add(this.lstWindows);
            this.Controls.Add(this.btnRefresh);
            this.Name = "howto_list_desktop_windows_Form1";
            this.Text = "howto_list_desktop_windows";
            this.Load += new System.EventHandler(this.howto_list_desktop_windows_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstWindows;
        private System.Windows.Forms.Button btnRefresh;
    }
}

