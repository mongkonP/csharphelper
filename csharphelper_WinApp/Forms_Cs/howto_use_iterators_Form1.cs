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
     public partial class howto_use_iterators_Form1:Form
  { 


        public howto_use_iterators_Form1()
        {
            InitializeComponent();
        }

        // Fill the ListBox with primes.
        private void howto_use_iterators_Form1_Load(object sender, EventArgs e)
        {
            foreach (int prime in Primes(250))
            {
                //Console.WriteLine("Got " + prime);
                lstPrimes.Items.Add(prime);
            }
        }

        // Return primes by using the Sieve of Eratosthenes.
        private static IEnumerable<int> Primes(int max)
        {
            bool[] not_prime = new bool[max + 1];
            for (int i = 2; i <= max; i++)
            {
                // See if i is prime.
                if (!not_prime[i])
                {
                    // The number i is prime. Return it.
                    //Console.WriteLine("Yielding " + i);
                    yield return i;

                    // Knock out multiples of i.
                    for (int j = i * 2; j <= max; j += i)
                        not_prime[j] = true;
                }
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
            this.lstPrimes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstPrimes
            // 
            this.lstPrimes.ColumnWidth = 50;
            this.lstPrimes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPrimes.FormattingEnabled = true;
            this.lstPrimes.Location = new System.Drawing.Point(0, 0);
            this.lstPrimes.MultiColumn = true;
            this.lstPrimes.Name = "lstPrimes";
            this.lstPrimes.Size = new System.Drawing.Size(284, 160);
            this.lstPrimes.TabIndex = 1;
            // 
            // howto_use_iterators_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.lstPrimes);
            this.Name = "howto_use_iterators_Form1";
            this.Text = "howto_use_iterators";
            this.Load += new System.EventHandler(this.howto_use_iterators_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstPrimes;
    }
}

