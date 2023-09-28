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
     public partial class howto_generate_permutations_Form1:Form
  { 


        public howto_generate_permutations_Form1()
        {
            InitializeComponent();
        }

        // Generate the combinations.
        private void btnGo_Click(object sender, EventArgs e)
        {
            // Get the items.
            string[] items = txtItems.Text.Split(' ');

            // Generate the permutations.
            List<List<string>> results =
                GeneratePermutations<string>(items.ToList());

            // Display the results.
            lstPermutations.Items.Clear();
            foreach (List<string> combination in results)
            {
                lstPermutations.Items.Add(string.Join(" ", combination.ToArray()));
            }

            // Calculate the number of permutations.
            long num_permutations = Factorial(items.Length);
            txtNumPermutations.Text = num_permutations.ToString();

            // Check the result.
            Debug.Assert(lstPermutations.Items.Count == num_permutations);
        }

        // Generate permutations.
        private List<List<T>> GeneratePermutations<T>(List<T> items)
        {
            // Make an array to hold the
            // permutation we are building.
            T[] current_permutation = new T[items.Count];

            // Make an array to tell whether
            // an item is in the current selection.
            bool[] in_selection = new bool[items.Count];

            // Make a result list.
            List<List<T>> results = new List<List<T>>();

            // Build the combinations recursively.
            PermuteItems<T>(items, in_selection,
                current_permutation, results, 0);

            // Return the results.
            return results;
        }

        // Recursively permute the items that are
        // not yet in the current selection.
        private void PermuteItems<T>(List<T> items, bool[] in_selection,
            T[] current_permutation, List<List<T>> results, int next_position)
        {
            // See if all of the positions are filled.
            if (next_position == items.Count)
            {
                // All of the positioned are filled.
                // Save this permutation.
                results.Add(current_permutation.ToList());
            }
            else
            {
                // Try options for the next position.
                for (int i = 0; i < items.Count; i++)
                {
                    if (!in_selection[i])
                    {
                        // Add this item to the current permutation.
                        in_selection[i] = true;
                        current_permutation[next_position] = items[i];

                        // Recursively fill the remaining positions.
                        PermuteItems<T>(items, in_selection,
                            current_permutation, results, next_position + 1);

                        // Remove the item from the current permutation.
                        in_selection[i] = false;
                    }
                }
            }
        }

        // Return n!
        private long Factorial(long n)
        {
            long result = 1;
            for (int i = 2; i <= n; i++) result *= i;
            return result;
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
            this.txtItems = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lstPermutations = new System.Windows.Forms.ListBox();
            this.txtNumPermutations = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Items:";
            // 
            // txtItems
            // 
            this.txtItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItems.Location = new System.Drawing.Point(12, 25);
            this.txtItems.Name = "txtItems";
            this.txtItems.Size = new System.Drawing.Size(322, 20);
            this.txtItems.TabIndex = 1;
            this.txtItems.Text = "Ape Bear Cat Dog Elf";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGo.Location = new System.Drawing.Point(137, 51);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Permutations:";
            // 
            // lstPermutations
            // 
            this.lstPermutations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPermutations.FormattingEnabled = true;
            this.lstPermutations.Location = new System.Drawing.Point(12, 138);
            this.lstPermutations.Name = "lstPermutations";
            this.lstPermutations.Size = new System.Drawing.Size(325, 108);
            this.lstPermutations.TabIndex = 6;
            // 
            // txtNumPermutations
            // 
            this.txtNumPermutations.Location = new System.Drawing.Point(96, 87);
            this.txtNumPermutations.Name = "txtNumPermutations";
            this.txtNumPermutations.ReadOnly = true;
            this.txtNumPermutations.Size = new System.Drawing.Size(37, 20);
            this.txtNumPermutations.TabIndex = 17;
            this.txtNumPermutations.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "# Permutations:";
            // 
            // howto_generate_permutations_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 258);
            this.Controls.Add(this.txtNumPermutations);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstPermutations);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtItems);
            this.Controls.Add(this.label1);
            this.Name = "howto_generate_permutations_Form1";
            this.Text = "howto_generate_permutations";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtItems;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstPermutations;
        private System.Windows.Forms.TextBox txtNumPermutations;
        private System.Windows.Forms.Label label4;
    }
}

