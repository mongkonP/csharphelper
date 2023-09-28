using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Used by 
using System.Collections;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_hour_conversion_chart_Form1:Form
  { 


        public howto_hour_conversion_chart_Form1()
        {
            InitializeComponent();
        }

        // Load the time zone lists.
        private void howto_hour_conversion_chart_Form1_Load(object sender, EventArgs e)
        {
            // Select the current date.
            dtpDate.Value = DateTime.Now;

            // Initialize the time zone lists.
            foreach (TimeZoneInfo info in
                TimeZoneInfo.GetSystemTimeZones())
            {
                cboTimeZone1.Items.Add(info);
                cboTimeZone2.Items.Add(info);
            }

            // Select some defaults.
            cboTimeZone1.SelectedItem =
                FindItemContaining(cboTimeZone1.Items, "Mountain Time");
            cboTimeZone2.SelectedItem =
                FindItemContaining(cboTimeZone2.Items, "Tokyo");
        }

        // Make a conversion chart.
        private void btnMakeChart_Click(object sender, EventArgs e)
        {
            ppdChart.ShowDialog();
        }

        // Draw the chart.
        private void pdocChart_PrintPage(object sender,
            System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Get the time zone information.
            TimeZoneInfo zone1 =
                cboTimeZone1.SelectedItem as TimeZoneInfo;
            TimeZoneInfo zone2 =
                cboTimeZone2.SelectedItem as TimeZoneInfo;

            // Make the chart.
            int y = e.MarginBounds.Top;
            int center_x = e.MarginBounds.Left + e.MarginBounds.Width / 2;
            int col1_left = e.MarginBounds.Left;
            int col1_right = center_x - 25;
            int col2_left = center_x + 25;
            int col2_right = e.MarginBounds.Right;
            int col_width = col1_right - col1_left;
            int col1_mid = col1_left + col_width / 2;
            int col2_mid = col2_left + col_width / 2;
            using (Font font = new Font("Times New Roman", 12, FontStyle.Bold))
            {
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

                // See how big the headers will be.
                SizeF size1 = e.Graphics.MeasureString(
                    name1, font, col_width);
                SizeF size2 = e.Graphics.MeasureString(
                    name2, font, col_width);
                float header_height =
                    Math.Max(size1.Height, size2.Height);

                // Draw the headers.
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    RectangleF rect = new RectangleF(col1_left, y,
                        col_width, header_height);

                    e.Graphics.DrawString(name1,
                        font, Brushes.DarkBlue, rect, sf);
                    rect.X = col2_left;
                    e.Graphics.DrawString(name2,
                        font, Brushes.DarkBlue, rect, sf);
                }

                y += (int)(header_height + 10);
            }
            e.Graphics.DrawLine(Pens.Black, col1_left, y, col2_right, y);
            y += 10;

            // Draw the hour conversions.
            using (Font font = new Font("Times New Roman", 18, GraphicsUnit.Pixel))
            {
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Near;

                    DateTime time1 = new DateTime(
                        DateTime.Now.Year,
                        DateTime.Now.Month,
                        DateTime.Now.Day,
                        0, 0, 0);
                    for (int hour = 1; hour <= 24; hour++)
                    {
                        e.Graphics.DrawString(time1.ToShortTimeString(),
                            font, Brushes.Black, col1_mid, y, sf);

                        DateTime time2 = TimeZoneInfo.ConvertTime(time1, zone1, zone2);
                        string text2 = time2.ToShortTimeString();
                        if (time1.Date < time2.Date) text2 += " (tomorrow)";
                        else if (time1.Date > time2.Date) text2 += " (yesterday)";

                        e.Graphics.DrawString(text2,
                            font, Brushes.Black, col2_mid, y, sf);
                        y += (int)(1.5f * font.Size);
                        e.Graphics.DrawLine(Pens.Black,
                            e.MarginBounds.Left, y,
                            e.MarginBounds.Right, y);
                        y += 5;
                        time1 = time1.AddHours(1);
                    }
                }
            }

            //// Draw vertical lines.
            //foreach (int x in new int[] { x1mid, x2mid, col1_left, col1_right, col2_left, col2_right })
            //{
            //    e.Graphics.DrawLine(Pens.Blue,
            //        x, e.MarginBounds.Top,
            //        x, e.MarginBounds.Bottom);
            //}
        }

        // Select an item containing the target string.
        private object FindItemContaining(IEnumerable items, string target)
        {
            foreach (object item in items)
                if (item.ToString().Contains(target))
                    return item;

            // Return null;
            return null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_hour_conversion_chart_Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.cboTimeZone1 = new System.Windows.Forms.ComboBox();
            this.cboTimeZone2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMakeChart = new System.Windows.Forms.Button();
            this.pdocChart = new System.Drawing.Printing.PrintDocument();
            this.ppdChart = new System.Windows.Forms.PrintPreviewDialog();
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
            // pdocChart
            // 
            this.pdocChart.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdocChart_PrintPage);
            // 
            // ppdChart
            // 
            this.ppdChart.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppdChart.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppdChart.ClientSize = new System.Drawing.Size(400, 300);
            this.ppdChart.Document = this.pdocChart;
            this.ppdChart.Enabled = true;
            this.ppdChart.Icon = ((System.Drawing.Icon)(resources.GetObject("ppdChart.Icon")));
            this.ppdChart.Name = "ppdChart";
            this.ppdChart.Visible = false;
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
            // howto_hour_conversion_chart_Form1
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
            this.Name = "howto_hour_conversion_chart_Form1";
            this.Text = "howto_hour_conversion_chart";
            this.Load += new System.EventHandler(this.howto_hour_conversion_chart_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTimeZone1;
        private System.Windows.Forms.ComboBox cboTimeZone2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMakeChart;
        private System.Drawing.Printing.PrintDocument pdocChart;
        private System.Windows.Forms.PrintPreviewDialog ppdChart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDate;
    }
}

