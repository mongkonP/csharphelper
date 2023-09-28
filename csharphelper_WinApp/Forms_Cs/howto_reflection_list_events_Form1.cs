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
     public partial class howto_reflection_list_events_Form1:Form
  { 


        public howto_reflection_list_events_Form1()
        {
            InitializeComponent();
        }

        // Make some events.
        public delegate int MyPublicDelegate(string index);
        public event MyPublicDelegate MyPublicEvent;

        private delegate int MyPrivateDelegate(string index);
        private event MyPrivateDelegate MyPrivateEvent;

        public virtual event MyPublicDelegate MyVirtualEvent;

        private void howto_reflection_list_events_Form1_Load(object sender, EventArgs e)
        {
            // Make column headers.
            lvwEvents.Columns.Clear();
            lvwEvents.Columns.Add("Event", 200,
                HorizontalAlignment.Left);
            lvwEvents.Columns.Add("Attributes", 300,
                HorizontalAlignment.Left);
            lvwEvents.Columns.Add("Properties", 150,
                HorizontalAlignment.Left);

            // List the events.
            // Use the class you want to study instead of howto_reflection_list_events_Form1.
            EventInfo[] event_infos = typeof(howto_reflection_list_events_Form1).GetEvents(
                BindingFlags.FlattenHierarchy |
                BindingFlags.Instance |
                BindingFlags.NonPublic |
                BindingFlags.Public |
                BindingFlags.Static);
            foreach (EventInfo info in event_infos)
            {
                string properties = "";
                if (info.EventHandlerType.IsNotPublic) properties += " private";
                if (info.EventHandlerType.IsPublic) properties += " public";
                if (info.EventHandlerType.IsSealed) properties += " sealed";

                if (properties.Length > 0) properties = properties.Substring(1);
                ListViewMakeRow(lvwEvents,
                    info.Name,
                    info.EventHandlerType.Attributes.ToString(),
                    properties);
            }

            // Size the columns to fit the data.
            for (int i = 0; i < lvwEvents.Columns.Count; i++)
                lvwEvents.Columns[i].Width = 150;

            // Size the form.
            int new_wid = 30;
            for (int i = 0; i < lvwEvents.Columns.Count; i++)
                new_wid += lvwEvents.Columns[i].Width;
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
            this.lvwEvents = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lvwEvents
            // 
            this.lvwEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwEvents.FullRowSelect = true;
            this.lvwEvents.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwEvents.Location = new System.Drawing.Point(0, 0);
            this.lvwEvents.Name = "lvwEvents";
            this.lvwEvents.Size = new System.Drawing.Size(284, 211);
            this.lvwEvents.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwEvents.TabIndex = 4;
            this.lvwEvents.UseCompatibleStateImageBehavior = false;
            this.lvwEvents.View = System.Windows.Forms.View.Details;
            // 
            // howto_reflection_list_events_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 211);
            this.Controls.Add(this.lvwEvents);
            this.Name = "howto_reflection_list_events_Form1";
            this.Text = "howto_reflection_list_events";
            this.Load += new System.EventHandler(this.howto_reflection_list_events_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListView lvwEvents;
    }
}

