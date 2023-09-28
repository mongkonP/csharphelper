using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_randomize_list_extension;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_randomize_list_extension_Form1:Form
  { 


        public howto_randomize_list_extension_Form1()
        {
            InitializeComponent();
        }

        private string[] ItemArray;
        private List<string> ItemList;

        private void howto_randomize_list_extension_Form1_Load(object sender, EventArgs e)
        {
            // Initialize the array and list.
            ItemArray = new string[] { "Apple", "Banana", "Cherry", "Date", "Eagle", "Fish", "Golf", "Harp", "Ibex", "Jackel", "Kangaroo" };
            ItemList = new List<string>(ItemArray);

            // Display the array and list in ListBoxes.
            lstArray.DataSource = ItemArray;
            lstList.DataSource = ItemList;
        }

        // Randomize the array and list.
        private void btnRandomize_Click(object sender, EventArgs e)
        {
            RandomizeLists();
        }
        private void RandomizeLists()
        {
            ItemArray.Randomize();
            ItemList.Randomize();

            // Redisplay the values.
            lstArray.DataSource = null;
            lstArray.DataSource = ItemArray;
            lstList.DataSource = null;
            lstList.DataSource = ItemList;
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
            this.lstArray = new System.Windows.Forms.ListBox();
            this.lstList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRandomize = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstArray
            // 
            this.lstArray.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstArray.FormattingEnabled = true;
            this.lstArray.IntegralHeight = false;
            this.lstArray.Location = new System.Drawing.Point(3, 21);
            this.lstArray.Name = "lstArray";
            this.lstArray.Size = new System.Drawing.Size(157, 128);
            this.lstArray.TabIndex = 0;
            // 
            // lstList
            // 
            this.lstList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstList.FormattingEnabled = true;
            this.lstList.IntegralHeight = false;
            this.lstList.Location = new System.Drawing.Point(166, 21);
            this.lstList.Name = "lstList";
            this.lstList.Size = new System.Drawing.Size(158, 128);
            this.lstList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Array";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(166, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "List";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRandomize
            // 
            this.btnRandomize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.btnRandomize, 2);
            this.btnRandomize.Location = new System.Drawing.Point(126, 159);
            this.btnRandomize.Name = "btnRandomize";
            this.btnRandomize.Size = new System.Drawing.Size(75, 23);
            this.btnRandomize.TabIndex = 4;
            this.btnRandomize.Text = "Randomize";
            this.btnRandomize.UseVisualStyleBackColor = true;
            this.btnRandomize.Click += new System.EventHandler(this.btnRandomize_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnRandomize, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lstArray, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lstList, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.81818F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.18182F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(327, 190);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // howto_randomize_list_extension_Form1
            // 
            this.AcceptButton = this.btnRandomize;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 214);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "howto_randomize_list_extension_Form1";
            this.Text = "howto_randomize_list_extension";
            this.Load += new System.EventHandler(this.howto_randomize_list_extension_Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstArray;
        private System.Windows.Forms.ListBox lstList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRandomize;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

