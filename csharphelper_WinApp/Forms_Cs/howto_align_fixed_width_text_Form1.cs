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
     public partial class howto_align_fixed_width_text_Form1:Form
  { 


        public howto_align_fixed_width_text_Form1()
        {
            InitializeComponent();
        }

        private void howto_align_fixed_width_text_Form1_Load(object sender, EventArgs e)
        {
            // Make the data values.
            string[] values = 
            {
                "1 - C# 24-Hour Trainer",
                "2 - Visual Basic 24-Hour Trainer",
                "3 - WPF Programmer's Reference",
                "10 - Beginning Database Design Solutions",
                "11 - Visual Basic 2010 Programmer's Reference", 
                "100 - Visual Basic 2008 Programmer's Reference", 
                "12 - Visual Basic 2005 Programmer's Reference", 
                "105 - Expert One-on-One Visual Basic Design and Development", 
                "13 - Microsoft Office Programming: A Guide for Experienced Developers", 
                "20 - Visual Basic .NET and XML", 
                "22 - Visual Basic Graphics Programming", 
                "202 - Bug Proofing Visual Basic", 
                "30 - Visual Basic Algorithms" 
            };

            // Left pad the numeric part of the values to 3 characters.
            var pad_query =
                from string value in values
                orderby int.Parse(value.Split(' ')[0])
                select value.Split(' ')[0].PadLeft(3) + value.Substring(value.IndexOf(' '));

            // Display the result.
            string[] results = pad_query.ToArray();
            cboBooks.DataSource = results;
            lstBooks.DataSource = results;
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
            this.lstBooks = new System.Windows.Forms.ListBox();
            this.cboBooks = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lstBooks
            // 
            this.lstBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBooks.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.lstBooks.FormattingEnabled = true;
            this.lstBooks.ItemHeight = 14;
            this.lstBooks.Location = new System.Drawing.Point(15, 43);
            this.lstBooks.Name = "lstBooks";
            this.lstBooks.Size = new System.Drawing.Size(301, 200);
            this.lstBooks.TabIndex = 5;
            // 
            // cboBooks
            // 
            this.cboBooks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBooks.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.cboBooks.FormattingEnabled = true;
            this.cboBooks.Location = new System.Drawing.Point(14, 14);
            this.cboBooks.Name = "cboBooks";
            this.cboBooks.Size = new System.Drawing.Size(303, 22);
            this.cboBooks.TabIndex = 4;
            // 
            // howto_align_fixed_width_text_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 256);
            this.Controls.Add(this.lstBooks);
            this.Controls.Add(this.cboBooks);
            this.Name = "howto_align_fixed_width_text_Form1";
            this.Text = "howto_align_fixed_width_text";
            this.Load += new System.EventHandler(this.howto_align_fixed_width_text_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstBooks;
        private System.Windows.Forms.ComboBox cboBooks;
    }
}

