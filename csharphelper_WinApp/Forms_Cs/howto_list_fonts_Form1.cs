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
     public partial class howto_list_fonts_Form1:Form
  { 


        public howto_list_fonts_Form1()
        {
            InitializeComponent();
        }

        // List the installed fonts.
        private void howto_list_fonts_Form1_Load(object sender, EventArgs e)
        {
            InstalledFontCollection fonts = new InstalledFontCollection();
            foreach (FontFamily font_family in fonts.Families)
            {
                lstFonts.Items.Add(font_family.Name);
            }

            // Select the first font.
            lstFonts.SelectedIndex = 0;
        }

        // Display a sample of the selected font.
        private void ShowSample()
        {
            // Compose the font style.
            FontStyle font_style = FontStyle.Regular;
            if (chkBold.Checked) font_style |= FontStyle.Bold;
            if (chkItalic.Checked) font_style |= FontStyle.Italic;
            if (chkUnderline.Checked) font_style |= FontStyle.Underline;
            if (chkStrikeout.Checked) font_style |= FontStyle.Strikeout;

            // Get the font size.
            float font_size = 8;
            try
            {
                font_size = float.Parse(txtSize.Text);
            }
            catch
            {
            }

            // Get the font family name.
            string family_name = "Times New Roman";
            if (!(lstFonts.SelectedItem == null))
                family_name = lstFonts.SelectedItem.ToString();

            // Set the sample's font.
            txtSample.Font = new Font(family_name, font_size, font_style);
        }

        // If something changes, display a new sample of the selected font.
        // This event handler catches all of the events for controls
        // that influence the font's properties.
        private void SomethingChanged(object sender, EventArgs e)
        {
            ShowSample();
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
            this.txtSample = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkStrikeout = new System.Windows.Forms.CheckBox();
            this.chkUnderline = new System.Windows.Forms.CheckBox();
            this.chkItalic = new System.Windows.Forms.CheckBox();
            this.chkBold = new System.Windows.Forms.CheckBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstFonts
            // 
            this.lstFonts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstFonts.FormattingEnabled = true;
            this.lstFonts.Location = new System.Drawing.Point(152, 12);
            this.lstFonts.Name = "lstFonts";
            this.lstFonts.Size = new System.Drawing.Size(143, 264);
            this.lstFonts.TabIndex = 0;
            this.lstFonts.SelectedIndexChanged += new System.EventHandler(this.SomethingChanged);
            // 
            // txtSample
            // 
            this.txtSample.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSample.Location = new System.Drawing.Point(301, 12);
            this.txtSample.Multiline = true;
            this.txtSample.Name = "txtSample";
            this.txtSample.Size = new System.Drawing.Size(135, 264);
            this.txtSample.TabIndex = 1;
            this.txtSample.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890!@#$%^&*()-=_+[]\\{}" +
                "|;\':\",./<>?`~";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.chkStrikeout);
            this.groupBox1.Controls.Add(this.chkUnderline);
            this.groupBox1.Controls.Add(this.chkItalic);
            this.groupBox1.Controls.Add(this.chkBold);
            this.groupBox1.Controls.Add(this.txtSize);
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 264);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Properties";
            // 
            // chkStrikeout
            // 
            this.chkStrikeout.Location = new System.Drawing.Point(27, 123);
            this.chkStrikeout.Name = "chkStrikeout";
            this.chkStrikeout.Size = new System.Drawing.Size(88, 16);
            this.chkStrikeout.TabIndex = 11;
            this.chkStrikeout.Text = "Strikeout";
            this.chkStrikeout.CheckedChanged += new System.EventHandler(this.SomethingChanged);
            // 
            // chkUnderline
            // 
            this.chkUnderline.Location = new System.Drawing.Point(27, 99);
            this.chkUnderline.Name = "chkUnderline";
            this.chkUnderline.Size = new System.Drawing.Size(88, 16);
            this.chkUnderline.TabIndex = 10;
            this.chkUnderline.Text = "Underline";
            this.chkUnderline.CheckedChanged += new System.EventHandler(this.SomethingChanged);
            // 
            // chkItalic
            // 
            this.chkItalic.Location = new System.Drawing.Point(27, 75);
            this.chkItalic.Name = "chkItalic";
            this.chkItalic.Size = new System.Drawing.Size(88, 16);
            this.chkItalic.TabIndex = 9;
            this.chkItalic.Text = "Italic";
            this.chkItalic.CheckedChanged += new System.EventHandler(this.SomethingChanged);
            // 
            // chkBold
            // 
            this.chkBold.Location = new System.Drawing.Point(27, 51);
            this.chkBold.Name = "chkBold";
            this.chkBold.Size = new System.Drawing.Size(88, 16);
            this.chkBold.TabIndex = 8;
            this.chkBold.Text = "Bold";
            this.chkBold.CheckedChanged += new System.EventHandler(this.SomethingChanged);
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(59, 19);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(32, 20);
            this.txtSize.TabIndex = 7;
            this.txtSize.Text = "30";
            this.txtSize.TextChanged += new System.EventHandler(this.SomethingChanged);
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(19, 19);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(32, 16);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "Size";
            // 
            // howto_list_fonts_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 288);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtSample);
            this.Controls.Add(this.lstFonts);
            this.Name = "howto_list_fonts_Form1";
            this.Text = "howto_list_fonts";
            this.Load += new System.EventHandler(this.howto_list_fonts_Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstFonts;
        private System.Windows.Forms.TextBox txtSample;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.CheckBox chkStrikeout;
        internal System.Windows.Forms.CheckBox chkUnderline;
        internal System.Windows.Forms.CheckBox chkItalic;
        internal System.Windows.Forms.CheckBox chkBold;
        internal System.Windows.Forms.TextBox txtSize;
        internal System.Windows.Forms.Label Label1;
    }
}

