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
     public partial class howto_use_array_methods_Form1:Form
  { 


        public howto_use_array_methods_Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            // Clear any previous formatting.
            rchItems.Select(0, rchItems.Text.Length);
            rchItems.SelectionColor = Color.Black;
            rchItems.SelectionBackColor = Color.White;

            // Array.Reverse.
            char[] items = rchItems.Text.ToCharArray();
            Array.Reverse(items);
            txtReverse.Text = new string(items);

            // Array.Sort.
            items = rchItems.Text.ToCharArray();
            Array.Sort(items);
            txtSort.Text = new string(items);

            // Array.IndexOf.
            char test_char = txtTestChar.Text[0];
            items = rchItems.Text.ToCharArray();
            int index_of = Array.IndexOf(items, test_char);
            txtIndexOf.Text = index_of.ToString();
            if (index_of >= 0)
            {
                rchItems.Select(index_of, 1);
                rchItems.SelectionColor = Color.Red;
            }

            // Array.LastIndexOf.
            int last_index_of = Array.LastIndexOf(items, test_char);
            txtLastIndexOf.Text = last_index_of.ToString();
            if (last_index_of >= 0)
            {
                rchItems.Select(last_index_of, 1);
                rchItems.SelectionBackColor = Color.LightBlue;
            }
            rchItems.Select(0, 0);

            // Copy Equals.
            char[] copy = new char[items.Length];
            Array.Copy(items, copy, items.Length);
            txtCopyEquals.Text = Array.Equals(items, copy).ToString();

            // Clone Equals.
            char[] clone = (char[])items.Clone();
            txtCloneEquals.Text = Array.Equals(items, clone).ToString();

            // Two arrays set to indicate the same memory location.
            char[] reference = items;
            txtRefEquals.Text = Array.Equals(items, reference).ToString();

            // Array.Resize.
            int initial_length = items.Length;
            Array.Resize(ref items, 2 * initial_length);
            Array.Copy(items, 0, items, initial_length, initial_length);
            rchLarger.Text = new string(items);

            // Array.Resize.
            Array.Resize(ref items, initial_length / 2);
            rchSmaller.Text = new string(items);
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
            this.txtRefEquals = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.rchSmaller = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.rchLarger = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCloneEquals = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCopyEquals = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rchItems = new System.Windows.Forms.RichTextBox();
            this.txtLastIndexOf = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIndexOf = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReverse = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTestChar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRefEquals
            // 
            this.txtRefEquals.Location = new System.Drawing.Point(90, 248);
            this.txtRefEquals.Name = "txtRefEquals";
            this.txtRefEquals.Size = new System.Drawing.Size(32, 20);
            this.txtRefEquals.TabIndex = 43;
            this.txtRefEquals.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 251);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 44;
            this.label11.Text = "Ref Equals:";
            // 
            // rchSmaller
            // 
            this.rchSmaller.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rchSmaller.Location = new System.Drawing.Point(90, 352);
            this.rchSmaller.Name = "rchSmaller";
            this.rchSmaller.Size = new System.Drawing.Size(226, 25);
            this.rchSmaller.TabIndex = 42;
            this.rchSmaller.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 355);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Smaller:";
            // 
            // rchLarger
            // 
            this.rchLarger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rchLarger.Location = new System.Drawing.Point(90, 290);
            this.rchLarger.Name = "rchLarger";
            this.rchLarger.Size = new System.Drawing.Size(226, 56);
            this.rchLarger.TabIndex = 40;
            this.rchLarger.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 293);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "Larger:";
            // 
            // txtCloneEquals
            // 
            this.txtCloneEquals.Location = new System.Drawing.Point(90, 222);
            this.txtCloneEquals.Name = "txtCloneEquals";
            this.txtCloneEquals.Size = new System.Drawing.Size(32, 20);
            this.txtCloneEquals.TabIndex = 37;
            this.txtCloneEquals.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Clone Equals:";
            // 
            // txtCopyEquals
            // 
            this.txtCopyEquals.Location = new System.Drawing.Point(90, 196);
            this.txtCopyEquals.Name = "txtCopyEquals";
            this.txtCopyEquals.Size = new System.Drawing.Size(32, 20);
            this.txtCopyEquals.TabIndex = 35;
            this.txtCopyEquals.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Copy Equals:";
            // 
            // rchItems
            // 
            this.rchItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rchItems.Location = new System.Drawing.Point(90, 12);
            this.rchItems.Name = "rchItems";
            this.rchItems.Size = new System.Drawing.Size(226, 22);
            this.rchItems.TabIndex = 22;
            this.rchItems.Text = "The quick brown fox jumps over the lazy dog.";
            // 
            // txtLastIndexOf
            // 
            this.txtLastIndexOf.Location = new System.Drawing.Point(90, 170);
            this.txtLastIndexOf.Name = "txtLastIndexOf";
            this.txtLastIndexOf.Size = new System.Drawing.Size(32, 20);
            this.txtLastIndexOf.TabIndex = 31;
            this.txtLastIndexOf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "LastIndexOf:";
            // 
            // txtIndexOf
            // 
            this.txtIndexOf.Location = new System.Drawing.Point(90, 144);
            this.txtIndexOf.Name = "txtIndexOf";
            this.txtIndexOf.Size = new System.Drawing.Size(32, 20);
            this.txtIndexOf.TabIndex = 30;
            this.txtIndexOf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "IndexOf:";
            // 
            // txtSort
            // 
            this.txtSort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSort.Location = new System.Drawing.Point(90, 118);
            this.txtSort.Name = "txtSort";
            this.txtSort.Size = new System.Drawing.Size(226, 20);
            this.txtSort.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Sort:";
            // 
            // txtReverse
            // 
            this.txtReverse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReverse.Location = new System.Drawing.Point(90, 92);
            this.txtReverse.Name = "txtReverse";
            this.txtReverse.Size = new System.Drawing.Size(226, 20);
            this.txtReverse.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Reverse:";
            // 
            // txtTestChar
            // 
            this.txtTestChar.Location = new System.Drawing.Point(90, 40);
            this.txtTestChar.Name = "txtTestChar";
            this.txtTestChar.Size = new System.Drawing.Size(32, 20);
            this.txtTestChar.TabIndex = 24;
            this.txtTestChar.Text = "e";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Test Item:";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGo.Location = new System.Drawing.Point(127, 63);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 25;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Items:";
            // 
            // howto_use_array_methods_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 389);
            this.Controls.Add(this.txtRefEquals);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.rchSmaller);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.rchLarger);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCloneEquals);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCopyEquals);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rchItems);
            this.Controls.Add(this.txtLastIndexOf);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtIndexOf);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSort);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtReverse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTestChar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.label1);
            this.Name = "howto_use_array_methods_Form1";
            this.Text = "howto_use_array_methods";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRefEquals;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox rchSmaller;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox rchLarger;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCloneEquals;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCopyEquals;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox rchItems;
        private System.Windows.Forms.TextBox txtLastIndexOf;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIndexOf;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtReverse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTestChar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label1;
    }
}

