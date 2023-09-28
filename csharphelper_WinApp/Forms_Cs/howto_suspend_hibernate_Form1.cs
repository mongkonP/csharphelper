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
     public partial class howto_suspend_hibernate_Form1:Form
  { 


        public howto_suspend_hibernate_Form1()
        {
            InitializeComponent();
        }

        // Suspend.
        private void btnSuspend_Click(object sender, EventArgs e)
        {
            Application.SetSuspendState(PowerState.Suspend, false, false);
        }

        // Hibernate.
        private void btnHibernate_Click(object sender, EventArgs e)
        {
            Application.SetSuspendState(PowerState.Hibernate, false, false);
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
            this.btnHibernate = new System.Windows.Forms.Button();
            this.btnSuspend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHibernate
            // 
            this.btnHibernate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHibernate.Location = new System.Drawing.Point(184, 39);
            this.btnHibernate.Name = "btnHibernate";
            this.btnHibernate.Size = new System.Drawing.Size(75, 23);
            this.btnHibernate.TabIndex = 3;
            this.btnHibernate.Text = "Hibernate";
            this.btnHibernate.UseVisualStyleBackColor = true;
            this.btnHibernate.Click += new System.EventHandler(this.btnHibernate_Click);
            // 
            // btnSuspend
            // 
            this.btnSuspend.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSuspend.Location = new System.Drawing.Point(56, 39);
            this.btnSuspend.Name = "btnSuspend";
            this.btnSuspend.Size = new System.Drawing.Size(75, 23);
            this.btnSuspend.TabIndex = 2;
            this.btnSuspend.Text = "Suspend";
            this.btnSuspend.UseVisualStyleBackColor = true;
            this.btnSuspend.Click += new System.EventHandler(this.btnSuspend_Click);
            // 
            // howto_suspend_hibernate_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 101);
            this.Controls.Add(this.btnHibernate);
            this.Controls.Add(this.btnSuspend);
            this.Name = "howto_suspend_hibernate_Form1";
            this.Text = "howto_suspend_hibernate";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHibernate;
        private System.Windows.Forms.Button btnSuspend;
    }
}

