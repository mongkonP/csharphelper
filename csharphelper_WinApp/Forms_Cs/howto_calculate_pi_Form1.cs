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
     public partial class howto_calculate_pi_Form1:Form
  { 


        public howto_calculate_pi_Form1()
        {
            InitializeComponent();
        }

        private void howto_calculate_pi_Form1_Load(object sender, EventArgs e)
        {
            txtActual.Text = Math.PI.ToString();
        }

        // Calculate Pi.
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            txtCalculated.Clear();
            txtDifference.Clear();
            Refresh();

            double pi_over_4 = 0;
            int num_terms = int.Parse(txtNumTerms.Text);
            double sign = 1;
            for (int term = 0; term < num_terms; term++)
            {
                //Console.WriteLine(sign + " / " + (term * 2 + 1) + " = " +
                //    (1.0 / (term * 2 + 1)));
                pi_over_4 += sign / (term * 2 + 1);
                sign *= -1;
            }

            // Display the result.
            double pi = 4 * pi_over_4;
            txtCalculated.Text = pi.ToString();
            txtDifference.Text = (Math.PI - pi).ToString();
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
            this.btnCalculate = new System.Windows.Forms.Button();
            this.txtActual = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCalculated = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumTerms = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDifference = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCalculate.Location = new System.Drawing.Point(105, 126);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 4;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // txtActual
            // 
            this.txtActual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtActual.Location = new System.Drawing.Point(78, 38);
            this.txtActual.Name = "txtActual";
            this.txtActual.ReadOnly = true;
            this.txtActual.Size = new System.Drawing.Size(194, 20);
            this.txtActual.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Calculated:";
            // 
            // txtCalculated
            // 
            this.txtCalculated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCalculated.Location = new System.Drawing.Point(78, 64);
            this.txtCalculated.Name = "txtCalculated";
            this.txtCalculated.ReadOnly = true;
            this.txtCalculated.Size = new System.Drawing.Size(194, 20);
            this.txtCalculated.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Actual:";
            // 
            // txtNumTerms
            // 
            this.txtNumTerms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumTerms.Location = new System.Drawing.Point(78, 12);
            this.txtNumTerms.Name = "txtNumTerms";
            this.txtNumTerms.Size = new System.Drawing.Size(194, 20);
            this.txtNumTerms.TabIndex = 0;
            this.txtNumTerms.Text = "1000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "# Terms:";
            // 
            // txtDifference
            // 
            this.txtDifference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDifference.Location = new System.Drawing.Point(78, 90);
            this.txtDifference.Name = "txtDifference";
            this.txtDifference.ReadOnly = true;
            this.txtDifference.Size = new System.Drawing.Size(194, 20);
            this.txtDifference.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Difference:";
            // 
            // howto_calculate_pi_Form1
            // 
            this.AcceptButton = this.btnCalculate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 162);
            this.Controls.Add(this.txtDifference);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNumTerms);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCalculated);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtActual);
            this.Controls.Add(this.btnCalculate);
            this.Name = "howto_calculate_pi_Form1";
            this.Text = "howto_calculate_pi";
            this.Load += new System.EventHandler(this.howto_calculate_pi_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.TextBox txtActual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCalculated;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumTerms;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDifference;
        private System.Windows.Forms.Label label4;
    }
}

