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
     public partial class howto_find_friday_13th_Form1:Form
  { 


        public howto_find_friday_13th_Form1()
        {
            InitializeComponent();
        }

        // Make the end date 10 years from now.
        private void howto_find_friday_13th_Form1_Load(object sender, EventArgs e)
        {
            dtpEnd.Value = dtpStart.Value + new TimeSpan(365 * 10, 0, 0, 0);
        }

        // List Friday the 13ths between the start and end dates.
        private void btnGo_Click(object sender, EventArgs e)
        {
            lstResults.Items.Clear();

            // Get the start and end date components.
            DateTime start_date = dtpStart.Value.Date;
            DateTime end_date = dtpEnd.Value.Date;
            int start_year = start_date.Year;
            int end_year = end_date.Year;

            // Loop over the selected years.
            for (int year = start_year; year <= end_year; year++)
            {
                // Loop over the months in the year.
                for (int month = 1; month <= 12; month++)
                {
                    // See if this month's 13th is a Friday.
                    DateTime test_date = new DateTime(year, month, 13);

                    // If we haven't reached the start date, skip this one.
                    if (test_date < start_date) continue;

                    // If we've passed the end date, stop looping.
                    if (test_date > end_date) break;

                    // See if this is a Friday.
                    if (test_date.DayOfWeek == DayOfWeek.Friday)
                        lstResults.Items.Add(test_date.ToShortDateString());
                }
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
            this.lstResults = new System.Windows.Forms.ListBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstResults
            // 
            this.lstResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstResults.FormattingEnabled = true;
            this.lstResults.IntegralHeight = false;
            this.lstResults.Location = new System.Drawing.Point(12, 93);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(280, 236);
            this.lstResults.TabIndex = 11;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGo.Location = new System.Drawing.Point(115, 64);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 10;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEnd.Location = new System.Drawing.Point(56, 38);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(236, 20);
            this.dtpEnd.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "To:";
            // 
            // dtpStart
            // 
            this.dtpStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpStart.Location = new System.Drawing.Point(56, 12);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(236, 20);
            this.dtpStart.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "From:";
            // 
            // howto_find_friday_13th_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 341);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.label1);
            this.Name = "howto_find_friday_13th_Form1";
            this.Text = "howto_find_friday_13th";
            this.Load += new System.EventHandler(this.howto_find_friday_13th_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label1;
    }
}

