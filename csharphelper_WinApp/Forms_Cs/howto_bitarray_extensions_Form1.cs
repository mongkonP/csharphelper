using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;

 

using howto_bitarray_extensions;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_bitarray_extensions_Form1:Form
  { 


        public howto_bitarray_extensions_Form1()
        {
            InitializeComponent();
        }

        // Demonstrate BitArray extensions.
        private void howto_bitarray_extensions_Form1_Load(object sender, EventArgs e)
        {
            // Make a BitArray holding IsSquare Xor IsFibonacci.
            BitArray bits = new BitArray(32);
            for (int i = 0; i < bits.Length; i++)
                bits[i] = (IsSquare(i) ^ IsFibonacci(i));

            // Display the result in various ways.
            string txt = "";
            txt += "# True: " + bits.NumTrue() + ", " +
                "# False: " + bits.NumFalse() + ", " +
                "AndAll: " + bits.AndAll() + ", " +
                "OrAll: " + bits.OrAll() +
                "\r\n";
            txt += bits.ToString("T", " ") + "\r\n";
            txt += bits.ToString("X", ".") + "\r\n";
            txt += bits.ToString("1", "0", "", 8, " ") + "\r\n";
            txt += bits.ToString("TRUE", "false", " ");
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
            this.txtBits.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBits.Size = new System.Drawing.Size(420, 128);
            this.txtBits.TabIndex = 1;
            this.txtBits.WordWrap = false;
            // 
            // howto_bitarray_extensions_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 152);
            this.Controls.Add(this.txtBits);
            this.Name = "howto_bitarray_extensions_Form1";
            this.Text = "howto_bitarray_extensions";
            this.Load += new System.EventHandler(this.howto_bitarray_extensions_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBits;
    }
}

