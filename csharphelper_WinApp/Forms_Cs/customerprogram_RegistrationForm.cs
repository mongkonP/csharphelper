using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class customerprogram_RegistrationForm:Form
  { 


        public customerprogram_RegistrationForm()
        {
            InitializeComponent();
        }

        // Email the product number.
        private void llnkEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string cmd = "mailto:" + llnkEmail.Tag.ToString() +
            "?Subject=Product registration+Body=Product Number " +
            txtProductNumber.Text;
            System.Diagnostics.Process.Start(cmd);
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
            this.llnkEmail = new System.Windows.Forms.LinkLabel();
            this.txtProductKey = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtProductNumber = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // llnkEmail
            // 
            this.llnkEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.llnkEmail.LinkArea = new System.Windows.Forms.LinkArea(35, 22);
            this.llnkEmail.Location = new System.Drawing.Point(12, 9);
            this.llnkEmail.Name = "llnkEmail";
            this.llnkEmail.Size = new System.Drawing.Size(341, 72);
            this.llnkEmail.TabIndex = 3;
            this.llnkEmail.TabStop = true;
            this.llnkEmail.Tag = "Register@someplace.com";
            this.llnkEmail.Text = "Email the following Product ID to: Register@someplace.com. When you receive the P" +
                "roduct Key, enter it in the textbox below.";
            this.llnkEmail.UseCompatibleTextRendering = true;
            this.llnkEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llnkEmail_LinkClicked);
            // 
            // txtProductKey
            // 
            this.txtProductKey.Location = new System.Drawing.Point(159, 125);
            this.txtProductKey.Name = "txtProductKey";
            this.txtProductKey.Size = new System.Drawing.Size(152, 26);
            this.txtProductKey.TabIndex = 0;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(55, 125);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(98, 20);
            this.Label3.TabIndex = 21;
            this.Label3.Text = "Product Key:";
            // 
            // txtProductNumber
            // 
            this.txtProductNumber.Location = new System.Drawing.Point(159, 93);
            this.txtProductNumber.Name = "txtProductNumber";
            this.txtProductNumber.ReadOnly = true;
            this.txtProductNumber.Size = new System.Drawing.Size(152, 26);
            this.txtProductNumber.TabIndex = 4;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(55, 93);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(89, 20);
            this.Label2.TabIndex = 20;
            this.Label2.Text = "Product ID:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(278, 172);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(190, 172);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 32);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // customerprogram_RegistrationForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(363, 214);
            this.Controls.Add(this.llnkEmail);
            this.Controls.Add(this.txtProductKey);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtProductNumber);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "customerprogram_RegistrationForm";
            this.Text = "customerprogram_RegistrationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel llnkEmail;
        internal System.Windows.Forms.TextBox txtProductKey;
        private System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtProductNumber;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}