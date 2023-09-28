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
     public partial class howto_swap_numbers_with_xor_Form1:Form
  { 


        public howto_swap_numbers_with_xor_Form1()
        {
            InitializeComponent();
        }

        // Swap the numbers.
        private void btnSwap_Click(object sender, EventArgs e)
        {
            // Get the numbers.
            long A = long.Parse(txtA.Text);
            long B = long.Parse(txtB.Text);

            // Swap the numbers.
            A = A ^ B;      // A holds a ^ b.
            B = B ^ A;      // B holds b ^ (a ^ b) = b ^ b ^ a = 0 ^ a = a.
            A = A ^ B;      // A holds (a ^ b) ^ a = a ^ a ^ b = b.

            // Display the results.
            txtSwappedA.Text = A.ToString();
            txtSwappedB.Text = B.ToString();
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
            this.txtSwappedB = new System.Windows.Forms.TextBox();
            this.txtSwappedA = new System.Windows.Forms.TextBox();
            this.btnSwap = new System.Windows.Forms.Button();
            this.txtB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSwappedB
            // 
            this.txtSwappedB.Location = new System.Drawing.Point(221, 37);
            this.txtSwappedB.Name = "txtSwappedB";
            this.txtSwappedB.ReadOnly = true;
            this.txtSwappedB.Size = new System.Drawing.Size(100, 20);
            this.txtSwappedB.TabIndex = 13;
            this.txtSwappedB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSwappedA
            // 
            this.txtSwappedA.Location = new System.Drawing.Point(221, 11);
            this.txtSwappedA.Name = "txtSwappedA";
            this.txtSwappedA.ReadOnly = true;
            this.txtSwappedA.Size = new System.Drawing.Size(100, 20);
            this.txtSwappedA.TabIndex = 12;
            this.txtSwappedA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSwap
            // 
            this.btnSwap.Location = new System.Drawing.Point(140, 23);
            this.btnSwap.Name = "btnSwap";
            this.btnSwap.Size = new System.Drawing.Size(75, 23);
            this.btnSwap.TabIndex = 11;
            this.btnSwap.Text = "Swap";
            this.btnSwap.UseVisualStyleBackColor = true;
            this.btnSwap.Click += new System.EventHandler(this.btnSwap_Click);
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(34, 37);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(100, 20);
            this.txtB.TabIndex = 10;
            this.txtB.Text = "314159265";
            this.txtB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "B:";
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(34, 11);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(100, 20);
            this.txtA.TabIndex = 8;
            this.txtA.Text = "-1337";
            this.txtA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "A:";
            // 
            // howto_swap_numbers_with_xor_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 71);
            this.Controls.Add(this.txtSwappedB);
            this.Controls.Add(this.txtSwappedA);
            this.Controls.Add(this.btnSwap);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.label1);
            this.Name = "howto_swap_numbers_with_xor_Form1";
            this.Text = "howto_swap_numbers_with_xor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSwappedB;
        private System.Windows.Forms.TextBox txtSwappedA;
        private System.Windows.Forms.Button btnSwap;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.Label label1;
    }
}

