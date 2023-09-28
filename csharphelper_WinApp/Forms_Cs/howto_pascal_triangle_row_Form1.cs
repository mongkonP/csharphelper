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
     public partial class howto_pascal_triangle_row_Form1:Form
  { 


        public howto_pascal_triangle_row_Form1()
        {
            InitializeComponent();
        }

        // See https://en.wikipedia.org/wiki/Pascal's_triangle#Calculating_a_row_or_diagonal_by_itself
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Get the values for the selected row.
            long row_number = long.Parse(txtRowNumber.Text);
            List<long> values = PascalRow(row_number);

            // Display the results.
            string txt = "";
            foreach (long value in values)
                txt += value.ToString() + ", ";
            txtResults.Text = txt.Substring(0, txt.Length - 2);
        }

        // Return the coefficients in a row of Pascal's triangle.
        private List<long> PascalRow(long row_number)
        {
            checked
            {
                long n = row_number;

                // Make the results as a list of long.
                List<long> results = new List<long>();
                long value = 1;
                results.Add(value);

                // Calculate the values.
                for (int k = 1; k <= n; k++)
                {
                    value = (value * (n + 1 - k)) / k;
                    results.Add(value);
                }

                return results;
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
            this.txtRowNumber = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Row #:";
            // 
            // txtRowNumber
            // 
            this.txtRowNumber.Location = new System.Drawing.Point(60, 14);
            this.txtRowNumber.Name = "txtRowNumber";
            this.txtRowNumber.Size = new System.Drawing.Size(43, 20);
            this.txtRowNumber.TabIndex = 1;
            this.txtRowNumber.Text = "10";
            this.txtRowNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(143, 12);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 2;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // txtResults
            // 
            this.txtResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResults.Location = new System.Drawing.Point(15, 78);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ReadOnly = true;
            this.txtResults.Size = new System.Drawing.Size(307, 71);
            this.txtResults.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Results:";
            // 
            // howto_pascal_triangle_row_Form1
            // 
            this.AcceptButton = this.btnCalculate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 161);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtRowNumber);
            this.Controls.Add(this.label1);
            this.Name = "howto_pascal_triangle_row_Form1";
            this.Text = "howto_pascal_triangle_row";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRowNumber;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.Label label2;
    }
}

