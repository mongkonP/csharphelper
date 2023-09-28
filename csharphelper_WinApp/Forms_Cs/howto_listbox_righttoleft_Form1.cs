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
     public partial class howto_listbox_righttoleft_Form1:Form
  { 


        public howto_listbox_righttoleft_Form1()
        {
            InitializeComponent();
        }

        private void howto_listbox_righttoleft_Form1_Load(object sender, EventArgs e)
        {
            double[] values =
            {
                111111.111111, 888888.888888,
                13.38, 7.75, 50.61, 532.21, 8.29, 111.11, 962.38,
                49.27, 4.06, 98.45, 896.13, 7.51, 592.09, 238.29,
            };
            lstPrices.DataSource = values;

            lstRightAligned.RightToLeft = RightToLeft.Yes;
            lstRightAligned.DataSource = values;

            lstFixedWidth.RightToLeft = RightToLeft.Yes;
            lstFixedWidth.DataSource = values;
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
            this.lstPrices = new System.Windows.Forms.ListBox();
            this.lstRightAligned = new System.Windows.Forms.ListBox();
            this.lstFixedWidth = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(258, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Arial";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(130, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "RightToLeft";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstPrices
            // 
            this.lstPrices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPrices.FormattingEnabled = true;
            this.lstPrices.IntegralHeight = false;
            this.lstPrices.Location = new System.Drawing.Point(10, 20);
            this.lstPrices.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.lstPrices.Name = "lstPrices";
            this.lstPrices.Size = new System.Drawing.Size(107, 156);
            this.lstPrices.TabIndex = 0;
            // 
            // lstRightAligned
            // 
            this.lstRightAligned.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRightAligned.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstRightAligned.FormattingEnabled = true;
            this.lstRightAligned.IntegralHeight = false;
            this.lstRightAligned.Location = new System.Drawing.Point(137, 20);
            this.lstRightAligned.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.lstRightAligned.Name = "lstRightAligned";
            this.lstRightAligned.Size = new System.Drawing.Size(108, 156);
            this.lstRightAligned.TabIndex = 1;
            // 
            // lstFixedWidth
            // 
            this.lstFixedWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFixedWidth.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFixedWidth.FormattingEnabled = true;
            this.lstFixedWidth.IntegralHeight = false;
            this.lstFixedWidth.ItemHeight = 14;
            this.lstFixedWidth.Location = new System.Drawing.Point(265, 20);
            this.lstFixedWidth.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.lstFixedWidth.Name = "lstFixedWidth";
            this.lstFixedWidth.Size = new System.Drawing.Size(109, 156);
            this.lstFixedWidth.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstPrices, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lstRightAligned, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lstFixedWidth, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(384, 186);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Normal";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_listbox_righttoleft_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 186);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "howto_listbox_righttoleft_Form1";
            this.Text = "howto_listbox_righttoleft";
            this.Load += new System.EventHandler(this.howto_listbox_righttoleft_Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstPrices;
        private System.Windows.Forms.ListBox lstRightAligned;
        private System.Windows.Forms.ListBox lstFixedWidth;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
    }
}

