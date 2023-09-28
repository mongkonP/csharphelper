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
     public partial class howto_fibonacci_methods_Form1:Form
  { 


        public howto_fibonacci_methods_Form1()
        {
            InitializeComponent();
        }

        // Calculate the Fibonacci number in various ways.
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            txtRecursive.Clear();
            txtLookup.Clear();
            txtIterate.Clear();
            txtDeMoivre.Clear();
            txtPhi1.Clear();
            Refresh();

            int n = int.Parse(txtN.Text);

            if (n <= 40) txtRecursive.Text = Fibonacci1(n).ToString();
            Refresh();

            txtLookup.Text = Fibonacci2(n).ToString();
            Refresh();

            txtIterate.Text = Fibonacci3(n).ToString();
            Refresh();

            txtDeMoivre.Text = Fibonacci4(n).ToString();
            Refresh();

            txtPhi1.Text = Fibonacci5(n).ToString();
            Refresh();

            Cursor = Cursors.Default;
        }

        // Recursive.
        private double Fibonacci1(int n)
        {
            if (n <= 1) return n;
            return Fibonacci1(n - 1) + Fibonacci1(n - 2);
        }

        // With lookup values.
        private double Fibonacci2(int n)
        {
            if (n <= 1) return n;

            // Create the lookup table.
            double[] fibo = new double[n + 1];
            return Fibonacci2(fibo, n);
        }
        private double Fibonacci2(double[] fibo, int n)
        {
            if (n <= 1) return n;

            // If we have already calculated this value, return it.
            if (fibo[n] > 0) return fibo[n];

            // Calculate the result.
            double result =
                Fibonacci2(fibo, n - 1) +
                Fibonacci2(fibo, n - 2);

            // Save the value in the table.
            fibo[n] = result;

            // Return the result.
            return result;
        }

        // Iterate holding the two previous values.
        private double Fibonacci3(int n)
        {
            if (n <= 1) return n;

            double minus2 = 0;
            double minus1 = 1;
            double fibo = minus1 + minus2;
            for (int i = 3; i <= n; i++)
            {
                minus2 = minus1;
                minus1 = fibo;
                fibo = minus1 + minus2;
            }
            return fibo;
        }

        // Use Abraham de Moivre's formula.
        private double Fibonacci4(int n)
        {
            double phi1 = (1 + Math.Sqrt(5)) / 2.0;
            double phi2 = (1 - Math.Sqrt(5)) / 2.0;
            return (Math.Pow(phi1, n) - Math.Pow(phi2, n)) / Math.Sqrt(5);
        }

        // Ignore phi2.
        private double Fibonacci5(int n)
        {
            double phi1 = (1 + Math.Sqrt(5)) / 2.0;
            return Math.Truncate(Math.Pow(phi1, n) / Math.Sqrt(5));
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
            this.txtIterate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPhi1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDeMoivre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLookup = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRecursive = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.txtN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtIterate
            // 
            this.txtIterate.Location = new System.Drawing.Point(133, 94);
            this.txtIterate.Name = "txtIterate";
            this.txtIterate.ReadOnly = true;
            this.txtIterate.Size = new System.Drawing.Size(110, 20);
            this.txtIterate.TabIndex = 18;
            this.txtIterate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(69, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Iterate:";
            // 
            // txtPhi1
            // 
            this.txtPhi1.Location = new System.Drawing.Point(133, 146);
            this.txtPhi1.Name = "txtPhi1";
            this.txtPhi1.ReadOnly = true;
            this.txtPhi1.Size = new System.Drawing.Size(110, 20);
            this.txtPhi1.TabIndex = 21;
            this.txtPhi1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "phi1:";
            // 
            // txtDeMoivre
            // 
            this.txtDeMoivre.Location = new System.Drawing.Point(133, 120);
            this.txtDeMoivre.Name = "txtDeMoivre";
            this.txtDeMoivre.ReadOnly = true;
            this.txtDeMoivre.Size = new System.Drawing.Size(110, 20);
            this.txtDeMoivre.TabIndex = 19;
            this.txtDeMoivre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "de Moivre:";
            // 
            // txtLookup
            // 
            this.txtLookup.Location = new System.Drawing.Point(133, 68);
            this.txtLookup.Name = "txtLookup";
            this.txtLookup.ReadOnly = true;
            this.txtLookup.Size = new System.Drawing.Size(110, 20);
            this.txtLookup.TabIndex = 16;
            this.txtLookup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Lookup:";
            // 
            // txtRecursive
            // 
            this.txtRecursive.Location = new System.Drawing.Point(133, 42);
            this.txtRecursive.Name = "txtRecursive";
            this.txtRecursive.ReadOnly = true;
            this.txtRecursive.Size = new System.Drawing.Size(110, 20);
            this.txtRecursive.TabIndex = 15;
            this.txtRecursive.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Recursive:";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(133, 13);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 14;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(36, 15);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(44, 20);
            this.txtN.TabIndex = 12;
            this.txtN.Text = "10";
            this.txtN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "N:";
            // 
            // howto_fibonacci_methods_Form1
            // 
            this.AcceptButton = this.btnCalculate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 176);
            this.Controls.Add(this.txtIterate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPhi1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDeMoivre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLookup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRecursive);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.label1);
            this.Name = "howto_fibonacci_methods_Form1";
            this.Text = "howto_fibonacci_methods";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIterate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPhi1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDeMoivre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLookup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRecursive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.Label label1;
    }
}

