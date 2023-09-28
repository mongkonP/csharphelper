using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;
using System.Globalization;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_textbox_proper_case_Form1:Form
  { 


        public howto_textbox_proper_case_Form1()
        {
            InitializeComponent();
        }

        private void howto_textbox_proper_case_Form1_Load(object sender, EventArgs e)
        {
            txtLowerCase.CharacterCasing = CharacterCasing.Lower;
            txtUpperCase.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtProperCase_TextChanged(object sender, EventArgs e)
        {
            TextBoxToProperCase(sender as TextBox);
        }

        // Convert the TextBox's text into proper case.
        private void TextBoxToProperCase(TextBox txt)
        {
            // Save the selection's start and length.
            int sel_start = txt.SelectionStart;
            int sel_length = txt.SelectionLength;

            CultureInfo culture_info = Thread.CurrentThread.CurrentCulture;
            TextInfo text_info = culture_info.TextInfo;
            txt.Text = text_info.ToTitleCase(txt.Text);

            // Restore the selection's start and length.
            txt.Select(sel_start, sel_length);
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
            this.txtProperCase = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUpperCase = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLowerCase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMixedCase = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtProperCase
            // 
            this.txtProperCase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProperCase.Location = new System.Drawing.Point(84, 90);
            this.txtProperCase.Name = "txtProperCase";
            this.txtProperCase.Size = new System.Drawing.Size(248, 20);
            this.txtProperCase.TabIndex = 15;
            this.txtProperCase.TextChanged += new System.EventHandler(this.txtProperCase_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Proper Case:";
            // 
            // txtUpperCase
            // 
            this.txtUpperCase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUpperCase.Location = new System.Drawing.Point(84, 64);
            this.txtUpperCase.Name = "txtUpperCase";
            this.txtUpperCase.Size = new System.Drawing.Size(248, 20);
            this.txtUpperCase.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Upper Case:";
            // 
            // txtLowerCase
            // 
            this.txtLowerCase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLowerCase.Location = new System.Drawing.Point(84, 38);
            this.txtLowerCase.Name = "txtLowerCase";
            this.txtLowerCase.Size = new System.Drawing.Size(248, 20);
            this.txtLowerCase.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Lower Case:";
            // 
            // txtMixedCase
            // 
            this.txtMixedCase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMixedCase.Location = new System.Drawing.Point(84, 12);
            this.txtMixedCase.Name = "txtMixedCase";
            this.txtMixedCase.Size = new System.Drawing.Size(248, 20);
            this.txtMixedCase.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "MIxed Case:";
            // 
            // howto_textbox_proper_case_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 121);
            this.Controls.Add(this.txtProperCase);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUpperCase);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLowerCase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMixedCase);
            this.Controls.Add(this.label1);
            this.Name = "howto_textbox_proper_case_Form1";
            this.Text = "howto_textbox_proper_case";
            this.Load += new System.EventHandler(this.howto_textbox_proper_case_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProperCase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUpperCase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLowerCase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMixedCase;
        private System.Windows.Forms.Label label1;
    }
}

