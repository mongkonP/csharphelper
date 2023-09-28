using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml;
using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_load_treeview_from_xml_Form1:Form
  { 


        public howto_load_treeview_from_xml_Form1()
        {
            InitializeComponent();
        }

        private void howto_load_treeview_from_xml_Form1_Load(object sender, EventArgs e)
        {
            string filename = Application.StartupPath;
            filename = System.IO.Path.Combine(filename, "..\\..");
            filename = Path.GetFullPath(filename) + "\\test.xml";
            LoadTreeViewFromXmlFile(filename, trvItems);
        }

        // Load a TreeView control from an XML file.
        private void LoadTreeViewFromXmlFile(string filename, TreeView trv)
        {
            // Load the XML document.
            XmlDocument xml_doc = new XmlDocument();
            xml_doc.Load(filename);

            // Add the root node's children to the TreeView.
            trv.Nodes.Clear();
            AddTreeViewChildNodes(trv.Nodes, xml_doc.DocumentElement);
        }

        // Add the children of this XML node 
        // to this child nodes collection.
        private void AddTreeViewChildNodes(TreeNodeCollection parent_nodes, XmlNode xml_node)
        {
            foreach (XmlNode child_node in xml_node.ChildNodes)
            {
                // Make the new TreeView node.
                TreeNode new_node = parent_nodes.Add(child_node.Name);

                // Recursively make this node's descendants.
                AddTreeViewChildNodes(new_node.Nodes, child_node);

                // If this is a leaf node, make sure it's visible.
                if (new_node.Nodes.Count == 0) new_node.EnsureVisible();
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
            this.SuspendLayout();
            // 
            // trvItems
            // 
            this.trvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvItems.Location = new System.Drawing.Point(0, 0);
            this.trvItems.Name = "trvItems";
            this.trvItems.Size = new System.Drawing.Size(344, 294);
            this.trvItems.TabIndex = 1;
            // 
            // howto_load_treeview_from_xml_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 294);
            this.Controls.Add(this.trvItems);
            this.Name = "howto_load_treeview_from_xml_Form1";
            this.Text = "howto_load_treeview_from_xml";
            this.Load += new System.EventHandler(this.howto_load_treeview_from_xml_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TreeView trvItems;
    }
}

