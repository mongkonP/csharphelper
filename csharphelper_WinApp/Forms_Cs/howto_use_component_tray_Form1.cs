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
     public partial class howto_use_component_tray_Form1:Form
  { 


        public howto_use_component_tray_Form1()
        {
            InitializeComponent();
        }

        private void howto_use_component_tray_Form1_Load(object sender, EventArgs e)
        {
            // Set the NotifyIcon's context menu.
            nicoStatus.ContextMenuStrip = ctxStatus;

            // Don't show in the task bar, only in the tray.
            this.ShowInTaskbar = false;

            // Display the happy status.
            radHappy.Checked = true;
            Happy_Click(null, null);
        }

        // Set the happy status.
        // The RadioButton and ContextMenu use the same event handler.
        private void Happy_Click(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Happy1;
            nicoStatus.Icon = Properties.Resources.Happy16x16;
            nicoStatus.Text = "Status: Happy";
        }

        // Set the sad status.
        // The RadioButton and ContextMenu use the same event handler.
        private void Sad_Click(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Sad;
            nicoStatus.Icon = Properties.Resources.Sad16x16;
            nicoStatus.Text = "Status: Sad";
        }

        // Restore the form.
        private void ctxRestore_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        // Exit.
        private void ctxExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_use_component_tray_Form1));
            this.nicoStatus = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radHappy = new System.Windows.Forms.RadioButton();
            this.radSad = new System.Windows.Forms.RadioButton();
            this.ctxStatus = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxStatusHappy = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxStatusSad = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxExit = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.ctxStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // nicoStatus
            // 
            this.nicoStatus.Text = "notifyIcon1";
            this.nicoStatus.Visible = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radHappy);
            this.groupBox1.Controls.Add(this.radSad);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 66);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // radHappy
            // 
            this.radHappy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radHappy.Image = ((System.Drawing.Image)(resources.GetObject("radHappy.Image")));
            this.radHappy.Location = new System.Drawing.Point(9, 15);
            this.radHappy.Name = "radHappy";
            this.radHappy.Size = new System.Drawing.Size(142, 48);
            this.radHappy.TabIndex = 0;
            this.radHappy.TabStop = true;
            this.radHappy.Text = "Happy";
            this.radHappy.UseVisualStyleBackColor = true;
            this.radHappy.Click += new System.EventHandler(this.Happy_Click);
            // 
            // radSad
            // 
            this.radSad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radSad.Image = ((System.Drawing.Image)(resources.GetObject("radSad.Image")));
            this.radSad.Location = new System.Drawing.Point(157, 15);
            this.radSad.Name = "radSad";
            this.radSad.Size = new System.Drawing.Size(142, 48);
            this.radSad.TabIndex = 1;
            this.radSad.TabStop = true;
            this.radSad.Text = "Sad";
            this.radSad.UseVisualStyleBackColor = true;
            this.radSad.Click += new System.EventHandler(this.Sad_Click);
            // 
            // ctxStatus
            // 
            this.ctxStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxStatusHappy,
            this.ctxStatusSad,
            this.toolStripMenuItem1,
            this.ctxRestore,
            this.ctxExit});
            this.ctxStatus.Name = "ctxStatus";
            this.ctxStatus.Size = new System.Drawing.Size(114, 98);
            // 
            // ctxStatusHappy
            // 
            this.ctxStatusHappy.Name = "ctxStatusHappy";
            this.ctxStatusHappy.Size = new System.Drawing.Size(113, 22);
            this.ctxStatusHappy.Text = "&Happy";
            this.ctxStatusHappy.Click += new System.EventHandler(this.Happy_Click);
            // 
            // ctxStatusSad
            // 
            this.ctxStatusSad.Name = "ctxStatusSad";
            this.ctxStatusSad.Size = new System.Drawing.Size(113, 22);
            this.ctxStatusSad.Text = "&Sad";
            this.ctxStatusSad.Click += new System.EventHandler(this.Sad_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(110, 6);
            // 
            // ctxRestore
            // 
            this.ctxRestore.Name = "ctxRestore";
            this.ctxRestore.Size = new System.Drawing.Size(113, 22);
            this.ctxRestore.Text = "&Restore";
            this.ctxRestore.Click += new System.EventHandler(this.ctxRestore_Click);
            // 
            // ctxExit
            // 
            this.ctxExit.Name = "ctxExit";
            this.ctxExit.Size = new System.Drawing.Size(113, 22);
            this.ctxExit.Text = "E&xit";
            this.ctxExit.Click += new System.EventHandler(this.ctxExit_Click);
            // 
            // howto_use_component_tray_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 90);
            this.Controls.Add(this.groupBox1);
            this.Name = "howto_use_component_tray_Form1";
            this.Text = "howto_use_component_tray";
            this.Load += new System.EventHandler(this.howto_use_component_tray_Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.ctxStatus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon nicoStatus;
        private System.Windows.Forms.RadioButton radHappy;
        private System.Windows.Forms.RadioButton radSad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ContextMenuStrip ctxStatus;
        private System.Windows.Forms.ToolStripMenuItem ctxStatusHappy;
        private System.Windows.Forms.ToolStripMenuItem ctxStatusSad;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ctxRestore;
        private System.Windows.Forms.ToolStripMenuItem ctxExit;
    }
}

