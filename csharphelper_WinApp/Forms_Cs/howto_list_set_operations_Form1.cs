using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_list_set_operations;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_list_set_operations_Form1:Form
  { 


        public howto_list_set_operations_Form1()
        {
            InitializeComponent();
        }

        private void howto_list_set_operations_Form1_Load(object sender, EventArgs e)
        {
            // Make some lists.
            List<Person> list_a = new List<Person>()
            {
                new Person("Art", "Archer"),
                new Person("Bev", "Baker"),
                new Person("Bev", "Baker"),
                new Person("Carl", "Carter"),
                new Person("Carl", "Carter"),
                new Person("Diane", "Dent"),
                new Person("Ed", "Eager"),
                new Person("Ed", "Eager"),
            };

            List<Person> list_b = new List<Person>()
            {
                new Person("Art", "Archer"),
                new Person("Bev", "Baker"),
                new Person("Bev", "Baker"),
                new Person("Carl", "Carter"),
                new Person("Ed", "Eager"),
                new Person("Ed", "Eager"),
                new Person("Fran", "Firth"),
            };

            // Display the values.
            lstA.DataSource = list_a;
            lstB.DataSource = list_b;
            lstAUnionB.DataSource = list_a.Union(list_b).ToList();
            lstAIntersectB.DataSource = list_a.Intersect(list_b).ToList();
            lstAMinusB.DataSource = list_a.Except(list_b).ToList();

            List<Person> intersection = list_a.Intersect(list_b).ToList();
            List<Person> only_a = list_a.Except(intersection).ToList();
            List<Person> only_b = list_b.Except(intersection).ToList();
            List<Person> xor = only_a.Union(only_b).ToList();
            lstAXorB.DataSource = xor;
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
            this.lstAXorB = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lstAMinusB = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstAIntersectB = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lstAUnionB = new System.Windows.Forms.ListBox();
            this.lstB = new System.Windows.Forms.ListBox();
            this.lstA = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstAXorB
            // 
            this.lstAXorB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstAXorB.FormattingEnabled = true;
            this.lstAXorB.IntegralHeight = false;
            this.lstAXorB.Location = new System.Drawing.Point(343, 23);
            this.lstAXorB.Name = "lstAXorB";
            this.lstAXorB.Size = new System.Drawing.Size(64, 111);
            this.lstAXorB.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(343, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "A ⊕ B";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstAMinusB
            // 
            this.lstAMinusB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstAMinusB.FormattingEnabled = true;
            this.lstAMinusB.IntegralHeight = false;
            this.lstAMinusB.Location = new System.Drawing.Point(275, 23);
            this.lstAMinusB.Name = "lstAMinusB";
            this.lstAMinusB.Size = new System.Drawing.Size(62, 111);
            this.lstAMinusB.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(275, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "A - B";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(207, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "A ∩ B";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(139, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "A ∪ B";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(71, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "B";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstAIntersectB
            // 
            this.lstAIntersectB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstAIntersectB.FormattingEnabled = true;
            this.lstAIntersectB.IntegralHeight = false;
            this.lstAIntersectB.Location = new System.Drawing.Point(207, 23);
            this.lstAIntersectB.Name = "lstAIntersectB";
            this.lstAIntersectB.Size = new System.Drawing.Size(62, 111);
            this.lstAIntersectB.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.lstAXorB, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstAMinusB, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstAIntersectB, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lstAUnionB, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lstB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lstA, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(410, 137);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // lstAUnionB
            // 
            this.lstAUnionB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstAUnionB.FormattingEnabled = true;
            this.lstAUnionB.IntegralHeight = false;
            this.lstAUnionB.Location = new System.Drawing.Point(139, 23);
            this.lstAUnionB.Name = "lstAUnionB";
            this.lstAUnionB.Size = new System.Drawing.Size(62, 111);
            this.lstAUnionB.TabIndex = 4;
            // 
            // lstB
            // 
            this.lstB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstB.FormattingEnabled = true;
            this.lstB.IntegralHeight = false;
            this.lstB.Location = new System.Drawing.Point(71, 23);
            this.lstB.Name = "lstB";
            this.lstB.Size = new System.Drawing.Size(62, 111);
            this.lstB.TabIndex = 3;
            // 
            // lstA
            // 
            this.lstA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstA.FormattingEnabled = true;
            this.lstA.IntegralHeight = false;
            this.lstA.Location = new System.Drawing.Point(3, 23);
            this.lstA.Name = "lstA";
            this.lstA.Size = new System.Drawing.Size(62, 111);
            this.lstA.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "A";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_list_set_operations_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 161);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "howto_list_set_operations_Form1";
            this.Text = "howto_list_set_operations";
            this.Load += new System.EventHandler(this.howto_list_set_operations_Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstAXorB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstAMinusB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstAIntersectB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox lstAUnionB;
        private System.Windows.Forms.ListBox lstB;
        private System.Windows.Forms.ListBox lstA;
        private System.Windows.Forms.Label label1;
    }
}

