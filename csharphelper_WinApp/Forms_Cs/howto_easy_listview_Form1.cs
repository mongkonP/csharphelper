using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_easy_listview;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_easy_listview_Form1:Form
  { 


        public howto_easy_listview_Form1()
        {
            InitializeComponent();
        }

        private void howto_easy_listview_Form1_Load(object sender, EventArgs e)
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
                item_rect.Top + item_rect.Height + 25);
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
            this.lvwBooks.AllowColumnReorder = true;
            this.lvwBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwBooks.FullRowSelect = true;
            this.lvwBooks.Location = new System.Drawing.Point(0, 0);
            this.lvwBooks.Name = "lvwBooks";
            this.lvwBooks.Size = new System.Drawing.Size(285, 41);
            this.lvwBooks.TabIndex = 7;
            this.lvwBooks.UseCompatibleStateImageBehavior = false;
            this.lvwBooks.View = System.Windows.Forms.View.Details;
            // 
            // howto_easy_listview_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 41);
            this.Controls.Add(this.lvwBooks);
            this.Name = "howto_easy_listview_Form1";
            this.Text = "howto_easy_listview";
            this.Load += new System.EventHandler(this.howto_easy_listview_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListView lvwBooks;
    }
}

