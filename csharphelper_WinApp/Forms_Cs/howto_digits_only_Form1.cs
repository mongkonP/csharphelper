using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Text.RegularExpressions;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_digits_only_Form1:Form
  { 


        public howto_digits_only_Form1()
        {
            InitializeComponent();
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            // Display only letters.
            txtLetters.Text =
                Regex.Replace(txtString.Text, "[^a-zA-Z]", "");

            // Display only digits.
            txtDigits.Text =
                Regex.Replace(txtString.Text, "[^0-9]", "");
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
            this.txtDigits = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLetters = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReplace = new System.Windows.Forms.Button();
            this.txtString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDigits
            // 
            this.txtDigits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDigits.Location = new System.Drawing.Point(60, 93);
            this.txtDigits.Name = "txtDigits";
            this.txtDigits.Size = new System.Drawing.Size(212, 20);
            this.txtDigits.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Digits:";
            // 
            // txtLetters
            // 
            this.txtLetters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLetters.Location = new System.Drawing.Point(60, 67);
            this.txtLetters.Name = "txtLetters";
            this.txtLetters.Size = new System.Drawing.Size(212, 20);
            this.txtLetters.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Letters:";
            // 
            // btnReplace
            // 
            this.btnReplace.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnReplace.Location = new System.Drawing.Point(105, 38);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(75, 23);
            this.btnReplace.TabIndex = 9;
            this.btnReplace.Text = "Replace";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // txtString
            // 
            this.txtString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtString.Location = new System.Drawing.Point(60, 12);
            this.txtString.Name = "txtString";
            this.txtString.Size = new System.Drawing.Size(212, 20);
            this.txtString.TabIndex = 8;
            this.txtString.Text = "NCC-1701";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "String:";
            // 
            // howto_digits_only_Form1
            // 
            this.AcceptButton = this.btnReplace;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 128);
            this.Controls.Add(this.txtDigits);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLetters);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.txtString);
            this.Controls.Add(this.label1);
            this.Name = "howto_digits_only_Form1";
            this.Text = "howto_digits_only";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDigits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLetters;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.TextBox txtString;
        private System.Windows.Forms.Label label1;
    }
}

