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
     public partial class howto_iterate_collection_Form1:Form
  { 


        public howto_iterate_collection_Form1()
        {
            InitializeComponent();
        }

        private void howto_iterate_collection_Form1_Load(object sender, EventArgs e)
        {
            // Make two arrays, a list, and a dictionary.
            string[] fruits = 
            { 
                "Apple", 
                "Banana", 
                "Cherry" 
            };
            List<string> cookies = new List<string>() 
            { 
                "Chocolate Chip", 
                "Snickerdoodle", 
                "Peanut Butter" 
            };
            Dictionary<int, string> dict = new Dictionary<int, string>()
            {
                {1, "One"},
                {2, "Two"},
                {3, "Three"},
            };
            string[,] array2d =
            {
                { "0, 0", "0, 1", "0, 2"},
                { "1, 0", "1, 1", "1, 2"},
            };

            // Iterate over the items in the arrays, list, and dictionary.
            foreach (string fruit in fruits) lstFruits.Items.Add(fruit);
            foreach (string cookie in cookies) lstCookies.Items.Add(cookie);
            foreach (KeyValuePair<int, string> pair in dict)
                lstDictionary.Items.Add(pair);
            foreach (string item in array2d) lstRowColumn.Items.Add(item);
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
            this.lstDictionary = new System.Windows.Forms.ListBox();
            this.lstRowColumn = new System.Windows.Forms.ListBox();
            this.lstCookies = new System.Windows.Forms.ListBox();
            this.lstFruits = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstDictionary
            // 
            this.lstDictionary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDictionary.FormattingEnabled = true;
            this.lstDictionary.IntegralHeight = false;
            this.lstDictionary.Location = new System.Drawing.Point(5, 108);
            this.lstDictionary.Name = "lstDictionary";
            this.lstDictionary.Size = new System.Drawing.Size(144, 98);
            this.lstDictionary.TabIndex = 6;
            // 
            // lstRowColumn
            // 
            this.lstRowColumn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRowColumn.FormattingEnabled = true;
            this.lstRowColumn.IntegralHeight = false;
            this.lstRowColumn.Location = new System.Drawing.Point(155, 108);
            this.lstRowColumn.Name = "lstRowColumn";
            this.lstRowColumn.Size = new System.Drawing.Size(144, 98);
            this.lstRowColumn.TabIndex = 7;
            // 
            // lstCookies
            // 
            this.lstCookies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCookies.FormattingEnabled = true;
            this.lstCookies.IntegralHeight = false;
            this.lstCookies.Location = new System.Drawing.Point(155, 5);
            this.lstCookies.Name = "lstCookies";
            this.lstCookies.Size = new System.Drawing.Size(144, 97);
            this.lstCookies.TabIndex = 5;
            // 
            // lstFruits
            // 
            this.lstFruits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFruits.FormattingEnabled = true;
            this.lstFruits.IntegralHeight = false;
            this.lstFruits.Location = new System.Drawing.Point(5, 5);
            this.lstFruits.Name = "lstFruits";
            this.lstFruits.Size = new System.Drawing.Size(144, 97);
            this.lstFruits.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lstFruits, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstRowColumn, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lstDictionary, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lstCookies, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(304, 211);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // howto_iterate_collection_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 211);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "howto_iterate_collection_Form1";
            this.Text = "howto_iterate_collection";
            this.Load += new System.EventHandler(this.howto_iterate_collection_Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstDictionary;
        private System.Windows.Forms.ListBox lstRowColumn;
        private System.Windows.Forms.ListBox lstCookies;
        private System.Windows.Forms.ListBox lstFruits;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

