using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_treeview_option_pages;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_treeview_option_pages_Form1:Form
  { 


        public howto_treeview_option_pages_Form1()
        {
            InitializeComponent();
        }

        List<Panel> Panels = new List<Panel>();
        Panel VisiblePanel = null;

        private void howto_treeview_option_pages_Form1_Load(object sender, EventArgs e)
        {
            // Load saved values.
            RegistryTools.LoadAllSettings(Application.ProductName, this);

            // Expand all tree nodes.
            treeView1.ExpandAll();

            // Move the Panels out of the TabControl.
            tabControl1.Visible = false;
            foreach (TabPage page in tabControl1.TabPages)
            {
                // Add the Panel to the list.
                Panel panel = page.Controls[0] as Panel;
                Panels.Add(panel);

                // Reparent and move the Panel.
                panel.Parent = tabControl1.Parent;
                panel.Location = tabControl1.Location;
                panel.Visible = false;
            }

            // Display the first panel.
            DisplayPanel(0);
        }

        private void howto_treeview_option_pages_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegistryTools.SaveAllSettings(Application.ProductName, this);
        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            lblVbar1.Text = vScrollBar1.Value.ToString();
        }

        private void vScrollBar2_ValueChanged(object sender, EventArgs e)
        {
            lblVbar2.Text = vScrollBar2.Value.ToString();
        }

        private void vScrollBar3_ValueChanged(object sender, EventArgs e)
        {
            lblVbar3.Text = vScrollBar3.Value.ToString();
        }

        // Display the appropriate Panel.
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int index = int.Parse(e.Node.Tag.ToString());
            DisplayPanel(index);
        }

        // Display the appropriate Panel.
        private void DisplayPanel(int index)
        {
            if (Panels.Count < 1) return;

            // If this is the same Panel, do nothing.
            if (VisiblePanel == Panels[index]) return;

            // Hide the previously visible Panel.
            if (VisiblePanel != null) VisiblePanel.Visible = false;

            // Display the appropriate Panel.
            Panels[index].Visible = true;
            VisiblePanel = Panels[index];
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("General");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Documents");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Environment", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("General");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Defaults");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Projects", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("All Languages");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("General");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Tabs");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Advanced");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("C#", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("General");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Tabs");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Advanced");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Visual Basic", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Text Editor", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode11,
            treeNode15});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panPages = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.lblVbar3 = new System.Windows.Forms.Label();
            this.lblVbar1 = new System.Windows.Forms.Label();
            this.vScrollBar3 = new System.Windows.Forms.VScrollBar();
            this.vScrollBar2 = new System.Windows.Forms.VScrollBar();
            this.lblVbar2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.hScrollBar3 = new System.Windows.Forms.HScrollBar();
            this.hScrollBar2 = new System.Windows.Forms.HScrollBar();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.panel10 = new System.Windows.Forms.Panel();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.panPages.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.panel9.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.panel10.SuspendLayout();
            this.tabPage11.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Location = new System.Drawing.Point(5, 5);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node1";
            treeNode1.Tag = "0";
            treeNode1.Text = "General";
            treeNode2.Name = "Node2";
            treeNode2.Tag = "1";
            treeNode2.Text = "Documents";
            treeNode3.Name = "Node0";
            treeNode3.Tag = "0";
            treeNode3.Text = "Environment";
            treeNode4.Name = "Node5";
            treeNode4.Tag = "2";
            treeNode4.Text = "General";
            treeNode5.Name = "Node6";
            treeNode5.Tag = "3";
            treeNode5.Text = "Defaults";
            treeNode6.Name = "Node4";
            treeNode6.Tag = "2";
            treeNode6.Text = "Projects";
            treeNode7.Name = "Node8";
            treeNode7.Tag = "4";
            treeNode7.Text = "All Languages";
            treeNode8.Name = "Node12";
            treeNode8.Tag = "5";
            treeNode8.Text = "General";
            treeNode9.Name = "Node13";
            treeNode9.Tag = "6";
            treeNode9.Text = "Tabs";
            treeNode10.Name = "Node14";
            treeNode10.Tag = "7";
            treeNode10.Text = "Advanced";
            treeNode11.Name = "Node9";
            treeNode11.Tag = "5";
            treeNode11.Text = "C#";
            treeNode12.Name = "Node15";
            treeNode12.Tag = "8";
            treeNode12.Text = "General";
            treeNode13.Name = "Node16";
            treeNode13.Tag = "9";
            treeNode13.Text = "Tabs";
            treeNode14.Name = "Node17";
            treeNode14.Tag = "10";
            treeNode14.Text = "Advanced";
            treeNode15.Name = "Node11";
            treeNode15.Tag = "8";
            treeNode15.Text = "Visual Basic";
            treeNode16.Name = "Node7";
            treeNode16.Tag = "4";
            treeNode16.Text = "Text Editor";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6,
            treeNode16});
            this.treeView1.Size = new System.Drawing.Size(170, 391);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // panPages
            // 
            this.panPages.Controls.Add(this.tabControl1);
            this.panPages.Location = new System.Drawing.Point(3, 3);
            this.panPages.Name = "panPages";
            this.panPages.Size = new System.Drawing.Size(285, 382);
            this.panPages.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Controls.Add(this.tabPage10);
            this.tabControl1.Controls.Add(this.tabPage11);
            this.tabControl1.Location = new System.Drawing.Point(6, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(276, 367);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(268, 341);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.vScrollBar1);
            this.panel1.Controls.Add(this.lblVbar3);
            this.panel1.Controls.Add(this.lblVbar1);
            this.panel1.Controls.Add(this.vScrollBar3);
            this.panel1.Controls.Add(this.vScrollBar2);
            this.panel1.Controls.Add(this.lblVbar2);
            this.panel1.Location = new System.Drawing.Point(6, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 333);
            this.panel1.TabIndex = 6;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(21, 40);
            this.vScrollBar1.Maximum = 109;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 254);
            this.vScrollBar1.TabIndex = 0;
            this.vScrollBar1.ValueChanged += new System.EventHandler(this.vScrollBar1_ValueChanged);
            // 
            // lblVbar3
            // 
            this.lblVbar3.AutoSize = true;
            this.lblVbar3.Location = new System.Drawing.Point(107, 309);
            this.lblVbar3.Name = "lblVbar3";
            this.lblVbar3.Size = new System.Drawing.Size(35, 13);
            this.lblVbar3.TabIndex = 5;
            this.lblVbar3.Text = "label1";
            // 
            // lblVbar1
            // 
            this.lblVbar1.AutoSize = true;
            this.lblVbar1.Location = new System.Drawing.Point(18, 309);
            this.lblVbar1.Name = "lblVbar1";
            this.lblVbar1.Size = new System.Drawing.Size(35, 13);
            this.lblVbar1.TabIndex = 1;
            this.lblVbar1.Text = "label1";
            // 
            // vScrollBar3
            // 
            this.vScrollBar3.Location = new System.Drawing.Point(110, 40);
            this.vScrollBar3.Maximum = 109;
            this.vScrollBar3.Name = "vScrollBar3";
            this.vScrollBar3.Size = new System.Drawing.Size(17, 254);
            this.vScrollBar3.TabIndex = 4;
            this.vScrollBar3.ValueChanged += new System.EventHandler(this.vScrollBar3_ValueChanged);
            // 
            // vScrollBar2
            // 
            this.vScrollBar2.Location = new System.Drawing.Point(64, 40);
            this.vScrollBar2.Maximum = 109;
            this.vScrollBar2.Name = "vScrollBar2";
            this.vScrollBar2.Size = new System.Drawing.Size(17, 254);
            this.vScrollBar2.TabIndex = 2;
            this.vScrollBar2.ValueChanged += new System.EventHandler(this.vScrollBar2_ValueChanged);
            // 
            // lblVbar2
            // 
            this.lblVbar2.AutoSize = true;
            this.lblVbar2.Location = new System.Drawing.Point(61, 309);
            this.lblVbar2.Name = "lblVbar2";
            this.lblVbar2.Size = new System.Drawing.Size(35, 13);
            this.lblVbar2.TabIndex = 3;
            this.lblVbar2.Text = "label1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(268, 341);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtLastName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtFirstName);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(256, 333);
            this.panel2.TabIndex = 4;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(77, 78);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 20);
            this.txtLastName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Last Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(77, 52);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtFirstName.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(268, 341);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.numericUpDown1);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(256, 333);
            this.panel3.TabIndex = 5;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(33, 69);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(268, 341);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.hScrollBar1);
            this.panel4.Controls.Add(this.hScrollBar3);
            this.panel4.Controls.Add(this.hScrollBar2);
            this.panel4.Location = new System.Drawing.Point(6, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(256, 333);
            this.panel4.TabIndex = 5;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(17, 35);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(228, 17);
            this.hScrollBar1.TabIndex = 0;
            // 
            // hScrollBar3
            // 
            this.hScrollBar3.Location = new System.Drawing.Point(17, 91);
            this.hScrollBar3.Name = "hScrollBar3";
            this.hScrollBar3.Size = new System.Drawing.Size(228, 17);
            this.hScrollBar3.TabIndex = 2;
            // 
            // hScrollBar2
            // 
            this.hScrollBar2.Location = new System.Drawing.Point(17, 63);
            this.hScrollBar2.Name = "hScrollBar2";
            this.hScrollBar2.Size = new System.Drawing.Size(228, 17);
            this.hScrollBar2.TabIndex = 1;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.panel5);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(268, 341);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label3);
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(256, 333);
            this.panel5.TabIndex = 5;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.panel6);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(268, 341);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label4);
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(256, 333);
            this.panel6.TabIndex = 5;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.panel7);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(268, 341);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "tabPage7";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label5);
            this.panel7.Location = new System.Drawing.Point(6, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(256, 333);
            this.panel7.TabIndex = 5;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.panel8);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(268, 341);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "tabPage8";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label6);
            this.panel8.Location = new System.Drawing.Point(3, 5);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(256, 333);
            this.panel8.TabIndex = 5;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.panel9);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(268, 341);
            this.tabPage9.TabIndex = 8;
            this.tabPage9.Text = "tabPage9";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label7);
            this.panel9.Location = new System.Drawing.Point(3, 2);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(256, 333);
            this.panel9.TabIndex = 5;
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.panel10);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(268, 341);
            this.tabPage10.TabIndex = 9;
            this.tabPage10.Text = "tabPage10";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.label8);
            this.panel10.Location = new System.Drawing.Point(3, 3);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(256, 333);
            this.panel10.TabIndex = 5;
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.panel11);
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(268, 341);
            this.tabPage11.TabIndex = 10;
            this.tabPage11.Text = "tabPage11";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.label14);
            this.panel11.Controls.Add(this.label9);
            this.panel11.Location = new System.Drawing.Point(3, 2);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(256, 333);
            this.panel11.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.LightGreen;
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(256, 22);
            this.label10.TabIndex = 6;
            this.label10.Text = "Page 1";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.LightGreen;
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(256, 22);
            this.label11.TabIndex = 7;
            this.label11.Text = "Page 2";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.LightGreen;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(256, 22);
            this.label12.TabIndex = 7;
            this.label12.Text = "Page 3";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.LightGreen;
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(256, 22);
            this.label13.TabIndex = 7;
            this.label13.Text = "Page 4";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LightGreen;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(256, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "Page 5";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LightGreen;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(256, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "Page 6";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.LightGreen;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(256, 22);
            this.label5.TabIndex = 7;
            this.label5.Text = "Page 7";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.LightGreen;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(256, 22);
            this.label6.TabIndex = 7;
            this.label6.Text = "Page 8";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.LightGreen;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(256, 22);
            this.label7.TabIndex = 7;
            this.label7.Text = "Page 9";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.LightGreen;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(256, 22);
            this.label8.TabIndex = 7;
            this.label8.Text = "Page 10";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.LightGreen;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(256, 22);
            this.label9.TabIndex = 7;
            this.label9.Text = "Page 11";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel12
            // 
            this.panel12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel12.Controls.Add(this.panPages);
            this.panel12.Location = new System.Drawing.Point(181, 5);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(295, 391);
            this.panel12.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 100F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Blue;
            this.label14.Location = new System.Drawing.Point(3, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(250, 305);
            this.label14.TabIndex = 8;
            this.label14.Text = "11";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_treeview_option_pages_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 399);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.treeView1);
            this.Name = "howto_treeview_option_pages_Form1";
            this.Text = "howto_treeview_option_pages";
            this.Load += new System.EventHandler(this.howto_treeview_option_pages_Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_treeview_option_pages_Form1_FormClosing);
            this.panPages.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.tabPage10.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.tabPage11.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panPages;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.Label lblVbar3;
        private System.Windows.Forms.VScrollBar vScrollBar3;
        private System.Windows.Forms.Label lblVbar2;
        private System.Windows.Forms.VScrollBar vScrollBar2;
        private System.Windows.Forms.Label lblVbar1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.HScrollBar hScrollBar3;
        private System.Windows.Forms.HScrollBar hScrollBar2;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label14;
    }
}

