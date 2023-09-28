using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_start_process_and_wait_Form1:Form
  { 


        public howto_start_process_and_wait_Form1()
        {
            InitializeComponent();
        }

        // Load the previously saved file.
        private string Filename = "";
        private void howto_start_process_and_wait_Form1_Load(object sender, EventArgs e)
        {
            // Compose the file's name.
            Filename = Path.GetFullPath(
                Path.Combine(Application.StartupPath, @"..\..")) +
                @"\text.rtf";

            // If the file exists, load it.
            if (File.Exists(Filename)) rchText.LoadFile(Filename);
        }

        // Allow the user to edit the file with WordPad.
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Hide.
            this.ShowInTaskbar = false;
            this.Hide();

            // Save the current text into the file.
            rchText.SaveFile(Filename);

            // We will open Filename with wordpad.exe.
            ProcessStartInfo start_info =
                new ProcessStartInfo("wordpad.exe", Filename);
            start_info.WindowStyle = ProcessWindowStyle.Maximized;

            // Open wordpad.
            Process proc = new Process();
            proc.StartInfo = start_info;
            proc.Start();

            // Wait for wordpad to finish.
            proc.WaitForExit();

            // Reload the file.
            rchText.LoadFile(Filename);

            // Unhide.
            this.ShowInTaskbar = true;
            this.Show();
        }

        // Save the current text into the file.
        private void howto_start_process_and_wait_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            rchText.SaveFile(Filename);
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
            this.rchText = new System.Windows.Forms.RichTextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rchText
            // 
            this.rchText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rchText.Location = new System.Drawing.Point(12, 12);
            this.rchText.Name = "rchText";
            this.rchText.Size = new System.Drawing.Size(333, 119);
            this.rchText.TabIndex = 0;
            this.rchText.Text = "";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEdit.Location = new System.Drawing.Point(126, 137);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(104, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit in WordPad";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // howto_start_process_and_wait_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 172);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.rchText);
            this.Name = "howto_start_process_and_wait_Form1";
            this.Text = "howto_start_process_and_wait";
            this.Load += new System.EventHandler(this.howto_start_process_and_wait_Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_start_process_and_wait_Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rchText;
        private System.Windows.Forms.Button btnEdit;
    }
}

