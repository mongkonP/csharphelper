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
     public partial class howto_listbox_formatstring_Form1:Form
  { 


        public howto_listbox_formatstring_Form1()
        {
            InitializeComponent();
        }

        private void howto_listbox_formatstring_Form1_Load(object sender, EventArgs e)
        {
            double[] prices =
            {
                13.38, 7.75, 50.61, 532.21, 8.29, 111.11, 962.38,
                49.27, 4.06, 98.45, 896.13, 7.51, 592.09, 238.29,
            };
            lstC.FormatString = "C";
            lstC.RightToLeft = RightToLeft.Yes;
            lstC.DataSource = prices;

            DateTime[] dates =
            {
                new DateTime(2013, 4, 1),
                new DateTime(2013, 3, 21),
                new DateTime(2013, 7, 18),
                new DateTime(2013, 9, 9),
                new DateTime(2013, 11, 30),
                new DateTime(2013, 2, 12),
                new DateTime(2013, 4, 1),
                new DateTime(2013, 3, 21),
                new DateTime(2013, 7, 18),
                new DateTime(2013, 9, 9),
                new DateTime(2013, 11, 30),
                new DateTime(2013, 2, 12),
            };
            lstNone.RightToLeft = RightToLeft.Yes;
            lstNone.DataSource = dates;

            lstD.FormatString = "D";
            lstD.RightToLeft = RightToLeft.Yes;
            lstD.DataSource = dates;
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstC = new System.Windows.Forms.ListBox();
            this.lstNone = new System.Windows.Forms.ListBox();
            this.lstD = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(230, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "D";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(106, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "None";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstC
            // 
            this.lstC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstC.FormattingEnabled = true;
            this.lstC.IntegralHeight = false;
            this.lstC.Location = new System.Drawing.Point(10, 20);
            this.lstC.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.lstC.Name = "lstC";
            this.lstC.Size = new System.Drawing.Size(83, 131);
            this.lstC.TabIndex = 0;
            // 
            // lstNone
            // 
            this.lstNone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstNone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstNone.FormattingEnabled = true;
            this.lstNone.IntegralHeight = false;
            this.lstNone.Location = new System.Drawing.Point(113, 20);
            this.lstNone.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.lstNone.Name = "lstNone";
            this.lstNone.Size = new System.Drawing.Size(104, 131);
            this.lstNone.TabIndex = 1;
            // 
            // lstD
            // 
            this.lstD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstD.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstD.FormattingEnabled = true;
            this.lstD.IntegralHeight = false;
            this.lstD.ItemHeight = 14;
            this.lstD.Location = new System.Drawing.Point(237, 20);
            this.lstD.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.lstD.Name = "lstD";
            this.lstD.Size = new System.Drawing.Size(187, 131);
            this.lstD.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.80964F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.57228F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.61809F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstC, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lstNone, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lstD, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(434, 161);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "C";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_listbox_formatstring_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 161);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "howto_listbox_formatstring_Form1";
            this.Text = "howto_listbox_formatstring";
            this.Load += new System.EventHandler(this.howto_listbox_formatstring_Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstC;
        private System.Windows.Forms.ListBox lstNone;
        private System.Windows.Forms.ListBox lstD;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
    }
}

