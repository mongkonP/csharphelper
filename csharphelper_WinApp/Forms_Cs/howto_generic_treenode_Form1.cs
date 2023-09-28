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

 

using howto_generic_treenode;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_generic_treenode_Form1:Form
  { 


        public howto_generic_treenode_Form1()
        {
            InitializeComponent();
        }

        // The root node.
        private TreeNode<CircleNode> root =
            new TreeNode<CircleNode>(new CircleNode("Root"));

        // Build the tree.
        private void howto_generic_treenode_Form1_Load(object sender, EventArgs e)
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
        private void howto_generic_treenode_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            root.DrawTree(e.Graphics);
        }

        // Arrange the tree to center it.
        private void howto_generic_treenode_Form1_Resize(object sender, EventArgs e)
        {
            ArrangeTree();
        }
        private void ArrangeTree()
        {
            using (Graphics gr = this.CreateGraphics())
            {
                // Arrange the tree once to see how big it is.
                float xmin = 0, ymin = 0;
                root.Arrange(gr, ref xmin, ref ymin);

                // Arrange the tree again to center it.
                xmin = (this.ClientSize.Width - xmin) / 2;
                ymin = (this.ClientSize.Height - ymin) / 2;
                root.Arrange(gr, ref xmin, ref ymin);
            }

            // Redraw.
            this.Refresh();
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
            this.SuspendLayout();
            // 
            // howto_generic_treenode_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 185);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "howto_generic_treenode_Form1";
            this.Text = "howto_generic_treenode";
            this.Load += new System.EventHandler(this.howto_generic_treenode_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_generic_treenode_Form1_Paint);
            this.Resize += new System.EventHandler(this.howto_generic_treenode_Form1_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

