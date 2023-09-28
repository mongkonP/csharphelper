using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_fraction_class;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_fraction_class_Form1:Form
  { 


        public howto_fraction_class_Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            txtPlus.Clear();
            txtMinus.Clear();
            txtTimes.Clear();
            txtDivide.Clear();
            txtDouble.Clear();

            try
            {
                Fraction a = new Fraction(txtFraction1.Text);
                Fraction b = new Fraction(txtFraction2.Text);

                txtPlus.Text = (a + b).ToString();
                txtMinus.Text = (a - b).ToString();
                txtTimes.Text = (a * b).ToString();
                txtDivide.Text = (a / b).ToString();
                txtNegate.Text = (-a).ToString();
                txtDouble.Text = ((double)a).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            this.Label6 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtFraction2 = new System.Windows.Forms.TextBox();
            this.txtFraction1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPlus = new System.Windows.Forms.TextBox();
            this.txtMinus = new System.Windows.Forms.TextBox();
            this.txtTimes = new System.Windows.Forms.TextBox();
            this.txtNegate = new System.Windows.Forms.TextBox();
            this.txtDivide = new System.Windows.Forms.TextBox();
            this.txtDouble = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(197, 119);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(17, 13);
            this.Label6.TabIndex = 22;
            this.Label6.Text = "-A";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(197, 93);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(32, 13);
            this.Label3.TabIndex = 21;
            this.Label3.Text = "A / B";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(197, 67);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(31, 13);
            this.Label4.TabIndex = 20;
            this.Label4.Text = "A * B";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(197, 41);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(30, 13);
            this.Label2.TabIndex = 19;
            this.Label2.Text = "A - B";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(197, 15);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(33, 13);
            this.Label1.TabIndex = 18;
            this.Label1.Text = "A + B";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(105, 24);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 17;
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtFraction2
            // 
            this.txtFraction2.Location = new System.Drawing.Point(35, 38);
            this.txtFraction2.Name = "txtFraction2";
            this.txtFraction2.Size = new System.Drawing.Size(64, 20);
            this.txtFraction2.TabIndex = 16;
            this.txtFraction2.Text = "21/10";
            // 
            // txtFraction1
            // 
            this.txtFraction1.Location = new System.Drawing.Point(35, 12);
            this.txtFraction1.Name = "txtFraction1";
            this.txtFraction1.Size = new System.Drawing.Size(64, 20);
            this.txtFraction1.TabIndex = 15;
            this.txtFraction1.Text = "4/15";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "A:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "B:";
            // 
            // txtPlus
            // 
            this.txtPlus.Location = new System.Drawing.Point(250, 12);
            this.txtPlus.Name = "txtPlus";
            this.txtPlus.Size = new System.Drawing.Size(100, 20);
            this.txtPlus.TabIndex = 25;
            // 
            // txtMinus
            // 
            this.txtMinus.Location = new System.Drawing.Point(250, 38);
            this.txtMinus.Name = "txtMinus";
            this.txtMinus.Size = new System.Drawing.Size(100, 20);
            this.txtMinus.TabIndex = 26;
            // 
            // txtTimes
            // 
            this.txtTimes.Location = new System.Drawing.Point(250, 64);
            this.txtTimes.Name = "txtTimes";
            this.txtTimes.Size = new System.Drawing.Size(100, 20);
            this.txtTimes.TabIndex = 27;
            // 
            // txtNegate
            // 
            this.txtNegate.Location = new System.Drawing.Point(250, 116);
            this.txtNegate.Name = "txtNegate";
            this.txtNegate.Size = new System.Drawing.Size(100, 20);
            this.txtNegate.TabIndex = 29;
            // 
            // txtDivide
            // 
            this.txtDivide.Location = new System.Drawing.Point(250, 90);
            this.txtDivide.Name = "txtDivide";
            this.txtDivide.Size = new System.Drawing.Size(100, 20);
            this.txtDivide.TabIndex = 28;
            // 
            // txtDouble
            // 
            this.txtDouble.Location = new System.Drawing.Point(250, 142);
            this.txtDouble.Name = "txtDouble";
            this.txtDouble.Size = new System.Drawing.Size(100, 20);
            this.txtDouble.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(197, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "(double)A";
            // 
            // howto_fraction_class_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 176);
            this.Controls.Add(this.txtDouble);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNegate);
            this.Controls.Add(this.txtDivide);
            this.Controls.Add(this.txtTimes);
            this.Controls.Add(this.txtMinus);
            this.Controls.Add(this.txtPlus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtFraction2);
            this.Controls.Add(this.txtFraction1);
            this.Name = "howto_fraction_class_Form1";
            this.Text = "howto_fraction_class";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnGo;
        internal System.Windows.Forms.TextBox txtFraction2;
        internal System.Windows.Forms.TextBox txtFraction1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPlus;
        private System.Windows.Forms.TextBox txtMinus;
        private System.Windows.Forms.TextBox txtTimes;
        private System.Windows.Forms.TextBox txtNegate;
        private System.Windows.Forms.TextBox txtDivide;
        private System.Windows.Forms.TextBox txtDouble;
        internal System.Windows.Forms.Label label8;
    }
}

