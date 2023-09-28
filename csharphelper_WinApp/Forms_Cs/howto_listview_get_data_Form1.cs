using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_listview_get_data;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_listview_get_data_Form1:Form
  { 


        public howto_listview_get_data_Form1()
        {
            InitializeComponent();
        }

        private void howto_listview_get_data_Form1_Load(object sender, EventArgs e)
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
            lvwBooks.AddRow("Interview Puzzles Dissected", RandomText(lorem_ipsum), "www.csharphelper.com/puzzles.htm", "978-1539504887", "300", "2016");
            lvwBooks.AddRow("C# 24-Hour Trainer", RandomText(lorem_ipsum), "tinyurl.com/n2a5797", "978-1-119-06566-1", "600", "2015");
            lvwBooks.AddRow("Beginning Software Engineering", RandomText(lorem_ipsum), "tinyurl.com/pz7bavo", "978-1-118-96914-4", "480", "2015");
            lvwBooks.AddRow("C# 5.0 Programmer's Reference", RandomText(lorem_ipsum), "tinyurl.com/qzcefsp", "978-1-118-84728-2", "960", "2014");
            lvwBooks.AddRow("Essential Algorithms", RandomText(lorem_ipsum), "tinyurl.com/pzuofop", "978-1-118-61210-1", "624", "2013");
            lvwBooks.AddRow("MCSD Certification Toolkit (Exam 70-483): Programming in C#", RandomText(lorem_ipsum), "tinyurl.com/oadu6c2", "978-1-118-61209-5", "648", "2013");
            lvwBooks.AddRow("Visual Basic 2012 Programmer's Reference", RandomText(lorem_ipsum), "tinyurl.com/y8rowwnd", "978-0-470-49983-2", "1272", "2012");
            lvwBooks.AddRow("Ready-to-Run Visual Basic Algorithms", RandomText(lorem_ipsum), "www.vb-helper.com/vba.htm", "0-471-24268-3", "395", "1998");
            lvwBooks.AddRow("Visual Basic Graphics Programming", RandomText(lorem_ipsum), "www.vb-helper.com/vbgp.htm", "0-472-35599-2", "712", "2000");
            lvwBooks.AddRow("Advanced Visual Basic Techniques", RandomText(lorem_ipsum), "www.vb-helper.com/avbt.htm", "0-471-18881-6", "440", "1997");
            lvwBooks.AddRow("Custom Controls Library", RandomText(lorem_ipsum), "www.vb-helper.com/ccl.htm", "0-471-24267-5", "684", "1998");
            lvwBooks.AddRow("Ready-to-Run Delphi Algorithms", RandomText(lorem_ipsum), "www.vb-helper.com/da.htm", "0-471-25400-2", "398", "1998");
            lvwBooks.AddRow("Bug Proofing Visual Basic", RandomText(lorem_ipsum), "www.vb-helper.com/err.htm", "0-471-32351-9", "397", "1999");
            lvwBooks.AddRow("Ready-to-Run Visual Basic Code Library", RandomText(lorem_ipsum), "www.vb-helper.com/vbcl.htm", "0-471-33345-X", "424", "1999");

            lvwBooks.AddRow("Bogus Book", RandomText(lorem_ipsum), "www.noplace.com/bogus.htm", "0-123-45678-9", "100", "6");
            lvwBooks.AddRow("Fakey", RandomText(lorem_ipsum), "www.skatepark.com/fakey.htm", "9-876-54321-0", "9", "700");

            lvwBooks.AddRow("Interview Puzzles Dissected", RandomText(lorem_ipsum), "www.csharphelper.com/puzzles.htm", "978-1539504887", "300", "2016");
            lvwBooks.AddRow("C# 24-Hour Trainer", RandomText(lorem_ipsum), "tinyurl.com/n2a5797", "978-1-119-06566-1", "600", "2015");
            lvwBooks.AddRow("Beginning Software Engineering", RandomText(lorem_ipsum), "tinyurl.com/pz7bavo", "978-1-118-96914-4", "480", "2015");
            lvwBooks.AddRow("C# 5.0 Programmer's Reference", RandomText(lorem_ipsum), "tinyurl.com/qzcefsp", "978-1-118-84728-2", "960", "2014");
            lvwBooks.AddRow("Essential Algorithms", RandomText(lorem_ipsum), "tinyurl.com/pzuofop", "978-1-118-61210-1", "624", "2013");
            lvwBooks.AddRow("MCSD Certification Toolkit (Exam 70-483): Programming in C#", RandomText(lorem_ipsum), "tinyurl.com/oadu6c2", "978-1-118-61209-5", "648", "2013");
            lvwBooks.AddRow("Visual Basic 2012 Programmer's Reference", RandomText(lorem_ipsum), "tinyurl.com/y8rowwnd", "978-0-470-49983-2", "1272", "2012");
            lvwBooks.AddRow("Ready-to-Run Visual Basic Algorithms", RandomText(lorem_ipsum), "www.vb-helper.com/vba.htm", "0-471-24268-3", "395", "1998");
            lvwBooks.AddRow("Visual Basic Graphics Programming", RandomText(lorem_ipsum), "www.vb-helper.com/vbgp.htm", "0-472-35599-2", "712", "2000");
            lvwBooks.AddRow("Advanced Visual Basic Techniques", RandomText(lorem_ipsum), "www.vb-helper.com/avbt.htm", "0-471-18881-6", "440", "1997");
            lvwBooks.AddRow("Custom Controls Library", RandomText(lorem_ipsum), "www.vb-helper.com/ccl.htm", "0-471-24267-5", "684", "1998");
            lvwBooks.AddRow("Ready-to-Run Delphi Algorithms", RandomText(lorem_ipsum), "www.vb-helper.com/da.htm", "0-471-25400-2", "398", "1998");
            lvwBooks.AddRow("Bug Proofing Visual Basic", RandomText(lorem_ipsum), "www.vb-helper.com/err.htm", "0-471-32351-9", "397", "1999");
            lvwBooks.AddRow("Ready-to-Run Visual Basic Code Library", RandomText(lorem_ipsum), "www.vb-helper.com/vbcl.htm", "0-471-33345-X", "424", "1999");

            lvwBooks.AddRow("Bogus Book", RandomText(lorem_ipsum), "www.noplace.com/bogus.htm", "0-123-45678-9", "100", "6");
            lvwBooks.AddRow("Fakey", RandomText(lorem_ipsum), "www.skatepark.com/fakey.htm", "9-876-54321-0", "9", "700");

            // Size the columns.
            lvwBooks.SizeColumnsToFitDataAndHeaders();
            for (int i = 0; i < 3; i++) lvwBooks.Columns[i].Width = 110;
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

        // Get the ListView's contents.
        private void btnGetData_Click(object sender, EventArgs e)
        {
            // Get the contents.
            string[,] listview_data = lvwBooks.GetListViewData();
        
            // Display the contents.
            StringBuilder sb = new StringBuilder();
            int num_rows = listview_data.GetUpperBound(0) + 1;
            int num_cols = listview_data.GetUpperBound(1) + 1;
            for (int r = 0; r < num_rows; r++)
            {
                for (int c = 0; c < num_cols; c++)
                {
                    sb.Append(listview_data[r, c] + "|");
                }
                sb.AppendLine();
            }
            txtResult.Text = sb.ToString();
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
            this.btnGetData = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwBooks
            // 
            this.lvwBooks.AllowColumnReorder = true;
            this.lvwBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwBooks.FullRowSelect = true;
            this.lvwBooks.Location = new System.Drawing.Point(3, 3);
            this.lvwBooks.Name = "lvwBooks";
            this.lvwBooks.Size = new System.Drawing.Size(328, 109);
            this.lvwBooks.TabIndex = 8;
            this.lvwBooks.UseCompatibleStateImageBehavior = false;
            this.lvwBooks.View = System.Windows.Forms.View.Details;
            // 
            // btnGetData
            // 
            this.btnGetData.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGetData.Location = new System.Drawing.Point(129, 119);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(75, 23);
            this.btnGetData.TabIndex = 7;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnGetData, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lvwBooks, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtResult, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(334, 261);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // txtResult
            // 
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Location = new System.Drawing.Point(3, 148);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(328, 110);
            this.txtResult.TabIndex = 9;
            this.txtResult.WordWrap = false;
            // 
            // howto_listview_get_data_Form1
            // 
            this.AcceptButton = this.btnGetData;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "howto_listview_get_data_Form1";
            this.Text = "howto_listview_get_data";
            this.Load += new System.EventHandler(this.howto_listview_get_data_Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListView lvwBooks;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtResult;
    }
}

