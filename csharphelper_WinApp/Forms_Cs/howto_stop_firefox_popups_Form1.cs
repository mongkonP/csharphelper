using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_stop_firefox_popups;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_stop_firefox_popups_Form1:Form
  { 


        public howto_stop_firefox_popups_Form1()
        {
            InitializeComponent();
        }

        // Make a list of the current Firefox windows.
        private List<IntPtr> Handles = new List<IntPtr>();
        private List<string> Titles = new List<string>();
        private void howto_stop_firefox_popups_Form1_Load(object sender, EventArgs e)
        {
            // Get the desktop windows.
            List<IntPtr> handles = new List<IntPtr>();
            List<string> titles = new List<string>();
            DesktopWindowsStuff.GetDesktopWindowHandlesAndTitles(out handles, out titles);

            // Save the Firefox windows.
            for (int i = 0; i < handles.Count; i++)
            {
                if (titles[i].EndsWith("Mozilla Firefox"))
                {
                    Handles.Add(handles[i]);
                    Titles.Add(titles[i]);
                }
            }

            // Display the results.
            lstAllowedWindows.DataSource = Titles;
        }

        // Look for new Firefox windows.
        private void tmrCheckForPopups_Tick(object sender, EventArgs e)
        {
            // Get the desktop windows.
            List<IntPtr> handles = new List<IntPtr>();
            List<string> titles = new List<string>();
            DesktopWindowsStuff.GetDesktopWindowHandlesAndTitles(out handles, out titles);

            // Look for new Firefox windows.
            for (int i = 0; i < handles.Count; i++)
            {
                if (titles[i].EndsWith("Mozilla Firefox"))
                {
                    // See if this is a new window.
                    if (!Handles.Contains(handles[i]))
                    {
                        // It's new. Stop it.
                        DesktopWindowsStuff.StopWindow(handles[i]);
                        lstStoppedWindows.Items.Add(titles[i]);

                        // Add it to the list of allowed handles so we don't
                        // try to stop it again if it takes a while to close.
                        Handles.Add(handles[i]);
                    }
                }
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
            this.components = new System.ComponentModel.Container();
            this.lstStoppedWindows = new System.Windows.Forms.ListBox();
            this.lstAllowedWindows = new System.Windows.Forms.ListBox();
            this.tmrCheckForPopups = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstStoppedWindows
            // 
            this.lstStoppedWindows.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstStoppedWindows.FormattingEnabled = true;
            this.lstStoppedWindows.IntegralHeight = false;
            this.lstStoppedWindows.Location = new System.Drawing.Point(12, 159);
            this.lstStoppedWindows.Name = "lstStoppedWindows";
            this.lstStoppedWindows.Size = new System.Drawing.Size(310, 90);
            this.lstStoppedWindows.TabIndex = 7;
            // 
            // lstAllowedWindows
            // 
            this.lstAllowedWindows.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAllowedWindows.FormattingEnabled = true;
            this.lstAllowedWindows.IntegralHeight = false;
            this.lstAllowedWindows.Location = new System.Drawing.Point(12, 37);
            this.lstAllowedWindows.Name = "lstAllowedWindows";
            this.lstAllowedWindows.Size = new System.Drawing.Size(310, 95);
            this.lstAllowedWindows.TabIndex = 5;
            // 
            // tmrCheckForPopups
            // 
            this.tmrCheckForPopups.Enabled = true;
            this.tmrCheckForPopups.Interval = 1000;
            this.tmrCheckForPopups.Tick += new System.EventHandler(this.tmrCheckForPopups_Tick);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(12, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(310, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Stopped Windows";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Allowed Firefox Windows";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_stop_firefox_popups_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 261);
            this.Controls.Add(this.lstStoppedWindows);
            this.Controls.Add(this.lstAllowedWindows);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "howto_stop_firefox_popups_Form1";
            this.Text = "howto_stop_firefox_popups";
            this.Load += new System.EventHandler(this.howto_stop_firefox_popups_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstStoppedWindows;
        private System.Windows.Forms.ListBox lstAllowedWindows;
        private System.Windows.Forms.Timer tmrCheckForPopups;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

