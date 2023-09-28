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
     public partial class howto_mersenne_primes_Form1:Form
  { 


        public howto_mersenne_primes_Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            lstPrimes.Items.Clear();
            Cursor = Cursors.WaitCursor;
            Refresh();

            try
            {
                checked
                {
                    long power = 1;
                    for (int n = 1; n < 63; n++)
                    {
                        // Get the next power of 2.
                        power *= 2;

                        // See if power - 1 is prime.
                        if (IsMersennePrime(power - 1))
                        {
                            lstPrimes.Items.Add(
                                n.ToString() + ": " + (power - 1).ToString());
                            Refresh();
                        }
                    }
                }
            }
            catch
            {
            }

            Cursor = Cursors.Default;
        }

        // Return true if the number is prime.
        private bool IsMersennePrime(long number)
        {
            // See if the number is divisible by odd values up to Sqrt(number).
            long sqrt = (long)Math.Sqrt(number);
            for (long i = 3; i < sqrt; i += 2)
                if (number % i == 0) return false;

            // If we get here, the number is prime.
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
            this.btnGo = new System.Windows.Forms.Button();
            this.lstPrimes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGo.Location = new System.Drawing.Point(130, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lstPrimes
            // 
            this.lstPrimes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPrimes.FormattingEnabled = true;
            this.lstPrimes.IntegralHeight = false;
            this.lstPrimes.Location = new System.Drawing.Point(12, 41);
            this.lstPrimes.Name = "lstPrimes";
            this.lstPrimes.Size = new System.Drawing.Size(310, 158);
            this.lstPrimes.TabIndex = 1;
            // 
            // howto_mersenne_primes_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 211);
            this.Controls.Add(this.lstPrimes);
            this.Controls.Add(this.btnGo);
            this.Name = "howto_mersenne_primes_Form1";
            this.Text = "howto_mersenne_primes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ListBox lstPrimes;
    }
}

