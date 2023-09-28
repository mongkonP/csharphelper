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
     public partial class howto_monthly_investment_Form1:Form
  { 


        public howto_monthly_investment_Form1()
        {
            InitializeComponent();
        }

        // Calculate the interest compounded monthly.
        private void btnGo_Click(object sender, EventArgs e)
        {
            // Get the parameters.
            decimal monthly_contribution = decimal.Parse(
                txtMonthlyContribution.Text, NumberStyles.Any);
            int num_months = int.Parse(txtNumMonths.Text);
            decimal interest_rate = decimal.Parse(
                txtInterestRate.Text.Replace("%", "")) / 100;
            interest_rate /= 12;

            // Calculate.
            lvwBalance.Items.Clear();
            decimal balance = 0;
            decimal total_interest = 0;
            decimal total_principle = 0;
            for (int i = 1; i <= num_months; i++)
            {
                // Display the month.
                ListViewItem new_item = lvwBalance.Items.Add(i.ToString());

                // Display the interest.
                decimal interest = balance * interest_rate;
                new_item.SubItems.Add(interest.ToString("c"));
                total_interest += interest;
                new_item.SubItems.Add(total_interest.ToString("c"));

                // Add the contribution.
                balance += monthly_contribution;
                total_principle += monthly_contribution;
                new_item.SubItems.Add(total_principle.ToString("c"));

                // Display the balance.
                balance += interest;
                new_item.SubItems.Add(balance.ToString("c"));
            }

            // Scroll to the last entry.
            lvwBalance.Items[lvwBalance.Items.Count - 1].EnsureVisible();
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
            this.colInterest = new System.Windows.Forms.ColumnHeader();
            this.colMonth = new System.Windows.Forms.ColumnHeader();
            this.lvwBalance = new System.Windows.Forms.ListView();
            this.colTotalInterest = new System.Windows.Forms.ColumnHeader();
            this.colTotalPrinciple = new System.Windows.Forms.ColumnHeader();
            this.colBalance = new System.Windows.Forms.ColumnHeader();
            this.txtInterestRate = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumMonths = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMonthlyContribution = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // colInterest
            // 
            this.colInterest.Text = "Interest";
            this.colInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colInterest.Width = 80;
            // 
            // colMonth
            // 
            this.colMonth.Text = "Month";
            // 
            // lvwBalance
            // 
            this.lvwBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwBalance.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMonth,
            this.colInterest,
            this.colTotalInterest,
            this.colTotalPrinciple,
            this.colBalance});
            this.lvwBalance.Location = new System.Drawing.Point(12, 90);
            this.lvwBalance.Name = "lvwBalance";
            this.lvwBalance.Size = new System.Drawing.Size(411, 159);
            this.lvwBalance.TabIndex = 15;
            this.lvwBalance.UseCompatibleStateImageBehavior = false;
            this.lvwBalance.View = System.Windows.Forms.View.Details;
            // 
            // colTotalInterest
            // 
            this.colTotalInterest.Text = "Total Interest";
            this.colTotalInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colTotalInterest.Width = 80;
            // 
            // colTotalPrinciple
            // 
            this.colTotalPrinciple.Text = "Total Principle";
            this.colTotalPrinciple.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colTotalPrinciple.Width = 80;
            // 
            // colBalance
            // 
            this.colBalance.Text = "Balance";
            this.colBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colBalance.Width = 80;
            // 
            // txtInterestRate
            // 
            this.txtInterestRate.Location = new System.Drawing.Point(125, 64);
            this.txtInterestRate.Name = "txtInterestRate";
            this.txtInterestRate.Size = new System.Drawing.Size(78, 20);
            this.txtInterestRate.TabIndex = 13;
            this.txtInterestRate.Text = "7.00%";
            this.txtInterestRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(226, 36);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 14;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Annual Interest Rate:";
            // 
            // txtNumMonths
            // 
            this.txtNumMonths.Location = new System.Drawing.Point(125, 38);
            this.txtNumMonths.Name = "txtNumMonths";
            this.txtNumMonths.Size = new System.Drawing.Size(78, 20);
            this.txtNumMonths.TabIndex = 11;
            this.txtNumMonths.Text = "120";
            this.txtNumMonths.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "# Months:";
            // 
            // txtMonthlyContribution
            // 
            this.txtMonthlyContribution.Location = new System.Drawing.Point(125, 12);
            this.txtMonthlyContribution.Name = "txtMonthlyContribution";
            this.txtMonthlyContribution.Size = new System.Drawing.Size(78, 20);
            this.txtMonthlyContribution.TabIndex = 9;
            this.txtMonthlyContribution.Text = "$100.00";
            this.txtMonthlyContribution.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Monthly Contribution:";
            // 
            // howto_monthly_investment_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 261);
            this.Controls.Add(this.lvwBalance);
            this.Controls.Add(this.txtInterestRate);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNumMonths);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMonthlyContribution);
            this.Controls.Add(this.label1);
            this.Name = "howto_monthly_investment_Form1";
            this.Text = "howto_monthly_investment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader colInterest;
        private System.Windows.Forms.ColumnHeader colMonth;
        private System.Windows.Forms.ListView lvwBalance;
        private System.Windows.Forms.ColumnHeader colBalance;
        private System.Windows.Forms.TextBox txtInterestRate;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumMonths;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMonthlyContribution;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader colTotalInterest;
        private System.Windows.Forms.ColumnHeader colTotalPrinciple;
    }
}

