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
     public partial class howto_list_locales_Form1:Form
  { 


        public howto_list_locales_Form1()
        {
            InitializeComponent();
        }

        private void howto_list_locales_Form1_Load(object sender, EventArgs e)
        {
            // Make the ListBox use tabs.
            lstLocales.UseTabStops = true;
            lstLocales.UseCustomTabOffsets = true;

            // Define the tabs.
            ListBox.IntegerCollection offsets = lstLocales.CustomTabOffsets;
            offsets.Add(100);

            // Add the locale information.
            foreach (CultureInfo info in
                CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                lstLocales.Items.Add(
                    info.EnglishName + '\t' +
                    info.NativeName);
            }

            // Display the number of locales.
            lblNumLocales.Text = lstLocales.Items.Count.ToString() + " locales";
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
            this.lblNumLocales = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstLocales
            // 
            this.lstLocales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLocales.FormattingEnabled = true;
            this.lstLocales.Location = new System.Drawing.Point(12, 12);
            this.lstLocales.Name = "lstLocales";
            this.lstLocales.Size = new System.Drawing.Size(260, 225);
            this.lstLocales.Sorted = true;
            this.lstLocales.TabIndex = 0;
            // 
            // lblNumLocales
            // 
            this.lblNumLocales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNumLocales.AutoSize = true;
            this.lblNumLocales.Location = new System.Drawing.Point(12, 242);
            this.lblNumLocales.Name = "lblNumLocales";
            this.lblNumLocales.Size = new System.Drawing.Size(76, 13);
            this.lblNumLocales.TabIndex = 1;
            this.lblNumLocales.Text = "lblNumLocales";
            // 
            // howto_list_locales_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.lblNumLocales);
            this.Controls.Add(this.lstLocales);
            this.Name = "howto_list_locales_Form1";
            this.Text = "howto_list_locales";
            this.Load += new System.EventHandler(this.howto_list_locales_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstLocales;
        private System.Windows.Forms.Label lblNumLocales;
    }
}

