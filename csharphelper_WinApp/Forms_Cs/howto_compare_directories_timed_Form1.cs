using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_compare_directories_timed_Form1:Form
  { 


        public howto_compare_directories_timed_Form1()
        {
            InitializeComponent();
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            txtGetFilesTime.Clear();
            txtLinqTwiceTime.Clear();
            txtLinqJoinsTime.Clear();
            txtGetFilesTime.Refresh();
            txtLinqTwiceTime.Refresh();
            txtLinqJoinsTime.Refresh();

            string dir1 = txtDir1.Text;
            if (!dir1.EndsWith("\\")) dir1 += "\\";
            string dir2 = txtDir2.Text;
            if (!dir2.EndsWith("\\")) dir2 += "\\";

            int num_trials = 10;

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int i = 0; i < num_trials; i++) Compare_GetFiles(dir1, dir2);
            stopwatch.Stop();
            txtGetFilesTime.Text = stopwatch.Elapsed.TotalSeconds.ToString("0.00");
            txtGetFilesTime.Refresh();

            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < num_trials; i++) Compare_LinqTwice(dir1, dir2);
            stopwatch.Stop();
            txtLinqTwiceTime.Text = stopwatch.Elapsed.TotalSeconds.ToString("0.00");
            txtLinqTwiceTime.Refresh();

            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < num_trials; i++) Compare_LinqJoins(dir1, dir2);
            stopwatch.Stop();
            txtLinqJoinsTime.Text = stopwatch.Elapsed.TotalSeconds.ToString("0.00");
            txtLinqJoinsTime.Refresh();

            Cursor = Cursors.Default;
        }

        // Use Directory.GetFiles to compare the files in each directory.
        private void Compare_GetFiles(string dir1, string dir2)
        {
            // Get sorted lists of files in the directories.
            string[] file_names1 = Directory.GetFiles(dir1);
            for (int i = 0; i < file_names1.Length; i++)
            {
                file_names1[i] = file_names1[i].Replace(dir1, "");
            }
            Array.Sort(file_names1);

            string[] file_names2 = Directory.GetFiles(dir2);
            for (int i = 0; i < file_names2.Length; i++)
            {
                file_names2[i] = file_names2[i].Replace(dir2, "");
            }
            Array.Sort(file_names2);

            // Compare.
            int i1 = 0, i2 = 0;
            List<string> dir1_only = new List<string>();
            List<string> dir2_only = new List<string>();
            List<string> both = new List<string>();
            while ((i1 < file_names1.Length) && (i2 < file_names2.Length))
            {
                if (file_names1[i1] == file_names2[i2])
                {
                    // They match. Display them both.
                    both.Add(file_names1[i1]);
                    i1++;
                    i2++;
                }
                else if (file_names1[i1].CompareTo(file_names2[i2]) < 0)
                {
                    // Display the directory 1 file.
                    dir1_only.Add(file_names1[i1]);
                    i1++;
                }
                else
                {
                    // Display the directory 2 file.
                    dir2_only.Add(file_names1[i2]);
                    i2++;
                }
            }

            // Display remaining directory 1 files.
            for (int i = i1; i < file_names1.Length; i++)
            {
                dir1_only.Add(file_names1[i]);
            }

            // Display remaining directory 2 files.
            for (int i = i2; i < file_names2.Length; i++)
            {
                dir2_only.Add(file_names1[i]);
            }
        }

        // Use LINQ twice to compare the files in each directory.
        private void Compare_LinqTwice(string dir1, string dir2)
        {
            // Get sorted lists of files in the directories.
            DirectoryInfo dir1_info = new DirectoryInfo(dir1);
            var dir1_query =
                from FileInfo file_info in dir1_info.GetFiles()
                orderby file_info.Name
                select file_info.Name;
            string[] file_names1 = dir1_query.ToArray();

            DirectoryInfo dir2_info = new DirectoryInfo(dir2);
            var dir2_query =
                from FileInfo file_info in dir2_info.GetFiles()
                orderby file_info.Name
                select file_info.Name;
            string[] file_names2 = dir2_query.ToArray();

            // Compare.
            int i1 = 0, i2 = 0;
            List<string> dir1_only = new List<string>();
            List<string> dir2_only = new List<string>();
            List<string> both = new List<string>();
            while ((i1 < file_names1.Length) && (i2 < file_names2.Length))
            {
                if (file_names1[i1] == file_names2[i2])
                {
                    // They match. Display them both.
                    both.Add(file_names1[i1]);
                    i1++;
                    i2++;
                }
                else if (file_names1[i1].CompareTo(file_names2[i2]) < 0)
                {
                    // Display the directory 1 file.
                    dir1_only.Add(file_names1[i1]);
                    i1++;
                }
                else
                {
                    // Display the directory 2 file.
                    dir2_only.Add(file_names1[i2]);
                    i2++;
                }
            }

            // Display remaining directory 1 files.
            for (int i = i1; i < file_names1.Length; i++)
            {
                dir1_only.Add(file_names1[i]);
            }

            // Display remaining directory 2 files.
            for (int i = i2; i < file_names2.Length; i++)
            {
                dir2_only.Add(file_names1[i]);
            }
        }

        // Use LINQ joins to compare the files in each directory.
        private void Compare_LinqJoins(string dir1, string dir2)
        {
            // Get sorted lists of files in the directories.
            DirectoryInfo dir1_info = new DirectoryInfo(dir1);
            var dir1_query =
                from FileInfo file_info in dir1_info.GetFiles()
                //orderby file_info.Name
                select file_info.Name;
            string[] file_names1 = dir1_query.ToArray();

            DirectoryInfo dir2_info = new DirectoryInfo(dir2);
            var dir2_query =
                from FileInfo file_info in dir2_info.GetFiles()
                //orderby file_info.Name
                select file_info.Name;
            string[] file_names2 = dir2_query.ToArray();

            // Compare.
            var dir1_only_query =
                from string file_name in file_names1
                where (!file_names2.Contains(file_name))
                select file_name;
            List<string> dir1_only = dir1_only_query.ToList();

            var dir2_only_query =
                from string file_name in file_names2
                where (!file_names1.Contains(file_name))
                select file_name;
            List<string> dir2_only = dir2_only_query.ToList();

            var both_query =
                from string file_name in file_names1
                where (file_names2.Contains(file_name))
                select file_name;
            List<string> both = both_query.ToList();
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
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnCompare = new System.Windows.Forms.Button();
            this.txtDir2 = new System.Windows.Forms.TextBox();
            this.txtDir1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGetFilesTime = new System.Windows.Forms.TextBox();
            this.txtLinqTwiceTime = new System.Windows.Forms.TextBox();
            this.txtLinqJoinsTime = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(10, 39);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(61, 13);
            this.Label2.TabIndex = 18;
            this.Label2.Text = "Directory 2:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(10, 15);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(61, 13);
            this.Label1.TabIndex = 17;
            this.Label1.Text = "Directory 1:";
            // 
            // btnCompare
            // 
            this.btnCompare.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCompare.Location = new System.Drawing.Point(152, 62);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(64, 40);
            this.btnCompare.TabIndex = 16;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // txtDir2
            // 
            this.txtDir2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDir2.Location = new System.Drawing.Point(77, 12);
            this.txtDir2.Name = "txtDir2";
            this.txtDir2.Size = new System.Drawing.Size(279, 20);
            this.txtDir2.TabIndex = 14;
            this.txtDir2.Text = "C:\\Windows\\System32";
            // 
            // txtDir1
            // 
            this.txtDir1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDir1.Location = new System.Drawing.Point(77, 36);
            this.txtDir1.Name = "txtDir1";
            this.txtDir1.Size = new System.Drawing.Size(279, 20);
            this.txtDir1.TabIndex = 15;
            this.txtDir1.Text = "C:\\Windows\\System32";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Directory.GetFiles:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "LINQ Twice:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "LINQ Joins:";
            // 
            // txtGetFilesTime
            // 
            this.txtGetFilesTime.Location = new System.Drawing.Point(111, 121);
            this.txtGetFilesTime.Name = "txtGetFilesTime";
            this.txtGetFilesTime.Size = new System.Drawing.Size(100, 20);
            this.txtGetFilesTime.TabIndex = 22;
            // 
            // txtLinqTwiceTime
            // 
            this.txtLinqTwiceTime.Location = new System.Drawing.Point(111, 147);
            this.txtLinqTwiceTime.Name = "txtLinqTwiceTime";
            this.txtLinqTwiceTime.Size = new System.Drawing.Size(100, 20);
            this.txtLinqTwiceTime.TabIndex = 23;
            // 
            // txtLinqJoinsTime
            // 
            this.txtLinqJoinsTime.Location = new System.Drawing.Point(111, 173);
            this.txtLinqJoinsTime.Name = "txtLinqJoinsTime";
            this.txtLinqJoinsTime.Size = new System.Drawing.Size(100, 20);
            this.txtLinqJoinsTime.TabIndex = 24;
            // 
            // howto_compare_directories_timed_Form1
            // 
            this.AcceptButton = this.btnCompare;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 205);
            this.Controls.Add(this.txtLinqJoinsTime);
            this.Controls.Add(this.txtLinqTwiceTime);
            this.Controls.Add(this.txtGetFilesTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.txtDir2);
            this.Controls.Add(this.txtDir1);
            this.Name = "howto_compare_directories_timed_Form1";
            this.Text = "howto_compare_directories_timed";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnCompare;
        internal System.Windows.Forms.TextBox txtDir2;
        internal System.Windows.Forms.TextBox txtDir1;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGetFilesTime;
        private System.Windows.Forms.TextBox txtLinqTwiceTime;
        private System.Windows.Forms.TextBox txtLinqJoinsTime;
    }
}

