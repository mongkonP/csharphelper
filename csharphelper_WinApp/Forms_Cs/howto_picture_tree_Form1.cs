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

 

using howto_picture_tree;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_picture_tree_Form1:Form
  { 


        public howto_picture_tree_Form1()
        {
            InitializeComponent();
        }

        // The root node.
        private TreeNode<PictureNode> root =
            new TreeNode<PictureNode>(
                new PictureNode("Queen Elizabeth II && Prince Philip Duke of Edinburgh",
                    Properties.Resources.Elizabeth_Philip));

        // Make a tree.
        private void howto_picture_tree_Form1_Load(object sender, EventArgs e)
        {
            TreeNode<PictureNode> charles =
                new TreeNode<PictureNode>(
                    new PictureNode("Prince Charles, Prince of Wales",
                        Properties.Resources.Charles));
            TreeNode<PictureNode> anne =
                new TreeNode<PictureNode>(
                    new PictureNode("Princess Anne",
                        Properties.Resources.Anne));
            TreeNode<PictureNode> andrew =
                new TreeNode<PictureNode>(
                    new PictureNode("Prince Andrew, Duke of York",
                        Properties.Resources.Andrew));
            TreeNode<PictureNode> edward =
                new TreeNode<PictureNode>(
                    new PictureNode("Prince Edward, Earl of Wessex",
                        Properties.Resources.Edward));
            TreeNode<PictureNode> william =
                new TreeNode<PictureNode>(
                    new PictureNode("Prince William",
                        Properties.Resources.William));
            TreeNode<PictureNode> harry =
                new TreeNode<PictureNode>(
                    new PictureNode("Prince Henry (Harry)",
                        Properties.Resources.Harry));
            TreeNode<PictureNode> peter =
                new TreeNode<PictureNode>(
                    new PictureNode("Peter Phillips",
                        Properties.Resources.Peter));
            TreeNode<PictureNode> zara =
                new TreeNode<PictureNode>(
                    new PictureNode("Zara Phillips",
                        Properties.Resources.Zara));
            TreeNode<PictureNode> beatrice =
                new TreeNode<PictureNode>(
                    new PictureNode("Princess Beatrice",
                        Properties.Resources.Beatrice));
            TreeNode<PictureNode> eugenie =
                new TreeNode<PictureNode>(
                    new PictureNode("Princess Eugenie",
                        Properties.Resources.Eugenie));
            TreeNode<PictureNode> louise =
                new TreeNode<PictureNode>(
                    new PictureNode("Lady Louise",
                        Properties.Resources.Louise));
            TreeNode<PictureNode> severn =
                new TreeNode<PictureNode>(
                    new PictureNode("Viscount Severn",
                        Properties.Resources.Severn));

            root.AddChild(charles);
            charles.AddChild(william);
            charles.AddChild(harry);
            root.AddChild(anne);
            anne.AddChild(peter);
            anne.AddChild(zara);
            root.AddChild(andrew);
            andrew.AddChild(beatrice);
            andrew.AddChild(eugenie);
            root.AddChild(edward);
            edward.AddChild(louise);
            edward.AddChild(severn);

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
        private TreeNode<PictureNode> SelectedNode;

        private void picTree_MouseClick(object sender, MouseEventArgs e)
        {
            FindNodeUnderMouse(e.Location);
        }

        // Set SelectedNode to the node under the mouse.
        private void FindNodeUnderMouse(PointF pt)
        {
            // Deselect the previously selected node.
            if (SelectedNode != null)
            {
                SelectedNode.Data.Selected = false;
                lblNodeText.Text = "";
            }

            // Find the node at this position (if any).
            using (Graphics gr = picTree.CreateGraphics())
            {
                SelectedNode = root.NodeAtPoint(gr, pt);
            }

            // Select the node.
            if (SelectedNode != null)
            {
                SelectedNode.Data.Selected = true;
                lblNodeText.Text = SelectedNode.Data.Description;
            }

            // Redraw.
            picTree.Refresh();
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
            this.picTree = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblNodeText = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picTree)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picTree
            // 
            this.picTree.BackColor = System.Drawing.Color.LightGray;
            this.picTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picTree.Location = new System.Drawing.Point(0, 0);
            this.picTree.Name = "picTree";
            this.picTree.Size = new System.Drawing.Size(864, 339);
            this.picTree.TabIndex = 6;
            this.picTree.TabStop = false;
            this.picTree.Resize += new System.EventHandler(this.picTree_Resize);
            this.picTree.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picTree_MouseClick);
            this.picTree.Paint += new System.Windows.Forms.PaintEventHandler(this.picTree_Paint);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblNodeText});
            this.statusStrip1.Location = new System.Drawing.Point(0, 339);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(864, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblNodeText
            // 
            this.lblNodeText.Name = "lblNodeText";
            this.lblNodeText.Size = new System.Drawing.Size(0, 17);
            // 
            // howto_picture_tree_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 361);
            this.Controls.Add(this.picTree);
            this.Controls.Add(this.statusStrip1);
            this.Name = "howto_picture_tree_Form1";
            this.Text = "howto_picture_tree";
            this.Load += new System.EventHandler(this.howto_picture_tree_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picTree)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picTree;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblNodeText;
    }
}

