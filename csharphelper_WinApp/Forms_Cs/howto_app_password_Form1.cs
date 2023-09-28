using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Set PasswordForm.btnOk.Modifiers = Public.

 

using howto_app_password;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_app_password_Form1:Form
  { 


        public howto_app_password_Form1()
        {
            InitializeComponent();
        }

        // Get the password from the user.
        private void howto_app_password_Form1_Load(object sender, EventArgs e)
        {
            const string token = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string encrypted = "0dbc23df7b4358281cbc83b89745db7a9da4a7e54c68c30965832908ea32a369";

            // Get the password from the user.
            howto_app_password_PasswordForm frm = new  howto_app_password_PasswordForm();
            if (frm.ShowDialog() == DialogResult.Cancel) Close();

            // See if the password is correct.
            string password = frm.txtPassword.Text;
            if (token.Encrypt(password).ToHex() != encrypted) Close();
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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome!";
            // 
            // howto_app_password_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 111);
            this.Controls.Add(this.label1);
            this.Name = "howto_app_password_Form1";
            this.Text = "howto_app_password";
            this.Load += new System.EventHandler(this.howto_app_password_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
    }
}

