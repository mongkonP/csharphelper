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
     public partial class howto_reflection_list_systeminfo_fields_Form1:Form
  { 


        public howto_reflection_list_systeminfo_fields_Form1()
        {
            InitializeComponent();
        }

        private void howto_reflection_list_systeminfo_fields_Form1_Load(object sender, EventArgs e)
        {
            // Make column headers.
            lvwProperties.Columns.Clear();
            lvwProperties.Columns.Add("Field", 10,
                HorizontalAlignment.Left);
            lvwProperties.Columns.Add("Type", 10,
                HorizontalAlignment.Left);
            lvwProperties.Columns.Add("Attributes", 10,
                HorizontalAlignment.Left);
            lvwProperties.Columns.Add("Visibility", 10,
                HorizontalAlignment.Left);
            lvwProperties.Columns.Add("Value", 10,
                HorizontalAlignment.Left);

            // List the fields.
            object property_value;
            FieldInfo[] field_infos = typeof(SystemInformation).GetFields(
                BindingFlags.FlattenHierarchy |
                BindingFlags.Instance |
                BindingFlags.NonPublic |
                BindingFlags.Public |
                BindingFlags.Static);
            foreach (FieldInfo info in field_infos)
            {
                string name = info.Name;
                string attributes = info.FieldType.Attributes.ToString();

                string visibility = "";
                if (info.IsAssembly) visibility += " assembly";
                if (info.IsFamily) visibility += " family";
                if (info.IsFamilyAndAssembly) visibility += " family AND assembly";
                if (info.IsFamilyOrAssembly) visibility += " family OR assembly";
                if (info.IsInitOnly) visibility += " init";
                if (info.IsLiteral) visibility += " literal";
                if (info.IsPrivate) visibility += " private";
                if (info.IsPublic) visibility += " public";
                if (info.IsStatic) visibility += " static";
                if (visibility.Length > 0) visibility = visibility.Substring(1);

                string value = "";

                // See if it's an array.
                if (!info.FieldType.IsArray)
                {
                    // It's not an array.
                    property_value = info.GetValue(this);
                    if (property_value == null)
                        value = "<null>";
                    else
                        value = property_value.ToString();
                }
                else
                {
                    // It is an array.
                    name += "[]";
                    // If it's an array of integers, get the values.
                    if (info.FieldType.Name == "Int32[]")
                    {
                        Int32[] values = (Int32[])info.GetValue(this);
                        if (values == null)
                        {
                            value = "<null>";
                        }
                        else
                        {
                            foreach (Int32 val in values)
                                value += ", " + val.ToString();
                            if (value.Length > 0) value = value.Substring(2);
                            value = "[" + value + "]";
                        }
                    }
                    else
                    {
                        value = "<array>";
                    }
                }

                ListViewMakeRow(lvwProperties, name,
                    info.FieldType.ToString(),
                    attributes, visibility, value);
            }

            // Size the columns to fit the data.
            for (int i = 0; i < lvwProperties.Columns.Count; i++)
                lvwProperties.Columns[i].Width = 100;

            // Size the form.
            int new_wid = 30;
            for (int i = 0; i < lvwProperties.Columns.Count; i++)
                new_wid += lvwProperties.Columns[i].Width;
            this.Size = new Size(new_wid, this.Size.Height);
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
            this.lvwProperties.Size = new System.Drawing.Size(284, 211);
            this.lvwProperties.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwProperties.TabIndex = 4;
            this.lvwProperties.UseCompatibleStateImageBehavior = false;
            this.lvwProperties.View = System.Windows.Forms.View.Details;
            // 
            // howto_reflection_list_systeminfo_fields_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 211);
            this.Controls.Add(this.lvwProperties);
            this.Name = "howto_reflection_list_systeminfo_fields_Form1";
            this.Text = "howto_reflection_list_systeminfo_fields";
            this.Load += new System.EventHandler(this.howto_reflection_list_systeminfo_fields_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListView lvwProperties;
    }
}

