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
     public partial class puzzle_zero_rows_columns4_Form1:Form
  { 


        public puzzle_zero_rows_columns4_Form1()
        {
            InitializeComponent();
        }

        // Demonstrate the algorithm.
        private void btnGo_Click(object sender, EventArgs e)
        {
            // Load the array.
            int num_rows = txtInput.Lines.Length;
            int num_cols = txtInput.Lines[0].Replace(" ", "").Length;
            int[,] values = new int[num_rows, num_cols];
            for (int row = 0; row < num_rows; row++)
            {
                string line = txtInput.Lines[row].Replace(" ", "");
                for (int col = 0; col < num_cols; col++)
                {
                    values[row, col] = int.Parse(line.Substring(col, 1));
                }
            }

            // Zero the appropriate rows and columns.
            ZeroRowsAndColumns(values);

            // Display the result.
            string result = "";
            for (int row = 0; row < num_rows; row++)
            {
                for (int col = 0; col < num_cols; col++)
                {
                    result += values[row, col].ToString() + " ";
                }
                // Remove the final " " and add a new line.
                result = result.Substring(0, result.Length - 1) + "\r\n";
            }

            // Remove the final \r\n.
            result = result.Substring(0, result.Length - 2);
            txtResult.Text = result;
        }

        // Insert the algorithm here.
        private void ZeroRowsAndColumns(int[,] values)
        {
            // See if the first row should be zero.
            bool row0_is_zero = false;
            for (int col = 0; col <= values.GetUpperBound(1); col++)
            {
                if (values[0, col] == 0)
                {
                    row0_is_zero = true;
                    break;
                }
            }

            // See if the first column should be zero.
            bool col0_is_zero = false;
            for (int row = 0; row <= values.GetUpperBound(0); row++)
            {
                if (values[row, 0] == 0)
                {
                    col0_is_zero = true;
                    break;
                }
            }

            // Copy zeros into the first row and column.
            for (int row = 1; row <= values.GetUpperBound(0); row++)
            {
                for (int col = 1; col <= values.GetUpperBound(1); col++)
                {
                    if (values[row, col] == 0)
                    {
                        values[row, 0] = 0;
                        values[0, col] = 0;
                    }
                }
            }

            // Zero out the required rows.
            for (int row = 1; row <= values.GetUpperBound(0); row++)
            {
                if (values[row, 0] == 0)
                {
                    // Zero out this row.
                    for (int c = 1; c <= values.GetUpperBound(1); c++)
                    {
                        values[row, c] = 0;
                    }
                }
            }

            // Zero out the required columns.
            for (int col = 1; col <= values.GetUpperBound(1); col++)
            {
                if (values[0, col] == 0)
                {
                    // Zero out this column.
                    for (int r = 1; r <= values.GetUpperBound(0); r++)
                    {
                        values[r, col] = 0;
                    }
                }
            }

            // If the first row should be zero, zero it out.
            if (row0_is_zero)
            {
                for (int c = 0; c <= values.GetUpperBound(1); c++)
                {
                    values[0, c] = 0;
                }
            }

            // If the first column should be zero, zero it out.
            if (col0_is_zero)
            {
                for (int r = 0; r <= values.GetUpperBound(0); r++)
                {
                    values[r, 0] = 0;
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
            this.btnGo = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(127, 42);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtResult
            // 
            this.txtResult.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(208, 12);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(108, 83);
            this.txtResult.TabIndex = 5;
            // 
            // txtInput
            // 
            this.txtInput.AcceptsReturn = true;
            this.txtInput.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(13, 12);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(108, 83);
            this.txtInput.TabIndex = 3;
            this.txtInput.Text = "7 6 5 7 2\r\n3 0 4 3 1\r\n1 8 7 9 9\r\n2 4 1 0 3";
            // 
            // puzzle_zero_rows_columns4_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 106);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtInput);
            this.Name = "puzzle_zero_rows_columns4_Form1";
            this.Text = "puzzle_zero_rows_columns4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtInput;
    }
}

