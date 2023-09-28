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
     public partial class howto_calculate_log_bases_Form1:Form
  { 


        public howto_calculate_log_bases_Form1()
        {
            InitializeComponent();
        }

        private void btnFindLog_Click(object sender, EventArgs e)
        {
            double number = double.Parse(txtNumber.Text);
            double log_base = double.Parse(txtBase.Text);
            double result = Math.Log(number) / Math.Log(log_base);
            txtResult.Text = result.ToString();
            txtVerify.Text = Math.Pow(log_base, result).ToString();
        }

        // Calculate log(number) in the indicated log base.
        private double LogBase(double number, double log_base)
        {
            return Math.Log(number) / Math.Log(log_base);
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
            this.txtVerify = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnFindLog = new System.Windows.Forms.Button();
            this.txtBase = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtVerify
            // 
            this.txtVerify.Location = new System.Drawing.Point(58, 121);
            this.txtVerify.Name = "txtVerify";
            this.txtVerify.ReadOnly = true;
            this.txtVerify.Size = new System.Drawing.Size(72, 20);
            this.txtVerify.TabIndex = 17;
            this.txtVerify.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(10, 121);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(36, 13);
            this.Label4.TabIndex = 16;
            this.Label4.Text = "Verify:";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(58, 89);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(72, 20);
            this.txtResult.TabIndex = 15;
            this.txtResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(10, 89);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(40, 13);
            this.Label3.TabIndex = 14;
            this.Label3.Text = "Result:";
            // 
            // btnFindLog
            // 
            this.btnFindLog.Location = new System.Drawing.Point(106, 49);
            this.btnFindLog.Name = "btnFindLog";
            this.btnFindLog.Size = new System.Drawing.Size(75, 23);
            this.btnFindLog.TabIndex = 13;
            this.btnFindLog.Text = "Find Log";
            this.btnFindLog.UseVisualStyleBackColor = true;
            this.btnFindLog.Click += new System.EventHandler(this.btnFindLog_Click);
            // 
            // txtBase
            // 
            this.txtBase.Location = new System.Drawing.Point(208, 13);
            this.txtBase.Name = "txtBase";
            this.txtBase.Size = new System.Drawing.Size(72, 20);
            this.txtBase.TabIndex = 12;
            this.txtBase.Text = "2";
            this.txtBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(168, 13);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(34, 13);
            this.Label2.TabIndex = 11;
            this.Label2.Text = "Base:";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(63, 12);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(72, 20);
            this.txtNumber.TabIndex = 10;
            this.txtNumber.Text = "1024";
            this.txtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(10, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(47, 13);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "Number:";
            // 
            // howto_calculate_log_bases_Form1
            // 
            this.AcceptButton = this.btnFindLog;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 151);
            this.Controls.Add(this.txtVerify);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.btnFindLog);
            this.Controls.Add(this.txtBase);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.Label1);
            this.Name = "howto_calculate_log_bases_Form1";
            this.Text = "howto_calculate_log_bases";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtVerify;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtResult;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button btnFindLog;
        internal System.Windows.Forms.TextBox txtBase;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtNumber;
        internal System.Windows.Forms.Label Label1;
    }
}

