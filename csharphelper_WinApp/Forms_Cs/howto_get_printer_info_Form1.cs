using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Printing;
using System.Diagnostics;
using System.Management;

// Add a reference to System.Management.
// For more information about the data available in the Win32_Printer class, see:
//      http://msdn.microsoft.com/en-us/library/aa394363%28VS.85%29.aspx

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_get_printer_info_Form1:Form
  { 


        public howto_get_printer_info_Form1()
        {
            InitializeComponent();
        }

        // List the installed printers.
        private void howto_get_printer_info_Form1_Load(object sender, EventArgs e)
        {
            // Find all of the installed printers.
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                cboPrinters.Items.Add(printer);
            }

            // Select the first printer.
            cboPrinters.SelectedIndex = 0;
        }

        // Display information about the selected printer.
        private void cboPrinters_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lookup arrays.
            string[] PrinterStatuses = 
            {
                "Other", "Unknown", "Idle", "Printing", "WarmUp",
                "Stopped Printing", "Offline"
            };
            string[] PrinterStates = 
            {
                "Paused", "Error", "Pending Deletion", "Paper Jam",
                "Paper Out", "Manual Feed", "Paper Problem",
                "Offline", "IO Active", "Busy", "Printing",
                "Output Bin Full", "Not Available", "Waiting",
                "Processing", "Initialization", "Warming Up", 
                "Toner Low", "No Toner", "Page Punt",
                "User Intervention Required", "Out of Memory",
                "Door Open", "Server_Unknown", "Power Save"};

            // Get a ManagementObjectSearcher for the printer.
            string query = "SELECT * FROM Win32_Printer WHERE Name='" +
                cboPrinters.SelectedItem.ToString() + "'";
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher(query);

            // Get the ManagementObjectCollection representing
            // the result of the WMI query. Loop through its
            // single item. Display some of that item's properties.
            foreach (ManagementObject service in searcher.Get())
            {
                txtName.Text = service.Properties["Name"].Value.ToString();

                UInt32 state = (UInt32)service.Properties["PrinterState"].Value;
                txtState.Text = PrinterStates[state];

                UInt16 status = (UInt16)service.Properties["PrinterStatus"].Value;
                txtStatus.Text = PrinterStatuses[status];

                txtDescription.Text = GetPropertyValue(service.Properties["Description"]);
                txtDefault.Text = GetPropertyValue(service.Properties["Default"]);
                txtHorRes.Text = GetPropertyValue(service.Properties["HorizontalResolution"]);
                txtVertRes.Text = GetPropertyValue(service.Properties["VerticalResolution"]);
                txtPort.Text = GetPropertyValue(service.Properties["PortName"]);

                lstPaperSizes.Items.Clear();
                string[] paper_sizes = (string[])service.Properties["PrinterPaperNames"].Value;
                foreach (string paper_size in paper_sizes)
                {
                    lstPaperSizes.Items.Add(paper_size);
                }

                // List the available properties.
                foreach (PropertyData data in service.Properties)
                {
                    string txt = data.Name;
                    if (data.Value != null)
                        txt += ": " + data.Value.ToString();
                    Console.WriteLine(txt);
                }
            }
        }

        // If the data is not null and has a value, return it.
        private string GetPropertyValue(PropertyData data)
        {
            if ((data == null) || (data.Value == null)) return "";
            return data.Value.ToString();
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
            this.cboPrinters = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVertRes = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHorRes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDefault = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lstPaperSizes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // cboPrinters
            // 
            this.cboPrinters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrinters.FormattingEnabled = true;
            this.cboPrinters.Location = new System.Drawing.Point(12, 12);
            this.cboPrinters.Name = "cboPrinters";
            this.cboPrinters.Size = new System.Drawing.Size(260, 21);
            this.cboPrinters.TabIndex = 1;
            this.cboPrinters.SelectedIndexChanged += new System.EventHandler(this.cboPrinters_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(84, 49);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(188, 20);
            this.txtName.TabIndex = 3;
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(84, 75);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(188, 20);
            this.txtState.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "State:";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(84, 101);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(188, 20);
            this.txtStatus.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Status:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(84, 127);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(188, 20);
            this.txtDescription.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Description:";
            // 
            // txtVertRes
            // 
            this.txtVertRes.Location = new System.Drawing.Point(84, 205);
            this.txtVertRes.Name = "txtVertRes";
            this.txtVertRes.Size = new System.Drawing.Size(188, 20);
            this.txtVertRes.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Vert Res:";
            // 
            // txtHorRes
            // 
            this.txtHorRes.Location = new System.Drawing.Point(84, 179);
            this.txtHorRes.Name = "txtHorRes";
            this.txtHorRes.Size = new System.Drawing.Size(188, 20);
            this.txtHorRes.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Hor Res:";
            // 
            // txtDefault
            // 
            this.txtDefault.Location = new System.Drawing.Point(84, 153);
            this.txtDefault.Name = "txtDefault";
            this.txtDefault.Size = new System.Drawing.Size(188, 20);
            this.txtDefault.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Default:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(84, 231);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(188, 20);
            this.txtPort.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Port:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 260);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Paper Sizes:";
            // 
            // lstPaperSizes
            // 
            this.lstPaperSizes.FormattingEnabled = true;
            this.lstPaperSizes.Location = new System.Drawing.Point(84, 257);
            this.lstPaperSizes.Name = "lstPaperSizes";
            this.lstPaperSizes.Size = new System.Drawing.Size(188, 95);
            this.lstPaperSizes.TabIndex = 20;
            // 
            // howto_get_printer_info_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 366);
            this.Controls.Add(this.lstPaperSizes);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtVertRes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtHorRes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDefault);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboPrinters);
            this.Name = "howto_get_printer_info_Form1";
            this.Text = "howto_get_printer_info";
            this.Load += new System.EventHandler(this.howto_get_printer_info_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPrinters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtVertRes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHorRes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDefault;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox lstPaperSizes;
    }
}

