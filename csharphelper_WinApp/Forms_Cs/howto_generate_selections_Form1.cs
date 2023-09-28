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
     public partial class howto_generate_selections_Form1:Form
  { 


        public howto_generate_selections_Form1()
        {
            InitializeComponent();
        }

        // Generate the combinations.
        private void btnGo_Click(object sender, EventArgs e)
        {
            // Get the items and N.
            string[] items = txtItems.Text.Split(' ');
            int n = int.Parse(txtNumPerSelection.Text);

            // Generate the selections.
            List<List<string>> results =
                GenerateSelections<string>(items.ToList(), n);

            // Display the results.
            lstSelections.Items.Clear();
            foreach (List<string> combination in results)
            {
                lstSelections.Items.Add(string.Join(" ", combination.ToArray()));
            }

            // Calculate the number of items.
            decimal num_combinations = NChooseK(items.Length, n);
            txtNumSelections.Text = num_combinations.ToString();

            // Check the result.
            Debug.Assert(lstSelections.Items.Count == num_combinations);
        }

        // Generate selections of n items.
        private List<List<T>> GenerateSelections<T>(List<T> items, int n)
        {
            // Make an array to tell whether
            // an item is in the current selection.
            bool[] in_selection = new bool[items.Count];

            // Make a result list.
            List<List<T>> results = new List<List<T>>();

            // Build the combinations recursively.
            SelectItems<T>(items, in_selection, results, n, 0);

            // Return the results.
            return results;
        }

        // Recursively select n additional items with indexes >= first_item.
        // If n == 0, add the current combination to the results.
        private void SelectItems<T>(List<T> items, bool[] in_selection,
            List<List<T>> results, int n, int first_item)
        {
            if (n == 0)
            {
                // Add the current selection to the results.
                List<T> selection = new List<T>();
                for (int i = 0; i < items.Count; i++)
                {
                    // If this item is selected, add it to the selection.
                    if (in_selection[i]) selection.Add(items[i]);
                }
                results.Add(selection);
            }
            else
            {
                // Try adding each of the remaining items.
                for (int i = first_item; i < items.Count; i++)
                {
                    // Try adding this item.
                    in_selection[i] = true;

                    // Recursively add the rest of the required items.
                    SelectItems(items, in_selection, results, n - 1, i + 1);

                    // Remove this item from the selection.
                    in_selection[i] = false;
                }
            }
        }

        // Return N choose K calculated directly.
        // For a description of the algorithm, see:
        //      http://csharphelper.com/blog/2014/08/calculate-the-binomial-coefficient-n-choose-k-efficiently-in-c/
        private decimal NChooseK(decimal N, decimal K)
        {
            Debug.Assert(N >= 0);
            Debug.Assert(K >= 0);
            Debug.Assert(N >= K);

            decimal result = 1;
            for (int i = 1; i <= K; i++)
            {
                result *= N - (K - i);
                result /= i;
            }
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
            this.txtNumSelections = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lstSelections = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtItems = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumPerSelection = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNumSelections
            // 
            this.txtNumSelections.Location = new System.Drawing.Point(97, 117);
            this.txtNumSelections.Name = "txtNumSelections";
            this.txtNumSelections.ReadOnly = true;
            this.txtNumSelections.Size = new System.Drawing.Size(37, 20);
            this.txtNumSelections.TabIndex = 24;
            this.txtNumSelections.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "# Selections:";
            // 
            // lstSelections
            // 
            this.lstSelections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSelections.FormattingEnabled = true;
            this.lstSelections.IntegralHeight = false;
            this.lstSelections.Location = new System.Drawing.Point(13, 168);
            this.lstSelections.Name = "lstSelections";
            this.lstSelections.Size = new System.Drawing.Size(325, 131);
            this.lstSelections.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Selections:";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGo.Location = new System.Drawing.Point(138, 81);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 20;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtItems
            // 
            this.txtItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItems.Location = new System.Drawing.Point(12, 25);
            this.txtItems.Name = "txtItems";
            this.txtItems.Size = new System.Drawing.Size(325, 20);
            this.txtItems.TabIndex = 19;
            this.txtItems.Text = "Ape Bear Cat Dog Elf";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Items:";
            // 
            // txtNumPerSelection
            // 
            this.txtNumPerSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumPerSelection.Location = new System.Drawing.Point(129, 55);
            this.txtNumPerSelection.Name = "txtNumPerSelection";
            this.txtNumPerSelection.Size = new System.Drawing.Size(39, 20);
            this.txtNumPerSelection.TabIndex = 26;
            this.txtNumPerSelection.Text = "3";
            this.txtNumPerSelection.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "# Items Per Selection:";
            // 
            // howto_generate_selections_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 311);
            this.Controls.Add(this.txtNumPerSelection);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumSelections);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstSelections);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtItems);
            this.Controls.Add(this.label1);
            this.Name = "howto_generate_selections_Form1";
            this.Text = "howto_generate_selections";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumSelections;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstSelections;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumPerSelection;
        private System.Windows.Forms.Label label2;
    }
}

