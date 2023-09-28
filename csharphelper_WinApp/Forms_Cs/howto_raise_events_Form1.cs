using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Globalization;

 

using howto_raise_events;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_raise_events_Form1:Form
  { 


        public howto_raise_events_Form1()
        {
            InitializeComponent();
        }

        // The BankAccount object this program manages.
        private BankAccount TheBankAccount;

        // Initialize the BankAccount object.
        private void howto_raise_events_Form1_Load(object sender, EventArgs e)
        {
            TheBankAccount = new BankAccount();
            TheBankAccount.Balance = 100m;
            txtBalance.Text = TheBankAccount.Balance.ToString("C");

            // Subscribe to the Overdrawn event.
            TheBankAccount.Overdrawn += Account_Overdrawn;
        }

        // Add money to the account.
        private void btnCredit_Click(object sender, EventArgs e)
        {
            // Get the amount.
            decimal amount;
            if (!decimal.TryParse(txtAmount.Text, NumberStyles.Currency,
                CultureInfo.CurrentCulture, out amount))
            {
                MessageBox.Show("The amount must be a currency value.",
                    "Invalid Amount", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtAmount.Focus();
            }

            // Post the credit.
            try
            {
                TheBankAccount.Credit(amount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Display the new balance.
            txtBalance.Text = TheBankAccount.Balance.ToString("C");
        }

        // Remove money from the account.
        private void btnDebit_Click(object sender, EventArgs e)
        {
            // Get the amount.
            decimal amount;
            if (!decimal.TryParse(txtAmount.Text, NumberStyles.Currency,
                CultureInfo.CurrentCulture, out amount))
            {
                MessageBox.Show("The amount must be a currency value.",
                    "Invalid Amount", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtAmount.Focus();
            }

            // Post the debit.
            try
            {
                TheBankAccount.Debit(amount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Display the new balance.
            txtBalance.Text = TheBankAccount.Balance.ToString("C");
        }

        // Handle the account's Overdrawn event.
        private void Account_Overdrawn(object sender, OverdrawnArgs e)
        {
            // Get the account.
            BankAccount account = sender as BankAccount;

            // Ask the user whether to allow this.
            if (MessageBox.Show("Insufficient funds.\n\n    Current balance: " +
                account.Balance.ToString("C") + "\n    Debit amount: " +
                e.DebitAmount.ToString("C") + "\n\n" +
                "Do you want to allow this transaction anyway?",
                "Allow?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
            {
                // Allow the transaction anyway.
                e.Allow = true;
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
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDebit = new System.Windows.Forms.Button();
            this.btnCredit = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(67, 69);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(74, 20);
            this.txtBalance.TabIndex = 11;
            this.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Balance:";
            // 
            // btnDebit
            // 
            this.btnDebit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDebit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDebit.Location = new System.Drawing.Point(197, 41);
            this.btnDebit.Name = "btnDebit";
            this.btnDebit.Size = new System.Drawing.Size(75, 23);
            this.btnDebit.TabIndex = 9;
            this.btnDebit.Text = "Debit";
            this.btnDebit.UseVisualStyleBackColor = true;
            this.btnDebit.Click += new System.EventHandler(this.btnDebit_Click);
            // 
            // btnCredit
            // 
            this.btnCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCredit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCredit.Location = new System.Drawing.Point(197, 12);
            this.btnCredit.Name = "btnCredit";
            this.btnCredit.Size = new System.Drawing.Size(75, 23);
            this.btnCredit.TabIndex = 8;
            this.btnCredit.Text = "Credit";
            this.btnCredit.UseVisualStyleBackColor = true;
            this.btnCredit.Click += new System.EventHandler(this.btnCredit_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(67, 14);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(74, 20);
            this.txtAmount.TabIndex = 7;
            this.txtAmount.Text = "$100.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Amount:";
            // 
            // howto_raise_events_Form1
            // 
            this.AcceptButton = this.btnCredit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnDebit;
            this.ClientSize = new System.Drawing.Size(284, 101);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDebit);
            this.Controls.Add(this.btnCredit);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label1);
            this.Name = "howto_raise_events_Form1";
            this.Text = "howto_raise_events";
            this.Load += new System.EventHandler(this.howto_raise_events_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDebit;
        private System.Windows.Forms.Button btnCredit;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label1;
    }
}

