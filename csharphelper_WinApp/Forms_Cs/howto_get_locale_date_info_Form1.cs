using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Globalization;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_get_locale_date_info_Form1:Form
  { 


        public howto_get_locale_date_info_Form1()
        {
            InitializeComponent();
        }

        private void howto_get_locale_date_info_Form1_Load(object sender, EventArgs e)
        {
            // Save the culture (to make the following code shorter).
            CultureInfo info = CultureInfo.InstalledUICulture;

            // Day/Month values.
            AddHeader("Day/Month:");
            AddArrayItems("Day",
                info.DateTimeFormat.DayNames);
            AddArrayItems("Abbrev Day",
                info.DateTimeFormat.AbbreviatedDayNames);
            AddArrayItems("Short Days",
                info.DateTimeFormat.ShortestDayNames);
            AddArrayItems("Month",
                info.DateTimeFormat.MonthNames);
            AddArrayItems("Abbrev Month",
                info.DateTimeFormat.AbbreviatedMonthNames);

            // Date/Time values.
            AddHeader("Date/Time Format:");
            AddItem("AMDesignator",
                info.DateTimeFormat.AMDesignator);
            AddItem("DateSeparator",
                info.DateTimeFormat.DateSeparator);
            AddItem("FirstDayOfWeek",
                info.DateTimeFormat.FirstDayOfWeek.ToString());
            AddItem("FullDateTimePattern",
                info.DateTimeFormat.FullDateTimePattern);
            AddItem("LongDatePattern",
                info.DateTimeFormat.LongDatePattern);
            AddItem("LongTimePattern",
                info.DateTimeFormat.LongTimePattern);
            AddItem("MonthDayPattern",
                info.DateTimeFormat.MonthDayPattern);
            AddItem("NativeCalendarName",
                info.DateTimeFormat.NativeCalendarName);
            AddItem("PMDesignator",
                info.DateTimeFormat.PMDesignator);
            AddItem("RFC1123Pattern",
                info.DateTimeFormat.RFC1123Pattern);
            AddItem("ShortDatePattern",
                info.DateTimeFormat.ShortDatePattern);
            AddItem("ShortTimePattern",
                info.DateTimeFormat.ShortTimePattern);
            AddItem("SortableDateTimePattern",
                info.DateTimeFormat.SortableDateTimePattern);
            AddItem("TimeSeparator",
                info.DateTimeFormat.TimeSeparator);

            // Culture values.
            AddHeader("Culture:");
            AddItem("Culture Name", info.Name);
            AddItem("Culture Native Name", info.NativeName);
            AddItem("Culture Display Name", info.DisplayName);
            AddItem("Culture English Name", info.EnglishName);
            AddItem("IetfLanguageTag", info.IetfLanguageTag);
            AddItem("IsNeutralCulture", info.IsNeutralCulture.ToString());

            // Currency values.
            AddHeader("Currency Format:");
            AddItem("Decimal Digits",
                info.NumberFormat.CurrencyDecimalDigits.ToString());
            AddItem("Decimal Separator",
                info.NumberFormat.CurrencyDecimalSeparator);
            AddItem("Group Separator",
                info.NumberFormat.CurrencyGroupSeparator);
            AddIntegerArrayItems("Group Size",
                info.NumberFormat.CurrencyGroupSizes);
            AddItem("Negative Pattern",
                info.NumberFormat.CurrencyNegativePattern.ToString());
            AddItem("Positive Pattern",
                info.NumberFormat.CurrencyPositivePattern.ToString());
            AddItem("Currency Symbol",
                info.NumberFormat.CurrencySymbol);

            // Number values.
            AddHeader("Number Format:");
            AddItem("NaN", info.NumberFormat.NaNSymbol);
            AddArrayItems("Native Digits",
                info.NumberFormat.NativeDigits);
            AddItem("Infinity Symbol",
                info.NumberFormat.NegativeInfinitySymbol);
            AddItem("Negative Sign",
                info.NumberFormat.NegativeSign);
            AddItem("Decimal Separator",
                info.NumberFormat.NumberDecimalSeparator);
            AddItem("Group Separator",
                info.NumberFormat.NumberGroupSeparator);
            AddIntegerArrayItems("Group Size",
                info.NumberFormat.PercentGroupSizes);
            AddItem("Negative Pattern",
                info.NumberFormat.NumberNegativePattern.ToString());
            AddItem("Positive Infinity Symbol",
                info.NumberFormat.PositiveInfinitySymbol);
            AddItem("Positive Sign",
                info.NumberFormat.PositiveSign);

            // Percent values.
            AddHeader("Percent Format:");
            AddItem("Decimal Digits",
                info.NumberFormat.PercentDecimalDigits.ToString());
            AddItem("Decimal Separator",
                info.NumberFormat.PercentDecimalSeparator);
            AddItem("Group Separator",
                info.NumberFormat.PercentGroupSeparator);
            AddIntegerArrayItems("Group Size",
                info.NumberFormat.PercentGroupSizes);
            AddItem("Negative Pattern",
                info.NumberFormat.PercentNegativePattern.ToString());
            AddItem("Positive Pattern",
                info.NumberFormat.PercentPositivePattern.ToString());
            AddItem("Percent Symbol",
                info.NumberFormat.PercentSymbol);
            AddItem("PerMilleSymbol",
                info.NumberFormat.PerMilleSymbol);

            lvwValues.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        // Add a header row.
        private void AddHeader(string name)
        {
            ListViewItem lvi = lvwValues.Items.Add(name);
            lvi.BackColor = Color.Pink;
        }

        // Add a value to the result.
        private void AddItem(string name, string value)
        {
            ListViewItem lvi = lvwValues.Items.Add(name);
            lvi.SubItems.Add(value);
        }

        // Add all values in an array.
        private void AddArrayItems(string name, string[] values)
        {
            for (int i = 0; i < values.Length; i++)
                AddItem(name + "[" + i + "]", values[i]);
        }

        // Add all values in an integer array.
        private void AddIntegerArrayItems(string name, int[] values)
        {
            for (int i = 0; i < values.Length; i++)
                AddItem(name + "[" + i + "]", values[i].ToString());
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
            this.lvwValues = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lvwValues
            // 
            this.lvwValues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lvwValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwValues.FullRowSelect = true;
            this.lvwValues.Location = new System.Drawing.Point(0, 0);
            this.lvwValues.Name = "lvwValues";
            this.lvwValues.Size = new System.Drawing.Size(359, 261);
            this.lvwValues.TabIndex = 2;
            this.lvwValues.UseCompatibleStateImageBehavior = false;
            this.lvwValues.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Item";
            this.ColumnHeader1.Width = 120;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Value";
            this.ColumnHeader2.Width = 120;
            // 
            // howto_get_locale_date_info_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 261);
            this.Controls.Add(this.lvwValues);
            this.Name = "howto_get_locale_date_info_Form1";
            this.Text = "howto_get_locale_date_info";
            this.Load += new System.EventHandler(this.howto_get_locale_date_info_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListView lvwValues;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader2;
    }
}

