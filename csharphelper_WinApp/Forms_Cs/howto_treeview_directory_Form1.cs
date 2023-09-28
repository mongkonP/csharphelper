using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

 

using howto_treeview_directory;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_treeview_directory_Form1:Form
  { 


        public howto_treeview_directory_Form1()
        {
            InitializeComponent();
        }

        // Go up two directories and build a TreeView from there.
        private void howto_treeview_directory_Form1_Load(object sender, EventArgs e)
        {
            string dir = Path.Combine(Environment.CurrentDirectory, "..\\..");
            DirectoryInfo dir_info = new DirectoryInfo(dir);

            trvDirectory.LoadFromDirectory(dir_info.FullName, 0, 1);
            trvDirectory.ExpandAll();
            trvDirectory.SelectedNode = trvDirectory.Nodes[0];
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_treeview_directory_Form1));
            this.imlFiles = new System.Windows.Forms.ImageList(this.components);
            this.trvDirectory = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // imlFiles
            // 
            this.imlFiles.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlFiles.ImageStream")));
            this.imlFiles.TransparentColor = System.Drawing.Color.Transparent;
            this.imlFiles.Images.SetKeyName(0, "Folder_Open.png");
            this.imlFiles.Images.SetKeyName(1, "Document_Text.png");
            // 
            // trvDirectory
            // 
            this.trvDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trvDirectory.ImageIndex = 0;
            this.trvDirectory.ImageList = this.imlFiles;
            this.trvDirectory.Location = new System.Drawing.Point(12, 12);
            this.trvDirectory.Name = "trvDirectory";
            this.trvDirectory.SelectedImageIndex = 0;
            this.trvDirectory.Size = new System.Drawing.Size(360, 237);
            this.trvDirectory.TabIndex = 1;
            // 
            // howto_treeview_directory_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.trvDirectory);
            this.Name = "howto_treeview_directory_Form1";
            this.Text = "howto_treeview_directory";
            this.Load += new System.EventHandler(this.howto_treeview_directory_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imlFiles;
        private System.Windows.Forms.TreeView trvDirectory;
    }
}

