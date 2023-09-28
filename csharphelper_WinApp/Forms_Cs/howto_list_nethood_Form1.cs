using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Add a reference to the COM object "Windows Script Host Object Model."
using System.IO;
using IWshRuntimeLibrary;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_list_nethood_Form1:Form
  { 


        public howto_list_nethood_Form1()
        {
            InitializeComponent();
        }

        private void howto_list_nethood_Form1_Load(object sender, EventArgs e)
        {
            // Make a Windows Script Host Shell object.
            IWshShell_Class wsh_shell = new IWshShell_Class();

            // Find the Nethood folder.
            IWshCollection special_folders = wsh_shell.SpecialFolders;
            object path_name = "Nethood";
            string nethood_path = special_folders.Item(ref path_name).ToString();
            DirectoryInfo di = new DirectoryInfo(nethood_path);

            // Enumerate Nethood's subdirectories.
            foreach (DirectoryInfo subdir in di.GetDirectories())
            {
                lstLinks.Items.Add(subdir.Name);
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
            this.lstLinks = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstLinks
            // 
            this.lstLinks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLinks.FormattingEnabled = true;
            this.lstLinks.Location = new System.Drawing.Point(0, 0);
            this.lstLinks.Name = "lstLinks";
            this.lstLinks.Size = new System.Drawing.Size(284, 121);
            this.lstLinks.TabIndex = 1;
            // 
            // howto_list_nethood_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 121);
            this.Controls.Add(this.lstLinks);
            this.Name = "howto_list_nethood_Form1";
            this.Text = "howto_list_nethood";
            this.Load += new System.EventHandler(this.howto_list_nethood_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstLinks;
    }
}

