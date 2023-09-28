using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;

 

using howto_get_memory_usage;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_get_memory_usage_Form1:Form
  { 


        public howto_get_memory_usage_Form1()
        {
            InitializeComponent();
        }

        // Display information about the current process's memory usage.
        private void howto_get_memory_usage_Form1_Load(object sender, EventArgs e)
        {
            Process proc = Process.GetCurrentProcess();
            AddItem(lvMemory, "Min Working Set", ((double)proc.MinWorkingSet).ToFileSize());
            AddItem(lvMemory, "Max Working Set", ((double)proc.MaxWorkingSet).ToFileSize());
            AddItem(lvMemory, "Non-paged Memory Size", ((double)proc.NonpagedSystemMemorySize64).ToFileSize());
            AddItem(lvMemory, "Paged Memory Size", ((double)proc.PagedMemorySize64).ToFileSize());
            AddItem(lvMemory, "Paged System Memory Size", ((double)proc.PagedSystemMemorySize64).ToFileSize());
            AddItem(lvMemory, "Peak Paged Memory Size", ((double)proc.PeakPagedMemorySize64).ToFileSize());
            AddItem(lvMemory, "Peak Virtual Memory Size", ((double)proc.PeakVirtualMemorySize64).ToFileSize());
            AddItem(lvMemory, "Peak Working Set", ((double)proc.PeakWorkingSet64).ToFileSize());
            AddItem(lvMemory, "Virtual Memory Size", ((double)proc.VirtualMemorySize64).ToFileSize());
            AddItem(lvMemory, "Working Set", ((double)proc.WorkingSet64).ToFileSize());

            lvMemory.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvMemory.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        // Add an item to the ListView.
        private void AddItem(ListView lv, string item_name, string item_value)
        {
            ListViewItem lv_item = lv.Items.Add(item_name);
            lv_item.SubItems.Add(item_value);
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
            this.lvMemory = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lvMemory
            // 
            this.lvMemory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lvMemory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMemory.Location = new System.Drawing.Point(0, 0);
            this.lvMemory.Name = "lvMemory";
            this.lvMemory.Size = new System.Drawing.Size(318, 214);
            this.lvMemory.TabIndex = 3;
            this.lvMemory.UseCompatibleStateImageBehavior = false;
            this.lvMemory.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Property";
            this.ColumnHeader1.Width = 200;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Value";
            this.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader2.Width = 200;
            // 
            // howto_get_memory_usage_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 214);
            this.Controls.Add(this.lvMemory);
            this.Name = "howto_get_memory_usage_Form1";
            this.Text = "howto_get_memory_usage";
            this.Load += new System.EventHandler(this.howto_get_memory_usage_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListView lvMemory;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader2;
    }
}

