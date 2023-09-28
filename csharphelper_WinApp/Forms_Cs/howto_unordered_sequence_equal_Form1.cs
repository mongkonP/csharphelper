using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_unordered_sequence_equal;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_unordered_sequence_equal_Form1:Form
  { 


        public howto_unordered_sequence_equal_Form1()
        {
            InitializeComponent();
        }

        private void howto_unordered_sequence_equal_Form1_Load(object sender, EventArgs e)
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
                new Person("Diane", "Dent"),
                new Person("Carl", "Carter"),
                new Person("Ed", "Eager"),
            };

            lstA.DataSource = list_a;
            lstB.DataSource = list_b;

            lblAEqualsB1.Text = list_a.HashableSequenceEqual(list_b).ToString();
            lblAEqualsB2.Text = list_a.ComparableSequenceEqual(list_b).ToString();
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
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lstB = new System.Windows.Forms.ListBox();
            this.lstA = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAEqualsB2 = new System.Windows.Forms.Label();
            this.lblAEqualsB1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Hashable:";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(173, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "B";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lstA, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(340, 114);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // lstB
            // 
            this.lstB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstB.FormattingEnabled = true;
            this.lstB.IntegralHeight = false;
            this.lstB.Location = new System.Drawing.Point(173, 23);
            this.lstB.Name = "lstB";
            this.lstB.Size = new System.Drawing.Size(164, 88);
            this.lstB.TabIndex = 3;
            // 
            // lstA
            // 
            this.lstA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstA.FormattingEnabled = true;
            this.lstA.IntegralHeight = false;
            this.lstA.Location = new System.Drawing.Point(3, 23);
            this.lstA.Name = "lstA";
            this.lstA.Size = new System.Drawing.Size(164, 88);
            this.lstA.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "A";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Comparable:";
            // 
            // lblAEqualsB2
            // 
            this.lblAEqualsB2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAEqualsB2.AutoSize = true;
            this.lblAEqualsB2.Location = new System.Drawing.Point(87, 148);
            this.lblAEqualsB2.Name = "lblAEqualsB2";
            this.lblAEqualsB2.Size = new System.Drawing.Size(63, 13);
            this.lblAEqualsB2.TabIndex = 14;
            this.lblAEqualsB2.Text = "lblAEqualsC";
            // 
            // lblAEqualsB1
            // 
            this.lblAEqualsB1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAEqualsB1.AutoSize = true;
            this.lblAEqualsB1.Location = new System.Drawing.Point(87, 127);
            this.lblAEqualsB1.Name = "lblAEqualsB1";
            this.lblAEqualsB1.Size = new System.Drawing.Size(63, 13);
            this.lblAEqualsB1.TabIndex = 15;
            this.lblAEqualsB1.Text = "lblAEqualsB";
            // 
            // howto_unordered_sequence_equal_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 171);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblAEqualsB2);
            this.Controls.Add(this.lblAEqualsB1);
            this.Name = "howto_unordered_sequence_equal_Form1";
            this.Text = "howto_unordered_sequence_equal";
            this.Load += new System.EventHandler(this.howto_unordered_sequence_equal_Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox lstB;
        private System.Windows.Forms.ListBox lstA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAEqualsB2;
        private System.Windows.Forms.Label lblAEqualsB1;
    }
}

