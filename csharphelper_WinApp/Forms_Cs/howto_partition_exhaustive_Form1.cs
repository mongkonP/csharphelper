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
     public partial class howto_partition_exhaustive_Form1:Form
  { 


        public howto_partition_exhaustive_Form1()
        {
            InitializeComponent();
        }

        private void btnPartition_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            txtItems1.Clear();
            txtItems2.Clear();
            txtTotal1.Clear();
            txtTotal2.Clear();
            Application.DoEvents();
            DateTime start_time = DateTime.Now;

            // Get the item values.
            string[] strings = txtItemValues.Lines;
            int[] values = new int[strings.Length];
            for (int i = 0; i < strings.Length; i++)
            {
                values[i] = int.Parse(strings[i]);
            }

            // Partition the values.
            bool[] best_assignment = PartitionValues(values);

            // Display the results.
            string result1 = "", result2 = "";
            int total1 = 0, total2 = 0;
            for (int i = 0; i < best_assignment.Length; i++)
            {
                if (best_assignment[i])
                {
                    result1 += "\r\n" + values[i];
                    total1 += values[i];
                }
                else
                {
                    result2 += "\r\n" + values[i];
                    total2 += values[i];
                }
            }
            if (result1.Length > 0) result1 = result1.Substring(2);
            if (result2.Length > 0) result2 = result2.Substring(2);

            txtItems1.Text = result1;
            txtItems2.Text = result2;
            txtTotal1.Text = total1.ToString();
            txtTotal2.Text = total2.ToString();

            DateTime stop_time = DateTime.Now;
            this.Cursor = Cursors.Default;
            TimeSpan elapsed = stop_time - start_time;
            lblElapsed.Text = elapsed.TotalSeconds.ToString("0.00") + " seconds";
        }

        // Partition the values. Return an array with entry i = true if
        // value i belongs in the first set of the partition.
        private bool[] PartitionValues(int[] values)
        {
            // Make variables to track the best solution and a test solution.
            bool[] best_assignment = new bool[values.Length];
            bool[] test_assignment = new bool[values.Length];

            // Get the total of all values.
            int total_value = values.Sum();

            // Partition the values starting with index 0.
            int best_err = total_value;
            PartitionValuesFromIndex(values, 0, total_value, test_assignment, 0, ref best_assignment, ref best_err);

            // Return the result.
            return best_assignment;
        }

        // Partition the values keeping those before index start_index fixed.
        // test_assignment is the test assignment so far.
        // test_value is the total value of the first set in the test assignment.
        // Initially best assignment and its error are in best_assignment and best_err.
        // Update those to reflect any improved solution we find.
        private void PartitionValuesFromIndex(int[] values, int start_index, int total_value,
            bool[] test_assignment, int test_value,
            ref bool[] best_assignment, ref int best_err)
        {
            // If start_index is beyond the end of the array,
            // then all entries have been assigned.
            if (start_index >= values.Length)
            {
                // We're done. See if this assignment is better than what we have so far.
                int test_err = Math.Abs(2 * test_value - total_value);
                if (test_err < best_err)
                {
                    // This is an improvement. Save it.
                    best_err = test_err;
                    best_assignment = (bool[])test_assignment.Clone();
                }
            }
            else
            {
                // Try adding values[start_index] to set 1.
                test_assignment[start_index] = true;
                PartitionValuesFromIndex(values, start_index + 1, total_value,
                    test_assignment, test_value + values[start_index],
                    ref best_assignment, ref best_err);

                // Try adding values[start_index] to set 2.
                test_assignment[start_index] = false;
                PartitionValuesFromIndex(values, start_index + 1, total_value,
                    test_assignment, test_value,
                    ref best_assignment, ref best_err);
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
            this.txtTotal2 = new System.Windows.Forms.TextBox();
            this.txtTotal1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtItems2 = new System.Windows.Forms.TextBox();
            this.txtItems1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPartition = new System.Windows.Forms.Button();
            this.txtItemValues = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblElapsed = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTotal2
            // 
            this.txtTotal2.Location = new System.Drawing.Point(233, 235);
            this.txtTotal2.Name = "txtTotal2";
            this.txtTotal2.ReadOnly = true;
            this.txtTotal2.Size = new System.Drawing.Size(64, 20);
            this.txtTotal2.TabIndex = 17;
            // 
            // txtTotal1
            // 
            this.txtTotal1.Location = new System.Drawing.Point(163, 235);
            this.txtTotal1.Name = "txtTotal1";
            this.txtTotal1.ReadOnly = true;
            this.txtTotal1.Size = new System.Drawing.Size(64, 20);
            this.txtTotal1.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Totals:";
            // 
            // txtItems2
            // 
            this.txtItems2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtItems2.Location = new System.Drawing.Point(233, 29);
            this.txtItems2.Multiline = true;
            this.txtItems2.Name = "txtItems2";
            this.txtItems2.ReadOnly = true;
            this.txtItems2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtItems2.Size = new System.Drawing.Size(64, 200);
            this.txtItems2.TabIndex = 14;
            this.txtItems2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtItems1
            // 
            this.txtItems1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtItems1.Location = new System.Drawing.Point(163, 29);
            this.txtItems1.Multiline = true;
            this.txtItems1.Name = "txtItems1";
            this.txtItems1.ReadOnly = true;
            this.txtItems1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtItems1.Size = new System.Drawing.Size(64, 200);
            this.txtItems1.TabIndex = 13;
            this.txtItems1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(163, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Results:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPartition
            // 
            this.btnPartition.Location = new System.Drawing.Point(82, 27);
            this.btnPartition.Name = "btnPartition";
            this.btnPartition.Size = new System.Drawing.Size(75, 23);
            this.btnPartition.TabIndex = 11;
            this.btnPartition.Text = "Partition";
            this.btnPartition.UseVisualStyleBackColor = true;
            this.btnPartition.Click += new System.EventHandler(this.btnPartition_Click);
            // 
            // txtItemValues
            // 
            this.txtItemValues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtItemValues.Location = new System.Drawing.Point(12, 27);
            this.txtItemValues.Multiline = true;
            this.txtItemValues.Name = "txtItemValues";
            this.txtItemValues.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtItemValues.Size = new System.Drawing.Size(64, 200);
            this.txtItemValues.TabIndex = 10;
            this.txtItemValues.Text = "79\r\n83\r\n37\r\n41\r\n16\r\n22\r\n23\r\n50\r\n36\r\n79\r\n24\r\n81\r\n94\r\n63\r\n79\r\n60\r\n67\r\n26\r\n73\r\n96\r\n2" +
                "4\r\n93\r\n18\r\n66\r\n79";
            this.txtItemValues.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Values:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblElapsed
            // 
            this.lblElapsed.AutoSize = true;
            this.lblElapsed.Location = new System.Drawing.Point(13, 236);
            this.lblElapsed.Name = "lblElapsed";
            this.lblElapsed.Size = new System.Drawing.Size(0, 13);
            this.lblElapsed.TabIndex = 18;
            // 
            // howto_partition_exhaustive_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 264);
            this.Controls.Add(this.lblElapsed);
            this.Controls.Add(this.txtTotal2);
            this.Controls.Add(this.txtTotal1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtItems2);
            this.Controls.Add(this.txtItems1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPartition);
            this.Controls.Add(this.txtItemValues);
            this.Controls.Add(this.label1);
            this.Name = "howto_partition_exhaustive_Form1";
            this.Text = "howto_partition_exhaustive";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTotal2;
        private System.Windows.Forms.TextBox txtTotal1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtItems2;
        private System.Windows.Forms.TextBox txtItems1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPartition;
        private System.Windows.Forms.TextBox txtItemValues;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblElapsed;
    }
}

