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
     public partial class howto_use_bit_operations_Form1:Form
  { 


        public howto_use_bit_operations_Form1()
        {
            InitializeComponent();
        }

        private void howto_use_bit_operations_Form1_Load(object sender, EventArgs e)
        {
            int A = Convert.ToInt32("11111111000000001111111100000000", 2);
            int B = Convert.ToInt32("11111111111111110000000000000000", 2);
            txtA.Text = BinaryString(A, 32);
            txtB.Text = BinaryString(B, 32);

            Calculate();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        // Perform the bitwise calculations.
        private void Calculate()
        {
            // Get A, B, and C.
            int A = Convert.ToInt32(txtA.Text, 2);
            int B = Convert.ToInt32(txtB.Text, 2);
            int C = int.Parse(txtC.Text);

            // Calculate and display results.
            // Not.
            int notA = ~A;
            txtNotA.Text = BinaryString(notA, 32);

            // A or B.
            int AorB = A | B;
            txtAorB.Text = BinaryString(AorB, 32);

            // A and B.
            int AandB = A & B;
            txtAandB.Text = BinaryString(AandB, 32);

            // A xor B.
            int AxorB = A ^ B;
            txtAxorB.Text = BinaryString(AxorB, 32);

            // A << C.
            int left_shift = A << C;
            txtLeftShift.Text = BinaryString(left_shift, 32);

            // A >> C.
            int right_shift = A >> C;
            txtRightShift.Text = BinaryString(right_shift, 32);
        }

        // Return a binary string representing the number,
        // padded with 0s on the left to the indicated number of bits.
        private string BinaryString(long value, int num_bits)
        {
            // Get the binary string.
            string result = Convert.ToString(value, 2);

            // Pad if necessary.
            result = result.PadLeft(num_bits, '0');

            // Trim to length if necessary.
            return result.Substring(result.Length - num_bits);
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
            this.txtRightShift = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLeftShift = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtC = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAorB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNotA = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAxorB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAandB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.txtB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRightShift
            // 
            this.txtRightShift.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRightShift.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRightShift.Location = new System.Drawing.Point(56, 248);
            this.txtRightShift.Name = "txtRightShift";
            this.txtRightShift.ReadOnly = true;
            this.txtRightShift.Size = new System.Drawing.Size(257, 20);
            this.txtRightShift.TabIndex = 46;
            this.txtRightShift.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 55;
            this.label8.Text = "A >> C";
            // 
            // txtLeftShift
            // 
            this.txtLeftShift.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLeftShift.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeftShift.Location = new System.Drawing.Point(56, 222);
            this.txtLeftShift.Name = "txtLeftShift";
            this.txtLeftShift.ReadOnly = true;
            this.txtLeftShift.Size = new System.Drawing.Size(257, 20);
            this.txtLeftShift.TabIndex = 45;
            this.txtLeftShift.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 225);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 54;
            this.label9.Text = "A << C";
            // 
            // txtC
            // 
            this.txtC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtC.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtC.Location = new System.Drawing.Point(271, 63);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(42, 20);
            this.txtC.TabIndex = 39;
            this.txtC.Text = "3";
            this.txtC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 53;
            this.label7.Text = "C:";
            // 
            // txtAorB
            // 
            this.txtAorB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAorB.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAorB.Location = new System.Drawing.Point(56, 144);
            this.txtAorB.Name = "txtAorB";
            this.txtAorB.ReadOnly = true;
            this.txtAorB.Size = new System.Drawing.Size(257, 20);
            this.txtAorB.TabIndex = 42;
            this.txtAorB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 52;
            this.label5.Text = "A | B";
            // 
            // txtNotA
            // 
            this.txtNotA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotA.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotA.Location = new System.Drawing.Point(56, 118);
            this.txtNotA.Name = "txtNotA";
            this.txtNotA.ReadOnly = true;
            this.txtNotA.Size = new System.Drawing.Size(257, 20);
            this.txtNotA.TabIndex = 41;
            this.txtNotA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "~A";
            // 
            // txtAxorB
            // 
            this.txtAxorB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAxorB.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAxorB.Location = new System.Drawing.Point(56, 196);
            this.txtAxorB.Name = "txtAxorB";
            this.txtAxorB.ReadOnly = true;
            this.txtAxorB.Size = new System.Drawing.Size(257, 20);
            this.txtAxorB.TabIndex = 44;
            this.txtAxorB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "A ^ B";
            // 
            // txtAandB
            // 
            this.txtAandB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAandB.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAandB.Location = new System.Drawing.Point(56, 170);
            this.txtAandB.Name = "txtAandB";
            this.txtAandB.ReadOnly = true;
            this.txtAandB.Size = new System.Drawing.Size(257, 20);
            this.txtAandB.TabIndex = 43;
            this.txtAandB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "A && B";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCalculate.Location = new System.Drawing.Point(124, 89);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 40;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // txtB
            // 
            this.txtB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtB.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtB.Location = new System.Drawing.Point(56, 37);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(257, 20);
            this.txtB.TabIndex = 38;
            this.txtB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "B:";
            // 
            // txtA
            // 
            this.txtA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtA.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtA.Location = new System.Drawing.Point(56, 11);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(257, 20);
            this.txtA.TabIndex = 37;
            this.txtA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "A:";
            // 
            // howto_use_bit_operations_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 279);
            this.Controls.Add(this.txtRightShift);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtLeftShift);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtAorB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNotA);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAxorB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAandB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.label1);
            this.Name = "howto_use_bit_operations_Form1";
            this.Text = "howto_use_bit_operations";
            this.Load += new System.EventHandler(this.howto_use_bit_operations_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRightShift;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLeftShift;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAorB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNotA;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAxorB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAandB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.Label label1;
    }
}

