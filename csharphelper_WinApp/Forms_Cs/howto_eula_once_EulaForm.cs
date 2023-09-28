using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_eula_once;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_eula_once_EulaForm:Form
  { 


        public howto_eula_once_EulaForm()
        {
            InitializeComponent();
        }

        // Load the EULA file.
        private void howto_eula_once_EulaForm_Load(object sender, EventArgs e)
        {
            rchEula.LoadFile("Eula.rtf");
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
            this.rchEula = new System.Windows.Forms.RichTextBox();
            this.btnDecline = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rchEula
            // 
            this.rchEula.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rchEula.Location = new System.Drawing.Point(12, 12);
            this.rchEula.Name = "rchEula";
            this.rchEula.Size = new System.Drawing.Size(460, 308);
            this.rchEula.TabIndex = 0;
            this.rchEula.Text = "";
            // 
            // btnDecline
            // 
            this.btnDecline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDecline.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDecline.Location = new System.Drawing.Point(316, 326);
            this.btnDecline.Name = "btnDecline";
            this.btnDecline.Size = new System.Drawing.Size(75, 23);
            this.btnDecline.TabIndex = 1;
            this.btnDecline.Text = "Decline";
            this.btnDecline.UseVisualStyleBackColor = true;
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Location = new System.Drawing.Point(397, 326);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            // 
            // howto_eula_once_EulaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnDecline);
            this.Controls.Add(this.rchEula);
            this.Name = "howto_eula_once_EulaForm";
            this.Text = "End User License Agreement";
            this.Load += new System.EventHandler(this.howto_eula_once_EulaForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rchEula;
        private System.Windows.Forms.Button btnDecline;
        private System.Windows.Forms.Button btnAccept;
    }
}