using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Add a reference to System.Management.
using System.Management;

using howto_show_computer_memory;


namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_show_computer_memory_Form1:Form
  { 


        public howto_show_computer_memory_Form1()
        {
            InitializeComponent();
        }

        // Prepare the ListView and display values.
        private void howto_show_computer_memory_Form1_Load(object sender, EventArgs e)
        {
            // Make the columns.
            lvwInfo.View = View.Details;
            lvwInfo.SetColumnHeaders(new object[]
                {
                    "Property", HorizontalAlignment.Left,
                    "Value", HorizontalAlignment.Right
                });

            // Add the values.
            ManagementObjectSearcher os_searcher = new ManagementObjectSearcher(
                "SELECT * FROM Win32_OperatingSystem");
            foreach (ManagementObject mobj in os_searcher.Get())
            {
                GetInfo(mobj, "FreePhysicalMemory");
                GetInfo(mobj, "FreeSpaceInPagingFiles");
                GetInfo(mobj, "FreeVirtualMemory");
                GetInfo(mobj, "SizeStoredInPagingFiles");
                GetInfo(mobj, "TotalSwapSpaceSize");
                GetInfo(mobj, "TotalVirtualMemorySize");
                GetInfo(mobj, "TotalVisibleMemorySize");
            }

            // Size the columns.
            lvwInfo.SizeColumnsToFitDataAndHeaders();
        }

        // Add information about the property to the ListView.
        private void GetInfo(ManagementObject mobj, string property_name)
        {
            object property_obj = mobj[property_name];
            if (property_obj == null)
            {
                lvwInfo.AddRow(property_name, "???");
            }
            else
            {
                ulong property_value = (ulong)property_obj * 1024;
                lvwInfo.AddRow(property_name, property_value.ToFileSizeApi());
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
            this.lvwInfo = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lvwInfo
            // 
            this.lvwInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwInfo.Location = new System.Drawing.Point(12, 12);
            this.lvwInfo.Name = "lvwInfo";
            this.lvwInfo.Size = new System.Drawing.Size(330, 157);
            this.lvwInfo.TabIndex = 1;
            this.lvwInfo.UseCompatibleStateImageBehavior = false;
            // 
            // howto_show_computer_memory_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 181);
            this.Controls.Add(this.lvwInfo);
            this.Name = "howto_show_computer_memory_Form1";
            this.Text = "howto_show_computer_memory";
            this.Load += new System.EventHandler(this.howto_show_computer_memory_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwInfo;
    }
}

