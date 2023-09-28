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
     public partial class howto_detect_leap_year_Form1:Form
  { 


        public howto_detect_leap_year_Form1()
        {
            InitializeComponent();
        }

        // List leap years between the two entered years.
        private void btnList_Click(object sender, EventArgs e)
        {
            lstYears.Items.Clear();

            int from_year = int.Parse(txtFromYear.Text);
            int to_year = int.Parse(txtToYear.Text);
            for (int year = from_year; year <= to_year; year++)
            {
                if (DateTime.IsLeapYear(year)) lstYears.Items.Add(year);
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
            this.lstYears = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtToYear = new System.Windows.Forms.TextBox();
            this.btnList = new System.Windows.Forms.Button();
            this.txtFromYear = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstYears
            // 
            this.lstYears.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstYears.FormattingEnabled = true;
            this.lstYears.IntegralHeight = false;
            this.lstYears.Location = new System.Drawing.Point(15, 41);
            this.lstYears.MultiColumn = true;
            this.lstYears.Name = "lstYears";
            this.lstYears.Size = new System.Drawing.Size(277, 208);
            this.lstYears.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "to";
            // 
            // txtToYear
            // 
            this.txtToYear.Location = new System.Drawing.Point(125, 14);
            this.txtToYear.Name = "txtToYear";
            this.txtToYear.Size = new System.Drawing.Size(44, 20);
            this.txtToYear.TabIndex = 7;
            this.txtToYear.Text = "2150";
            this.txtToYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnList.Location = new System.Drawing.Point(217, 12);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(75, 23);
            this.btnList.TabIndex = 8;
            this.btnList.Text = "List";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // txtFromYear
            // 
            this.txtFromYear.Location = new System.Drawing.Point(55, 14);
            this.txtFromYear.Name = "txtFromYear";
            this.txtFromYear.Size = new System.Drawing.Size(44, 20);
            this.txtFromYear.TabIndex = 5;
            this.txtFromYear.Text = "2000";
            this.txtFromYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Years:";
            // 
            // howto_detect_leap_year_Form1
            // 
            this.AcceptButton = this.btnList;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 261);
            this.Controls.Add(this.lstYears);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtToYear);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.txtFromYear);
            this.Controls.Add(this.label1);
            this.Name = "howto_detect_leap_year_Form1";
            this.Text = "howto_detect_leap_year";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstYears;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtToYear;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.TextBox txtFromYear;
        private System.Windows.Forms.Label label1;
    }
}

