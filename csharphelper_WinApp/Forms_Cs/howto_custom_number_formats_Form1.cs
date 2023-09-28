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
     public partial class howto_custom_number_formats_Form1:Form
  { 


        public howto_custom_number_formats_Form1()
        {
            InitializeComponent();
        }

        private void howto_custom_number_formats_Form1_Load(object sender, EventArgs e)
        {
            lvwResults.Items.Add(new ListViewItem(new String[] { "Zero placeholder", "0", "A digit or 0 if no digit is present" }));
            lvwResults.Items.Add(new ListViewItem(new String[] { "Digit placeholder", "#", "A digit or nothing if no digit is present" }));
            lvwResults.Items.Add(new ListViewItem(new String[] { "Decimal separator", ".", "The decimal separator" }));
            lvwResults.Items.Add(new ListViewItem(new String[] { "Thousands separator", ",", "Thousands separator" }));
            lvwResults.Items.Add(new ListViewItem(new String[] { "Scaling", ",", "When placed at the end of the format string, divides by 1000" }));
            lvwResults.Items.Add(new ListViewItem(new String[] { "Percent placeholder", "%", "Multiplies by 100 and inserts a percent symbol" }));
            lvwResults.Items.Add(new ListViewItem(new String[] { "Per mille placeholder", "‰", "Multiplies by 100 and inserts a per mille symbol" }));
            lvwResults.Items.Add(new ListViewItem(new String[] { "Exponentiation", "E+0", "Exponentiation." }));
            lvwResults.Items.Add(new ListViewItem(new String[] { "Escape character", "\\", "The following character is not interpreted as a formatting character" }));
            lvwResults.Items.Add(new ListViewItem(new String[] { "Literal string", "'...'", "The characters in single or double quotes are displayed literally" }));
            lvwResults.Items.Add(new ListViewItem(new String[] { "Section separator", ";", "Creates up to three sections for values > 0, < 0, or = 0." }));

            lvwSamples.Items.Add(new ListViewItem(new String[] { "123(\"00000\")", 123.ToString("00000") }));
            lvwSamples.Items.Add(new ListViewItem(new String[] { "123(\"#####\")", 123.ToString("#####") }));
            lvwSamples.Items.Add(new ListViewItem(new String[] { "123.4567(\"0.00\")", 123.4567.ToString("0.00") }));
            lvwSamples.Items.Add(new ListViewItem(new String[] { "1234567890(\"#,#\")", 1234567890.ToString("#,#") }));
            lvwSamples.Items.Add(new ListViewItem(new String[] { "1234567890(\"#,#,,\")", 1234567890.ToString("#,#,,") }));
            lvwSamples.Items.Add(new ListViewItem(new String[] { "0.1234(\"#.#%\")", 0.1234.ToString("#.#%") }));
            lvwSamples.Items.Add(new ListViewItem(new String[] { "1234567890(\"#E000\")", 1234567890.ToString("#E000") }));
            lvwSamples.Items.Add(new ListViewItem(new String[] { "1234567890(\"#E+000\")", 1234567890.ToString("#E+000") }));
            lvwSamples.Items.Add(new ListViewItem(new String[] { "0.00001234(\"#E000\")", 0.00001234.ToString("#E000") }));
            lvwSamples.Items.Add(new ListViewItem(new String[] { "1.234(\"+0.00;<0.00>;-zero-\")", 1.234.ToString("+0.00;<0.00>;-zero-") }));
            lvwSamples.Items.Add(new ListViewItem(new String[] { "-1.234(\"+0.00;<0.00>;-zero-\")", (-1.234).ToString("+0.00;<0.00>;-zero-") }));
            lvwSamples.Items.Add(new ListViewItem(new String[] { "0(\"+0.00;<0.00>;-zero-\")", 0.ToString("+0.00;<0.00>;-zero-") }));

            // Generate code for an HTML tables.
            Console.WriteLine(ListViewToHtmlTable(lvwResults, 1, 0, 5));
            Console.WriteLine(ListViewToHtmlTable(lvwSamples, 1, 0, 5));
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
            this.lvwSamples = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lvwResults
            // 
            this.lvwResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwResults.Location = new System.Drawing.Point(1, 1);
            this.lvwResults.Name = "lvwResults";
            this.lvwResults.Size = new System.Drawing.Size(590, 228);
            this.lvwResults.TabIndex = 2;
            this.lvwResults.UseCompatibleStateImageBehavior = false;
            this.lvwResults.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Format";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Result";
            this.columnHeader3.Width = 370;
            // 
            // lvwSamples
            // 
            this.lvwSamples.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwSamples.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.lvwSamples.Location = new System.Drawing.Point(1, 235);
            this.lvwSamples.Name = "lvwSamples";
            this.lvwSamples.Size = new System.Drawing.Size(590, 260);
            this.lvwSamples.TabIndex = 3;
            this.lvwSamples.UseCompatibleStateImageBehavior = false;
            this.lvwSamples.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Example";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Result";
            this.columnHeader5.Width = 150;
            // 
            // howto_custom_number_formats_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 497);
            this.Controls.Add(this.lvwSamples);
            this.Controls.Add(this.lvwResults);
            this.Name = "howto_custom_number_formats_Form1";
            this.Text = "howto_custom_number_formats";
            this.Load += new System.EventHandler(this.howto_custom_number_formats_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwResults;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView lvwSamples;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}

