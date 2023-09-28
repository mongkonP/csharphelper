using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_default_application_Form1:Form
  { 


        public howto_default_application_Form1()
        {
            InitializeComponent();
        }

        // Initialize the file name.
        private void howto_default_application_Form1_Load(object sender, EventArgs e)
        {
            string filename = Path.Combine(Application.StartupPath, @"..\..\");
            filename = Path.GetFullPath(filename) + "test.txt";
            cboFile.Items.Add(filename);
            cboFile.Text = filename;
        }

        // "Start" the file.
        private void btnOpen_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(cboFile.Text);
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
            this.btnOpen = new System.Windows.Forms.Button();
            this.cboFile = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File:";
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOpen.Location = new System.Drawing.Point(202, 38);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // cboFile
            // 
            this.cboFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFile.FormattingEnabled = true;
            this.cboFile.Items.AddRange(new object[] {
            "http://www.csharphelper.com",
            "http://www.google.com"});
            this.cboFile.Location = new System.Drawing.Point(44, 12);
            this.cboFile.Name = "cboFile";
            this.cboFile.Size = new System.Drawing.Size(423, 21);
            this.cboFile.TabIndex = 3;
            // 
            // howto_default_application_Form1
            // 
            this.AcceptButton = this.btnOpen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 77);
            this.Controls.Add(this.cboFile);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.label1);
            this.Name = "howto_default_application_Form1";
            this.Text = "howto_default_application";
            this.Load += new System.EventHandler(this.howto_default_application_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.ComboBox cboFile;
    }
}

