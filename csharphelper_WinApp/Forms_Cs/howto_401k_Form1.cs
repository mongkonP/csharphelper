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
     public partial class howto_401k_Form1:Form
  { 


        public howto_401k_Form1()
        {
            InitializeComponent();
        }

        // Compare regular and 401k account balances.
        private void btnGo_Click(object sender, EventArgs e)
        {
            decimal annual_contribution =
                decimal.Parse(txtAnnualContribution.Text, NumberStyles.Any);

            decimal tax_rate =
                decimal.Parse(txtTaxRate.Text.Replace("%", ""),
                    NumberStyles.Any) / 100;
            if (tax_rate >= 1) tax_rate /= 100;

            decimal interest_rate =
                decimal.Parse(txtInterestRate.Text.Replace("%", ""),
                    NumberStyles.Any) / 100;
            if (interest_rate >= 1) interest_rate /= 100;

            int num_years = int.Parse(txtYears.Text);

            decimal balance_bank = 0;
            decimal balance_401k = 0;
            lvwResults.Items.Clear();
            for (int year = 0; year < num_years; year++)
            {
                ListViewItem lv_item = new ListViewItem(year.ToString());
                lvwResults.Items.Add(lv_item);
                lv_item.SubItems.Add(balance_bank.ToString("C"));
                lv_item.SubItems.Add(balance_401k.ToString("C"));

                // Bank balance += interest + contribution, minus taxes.
                balance_bank = balance_bank +
                    (1 - tax_rate) * (balance_bank * interest_rate + annual_contribution);

                // 401(k) balance += interest + contribution.
                balance_401k = balance_401k +
                    (balance_401k * interest_rate + annual_contribution);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_401k_Form1));
            this.lvwResults = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.txtYears = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtInterestRate = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtTaxRate = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtAnnualContribution = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwResults
            // 
            this.lvwResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.ColumnHeader3});
            this.lvwResults.Location = new System.Drawing.Point(10, 239);
            this.lvwResults.Name = "lvwResults";
            this.lvwResults.Size = new System.Drawing.Size(392, 128);
            this.lvwResults.TabIndex = 32;
            this.lvwResults.UseCompatibleStateImageBehavior = false;
            this.lvwResults.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Year";
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Bank";
            this.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader2.Width = 120;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "401(k)";
            this.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader3.Width = 120;
            // 
            // txtYears
            // 
            this.txtYears.Location = new System.Drawing.Point(127, 213);
            this.txtYears.Name = "txtYears";
            this.txtYears.Size = new System.Drawing.Size(96, 20);
            this.txtYears.TabIndex = 31;
            this.txtYears.Text = "35";
            this.txtYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(7, 213);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(104, 16);
            this.Label5.TabIndex = 30;
            this.Label5.Text = "Years:";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(263, 173);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 29;
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtInterestRate
            // 
            this.txtInterestRate.Location = new System.Drawing.Point(127, 189);
            this.txtInterestRate.Name = "txtInterestRate";
            this.txtInterestRate.Size = new System.Drawing.Size(96, 20);
            this.txtInterestRate.TabIndex = 28;
            this.txtInterestRate.Text = "9%";
            this.txtInterestRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label4
            // 
            this.Label4.Location = new System.Drawing.Point(7, 189);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(104, 16);
            this.Label4.TabIndex = 27;
            this.Label4.Text = "Annual interest rate:";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.ForeColor = System.Drawing.Color.Red;
            this.GroupBox1.Location = new System.Drawing.Point(10, 7);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(392, 128);
            this.GroupBox1.TabIndex = 26;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "WARNING";
            // 
            // Label3
            // 
            this.Label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(8, 16);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(376, 104);
            this.Label3.TabIndex = 0;
            this.Label3.Text = resources.GetString("Label3.Text");
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTaxRate
            // 
            this.txtTaxRate.Location = new System.Drawing.Point(127, 165);
            this.txtTaxRate.Name = "txtTaxRate";
            this.txtTaxRate.Size = new System.Drawing.Size(96, 20);
            this.txtTaxRate.TabIndex = 25;
            this.txtTaxRate.Text = "20%";
            this.txtTaxRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(7, 165);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(104, 16);
            this.Label2.TabIndex = 24;
            this.Label2.Text = "Income tax rate:";
            // 
            // txtAnnualContribution
            // 
            this.txtAnnualContribution.Location = new System.Drawing.Point(127, 141);
            this.txtAnnualContribution.Name = "txtAnnualContribution";
            this.txtAnnualContribution.Size = new System.Drawing.Size(96, 20);
            this.txtAnnualContribution.TabIndex = 23;
            this.txtAnnualContribution.Text = "$4,000.00";
            this.txtAnnualContribution.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(7, 141);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(104, 16);
            this.Label1.TabIndex = 22;
            this.Label1.Text = "Annual contribution:";
            // 
            // howto_401k_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 374);
            this.Controls.Add(this.lvwResults);
            this.Controls.Add(this.txtYears);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtInterestRate);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.txtTaxRate);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtAnnualContribution);
            this.Controls.Add(this.Label1);
            this.Name = "howto_401k_Form1";
            this.Text = "howto_401k";
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ListView lvwResults;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader2;
        internal System.Windows.Forms.ColumnHeader ColumnHeader3;
        internal System.Windows.Forms.TextBox txtYears;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Button btnGo;
        internal System.Windows.Forms.TextBox txtInterestRate;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtTaxRate;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtAnnualContribution;
        internal System.Windows.Forms.Label Label1;
    }
}

