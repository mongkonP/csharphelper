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
     public partial class howto_use_filesystemwatcher_Form1:Form
  { 


        public howto_use_filesystemwatcher_Form1()
        {
            InitializeComponent();
        }

        // Create the From and To directories.
        private void howto_use_filesystemwatcher_Form1_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory(txtInputDir.Text);
            Directory.CreateDirectory(txtOutputDir.Text);
        }

        // The input and output directories.
        private string InputDir, OutputDir;

        // Start the FileSystemWatcher.
        private void btnWatch_Click(object sender, EventArgs e)
        {
            // Clear the list of files moved.
            lstFilesMoved.Items.Clear();
            lstFilesMoved.Items.Add("Ready");

            // Make sure the file paths end with \.
            InputDir = txtInputDir.Text;
            if (!InputDir.EndsWith("\\")) InputDir += "\\";
            OutputDir = txtOutputDir.Text;
            if (!OutputDir.EndsWith("\\")) OutputDir += "\\";

            // Prepare and start the watcher.
            fswInputDir.Path = txtInputDir.Text;
            fswInputDir.EnableRaisingEvents = true;
        }

        // The watcher detected a new file. Move it into the output directory.
        private void fswInputDir_Created(object sender, FileSystemEventArgs e)
        {
            // Try to move the file.
            lstFilesMoved.Items.Add(e.Name);
            try
            {
                // Compose the source and destination file names.
                string from_file = InputDir + e.Name;
                string to_file = OutputDir + e.Name;

                // If the destination file already exists, delete it.
                if (File.Exists(to_file)) File.Delete(to_file);

                // Move the file.
                File.Move(from_file, to_file);
            }
            catch (Exception ex)
            {
                lstFilesMoved.Items.Add("    " + ex.Message);
            }
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
            this.txtInputDir = new System.Windows.Forms.TextBox();
            this.txtOutputDir = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnWatch = new System.Windows.Forms.Button();
            this.fswInputDir = new System.IO.FileSystemWatcher();
            this.lstFilesMoved = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.fswInputDir)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From Directory:";
            // 
            // txtInputDir
            // 
            this.txtInputDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputDir.Location = new System.Drawing.Point(96, 12);
            this.txtInputDir.Name = "txtInputDir";
            this.txtInputDir.Size = new System.Drawing.Size(233, 20);
            this.txtInputDir.TabIndex = 1;
            this.txtInputDir.Text = "InputDir\\";
            // 
            // txtOutputDir
            // 
            this.txtOutputDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputDir.Location = new System.Drawing.Point(96, 38);
            this.txtOutputDir.Name = "txtOutputDir";
            this.txtOutputDir.Size = new System.Drawing.Size(233, 20);
            this.txtOutputDir.TabIndex = 3;
            this.txtOutputDir.Text = "OutputDir\\";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "To Directory:";
            // 
            // btnWatch
            // 
            this.btnWatch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnWatch.Location = new System.Drawing.Point(133, 64);
            this.btnWatch.Name = "btnWatch";
            this.btnWatch.Size = new System.Drawing.Size(75, 23);
            this.btnWatch.TabIndex = 4;
            this.btnWatch.Text = "Watch";
            this.btnWatch.UseVisualStyleBackColor = true;
            this.btnWatch.Click += new System.EventHandler(this.btnWatch_Click);
            // 
            // fswInputDir
            // 
            this.fswInputDir.EnableRaisingEvents = true;
            this.fswInputDir.SynchronizingObject = this;
            this.fswInputDir.Created += new System.IO.FileSystemEventHandler(this.fswInputDir_Created);
            // 
            // lstFilesMoved
            // 
            this.lstFilesMoved.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFilesMoved.FormattingEnabled = true;
            this.lstFilesMoved.HorizontalScrollbar = true;
            this.lstFilesMoved.IntegralHeight = false;
            this.lstFilesMoved.Location = new System.Drawing.Point(12, 93);
            this.lstFilesMoved.Name = "lstFilesMoved";
            this.lstFilesMoved.Size = new System.Drawing.Size(317, 156);
            this.lstFilesMoved.TabIndex = 5;
            // 
            // howto_use_filesystemwatcher_Form1
            // 
            this.AcceptButton = this.btnWatch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 261);
            this.Controls.Add(this.lstFilesMoved);
            this.Controls.Add(this.btnWatch);
            this.Controls.Add(this.txtOutputDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInputDir);
            this.Controls.Add(this.label1);
            this.Name = "howto_use_filesystemwatcher_Form1";
            this.Text = "howto_use_filesystemwatcher";
            this.Load += new System.EventHandler(this.howto_use_filesystemwatcher_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fswInputDir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInputDir;
        private System.Windows.Forms.TextBox txtOutputDir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnWatch;
        private System.IO.FileSystemWatcher fswInputDir;
        private System.Windows.Forms.ListBox lstFilesMoved;
    }
}

