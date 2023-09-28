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
     public partial class howto_bitwise_operators_Form1:Form
  { 


        public howto_bitwise_operators_Form1()
        {
            InitializeComponent();
        }

        private void howto_bitwise_operators_Form1_Load(object sender, EventArgs e)
        {
            cboOperator.SelectedIndex = 0;
        }

        private void cboOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void Calculate()
        {
            txtResult.Clear();
            txtDecimalOperand2.Clear();
            txtDecimalOperand1.Clear();
            txtDecimalResult.Clear();

            try
            {
                // Convert the binary inputs into integers.
                int operand1 = Convert.ToInt32(txtOperand1.Text, 2);
                int operand2 = Convert.ToInt32(txtOperand2.Text, 2);

                // Calculate the result.
                int result = 0;
                switch (cboOperator.Text)
                {
                    case "&":
                        result = (operand1 & operand2);
                        break;
                    case "|":
                        result = (operand1 | operand2);
                        break;
                    case "^":
                        result = (operand1 ^ operand2);
                        break;
                    case "<<":
                        result = (operand1 << operand2);
                        break;
                    case ">>":
                        result = (operand1 >> operand2);
                        break;
                    case "~":
                        result = ~operand1;
                        break;
                }

                // Display the result in binary.
                txtResult.Text = Convert.ToString(result, 2);

                // Show the values in decimal.
                txtDecimalOperand1.Text = operand1.ToString();
                txtDecimalOperand2.Text = operand2.ToString();
                txtDecimalResult.Text = result.ToString();
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
            this.txtOperand1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOperand2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboOperator = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtDecimalOperand2 = new System.Windows.Forms.TextBox();
            this.txtDecimalOperand1 = new System.Windows.Forms.TextBox();
            this.txtDecimalResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtOperand1
            // 
            this.txtOperand1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOperand1.Location = new System.Drawing.Point(78, 12);
            this.txtOperand1.Name = "txtOperand1";
            this.txtOperand1.Size = new System.Drawing.Size(206, 20);
            this.txtOperand1.TabIndex = 0;
            this.txtOperand1.Text = "01100101";
            this.txtOperand1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOperand1.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Operand 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Operand 2:";
            // 
            // txtOperand2
            // 
            this.txtOperand2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOperand2.Location = new System.Drawing.Point(78, 38);
            this.txtOperand2.Name = "txtOperand2";
            this.txtOperand2.Size = new System.Drawing.Size(206, 20);
            this.txtOperand2.TabIndex = 2;
            this.txtOperand2.Text = "11011001";
            this.txtOperand2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOperand2.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Operator:";
            // 
            // cboOperator
            // 
            this.cboOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperator.FormattingEnabled = true;
            this.cboOperator.Items.AddRange(new object[] {
            "&",
            "|",
            "^",
            "<<",
            ">>",
            "~"});
            this.cboOperator.Location = new System.Drawing.Point(156, 64);
            this.cboOperator.Name = "cboOperator";
            this.cboOperator.Size = new System.Drawing.Size(49, 21);
            this.cboOperator.TabIndex = 5;
            this.cboOperator.SelectedIndexChanged += new System.EventHandler(this.cboOperator_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Result:";
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(78, 127);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(206, 20);
            this.txtResult.TabIndex = 7;
            this.txtResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDecimalOperand2
            // 
            this.txtDecimalOperand2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDecimalOperand2.Location = new System.Drawing.Point(290, 38);
            this.txtDecimalOperand2.Name = "txtDecimalOperand2";
            this.txtDecimalOperand2.Size = new System.Drawing.Size(77, 20);
            this.txtDecimalOperand2.TabIndex = 9;
            this.txtDecimalOperand2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDecimalOperand1
            // 
            this.txtDecimalOperand1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDecimalOperand1.Location = new System.Drawing.Point(290, 12);
            this.txtDecimalOperand1.Name = "txtDecimalOperand1";
            this.txtDecimalOperand1.Size = new System.Drawing.Size(77, 20);
            this.txtDecimalOperand1.TabIndex = 8;
            this.txtDecimalOperand1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDecimalResult
            // 
            this.txtDecimalResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDecimalResult.Location = new System.Drawing.Point(290, 127);
            this.txtDecimalResult.Name = "txtDecimalResult";
            this.txtDecimalResult.Size = new System.Drawing.Size(77, 20);
            this.txtDecimalResult.TabIndex = 10;
            this.txtDecimalResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // howto_bitwise_operators_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 165);
            this.Controls.Add(this.txtDecimalResult);
            this.Controls.Add(this.txtDecimalOperand2);
            this.Controls.Add(this.txtDecimalOperand1);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboOperator);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOperand2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOperand1);
            this.Name = "howto_bitwise_operators_Form1";
            this.Text = "howto_bitwise_operators";
            this.Load += new System.EventHandler(this.howto_bitwise_operators_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOperand1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOperand2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboOperator;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtDecimalOperand2;
        private System.Windows.Forms.TextBox txtDecimalOperand1;
        private System.Windows.Forms.TextBox txtDecimalResult;
    }
}

