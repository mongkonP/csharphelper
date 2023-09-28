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
     public partial class howto_reflection_list_properties_Form1:Form
  { 


        public howto_reflection_list_properties_Form1()
        {
            InitializeComponent();
        }

        // Add some properties.
        private int _MyPrivateProperty;
        private int MyPrivateProperty
        {
            get { return _MyPrivateProperty; }
            set { _MyPrivateProperty = value; }
        }
        public int MyPublicProperty
        {
            get { return 2; }
            set { }
        }
        public static int MyPublicStaticProperty
        {
            get { return 3; }
        }
        protected int MyProtectedProperty
        {
            get { return 4; }
        }
        public virtual int MyPublicVirtualProperty
        {
            set { }
        }

        private void howto_reflection_list_properties_Form1_Load(object sender, EventArgs e)
        {
            // Make column headers.
            lvwProperties.Columns.Clear();
            lvwProperties.Columns.Add("Property", 10,
                HorizontalAlignment.Left);
            lvwProperties.Columns.Add("Type", 10,
                HorizontalAlignment.Left);
            lvwProperties.Columns.Add("Attributes", 10,
                HorizontalAlignment.Left);
            lvwProperties.Columns.Add("Value", 10,
                HorizontalAlignment.Left);

            // List the properties.
            // Use the class you want to study instead of howto_reflection_list_properties_Form1.
            object property_value;
            PropertyInfo[] property_infos = typeof(howto_reflection_list_properties_Form1).GetProperties(
                BindingFlags.FlattenHierarchy |
                BindingFlags.Instance |
                BindingFlags.NonPublic |
                BindingFlags.Public |
                BindingFlags.Static);
            foreach (PropertyInfo info in property_infos)
            {
                string name = info.Name;
                string attributes = info.PropertyType.Attributes.ToString();
                if (info.CanRead) attributes += " get";
                if (info.CanWrite) attributes += " set";

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

                ListViewMakeRow(lvwProperties, name,
                    info.PropertyType.ToString(),
                    attributes, value);
            }

            // Size the columns to fit the data.
            for (int i = 0; i < lvwProperties.Columns.Count; i++)
                lvwProperties.Columns[i].Width = -2;

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
            this.lvwProperties.Size = new System.Drawing.Size(284, 261);
            this.lvwProperties.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwProperties.TabIndex = 2;
            this.lvwProperties.UseCompatibleStateImageBehavior = false;
            this.lvwProperties.View = System.Windows.Forms.View.Details;
            // 
            // howto_reflection_list_properties_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lvwProperties);
            this.Name = "howto_reflection_list_properties_Form1";
            this.Text = "howto_reflection_list_properties";
            this.Load += new System.EventHandler(this.howto_reflection_list_properties_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListView lvwProperties;
    }
}

