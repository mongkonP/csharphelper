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
     public partial class howto_run_dos_capture_output_Form1:Form
  { 


        public howto_run_dos_capture_output_Form1()
        {
            InitializeComponent();
        }

        // Initialize.
        private void howto_run_dos_capture_output_Form1_Load(object sender, EventArgs e)
        {
            txtProgram.Text = Path.GetFullPath(Path.Combine(
                    Application.StartupPath, "..\\..\\hello.bat"));
            txtProgram.Select(0, 0);
        }

        // Run the DOS program.
        private void btnRun_Click(object sender, EventArgs e)
        {
            // Set start information.
            ProcessStartInfo start_info = new ProcessStartInfo(txtProgram.Text);
            start_info.UseShellExecute = false;
            start_info.CreateNoWindow = true;
            start_info.RedirectStandardOutput = true;
            start_info.RedirectStandardError = true;

            // Make the process and set its start information.
            using (Process proc = new Process())
            {
                proc.StartInfo = start_info;

                // Start the process.
                proc.Start();

                // Attach to stdout and stderr.
                using (StreamReader std_out = proc.StandardOutput)
                {
                    using (StreamReader std_err = proc.StandardError)
                    {
                        // Display the results.
                        txtStdout.Text = std_out.ReadToEnd();
                        txtStderr.Text = std_err.ReadToEnd();

                        // Clean up.
                        std_err.Close();
                        std_out.Close();
                        proc.Close();
                    }
                }
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
            this.Label3 = new System.Windows.Forms.Label();
            this.txtStderr = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtStdout = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.txtProgram = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label3.Location = new System.Drawing.Point(0, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(29, 13);
            this.Label3.TabIndex = 13;
            this.Label3.Text = "Error";
            // 
            // txtStderr
            // 
            this.txtStderr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStderr.Location = new System.Drawing.Point(0, 13);
            this.txtStderr.Multiline = true;
            this.txtStderr.Name = "txtStderr";
            this.txtStderr.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStderr.Size = new System.Drawing.Size(316, 49);
            this.txtStderr.TabIndex = 12;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label2.Location = new System.Drawing.Point(0, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(39, 13);
            this.Label2.TabIndex = 11;
            this.Label2.Text = "Output";
            // 
            // txtStdout
            // 
            this.txtStdout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStdout.Location = new System.Drawing.Point(0, 13);
            this.txtStdout.Multiline = true;
            this.txtStdout.Name = "txtStdout";
            this.txtStdout.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStdout.Size = new System.Drawing.Size(316, 87);
            this.txtStdout.TabIndex = 10;
            // 
            // btnRun
            // 
            this.btnRun.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRun.Location = new System.Drawing.Point(143, 41);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(56, 23);
            this.btnRun.TabIndex = 9;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // txtProgram
            // 
            this.txtProgram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProgram.Location = new System.Drawing.Point(60, 9);
            this.txtProgram.Name = "txtProgram";
            this.txtProgram.Size = new System.Drawing.Size(271, 20);
            this.txtProgram.TabIndex = 8;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(46, 13);
            this.Label1.TabIndex = 7;
            this.Label1.Text = "Program";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(15, 70);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtStdout);
            this.splitContainer1.Panel1.Controls.Add(this.Label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtStderr);
            this.splitContainer1.Panel2.Controls.Add(this.Label3);
            this.splitContainer1.Size = new System.Drawing.Size(316, 166);
            this.splitContainer1.SplitterDistance = 100;
            this.splitContainer1.TabIndex = 14;
            // 
            // howto_run_dos_capture_output_Form1
            // 
            this.AcceptButton = this.btnRun;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 248);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtProgram);
            this.Controls.Add(this.Label1);
            this.Name = "howto_run_dos_capture_output_Form1";
            this.Text = "howto_run_dos_capture_output";
            this.Load += new System.EventHandler(this.howto_run_dos_capture_output_Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtStderr;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtStdout;
        internal System.Windows.Forms.Button btnRun;
        internal System.Windows.Forms.TextBox txtProgram;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

