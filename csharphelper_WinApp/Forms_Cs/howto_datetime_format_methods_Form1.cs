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
     public partial class howto_datetime_format_methods_Form1:Form
  { 


        public howto_datetime_format_methods_Form1()
        {
            InitializeComponent();
        }

        private void howto_datetime_format_methods_Form1_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            lvwResults.Items.Add(new ListViewItem(new String[] { "ToLongDateString", "D", now.ToLongDateString() }));
            lvwResults.Items.Add(new ListViewItem(new String[] { "ToLongTimeString", "T", now.ToLongTimeString() }));
            lvwResults.Items.Add(new ListViewItem(new String[] { "ToShortDateString", "d", now.ToShortDateString() }));
            lvwResults.Items.Add(new ListViewItem(new String[] { "ToShortTimeString", "t", now.ToShortTimeString() }));
            lvwResults.Items.Add(new ListViewItem(new String[] { "ToString", "G", now.ToString() }));

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
            this.lvwResults.Location = new System.Drawing.Point(0, 0);
            this.lvwResults.Name = "lvwResults";
            this.lvwResults.Size = new System.Drawing.Size(359, 140);
            this.lvwResults.TabIndex = 3;
            this.lvwResults.UseCompatibleStateImageBehavior = false;
            this.lvwResults.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Method";
            this.columnHeader1.Width = 110;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Equivalent";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Result";
            this.columnHeader3.Width = 160;
            // 
            // howto_datetime_format_methods_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 140);
            this.Controls.Add(this.lvwResults);
            this.Name = "howto_datetime_format_methods_Form1";
            this.Text = "howto_datetime_format_methods";
            this.Load += new System.EventHandler(this.howto_datetime_format_methods_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwResults;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

