using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Add a reference to Microsoft.Office.Interop.Word.

using Word = Microsoft.Office.Interop.Word;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_hour_conversion_chart_word_Form1:Form
  { 


        public howto_hour_conversion_chart_word_Form1()
        {
            InitializeComponent();
        }

        // Load the timezone lists.
        private void howto_hour_conversion_chart_word_Form1_Load(object sender, EventArgs e)
        {
            // Select the current date.
            dtpDate.Value = DateTime.Now;

            // Initialize the timezone lists.
            foreach (TimeZoneInfo info in
                TimeZoneInfo.GetSystemTimeZones())
            {
                cboTimeZone1.Items.Add(info);
                cboTimeZone2.Items.Add(info);
            }

            // Select some defaults.
            SelectItemContaining(cboTimeZone1, "Mountain Time");
            SelectItemContaining(cboTimeZone2, "Tokyo");
        }

        // Select an item containing the target string.
        private void SelectItemContaining(ComboBox cbo, string target)
        {
            foreach (object item in cbo.Items)
            {
                if (item.ToString().Contains(target))
                {
                    cbo.SelectedItem = item;
                    return;
                }
            }

            // Select the first item.
            cbo.SelectedIndex = 0;
        }

        // Make a conversion chart.
        private void btnMakeChart_Click(object sender, EventArgs e)
        {
            // Get the timezone information.
            TimeZoneInfo zone1 =
                cboTimeZone1.SelectedItem as TimeZoneInfo;
            TimeZoneInfo zone2 =
                cboTimeZone2.SelectedItem as TimeZoneInfo;

            // Get the Word application object.
            Word._Application word_app = new Word.Application();

            // Make Word visible (optional).
            word_app.Visible = true;

            // Create the Word document.
            object missing = Type.Missing;
            Word._Document word_doc = word_app.Documents.Add(
                ref missing, ref missing, ref missing, ref missing);

            // Create a table.
            object start = 0;
            Word.Range range = word_doc.Range(ref start, ref start);
            object collapse_end = Word.WdCollapseDirection.wdCollapseEnd;
            range.Collapse(ref collapse_end);
            object default_table_behavior = Word.WdDefaultTableBehavior.wdWord9TableBehavior;
            object auto_fit_behavior = Word.WdAutoFitBehavior.wdAutoFitContent;
            Word.Table word_table = word_doc.Tables.Add(
                range, 25, 2, ref default_table_behavior, ref auto_fit_behavior);

            // Compose the headers.
            string name1 = zone1.DisplayName;
            name1 = name1.Replace(") ", ")\n");
            name1 = name1.Replace(" (", "\n(");
            if (name1.EndsWith("\n")) name1 =
                name1.Substring(0, name1.Length - 1);
            string name2 = zone2.DisplayName;
            name2 = name2.Replace(") ", ")\n");
            name2 = name2.Replace(" (", "\n(");
            if (name2.EndsWith("\n")) name2 =
                name2.Substring(0, name2.Length - 2);

            word_table.Cell(1, 1).Range.Text = name1;
            word_table.Cell(1, 2).Range.Text = name2;

            // Draw the hour conversions.
            DateTime time1 = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                0, 0, 0);
            for (int hour = 1; hour <= 24; hour++)
            {
                word_table.Cell(hour + 1, 1).Range.Text = time1.ToShortTimeString();

                DateTime time2 = TimeZoneInfo.ConvertTime(time1, zone1, zone2);
                string text2 = time2.ToShortTimeString();
                if (time1.Date < time2.Date) text2 += " (tomorrow)";
                else if (time1.Date > time2.Date) text2 += " (yesterday)";
                word_table.Cell(hour + 1, 2).Range.Text = text2;

                time1 = time1.AddHours(1);
            }

            // Center the table's columns.
            word_table.Range.Font.Size = 10;
            word_table.Range.Font.Name = "Times New Roman";
            word_table.Range.ParagraphFormat.Alignment =
                Word.WdParagraphAlignment.wdAlignParagraphCenter;
            word_table.Range.ParagraphFormat.LineSpacingRule =
                Word.WdLineSpacing.wdLineSpaceExactly;
            word_table.Range.ParagraphFormat.LineSpacing = 12f;
            word_table.Range.ParagraphFormat.SpaceAfter = 0f;

            // Save the document.
            string filename = Application.StartupPath + "\\TimeConversion.docx";

            object filename_obj = filename;
            word_doc.SaveAs(ref filename_obj, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing);

            // Close down Word.
            object save_changes = false;
            word_doc.Close(ref save_changes, ref missing, ref missing);
            word_app.Quit(ref save_changes, ref missing, ref missing);

            MessageBox.Show("Done");
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboTimeZone1 = new System.Windows.Forms.ComboBox();
            this.cboTimeZone2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMakeChart = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Time Zone 1:";
            // 
            // cboTimeZone1
            // 
            this.cboTimeZone1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTimeZone1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimeZone1.FormattingEnabled = true;
            this.cboTimeZone1.Location = new System.Drawing.Point(88, 38);
            this.cboTimeZone1.Name = "cboTimeZone1";
            this.cboTimeZone1.Size = new System.Drawing.Size(234, 21);
            this.cboTimeZone1.Sorted = true;
            this.cboTimeZone1.TabIndex = 1;
            // 
            // cboTimeZone2
            // 
            this.cboTimeZone2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTimeZone2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimeZone2.FormattingEnabled = true;
            this.cboTimeZone2.Location = new System.Drawing.Point(88, 65);
            this.cboTimeZone2.Name = "cboTimeZone2";
            this.cboTimeZone2.Size = new System.Drawing.Size(234, 21);
            this.cboTimeZone2.Sorted = true;
            this.cboTimeZone2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Time Zone 2:";
            // 
            // btnMakeChart
            // 
            this.btnMakeChart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMakeChart.Location = new System.Drawing.Point(130, 92);
            this.btnMakeChart.Name = "btnMakeChart";
            this.btnMakeChart.Size = new System.Drawing.Size(75, 23);
            this.btnMakeChart.TabIndex = 4;
            this.btnMakeChart.Text = "Make Chart";
            this.btnMakeChart.UseVisualStyleBackColor = true;
            this.btnMakeChart.Click += new System.EventHandler(this.btnMakeChart_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Date:";
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDate.Location = new System.Drawing.Point(88, 12);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(234, 20);
            this.dtpDate.TabIndex = 6;
            // 
            // howto_hour_conversion_chart_word_Form1
            // 
            this.AcceptButton = this.btnMakeChart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 123);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnMakeChart);
            this.Controls.Add(this.cboTimeZone2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboTimeZone1);
            this.Controls.Add(this.label1);
            this.Name = "howto_hour_conversion_chart_word_Form1";
            this.Text = "howto_hour_conversion_chart";
            this.Load += new System.EventHandler(this.howto_hour_conversion_chart_word_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTimeZone1;
        private System.Windows.Forms.ComboBox cboTimeZone2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMakeChart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDate;
    }
}

