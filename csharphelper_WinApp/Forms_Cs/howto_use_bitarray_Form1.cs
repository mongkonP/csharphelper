using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_use_bitarray_Form1:Form
  { 


        public howto_use_bitarray_Form1()
        {
            InitializeComponent();
        }

        // Demonstrate the BitArray class.
        private void howto_use_bitarray_Form1_Load(object sender, EventArgs e)
        {
            string txt = "";

            // Set all bits to true then false.
            BitArray bits = new BitArray(32);
            bits.SetAll(true);
            txt += "True:       " + BitArrayToString(bits) + "\r\n";
            bits.SetAll(false);
            txt += "False:      " + BitArrayToString(bits) + "\r\n";

            // Set bits[i] true if i is a Fibonacci number.
            BitArray is_fibonacci = new BitArray(bits.Length);
            for (int i = 0; i < bits.Length; i++)
                is_fibonacci[i] = IsFibonacci(i);
            txt += "Fibonacci:  " +
                BitArrayToString(is_fibonacci) + "\r\n";

            // Invert the bits.
            is_fibonacci.Not();
            for (int i = 0; i < bits.Length; i++)
                bits[i] = IsFibonacci(i);
            txt += "~Fibonacci: " +
                BitArrayToString(is_fibonacci) + "\r\n";

            // Set a bit true if i is a perfect square.
            BitArray is_square = new BitArray(bits.Length);
            for (int i = 0; i < bits.Length; i++)
                is_square[i] = IsSquare(i);
            txt += "Square:     " +
                BitArrayToString(is_square) + "\r\n";

            // And with is_square.
            BitArray sqaure_and_not_fibonacci =
                is_square.And(is_fibonacci);
            is_fibonacci.Not();
            for (int i = 0; i < bits.Length; i++)
                bits[i] = IsFibonacci(i);
            txt += "Sq && ~Fib: " +
                BitArrayToString(sqaure_and_not_fibonacci);

            // Display the results.
            txtBits.Text = txt;
            txtBits.Select(0, 0);
        }

        // Return true if i is a perfect square.
        private bool IsSquare(int i)
        {
            int sqrt_i = (int)Math.Sqrt(i);
            return (sqrt_i * sqrt_i == i);
        }

        // Return true if i is a Fibonacci number.
        private bool IsFibonacci(int i)
        {
            if (i == 0) return true;

            long fib_i_minus_1 = 0;
            long fib_i = 1;
            while (fib_i < i)
            {
                long fib_i_plus_1 = fib_i + fib_i_minus_1;
                fib_i_minus_1 = fib_i;
                fib_i = fib_i_plus_1;
            }
            return (i == fib_i);
        }

        // Return a string showing the BitArray's values.
        private string BitArrayToString(BitArray bits)
        {
            string result = "";
            foreach (bool value in bits)
            {
                if (value) result += "1";
                else result += "0";
            }
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
            this.txtBits = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtBits
            // 
            this.txtBits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBits.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBits.Location = new System.Drawing.Point(12, 12);
            this.txtBits.Multiline = true;
            this.txtBits.Name = "txtBits";
            this.txtBits.ReadOnly = true;
            this.txtBits.Size = new System.Drawing.Size(321, 107);
            this.txtBits.TabIndex = 1;
            // 
            // howto_use_bitarray_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 131);
            this.Controls.Add(this.txtBits);
            this.Name = "howto_use_bitarray_Form1";
            this.Text = "howto_use_bitarray";
            this.Load += new System.EventHandler(this.howto_use_bitarray_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBits;
    }
}

