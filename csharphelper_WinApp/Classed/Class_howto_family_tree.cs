
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

  namespace  howto_family_tree

 { 

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











    class PictureNode : IDrawable
    {
        // Constructor.
        public Image Picture = null;
        public string Description;
        public bool Selected = false;
        public PictureNode(string description, Image picture)
        {
            Description = description;
            Picture = picture;

            // For testing.
            //NodeSize = new SizeF(Rand.Next(50, 150), Rand.Next(50, 150));
        }

        // The size of the drawn rectangles.
        public SizeF NodeSize = new SizeF(100, 100);

        // For testing.
        //private static Random Rand = new Random();

        // Return the size needed by this node.
        public SizeF GetSize(Graphics gr, Font font)
        {
            return NodeSize;
        }

        // Return a RectangleF giving the node's location.
        private RectangleF Location(PointF center)
        {
            return new RectangleF(
                center.X - NodeSize.Width / 2,
                center.Y - NodeSize.Height / 2,
                NodeSize.Width, NodeSize.Height);
        }

        // Return True if the target is under this node.
        public bool IsAtPoint(Graphics gr, Font font, PointF center_pt, PointF target_pt)
        {
            RectangleF rect = Location(center_pt);
            return rect.Contains(target_pt);
        }

        // Draw the person.
        public void Draw(float x, float y, Graphics gr, Pen pen, Brush bg_brush, Brush text_brush, Font font)
        {
            // Draw a border.
            RectangleF rectf = Location(new PointF(x, y));
            Rectangle rect = Rectangle.Round(rectf);
            if (Selected)
            {
                gr.FillRectangle(Brushes.White, rect);
                ControlPaint.DrawBorder3D(gr, rect,
                    Border3DStyle.Sunken);
            }
            else
            {
                gr.FillRectangle(Brushes.LightGray, rect);
                ControlPaint.DrawBorder3D(gr, rect,
                    Border3DStyle.Raised);
            }

            // Draw the picture.
            rectf.Inflate(-5, -5);
            rectf = PositionImage(Picture, rectf);
            gr.DrawImage(Picture, rectf);
        }

        // Find a rectangle to draw the image centered in the
        // rectangle as large as possible without stretching.
        private RectangleF PositionImage(Image picture, RectangleF rect)
        {
            // Get the X and Y scales.
            float pic_wid = picture.Width;
            float pic_hgt = picture.Height;
            float pic_aspect = pic_wid / pic_hgt;
            float rect_aspect = rect.Width / rect.Height;
            float scale = 1;
            if (pic_aspect > rect_aspect)
            {
                scale = rect.Width / pic_wid;
            }
            else
            {
                scale = rect.Height / pic_hgt;
            }

            // See where we need to draw.
            pic_wid *= scale;
            pic_hgt *= scale;
            RectangleF drawing_rect = new RectangleF(
                rect.X + (rect.Width - pic_wid) / 2,
                rect.Y + (rect.Height - pic_hgt) / 2,
                pic_wid, pic_hgt);
            return drawing_rect;
        }
    }










    class TreeNode<T> where T : IDrawable
    {
        // The data.
        public T Data;

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

        // Add a TreeNode to out Children list.
        public void AddChild(TreeNode<T> child)
        {
            Children.Add(child);
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
            // See if we have 1 child.
            if (Children.Count == 1)
            {
                // Just connect the centers.
                gr.DrawLine(MyPen, Center, Children[0].Center);
            }
            else if (Children.Count > 1)
            {
                // Draw a horizontal line above the children.
                float xmin = Children[0].Center.X;
                float xmax = Children[Children.Count - 1].Center.X;
                SizeF my_size = Data.GetSize(gr, MyFont);
                float y = Center.Y + my_size.Height / 2 + Voffset / 2f;
                gr.DrawLine(MyPen, xmin, y, xmax, y);

                // Draw the vertical line from the parent
                // to the horizontal line.
                gr.DrawLine(MyPen, Center.X, Center.Y, Center.X, y);

                // Draw lines from the horizontal line to the children.
                foreach (TreeNode<T> child in Children)
                {
                    gr.DrawLine(MyPen,
                        child.Center.X, y,
                        child.Center.X, child.Center.Y);
                }
            }

            // Recursively make the children draw their subtrees.
            foreach (TreeNode<T> child in Children)
            {
                child.DrawSubtreeLinks(gr);
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