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
     public partial class howto_listview_size_columns_Form1:Form
  { 


        public howto_listview_size_columns_Form1()
        {
            InitializeComponent();
        }

        // Set the listView's column sizes to the same value.
        private void SetListViewColumnSizes(ListView lvw, int width)
        {
            foreach (ColumnHeader col in lvw.Columns)
                col.Width = width;
        }

        // Make all of the columns 100 pixels wide.
        private void btnSize100_Click(object sender, EventArgs e)
        {
            SetListViewColumnSizes(lvwBooks, 100);
            SizeForm();
        }

        // Size the columns to fit their data.
        private void btnSizeMinus1_Click(object sender, EventArgs e)
        {
            SetListViewColumnSizes(lvwBooks, -1);
            SizeForm();
        }

        // Size the columns to fit their data and column headers.
        private void btnSizeMinus2_Click(object sender, EventArgs e)
        {
            SetListViewColumnSizes(lvwBooks, -2);
            SizeForm();
        }

        // Make the ListView fit its data
        // and make the form fit the listView.
        private void SizeForm()
        {
            // Add up the column widths.
            int wid = 0;
            foreach (ColumnHeader col in lvwBooks.Columns)
            {
                wid += col.Width;
            }

            // Size the ListView and form.
            lvwBooks.Width = wid + 5;
            this.ClientSize = new Size(
                lvwBooks.Right + lvwBooks.Left,
                this.ClientSize.Height);
        }

        // Display some data.
        private void howto_listview_size_columns_Form1_Load(object sender, EventArgs e)
        {
            // Create some data.
            string[,] data =
            {
                { "C# 5.0 Programmer's Reference", "http://www.wrox.com/WileyCDA/WroxTitle/C-5-0-Programmer-s-Reference.productCd-1118847288.html", "978-1-118-84728-2", "960", "2014" },
                { "MCSD Certification Toolkit (Exam 70-483): Programming in C#", "http://www.wrox.com/WileyCDA/WroxTitle/C-5-0-Programmer-s-Reference.productCd-1118847288.html", "978-1-118-61209-5", "648", "2013" },
                { "Visual Basic 2012 Programmer's Reference", "http://www.wrox.com/WileyCDA/WroxTitle/Visual-Basic-2012-Programmer-s-Reference.productCd-1118314077.html", "978-1-118-31407-4", "840", "2012" },
                { "Essential Algorithms: A Practical Approach to Computer Algorithms ", "http://www.wiley.com/WileyCDA/WileyTitle/productCd-1118612108.html", "978-1-118-61210-1", "624", "2013" },
                { "Beginning Database Design Solutions", "http://www.vb-helper.com/db_design.htm", "978-0-470-38549-4", "552", "2008" },
                { "Start Here! Fundamentals of Microsoft .NET Programming", "http://www.amazon.com/Start-Here-Fundamentals-Microsoft-Programming/dp/0735661685", "978-0-735-66168-4", "264", "2011" },
            };

            // Make the ListView's column headers.
            lvwBooks.Columns.Clear();
            lvwBooks.Columns.Add("Title", 250);
            lvwBooks.Columns.Add("URL", 250);
            lvwBooks.Columns.Add("ISBN", 150);
            lvwBooks.Columns.Add("Number of Pages", 50, HorizontalAlignment.Right);
            lvwBooks.Columns.Add("Publication Year", 50, HorizontalAlignment.Right);

            // Add the data.
            CopyArrayToListView(lvwBooks, data);

            // Display the details view.
            lvwBooks.View = View.Details;
        }

        // Copy a two-dimensional array of data into a ListView.
        private void CopyArrayToListView(ListView lvw, string[,] data)
        {
            int max_row = data.GetUpperBound(0);
            int max_col = data.GetUpperBound(1);
            for (int row = 0; row <= max_row; row++)
            {
                ListViewItem new_item = lvw.Items.Add(data[row, 0]);
                for (int col = 1; col <= max_col; col++)
                {
                    new_item.SubItems.Add(data[row, col]);
                }
            }
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
            this.lvwBooks = new System.Windows.Forms.ListView();
            this.btnSize100 = new System.Windows.Forms.Button();
            this.btnSizeMinus1 = new System.Windows.Forms.Button();
            this.btnSizeMinus2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwBooks
            // 
            this.lvwBooks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lvwBooks.Location = new System.Drawing.Point(12, 41);
            this.lvwBooks.Name = "lvwBooks";
            this.lvwBooks.Size = new System.Drawing.Size(765, 150);
            this.lvwBooks.TabIndex = 1;
            this.lvwBooks.UseCompatibleStateImageBehavior = false;
            // 
            // btnSize100
            // 
            this.btnSize100.Location = new System.Drawing.Point(12, 12);
            this.btnSize100.Name = "btnSize100";
            this.btnSize100.Size = new System.Drawing.Size(75, 23);
            this.btnSize100.TabIndex = 2;
            this.btnSize100.Text = "Size = 100";
            this.btnSize100.UseVisualStyleBackColor = true;
            this.btnSize100.Click += new System.EventHandler(this.btnSize100_Click);
            // 
            // btnSizeMinus1
            // 
            this.btnSizeMinus1.Location = new System.Drawing.Point(107, 12);
            this.btnSizeMinus1.Name = "btnSizeMinus1";
            this.btnSizeMinus1.Size = new System.Drawing.Size(75, 23);
            this.btnSizeMinus1.TabIndex = 3;
            this.btnSizeMinus1.Text = "Size = -1";
            this.btnSizeMinus1.UseVisualStyleBackColor = true;
            this.btnSizeMinus1.Click += new System.EventHandler(this.btnSizeMinus1_Click);
            // 
            // btnSizeMinus2
            // 
            this.btnSizeMinus2.Location = new System.Drawing.Point(202, 12);
            this.btnSizeMinus2.Name = "btnSizeMinus2";
            this.btnSizeMinus2.Size = new System.Drawing.Size(75, 23);
            this.btnSizeMinus2.TabIndex = 4;
            this.btnSizeMinus2.Text = "Size = -2";
            this.btnSizeMinus2.UseVisualStyleBackColor = true;
            this.btnSizeMinus2.Click += new System.EventHandler(this.btnSizeMinus2_Click);
            // 
            // howto_listview_size_columns_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 203);
            this.Controls.Add(this.btnSizeMinus2);
            this.Controls.Add(this.btnSizeMinus1);
            this.Controls.Add(this.btnSize100);
            this.Controls.Add(this.lvwBooks);
            this.Name = "howto_listview_size_columns_Form1";
            this.Text = "howto_listview_size_columns";
            this.Load += new System.EventHandler(this.howto_listview_size_columns_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwBooks;
        private System.Windows.Forms.Button btnSize100;
        private System.Windows.Forms.Button btnSizeMinus1;
        private System.Windows.Forms.Button btnSizeMinus2;
    }
}

