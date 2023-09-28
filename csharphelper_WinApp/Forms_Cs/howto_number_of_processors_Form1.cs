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
     public partial class howto_number_of_processors_Form1:Form
  { 


        public howto_number_of_processors_Form1()
        {
            InitializeComponent();
        }

        private void howto_number_of_processors_Form1_Load(object sender, EventArgs e)
        {
            int num_physical_processors, num_cores, num_logical_processors;
            GetProcessorCounts(out num_physical_processors, out num_cores, out num_logical_processors);
            txtPhysicalProcessors.Text = num_physical_processors.ToString();
            txtCores.Text = num_cores.ToString();
            txtLogicalProcessors.Text = num_logical_processors.ToString();
        }

        // Return the numbers of physical processors, cores,
        // and logical processors.
        private void GetProcessorCounts(out int num_physical_processors,
            out int num_cores, out int num_logical_processors)
        {
            string query;
            ManagementObjectSearcher searcher;

            // Get the number of physical processors.
            num_physical_processors = 0;
            query = "SELECT * FROM Win32_ComputerSystem";
            searcher = new ManagementObjectSearcher(query);
            foreach (ManagementObject sys in searcher.Get())
                num_physical_processors =
                    int.Parse(sys["NumberOfProcessors"].ToString());

            // Get the number of cores.
            query = "SELECT * FROM Win32_Processor";
            num_cores = 0;
            searcher = new ManagementObjectSearcher(query);
            foreach (ManagementObject proc in searcher.Get())
                num_cores += int.Parse(proc["NumberOfCores"].ToString());

            num_logical_processors = Environment.ProcessorCount;
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
            this.txtPhysicalProcessors = new System.Windows.Forms.TextBox();
            this.txtCores = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLogicalProcessors = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Physical Processors:";
            // 
            // txtPhysicalProcessors
            // 
            this.txtPhysicalProcessors.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPhysicalProcessors.Location = new System.Drawing.Point(201, 18);
            this.txtPhysicalProcessors.Name = "txtPhysicalProcessors";
            this.txtPhysicalProcessors.Size = new System.Drawing.Size(46, 20);
            this.txtPhysicalProcessors.TabIndex = 1;
            this.txtPhysicalProcessors.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCores
            // 
            this.txtCores.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCores.Location = new System.Drawing.Point(201, 44);
            this.txtCores.Name = "txtCores";
            this.txtCores.Size = new System.Drawing.Size(46, 20);
            this.txtCores.TabIndex = 3;
            this.txtCores.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cores:";
            // 
            // txtLogicalProcessors
            // 
            this.txtLogicalProcessors.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLogicalProcessors.Location = new System.Drawing.Point(201, 70);
            this.txtLogicalProcessors.Name = "txtLogicalProcessors";
            this.txtLogicalProcessors.Size = new System.Drawing.Size(46, 20);
            this.txtLogicalProcessors.TabIndex = 5;
            this.txtLogicalProcessors.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Logical Processors:";
            // 
            // howto_number_of_processors_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 108);
            this.Controls.Add(this.txtLogicalProcessors);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCores);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPhysicalProcessors);
            this.Controls.Add(this.label1);
            this.Name = "howto_number_of_processors_Form1";
            this.Text = "howto_number_of_processors";
            this.Load += new System.EventHandler(this.howto_number_of_processors_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPhysicalProcessors;
        private System.Windows.Forms.TextBox txtCores;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLogicalProcessors;
        private System.Windows.Forms.Label label3;
    }
}

