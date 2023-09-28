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

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_get_cpu_serial_number_id_Form1:Form
  { 


        public howto_get_cpu_serial_number_id_Form1()
        {
            InitializeComponent();
        }

        // Display the mother board serial numbers and the CPU IDs.
        private void howto_get_cpu_serial_number_id_Form1_Load(object sender, EventArgs e)
        {
            lstBoardSerialNumbers.DataSource = GetBoardSerialNumbers();
            lstCpuIds.DataSource = GetCpuIds();
        }

        // Use WMI to return the system's base board serial numbers.
        private List<string> GetBoardSerialNumbers()
        {
            List<string> results = new List<string>();

            string query = "SELECT * FROM Win32_BaseBoard";
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher(query);
            foreach (ManagementObject info in searcher.Get())
            {
                results.Add(info.GetPropertyValue("SerialNumber").ToString());
            }

            return results;
        }

        // Use WMI to return the CPUs' IDs.
        private List<string> GetCpuIds()
        {
            List<string> results = new List<string>();

            string query = "Select * FROM Win32_Processor";
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher(query);
            foreach (ManagementObject info in searcher.Get())
            {
                results.Add(info.GetPropertyValue("ProcessorId").ToString());
            }

            return results;
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
            this.label1 = new System.Windows.Forms.Label();
            this.lstBoardSerialNumbers = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstCpuIds = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Board Serial Numbers";
            // 
            // lstBoardSerialNumbers
            // 
            this.lstBoardSerialNumbers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBoardSerialNumbers.FormattingEnabled = true;
            this.lstBoardSerialNumbers.ItemHeight = 20;
            this.lstBoardSerialNumbers.Location = new System.Drawing.Point(0, 20);
            this.lstBoardSerialNumbers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstBoardSerialNumbers.Name = "lstBoardSerialNumbers";
            this.lstBoardSerialNumbers.Size = new System.Drawing.Size(329, 44);
            this.lstBoardSerialNumbers.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(18, 18);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstBoardSerialNumbers);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lstCpuIds);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(329, 149);
            this.splitContainer1.SplitterDistance = 72;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 4;
            // 
            // lstCpuIds
            // 
            this.lstCpuIds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCpuIds.FormattingEnabled = true;
            this.lstCpuIds.ItemHeight = 20;
            this.lstCpuIds.Location = new System.Drawing.Point(0, 20);
            this.lstCpuIds.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstCpuIds.Name = "lstCpuIds";
            this.lstCpuIds.Size = new System.Drawing.Size(329, 44);
            this.lstCpuIds.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "CPU IDs";
            // 
            // howto_get_cpu_serial_number_id_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 186);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "howto_get_cpu_serial_number_id_Form1";
            this.Text = "howto_get_cpu_serial_number_id";
            this.Load += new System.EventHandler(this.howto_get_cpu_serial_number_id_Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstBoardSerialNumbers;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lstCpuIds;
        private System.Windows.Forms.Label label2;
    }
}

