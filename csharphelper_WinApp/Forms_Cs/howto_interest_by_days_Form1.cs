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
     public partial class howto_interest_by_days_Form1:Form
  { 


        public howto_interest_by_days_Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Get inputs.
            DateTime start_date = DateTime.Parse(txtStartDate.Text);
            DateTime end_date = DateTime.Parse(txtEndDate.Text);

            string ann_interest_string = txtAnnualPercent.Text;
            if (ann_interest_string.Contains("%"))
                ann_interest_string = ann_interest_string.Replace("%", "");
            decimal annual_rate = decimal.Parse(ann_interest_string);
            if (annual_rate >= 0.5m)
                annual_rate /= 100m;

            decimal principle =
                decimal.Parse(txtPrinciple.Text, NumberStyles.Any);

            // Redisplay the inputs to make sure they're correct.
            txtStartDate.Text = start_date.ToShortDateString();
            txtEndDate.Text = end_date.ToShortDateString();
            txtAnnualPercent.Text = annual_rate.ToString("P");
            txtPrinciple.Text = principle.ToString("C");

            // Calculate the number of days in a "year."


            // Calculate simple interest.
            TimeSpan elapsed = end_date - start_date;
            int days = (int)elapsed.TotalDays;
            decimal daily_rate = annual_rate / 365m ;
            decimal simple_interest = days * daily_rate * principle;
            decimal simple_total = principle + simple_interest;

            // Calculate interest compounded daily.
            decimal daily_total = principle *
                (decimal)Math.Pow(1 + (double)daily_rate, days);
            decimal daily_interest = daily_total - principle;

            // Calculate interest compounded continuously.
            decimal continuous_total = principle *
                (decimal)Math.Pow(Math.E, (double)daily_rate * days);
            decimal continuous_interest = continuous_total - principle;

            // Display results.
            Console.WriteLine("# Days: " + days.ToString());
            txtSimple.Text = simple_interest.ToString("C");
            txtSimpleTotal.Text = simple_total.ToString("C");

            txtDaily.Text = daily_interest.ToString("C");
            txtDailyTotal.Text = daily_total.ToString("C");

            txtContinuously.Text = continuous_interest.ToString("C");
            txtContinuousTotal.Text = continuous_total.ToString("C");
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
            this.txtDaily = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSimple = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrinciple = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAnnualPercent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContinuously = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtContinuousTotal = new System.Windows.Forms.TextBox();
            this.txtDailyTotal = new System.Windows.Forms.TextBox();
            this.txtSimpleTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDaily
            // 
            this.txtDaily.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDaily.Location = new System.Drawing.Point(88, 172);
            this.txtDaily.Name = "txtDaily";
            this.txtDaily.ReadOnly = true;
            this.txtDaily.Size = new System.Drawing.Size(100, 20);
            this.txtDaily.TabIndex = 32;
            this.txtDaily.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Daily:";
            // 
            // txtSimple
            // 
            this.txtSimple.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSimple.Location = new System.Drawing.Point(88, 146);
            this.txtSimple.Name = "txtSimple";
            this.txtSimple.ReadOnly = true;
            this.txtSimple.Size = new System.Drawing.Size(100, 20);
            this.txtSimple.TabIndex = 31;
            this.txtSimple.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Simple:";
            // 
            // txtPrinciple
            // 
            this.txtPrinciple.Location = new System.Drawing.Point(76, 91);
            this.txtPrinciple.Name = "txtPrinciple";
            this.txtPrinciple.Size = new System.Drawing.Size(100, 20);
            this.txtPrinciple.TabIndex = 28;
            this.txtPrinciple.Text = "$5,000.00";
            this.txtPrinciple.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Principle:";
            // 
            // txtAnnualPercent
            // 
            this.txtAnnualPercent.Location = new System.Drawing.Point(76, 65);
            this.txtAnnualPercent.Name = "txtAnnualPercent";
            this.txtAnnualPercent.Size = new System.Drawing.Size(100, 20);
            this.txtAnnualPercent.TabIndex = 27;
            this.txtAnnualPercent.Text = "30";
            this.txtAnnualPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Ann %:";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalculate.Location = new System.Drawing.Point(220, 51);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 29;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // txtEndDate
            // 
            this.txtEndDate.Location = new System.Drawing.Point(76, 39);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(100, 20);
            this.txtEndDate.TabIndex = 26;
            this.txtEndDate.Text = "8/2/17";
            this.txtEndDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "End Date:";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Location = new System.Drawing.Point(76, 13);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(100, 20);
            this.txtStartDate.TabIndex = 25;
            this.txtStartDate.Text = "5/12/17";
            this.txtStartDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Start Date:";
            // 
            // txtContinuously
            // 
            this.txtContinuously.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtContinuously.Location = new System.Drawing.Point(88, 198);
            this.txtContinuously.Name = "txtContinuously";
            this.txtContinuously.ReadOnly = true;
            this.txtContinuously.Size = new System.Drawing.Size(100, 20);
            this.txtContinuously.TabIndex = 40;
            this.txtContinuously.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = "Continuously:";
            // 
            // txtContinuousTotal
            // 
            this.txtContinuousTotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtContinuousTotal.Location = new System.Drawing.Point(194, 198);
            this.txtContinuousTotal.Name = "txtContinuousTotal";
            this.txtContinuousTotal.ReadOnly = true;
            this.txtContinuousTotal.Size = new System.Drawing.Size(100, 20);
            this.txtContinuousTotal.TabIndex = 44;
            this.txtContinuousTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDailyTotal
            // 
            this.txtDailyTotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDailyTotal.Location = new System.Drawing.Point(194, 172);
            this.txtDailyTotal.Name = "txtDailyTotal";
            this.txtDailyTotal.ReadOnly = true;
            this.txtDailyTotal.Size = new System.Drawing.Size(100, 20);
            this.txtDailyTotal.TabIndex = 43;
            this.txtDailyTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSimpleTotal
            // 
            this.txtSimpleTotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSimpleTotal.Location = new System.Drawing.Point(194, 146);
            this.txtSimpleTotal.Name = "txtSimpleTotal";
            this.txtSimpleTotal.ReadOnly = true;
            this.txtSimpleTotal.Size = new System.Drawing.Size(100, 20);
            this.txtSimpleTotal.TabIndex = 42;
            this.txtSimpleTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.Location = new System.Drawing.Point(88, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 19);
            this.label5.TabIndex = 45;
            this.label5.Text = "Interest";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.Location = new System.Drawing.Point(194, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 19);
            this.label9.TabIndex = 46;
            this.label9.Text = "Total";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_interest_by_days_Form1
            // 
            this.AcceptButton = this.btnCalculate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 234);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtContinuousTotal);
            this.Controls.Add(this.txtDailyTotal);
            this.Controls.Add(this.txtSimpleTotal);
            this.Controls.Add(this.txtContinuously);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDaily);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSimple);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPrinciple);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAnnualPercent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.label1);
            this.Name = "howto_interest_by_days_Form1";
            this.Text = "howto_interest_by_days";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDaily;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSimple;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrinciple;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAnnualPercent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContinuously;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtContinuousTotal;
        private System.Windows.Forms.TextBox txtDailyTotal;
        private System.Windows.Forms.TextBox txtSimpleTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
    }
}

