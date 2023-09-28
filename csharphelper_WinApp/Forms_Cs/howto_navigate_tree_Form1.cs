using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Drawing.Text;

 

using howto_navigate_tree;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_navigate_tree_Form1:Form
  { 


        public howto_navigate_tree_Form1()
        {
            InitializeComponent();
        }

        // The root node.
        private TreeNode<CircleNode> Node0 =
            new TreeNode<CircleNode>(new CircleNode("0"));

        // Make a tree.
        private void howto_navigate_tree_Form1_Load(object sender, EventArgs e)
        {
            TreeNode<CircleNode> node1 =
                new TreeNode<CircleNode>(new CircleNode("1"));
            TreeNode<CircleNode> node2 =
                new TreeNode<CircleNode>(new CircleNode("2"));
            TreeNode<CircleNode> node3 =
                new TreeNode<CircleNode>(new CircleNode("3"));
            TreeNode<CircleNode> node4 =
                new TreeNode<CircleNode>(new CircleNode("4"));
            TreeNode<CircleNode> node5 =
                new TreeNode<CircleNode>(new CircleNode("5"));
            TreeNode<CircleNode> node6 =
                new TreeNode<CircleNode>(new CircleNode("6"));
            TreeNode<CircleNode> node10 =
                new TreeNode<CircleNode>(new CircleNode("10"));
            TreeNode<CircleNode> node13 =
                new TreeNode<CircleNode>(new CircleNode("13"));

            Node0.LeftChild = node1;
            Node0.RightChild = node2;
            node1.LeftChild = node3;
            node1.RightChild = node4;
            node2.LeftChild = node5;
            node2.RightChild = node6;
            node4.RightChild = node10;
            node6.LeftChild = node13;

            // Arrange the tree.
            ArrangeTree();
        }

        // Draw the tree.
        private void picTree_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            Node0.DrawTree(e.Graphics);
        }

        // Center the tree on the form.
        private void picTree_Resize(object sender, EventArgs e)
        {
            ArrangeTree();
        }
        private void ArrangeTree()
        {
            using (Graphics gr = picTree.CreateGraphics())
            {
                // Arrange the tree once to see how big it is.
                float xmin = 0, ymin = 0;
                Node0.Arrange(gr, ref xmin, ref ymin);

                // Arrange the tree again to center it horizontally.
                xmin = (this.ClientSize.Width - xmin) / 2;
                ymin = 10;
                Node0.Arrange(gr, ref xmin, ref ymin);
            }

            picTree.Refresh();
        }

        // The currently selected node.
        private TreeNode<CircleNode> SelectedNode;

        // Display the text of the node under the mouse.
        private void picTree_MouseMove(object sender, MouseEventArgs e)
        {
            // Find the node under the mouse.
            FindNodeUnderMouse(e.Location);

            // If there is a node under the mouse,
            // display the node's text.
            if (SelectedNode == null)
            {
                lblNodeText.Text = "";
            }
            else
            {
                lblNodeText.Text = "Node " +
                    SelectedNode.Data.Text + ": " +
                    SelectedNode.NodeNumber();
            }
        }

        // If this is a right button down and the
        // mouse is over a node, display a context menu.
        private void picTree_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            // Find the node under the mouse.
            FindNodeUnderMouse(e.Location);

            // If there is a node under the mouse,
            // display the context menu.
            if (SelectedNode != null)
            {
                // Don't let the user add a child if the
                // selected node already has two children.
                ctxNodeAddLeftChild.Enabled = (SelectedNode.LeftChild == null);
                ctxNodeAddRightChild.Enabled = (SelectedNode.RightChild == null);

                // Don't let the user delete the root node.
                // (The TreeNode class can't do that.)
                ctxNodeDelete.Enabled = (SelectedNode != Node0);

                // Display the context menu.
                ctxNode.Show(this, e.Location);
            }
        }

        // Set SelectedNode to the node under the mouse.
        private void FindNodeUnderMouse(PointF pt)
        {
            using (Graphics gr = picTree.CreateGraphics())
            {
                SelectedNode = Node0.NodeAtPoint(gr, pt);
            }
        }

        // Add a left child to the selected node.
        private void ctxNodeAddLeftChild_Click(object sender, EventArgs e)
        {
            howto_navigate_tree_NodeTextDialog dlg = new  howto_navigate_tree_NodeTextDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                TreeNode<CircleNode> child =
                    new TreeNode<CircleNode>(new CircleNode(dlg.txtNodeText.Text));
                SelectedNode.LeftChild = child;

                // Rearrange the tree to show the new node.
                ArrangeTree();
            }
        }

        // Add a right child to the selected node.
        private void ctxNodeAddRightChild_Click(object sender, EventArgs e)
        {
            howto_navigate_tree_NodeTextDialog dlg = new  howto_navigate_tree_NodeTextDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                TreeNode<CircleNode> child =
                    new TreeNode<CircleNode>(new CircleNode(dlg.txtNodeText.Text));
                SelectedNode.RightChild = child;

                // Rearrange the tree to show the new node.
                ArrangeTree();
            }
        }

        // Delete this node from the tree.
        private void ctxNodeDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this node?",
                "Delete Node?", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Delete the node and its subtree.
                Node0.DeleteNode(SelectedNode);

                // Rearrange the tree to show the new structure.
                ArrangeTree();
            }
        }

        // Find a node by number.
        private void mnuDataFindNode_Click(object sender, EventArgs e)
        {
            howto_navigate_tree_NodeTextDialog dlg = new  howto_navigate_tree_NodeTextDialog();
            dlg.Text = "Enter Node Number";
            dlg.lblPrompt.Text = "Node #:";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Clear any previously selected nodes.
                Node0.SetSubtreeBg(Brushes.White);

                // Find the indicated node.
                int number = int.Parse(dlg.txtNodeText.Text);
                TreeNode<CircleNode> selected_node =
                    Node0.FindNodeByNumber(number);

                // Mark the node.
                if (selected_node != null)
                    selected_node.BgBrush = Brushes.Pink;

                // Rearrange the tree to show the new node.
                ArrangeTree();
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
            this.picTree = new System.Windows.Forms.PictureBox();
            this.ctxNodeDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxNodeAddLeftChild = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblNodeText = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDataFindNode = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxNodeAddRightChild = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picTree)).BeginInit();
            this.ctxNode.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picTree
            // 
            this.picTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picTree.Location = new System.Drawing.Point(0, 24);
            this.picTree.Name = "picTree";
            this.picTree.Size = new System.Drawing.Size(295, 188);
            this.picTree.TabIndex = 4;
            this.picTree.TabStop = false;
            this.picTree.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picTree_MouseMove);
            this.picTree.Resize += new System.EventHandler(this.picTree_Resize);
            this.picTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picTree_MouseDown);
            this.picTree.Paint += new System.Windows.Forms.PaintEventHandler(this.picTree_Paint);
            // 
            // ctxNodeDelete
            // 
            this.ctxNodeDelete.Name = "ctxNodeDelete";
            this.ctxNodeDelete.Size = new System.Drawing.Size(167, 22);
            this.ctxNodeDelete.Text = "&Delete Node...";
            this.ctxNodeDelete.Click += new System.EventHandler(this.ctxNodeDelete_Click);
            // 
            // ctxNodeAddLeftChild
            // 
            this.ctxNodeAddLeftChild.Name = "ctxNodeAddLeftChild";
            this.ctxNodeAddLeftChild.Size = new System.Drawing.Size(167, 22);
            this.ctxNodeAddLeftChild.Text = "Add &Left Child...";
            this.ctxNodeAddLeftChild.Click += new System.EventHandler(this.ctxNodeAddLeftChild_Click);
            // 
            // ctxNode
            // 
            this.ctxNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxNodeAddLeftChild,
            this.ctxNodeAddRightChild,
            this.ctxNodeDelete});
            this.ctxNode.Name = "ctxNode";
            this.ctxNode.Size = new System.Drawing.Size(168, 92);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblNodeText});
            this.statusStrip1.Location = new System.Drawing.Point(0, 212);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(295, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblNodeText
            // 
            this.lblNodeText.Name = "lblNodeText";
            this.lblNodeText.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(295, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDataFindNode});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.dataToolStripMenuItem.Text = "&Data";
            // 
            // mnuDataFindNode
            // 
            this.mnuDataFindNode.Name = "mnuDataFindNode";
            this.mnuDataFindNode.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.mnuDataFindNode.Size = new System.Drawing.Size(178, 22);
            this.mnuDataFindNode.Text = "&Find Node...";
            this.mnuDataFindNode.Click += new System.EventHandler(this.mnuDataFindNode_Click);
            // 
            // ctxNodeAddRightChild
            // 
            this.ctxNodeAddRightChild.Name = "ctxNodeAddRightChild";
            this.ctxNodeAddRightChild.Size = new System.Drawing.Size(167, 22);
            this.ctxNodeAddRightChild.Text = "Add &Right Child...";
            this.ctxNodeAddRightChild.Click += new System.EventHandler(this.ctxNodeAddRightChild_Click);
            // 
            // howto_navigate_tree_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 234);
            this.Controls.Add(this.picTree);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "howto_navigate_tree_Form1";
            this.Text = "howto_navigate_tree";
            this.Load += new System.EventHandler(this.howto_navigate_tree_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picTree)).EndInit();
            this.ctxNode.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picTree;
        private System.Windows.Forms.ToolStripMenuItem ctxNodeDelete;
        private System.Windows.Forms.ToolStripMenuItem ctxNodeAddLeftChild;
        private System.Windows.Forms.ContextMenuStrip ctxNode;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblNodeText;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuDataFindNode;
        private System.Windows.Forms.ToolStripMenuItem ctxNodeAddRightChild;
    }
}

