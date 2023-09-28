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
     public partial class howto_standard_date_formats_Form1:Form
  { 


        public howto_standard_date_formats_Form1()
        {
            InitializeComponent();
        }

        private void howto_standard_date_formats_Form1_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            lvwResults.Items.Add(new ListViewItem(new String[] { "Short date", "d", now.ToString("d") }, lvwResults.Groups[0]));
            lvwResults.Items.Add(new ListViewItem(new String[] { "Long date", "D", now.ToString("D") }, lvwResults.Groups[0]));
            lvwResults.Items.Add(new ListViewItem(new String[] { "Month/day", "M or m", now.ToString("m") }, lvwResults.Groups[0]));
            lvwResults.Items.Add(new ListViewItem(new String[] { "Year/month", "Y or y", now.ToString("y") }, lvwResults.Groups[0]));

            lvwResults.Items.Add(new ListViewItem(new String[] { "Short time", "t", now.ToString("t") }, lvwResults.Groups[1]));
            lvwResults.Items.Add(new ListViewItem(new String[] { "Long time", "T", now.ToString("T") }, lvwResults.Groups[1]));

            lvwResults.Items.Add(new ListViewItem(new String[] { "Full date/time (short time)", "f", now.ToString("f") }, lvwResults.Groups[2]));
            lvwResults.Items.Add(new ListViewItem(new String[] { "Full date/time (long time)", "F", now.ToString("F") }, lvwResults.Groups[2]));
            lvwResults.Items.Add(new ListViewItem(new String[] { "General date/time (short time)", "g", now.ToString("g") }, lvwResults.Groups[2]));
            lvwResults.Items.Add(new ListViewItem(new String[] { "General date/time (long time)", "G", now.ToString("G") }, lvwResults.Groups[2]));
            lvwResults.Items.Add(new ListViewItem(new String[] { "Round-trip date/time", "O or o", now.ToString("o") }, lvwResults.Groups[2]));
            lvwResults.Items.Add(new ListViewItem(new String[] { "RFC1123", "R or r", now.ToString("r") }, lvwResults.Groups[2]));
            lvwResults.Items.Add(new ListViewItem(new String[] { "Sortable date/time", "s", now.ToString("s") }, lvwResults.Groups[2]));
            lvwResults.Items.Add(new ListViewItem(new String[] { "Universal sortable date/time", "u", now.ToString("s") }, lvwResults.Groups[2]));
            lvwResults.Items.Add(new ListViewItem(new String[] { "Universal full date/time", "U", now.ToString("u") }, lvwResults.Groups[2]));

            // Generate code for an HTML table.
            Console.WriteLine(ListViewToHtmlTable(lvwResults, 1, 0, 5));
        }

        // Return an HTML table showing the ListView's contents.
        private string ListViewToHtmlTable(ListView lvw, int border, int cell_spacing, int cell_padding)
        {
            // Open the <table> element.
            string txt = "<table " +
                "border=\"" + border.ToString() + "\" " +
                "cellspacing=\"" + cell_spacing.ToString() + "\" " +
                "cellpadding=\"" + cell_padding.ToString() + "\">\n";

            // See how many columns there are.
            int num_cols = lvw.Columns.Count;

            // See if there are any non-grouped items.
            bool have_non_grouped_items = false;
            foreach (ListViewItem item in lvw.Items)
            {
                if (item.Group == null)
                {
                    have_non_grouped_items = true;
                    break;
                }
            }

            // Display non-grouped items.
            if (have_non_grouped_items)
            {
                // Display the column headers.
                txt += ListViewColumnHeaderHtml(lvw);

                // Display the non-grouped items.
                foreach (ListViewItem item in lvw.Items)
                {
                    if (item.Group == null)
                    {
                        // Display this item.
                        txt += ListViewItemHtml(item);
                    }
                }
            }

            // Process the groups.
            foreach (ListViewGroup grp in lvw.Groups)
            {
                // Display the header.
                txt += "  <tr><th " +
                    "colspan=\"" + num_cols + "\" " +
                    "align=\"" + grp.HeaderAlignment.ToString() + "\" " +
                    "bgcolor=\"LightBlue\">" +
                    grp.Header + "</th></tr>\n";

                // Display the column headers.
                txt += ListViewColumnHeaderHtml(lvw);

                // Display the items in the group.
                foreach (ListViewItem item in grp.Items)
                {
                    txt += ListViewItemHtml(item);
                }
            }
            txt += "</table>\n";
            return txt;
        }

        // Return a string representing ListView column headers.
        private string ListViewColumnHeaderHtml(ListView lvw)
        {
            // Display the column headers.
            string txt = "  <tr>";
            foreach (ColumnHeader col in lvw.Columns)
            {
                // Display this column header.
                txt += "<th bgcolor=\"#CCFFFF\"" +
                    "width=\"" + col.Width.ToString() + "\" " +
                    "align=\"" + col.TextAlign.ToString() + "\">" +
                    col.Text + "</th>";
            }
            txt += "</tr>\n";
            return txt;
        }

        // Return the HTML text representing this item's row.
        private string ListViewItemHtml(ListViewItem item)
        {
            string txt = "  <tr>";
            ListView lvw = item.ListView;
            for (int i = 0; i < item.SubItems.Count; i++)
            {
                txt += "<td " +
                    "align=\"" + lvw.Columns[i].TextAlign.ToString() + "\">" +
                    item.SubItems[i].Text + "</td>";
            }
            txt += "</tr>\n";
            return txt;
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Date Formats", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Time Formats", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Date/Time Formats", System.Windows.Forms.HorizontalAlignment.Left);
            this.lvwResults = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lvwResults
            // 
            this.lvwResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwResults.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup1.Header = "Date Formats";
            listViewGroup1.Name = "listViewGroup1";
            listViewGroup2.Header = "Time Formats";
            listViewGroup2.Name = "listViewGroup2";
            listViewGroup3.Header = "Date/Time Formats";
            listViewGroup3.Name = "listViewGroup3";
            this.lvwResults.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.lvwResults.Location = new System.Drawing.Point(0, 0);
            this.lvwResults.Name = "lvwResults";
            this.lvwResults.Size = new System.Drawing.Size(467, 389);
            this.lvwResults.TabIndex = 2;
            this.lvwResults.UseCompatibleStateImageBehavior = false;
            this.lvwResults.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 176;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Format";
            this.columnHeader2.Width = 67;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Result";
            this.columnHeader3.Width = 215;
            // 
            // howto_standard_date_formats_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 389);
            this.Controls.Add(this.lvwResults);
            this.Name = "howto_standard_date_formats_Form1";
            this.Text = "howto_standard_date_formats";
            this.Load += new System.EventHandler(this.howto_standard_date_formats_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwResults;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

