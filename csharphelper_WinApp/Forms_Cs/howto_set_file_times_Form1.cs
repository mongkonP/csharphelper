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
     public partial class howto_set_file_times_Form1:Form
  { 


        public howto_set_file_times_Form1()
        {
            InitializeComponent();
        }

        // Start with the executable file selected.
        private void howto_set_file_times_Form1_Load(object sender, EventArgs e)
        {
            txtFile.Text = Application.ExecutablePath;
        }

        // Let the user pick a file.
        private void btnPickFile_Click(object sender, EventArgs e)
        {
            ofdFile.FileName = txtFile.Text;
            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = ofdFile.FileName;
            }
        }

        // Get the file's times.
        private void btnGetTimes_Click(object sender, EventArgs e)
        {
            txtCreationTime.Text = File.GetCreationTime(txtFile.Text).ToString();
            txtModifiedTime.Text = File.GetLastWriteTime(txtFile.Text).ToString();
            txtAccessTime.Text = File.GetLastAccessTime(txtFile.Text).ToString();
        }

        // Set the file's times.
        private void btnSetTimes_Click(object sender, EventArgs e)
        {
            File.SetCreationTime(txtFile.Text, DateTime.Parse(txtCreationTime.Text));
            File.SetLastWriteTime(txtFile.Text, DateTime.Parse(txtModifiedTime.Text));
            File.SetLastAccessTime(txtFile.Text, DateTime.Parse(txtAccessTime.Text));
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
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnPickFile = new System.Windows.Forms.Button();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.btnGetTimes = new System.Windows.Forms.Button();
            this.txtCreationTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtModifiedTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAccessTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSetTimes = new System.Windows.Forms.Button();
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
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(44, 12);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(199, 20);
            this.txtFile.TabIndex = 1;
            // 
            // btnPickFile
            // 
            this.btnPickFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPickFile.Image = Properties.Resources.Ellipsis;
            this.btnPickFile.Location = new System.Drawing.Point(249, 9);
            this.btnPickFile.Name = "btnPickFile";
            this.btnPickFile.Size = new System.Drawing.Size(23, 23);
            this.btnPickFile.TabIndex = 6;
            this.btnPickFile.UseVisualStyleBackColor = true;
            this.btnPickFile.Click += new System.EventHandler(this.btnPickFile_Click);
            // 
            // ofdFile
            // 
            this.ofdFile.FileName = "openFileDialog1";
            // 
            // btnGetTimes
            // 
            this.btnGetTimes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGetTimes.Location = new System.Drawing.Point(105, 38);
            this.btnGetTimes.Name = "btnGetTimes";
            this.btnGetTimes.Size = new System.Drawing.Size(75, 23);
            this.btnGetTimes.TabIndex = 7;
            this.btnGetTimes.Text = "Get Times";
            this.btnGetTimes.UseVisualStyleBackColor = true;
            this.btnGetTimes.Click += new System.EventHandler(this.btnGetTimes_Click);
            // 
            // txtCreationTime
            // 
            this.txtCreationTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCreationTime.Location = new System.Drawing.Point(67, 67);
            this.txtCreationTime.Name = "txtCreationTime";
            this.txtCreationTime.Size = new System.Drawing.Size(205, 20);
            this.txtCreationTime.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Creation:";
            // 
            // txtModifiedTime
            // 
            this.txtModifiedTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtModifiedTime.Location = new System.Drawing.Point(67, 93);
            this.txtModifiedTime.Name = "txtModifiedTime";
            this.txtModifiedTime.Size = new System.Drawing.Size(205, 20);
            this.txtModifiedTime.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Modified:";
            // 
            // txtAccessTime
            // 
            this.txtAccessTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccessTime.Location = new System.Drawing.Point(67, 119);
            this.txtAccessTime.Name = "txtAccessTime";
            this.txtAccessTime.Size = new System.Drawing.Size(205, 20);
            this.txtAccessTime.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Access:";
            // 
            // btnSetTimes
            // 
            this.btnSetTimes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSetTimes.Location = new System.Drawing.Point(105, 145);
            this.btnSetTimes.Name = "btnSetTimes";
            this.btnSetTimes.Size = new System.Drawing.Size(75, 23);
            this.btnSetTimes.TabIndex = 14;
            this.btnSetTimes.Text = "Set Times";
            this.btnSetTimes.UseVisualStyleBackColor = true;
            this.btnSetTimes.Click += new System.EventHandler(this.btnSetTimes_Click);
            // 
            // howto_set_file_times_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 175);
            this.Controls.Add(this.btnSetTimes);
            this.Controls.Add(this.txtAccessTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtModifiedTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCreationTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGetTimes);
            this.Controls.Add(this.btnPickFile);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label1);
            this.Name = "howto_set_file_times_Form1";
            this.Text = "howto_set_file_times";
            this.Load += new System.EventHandler(this.howto_set_file_times_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnPickFile;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.Button btnGetTimes;
        private System.Windows.Forms.TextBox txtCreationTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtModifiedTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAccessTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSetTimes;
    }
}

