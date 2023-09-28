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
     public partial class howto_use_notify_icon_Form1:Form
  { 


        public howto_use_notify_icon_Form1()
        {
            InitializeComponent();
        }

        // Display the happy icon.
        private void radHappy_Click(object sender, EventArgs e)
        {
            if (!radHappy.Checked) radHappy.Checked = true;
            this.Icon = Properties.Resources.HappyIco;
            NotifyIcon1.Icon = Properties.Resources.HappySmallIco;
            NotifyIcon1.Text = "Happy";
        }

        // Display the sad icon.
        private void radSad_Click(object sender, EventArgs e)
        {
            if (!radSad.Checked) radSad.Checked = true;
            this.Icon = Properties.Resources.SadIco;
            NotifyIcon1.Icon = Properties.Resources.SadSmallIco;
            NotifyIcon1.Text = "Sad";
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_use_notify_icon_Form1));
            this.radSad = new System.Windows.Forms.RadioButton();
            this.radHappy = new System.Windows.Forms.RadioButton();
            this.NotifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctxNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxHappy = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxSad = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxNotify.SuspendLayout();
            this.SuspendLayout();
            // 
            // radSad
            // 
            this.radSad.Image = ((System.Drawing.Image)(resources.GetObject("radSad.Image")));
            this.radSad.Location = new System.Drawing.Point(179, 30);
            this.radSad.Name = "radSad";
            this.radSad.Size = new System.Drawing.Size(53, 43);
            this.radSad.TabIndex = 5;
            this.radSad.Click += new System.EventHandler(this.radSad_Click);
            // 
            // radHappy
            // 
            this.radHappy.Checked = true;
            this.radHappy.Image = ((System.Drawing.Image)(resources.GetObject("radHappy.Image")));
            this.radHappy.Location = new System.Drawing.Point(52, 30);
            this.radHappy.Name = "radHappy";
            this.radHappy.Size = new System.Drawing.Size(53, 43);
            this.radHappy.TabIndex = 4;
            this.radHappy.TabStop = true;
            this.radHappy.Click += new System.EventHandler(this.radHappy_Click);
            // 
            // NotifyIcon1
            // 
            this.NotifyIcon1.ContextMenuStrip = this.ctxNotify;
            this.NotifyIcon1.Text = "NotifyIcon1";
            this.NotifyIcon1.Visible = true;
            // 
            // ctxNotify
            // 
            this.ctxNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxHappy,
            this.ctxSad});
            this.ctxNotify.Name = "ctxNotify";
            this.ctxNotify.Size = new System.Drawing.Size(110, 48);
            // 
            // ctxHappy
            // 
            this.ctxHappy.Image = ((System.Drawing.Image)(resources.GetObject("ctxHappy.Image")));
            this.ctxHappy.Name = "ctxHappy";
            this.ctxHappy.Size = new System.Drawing.Size(109, 22);
            this.ctxHappy.Text = "&Happy";
            this.ctxHappy.Click += new System.EventHandler(this.radHappy_Click);
            // 
            // ctxSad
            // 
            this.ctxSad.Image = ((System.Drawing.Image)(resources.GetObject("ctxSad.Image")));
            this.ctxSad.Name = "ctxSad";
            this.ctxSad.Size = new System.Drawing.Size(109, 22);
            this.ctxSad.Text = "&Sad";
            this.ctxSad.Click += new System.EventHandler(this.radSad_Click);
            // 
            // howto_use_notify_icon_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 103);
            this.Controls.Add(this.radHappy);
            this.Controls.Add(this.radSad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "howto_use_notify_icon_Form1";
            this.Text = "howto_use_notify_icon";
            this.ctxNotify.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.RadioButton radSad;
        internal System.Windows.Forms.RadioButton radHappy;
        internal System.Windows.Forms.NotifyIcon NotifyIcon1;
        private System.Windows.Forms.ContextMenuStrip ctxNotify;
        private System.Windows.Forms.ToolStripMenuItem ctxHappy;
        private System.Windows.Forms.ToolStripMenuItem ctxSad;
    }
}

