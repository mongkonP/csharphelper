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
     public partial class howto_reuse_form_Form1:Form
  { 


        public howto_reuse_form_Form1()
        {
            InitializeComponent();
        }

        // The reusable form.
        private howto_reuse_form_ReusableForm TheReusableForm = new  howto_reuse_form_ReusableForm();

        // Display the reusable form.
        private void btnReusableForm_Click(object sender, EventArgs e)
        {
            TheReusableForm.Show();
            TheReusableForm.Activate();
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
            this.btnReusableForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReusableForm
            // 
            this.btnReusableForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReusableForm.Location = new System.Drawing.Point(94, 44);
            this.btnReusableForm.Name = "btnReusableForm";
            this.btnReusableForm.Size = new System.Drawing.Size(97, 23);
            this.btnReusableForm.TabIndex = 2;
            this.btnReusableForm.Text = "Reusable Form";
            this.btnReusableForm.UseVisualStyleBackColor = true;
            this.btnReusableForm.Click += new System.EventHandler(this.btnReusableForm_Click);
            // 
            // howto_reuse_form_Form1
            // 
            this.AcceptButton = this.btnReusableForm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Controls.Add(this.btnReusableForm);
            this.Name = "howto_reuse_form_Form1";
            this.Text = "howto_reuse_form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReusableForm;
    }
}

