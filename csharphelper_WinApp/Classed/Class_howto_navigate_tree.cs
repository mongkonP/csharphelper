
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

  namespace  howto_navigate_tree

 { 

class CircleNode : IDrawable
    {
        // The string we will draw.
        public string Text;

        // Constructor.
        public CircleNode(string new_text)
        {
            Text = new_text;
        }

        // Return the size of the string plus a 10 pixel margin.
        public SizeF GetSize(Graphics gr, Font font)
        {
            return gr.MeasureString(Text, font) + new SizeF(10, 10);
        }

        // Draw the object centered at (x, y).
        void IDrawable.Draw(float x, float y, Graphics gr, Pen pen, Brush bg_brush, Brush text_brush, Font font)
        {
            // Fill and draw an ellipse at our location.
            SizeF my_size = GetSize(gr, font);
            RectangleF rect = new RectangleF(
                x - my_size.Width / 2,
                y - my_size.Height / 2,
                my_size.Width, my_size.Height);
            gr.FillEllipse(bg_brush, rect);
            gr.DrawEllipse(pen, rect);

            // Draw the text.
            using (StringFormat string_format = new StringFormat())
            {
                string_format.Alignment = StringAlignment.Center;
                string_format.LineAlignment = StringAlignment.Center;
                gr.DrawString(Text, font, text_brush, x, y, string_format);
            }
        }

        // Return true if the node is above this point.
        // Note: The equation for an ellipse with half
        // width w and half height h centered at the origin is:
        //      x*x/w/w + y*y/h/h <= 1.
        bool IDrawable.IsAtPoint(Graphics gr, Font font, PointF center_pt, PointF target_pt)
        {
            // Get our size.
            SizeF my_size = GetSize(gr, font);

            // translate so we can assume the
            // ellipse is centered at the origin.
            target_pt.X -= center_pt.X;
            target_pt.Y -= center_pt.Y;

            // Determine whether the target point is under our ellipse.
            float w = my_size.Width / 2;
            float h = my_size.Height / 2;
            return
                target_pt.X * target_pt.X / w / w +
                target_pt.Y * target_pt.Y / h / h
                <= 1;
        }
    }










    // Represents something that a TreeNode can draw.
    interface IDrawable
    {
        // Return the object's needed size.
        SizeF GetSize(Graphics gr, Font font);

        // Return true if the node is above this point.
        bool IsAtPoint(Graphics gr, Font font, PointF center_pt, PointF target_pt);

        // Draw the object centered at (x, y).
        void Draw(float x, float y, Graphics gr, Pen pen,
            Brush bg_brush, Brush text_brush, Font font);
    }










    class TreeNode<T> where T : IDrawable
    {
        // The data.
        public T Data;

        // Child nodes in the tree.
        private TreeNode<T> _LeftChild;
        public TreeNode<T> LeftChild
        {
            get { return _LeftChild; }
            set
            {
                _LeftChild = value;
                if (_LeftChild != null) _LeftChild.Parent = this;
            }
        }

        private TreeNode<T> _RightChild;
        public TreeNode<T> RightChild {
            get { return _RightChild; }
            set
            {
                _RightChild = value;
                if (_RightChild != null) _RightChild.Parent = this;
            }
        }

        public TreeNode<T> Parent { get; set; }

        // Space to skip horizontally between siblings
        // and vertically between generations.
        private const float Hoffset = 5;
        private const float Voffset = 10;
        private const float MinSubtreeWidth = 20;

        // The node's center after arranging.
        private PointF Center;

        // Drawing properties.
        public Font MyFont = null;
        public Pen MyPen = Pens.Black;
        public Brush FontBrush = Brushes.Black;
        public Brush BgBrush = Brushes.White;

        // Constructor.
        public TreeNode(T new_data)
            : this(new_data, new Font("Times New Roman", 12))
        {
            Data = new_data;
        }
        public TreeNode(T new_data, Font fg_font)
        {
            Data = new_data;
            MyFont = fg_font;
        }

        // Arrange the node and its children in the allowed area.
        // Set xmin to indicate the right edge of our subtree.
        // Set ymin to indicate the bottom edge of our subtree.
        public void Arrange(Graphics gr, ref float xmin, ref float ymin)
        {
            // See how big this node is.
            SizeF my_size = Data.GetSize(gr, MyFont);

            // Recursively arrange our children,
            // allowing room for this node.
            float x = xmin;
            float biggest_ymin = ymin + my_size.Height;
            float subtree_ymin = ymin + my_size.Height + Voffset;

            if (LeftChild != null)
            {
                // Arrange this child's subtree.
                float child_ymin = subtree_ymin;
                LeftChild.Arrange(gr, ref x, ref child_ymin);

                // See if this increases the biggest ymin value.
                if (biggest_ymin < child_ymin) biggest_ymin = child_ymin;
            }
            else x += MinSubtreeWidth;

            // Allow room between the children.
            x += Hoffset;

            if (RightChild != null)
            {
                // Arrange this child's subtree.
                float child_ymin = subtree_ymin;
                RightChild.Arrange(gr, ref x, ref child_ymin);

                // See if this increases the biggest ymin value.
                if (biggest_ymin < child_ymin) biggest_ymin = child_ymin;
            }
            else x += MinSubtreeWidth;

            // See if this node is wider than the subtree under it.
            float subtree_width = x - xmin;
            if (my_size.Width > subtree_width)
            {
                // Center the subtree under this node.
                // Make the children rearrange themselves
                // moved to center their subtrees.
                x = xmin + (my_size.Width - subtree_width) / 2;
                if (LeftChild != null)
                {
                    // Arrange this child's subtree.
                    LeftChild.Arrange(gr, ref x, ref subtree_ymin);
                }
                else x += MinSubtreeWidth;

                // Allow room between the children.
                x += Hoffset;

                if (RightChild != null)
                {
                    // Arrange this child's subtree.
                    RightChild.Arrange(gr, ref x, ref subtree_ymin);
                }
                else x += MinSubtreeWidth;

                // The subtree's width is this node's width.
                subtree_width = my_size.Width;
            }

            // Set this node's center position.
            Center = new PointF(
                xmin + subtree_width / 2,
                ymin + my_size.Height / 2);

            // Increase xmin to allow room for
            // the subtree before returning.
            xmin += subtree_width;

            // Set the return value for ymin.
            ymin = biggest_ymin;
        }

        // Draw the subtree rooted at this node
        // with the given upper left corner.
        public void DrawTree(Graphics gr, ref float x, float y)
        {
            // Arrange the tree.
            Arrange(gr, ref x, ref y);

            // Draw the tree.
            DrawTree(gr);
        }

        // Draw the subtree rooted at this node.
        public void DrawTree(Graphics gr)
        {
            // Draw the links.
            DrawSubtreeLinks(gr);

            // Draw the nodes.
            DrawSubtreeNodes(gr);
        }

        // Draw the links for the subtree rooted at this node.
        private void DrawSubtreeLinks(Graphics gr)
        {
            if (LeftChild != null)
            {
                // Draw the link between this node this child.
                gr.DrawLine(MyPen, Center, LeftChild.Center);

                // Recursively make the child draw its subtree nodes.
                LeftChild.DrawSubtreeLinks(gr);
            }
            if (RightChild != null)
            {
                // Draw the link between this node this child.
                gr.DrawLine(MyPen, Center, RightChild.Center);

                // Recursively make the child draw its subtree nodes.
                RightChild.DrawSubtreeLinks(gr);
            }
        }

        // Draw the nodes for the subtree rooted at this node.
        private void DrawSubtreeNodes(Graphics gr)
        {
            // Draw this node.
            Data.Draw(Center.X, Center.Y, gr, MyPen, BgBrush, FontBrush, MyFont);

            // Recursively make the child draw its subtree nodes.
            if (LeftChild != null)
                LeftChild.DrawSubtreeNodes(gr);
            if (RightChild != null)
                RightChild.DrawSubtreeNodes(gr);
        }

        // Return the TreeNode at this point (or null if there isn't one there).
        public TreeNode<T> NodeAtPoint(Graphics gr, PointF target_pt)
        {
            // See if the point is under this node.
            if (Data.IsAtPoint(gr, MyFont, Center, target_pt)) return this;

            // See if the point is under a node in the subtree.
            if (LeftChild != null)
            {
                TreeNode<T> hit_node = LeftChild.NodeAtPoint(gr, target_pt);
                if (hit_node != null) return hit_node;
            }
            if (RightChild != null)
            {
                TreeNode<T> hit_node = RightChild.NodeAtPoint(gr, target_pt);
                if (hit_node != null) return hit_node;
            }

            return null;
        }

        // Delete a target node from this node's subtree.
        // Return true if we delete the node.
        public bool DeleteNode(TreeNode<T> target)
        {
            // Check the subtrees.
            if (LeftChild != null)
            {
                if (target == LeftChild)
                {
                    LeftChild = null;
                    return true;
                }
                else
                {
                    if (LeftChild.DeleteNode(target)) return true;
                }
            }

            if (RightChild != null)
            {
                if (target == RightChild)
                {
                    RightChild = null;
                    return true;
                }
                else
                {
                    if (RightChild.DeleteNode(target)) return true;
                }
            }

            // It's not in our subtree.
            return false;
        }

        // Return this node's number.
        public int NodeNumber()
        {
            // If we're the root node, return 0.
            if (Parent == null) return 0;

            // We are not the root node.
            // See if we are the left or right child.
            if (this == Parent.LeftChild)
                return Parent.NodeNumber() * 2 + 1;
            else
                return Parent.NodeNumber() * 2 + 2;
        }

        // Find the indicated node in this subtree.
        public TreeNode<T> FindNodeByNumber(int number)
        {
            // If this is the root node, return it.
            if (number <= 0) return this;

            // Add 1 to the number so the numbers at each level
            // in the tree has the same number of bits.
            number++;

            // Find the least significant bit.
            int msb = FindMsb(number);

            // Climb down through the tree.
            TreeNode<T> node = this;
            for (int i = msb - 1; i >= 0; i--)
            {
                // Use this bit to decide which way to go.
                if ((number & (1 << i)) == 0)
                    node = node.LeftChild;
                else
                    node = node.RightChild;

                // See if we fell off the tree.
                if (node == null) return null;
            }

            // Return the current node.
            return node;
        }


        // Return the number's least significant bit.
        private int FindMsb(int number)
        {
            for (int i = 31; i >= 0; i--)
                if ((number & (1 << i)) != 0) return i;
            return -1;
        }

        // Add a node to the left or right child.
        public void AddChild(TreeNode<T> child)
        {
            if (LeftChild == null)
                LeftChild = child;
            else if (RightChild == null)
                RightChild = child;
            else
                throw new Exception("This node already has two children");
        }

        // Set the background color for this subtree.
        public void SetSubtreeBg(Brush brush)
        {
            BgBrush = brush;
            if (LeftChild != null) LeftChild.SetSubtreeBg(brush);
            if (RightChild != null) RightChild.SetSubtreeBg(brush);
        }
    }

}