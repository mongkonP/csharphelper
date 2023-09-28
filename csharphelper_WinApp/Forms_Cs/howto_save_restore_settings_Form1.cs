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
     public partial class howto_save_restore_settings_Form1:Form
  { 


        public howto_save_restore_settings_Form1()
        {
            InitializeComponent();
        }

        // Restore settings.
        private void howto_save_restore_settings_Form1_Load(object sender, EventArgs e)
        {
            SetBounds(
                Properties.Settings.Default.Left,
                Properties.Settings.Default.Top,
                Properties.Settings.Default.Width,
                Properties.Settings.Default.Height);
            txtContent.Text = Properties.Settings.Default.Contents;
        }

        // Save the current settings.
        private void howto_save_restore_settings_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Left = Left;
            Properties.Settings.Default.Top = Top;
            Properties.Settings.Default.Width = Width;
            Properties.Settings.Default.Height = Height;
            Properties.Settings.Default.Contents = txtContent.Text;
            Properties.Settings.Default.Save();
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
            this.txtContent = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtContent
            // 
            this.txtContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContent.Location = new System.Drawing.Point(0, 0);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContent.Size = new System.Drawing.Size(284, 264);
            this.txtContent.TabIndex = 0;
            // 
            // howto_save_restore_settings_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.txtContent);
            this.Name = "howto_save_restore_settings_Form1";
            this.Text = "howto_save_restore_settings";
            this.Load += new System.EventHandler(this.howto_save_restore_settings_Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_save_restore_settings_Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtContent;
    }
}

