using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_read_csv_file_Form1:Form
  { 


        public howto_read_csv_file_Form1()
        {
            InitializeComponent();
        }

        private void howto_read_csv_file_Form1_Load(object sender, EventArgs e)
        {
            txtFile.Text = Path.GetFullPath(
                Path.Combine(Application.StartupPath, "..\\..")) +
                "\\Data.csv";
            txtFile.Select(0, 0);
        }

        // Read the CSV file.
        // Assumes each line has the same number of fields
        // and no line is blank.
        private void btnGo_Click(object sender, EventArgs e)
        {
            // Get the data.
            string[,] values = LoadCsv(txtFile.Text);
            int num_rows = values.GetUpperBound(0) + 1;
            int num_cols = values.GetUpperBound(1) + 1;

            // Display the data to show we have it.

            // Make column headers.
            // For this example, we assume the first row
            // contains the column names.
            dgvValues.Columns.Clear();
            for (int c = 0; c < num_cols; c++)
                dgvValues.Columns.Add(values[0, c], values[0, c]);

            // Add the data.
            for (int r = 1; r < num_rows; r++)
            {
                dgvValues.Rows.Add();
                for (int c = 0; c < num_cols; c++)
                {
                    dgvValues.Rows[r - 1].Cells[c].Value = values[r, c];
                }
            }

            //// Make the columns autosize.
            //foreach (DataGridViewColumn col in dgvValues.Columns)
            //    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        // Load a CSV file into an array of rows and columns.
        // Assume there may be blank lines but every line has
        // the same number of fields.
        private string[,] LoadCsv(string filename)
        {
            // Get the file's text.
            string whole_file = File.ReadAllText(filename);

            // Split into lines.
            whole_file = whole_file.Replace('\n', '\r');
            string[] lines = whole_file.Split(new char[] { '\r' },
                StringSplitOptions.RemoveEmptyEntries);

            // See how many rows and columns there are.
            int num_rows = lines.Length;
            int num_cols = lines[0].Split(',').Length;

            // Allocate the data array.
            string[,] values = new string[num_rows, num_cols];

            // Load the array.
            for (int r = 0; r < num_rows; r++)
            {
                string[] line_r = lines[r].Split(',');
                for (int c = 0; c < num_cols; c++)
                {
                    values[r, c] = line_r[c];
                }
            }

            // Return the values.
            return values;
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
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.dgvValues = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValues)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File:";
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(44, 12);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(430, 20);
            this.txtFile.TabIndex = 1;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(480, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // dgvValues
            // 
            this.dgvValues.AllowUserToAddRows = false;
            this.dgvValues.AllowUserToDeleteRows = false;
            this.dgvValues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvValues.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvValues.Location = new System.Drawing.Point(12, 38);
            this.dgvValues.Name = "dgvValues";
            this.dgvValues.ReadOnly = true;
            this.dgvValues.Size = new System.Drawing.Size(462, 214);
            this.dgvValues.TabIndex = 3;
            // 
            // howto_read_csv_file_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 264);
            this.Controls.Add(this.dgvValues);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label1);
            this.Name = "howto_read_csv_file_Form1";
            this.Text = "howto_read_csv_file";
            this.Load += new System.EventHandler(this.howto_read_csv_file_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvValues)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.DataGridView dgvValues;
    }
}

