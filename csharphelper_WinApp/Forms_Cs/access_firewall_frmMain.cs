using System;
using System.Drawing;
using System.Windows.Forms;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class access_firewall_frmMain:Form
  { 


        public access_firewall_frmMain()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            // End the program.
            Close();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            // Create the firewall type.
            Type FWManagerType = Type.GetTypeFromProgID("HNetCfg.FwMgr");

            // Use the firewall type to create a firewall manager object.
            dynamic FWManager = Activator.CreateInstance(FWManagerType);

            // Check the status of the firewall.
            MessageBox.Show("The firewall is turned on: " + 
                Convert.ToString(
                    FWManager.LocalPolicy.CurrentProfile.FirewallEnabled));
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
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCheck
            // 
            this.btnCheck.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCheck.Location = new System.Drawing.Point(197, 12);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 0;
            this.btnCheck.Text = "&Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.Location = new System.Drawing.Point(197, 41);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.Text = "&Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // access_firewall_frmMain
            // 
            this.AcceptButton = this.btnCheck;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnCheck);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "access_firewall_frmMain";
            this.Text = "Access the Firewall";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnQuit;
    }
}

