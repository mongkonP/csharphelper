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
     public partial class howto_compare_string_object_Form1:Form
  { 


        public howto_compare_string_object_Form1()
        {
            InitializeComponent();
        }

        private void howto_compare_string_object_Form1_Load(object sender, EventArgs e)
        {
            // Two equal strings created at run time.
            string A = "ABCDEFGHIJ";
            string B = "ABCDEFGHIJ";
            bool a_eq_b = A == B;
            bool a_equals_b = A.Equals(B);
            txtAeqB.Text = a_eq_b.ToString();
            txtAequalsB.Text = a_equals_b.ToString();

            // Two equal strings created at
            // design time but stored as objects.
            object C = A;
            object D = B;
            bool c_eq_d = C == D;
            bool c_equals_d = C.Equals(D);
            txtCeqD.Text = c_eq_d.ToString();
            txtCequalsD.Text = c_equals_d.ToString();

            // Two equal strings created at run time.
            string E = A.Substring(2, 4);
            string F = A.Substring(2, 4);
            bool e_eq_f = E == F;
            bool e_equals_f = E.Equals(F);
            txtEeqF.Text = e_eq_f.ToString();
            txtEequalsF.Text = e_equals_f.ToString();

            // Two equal strings created at
            // run time but stored as objects.
            object G = E;
            object H = F;
            bool g_eq_h = G == H;
            bool g_equals_h = G.Equals(H);
            txtGeqH.Text = g_eq_h.ToString();
            txtGequalsH.Text = g_equals_h.ToString();

            txtAeqB.Select(0, 0);
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
            this.txtAeqB = new System.Windows.Forms.TextBox();
            this.txtAequalsB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCequalsD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCeqD = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEequalsF = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEeqF = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGequalsH = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGeqH = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "A == B:";
            // 
            // txtAeqB
            // 
            this.txtAeqB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAeqB.Location = new System.Drawing.Point(162, 15);
            this.txtAeqB.Name = "txtAeqB";
            this.txtAeqB.Size = new System.Drawing.Size(100, 20);
            this.txtAeqB.TabIndex = 1;
            // 
            // txtAequalsB
            // 
            this.txtAequalsB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAequalsB.Location = new System.Drawing.Point(162, 41);
            this.txtAequalsB.Name = "txtAequalsB";
            this.txtAequalsB.Size = new System.Drawing.Size(100, 20);
            this.txtAequalsB.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "A.Equals(B):";
            // 
            // txtCequalsD
            // 
            this.txtCequalsD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCequalsD.Location = new System.Drawing.Point(162, 93);
            this.txtCequalsD.Name = "txtCequalsD";
            this.txtCequalsD.Size = new System.Drawing.Size(100, 20);
            this.txtCequalsD.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "C.Equals(D):";
            // 
            // txtCeqD
            // 
            this.txtCeqD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCeqD.Location = new System.Drawing.Point(162, 67);
            this.txtCeqD.Name = "txtCeqD";
            this.txtCeqD.Size = new System.Drawing.Size(100, 20);
            this.txtCeqD.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "C == D:";
            // 
            // txtEequalsF
            // 
            this.txtEequalsF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEequalsF.Location = new System.Drawing.Point(162, 144);
            this.txtEequalsF.Name = "txtEequalsF";
            this.txtEequalsF.Size = new System.Drawing.Size(100, 20);
            this.txtEequalsF.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(81, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "E.Equals(F):";
            // 
            // txtEeqF
            // 
            this.txtEeqF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEeqF.Location = new System.Drawing.Point(162, 118);
            this.txtEeqF.Name = "txtEeqF";
            this.txtEeqF.Size = new System.Drawing.Size(100, 20);
            this.txtEeqF.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(81, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "E == F:";
            // 
            // txtGequalsH
            // 
            this.txtGequalsH.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtGequalsH.Location = new System.Drawing.Point(162, 196);
            this.txtGequalsH.Name = "txtGequalsH";
            this.txtGequalsH.Size = new System.Drawing.Size(100, 20);
            this.txtGequalsH.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(81, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "G.Equals(H):";
            // 
            // txtGeqH
            // 
            this.txtGeqH.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtGeqH.Location = new System.Drawing.Point(162, 170);
            this.txtGeqH.Name = "txtGeqH";
            this.txtGeqH.Size = new System.Drawing.Size(100, 20);
            this.txtGeqH.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(81, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "G == H:";
            // 
            // howto_compare_string_object_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 230);
            this.Controls.Add(this.txtGequalsH);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtGeqH);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtEequalsF);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEeqF);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCequalsD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCeqD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAequalsB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAeqB);
            this.Controls.Add(this.label1);
            this.Name = "howto_compare_string_object_Form1";
            this.Text = "howto_compare_string_object";
            this.Load += new System.EventHandler(this.howto_compare_string_object_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAeqB;
        private System.Windows.Forms.TextBox txtAequalsB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCequalsD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCeqD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEequalsF;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEeqF;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGequalsH;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGeqH;
        private System.Windows.Forms.Label label8;
    }
}

