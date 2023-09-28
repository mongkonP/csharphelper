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
     public partial class howto_list_prime_factors_Form1:Form
  { 


        public howto_list_prime_factors_Form1()
        {
            InitializeComponent();
        }

        // Find the number's factors.
        private void btnFactor_Click(object sender, EventArgs e)
        {
            txtFactors.Clear();
            Refresh();

            // Get the number.
            long number;
            if (!long.TryParse(txtNumber.Text, out number)) number = -1;
            if (number < 2)
            {
                MessageBox.Show("The number must be between 2 and " +
                    long.MaxValue);
                txtFactors.Focus();
                return;
            }

            // Get the factors.
            List<long> factors = FindFactors(number);
            List<string> strings = factors.ConvertAll<string>(x => x.ToString());
            txtFactors.Text = string.Join(" x ", strings.ToArray());
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
            this.btnFactor = new System.Windows.Forms.Button();
            this.txtFactors = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number:";
            // 
            // txtNumber
            // 
            this.txtNumber.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNumber.Location = new System.Drawing.Point(92, 12);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(153, 20);
            this.txtNumber.TabIndex = 1;
            this.txtNumber.Text = "1234567890";
            this.txtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnFactor
            // 
            this.btnFactor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFactor.Location = new System.Drawing.Point(105, 38);
            this.btnFactor.Name = "btnFactor";
            this.btnFactor.Size = new System.Drawing.Size(75, 23);
            this.btnFactor.TabIndex = 2;
            this.btnFactor.Text = "Factor";
            this.btnFactor.UseVisualStyleBackColor = true;
            this.btnFactor.Click += new System.EventHandler(this.btnFactor_Click);
            // 
            // txtFactors
            // 
            this.txtFactors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFactors.Location = new System.Drawing.Point(12, 76);
            this.txtFactors.Name = "txtFactors";
            this.txtFactors.ReadOnly = true;
            this.txtFactors.Size = new System.Drawing.Size(260, 20);
            this.txtFactors.TabIndex = 3;
            this.txtFactors.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // howto_list_prime_factors_Form1
            // 
            this.AcceptButton = this.btnFactor;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 110);
            this.Controls.Add(this.txtFactors);
            this.Controls.Add(this.btnFactor);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.label1);
            this.Name = "howto_list_prime_factors_Form1";
            this.Text = "howto_list_prime_factors";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Button btnFactor;
        private System.Windows.Forms.TextBox txtFactors;
    }
}

