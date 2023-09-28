using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;
using System.Management;    // Add a reference to System.Management.

 

using howto_process_tree;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_process_tree_Form1:Form
  { 


        public howto_process_tree_Form1()
        {
            InitializeComponent();
        }

        private int NumProcesses, NumThreads;

        private void btnLoad_Click(object sender, EventArgs e)
        {
            trvProcesses.Nodes.Clear();
            Stopwatch watch = new Stopwatch();
            watch.Start();

            Dictionary<int, ProcessInfo> process_dict =
                new Dictionary<int, ProcessInfo>();

            // Get the processes.
            foreach (Process process in Process.GetProcesses())
            {
                process_dict.Add(process.Id, new ProcessInfo(process));
            }

            // Get the parent/child info.
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(
               "SELECT ProcessId, ParentProcessId FROM Win32_Process");
            ManagementObjectCollection collection = searcher.Get();

            // Create the child lists.
            foreach (var item in collection)
            {
                // Find the parent and child in the dictionary.
                int child_id = Convert.ToInt32(item["ProcessId"]);
                int parent_id = Convert.ToInt32(item["ParentProcessId"]);

                ProcessInfo child_info = null;
                ProcessInfo parent_info = null;
                if (process_dict.ContainsKey(child_id))
                    child_info = process_dict[child_id];
                if (process_dict.ContainsKey(parent_id))
                    parent_info = process_dict[parent_id];

                if (child_info == null)
                    Console.WriteLine(
                        "Cannot find child " + child_id.ToString() +
                        " for parent " + parent_id.ToString());

                if (parent_info == null)
                    Console.WriteLine(
                        "Cannot find parent " + parent_id.ToString() +
                        " for child " + child_id.ToString());

                if ((child_info != null) && (parent_info != null))
                {
                    parent_info.Children.Add(child_info);
                    child_info.Parent = parent_info;
                }
            }

            // Convert the dictionary into a list.
            List<ProcessInfo> infos = process_dict.Values.ToList();

            // Sort the list.
            infos.Sort();

            // Populate the TreeView.
            NumProcesses = 0;
            NumThreads = 0;
            foreach (ProcessInfo info in infos)
            {
                // Start with root processes.
                if (info.Parent != null) continue;

                // Add this process to the TreeView.
                AddInfoToTree(trvProcesses.Nodes, info);
            }
            lblCounts.Text =
                "# Processes: " + 
                NumProcesses.ToString() + ", " +
                "# Threads : " +
                NumThreads.ToString();

            watch.Stop();
            Console.WriteLine(string.Format("{0:0.00} seconds",
                watch.Elapsed.TotalSeconds));
        }

        // Add a ProcessInfo, its children, and its threads to the tree.
        private void AddInfoToTree(TreeNodeCollection nodes, ProcessInfo info)
        {
            // Add the process's node.
            TreeNode process_node = nodes.Add(info.ToString());
            process_node.Tag = info;
            NumProcesses++;

            // Add the node's threads.
            if (info.TheProcess.Threads.Count > 0)
            {
                TreeNode thread_node = process_node.Nodes.Add("Threads");
                foreach (ProcessThread thread in info.TheProcess.Threads)
                {
                    thread_node.Nodes.Add(string.Format(
                        "Thread {0}", thread.Id));
                    NumThreads++;
                }
            }

            // Sort the children.
            info.Children.Sort();

            // Add child processes.
            foreach (ProcessInfo child_info in info.Children)
            {
                AddInfoToTree(process_node.Nodes, child_info);
            }

            // Expand the main process node.
            if (info.Children.Count > 0)
                process_node.Expand();
        }

        // Kill the selected process.
        private void trvProcesses_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //TreeNode node = e.Node;
            //ProcessInfo process_info = node.Tag as ProcessInfo;
            //if (MessageBox.Show("Kill " + process_info.ToString() + "?",
            //    "Kill Process?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    process_info.TheProcess.Kill();
            //}                
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
            this.trvProcesses = new System.Windows.Forms.TreeView();
            this.lblCounts = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // trvProcesses
            // 
            this.trvProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trvProcesses.Location = new System.Drawing.Point(12, 41);
            this.trvProcesses.Name = "trvProcesses";
            this.trvProcesses.Size = new System.Drawing.Size(260, 295);
            this.trvProcesses.TabIndex = 0;
            this.trvProcesses.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvProcesses_AfterSelect);
            // 
            // lblCounts
            // 
            this.lblCounts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCounts.AutoSize = true;
            this.lblCounts.Location = new System.Drawing.Point(12, 339);
            this.lblCounts.Name = "lblCounts";
            this.lblCounts.Size = new System.Drawing.Size(0, 13);
            this.lblCounts.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(105, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // howto_process_tree_Form1
            // 
            this.AcceptButton = this.btnLoad;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.lblCounts);
            this.Controls.Add(this.trvProcesses);
            this.Name = "howto_process_tree_Form1";
            this.Text = "howto_process_tree";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView trvProcesses;
        private System.Windows.Forms.Label lblCounts;
        private System.Windows.Forms.Button btnLoad;

    }
}

