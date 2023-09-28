using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;
using System.Globalization;

 

using howto_show_locale_dates;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_show_locale_dates_Form1:Form
  { 


        public howto_show_locale_dates_Form1()
        {
            InitializeComponent();
        }

        // List the locales.
        private void howto_show_locale_dates_Form1_Load(object sender, EventArgs e)
        {
            // Make the ListBox use tabs.
            lstLocales.UseTabStops = true;
            lstLocales.UseCustomTabOffsets = true;

            // Define the tabs.
            ListBox.IntegerCollection offsets =
                lstLocales.CustomTabOffsets;
            offsets.Add(200);

            // Add the locale information.
            foreach (CultureInfo info in
                CultureInfo.GetCultures(CultureTypes.SpecificCultures))
                    lstLocales.Items.Add(new CultureData(info));
            
            // Select the first culture.
            lstLocales.SelectedIndex = 0;
        }

        // Display date and currency samples.
        private void lstLocales_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected culture's data.
            CultureData data = lstLocales.SelectedItem as CultureData;

            // Set the thread culture and UI culture.
            Thread.CurrentThread.CurrentUICulture = data.Info;
            Thread.CurrentThread.CurrentCulture = data.Info;

            // Display the date sample.
            // lblDate.Text = DateTime.Now.ToString("M/dd/yyyy");  // Bad. Custom specifier.
            lblDate.Text = DateTime.Now.ToString("D");  // Good. Standard specifier.

            // Display the date currency value.
            decimal value = 12345.67m;
            lblCurrency.Text = value.ToString("C");
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
            this.lstLocales = new System.Windows.Forms.ListBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstLocales
            // 
            this.lstLocales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLocales.FormattingEnabled = true;
            this.lstLocales.IntegralHeight = false;
            this.lstLocales.Location = new System.Drawing.Point(12, 12);
            this.lstLocales.Name = "lstLocales";
            this.lstLocales.Size = new System.Drawing.Size(460, 224);
            this.lstLocales.Sorted = true;
            this.lstLocales.TabIndex = 0;
            this.lstLocales.SelectedIndexChanged += new System.EventHandler(this.lstLocales_SelectedIndexChanged);
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(9, 239);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(0, 13);
            this.lblDate.TabIndex = 1;
            // 
            // lblCurrency
            // 
            this.lblCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(204, 239);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(0, 13);
            this.lblCurrency.TabIndex = 2;
            // 
            // howto_show_locale_dates_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lstLocales);
            this.Name = "howto_show_locale_dates_Form1";
            this.Text = "howto_show_locale_dates";
            this.Load += new System.EventHandler(this.howto_show_locale_dates_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstLocales;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblCurrency;
    }
}

