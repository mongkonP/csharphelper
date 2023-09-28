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
     public partial class howto_runtime_menus_Form1:Form
  { 


        public howto_runtime_menus_Form1()
        {
            InitializeComponent();
        }

        // Exit.
        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Create some tool menu items.
        private void howto_runtime_menus_Form1_Load(object sender, EventArgs e)
        {
            // Tool 1 displays a string.
            ToolStripMenuItem tool1 = new ToolStripMenuItem("Tool 1");
            tool1.Name = "mnuToolsTool1";
            tool1.ShortcutKeys = (Keys.D1 | Keys.Control); // Ctrl+1
            tool1.Click += mnuTool1_Click;
            mnuTools.DropDownItems.Add(tool1);

            // Tool 2 displays a string and image.
            ToolStripMenuItem tool2 = new ToolStripMenuItem(
                "Tool 2", Properties.Resources.happy);
            tool2.Name = "mnuToolsTool2";
            tool2.ShortcutKeys = (Keys.D2 | Keys.Control); // Ctrl+2
            tool2.Click += mnuTool2_Click;
            mnuTools.DropDownItems.Add(tool2);
        }

        // Execute tool 1.
        private void mnuTool1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tool 1");
        }

        // Execute tool 2.
        private void mnuTool2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tool 2");
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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mnuTools});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(310, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(92, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuTools
            // 
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(48, 20);
            this.mnuTools.Text = "&Tools";
            // 
            // howto_runtime_menus_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 89);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_runtime_menus_Form1";
            this.Text = "howto_runtime_menus";
            this.Load += new System.EventHandler(this.howto_runtime_menus_Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
    }
}

