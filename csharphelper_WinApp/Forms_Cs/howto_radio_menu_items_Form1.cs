using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_radio_menu_items_Form1:Form
  { 


        public howto_radio_menu_items_Form1()
        {
            InitializeComponent();
        }

        // Check this menu item and uncheck the others.
        private void mnuViewOption_Click(object sender, EventArgs e)
        {
            // Check the menu item.
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            CheckMenuItem(mnuView, item);

            // Do something with the menu selection.
            // You could use a switch statement here.
            // This example just displays the menu item's text.
            MessageBox.Show(item.Text);
        }

        // Uncheck all menu items in this menu except checked_item.
        private void CheckMenuItem(ToolStripMenuItem mnu, ToolStripMenuItem checked_item)
        {
            // Uncheck the menu items except checked_item.
            foreach (ToolStripItem item in mnu.DropDownItems)
            {
                if (item is ToolStripMenuItem)
                {
                    ToolStripMenuItem menu_item = item as ToolStripMenuItem;
                    menu_item.Checked = (menu_item == checked_item);
                }
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewLargeIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuViewSmallIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewTile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuView});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(326, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuView
            // 
            this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewDetail,
            this.mnuViewLargeIcon,
            this.mnuViewList,
            this.toolStripSeparator1,
            this.mnuViewSmallIcon,
            this.mnuViewTile});
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(44, 20);
            this.mnuView.Text = "&View";
            // 
            // mnuViewDetail
            // 
            this.mnuViewDetail.Checked = true;
            this.mnuViewDetail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuViewDetail.Name = "mnuViewDetail";
            this.mnuViewDetail.Size = new System.Drawing.Size(129, 22);
            this.mnuViewDetail.Text = "&Detail";
            this.mnuViewDetail.Click += new System.EventHandler(this.mnuViewOption_Click);
            // 
            // mnuViewLargeIcon
            // 
            this.mnuViewLargeIcon.Name = "mnuViewLargeIcon";
            this.mnuViewLargeIcon.Size = new System.Drawing.Size(129, 22);
            this.mnuViewLargeIcon.Text = "&Large Icon";
            this.mnuViewLargeIcon.Click += new System.EventHandler(this.mnuViewOption_Click);
            // 
            // mnuViewList
            // 
            this.mnuViewList.Name = "mnuViewList";
            this.mnuViewList.Size = new System.Drawing.Size(129, 22);
            this.mnuViewList.Text = "&List";
            this.mnuViewList.Click += new System.EventHandler(this.mnuViewOption_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(126, 6);
            // 
            // mnuViewSmallIcon
            // 
            this.mnuViewSmallIcon.Name = "mnuViewSmallIcon";
            this.mnuViewSmallIcon.Size = new System.Drawing.Size(129, 22);
            this.mnuViewSmallIcon.Text = "&Small Icon";
            this.mnuViewSmallIcon.Click += new System.EventHandler(this.mnuViewOption_Click);
            // 
            // mnuViewTile
            // 
            this.mnuViewTile.Name = "mnuViewTile";
            this.mnuViewTile.Size = new System.Drawing.Size(129, 22);
            this.mnuViewTile.Text = "&Tile";
            this.mnuViewTile.Click += new System.EventHandler(this.mnuViewOption_Click);
            // 
            // howto_radio_menu_items_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 264);
            this.Controls.Add(this.menuStrip1);
            this.Name = "howto_radio_menu_items_Form1";
            this.Text = "howto_radio_menu_items";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuViewDetail;
        private System.Windows.Forms.ToolStripMenuItem mnuViewLargeIcon;
        private System.Windows.Forms.ToolStripMenuItem mnuViewList;
        private System.Windows.Forms.ToolStripMenuItem mnuViewSmallIcon;
        private System.Windows.Forms.ToolStripMenuItem mnuViewTile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

