using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_yield_primes;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_yield_primes_Form1:Form
  { 


        public howto_yield_primes_Form1()
        {
            InitializeComponent();
        }

        // Display primes up to the indicated limit.
        private void btnGo_Click(object sender, EventArgs e)
        {
            long limit = long.Parse(txtLimit.Text);
            StringBuilder sb = new StringBuilder();

            PrimeGenerator generator = new PrimeGenerator();
            foreach (long value in generator)
            {
                if (value > limit) break;
                sb.Append(value.ToString() + " ");
            }
            string text = sb.ToString();
            txtPrimes.Text = text.Substring(0, text.Length - 1);
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
            this.txtLimit = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtPrimes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Primes up to:";
            // 
            // txtLimit
            // 
            this.txtLimit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLimit.Location = new System.Drawing.Point(86, 14);
            this.txtLimit.Name = "txtLimit";
            this.txtLimit.Size = new System.Drawing.Size(105, 20);
            this.txtLimit.TabIndex = 1;
            this.txtLimit.Text = "10000";
            this.txtLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(197, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtPrimes
            // 
            this.txtPrimes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrimes.Location = new System.Drawing.Point(12, 57);
            this.txtPrimes.Multiline = true;
            this.txtPrimes.Name = "txtPrimes";
            this.txtPrimes.ReadOnly = true;
            this.txtPrimes.Size = new System.Drawing.Size(260, 192);
            this.txtPrimes.TabIndex = 3;
            // 
            // howto_yield_primes_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txtPrimes);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtLimit);
            this.Controls.Add(this.label1);
            this.Name = "howto_yield_primes_Form1";
            this.Text = "howto_yield_primes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLimit;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtPrimes;
    }
}

