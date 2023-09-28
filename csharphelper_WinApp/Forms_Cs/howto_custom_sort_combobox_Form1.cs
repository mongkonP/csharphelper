using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_custom_sort_combobox;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_custom_sort_combobox_Form1:Form
  { 


        public howto_custom_sort_combobox_Form1()
        {
            InitializeComponent();
        }

        private void howto_custom_sort_combobox_Form1_Load(object sender, EventArgs e)
        {
            // Copy the items into an array.
            int num_items = lstNumeric.Items.Count;
            string[] items = new string[num_items];
            for (int i = 0; i < num_items; i++)
                items[i] = lstNumeric.Items[i].ToString();

            // Sort the array.
            RomanItemComparer roman_comparer =
                new RomanItemComparer();
            Array.Sort(items, roman_comparer);

            // Display the sorted items.
            lstNumeric.Sorted = false;
            lstNumeric.DataSource = items;
            cboNumeric.Sorted = false;
            cboNumeric.DataSource = items;

            // Sort the alphabetically sorted controls.
            lstAlphabetic.Sorted = true;
            cboAlphabetic.Sorted = true;

            lstAlphabetic.SelectedIndex = -1;
            cboAlphabetic.SelectedIndex = -1;
            lstNumeric.SelectedIndex = -1;
            cboNumeric.SelectedIndex = -1;
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
            this.cboNumeric = new System.Windows.Forms.ComboBox();
            this.cboAlphabetic = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstNumeric = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstAlphabetic = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // cboNumeric
            // 
            this.cboNumeric.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboNumeric.FormattingEnabled = true;
            this.cboNumeric.IntegralHeight = false;
            this.cboNumeric.Items.AddRange(new object[] {
            "iv. Date",
            "vii. Grapefruit",
            "iii. Carrot",
            "v. Eggplant",
            "i. Apple",
            "vi. Fish",
            "ix. Ice cream",
            "viii. Honey",
            "ii. Broccoli"});
            this.cboNumeric.Location = new System.Drawing.Point(167, 168);
            this.cboNumeric.Name = "cboNumeric";
            this.cboNumeric.Size = new System.Drawing.Size(148, 144);
            this.cboNumeric.TabIndex = 15;
            // 
            // cboAlphabetic
            // 
            this.cboAlphabetic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboAlphabetic.FormattingEnabled = true;
            this.cboAlphabetic.IntegralHeight = false;
            this.cboAlphabetic.Items.AddRange(new object[] {
            "iv. Date",
            "vii. Grapefruit",
            "iii. Carrot",
            "v. Eggplant",
            "i. Apple",
            "vi. Fish",
            "ix. Ice cream",
            "viii. Honey",
            "ii. Broccoli"});
            this.cboAlphabetic.Location = new System.Drawing.Point(13, 168);
            this.cboAlphabetic.Name = "cboAlphabetic";
            this.cboAlphabetic.Size = new System.Drawing.Size(148, 144);
            this.cboAlphabetic.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Numeric";
            // 
            // lstNumeric
            // 
            this.lstNumeric.FormattingEnabled = true;
            this.lstNumeric.Items.AddRange(new object[] {
            "iv. Date",
            "vii. Grapefruit",
            "iii. Carrot",
            "v. Eggplant",
            "i. Apple",
            "vi. Fish",
            "ix. Ice cream",
            "viii. Honey",
            "ii. Broccoli"});
            this.lstNumeric.Location = new System.Drawing.Point(167, 26);
            this.lstNumeric.Name = "lstNumeric";
            this.lstNumeric.Size = new System.Drawing.Size(148, 134);
            this.lstNumeric.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Alphabetic";
            // 
            // lstAlphabetic
            // 
            this.lstAlphabetic.FormattingEnabled = true;
            this.lstAlphabetic.Items.AddRange(new object[] {
            "iv. Date",
            "vii. Grapefruit",
            "iii. Carrot",
            "v. Eggplant",
            "i. Apple",
            "vi. Fish",
            "ix. Ice cream",
            "viii. Honey",
            "ii. Broccoli"});
            this.lstAlphabetic.Location = new System.Drawing.Point(13, 26);
            this.lstAlphabetic.Name = "lstAlphabetic";
            this.lstAlphabetic.Size = new System.Drawing.Size(148, 134);
            this.lstAlphabetic.TabIndex = 10;
            // 
            // howto_custom_sort_combobox_Form1
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
            this.Name = "howto_custom_sort_combobox_Form1";
            this.Text = "howto_custom_sort_combobox";
            this.Load += new System.EventHandler(this.howto_custom_sort_combobox_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboNumeric;
        private System.Windows.Forms.ComboBox cboAlphabetic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstAlphabetic;

    }
}

