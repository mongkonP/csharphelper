using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_to_from_ragged;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_to_from_ragged_Form1:Form
  { 


        public howto_to_from_ragged_Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            int num_rows = int.Parse(txtNumRows.Text);
            int num_cols = int.Parse(txtNumCols.Text);

            // Create a two-dimensional array.
            string[,] array2d = new string[num_rows, num_cols];
            for (int r = 0; r < num_rows; r++)
                for (int c = 0; c < num_cols; c++)
                    array2d[r, c] = "(" + r.ToString() + ", " + c.ToString() + ")";

            // Copy into a ragged array and display it.
            string[][] ragged = array2d.ToRagged();
            txtRaggedArray.Text = ragged.Dump("\t", "\r\n");

            // Copy back into a two-dimensional array and display it.
            array2d = ragged.To2DArray();
            txt2DArray.Text = array2d.Dump("\t", "\r\n");
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
            this.txtNumRows = new System.Windows.Forms.TextBox();
            this.txtNumCols = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txt2DArray = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRaggedArray = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "# Rows:";
            // 
            // txtNumRows
            // 
            this.txtNumRows.Location = new System.Drawing.Point(65, 12);
            this.txtNumRows.Name = "txtNumRows";
            this.txtNumRows.Size = new System.Drawing.Size(44, 20);
            this.txtNumRows.TabIndex = 1;
            this.txtNumRows.Text = "4";
            this.txtNumRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNumCols
            // 
            this.txtNumCols.Location = new System.Drawing.Point(65, 38);
            this.txtNumCols.Name = "txtNumCols";
            this.txtNumCols.Size = new System.Drawing.Size(44, 20);
            this.txtNumCols.TabIndex = 3;
            this.txtNumCols.Text = "5";
            this.txtNumCols.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "# Cols:";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(115, 24);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtRaggedArray, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txt2DArray, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 64);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(460, 185);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // txt2DArray
            // 
            this.txt2DArray.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt2DArray.Location = new System.Drawing.Point(3, 23);
            this.txt2DArray.Multiline = true;
            this.txt2DArray.Name = "txt2DArray";
            this.txt2DArray.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt2DArray.Size = new System.Drawing.Size(224, 159);
            this.txt2DArray.TabIndex = 7;
            this.txt2DArray.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "2D Array";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(233, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ragged Array";
            // 
            // txtRaggedArray
            // 
            this.txtRaggedArray.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRaggedArray.Location = new System.Drawing.Point(233, 23);
            this.txtRaggedArray.Multiline = true;
            this.txtRaggedArray.Name = "txtRaggedArray";
            this.txtRaggedArray.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRaggedArray.Size = new System.Drawing.Size(224, 159);
            this.txtRaggedArray.TabIndex = 9;
            this.txtRaggedArray.WordWrap = false;
            // 
            // howto_to_from_ragged_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtNumCols);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumRows);
            this.Controls.Add(this.label1);
            this.Name = "howto_to_from_ragged_Form1";
            this.Text = "howto_to_from_ragged";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumRows;
        private System.Windows.Forms.TextBox txtNumCols;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtRaggedArray;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt2DArray;
    }
}

