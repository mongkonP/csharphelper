using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_battery_status_Form1:Form
  { 


        public howto_battery_status_Form1()
        {
            InitializeComponent();
        }

        private void howto_battery_status_Form1_Load(object sender, EventArgs e)
        {
            ShowPowerStatus();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowPowerStatus();
        }

        private void ShowPowerStatus()
        {
            PowerStatus status = SystemInformation.PowerStatus;
            txtChargeStatus.Text = status.BatteryChargeStatus.ToString();
            if (status.BatteryFullLifetime == -1)
                txtFullLifetime.Text = "Unknown";
            else
                txtFullLifetime.Text = status.BatteryFullLifetime.ToString();
            txtCharge.Text = status.BatteryLifePercent.ToString("P0");
            if (status.BatteryLifeRemaining == -1)
                txtLifeRemaining.Text = "Unknown";
            else
                txtLifeRemaining.Text = status.BatteryLifeRemaining.ToString();
            txtLineStatus.Text = status.PowerLineStatus.ToString();
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChargeStatus = new System.Windows.Forms.TextBox();
            this.txtFullLifetime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLifeRemaining = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCharge = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLineStatus = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackgroundImage = Properties.Resources.refresh2;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRefresh.Location = new System.Drawing.Point(240, 145);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(32, 32);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Charge Status:";
            // 
            // txtChargeStatus
            // 
            this.txtChargeStatus.Location = new System.Drawing.Point(124, 12);
            this.txtChargeStatus.Name = "txtChargeStatus";
            this.txtChargeStatus.Size = new System.Drawing.Size(148, 20);
            this.txtChargeStatus.TabIndex = 2;
            // 
            // txtFullLifetime
            // 
            this.txtFullLifetime.Location = new System.Drawing.Point(124, 38);
            this.txtFullLifetime.Name = "txtFullLifetime";
            this.txtFullLifetime.Size = new System.Drawing.Size(148, 20);
            this.txtFullLifetime.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Full Life (sec):";
            // 
            // txtLifeRemaining
            // 
            this.txtLifeRemaining.Location = new System.Drawing.Point(124, 90);
            this.txtLifeRemaining.Name = "txtLifeRemaining";
            this.txtLifeRemaining.Size = new System.Drawing.Size(148, 20);
            this.txtLifeRemaining.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Life Remaining (sec):";
            // 
            // txtCharge
            // 
            this.txtCharge.Location = new System.Drawing.Point(124, 64);
            this.txtCharge.Name = "txtCharge";
            this.txtCharge.Size = new System.Drawing.Size(148, 20);
            this.txtCharge.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Charge:";
            // 
            // txtLineStatus
            // 
            this.txtLineStatus.Location = new System.Drawing.Point(124, 116);
            this.txtLineStatus.Name = "txtLineStatus";
            this.txtLineStatus.Size = new System.Drawing.Size(148, 20);
            this.txtLineStatus.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Line Status:";
            // 
            // howto_battery_status_Form1
            // 
            this.AcceptButton = this.btnRefresh;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 189);
            this.Controls.Add(this.txtLineStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLifeRemaining);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCharge);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFullLifetime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtChargeStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefresh);
            this.Name = "howto_battery_status_Form1";
            this.Text = "howto_battery_status";
            this.Load += new System.EventHandler(this.howto_battery_status_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChargeStatus;
        private System.Windows.Forms.TextBox txtFullLifetime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLifeRemaining;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCharge;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLineStatus;
        private System.Windows.Forms.Label label5;
    }
}

