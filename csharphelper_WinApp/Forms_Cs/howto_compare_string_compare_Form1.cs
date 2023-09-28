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
     public partial class howto_compare_string_compare_Form1:Form
  { 


        public howto_compare_string_compare_Form1()
        {
            InitializeComponent();
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            // Get ready.
            Cursor = Cursors.WaitCursor;
            txtEqEq.Clear();
            txtStringCompare.Clear();
            txtIgnoreCase.Clear();
            txtEquals.Clear();
            txtEquals2.Clear();
            txtToLower.Clear();
            Application.DoEvents();

            int iterations = int.Parse(txtIterations.Text);
            string value0 = "AAAAAAAAAAAAAAAAAAAAAA";
            string value1 = "AAAAAAAAAAAAAAAAAAAAAA";
            string value2 = "AAAAAAAAAAAAAAAAAAAAAB";
            string value3 = "BAAAAAAAAAAAAAAAAAAAAA";
            DateTime start_time;
            TimeSpan elapsed;

            // ==.
            start_time = DateTime.Now;
            for (int i = 1; i <= iterations; i++)
            {
                if (value0 == value1) { }
                if (value0 == value2) { }
                if (value0 == value3) { }
            }
            elapsed = DateTime.Now - start_time;
            txtEqEq.Text = elapsed.TotalSeconds.ToString("0.000") + " sec";
            Application.DoEvents();

            // String.Compare (default is case-sensitive).
            start_time = DateTime.Now;
            for (int i = 1; i <= iterations; i++)
            {
                if (String.Compare(value0, value1, false) == 0) { }
                if (String.Compare(value0, value2, false) == 0) { }
                if (String.Compare(value0, value3, false) == 0) { }
            }
            elapsed = DateTime.Now - start_time;
            txtStringCompare.Text = elapsed.TotalSeconds.ToString("0.000") + " sec";
            Application.DoEvents();

            // String.Equals.
            start_time = DateTime.Now;
            for (int i = 1; i <= iterations; i++)
            {
                if (value0.Equals(value1)) { }
                if (value0.Equals(value2)) { }
                if (value0.Equals(value3)) { }
            }
            elapsed = DateTime.Now - start_time;
            txtEquals.Text = elapsed.TotalSeconds.ToString("0.000") + " sec";
            Application.DoEvents();

            // String.Compare, case-insensitive.
            start_time = DateTime.Now;
            for (int i = 1; i <= iterations; i++)
            {
                if (String.Compare(value0, value1, true) == 0) { }
                if (String.Compare(value0, value2, true) == 0) { }
                if (String.Compare(value0, value3, true) == 0) { }
            }
            elapsed = DateTime.Now - start_time;
            txtIgnoreCase.Text = elapsed.TotalSeconds.ToString("0.000") + " sec";
            Application.DoEvents();

            // String.Equals, case-insensitive.
            start_time = DateTime.Now;
            for (int i = 1; i <= iterations; i++)
            {
                if (value0.Equals(value1, StringComparison.CurrentCultureIgnoreCase)) { }
                if (value0.Equals(value2, StringComparison.CurrentCultureIgnoreCase)) { }
                if (value0.Equals(value3, StringComparison.CurrentCultureIgnoreCase)) { }
            }
            elapsed = DateTime.Now - start_time;
            txtEquals2.Text = elapsed.TotalSeconds.ToString("0.000") + " sec";
            Application.DoEvents();

            // ToLower.
            start_time = DateTime.Now;
            value1 = value1.ToLower();
            value2 = value2.ToLower();
            value3 = value3.ToLower();
            for (int i = 1; i <= iterations; i++)
            {
                if (value0.ToLower() == value1) { }
                if (value0.ToLower() == value2) { }
                if (value0.ToLower() == value3) { }
            }
            elapsed = DateTime.Now - start_time;
            txtToLower.Text = elapsed.TotalSeconds.ToString("0.000") + " sec";

            Cursor = Cursors.Default;
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
            this.txtStringCompare = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIgnoreCase = new System.Windows.Forms.TextBox();
            this.txtEquals = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEqEq = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtToLower = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEquals2 = new System.Windows.Forms.TextBox();
            this.btnCompare = new System.Windows.Forms.Button();
            this.txtIterations = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStringCompare
            // 
            this.txtStringCompare.Location = new System.Drawing.Point(127, 44);
            this.txtStringCompare.Name = "txtStringCompare";
            this.txtStringCompare.ReadOnly = true;
            this.txtStringCompare.Size = new System.Drawing.Size(83, 20);
            this.txtStringCompare.TabIndex = 1;
            this.txtStringCompare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "String.Compare";
            // 
            // txtIgnoreCase
            // 
            this.txtIgnoreCase.Location = new System.Drawing.Point(127, 19);
            this.txtIgnoreCase.Name = "txtIgnoreCase";
            this.txtIgnoreCase.ReadOnly = true;
            this.txtIgnoreCase.Size = new System.Drawing.Size(83, 20);
            this.txtIgnoreCase.TabIndex = 0;
            this.txtIgnoreCase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtEquals
            // 
            this.txtEquals.Location = new System.Drawing.Point(127, 70);
            this.txtEquals.Name = "txtEquals";
            this.txtEquals.ReadOnly = true;
            this.txtEquals.Size = new System.Drawing.Size(83, 20);
            this.txtEquals.TabIndex = 2;
            this.txtEquals.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtStringCompare);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtEqEq);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtEquals);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(15, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 100);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Case Sensitive";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "==";
            // 
            // txtEqEq
            // 
            this.txtEqEq.Location = new System.Drawing.Point(127, 18);
            this.txtEqEq.Name = "txtEqEq";
            this.txtEqEq.ReadOnly = true;
            this.txtEqEq.Size = new System.Drawing.Size(83, 20);
            this.txtEqEq.TabIndex = 0;
            this.txtEqEq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "String.Equals";
            // 
            // txtToLower
            // 
            this.txtToLower.Location = new System.Drawing.Point(127, 72);
            this.txtToLower.Name = "txtToLower";
            this.txtToLower.ReadOnly = true;
            this.txtToLower.Size = new System.Drawing.Size(83, 20);
            this.txtToLower.TabIndex = 2;
            this.txtToLower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "String.Equals";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "String.Compare";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Iterations:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "ToLower";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtIgnoreCase);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtToLower);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtEquals2);
            this.groupBox2.Location = new System.Drawing.Point(15, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 100);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Case Insensitive";
            // 
            // txtEquals2
            // 
            this.txtEquals2.Location = new System.Drawing.Point(127, 46);
            this.txtEquals2.Name = "txtEquals2";
            this.txtEquals2.ReadOnly = true;
            this.txtEquals2.Size = new System.Drawing.Size(83, 20);
            this.txtEquals2.TabIndex = 1;
            this.txtEquals2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCompare
            // 
            this.btnCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompare.Location = new System.Drawing.Point(267, 11);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(75, 23);
            this.btnCompare.TabIndex = 19;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // txtIterations
            // 
            this.txtIterations.Location = new System.Drawing.Point(97, 13);
            this.txtIterations.Name = "txtIterations";
            this.txtIterations.Size = new System.Drawing.Size(69, 20);
            this.txtIterations.TabIndex = 18;
            this.txtIterations.Text = "10000000";
            this.txtIterations.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // howto_compare_string_compare_Form1
            // 
            this.AcceptButton = this.btnCompare;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 266);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.txtIterations);
            this.Name = "howto_compare_string_compare_Form1";
            this.Text = "howto_compare_string_compare";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStringCompare;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIgnoreCase;
        private System.Windows.Forms.TextBox txtEquals;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEqEq;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtToLower;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtEquals2;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.TextBox txtIterations;
    }
}

