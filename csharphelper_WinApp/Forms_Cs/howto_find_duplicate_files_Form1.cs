using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Note there is a bug in the TreeView control. If you double-click a node,
// the node's appearance changes but its Checked property doesn't change.
// You can fix this by subclassing the TreeView and ignoring WM_LBUTTONDBLCLK messages.
//
//  public class MyTreeView : TreeView
//  {
//      protected override void WndProc(ref Message m)
//      {
//          // Suppress WM_LBUTTONDBLCLK
//          if (m.Msg == 0x203)
//          {
//              m.Result = IntPtr.Zero;
//          }
//          else base.WndProc(ref m);
//      }
//  }
//
// The TreeView also has the annoying habit of displaying each node's text
// in a tooltip if the control isn't wide enough to show it's whole value.

// Add a references to Microsoft.VisualBasic.
using Microsoft.VisualBasic.FileIO;

using System.IO;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Diagnostics;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_find_duplicate_files_Form1:Form
  { 


        public howto_find_duplicate_files_Form1()
        {
            InitializeComponent();
        }

        // Save and restore the directory path.
        private void howto_find_duplicate_files_Form1_Load(object sender, EventArgs e)
        {
            txtDirectory.Text = Properties.Settings.Default.Directory;

            splitContainer1.Panel2.BackColor = Color.White;

            // Prepare the preview controls.
            picImage.SizeMode = PictureBoxSizeMode.Zoom;
            picImage.Dock = DockStyle.Fill;
            picImage.Visible = false;
            rchText.Dock = DockStyle.Fill;
            rchText.Visible = false;
        }

        private void howto_find_duplicate_files_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Directory = txtDirectory.Text;
            Properties.Settings.Default.Save();
        }

        // Let the user browse for a folder.
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            fbdDirectory.SelectedPath = txtDirectory.Text;
            if (fbdDirectory.ShowDialog() == DialogResult.OK)
                txtDirectory.Text = fbdDirectory.SelectedPath;
        }

        // Search the directory for duplicates.
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            Cursor = Cursors.WaitCursor;
            trvFiles.Visible = false;
            trvFiles.Nodes.Clear();
            lblNumDuplicates.Text = "";
            Refresh();

            try
            {
                // Get a list of the files and their hash values.
                var get_info =
                    from string filename in Directory.GetFiles(txtDirectory.Text)
                    select new
                    {
                        Name = filename,
                        Hash = BytesToString(GetHash(filename))
                    };

                // Group the files by hash value.
                var group_infos =
                    from info in get_info
                    group info by info.Hash into g
                    where g.Count() > 1
                    //orderby g.Key
                    select g;

                // Loop through the files.
                int num_groups = 0;
                int num_files = 0;
                foreach (var g in group_infos)
                {
                    num_groups++;
                    TreeNode hash_node = trvFiles.Nodes.Add(g.Key.ToString());
                    foreach (var info in g)
                    {
                        num_files++;
                        TreeNode file_node = new TreeNode(info.Name);
                        file_node.Tag = new FileInfo(info.Name);
                        hash_node.Nodes.Add(file_node);
                    }
                }

                // Display the number of duplicates.
                lblNumDuplicates.Text =
                    (num_files - num_groups).ToString() +
                    " duplicate files";

                // Expand all nodes.
                trvFiles.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Scroll to the top.
                if (trvFiles.Nodes.Count > 0)
                    trvFiles.Nodes[0].EnsureVisible();
                trvFiles.Visible = true;

                Cursor = Cursors.Default;
            }

            watch.Stop();
            Console.WriteLine(watch.Elapsed.TotalSeconds.ToString("0.00") + " seconds");
        }

        // Display the clicked file.
        private void trvFiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (Deleting) return;

            // Hide the display controls.
            rchText.Visible = false;
            picImage.Visible = false;
            Refresh();

            // Do nothing for size nodes.
            if (e.Node.Level == 0) return;

            // Get the file's information.
            FileInfo file_info = e.Node.Tag as FileInfo;
            switch (file_info.Extension.ToLower())
            {
                case ".txt":    // Text files.
                case ".html":
                case ".cs":
                case ".csproj":
                case ".resx":
                case ".xml":
                case ".xaml":
                case ".config":
                    rchText.Text = File.ReadAllText(file_info.FullName);
                    rchText.Visible = true;
                    break;

                case ".rtf":    // Rich text.
                    rchText.LoadFile(file_info.FullName);
                    rchText.Visible = true;
                    break;

                case ".jpg":    // Image files.
                case ".jpeg":
                case ".gif":
                case ".png":
                case ".tiff":
                case ".bmp":
                    picImage.Image = LoadBitmapUnlocked(file_info.FullName);
                    picImage.Visible = true;
                    break;

                default:
                    rchText.Text = "Unknown file extension " + file_info.Extension;
                    rchText.Visible = true;
                    break;
            }
        }

        // Select all but the first file in each group.
        private void btnSelectDuplicates_Click(object sender, EventArgs e)
        {
            foreach (TreeNode hash_node in trvFiles.Nodes)
            {
                hash_node.Checked = false;
                hash_node.Nodes[0].Checked = false;
                for (int i = 1; i < hash_node.Nodes.Count; i++)
                    hash_node.Nodes[i].Checked = true;
            }
        }

        // Delete the selected files.
        private bool Deleting = false;
        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            Deleting = true;
            trvFiles.Visible = false;
            lblNumDuplicates.Text = "";
            picImage.Visible = false;
            picImage.Image = null;
            rchText.Visible = false;
            Cursor = Cursors.WaitCursor;
            Refresh();

            try
            {
                // Make a list of nodes to delete.
                List<TreeNode> nodes_to_delete = new List<TreeNode>();
                foreach (TreeNode hash_node in trvFiles.Nodes)
                {
                    foreach (TreeNode file_node in hash_node.Nodes)
                    {
                        // See if the file's node is checked.
                        if (file_node.Checked) nodes_to_delete.Add(file_node);
                    }
                }

                // Delete the selected nodes and their files.
                foreach (TreeNode file_node in nodes_to_delete)
                {
                    // Get the FileInfo from the Tag property.
                    FileInfo file_info = file_node.Tag as FileInfo;

                    // Move the file into the recycle bin.
                    DeleteFile(file_info.FullName);

                    // Remove the file from the TreeView.
                    file_node.Remove();
                }

                // Make a list of size nodes with no remaining children.
                nodes_to_delete = new List<TreeNode>();
                foreach (TreeNode hash_node in trvFiles.Nodes)
                {
                    if (hash_node.Nodes.Count == 0) nodes_to_delete.Add(hash_node);
                }

                // Delete the size nodes with no remaining children.
                foreach (TreeNode hash_node in nodes_to_delete)
                {
                    hash_node.Remove();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Scroll to the top.
                if (trvFiles.Nodes.Count > 0)
                    trvFiles.Nodes[0].EnsureVisible();
                trvFiles.Visible = true;

                Deleting = false;
                Cursor = Cursors.Default;
            }
        }

        // Delete a file or move it to the recycle bin.
        public static void DeleteFile(string filename)
        {
            DeleteFile(filename, false, false);
        }
        public static void DeleteFile(string filename, bool confirm)
        {
            DeleteFile(filename, confirm, false);
        }
        public static void DeleteFile(string filename, bool confirm, bool delete_permanently)
        {
            UIOption ui_option = UIOption.OnlyErrorDialogs;
            if (confirm) ui_option = UIOption.AllDialogs;

            RecycleOption recycle_option =
                recycle_option = RecycleOption.SendToRecycleBin;
            if (delete_permanently)
                recycle_option = RecycleOption.DeletePermanently;

            try
            {
                FileSystem.DeleteFile(filename, ui_option, recycle_option);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting file.\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // If the user checks or unchecks a size node,
        // check or uncheck its file nodes.
        private void trvFiles_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // If this is a size node, check or uncheck its file nodes.
            if (e.Node.Level == 0)
            {
                foreach (TreeNode file_node in e.Node.Nodes)
                {
                    file_node.Checked = e.Node.Checked;
                }
            }
        }

        // The cryptographic service provider.
        private MD5 Md5 = MD5.Create();

        // Compute the file's hash.
        private byte[] GetHash(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                return Md5.ComputeHash(stream);
            }
        }

        // Return a hash code as a string.
        private string BytesToString(byte[] bytes)
        {
            string result = "";
            foreach (byte b in bytes) result += b.ToString("x2");
            return result;
        }

        // Load a bitmap without locking it.
        private Bitmap LoadBitmapUnlocked(string file_name)
        {
            using (Bitmap bm = new Bitmap(file_name))
            {
                return new Bitmap(bm);
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
            this.lblNumDuplicates = new System.Windows.Forms.Label();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.btnSelectDuplicates = new System.Windows.Forms.Button();
            this.rchText = new System.Windows.Forms.RichTextBox();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.trvFiles = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.fbdDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNumDuplicates
            // 
            this.lblNumDuplicates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNumDuplicates.AutoSize = true;
            this.lblNumDuplicates.Location = new System.Drawing.Point(3, 267);
            this.lblNumDuplicates.Name = "lblNumDuplicates";
            this.lblNumDuplicates.Size = new System.Drawing.Size(0, 13);
            this.lblNumDuplicates.TabIndex = 7;
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteSelected.Location = new System.Drawing.Point(120, 283);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(111, 23);
            this.btnDeleteSelected.TabIndex = 6;
            this.btnDeleteSelected.Text = "Delete Selected";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // btnSelectDuplicates
            // 
            this.btnSelectDuplicates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectDuplicates.Location = new System.Drawing.Point(3, 283);
            this.btnSelectDuplicates.Name = "btnSelectDuplicates";
            this.btnSelectDuplicates.Size = new System.Drawing.Size(111, 23);
            this.btnSelectDuplicates.TabIndex = 5;
            this.btnSelectDuplicates.Text = "Select Duplicates";
            this.btnSelectDuplicates.UseVisualStyleBackColor = true;
            this.btnSelectDuplicates.Click += new System.EventHandler(this.btnSelectDuplicates_Click);
            // 
            // rchText
            // 
            this.rchText.Location = new System.Drawing.Point(60, 48);
            this.rchText.Name = "rchText";
            this.rchText.Size = new System.Drawing.Size(100, 96);
            this.rchText.TabIndex = 2;
            this.rchText.Text = "";
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(19, 180);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(100, 50);
            this.picImage.TabIndex = 1;
            this.picImage.TabStop = false;
            // 
            // trvFiles
            // 
            this.trvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trvFiles.CheckBoxes = true;
            this.trvFiles.Location = new System.Drawing.Point(3, 3);
            this.trvFiles.Name = "trvFiles";
            this.trvFiles.Size = new System.Drawing.Size(279, 261);
            this.trvFiles.TabIndex = 0;
            this.trvFiles.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trvFiles_AfterCheck);
            this.trvFiles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvFiles_AfterSelect);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 40);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblNumDuplicates);
            this.splitContainer1.Panel1.Controls.Add(this.btnDeleteSelected);
            this.splitContainer1.Panel1.Controls.Add(this.btnSelectDuplicates);
            this.splitContainer1.Panel1.Controls.Add(this.trvFiles);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.picImage);
            this.splitContainer1.Panel2.Controls.Add(this.rchText);
            this.splitContainer1.Size = new System.Drawing.Size(560, 309);
            this.splitContainer1.SplitterDistance = 285;
            this.splitContainer1.TabIndex = 9;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(497, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Image = Properties.Resources.EllipsisTransparent;
            this.btnBrowse.Location = new System.Drawing.Point(463, 12);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(28, 23);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Location = new System.Drawing.Point(70, 14);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(387, 20);
            this.txtDirectory.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Directory:";
            // 
            // howto_find_duplicate_files_Form1
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.label1);
            this.Name = "howto_find_duplicate_files_Form1";
            this.Text = "howto_find_duplicate_files";
            this.Load += new System.EventHandler(this.howto_find_duplicate_files_Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_find_duplicate_files_Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumDuplicates;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.Button btnSelectDuplicates;
        private System.Windows.Forms.RichTextBox rchText;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.TreeView trvFiles;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.FolderBrowserDialog fbdDirectory;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Label label1;
    }
}

