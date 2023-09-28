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
     public partial class howto_find_primes_Form1:Form
  { 


        public howto_find_primes_Form1()
        {
            InitializeComponent();
        }

        // Find a prime.
        private Random Rand = new Random();
        private void btnFindPrime_Click(object sender, EventArgs e)
        {
            txtResult.Clear();
            Refresh();

            // Get the bounds.
            int min = int.Parse(txtMinimum.Text);
            int max = int.Parse(txtMaximum.Text);
            int num_tests = (int)nudNumTests.Value;

            // Find a prime.
            int p = FindPrime(min, max, num_tests);
            Console.WriteLine("Prime: " + p);
        }

        // Probabilistically find a prime number within the range [min, max].
        private int FindPrime(int min, int max, int num_tests)
        {
            // Try random numbers until we find a prime.
            for (int i = 1; ; i++)
            {
                // Pick a random odd p.
                int p = Rand.Next(min, max + 1);
                if (p % 2 == 0) continue;
                txtResult.Text = "Checking " + p;
                txtResult.Refresh();

                // See if it's prime.
                if (IsProbablyPrime(p, 100))
                {
                    txtResult.Text = p.ToString() + " (" + i + " tries)";
                    return p;
                }
            }
        }

        // Perform tests to see if a number is (probably) prime.
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
                    if (result != 1) return false;
                }
            }

            // If we survived all the tests, p is probably prime.
            return true;
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
            this.txtMinimum = new System.Windows.Forms.TextBox();
            this.txtMaximum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFindPrime = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudNumTests = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumTests)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Minimum:";
            // 
            // txtMinimum
            // 
            this.txtMinimum.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMinimum.Location = new System.Drawing.Point(128, 12);
            this.txtMinimum.Name = "txtMinimum";
            this.txtMinimum.Size = new System.Drawing.Size(100, 20);
            this.txtMinimum.TabIndex = 1;
            this.txtMinimum.Text = "100000";
            this.txtMinimum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMaximum
            // 
            this.txtMaximum.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMaximum.Location = new System.Drawing.Point(128, 38);
            this.txtMaximum.Name = "txtMaximum";
            this.txtMaximum.Size = new System.Drawing.Size(100, 20);
            this.txtMaximum.TabIndex = 3;
            this.txtMaximum.Text = "999999";
            this.txtMaximum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Maximum:";
            // 
            // btnFindPrime
            // 
            this.btnFindPrime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFindPrime.Location = new System.Drawing.Point(105, 90);
            this.btnFindPrime.Name = "btnFindPrime";
            this.btnFindPrime.Size = new System.Drawing.Size(75, 23);
            this.btnFindPrime.TabIndex = 4;
            this.btnFindPrime.Text = "Find Prime";
            this.btnFindPrime.UseVisualStyleBackColor = true;
            this.btnFindPrime.Click += new System.EventHandler(this.btnFindPrime_Click);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(12, 119);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(260, 20);
            this.txtResult.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "# Tests:";
            // 
            // numericUpDown1
            // 
            this.nudNumTests.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nudNumTests.Location = new System.Drawing.Point(128, 64);
            this.nudNumTests.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudNumTests.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumTests.Name = "numericUpDown1";
            this.nudNumTests.Size = new System.Drawing.Size(100, 20);
            this.nudNumTests.TabIndex = 7;
            this.nudNumTests.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudNumTests.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // howto_find_primes_Form1
            // 
            this.AcceptButton = this.btnFindPrime;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 151);
            this.Controls.Add(this.nudNumTests);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnFindPrime);
            this.Controls.Add(this.txtMaximum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMinimum);
            this.Controls.Add(this.label1);
            this.Name = "howto_find_primes_Form1";
            this.Text = "howto_find_primes";
            ((System.ComponentModel.ISupportInitialize)(this.nudNumTests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMinimum;
        private System.Windows.Forms.TextBox txtMaximum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFindPrime;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudNumTests;
    }
}

