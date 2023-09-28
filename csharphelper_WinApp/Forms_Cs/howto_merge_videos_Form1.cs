using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Add a references to:
//      Microsoft.Expression.Encoder
//      Microsoft.Expression.Encoder.Api2
//      Microsoft.Expression.Encoder.Types
//      Microsoft.Expression.Encoder.Utilities

using Microsoft.Expression.Encoder;
using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_merge_videos_Form1:Form
  { 


        public howto_merge_videos_Form1()
        {
            InitializeComponent();
        }

        // Let the user select a video to add to the file list.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ofdVideo.ShowDialog() == DialogResult.OK)
            {
                lstFiles.Items.Add(ofdVideo.FileName);
                btnMerge.Enabled = (lstFiles.Items.Count >= 2);
            }
        }

        // Enable the Delete button if a file is selected.
        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemove.Enabled = (lstFiles.SelectedIndex >= 0);
        }

        // Remove the selected file from the list.
        private void btnRemove_Click(object sender, EventArgs e)
        {
            lstFiles.Items.RemoveAt(lstFiles.SelectedIndex);
            btnMerge.Enabled = (lstFiles.Items.Count >= 2);
        }

        // Build the merged video.
        private void btnMerge_Click(object sender, EventArgs e)
        {
            if (sfdMerged.ShowDialog() != DialogResult.OK) return;
            Cursor = Cursors.WaitCursor;
            prgEncode.Value = 0;
            prgEncode.Visible = true;
            Refresh();

            try
            {
                // Create a job.
                using (Job job = new Job())
                {
                    // Make one MediaItem containing all of the sources.
                    MediaItem media_item = new MediaItem(lstFiles.Items[0].ToString());
                    job.MediaItems.Add(media_item);

                    for (int i = 1; i < lstFiles.Items.Count; i++)
                    {
                        media_item.Sources.Add(
                            new Source(lstFiles.Items[i].ToString()));
                    }

                    // Set the output directory.
                    FileInfo file_info = new FileInfo(sfdMerged.FileName);
                    job.OutputDirectory = file_info.DirectoryName;

                    // Set the output file name.
                    media_item.OutputFileName = file_info.Name;

                    // Don't create a subdirectory.
                    job.CreateSubfolder = false;

                    // Use the original size.
                    media_item.OutputFormat.VideoProfile.Size = media_item.OriginalVideoSize;

                    // Install the progress event handler.
                    job.EncodeProgress += job_EncodeProgress;

                    // Encode.
                    job.Encode();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Cursor = Cursors.Default;
            prgEncode.Visible = false;
        }

        // Display progress.
        private void job_EncodeProgress(object sender, EncodeProgressEventArgs e)
        {
            prgEncode.Value = (int)e.Progress;
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
            this.btnMerge = new System.Windows.Forms.Button();
            this.ofdVideo = new System.Windows.Forms.OpenFileDialog();
            this.sfdMerged = new System.Windows.Forms.SaveFileDialog();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.prgEncode = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnMerge
            // 
            this.btnMerge.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnMerge.Enabled = false;
            this.btnMerge.Location = new System.Drawing.Point(105, 117);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(75, 23);
            this.btnMerge.TabIndex = 9;
            this.btnMerge.Text = "Merge...";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // ofdVideo
            // 
            this.ofdVideo.Filter = "Video Files|*.wmv;*.avi|All Files|*.*";
            // 
            // sfdMerged
            // 
            this.sfdMerged.Filter = "Video Files|*.wmv;*.avi|All Files|*.*";
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Image = Properties.Resources.bmRemove;
            this.btnRemove.Location = new System.Drawing.Point(36, 12);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(18, 18);
            this.btnRemove.TabIndex = 8;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lstFiles
            // 
            this.lstFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.HorizontalScrollbar = true;
            this.lstFiles.IntegralHeight = false;
            this.lstFiles.Location = new System.Drawing.Point(12, 36);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(260, 75);
            this.lstFiles.TabIndex = 7;
            this.lstFiles.SelectedIndexChanged += new System.EventHandler(this.lstFiles_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = Properties.Resources.bmAdd;
            this.btnAdd.Location = new System.Drawing.Point(12, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(18, 18);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // prgEncode
            // 
            this.prgEncode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.prgEncode.Location = new System.Drawing.Point(12, 142);
            this.prgEncode.Name = "prgEncode";
            this.prgEncode.Size = new System.Drawing.Size(260, 12);
            this.prgEncode.TabIndex = 10;
            this.prgEncode.Visible = false;
            // 
            // howto_merge_videos_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.prgEncode);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.btnAdd);
            this.Name = "howto_merge_videos_Form1";
            this.Text = "howto_merge_videos";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.OpenFileDialog ofdVideo;
        private System.Windows.Forms.SaveFileDialog sfdMerged;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ProgressBar prgEncode;
    }
}

