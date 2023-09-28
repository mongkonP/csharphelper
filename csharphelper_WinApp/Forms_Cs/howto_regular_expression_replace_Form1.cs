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
     public partial class howto_regular_expression_replace_Form1:Form
  { 


        public howto_regular_expression_replace_Form1()
        {
            InitializeComponent();
        }

        // Make the replacements.
        private void btnGo_Click(object sender, EventArgs e)
        {
            Regex reg_exp = new Regex(txtPattern.Text);
            lblResult.Text = reg_exp.Replace(txtTestString.Text, txtReplacementPattern.Text);
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
            this.txtTestString = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtReplacementPattern = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtPattern = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTestString
            // 
            this.txtTestString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTestString.Location = new System.Drawing.Point(6, 110);
            this.txtTestString.Name = "txtTestString";
            this.txtTestString.Size = new System.Drawing.Size(368, 20);
            this.txtTestString.TabIndex = 29;
            this.txtTestString.Text = "The QUICK BROWN fox jumps over the LAZY dog.";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(6, 94);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(58, 13);
            this.Label4.TabIndex = 35;
            this.Label4.Text = "Test String";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGo.Location = new System.Drawing.Point(153, 134);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 31;
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblResult
            // 
            this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblResult.Location = new System.Drawing.Point(6, 190);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(368, 16);
            this.lblResult.TabIndex = 34;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(6, 174);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(37, 13);
            this.Label3.TabIndex = 33;
            this.Label3.Text = "Result";
            // 
            // txtReplacementPattern
            // 
            this.txtReplacementPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReplacementPattern.Location = new System.Drawing.Point(6, 70);
            this.txtReplacementPattern.Name = "txtReplacementPattern";
            this.txtReplacementPattern.Size = new System.Drawing.Size(368, 20);
            this.txtReplacementPattern.TabIndex = 27;
            this.txtReplacementPattern.Text = ".";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(6, 54);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(107, 13);
            this.Label2.TabIndex = 30;
            this.Label2.Text = "Replacement Pattern";
            // 
            // txtPattern
            // 
            this.txtPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPattern.Location = new System.Drawing.Point(6, 22);
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.Size = new System.Drawing.Size(368, 20);
            this.txtPattern.TabIndex = 32;
            this.txtPattern.Text = "[aeiouAEIOU]";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(6, 6);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(41, 13);
            this.Label1.TabIndex = 28;
            this.Label1.Text = "Pattern";
            // 
            // howto_regular_expression_replace_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 213);
            this.Controls.Add(this.txtTestString);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtReplacementPattern);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtPattern);
            this.Controls.Add(this.Label1);
            this.Name = "howto_regular_expression_replace_Form1";
            this.Text = "howto_regular_expression_replace";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtTestString;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Button btnGo;
        internal System.Windows.Forms.Label lblResult;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtReplacementPattern;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtPattern;
        internal System.Windows.Forms.Label Label1;
    }
}

