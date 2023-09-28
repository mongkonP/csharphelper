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
     public partial class howto_set_textbox_case_Form1:Form
  { 


        public howto_set_textbox_case_Form1()
        {
            InitializeComponent();
        }

        private void howto_set_textbox_case_Form1_Load(object sender, EventArgs e)
        {
            txtLowerCase.CharacterCasing = CharacterCasing.Lower;
            txtUpperCase.CharacterCasing = CharacterCasing.Upper;
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
            this.txtUpperCase = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLowerCase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMixedCase = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUpperCase
            // 
            this.txtUpperCase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUpperCase.Location = new System.Drawing.Point(84, 66);
            this.txtUpperCase.Name = "txtUpperCase";
            this.txtUpperCase.Size = new System.Drawing.Size(208, 20);
            this.txtUpperCase.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Upper Case:";
            // 
            // txtLowerCase
            // 
            this.txtLowerCase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLowerCase.Location = new System.Drawing.Point(84, 40);
            this.txtLowerCase.Name = "txtLowerCase";
            this.txtLowerCase.Size = new System.Drawing.Size(208, 20);
            this.txtLowerCase.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Lower Case:";
            // 
            // txtMixedCase
            // 
            this.txtMixedCase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMixedCase.Location = new System.Drawing.Point(84, 14);
            this.txtMixedCase.Name = "txtMixedCase";
            this.txtMixedCase.Size = new System.Drawing.Size(208, 20);
            this.txtMixedCase.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "MIxed Case:";
            // 
            // howto_set_textbox_case_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 101);
            this.Controls.Add(this.txtUpperCase);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLowerCase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMixedCase);
            this.Controls.Add(this.label1);
            this.Name = "howto_set_textbox_case_Form1";
            this.Text = "howto_set_textbox_case";
            this.Load += new System.EventHandler(this.howto_set_textbox_case_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUpperCase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLowerCase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMixedCase;
        private System.Windows.Forms.Label label1;
    }
}

