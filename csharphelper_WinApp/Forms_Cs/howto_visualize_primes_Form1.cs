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
     public partial class howto_visualize_primes_Form1:Form
  { 


        public howto_visualize_primes_Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            txtNumPrimes.Clear();
            picBitmap.Image = null;
            picBitmap.Refresh();
            Cursor = Cursors.WaitCursor;

            // Make a sieve.
            int num_rows = int.Parse(txtNumRows.Text);
            int num_cols = int.Parse(txtNumColumns.Text);
            int length = num_rows * num_cols;
            bool[] is_prime = MakeSieve(length);

            // Make the bitmap.
            Bitmap bm = MakeBitmap(is_prime, num_cols, num_rows);

            // Display the result.
            picBitmap.Image = bm;

            // Display the number of primes.
            int num_primes = 0;
            for (int i = 2; i < length; i++)
                if (is_prime[i]) num_primes++;
            txtNumPrimes.Text = num_primes.ToString();

            Cursor = Cursors.Default;
        }

        // Build Euler's Sieve.
        private bool[] MakeSieve(int max)
        {
            // Make an array indicating whether numbers are prime.
            bool[] is_prime = new bool[max + 1];
            is_prime[2] = true;
            for (int i = 3; i <= max; i += 2) is_prime[i] = true;

            // Cross out multiples of odd primes.
            for (int p = 3; p <= max; p += 2)
            {
                // See if i is prime.
                if (is_prime[p])
                {
                    // Knock out multiples of p.
                    int max_q = max / p;
                    if (max_q % 2 == 0) max_q--;    // Make it odd.
                    for (int q = max_q; q >= p; q -= 2)
                    {
                        // Only use q if it is prime.
                        if (is_prime[q]) is_prime[p * q] = false;
                    }
                }
            }
            return is_prime;
        }

        // Make a bitmap showing the primes.
        private Bitmap MakeBitmap(bool[] is_prime, int wid, int hgt)
        {
            // Make the bitmap.
            Bitmap bm = new Bitmap(wid, hgt);

            // Set the pixels.
            int index = 0;
            for (int y = 0; y < hgt; y++)
            {
                for (int x = 0; x < wid; x++)
                {
                    if ((index % 2 == 1) && (is_prime[index]))
                        bm.SetPixel(x, y, Color.Red);
                    else
                        bm.SetPixel(x, y, Color.Black);
                    index++;
                }
            }

            // Fix 0, 1, and 2. (Assumes num_cols >= 3.)
            bm.SetPixel(0, 0, Color.Blue);
            bm.SetPixel(1, 0, Color.Blue);
            bm.SetPixel(2, 0, Color.Red);

            return bm;
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
            this.txtNumRows = new System.Windows.Forms.TextBox();
            this.txtNumColumns = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.picBitmap = new System.Windows.Forms.PictureBox();
            this.panScroller = new System.Windows.Forms.Panel();
            this.txtNumPrimes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBitmap)).BeginInit();
            this.panScroller.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "# Rows:";
            // 
            // txtNumRows
            // 
            this.txtNumRows.Location = new System.Drawing.Point(74, 12);
            this.txtNumRows.Name = "txtNumRows";
            this.txtNumRows.Size = new System.Drawing.Size(52, 20);
            this.txtNumRows.TabIndex = 1;
            this.txtNumRows.Text = "100";
            this.txtNumRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNumColumns
            // 
            this.txtNumColumns.Location = new System.Drawing.Point(74, 38);
            this.txtNumColumns.Name = "txtNumColumns";
            this.txtNumColumns.Size = new System.Drawing.Size(52, 20);
            this.txtNumColumns.TabIndex = 3;
            this.txtNumColumns.Text = "100";
            this.txtNumColumns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "# Columns:";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(132, 24);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // picBitmap
            // 
            this.picBitmap.Location = new System.Drawing.Point(0, 0);
            this.picBitmap.Name = "picBitmap";
            this.picBitmap.Size = new System.Drawing.Size(100, 50);
            this.picBitmap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBitmap.TabIndex = 5;
            this.picBitmap.TabStop = false;
            // 
            // panScroller
            // 
            this.panScroller.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panScroller.AutoScroll = true;
            this.panScroller.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panScroller.Controls.Add(this.picBitmap);
            this.panScroller.Location = new System.Drawing.Point(12, 64);
            this.panScroller.Name = "panScroller";
            this.panScroller.Size = new System.Drawing.Size(339, 185);
            this.panScroller.TabIndex = 6;
            // 
            // txtNumPrimes
            // 
            this.txtNumPrimes.Location = new System.Drawing.Point(270, 12);
            this.txtNumPrimes.Name = "txtNumPrimes";
            this.txtNumPrimes.ReadOnly = true;
            this.txtNumPrimes.Size = new System.Drawing.Size(81, 20);
            this.txtNumPrimes.TabIndex = 8;
            this.txtNumPrimes.Text = "100";
            this.txtNumPrimes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "# Primes:";
            // 
            // howto_visualize_primes_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 261);
            this.Controls.Add(this.txtNumPrimes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panScroller);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtNumColumns);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumRows);
            this.Controls.Add(this.label1);
            this.Name = "howto_visualize_primes_Form1";
            this.Text = "howto_visualize_primes";
            ((System.ComponentModel.ISupportInitialize)(this.picBitmap)).EndInit();
            this.panScroller.ResumeLayout(false);
            this.panScroller.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumRows;
        private System.Windows.Forms.TextBox txtNumColumns;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.PictureBox picBitmap;
        private System.Windows.Forms.Panel panScroller;
        private System.Windows.Forms.TextBox txtNumPrimes;
        private System.Windows.Forms.Label label3;
    }
}

