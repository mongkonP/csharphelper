using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_display_significant_digits;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_display_significant_digits_Form1:Form
  { 


        public howto_display_significant_digits_Form1()
        {
            InitializeComponent();
        }

        // Display the result.
        private void howto_display_significant_digits_Form1_Load(object sender, EventArgs e)
        {
            DisplayResult();
        }
        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            DisplayResult();
        }
        private void nudDigits_ValueChanged(object sender, EventArgs e)
        {
            DisplayResult();
        }

        // Display the result.
        private void DisplayResult()
        {
            txtResult.Clear();
            txtGFormat.Clear();
            try
            {
                double number = double.Parse(txtNumber.Text);
                int num_digits = (int)nudDigits.Value;
                txtResult.Text = number.ToSignificantDigits(num_digits);

                string format = "{0:G" + num_digits.ToString() + "}";
                txtGFormat.Text = String.Format(format, number);
            }
            catch
            {
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
            this.txtGFormat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudDigits = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudDigits)).BeginInit();
            this.SuspendLayout();
            // 
            // txtGFormat
            // 
            this.txtGFormat.Location = new System.Drawing.Point(172, 130);
            this.txtGFormat.Name = "txtGFormat";
            this.txtGFormat.ReadOnly = true;
            this.txtGFormat.Size = new System.Drawing.Size(109, 20);
            this.txtGFormat.TabIndex = 15;
            this.txtGFormat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "G Format:";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(172, 104);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(109, 20);
            this.txtResult.TabIndex = 13;
            this.txtResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "ToSignificantDigits:";
            // 
            // nudDigits
            // 
            this.nudDigits.Location = new System.Drawing.Point(172, 38);
            this.nudDigits.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudDigits.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDigits.Name = "nudDigits";
            this.nudDigits.Size = new System.Drawing.Size(46, 20);
            this.nudDigits.TabIndex = 11;
            this.nudDigits.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.nudDigits.ValueChanged += new System.EventHandler(this.nudDigits_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "# Significant Digits:";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(172, 12);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(109, 20);
            this.txtNumber.TabIndex = 9;
            this.txtNumber.Text = "10.012345";
            this.txtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumber.TextChanged += new System.EventHandler(this.txtNumber_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Number:";
            // 
            // howto_display_significant_digits_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 163);
            this.Controls.Add(this.txtGFormat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudDigits);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.label1);
            this.Name = "howto_display_significant_digits_Form1";
            this.Text = "howto_display_significant_digits";
            this.Load += new System.EventHandler(this.howto_display_significant_digits_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudDigits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGFormat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudDigits;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label1;
    }
}

