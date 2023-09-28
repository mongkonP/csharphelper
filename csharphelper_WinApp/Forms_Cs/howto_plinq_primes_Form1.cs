using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_plinq_primes_Form1:Form
  { 


        public howto_plinq_primes_Form1()
        {
            InitializeComponent();
        }

        // Generate a list of numbers and pick out the prime ones.
        private void btnGo_Click(object sender, EventArgs e)
        {
            lstAllNumbers.DataSource = null;
            lstLinq.DataSource = null;
            lstPlinq.DataSource = null;
            lblLinq.Text = "";
            lblPlinq.Text = "";
            Cursor = Cursors.WaitCursor;
            Refresh();
            Stopwatch watch = new Stopwatch();

            // Create the numbers.
            watch.Start();
            Random rand = new Random();
            int num_numbers = int.Parse(txtNumNumbers.Text);
            int[] numbers = new int[num_numbers];
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = rand.Next(0, 100);
            watch.Stop();
            lstAllNumbers.DataSource = numbers.Take(1000).ToArray();
            lblRandom.Text = watch.Elapsed.TotalSeconds.ToString("0.00") + " secs";
            lblLinq.Refresh();
            lstAllNumbers.Refresh();

            // Make an IsPrime delegate.
            Func<int, bool> IsPrime = number =>
            {
                if (number == 0) return false;
                else if (number < 0) number = -number;

                if (number == 1) return false;
                if (number == 2) return true;
                if (number % 2 == 0) return false;
                for (int i = 3; i * i <= number; i += 2)
                    if (number % i == 0) return false;
                return true;
            };

            // Use LINQ to find the prime numbers.
            watch.Restart();
            var linq_query =
                from int number in numbers
                where IsPrime(number)
                select number;
            int[] linq_primes = linq_query.ToArray();
            watch.Stop();
            lstLinq.DataSource = linq_primes.Take(1000).ToArray();
            lblLinq.Text = watch.Elapsed.TotalSeconds.ToString("0.00") + " secs";
            lblLinq.Refresh();
            lstLinq.Refresh();

            // Use PLINQ to find the prime numbers.
            watch.Restart();
            var plinq_query =
                from int number in numbers.AsParallel()
                where IsPrime(number)
                select number;
            int[] plinq_primes = plinq_query.ToArray();
            watch.Stop();
            lstPlinq.DataSource = plinq_primes.Take(1000).ToArray();
            lblPlinq.Text = watch.Elapsed.TotalSeconds.ToString("0.00") + " secs";

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
            this.lblRandom = new System.Windows.Forms.Label();
            this.lblPlinq = new System.Windows.Forms.Label();
            this.lblLinq = new System.Windows.Forms.Label();
            this.lstPlinq = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lstLinq = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstAllNumbers = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtNumNumbers = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblRandom
            // 
            this.lblRandom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRandom.AutoSize = true;
            this.lblRandom.Location = new System.Drawing.Point(11, 237);
            this.lblRandom.Name = "lblRandom";
            this.lblRandom.Size = new System.Drawing.Size(0, 13);
            this.lblRandom.TabIndex = 36;
            // 
            // lblPlinq
            // 
            this.lblPlinq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPlinq.AutoSize = true;
            this.lblPlinq.Location = new System.Drawing.Point(183, 237);
            this.lblPlinq.Name = "lblPlinq";
            this.lblPlinq.Size = new System.Drawing.Size(0, 13);
            this.lblPlinq.TabIndex = 35;
            // 
            // lblLinq
            // 
            this.lblLinq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLinq.AutoSize = true;
            this.lblLinq.Location = new System.Drawing.Point(97, 237);
            this.lblLinq.Name = "lblLinq";
            this.lblLinq.Size = new System.Drawing.Size(0, 13);
            this.lblLinq.TabIndex = 34;
            // 
            // lstPlinq
            // 
            this.lstPlinq.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstPlinq.FormattingEnabled = true;
            this.lstPlinq.IntegralHeight = false;
            this.lstPlinq.Location = new System.Drawing.Point(186, 71);
            this.lstPlinq.Name = "lstPlinq";
            this.lstPlinq.Size = new System.Drawing.Size(80, 163);
            this.lstPlinq.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(186, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "PLINQ:";
            // 
            // lstLinq
            // 
            this.lstLinq.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstLinq.FormattingEnabled = true;
            this.lstLinq.IntegralHeight = false;
            this.lstLinq.Location = new System.Drawing.Point(100, 71);
            this.lstLinq.Name = "lstLinq";
            this.lstLinq.Size = new System.Drawing.Size(80, 163);
            this.lstLinq.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "LINQ:";
            // 
            // lstAllNumbers
            // 
            this.lstAllNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstAllNumbers.FormattingEnabled = true;
            this.lstAllNumbers.IntegralHeight = false;
            this.lstAllNumbers.Location = new System.Drawing.Point(14, 71);
            this.lstAllNumbers.Name = "lstAllNumbers";
            this.lstAllNumbers.Size = new System.Drawing.Size(80, 163);
            this.lstAllNumbers.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "All Numbers:";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(191, 10);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 27;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtNumNumbers
            // 
            this.txtNumNumbers.Location = new System.Drawing.Point(82, 12);
            this.txtNumNumbers.Name = "txtNumNumbers";
            this.txtNumNumbers.Size = new System.Drawing.Size(59, 20);
            this.txtNumNumbers.TabIndex = 26;
            this.txtNumNumbers.Text = "100";
            this.txtNumNumbers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "# Numbers:";
            // 
            // howto_plinq_primes_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 261);
            this.Controls.Add(this.lblRandom);
            this.Controls.Add(this.lblPlinq);
            this.Controls.Add(this.lblLinq);
            this.Controls.Add(this.lstPlinq);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstLinq);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstAllNumbers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtNumNumbers);
            this.Controls.Add(this.label1);
            this.Name = "howto_plinq_primes_Form1";
            this.Text = "howto_plinq_primes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRandom;
        private System.Windows.Forms.Label lblPlinq;
        private System.Windows.Forms.Label lblLinq;
        private System.Windows.Forms.ListBox lstPlinq;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstLinq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstAllNumbers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtNumNumbers;
        private System.Windows.Forms.Label label1;
    }
}

