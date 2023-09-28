using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_implement_interface;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_implement_interface_Form1:Form
  { 


        public howto_implement_interface_Form1()
        {
            InitializeComponent();
        }

        // Make some people.
        private void howto_implement_interface_Form1_Load(object sender, EventArgs e)
        {
            // Make some people and display them.
            SortablePerson[] unsorted = 
            {
                new SortablePerson() { FirstName = "Sam", LastName = "Cart" },
                new SortablePerson() { FirstName = "Ann", LastName = "Beech" },
                new SortablePerson() { FirstName = "Mark", LastName = "Ash" },
                new SortablePerson() { FirstName = "Chris", LastName = "Beech" },
                new SortablePerson() { FirstName = "Phred", LastName = "Cart" },
            };

            lstUnsorted.DataSource = unsorted;

            // Make some people, sort them, and display them.
            SortablePerson[] sorted = 
            {
                new SortablePerson() { FirstName = "Sam", LastName = "Cart" },
                new SortablePerson() { FirstName = "Ann", LastName = "Beech" },
                new SortablePerson() { FirstName = "Mark", LastName = "Ash" },
                new SortablePerson() { FirstName = "Chris", LastName = "Beech" },
                new SortablePerson() { FirstName = "Phred", LastName = "Cart" },
            };

            Array.Sort(sorted);
            
            lstSorted.DataSource = sorted;
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
            this.lstUnsorted = new System.Windows.Forms.ListBox();
            this.lstSorted = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstUnsorted
            // 
            this.lstUnsorted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstUnsorted.FormattingEnabled = true;
            this.lstUnsorted.IntegralHeight = false;
            this.lstUnsorted.Location = new System.Drawing.Point(3, 3);
            this.lstUnsorted.Name = "lstUnsorted";
            this.lstUnsorted.Size = new System.Drawing.Size(151, 93);
            this.lstUnsorted.TabIndex = 0;
            // 
            // lstSorted
            // 
            this.lstSorted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSorted.FormattingEnabled = true;
            this.lstSorted.IntegralHeight = false;
            this.lstSorted.Location = new System.Drawing.Point(160, 3);
            this.lstSorted.Name = "lstSorted";
            this.lstSorted.Size = new System.Drawing.Size(151, 93);
            this.lstSorted.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lstSorted, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstUnsorted, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(314, 99);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // howto_implement_interface_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 123);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "howto_implement_interface_Form1";
            this.Text = "howto_implement_interface";
            this.Load += new System.EventHandler(this.howto_implement_interface_Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstUnsorted;
        private System.Windows.Forms.ListBox lstSorted;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

