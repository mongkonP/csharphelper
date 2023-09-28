using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_subarray_extensions;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_subarray_extensions_Form1:Form
  { 


        public howto_subarray_extensions_Form1()
        {
            InitializeComponent();
        }

        private string[] Values1d;
        private string[,] Values2d;

        // Initialize the values.
        private void howto_subarray_extensions_Form1_Load(object sender, EventArgs e)
        {
            Values1d = new string[5];
            for (int col = 0; col <= Values1d.GetUpperBound(0); col++)
            {
                Values1d[col] = "(" + col.ToString() + ")";
            }

            Values2d = new string[5, 4];
            for (int row = 0; row <= Values2d.GetUpperBound(0); row++)
            {
                for (int col = 0; col <= Values2d.GetUpperBound(1); col++)
                {
                    Values2d[row, col] = "(" + row.ToString() + ", " + col.ToString() + ")";
                }
            }

            // Display the values.
            ShowValues(lstValues1d, Values1d);
            ShowValues(lstValues2d, Values2d);
            ShowValues(lstValues2d2, Values2d);
        }

        // Copy the values and display the result.
        private void btnCopy1d_Click(object sender, EventArgs e)
        {
            string[] new_values = Values1d.SubArray(1, 3);
            ShowValues(lstCopy1d, new_values);
        }

        // Copy the values and display the result.
        private void btnCopy2d_Click(object sender, EventArgs e)
        {
            string[,] new_values = Values2d.SubArray(2, 3, 1, 3);
            ShowValues(lstCopy2d, new_values);
        }

        // Copy the values and display the result.
        private void btnCopy2d2_Click(object sender, EventArgs e)
        {
            // Allocate a new array.
            string[,] new_values = new string[
                Values2d.GetUpperBound(0) + 1,
                Values2d.GetUpperBound(1) + 1];

            // Fill the array with --- values.
            for (int row = 0; row <= new_values.GetUpperBound(0); row++)
            {
                for (int col = 0; col <= new_values.GetUpperBound(1); col++)
                {
                    new_values[row, col] = "------";
                }
            }

            // Copy the values.
            Values2d.CopyTo(new_values, 2, 3, 1, 3, 1, 0);

            // Display the values.
            ShowValues(lstCopy2d2, new_values);
        }

        // Display some values in a ListBox.
        private void ShowValues(ListBox lst, string[,] the_values)
        {
            lst.Items.Clear();
            for (int row = 0; row <= the_values.GetUpperBound(0); row++)
            {
                string str = "";
                for (int col = 0; col <= the_values.GetUpperBound(1); col++)
                {
                    str += the_values[row, col] + " ";
                }
                str = str.Substring(0, str.Length - 1);
                lst.Items.Add(str);
            }
        }

        private void ShowValues(ListBox lst, string[] the_values)
        {
            lst.Items.Clear();
            string str = "";
            for (int col = 0; col <= the_values.GetUpperBound(0); col++)
            {
                str += the_values[col] + " ";
            }
            str = str.Substring(0, str.Length - 1);
            lst.Items.Add(str);
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
            this.lstValues2d2 = new System.Windows.Forms.ListBox();
            this.lstValues1d = new System.Windows.Forms.ListBox();
            this.lstCopy1d = new System.Windows.Forms.ListBox();
            this.lstValues2d = new System.Windows.Forms.ListBox();
            this.btnCopy1d = new System.Windows.Forms.Button();
            this.btnCopy2d = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lstCopy2d2 = new System.Windows.Forms.ListBox();
            this.btnCopy2d2 = new System.Windows.Forms.Button();
            this.lstCopy2d = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstValues2d2
            // 
            this.lstValues2d2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstValues2d2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstValues2d2.FormattingEnabled = true;
            this.lstValues2d2.ItemHeight = 14;
            this.lstValues2d2.Location = new System.Drawing.Point(3, 163);
            this.lstValues2d2.Name = "lstValues2d2";
            this.lstValues2d2.Size = new System.Drawing.Size(202, 102);
            this.lstValues2d2.TabIndex = 12;
            // 
            // lstValues1d
            // 
            this.lstValues1d.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstValues1d.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstValues1d.FormattingEnabled = true;
            this.lstValues1d.ItemHeight = 14;
            this.lstValues1d.Location = new System.Drawing.Point(3, 3);
            this.lstValues1d.Name = "lstValues1d";
            this.lstValues1d.Size = new System.Drawing.Size(202, 18);
            this.lstValues1d.TabIndex = 6;
            // 
            // lstCopy1d
            // 
            this.lstCopy1d.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCopy1d.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCopy1d.FormattingEnabled = true;
            this.lstCopy1d.ItemHeight = 14;
            this.lstCopy1d.Location = new System.Drawing.Point(284, 3);
            this.lstCopy1d.Name = "lstCopy1d";
            this.lstCopy1d.Size = new System.Drawing.Size(203, 18);
            this.lstCopy1d.TabIndex = 8;
            // 
            // lstValues2d
            // 
            this.lstValues2d.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstValues2d.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstValues2d.FormattingEnabled = true;
            this.lstValues2d.ItemHeight = 14;
            this.lstValues2d.Location = new System.Drawing.Point(3, 53);
            this.lstValues2d.Name = "lstValues2d";
            this.lstValues2d.Size = new System.Drawing.Size(202, 102);
            this.lstValues2d.TabIndex = 9;
            // 
            // btnCopy1d
            // 
            this.btnCopy1d.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy1d.Location = new System.Drawing.Point(211, 3);
            this.btnCopy1d.Name = "btnCopy1d";
            this.btnCopy1d.Size = new System.Drawing.Size(67, 23);
            this.btnCopy1d.TabIndex = 7;
            this.btnCopy1d.Text = "Copy";
            this.btnCopy1d.UseVisualStyleBackColor = true;
            this.btnCopy1d.Click += new System.EventHandler(this.btnCopy1d_Click);
            // 
            // btnCopy2d
            // 
            this.btnCopy2d.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy2d.Location = new System.Drawing.Point(211, 53);
            this.btnCopy2d.Name = "btnCopy2d";
            this.btnCopy2d.Size = new System.Drawing.Size(67, 23);
            this.btnCopy2d.TabIndex = 10;
            this.btnCopy2d.Text = "Copy";
            this.btnCopy2d.UseVisualStyleBackColor = true;
            this.btnCopy2d.Click += new System.EventHandler(this.btnCopy2d_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lstValues2d2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lstValues1d, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstCopy1d, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstValues2d, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCopy1d, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCopy2d, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lstCopy2d2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCopy2d2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lstCopy2d, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(490, 271);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // lstCopy2d2
            // 
            this.lstCopy2d2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCopy2d2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCopy2d2.FormattingEnabled = true;
            this.lstCopy2d2.ItemHeight = 14;
            this.lstCopy2d2.Location = new System.Drawing.Point(284, 163);
            this.lstCopy2d2.Name = "lstCopy2d2";
            this.lstCopy2d2.Size = new System.Drawing.Size(203, 102);
            this.lstCopy2d2.TabIndex = 14;
            // 
            // btnCopy2d2
            // 
            this.btnCopy2d2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy2d2.Location = new System.Drawing.Point(211, 163);
            this.btnCopy2d2.Name = "btnCopy2d2";
            this.btnCopy2d2.Size = new System.Drawing.Size(67, 23);
            this.btnCopy2d2.TabIndex = 13;
            this.btnCopy2d2.Text = "Copy";
            this.btnCopy2d2.UseVisualStyleBackColor = true;
            this.btnCopy2d2.Click += new System.EventHandler(this.btnCopy2d2_Click);
            // 
            // lstCopy2d
            // 
            this.lstCopy2d.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCopy2d.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCopy2d.FormattingEnabled = true;
            this.lstCopy2d.ItemHeight = 14;
            this.lstCopy2d.Location = new System.Drawing.Point(284, 53);
            this.lstCopy2d.Name = "lstCopy2d";
            this.lstCopy2d.Size = new System.Drawing.Size(203, 102);
            this.lstCopy2d.TabIndex = 11;
            // 
            // howto_subarray_extensions_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 295);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "howto_subarray_extensions_Form1";
            this.Text = "howto_subarray_extensions";
            this.Load += new System.EventHandler(this.howto_subarray_extensions_Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListBox lstValues2d2;
        internal System.Windows.Forms.ListBox lstValues1d;
        internal System.Windows.Forms.ListBox lstCopy1d;
        internal System.Windows.Forms.ListBox lstValues2d;
        internal System.Windows.Forms.Button btnCopy1d;
        internal System.Windows.Forms.Button btnCopy2d;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal System.Windows.Forms.ListBox lstCopy2d2;
        internal System.Windows.Forms.Button btnCopy2d2;
        internal System.Windows.Forms.ListBox lstCopy2d;
    }
}

