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
     public partial class howto_approximate_pi_Form1:Form
  { 


        public howto_approximate_pi_Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int num_terms = int.Parse(txtNumTerms.Text);

            DisplayValue(Math.PI, txtMathPi, txtMathPiError);
            DisplayValue(GregoryLeibnizPi(num_terms), txtGregoryLeibniz, txtGregoryLeibnizError);
            DisplayValue(NilakanthaPi(num_terms), txtNilakantha, txtNilakanthaError);
            DisplayValue(NewtonPi(num_terms), txtNewton, txtNewtonError);
            DisplayValue(ArcsinePi(num_terms), txtArcsine, txtArcsineError);
            DisplayValue(355.0 / 113.0, txt355_113, txt355_113Error);
        }

        // Display a value for pi and its error from Math.PI.
        private void DisplayValue(double pi, TextBox txtValue, TextBox txtError)
        {
            txtValue.Text = pi.ToString("F15");
            double error = Math.PI - pi;
            txtError.Text = error.ToString("E");
        }

#region Gregory-Leibniz

        // Gregory-Leibniz series.
        // Pi/4 = Sum(-1^k/(2k+1))
        private double GregoryLeibnizPi(long num_terms)
        {
            double result = 0;
            double sign = 1;
            for (int term = 0; term < num_terms; term++)
            {
                result += sign / (term * 2 + 1);
                sign *= -1;
            }
            return 4 * result;
        }

#endregion

#region Newton

        // Newton series.
        // Pi/2 = Sum(k!/(2k+1)!!)
        private double NewtonPi(int num_terms)
        {
            double result = 0;
            for (int k = 0; k < num_terms; k++)
                result += Factorial(k) / OddProd(2 * k + 1);
            return result * 2;
        }

        // Return n!
        private double Factorial(long n)
        {
            double result = 1;
            for (long i = 2; i <= n; i++) result *= i;
            return result;
        }

        // Return the product of the odd integers up to the number.
        private double OddProd(long n)
        {
            double result = 1;
            for (long i = 3; i <= n; i += 2) result *= i;
            return result;
        }


#endregion Newton

#region Nilakantha

        // Nilakantha series.
        // Pi/2 = Sum(-1^k/(2k+2)(2k+3)(2k+4))
        private double NilakanthaPi(int num_terms)
        {
            double result = 0;
            double sign = 1;
            for (int i=0; i<num_terms; i++)
            {
                result += sign / (2 * i + 2) / (2 * i + 3) / (2 * i + 4);
                sign = -sign;
            }
            return 3 + result * 4;
        }

#endregion Nilakantha

#region Arcsine

        // Arcsine series.
        // Pi = Sum(3*(2n choose n) / 16^n (2*n+1))
        private double ArcsinePi(int num_terms)
        {
            double result = 0;
            for (int i = 0; i < num_terms; i++)
                result += 3 * Choose(2 * i, i)
                    / Math.Pow(16, i)
                    / (2 * i + 1);
            return result;
        }

        // Return n choose k.
        private double Choose(int n, int k)
        {
            double result = 1;
            for (int i = 1; i <= k; i++)
            {
                result *= n - (k - i);
                result /= i;
            }
            return result;
        }

