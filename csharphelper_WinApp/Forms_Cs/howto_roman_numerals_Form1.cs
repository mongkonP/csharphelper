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
     public partial class howto_roman_numerals_Form1:Form
  { 


        public howto_roman_numerals_Form1()
        {
            InitializeComponent();
        }

        // Convert.
        private void btnConvert_Click(object sender, EventArgs e)
        {
            // See if we have an Arabic or Roman input.
            if (txtArabic.Text.Length > 0)
            {
                int arabic = int.Parse(txtArabic.Text);
                string roman = ArabicToRoman(arabic);
                int recovered = RomanToArabic(roman);

                txtRecoveredRoman.Text = roman;
                txtRecoveredArabic.Text = recovered.ToString();
            }
            else
            {
                string roman = txtRoman.Text;
                int arabic = RomanToArabic(roman);
                string recovered = ArabicToRoman(arabic);

                txtRecoveredRoman.Text = recovered;
                txtRecoveredArabic.Text = arabic.ToString();
            }

            txtArabic.Clear();
            txtRoman.Clear();
        }

        // Maps letters to numbers.
        private Dictionary<char, int> CharValues = null;

        // Convert Roman numerals to an integer.
        private int RomanToArabic(string roman)
        {
            // Initialize the letter map.
            if (CharValues == null)
            {
                CharValues = new Dictionary<char, int>();
                CharValues.Add('I', 1);
                CharValues.Add('V', 5);
                CharValues.Add('X', 10);
                CharValues.Add('L', 50);
                CharValues.Add('C', 100);
                CharValues.Add('D', 500);
                CharValues.Add('M', 1000);
            }

            if (roman.Length == 0) return 0;
            roman = roman.ToUpper();

            // See if the number begins with (.
            if (roman[0] == '(')
            {
                // Find the closing parenthesis.
                int pos = roman.LastIndexOf(')');

                // Get the value inside the parentheses.
                string part1 = roman.Substring(1, pos - 1);
                string part2 = roman.Substring(pos + 1);
                return 1000 * RomanToArabic(part1) + RomanToArabic(part2);
            }

            // The number doesn't begin with (.
            // Convert the letters' values.
            int total = 0;
            int last_value = 0;
            for (int i = roman.Length - 1; i >= 0; i--)
            {
                int new_value = CharValues[roman[i]];

                // See if we should add or subtract.
                if (new_value < last_value)
                    total -= new_value;
                else
                {
                    total += new_value;
                    last_value = new_value;
                }
            }

            // Return the result.
            return total;
        }

        // Map digits to letters.
        private string[] ThouLetters = { "", "M", "MM", "MMM" };
        private string[] HundLetters = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        private string[] TensLetters = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        private string[] OnesLetters = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
        
        // Convert Roman numerals to an integer.
        private string ArabicToRoman(int arabic)
        {
            // See if it's >= 4000.
            if (arabic >= 4000)
            {
                // Use parentheses.
                int thou = arabic / 1000;
                arabic %= 1000;
                return "(" + ArabicToRoman(thou) + ")" + ArabicToRoman(arabic);
            }

            // Otherwise process the letters.
            string result = "";

            // Pull out thousands.
            int num;
            num = arabic / 1000;
            result += ThouLetters[num];
            arabic %= 1000;

            // Handle hundreds.
            num = arabic / 100;
            result += HundLetters[num];
            arabic %= 100;

            // Handle tens.
            num = arabic / 10;
            result += TensLetters[num];
            arabic %= 10;

            // Handle ones.
            result += OnesLetters[arabic];

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
            this.txtArabic = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.txtRoman = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRecoveredArabic = new System.Windows.Forms.TextBox();
            this.txtRecoveredRoman = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtArabic
            // 
            this.txtArabic.Location = new System.Drawing.Point(15, 25);
            this.txtArabic.Name = "txtArabic";
            this.txtArabic.Size = new System.Drawing.Size(129, 20);
            this.txtArabic.TabIndex = 0;
            this.txtArabic.Text = "1984";
            this.txtArabic.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Arabic:";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(109, 51);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 2;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // txtRoman
            // 
            this.txtRoman.AcceptsReturn = true;
            this.txtRoman.Location = new System.Drawing.Point(150, 25);
            this.txtRoman.Name = "txtRoman";
            this.txtRoman.Size = new System.Drawing.Size(129, 20);
            this.txtRoman.TabIndex = 1;
            this.txtRoman.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(147, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Roman:";
            // 
            // txtRecoveredArabic
            // 
            this.txtRecoveredArabic.Location = new System.Drawing.Point(15, 80);
            this.txtRecoveredArabic.Name = "txtRecoveredArabic";
            this.txtRecoveredArabic.ReadOnly = true;
            this.txtRecoveredArabic.Size = new System.Drawing.Size(129, 20);
            this.txtRecoveredArabic.TabIndex = 3;
            this.txtRecoveredArabic.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtRecoveredRoman
            // 
            this.txtRecoveredRoman.Location = new System.Drawing.Point(150, 80);
            this.txtRecoveredRoman.Name = "txtRecoveredRoman";
            this.txtRecoveredRoman.ReadOnly = true;
            this.txtRecoveredRoman.Size = new System.Drawing.Size(129, 20);
            this.txtRecoveredRoman.TabIndex = 4;
            this.txtRecoveredRoman.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // howto_roman_numerals_Form1
            // 
            this.AcceptButton = this.btnConvert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 118);
            this.Controls.Add(this.txtRecoveredRoman);
            this.Controls.Add(this.txtRecoveredArabic);
            this.Controls.Add(this.txtRoman);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.txtArabic);
            this.Controls.Add(this.label2);
            this.Name = "howto_roman_numerals_Form1";
            this.Text = "howto_roman_numerals";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtArabic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.TextBox txtRoman;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRecoveredArabic;
        private System.Windows.Forms.TextBox txtRecoveredRoman;
    }
}

