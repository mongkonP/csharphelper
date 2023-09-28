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
     public partial class howto_list_cultures_Form1:Form
  { 


        public howto_list_cultures_Form1()
        {
            InitializeComponent();
        }

        // List the available culture names.
        private void howto_list_cultures_Form1_Load(object sender, EventArgs e)
        {
            lvwCultures.FullRowSelect = true;

            // Add the names to the ListView.
            foreach (CultureInfo culture_info in
                CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                string specific_name = "(none)";
                try
                {
                    specific_name = CultureInfo.CreateSpecificCulture(culture_info.Name).Name;
                }
                catch { }

                ListViewItem lvi = lvwCultures.Items.Add(culture_info.Name);
                lvi.SubItems.Add(specific_name);
                lvi.SubItems.Add(culture_info.EnglishName);
            }

            // Sort the names.
            lvwCultures.Sorting = SortOrder.Ascending;
            lvwCultures.Sort();

            // Color related cultures.
            Color color1 = Color.FromArgb(192, 255, 192);
            Color color2 = Color.LightGreen;
            Color bg_color = color2;
            string last_name = "";
            foreach (ListViewItem lvi in lvwCultures.Items)
            {
                string item_name = lvi.Text.Split('-')[0];
                if (item_name != last_name)
                {
                    // Switch colors.
                    bg_color = (bg_color == color1) ? color2 : color1;
                    last_name = item_name;
                }
                lvi.BackColor = bg_color;
            }

            // Size the columns.
            lvwCultures.Columns[0].Width = -2;
            lvwCultures.Columns[1].Width = -2;
            lvwCultures.Columns[2].Width = -2;
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
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.lvwCultures = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Specific Name";
            this.columnHeader2.Width = 90;
            // 
            // lvwCultures
            // 
            this.lvwCultures.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwCultures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwCultures.Location = new System.Drawing.Point(0, 0);
            this.lvwCultures.Name = "lvwCultures";
            this.lvwCultures.Size = new System.Drawing.Size(384, 261);
            this.lvwCultures.TabIndex = 1;
            this.lvwCultures.UseCompatibleStateImageBehavior = false;
            this.lvwCultures.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "English Name";
            this.columnHeader3.Width = 133;
            // 
            // howto_list_cultures_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.lvwCultures);
            this.Name = "howto_list_cultures_Form1";
            this.Text = "howto_list_cultures";
            this.Load += new System.EventHandler(this.howto_list_cultures_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView lvwCultures;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

