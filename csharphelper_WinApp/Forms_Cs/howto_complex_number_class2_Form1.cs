using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;

 

using howto_complex_number_class2;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_complex_number_class2_Form1:Form
  { 


        public howto_complex_number_class2_Form1()
        {
            InitializeComponent();
        }

        // Perform sample calculations.
        private void btnGo_Click(object sender, EventArgs e)
        {
            Complex A = Complex.Parse(txtA.Text);
            Complex B = Complex.Parse(txtB.Text);

            txtAequalsB.Text = (A == B).ToString();
            txtAnotequalsB.Text = (A != B).ToString();
            txtAhash.Text = A.GetHashCode().ToString();

            // Make some null tests.
            A = null;
            Debug.Assert(A != B);
            Debug.Assert(A == null);
            Debug.Assert(null == A);
            Debug.Assert(B != null);
            Debug.Assert(null != B);
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
            this.txtAequalsB = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAhash = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtAnotequalsB = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtA = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtAequalsB
            // 
            this.txtAequalsB.Location = new System.Drawing.Point(292, 12);
            this.txtAequalsB.Name = "txtAequalsB";
            this.txtAequalsB.ReadOnly = true;
            this.txtAequalsB.Size = new System.Drawing.Size(115, 20);
            this.txtAequalsB.TabIndex = 68;
            this.txtAequalsB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(216, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 17);
            this.label12.TabIndex = 90;
            this.label12.Text = "A == B";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAhash
            // 
            this.txtAhash.Location = new System.Drawing.Point(292, 64);
            this.txtAhash.Name = "txtAhash";
            this.txtAhash.ReadOnly = true;
            this.txtAhash.Size = new System.Drawing.Size(115, 20);
            this.txtAhash.TabIndex = 70;
            this.txtAhash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(216, 65);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 17);
            this.label14.TabIndex = 88;
            this.label14.Text = "A.Hash";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAnotequalsB
            // 
            this.txtAnotequalsB.Location = new System.Drawing.Point(292, 38);
            this.txtAnotequalsB.Name = "txtAnotequalsB";
            this.txtAnotequalsB.ReadOnly = true;
            this.txtAnotequalsB.Size = new System.Drawing.Size(115, 20);
            this.txtAnotequalsB.TabIndex = 69;
            this.txtAnotequalsB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(216, 39);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 17);
            this.label15.TabIndex = 87;
            this.label15.Text = "A != B";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 83;
            this.label4.Text = "B:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 82;
            this.label2.Text = "A:";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(135, 37);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(59, 24);
            this.btnGo.TabIndex = 61;
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(51, 53);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(64, 20);
            this.txtB.TabIndex = 59;
            this.txtB.Text = "21 + 10i";
            this.txtB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(51, 27);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(64, 20);
            this.txtA.TabIndex = 58;
            this.txtA.Text = "4 + 5i";
            this.txtA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // howto_complex_number_class2_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 100);
            this.Controls.Add(this.txtAequalsB);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtAhash);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtAnotequalsB);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtA);
            this.Name = "howto_complex_number_class2_Form1";
            this.Text = "howto_complex_number_class2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAequalsB;
        internal System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtAhash;
        internal System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtAnotequalsB;
        internal System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button btnGo;
        internal System.Windows.Forms.TextBox txtB;
        internal System.Windows.Forms.TextBox txtA;
    }
}

