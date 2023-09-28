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
     public partial class howto_regular_expression_replace_lines_Form1:Form
  { 


        public howto_regular_expression_replace_lines_Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                Regex reg_exp = new Regex(txtPattern.Text);
                lblResult.Text = reg_exp.Replace(txtInput.Text, txtReplacementPattern.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            this.lblResult = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtReplacementPattern = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtPattern = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblResult.Location = new System.Drawing.Point(6, 246);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(376, 80);
            this.lblResult.TabIndex = 18;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(6, 230);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(37, 13);
            this.Label4.TabIndex = 17;
            this.Label4.Text = "Result";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(6, 94);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(28, 13);
            this.Label3.TabIndex = 16;
            this.Label3.Text = "Text";
            // 
            // txtInput
            // 
            this.txtInput.AcceptsReturn = true;
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Location = new System.Drawing.Point(6, 110);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(380, 80);
            this.txtInput.TabIndex = 15;
            this.txtInput.Text = "Archer, Ann\r\nBaker, Bob\r\nCarter, Cindy\r\nDeevers, Dan";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGo.Location = new System.Drawing.Point(159, 198);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 14;
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(6, 46);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(107, 13);
            this.Label2.TabIndex = 13;
            this.Label2.Text = "Replacement Pattern";
            // 
            // txtReplacementPattern
            // 
            this.txtReplacementPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReplacementPattern.Location = new System.Drawing.Point(6, 62);
            this.txtReplacementPattern.Name = "txtReplacementPattern";
            this.txtReplacementPattern.Size = new System.Drawing.Size(380, 20);
            this.txtReplacementPattern.TabIndex = 12;
            this.txtReplacementPattern.Text = "$2 $1";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(6, 6);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(41, 13);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "Pattern";
            // 
            // txtPattern
            // 
            this.txtPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPattern.Location = new System.Drawing.Point(6, 22);
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.Size = new System.Drawing.Size(380, 20);
            this.txtPattern.TabIndex = 10;
            this.txtPattern.Text = "(?m)^([^,]*), ([^\\r]*)\\r?$";
            // 
            // howto_regular_expression_replace_lines_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 333);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtReplacementPattern);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtPattern);
            this.Name = "howto_regular_expression_replace_lines_Form1";
            this.Text = "howto_regular_expression_replace_lines";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblResult;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtInput;
        internal System.Windows.Forms.Button btnGo;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtReplacementPattern;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtPattern;
    }
}

