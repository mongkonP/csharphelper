using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Globalization;
using System.Drawing.Printing;
using System.Threading;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_print_calendar_Form1:Form
  { 


        public howto_print_calendar_Form1()
        {
            // English in Australia.
            //Thread.CurrentThread.CurrentCulture =
            //    new CultureInfo("en-AU", false);
            //Thread.CurrentThread.CurrentUICulture =
            //    new CultureInfo("en-AU", false);

            // German in Germany.
            //Thread.CurrentThread.CurrentCulture =
            //    new CultureInfo("de-DE", false);
            //Thread.CurrentThread.CurrentUICulture =
            //    new CultureInfo("de-DE", false);

            InitializeComponent();
        }

        // The calendar data.
        DateTime FirstOfMonth;
        private string[] CalendarData;

        // Initialize the month and year text box.
        private void howto_print_calendar_Form1_Load(object sender, EventArgs e)
        {
            // Initialize the month ComboBox.
            string[] month_names =
                CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
            foreach (string name in month_names)
                if (name.Length > 0)
                    cboMonth.Items.Add(name);

            // Display next month's name.
            DateTime today = DateTime.Today;
            int month_num = today.Month + 1;
            if (month_num == 13) month_num = 1;
            cboMonth.SelectedIndex = month_num - 1;

            // Initialize the year ComboBox.
            for (int i = 0; i < 5; i++)
                cboYear.Items.Add(today.Year + i);

            // Display next year.
            int year_num = today.Year;
            if (month_num == 0) year_num++;
            cboYear.SelectedItem = year_num;
        }

        // Display a print preview of the calendar.
        private void btnPreview_Click(object sender, EventArgs e)
        {
            // Get the selected month and year.
            int year_num = (int)cboYear.SelectedItem;
            int month_num = cboMonth.SelectedIndex + 1;
            DateTime first_of_month =
                new DateTime(year_num, month_num, 1);

            // See how many days are in the selected month.
            int num_days = DateTime.DaysInMonth(year_num, month_num);

            // Generate some "random" data for the indicated month.
            CalendarData = MakeData(num_days);

            // Save the first date of the selected month.
            FirstOfMonth = first_of_month;

            // Display the print preview of the calendar.
            ppdCalendar.ShowDialog();
        }

        // Generate some "random" data for
        // the indicated number of days.
        private string[] MakeData(int num_days)
        {
            string words = "lorem ipsum dolor sit amet consectetur adipiscing elit integer pulvinar diam ante quis cursus felis dignissim quis nullam non tristique sapien vitae dignissim mauris etiam et risus et purus efficitur dignissim nec ultricies eros aenean consequat scelerisque enim ut congue mi pulvinar dictum aliquam erat volutpat praesent vitae lobortis nisi aliquam ornare varius eros id feugiat in id orci interdum egestas tellus nec pharetra quam ";
            words += "vivamus lacus risus accumsan volutpat vestibulum id tempor vitae dolor fusce vehicula ligula at justo hendrerit et cursus nisl efficitur vestibulum sed ipsum vel ligula lacinia fringilla quis nec justo proin mattis faucibus dictum sed porttitor egestas porttitor ut erat magna tempus vel luctus a scelerisque id lacus class aptent taciti sociosqu ad litora torquent per conubia nostra per inceptos himenaeos ut enim odio tincidunt fringilla sollicitudin sit amet ultricies et orci ";
            words += "fusce ac interdum nibh a accumsan velit sed sagittis lacinia velit et rutrum diam ornare vel aenean porta molestie dolor praesent rhoncus quam sed felis tempor a elementum lacus congue phasellus fringilla metus et lorem semper rutrum phasellus volutpat posuere magna et rutrum maecenas vel aliquam massa morbi suscipit mi a tincidunt viverra nibh libero tristique orci at mattis erat augue mollis purus cras magna justo pulvinar nec dignissim eu malesuada sed enim donec ac posuere nisi mauris vitae mauris et arcu placerat sollicitudin nec quis dolor ";
            words += "integer vitae vestibulum nibh nunc sit amet eros ante nunc a dui ornare tristique ex id auctor enim mauris maximus ac felis vitae dignissim donec ex lorem mattis sit amet venenatis id laoreet vel neque donec sollicitudin orci varius ipsum sodales at maximus est suscipit donec id nulla porta sodales mauris eu auctor arcu nullam posuere tortor eget mauris suscipit bibendum maecenas sollicitudin faucibus libero ac facilisis erat lacinia vel aliquam erat volutpat maecenas pellentesque ultricies felis nec scelerisque turpis convallis fringilla ut venenatis et sapien ac vulputate ";
            words += "praesent feugiat rhoncus tellus sit amet pretium dolor mattis non cras blandit neque nulla ullamcorper dictum tellus semper tempus curabitur porttitor luctus urna vel venenatis tortor volutpat non phasellus magna odio sollicitudin at tincidunt a convallis quis velit nam sit amet aliquam mauris ut quis pretium odio nec pretium mi vestibulum congue diam nibh vitae rhoncus purus vestibulum ut vestibulum aliquam hendrerit quam quis commodo est fermentum ut lorem ipsum dolor sit amet consectetur adipiscing elit proin quis turpis fringilla pharetra ipsum eu tincidunt ex aliquam erat volutpat pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas aenean at tellus in justo iaculis pretium vitae sit amet massa suspendisse potenti sed sit amet pellentesque ligula aliquam ipsum nulla iaculis id fermentum sed gravida quis elit ";
            words += "duis leo augue tristique non finibus sit amet malesuada et ante proin nul";
            words += "la est commodo in massa vel euismod aliquam lectus curabitur facilisis cursus neque quis lacinia maecenas vel ullamcorper ligula suspendisse mollis arcu in luctus malesuada quam ex accumsan nulla id feugiat neque sapien in massa mauris porta faucibus augue mollis tincidunt eros porttitor non phasellus ut bibendum";

            Random rand = new Random();
            string[] result = new string[num_days];
            for (int i = 0; i < num_days; i++)
            {
                int length = rand.Next(3, 15);
                result[i] = TakeWords(ref words, length);
            }

            return result;
        }

        // Take the indicated number of words from the string.
        private string TakeWords(ref string source, int num_words)
        {
            string result = "";
            for (int word = 0; word < num_words; word++)
            {
                int space_pos = source.IndexOf(' ');
                result += source.Substring(0, space_pos + 1);
                source = source.Substring(space_pos + 1);
            }
            return result.Trim();
        }

        // Draw the calendar.
        private void pdocCalendar_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DrawCalendar(e.Graphics, e.MarginBounds,
                FirstOfMonth, CalendarData);
        }

        // Draw the calendar as big as posisble.
        private void DrawCalendar(Graphics gr, RectangleF bounds,
            DateTime first_of_month, string[] date_data)
        {
            // Make the rows and columns as big as possible.
            float col_wid = bounds.Width / 7f;

            // See how many weeks we will need.
            int num_rows = NumberOfWeekRows(first_of_month);

            // Add an extra row for the month and year at the top.
            num_rows++;

            // Calculate the row height.
            float row_hgt = bounds.Height / (float)num_rows;

            // Draw the month and year.
            float x = bounds.X;
            float y = bounds.Y;
            RectangleF rectf = new RectangleF(x, y, bounds.Width, row_hgt / 2f);
            DrawMonthAndYear(gr, rectf, first_of_month);
            y += row_hgt / 2f;

            // Draw the day names.
            DrawWeekdayNames(gr, x, y, col_wid, row_hgt / 2f);
            y += row_hgt / 2f;

            // Draw the date cells.
            DrawDateData(first_of_month, date_data,
                gr, x, y, col_wid, row_hgt);

            // Outline the calendar.
            gr.DrawRectangle(Pens.Black,
                bounds.X, bounds.Y, bounds.Width, bounds.Height);
        }

        // Return the number of week rows needed by this month.
        private int NumberOfWeekRows(DateTime first_of_month)
        {
            // Get the number of days in the month.
            int num_days = DateTime.DaysInMonth(
                first_of_month.Year, first_of_month.Month);

            // Add the column number for the first day of the month.
            num_days += DateColumn(first_of_month);

            // Divide by 7 and round up.
            return (int)Math.Ceiling(num_days / 7f);
        }

        // Return the column number for this date in the current locale.
        private int DateColumn(DateTime date)
        {
            int col =
                (int)date.DayOfWeek -
                (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            if (col < 0) col += 7;
            return col;
        }

        // Draw the month and year.
        private void DrawMonthAndYear(Graphics gr, RectangleF rectf, DateTime date)
        {
            using (StringFormat sf = new StringFormat())
            {
                // Center the text.
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                string[] month_names =
                    CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
                string title = month_names[date.Month - 1] +
                    " " + date.Year.ToString();

                // Find the biggest font that will fit.
                int font_size = FindFontSize(gr, rectf, "Times New Roman", title);

                // Draw the text.
                gr.FillRectangle(Brushes.LightBlue, rectf);
                using (Font font = new Font("Times New Roman", font_size))
                {
                    gr.DrawString(title, font, Brushes.Blue, rectf, sf);
                }
            }
        }

        // Draw the weekday names.
        private void DrawWeekdayNames(Graphics gr, float x, float y, float col_wid, float hgt)
        {
            // Find the widest day name.
            float max_wid = 0;
            string[] day_names =
                CultureInfo.CurrentCulture.DateTimeFormat.DayNames;
            string widest_name = day_names[0];
            using (Font font = new Font("Times New Roman", 10))
            {
                foreach (string name in day_names)
                {
                    SizeF size = gr.MeasureString(name,font);
                    if (max_wid < size.Width)
                    {
                        max_wid = size.Width;
                        widest_name = name;
                    }
                }
            }

            // Find the biggest font size that will fit.
            RectangleF rectf = new RectangleF(x, y, col_wid, hgt);
            int font_size = FindFontSize(gr, rectf, "Times New Roman", widest_name);

            // Draw the day names.
            using (Font font = new Font("Times New Roman", font_size))
            {
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    int index = (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
                    for (int i = 0; i < 7; i++)
                    {
                        gr.FillRectangle(Brushes.LightBlue, rectf);
                        gr.DrawString(day_names[index], font, Brushes.Blue, rectf, sf);
                        index = (index + 1) % 7;
                        rectf.X += col_wid;
                    }
                }
            }
        }

        // Draw the data for each date.
        private void DrawDateData(DateTime first_of_month, string[] date_data,
            Graphics gr, float x, float y, float col_wid, float row_hgt)
        {
            // Let date numbers occupy the upper quarter
            // and left third of the date box.
            RectangleF date_rectf =
                new RectangleF(x, y, col_wid / 3f, row_hgt / 4f);

            // The date data goes below the date rectangle.
            RectangleF data_rectf =
                new RectangleF(x, y, col_wid, row_hgt * 0.75f);

            // See how big we can make the font.
            int font_size = FindFontSize(gr, date_rectf, "Times New Roman", "30");

            // Get the column number for the first day of the month.
            int col = DateColumn(first_of_month);

            // Draw the dates.
            using (Font number_font = new Font("Times New Roman", font_size))
            {
                using (Font data_font = new Font("Times New Roman", font_size * 0.75f))
                {
                    using (StringFormat ul_sf = new StringFormat())
                    {
                        ul_sf.Alignment = StringAlignment.Near;
                        ul_sf.LineAlignment = StringAlignment.Near;
                        ul_sf.Trimming = StringTrimming.EllipsisWord;
                        ul_sf.FormatFlags = StringFormatFlags.LineLimit;

                        int num_days = DateTime.DaysInMonth(
                            first_of_month.Year, first_of_month.Month);
                        for (int day_num = 0; day_num < num_days; day_num++)
                        {
                            // Outline the cell.
                            RectangleF cell_rectf = new RectangleF(
                                x + col * col_wid, y, col_wid, row_hgt);
                            gr.DrawRectangle(Pens.Black,
                                cell_rectf.X, cell_rectf.Y,
                                cell_rectf.Width, cell_rectf.Height);

                            // Draw the date.
                            date_rectf.X = cell_rectf.X;
                            date_rectf.Y = cell_rectf.Y;
                            gr.DrawString((day_num + 1).ToString(),
                                number_font, Brushes.Blue, date_rectf, ul_sf);

                            // Draw the data.
                            data_rectf.X = x + col * col_wid;
                            data_rectf.Y = y + row_hgt * 0.25f;
                            gr.DrawString(date_data[day_num],
                                data_font, Brushes.Black, data_rectf, ul_sf);

                            // Move to the next cell.
                            col = (col + 1) % 7;
                            if (col == 0) y += row_hgt;
                        }
                    }
                }
            }
        }

        // Find the largest integer font size that will fit in the given space.
        private int FindFontSize(Graphics gr, RectangleF rectf, string font_name, string text)
        {
            for (int font_size = 5; ; font_size++)
            {
                using (Font font = new Font(font_name, font_size))
                {
                    SizeF text_size = gr.MeasureString(text, font);
                    if ((text_size.Width > rectf.Width) ||
                        (text_size.Height > rectf.Height))
                        return font_size - 1;
                }
            }
        }

        // Print in landscape mode.
        private void pdocCalendar_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
        {
            e.PageSettings.Landscape = true;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_print_calendar_Form1));
            this.btnPreview = new System.Windows.Forms.Button();
            this.pdocCalendar = new System.Drawing.Printing.PrintDocument();
            this.ppdCalendar = new System.Windows.Forms.PrintPreviewDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPreview.Location = new System.Drawing.Point(105, 73);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 2;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // pdocCalendar
            // 
            this.pdocCalendar.DocumentName = "Calendar";
            this.pdocCalendar.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdocCalendar_PrintPage);
            this.pdocCalendar.QueryPageSettings += new System.Drawing.Printing.QueryPageSettingsEventHandler(this.pdocCalendar_QueryPageSettings);
            // 
            // ppdCalendar
            // 
            this.ppdCalendar.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppdCalendar.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppdCalendar.ClientSize = new System.Drawing.Size(400, 300);
            this.ppdCalendar.Document = this.pdocCalendar;
            this.ppdCalendar.Enabled = true;
            this.ppdCalendar.Icon = ((System.Drawing.Icon)(resources.GetObject("ppdCalendar.Icon")));
            this.ppdCalendar.Name = "ppdCalendar";
            this.ppdCalendar.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Month:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Year:";
            // 
            // cboMonth
            // 
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(58, 12);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(163, 21);
            this.cboMonth.TabIndex = 0;
            // 
            // cboYear
            // 
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(58, 39);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(163, 21);
            this.cboYear.TabIndex = 1;
            // 
            // howto_print_calendar_Form1
            // 
            this.AcceptButton = this.btnPreview;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 108);
            this.Controls.Add(this.cboYear);
            this.Controls.Add(this.cboMonth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPreview);
            this.Name = "howto_print_calendar_Form1";
            this.Text = "howto_print_calendar";
            this.Load += new System.EventHandler(this.howto_print_calendar_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPreview;
        private System.Drawing.Printing.PrintDocument pdocCalendar;
        private System.Windows.Forms.PrintPreviewDialog ppdCalendar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.ComboBox cboYear;
    }
}

