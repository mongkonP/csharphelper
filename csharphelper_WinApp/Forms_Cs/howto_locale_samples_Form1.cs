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
     public partial class howto_locale_samples_Form1:Form
  { 


        public howto_locale_samples_Form1()
        {
            InitializeComponent();
        }

        private void howto_locale_samples_Form1_Load(object sender, EventArgs e)
        {
            float float_value = 1234.56f;
            decimal dec_value = 1234.56m;
            DateTime now = DateTime.Now;

            // Loop through the locales.
            foreach (CultureInfo info in
                CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                ListViewItem item = lvwResults.Items.Add(
                    info.EnglishName);
                item.SubItems.Add(info.NativeName);
                item.SubItems.Add(info.Name);

                // You can't use a neutral culture as a format
                // provider, so if the CultureInfo is neutral,
                // look for a non-neutral ancestor.
                CultureInfo culture = info;
                while ((culture != null) && (culture.IsNeutralCulture))
                    culture = culture.Parent;
                if (culture != null)
                {
                    item.SubItems.Add(float_value.ToString("N", culture));
                    item.SubItems.Add(dec_value.ToString("C", culture));
                    item.SubItems.Add(now.ToString("d", culture));
                    item.SubItems.Add(now.ToString("t", culture));
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
            this.lvwResults = new System.Windows.Forms.ListView();
            this.colLocale = new System.Windows.Forms.ColumnHeader();
            this.colNumber = new System.Windows.Forms.ColumnHeader();
            this.colCurrency = new System.Windows.Forms.ColumnHeader();
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.colTime = new System.Windows.Forms.ColumnHeader();
            this.colEnglishName = new System.Windows.Forms.ColumnHeader();
            this.coloNativeName = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lvwResults
            // 
            this.lvwResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEnglishName,
            this.coloNativeName,
            this.colLocale,
            this.colNumber,
            this.colCurrency,
            this.colDate,
            this.colTime});
            this.lvwResults.FullRowSelect = true;
            this.lvwResults.Location = new System.Drawing.Point(16, 15);
            this.lvwResults.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvwResults.Name = "lvwResults";
            this.lvwResults.Size = new System.Drawing.Size(737, 291);
            this.lvwResults.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwResults.TabIndex = 0;
            this.lvwResults.UseCompatibleStateImageBehavior = false;
            this.lvwResults.View = System.Windows.Forms.View.Details;
            // 
            // colLocale
            // 
            this.colLocale.Text = "Locale";
            this.colLocale.Width = 100;
            // 
            // colNumber
            // 
            this.colNumber.Text = "Number";
            this.colNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colNumber.Width = 100;
            // 
            // colCurrency
            // 
            this.colCurrency.Text = "Currency";
            this.colCurrency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCurrency.Width = 100;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 100;
            // 
            // colTime
            // 
            this.colTime.Text = "Time";
            this.colTime.Width = 100;
            // 
            // colEnglishName
            // 
            this.colEnglishName.Text = "English Name";
            this.colEnglishName.Width = 100;
            // 
            // coloNativeName
            // 
            this.coloNativeName.Text = "Native Name";
            this.coloNativeName.Width = 100;
            // 
            // howto_locale_samples_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 321);
            this.Controls.Add(this.lvwResults);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "howto_locale_samples_Form1";
            this.Text = "howto_locale_samples";
            this.Load += new System.EventHandler(this.howto_locale_samples_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwResults;
        private System.Windows.Forms.ColumnHeader colLocale;
        private System.Windows.Forms.ColumnHeader colNumber;
        private System.Windows.Forms.ColumnHeader colCurrency;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colTime;
        private System.Windows.Forms.ColumnHeader colEnglishName;
        private System.Windows.Forms.ColumnHeader coloNativeName;
    }
}

