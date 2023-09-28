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
     public partial class howto_fibonacci_word_Form1:Form
  { 


        public howto_fibonacci_word_Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            int num_words = int.Parse(txtN.Text);

            // List sub-words.
            lstS.Items.Clear();
            for (int i = 0; i < num_words; i++)
            {
                lstS.Items.Add(FiboS(i));
            }

            // List words.
            lstWords.Items.Clear();
            for (int i = 0; i < num_words; i++)
            {
                lstWords.Items.Add(Fibo(i).ToString() +
                    ": " + FiboWord(i));
            }
        }

        // Calculate the nth Fibonacci sub-word.
        private string FiboS(int n)
        {
            if (n == 0) return "0";
            if (n == 1) return "01";
            string s2 = "0";        // s - 2
            string s1 = "01";       // s - 1 
            string s0 = "010";      // s (Initially s = 2.)
            for (int i = 2; i < n; i++)
            {
                s0 = s1 + s2;
                s2 = s1;
                s1 = s0;
            }
            return s0;
        }

        // Calculate the nth Fibonacci word.
        private string FiboWord(int n)
        {
            // See how long it should be.
            int length = Fibo(n);
            string s2 = "0";        // s - 2
            string s1 = "01";       // s - 1 
            string s0 = "010";      // s (Initially s = 2.)
            while (s0.Length < length)
            {
                s0 = s1 + s2;
                s2 = s1;
                s1 = s0;
            }
            return s0.Substring(0, length);
        }

        // Return the nth Fibonacci number.
        private int Fibo(int n)
        {
            if (n <= 1) return n;
            int n2 = 0;         // n - 2
            int n1 = 1;         // n - 1
            int n0 = n1 + n2;   // n (Initially n = 2.)
            for (int i = 2; i < n; i++)
            {
                n2 = n1;
                n1 = n0;
                n0 = n1 + n2;
            }
            return n0;
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
            this.btnGo = new System.Windows.Forms.Button();
            this.lstWords = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lstS = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "n:";
            // 
            // txtN
            // 
            this.txtN.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtN.Location = new System.Drawing.Point(25, 4);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(64, 20);
            this.txtN.TabIndex = 1;
            this.txtN.Text = "12";
            this.txtN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(227, 3);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lstWords
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lstWords, 3);
            this.lstWords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstWords.FormattingEnabled = true;
            this.lstWords.IntegralHeight = false;
            this.lstWords.Location = new System.Drawing.Point(3, 158);
            this.lstWords.Name = "lstWords";
            this.lstWords.Size = new System.Drawing.Size(299, 121);
            this.lstWords.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lstWords, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnGo, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstS, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtN, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(305, 282);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // lstS
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lstS, 3);
            this.lstS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstS.FormattingEnabled = true;
            this.lstS.IntegralHeight = false;
            this.lstS.Location = new System.Drawing.Point(3, 32);
            this.lstS.Name = "lstS";
            this.lstS.Size = new System.Drawing.Size(299, 120);
            this.lstS.TabIndex = 4;
            // 
            // howto_fibonacci_word_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 291);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "howto_fibonacci_word_Form1";
            this.Text = "howto_fibonacci_word";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ListBox lstWords;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox lstS;
    }
}

