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
     public partial class howto_calculate_compound_interest_Form1:Form
  { 


        public howto_calculate_compound_interest_Form1()
        {
            InitializeComponent();
        }

        // Calculate and display interest for the following years.
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            lstResults.Items.Clear();

            double principle = double.Parse(txtPrinciple.Text);
            double interestRate = double.Parse(txtInterestRate.Text);
            int numYears = int.Parse(txtNumYears.Text);
            for (int i = 1; i <= numYears; i++)
            {
                double balance = principle * Math.Pow(1 + interestRate, i);
                lstResults.Items.Add("Year " + i.ToString() + "\t" +
                    balance.ToString("C"));
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrinciple = new System.Windows.Forms.TextBox();
            this.txtInterestRate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.txtNumYears = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Principle:";
            // 
            // txtPrinciple
            // 
            this.txtPrinciple.Location = new System.Drawing.Point(89, 12);
            this.txtPrinciple.Name = "txtPrinciple";
            this.txtPrinciple.Size = new System.Drawing.Size(81, 20);
            this.txtPrinciple.TabIndex = 0;
            this.txtPrinciple.Text = "10000.00";
            this.txtPrinciple.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtInterestRate
            // 
            this.txtInterestRate.Location = new System.Drawing.Point(89, 38);
            this.txtInterestRate.Name = "txtInterestRate";
            this.txtInterestRate.Size = new System.Drawing.Size(81, 20);
            this.txtInterestRate.TabIndex = 1;
            this.txtInterestRate.Text = "0.05";
            this.txtInterestRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Interest Rate:";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalculate.Location = new System.Drawing.Point(304, 26);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 3;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lstResults
            // 
            this.lstResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstResults.FormattingEnabled = true;
            this.lstResults.IntegralHeight = false;
            this.lstResults.Location = new System.Drawing.Point(15, 90);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(363, 173);
            this.lstResults.TabIndex = 4;
            // 
            // txtNumYears
            // 
            this.txtNumYears.Location = new System.Drawing.Point(89, 64);
            this.txtNumYears.Name = "txtNumYears";
            this.txtNumYears.Size = new System.Drawing.Size(81, 20);
            this.txtNumYears.TabIndex = 2;
            this.txtNumYears.Text = "10";
            this.txtNumYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "# Years:";
            // 
            // howto_calculate_compound_interest_Form1
            // 
            this.AcceptButton = this.btnCalculate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 275);
            this.Controls.Add(this.txtNumYears);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtInterestRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPrinciple);
            this.Controls.Add(this.label1);
            this.Name = "howto_calculate_compound_interest_Form1";
            this.Text = "howto_calculate_compound_interest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPrinciple;
        private System.Windows.Forms.TextBox txtInterestRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.TextBox txtNumYears;
        private System.Windows.Forms.Label label3;
    }
}

