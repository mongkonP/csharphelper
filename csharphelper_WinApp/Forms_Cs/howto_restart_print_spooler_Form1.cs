using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Add a reference to System.ServiceProcess.
using System.ServiceProcess;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_restart_print_spooler_Form1:Form
  { 


        public howto_restart_print_spooler_Form1()
        {
            InitializeComponent();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            // Stop the spooler.
            ServiceController service = new ServiceController("Spooler");
            if ((!service.Status.Equals(ServiceControllerStatus.Stopped)) &&
                (!service.Status.Equals(ServiceControllerStatus.StopPending)))
            {
                lblStatus.Text = "Stopping spooler...";
                lblStatus.Refresh();

                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped);
            }

            // Start the spooler.
            lblStatus.Text = "Restarting spooler...";
            lblStatus.Refresh();
            service.Start();
            service.WaitForStatus(ServiceControllerStatus.Running);

            lblStatus.Text = "Done";
            Cursor = Cursors.Default;
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
            this.btnRestart = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRestart
            // 
            this.btnRestart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRestart.Location = new System.Drawing.Point(130, 44);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 23);
            this.btnRestart.TabIndex = 0;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 89);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 1;
            // 
            // howto_restart_print_spooler_Form1
            // 
            this.AcceptButton = this.btnRestart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 111);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnRestart);
            this.Name = "howto_restart_print_spooler_Form1";
            this.Text = "howto_restart_print_spooler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Label lblStatus;
    }
}

