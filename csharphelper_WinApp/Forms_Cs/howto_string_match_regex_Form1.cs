using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_string_match_regex;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_string_match_regex_Form1:Form
  { 


        public howto_string_match_regex_Form1()
        {
            InitializeComponent();
        }

        // Validate a 7-digit US phone number.
        private void txt7Digit_TextChanged(object sender, EventArgs e)
        {
            if (txt7Digit.Text.Matches("^[2-9]{3}-\\d{4}$"))
            {
                txt7Digit.BackColor = Color.White;
            }
            else
            {
                txt7Digit.BackColor = Color.Yellow;
            }
        }

        // Validate a 10-digit US phone number.
        private void txt10Digit_TextChanged(object sender, EventArgs e)
        {
            if (txt10Digit.Text.Matches("^[2-9]{3}-[2-9]{3}-\\d{4}$"))
            {
                txt10Digit.BackColor = Color.White;
            }
            else
            {
                txt10Digit.BackColor = Color.Yellow;
            }
        }

        // Validate a 7- or 10-digit US phone number.
        private void txtEither_TextChanged(object sender, EventArgs e)
        {
            if (txtEither.Text.Matches("^([2-9]{3}-)?[2-9]{3}-\\d{4}$"))
            {
                txtEither.BackColor = Color.White;
            }
            else
            {
                txtEither.BackColor = Color.Yellow;
            }
        }

    

/// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            this.txt7Digit = new System.Windows.Forms.TextBox();
            this.txt10Digit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEither = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "XXX-XXXX";
            // 
            // txt7Digit
            // 
            this.txt7Digit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt7Digit.BackColor = System.Drawing.Color.Yellow;
            this.txt7Digit.Location = new System.Drawing.Point(127, 9);
            this.txt7Digit.Name = "txt7Digit";
            this.txt7Digit.Size = new System.Drawing.Size(221, 20);
            this.txt7Digit.TabIndex = 1;
            this.txt7Digit.TextChanged += new System.EventHandler(this.txt7Digit_TextChanged);
            // 
            // txt10Digit
            // 
            this.txt10Digit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt10Digit.BackColor = System.Drawing.Color.Yellow;
            this.txt10Digit.Location = new System.Drawing.Point(127, 35);
            this.txt10Digit.Name = "txt10Digit";
            this.txt10Digit.Size = new System.Drawing.Size(221, 20);
            this.txt10Digit.TabIndex = 3;
            this.txt10Digit.TextChanged += new System.EventHandler(this.txt10Digit_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "XXX-XXX-XXXX";
            // 
            // txtEither
            // 
            this.txtEither.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEither.BackColor = System.Drawing.Color.Yellow;
            this.txtEither.Location = new System.Drawing.Point(127, 61);
            this.txtEither.Name = "txtEither";
            this.txtEither.Size = new System.Drawing.Size(221, 20);
            this.txtEither.TabIndex = 5;
            this.txtEither.TextChanged += new System.EventHandler(this.txtEither_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Either";
            // 
            // howto_string_match_regex_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 96);
            this.Controls.Add(this.txtEither);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt10Digit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt7Digit);
            this.Controls.Add(this.label1);
            this.Name = "howto_string_match_regex_Form1";
            this.Text = "howto_string_match_regex";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt7Digit;
        private System.Windows.Forms.TextBox txt10Digit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEither;
        private System.Windows.Forms.Label label3;
    }
}
