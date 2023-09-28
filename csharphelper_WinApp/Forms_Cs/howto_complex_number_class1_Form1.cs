using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_complex_number_class1;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_complex_number_class1_Form1:Form
  { 


        public howto_complex_number_class1_Form1()
        {
            InitializeComponent();
        }

        // Perform sample calculations.
        private void btnGo_Click(object sender, EventArgs e)
        {
            Complex A = Complex.Parse(txtA.Text);
            Complex B = Complex.Parse(txtB.Text);

            txtNegative.Text = (-A).ToString();
            txtAminusB.Text = (A - B).ToString();
            txtAplusB.Text = (A + B).ToString();
            txtAtimesB.Text = (A * B).ToString();

            txtAdividedbyB.Text = (A / B).ToString("0.0000");
            Complex check1 = A / B;
            txtCheck.Text = (check1 * B).ToString();
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
            this.txtCheck = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAdividedbyB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNegative = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAtimesB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAplusB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAminusB = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtA = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtCheck
            // 
            this.txtCheck.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCheck.Location = new System.Drawing.Point(156, 205);
            this.txtCheck.Name = "txtCheck";
            this.txtCheck.ReadOnly = true;
            this.txtCheck.Size = new System.Drawing.Size(115, 20);
            this.txtCheck.TabIndex = 67;
            this.txtCheck.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(80, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 17);
            this.label6.TabIndex = 85;
            this.label6.Text = "(A / B) * B";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAdividedbyB
            // 
            this.txtAdividedbyB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAdividedbyB.Location = new System.Drawing.Point(156, 179);
            this.txtAdividedbyB.Name = "txtAdividedbyB";
            this.txtAdividedbyB.ReadOnly = true;
            this.txtAdividedbyB.Size = new System.Drawing.Size(115, 20);
            this.txtAdividedbyB.TabIndex = 66;
            this.txtAdividedbyB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(80, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 17);
            this.label8.TabIndex = 84;
            this.label8.Text = "A / B";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 83;
            this.label4.Text = "B:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 82;
            this.label2.Text = "A:";
            // 
            // txtNegative
            // 
            this.txtNegative.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNegative.Location = new System.Drawing.Point(156, 75);
            this.txtNegative.Name = "txtNegative";
            this.txtNegative.ReadOnly = true;
            this.txtNegative.Size = new System.Drawing.Size(115, 20);
            this.txtNegative.TabIndex = 62;
            this.txtNegative.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(80, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 17);
            this.label7.TabIndex = 81;
            this.label7.Text = "-A";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAtimesB
            // 
            this.txtAtimesB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAtimesB.Location = new System.Drawing.Point(156, 153);
            this.txtAtimesB.Name = "txtAtimesB";
            this.txtAtimesB.ReadOnly = true;
            this.txtAtimesB.Size = new System.Drawing.Size(115, 20);
            this.txtAtimesB.TabIndex = 65;
            this.txtAtimesB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(80, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 17);
            this.label5.TabIndex = 80;
            this.label5.Text = "A * B";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAplusB
            // 
            this.txtAplusB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAplusB.Location = new System.Drawing.Point(156, 127);
            this.txtAplusB.Name = "txtAplusB";
            this.txtAplusB.ReadOnly = true;
            this.txtAplusB.Size = new System.Drawing.Size(115, 20);
            this.txtAplusB.TabIndex = 64;
            this.txtAplusB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(80, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 79;
            this.label3.Text = "A + B";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAminusB
            // 
            this.txtAminusB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAminusB.Location = new System.Drawing.Point(156, 101);
            this.txtAminusB.Name = "txtAminusB";
            this.txtAminusB.ReadOnly = true;
            this.txtAminusB.Size = new System.Drawing.Size(115, 20);
            this.txtAminusB.TabIndex = 63;
            this.txtAminusB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label1
            // 
            this.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(80, 102);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(70, 17);
            this.Label1.TabIndex = 76;
            this.Label1.Text = "A - B";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGo.Location = new System.Drawing.Point(202, 23);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(59, 24);
            this.btnGo.TabIndex = 61;
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtB
            // 
            this.txtB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtB.Location = new System.Drawing.Point(118, 39);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(64, 20);
            this.txtB.TabIndex = 59;
            this.txtB.Text = "21 + 10i";
            this.txtB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtA
            // 
            this.txtA.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtA.Location = new System.Drawing.Point(118, 13);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(64, 20);
            this.txtA.TabIndex = 58;
            this.txtA.Text = "4 + 5i";
            this.txtA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // howto_complex_number_class1_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 238);
            this.Controls.Add(this.txtCheck);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAdividedbyB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNegative);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtAtimesB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAplusB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAminusB);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtA);
            this.Name = "howto_complex_number_class1_Form1";
            this.Text = "howto_complex_number_class1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCheck;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAdividedbyB;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNegative;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAtimesB;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAplusB;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAminusB;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnGo;
        internal System.Windows.Forms.TextBox txtB;
        internal System.Windows.Forms.TextBox txtA;
    }
}

