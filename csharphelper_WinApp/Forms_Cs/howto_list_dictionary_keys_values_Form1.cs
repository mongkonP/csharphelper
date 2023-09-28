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
     public partial class howto_list_dictionary_keys_values_Form1:Form
  { 


        public howto_list_dictionary_keys_values_Form1()
        {
            InitializeComponent();
        }

        // The dictionary of digit names.
        private Dictionary<int, string> Numbers = new Dictionary<int, string>()
        {
            {0, "Zero"},
            {1, "One"},
            {2, "Two"},
            {3, "Three"},
            {4, "Four"},
            {5, "Five"},
            {6, "Six"},
            {7, "Seven"},
            {8, "Either"},
            {9, "Nine"}
        };

        private void howto_list_dictionary_keys_values_Form1_Load(object sender, EventArgs e)
        {
            // Display the keys.
            foreach (int number in Numbers.Keys)
                lstKeys.Items.Add(number);

            // Convert the Dictionary's ValueCollection
            // into an array and display the values.
            string[] values = Numbers.Values.ToArray();
            for (int i = 0; i < values.Length; i++)
                lstValues.Items.Add(values[i]);

            // Display the keys and values.
            foreach (int number in Numbers.Keys)
                lstKeysAndValues.Items.Add(number.ToString() +
                    ": " + Numbers[number]);
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
            this.lstKeysAndValues = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstValues = new System.Windows.Forms.ListBox();
            this.lstKeys = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(229, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Keys && Values";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstKeysAndValues
            // 
            this.lstKeysAndValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstKeysAndValues.FormattingEnabled = true;
            this.lstKeysAndValues.Location = new System.Drawing.Point(229, 23);
            this.lstKeysAndValues.Name = "lstKeysAndValues";
            this.lstKeysAndValues.Size = new System.Drawing.Size(108, 160);
            this.lstKeysAndValues.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstKeysAndValues, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstValues, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lstKeys, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(340, 187);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(116, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Values";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Keys";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstValues
            // 
            this.lstValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstValues.FormattingEnabled = true;
            this.lstValues.Location = new System.Drawing.Point(116, 23);
            this.lstValues.Name = "lstValues";
            this.lstValues.Size = new System.Drawing.Size(107, 160);
            this.lstValues.TabIndex = 2;
            // 
            // lstKeys
            // 
            this.lstKeys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstKeys.FormattingEnabled = true;
            this.lstKeys.Location = new System.Drawing.Point(3, 23);
            this.lstKeys.Name = "lstKeys";
            this.lstKeys.Size = new System.Drawing.Size(107, 160);
            this.lstKeys.TabIndex = 0;
            // 
            // howto_list_dictionary_keys_values_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 211);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "howto_list_dictionary_keys_values_Form1";
            this.Text = "howto_list_dictionary_keys_values";
            this.Load += new System.EventHandler(this.howto_list_dictionary_keys_values_Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstKeysAndValues;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstValues;
        private System.Windows.Forms.ListBox lstKeys;
    }
}

