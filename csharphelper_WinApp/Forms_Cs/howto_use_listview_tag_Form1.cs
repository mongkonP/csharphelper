using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_use_listview_tag_Form1:Form
  { 


        public howto_use_listview_tag_Form1()
        {
            InitializeComponent();
        }

        private void howto_use_listview_tag_Form1_Load(object sender, EventArgs e)
        {
            // Select whole rows.
            lvwBooks.FullRowSelect = true;

            // Add some groups to the ListView.
            ListViewGroup csharp_group = new ListViewGroup("C# Books");
            ListViewGroup vb_group = new ListViewGroup("Visual Basic Books");
            lvwBooks.Groups.Add(csharp_group);
            lvwBooks.Groups.Add(vb_group);

            // C# Books.
            ListViewItem new_item;
            new_item = lvwBooks.Items.Add(new ListViewItem(new string[]
                {   "C# 5.0 Programmer's Reference",
                    "http://www.wrox.com/WileyCDA/WroxTitle/C-5-0-Programmer-s-Reference.productCd-1118847288.html", 
                    "960", "2014"},
                csharp_group));
            new_item.Tag = "1118847288";
            new_item = lvwBooks.Items.Add(new ListViewItem(new string[]
                {   "MCSD Certification Toolkit (Exam 70-483): Programming in C#",
                    "http://www.wrox.com/WileyCDA/WroxTitle/C-5-0-Programmer-s-Reference.productCd-1118847288.html", 
                    "648", "2013"},
                csharp_group));
            new_item.Tag = "1118612094";

            // Visual Basic.
            new_item = lvwBooks.Items.Add(new ListViewItem(new string[]
                {   "Visual Basic 2012 Programmer's Reference",
                    "http://www.wrox.com/WileyCDA/WroxTitle/Visual-Basic-2012-Programmer-s-Reference.productCd-1118314077.html", 
                    "840", "2012"},
                vb_group));
            new_item.Tag = "1118314077";

            // Misc.
            new_item = lvwBooks.Items.Add(new ListViewItem(new string[]
                {   "Essential Algorithms: A Practical Approach to Computer Algorithms ",
                    "http://www.wiley.com/WileyCDA/WileyTitle/productCd-1118612108.html", 
                    "624", "2013"}));
            new_item.Tag = "1118612108";
            new_item = lvwBooks.Items.Add(new ListViewItem(new string[]
                {   "Beginning Database Design Solutions",
                    "http://www.vb-helper.com/db_design.htm", 
                    "552", "2008"},
                csharp_group));
            new_item.Tag = "0470385499";
            new_item = lvwBooks.Items.Add(new ListViewItem(new string[]
                {   "Start Here! Fundamentals of Microsoft .NET Programming", 
                    "http://www.amazon.com/Start-Here-Fundamentals-Microsoft-Programming/dp/0735661685", 
                    "264", "2011"}));
            new_item.Tag = "0735661685";
        }

        private void mnuViewDetail_Click(object sender, EventArgs e)
        {
            lvwBooks.View = View.Details;
            CheckMenuItem(mnuView, mnuViewDetail);
        }
        private void mnuViewLargeIcon_Click(object sender, EventArgs e)
        {
            lvwBooks.View = View.LargeIcon;
            CheckMenuItem(mnuView, mnuViewLargeIcon);
        }
        private void mnuViewList_Click(object sender, EventArgs e)
        {
            lvwBooks.View = View.List;
            CheckMenuItem(mnuView, mnuViewList);
        }
        private void mnuViewSmallIcon_Click(object sender, EventArgs e)
        {
            lvwBooks.View = View.SmallIcon;
            CheckMenuItem(mnuView, mnuViewSmallIcon);
        }
        private void mnuViewTile_Click(object sender, EventArgs e)
        {
            lvwBooks.View = View.Tile;
            CheckMenuItem(mnuView, mnuViewTile);
        }

        // Uncheck all menu items in this menu except checked_item.
        private void CheckMenuItem(ToolStripMenuItem mnu, ToolStripMenuItem checked_item)
        {
            // Uncheck all of the menu items.
            foreach (ToolStripItem item in mnu.DropDownItems)
            {
                if (item is ToolStripMenuItem)
                {
                    ToolStripMenuItem menu_item = item as ToolStripMenuItem;
                    menu_item.Checked = false;
                }
            }

            // Check the one that should be checked.
            checked_item.Checked = true;
        }

        // Open the Amazon page for the selected book.
        private void lvwBooks_DoubleClick(object sender, EventArgs e)
        {
            if (lvwBooks.SelectedItems.Count < 1) return;

            // Get the selected item.
            ListViewItem selected_item =
                lvwBooks.SelectedItems[0];

            // Use the Tag value to build the URL.
            string url = "http://www.amazon.com/gp/product/@ISBN@";
            url = url.Replace("@ISBN@", (string)selected_item.Tag);

            // Open the URL.
            Process.Start(url);
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
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewLargeIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewSmallIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewTile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwBooks
            // 
            this.lvwBooks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5});
            this.lvwBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwBooks.Location = new System.Drawing.Point(0, 24);
            this.lvwBooks.Name = "lvwBooks";
            this.lvwBooks.Size = new System.Drawing.Size(580, 225);
            this.lvwBooks.TabIndex = 2;
            this.lvwBooks.UseCompatibleStateImageBehavior = false;
            this.lvwBooks.View = System.Windows.Forms.View.Details;
            this.lvwBooks.DoubleClick += new System.EventHandler(this.lvwBooks_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Title";
            this.columnHeader1.Width = 220;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "URL";
            this.columnHeader2.Width = 250;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Pages";
            this.columnHeader4.Width = 50;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Year";
            this.columnHeader5.Width = 50;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuView});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(580, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuView
            // 
            this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewDetail,
            this.mnuViewLargeIcon,
            this.mnuViewList,
            this.mnuViewSmallIcon,
            this.mnuViewTile});
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(44, 20);
            this.mnuView.Text = "&View";
            // 
            // mnuViewDetail
            // 
            this.mnuViewDetail.Checked = true;
            this.mnuViewDetail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuViewDetail.Name = "mnuViewDetail";
            this.mnuViewDetail.Size = new System.Drawing.Size(152, 22);
            this.mnuViewDetail.Text = "&Detail";
            this.mnuViewDetail.Click += new System.EventHandler(this.mnuViewDetail_Click);
            // 
            // mnuViewLargeIcon
            // 
            this.mnuViewLargeIcon.Name = "mnuViewLargeIcon";
            this.mnuViewLargeIcon.Size = new System.Drawing.Size(152, 22);
            this.mnuViewLargeIcon.Text = "&Large Icon";
            this.mnuViewLargeIcon.Click += new System.EventHandler(this.mnuViewLargeIcon_Click);
            // 
            // mnuViewList
            // 
            this.mnuViewList.Name = "mnuViewList";
            this.mnuViewList.Size = new System.Drawing.Size(152, 22);
            this.mnuViewList.Text = "&List";
            this.mnuViewList.Click += new System.EventHandler(this.mnuViewList_Click);
            // 
            // mnuViewSmallIcon
            // 
            this.mnuViewSmallIcon.Name = "mnuViewSmallIcon";
            this.mnuViewSmallIcon.Size = new System.Drawing.Size(152, 22);
            this.mnuViewSmallIcon.Text = "&Small Icon";
            this.mnuViewSmallIcon.Click += new System.EventHandler(this.mnuViewSmallIcon_Click);
            // 
            // mnuViewTile
            // 
            this.mnuViewTile.Name = "mnuViewTile";
            this.mnuViewTile.Size = new System.Drawing.Size(152, 22);
            this.mnuViewTile.Text = "&Tile";
            this.mnuViewTile.Click += new System.EventHandler(this.mnuViewTile_Click);
            // 
            // howto_use_listview_tag_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 249);
            this.Controls.Add(this.lvwBooks);
            this.Controls.Add(this.menuStrip1);
            this.Name = "howto_use_listview_tag_Form1";
            this.Text = "howto_use_listview_tag";
            this.Load += new System.EventHandler(this.howto_use_listview_tag_Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwBooks;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuViewDetail;
        private System.Windows.Forms.ToolStripMenuItem mnuViewLargeIcon;
        private System.Windows.Forms.ToolStripMenuItem mnuViewList;
        private System.Windows.Forms.ToolStripMenuItem mnuViewSmallIcon;
        private System.Windows.Forms.ToolStripMenuItem mnuViewTile;
    }
}

