using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Checked and unchecked, even when obeyed,
// apply only to the directly enclosed code
// not code inside nested function calls.
//http://www.codeproject.com/KB/cs/overflow_checking.aspx

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_checked_unchecked_Form1:Form
  { 


        public howto_checked_unchecked_Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            int N = int.Parse(txtN.Text);

            txtInteger.Text = IntFactorial(N);
            txtLong.Text = LongFactorial(N);
            txtDecimal.Text = DecimalFactorial(N);
            txtFloat.Text = FloatFactorial(N);
            txtDouble.Text = DoubleFactorial(N);

            txtIntegerChecked.Text = IntFactorialChecked(N);
            txtLongChecked.Text = LongFactorialChecked(N);
            txtDecimalChecked.Text = DecimalFactorialChecked(N);
            txtFloatChecked.Text = FloatFactorialChecked(N);
            txtDoubleChecked.Text = DoubleFactorialChecked(N);

            txtIntegerUnchecked.Text = IntFactorialUnchecked(N);
            txtLongUnchecked.Text = LongFactorialUnchecked(N);
            txtDecimalUnchecked.Text = DecimalFactorialUnchecked(N);
            txtFloatUnchecked.Text = FloatFactorialUnchecked(N);
            txtDoubleUnchecked.Text = DoubleFactorialUnchecked(N);
        }

        // Calculate factorials with different data types.
        private string IntFactorial(int N)
        {
            // Integer obeys checked and unchecked.
            try
            {
                int result = 1;
                for (int i = 2; i <= N; i++) result *= i;
                return result.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        private string LongFactorial(long N)
        {
            // Long obeys checked and unchecked.
            try
            {
                long result = 1;
                for (long i = 2; i <= N; i++) result *= i;
                return result.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        private string DecimalFactorial(decimal N)
        {
            // Decimal ignores checked and unchecked
            // and always throws OverflowException.
            try
            {
                decimal result = 1;
                for (decimal i = 2; i <= N; i++) result *= i;
                return result.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        // Floats and doubles ignore checked and return Infinity.
        private string FloatFactorial(float N)
        {
            float result = 1;
            for (float i = 2; i <= N; i++) result *= i;
            if (float.IsInfinity(result)) return "Infinity";
            return result.ToString();
        }
        private string DoubleFactorial(double N)
        {
            double result = 1;
            for (double i = 2; i <= N; i++) result *= i;
            if (double.IsInfinity(result)) return "Infinity";
            return result.ToString();
        }

        private string IntFactorialChecked(int N)
        {
            // Integer obeys checked and unchecked.
            try
            {
                checked
                {
                    int result = 1;
                    for (int i = 2; i <= N; i++) result *= i;
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        private string LongFactorialChecked(long N)
        {
            // Long obeys checked and unchecked.
            try
            {
                checked
                {
                    long result = 1;
                    for (long i = 2; i <= N; i++) result *= i;
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        private string DecimalFactorialChecked(decimal N)
        {
            // Decimal ignores checked and unchecked
            // and always throws OverflowException.
            try
            {
                checked
                {
                    decimal result = 1;
                    for (decimal i = 2; i <= N; i++) result *= i;
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        // Floats and doubles ignore checked and return Infinity.
        private string FloatFactorialChecked(float N)
        {
            checked
            {
                float result = 1;
                for (float i = 2; i <= N; i++) result *= i;
                if (float.IsInfinity(result)) return "Infinity";
                return result.ToString();
            }
        }
        private string DoubleFactorialChecked(double N)
        {
            checked
            {
                double result = 1;
                for (double i = 2; i <= N; i++) result *= i;
                if (double.IsInfinity(result)) return "Infinity";
                return result.ToString();
            }
        }

        private string IntFactorialUnchecked(int N)
        {
            // Integer obeys unchecked and ununchecked.
            try
            {
                unchecked
                {
                    int result = 1;
                    for (int i = 2; i <= N; i++) result *= i;
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        private string LongFactorialUnchecked(long N)
        {
            // Long obeys unchecked and ununchecked.
            try
            {
                unchecked
                {
                    long result = 1;
                    for (long i = 2; i <= N; i++) result *= i;
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        private string DecimalFactorialUnchecked(decimal N)
        {
            // Decimal ignores unchecked and ununchecked
            // and always throws OverflowException.
            try
            {
                unchecked
                {
                    decimal result = 1;
                    for (decimal i = 2; i <= N; i++) result *= i;
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        // Floats and doubles ignore unchecked and return Infinity.
        private string FloatFactorialUnchecked(float N)
        {
            unchecked
            {
                float result = 1;
                for (float i = 2; i <= N; i++) result *= i;
                if (float.IsInfinity(result)) return "Infinity";
                return result.ToString();
            }
        }
        private string DoubleFactorialUnchecked(double N)
        {
            unchecked
            {
                double result = 1;
                for (double i = 2; i <= N; i++) result *= i;
                if (double.IsInfinity(result)) return "Infinity";
                return result.ToString();
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtN = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInteger = new System.Windows.Forms.TextBox();
            this.txtLong = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFloat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDecimal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDouble = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDoubleChecked = new System.Windows.Forms.TextBox();
            this.txtFloatChecked = new System.Windows.Forms.TextBox();
            this.txtDecimalChecked = new System.Windows.Forms.TextBox();
            this.txtLongChecked = new System.Windows.Forms.TextBox();
            this.txtIntegerChecked = new System.Windows.Forms.TextBox();
            this.txtDoubleUnchecked = new System.Windows.Forms.TextBox();
            this.txtFloatUnchecked = new System.Windows.Forms.TextBox();
            this.txtDecimalUnchecked = new System.Windows.Forms.TextBox();
            this.txtLongUnchecked = new System.Windows.Forms.TextBox();
            this.txtIntegerUnchecked = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "N";
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(33, 14);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(38, 20);
            this.txtN.TabIndex = 1;
            this.txtN.Text = "50";
            this.txtN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(77, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Integer";
            // 
            // txtInteger
            // 
            this.txtInteger.Location = new System.Drawing.Point(69, 87);
            this.txtInteger.Name = "txtInteger";
            this.txtInteger.ReadOnly = true;
            this.txtInteger.Size = new System.Drawing.Size(203, 20);
            this.txtInteger.TabIndex = 4;
            this.txtInteger.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLong
            // 
            this.txtLong.Location = new System.Drawing.Point(69, 113);
            this.txtLong.Name = "txtLong";
            this.txtLong.ReadOnly = true;
            this.txtLong.Size = new System.Drawing.Size(203, 20);
            this.txtLong.TabIndex = 6;
            this.txtLong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Long";
            // 
            // txtFloat
            // 
            this.txtFloat.Location = new System.Drawing.Point(69, 165);
            this.txtFloat.Name = "txtFloat";
            this.txtFloat.ReadOnly = true;
            this.txtFloat.Size = new System.Drawing.Size(203, 20);
            this.txtFloat.TabIndex = 10;
            this.txtFloat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Float";
            // 
            // txtDecimal
            // 
            this.txtDecimal.Location = new System.Drawing.Point(69, 139);
            this.txtDecimal.Name = "txtDecimal";
            this.txtDecimal.ReadOnly = true;
            this.txtDecimal.Size = new System.Drawing.Size(203, 20);
            this.txtDecimal.TabIndex = 8;
            this.txtDecimal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Decimal";
            // 
            // txtDouble
            // 
            this.txtDouble.Location = new System.Drawing.Point(69, 191);
            this.txtDouble.Name = "txtDouble";
            this.txtDouble.ReadOnly = true;
            this.txtDouble.Size = new System.Drawing.Size(203, 20);
            this.txtDouble.TabIndex = 12;
            this.txtDouble.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Double";
            // 
            // txtDoubleChecked
            // 
            this.txtDoubleChecked.Location = new System.Drawing.Point(278, 191);
            this.txtDoubleChecked.Name = "txtDoubleChecked";
            this.txtDoubleChecked.ReadOnly = true;
            this.txtDoubleChecked.Size = new System.Drawing.Size(203, 20);
            this.txtDoubleChecked.TabIndex = 17;
            this.txtDoubleChecked.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFloatChecked
            // 
            this.txtFloatChecked.Location = new System.Drawing.Point(278, 165);
            this.txtFloatChecked.Name = "txtFloatChecked";
            this.txtFloatChecked.ReadOnly = true;
            this.txtFloatChecked.Size = new System.Drawing.Size(203, 20);
            this.txtFloatChecked.TabIndex = 16;
            this.txtFloatChecked.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDecimalChecked
            // 
            this.txtDecimalChecked.Location = new System.Drawing.Point(278, 139);
            this.txtDecimalChecked.Name = "txtDecimalChecked";
            this.txtDecimalChecked.ReadOnly = true;
            this.txtDecimalChecked.Size = new System.Drawing.Size(203, 20);
            this.txtDecimalChecked.TabIndex = 15;
            this.txtDecimalChecked.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLongChecked
            // 
            this.txtLongChecked.Location = new System.Drawing.Point(278, 113);
            this.txtLongChecked.Name = "txtLongChecked";
            this.txtLongChecked.ReadOnly = true;
            this.txtLongChecked.Size = new System.Drawing.Size(203, 20);
            this.txtLongChecked.TabIndex = 14;
            this.txtLongChecked.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIntegerChecked
            // 
            this.txtIntegerChecked.Location = new System.Drawing.Point(278, 87);
            this.txtIntegerChecked.Name = "txtIntegerChecked";
            this.txtIntegerChecked.ReadOnly = true;
            this.txtIntegerChecked.Size = new System.Drawing.Size(203, 20);
            this.txtIntegerChecked.TabIndex = 13;
            this.txtIntegerChecked.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDoubleUnchecked
            // 
            this.txtDoubleUnchecked.Location = new System.Drawing.Point(487, 191);
            this.txtDoubleUnchecked.Name = "txtDoubleUnchecked";
            this.txtDoubleUnchecked.ReadOnly = true;
            this.txtDoubleUnchecked.Size = new System.Drawing.Size(203, 20);
            this.txtDoubleUnchecked.TabIndex = 22;
            this.txtDoubleUnchecked.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFloatUnchecked
            // 
            this.txtFloatUnchecked.Location = new System.Drawing.Point(487, 165);
            this.txtFloatUnchecked.Name = "txtFloatUnchecked";
            this.txtFloatUnchecked.ReadOnly = true;
            this.txtFloatUnchecked.Size = new System.Drawing.Size(203, 20);
            this.txtFloatUnchecked.TabIndex = 21;
            this.txtFloatUnchecked.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDecimalUnchecked
            // 
            this.txtDecimalUnchecked.Location = new System.Drawing.Point(487, 139);
            this.txtDecimalUnchecked.Name = "txtDecimalUnchecked";
            this.txtDecimalUnchecked.ReadOnly = true;
            this.txtDecimalUnchecked.Size = new System.Drawing.Size(203, 20);
            this.txtDecimalUnchecked.TabIndex = 20;
            this.txtDecimalUnchecked.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLongUnchecked
            // 
            this.txtLongUnchecked.Location = new System.Drawing.Point(487, 113);
            this.txtLongUnchecked.Name = "txtLongUnchecked";
            this.txtLongUnchecked.ReadOnly = true;
            this.txtLongUnchecked.Size = new System.Drawing.Size(203, 20);
            this.txtLongUnchecked.TabIndex = 19;
            this.txtLongUnchecked.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIntegerUnchecked
            // 
            this.txtIntegerUnchecked.Location = new System.Drawing.Point(487, 87);
            this.txtIntegerUnchecked.Name = "txtIntegerUnchecked";
            this.txtIntegerUnchecked.ReadOnly = true;
            this.txtIntegerUnchecked.Size = new System.Drawing.Size(203, 20);
            this.txtIntegerUnchecked.TabIndex = 18;
            this.txtIntegerUnchecked.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(66, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(206, 23);
            this.label7.TabIndex = 23;
            this.label7.Text = "Default";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(278, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(206, 23);
            this.label8.TabIndex = 24;
            this.label8.Text = "Checked";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(484, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(206, 23);
            this.label9.TabIndex = 25;
            this.label9.Text = "Unchecked";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_checked_unchecked_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 224);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDoubleUnchecked);
            this.Controls.Add(this.txtFloatUnchecked);
            this.Controls.Add(this.txtDecimalUnchecked);
            this.Controls.Add(this.txtLongUnchecked);
            this.Controls.Add(this.txtIntegerUnchecked);
            this.Controls.Add(this.txtDoubleChecked);
            this.Controls.Add(this.txtFloatChecked);
            this.Controls.Add(this.txtDecimalChecked);
            this.Controls.Add(this.txtLongChecked);
            this.Controls.Add(this.txtIntegerChecked);
            this.Controls.Add(this.txtDouble);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFloat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDecimal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInteger);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.label1);
            this.Name = "howto_checked_unchecked_Form1";
            this.Text = "howto_checked_unchecked";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInteger;
        private System.Windows.Forms.TextBox txtLong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFloat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDecimal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDouble;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDoubleChecked;
        private System.Windows.Forms.TextBox txtFloatChecked;
        private System.Windows.Forms.TextBox txtDecimalChecked;
        private System.Windows.Forms.TextBox txtLongChecked;
        private System.Windows.Forms.TextBox txtIntegerChecked;
        private System.Windows.Forms.TextBox txtDoubleUnchecked;
        private System.Windows.Forms.TextBox txtFloatUnchecked;
        private System.Windows.Forms.TextBox txtDecimalUnchecked;
        private System.Windows.Forms.TextBox txtLongUnchecked;
        private System.Windows.Forms.TextBox txtIntegerUnchecked;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

