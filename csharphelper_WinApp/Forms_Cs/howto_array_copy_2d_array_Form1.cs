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
     public partial class howto_array_copy_2d_array_Form1:Form
  { 


        public howto_array_copy_2d_array_Form1()
        {
            InitializeComponent();
        }

        private string[,] Values2d;

        // Initialize the values.
        private void howto_array_copy_2d_array_Form1_Load(object sender, EventArgs e)
        {
            Values2d = new string[5, 4];
            for (int row = 0; row <= Values2d.GetUpperBound(0); row++)
            {
                for (int col = 0; col <= Values2d.GetUpperBound(1); col++)
                {
                    Values2d[row, col] = "(" + row.ToString() + ", " + col.ToString() + ")";
                }
            }

            // Display the values.
            ShowValues(lstValues, Values2d);
        }

        // Copy the values and display the result.
        private void btnCopy2d_Click(object sender, EventArgs e)
        {
            string[,] new_values = new string[3, 3];
            for (int row = 0; row <= new_values.GetUpperBound(0); row++)
            {
                for (int col = 0; col <= new_values.GetUpperBound(1); col++)
                {
                    new_values[row, col] = "------";
                }
            }

            Array.Copy(Values2d, 6, new_values, 2, 6);
            ShowValues(lstCopy, new_values);
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
            this.lstValues = new System.Windows.Forms.ListBox();
            this.btnCopy2d = new System.Windows.Forms.Button();
            this.lstCopy = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstValues
            // 
            this.lstValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstValues.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstValues.FormattingEnabled = true;
            this.lstValues.ItemHeight = 14;
            this.lstValues.Location = new System.Drawing.Point(3, 3);
            this.lstValues.Name = "lstValues";
            this.lstValues.Size = new System.Drawing.Size(210, 102);
            this.lstValues.TabIndex = 0;
            // 
            // btnCopy2d
            // 
            this.btnCopy2d.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy2d.Location = new System.Drawing.Point(219, 3);
            this.btnCopy2d.Name = "btnCopy2d";
            this.btnCopy2d.Size = new System.Drawing.Size(67, 23);
            this.btnCopy2d.TabIndex = 1;
            this.btnCopy2d.Text = "Copy";
            this.btnCopy2d.UseVisualStyleBackColor = true;
            this.btnCopy2d.Click += new System.EventHandler(this.btnCopy2d_Click);
            // 
            // lstCopy
            // 
            this.lstCopy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCopy.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCopy.FormattingEnabled = true;
            this.lstCopy.ItemHeight = 14;
            this.lstCopy.Location = new System.Drawing.Point(292, 3);
            this.lstCopy.Name = "lstCopy";
            this.lstCopy.Size = new System.Drawing.Size(210, 102);
            this.lstCopy.TabIndex = 2;
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
            this.tableLayoutPanel1.Controls.Add(this.lstValues, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstCopy, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCopy2d, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(505, 108);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // howto_array_copy_2d_array_Form1
            // 
            this.AcceptButton = this.btnCopy2d;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 132);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "howto_array_copy_2d_array_Form1";
            this.Text = "howto_array_copy_2d_array";
            this.Load += new System.EventHandler(this.howto_array_copy_2d_array_Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListBox lstValues;
        internal System.Windows.Forms.Button btnCopy2d;
        internal System.Windows.Forms.ListBox lstCopy;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

