using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;


 

using howto_crypt_file;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_crypt_file_Form1:Form
  { 


        public howto_crypt_file_Form1()
        {
            InitializeComponent();
        }

        private void howto_crypt_file_Form1_Load(object sender, EventArgs e)
        {
            string file_path = Path.Combine(Application.StartupPath, "..\\..");
            file_path = new FileInfo(file_path).FullName;

            txtPlaintextFile.Text = file_path + "\\plaintext.txt";
            txtCiphertextFile.Text = file_path + "\\ciphertext.dat";
            txtDecipheredFile.Text = file_path + "\\deciphered.txt";

            // Display the original file.
            txtPlaintext.Text = File.ReadAllText(txtPlaintextFile.Text);
        }

        // Encrypt the plaintext file.
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            // Encrypt the file.
            CryptoStuff.EncryptFile(txtPassword.Text, txtPlaintextFile.Text, txtCiphertextFile.Text);

            // Display the result.
            txtCiphertext.Text = File.ReadAllBytes(txtCiphertextFile.Text).ToHex(' ');
        }

        // Decrypt the ciphertext file.
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            // Decrypt the file.
            CryptoStuff.DecryptFile(txtPassword.Text, txtCiphertextFile.Text, txtDecipheredFile.Text);

            // Display the result.
            txtDeciphered.Text = File.ReadAllText(txtDecipheredFile.Text);
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
            this.txtDeciphered = new System.Windows.Forms.TextBox();
            this.txtCiphertext = new System.Windows.Forms.TextBox();
            this.txtPlaintext = new System.Windows.Forms.TextBox();
            this.txtDecipheredFile = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.txtCiphertextFile = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtPlaintextFile = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDeciphered
            // 
            this.txtDeciphered.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDeciphered.Location = new System.Drawing.Point(487, 78);
            this.txtDeciphered.Margin = new System.Windows.Forms.Padding(0, 2, 3, 3);
            this.txtDeciphered.Multiline = true;
            this.txtDeciphered.Name = "txtDeciphered";
            this.txtDeciphered.ReadOnly = true;
            this.txtDeciphered.Size = new System.Drawing.Size(200, 86);
            this.txtDeciphered.TabIndex = 78;
            // 
            // txtCiphertext
            // 
            this.txtCiphertext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCiphertext.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCiphertext.Location = new System.Drawing.Point(247, 78);
            this.txtCiphertext.Margin = new System.Windows.Forms.Padding(0, 2, 3, 3);
            this.txtCiphertext.Multiline = true;
            this.txtCiphertext.Name = "txtCiphertext";
            this.txtCiphertext.ReadOnly = true;
            this.txtCiphertext.Size = new System.Drawing.Size(200, 86);
            this.txtCiphertext.TabIndex = 77;
            // 
            // txtPlaintext
            // 
            this.txtPlaintext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPlaintext.Location = new System.Drawing.Point(7, 78);
            this.txtPlaintext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.txtPlaintext.Multiline = true;
            this.txtPlaintext.Name = "txtPlaintext";
            this.txtPlaintext.ReadOnly = true;
            this.txtPlaintext.Size = new System.Drawing.Size(200, 86);
            this.txtPlaintext.TabIndex = 76;
            // 
            // txtDecipheredFile
            // 
            this.txtDecipheredFile.Location = new System.Drawing.Point(487, 54);
            this.txtDecipheredFile.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.txtDecipheredFile.Name = "txtDecipheredFile";
            this.txtDecipheredFile.Size = new System.Drawing.Size(200, 20);
            this.txtDecipheredFile.TabIndex = 5;
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(487, 30);
            this.Label4.Margin = new System.Windows.Forms.Padding(3, 3, 2, 1);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(200, 24);
            this.Label4.TabIndex = 74;
            this.Label4.Text = "Deciphered";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(71, 6);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(611, 20);
            this.txtPassword.TabIndex = 0;
            this.txtPassword.Text = "The quick brown fox jumps over the lazy dog";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(7, 9);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(53, 13);
            this.Label3.TabIndex = 72;
            this.Label3.Text = "Password";
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(455, 54);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(23, 23);
            this.btnDecrypt.TabIndex = 4;
            this.btnDecrypt.TabStop = false;
            this.btnDecrypt.Text = ">";
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(215, 54);
            this.btnEncrypt.Margin = new System.Windows.Forms.Padding(3, 2, 1, 3);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(23, 23);
            this.btnEncrypt.TabIndex = 2;
            this.btnEncrypt.TabStop = false;
            this.btnEncrypt.Text = ">";
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // txtCiphertextFile
            // 
            this.txtCiphertextFile.Location = new System.Drawing.Point(247, 54);
            this.txtCiphertextFile.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.txtCiphertextFile.Name = "txtCiphertextFile";
            this.txtCiphertextFile.Size = new System.Drawing.Size(200, 20);
            this.txtCiphertextFile.TabIndex = 3;
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(247, 30);
            this.Label2.Margin = new System.Windows.Forms.Padding(3, 3, 2, 1);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(200, 24);
            this.Label2.TabIndex = 68;
            this.Label2.Text = "Ciphertext";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPlaintextFile
            // 
            this.txtPlaintextFile.Location = new System.Drawing.Point(7, 54);
            this.txtPlaintextFile.Margin = new System.Windows.Forms.Padding(1, 1, 3, 2);
            this.txtPlaintextFile.Name = "txtPlaintextFile";
            this.txtPlaintextFile.Size = new System.Drawing.Size(200, 20);
            this.txtPlaintextFile.TabIndex = 1;
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(7, 30);
            this.Label1.Margin = new System.Windows.Forms.Padding(3, 3, 2, 1);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(200, 24);
            this.Label1.TabIndex = 66;
            this.Label1.Text = "Plaintext";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_crypt_file_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 171);
            this.Controls.Add(this.txtDeciphered);
            this.Controls.Add(this.txtCiphertext);
            this.Controls.Add(this.txtPlaintext);
            this.Controls.Add(this.txtDecipheredFile);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.txtCiphertextFile);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtPlaintextFile);
            this.Controls.Add(this.Label1);
            this.Name = "howto_crypt_file_Form1";
            this.Text = "howto_crypt_file";
            this.Load += new System.EventHandler(this.howto_crypt_file_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtDeciphered;
        internal System.Windows.Forms.TextBox txtCiphertext;
        internal System.Windows.Forms.TextBox txtPlaintext;
        internal System.Windows.Forms.TextBox txtDecipheredFile;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button btnDecrypt;
        internal System.Windows.Forms.Button btnEncrypt;
        internal System.Windows.Forms.TextBox txtCiphertextFile;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtPlaintextFile;
        internal System.Windows.Forms.Label Label1;
    }
}

