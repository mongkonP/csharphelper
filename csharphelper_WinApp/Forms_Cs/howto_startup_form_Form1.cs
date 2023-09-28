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
     public partial class howto_startup_form_Form1:Form
  { 


        public howto_startup_form_Form1()
        {
            InitializeComponent();
        }

        // Display a new form with a blue background.
        private void btnNewForm_Click(object sender, EventArgs e)
        {
            howto_startup_form_Form1 frm = new howto_startup_form_Form1();
            frm.BackColor = Color.LightBlue;
            frm.Show();
        }

        // If this is the main form and any other forms have their
        // Prevent Startup From Closing boxes checked, don't close.
        private void howto_startup_form_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // See if this is the main form.
            if (this == Application.OpenForms[0])
                // See if any form has the CheckBox checked.
                foreach (howto_startup_form_Form1 frm in Application.OpenForms)
                    if (frm.chkPreventStartupFromClosing.Checked)
                    {
                        e.Cancel = true;
                        break;
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
            this.chkPreventStartupFromClosing = new System.Windows.Forms.CheckBox();
            this.btnNewForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkPreventStartupFromClosing
            // 
            this.chkPreventStartupFromClosing.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkPreventStartupFromClosing.AutoSize = true;
            this.chkPreventStartupFromClosing.Location = new System.Drawing.Point(61, 66);
            this.chkPreventStartupFromClosing.Name = "chkPreventStartupFromClosing";
            this.chkPreventStartupFromClosing.Size = new System.Drawing.Size(163, 17);
            this.chkPreventStartupFromClosing.TabIndex = 3;
            this.chkPreventStartupFromClosing.Text = "Prevent Startup From Closing";
            this.chkPreventStartupFromClosing.UseVisualStyleBackColor = true;
            // 
            // btnNewForm
            // 
            this.btnNewForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNewForm.Location = new System.Drawing.Point(105, 27);
            this.btnNewForm.Name = "btnNewForm";
            this.btnNewForm.Size = new System.Drawing.Size(75, 23);
            this.btnNewForm.TabIndex = 2;
            this.btnNewForm.Text = "New Form";
            this.btnNewForm.UseVisualStyleBackColor = true;
            this.btnNewForm.Click += new System.EventHandler(this.btnNewForm_Click);
            // 
            // howto_startup_form_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Controls.Add(this.chkPreventStartupFromClosing);
            this.Controls.Add(this.btnNewForm);
            this.Name = "howto_startup_form_Form1";
            this.Text = "howto_startup_form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_startup_form_Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkPreventStartupFromClosing;
        private System.Windows.Forms.Button btnNewForm;
    }
}

