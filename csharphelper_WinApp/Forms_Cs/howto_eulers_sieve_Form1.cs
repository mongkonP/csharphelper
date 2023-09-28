using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_eulers_sieve_Form1:Form
  { 


        public howto_eulers_sieve_Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            lstPrimes.Items.Clear();
            lblEstPrimes.Text = "";
            lblActualPrimes.Text = "";
            Cursor = Cursors.WaitCursor;
            Refresh();

            // Make the sieve.
            int max = int.Parse(txtMaxNumber.Text);
            bool[] is_prime = MakeSieve(max);

            // Display the primes.
            int num_primes = 0;
            for (int i = 2; i <= max; i++)
                if (is_prime[i])
                {
                    if (num_primes <= 10000) lstPrimes.Items.Add(i);
                    num_primes++;
                }
            if (num_primes > 10000) lstPrimes.Items.Add("...");

            // Display the estimated and actual number of primes.
            lblActualPrimes.Text = num_primes.ToString();

            // Display a Legendre estimate ?(n) = n/(log(n) - 1.08366).
            // See http://mathworld.wolfram.com/PrimeCountingFunction.html.
            double est = (max / (Math.Log(max) - 1.08366));
            lblEstPrimes.Text = est.ToString("0");

            Cursor = Cursors.Default;
        }

        // Build Euler's Sieve.
        private bool[] MakeSieve(int max)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            // Make an array indicating whether numbers are prime.
            bool[] is_prime = new bool[max + 1];
            is_prime[2] = true;
            for (int i = 3; i <= max; i += 2) is_prime[i] = true;

            // Cross out multiples of odd primes.
            for (int p = 3; p <= max; p += 2)
            {
                // See if i is prime.
                if (is_prime[p])
                {
                    // Knock out multiples of p.
                    int max_q = max / p;
                    if (max_q % 2 == 0) max_q--;    // Make it odd.
                    for (int q = max_q; q >= p; q -= 2)
                    {
                        // Only use q if it is prime.
                        if (is_prime[q]) is_prime[p * q] = false;
                    }
                }
            }

            watch.Stop();
            Console.WriteLine(watch.Elapsed.TotalSeconds.ToString("0.00") + " seconds");

            return is_prime;
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
            this.lstPrimes = new System.Windows.Forms.ListBox();
            this.lblActualPrimes = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblEstPrimes = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtMaxNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstPrimes
            // 
            this.lstPrimes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPrimes.ColumnWidth = 50;
            this.lstPrimes.FormattingEnabled = true;
            this.lstPrimes.IntegralHeight = false;
            this.lstPrimes.Location = new System.Drawing.Point(12, 90);
            this.lstPrimes.MultiColumn = true;
            this.lstPrimes.Name = "lstPrimes";
            this.lstPrimes.Size = new System.Drawing.Size(360, 159);
            this.lstPrimes.TabIndex = 2;
            // 
            // lblActualPrimes
            // 
            this.lblActualPrimes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblActualPrimes.Location = new System.Drawing.Point(99, 67);
            this.lblActualPrimes.Name = "lblActualPrimes";
            this.lblActualPrimes.Size = new System.Drawing.Size(55, 20);
            this.lblActualPrimes.TabIndex = 31;
            this.lblActualPrimes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Actual Primes:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEstPrimes
            // 
            this.lblEstPrimes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEstPrimes.Location = new System.Drawing.Point(99, 47);
            this.lblEstPrimes.Name = "lblEstPrimes";
            this.lblEstPrimes.Size = new System.Drawing.Size(55, 20);
            this.lblEstPrimes.TabIndex = 29;
            this.lblEstPrimes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Est. Primes:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(297, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtMaxNumber
            // 
            this.txtMaxNumber.Location = new System.Drawing.Point(99, 14);
            this.txtMaxNumber.Name = "txtMaxNumber";
            this.txtMaxNumber.Size = new System.Drawing.Size(55, 20);
            this.txtMaxNumber.TabIndex = 0;
            this.txtMaxNumber.Text = "10000";
            this.txtMaxNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Max Number:";
            // 
            // howto_eulers_sieve_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.lstPrimes);
            this.Controls.Add(this.lblActualPrimes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblEstPrimes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtMaxNumber);
            this.Controls.Add(this.label1);
            this.Name = "howto_eulers_sieve_Form1";
            this.Text = "howto_eulers_sieve";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstPrimes;
        private System.Windows.Forms.Label lblActualPrimes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblEstPrimes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtMaxNumber;
        private System.Windows.Forms.Label label1;
    }
}

