using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Text;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_list_installed_fonts_Form1:Form
  { 


        public howto_list_installed_fonts_Form1()
        {
            InitializeComponent();
        }

        // List the available fonts.
        private void howto_list_installed_fonts_Form1_Load(object sender, EventArgs e)
        {
            // List the font families.
            InstalledFontCollection installedFonts = new InstalledFontCollection();
            foreach (FontFamily fontFamily in installedFonts.Families)
            {
                lstFonts.Items.Add(fontFamily.Name);
            }

            // Select the first font.
            lstFonts.SelectedIndex = 0;
        }

        // Display a sample of the selected font.
        private void lstFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Display the font family's name.
            lblSample.Text = lstFonts.Text;

            // Use the font family.
            Font font = MakeFont(lstFonts.Text, 20, FontStyle.Regular);
            if (font == null) font = MakeFont(lstFonts.Text, 20, FontStyle.Bold);
            if (font == null) font = MakeFont(lstFonts.Text, 20, FontStyle.Italic);
            if (font == null) font = MakeFont(lstFonts.Text, 20, FontStyle.Strikeout);
            if (font == null) font = MakeFont(lstFonts.Text, 20, FontStyle.Underline);

            if (font != null) lblSample.Font = font;
        }

        // Make a font with the given family name, size, and style.
        private Font MakeFont(string family, float size, FontStyle style)
        {
            try
            {
                return new Font(family, size, style);
            }
            catch
            {
                return null;
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
            this.lstFonts = new System.Windows.Forms.ListBox();
            this.lblSample = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstFonts
            // 
            this.lstFonts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFonts.FormattingEnabled = true;
            this.lstFonts.IntegralHeight = false;
            this.lstFonts.Location = new System.Drawing.Point(12, 12);
            this.lstFonts.Name = "lstFonts";
            this.lstFonts.Size = new System.Drawing.Size(260, 167);
            this.lstFonts.TabIndex = 0;
            this.lstFonts.SelectedIndexChanged += new System.EventHandler(this.lstFonts_SelectedIndexChanged);
            // 
            // lblSample
            // 
            this.lblSample.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSample.BackColor = System.Drawing.Color.White;
            this.lblSample.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSample.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSample.Location = new System.Drawing.Point(12, 175);
            this.lblSample.Name = "lblSample";
            this.lblSample.Size = new System.Drawing.Size(260, 80);
            this.lblSample.TabIndex = 1;
            this.lblSample.Text = "label1";
            // 
            // howto_list_installed_fonts_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.lblSample);
            this.Controls.Add(this.lstFonts);
            this.Name = "howto_list_installed_fonts_Form1";
            this.Text = "howto_list_installed_fonts";
            this.Load += new System.EventHandler(this.howto_list_installed_fonts_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstFonts;
        private System.Windows.Forms.Label lblSample;
    }
}

