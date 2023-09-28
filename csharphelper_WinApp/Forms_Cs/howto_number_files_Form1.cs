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
     public partial class howto_number_files_Form1:Form
  { 


        public howto_number_files_Form1()
        {
            InitializeComponent();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            lvwFiles.Items.Clear();

            string[] filenames = Directory.GetFiles(txtDirectory.Text);
            if (filenames.Length == 0) return;
            Array.Sort(filenames);

            int index = int.Parse(txtStartAt.Text);
            string format = "{0:D" + txtStartAt.Text.Length.ToString() + "}";
            string base_name = txtBaseName.Text;
            List<string> old_names = new List<string>();

            foreach (string filename in filenames)
            {
                string old_name = Path.GetFileName(filename);
                old_names.Add(old_name);
                ListViewItem item = lvwFiles.Items.Add(old_name);

                string new_name =
                    base_name +
                    string.Format(format, index) +
                    Path.GetExtension(filename);

                if (old_names.Contains(new_name))
                {
                    MessageBox.Show("Name " + new_name + " is already in use.");
                    break;
                }

                item.SubItems.Add(new_name);
                index++;
            }

            lvwFiles.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwFiles.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            btnRename.Enabled = true;
        }

        private void howto_number_files_Form1_Resize(object sender, EventArgs e)
        {
            lvwFiles.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvwFiles.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            string dirname = txtDirectory.Text;
            foreach (ListViewItem item in lvwFiles.Items)
            {
                string old_name = Path.Combine(dirname, item.Text);
                string new_name = Path.Combine(dirname, item.SubItems[1].Text);
                File.Move(old_name, new_name);
            }

            int num_files = lvwFiles.Items.Count; 
            lvwFiles.Items.Clear();
            btnRename.Enabled = false;
            MessageBox.Show("Renamed " +
                num_files.ToString() + " files.");
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            lvwFiles.Items.Clear();
            btnRename.Enabled = false;
        }

        // Let the user browse for the directory.
        private void btnPickDirectory_Click(object sender, EventArgs e)
        {
            try
            {
                fbdDirectory.SelectedPath = txtDirectory.Text;
            }
            catch
            {
            }

            if (fbdDirectory.ShowDialog() == DialogResult.OK)
            {
                txtDirectory.Text = fbdDirectory.SelectedPath;
            }
        }

        // Restore parameters.
        private void howto_number_files_Form1_Load(object sender, EventArgs e)
        {
            SetBounds(
                Properties.Settings.Default.Left,
                Properties.Settings.Default.Top,
                Properties.Settings.Default.Width,
                Properties.Settings.Default.Height);

            txtDirectory.Text = Properties.Settings.Default.Directory;
            if (txtDirectory.Text.Length == 0) txtDirectory.Text = Application.StartupPath;
        }

        // Save parameters.
        private void howto_number_files_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Left = Left;
            Properties.Settings.Default.Top = Top;
            Properties.Settings.Default.Width = Width;
            Properties.Settings.Default.Height = Height;

            Properties.Settings.Default.Directory = txtDirectory.Text;

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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.txtStartAt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnList = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.lvwFiles = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBaseName = new System.Windows.Forms.TextBox();
            this.btnPickDirectory = new System.Windows.Forms.Button();
            this.fbdDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Directory:";
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Location = new System.Drawing.Point(83, 15);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(263, 20);
            this.txtDirectory.TabIndex = 0;
            this.txtDirectory.Text = "C:\\Users\\Rod\\Desktop\\temp";
            this.txtDirectory.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtStartAt
            // 
            this.txtStartAt.Location = new System.Drawing.Point(83, 67);
            this.txtStartAt.Name = "txtStartAt";
            this.txtStartAt.Size = new System.Drawing.Size(39, 20);
            this.txtStartAt.TabIndex = 2;
            this.txtStartAt.Text = "00";
            this.txtStartAt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtStartAt.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Start At:";
            // 
            // btnList
            // 
            this.btnList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnList.Location = new System.Drawing.Point(115, 93);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(75, 23);
            this.btnList.TabIndex = 3;
            this.btnList.Text = "List";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnRename
            // 
            this.btnRename.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRename.Enabled = false;
            this.btnRename.Location = new System.Drawing.Point(207, 93);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(75, 23);
            this.btnRename.TabIndex = 4;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // lvwFiles
            // 
            this.lvwFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwFiles.Location = new System.Drawing.Point(12, 122);
            this.lvwFiles.Name = "lvwFiles";
            this.lvwFiles.Size = new System.Drawing.Size(372, 127);
            this.lvwFiles.TabIndex = 5;
            this.lvwFiles.UseCompatibleStateImageBehavior = false;
            this.lvwFiles.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Original Name";
            this.columnHeader1.Width = 170;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "New Name";
            this.columnHeader2.Width = 170;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Base Name:";
            // 
            // txtBaseName
            // 
            this.txtBaseName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBaseName.Location = new System.Drawing.Point(83, 41);
            this.txtBaseName.Name = "txtBaseName";
            this.txtBaseName.Size = new System.Drawing.Size(301, 20);
            this.txtBaseName.TabIndex = 1;
            this.txtBaseName.Text = "Vacation";
            // 
            // btnPickDirectory
            // 
            this.btnPickDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickDirectory.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPickDirectory.Image = Properties.Resources.Ellipsis;
            this.btnPickDirectory.Location = new System.Drawing.Point(352, 12);
            this.btnPickDirectory.Name = "btnPickDirectory";
            this.btnPickDirectory.Size = new System.Drawing.Size(32, 24);
            this.btnPickDirectory.TabIndex = 10;
            this.btnPickDirectory.UseVisualStyleBackColor = true;
            this.btnPickDirectory.Click += new System.EventHandler(this.btnPickDirectory_Click);
            // 
            // howto_number_files_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 261);
            this.Controls.Add(this.btnPickDirectory);
            this.Controls.Add(this.txtBaseName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lvwFiles);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.txtStartAt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.label1);
            this.Name = "howto_number_files_Form1";
            this.Text = "howto_number_files";
            this.Load += new System.EventHandler(this.howto_number_files_Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_number_files_Form1_FormClosing);
            this.Resize += new System.EventHandler(this.howto_number_files_Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.TextBox txtStartAt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.ListView lvwFiles;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBaseName;
        internal System.Windows.Forms.Button btnPickDirectory;
        internal System.Windows.Forms.FolderBrowserDialog fbdDirectory;
    }
}

