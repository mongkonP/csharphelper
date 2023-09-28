using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_listview_extensions;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_listview_extensions_Form1:Form
  { 


        public howto_listview_extensions_Form1()
        {
            InitializeComponent();
        }

        private void howto_listview_extensions_Form1_Load(object sender, EventArgs e)
        {
            // Make the ListView column headers.
            lvwBooks.SetColumnHeaders(
                new object[] {
                    "Title", HorizontalAlignment.Left,
                    "URL", HorizontalAlignment.Left,
                    "ISBN", HorizontalAlignment.Left,
                    "Picture", HorizontalAlignment.Left,
                    "Pages", HorizontalAlignment.Right,
                    "Year", HorizontalAlignment.Right,
                    "Pub Date", HorizontalAlignment.Right
                });

            // Remove any existing items.
            lvwBooks.Items.Clear();

            // Add data rows.
            lvwBooks.AddRow("Ready-to-Run Visual Basic Algorithms", "http://www.vb-helper.com/vba.htm", "0-471-24268-3", "http://www.vb-helper.com/vba.jpg", "395", "1998", "1/5/1998");
            lvwBooks.AddRow("Visual Basic Graphics Programming", "http://www.vb-helper.com/vbgp.htm", "0-472-35599-2", "http://www.vb-helper.com/vbgp.jpg", "712", "2000", "2/2/2000");
            lvwBooks.AddRow("Advanced Visual Basic Techniques", "http://www.vb-helper.com/avbt.htm", "0-471-18881-6", "http://www.vb-helper.com/avbt.jpg", "440", "1997", "3/3/1997");
            lvwBooks.AddRow("Custom Controls Library", "http://www.vb-helper.com/ccl.htm", "0-471-24267-5", "http://www.vb-helper.com/ccl.jpg", "684", "1998", "10/10/1998");
            lvwBooks.AddRow("Ready-to-Run Delphi Algorithms", "http://www.vb-helper.com/da.htm", "0-471-25400-2", "http://www.vb-helper.com/da.jpg", "398", "1998", "01/20/1998");
            lvwBooks.AddRow("Bug Proofing Visual Basic", "http://www.vb-helper.com/err.htm", "0-471-32351-9", "http://www.vb-helper.com/err.jpg", "397", "1999", "5/5/1999");
            lvwBooks.AddRow("Ready-to-Run Visual Basic Code Library", "http://www.vb-helper.com/vbcl.htm", "0-471-33345-X", "http://www.vb-helper.com/vbcl.jpg", "424", "1999", "8/8/1999");

            lvwBooks.AddRow("Bogus Book", "http://www.noplace.com/bogus.htm", "0-123-45678-9", "http://www.noplace.com/bogus.jpg", "100", "6", "1/09/1998");
            lvwBooks.AddRow("Fakey", "http://www.skatepark.com/fakey.htm", "9-876-54321-0", "http://www.skatepark.com/fakey.jpg", "9", "700", "1/08/1998");

            // Size the columns.
            lvwBooks.SizeColumnsToFitDataAndHeaders();

            // Make the form big enough to show the ListView.
            Rectangle item_rect =
                lvwBooks.GetItemRect(lvwBooks.Columns.Count - 1);
            this.SetClientSizeCore(
                item_rect.Left + item_rect.Width + 50,
                item_rect.Top + item_rect.Height + 75);
        }

        // Sort on clicked columns.
        private void radSortClickedColumn_Click(object sender, EventArgs e)
        {
            lvwBooks.SetSortMode(ListViewExtensions.SortMode.SortOnClickedColumn);
        }

        // Sort on all columns.
        private void radSortAllColumns_Click(object sender, EventArgs e)
        {
            lvwBooks.SetSortMode(ListViewExtensions.SortMode.SortOnAllColumns);
        }

        // Do not sort.
        private void radNoSort_Click(object sender, EventArgs e)
        {
            lvwBooks.SetSortMode(ListViewExtensions.SortMode.SortNone);
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
            this.radNoSort = new System.Windows.Forms.RadioButton();
            this.radSortAllColumns = new System.Windows.Forms.RadioButton();
            this.radSortClickedColumn = new System.Windows.Forms.RadioButton();
            this.lvwBooks = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // radNoSort
            // 
            this.radNoSort.AutoSize = true;
            this.radNoSort.Location = new System.Drawing.Point(0, 0);
            this.radNoSort.Name = "radNoSort";
            this.radNoSort.Size = new System.Drawing.Size(59, 17);
            this.radNoSort.TabIndex = 4;
            this.radNoSort.TabStop = true;
            this.radNoSort.Text = "No sort";
            this.radNoSort.UseVisualStyleBackColor = true;
            this.radNoSort.Click += new System.EventHandler(this.radNoSort_Click);
            // 
            // radSortAllColumns
            // 
            this.radSortAllColumns.AutoSize = true;
            this.radSortAllColumns.Location = new System.Drawing.Point(65, 0);
            this.radSortAllColumns.Name = "radSortAllColumns";
            this.radSortAllColumns.Size = new System.Drawing.Size(114, 17);
            this.radSortAllColumns.TabIndex = 5;
            this.radSortAllColumns.TabStop = true;
            this.radSortAllColumns.Text = "Sort on all columns";
            this.radSortAllColumns.UseVisualStyleBackColor = true;
            this.radSortAllColumns.Click += new System.EventHandler(this.radSortAllColumns_Click);
            // 
            // radSortClickedColumn
            // 
            this.radSortClickedColumn.AutoSize = true;
            this.radSortClickedColumn.Location = new System.Drawing.Point(185, 0);
            this.radSortClickedColumn.Name = "radSortClickedColumn";
            this.radSortClickedColumn.Size = new System.Drawing.Size(138, 17);
            this.radSortClickedColumn.TabIndex = 6;
            this.radSortClickedColumn.TabStop = true;
            this.radSortClickedColumn.Text = "Sort on clicked columns";
            this.radSortClickedColumn.UseVisualStyleBackColor = true;
            this.radSortClickedColumn.Click += new System.EventHandler(this.radSortClickedColumn_Click);
            // 
            // lvwBooks
            // 
            this.lvwBooks.AllowColumnReorder = true;
            this.lvwBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwBooks.FullRowSelect = true;
            this.lvwBooks.Location = new System.Drawing.Point(0, 23);
            this.lvwBooks.Name = "lvwBooks";
            this.lvwBooks.Size = new System.Drawing.Size(577, 243);
            this.lvwBooks.TabIndex = 7;
            this.lvwBooks.UseCompatibleStateImageBehavior = false;
            this.lvwBooks.View = System.Windows.Forms.View.Details;
            // 
            // howto_listview_extensions_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 266);
            this.Controls.Add(this.radNoSort);
            this.Controls.Add(this.radSortAllColumns);
            this.Controls.Add(this.radSortClickedColumn);
            this.Controls.Add(this.lvwBooks);
            this.Name = "howto_listview_extensions_Form1";
            this.Text = "howto_listview_extensions";
            this.Load += new System.EventHandler(this.howto_listview_extensions_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radNoSort;
        private System.Windows.Forms.RadioButton radSortAllColumns;
        private System.Windows.Forms.RadioButton radSortClickedColumn;
        internal System.Windows.Forms.ListView lvwBooks;
    }
}

