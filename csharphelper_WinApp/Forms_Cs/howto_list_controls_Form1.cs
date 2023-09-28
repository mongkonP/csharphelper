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
     public partial class howto_list_controls_Form1:Form
  { 


        public howto_list_controls_Form1()
        {
            InitializeComponent();
        }

        // List all of the controls on the form.
        private void howto_list_controls_Form1_Load(object sender, EventArgs e)
        {
            // List the controls in a ListBox.
            ListControls(lstControls, this, 0);

            // List the controls in a TreeView.
            ListControls(trvControls.Nodes, this);
            trvControls.ExpandAll();
        }

        // List the controls in a ListBox.
        private void ListControls(ListBox lst, Object parent, int indent)
        {
            string spaces = new string(' ', indent);
            if (parent is ToolStrip)
            {
                // Note that a StatusStrip is also a ToolStrip.
                ToolStrip tool_strip = parent as ToolStrip;
                lst.Items.Add(spaces +
                    tool_strip.Name + " (" +
                    tool_strip.GetType().Name + ")");
                foreach (ToolStripItem item in tool_strip.Items)
                {
                    ListControls(lst, item, indent + 4);
                }
            }
            else if (parent is ToolStripDropDownButton)
            {
                // ToolStripDropDownButton inherits from ToolStripItem
                // so it must come first in this if-else-if sequence.
                ToolStripDropDownButton dropdown_button =
                    parent as ToolStripDropDownButton;
                lst.Items.Add(spaces +
                    dropdown_button.Name + " (" +
                    dropdown_button.GetType().Name + ")");
                ListControls(lst, dropdown_button.DropDown, indent + 4);
            }
            else if (parent is ToolStripSplitButton)
            {
                // ToolStripSplitButton inherits from ToolStripItem
                // so it must come first in this if-else-if sequence.
                ToolStripSplitButton split_button =
                    parent as ToolStripSplitButton;
                lst.Items.Add(spaces +
                    split_button.Name + " (" +
                    split_button.GetType().Name + ")");
                ListControls(lst, split_button.DropDown, indent + 4);
            }
            else if (parent is ToolStripMenuItem)
            {
                // ToolStripMenuItem inherits from ToolStripItem
                // so it must come first in this if-else-if sequence.
                ToolStripMenuItem item = parent as ToolStripMenuItem;
                lst.Items.Add(spaces +
                    item.Name + " (" +
                    item.GetType().Name + ")");
                ListControls(lst, item.DropDown, indent + 4);
            }
            else if (parent is ToolStripItem)
            {
                ToolStripItem item = parent as ToolStripItem;
                lst.Items.Add(spaces +
                    item.Name + " (" +
                    item.GetType().Name + ")");
            }
            else if (parent is Control)
            {
                Control control = parent as Control;
                lst.Items.Add(spaces +
                    control.Name + " (" +
                    control.GetType().Name + ")");
                foreach (Control child in control.Controls)
                {
                    ListControls(lst, child, indent + 4);
                }
            }
        }

        // List the controls in a TreeView.
        private void ListControls(TreeNodeCollection nodes, Object parent)
        {
            if (parent is ToolStrip)
            {
                // Note that a StatusStrip is also a ToolStrip.
                ToolStrip tool_strip = parent as ToolStrip;
                TreeNode new_node = nodes.Add(
                    tool_strip.Name + " (" +
                    tool_strip.GetType().Name + ")");
                foreach (ToolStripItem item in tool_strip.Items)
                {
                    ListControls(new_node.Nodes, item);
                }
            }
            else if (parent is ToolStripDropDownButton)
            {
                // ToolStripDropDownButton inherits from ToolStripItem
                // so it must come first in this if-else-if sequence.
                ToolStripDropDownButton dropdown_button =
                    parent as ToolStripDropDownButton;
                TreeNode new_node = nodes.Add(
                    dropdown_button.Name + " (" +
                    dropdown_button.GetType().Name + ")");
                ListControls(new_node.Nodes, dropdown_button.DropDown);
            }
            else if (parent is ToolStripSplitButton)
            {
                // ToolStripSplitButton inherits from ToolStripItem
                // so it must come first in this if-else-if sequence.
                ToolStripSplitButton split_button =
                    parent as ToolStripSplitButton;
                TreeNode new_node = nodes.Add(
                    split_button.Name + " (" +
                    split_button.GetType().Name + ")");
                ListControls(new_node.Nodes, split_button.DropDown);
            }
            else if (parent is ToolStripMenuItem)
            {
                // ToolStripMenuItem inherits from ToolStripItem
                // so it must come first in this if-else-if sequence.
                ToolStripMenuItem item = parent as ToolStripMenuItem;
                TreeNode new_node = nodes.Add(
                    item.Name + " (" +
                    item.GetType().Name + ")");
                ListControls(new_node.Nodes, item.DropDown);
            }
            else if (parent is ToolStripItem)
            {
                ToolStripItem item = parent as ToolStripItem;
                TreeNode new_node = nodes.Add(
                    item.Name + " (" +
                    item.GetType().Name + ")");
            }
            else if (parent is Control)
            {
                Control control = parent as Control;
                TreeNode new_node = nodes.Add(
                    control.Name + " (" +
                    control.GetType().Name + ")");
                foreach (Control child in control.Controls)
                {
                    ListControls(new_node.Nodes, child);
                }
            }
        }

        // Set a tool strip item's image to match the clicked tool.
        private void btnTool_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            item.OwnerItem.Image = item.Image;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_list_controls_Form1));
            this.grpName = new System.Windows.Forms.GroupBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.picSmiley = new System.Windows.Forms.PictureBox();
            this.lstAnimals = new System.Windows.Forms.ListBox();
            this.btnClickMe = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblTools = new System.Windows.Forms.ToolStripLabel();
            this.btnArrow = new System.Windows.Forms.ToolStripButton();
            this.btnRectangle = new System.Windows.Forms.ToolStripButton();
            this.splitColor = new System.Windows.Forms.ToolStripSplitButton();
            this.toolPink = new System.Windows.Forms.ToolStripMenuItem();
            this.toolLightGreen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolLightBlue = new System.Windows.Forms.ToolStripMenuItem();
            this.lstControls = new System.Windows.Forms.ListBox();
            this.trvControls = new System.Windows.Forms.TreeView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.blueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.blueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.greenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.redToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSources = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSourcesDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSourcesInternet = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabListView = new System.Windows.Forms.TabPage();
            this.tabTreeView = new System.Windows.Forms.TabPage();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.grpName.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSmiley)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabListView.SuspendLayout();
            this.tabTreeView.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpName
            // 
            this.grpName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpName.Controls.Add(this.txtLastName);
            this.grpName.Controls.Add(this.lblLastName);
            this.grpName.Controls.Add(this.txtFirstName);
            this.grpName.Controls.Add(this.lblFirstName);
            this.grpName.Location = new System.Drawing.Point(3, 3);
            this.grpName.Name = "grpName";
            this.grpName.Size = new System.Drawing.Size(198, 74);
            this.grpName.TabIndex = 0;
            this.grpName.TabStop = false;
            this.grpName.Text = "Name";
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.Location = new System.Drawing.Point(94, 45);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(98, 20);
            this.txtLastName.TabIndex = 3;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(18, 48);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(61, 13);
            this.lblLastName.TabIndex = 2;
            this.lblLastName.Text = "Last Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.Location = new System.Drawing.Point(94, 19);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(98, 20);
            this.txtFirstName.TabIndex = 1;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(18, 22);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(60, 13);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 84);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpName);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.picSmiley);
            this.splitContainer1.Panel2.Controls.Add(this.lstAnimals);
            this.splitContainer1.Size = new System.Drawing.Size(213, 181);
            this.splitContainer1.SplitterDistance = 97;
            this.splitContainer1.TabIndex = 1;
            // 
            // picSmiley
            // 
            this.picSmiley.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picSmiley.Image = Properties.Resources.Smiley;
            this.picSmiley.Location = new System.Drawing.Point(115, 3);
            this.picSmiley.Name = "picSmiley";
            this.picSmiley.Size = new System.Drawing.Size(93, 74);
            this.picSmiley.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSmiley.TabIndex = 4;
            this.picSmiley.TabStop = false;
            // 
            // lstAnimals
            // 
            this.lstAnimals.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstAnimals.FormattingEnabled = true;
            this.lstAnimals.IntegralHeight = false;
            this.lstAnimals.Items.AddRange(new object[] {
            "Ape",
            "Bear",
            "Cat",
            "Dog",
            "Eagle",
            "Frog",
            "Giraffe"});
            this.lstAnimals.Location = new System.Drawing.Point(3, 3);
            this.lstAnimals.Name = "lstAnimals";
            this.lstAnimals.Size = new System.Drawing.Size(106, 110);
            this.lstAnimals.TabIndex = 0;
            // 
            // btnClickMe
            // 
            this.btnClickMe.Location = new System.Drawing.Point(12, 55);
            this.btnClickMe.Name = "btnClickMe";
            this.btnClickMe.Size = new System.Drawing.Size(75, 23);
            this.btnClickMe.TabIndex = 2;
            this.btnClickMe.Text = "Click Me";
            this.btnClickMe.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileSources,
            this.toolStripSeparator1,
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(152, 22);
            this.mnuFileExit.Text = "E&xit";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTools,
            this.btnArrow,
            this.btnRectangle,
            this.splitColor});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(484, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblTools
            // 
            this.lblTools.Name = "lblTools";
            this.lblTools.Size = new System.Drawing.Size(38, 22);
            this.lblTools.Text = "Tools:";
            // 
            // btnArrow
            // 
            this.btnArrow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnArrow.Image = ((System.Drawing.Image)(resources.GetObject("btnArrow.Image")));
            this.btnArrow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnArrow.Name = "btnArrow";
            this.btnArrow.Size = new System.Drawing.Size(23, 22);
            this.btnArrow.Text = "toolStripButton1";
            // 
            // btnRectangle
            // 
            this.btnRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRectangle.Image = ((System.Drawing.Image)(resources.GetObject("btnRectangle.Image")));
            this.btnRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRectangle.Name = "btnRectangle";
            this.btnRectangle.Size = new System.Drawing.Size(23, 22);
            this.btnRectangle.Text = "toolStripButton2";
            // 
            // splitColor
            // 
            this.splitColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.splitColor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolPink,
            this.toolLightGreen,
            this.toolLightBlue});
            this.splitColor.Image = ((System.Drawing.Image)(resources.GetObject("splitColor.Image")));
            this.splitColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.splitColor.Name = "splitColor";
            this.splitColor.Size = new System.Drawing.Size(32, 22);
            this.splitColor.Text = "toolStripSplitButton1";
            // 
            // toolPink
            // 
            this.toolPink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolPink.Image = Properties.Resources.BgRed;
            this.toolPink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPink.Name = "toolPink";
            this.toolPink.Size = new System.Drawing.Size(132, 22);
            this.toolPink.Text = "Pink";
            this.toolPink.ToolTipText = "Pink";
            this.toolPink.BackColorChanged += new System.EventHandler(this.btnTool_Click);
            this.toolPink.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // toolLightGreen
            // 
            this.toolLightGreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolLightGreen.Image = Properties.Resources.BgGreen;
            this.toolLightGreen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolLightGreen.Name = "toolLightGreen";
            this.toolLightGreen.Size = new System.Drawing.Size(132, 22);
            this.toolLightGreen.Text = "LightGreen";
            this.toolLightGreen.ToolTipText = "Light Green";
            this.toolLightGreen.BackColorChanged += new System.EventHandler(this.btnTool_Click);
            this.toolLightGreen.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // toolLightBlue
            // 
            this.toolLightBlue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolLightBlue.Image = Properties.Resources.BgBlue;
            this.toolLightBlue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolLightBlue.Name = "toolLightBlue";
            this.toolLightBlue.Size = new System.Drawing.Size(132, 22);
            this.toolLightBlue.Text = "LightBlue";
            this.toolLightBlue.ToolTipText = "Light Blue";
            this.toolLightBlue.BackColorChanged += new System.EventHandler(this.btnTool_Click);
            this.toolLightBlue.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // lstControls
            // 
            this.lstControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstControls.FormattingEnabled = true;
            this.lstControls.IntegralHeight = false;
            this.lstControls.Location = new System.Drawing.Point(3, 3);
            this.lstControls.Name = "lstControls";
            this.lstControls.Size = new System.Drawing.Size(227, 181);
            this.lstControls.TabIndex = 5;
            // 
            // trvControls
            // 
            this.trvControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvControls.Location = new System.Drawing.Point(3, 3);
            this.trvControls.Name = "trvControls";
            this.trvControls.Size = new System.Drawing.Size(227, 181);
            this.trvControls.TabIndex = 6;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1,
            this.toolStripSplitButton1,
            this.toolStripDropDownButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 268);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(484, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blueToolStripMenuItem,
            this.greenToolStripMenuItem,
            this.redToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 20);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // blueToolStripMenuItem
            // 
            this.blueToolStripMenuItem.Image = Properties.Resources.BgBlue;
            this.blueToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.blueToolStripMenuItem.Name = "blueToolStripMenuItem";
            this.blueToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.blueToolStripMenuItem.Text = "Blue";
            this.blueToolStripMenuItem.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // greenToolStripMenuItem
            // 
            this.greenToolStripMenuItem.Image = Properties.Resources.BgGreen;
            this.greenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.greenToolStripMenuItem.Name = "greenToolStripMenuItem";
            this.greenToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.greenToolStripMenuItem.Text = "Green";
            this.greenToolStripMenuItem.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // redToolStripMenuItem
            // 
            this.redToolStripMenuItem.Image = Properties.Resources.BgRed;
            this.redToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redToolStripMenuItem.Name = "redToolStripMenuItem";
            this.redToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.redToolStripMenuItem.Text = "Red";
            this.redToolStripMenuItem.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blueToolStripMenuItem1,
            this.greenToolStripMenuItem1,
            this.redToolStripMenuItem1});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 20);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // blueToolStripMenuItem1
            // 
            this.blueToolStripMenuItem1.Image = Properties.Resources.BgBlue;
            this.blueToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.blueToolStripMenuItem1.Name = "blueToolStripMenuItem1";
            this.blueToolStripMenuItem1.Size = new System.Drawing.Size(105, 22);
            this.blueToolStripMenuItem1.Text = "Blue";
            this.blueToolStripMenuItem1.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // greenToolStripMenuItem1
            // 
            this.greenToolStripMenuItem1.Image = Properties.Resources.BgGreen;
            this.greenToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.greenToolStripMenuItem1.Name = "greenToolStripMenuItem1";
            this.greenToolStripMenuItem1.Size = new System.Drawing.Size(105, 22);
            this.greenToolStripMenuItem1.Text = "Green";
            this.greenToolStripMenuItem1.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // redToolStripMenuItem1
            // 
            this.redToolStripMenuItem1.Image = Properties.Resources.BgRed;
            this.redToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redToolStripMenuItem1.Name = "redToolStripMenuItem1";
            this.redToolStripMenuItem1.Size = new System.Drawing.Size(105, 22);
            this.redToolStripMenuItem1.Text = "Red";
            this.redToolStripMenuItem1.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // mnuFileSources
            // 
            this.mnuFileSources.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileSourcesDatabase,
            this.mnuFileSourcesInternet});
            this.mnuFileSources.Name = "mnuFileSources";
            this.mnuFileSources.Size = new System.Drawing.Size(152, 22);
            this.mnuFileSources.Text = "&Sources";
            // 
            // mnuFileSourcesDatabase
            // 
            this.mnuFileSourcesDatabase.Name = "mnuFileSourcesDatabase";
            this.mnuFileSourcesDatabase.Size = new System.Drawing.Size(152, 22);
            this.mnuFileSourcesDatabase.Text = "&Database";
            // 
            // mnuFileSourcesInternet
            // 
            this.mnuFileSourcesInternet.Name = "mnuFileSourcesInternet";
            this.mnuFileSourcesInternet.Size = new System.Drawing.Size(152, 22);
            this.mnuFileSourcesInternet.Text = "&Internet";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabListView);
            this.tabControl1.Controls.Add(this.tabTreeView);
            this.tabControl1.Location = new System.Drawing.Point(231, 52);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(241, 213);
            this.tabControl1.TabIndex = 9;
            // 
            // tabListView
            // 
            this.tabListView.Controls.Add(this.lstControls);
            this.tabListView.Location = new System.Drawing.Point(4, 22);
            this.tabListView.Name = "tabListView";
            this.tabListView.Padding = new System.Windows.Forms.Padding(3);
            this.tabListView.Size = new System.Drawing.Size(233, 187);
            this.tabListView.TabIndex = 0;
            this.tabListView.Text = "ListView";
            this.tabListView.UseVisualStyleBackColor = true;
            // 
            // tabTreeView
            // 
            this.tabTreeView.Controls.Add(this.trvControls);
            this.tabTreeView.Location = new System.Drawing.Point(4, 22);
            this.tabTreeView.Name = "tabTreeView";
            this.tabTreeView.Padding = new System.Windows.Forms.Padding(3);
            this.tabTreeView.Size = new System.Drawing.Size(233, 187);
            this.tabTreeView.TabIndex = 1;
            this.tabTreeView.Text = "TreeView";
            this.tabTreeView.UseVisualStyleBackColor = true;
            // 
            // howto_list_controls_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 290);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnClickMe);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_list_controls_Form1";
            this.Text = "howto_list_controls";
            this.Load += new System.EventHandler(this.howto_list_controls_Form1_Load);
            this.grpName.ResumeLayout(false);
            this.grpName.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSmiley)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabListView.ResumeLayout(false);
            this.tabTreeView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lstAnimals;
        private System.Windows.Forms.Button btnClickMe;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.PictureBox picSmiley;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel lblTools;
        private System.Windows.Forms.ToolStripButton btnArrow;
        private System.Windows.Forms.ToolStripButton btnRectangle;
        private System.Windows.Forms.ToolStripSplitButton splitColor;
        private System.Windows.Forms.ToolStripMenuItem toolPink;
        private System.Windows.Forms.ToolStripMenuItem toolLightGreen;
        private System.Windows.Forms.ToolStripMenuItem toolLightBlue;
        private System.Windows.Forms.ListBox lstControls;
        private System.Windows.Forms.TreeView trvControls;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem blueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem blueToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem greenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem redToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSources;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSourcesDatabase;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSourcesInternet;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabListView;
        private System.Windows.Forms.TabPage tabTreeView;
        private System.Windows.Forms.Timer timer1;
    }
}

