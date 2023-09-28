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
     public partial class howto_reflection_list_methods_Form1:Form
  { 


        public howto_reflection_list_methods_Form1()
        {
            InitializeComponent();
        }

        // Add some methods.
        private void MyPrivateMethod(string arg0, string arg2) { }
        public void MyPublicMethod(float float0, double double0) { }
        private void MyOverloadedMethod() { }
        private void MyOverloadedMethod(int arg0) { }
        protected void MyProtectedMethod() { }

        private void howto_reflection_list_methods_Form1_Load(object sender, EventArgs e)
        {
            // Make column headers.
            lvwMethods.Columns.Clear();
            lvwMethods.Columns.Add("Method", 200,
                HorizontalAlignment.Left);
            lvwMethods.Columns.Add("Description", 300,
                HorizontalAlignment.Left);
            lvwMethods.Columns.Add("Properties", 150,
                HorizontalAlignment.Left);

            // List the methods.
            // Use the class you want to study instead of howto_reflection_list_methods_Form1.
            MethodInfo[] method_infos = typeof(howto_reflection_list_methods_Form1).GetMethods(
                BindingFlags.FlattenHierarchy |
                BindingFlags.Instance |
                BindingFlags.NonPublic |
                BindingFlags.Public |
                BindingFlags.Static);
            foreach (MethodInfo info in method_infos)
            {
                // Make a list of properties.
                string properties = "";
                if (info.IsConstructor) properties += " ctor";
                if (info.IsAbstract) properties += " abstract";
                if (info.IsPrivate) properties += " private";
                if (info.IsPublic) properties += " public";
                if (info.IsFamily) properties += " protected";
                if (info.IsFamilyAndAssembly) properties += " protected AND internal";
                if (info.IsFamilyOrAssembly) properties += " protected OR internal";
                if (info.IsFinal) properties += " sealed";
                if (info.IsGenericMethod) properties += " generic";
                if (info.IsStatic) properties += " static";
                if (info.IsVirtual) properties += " virtual";

                if (properties.Length > 0) properties = properties.Substring(1);
                ListViewMakeRow(lvwMethods,
                    info.Name,
                    info.ToString(),
                    properties);
            }

            // Size the columns to fit the data.
            for (int i = 0; i < lvwMethods.Columns.Count; i++)
                lvwMethods.Columns[i].Width = 150;

            // Size the form.
            int new_wid = 30;
            for (int i = 0; i < lvwMethods.Columns.Count; i++)
                new_wid += lvwMethods.Columns[i].Width;
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
            this.lvwMethods = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lvwMethods
            // 
            this.lvwMethods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwMethods.FullRowSelect = true;
            this.lvwMethods.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwMethods.Location = new System.Drawing.Point(0, 0);
            this.lvwMethods.Name = "lvwMethods";
            this.lvwMethods.Size = new System.Drawing.Size(384, 211);
            this.lvwMethods.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwMethods.TabIndex = 3;
            this.lvwMethods.UseCompatibleStateImageBehavior = false;
            this.lvwMethods.View = System.Windows.Forms.View.Details;
            // 
            // howto_reflection_list_methods_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 211);
            this.Controls.Add(this.lvwMethods);
            this.Name = "howto_reflection_list_methods_Form1";
            this.Text = "howto_reflection_list_methods";
            this.Load += new System.EventHandler(this.howto_reflection_list_methods_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListView lvwMethods;
    }
}

