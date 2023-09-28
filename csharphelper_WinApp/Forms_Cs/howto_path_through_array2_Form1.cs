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
     public partial class howto_path_through_array2_Form1:Form
  { 


        public howto_path_through_array2_Form1()
        {
            InitializeComponent();
        }

        // The minimum and maximum numbers.
        private const int MinValue = 1;
        private const int MaxValue = 99;

        // The numbers.
        private int[,] Numbers = null;
        private int NumRows = 0;
        private int NumCols = 0;

        // The best path.
        private int[] BestPath = null;
        private int BestTotal = int.MinValue;
        private int[] BestPath2 = null;
        private int BestTotal2 = int.MinValue;

        // The number of times FindPath is called.
        private int NumFindPathCalls = 0;

        private void btnMakeNumbers_Click(object sender, EventArgs e)
        {
            NumRows = (int)nudNumRows.Value;
            NumCols = (int)nudNumCols.Value;
            Numbers = new int[NumRows, NumCols];
            Random rand = new Random();
            for (int row = 0; row < NumRows; row++)
            {
                for (int col = 0; col < NumCols; col++)
                {
                    Numbers[row, col] = rand.Next(MinValue, MaxValue);
                }
            }
            BestPath = null;
            BestPath2 = null;

            // Display the numbers.
            DisplayNumbers();

            // Enable the Find Path button.
            btnFindPath.Enabled = true;
            txtExhaustiveValue.Clear();
            txtExhaustiveRecursions.Clear();
            txtBranchAndBoundValue.Clear();
            txtBranchAndBoundRecursions.Clear();
            AcceptButton = btnFindPath;
        }

        // Display the numbers and the best path.
        private void DisplayNumbers()
        {
            // Display the numbers.
            string txt = "";
            for (int row = 0; row < NumRows; row++)
            {
                txt += Environment.NewLine;
                for (int col = 0; col < NumCols; col++)
                {
                    txt += string.Format("{0,3}", Numbers[row, col]);
                }
            }
            txt = txt.Substring(Environment.NewLine.Length);
            rchNumbers.Text = txt;

            // Display the best path.
            if (BestPath == null) return;
            rchNumbers.Select();
            rchNumbers.SelectionBackColor = Color.White;
            for (int row = 0; row < NumRows; row++)
            {
                int start = 1 +
                    row * (NumCols * 3 + Environment.NewLine.Length - 1) +
                    BestPath[row] * 3;
                rchNumbers.Select(start, 2);
                rchNumbers.SelectionBackColor = Color.LightGreen;

                start = 1 +
                    row * (NumCols * 3 + Environment.NewLine.Length - 1) +
                    BestPath2[row] * 3;
                rchNumbers.Select(start, 2);
                rchNumbers.SelectionColor = Color.Red;
            }
            rchNumbers.Select(0, 0);

            // Display the best path in the Console window.
            for (int row = 0; row < NumRows; row++)
                Console.Write(Numbers[row, BestPath[row]] + " ");
            Console.WriteLine("");
            for (int row = 0; row < NumRows; row++)
                Console.Write(Numbers[row, BestPath2[row]] + " ");
            Console.WriteLine("");
        }

        // Find the best path through the numbers.
        private void btnFindPath_Click(object sender, EventArgs e)
        {
            txtExhaustiveValue.Clear();
            txtExhaustiveRecursions.Clear();
            txtBranchAndBoundValue.Clear();
            txtBranchAndBoundRecursions.Clear();
            Cursor = Cursors.WaitCursor;

            // Exhaustive search.
            // Make one BestPath entry per row.
            BestPath = new int[NumRows];
            BestTotal = int.MinValue;

            // Find the best path.
            NumFindPathCalls = 0;
            int total = FindBestPath();
            txtExhaustiveValue.Text = total.ToString("0,0");
            txtExhaustiveRecursions.Text = NumFindPathCalls.ToString("0,0");

            // Branch and bound search.
            // Make one BestPath entry per row.
            BestPath2 = new int[NumRows];
            BestTotal2 = int.MinValue;

            // Find the best path.
            NumFindPathCalls = 0;
            total = FindBestPath2();
            txtBranchAndBoundValue.Text = total.ToString("0,0");
            txtBranchAndBoundRecursions.Text = NumFindPathCalls.ToString("0,0");

            // Redisplay the numbers to show the solution.
            DisplayNumbers();

            Cursor = Cursors.Default;
        }

        // Find the best path.
        // Return the path's total value.
        private int FindBestPath()
        {
            // Make a test path, one entry per row.
            int[] test_path = new int[NumRows];

            // Start in row 0 and try each column.
            for (int col = 0; col < NumCols; col++)
            {
                test_path[0] = col;
                FindPath(test_path, 1);
            }

            // Return the best total.
            return BestTotal;
        }

        // Recursively explore paths starting with the indicated row.
        // Return the path's total value.
        private void FindPath(int[] test_path, int row)
        {
            NumFindPathCalls++;

            // See if we have a complete solution.
            if (row >= NumRows)
            {
                // We have a complete solution.
                // See if it is better than the best solution so far.
                int total = 0;
                for (int r = 0; r < NumRows; r++) total += Numbers[r, test_path[r]];
                if (total > BestTotal)
                {
                    // This is an improvement.
                    BestTotal = total;
                    Array.Copy(test_path, BestPath, NumRows);
                }
            }
            else
            {
                // We don't have a complete solution.
                // Try the possibilities for this row.

                // Get the column used in the previous row.
                int prev_col = test_path[row - 1];

                // Column - 1
                if (prev_col > 0)
                {
                    test_path[row] = prev_col - 1;
                    FindPath(test_path, row + 1);
                }

                // Column
                test_path[row] = prev_col;
                FindPath(test_path, row + 1);

                // Column + 1
                if (prev_col < NumCols - 1)
                {
                    test_path[row] = prev_col + 1;
                    FindPath(test_path, row + 1);
                }
            }
        }

        // Find the best path.
        // Return the path's total value.
        private int FindBestPath2()
        {
            // Make a test path, one entry per row.
            int[] test_path = new int[NumRows];

            // Start in row 0 and try each column.
            for (int col = 0; col < NumCols; col++)
            {
                test_path[0] = col;
                int test_total = Numbers[0, col];
                FindPath2(test_path, test_total, 1);
            }

            // Return the best total.
            return BestTotal;
        }

        // Recursively explore paths starting with the indicated row.
        // Return the path's total value.
        private void FindPath2(int[] test_path, int test_total, int row)
        {
            NumFindPathCalls++;

            // See if we have a complete solution.
            if (row >= NumRows)
            {
                // We have a complete solution.
                // See if it is better than the best solution so far.
                if (test_total > BestTotal2)
                {
                    // This is an improvement.
                    BestTotal2 = test_total;
                    Array.Copy(test_path, BestPath2, NumRows);
                }
            }
            else
            {
                // We don't have a complete solution.

                // See if there's any chance we can improve
                // on the best solution found so far.
                int rows_remaining = NumRows - row;
                if (test_total + MaxValue * rows_remaining <= BestTotal2) return;

                // Try the possibilities for this row.

                // Get the column used in the previous row.
                int prev_col = test_path[row - 1];

                // Column - 1
                if (prev_col > 0)
                {
                    int col = prev_col - 1;
                    test_path[row] = col;
                    FindPath2(test_path, test_total + Numbers[row, col], row + 1);
                }

                // Column
                test_path[row] = prev_col;
                FindPath2(test_path, test_total + Numbers[row, prev_col], row + 1);

                // Column + 1
                if (prev_col < NumCols - 1)
                {
                    int col = prev_col + 1;
                    test_path[row] = col;
                    FindPath2(test_path, test_total + Numbers[row, col], row + 1);
                }
            }
            AcceptButton = btnMakeNumbers;
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
            this.label5 = new System.Windows.Forms.Label();
            this.rchNumbers = new System.Windows.Forms.RichTextBox();
            this.nudNumCols = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.txtExhaustiveRecursions = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBranchAndBoundRecursions = new System.Windows.Forms.TextBox();
            this.txtExhaustiveValue = new System.Windows.Forms.TextBox();
            this.nudNumRows = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnMakeNumbers = new System.Windows.Forms.Button();
            this.txtBranchAndBoundValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFindPath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumCols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumRows)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(113, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Value";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rchNumbers
            // 
            this.rchNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rchNumbers.BackColor = System.Drawing.Color.White;
            this.rchNumbers.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rchNumbers.Location = new System.Drawing.Point(14, 92);
            this.rchNumbers.Name = "rchNumbers";
            this.rchNumbers.ReadOnly = true;
            this.rchNumbers.Size = new System.Drawing.Size(300, 123);
            this.rchNumbers.TabIndex = 15;
            this.rchNumbers.Text = "";
            // 
            // nudNumCols
            // 
            this.nudNumCols.Location = new System.Drawing.Point(75, 45);
            this.nudNumCols.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudNumCols.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumCols.Name = "nudNumCols";
            this.nudNumCols.Size = new System.Drawing.Size(48, 20);
            this.nudNumCols.TabIndex = 1;
            this.nudNumCols.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudNumCols.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Location = new System.Drawing.Point(191, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Recursions";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtExhaustiveRecursions
            // 
            this.txtExhaustiveRecursions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtExhaustiveRecursions.Location = new System.Drawing.Point(194, 263);
            this.txtExhaustiveRecursions.Name = "txtExhaustiveRecursions";
            this.txtExhaustiveRecursions.ReadOnly = true;
            this.txtExhaustiveRecursions.Size = new System.Drawing.Size(72, 20);
            this.txtExhaustiveRecursions.TabIndex = 22;
            this.txtExhaustiveRecursions.Text = "666,666,666";
            this.txtExhaustiveRecursions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "# Cols:";
            // 
            // txtBranchAndBoundRecursions
            // 
            this.txtBranchAndBoundRecursions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBranchAndBoundRecursions.Location = new System.Drawing.Point(194, 289);
            this.txtBranchAndBoundRecursions.Name = "txtBranchAndBoundRecursions";
            this.txtBranchAndBoundRecursions.ReadOnly = true;
            this.txtBranchAndBoundRecursions.Size = new System.Drawing.Size(72, 20);
            this.txtBranchAndBoundRecursions.TabIndex = 24;
            this.txtBranchAndBoundRecursions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtExhaustiveValue
            // 
            this.txtExhaustiveValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtExhaustiveValue.Location = new System.Drawing.Point(116, 263);
            this.txtExhaustiveValue.Name = "txtExhaustiveValue";
            this.txtExhaustiveValue.ReadOnly = true;
            this.txtExhaustiveValue.Size = new System.Drawing.Size(72, 20);
            this.txtExhaustiveValue.TabIndex = 19;
            this.txtExhaustiveValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudNumRows
            // 
            this.nudNumRows.Location = new System.Drawing.Point(75, 19);
            this.nudNumRows.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudNumRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumRows.Name = "nudNumRows";
            this.nudNumRows.Size = new System.Drawing.Size(48, 20);
            this.nudNumRows.TabIndex = 0;
            this.nudNumRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudNumRows.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Branch and Bound:";
            // 
            // btnMakeNumbers
            // 
            this.btnMakeNumbers.Location = new System.Drawing.Point(152, 31);
            this.btnMakeNumbers.Name = "btnMakeNumbers";
            this.btnMakeNumbers.Size = new System.Drawing.Size(100, 23);
            this.btnMakeNumbers.TabIndex = 2;
            this.btnMakeNumbers.Text = "Make Numbers";
            this.btnMakeNumbers.UseVisualStyleBackColor = true;
            this.btnMakeNumbers.Click += new System.EventHandler(this.btnMakeNumbers_Click);
            // 
            // txtBranchAndBoundValue
            // 
            this.txtBranchAndBoundValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBranchAndBoundValue.Location = new System.Drawing.Point(116, 289);
            this.txtBranchAndBoundValue.Name = "txtBranchAndBoundValue";
            this.txtBranchAndBoundValue.ReadOnly = true;
            this.txtBranchAndBoundValue.Size = new System.Drawing.Size(72, 20);
            this.txtBranchAndBoundValue.TabIndex = 23;
            this.txtBranchAndBoundValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Exhaustive Search:";
            // 
            // btnFindPath
            // 
            this.btnFindPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFindPath.Enabled = false;
            this.btnFindPath.Location = new System.Drawing.Point(14, 221);
            this.btnFindPath.Name = "btnFindPath";
            this.btnFindPath.Size = new System.Drawing.Size(100, 23);
            this.btnFindPath.TabIndex = 16;
            this.btnFindPath.Text = "Find Path";
            this.btnFindPath.UseVisualStyleBackColor = true;
            this.btnFindPath.Click += new System.EventHandler(this.btnFindPath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "# Rows:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.nudNumCols);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nudNumRows);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnMakeNumbers);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 74);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Make Numbers";
            // 
            // howto_path_through_array2_Form1
            // 
            this.AcceptButton = this.btnMakeNumbers;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 321);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rchNumbers);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtExhaustiveRecursions);
            this.Controls.Add(this.txtBranchAndBoundRecursions);
            this.Controls.Add(this.txtExhaustiveValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBranchAndBoundValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnFindPath);
            this.Controls.Add(this.groupBox1);
            this.Name = "howto_path_through_array2_Form1";
            this.Text = "howto_path_through_array2";
            ((System.ComponentModel.ISupportInitialize)(this.nudNumCols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumRows)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rchNumbers;
        private System.Windows.Forms.NumericUpDown nudNumCols;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtExhaustiveRecursions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBranchAndBoundRecursions;
        private System.Windows.Forms.TextBox txtExhaustiveValue;
        private System.Windows.Forms.NumericUpDown nudNumRows;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnMakeNumbers;
        private System.Windows.Forms.TextBox txtBranchAndBoundValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFindPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

