using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

 

using howto_sunburst_chart5;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_sunburst_chart5_Form1:Form
  { 


        public howto_sunburst_chart5_Form1()
        {
            InitializeComponent();
        }

        // The XML document we will display.
        private XmlDocument XmlDoc = new XmlDocument();

        // The items' wedges.
        private List<Wedge> Wedges = null;

        // The Wedge that is currently under the mouse.
        private Wedge WedgeUnderMouse = null;

        private void howto_sunburst_chart5_Form1_Load(object sender, EventArgs e)
        {
            // Load the XML document.
            XmlDoc.Load("test.xml");

            // Load the TreeView.
            LoadTreeViewFromXmlDoc(XmlDoc, trvItems);
            trvItems.ExpandAll();

            // Make the sun burst chart.
            MakeSunburst();
        }
        private void howto_sunburst_chart5_Form1_Resize(object sender, EventArgs e)
        {
            MakeSunburst();
        }

        // Make the sunburst chart for the current size.
        private void MakeSunburst()
        {
            Wedges = new List<Wedge>();

            using (Font font = new Font("Arial", 10, FontStyle.Bold))
            {
                picSunburst.Image = MakeSunburst(
                    picSunburst.ClientSize.Width,
                    picSunburst.ClientSize.Height,
                    4, XmlDoc, Color.White, Pens.Blue,
                    font, ref Wedges);
            }
        }

        // Load a TreeView control from an XML file.
        private void LoadTreeViewFromXmlDoc(XmlDocument xml_doc, TreeView trv)
        {
            // Add the root node's children to the TreeView.
            trv.Nodes.Clear();
            AddTreeViewNode(trv.Nodes, xml_doc.DocumentElement);
        }

        // Add the children of this XML node 
        // to this child nodes collection.
        private void AddTreeViewNode(
            TreeNodeCollection parent_nodes, XmlNode xml_node)
        {
            // Make the new TreeView node.
            TreeNode new_node = parent_nodes.Add(xml_node.Name);

            // Add child nodes.
            foreach (XmlNode child_node in xml_node.ChildNodes)
            {
                // Recursively make this node's descendants.
                AddTreeViewNode(new_node.Nodes, child_node);
            }
        }

        // Make a sunburst chart from the XML data.
        private Bitmap MakeSunburst(int wid, int hgt, int margin,
            XmlDocument xml_doc, Color bm_color, Pen arc_pen, Font font,
            ref List<Wedge> wedges)
        {
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(bm_color);
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                // See how deep we must go.
                int depth = FindDepth(xml_doc.DocumentElement);

                // Calculate geometry.
                float cx = wid / 2f;
                float cy = hgt / 2f;
                wid -= 2 * margin;
                hgt -= 2 * margin;
                float dr = (Math.Min(wid, hgt) / 2f / depth);

                // Draw the root.
                RectangleF rect = new RectangleF(
                    cx - dr, cy - dr, 2 * dr, 2 * dr);
                Color bg_color = GetNodeColor(XmlDoc.DocumentElement,
                    "BgColor", Color.Transparent);
                using (Brush brush = new SolidBrush(bg_color))
                {
                    gr.FillEllipse(brush, rect);
                }
                gr.DrawEllipse(arc_pen, rect);

                Color fg_color = GetNodeColor(XmlDoc.DocumentElement,
                    "FgColor", Color.Black);
                using (Brush brush = new SolidBrush(fg_color))
                {
                    using (StringFormat sf = new StringFormat())
                    {
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        gr.DrawString(XmlDoc.DocumentElement.Name,
                            font, brush, cx, cy, sf);
                    }
                }

                // Make the root's wedge.
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(rect);
                wedges.Add(new Wedge(path, fg_color, bg_color,
                    XmlDoc.DocumentElement.Name,
                    IsHidden(XmlDoc.DocumentElement)));

                // Draw the other nodes.
                DrawSunburstChildren(gr, cx, cy, dr, 1,
                    XmlDoc.DocumentElement.ChildNodes,
                    0, 360, font, bg_color, fg_color,
                    ref wedges);
            }
            return bm;
        }

        // Return the depth of the XML sub-document rooted at this node.
        private int FindDepth(XmlNode node)
        {
            int depth = 1;
            foreach (XmlNode child in node.ChildNodes)
            {
                int child_depth = FindDepth(child);
                if (depth < 1 + child_depth) depth = 1 + child_depth;
            }
            return depth;
        }

        // Draw the children of this node.
        private void DrawSunburstChildren(Graphics gr,
            float cx, float cy, float dr, int level,
            XmlNodeList children, float min_angle, float max_angle,
            Font font, Color parent_bg_color, Color parent_fg_color,
            ref List<Wedge> wedges)
        {
            // Draw child arcs.
            int num_children = children.Count;
            float angle = min_angle;
            float dangle = (max_angle - min_angle) / num_children;
            foreach (XmlNode child in children)
            {
                // Draw this child.
                Color child_bg_color, child_fg_color;
                DrawSunburstChild(gr,
                    cx, cy, dr, level,
                    child, angle, angle + dangle, font,
                    parent_bg_color, parent_fg_color,
                    out child_bg_color, out child_fg_color, ref wedges);

                // Draw this child's children.
                DrawSunburstChildren(gr, cx, cy, dr, level + 1,
                    child.ChildNodes, angle, angle + dangle, font,
                    child_bg_color, child_fg_color, ref wedges);

                // Move to the next child's section.
                angle = angle + dangle;
            }
        }

        // Draw a single node.
        private void DrawSunburstChild(Graphics gr,
            float cx, float cy, float dr, int level,
            XmlNode node, float min_angle, float max_angle, Font font,
            Color default_bg_color, Color default_fg_color,
            out Color bg_color, out Color fg_color,
            ref List<Wedge> wedges)
        {
            // Draw the outline.
            double min_theta = min_angle / 180f * Math.PI;
            double max_theta = max_angle / 180f * Math.PI;
            float inner_r = level * dr;
            float outer_r = inner_r + dr;
            RectangleF outer_rect = new RectangleF(
                cx - outer_r, cy - outer_r,
                2 * outer_r, 2 * outer_r);
            RectangleF inner_rect = new RectangleF(
                cx - inner_r, cy - inner_r,
                2 * inner_r, 2 * inner_r);

            float inner_min_x = (float)(cx + inner_r * Math.Cos(min_theta));
            float inner_min_y = (float)(cy + inner_r * Math.Sin(min_theta));
            float outer_min_x = (float)(cx + outer_r * Math.Cos(min_theta));
            float outer_min_y = (float)(cy + outer_r * Math.Sin(min_theta));

            float inner_max_x = (float)(cx + inner_r * Math.Cos(max_theta));
            float inner_max_y = (float)(cy + inner_r * Math.Sin(max_theta));
            float outer_max_x = (float)(cx + outer_r * Math.Cos(max_theta));
            float outer_max_y = (float)(cy + outer_r * Math.Sin(max_theta));

            GraphicsPath path = new GraphicsPath();
            path.AddArc(outer_rect, min_angle, max_angle - min_angle);
            path.AddLine(outer_max_x, outer_max_y, inner_max_x, inner_max_y);
            path.AddArc(inner_rect, max_angle, min_angle - max_angle);
            path.AddLine(inner_min_x, inner_min_y, outer_min_x, outer_min_y);
            path.CloseFigure();

            // See if this wedge should be hidden.
            bool is_hidden = IsHidden(node);

            bg_color = GetNodeColor(node, "BgColor", default_bg_color);
            if (!is_hidden)
            {
                using (Brush brush = new SolidBrush(bg_color))
                {
                    gr.FillPath(brush, path);
                }
                gr.DrawPath(Pens.Black, path);
            }

            // Get the node's text.
            string text = node.Name;
            if (node.Attributes["Text"] != null)
                text = node.Attributes["Text"].Value;

            // Draw the text.
            float mid_r = (inner_r + outer_r) / 2;
            fg_color = GetNodeColor(node, "FgColor", default_fg_color);
            if (!is_hidden)
            {
                using (Brush brush = new SolidBrush(fg_color))
                {
                    DrawNodeTextInWedge(gr, brush, font, text,
                        cx, cy, min_theta, max_theta, mid_r);
                }
            }

            // Make the item's wedge.
            wedges.Add(new Wedge(path, fg_color, bg_color, text, is_hidden));
        }

        // Draw multi-line text in a wedge.
        private void DrawNodeTextInWedge(Graphics gr, Brush brush,
            Font font, string text, float cx, float cy,
            double min_theta, double max_theta, float mid_r)
        {
            // Get the node's text.
            string[] separators = { @"\n" };
            string[] lines = text.Split(separators, StringSplitOptions.None);

            // See how tall each line should be.
            float hgt = font.Height * 0.8f;

            // Calculate the minimum and maximum radii,
            // and the change in radius per line dr.
            float min_r = mid_r - (lines.Length - 1) * hgt / 2f;
            float max_r = min_r + (lines.Length - 1) * hgt;
            float dr = (max_r - min_r) / (float)(lines.Length - 1);

            // Draw the lines of text.
            float radius = max_r;
            for (int i = 0; i < lines.Length; i++)
            {
                DrawTextOnArc(gr, brush, font, lines[i],
                    cx, cy, min_theta, max_theta, radius);
                radius -= dr;
            }
        }

        // Draw text along this arc.
        private void DrawTextOnArc(Graphics gr, Brush brush,
            Font font, string text, float cx, float cy,
            double min_theta, double max_theta, float radius)
        {
            // Use at most 32 characters.
            if (text.Length > 32) text = text.Substring(0, 32);

            // Make a CharacterRange for the string's characters.
            List<CharacterRange> range_list = new List<CharacterRange>();
            for (int i = 0; i < text.Length; i++)
            {
                range_list.Add(new CharacterRange(i, 1));
            }

            using (StringFormat sf = new StringFormat())
            {
                sf.SetMeasurableCharacterRanges(range_list.ToArray());

                // Measure the string's character ranges.
                RectangleF rect = new RectangleF(0, 0, 1000, 1000);
                Region[] regions = gr.MeasureCharacterRanges(text, font, rect, sf);

                // Get the total width.
                float total_width = regions.Sum(region => region.GetBounds(gr).Width);

                // Get the angle subtended by the text.
                double total_theta = total_width / radius;

                // Find the starting angle.
                double start_theta = (min_theta + max_theta - total_theta) / 2;

                // Find the angle per unit of character width.
                double theta_per_width = total_theta / total_width;
                
                // Draw the characters.
                for (int i = 0; i < regions.Length; i++)
                {
                    float x = (float)(cx + radius * Math.Cos(start_theta));
                    float y = (float)(cy + radius * Math.Sin(start_theta));
                    float angle = (float)(start_theta / Math.PI * 180 + 90);
                    PointF point = new PointF(x, y);
                    DrawCenteredText(gr, font, brush,
                        text[i].ToString(), point, angle);

                    start_theta += theta_per_width * regions[i].GetBounds(gr).Width;
                }
            }
        }

        // Return a node's Color attribute or
        // the default value if there is no color.
        private Color GetNodeColor(XmlNode node, string color_name, Color default_color)
        {
            if (node.Attributes[color_name] == null) return default_color;
            try
            {
                return Color.FromName(node.Attributes[color_name].Value);
            }
            catch
            {
                return default_color;
            }
        }

        // Return true if the wedge should be hidden.
        private bool IsHidden(XmlNode node)
        {
            if (node.Attributes["IsHidden"] == null) return false;
            return (bool.Parse(node.Attributes["IsHidden"].Value));
        }

        // Draw text centered at the position.
        private void DrawCenteredText(Graphics gr, Font font, Brush brush,
            string text, PointF center, float angle)
        {
            // Rotate.
            gr.RotateTransform(angle);

            // Translate.
            gr.TranslateTransform(center.X, center.Y, MatrixOrder.Append);

            // Draw the text.
            using (StringFormat sf = new StringFormat())
            {
                // sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                gr.DrawString(text, font, brush, 0, 0, sf);
            }

            // Reset the transformation.
            gr.ResetTransform();
        }

        // Draw some text along a GraphicsPath.
        private void DrawTextOnPath(Graphics gr, Brush brush, Font font, string txt, GraphicsPath path, bool text_above_path)
        {
            // Make a copy so we don't mess up the original.
            path = (GraphicsPath)path.Clone();

            // Flatten the path into segments.
            path.Flatten();

            // Draw characters.
            int start_ch = 0;
            PointF start_point = path.PathPoints[0];
            for (int i = 1; i < path.PointCount; i++)
            {
                PointF end_point = path.PathPoints[i];
                DrawTextOnSegment(gr, brush, font, txt, ref start_ch,
                    ref start_point, end_point, text_above_path);
                if (start_ch >= txt.Length) break;
            }
        }

        // Draw some text along a line segment.
        // Leave char_num pointing to the next character to be drawn.
        // Leave start_point holding the coordinates of the last point used.
        private void DrawTextOnSegment(Graphics gr, Brush brush, Font font, string txt, ref int first_ch, ref PointF start_point, PointF end_point, bool text_above_segment)
        {
            float dx = end_point.X - start_point.X;
            float dy = end_point.Y - start_point.Y;
            float dist = (float)Math.Sqrt(dx * dx + dy * dy);
            dx /= dist;
            dy /= dist;

            // See how many characters will fit.
            int last_ch = first_ch;
            while (last_ch < txt.Length)
            {
                string test_string = txt.Substring(first_ch, last_ch - first_ch + 1);
                if (gr.MeasureString(test_string, font).Width > dist)
                {
                    // This is one too many characters.
                    last_ch--;
                    break;
                }
                last_ch++;
            }
            if (last_ch < first_ch) return;
            if (last_ch >= txt.Length) last_ch = txt.Length - 1;
            string chars_that_fit = txt.Substring(first_ch, last_ch - first_ch + 1);

            // Rotate and translate to position the characters.
            GraphicsState state = gr.Save();
            if (text_above_segment)
            {
                gr.TranslateTransform(0,
                    -gr.MeasureString(chars_that_fit, font).Height,
                    MatrixOrder.Append);
            }
            float angle = (float)(180 * Math.Atan2(dy, dx) / Math.PI);
            gr.RotateTransform(angle, MatrixOrder.Append);
            gr.TranslateTransform(start_point.X, start_point.Y, MatrixOrder.Append);

            // Draw the characters that fit.
            gr.DrawString(chars_that_fit, font, brush, 0, 0);

            // Restore the saved state.
            gr.Restore(state);

            // Update first_ch and start_point.
            first_ch = last_ch + 1;
            float text_width = gr.MeasureString(chars_that_fit, font).Width;
            start_point = new PointF(
                start_point.X + dx * text_width,
                start_point.Y + dy * text_width);
        }

        // Display information about the wedge under the mouse.
        private void picSunburst_MouseMove(object sender, MouseEventArgs e)
        {
            // Find the wedge under the mouse.
            foreach (Wedge wedge in Wedges)
            {
                if (wedge.ContainsPoint(e.Location))
                {
                    DisplayWedgeInfo(wedge);
                    return;
                }
            }

            // We didn't find a wedge containing
            // the mouse. Clear the info.
            DisplayWedgeInfo(null);
        }

        // If this is a new Wedge under the mouse,
        // display its information.
        private void DisplayWedgeInfo(Wedge wedge)
        {
            // If the Wedge under the mouse has
            // not changed, do nothing.
            if (wedge == WedgeUnderMouse) return;
            WedgeUnderMouse = wedge;

            // See if the FgColor is Transparent.
            if ((wedge == null) || (wedge.IsHidden))
            {
                // It's null or Transparent. Clear the label.
                lblWedgeUnderMouse.Text = "";
            }
            else
            {
                // It's not Transparent.
                // Display the Wedge's information.
                lblWedgeUnderMouse.Text = wedge.Text.Replace("\\n", " ");
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
            this.trvItems = new System.Windows.Forms.TreeView();
            this.picSunburst = new System.Windows.Forms.PictureBox();
            this.lblWedgeUnderMouse = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picSunburst)).BeginInit();
            this.SuspendLayout();
            // 
            // trvItems
            // 
            this.trvItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.trvItems.Location = new System.Drawing.Point(12, 12);
            this.trvItems.Name = "trvItems";
            this.trvItems.Size = new System.Drawing.Size(136, 350);
            this.trvItems.TabIndex = 0;
            // 
            // picSunburst
            // 
            this.picSunburst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picSunburst.BackColor = System.Drawing.Color.White;
            this.picSunburst.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picSunburst.Location = new System.Drawing.Point(154, 12);
            this.picSunburst.Name = "picSunburst";
            this.picSunburst.Size = new System.Drawing.Size(363, 350);
            this.picSunburst.TabIndex = 1;
            this.picSunburst.TabStop = false;
            this.picSunburst.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picSunburst_MouseMove);
            // 
            // lblWedgeUnderMouse
            // 
            this.lblWedgeUnderMouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWedgeUnderMouse.AutoSize = true;
            this.lblWedgeUnderMouse.Location = new System.Drawing.Point(154, 365);
            this.lblWedgeUnderMouse.Name = "lblWedgeUnderMouse";
            this.lblWedgeUnderMouse.Size = new System.Drawing.Size(0, 13);
            this.lblWedgeUnderMouse.TabIndex = 2;
            // 
            // howto_sunburst_chart5_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 387);
            this.Controls.Add(this.lblWedgeUnderMouse);
            this.Controls.Add(this.picSunburst);
            this.Controls.Add(this.trvItems);
            this.Name = "howto_sunburst_chart5_Form1";
            this.Text = "howto_sunburst_chart5";
            this.Load += new System.EventHandler(this.howto_sunburst_chart5_Form1_Load);
            this.Resize += new System.EventHandler(this.howto_sunburst_chart5_Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picSunburst)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView trvItems;
        private System.Windows.Forms.PictureBox picSunburst;
        private System.Windows.Forms.Label lblWedgeUnderMouse;
    }
}

