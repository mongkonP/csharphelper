using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

 

using howto_mru_list2;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_mru_list2_Form1:Form
  { 


        public howto_mru_list2_Form1()
        {
            InitializeComponent();
        }

        // The MruList.
        private MruList MyMruList;

        // Make the MruList.
        private void howto_mru_list2_Form1_Load(object sender, EventArgs e)
        {
            MyMruList = new MruList(this, mnuFile, 4);
            MyMruList.FileSelected += MyMruList_FileSelected;
        }

        // Open a file.
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                OpenFile(ofdFile.FileName);
            }
        }

        // Open a file and add it to the MRU list.
        private void OpenFile(string file_name)
        {
            try
            {
                // Load the file.
                rchFile.Clear();
                if (file_name.ToLower().EndsWith(".rtf"))
                {
                    rchFile.LoadFile(file_name);
                }
                else
                {
                    rchFile.Text = File.ReadAllText(file_name);
                }

                // Add the file to the MRU list.
                MyMruList.AddFile(file_name);
            }
            catch (Exception ex)
            {
                // Remove the file from the MRU list.
                MyMruList.RemoveFile(file_name);

                // Tell the user what happened.
                MessageBox.Show(ex.Message);
            }
        }

        // Open a file selected from the MRU list.
        private void MyMruList_FileSelected(string file_name)
        {
            OpenFile(file_name);
        }

        // Methods to get and save the MRU list file paths.
        public string GetMruFilePaths()
        {
            return Properties.Settings.Default.FilePaths;
        }

        public void SaveMruFilePaths(string paths)
        {
            Properties.Settings.Default.FilePaths = paths;
            Properties.Settings.Default.Save();
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
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.rchFile = new System.Windows.Forms.RichTextBox();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(152, 22);
            this.mnuFileOpen.Text = "&Open";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // rchFile
            // 
            this.rchFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.rchFile.Location = new System.Drawing.Point(0, 24);
            this.rchFile.Name = "rchFile";
            this.rchFile.Size = new System.Drawing.Size(284, 137);
            this.rchFile.TabIndex = 5;
            this.rchFile.Text = "";
            // 
            // ofdFile
            // 
            this.ofdFile.FileName = "openFileDialog1";
            this.ofdFile.Filter = "Text Files|*.txt;*.rtf|All Files|*.*";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // howto_mru_list2_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.rchFile);
            this.Controls.Add(this.menuStrip1);
            this.Name = "howto_mru_list2_Form1";
            this.Text = "howto_mru_list2";
            this.Load += new System.EventHandler(this.howto_mru_list2_Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.RichTextBox rchFile;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

