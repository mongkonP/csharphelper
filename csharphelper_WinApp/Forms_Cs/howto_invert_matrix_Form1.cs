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
     public partial class howto_invert_matrix_Form1:Form
  { 


        public howto_invert_matrix_Form1()
        {
            InitializeComponent();
        }

        private void btnInvert_Click(object sender, EventArgs e)
        {
            // Build the matrix.
            string[] matrix_rows = txtMatrix.Text.Split(
                new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int num_rows = matrix_rows.Length;
            double[,] matrix = new double[num_rows, num_rows];
            for (int row = 0; row < num_rows; row++)
            {
                char[] chars = { ' ' };
                string[] row_items =
                    matrix_rows[row].Split(chars, StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < num_rows; col++)
                {
                    matrix[row, col] = double.Parse(row_items[col]);
                }
            }

            // Find the inverse.
            double[,] inverse = InvertMatrix(matrix);

            if (inverse == null)
            {
                txtInverse.Text = "Null";
                txtProduct.Clear();
            }
            else
            {
                // Multiply the matrix by the inverse.
                double[,] product = MultiplyMatrices(matrix, inverse);

                // Display the results.
                txtInverse.Text = MatrixToString(inverse, "{0,8:F4}");
                txtProduct.Text = MatrixToString(product, "{0,8:F4}");
            }

        }

        // Return the matrix's inverse or null if it has none.
        private double[,] InvertMatrix(double[,] matrix)
        {
            const double tiny = 0.00001;

            // Build the augmented matrix.
            int num_rows = matrix.GetUpperBound(0) + 1;
            double[,] augmented = new double[num_rows, 2 * num_rows];
            for (int row = 0; row < num_rows; row++)
            {
                for (int col = 0; col < num_rows; col++)
                    augmented[row, col] = matrix[row, col];
                augmented[row, row + num_rows] = 1;
            }

            // num_cols is the number of the augmented matrix.
            int num_cols = 2 * num_rows;

            // Solve.
            for (int row = 0; row < num_rows; row++)
            {
                // Zero out all entries in column r after this row.
                // See if this row has a non-zero entry in column r.
                if (Math.Abs(augmented[row, row]) < tiny)
                {
                    // Too close to zero. Try to swap with a later row.
                    for (int r2 = row + 1; r2 < num_rows; r2++)
                    {
                        if (Math.Abs(augmented[r2, row]) > tiny)
                        {
                            // This row will work. Swap them.
                            for (int c = 0; c < num_cols; c++)
                            {
                                double tmp = augmented[row, c];
                                augmented[row, c] = augmented[r2, c];
                                augmented[r2, c] = tmp;
                            }
                            break;
                        }
                    }
                }

                // If this row has a non-zero entry in column r, use it.
                if (Math.Abs(augmented[row, row]) > tiny)
                {
                    // Divide the row by augmented[row, row] to make this entry 1.
                    for (int col = 0; col < num_cols; col++)
                        if (col != row)
                            augmented[row, col] /= augmented[row, row];
                    augmented[row, row] = 1;

                    // Subtract this row from the other rows.
                    for (int row2 = 0; row2 < num_rows; row2++)
                    {
                        if (row2 != row)
                        {
                            double factor = augmented[row2, row] / augmented[row, row];
                            for (int col = 0; col < num_cols; col++)
                                augmented[row2, col] -= factor * augmented[row, col];
                        }
                    }
                }
            }

            // See if we have a solution.
            if (augmented[num_rows - 1, num_rows - 1] == 0) return null;

            // Extract the inverse array.
            double[,] inverse = new double[num_rows, num_rows];
            for (int row = 0; row < num_rows; row++)
            {
                for (int col = 0; col < num_rows; col++)
                {
                    inverse[row, col] = augmented[row, col + num_rows];
                }
            }

            return inverse;
        }

        // Multiply two matrices.
        private double[,] MultiplyMatrices(double[,] m1, double[,] m2)
        {
            int num_rows = m1.GetUpperBound(0) + 1;
            double[,] result = new double[num_rows, num_rows];
            for (int row = 0; row < num_rows; row++)
            {
                for (int col = 0; col < num_rows; col++)
                {
                    double value = 0;
                    for (int i = 0; i < num_rows; i++)
                        value += m1[row, i] * m2[i, col];
                    result[row, col] = value;
                }
            }

            return result;
        }

        // Return a string representation of the matrix.
        private string MatrixToString(double[,] matrix, string format)
        {
            StringBuilder sb = new StringBuilder();
            int num_rows = matrix.GetUpperBound(0) + 1;
            int num_cols = matrix.GetUpperBound(1) + 1;
            for (int row = 0; row < num_rows; row++)
            {
                for (int col = 0; col < num_cols; col++)
                    sb.Append(string.Format(format, matrix[row, col]));
                if (row < num_rows - 1) sb.AppendLine();
            }
            return sb.ToString();
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
            this.txtMatrix = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInvert = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInverse = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtMatrix
            // 
            this.txtMatrix.AcceptsReturn = true;
            this.txtMatrix.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatrix.Location = new System.Drawing.Point(35, 12);
            this.txtMatrix.Multiline = true;
            this.txtMatrix.Name = "txtMatrix";
            this.txtMatrix.Size = new System.Drawing.Size(65, 65);
            this.txtMatrix.TabIndex = 0;
            this.txtMatrix.Text = "1 3 3\r\n1 4 3\r\n1 3 4\r";
            this.txtMatrix.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "A:";
            // 
            // btnInvert
            // 
            this.btnInvert.Location = new System.Drawing.Point(106, 29);
            this.btnInvert.Name = "btnInvert";
            this.btnInvert.Size = new System.Drawing.Size(75, 23);
            this.btnInvert.TabIndex = 2;
            this.btnInvert.Text = "Invert";
            this.btnInvert.UseVisualStyleBackColor = true;
            this.btnInvert.Click += new System.EventHandler(this.btnInvert_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "B:";
            // 
            // txtInverse
            // 
            this.txtInverse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInverse.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInverse.Location = new System.Drawing.Point(210, 12);
            this.txtInverse.Multiline = true;
            this.txtInverse.Name = "txtInverse";
            this.txtInverse.ReadOnly = true;
            this.txtInverse.Size = new System.Drawing.Size(188, 65);
            this.txtInverse.TabIndex = 3;
            this.txtInverse.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "A * B:";
            // 
            // txtProduct
            // 
            this.txtProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProduct.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProduct.Location = new System.Drawing.Point(210, 103);
            this.txtProduct.Multiline = true;
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.ReadOnly = true;
            this.txtProduct.Size = new System.Drawing.Size(188, 65);
            this.txtProduct.TabIndex = 5;
            this.txtProduct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // howto_invert_matrix_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 180);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtProduct);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInverse);
            this.Controls.Add(this.btnInvert);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMatrix);
            this.Name = "howto_invert_matrix_Form1";
            this.Text = "howto_invert_matrix";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMatrix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInvert;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInverse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProduct;
    }
}

