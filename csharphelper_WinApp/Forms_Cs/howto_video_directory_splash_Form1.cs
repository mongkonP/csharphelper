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
using Microsoft.Expression.Encoder.Profiles;
using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_video_directory_splash_Form1:Form
  { 


        public howto_video_directory_splash_Form1()
        {
            InitializeComponent();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            lstSplash.Items.Clear();
            try
            {
                foreach (string filename in Directory.GetFiles(
                    txtDirectory.Text, "* splash.wmv"))
                {
                    lstSplash.Items.Add(filename);
                }
                btnGo.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Refresh();

            for (int i = 0; i < lstSplash.Items.Count; i++)
            {
                lstSplash.SelectedIndex = i;
                lstSplash.Refresh();
                MergeSplash(lstSplash.Items[i].ToString());
            }

            Cursor = Cursors.Default;
        }

        private void MergeSplash(string splash_file)
        {
            prgEncode.Value = 0;
            prgEncode.Visible = true;
            Refresh();

            try
            {
                // Create a job.
                using (Job job = new Job())
                {
                    // Make a MediaItem containing the splash video.
                    MediaItem media_item = new MediaItem(splash_file);
                    job.MediaItems.Add(media_item);

                    // Use the original size.
                    media_item.OutputFormat.VideoProfile.Size =
                        media_item.OriginalVideoSize;

                    // Restrict the splash video to 5 seconds.
                    media_item.Sources[0].Clips[0].EndTime =
                        new TimeSpan(0, 0, 5);

                    // Add the movie.
                    string base_name = splash_file.Replace(" splash", " base");
                    media_item.Sources.Add(new Source(base_name));

                    // Set the quality.
                    media_item.OutputFormat.VideoProfile.Bitrate =
                        new VariableQualityBitrate(90);

                    // Set the output directory.
                    FileInfo file_info = new FileInfo(splash_file);
                    job.OutputDirectory = file_info.DirectoryName;

                    // Set the output file name.
                    media_item.OutputFileName = file_info.Name.Replace(" splash", "");

                    // Don't create a subdirectory.
                    job.CreateSubfolder = false;

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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.btnList = new System.Windows.Forms.Button();
            this.lstSplash = new System.Windows.Forms.ListBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.prgEncode = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Directory:";
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Location = new System.Drawing.Point(70, 12);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(264, 20);
            this.txtDirectory.TabIndex = 1;
            // 
            // btnList
            // 
            this.btnList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnList.Location = new System.Drawing.Point(136, 38);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(75, 23);
            this.btnList.TabIndex = 2;
            this.btnList.Text = "List";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // lstSplash
            // 
            this.lstSplash.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSplash.FormattingEnabled = true;
            this.lstSplash.HorizontalScrollbar = true;
            this.lstSplash.IntegralHeight = false;
            this.lstSplash.Location = new System.Drawing.Point(12, 67);
            this.lstSplash.Name = "lstSplash";
            this.lstSplash.Size = new System.Drawing.Size(322, 146);
            this.lstSplash.TabIndex = 3;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGo.Enabled = false;
            this.btnGo.Location = new System.Drawing.Point(136, 219);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // prgEncode
            // 
            this.prgEncode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.prgEncode.Location = new System.Drawing.Point(12, 245);
            this.prgEncode.Name = "prgEncode";
            this.prgEncode.Size = new System.Drawing.Size(322, 12);
            this.prgEncode.TabIndex = 12;
            this.prgEncode.Visible = false;
            // 
            // howto_video_directory_splash_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 261);
            this.Controls.Add(this.prgEncode);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.lstSplash);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.label1);
            this.Name = "howto_video_directory_splash_Form1";
            this.Text = "howto_video_directory_splash";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.ListBox lstSplash;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ProgressBar prgEncode;
    }
}

