using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Security.Cryptography;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_hash_file_Form1:Form
  { 


        public howto_hash_file_Form1()
        {
            InitializeComponent();
        }

        // Start with the executable selected.
        private void howto_hash_file_Form1_Load(object sender, EventArgs e)
        {
            txtFile.Text = Application.ExecutablePath;
        }

        // Compute the file's hash code.
        private void btnHash_Click(object sender, EventArgs e)
        {
            txtMd5.Text = BytesToString(GetHashMD5(txtFile.Text));
            txtSha256.Text = BytesToString(GetHashSha256(txtFile.Text));
        }

        // Let the user select a file.
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ofdFile.FileName = txtFile.Text;
            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = ofdFile.FileName;
                txtMd5.Clear();
                txtSha256.Clear();
            }
        }

        // The cryptographic service provider.
        private MD5 Md5 = MD5.Create();

        // Compute the file's hash.
        private byte[] GetHashMD5(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                return Md5.ComputeHash(stream);
            }
        }

        // The cryptographic service provider.
        private SHA256 Sha256 = SHA256.Create();

        // Compute the file's hash.
        private byte[] GetHashSha256(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                return Sha256.ComputeHash(stream);
            }
        }

        // Return a byte array as a sequence of hex values.
        public static string BytesToString(byte[] bytes)
        {
            string result = "";
            foreach (byte b in bytes) result += b.ToString("x2");
            return result;
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.btnHash = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMd5 = new System.Windows.Forms.TextBox();
            this.txtSha256 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "SHA256:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "MD5:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Image = Properties.Resources.EllipsisTransparent;
            this.btnBrowse.Location = new System.Drawing.Point(361, 11);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(30, 23);
            this.btnBrowse.TabIndex = 10;
            this.btnBrowse.TabStop = false;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // ofdFile
            // 
            this.ofdFile.FileName = "openFileDialog1";
            // 
            // btnHash
            // 
            this.btnHash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHash.Location = new System.Drawing.Point(397, 11);
            this.btnHash.Name = "btnHash";
            this.btnHash.Size = new System.Drawing.Size(75, 23);
            this.btnHash.TabIndex = 11;
            this.btnHash.Text = "Hash";
            this.btnHash.UseVisualStyleBackColor = true;
            this.btnHash.Click += new System.EventHandler(this.btnHash_Click);
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(68, 13);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(287, 20);
            this.txtFile.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "File:";
            // 
            // txtMd5
            // 
            this.txtMd5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMd5.Location = new System.Drawing.Point(68, 61);
            this.txtMd5.Name = "txtMd5";
            this.txtMd5.ReadOnly = true;
            this.txtMd5.Size = new System.Drawing.Size(404, 20);
            this.txtMd5.TabIndex = 16;
            // 
            // txtSha256
            // 
            this.txtSha256.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSha256.Location = new System.Drawing.Point(68, 87);
            this.txtSha256.Name = "txtSha256";
            this.txtSha256.ReadOnly = true;
            this.txtSha256.Size = new System.Drawing.Size(404, 20);
            this.txtSha256.TabIndex = 17;
            // 
            // howto_hash_file_Form1
            // 
            this.AcceptButton = this.btnHash;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 119);
            this.Controls.Add(this.txtSha256);
            this.Controls.Add(this.txtMd5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnHash);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label1);
            this.Name = "howto_hash_file_Form1";
            this.Text = "howto_hash_file";
            this.Load += new System.EventHandler(this.howto_hash_file_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.Button btnHash;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMd5;
        private System.Windows.Forms.TextBox txtSha256;
    }
}

