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
     public partial class howto_convert_excel_column_numbers_Form1:Form
  { 


        public howto_convert_excel_column_numbers_Form1()
        {
            InitializeComponent();
        }

        // Convert to column number and back.
        private void txtLetter_TextChanged(object sender, EventArgs e)
        {
            // Don't bother if there's no text.
            if (txtLetter.Text.Length < 1) return;

            // Convert to a number.
            int col_num = ColumnNameToNumber(txtLetter.Text);

            // Convert back.
            string col_name = ColumnNumberToName(col_num);

            txtNumber.Text = col_num.ToString();
            txtNewLetter.Text = col_name;
        }

        // Return the column number for this column name.
        private int ColumnNameToNumber(string col_name)
        {
            int result = 0;

            // Process each letter.
            for (int i = 0; i < col_name.Length; i++)
            {
                result *= 26;
                char letter = col_name[i];

                // See if it's out of bounds.
                if (letter < 'A') letter = 'A';
                if (letter > 'Z') letter = 'Z';

                // Add in the value of this letter.
                result += (int)letter - (int)'A' + 1;
            }
            return result;
        }

        // Return the column name for this column number.
        private string ColumnNumberToName(int col_num)
        {
            // See if it's out of bounds.
            if (col_num < 1) return "A";

            // Calculate the letters.
            string result = "";
            while (col_num > 0)
            {
                // Get the least significant digit.
                col_num -= 1;
                int digit = col_num % 26;

                // Convert the digit into a letter.
                result = (char)((int)'A' + digit) + result;

                col_num = (int)(col_num / 26);
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
            this.txtNewLetter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLetter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNewLetter
            // 
            this.txtNewLetter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNewLetter.Location = new System.Drawing.Point(205, 70);
            this.txtNewLetter.Name = "txtNewLetter";
            this.txtNewLetter.ReadOnly = true;
            this.txtNewLetter.Size = new System.Drawing.Size(42, 20);
            this.txtNewLetter.TabIndex = 11;
            this.txtNewLetter.Text = "A";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Letter:";
            // 
            // txtNumber
            // 
            this.txtNumber.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNumber.Location = new System.Drawing.Point(205, 44);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.ReadOnly = true;
            this.txtNumber.Size = new System.Drawing.Size(42, 20);
            this.txtNumber.TabIndex = 9;
            this.txtNumber.Text = "A";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Number:";
            // 
            // txtLetter
            // 
            this.txtLetter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLetter.Location = new System.Drawing.Point(205, 18);
            this.txtLetter.Name = "txtLetter";
            this.txtLetter.Size = new System.Drawing.Size(42, 20);
            this.txtLetter.TabIndex = 7;
            this.txtLetter.Text = "A";
            this.txtLetter.TextChanged += new System.EventHandler(this.txtLetter_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Letter:";
            // 
            // howto_convert_excel_column_numbers_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 108);
            this.Controls.Add(this.txtNewLetter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLetter);
            this.Controls.Add(this.label1);
            this.Name = "howto_convert_excel_column_numbers_Form1";
            this.Text = "howto_convert_excel_column_numbers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNewLetter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLetter;
        private System.Windows.Forms.Label label1;
    }
}

