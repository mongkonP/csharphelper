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

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_sunburst_chart2_Form1:Form
  { 


        public howto_sunburst_chart2_Form1()
        {
            InitializeComponent();
        }

        private XmlDocument XmlDoc = new XmlDocument();

        private void howto_sunburst_chart2_Form1_Load(object sender, EventArgs e)
        {
            // Load the XML document.
            XmlDoc.Load("test.xml");

            // Load the TreeView.
            LoadTreeViewFromXmlDoc(XmlDoc, trvItems);
            trvItems.ExpandAll();

            // Make the sun burst chart.
            MakeSunburst();
        }
        private void howto_sunburst_chart2_Form1_Resize(object sender, EventArgs e)
        {
            MakeSunburst();
        }

        // Make the sunburst chart for the current size.
        private void MakeSunburst()
        {
            using (Font font = new Font("Arial", 10, FontStyle.Bold))
            {
                picSunburst.Image = MakeSunburst(
                    picSunburst.ClientSize.Width,
                    picSunburst.ClientSize.Height,
                    4, XmlDoc, Color.White, Pens.Blue, font);
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
            XmlDocument xml_doc, Color bm_color, Pen arc_pen, Font font)
        {
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(bm_color);
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                // See how deep we must go.
                int depth = FindDepth(xml_doc.DocumentElement);

                // Calculate geometry.
                float cx = wid / 2f;
                float cy = hgt / 2f;
                wid -= 2 * margin;
                hgt -= 2 * margin;
                float dr = (Math.Min(wid, hgt) / 2f / depth);

#if xDEBUG
                // Draw circles.
                using (Pen pen = new Pen(Color.LightGreen, 5))
                {
                    for (int i = 1; i <= depth; i++)
                    {
                        RectangleF crect = new RectangleF(
                            cx - dr * i, cy - dr * i,
                            2 * dr * i, 2 * dr * i);
                        gr.DrawEllipse(pen, crect);
                    }
                }
#endif

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
                DrawCenteredText(gr, font, fg_color,
                    XmlDoc.DocumentElement.Name,
                    new PointF(cx, cy), 0);

                // Draw the other nodes.
                DrawSunburstChildren(gr, cx, cy, dr, 1,
                    XmlDoc.DocumentElement.ChildNodes,
                    0, 360, font, bg_color, fg_color);
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
            Font font, Color parent_bg_color, Color parent_fg_color)
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
                    out child_bg_color, out child_fg_color);

                // Draw this child's children.
                DrawSunburstChildren(gr, cx, cy, dr, level + 1,
                    child.ChildNodes, angle, angle + dangle, font,
                    child_bg_color, child_fg_color);

                // Move to the next child's section.
                angle = angle + dangle;
            }
        }

        // Draw a single node.
        private void DrawSunburstChild(Graphics gr,
            float cx, float cy, float dr, int level,
            XmlNode node, float min_angle, float max_angle, Font font,
            Color default_bg_color, Color default_fg_color,
            out Color bg_color, out Color fg_color)
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

            bg_color = GetNodeColor(node, "BgColor", default_bg_color);
            using (Brush brush = new SolidBrush(bg_color))
            {
                gr.FillPath(brush, path);
            }
            gr.DrawPath(Pens.Black, path);

            // Draw the text.
            double mid_theta = (min_theta + max_theta) / 2;
            float text_angle = (float)(90 + mid_theta / Math.PI * 180);
            float mid_r = (inner_r + outer_r) / 2;
            float text_x = (float)(cx + mid_r * Math.Cos(mid_theta));
            float text_y = (float)(cy + mid_r * Math.Sin(mid_theta));
            string text = node.Name;
            fg_color = GetNodeColor(node, "FgColor", default_fg_color);
            DrawCenteredText(gr, font, fg_color, text,
                new PointF(text_x, text_y), text_angle);
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

        // Draw text centered at the position.
        private void DrawCenteredText(Graphics gr, Font font, Color color,
            string text, PointF center, float angle)
        {
            // Rotate.
            gr.RotateTransform(angle);

            // Translate.
            gr.TranslateTransform(center.X, center.Y, MatrixOrder.Append);

            // Draw the text.
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                using (Brush brush = new SolidBrush(color))
                {
                    gr.DrawString(text, font, brush, 0, 0, sf);
                }
            }

            // Reset the transformation.
            gr.ResetTransform();
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
            ((System.ComponentModel.ISupportInitialize)(this.picSunburst)).BeginInit();
            this.SuspendLayout();
            // 
            // trvItems
            // 
            this.trvItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.trvItems.Location = new System.Drawing.Point(12, 12);
            this.trvItems.Name = "trvItems";
            this.trvItems.Size = new System.Drawing.Size(181, 273);
            this.trvItems.TabIndex = 0;
            // 
            // picSunburst
            // 
            this.picSunburst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picSunburst.BackColor = System.Drawing.Color.White;
            this.picSunburst.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picSunburst.Location = new System.Drawing.Point(199, 12);
            this.picSunburst.Name = "picSunburst";
            this.picSunburst.Size = new System.Drawing.Size(273, 273);
            this.picSunburst.TabIndex = 1;
            this.picSunburst.TabStop = false;
            // 
            // howto_sunburst_chart2_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 297);
            this.Controls.Add(this.picSunburst);
            this.Controls.Add(this.trvItems);
            this.Name = "howto_sunburst_chart2_Form1";
            this.Text = "howto_sunburst_chart";
            this.Load += new System.EventHandler(this.howto_sunburst_chart2_Form1_Load);
            this.Resize += new System.EventHandler(this.howto_sunburst_chart2_Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picSunburst)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trvItems;
        private System.Windows.Forms.PictureBox picSunburst;
    }
}

