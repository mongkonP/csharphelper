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
     public partial class howto_gaussian_elimination_Form1:Form
  { 


        public howto_gaussian_elimination_Form1()
        {
            InitializeComponent();
        }

        // Solve the system of equations.
        private void cmdSolve_Click(object sender, EventArgs e)
        {
            const double tiny = 0.00001;
            string txt = "";

            // Build the augmented matrix.
            // The values num_rows and num_cols are the number of rows
            // and columns in the matrix, not the augmented matrix.
            int num_rows, num_cols;
            double[,] arr = LoadArray(out num_rows, out num_cols);
            double[,] orig_arr = LoadArray(out num_rows, out num_cols);
            
            // Display the initial arrays.
            PrintArray(arr);
            PrintArray(orig_arr);

            // Start solving.
            for (int r = 0; r < num_rows - 1; r++)
            {
                // Zero out all entries in column r after this row.
                // See if this row has a non-zero entry in column r.
                if (Math.Abs(arr[r, r]) < tiny)
                {
                    // Too close to zero. Try to swap with a later row.
                    for (int r2 = r + 1; r2 < num_rows; r2++)
                    {
                        if (Math.Abs(arr[r2, r]) > tiny)
                        {
                            // This row will work. Swap them.
                            for (int c = 0; c <= num_cols; c++)
                            {
                                double tmp = arr[r, c];
                                arr[r, c] = arr[r2, c];
                                arr[r2, c] = tmp;
                            }
                            break;
                        }
                    }
                }

                // If this row has a non-zero entry in column r, use it.
                if (Math.Abs(arr[r, r]) > tiny)
                {
                    // Zero out this column in later rows.
                    for (int r2 = r + 1; r2 < num_rows; r2++)
                    {
                        double factor = -arr[r2, r] / arr[r, r];
                        for (int c = r; c <= num_cols; c++)
                        {
                            arr[r2, c] = arr[r2, c] + factor * arr[r, c];
                        }
                    }
                }
            }

            // Display the upper-triangular array.
            PrintArray(arr);

            // See if we have a solution.
            if (arr[num_rows - 1, num_cols - 1] == 0)
            {
                // We have no solution.
                // See if all of the entries in this row are 0.
                bool all_zeros = true;
                for (int c = 0; c <= num_cols + 1; c++)
                {
                    if (arr[num_rows - 1, c] != 0)
                    {
                        all_zeros = false;
                        break;
                    }
                }
                if (all_zeros)
                {
                    txt = "The solution is not unique";
                }
                else
                {
                    txt = "There is no solution";
                }
            }
            else
            {
                // Backsolve.
                for (int r = num_rows - 1; r >= 0; r--)
                {
                    double tmp = arr[r, num_cols];
                    for (int r2 = r + 1; r2 < num_rows; r2++)
                    {
                        tmp -= arr[r, r2] * arr[r2, num_cols + 1];
                    }
                    arr[r, num_cols + 1] = tmp / arr[r, r];
                }

                // Display the results.
                txt = "       Values:";
                for (int r = 0; r < num_rows; r++)
                {
                    txt += "\r\nx" + r.ToString() + " = " +
                        arr[r, num_cols + 1].ToString();
                }

                // Verify.
                txt += "\r\n    Check:";
                for (int r = 0; r < num_rows; r++)
                {
                    double tmp = 0;
                    for (int c = 0; c < num_cols; c++)
                    {
                        tmp += orig_arr[r, c] * arr[c, num_cols + 1];
                    }
                    txt += "\r\n" + tmp.ToString();
                }

                txt = txt.Substring("\r\n".Length + 1);
            }

            txtResults.Text = txt;
        }

        // Load the augmented array.
        // Column num_cols holds the result values.
        // Column num_cols + 1 will hold the variables' final values after backsolving.
        private double[,] LoadArray(out int num_rows, out int num_cols)
        {
            // Build the augmented matrix.
            string[] value_rows = txtValues.Text.Split(
                new string[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            string[] coef_rows = txtCoefficients.Text.Split(
                new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            string[] one_row = coef_rows[0].Split(
                new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            num_rows = coef_rows.GetUpperBound(0) + 1;
            num_cols = one_row.GetUpperBound(0) + 1;
            double[,] arr = new double[num_rows, num_cols + 2];
            for (int r = 0; r < num_rows; r++)
            {
                one_row = coef_rows[r].Split(
                    new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                for (int c = 0; c < num_cols; c++)
                {
                    arr[r, c] = double.Parse(one_row[c]);
                }
                arr[r, num_cols] = double.Parse(value_rows[r]);
            }

            return arr;
        }

        // Display the array's values in the Console window.
        private void PrintArray(double[,] arr)
        {
            for (int r = arr.GetLowerBound(0); r <= arr.GetUpperBound(0); r++)
            {
                for (int c = arr.GetLowerBound(1); c <= arr.GetUpperBound(1); c++)
                {
                    Console.Write(arr[r, c] + "\t");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
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
            this.cmdSolve = new System.Windows.Forms.Button();
            this.txtValues = new System.Windows.Forms.TextBox();
            this.txtCoefficients = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblVariables = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtResults
            // 
            this.txtResults.AcceptsReturn = true;
            this.txtResults.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.SetColumnSpan(this.txtResults, 4);
            this.txtResults.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResults.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.txtResults.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtResults.Location = new System.Drawing.Point(3, 151);
            this.txtResults.MaxLength = 0;
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtResults.Size = new System.Drawing.Size(346, 200);
            this.txtResults.TabIndex = 17;
            // 
            // cmdSolve
            // 
            this.cmdSolve.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdSolve.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSolve.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdSolve.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSolve.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSolve.Location = new System.Drawing.Point(134, 10);
            this.cmdSolve.Name = "cmdSolve";
            this.cmdSolve.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdSolve.Size = new System.Drawing.Size(79, 34);
            this.cmdSolve.TabIndex = 16;
            this.cmdSolve.Text = "Solve";
            this.cmdSolve.UseVisualStyleBackColor = false;
            this.cmdSolve.Click += new System.EventHandler(this.cmdSolve_Click);
            // 
            // txtValues
            // 
            this.txtValues.AcceptsReturn = true;
            this.txtValues.BackColor = System.Drawing.SystemColors.Window;
            this.txtValues.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtValues.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValues.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtValues.Location = new System.Drawing.Point(267, 3);
            this.txtValues.MaxLength = 0;
            this.txtValues.Multiline = true;
            this.txtValues.Name = "txtValues";
            this.txtValues.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtValues.Size = new System.Drawing.Size(82, 82);
            this.txtValues.TabIndex = 13;
            this.txtValues.Text = "1\r\n-1\r\n8\r\n-56\r\n569";
            this.txtValues.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCoefficients
            // 
            this.txtCoefficients.AcceptsReturn = true;
            this.txtCoefficients.BackColor = System.Drawing.SystemColors.Window;
            this.txtCoefficients.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCoefficients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCoefficients.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCoefficients.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCoefficients.Location = new System.Drawing.Point(3, 3);
            this.txtCoefficients.MaxLength = 0;
            this.txtCoefficients.Multiline = true;
            this.txtCoefficients.Name = "txtCoefficients";
            this.txtCoefficients.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCoefficients.Size = new System.Drawing.Size(198, 82);
            this.txtCoefficients.TabIndex = 12;
            this.txtCoefficients.Text = "   1   1   1  1 1\r\n  32  16   8  4 2\r\n 243  81  27  9 3\r\n1024 256  64 16 4\r\n3125 " +
                "625 125 25 5";
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(247, 0);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(14, 88);
            this.Label1.TabIndex = 15;
            this.Label1.Text = "=";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVariables
            // 
            this.lblVariables.BackColor = System.Drawing.SystemColors.Control;
            this.lblVariables.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVariables.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVariables.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVariables.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblVariables.Location = new System.Drawing.Point(207, 0);
            this.lblVariables.Name = "lblVariables";
            this.lblVariables.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblVariables.Size = new System.Drawing.Size(34, 88);
            this.lblVariables.TabIndex = 14;
            this.lblVariables.Text = "x0\r\nx1\r\nx2\r\nx3\r\n...";
            this.lblVariables.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.txtCoefficients, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtResults, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblVariables, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Label1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtValues, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(352, 354);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 4);
            this.panel1.Controls.Add(this.cmdSolve);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(346, 54);
            this.panel1.TabIndex = 16;
            // 
            // howto_gaussian_elimination_Form1
            // 
            this.AcceptButton = this.cmdSolve;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 354);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "howto_gaussian_elimination_Form1";
            this.Text = "howto_gaussian_elimination";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox txtResults;
        public System.Windows.Forms.Button cmdSolve;
        public System.Windows.Forms.TextBox txtValues;
        public System.Windows.Forms.TextBox txtCoefficients;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Label lblVariables;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
    }
}

