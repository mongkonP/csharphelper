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
     public partial class howto_check_primality_Form1:Form
  { 


        public howto_check_primality_Form1()
        {
            InitializeComponent();
        }

        // Perform the tests to see if the number is prime.
        private void btnTest_Click(object sender, EventArgs e)
        {
            txtIsPrime.Clear();
            txtFactors.Clear();
            Cursor = Cursors.WaitCursor;
            Refresh();

            // Get the possible prime p.
            int p;
            if (!int.TryParse(txtNumber.Text, out p)) p = -1;
            if ((p < 3) || (p > 100000000))
            {
                MessageBox.Show("Number must be between 3 and 100,000,000");
                txtNumber.Focus();
                return;
            }

            // Perform the tests.
            int num_tests = (int)nudNumTests.Value;
            if (IsProbablyPrime(p, num_tests))
            {
                // It is probably prime.
                double prob = Math.Pow(2, -num_tests);
                txtIsPrime.Text = "Probably prime";
                txtFactors.Text = "Prob. composite: " + prob.ToString("R");
            }
            else
            {
                // It is not prime.
                // Display the factors.
                List<long> factors = FindFactors(p);
                List<string> strings = factors.ConvertAll<string>(x => x.ToString());
                txtFactors.Text = string.Join(" x ", strings.ToArray()); 
            }
            Cursor = Cursors.Default;
        }

        // Perform tests to see if a number is (probably) prime.
        private Random Rand = new Random();
        private bool IsProbablyPrime(int p, int num_tests)
        {
            checked
            {
                // Perform the tests.
                for (int i = 0; i < num_tests; i++)
                {
                    // Pick a number n in the range (1, p).
                    long n = Rand.Next(2, p);

                    // Calculate n ^ (p - 1).
                    long result = n;
                    for (int power = 1; power < p - 1; power++)
                    {
                        result = (result * n) % p;
                    }

                    // If the final result is not 1, p is not prime.
                    if (result != 1)
                    {
                        txtIsPrime.Text = (i + 1).ToString() +
                            " tests. " + n + "^(p-1) = " + result;
                        return false;
                    }
                }
            }

            // If we survived all the tests, p is probably prime.
            return true;
        }

        // Return the number's prime factors.
        private List<long> FindFactors(long num)
        {
            List<long> result = new List<long>();

            // Take out the 2s.
            while (num % 2 == 0)
            {
                result.Add(2);
                num /= 2;
            }

            // Take out other primes.
            long factor = 3;
            while (factor * factor <= num)
            {
                if (num % factor == 0)
                {
                    // This is a factor.
                    result.Add(factor);
                    num /= factor;
                }
                else
                {
                    // Go to the next odd number.
                    factor += 2;
                }
            }

            // If num is not 1, then whatever is left is prime.
            if (num > 1) result.Add(num);

            return result;
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
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.nudNumTests = new System.Windows.Forms.NumericUpDown();
            this.txtIsPrime = new System.Windows.Forms.TextBox();
            this.txtFactors = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumTests)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number:";
            // 
            // txtNumber
            // 
            this.txtNumber.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNumber.Location = new System.Drawing.Point(144, 12);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(81, 20);
            this.txtNumber.TabIndex = 1;
            this.txtNumber.Text = "606733";
            this.txtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "# Tests:";
            // 
            // btnTest
            // 
            this.btnTest.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTest.Location = new System.Drawing.Point(115, 64);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 4;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // nudNumTests
            // 
            this.nudNumTests.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nudNumTests.Location = new System.Drawing.Point(144, 38);
            this.nudNumTests.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudNumTests.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumTests.Name = "nudNumTests";
            this.nudNumTests.Size = new System.Drawing.Size(81, 20);
            this.nudNumTests.TabIndex = 6;
            this.nudNumTests.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudNumTests.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // txtIsPrime
            // 
            this.txtIsPrime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIsPrime.Location = new System.Drawing.Point(12, 93);
            this.txtIsPrime.Name = "txtIsPrime";
            this.txtIsPrime.ReadOnly = true;
            this.txtIsPrime.Size = new System.Drawing.Size(280, 20);
            this.txtIsPrime.TabIndex = 7;
            this.txtIsPrime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFactors
            // 
            this.txtFactors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFactors.Location = new System.Drawing.Point(12, 119);
            this.txtFactors.Name = "txtFactors";
            this.txtFactors.ReadOnly = true;
            this.txtFactors.Size = new System.Drawing.Size(280, 20);
            this.txtFactors.TabIndex = 8;
            this.txtFactors.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // howto_check_primality_Form1
            // 
            this.AcceptButton = this.btnTest;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 151);
            this.Controls.Add(this.txtFactors);
            this.Controls.Add(this.txtIsPrime);
            this.Controls.Add(this.nudNumTests);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.label1);
            this.Name = "howto_check_primality_Form1";
            this.Text = "howto_check_primality";
            ((System.ComponentModel.ISupportInitialize)(this.nudNumTests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.NumericUpDown nudNumTests;
        private System.Windows.Forms.TextBox txtIsPrime;
        private System.Windows.Forms.TextBox txtFactors;
    }
}

