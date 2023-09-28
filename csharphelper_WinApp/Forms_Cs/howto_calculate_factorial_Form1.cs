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
     public partial class howto_calculate_factorial_Form1:Form
  { 


        public howto_calculate_factorial_Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            decimal N = decimal.Parse(txtN.Text);
            try
            {
                txtNFactorial.Text = Factorial(N).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtN = new System.Windows.Forms.TextBox();
            this.txtNFactorial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "N";
            // 
            // txtN
            // 
            this.txtN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtN.Location = new System.Drawing.Point(53, 12);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(200, 20);
            this.txtN.TabIndex = 1;
            this.txtN.Text = "10";
            this.txtN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNFactorial
            // 
            this.txtNFactorial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNFactorial.Location = new System.Drawing.Point(53, 38);
            this.txtNFactorial.Name = "txtNFactorial";
            this.txtNFactorial.ReadOnly = true;
            this.txtNFactorial.Size = new System.Drawing.Size(200, 20);
            this.txtNFactorial.TabIndex = 3;
            this.txtNFactorial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "N!";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(272, 24);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(50, 23);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // howto_calculate_factorial_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 74);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtNFactorial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.label1);
            this.Name = "howto_calculate_factorial_Form1";
            this.Text = "howto_calculate_factorial";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.TextBox txtNFactorial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGo;
    }
}

