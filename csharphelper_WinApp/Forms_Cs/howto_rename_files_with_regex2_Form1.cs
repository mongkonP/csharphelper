using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Text.RegularExpressions;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_rename_files_with_regex2_Form1:Form
  { 


        public howto_rename_files_with_regex2_Form1()
        {
            InitializeComponent();
        }

        // Start in the test directory.
        private void howto_rename_files_with_regex2_Form1_Load(object sender, EventArgs e)
        {
            DirectoryInfo dir_info = new DirectoryInfo(
                Path.Combine(Application.StartupPath, @"..\..\Test"));
            txtDirectory.Text = dir_info.FullName;

            DateTime last_month = DateTime.Now.AddMonths(-1);
            txtFromDate.Text = last_month.ToShortDateString();
            txtToDate.Text = DateTime.Now.ToShortDateString();
        }

        // Make a list of file names to change from and to.
        private List<string> FullFromNames, FromNames, ToNames;
        private List<DateTime> Dates;
        private void MakeFileLists()
        {
            try
            {
                // Make the file name lists.
                FullFromNames = new List<string>();
                FromNames = new List<string>();
                ToNames = new List<string>();
                Dates = new List<DateTime>();

                // Get the files that match the pattern and date range.
                DirectoryInfo dir_info = new DirectoryInfo(txtDirectory.Text);
                FileInfo[] files = dir_info.GetFiles(txtFilePattern.Text);
                Regex regex = new Regex(txtOldPattern.Text);

                DateTime from_date = DateTime.Parse(txtFromDate.Text).Date;
                DateTime to_date = DateTime.Parse(txtToDate.Text).Date;

                for (int i = 0; i < files.Length; i++)
                {
                    string new_name = regex.Replace(files[i].Name,
                        txtNewPattern.Text);
                    new_name = new_name.Replace("$i", i.ToString());

                    if (files[i].Name != new_name)
                    {
                        // Get the file's last modificaiton date.
                        FileInfo file_info = new FileInfo(files[i].FullName);
                        if ((file_info.LastWriteTime.Date >= from_date) &&
                            (file_info.LastWriteTime.Date <= to_date))
                        {
                            FullFromNames.Add(files[i].FullName);
                            FromNames.Add(files[i].Name);
                            ToNames.Add(new_name);
                            Dates.Add(file_info.LastWriteTime);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error building file list.\n" + ex.Message);
                FullFromNames = new List<string>();
                FromNames = new List<string>();
                ToNames = new List<string>();
            }
        }

        // Display a list of changes that we will make.
        private void btnPreviewChanges_Click(object sender, EventArgs e)
        {
            // Make the file lists.
            MakeFileLists();

            // Display the lists.
            lvwResults.Items.Clear();
            for (int i = 0; i < FromNames.Count; i++)
            {
                ListViewItem new_item =
                    lvwResults.Items.Add(FromNames[i]);
                new_item.SubItems.Add(ToNames[i]);
                new_item.SubItems.Add(Dates[i].ToShortDateString());
            }
            for (int i = 0; i < lvwResults.Columns.Count; i++)
                lvwResults.Columns[i].Width = -2;

            // Enable the Make Changes button.
            btnMakeChanges.Enabled = true;
        }

        // Make the changes.
        private void btnMakeChanges_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < FromNames.Count; i++)
                {
                    try
                    {
                        FileInfo file_info = new FileInfo(FullFromNames[i]);
                        string new_name = file_info.DirectoryName + "\\" + ToNames[i];

                        file_info.MoveTo(new_name);
                        //Console.WriteLine(i.ToString() + ": " + file_info.FullName + " --> " + new_name);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error moving file '" +
                            FromNames[i] + "' to '" +
                            ToNames[i] + "'.\n" + ex.Message);
                        throw;
                    }
                }
                lvwResults.Items.Clear();
                btnMakeChanges.Enabled = false;
                FullFromNames = new List<string>();
                FromNames = new List<string>();
                ToNames = new List<string>();

                MessageBox.Show("Done");
            }
            catch
            {
            }
        }

        // Remove the selected files from the ListView.
        private void btnRemoveFile_Click(object sender, EventArgs e)
        {
            for (int i = lvwResults.Items.Count - 1; i >= 0; i--)
            {
                if (lvwResults.Items[i].Selected)
                {
                    lvwResults.Items.RemoveAt(i);
                    FromNames.RemoveAt(i);
                    ToNames.RemoveAt(i);
                }
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.txtOldPattern = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewPattern = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPreviewChanges = new System.Windows.Forms.Button();
            this.btnMakeChanges = new System.Windows.Forms.Button();
            this.txtFilePattern = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lvwResults = new System.Windows.Forms.ListView();
            this.colFromName = new System.Windows.Forms.ColumnHeader();
            this.colToName = new System.Windows.Forms.ColumnHeader();
            this.btnRemoveFile = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.txtFromDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtToDate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Directory:";
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Location = new System.Drawing.Point(87, 12);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(486, 20);
            this.txtDirectory.TabIndex = 0;
            // 
            // txtOldPattern
            // 
            this.txtOldPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOldPattern.Location = new System.Drawing.Point(87, 64);
            this.txtOldPattern.Name = "txtOldPattern";
            this.txtOldPattern.Size = new System.Drawing.Size(486, 20);
            this.txtOldPattern.TabIndex = 2;
            this.txtOldPattern.Text = "^(.*)file(.*)$";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Old Pattern:";
            // 
            // txtNewPattern
            // 
            this.txtNewPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewPattern.Location = new System.Drawing.Point(87, 90);
            this.txtNewPattern.Name = "txtNewPattern";
            this.txtNewPattern.Size = new System.Drawing.Size(486, 20);
            this.txtNewPattern.TabIndex = 3;
            this.txtNewPattern.Text = "$1part($i)_$2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "New Pattern:";
            // 
            // btnPreviewChanges
            // 
            this.btnPreviewChanges.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPreviewChanges.Location = new System.Drawing.Point(161, 142);
            this.btnPreviewChanges.Name = "btnPreviewChanges";
            this.btnPreviewChanges.Size = new System.Drawing.Size(115, 23);
            this.btnPreviewChanges.TabIndex = 4;
            this.btnPreviewChanges.Text = "Preview Changes";
            this.btnPreviewChanges.UseVisualStyleBackColor = true;
            this.btnPreviewChanges.Click += new System.EventHandler(this.btnPreviewChanges_Click);
            // 
            // btnMakeChanges
            // 
            this.btnMakeChanges.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMakeChanges.Enabled = false;
            this.btnMakeChanges.Location = new System.Drawing.Point(309, 142);
            this.btnMakeChanges.Name = "btnMakeChanges";
            this.btnMakeChanges.Size = new System.Drawing.Size(115, 23);
            this.btnMakeChanges.TabIndex = 5;
            this.btnMakeChanges.Text = "Make Changes";
            this.btnMakeChanges.UseVisualStyleBackColor = true;
            this.btnMakeChanges.Click += new System.EventHandler(this.btnMakeChanges_Click);
            // 
            // txtFilePattern
            // 
            this.txtFilePattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePattern.Location = new System.Drawing.Point(87, 38);
            this.txtFilePattern.Name = "txtFilePattern";
            this.txtFilePattern.Size = new System.Drawing.Size(486, 20);
            this.txtFilePattern.TabIndex = 1;
            this.txtFilePattern.Text = "*.txt";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "File Pattern:";
            // 
            // lvwResults
            // 
            this.lvwResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFromName,
            this.colToName,
            this.colDate});
            this.lvwResults.FullRowSelect = true;
            this.lvwResults.Location = new System.Drawing.Point(12, 171);
            this.lvwResults.Name = "lvwResults";
            this.lvwResults.Size = new System.Drawing.Size(561, 135);
            this.lvwResults.TabIndex = 11;
            this.lvwResults.UseCompatibleStateImageBehavior = false;
            this.lvwResults.View = System.Windows.Forms.View.Details;
            // 
            // colFromName
            // 
            this.colFromName.Text = "Change From:";
            this.colFromName.Width = 234;
            // 
            // colToName
            // 
            this.colToName.Text = "Change To:";
            this.colToName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colToName.Width = 234;
            // 
            // btnRemoveFile
            // 
            this.btnRemoveFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveFile.Location = new System.Drawing.Point(553, 142);
            this.btnRemoveFile.Name = "btnRemoveFile";
            this.btnRemoveFile.Size = new System.Drawing.Size(20, 23);
            this.btnRemoveFile.TabIndex = 12;
            this.btnRemoveFile.Text = "x";
            this.toolTip1.SetToolTip(this.btnRemoveFile, "Remove file from list.");
            this.btnRemoveFile.UseVisualStyleBackColor = true;
            this.btnRemoveFile.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // colDate
            // 
            this.colDate.Text = "Date:";
            this.colDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFromDate
            // 
            this.txtFromDate.Location = new System.Drawing.Point(87, 116);
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Size = new System.Drawing.Size(70, 20);
            this.txtFromDate.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Dates:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(160, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "to";
            // 
            // txtToDate
            // 
            this.txtToDate.Location = new System.Drawing.Point(176, 116);
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.Size = new System.Drawing.Size(70, 20);
            this.txtToDate.TabIndex = 16;
            // 
            // howto_rename_files_with_regex2_Form1
            // 
            this.AcceptButton = this.btnPreviewChanges;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 318);
            this.Controls.Add(this.txtToDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFromDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRemoveFile);
            this.Controls.Add(this.lvwResults);
            this.Controls.Add(this.txtFilePattern);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnMakeChanges);
            this.Controls.Add(this.btnPreviewChanges);
            this.Controls.Add(this.txtNewPattern);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOldPattern);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.label1);
            this.Name = "howto_rename_files_with_regex2_Form1";
            this.Text = "howto_rename_files_with_regex2";
            this.Load += new System.EventHandler(this.howto_rename_files_with_regex2_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.TextBox txtOldPattern;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewPattern;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPreviewChanges;
        private System.Windows.Forms.Button btnMakeChanges;
        private System.Windows.Forms.TextBox txtFilePattern;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lvwResults;
        private System.Windows.Forms.ColumnHeader colFromName;
        private System.Windows.Forms.ColumnHeader colToName;
        private System.Windows.Forms.Button btnRemoveFile;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.TextBox txtFromDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtToDate;
    }
}

