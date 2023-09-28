using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_sort_all_listview_columns;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_sort_all_listview_columns_Form1:Form
  { 


        public howto_sort_all_listview_columns_Form1()
        {
            InitializeComponent();
        }

        // Make some data.
        private void howto_sort_all_listview_columns_Form1_Load(object sender, EventArgs e)
        {
            // Remove any existing items.
            lvwBooks.Items.Clear();

            // Add data rows.
            ListViewMakeRow(lvwBooks, "B", new string[] { "B", "B", "1000" });
            ListViewMakeRow(lvwBooks, "B", new string[] { "B", "B", "1000", "4/1/2014", "F" });
            ListViewMakeRow(lvwBooks, "A", new string[] { "A", "C" });
            ListViewMakeRow(lvwBooks, "C", new string[] { "B", "C", "1000", "4/1/2014" });
            ListViewMakeRow(lvwBooks, "A", new string[] { "B", "C", "1000", "4/1/2014", "F" });
            ListViewMakeRow(lvwBooks, "A", new string[] { "A", "A", "9", "12/20/2013", "C" });
            ListViewMakeRow(lvwBooks, "B", new string[] { "B" });
            ListViewMakeRow(lvwBooks, "C", new string[] { "C", "C", "1000", "4/1/2014", "F" });
            ListViewMakeRow(lvwBooks, "A", new string[] { "A", "A" });
            ListViewMakeRow(lvwBooks, "B", new string[] { "B", "B", "20" });
            ListViewMakeRow(lvwBooks, "A", new string[] { "A", "A", "9", "12/20/2013", "A" });
            ListViewMakeRow(lvwBooks, "C", new string[] { "C", "C", "1001", "8/20/2014" });
            ListViewMakeRow(lvwBooks, "A", new string[] { "A", "A", "9", "4/1/2014" });
            ListViewMakeRow(lvwBooks, "C", new string[] { "C", "C", "100", "1/2/2014", "F" });
            ListViewMakeRow(lvwBooks, "A", new string[] { "A", "A", "10" });

            // Make the ListView column headers.
            ListViewMakeColumnHeaders(lvwBooks,
                new object[] {
                    "1", HorizontalAlignment.Left,
                    "2", HorizontalAlignment.Left,
                    "3", HorizontalAlignment.Left,
                    "4", HorizontalAlignment.Right,
                    "5", HorizontalAlignment.Right,
                    "6", HorizontalAlignment.Left
                });

            // Size the columns.
            foreach (ColumnHeader col in lvwBooks.Columns)
            {
                col.Width = -2;
            }

            // Make the form big enough to show the ListView.
            Rectangle item_rect = lvwBooks.GetItemRect(lvwBooks.Columns.Count - 1);
            Size new_size = new Size(item_rect.Left + item_rect.Width + 50, this.ClientSize.Height);
            this.ClientSize = new_size;
        }

        // Make a ListView row.
        private void ListViewMakeRow(ListView lvw, String item_title, string[] subitem_titles)
        {
            // Make the item.
            ListViewItem new_item = lvw.Items.Add(item_title);

            // Make the sub-items.
            for (int i = subitem_titles.GetLowerBound(0); i <= subitem_titles.GetUpperBound(0); i++)
            {
                new_item.SubItems.Add(subitem_titles[i]);
            }
        }

        // Make the ListView's column headers.
        // The ParamArray entries should alternate between
        // strings and HorizontalAlignment values.
        private void ListViewMakeColumnHeaders(ListView lvw, Object[] header_info)
        {
            // Remove any existing headers.
            lvw.Columns.Clear();

            // Make the column headers.
            for (int i = header_info.GetLowerBound(0); i <= header_info.GetUpperBound(0); i += 2)
            {
                lvw.Columns.Add(
                    (string)header_info[i],
                    -1,
                    (HorizontalAlignment)header_info[i + 1]);
            }
        }

        // Sort ascending.
        private void radAscending_Click(object sender, EventArgs e)
        {
            // Create a comparer.
            lvwBooks.ListViewItemSorter = new ListViewAllColumnComparer(SortOrder.Ascending);

            // Sort.
            lvwBooks.Sort();
        }

        // Sort descending.
        private void radDescending_Click(object sender, EventArgs e)
        {
            // Create a comparer.
            lvwBooks.ListViewItemSorter = new ListViewAllColumnComparer(SortOrder.Descending);

            // Sort.
            lvwBooks.Sort();
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
            this.radDescending = new System.Windows.Forms.RadioButton();
            this.radAscending = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lvwBooks
            // 
            this.lvwBooks.AllowColumnReorder = true;
            this.lvwBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwBooks.FullRowSelect = true;
            this.lvwBooks.LabelEdit = true;
            this.lvwBooks.Location = new System.Drawing.Point(0, 35);
            this.lvwBooks.Name = "lvwBooks";
            this.lvwBooks.Size = new System.Drawing.Size(297, 311);
            this.lvwBooks.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwBooks.TabIndex = 2;
            this.lvwBooks.UseCompatibleStateImageBehavior = false;
            this.lvwBooks.View = System.Windows.Forms.View.Details;
            // 
            // radDescending
            // 
            this.radDescending.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radDescending.AutoSize = true;
            this.radDescending.Location = new System.Drawing.Point(176, 12);
            this.radDescending.Name = "radDescending";
            this.radDescending.Size = new System.Drawing.Size(82, 17);
            this.radDescending.TabIndex = 1;
            this.radDescending.TabStop = true;
            this.radDescending.Text = "Descending";
            this.radDescending.UseVisualStyleBackColor = true;
            this.radDescending.Click += new System.EventHandler(this.radDescending_Click);
            // 
            // radAscending
            // 
            this.radAscending.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radAscending.AutoSize = true;
            this.radAscending.Location = new System.Drawing.Point(38, 12);
            this.radAscending.Name = "radAscending";
            this.radAscending.Size = new System.Drawing.Size(75, 17);
            this.radAscending.TabIndex = 0;
            this.radAscending.TabStop = true;
            this.radAscending.Text = "Ascending";
            this.radAscending.UseVisualStyleBackColor = true;
            this.radAscending.Click += new System.EventHandler(this.radAscending_Click);
            // 
            // howto_sort_all_listview_columns_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 346);
            this.Controls.Add(this.radAscending);
            this.Controls.Add(this.radDescending);
            this.Controls.Add(this.lvwBooks);
            this.Name = "howto_sort_all_listview_columns_Form1";
            this.Text = "howto_sort_all_listview_columns";
            this.Load += new System.EventHandler(this.howto_sort_all_listview_columns_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ListView lvwBooks;
        private System.Windows.Forms.RadioButton radDescending;
        private System.Windows.Forms.RadioButton radAscending;
    }
}

