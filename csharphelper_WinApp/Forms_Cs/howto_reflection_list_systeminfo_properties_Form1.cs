using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Reflection;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_reflection_list_systeminfo_properties_Form1:Form
  { 


        public howto_reflection_list_systeminfo_properties_Form1()
        {
            InitializeComponent();
        }

        private void howto_reflection_list_systeminfo_properties_Form1_Load(object sender, EventArgs e)
        {
            // Make column headers.
            lvwProperties.Columns.Clear();
            lvwProperties.Columns.Add("Property", 200,
                HorizontalAlignment.Left);
            lvwProperties.Columns.Add("Value", 225,
                HorizontalAlignment.Left);

            // List the SystemInformation class's properties.
            object property_value;
            PropertyInfo[] property_infos = typeof(SystemInformation).GetProperties(
                BindingFlags.FlattenHierarchy |
                BindingFlags.Instance |
                BindingFlags.NonPublic |
                BindingFlags.Public |
                BindingFlags.Static);
            foreach (PropertyInfo info in property_infos)
            {
                string name = info.Name;
                string value = "";

                // See if it's an array.
                if (!info.PropertyType.IsArray)
                {
                    // It's not an array.
                    if (info.CanRead) property_value = info.GetValue(this, null);
                    else property_value = "---";

                    if (property_value == null)
                        value = "<null>";
                    else
                        value = property_value.ToString();
                }
                else
                {
                    // It is an array.
                    name += "[]";
                    value = "<array>";
                }

                ListViewMakeRow(lvwProperties, name, value);
            }

            this.Text += " (" + lvwProperties.Items.Count + " properties)";
        }

        // Make a ListView row.
        private void ListViewMakeRow(ListView lvw, String item_title, params string[] subitem_titles)
        {
            // Make the item.
            ListViewItem new_item = lvw.Items.Add(item_title);

            // Make the sub-items.
            for (int i = subitem_titles.GetLowerBound(0); i <= subitem_titles.GetUpperBound(0); i++)
            {
                new_item.SubItems.Add(subitem_titles[i]);
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
            this.lvwProperties = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lvwProperties
            // 
            this.lvwProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwProperties.FullRowSelect = true;
            this.lvwProperties.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwProperties.Location = new System.Drawing.Point(0, 0);
            this.lvwProperties.Name = "lvwProperties";
            this.lvwProperties.Size = new System.Drawing.Size(504, 211);
            this.lvwProperties.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwProperties.TabIndex = 3;
            this.lvwProperties.UseCompatibleStateImageBehavior = false;
            this.lvwProperties.View = System.Windows.Forms.View.Details;
            // 
            // howto_reflection_list_systeminfo_properties_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 211);
            this.Controls.Add(this.lvwProperties);
            this.Name = "howto_reflection_list_systeminfo_properties_Form1";
            this.Text = "howto_reflection_list_systeminfo_properties";
            this.Load += new System.EventHandler(this.howto_reflection_list_systeminfo_properties_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListView lvwProperties;
    }
}

