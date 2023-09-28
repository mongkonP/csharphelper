using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Globalization;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_calculate_present_value_Form1:Form
  { 


        public howto_calculate_present_value_Form1()
        {
            InitializeComponent();
        }

        // Calculate the present value.
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            txtPresentValue.Clear();

            // Get the inputs.
            decimal interest_rate =
                decimal.Parse(txtInterestRate.Text.Replace("%", ""));
            if (txtInterestRate.Text.Contains("%"))
                interest_rate /= 100;

            decimal future_value =
                decimal.Parse(txtAmount.Text, NumberStyles.Any);

            decimal years = decimal.Parse(txtYears.Text);

            // Calculate and display the result.
            decimal current_value =
                (decimal)future_value /
                (decimal)Math.Pow((double)(1 + interest_rate), (double)years);
            txtPresentValue.Text = current_value.ToString("C");
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
            this.txtPresentValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtYears = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInterestRate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPresentValue
            // 
            this.txtPresentValue.Location = new System.Drawing.Point(94, 100);
            this.txtPresentValue.Name = "txtPresentValue";
            this.txtPresentValue.ReadOnly = true;
            this.txtPresentValue.Size = new System.Drawing.Size(77, 20);
            this.txtPresentValue.TabIndex = 14;
            this.txtPresentValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Present Value:";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalculate.Location = new System.Drawing.Point(247, 12);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 13;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(94, 11);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(77, 20);
            this.txtAmount.TabIndex = 8;
            this.txtAmount.Text = "$100,000.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Amount:";
            // 
            // txtYears
            // 
            this.txtYears.Location = new System.Drawing.Point(94, 63);
            this.txtYears.Name = "txtYears";
            this.txtYears.Size = new System.Drawing.Size(77, 20);
            this.txtYears.TabIndex = 11;
            this.txtYears.Text = "20";
            this.txtYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Years:";
            // 
            // txtInterestRate
            // 
            this.txtInterestRate.Location = new System.Drawing.Point(94, 37);
            this.txtInterestRate.Name = "txtInterestRate";
            this.txtInterestRate.Size = new System.Drawing.Size(77, 20);
            this.txtInterestRate.TabIndex = 10;
            this.txtInterestRate.Text = "10%";
            this.txtInterestRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Interest Rate:";
            // 
            // howto_calculate_present_value_Form1
            // 
            this.AcceptButton = this.btnCalculate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 131);
            this.Controls.Add(this.txtPresentValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtYears);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInterestRate);
            this.Controls.Add(this.label1);
            this.Name = "howto_calculate_present_value_Form1";
            this.Text = "howto_calculate_present_value";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPresentValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtYears;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInterestRate;
        private System.Windows.Forms.Label label1;
    }
}

