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
     public partial class howto_credit_card_calculator_Form1:Form
  { 


        public howto_credit_card_calculator_Form1()
        {
            InitializeComponent();
        }

        // Calculate the payments.
        private void btnGo_Click(object sender, EventArgs e)
        {
            // Get the parameters.
            decimal balance = decimal.Parse(txtInitialBalance.Text, NumberStyles.Any);
            decimal interest_rate = decimal.Parse(txtInterestRate.Text.Replace("%", "")) / 100;
            decimal payment_percent = decimal.Parse(txtPaymentPercent.Text.Replace("%", "")) / 100;
            decimal min_payment = decimal.Parse(txtMinPayment.Text, NumberStyles.Any);
            interest_rate /= 12;

            txtTotalPayments.Clear();
            decimal total_payments = 0;

            // Display the initial balance.
            lvwPayments.Items.Clear();
            ListViewItem new_item = lvwPayments.Items.Add("0");
            new_item.SubItems.Add("");
            new_item.SubItems.Add("");
            new_item.SubItems.Add(balance.ToString("c"));

            // Loop until balance == 0.
            for (int i = 1; balance > 0; i++)
            {
                // Calculate the payment.
                decimal payment = balance * payment_percent;
                if (payment < min_payment) payment = min_payment;

                // Calculate interest.
                decimal interest = balance * interest_rate;
                balance += interest;

                // See if we can pay off the balance.
                if (payment > balance) payment = balance;
                total_payments += payment;
                balance -= payment;

                // Display results.
                new_item = lvwPayments.Items.Add(i.ToString());
                new_item.SubItems.Add(payment.ToString("c"));
                new_item.SubItems.Add(interest.ToString("c"));
                new_item.SubItems.Add(balance.ToString("c"));
            }

            // Display the total payments.
            txtTotalPayments.Text = total_payments.ToString("c");
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
            this.label5 = new System.Windows.Forms.Label();
            this.colMonth = new System.Windows.Forms.ColumnHeader();
            this.colPayment = new System.Windows.Forms.ColumnHeader();
            this.colInterest = new System.Windows.Forms.ColumnHeader();
            this.colBalance = new System.Windows.Forms.ColumnHeader();
            this.txtTotalPayments = new System.Windows.Forms.TextBox();
            this.lvwPayments = new System.Windows.Forms.ListView();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtMinPayment = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPaymentPercent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInterestRate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInitialBalance = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(243, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Total Payments:";
            // 
            // colMonth
            // 
            this.colMonth.Text = "";
            this.colMonth.Width = 30;
            // 
            // colPayment
            // 
            this.colPayment.Text = "Payment";
            this.colPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colPayment.Width = 80;
            // 
            // colInterest
            // 
            this.colInterest.Text = "Interest";
            this.colInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colInterest.Width = 80;
            // 
            // colBalance
            // 
            this.colBalance.Text = "Balance";
            this.colBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colBalance.Width = 80;
            // 
            // txtTotalPayments
            // 
            this.txtTotalPayments.Location = new System.Drawing.Point(332, 230);
            this.txtTotalPayments.Name = "txtTotalPayments";
            this.txtTotalPayments.ReadOnly = true;
            this.txtTotalPayments.Size = new System.Drawing.Size(73, 20);
            this.txtTotalPayments.TabIndex = 23;
            this.txtTotalPayments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lvwPayments
            // 
            this.lvwPayments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwPayments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMonth,
            this.colPayment,
            this.colInterest,
            this.colBalance});
            this.lvwPayments.Location = new System.Drawing.Point(186, 15);
            this.lvwPayments.Name = "lvwPayments";
            this.lvwPayments.Size = new System.Drawing.Size(302, 209);
            this.lvwPayments.TabIndex = 21;
            this.lvwPayments.UseCompatibleStateImageBehavior = false;
            this.lvwPayments.View = System.Windows.Forms.View.Details;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(57, 119);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 20;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtMinPayment
            // 
            this.txtMinPayment.Location = new System.Drawing.Point(94, 93);
            this.txtMinPayment.Name = "txtMinPayment";
            this.txtMinPayment.Size = new System.Drawing.Size(73, 20);
            this.txtMinPayment.TabIndex = 19;
            this.txtMinPayment.Text = "$15.00";
            this.txtMinPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Min Payment:";
            // 
            // txtPaymentPercent
            // 
            this.txtPaymentPercent.Location = new System.Drawing.Point(94, 67);
            this.txtPaymentPercent.Name = "txtPaymentPercent";
            this.txtPaymentPercent.Size = new System.Drawing.Size(73, 20);
            this.txtPaymentPercent.TabIndex = 17;
            this.txtPaymentPercent.Text = "4.00%";
            this.txtPaymentPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Payment %:";
            // 
            // txtInterestRate
            // 
            this.txtInterestRate.Location = new System.Drawing.Point(94, 41);
            this.txtInterestRate.Name = "txtInterestRate";
            this.txtInterestRate.Size = new System.Drawing.Size(73, 20);
            this.txtInterestRate.TabIndex = 15;
            this.txtInterestRate.Text = "18.90%";
            this.txtInterestRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Interest Rate:";
            // 
            // txtInitialBalance
            // 
            this.txtInitialBalance.Location = new System.Drawing.Point(94, 15);
            this.txtInitialBalance.Name = "txtInitialBalance";
            this.txtInitialBalance.Size = new System.Drawing.Size(73, 20);
            this.txtInitialBalance.TabIndex = 13;
            this.txtInitialBalance.Text = "$5,000.00";
            this.txtInitialBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Initial Balance:";
            // 
            // howto_credit_card_calculator_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 264);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTotalPayments);
            this.Controls.Add(this.lvwPayments);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtMinPayment);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPaymentPercent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInterestRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInitialBalance);
            this.Controls.Add(this.label1);
            this.Name = "howto_credit_card_calculator_Form1";
            this.Text = "howto_credit_card_calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader colMonth;
        private System.Windows.Forms.ColumnHeader colPayment;
        private System.Windows.Forms.ColumnHeader colInterest;
        private System.Windows.Forms.ColumnHeader colBalance;
        private System.Windows.Forms.TextBox txtTotalPayments;
        private System.Windows.Forms.ListView lvwPayments;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtMinPayment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPaymentPercent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInterestRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInitialBalance;
        private System.Windows.Forms.Label label1;
    }
}

