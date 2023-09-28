using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_calculate_n_choose_k_Form1:Form
  { 


        public howto_calculate_n_choose_k_Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            // Get N and K.
            decimal N = decimal.Parse(txtN.Text);
            decimal K = decimal.Parse(txtK.Text);

            // Calculate using factorials.
            try
            {
                txtWFactorials.Text = MChooseNFactorial(N, K).ToString();
            }
            catch
            {
                txtWFactorials.Text = "Error";
            }

            // Calculate using the more direct method.
            try
            {
                txtDirect.Text = NChooseK(N, K).ToString();
            }
            catch
            {
                txtDirect.Text = "Error";
            }
        }

        // Return N choose K calculated directly.
        // For a description of the algorithm, see:
        //      http://csharphelper.com/blog/2014/08/calculate-the-binomial-coefficient-n-choose-k-efficiently-in-c/
        private decimal NChooseK(decimal N, decimal K)
        {
            Debug.Assert(N >= 0);
            Debug.Assert(K >= 0);
            Debug.Assert(N >= K);

            decimal result = 1;
            for (int i = 1; i <= K; i++)
            {
                result *= N - (K - i);
                result /= i;
            }
            return result;
        }

        // Use the Factorial function to calculate M choose N.
        private decimal MChooseNFactorial(decimal M, decimal N)
        {
            Debug.Assert(M >= 0);
            Debug.Assert(N >= 0);
            Debug.Assert(M >= N);

            return Factorial(M) / Factorial(N) / Factorial(M - N);
        }

        // Calculate N!
        private decimal Factorial(decimal N)
        {
            Debug.Assert(N >= 0);

            decimal result = 1;
            for (decimal i = 2; i <= N; i++) result *= i;
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
            this.txtDirect = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWFactorials = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtK = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDirect
            // 
            this.txtDirect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirect.Location = new System.Drawing.Point(83, 91);
            this.txtDirect.Name = "txtDirect";
            this.txtDirect.ReadOnly = true;
            this.txtDirect.Size = new System.Drawing.Size(180, 20);
            this.txtDirect.TabIndex = 19;
            this.txtDirect.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Directly";
            // 
            // txtWFactorials
            // 
            this.txtWFactorials.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWFactorials.Location = new System.Drawing.Point(83, 65);
            this.txtWFactorials.Name = "txtWFactorials";
            this.txtWFactorials.ReadOnly = true;
            this.txtWFactorials.Size = new System.Drawing.Size(180, 20);
            this.txtWFactorials.TabIndex = 18;
            this.txtWFactorials.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "w/Factorials";
            // 
            // txtN
            // 
            this.txtN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtN.Location = new System.Drawing.Point(83, 13);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(180, 20);
            this.txtN.TabIndex = 15;
            this.txtN.Text = "28";
            this.txtN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "N";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(282, 50);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(50, 23);
            this.btnGo.TabIndex = 17;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtK
            // 
            this.txtK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtK.Location = new System.Drawing.Point(83, 39);
            this.txtK.Name = "txtK";
            this.txtK.Size = new System.Drawing.Size(180, 20);
            this.txtK.TabIndex = 16;
            this.txtK.Text = "3";
            this.txtK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "K";
            // 
            // howto_calculate_n_choose_k_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 124);
            this.Controls.Add(this.txtDirect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtWFactorials);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtK);
            this.Controls.Add(this.label1);
            this.Name = "howto_calculate_n_choose_k_Form1";
            this.Text = "howto_calculate_n_choose_k";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDirect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWFactorials;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtK;
        private System.Windows.Forms.Label label1;
    }
}

