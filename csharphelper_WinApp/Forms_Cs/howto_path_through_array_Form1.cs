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
     public partial class howto_path_through_array_Form1:Form
  { 


        public howto_path_through_array_Form1()
        {
            InitializeComponent();
        }

        // The numbers.
        private int[,] Numbers = null;
        private int NumRows = 0;
        private int NumCols = 0;

        // The best path.
        private int[] BestPath = null;
        private int BestTotal = int.MinValue;

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
                    Numbers[row, col] = rand.Next(1, 99);
                }
            }
            BestPath = null;

            // Display the numbers.
            DisplayNumbers();

            // Enable the Find Path button.
            btnFindPath.Enabled = true;
            AcceptButton = btnFindPath;
            lblTotal.Text = "";
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
            }
            rchNumbers.Select(0, 0);

            // Display the best path in the Console window.
            for (int row = 0; row < NumRows; row++)
                Console.Write(Numbers[row, BestPath[row]] + " ");
            Console.WriteLine("");
        }

        // Find the best path through the numbers.
        private void btnFindPath_Click(object sender, EventArgs e)
        {
            lblTotal.Text = "";
            Cursor = Cursors.WaitCursor;

            // Make one BestPath entry per row.
            BestPath = new int[NumRows];
            BestTotal = int.MinValue;

            // Find the best path.
            int total = FindBestPath();
            lblTotal.Text = total.ToString();

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
            this.rchNumbers = new System.Windows.Forms.RichTextBox();
            this.nudNumCols = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudNumRows = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMakeNumbers = new System.Windows.Forms.Button();
            this.btnFindPath = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumCols)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumRows)).BeginInit();
            this.SuspendLayout();
            // 
            // rchNumbers
            // 
            this.rchNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rchNumbers.BackColor = System.Drawing.Color.White;
            this.rchNumbers.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rchNumbers.Location = new System.Drawing.Point(12, 90);
            this.rchNumbers.Name = "rchNumbers";
            this.rchNumbers.ReadOnly = true;
            this.rchNumbers.Size = new System.Drawing.Size(290, 132);
            this.rchNumbers.TabIndex = 6;
            this.rchNumbers.Text = "";
            // 
            // nudNumCols
            // 
            this.nudNumCols.Location = new System.Drawing.Point(98, 45);
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.nudNumCols);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nudNumRows);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnMakeNumbers);
            this.groupBox1.Location = new System.Drawing.Point(12, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 74);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Make Numbers";
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
            // nudNumRows
            // 
            this.nudNumRows.Location = new System.Drawing.Point(98, 19);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "# Rows:";
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
            // btnFindPath
            // 
            this.btnFindPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFindPath.Enabled = false;
            this.btnFindPath.Location = new System.Drawing.Point(12, 228);
            this.btnFindPath.Name = "btnFindPath";
            this.btnFindPath.Size = new System.Drawing.Size(100, 23);
            this.btnFindPath.TabIndex = 7;
            this.btnFindPath.Text = "Find Path";
            this.btnFindPath.UseVisualStyleBackColor = true;
            this.btnFindPath.Click += new System.EventHandler(this.btnFindPath_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(118, 233);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 13);
            this.lblTotal.TabIndex = 8;
            // 
            // howto_path_through_array_Form1
            // 
            this.AcceptButton = this.btnMakeNumbers;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 261);
            this.Controls.Add(this.rchNumbers);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnFindPath);
            this.Controls.Add(this.lblTotal);
            this.Name = "howto_path_through_array_Form1";
            this.Text = "howto_path_through_array";
            ((System.ComponentModel.ISupportInitialize)(this.nudNumCols)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumRows)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rchNumbers;
        private System.Windows.Forms.NumericUpDown nudNumCols;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudNumRows;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMakeNumbers;
        private System.Windows.Forms.Button btnFindPath;
        private System.Windows.Forms.Label lblTotal;
    }
}

