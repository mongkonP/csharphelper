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
     public partial class howto_compare_directories_Form1:Form
  { 


        public howto_compare_directories_Form1()
        {
            InitializeComponent();
        }

        private void howto_compare_directories_Form1_Load(object sender, EventArgs e)
        {
            string base_dir = Application.StartupPath;
            if (base_dir.EndsWith("\\bin\\Debug"))
            {
                base_dir = base_dir.Substring(0, base_dir.Length - 10);
            }

            txtDir1.Text = base_dir + "\\Dir1";
            txtDir2.Text = base_dir + "\\Dir2";

            SizeColumns();
        }

        private void howto_compare_directories_Form1_Resize(object sender, EventArgs e)
        {
            SizeColumns();
        }

        private void SizeColumns()
        {
            int wid = (int)((dgvFiles.Width - 50) / 2);
            if (wid < 10) wid = 10;
            dgvFiles.Columns[0].Width = wid;
            dgvFiles.Columns[1].Width = wid;
        }

        // Compare the files in each directory.
        private void btnCompare_Click(object sender, EventArgs e)
        {
            // Clear previous results.
            dgvFiles.Rows.Clear();

            // Get sorted lists of files in the directories.
            string dir1 = txtDir1.Text;
            if (!dir1.EndsWith("\\")) dir1 += "\\";
            string[] file_names1 = Directory.GetFiles(dir1);
            for (int i = 0; i < file_names1.Length; i++)
            {
                file_names1[i] = file_names1[i].Replace(dir1, "");
            }
            Array.Sort(file_names1);

            string dir2 = txtDir2.Text;
            if (!dir2.EndsWith("\\")) dir2 += "\\";
            string[] file_names2 = Directory.GetFiles(dir2);
            for (int i = 0; i < file_names2.Length; i++)
            {
                file_names2[i] = file_names2[i].Replace(dir2, "");
            }
            Array.Sort(file_names2);

            // Compare.
            int i1 = 0, i2 = 0;
            while ((i1 < file_names1.Length) && (i2 < file_names2.Length))
            {
                if (file_names1[i1] == file_names2[i2])
                {
                    // They match. Display them both.
                    dgvFiles.Rows.Add(new Object[] { file_names1[i1], file_names2[i2] });
                    i1++;
                    i2++;
                }
                else if (file_names1[i1].CompareTo(file_names2[i2]) < 0)
                {
                    // Display the directory 1 file.
                    dgvFiles.Rows.Add(new Object[] { file_names1[i1], null });
                    i1++;
                }
                else
                {
                    // Display the directory 2 file.
                    dgvFiles.Rows.Add(new Object[] { null, file_names2[i2] });
                    i2++;
                }
            }

            // Display remaining directory 1 files.
            for (int i = i1; i < file_names1.Length; i++)
            {
                dgvFiles.Rows.Add(new Object[] { file_names1[i], null });
            }

            // Display remaining directory 2 files.
            for (int i = i2; i < file_names2.Length; i++)
            {
                dgvFiles.Rows.Add(new Object[] { null, file_names2[i] });
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
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.colDir1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dir2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnCompare = new System.Windows.Forms.Button();
            this.txtDir2 = new System.Windows.Forms.TextBox();
            this.txtDir1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFiles
            // 
            this.dgvFiles.AllowUserToAddRows = false;
            this.dgvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDir1,
            this.Dir2});
            this.dgvFiles.Location = new System.Drawing.Point(8, 104);
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.Size = new System.Drawing.Size(467, 208);
            this.dgvFiles.TabIndex = 14;
            // 
            // colDir1
            // 
            this.colDir1.HeaderText = "Directory 1";
            this.colDir1.Name = "colDir1";
            // 
            // Dir2
            // 
            this.Dir2.HeaderText = "Directory 2";
            this.Dir2.Name = "Dir2";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(8, 32);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(61, 13);
            this.Label2.TabIndex = 13;
            this.Label2.Text = "Directory 2:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(8, 8);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(61, 13);
            this.Label1.TabIndex = 12;
            this.Label1.Text = "Directory 1:";
            // 
            // btnCompare
            // 
            this.btnCompare.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCompare.Location = new System.Drawing.Point(210, 56);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(64, 40);
            this.btnCompare.TabIndex = 11;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // txtDir2
            // 
            this.txtDir2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDir2.Location = new System.Drawing.Point(72, 8);
            this.txtDir2.Name = "txtDir2";
            this.txtDir2.Size = new System.Drawing.Size(404, 20);
            this.txtDir2.TabIndex = 9;
            // 
            // txtDir1
            // 
            this.txtDir1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDir1.Location = new System.Drawing.Point(72, 32);
            this.txtDir1.Name = "txtDir1";
            this.txtDir1.Size = new System.Drawing.Size(404, 20);
            this.txtDir1.TabIndex = 10;
            // 
            // howto_compare_directories_Form1
            // 
            this.AcceptButton = this.btnCompare;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 320);
            this.Controls.Add(this.dgvFiles);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.txtDir2);
            this.Controls.Add(this.txtDir1);
            this.Name = "howto_compare_directories_Form1";
            this.Text = "howto_compare_directories";
            this.Load += new System.EventHandler(this.howto_compare_directories_Form1_Load);
            this.Resize += new System.EventHandler(this.howto_compare_directories_Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgvFiles;
        internal System.Windows.Forms.DataGridViewTextBoxColumn colDir1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Dir2;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnCompare;
        internal System.Windows.Forms.TextBox txtDir2;
        internal System.Windows.Forms.TextBox txtDir1;
    }
}

