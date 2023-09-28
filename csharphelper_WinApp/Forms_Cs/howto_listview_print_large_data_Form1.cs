using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_listview_print_large_data;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_listview_print_large_data_Form1:Form
  { 


        public howto_listview_print_large_data_Form1()
        {
            InitializeComponent();
        }

        private void howto_listview_print_large_data_Form1_Load(object sender, EventArgs e)
        {
            // Make the ListView column headers.
            lvwBooks.SetColumnHeaders(
                new object[] {
                    "Title", HorizontalAlignment.Left,
                    "Synopsis", HorizontalAlignment.Left,
                    "URL", HorizontalAlignment.Left,
                    "ISBN", HorizontalAlignment.Left,
                    "Pages", HorizontalAlignment.Right,
                    "Year", HorizontalAlignment.Right,
                });

            // Remove any existing items.
            lvwBooks.Items.Clear();

            // Add data rows.
            string lorem_ipsum = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            lvwBooks.AddRow("Interview Puzzles Dissected", RandomText(lorem_ipsum),  "www.csharphelper.com/puzzles.htm", "978-1539504887", "300", "2016");
            lvwBooks.AddRow("C# 24-Hour Trainer", RandomText(lorem_ipsum),  "tinyurl.com/n2a5797", "978-1-119-06566-1", "600", "2015");
            lvwBooks.AddRow("Beginning Software Engineering", RandomText(lorem_ipsum),  "tinyurl.com/pz7bavo", "978-1-118-96914-4", "480", "2015");
            lvwBooks.AddRow("C# 5.0 Programmer's Reference", RandomText(lorem_ipsum),  "tinyurl.com/qzcefsp", "978-1-118-84728-2", "960", "2014");
            lvwBooks.AddRow("Essential Algorithms", RandomText(lorem_ipsum),  "tinyurl.com/pzuofop", "978-1-118-61210-1", "624", "2013");
            lvwBooks.AddRow("MCSD Certification Toolkit (Exam 70-483): Programming in C#", RandomText(lorem_ipsum),  "tinyurl.com/oadu6c2", "978-1-118-61209-5", "648", "2013");
            lvwBooks.AddRow("Visual Basic 2012 Programmer's Reference", RandomText(lorem_ipsum),  "tinyurl.com/y8rowwnd", "978-0-470-49983-2", "1272", "2012");
            lvwBooks.AddRow("Ready-to-Run Visual Basic Algorithms", RandomText(lorem_ipsum),  "www.vb-helper.com/vba.htm", "0-471-24268-3", "395", "1998");
            lvwBooks.AddRow("Visual Basic Graphics Programming", RandomText(lorem_ipsum),  "www.vb-helper.com/vbgp.htm", "0-472-35599-2", "712", "2000");
            lvwBooks.AddRow("Advanced Visual Basic Techniques", RandomText(lorem_ipsum),  "www.vb-helper.com/avbt.htm", "0-471-18881-6", "440", "1997");
            lvwBooks.AddRow("Custom Controls Library", RandomText(lorem_ipsum),  "www.vb-helper.com/ccl.htm", "0-471-24267-5", "684", "1998");
            lvwBooks.AddRow("Ready-to-Run Delphi Algorithms", RandomText(lorem_ipsum),  "www.vb-helper.com/da.htm", "0-471-25400-2", "398", "1998");
            lvwBooks.AddRow("Bug Proofing Visual Basic", RandomText(lorem_ipsum),  "www.vb-helper.com/err.htm", "0-471-32351-9", "397", "1999");
            lvwBooks.AddRow("Ready-to-Run Visual Basic Code Library", RandomText(lorem_ipsum),  "www.vb-helper.com/vbcl.htm", "0-471-33345-X", "424", "1999");

            lvwBooks.AddRow("Bogus Book", RandomText(lorem_ipsum),  "www.noplace.com/bogus.htm", "0-123-45678-9", "100", "6");
            lvwBooks.AddRow("Fakey", RandomText(lorem_ipsum),  "www.skatepark.com/fakey.htm", "9-876-54321-0", "9", "700");

            // Size the columns.
            lvwBooks.SizeColumnsToFitDataAndHeaders();
            for (int i = 0; i < 3; i++) lvwBooks.Columns[i].Width = 110;

            // Make the form big enough to show the ListView.
            Rectangle item_rect =
                lvwBooks.GetItemRect(lvwBooks.Columns.Count - 1);
            this.SetClientSizeCore(
                item_rect.Left + item_rect.Width + 50,
                item_rect.Top + item_rect.Height + 75);
        }

        // Return a random chunk of the string.
        private Random Rand = new Random();
        private string RandomText(string lorem_ipsum)
        {
            const int max_length = 200;
            const int min_length = 30;

            // See how long the result will be.
            int length = Rand.Next(min_length, max_length + 1);

            // See where the result should be taken.
            int start_pos = Rand.Next(0, lorem_ipsum.Length - length - 1);
            string result = lorem_ipsum.Substring(start_pos, length);

            // Remove leading and trailing spaces.
            result = result.Trim();

            // Capitalize the first character.
            result = char.ToUpper(result[0]) + result.Substring(1);

            // End in a period.
            if (!result.EndsWith(".")) result += ".";

            return result;
        }

        // Print the ListView's contents.
        private void btnPreview_Click(object sender, EventArgs e)
        {
            // Start maximized.
            Form frm = ppdListView as Form;
            frm.WindowState = FormWindowState.Maximized;
            frm.Size = new Size(500, 340);

            // Start at 100% scale.
            ppdListView.PrintPreviewControl.Zoom = 1.0;

            // Display.
            ppdListView.ShowDialog();
        }

        // Print the ListView's data.
        private void pdocListView_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Print the ListView.
            lvwBooks.PrintMultiLineData(e.MarginBounds.Location,
                e.Graphics, Brushes.Blue,
                Brushes.Black, Pens.Blue);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_listview_print_large_data_Form1));
            this.lvwBooks = new System.Windows.Forms.ListView();
            this.btnPreview = new System.Windows.Forms.Button();
            this.ppdListView = new System.Windows.Forms.PrintPreviewDialog();
            this.pdocListView = new System.Drawing.Printing.PrintDocument();
            this.SuspendLayout();
            // 
            // lvwBooks
            // 
            this.lvwBooks.AllowColumnReorder = true;
            this.lvwBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwBooks.FullRowSelect = true;
            this.lvwBooks.Location = new System.Drawing.Point(12, 10);
            this.lvwBooks.Name = "lvwBooks";
            this.lvwBooks.Size = new System.Drawing.Size(260, 210);
            this.lvwBooks.TabIndex = 8;
            this.lvwBooks.UseCompatibleStateImageBehavior = false;
            this.lvwBooks.View = System.Windows.Forms.View.Details;
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPreview.Location = new System.Drawing.Point(105, 226);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 7;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // ppdListView
            // 
            this.ppdListView.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppdListView.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppdListView.ClientSize = new System.Drawing.Size(400, 300);
            this.ppdListView.Document = this.pdocListView;
            this.ppdListView.Enabled = true;
            this.ppdListView.Icon = ((System.Drawing.Icon)(resources.GetObject("ppdListView.Icon")));
            this.ppdListView.Name = "ppdListView";
            this.ppdListView.Visible = false;
            // 
            // pdocListView
            // 
            this.pdocListView.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdocListView_PrintPage);
            // 
            // howto_listview_print_large_data_Form1
            // 
            this.AcceptButton = this.btnPreview;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lvwBooks);
            this.Controls.Add(this.btnPreview);
            this.Name = "howto_listview_print_large_data_Form1";
            this.Text = "howto_listview_print_large_data";
            this.Load += new System.EventHandler(this.howto_listview_print_large_data_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListView lvwBooks;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.PrintPreviewDialog ppdListView;
        private System.Drawing.Printing.PrintDocument pdocListView;
    }
}

