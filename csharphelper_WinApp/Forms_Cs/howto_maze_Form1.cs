using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

using howto_maze;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_maze_Form1:Form
  { 


        public howto_maze_Form1()
        {
            InitializeComponent();
        }

        private int Xmin, Ymin, CellWid, CellHgt;

        private void btnCreate_Click(object sender, EventArgs e)
        {
            // Figure out the drawing geometry.
            int wid = int.Parse(txtWidth.Text);
            int hgt = int.Parse(txtHeight.Text);

            CellWid = picMaze.ClientSize.Width / (wid + 2);
            CellHgt = picMaze.ClientSize.Height / (hgt + 2);
            if (CellWid > CellHgt) CellWid = CellHgt;
            else CellHgt = CellWid;
            Xmin = (picMaze.ClientSize.Width - wid * CellWid) / 2;
            Ymin = (picMaze.ClientSize.Height - hgt * CellHgt) / 2;

            // Build the maze nodes.
            MazeNode[,] nodes = MakeNodes(wid, hgt);

            // Build the spanning tree.
            FindSpanningTree(nodes[0, 0]);

            // Display the maze.
            DisplayMaze(nodes);
        }

        // Make the network of MazeNodes.
        private MazeNode[,] MakeNodes(int wid, int hgt)
        {
            // Make the nodes.
            MazeNode[,] nodes = new MazeNode[hgt, wid];
            for (int r = 0; r < hgt; r++)
            {
                int y = Ymin + CellHgt * r;
                for (int c = 0; c < wid; c++)
                {
                    int x = Xmin + CellWid * c;
                    nodes[r, c] = new MazeNode(
                        x, y, CellWid, CellHgt);
                }
            }

            // Initialize the nodes' neighbors.
            for (int r = 0; r < hgt; r++)
            {
                for (int c = 0; c < wid; c++)
                {
                    if (r > 0)
                        nodes[r, c].Neighbors[MazeNode.North] = nodes[r - 1, c];
                    if (r < hgt - 1)
                        nodes[r, c].Neighbors[MazeNode.South] = nodes[r + 1, c];
                    if (c > 0)
                        nodes[r, c].Neighbors[MazeNode.West] = nodes[r, c - 1];
                    if (c < wid - 1)
                        nodes[r, c].Neighbors[MazeNode.East] = nodes[r, c + 1];
                }
            }

            // Return the nodes.
            return nodes;
        }

        // Build a spanning tree with the indicated root node.
        private void FindSpanningTree(MazeNode root)
        {
            Random rand = new Random();

            // Set the root node's predecessor so we know it's in the tree.
            root.Predecessor = root;

            // Make a list of candidate links.
            List<MazeLink> links = new List<MazeLink>();

            // Add the root's links to the links list.
            foreach (MazeNode neighbor in root.Neighbors)
            {
                if (neighbor != null)
                    links.Add(new MazeLink(root, neighbor));
            }

            // Add the other nodes to the tree.
            while (links.Count > 0)
            {
                // Pick a random link.
                int link_num = rand.Next(0, links.Count);
                MazeLink link = links[link_num];
                links.RemoveAt(link_num);

                // Add this link to the tree.
                MazeNode to_node = link.ToNode;
                link.ToNode.Predecessor = link.FromNode;

                // Remove any links from the list that point
                // to nodes that are already in the tree.
                // (That will be the newly added node.)
                for (int i = links.Count - 1; i >= 0; i--)
                {
                    if (links[i].ToNode.Predecessor != null)
                        links.RemoveAt(i);
                }

                // Add to_node's links to the links list.
                foreach (MazeNode neighbor in to_node.Neighbors)
                {
                    if ((neighbor != null) && (neighbor.Predecessor == null))
                        links.Add(new MazeLink(to_node, neighbor));
                }
            }
        }

        // Display the maze in the picMaze PictureBox.
        private void DisplayMaze(MazeNode[,] nodes)
        {
            int hgt = nodes.GetUpperBound(0) + 1;
            int wid = nodes.GetUpperBound(1) + 1;
            Bitmap bm = new Bitmap(
                picMaze.ClientSize.Width,
                picMaze.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                for (int r = 0; r < hgt; r++)
                {
                    for (int c = 0; c < wid; c++)
                    {
                        //nodes[r, c].DrawCenter(gr, Brushes.Red);
                        nodes[r, c].DrawWalls(gr, Pens.Black);
                        //nodes[r, c].DrawNeighborLinks(gr, Pens.Black);
                        //nodes[r, c].DrawBoundingBox(gr, Pens.Blue);
                        //nodes[r, c].DrawPredecessorLink(gr, Pens.LightGray);
                    }
                }
            }

            picMaze.Image = bm;
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.picMaze = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picMaze)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Width:";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(59, 12);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(35, 20);
            this.txtWidth.TabIndex = 1;
            this.txtWidth.Text = "15";
            this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(59, 38);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(35, 20);
            this.txtHeight.TabIndex = 3;
            this.txtHeight.Text = "10";
            this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Height:";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(114, 25);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 4;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // picMaze
            // 
            this.picMaze.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picMaze.BackColor = System.Drawing.Color.White;
            this.picMaze.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picMaze.Location = new System.Drawing.Point(12, 64);
            this.picMaze.Name = "picMaze";
            this.picMaze.Size = new System.Drawing.Size(340, 240);
            this.picMaze.TabIndex = 5;
            this.picMaze.TabStop = false;
            // 
            // howto_maze_Form1
            // 
            this.AcceptButton = this.btnCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 316);
            this.Controls.Add(this.picMaze);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.label1);
            this.Name = "howto_maze_Form1";
            this.Text = "howto_maze";
            ((System.ComponentModel.ISupportInitialize)(this.picMaze)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.PictureBox picMaze;
    }
}