#endregion Arcsine

        private double PiDigit(int d)
        {
            return d * Math.Pow(2, d) * Factorial(d) * Factorial(d)
                / Factorial(2 * d);
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
            this.txtNumTerms = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.txtGregoryLeibniz = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGregoryLeibnizError = new System.Windows.Forms.TextBox();
            this.txtNewtonError = new System.Windows.Forms.TextBox();
            this.txtNewton = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNilakanthaError = new System.Windows.Forms.TextBox();
            this.txtNilakantha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMathPiError = new System.Windows.Forms.TextBox();
            this.txtMathPi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtArcsineError = new System.Windows.Forms.TextBox();
            this.txtArcsine = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt355_113Error = new System.Windows.Forms.TextBox();
            this.txt355_113 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "# Terms:";
            // 
            // txtNumTerms
            // 
            this.txtNumTerms.Location = new System.Drawing.Point(67, 14);
            this.txtNumTerms.Name = "txtNumTerms";
            this.txtNumTerms.Size = new System.Drawing.Size(58, 20);
            this.txtNumTerms.TabIndex = 0;
            this.txtNumTerms.Text = "10";
            this.txtNumTerms.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(147, 12);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 1;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // txtGregoryLeibniz
            // 
            this.txtGregoryLeibniz.Location = new System.Drawing.Point(120, 113);
            this.txtGregoryLeibniz.Name = "txtGregoryLeibniz";
            this.txtGregoryLeibniz.ReadOnly = true;
            this.txtGregoryLeibniz.Size = new System.Drawing.Size(137, 20);
            this.txtGregoryLeibniz.TabIndex = 4;
            this.txtGregoryLeibniz.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Gregory-Leibniz";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 19);
            this.label4.TabIndex = 17;
            this.label4.Text = "Series";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtGregoryLeibnizError
            // 
            this.txtGregoryLeibnizError.Location = new System.Drawing.Point(263, 113);
            this.txtGregoryLeibnizError.Name = "txtGregoryLeibnizError";
            this.txtGregoryLeibnizError.ReadOnly = true;
            this.txtGregoryLeibnizError.Size = new System.Drawing.Size(137, 20);
            this.txtGregoryLeibnizError.TabIndex = 5;
            this.txtGregoryLeibnizError.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNewtonError
            // 
            this.txtNewtonError.Location = new System.Drawing.Point(263, 165);
            this.txtNewtonError.Name = "txtNewtonError";
            this.txtNewtonError.ReadOnly = true;
            this.txtNewtonError.Size = new System.Drawing.Size(137, 20);
            this.txtNewtonError.TabIndex = 9;
            this.txtNewtonError.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNewton
            // 
            this.txtNewton.Location = new System.Drawing.Point(120, 165);
            this.txtNewton.Name = "txtNewton";
            this.txtNewton.ReadOnly = true;
            this.txtNewton.Size = new System.Drawing.Size(137, 20);
            this.txtNewton.TabIndex = 8;
            this.txtNewton.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Newton";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(117, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 19);
            this.label8.TabIndex = 26;
            this.label8.Text = "Result";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(263, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 19);
            this.label9.TabIndex = 27;
            this.label9.Text = "Error";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNilakanthaError
            // 
            this.txtNilakanthaError.Location = new System.Drawing.Point(263, 139);
            this.txtNilakanthaError.Name = "txtNilakanthaError";
            this.txtNilakanthaError.ReadOnly = true;
            this.txtNilakanthaError.Size = new System.Drawing.Size(137, 20);
            this.txtNilakanthaError.TabIndex = 7;
            this.txtNilakanthaError.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNilakantha
            // 
            this.txtNilakantha.Location = new System.Drawing.Point(120, 139);
            this.txtNilakantha.Name = "txtNilakantha";
            this.txtNilakantha.ReadOnly = true;
            this.txtNilakantha.Size = new System.Drawing.Size(137, 20);
            this.txtNilakantha.TabIndex = 6;
            this.txtNilakantha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Nilakantha";
            // 
            // txtMathPiError
            // 
            this.txtMathPiError.Location = new System.Drawing.Point(263, 87);
            this.txtMathPiError.Name = "txtMathPiError";
            this.txtMathPiError.ReadOnly = true;
            this.txtMathPiError.Size = new System.Drawing.Size(137, 20);
            this.txtMathPiError.TabIndex = 3;
            this.txtMathPiError.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMathPi
            // 
            this.txtMathPi.Location = new System.Drawing.Point(120, 87);
            this.txtMathPi.Name = "txtMathPi";
            this.txtMathPi.ReadOnly = true;
            this.txtMathPi.Size = new System.Drawing.Size(137, 20);
            this.txtMathPi.TabIndex = 2;
            this.txtMathPi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Math.PI";
            // 
            // txtArcsineError
            // 
            this.txtArcsineError.Location = new System.Drawing.Point(263, 191);
            this.txtArcsineError.Name = "txtArcsineError";
            this.txtArcsineError.ReadOnly = true;
            this.txtArcsineError.Size = new System.Drawing.Size(137, 20);
            this.txtArcsineError.TabIndex = 11;
            this.txtArcsineError.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtArcsine
            // 
            this.txtArcsine.Location = new System.Drawing.Point(120, 191);
            this.txtArcsine.Name = "txtArcsine";
            this.txtArcsine.ReadOnly = true;
            this.txtArcsine.Size = new System.Drawing.Size(137, 20);
            this.txtArcsine.TabIndex = 10;
            this.txtArcsine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Arcsine";
            // 
            // txt355_113Error
            // 
            this.txt355_113Error.Location = new System.Drawing.Point(263, 217);
            this.txt355_113Error.Name = "txt355_113Error";
            this.txt355_113Error.ReadOnly = true;
            this.txt355_113Error.Size = new System.Drawing.Size(137, 20);
            this.txt355_113Error.TabIndex = 36;
            this.txt355_113Error.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt355_113
            // 
            this.txt355_113.Location = new System.Drawing.Point(120, 217);
            this.txt355_113.Name = "txt355_113";
            this.txt355_113.ReadOnly = true;
            this.txt355_113.Size = new System.Drawing.Size(137, 20);
            this.txt355_113.TabIndex = 35;
            this.txt355_113.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 220);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "355/113";
            // 
            // howto_approximate_pi_Form1
            // 
            this.AcceptButton = this.btnCalculate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 248);
            this.Controls.Add(this.txt355_113Error);
            this.Controls.Add(this.txt355_113);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtArcsineError);
            this.Controls.Add(this.txtArcsine);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMathPiError);
            this.Controls.Add(this.txtMathPi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNilakanthaError);
            this.Controls.Add(this.txtNilakantha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNewtonError);
            this.Controls.Add(this.txtNewton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtGregoryLeibnizError);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtGregoryLeibniz);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtNumTerms);
            this.Controls.Add(this.label1);
            this.Name = "howto_approximate_pi_Form1";
            this.Text = "howto_approximate_pi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumTerms;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.TextBox txtGregoryLeibniz;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGregoryLeibnizError;
        private System.Windows.Forms.TextBox txtNewtonError;
        private System.Windows.Forms.TextBox txtNewton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNilakanthaError;
        private System.Windows.Forms.TextBox txtNilakantha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMathPiError;
        private System.Windows.Forms.TextBox txtMathPi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtArcsineError;
        private System.Windows.Forms.TextBox txtArcsine;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt355_113Error;
        private System.Windows.Forms.TextBox txt355_113;
        private System.Windows.Forms.Label label10;
    }
}

