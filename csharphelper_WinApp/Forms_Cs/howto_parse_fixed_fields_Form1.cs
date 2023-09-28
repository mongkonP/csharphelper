using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Add a reference to Microsoft.VisualBasic.
using Microsoft.VisualBasic.FileIO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_parse_fixed_fields_Form1:Form
  { 


        public howto_parse_fixed_fields_Form1()
        {
            InitializeComponent();
        }

        // Load the data.
        private void howto_parse_fixed_fields_Form1_Load(object sender, EventArgs e)
        {
            // Open a TextFieldParser using these delimiters.
            using (TextFieldParser parser =
                FileSystem.OpenTextFieldParser("Names.txt"))
            {
                // Set the field widths.
                parser.TextFieldType = FieldType.FixedWidth;
                parser.FieldWidths = new int[] { 20, 20, 30, 20, 2, 5 };

                // Process the file's lines.
                while (!parser.EndOfData)
                {
                    try
                    {
                        string[] fields = parser.ReadFields();
                        ListViewItem item = lvwPeople.Items.Add(fields[0]);
                        for (int i = 1; i <= 5; i++)
                        {
                            item.SubItems.Add(fields[i]);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            lvwPeople.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
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
            this.lvwPeople = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lvwPeople
            // 
            this.lvwPeople.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvwPeople.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwPeople.Location = new System.Drawing.Point(0, 0);
            this.lvwPeople.Name = "lvwPeople";
            this.lvwPeople.Size = new System.Drawing.Size(454, 203);
            this.lvwPeople.TabIndex = 2;
            this.lvwPeople.UseCompatibleStateImageBehavior = false;
            this.lvwPeople.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "First Name";
            this.columnHeader1.Width = 72;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Last Name";
            this.columnHeader2.Width = 74;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Street";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "City";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "State";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "ZIP";
            // 
            // howto_parse_fixed_fields_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 203);
            this.Controls.Add(this.lvwPeople);
            this.Name = "howto_parse_fixed_fields_Form1";
            this.Text = "howto_parse_fixed_fields";
            this.Load += new System.EventHandler(this.howto_parse_fixed_fields_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwPeople;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}

