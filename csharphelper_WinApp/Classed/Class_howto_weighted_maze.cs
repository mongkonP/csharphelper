
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;

  namespace  howto_weighted_maze

 { 

class MazeLink
    {
        public MazeNode FromNode, ToNode;
        public MazeLink(MazeNode from_node, MazeNode to_node)
        {
            FromNode = from_node;
            ToNode = to_node;
        }

        // The method used to weight links.
        public enum Favor
        {
            None,
            Age,
            Horizontal,
            Vertical,
            ZigZag,
            Straight,
        }

        // The number of rounds that this link
        // has been in the candidate list.
        public int Age = 0;

        // The link's weight.
        public int Weight(Favor favor)
        {
            switch (favor)
            {
                case Favor.None:
                    return 1;
                case Favor.Age:
                    return Age * Age;
                case Favor.Horizontal:
                    if (FromNode.Bounds.Top == ToNode.Bounds.Top)
                        return 5;
                    else return 1;
                case Favor.Vertical:
                    if (FromNode.Bounds.Left == ToNode.Bounds.Left)
                        return 5;
                    else return 1;
                case Favor.ZigZag:
                    {
                        MazeNode from_pred = FromNode.Predecessor;
                        if (from_pred == FromNode) return 1;

                        bool is_horz = (FromNode.Bounds.Top == ToNode.Bounds.Top);
                        bool pred_is_horz = (from_pred.Bounds.Top == FromNode.Bounds.Top);
                        if (is_horz == pred_is_horz) return 1;
                        else return 10;
                    }
                case Favor.Straight:
                    {
                        MazeNode from_pred = FromNode.Predecessor;
                        if (from_pred == FromNode) return 1;

                        bool is_horz = (FromNode.Bounds.Top == ToNode.Bounds.Top);
                        bool pred_is_horz = (from_pred.Bounds.Top == FromNode.Bounds.Top);
                        if (is_horz != pred_is_horz) return 1;
                        else return 10;
                    }
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
    }










    class MazeNode
    {
        public const int North = 0;
        public const int South = North + 1;
        public const int East = South + 1;
        public const int West = East + 1;

        // The node's neighbors in order North, South, East, West.
        public MazeNode[] Neighbors = new MazeNode[4];

        // The predecessor in the spanning tree.
        public MazeNode Predecessor = null;

        // The node's bounds.
        public Rectangle Bounds;

        // Return this node's center.
        public Point Center
        {
            get
            {
                int x = Bounds.Left + Bounds.Width / 2;
                int y = Bounds.Top + Bounds.Height / 2;
                return new Point(x, y);
            }
        }

        // Constructor.
        public MazeNode(int x, int y, int wid, int hgt)
        {
            Bounds = new Rectangle(x, y, wid, hgt);
        }

        // Draw the node's bounding box.
        public void DrawBoundingBox(Graphics gr, Pen pen)
        {
            gr.DrawRectangle(pen,
                Bounds.Left + 1, Bounds.Y + 1,
                Bounds.Width - 2, Bounds.Height - 2);
        }

        // Draw a circle at the node's center.
        public void DrawCenter(Graphics gr, Brush brush)
        {
            int cx = Bounds.Left + Bounds.Width / 2;
            int cy = Bounds.Top + Bounds.Height / 2;
            gr.FillEllipse(brush, cx - 2, cy - 2, 4, 4);
        }

        // Draw a link to the node's predecessor.
        public void DrawPredecessorLink(Graphics gr, Pen pen)
        {
            if ((Predecessor != null) && (Predecessor != this))
                gr.DrawLine(pen, Center, Predecessor.Center);
        }

        // Draw links to the node's neighbors.
        public void DrawNeighborLinks(Graphics gr, Pen pen)
        {
            foreach (MazeNode neighbor in Neighbors)
            {
                if (neighbor != null)
                {
                    int dx = (int)(0.4 * (neighbor.Center.X - Center.X));
                    int dy = (int)(0.4 * (neighbor.Center.Y - Center.Y));
                    Point pt = new Point(Center.X + dx, Center.Y + dy);
                    gr.DrawLine(pen, Center, pt);
                }
            }
        }

        // Draw the walls that don't cross a predecessor link.
        public void DrawWalls(Graphics gr, Pen pen)
        {
            for (int side = 0; side < 4; side++)
            {
                if ((Neighbors[side] == null) ||
                    ((Neighbors[side].Predecessor != this) &&
                     (Neighbors[side] != this.Predecessor)))
                {
                    DrawWall(gr, pen, side, 0);
                }
            }
        }

        // Draw one side of our bounding box.
        private void DrawWall(Graphics gr, Pen pen, int side, int offset)
        {
            switch (side)
            {
                case North:
                    gr.DrawLine(pen,
                        Bounds.Left + offset, Bounds.Top + offset,
                        Bounds.Right - offset, Bounds.Top + offset);
                    break;
                case South:
                    gr.DrawLine(pen,
                        Bounds.Left + offset, Bounds.Bottom - offset,
                        Bounds.Right - offset, Bounds.Bottom - offset);
                    break;
                case East:
                    gr.DrawLine(pen,
                        Bounds.Right - offset, Bounds.Top + offset,
                        Bounds.Right - offset, Bounds.Bottom - offset);
                    break;
                case West:
                    gr.DrawLine(pen,
                        Bounds.Left + offset, Bounds.Top + offset,
                        Bounds.Left + offset, Bounds.Bottom - offset);
                    break;
            }
        }
    }

}