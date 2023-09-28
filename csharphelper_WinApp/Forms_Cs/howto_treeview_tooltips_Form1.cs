using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_treeview_tooltips;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_treeview_tooltips_Form1:Form
  { 


        public howto_treeview_tooltips_Form1()
        {
            InitializeComponent();
        }

        // Build the TreeView.
        private void howto_treeview_tooltips_Form1_Load(object sender, EventArgs e)
        {
            const int imFactory = 0;
            const int imGroup = 1;
            const int imPerson = 2;

            // Load TreeView data.
            TreeNode factory, group, person;
            factory = AddTreeViewNode(trvOrg.Nodes, "R & D", imFactory, new FactoryData("Factory: R & D"));
            group = AddTreeViewNode(factory.Nodes, "Engineering", imGroup, new GroupData("Group: Engineering"));
            person = AddTreeViewNode(group.Nodes, "Cameron, Charlie", imPerson, new PersonData("Person: Cameron, Charlie", "Alpha", "Beta"));
            person = AddTreeViewNode(group.Nodes, "Davis, Debbie", imPerson, new PersonData("Person: Davos, Debbie", "Alpha", "Gamma"));

            group = AddTreeViewNode(factory.Nodes, "Test", imGroup, new GroupData("Group: Test"));
            person = AddTreeViewNode(group.Nodes, "Able, Andy", imPerson, new PersonData("Person: Able, Andy", "SPCD", "Feldspar", "Flicker"));
            person = AddTreeViewNode(group.Nodes, "Baker, Betty", imPerson, new PersonData("Person: Baker, Betty", "Pickle"));

            factory = AddTreeViewNode(trvOrg.Nodes, "Sales & Support", imFactory, new FactoryData("Factory: Sales & Support"));
            group = AddTreeViewNode(factory.Nodes, "Showroom Sales", imGroup, new GroupData("Group: Showroom Sales"));
            person = AddTreeViewNode(group.Nodes, "Gaines, Gina", imPerson, new PersonData("Person: Gaines, Gina", "SalesForce1"));

            group = AddTreeViewNode(factory.Nodes, "Field Service", imGroup, new GroupData("Group: Field Service"));
            person = AddTreeViewNode(group.Nodes, "Helms, Harry", imPerson, new PersonData("Person: Helms, Harry", "Bookster", "Tetrup"));
            person = AddTreeViewNode(group.Nodes, "Ives, Irma", imPerson, new PersonData("Person: Ives, Irma"));
            person = AddTreeViewNode(group.Nodes, "Jackson, Josh", imPerson, new PersonData("Person: Jackson, Josh", "MicroCosmos"));

            group = AddTreeViewNode(factory.Nodes, "Customer Support", imGroup, new GroupData("Group: Customer Support"));
            person = AddTreeViewNode(group.Nodes, "Klug, Karl", imPerson, new PersonData("Person: Klug, Karl", "MicroCosmos", "Anabash"));
            person = AddTreeViewNode(group.Nodes, "Landau, Linda", imPerson, new PersonData("Person: Landau, Linda", "Wintegration"));

            trvOrg.ExpandAll();
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

        // Display the appropriate tooltip.
        private TreeNode old_node = null;
        private void trvOrg_MouseMove(object sender, MouseEventArgs e)
        {
            // Find the node under the mouse.
            TreeNode node_here = trvOrg.GetNodeAt(e.X, e.Y);
            if (node_here == old_node) return;
            old_node = node_here;

            // See if we have a node.
            if (old_node == null)
            {
                ttOrg.SetToolTip(trvOrg, "");
            }
            else
            {
                // Get this node's object data.
                if (node_here.Tag is FactoryData)
                {
                    FactoryData factory_data = node_here.Tag as FactoryData;
                    ttOrg.SetToolTip(trvOrg, factory_data.Name);
                }
                else if (node_here.Tag is GroupData)
                {
                    GroupData group_data = node_here.Tag as GroupData;
                    ttOrg.SetToolTip(trvOrg, group_data.Name);
                }
                else if (node_here.Tag is PersonData)
                {
                    PersonData person_data = node_here.Tag as PersonData;
                    ttOrg.SetToolTip(trvOrg, person_data.Name);
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_treeview_tooltips_Form1));
            this.ttOrg = new System.Windows.Forms.ToolTip(this.components);
            this.imlTree = new System.Windows.Forms.ImageList(this.components);
            this.trvOrg = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // imlTree
            // 
            this.imlTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlTree.ImageStream")));
            this.imlTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imlTree.Images.SetKeyName(0, "");
            this.imlTree.Images.SetKeyName(1, "");
            this.imlTree.Images.SetKeyName(2, "");
            // 
            // trvOrg
            // 
            this.trvOrg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvOrg.ImageIndex = 0;
            this.trvOrg.ImageList = this.imlTree;
            this.trvOrg.Location = new System.Drawing.Point(0, 0);
            this.trvOrg.Name = "trvOrg";
            this.trvOrg.SelectedImageIndex = 0;
            this.trvOrg.Size = new System.Drawing.Size(251, 293);
            this.trvOrg.TabIndex = 2;
            this.trvOrg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.trvOrg_MouseMove);
            // 
            // howto_treeview_tooltips_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 293);
            this.Controls.Add(this.trvOrg);
            this.Name = "howto_treeview_tooltips_Form1";
            this.Text = "howto_treeview_tooltips";
            this.Load += new System.EventHandler(this.howto_treeview_tooltips_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ToolTip ttOrg;
        internal System.Windows.Forms.ImageList imlTree;
        internal System.Windows.Forms.TreeView trvOrg;
    }
}

