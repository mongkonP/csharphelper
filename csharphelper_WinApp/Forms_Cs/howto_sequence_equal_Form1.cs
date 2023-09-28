using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_sequence_equal;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_sequence_equal_Form1:Form
  { 


        public howto_sequence_equal_Form1()
        {
            InitializeComponent();
        }

        private void howto_sequence_equal_Form1_Load(object sender, EventArgs e)
        {
            // Make some lists.
            List<Person> list_a = new List<Person>()
            {
                new Person("Art", "Archer"),
                new Person("Bev", "Baker"),
                new Person("Carl", "Carter"),
                new Person("Diane", "Dent"),
                new Person("Ed", "Eager"),
            };
            List<Person> list_b = new List<Person>()
            {
                new Person("Art", "Archer"),
                new Person("Bev", "Baker"),
                new Person("Carl", "Carter"),
                new Person("Diane", "Dent"),
                new Person("Ed", "Eager"),
            };
            List<Person> list_c = new List<Person>()
            {
                new Person("Art", "Archer"),
                new Person("Bev", "Baker"),
                new Person("Diane", "Dent"),
                new Person("Carl", "Carter"),
                new Person("Ed", "Eager"),
            };

            lstA.DataSource = list_a;
            lstB.DataSource = list_b;
            lstC.DataSource = list_c;

            lblAEqualsB.Text = "A == B: " + list_a.SequenceEqual(list_b);
            lblAEqualsC.Text = "A == C: " + list_a.SequenceEqual(list_c);
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
            this.label2 = new System.Windows.Forms.Label();
            this.lblAEqualsC = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstC = new System.Windows.Forms.ListBox();
            this.lstB = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lstA = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAEqualsB = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(96, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "B";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAEqualsC
            // 
            this.lblAEqualsC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAEqualsC.AutoSize = true;
            this.lblAEqualsC.Location = new System.Drawing.Point(11, 153);
            this.lblAEqualsC.Name = "lblAEqualsC";
            this.lblAEqualsC.Size = new System.Drawing.Size(63, 13);
            this.lblAEqualsC.TabIndex = 8;
            this.lblAEqualsC.Text = "lblAEqualsC";
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(189, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "C";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstC
            // 
            this.lstC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstC.FormattingEnabled = true;
            this.lstC.IntegralHeight = false;
            this.lstC.Location = new System.Drawing.Point(189, 23);
            this.lstC.Name = "lstC";
            this.lstC.Size = new System.Drawing.Size(88, 92);
            this.lstC.TabIndex = 4;
            // 
            // lstB
            // 
            this.lstB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstB.FormattingEnabled = true;
            this.lstB.IntegralHeight = false;
            this.lstB.Location = new System.Drawing.Point(96, 23);
            this.lstB.Name = "lstB";
            this.lstB.Size = new System.Drawing.Size(87, 92);
            this.lstB.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstC, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lstB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lstA, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 11);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(280, 118);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // lstA
            // 
            this.lstA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstA.FormattingEnabled = true;
            this.lstA.IntegralHeight = false;
            this.lstA.Location = new System.Drawing.Point(3, 23);
            this.lstA.Name = "lstA";
            this.lstA.Size = new System.Drawing.Size(87, 92);
            this.lstA.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "A";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAEqualsB
            // 
            this.lblAEqualsB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAEqualsB.AutoSize = true;
            this.lblAEqualsB.Location = new System.Drawing.Point(11, 132);
            this.lblAEqualsB.Name = "lblAEqualsB";
            this.lblAEqualsB.Size = new System.Drawing.Size(63, 13);
            this.lblAEqualsB.TabIndex = 9;
            this.lblAEqualsB.Text = "lblAEqualsB";
            // 
            // howto_sequence_equal_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 176);
            this.Controls.Add(this.lblAEqualsC);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblAEqualsB);
            this.Name = "howto_sequence_equal_Form1";
            this.Text = "howto_sequence_equal";
            this.Load += new System.EventHandler(this.howto_sequence_equal_Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAEqualsC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstC;
        private System.Windows.Forms.ListBox lstB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox lstA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAEqualsB;
    }
}

