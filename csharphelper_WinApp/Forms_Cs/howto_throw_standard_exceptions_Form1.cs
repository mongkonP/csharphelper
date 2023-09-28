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
     public partial class howto_throw_standard_exceptions_Form1:Form
  { 


        public howto_throw_standard_exceptions_Form1()
        {
            InitializeComponent();
        }

        // Calculate the tip.
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                PerformCalculation();
            }
            catch (Exception ex)
            {
                txtTipAmount.Clear();
                MessageBox.Show(ex.Message);
            }
        }

        private void PerformCalculation()
        {
            // Parse the cost.
            decimal cost;
            if (!decimal.TryParse(txtCost.Text,
                NumberStyles.Currency, null, out cost))
                throw new FormatException("Cost must be a monetary amount.");
            // Validate the cost.
            if ((cost < 0.01m) || (cost > 500m))
                throw new ArgumentOutOfRangeException(
                    "Cost must be between $0.01 and $500.00.");

            // Parse the tip percentage.
            string percent_string = txtPercentTip.Text;
            if (percent_string.StartsWith("%"))
                percent_string = percent_string.Substring(1);
            else if (percent_string.EndsWith("%"))
                percent_string = percent_string.Substring(0, percent_string.Length - 1);
            decimal tip_percent;
            if (!decimal.TryParse(percent_string, out tip_percent))
                throw new FormatException("% Tip must be a numeric value.");
            // If the original value contained a % symbol, divide by 100.
            if (txtPercentTip.Text.Contains("%")) tip_percent /= 100m;
            // Validate the percentage.
            if ((tip_percent < 0) || (tip_percent > 100))
                throw new ArgumentOutOfRangeException(
                    "% Tip must be between 0% and 100%.");

            // Everything's valid. Perform the calculation.
            decimal tip_amount = cost * tip_percent;
            txtTipAmount.Text = tip_amount.ToString("C");
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
            this.txtTipAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.txtPercentTip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTipAmount
            // 
            this.txtTipAmount.Location = new System.Drawing.Point(61, 78);
            this.txtTipAmount.Name = "txtTipAmount";
            this.txtTipAmount.ReadOnly = true;
            this.txtTipAmount.Size = new System.Drawing.Size(61, 20);
            this.txtTipAmount.TabIndex = 13;
            this.txtTipAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "$ Tip:";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalculate.Location = new System.Drawing.Point(277, 44);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 11;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // txtPercentTip
            // 
            this.txtPercentTip.Location = new System.Drawing.Point(61, 38);
            this.txtPercentTip.Name = "txtPercentTip";
            this.txtPercentTip.Size = new System.Drawing.Size(61, 20);
            this.txtPercentTip.TabIndex = 10;
            this.txtPercentTip.Text = "15%";
            this.txtPercentTip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "% Tip:";
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(61, 12);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(61, 20);
            this.txtCost.TabIndex = 8;
            this.txtCost.Text = "$20.00";
            this.txtCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Cost:";
            // 
            // howto_throw_standard_exceptions_Form1
            // 
            this.AcceptButton = this.btnCalculate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 111);
            this.Controls.Add(this.txtTipAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtPercentTip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.label1);
            this.Name = "howto_throw_standard_exceptions_Form1";
            this.Text = "howto_throw_standard_exceptions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTipAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.TextBox txtPercentTip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.Label label1;
    }
}

