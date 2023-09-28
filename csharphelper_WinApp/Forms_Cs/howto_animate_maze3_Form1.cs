using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Threading;

 

using howto_animate_maze3;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_animate_maze3_Form1:Form
  { 


        public howto_animate_maze3_Form1()
        {
            InitializeComponent();
        }

        private int Xmin, Ymin, CellWid, CellHgt, NumRows, NumCols;
        private MazeNode[,] Nodes = null;
        private MazeNode StartNode = null, EndNode = null;

        private List<MazeNode> Path = null;
        private List<int> LastUsedNeighbor = null;

        private void btnCreate_Click(object sender, EventArgs e)
        {
            tmrStep.Enabled = false;

            // Figure out the drawing geometry.
            NumCols = int.Parse(txtWidth.Text);
            NumRows = int.Parse(txtHeight.Text);

            CellWid = picMaze.ClientSize.Width / (NumCols + 2);
            CellHgt = picMaze.ClientSize.Height / (NumRows + 2);
            if (CellWid > CellHgt) CellWid = CellHgt;
            else CellHgt = CellWid;
            Xmin = (picMaze.ClientSize.Width - NumCols * CellWid) / 2;
            Ymin = (picMaze.ClientSize.Height - NumRows * CellHgt) / 2;

            // Build the maze nodes.
            Nodes = MakeNodes(NumCols, NumRows);

            // Clear any previous path and the start and end nodes.
            Path = null;
            LastUsedNeighbor = null;
            StartNode = null;
            EndNode = null;

            // Build the spanning tree.
            FindSpanningTree(Nodes[0, 0]);

            // Display the maze.
            DisplayMaze(Nodes);
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
                        nodes[r, c].AdjacentNodes[MazeNode.North] = nodes[r - 1, c];
                    if (r < hgt - 1)
                        nodes[r, c].AdjacentNodes[MazeNode.South] = nodes[r + 1, c];
                    if (c > 0)
                        nodes[r, c].AdjacentNodes[MazeNode.West] = nodes[r, c - 1];
                    if (c < wid - 1)
                        nodes[r, c].AdjacentNodes[MazeNode.East] = nodes[r, c + 1];
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
            foreach (MazeNode neighbor in root.AdjacentNodes)
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
                foreach (MazeNode neighbor in to_node.AdjacentNodes)
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
                        //nodes[r, c].DrawPredecessorLink(gr, Pens.Pink);
                    }
                }
            }

            picMaze.Image = bm;
        }

        private void scrFps_Scroll(object sender, ScrollEventArgs e)
        {
            int fps = scrFps.Value;
            lblFps.Text = fps.ToString();
            tmrStep.Interval = 1000 / fps;
        }

        private void picMaze_MouseClick(object sender, MouseEventArgs e)
        {
            tmrStep.Enabled = false;

            // Find the node clicked.
            if (Nodes == null) return;
            if (e.Button == MouseButtons.Left)
                StartNode = FindNodeAt(e.Location);
            else if (e.Button == MouseButtons.Right)
                EndNode = FindNodeAt(e.Location);

            // See if we have both nodes.
            if ((StartNode != null) && (EndNode != null))
                StartSolving();

            picMaze.Refresh();
        }

        // Return the node at a point.
        private MazeNode FindNodeAt(Point location)
        {
            if (location.X < Xmin) return null;
            if (location.Y < Ymin) return null;

            int row = (location.Y - Ymin) / CellHgt;
            if (row >= NumRows) return null;

            int col = (location.X - Xmin) / CellWid;
            if (col >= NumCols) return null;

            return Nodes[row, col];
        }

        private void picMaze_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            if (StartNode != null) StartNode.DrawCenter(e.Graphics, Brushes.Red);
            if (EndNode != null) EndNode.DrawCenter(e.Graphics, Brushes.Green);
            if ((Path != null) && (Path.Count > 1))
            {
                List<PointF> points = new List<PointF>();
                foreach (MazeNode node in Path)
                    points.Add(node.Center);
                if (FoundSolution)
                    e.Graphics.DrawLines(Pens.Red, points.ToArray());
                else
                    e.Graphics.DrawLines(Pens.Blue, points.ToArray());
            }
        }

        // Start solving the maze.
        private void StartSolving()
        {
            // Remove any previous results.
            Path = new List<MazeNode>();
            LastUsedNeighbor = new List<int>();
            foreach (MazeNode node in Nodes)
                node.InPath = false;

            // Make the nodes define their neighbors.
            foreach (MazeNode node in Nodes)
                node.DefineNeighbors();

            // Start at the start node.
            Path.Add(StartNode);
            LastUsedNeighbor.Add(-1);
            StartNode.InPath = true;

            // Solve.
            FoundSolution = false;
            tmrStep.Enabled = true;
        }

        private bool FoundSolution = false;

        // The final node in the Path list is the node we are visiting.
        // If LastUsedNeighbor has an entry for that node, then
        // we have visited some of its children.
        // See if we have a solution.
        // If not, try the last node's next neighbor.
        private void Solve()
        {
            // See if we have reached the end node.
            int last_node_index = Path.Count - 1;
            MazeNode last_node = Path[last_node_index];
            if (last_node == EndNode)
            {
                FoundSolution = true;
                tmrStep.Enabled = false;
                return;
            }

            // See if the last node has any more neighbors we can visit.
            bool found_neighbor = false;
            int neighbor_index = LastUsedNeighbor[last_node_index];
            MazeNode neighbor = null;
            for (; ; )
            {
                // Try the next neighbor.
                neighbor_index++;

                // If we have checked all neighbors, break.
                if (neighbor_index >= last_node.Neighbors.Count) break;

                // See if this neighbor is not already in the current path.
                neighbor = last_node.Neighbors[neighbor_index];
                if (!neighbor.InPath)
                {
                    // Visit this neighbor.
                    found_neighbor = true;
                    LastUsedNeighbor[last_node_index] = neighbor_index;
                    break;
                }
            }

            // See if we found a neighbor to visit.
            if (found_neighbor)
            {
                // Visit this neighbor.
                Path.Add(neighbor);
                LastUsedNeighbor.Add(-1);
                neighbor.InPath = true;
            }
            else
            {
                // We have visited all of the last node's neighbors.
                // Remove the last node from the Path list.
                last_node.InPath = false;
                Path.RemoveAt(last_node_index);
                LastUsedNeighbor.RemoveAt(last_node_index);
            }
        }

        // Take a step in solving the maze.
        private void tmrStep_Tick(object sender, EventArgs e)
        {
            Solve();
            picMaze.Refresh();
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFps = new System.Windows.Forms.Label();
            this.picMaze = new System.Windows.Forms.PictureBox();
            this.scrFps = new System.Windows.Forms.HScrollBar();
            this.tmrStep = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picMaze)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(114, 25);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 15;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(59, 38);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(35, 20);
            this.txtHeight.TabIndex = 14;
            this.txtHeight.Text = "10";
            this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Height:";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(59, 12);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(35, 20);
            this.txtWidth.TabIndex = 12;
            this.txtWidth.Text = "15";
            this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Width:";
            // 
            // lblFps
            // 
            this.lblFps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFps.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFps.Location = new System.Drawing.Point(305, 290);
            this.lblFps.Name = "lblFps";
            this.lblFps.Size = new System.Drawing.Size(47, 17);
            this.lblFps.TabIndex = 16;
            this.lblFps.Text = "5";
            this.lblFps.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.picMaze.Size = new System.Drawing.Size(340, 223);
            this.picMaze.TabIndex = 17;
            this.picMaze.TabStop = false;
            this.picMaze.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picMaze_MouseClick);
            this.picMaze.Paint += new System.Windows.Forms.PaintEventHandler(this.picMaze_Paint);
            // 
            // scrFps
            // 
            this.scrFps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scrFps.Location = new System.Drawing.Point(12, 290);
            this.scrFps.Maximum = 109;
            this.scrFps.Minimum = 1;
            this.scrFps.Name = "scrFps";
            this.scrFps.Size = new System.Drawing.Size(293, 16);
            this.scrFps.TabIndex = 18;
            this.scrFps.Value = 5;
            this.scrFps.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrFps_Scroll);
            // 
            // tmrStep
            // 
            this.tmrStep.Tick += new System.EventHandler(this.tmrStep_Tick);
            // 
            // howto_animate_maze3_Form1
            // 
            this.AcceptButton = this.btnCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 316);
            this.Controls.Add(this.scrFps);
            this.Controls.Add(this.picMaze);
            this.Controls.Add(this.lblFps);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.label1);
            this.Name = "howto_animate_maze3_Form1";
            this.Text = "howto_animate_maze3";
            ((System.ComponentModel.ISupportInitialize)(this.picMaze)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFps;
        private System.Windows.Forms.PictureBox picMaze;
        private System.Windows.Forms.HScrollBar scrFps;
        private System.Windows.Forms.Timer tmrStep;
    }
}

