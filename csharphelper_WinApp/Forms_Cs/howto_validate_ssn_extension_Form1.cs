using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_validate_ssn_extension;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_validate_ssn_extension_Form1:Form
  { 


        public howto_validate_ssn_extension_Form1()
        {
            InitializeComponent();
        }

        // If the SSN is invalid, display a yellow background.
        private void txtWithDashes_TextChanged(object sender, EventArgs e)
        {
            if (txtWithDashes.Text.IsValidSsnWithDashes())
                txtWithDashes.BackColor = SystemColors.Window;
            else
                txtWithDashes.BackColor = Color.Yellow;
        }

        private void txtWithoutDashes_TextChanged(object sender, EventArgs e)
        {
            if (txtWithoutDashes.Text.IsValidSsnWithoutDashes())
                txtWithoutDashes.BackColor = SystemColors.Window;
            else
                txtWithoutDashes.BackColor = Color.Yellow;
        }

        private void txtEither_TextChanged(object sender, EventArgs e)
        {
            if (txtEither.Text.IsValidSsn())
                txtEither.BackColor = SystemColors.Window;
            else
                txtEither.BackColor = Color.Yellow;
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtEither = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWithoutDashes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWithDashes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Either:";
            // 
            // txtEither
            // 
            this.txtEither.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEither.Location = new System.Drawing.Point(173, 71);
            this.txtEither.Name = "txtEither";
            this.txtEither.Size = new System.Drawing.Size(81, 20);
            this.txtEither.TabIndex = 10;
            this.txtEither.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEither.TextChanged += new System.EventHandler(this.txtEither_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Without Dashes:";
            // 
            // txtWithoutDashes
            // 
            this.txtWithoutDashes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtWithoutDashes.Location = new System.Drawing.Point(173, 45);
            this.txtWithoutDashes.Name = "txtWithoutDashes";
            this.txtWithoutDashes.Size = new System.Drawing.Size(81, 20);
            this.txtWithoutDashes.TabIndex = 8;
            this.txtWithoutDashes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtWithoutDashes.TextChanged += new System.EventHandler(this.txtWithoutDashes_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "With Dashes:";
            // 
            // txtWithDashes
            // 
            this.txtWithDashes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtWithDashes.Location = new System.Drawing.Point(173, 19);
            this.txtWithDashes.Name = "txtWithDashes";
            this.txtWithDashes.Size = new System.Drawing.Size(81, 20);
            this.txtWithDashes.TabIndex = 6;
            this.txtWithDashes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtWithDashes.TextChanged += new System.EventHandler(this.txtWithDashes_TextChanged);
            // 
            // howto_validate_ssn_extension_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 111);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEither);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtWithoutDashes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtWithDashes);
            this.Name = "howto_validate_ssn_extension_Form1";
            this.Text = "howto_validate_ssn_extension";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEither;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWithoutDashes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWithDashes;
    }
}

