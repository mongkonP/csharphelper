using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_find_composite_runs_Form1:Form
  { 


        public howto_find_composite_runs_Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            btnGo.Enabled = false;
            txtResults.Clear();
            Cursor = Cursors.WaitCursor;
            Refresh();

            int desired_length = int.Parse(txtNumComposites.Text);

            for (int length = 100; length <= 100000000; length *= 10)
            {
                // Make the sieve.
                bool[] is_prime = MakeSieve(length);

                // Look for a run.
                int run_start, run_length;
                run_start = FindRun(is_prime, desired_length, out run_length);

                // See if we found the desired run.
                if (run_start >= 0)
                {
                    string txt = "Run length " + run_length.ToString() + ":\r\n";
                    int found = 0;
                    for (int i = run_start; i < is_prime.Length; i++)
                    {
                        if (is_prime[i]) break;
                        txt += i.ToString() + " ";
                        found++;
                    }
                    txtResults.Text = txt;
                    Debug.Assert(found == run_length);
                    break;
                }
            }

            if (txtResults.Text.Length == 0)
                txtResults.Text = "Not found";

            btnGo.Enabled = true;
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

        // Return the index of the beginning of a run with the desried length.
        private int FindRun(bool[] is_prime, int desired_length, out int found_length)
        {
            // Make sure there is at least 1 composite number (4).
            Debug.Assert(is_prime.Length > 5);

            // Examine values.
            found_length = 0;
            int run_start = -1;
            bool in_run = false;
            for (int i = 4; i < is_prime.Length; i++)
            {
                // See if this value is prime.
                if (is_prime[i])
                {
                    // The previous run is ending. (We know there was a run
                    // because every prime is preceded by a multiple of 2.)

                    // See if the previous run is long enough.
                    if (found_length >= desired_length)
                    {
                        // Return this run.
                        return run_start;
                    }

                    // We're no longer in a run.
                    in_run = false;
                    found_length = 0;
                }
                else
                {
                    if (!in_run)
                    {
                        // Start a run.
                        in_run = true;
                        run_start = i;
                    }
                    found_length++;     // Continue the run.
                }
            }

            // See if we finished with a run of the desired length.
            if (in_run && (found_length >= desired_length))
            {
                // Return this run.
                return run_start;
            }
            return -1;
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
            this.txtResults = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtNumComposites = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtResults
            // 
            this.txtResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResults.Location = new System.Drawing.Point(12, 40);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResults.Size = new System.Drawing.Size(360, 209);
            this.txtResults.TabIndex = 7;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(297, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtNumComposites
            // 
            this.txtNumComposites.Location = new System.Drawing.Point(92, 14);
            this.txtNumComposites.Name = "txtNumComposites";
            this.txtNumComposites.Size = new System.Drawing.Size(49, 20);
            this.txtNumComposites.TabIndex = 5;
            this.txtNumComposites.Text = "10";
            this.txtNumComposites.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "# Composites:";
            // 
            // howto_find_composite_runs_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtNumComposites);
            this.Controls.Add(this.label1);
            this.Name = "howto_find_composite_runs_Form1";
            this.Text = "howto_find_composite_runs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtNumComposites;
        private System.Windows.Forms.Label label1;
    }
}

