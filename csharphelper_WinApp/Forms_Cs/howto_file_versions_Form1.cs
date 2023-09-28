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
     public partial class howto_file_versions_Form1:Form
  { 


        public howto_file_versions_Form1()
        {
            InitializeComponent();
        }

        // Get the basic file name.
        private string LogFileName;
        private void howto_file_versions_Form1_Load(object sender, EventArgs e)
        {
            LogFileName = Application.StartupPath;
            LogFileName = Path.GetFullPath(
                Path.Combine(LogFileName, "..\\..\\log.txt"));
        }

        // Write an entry into the log file.
        private void btnWrite_Click(object sender, EventArgs e)
        {
            WriteToLog(txtEntry.Text, LogFileName, 100, 3);
            txtEntry.Clear();
            txtEntry.Focus();
        }

        // If the file exceeds max_size bytes, move it to a new file
        // with .1 appended to the name and bump down older versions.
        // (E.g. log.txt.1, log.txt.2, etc.)
        // Then write the text into the main log file. 
        private void WriteToLog(string new_text, string file_name, long max_size, int num_backups)
        {
            // See if the file is too big.
            FileInfo file_info = new FileInfo(file_name);
            if (file_info.Exists && file_info.Length > max_size)
            {
                // Remove the oldest version if it exists.
                if (File.Exists(file_name + "." + num_backups.ToString()))
                {
                    File.Delete(file_name + "." + num_backups.ToString());
                }

                // Bump down earlier backups.
                for (int i = num_backups - 1; i > 0; i--)
                {
                    if (File.Exists(file_name + "." + i.ToString()))
                    {
                        // Move file i to file i + 1.
                        File.Move(file_name + "." + i.ToString(),
                             file_name + "." + (i + 1).ToString());
                    }
                }

                // Move the main log file.
                File.Move(file_name, file_name + ".1");
            }

            // Write the text.
            File.AppendAllText(file_name, new_text + '\n');
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
            this.btnWrite = new System.Windows.Forms.Button();
            this.txtEntry = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnWrite
            // 
            this.btnWrite.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnWrite.Location = new System.Drawing.Point(130, 57);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(75, 23);
            this.btnWrite.TabIndex = 0;
            this.btnWrite.Text = "Write";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // txtEntry
            // 
            this.txtEntry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEntry.Location = new System.Drawing.Point(12, 12);
            this.txtEntry.Name = "txtEntry";
            this.txtEntry.Size = new System.Drawing.Size(310, 20);
            this.txtEntry.TabIndex = 1;
            this.txtEntry.Text = "When in worry or in doubt, run in circles, scream, and shout.";
            // 
            // howto_file_versions_Form1
            // 
            this.AcceptButton = this.btnWrite;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 114);
            this.Controls.Add(this.txtEntry);
            this.Controls.Add(this.btnWrite);
            this.Name = "howto_file_versions_Form1";
            this.Text = "howto_file_versions";
            this.Load += new System.EventHandler(this.howto_file_versions_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.TextBox txtEntry;
    }
}

