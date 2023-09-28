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
     public partial class howto_compare_sorts_Form1:Form
  { 


        public howto_compare_sorts_Form1()
        {
            InitializeComponent();
        }

        // If the Sorted box is checked, enable the % Unsorted text box.
        private void chkSorted_CheckedChanged(object sender, EventArgs e)
        {
            txtNumUnsorted.Enabled = (chkSorted.Checked);
            lblPercentUnsorted.Enabled = txtNumUnsorted.Enabled;
        }

        // A random number generators used by various algorithms.
        private Random Rand = new Random();

        // The data to sort.
        private int[] Values = null, SortedValues = null;
        private int NumItems, MaxValue;

        // Prepare the data to sort.
        private void PrepareData()
        {
            // Allocate space.
            NumItems = int.Parse(txtNumItems.Text);
            Values = new int[NumItems];
            SortedValues = new int[NumItems];

            // Make random values.
            MaxValue = int.Parse(txtMaxValue.Text);
            for (int i = 0; i < NumItems; i++)
            {
                Values[i] = Rand.Next(0, MaxValue + 1);
            }

            // Sort the values if necessary.
            if (chkSorted.Checked)
            {
                Array.Sort(Values);

                // Unsort some of the values.
                int num_unsorted = int.Parse(txtNumUnsorted.Text);
                for (int i = 0; i < num_unsorted; i++)
                {
                    // Pick two items to swap.
                    int index1 = Rand.Next(0, NumItems);
                    int index2 = Rand.Next(0, NumItems);
                    int temp = Values[index1];
                    Values[index1] = Values[index2];
                    Values[index2] = temp;
                }
            }
        }

        // Sort with Bubblesort.
        private void btnBubblesort_Click(object sender, EventArgs e)
        {
            RunAlgorithm(txtTimeBubblesort, Bubblesort);
        }

        // Sort with Array.Sort.
        private void btnArraySort_Click(object sender, EventArgs e)
        {
            RunAlgorithm(txtTimeArraySort, ArraySort);
        }

        // Sort with Selectionsort.
        private void btnSelectionsort_Click(object sender, EventArgs e)
        {
            RunAlgorithm(txtTimeSelectionsort, Selectionsort);
        }

        // Sort with Quicksort.
        private void btnQuicksort_Click(object sender, EventArgs e)
        {
            RunAlgorithm(txtTimeQuicksort, Quicksort);
        }

        // Sort with Countingsort.
        private void btnCountingsort_Click(object sender, EventArgs e)
        {
            RunAlgorithm(txtTimeCountingsort, Countingsort);
        }

        // Run an algorithm.
        private delegate void Algorithm(int[] values);
        private void RunAlgorithm(TextBox time_textbox, Algorithm algorithm)
        {
            time_textbox.Clear();
            Cursor = Cursors.WaitCursor;
            Refresh();
            int num_trials = int.Parse(txtNumTrials.Text);

            // Prepare the data.
            PrepareData();

            Stopwatch watch = new Stopwatch();
            for (int trial = 0; trial < num_trials; trial++)
            {
                // Copy the unsorted data into the SortedValues array.
                Array.Copy(Values, SortedValues, NumItems);

                // Run the algorithm.
                watch.Start();
                algorithm(SortedValues);
                watch.Stop();
            }

            // Display the total time.
            time_textbox.Text = watch.Elapsed.TotalSeconds.ToString("0.00") + " sec";

            // Verify that the algorithm worked.
            Verify();

            Cursor = Cursors.Default;
        }

        // Verify that the values are sorted.
        private void Verify()
        {
            for (int i = 1; i < NumItems; i++)
            {
                if (SortedValues[i] < SortedValues[i - 1])
                {
                    MessageBox.Show("The values are not sorted.\n" +
                        "SortedValues[" + i + "] = " + SortedValues[i] +
                        " < " + "SortedValues[" + (i - 1) + "] = " + SortedValues[i - 1],
                        "Sorting Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
        }

        #region Algorithms

        // Sort with Array.Sort.
        private void ArraySort(int[] values)
        {
            // Sort.
            Array.Sort(values);
        }

        // Bubblesort with:
        //   - Alternating upward and downward passes
        //   - Holding bubbled item in a temporary variable
        //   - Updating min and max to narrow the search range
        private void Bubblesort(int[] values)
        {
            int min = 0;
            int max = NumItems - 1;
            while (min < max)
            {
                // Bubble up.
                int last_swap = min - 1;
                // For i = min + 1 To max
                int i = min + 1;
                while (i <= max)
                {
                    // Find a bubble.
                    if (values[i - 1] > values[i])
                    {
                        // See where to drop the bubble.
                        int tmp = values[i - 1];
                        int j = i;
                        do
                        {
                            values[j - 1] = values[j];
                            j++;
                            if (j > max) break;
                        } while (values[j] < tmp);
                        values[j - 1] = tmp;
                        last_swap = j - 1;
                        i = j + 1;
                    }
                    else
                    {
                        i++;
                    }
                }
                // Update max.
                max = last_swap - 1;

                // Bubble down.
                last_swap = max + 1;
                // For i = max - 1 To min Step -1
                i = max - 1;
                while (i >= min)
                {
                    // Find a bubble.
                    if (values[i + 1] < values[i])
                    {
                        // See where to drop the bubble.
                        int tmp = values[i + 1];
                        int j = i;
                        do
                        {
                            values[j + 1] = values[j];
                            j--;
                            if (j < min) break;
                        } while (values[j] > tmp);
                        values[j + 1] = tmp;
                        last_swap = j + 1;
                        i = j - 1;
                    }
                    else
                    {
                        i--;
                    }
                }
                // Update min.
                min = last_swap + 1;
            }
        }

        // Selectionsort.
        private void Selectionsort(int[] values)
        {
            for (int i = 0; i < NumItems - 1; i++)
            {
                int best_value = values[i];
                int best_j = i;
                for (int j = i + 1; j < NumItems; j++)
                {
                    if (values[j] < best_value)
                    {
                        best_value = values[j];
                        best_j = j;
                    }
                }
                values[best_j] = values[i];
                values[i] = best_value;
            }
        }

        // Quicksort.
        private void Quicksort(int[] values)
        {
            Quicksort(values, 0, NumItems - 1);
        }

        // Use Quicksort to recursively sort
        // the items with indexes min <= i <= max.
        private void Quicksort(int[] values, int min, int max)
        {
            // If the list has no more than 1 element, it's sorted.
            if (min >= max) return;

            // Pick a dividing item.
            int i = Rand.Next(min, max + 1);
            int med_value = values[i];

            // Swap it to the front so we can find it easily.
            values[i] = values[min];

            // Move the items smaller than this into the left
            // half of the list. Move the others into the right.
            int lo = min;
            int hi = max;
            for (; ; )
            {
                // Look down from hi for a value < med_value.
                while (values[hi] >= med_value)
                {
                    hi--;
                    if (hi <= lo) break;
                }
                if (hi <= lo)
                {
                    values[lo] = med_value;
                    break;
                }

                // Swap the lo and hi values.
                values[lo] = values[hi];

                // Look up from lo for a value >= med_value.
                lo++;
                while (values[lo] < med_value)
                {
                    lo++;
                    if (lo >= hi) break;
                }
                if (lo >= hi)
                {
                    lo = hi;
                    values[hi] = med_value;
                    break;
                }

                // Swap the lo and hi values.
                values[hi] = values[lo];
            }

            // Sort the two sublists
            Quicksort(values, min, lo - 1);
            Quicksort(values, lo + 1, max);
        }

        // Countingsort.
        private void Countingsort(int[] values)
        {
            // Create the Counts array.
            int[] counts = new int[MaxValue + 1];

            // Count the items.
            for (int i = 0; i < NumItems; i++)
            {
                counts[values[i]]++;
            }

            // Place items in the sorted array.
            int index = 0;
            for (int i = 0; i <= MaxValue; i++)
            {
                for (int j = 0; j < counts[i]; j++)
                {
                    values[index++] = i;
                }
            }
        }

        #endregion Algorithms

    

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
            this.txtTimeArraySort = new System.Windows.Forms.TextBox();
            this.btnArraySort = new System.Windows.Forms.Button();
            this.txtTimeCountingsort = new System.Windows.Forms.TextBox();
            this.txtTimeQuicksort = new System.Windows.Forms.TextBox();
            this.txtTimeSelectionsort = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTimeBubblesort = new System.Windows.Forms.TextBox();
            this.btnCountingsort = new System.Windows.Forms.Button();
            this.btnQuicksort = new System.Windows.Forms.Button();
            this.btnSelectionsort = new System.Windows.Forms.Button();
            this.btnBubblesort = new System.Windows.Forms.Button();
            this.txtMaxValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumTrials = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkSorted = new System.Windows.Forms.CheckBox();
            this.txtNumUnsorted = new System.Windows.Forms.TextBox();
            this.lblPercentUnsorted = new System.Windows.Forms.Label();
            this.txtNumItems = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTimeArraySort
            // 
            this.txtTimeArraySort.Location = new System.Drawing.Point(173, 261);
            this.txtTimeArraySort.Name = "txtTimeArraySort";
            this.txtTimeArraySort.ReadOnly = true;
            this.txtTimeArraySort.Size = new System.Drawing.Size(87, 20);
            this.txtTimeArraySort.TabIndex = 39;
            this.txtTimeArraySort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnArraySort
            // 
            this.btnArraySort.Location = new System.Drawing.Point(60, 259);
            this.btnArraySort.Name = "btnArraySort";
            this.btnArraySort.Size = new System.Drawing.Size(87, 23);
            this.btnArraySort.TabIndex = 38;
            this.btnArraySort.Text = "Array.Sort";
            this.btnArraySort.UseVisualStyleBackColor = true;
            this.btnArraySort.Click += new System.EventHandler(this.btnArraySort_Click);
            // 
            // txtTimeCountingsort
            // 
            this.txtTimeCountingsort.Location = new System.Drawing.Point(173, 232);
            this.txtTimeCountingsort.Name = "txtTimeCountingsort";
            this.txtTimeCountingsort.ReadOnly = true;
            this.txtTimeCountingsort.Size = new System.Drawing.Size(87, 20);
            this.txtTimeCountingsort.TabIndex = 37;
            this.txtTimeCountingsort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTimeQuicksort
            // 
            this.txtTimeQuicksort.Location = new System.Drawing.Point(173, 203);
            this.txtTimeQuicksort.Name = "txtTimeQuicksort";
            this.txtTimeQuicksort.ReadOnly = true;
            this.txtTimeQuicksort.Size = new System.Drawing.Size(87, 20);
            this.txtTimeQuicksort.TabIndex = 36;
            this.txtTimeQuicksort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTimeSelectionsort
            // 
            this.txtTimeSelectionsort.Location = new System.Drawing.Point(173, 174);
            this.txtTimeSelectionsort.Name = "txtTimeSelectionsort";
            this.txtTimeSelectionsort.ReadOnly = true;
            this.txtTimeSelectionsort.Size = new System.Drawing.Size(87, 20);
            this.txtTimeSelectionsort.TabIndex = 35;
            this.txtTimeSelectionsort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(173, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 23);
            this.label6.TabIndex = 34;
            this.label6.Text = "Time";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(60, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 23);
            this.label5.TabIndex = 33;
            this.label5.Text = "Algorithm";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTimeBubblesort
            // 
            this.txtTimeBubblesort.Location = new System.Drawing.Point(173, 145);
            this.txtTimeBubblesort.Name = "txtTimeBubblesort";
            this.txtTimeBubblesort.ReadOnly = true;
            this.txtTimeBubblesort.Size = new System.Drawing.Size(87, 20);
            this.txtTimeBubblesort.TabIndex = 32;
            this.txtTimeBubblesort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCountingsort
            // 
            this.btnCountingsort.Location = new System.Drawing.Point(60, 230);
            this.btnCountingsort.Name = "btnCountingsort";
            this.btnCountingsort.Size = new System.Drawing.Size(87, 23);
            this.btnCountingsort.TabIndex = 31;
            this.btnCountingsort.Text = "Countingsort";
            this.btnCountingsort.UseVisualStyleBackColor = true;
            this.btnCountingsort.Click += new System.EventHandler(this.btnCountingsort_Click);
            // 
            // btnQuicksort
            // 
            this.btnQuicksort.Location = new System.Drawing.Point(60, 201);
            this.btnQuicksort.Name = "btnQuicksort";
            this.btnQuicksort.Size = new System.Drawing.Size(87, 23);
            this.btnQuicksort.TabIndex = 30;
            this.btnQuicksort.Text = "Quicksort";
            this.btnQuicksort.UseVisualStyleBackColor = true;
            this.btnQuicksort.Click += new System.EventHandler(this.btnQuicksort_Click);
            // 
            // btnSelectionsort
            // 
            this.btnSelectionsort.Location = new System.Drawing.Point(60, 172);
            this.btnSelectionsort.Name = "btnSelectionsort";
            this.btnSelectionsort.Size = new System.Drawing.Size(87, 23);
            this.btnSelectionsort.TabIndex = 29;
            this.btnSelectionsort.Text = "Selectionsort";
            this.btnSelectionsort.UseVisualStyleBackColor = true;
            this.btnSelectionsort.Click += new System.EventHandler(this.btnSelectionsort_Click);
            // 
            // btnBubblesort
            // 
            this.btnBubblesort.Location = new System.Drawing.Point(60, 143);
            this.btnBubblesort.Name = "btnBubblesort";
            this.btnBubblesort.Size = new System.Drawing.Size(87, 23);
            this.btnBubblesort.TabIndex = 26;
            this.btnBubblesort.Text = "Bubblesort";
            this.btnBubblesort.UseVisualStyleBackColor = true;
            this.btnBubblesort.Click += new System.EventHandler(this.btnBubblesort_Click);
            // 
            // txtMaxValue
            // 
            this.txtMaxValue.Location = new System.Drawing.Point(78, 71);
            this.txtMaxValue.Name = "txtMaxValue";
            this.txtMaxValue.Size = new System.Drawing.Size(100, 20);
            this.txtMaxValue.TabIndex = 23;
            this.txtMaxValue.Text = "1000000";
            this.txtMaxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Max Value:";
            // 
            // txtNumTrials
            // 
            this.txtNumTrials.Location = new System.Drawing.Point(78, 45);
            this.txtNumTrials.Name = "txtNumTrials";
            this.txtNumTrials.Size = new System.Drawing.Size(100, 20);
            this.txtNumTrials.TabIndex = 21;
            this.txtNumTrials.Text = "1000";
            this.txtNumTrials.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "# Trials:";
            // 
            // chkSorted
            // 
            this.chkSorted.AutoSize = true;
            this.chkSorted.Location = new System.Drawing.Point(209, 21);
            this.chkSorted.Name = "chkSorted";
            this.chkSorted.Size = new System.Drawing.Size(57, 17);
            this.chkSorted.TabIndex = 24;
            this.chkSorted.Text = "Sorted";
            this.chkSorted.UseVisualStyleBackColor = true;
            this.chkSorted.CheckedChanged += new System.EventHandler(this.chkSorted_CheckedChanged);
            // 
            // txtNumUnsorted
            // 
            this.txtNumUnsorted.Enabled = false;
            this.txtNumUnsorted.Location = new System.Drawing.Point(275, 45);
            this.txtNumUnsorted.Name = "txtNumUnsorted";
            this.txtNumUnsorted.Size = new System.Drawing.Size(33, 20);
            this.txtNumUnsorted.TabIndex = 25;
            this.txtNumUnsorted.Text = "100";
            this.txtNumUnsorted.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPercentUnsorted
            // 
            this.lblPercentUnsorted.AutoSize = true;
            this.lblPercentUnsorted.Enabled = false;
            this.lblPercentUnsorted.Location = new System.Drawing.Point(206, 48);
            this.lblPercentUnsorted.Name = "lblPercentUnsorted";
            this.lblPercentUnsorted.Size = new System.Drawing.Size(63, 13);
            this.lblPercentUnsorted.TabIndex = 22;
            this.lblPercentUnsorted.Text = "# Unsorted:";
            // 
            // txtNumItems
            // 
            this.txtNumItems.Location = new System.Drawing.Point(78, 19);
            this.txtNumItems.Name = "txtNumItems";
            this.txtNumItems.Size = new System.Drawing.Size(100, 20);
            this.txtNumItems.TabIndex = 19;
            this.txtNumItems.Text = "10000";
            this.txtNumItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "# Items:";
            // 
            // howto_compare_sorts_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 300);
            this.Controls.Add(this.txtTimeArraySort);
            this.Controls.Add(this.btnArraySort);
            this.Controls.Add(this.txtTimeCountingsort);
            this.Controls.Add(this.txtTimeQuicksort);
            this.Controls.Add(this.txtTimeSelectionsort);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTimeBubblesort);
            this.Controls.Add(this.btnCountingsort);
            this.Controls.Add(this.btnQuicksort);
            this.Controls.Add(this.btnSelectionsort);
            this.Controls.Add(this.btnBubblesort);
            this.Controls.Add(this.txtMaxValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNumTrials);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkSorted);
            this.Controls.Add(this.txtNumUnsorted);
            this.Controls.Add(this.lblPercentUnsorted);
            this.Controls.Add(this.txtNumItems);
            this.Controls.Add(this.label1);
            this.Name = "howto_compare_sorts_Form1";
            this.Text = "howto_compare_sorts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTimeArraySort;
        private System.Windows.Forms.Button btnArraySort;
        private System.Windows.Forms.TextBox txtTimeCountingsort;
        private System.Windows.Forms.TextBox txtTimeQuicksort;
        private System.Windows.Forms.TextBox txtTimeSelectionsort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTimeBubblesort;
        private System.Windows.Forms.Button btnCountingsort;
        private System.Windows.Forms.Button btnQuicksort;
        private System.Windows.Forms.Button btnSelectionsort;
        private System.Windows.Forms.Button btnBubblesort;
        private System.Windows.Forms.TextBox txtMaxValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumTrials;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkSorted;
        private System.Windows.Forms.TextBox txtNumUnsorted;
        private System.Windows.Forms.Label lblPercentUnsorted;
        private System.Windows.Forms.TextBox txtNumItems;
        private System.Windows.Forms.Label label1;
    }
}

