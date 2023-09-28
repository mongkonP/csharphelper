
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

  namespace  howto_generic_treenode_weights

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

        // The weight of the link to this node from its parent.
        public int LinkWeight;

        // Child nodes in the tree.
        public List<TreeNode<T>> Children = new List<TreeNode<T>>();

        // Space to skip horizontally between siblings
        // and vertically between generations.
        private const float Hoffset = 5;
        private const float Voffset = 30;

        // The node's center after arranging.
        private PointF Center;

        // Drawing properties.
        public Font MyFont = null;
        public Pen MyPen = Pens.Black;
        public Brush FontBrush = Brushes.Black;
        public Brush LinkWeightBrush = Brushes.Red;
        public Font LinkWeightFont = null;
        public Brush BgBrush = Brushes.White;
        public Brush WeightBgBrush = SystemBrushes.Control;

        // Constructor.
        public TreeNode(T new_data)
            : this(new_data, int.MinValue)
        {
        }
        public TreeNode(T new_data, int link_weight)
            : this(new_data, link_weight,
                new Font("Times New Roman", 12),
                new Font("Times New Roman", 8))
        {
        }
        public TreeNode(T new_data, int link_weight, Font fg_font, Font link_weight_font)
        {
            Data = new_data;
            LinkWeight = link_weight;
            MyFont = fg_font;
            LinkWeightFont = link_weight_font;
        }

        // Add a TreeNode to our Children list.
        public void AddChild(TreeNode<T> child)
        {
            AddChild(child, int.MinValue);
        }
        public void AddChild(TreeNode<T> child, int link_weight)
        {
            Children.Add(child);
            child.LinkWeight = link_weight;
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
            foreach (TreeNode<T> child in Children)
            {
                // Arrange this child's subtree.
                float child_ymin = subtree_ymin;
                child.Arrange(gr, ref x, ref child_ymin);

                // See if this increases the biggest ymin value.
                if (biggest_ymin < child_ymin) biggest_ymin = child_ymin;

                // Allow room before the next sibling.
                x += Hoffset;
            }

            // Remove the spacing after the last child.
            if (Children.Count > 0) x -= Hoffset;

            // See if this node is wider than the subtree under it.
            float subtree_width = x - xmin;
            if (my_size.Width > subtree_width)
            {
                // Center the subtree under this node.
                // Make the children rearrange themselves
                // moved to center their subtrees.
                x = xmin + (my_size.Width - subtree_width) / 2;
                foreach (TreeNode<T> child in Children)
                {
                    // Arrange this child's subtree.
                    child.Arrange(gr, ref x, ref subtree_ymin);

                    // Allow room before the next sibling.
                    x += Hoffset;
                }

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
            foreach (TreeNode<T> child in Children)
            {
                // Draw the link between this node this child.
                DrawLink(gr, child.LinkWeight, Center, child.Center);

                // Recursively make the child draw its subtree nodes.
                child.DrawSubtreeLinks(gr);
            }
        }

        // Draw a link with its weight.
        private void DrawLink(Graphics gr,
            int link_weight, PointF point1, PointF point2)
        {
            // Draw the link.
            gr.DrawLine(MyPen, point1, point2);

            // Display the link's weight.
            if (link_weight > int.MinValue)
            {
                PointF middle = new PointF(
                    (point1.X + point2.X) / 2f,
                    (point1.Y + point2.Y) / 2f);
                SizeF size = gr.MeasureString(
                    link_weight.ToString(), LinkWeightFont);
                RectangleF rect = new RectangleF(
                    middle.X - size.Width / 2f,
                    middle.Y - size.Height / 2f,
                    size.Width,
                    size.Height);
                gr.FillRectangle(WeightBgBrush, rect);

                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    gr.DrawString(link_weight.ToString(),
                    LinkWeightFont, LinkWeightBrush, rect, sf);
                }
            }
        }

        // Draw the nodes for the subtree rooted at this node.
        private void DrawSubtreeNodes(Graphics gr)
        {
            // Draw this node.
            Data.Draw(Center.X, Center.Y, gr, MyPen, BgBrush, FontBrush, MyFont);

            // Recursively make the child draw its subtree nodes.
            foreach (TreeNode<T> child in Children)
            {
                child.DrawSubtreeNodes(gr);
            }
        }

        // Return the TreeNode at this point (or null if there isn't one there).
        public TreeNode<T> NodeAtPoint(Graphics gr, PointF target_pt)
        {
            // See if the point is under this node.
            if (Data.IsAtPoint(gr, MyFont, Center, target_pt)) return this;

            // See if the point is under a node in the subtree.
            foreach (TreeNode<T> child in Children)
            {
                TreeNode<T> hit_node = child.NodeAtPoint(gr, target_pt);
                if (hit_node != null) return hit_node;
            }

            return null;
        }

        // Delete a target node from this node's subtree.
        // Return true if we delete the node.
        public bool DeleteNode(TreeNode<T> target)
        {
            // See if the target is in our subtree.
            foreach (TreeNode<T> child in Children)
            {
                // See if it's the child.
                if (child == target)
                {
                    // Delete this child.
                    Children.Remove(child);
                    return true;
                }

                // See if it's in the child's subtree.
                if (child.DeleteNode(target)) return true;
            }

            // It's not in our subtree.
            return false;
        }
    }

}