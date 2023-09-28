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
     public partial class howto_linq_find_primes2_Form1:Form
  { 


        public howto_linq_find_primes2_Form1()
        {
            InitializeComponent();
        }

        // Find primes.
        private void btnGo_Click(object sender, EventArgs e)
        {
            int max = int.Parse(txtMax.Text);

            // Define the IsOddPrime delegate.
            Func<int, bool> IsOddPrime = n =>
            {
                for (int i = 3; i * i <= n; i += 2)
                    if (n % i == 0) return false;
                return true;
            };

            // Check odd numbers.
            var primes =
                from number in Enumerable.Range(1, max / 2)
                where IsOddPrime(2 * number + 1)
                select 2 * number + 1;

            // Add the number 2.
            List<int> numbers = primes.ToList();
            numbers.Insert(0, 2);

            // Remove max + 1 if it is in the list.
            if (numbers[numbers.Count - 1] > max)
                numbers.RemoveAt(numbers.Count - 1);

            // Display the results.
            lstPrimes.DataSource = numbers;
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstPrimes
            // 
            this.lstPrimes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPrimes.FormattingEnabled = true;
            this.lstPrimes.IntegralHeight = false;
            this.lstPrimes.Location = new System.Drawing.Point(15, 41);
            this.lstPrimes.MultiColumn = true;
            this.lstPrimes.Name = "lstPrimes";
            this.lstPrimes.Size = new System.Drawing.Size(293, 208);
            this.lstPrimes.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Maximum #:";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(187, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 5;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(82, 14);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(73, 20);
            this.txtMax.TabIndex = 4;
            this.txtMax.Text = "1000";
            this.txtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // howto_linq_find_primes2_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 261);
            this.Controls.Add(this.lstPrimes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtMax);
            this.Name = "howto_linq_find_primes2_Form1";
            this.Text = "howto_linq_find_primes2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstPrimes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtMax;
    }
}

