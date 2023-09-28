using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_listview_display_subitem_icons;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_listview_display_subitem_icons_Form1:Form
  { 


        public howto_listview_display_subitem_icons_Form1()
        {
            InitializeComponent();
        }

        private void howto_listview_display_subitem_icons_Form1_Load(object sender, EventArgs e)
        {
            // Start with the last View (Details) selected.
            cboView.SelectedIndex = cboView.Items.Count - 1;

            // Make the column headers.
            lvwBooks.MakeColumnHeaders(
                "Title", 230, HorizontalAlignment.Left,
                "URL", 220, HorizontalAlignment.Left,
                "ISBN", 130, HorizontalAlignment.Left,
                "Picture", 230, HorizontalAlignment.Left,
                "Pages", 70, HorizontalAlignment.Right,
                "Year", 80, HorizontalAlignment.Right);

            // Add data rows.
            lvwBooks.AddRow("WPF 3d", "http://www.csharphelper.com/wpf3d.html", "978-1983905964", "http://www.csharphelper.com/wpf3d_350_429.jpg", "430", "2018");
            lvwBooks.AddRow("The C# Helper Top 100", "http://www.csharphelper.com/top100.htm", "978-1546886716", "http://www.csharphelper.com/top100_350_433.jpg", "380", "2017");
            lvwBooks.AddRow("Interview Puzzles Dissected", "http://www.csharphelper.com/puzzles.htm", "978-1539504887", "http://www.csharphelper.com/interview_puzzles_350_433.jpg", "300", "2016");
            lvwBooks.AddRow("C# 24-Hour Trainer, 2e", "http://tinyurl.com/n2a5797", "978-1-119-06566-1", "http://www.csharphelper.com/csharp24hr_2e_79x100.jpg", "600", "2015");
            lvwBooks.AddRow("Beginning Software Engineering", "http://tinyurl.com/pz7bavo", "978-1-118-96914-4", "http://tinyurl.com/y7zusrct", "480", "2015");
            lvwBooks.AddRow("Essential Algorithms", "http://tinyurl.com/y9uqajqv", "978-1-118-61210-1", "http://tinyurl.com/y84d2jgp", "624", "2013");
            lvwBooks.AddRow("Beginning Database Design Solutions", "http://www.vb-helper.com/db_design.htm", "978-0-470-38549-4", "http://www.vb-helper.com/db_design.jpg", "522", "2008");

            // Add icons to the sub-items.
            for (int r = 0; r < lvwBooks.Items.Count; r++)
            {
                // Set the main item's image index.
                lvwBooks.Items[r].ImageIndex = r;

                // Set the sub-item indices.
                for (int c = 1; c < lvwBooks.Columns.Count; c++)
                {
                    lvwBooks.AddIconToSubitem(r, c, 6 + c);
                }
            }

            // Initially display the sub-item icons if
            // the check box is checked.
            lvwBooks.ShowSubItemIcons(chkSubitemIcons.Checked);
        }

        // Toggle grid lines.
        private void chkGridLines_CheckedChanged(object sender, EventArgs e)
        {
            lvwBooks.GridLines = chkGridLines.Checked;
        }

        // Toggle sub-item icons.
        private void chkSubitemIcons_CheckedChanged(object sender, EventArgs e)
        {
            lvwBooks.ShowSubItemIcons(chkSubitemIcons.Checked);
        }

        // Change the ListView's view.
        private void cboView_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboView.Text)
            {
                case "Large Icons":
                    lvwBooks.View = View.LargeIcon;
                    break;
                case "Small Icons":
                    lvwBooks.View = View.SmallIcon;
                    break;
                case "List":
                    lvwBooks.View = View.List;
                    break;
                case "Tile":
                    lvwBooks.View = View.Tile;
                    break;
                case "Details":
                    lvwBooks.View = View.Details;
                    break;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_listview_display_subitem_icons_Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.cboView = new System.Windows.Forms.ComboBox();
            this.chkSubitemIcons = new System.Windows.Forms.CheckBox();
            this.chkGridLines = new System.Windows.Forms.CheckBox();
            this.imlLargeIcons = new System.Windows.Forms.ImageList(this.components);
            this.imlSmallIcons = new System.Windows.Forms.ImageList(this.components);
            this.lvwBooks = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "View:";
            // 
            // cboView
            // 
            this.cboView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboView.FormattingEnabled = true;
            this.cboView.Items.AddRange(new object[] {
            "Large Icons",
            "Small Icons",
            "List",
            "Tile",
            "Details"});
            this.cboView.Location = new System.Drawing.Point(51, 12);
            this.cboView.Name = "cboView";
            this.cboView.Size = new System.Drawing.Size(121, 21);
            this.cboView.TabIndex = 5;
            this.cboView.SelectedIndexChanged += new System.EventHandler(this.cboView_SelectedIndexChanged);
            // 
            // chkSubitemIcons
            // 
            this.chkSubitemIcons.AutoSize = true;
            this.chkSubitemIcons.Checked = true;
            this.chkSubitemIcons.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSubitemIcons.Location = new System.Drawing.Point(307, 14);
            this.chkSubitemIcons.Name = "chkSubitemIcons";
            this.chkSubitemIcons.Size = new System.Drawing.Size(96, 17);
            this.chkSubitemIcons.TabIndex = 7;
            this.chkSubitemIcons.Text = "Sub-item Icons";
            this.chkSubitemIcons.UseVisualStyleBackColor = true;
            this.chkSubitemIcons.CheckedChanged += new System.EventHandler(this.chkSubitemIcons_CheckedChanged);
            // 
            // chkGridLines
            // 
            this.chkGridLines.AutoSize = true;
            this.chkGridLines.Location = new System.Drawing.Point(211, 14);
            this.chkGridLines.Name = "chkGridLines";
            this.chkGridLines.Size = new System.Drawing.Size(73, 17);
            this.chkGridLines.TabIndex = 6;
            this.chkGridLines.Text = "Grid Lines";
            this.chkGridLines.UseVisualStyleBackColor = true;
            this.chkGridLines.CheckedChanged += new System.EventHandler(this.chkGridLines_CheckedChanged);
            // 
            // imlLargeIcons
            // 
            this.imlLargeIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlLargeIcons.ImageStream")));
            this.imlLargeIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imlLargeIcons.Images.SetKeyName(0, "1_64x64.png");
            this.imlLargeIcons.Images.SetKeyName(1, "2_64x64.png");
            this.imlLargeIcons.Images.SetKeyName(2, "3_64x64.png");
            this.imlLargeIcons.Images.SetKeyName(3, "4_64x64.png");
            this.imlLargeIcons.Images.SetKeyName(4, "5_64x64.png");
            this.imlLargeIcons.Images.SetKeyName(5, "6_64x64.png");
            this.imlLargeIcons.Images.SetKeyName(6, "7_64x64.png");
            // 
            // imlSmallIcons
            // 
            this.imlSmallIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlSmallIcons.ImageStream")));
            this.imlSmallIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imlSmallIcons.Images.SetKeyName(0, "1_32x32.png");
            this.imlSmallIcons.Images.SetKeyName(1, "2_32x32.png");
            this.imlSmallIcons.Images.SetKeyName(2, "3_32x32.png");
            this.imlSmallIcons.Images.SetKeyName(3, "4_32x32.png");
            this.imlSmallIcons.Images.SetKeyName(4, "5_32x32.png");
            this.imlSmallIcons.Images.SetKeyName(5, "6_32x32.png");
            this.imlSmallIcons.Images.SetKeyName(6, "7_32x32.png");
            this.imlSmallIcons.Images.SetKeyName(7, "URL.png");
            this.imlSmallIcons.Images.SetKeyName(8, "#.png");
            this.imlSmallIcons.Images.SetKeyName(9, "pic.png");
            this.imlSmallIcons.Images.SetKeyName(10, "pgs.png");
            this.imlSmallIcons.Images.SetKeyName(11, "Yr.png");
            // 
            // lvwBooks
            // 
            this.lvwBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwBooks.LargeImageList = this.imlLargeIcons;
            this.lvwBooks.Location = new System.Drawing.Point(12, 39);
            this.lvwBooks.Name = "lvwBooks";
            this.lvwBooks.Size = new System.Drawing.Size(460, 210);
            this.lvwBooks.SmallImageList = this.imlSmallIcons;
            this.lvwBooks.TabIndex = 8;
            this.lvwBooks.UseCompatibleStateImageBehavior = false;
            // 
            // howto_listview_display_subitem_icons_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboView);
            this.Controls.Add(this.chkSubitemIcons);
            this.Controls.Add(this.chkGridLines);
            this.Controls.Add(this.lvwBooks);
            this.Name = "howto_listview_display_subitem_icons_Form1";
            this.Text = "howto_listview_display_subitem_icons";
            this.Load += new System.EventHandler(this.howto_listview_display_subitem_icons_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboView;
        private System.Windows.Forms.CheckBox chkSubitemIcons;
        private System.Windows.Forms.CheckBox chkGridLines;
        internal System.Windows.Forms.ImageList imlLargeIcons;
        internal System.Windows.Forms.ImageList imlSmallIcons;
        private System.Windows.Forms.ListView lvwBooks;
    }
}

