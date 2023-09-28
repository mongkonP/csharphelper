using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;
using System.Runtime.InteropServices;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_shutdown_windows_Form1:Form
  { 


        [DllImport("user32")]
        public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

        [DllImport("user32")]
        public static extern void LockWorkStation();

        public howto_shutdown_windows_Form1()
        {
            InitializeComponent();
        }

        // Shutdown.
        private void btnShutdown_Click(object sender, EventArgs e)
        {
            var psi = new ProcessStartInfo("shutdown", "/s /t 0");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process.Start(psi);
        }

        // Reboot.
        private void btnReboot_Click(object sender, EventArgs e)
        {
            var psi = new ProcessStartInfo("shutdown", "/r /t 0");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process.Start(psi);
        }

        // Log off.
        private void btnLogOff_Click(object sender, EventArgs e)
        {
            ExitWindowsEx(0, 0);
        }

        // Lock.
        private void btnLock_Click(object sender, EventArgs e)
        {
            LockWorkStation();
        }

        // Hibernate.
        private void btnHibernate_Click(object sender, EventArgs e)
        {
            Application.SetSuspendState(PowerState.Hibernate, true, true);
        }

        // Sleep.
        private void btnSleep_Click(object sender, EventArgs e)
        {
            Application.SetSuspendState(PowerState.Suspend, true, true);
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
            this.btnShutdown = new System.Windows.Forms.Button();
            this.btnReboot = new System.Windows.Forms.Button();
            this.btnLogOff = new System.Windows.Forms.Button();
            this.btnLock = new System.Windows.Forms.Button();
            this.btnHibernate = new System.Windows.Forms.Button();
            this.btnSleep = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnShutdown
            // 
            this.btnShutdown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnShutdown.Location = new System.Drawing.Point(20, 22);
            this.btnShutdown.Name = "btnShutdown";
            this.btnShutdown.Size = new System.Drawing.Size(75, 23);
            this.btnShutdown.TabIndex = 0;
            this.btnShutdown.Text = "Shutdown";
            this.btnShutdown.UseVisualStyleBackColor = true;
            this.btnShutdown.Click += new System.EventHandler(this.btnShutdown_Click);
            // 
            // btnReboot
            // 
            this.btnReboot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReboot.Location = new System.Drawing.Point(117, 22);
            this.btnReboot.Name = "btnReboot";
            this.btnReboot.Size = new System.Drawing.Size(75, 23);
            this.btnReboot.TabIndex = 1;
            this.btnReboot.Text = "Reboot";
            this.btnReboot.UseVisualStyleBackColor = true;
            this.btnReboot.Click += new System.EventHandler(this.btnReboot_Click);
            // 
            // btnLogOff
            // 
            this.btnLogOff.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogOff.Location = new System.Drawing.Point(214, 22);
            this.btnLogOff.Name = "btnLogOff";
            this.btnLogOff.Size = new System.Drawing.Size(75, 23);
            this.btnLogOff.TabIndex = 2;
            this.btnLogOff.Text = "Log Off";
            this.btnLogOff.UseVisualStyleBackColor = true;
            this.btnLogOff.Click += new System.EventHandler(this.btnLogOff_Click);
            // 
            // btnLock
            // 
            this.btnLock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLock.Location = new System.Drawing.Point(20, 66);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(75, 23);
            this.btnLock.TabIndex = 3;
            this.btnLock.Text = "Lock";
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // btnHibernate
            // 
            this.btnHibernate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHibernate.Location = new System.Drawing.Point(117, 66);
            this.btnHibernate.Name = "btnHibernate";
            this.btnHibernate.Size = new System.Drawing.Size(75, 23);
            this.btnHibernate.TabIndex = 4;
            this.btnHibernate.Text = "Hibernate";
            this.btnHibernate.UseVisualStyleBackColor = true;
            this.btnHibernate.Click += new System.EventHandler(this.btnHibernate_Click);
            // 
            // btnSleep
            // 
            this.btnSleep.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSleep.Location = new System.Drawing.Point(214, 66);
            this.btnSleep.Name = "btnSleep";
            this.btnSleep.Size = new System.Drawing.Size(75, 23);
            this.btnSleep.TabIndex = 5;
            this.btnSleep.Text = "Sleep";
            this.btnSleep.UseVisualStyleBackColor = true;
            this.btnSleep.Click += new System.EventHandler(this.btnSleep_Click);
            // 
            // howto_shutdown_windows_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 111);
            this.Controls.Add(this.btnSleep);
            this.Controls.Add(this.btnHibernate);
            this.Controls.Add(this.btnLock);
            this.Controls.Add(this.btnLogOff);
            this.Controls.Add(this.btnReboot);
            this.Controls.Add(this.btnShutdown);
            this.Name = "howto_shutdown_windows_Form1";
            this.Text = "howto_shutdown_windows";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShutdown;
        private System.Windows.Forms.Button btnReboot;
        private System.Windows.Forms.Button btnLogOff;
        private System.Windows.Forms.Button btnLock;
        private System.Windows.Forms.Button btnHibernate;
        private System.Windows.Forms.Button btnSleep;
    }
}

