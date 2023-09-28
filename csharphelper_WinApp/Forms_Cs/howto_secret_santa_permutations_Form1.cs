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
     public partial class howto_secret_santa_permutations_Form1:Form
  { 


        public howto_secret_santa_permutations_Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            txtTotal.Clear();
            txtFound.Clear();
            txtPercentValid.Clear();
            txtSubfactorial.Clear();
            Refresh();

            int N = int.Parse(txtNumPeople.Text);

            // Calculate the total number of permutations.
            decimal total = -1;
            try
            {
                total = Factorial(N);
                txtTotal.Text = total.ToString("N0");
            }
            catch
            {
                txtTotal.Text = "<Too many>";
            }

            // Calculate the number of derangements.
            decimal subfactorial = -1;
            try
            {
                subfactorial = Subfactorial(N);
                txtSubfactorial.Text = subfactorial.ToString("N0");
            }
            catch
            {
                txtSubfactorial.Text = "<Too many>";
            }

            // Calculate the percentage of valid permutations.
            if ((total < 0) || (subfactorial < 0))
            {
                txtPercentValid.Text = "<Too many>";
            }
            else
            {
                decimal percent = subfactorial / total;
                txtPercentValid.Text = percent.ToString("P");
            }

            if (N > 10)
            {
                txtFound.Text = "<Too many>";
                Cursor = Cursors.Default;
                return;
            }

            // Get the valid permutations.
            List<List<int>> permutations =
                SecretSantaPermutations(N);

            int num_valid = permutations.Count;
            txtFound.Text = num_valid.ToString("N0");

            // Display up to 1,000 permutations.
            if (num_valid > 1001) num_valid = 1001;
            string[] results = new string[num_valid];
            for (int i = 0; i < num_valid; i++)
            {
                results[i] = "";
                for (int j = 0; j < permutations[i].Count; j++)
                    results[i] += permutations[i][j].ToString() + " ";
            }
            if (permutations.Count > num_valid)
                results[num_valid - 1] = "...";
            lstValid.DataSource = results;

            Cursor = Cursors.Default;
        }

        // Calculate the factorial.
        private decimal Factorial(decimal N)
        {
            decimal result = 1;
            for (int i = 2; i <= N; i++)
                result *= i;
            return result;
        }

        // Calculate the subfactorial.
        private decimal Subfactorial(decimal N)
        {
            if (N == 0) return 1;
            if (N == 1) return 0;
            return (N - 1) * (Subfactorial(N - 1) + Subfactorial(N - 2));
        }

        // Generate all valid permutations.
        List<List<int>> SecretSantaPermutations(int N)
        {
            // A test assignment.
            int[] assignments = new int[N];

            // is_assigned[i] = true if person i has been assigned.
            bool[] is_assigned = new bool[N];

            // The valid permutations.
            List<List<int>> permutations = new List<List<int>>();

            // Make the permutations.
            AssignPerson(permutations, 0, N, assignments, is_assigned);

            // Return the valid permutations.
            return permutations;
        }

        // Assign the next person to position pos.
        void AssignPerson(List<List<int>> valid,
            int pos, int N, int[] assignments, bool[] is_assigned)
        {
            // If pos >= N, then we have a complete assigment.
            if (pos >= N)
            {
                // Save this assignment.
                List<int> result = new List<int>();
                for (int i = 0; i < N; i++)
                    result.Add(assignments[i]);
                valid.Add(result);
            }
            else
            {
                // Assign people to position pos.
                for (int per = 0; per < N; per++)
                {
                    // See if person per has been assigned.
                    // Only make the assigment if per != pos.
                    if ((per != pos) && (!is_assigned[per]))
                    {
                        // Assign person per to position pos.
                        assignments[pos] = per;
                        is_assigned[per] = true;

                        // Recursively try other assignments.
                        AssignPerson(valid, pos + 1, N, assignments, is_assigned);

                        // Unassign person per from position pos.
                        is_assigned[per] = false;
                    }
                }
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
            this.btnCalculate = new System.Windows.Forms.Button();
            this.txtNumPeople = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPercentValid = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFound = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstValid = new System.Windows.Forms.ListBox();
            this.txtSubfactorial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalculate.Location = new System.Drawing.Point(297, 12);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 1;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // txtNumPeople
            // 
            this.txtNumPeople.Location = new System.Drawing.Point(71, 14);
            this.txtNumPeople.Name = "txtNumPeople";
            this.txtNumPeople.Size = new System.Drawing.Size(63, 20);
            this.txtNumPeople.TabIndex = 0;
            this.txtNumPeople.Text = "5";
            this.txtNumPeople.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "# People:";
            // 
            // txtPercentValid
            // 
            this.txtPercentValid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPercentValid.Location = new System.Drawing.Point(122, 112);
            this.txtPercentValid.Name = "txtPercentValid";
            this.txtPercentValid.ReadOnly = true;
            this.txtPercentValid.Size = new System.Drawing.Size(250, 20);
            this.txtPercentValid.TabIndex = 4;
            this.txtPercentValid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "% Valid:";
            // 
            // txtValid
            // 
            this.txtFound.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFound.Location = new System.Drawing.Point(122, 138);
            this.txtFound.Name = "txtValid";
            this.txtFound.ReadOnly = true;
            this.txtFound.Size = new System.Drawing.Size(250, 20);
            this.txtFound.TabIndex = 5;
            this.txtFound.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Permutations Found:";
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.Location = new System.Drawing.Point(122, 60);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(250, 20);
            this.txtTotal.TabIndex = 2;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Total Permutations:";
            // 
            // lstValid
            // 
            this.lstValid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstValid.FormattingEnabled = true;
            this.lstValid.IntegralHeight = false;
            this.lstValid.Location = new System.Drawing.Point(12, 164);
            this.lstValid.Name = "lstValid";
            this.lstValid.Size = new System.Drawing.Size(360, 185);
            this.lstValid.TabIndex = 6;
            // 
            // txtSubfactorial
            // 
            this.txtSubfactorial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubfactorial.Location = new System.Drawing.Point(122, 86);
            this.txtSubfactorial.Name = "txtSubfactorial";
            this.txtSubfactorial.ReadOnly = true;
            this.txtSubfactorial.Size = new System.Drawing.Size(250, 20);
            this.txtSubfactorial.TabIndex = 3;
            this.txtSubfactorial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Subfactorial:";
            // 
            // howto_secret_santa_permutations_Form1
            // 
            this.AcceptButton = this.btnCalculate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.txtSubfactorial);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstValid);
            this.Controls.Add(this.txtPercentValid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFound);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtNumPeople);
            this.Controls.Add(this.label1);
            this.Name = "howto_secret_santa_permutations_Form1";
            this.Text = "howto_secret_santa_permutations";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.TextBox txtNumPeople;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPercentValid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFound;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstValid;
        private System.Windows.Forms.TextBox txtSubfactorial;
        private System.Windows.Forms.Label label3;
    }
}

