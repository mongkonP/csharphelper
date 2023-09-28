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
     public partial class howto_gcd_lcm_Form1:Form
  { 


        public howto_gcd_lcm_Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            long A = long.Parse(txtA.Text);
            long B = long.Parse(txtB.Text);
            txtGcd.Text = GCD(A, B).ToString();
            txtLcm.Text = LCM(A, B).ToString();
        }

        // Use Euclid's algorithm to calculate the
        // greatest common divisor (GCD) of two numbers.
        private long GCD(long a, long b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            // Pull out remainders.
            for (; ; )
            {
                long remainder = a % b;
                if (remainder == 0) return b;
                a = b;
                b = remainder;
            };
        }

        // Return the least common multiple
        // (LCM) of two numbers.
        private long LCM(long a, long b)
        {
            return a * b / GCD(a, b);
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
            this.txtA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtB = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLcm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGcd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(35, 12);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(47, 20);
            this.txtA.TabIndex = 0;
            this.txtA.Text = "36";
            this.txtA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "A:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "B:";
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(35, 38);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(47, 20);
            this.txtB.TabIndex = 2;
            this.txtB.Text = "84";
            this.txtB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(109, 25);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(202, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "LCM:";
            // 
            // txtLcm
            // 
            this.txtLcm.Location = new System.Drawing.Point(241, 38);
            this.txtLcm.Name = "txtLcm";
            this.txtLcm.ReadOnly = true;
            this.txtLcm.Size = new System.Drawing.Size(47, 20);
            this.txtLcm.TabIndex = 7;
            this.txtLcm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "GCD:";
            // 
            // txtGcd
            // 
            this.txtGcd.Location = new System.Drawing.Point(241, 12);
            this.txtGcd.Name = "txtGcd";
            this.txtGcd.ReadOnly = true;
            this.txtGcd.Size = new System.Drawing.Size(47, 20);
            this.txtGcd.TabIndex = 5;
            this.txtGcd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // howto_gcd_lcm_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 77);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLcm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtGcd);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtA);
            this.Name = "howto_gcd_lcm_Form1";
            this.Text = "howto_gcd_lcm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLcm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGcd;
    }
}

