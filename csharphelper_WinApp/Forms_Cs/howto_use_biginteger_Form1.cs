using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Add a reference to System.Numerics.
using System.Numerics;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_use_biginteger_Form1:Form
  { 


        public howto_use_biginteger_Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            long N;
            if (!long.TryParse(txtN.Text, out N))
            {
                MessageBox.Show("N must be an integer.");
                txtN.Focus();
                return;
            }

            checked
            {
                try
                {
                    txtLongFactorial.Text = LongFactorial(N).ToString();
                }
                catch (Exception ex)
                {
                    txtLongFactorial.Text = ex.Message;
                }
            }
            txtBigIntegerFactorial.Text = BigFactorial(N).ToString();
        }

        // Return N!.
        private BigInteger BigFactorial(BigInteger N)
        {
            if (N < 0) throw new ArgumentException("N must be at leaat 0.");
            if (N <= 1) return 1;
            BigInteger result = 1;
            for (int i = 2; i <= N; i++) result *= i;
            return result;
        }

        // Return N!.
        private long LongFactorial(long N)
        {
            if (N < 0) throw new ArgumentException("N must be at leaat 0.");
            if (N <= 1) return 1;
            checked
            {
                long result = 1;
                for (int i = 2; i <= N; i++) result *= i;
                return result;
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtBigIntegerFactorial = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.txtLongFactorial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "N:";
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(36, 14);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(34, 20);
            this.txtN.TabIndex = 0;
            this.txtN.Text = "30";
            this.txtN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "BigInteger:";
            // 
            // txtBigIntegerFactorial
            // 
            this.txtBigIntegerFactorial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBigIntegerFactorial.Location = new System.Drawing.Point(76, 81);
            this.txtBigIntegerFactorial.Name = "txtBigIntegerFactorial";
            this.txtBigIntegerFactorial.ReadOnly = true;
            this.txtBigIntegerFactorial.Size = new System.Drawing.Size(234, 20);
            this.txtBigIntegerFactorial.TabIndex = 3;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(76, 12);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 1;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // txtLongFactorial
            // 
            this.txtLongFactorial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLongFactorial.Location = new System.Drawing.Point(76, 55);
            this.txtLongFactorial.Name = "txtLongFactorial";
            this.txtLongFactorial.ReadOnly = true;
            this.txtLongFactorial.Size = new System.Drawing.Size(234, 20);
            this.txtLongFactorial.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Long:";
            // 
            // howto_use_biginteger_Form1
            // 
            this.AcceptButton = this.btnCalculate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 112);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLongFactorial);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtBigIntegerFactorial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.label1);
            this.Name = "howto_use_biginteger_Form1";
            this.Text = "howto_use_biginteger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBigIntegerFactorial;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.TextBox txtLongFactorial;
        private System.Windows.Forms.Label label3;
    }
}

