using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Text.RegularExpressions;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_custom_sort_listbox_Form1:Form
  { 


        public howto_custom_sort_listbox_Form1()
        {
            InitializeComponent();
        }

        // Display items sorted in numeric order.
        private void howto_custom_sort_listbox_Form1_Load(object sender, EventArgs e)
        {
            lstAlphabetic.Sorted = true;
            cboAlphabetic.Sorted = true;

            SortListBoxItems(lstNumeric);
            SortComboBoxItems(cboNumeric);

            lstAlphabetic.SelectedIndex = -1;
            lstNumeric.SelectedIndex = -1;
            cboAlphabetic.SelectedIndex = -1;
            cboNumeric.SelectedIndex = -1;
        }

        // Sort the items in the ListBox by their contained numeric values.
        private void SortListBoxItems(ListBox lst)
        {
            // Get the original items as an array.
            int num_items = lst.Items.Count;
            object[] items = new object[num_items];
            lst.Items.CopyTo(items, 0);

            // Sort them by their contained numeric values.
            items = SortNumericItems(items);

            // Display the results.
            lst.Sorted = false;
            lst.DataSource = items;
        }

        // Sort the items in the ComboBox by their contained numeric values.
        private void SortComboBoxItems(ComboBox cbo)
        {
            // Get the original items as an array.
            int num_items = cbo.Items.Count;
            object[] items = new object[num_items];
            cbo.Items.CopyTo(items, 0);

            // Sort them by their contained numeric values.
            items = SortNumericItems(items);

            // Display the results.
            cbo.Sorted = false;
            cbo.DataSource = items;
        }

        // Sort items by contained numeric values.
        private object[] SortNumericItems(object[] items)
        {
            // Get the numeric values of the items.
            int num_items = items.Length;
            const string float_pattern = @"-?\d+\.?\d*";
            double[] values = new double[num_items];
            for (int i = 0; i < num_items; i++)
            {
                string match = Regex.Match(
                    items[i].ToString(), float_pattern).Value;
                double value;
                if (!double.TryParse(match, out value))
                    value = double.MinValue;
                values[i] = value;

                //Console.WriteLine(value + ": " + items[i].ToString());
            }

            // Sort the items array using the keys to determine order.
            Array.Sort(values, items);
            return items;
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
            this.lstNumeric = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstAlphabetic = new System.Windows.Forms.ListBox();
            this.cboAlphabetic = new System.Windows.Forms.ComboBox();
            this.cboNumeric = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Numeric";
            // 
            // lstNumeric
            // 
            this.lstNumeric.FormattingEnabled = true;
            this.lstNumeric.Items.AddRange(new object[] {
            "X 100 Frog",
            "1.66 Cat",
            "X 010.2 Dog",
            "001 Bear",
            "110 Hippo",
            "-1.8 Ape",
            "10.5 Eagle",
            "X 101 Giraffe",
            "No number"});
            this.lstNumeric.Location = new System.Drawing.Point(166, 25);
            this.lstNumeric.Name = "lstNumeric";
            this.lstNumeric.Size = new System.Drawing.Size(148, 134);
            this.lstNumeric.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Alphabetic";
            // 
            // lstAlphabetic
            // 
            this.lstAlphabetic.FormattingEnabled = true;
            this.lstAlphabetic.Items.AddRange(new object[] {
            "X 100 Frog",
            "1.66 Cat",
            "X 010.2 Dog",
            "001 Bear",
            "110 Hippo",
            "-1.8 Ape",
            "10.5 Eagle",
            "X 101 Giraffe",
            "No number"});
            this.lstAlphabetic.Location = new System.Drawing.Point(12, 25);
            this.lstAlphabetic.Name = "lstAlphabetic";
            this.lstAlphabetic.Size = new System.Drawing.Size(148, 134);
            this.lstAlphabetic.TabIndex = 4;
            // 
            // cboAlphabetic
            // 
            this.cboAlphabetic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboAlphabetic.FormattingEnabled = true;
            this.cboAlphabetic.IntegralHeight = false;
            this.cboAlphabetic.Items.AddRange(new object[] {
            "X 100 Frog",
            "1.66 Cat",
            "X 010.2 Dog",
            "001 Bear",
            "110 Hippo",
            "-1.8 Ape",
            "10.5 Eagle",
            "X 101 Giraffe",
            "No number"});
            this.cboAlphabetic.Location = new System.Drawing.Point(12, 167);
            this.cboAlphabetic.Name = "cboAlphabetic";
            this.cboAlphabetic.Size = new System.Drawing.Size(148, 144);
            this.cboAlphabetic.TabIndex = 8;
            // 
            // cboNumeric
            // 
            this.cboNumeric.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboNumeric.FormattingEnabled = true;
            this.cboNumeric.IntegralHeight = false;
            this.cboNumeric.Items.AddRange(new object[] {
            "X 100 Frog",
            "1.66 Cat",
            "X 010.2 Dog",
            "001 Bear",
            "110 Hippo",
            "-1.8 Ape",
            "10.5 Eagle",
            "X 101 Giraffe",
            "No number"});
            this.cboNumeric.Location = new System.Drawing.Point(166, 167);
            this.cboNumeric.Name = "cboNumeric";
            this.cboNumeric.Size = new System.Drawing.Size(148, 144);
            this.cboNumeric.TabIndex = 9;
            // 
            // howto_custom_sort_listbox_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 323);
            this.Controls.Add(this.cboNumeric);
            this.Controls.Add(this.cboAlphabetic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstNumeric);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstAlphabetic);
            this.Name = "howto_custom_sort_listbox_Form1";
            this.Text = "howto_custom_sort_listbox";
            this.Load += new System.EventHandler(this.howto_custom_sort_listbox_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstAlphabetic;
        private System.Windows.Forms.ComboBox cboAlphabetic;
        private System.Windows.Forms.ComboBox cboNumeric;
    }
}

