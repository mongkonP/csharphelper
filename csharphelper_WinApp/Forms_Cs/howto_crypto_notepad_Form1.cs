using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

 

using howto_crypto_notepad;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_crypto_notepad_Form1:Form
  { 


        public howto_crypto_notepad_Form1()
        {
            InitializeComponent();
        }

        private const string NOTES_FILE = "Notes.dat";
        private string Password;
        private bool SaveChanges = false;

        // Load the encrypted notes.
        private void howto_crypto_notepad_Form1_Load(object sender, EventArgs e)
        {
            // Get the password.
            if (InputBox("Password", "", out Password) == DialogResult.Cancel)
            {
                Close();
                return;
            }

            // If the notes file exists, decrypt it.
            if (File.Exists(NOTES_FILE))
            {
                try
                {
                    rchNotes.Rtf = File.ReadAllBytes(NOTES_FILE).Decrypt(Password);
                }
                catch
                {
                    MessageBox.Show("Invalid password");
                    Close();
                    return;
                }
            }

            // We're all logged in. If we close after this, save changes.
            SaveChanges = true;
        }

        // Save the encrypted notes.
        private void howto_crypto_notepad_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SaveChanges)
                File.WriteAllBytes(NOTES_FILE,
                    rchNotes.Rtf.Encrypt(Password));
        }

        // Prompt the user for a simple text value.
        private DialogResult InputBox(string prompt, string default_value, out string result)
        {
            howto_crypto_notepad_frmInputBox dlg = new  howto_crypto_notepad_frmInputBox();
            dlg.Text = prompt;
            dlg.lblPrompt.Text = prompt;
            dlg.txtValue.Text = default_value;

            DialogResult dialog_result = dlg.ShowDialog();

            result = dlg.txtValue.Text;
            return dialog_result;
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
            this.rchNotes = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rchNotes
            // 
            this.rchNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rchNotes.Location = new System.Drawing.Point(0, 0);
            this.rchNotes.Name = "rchNotes";
            this.rchNotes.Size = new System.Drawing.Size(811, 466);
            this.rchNotes.TabIndex = 0;
            this.rchNotes.Text = "";
            // 
            // howto_crypto_notepad_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 466);
            this.Controls.Add(this.rchNotes);
            this.Name = "howto_crypto_notepad_Form1";
            this.Text = "howto_crypto_notepad";
            this.Load += new System.EventHandler(this.howto_crypto_notepad_Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_crypto_notepad_Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rchNotes;
    }
}

