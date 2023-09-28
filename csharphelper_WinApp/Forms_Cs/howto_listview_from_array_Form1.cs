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
     public partial class howto_listview_from_array_Form1:Form
  { 


        public howto_listview_from_array_Form1()
        {
            InitializeComponent();
        }

        private void howto_listview_from_array_Form1_Load(object sender, EventArgs e)
        {
            // Create some data.
            // Name, URL, ISBN, pages, year.
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
            lvwBooks.Columns.Add("Pages", 50, HorizontalAlignment.Right);
            lvwBooks.Columns.Add("Year", 50, HorizontalAlignment.Right);

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
            this.SuspendLayout();
            // 
            // lvwBooks
            // 
            this.lvwBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwBooks.Location = new System.Drawing.Point(0, 0);
            this.lvwBooks.Name = "lvwBooks";
            this.lvwBooks.Size = new System.Drawing.Size(773, 167);
            this.lvwBooks.TabIndex = 0;
            this.lvwBooks.UseCompatibleStateImageBehavior = false;
            // 
            // howto_listview_from_array_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 167);
            this.Controls.Add(this.lvwBooks);
            this.Name = "howto_listview_from_array_Form1";
            this.Text = "howto_listview_from_array";
            this.Load += new System.EventHandler(this.howto_listview_from_array_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwBooks;
    }
}

