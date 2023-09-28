using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_treeview_popups;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_treeview_popups_Form1:Form
  { 


        public howto_treeview_popups_Form1()
        {
            InitializeComponent();
        }

        private void howto_treeview_popups_Form1_Load(object sender, EventArgs e)
        {
            const int imFactory = 0;
            const int imGroup = 1;
            const int imPerson = 2;

            // Load TreeView data.
            TreeNode factory, group, person;
            factory = AddTreeViewNode(trvOrg.Nodes, "R & D", imFactory, new FactoryData("R & D"));
            group = AddTreeViewNode(factory.Nodes, "Engineering", imGroup, new GroupData("Engineering"));
            person = AddTreeViewNode(group.Nodes, "Cameron, Charlie", imPerson, new PersonData("Cameron, Charlie", "Alpha", "Beta"));
            person = AddTreeViewNode(group.Nodes, "Davos, Debbie", imPerson, new PersonData("Davos, Debbie", "Alpha", "Gamma"));
            person.EnsureVisible();
            group = AddTreeViewNode(factory.Nodes, "Test", imGroup, new GroupData("Test"));
            person = AddTreeViewNode(group.Nodes, "Able, Andy", imPerson, new PersonData("Able, Andy", "SPCD", "Feldspar", "Flicker"));
            person = AddTreeViewNode(group.Nodes, "Baker, Betty", imPerson, new PersonData("Baker, Betty", "Pickle"));
            person.EnsureVisible();
            factory = AddTreeViewNode(trvOrg.Nodes, "Sales & Support", imFactory, new FactoryData("Sales & Support"));
            group = AddTreeViewNode(factory.Nodes, "Showroom Sales", imGroup, new GroupData("Showroom Sales"));
            person = AddTreeViewNode(group.Nodes, "Gaines, Gina", imPerson, new PersonData("Gaines, Gina", "SalesForce1"));
            person.EnsureVisible();
            group = AddTreeViewNode(factory.Nodes, "Field Service", imGroup, new GroupData("Field Service"));
            person = AddTreeViewNode(group.Nodes, "Helms, Harry", imPerson, new PersonData("Helms, Harry", "Bookster", "Tetrup"));
            person = AddTreeViewNode(group.Nodes, "Ives, Irma", imPerson, new PersonData("Ives, Irma"));
            person = AddTreeViewNode(group.Nodes, "Jackson, Josh", imPerson, new PersonData("Jackson, Josh", "MicroCosmos"));
            person.EnsureVisible();
            group = AddTreeViewNode(factory.Nodes, "Customer Support", imGroup, new GroupData("Customer Support"));
            person = AddTreeViewNode(group.Nodes, "Klug, Karl", imPerson, new PersonData("Klug, Karl", "MicroCosmos", "Anabash"));
            person = AddTreeViewNode(group.Nodes, "Landau, Linda", imPerson, new PersonData("Landau, Linda", "Wintegration"));
            person.EnsureVisible();
        }

        // Add a new node to the collection.
        private TreeNode AddTreeViewNode(TreeNodeCollection parent_nodes, string text, int image_index, object tag_object)
        {
            TreeNode new_node = parent_nodes.Add(text);
            new_node.ImageIndex = image_index;
            new_node.SelectedImageIndex = image_index;
            new_node.Tag = tag_object;
            return new_node;
        }

        // Display the appropriate context menu.
        private void trvOrg_MouseDown(object sender, MouseEventArgs e)
        {
            // Make sure this is the right button.
            if (e.Button != MouseButtons.Right) return;

            // Select this node.
            TreeNode node_here = trvOrg.GetNodeAt(e.X, e.Y);
            trvOrg.SelectedNode = node_here;

            // See if we got a node.
            if (node_here == null) return;

            // See what kind of object this is and
            // display the appropriate popup menu.
            if (node_here.Tag is FactoryData)
                ctxFactory.Show(trvOrg, new Point(e.X, e.Y));
            else if (node_here.Tag is GroupData)
                ctxGroup.Show(trvOrg, new Point(e.X, e.Y));
            else if (node_here.Tag is PersonData)
                ctxPerson.Show(trvOrg, new Point(e.X, e.Y));
        }

        private void mnuFactoryDelete_Click(object sender, EventArgs e)
        {
            trvOrg.SelectedNode.Remove();
        }

        private void mnuGroupDelete_Click(object sender, EventArgs e)
        {
            trvOrg.SelectedNode.Remove();
        }

        private void mnuPersonDelete_Click(object sender, EventArgs e)
        {
            trvOrg.SelectedNode.Remove();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_treeview_popups_Form1));
            this.ctxPerson = new System.Windows.Forms.ContextMenu();
            this.mnuPersonDelete = new System.Windows.Forms.MenuItem();
            this.ctxGroup = new System.Windows.Forms.ContextMenu();
            this.mnuGroupDelete = new System.Windows.Forms.MenuItem();
            this.imlTree = new System.Windows.Forms.ImageList(this.components);
            this.mnuFactoryDelete = new System.Windows.Forms.MenuItem();
            this.trvOrg = new System.Windows.Forms.TreeView();
            this.ctxFactory = new System.Windows.Forms.ContextMenu();
            this.SuspendLayout();
            // 
            // ctxPerson
            // 
            this.ctxPerson.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuPersonDelete});
            // 
            // mnuPersonDelete
            // 
            this.mnuPersonDelete.Index = 0;
            this.mnuPersonDelete.Text = "Delete Person";
            this.mnuPersonDelete.Click += new System.EventHandler(this.mnuPersonDelete_Click);
            // 
            // ctxGroup
            // 
            this.ctxGroup.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuGroupDelete});
            // 
            // mnuGroupDelete
            // 
            this.mnuGroupDelete.Index = 0;
            this.mnuGroupDelete.Text = "Delete Group";
            this.mnuGroupDelete.Click += new System.EventHandler(this.mnuGroupDelete_Click);
            // 
            // imlTree
            // 
            this.imlTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlTree.ImageStream")));
            this.imlTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imlTree.Images.SetKeyName(0, "");
            this.imlTree.Images.SetKeyName(1, "");
            this.imlTree.Images.SetKeyName(2, "");
            // 
            // mnuFactoryDelete
            // 
            this.mnuFactoryDelete.Index = 0;
            this.mnuFactoryDelete.Text = "Delete Factory";
            this.mnuFactoryDelete.Click += new System.EventHandler(this.mnuFactoryDelete_Click);
            // 
            // trvOrg
            // 
            this.trvOrg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvOrg.ImageIndex = 0;
            this.trvOrg.ImageList = this.imlTree;
            this.trvOrg.Location = new System.Drawing.Point(0, 0);
            this.trvOrg.Name = "trvOrg";
            this.trvOrg.SelectedImageIndex = 0;
            this.trvOrg.Size = new System.Drawing.Size(251, 287);
            this.trvOrg.TabIndex = 2;
            this.trvOrg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trvOrg_MouseDown);
            // 
            // ctxFactory
            // 
            this.ctxFactory.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFactoryDelete});
            // 
            // howto_treeview_popups_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 287);
            this.Controls.Add(this.trvOrg);
            this.Name = "howto_treeview_popups_Form1";
            this.Text = "howto_treeview_popups";
            this.Load += new System.EventHandler(this.howto_treeview_popups_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ContextMenu ctxPerson;
        internal System.Windows.Forms.MenuItem mnuPersonDelete;
        internal System.Windows.Forms.ContextMenu ctxGroup;
        internal System.Windows.Forms.MenuItem mnuGroupDelete;
        internal System.Windows.Forms.ImageList imlTree;
        internal System.Windows.Forms.MenuItem mnuFactoryDelete;
        internal System.Windows.Forms.TreeView trvOrg;
        internal System.Windows.Forms.ContextMenu ctxFactory;
    }
}

