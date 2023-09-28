#define Use_IndexOf
#define Use_HitTest

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_listview_which_row_column;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_listview_which_row_column_Form1:Form
  { 


        public howto_listview_which_row_column_Form1()
        {
            InitializeComponent();
        }

        private void howto_listview_which_row_column_Form1_Load(object sender, EventArgs e)
        {
            // Remove any existing items.
            lvwBooks.Items.Clear();

            // Add data rows.
            lvwBooks.AddRow(new string[] { "C# 5.0 Programmer's Reference", "http://www.wrox.com/WileyCDA/WroxTitle/C-5-0-Programmer-s-Reference.productCd-1118847288.html", "978-1-118-84728-2", "960", "2014" });
            lvwBooks.AddRow(new string[] { "MCSD Certification Toolkit (Exam 70-483): Programming in C#", "http://www.wrox.com/WileyCDA/WroxTitle/C-5-0-Programmer-s-Reference.productCd-1118847288.html", "978-1-118-61209-5", "648", "2013" });
            lvwBooks.AddRow(new string[] { "Visual Basic 2012 Programmer's Reference", "http://www.wrox.com/WileyCDA/WroxTitle/Visual-Basic-2012-Programmer-s-Reference.productCd-1118314077.html", "978-1-118-31407-4", "840", "2012" });
            lvwBooks.AddRow("Essential Algorithms: A Practical Approach to Computer Algorithms", "http://www.wiley.com/WileyCDA/WileyTitle/productCd-1118612108.html", "978-1-118-61210-1", "624", "2013");
            lvwBooks.AddRow("Beginning Database Design Solutions", "http://www.vb-helper.com/db_design.htm", "978-0-470-38549-4", "552", "2008");
            lvwBooks.AddRow("Start Here! Fundamentals of Microsoft .NET Programming", "http://www.amazon.com/Start-Here-Fundamentals-Microsoft-Programming/dp/0735661685", "978-0-735-66168-4", "264", "2011");

            // Make the ListView column headers.
            lvwBooks.MakeColumnHeaders(
                "Title", HorizontalAlignment.Left,
                "URL", HorizontalAlignment.Left,
                "ISBN", HorizontalAlignment.Left,
                "Pages", HorizontalAlignment.Right,
                "Year", HorizontalAlignment.Right
            );

            // Size the columns to fit the data and colummn headers.
            lvwBooks.SizeColumns(-2);

            // Make the form big enough to show the ListView.
            Rectangle item_rect =
                lvwBooks.GetItemRect(lvwBooks.Items.Count - 1);
            this.ClientSize = new Size(
                item_rect.Left + item_rect.Width + 25,
                item_rect.Top + item_rect.Height + 75);
        }

        // Display the row and column under the mouse.
        private void lvwBooks_MouseMove(object sender, MouseEventArgs e)
        {
            txtRow.Clear();
            txtColumn.Clear();

#if Use_IndexOf
            // Method 3: Use HitTest and IndexOf.
            ListViewHitTestInfo hti = lvwBooks.HitTest(e.Location);
            if (hti.Item == null) return;
            ListViewItem item = hti.Item;
            txtRow.Text = item.Index.ToString();

            // See which sub-item this is.
            txtColumn.Text = item.SubItems.IndexOf(hti.SubItem).ToString();
#elif Use_HitTest
            // Method 2: Use HitTest.
            ListViewHitTestInfo hti = lvwBooks.HitTest(e.Location);
            if (hti.Item == null) return;
            ListViewItem item = hti.Item;
            txtRow.Text = item.Index.ToString();

            // See which sub-item this is.
            ListViewItem.ListViewSubItem subitem = hti.SubItem;
            for (int i = 0; i < item.SubItems.Count; i++)
            {
                if (item.SubItems[i] == subitem)
                {
                    txtColumn.Text = i.ToString();
                }
            }
#else
            // Method 1: Use the FindListViewRowColumn method.
            int row, column;
            if (lvwBooks.FindListViewRowColumn(e.X, e.Y, out row, out column))
            {
                txtRow.Text = row.ToString();
                txtColumn.Text = column.ToString();
            }
#endif
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
            this.txtColumn = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtRow = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.lvwBooks = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // txtColumn
            // 
            this.txtColumn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtColumn.Location = new System.Drawing.Point(135, 243);
            this.txtColumn.Name = "txtColumn";
            this.txtColumn.Size = new System.Drawing.Size(32, 20);
            this.txtColumn.TabIndex = 14;
            this.txtColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label2
            // 
            this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(87, 246);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(45, 13);
            this.Label2.TabIndex = 13;
            this.Label2.Text = "Column:";
            // 
            // txtRow
            // 
            this.txtRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtRow.Location = new System.Drawing.Point(39, 243);
            this.txtRow.Name = "txtRow";
            this.txtRow.Size = new System.Drawing.Size(32, 20);
            this.txtRow.TabIndex = 12;
            this.txtRow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label1
            // 
            this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(7, 246);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(32, 13);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "Row:";
            // 
            // lvwBooks
            // 
            this.lvwBooks.AllowColumnReorder = true;
            this.lvwBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwBooks.Location = new System.Drawing.Point(-1, 3);
            this.lvwBooks.Name = "lvwBooks";
            this.lvwBooks.Size = new System.Drawing.Size(578, 232);
            this.lvwBooks.TabIndex = 10;
            this.lvwBooks.UseCompatibleStateImageBehavior = false;
            this.lvwBooks.View = System.Windows.Forms.View.Details;
            this.lvwBooks.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lvwBooks_MouseMove);
            // 
            // howto_listview_which_row_column_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 266);
            this.Controls.Add(this.txtColumn);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtRow);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lvwBooks);
            this.Name = "howto_listview_which_row_column_Form1";
            this.Text = "howto_listview_which_row_column";
            this.Load += new System.EventHandler(this.howto_listview_which_row_column_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtColumn;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtRow;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ListView lvwBooks;
    }
}

