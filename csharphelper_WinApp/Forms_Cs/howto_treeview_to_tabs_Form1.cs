using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_treeview_to_tabs_Form1:Form
  { 


        public howto_treeview_to_tabs_Form1()
        {
            InitializeComponent();
        }

        private void howto_treeview_to_tabs_Form1_Load(object sender, EventArgs e)
        {
            string path = Application.StartupPath;
            if (!path.EndsWith("\\")) path += "\\";

            // Load the TreeView.
            string file_name = path + "test.txt";
            LoadTreeViewFromFile(file_name, trvItems);

            // Write the TreeView's contents into a file.
            SaveTreeViewIntoFile(path + "New.txt", trvItems);
        }

        // Load a TreeView control from a file that uses tabs
        // to show indentation.
        private void LoadTreeViewFromFile(string file_name, TreeView trv)
        {
            // Get the file's contents.
            string file_contents = File.ReadAllText(file_name);

            // Break the file into lines.
            string[] lines = file_contents.Split(
                new char[] { '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries);

            // Process the lines.
            trv.Nodes.Clear();
            Dictionary<int, TreeNode> parents =
                new Dictionary<int, TreeNode>();
            foreach (string text_line in lines)
            {
                // See how many tabs are at the start of the line.
                int level = text_line.Length -
                    text_line.TrimStart('\t').Length;

                // Add the new node.
                if (level == 0)
                    parents[level] = trv.Nodes.Add(text_line.Trim());
                else
                    parents[level] = parents[level - 1].Nodes.Add(text_line.Trim());
                parents[level].EnsureVisible();
            }

            if (trv.Nodes.Count > 0) trv.Nodes[0].EnsureVisible();
        }

        // Write the TreeView's values into a file that uses tabs
        // to show indentation.
        private void SaveTreeViewIntoFile(string file_name, TreeView trv)
        {
            // Build a string containing the TreeView's contents.
            StringBuilder sb = new StringBuilder();
            foreach (TreeNode node in trv.Nodes)
                WriteNodeIntoString(0, node, sb);

            // Write the result into the file.
            File.WriteAllText(file_name, sb.ToString());
        }

        // Write this node's subtree into the StringBuilder.
        private void WriteNodeIntoString(int level, TreeNode node, StringBuilder sb)
        {
            // Append the correct number of tabs and the node's text.
            sb.AppendLine(new string('\t', level) + node.Text);

            // Recursively add children with one greater level of tabs.
            foreach (TreeNode child in node.Nodes)
                WriteNodeIntoString(level + 1, child, sb);
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
            this.trvItems.Size = new System.Drawing.Size(347, 287);
            this.trvItems.TabIndex = 3;
            // 
            // howto_treeview_to_tabs_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 287);
            this.Controls.Add(this.trvItems);
            this.Name = "howto_treeview_to_tabs_Form1";
            this.Text = "howto_treeview_to_tabs";
            this.Load += new System.EventHandler(this.howto_treeview_to_tabs_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TreeView trvItems;
    }
}

