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
     public partial class howto_listview_to_html_table_Form1:Form
  { 


        public howto_listview_to_html_table_Form1()
        {
            InitializeComponent();
        }

        private void howto_listview_to_html_table_Form1_Load(object sender, EventArgs e)
        {
            double float_value = -12345.6789;

            lvwResults.Items.Add(new ListViewItem(new String[] { "Currency", "C or c", float_value.ToString("C") }, lvwResults.Groups[0]));
            lvwResults.Items.Add(new ListViewItem(new String[] { "Exponential", "E or e", float_value.ToString("E") }, lvwResults.Groups[0]));
            lvwResults.Items.Add(new ListViewItem(new String[] { "Fixed Point", "F or f", float_value.ToString("F") }, lvwResults.Groups[0]));
            lvwResults.Items.Add(new ListViewItem(new String[] { "General", "G or g", float_value.ToString("G") }, lvwResults.Groups[0]));
            lvwResults.Items.Add(new ListViewItem(new String[] { "Number", "N or n", float_value.ToString("N") }, lvwResults.Groups[0]));
            lvwResults.Items.Add(new ListViewItem(new String[] { "Percent", "P or p", float_value.ToString("P") }, lvwResults.Groups[0]));
            lvwResults.Items.Add(new ListViewItem(new String[] { "Round-trip", "R or r", float_value.ToString("R") }, lvwResults.Groups[0]));

            int int_value = -123456789;
            lvwResults.Items.Add(new ListViewItem(new String[] { "Decimal", "D or d", int_value.ToString("D") }, lvwResults.Groups[1]));
            lvwResults.Items.Add(new ListViewItem(new String[] { "Hexadecimal", "H or h", int_value.ToString("X") }, lvwResults.Groups[1]));

            // Miscellaneous stuff.
            lvwResults.Items.Add(new ListViewItem(new String[] { "Apple", "Dog", "Book" } ));
            lvwResults.Items.Add(new ListViewItem(new String[] { "Penny", "Catabalpas", "Pickle" }));
        }

        // Display an HTML table showing the ListView's contents.
        private void btnGo_Click(object sender, EventArgs e)
        {
            wbrTable.DocumentText = ListViewToHtmlTable(lvwResults, 1, 1, 2);
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
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Floating Point Formats", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Integer Formats", System.Windows.Forms.HorizontalAlignment.Left);
            this.lvwResults = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.btnGo = new System.Windows.Forms.Button();
            this.wbrTable = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // lvwResults
            // 
            this.lvwResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lvwResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            listViewGroup3.Header = "Floating Point Formats";
            listViewGroup3.Name = "listViewGroup1";
            listViewGroup4.Header = "Integer Formats";
            listViewGroup4.Name = "listViewGroup2";
            this.lvwResults.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3,
            listViewGroup4});
            this.lvwResults.Location = new System.Drawing.Point(0, 0);
            this.lvwResults.Name = "lvwResults";
            this.lvwResults.Size = new System.Drawing.Size(292, 450);
            this.lvwResults.TabIndex = 2;
            this.lvwResults.UseCompatibleStateImageBehavior = false;
            this.lvwResults.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 103;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Format";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 67;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Result";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 113;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnGo.Location = new System.Drawing.Point(298, 214);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(27, 23);
            this.btnGo.TabIndex = 3;
            this.btnGo.Text = ">";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // wbrTable
            // 
            this.wbrTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wbrTable.Location = new System.Drawing.Point(331, 0);
            this.wbrTable.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbrTable.Name = "wbrTable";
            this.wbrTable.Size = new System.Drawing.Size(365, 450);
            this.wbrTable.TabIndex = 4;
            // 
            // howto_listview_to_html_table_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 450);
            this.Controls.Add(this.wbrTable);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.lvwResults);
            this.Name = "howto_listview_to_html_table_Form1";
            this.Text = "howto_listview_to_html_table";
            this.Load += new System.EventHandler(this.howto_listview_to_html_table_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwResults;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.WebBrowser wbrTable;
    }
}

