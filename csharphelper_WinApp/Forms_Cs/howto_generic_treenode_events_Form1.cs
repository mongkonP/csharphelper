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

 

using howto_generic_treenode_events;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_generic_treenode_events_Form1:Form
  { 


        public howto_generic_treenode_events_Form1()
        {
            InitializeComponent();
        }

        // The root node.
        private TreeNode<CircleNode> root =
            new TreeNode<CircleNode>(new CircleNode("Root"));

        // Make a tree.
        private void howto_generic_treenode_events_Form1_Load(object sender, EventArgs e)
        {
            TreeNode<CircleNode> a_node =
                new TreeNode<CircleNode>(new CircleNode("A"));
            TreeNode<CircleNode> b_node =
                new TreeNode<CircleNode>(new CircleNode("B"));
            TreeNode<CircleNode> c_node =
                new TreeNode<CircleNode>(new CircleNode("C"));
            TreeNode<CircleNode> d_node =
                new TreeNode<CircleNode>(new CircleNode("D"));
            TreeNode<CircleNode> e_node =
                new TreeNode<CircleNode>(new CircleNode("E"));
            TreeNode<CircleNode> f_node =
                new TreeNode<CircleNode>(new CircleNode("F"));
            TreeNode<CircleNode> g_node =
                new TreeNode<CircleNode>(new CircleNode("G"));
            TreeNode<CircleNode> h_node =
                new TreeNode<CircleNode>(new CircleNode("H"));

            root.AddChild(a_node);
            root.AddChild(b_node);
            a_node.AddChild(c_node);
            a_node.AddChild(d_node);
            b_node.AddChild(e_node);
            b_node.AddChild(f_node);
            b_node.AddChild(g_node);
            e_node.AddChild(h_node);

            // Arrange the tree.
            ArrangeTree();
        }

        // Draw the tree.
        private void picTree_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            root.DrawTree(e.Graphics);
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
                root.Arrange(gr, ref xmin, ref ymin);

                // Arrange the tree again to center it horizontally.
                xmin = (this.ClientSize.Width - xmin) / 2;
                ymin = 10;
                root.Arrange(gr, ref xmin, ref ymin);
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
                lblNodeText.Text = SelectedNode.Data.Text;
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
                // Don't let the user delete the root node.
                // (The TreeNode class can't do that.)
                ctxNodeDelete.Enabled = (SelectedNode != root);

                // Display the context menu.
                ctxNode.Show(this, e.Location);
            }
        }

        // Set SelectedNode to the node under the mouse.
        private void FindNodeUnderMouse(PointF pt)
        {
            using (Graphics gr = picTree.CreateGraphics())
            {
                SelectedNode = root.NodeAtPoint(gr, pt);
            }
        }

        // Add a child to the selected node.
        private void ctxNodeAddChild_Click(object sender, EventArgs e)
        {
            howto_generic_treenode_events_NodeTextDialog dlg = new  howto_generic_treenode_events_NodeTextDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                TreeNode<CircleNode> child =
                    new TreeNode<CircleNode>(new CircleNode(dlg.txtNodeText.Text));
                SelectedNode.AddChild(child);

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
                root.DeleteNode(SelectedNode);

                // Rearrange the tree to show the new structure.
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
            this.ctxNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxNodeAddChild = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxNodeDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblNodeText = new System.Windows.Forms.ToolStripStatusLabel();
            this.picTree = new System.Windows.Forms.PictureBox();
            this.ctxNode.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTree)).BeginInit();
            this.SuspendLayout();
            // 
            // ctxNode
            // 
            this.ctxNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxNodeAddChild,
            this.ctxNodeDelete});
            this.ctxNode.Name = "ctxNode";
            this.ctxNode.Size = new System.Drawing.Size(149, 48);
            // 
            // ctxNodeAddChild
            // 
            this.ctxNodeAddChild.Name = "ctxNodeAddChild";
            this.ctxNodeAddChild.Size = new System.Drawing.Size(148, 22);
            this.ctxNodeAddChild.Text = "&Add Child...";
            this.ctxNodeAddChild.Click += new System.EventHandler(this.ctxNodeAddChild_Click);
            // 
            // ctxNodeDelete
            // 
            this.ctxNodeDelete.Name = "ctxNodeDelete";
            this.ctxNodeDelete.Size = new System.Drawing.Size(148, 22);
            this.ctxNodeDelete.Text = "&Delete Node...";
            this.ctxNodeDelete.Click += new System.EventHandler(this.ctxNodeDelete_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblNodeText});
            this.statusStrip1.Location = new System.Drawing.Point(0, 212);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(295, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblNodeText
            // 
            this.lblNodeText.Name = "lblNodeText";
            this.lblNodeText.Size = new System.Drawing.Size(0, 17);
            // 
            // picTree
            // 
            this.picTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picTree.Location = new System.Drawing.Point(0, 0);
            this.picTree.Name = "picTree";
            this.picTree.Size = new System.Drawing.Size(295, 212);
            this.picTree.TabIndex = 2;
            this.picTree.TabStop = false;
            this.picTree.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picTree_MouseMove);
            this.picTree.Resize += new System.EventHandler(this.picTree_Resize);
            this.picTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picTree_MouseDown);
            this.picTree.Paint += new System.Windows.Forms.PaintEventHandler(this.picTree_Paint);
            // 
            // howto_generic_treenode_events_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 234);
            this.Controls.Add(this.picTree);
            this.Controls.Add(this.statusStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "howto_generic_treenode_events_Form1";
            this.Text = "howto_generic_treenode_events";
            this.Load += new System.EventHandler(this.howto_generic_treenode_events_Form1_Load);
            this.Resize += new System.EventHandler(this.picTree_Resize);
            this.ctxNode.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTree)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip ctxNode;
        private System.Windows.Forms.ToolStripMenuItem ctxNodeAddChild;
        private System.Windows.Forms.ToolStripMenuItem ctxNodeDelete;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblNodeText;
        private System.Windows.Forms.PictureBox picTree;
    }
}

