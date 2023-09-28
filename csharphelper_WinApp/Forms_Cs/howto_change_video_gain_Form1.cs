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
     public partial class howto_change_video_gain_Form1:Form
  { 


        public howto_change_video_gain_Form1()
        {
            InitializeComponent();
        }

        private void txtMovie_TextChanged(object sender, EventArgs e)
        {
            btnCreate.Enabled = File.Exists(txtMovie.Text);
        }

        private void btnMovie_Click(object sender, EventArgs e)
        {
            ofdMovie.FileName = txtMovie.Text;
            if (ofdMovie.ShowDialog() == DialogResult.OK)
                txtMovie.Text = ofdMovie.FileName;
        }

        private void btnCreate_Click(object sender, EventArgs e)
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
                    // Make a MediaItem containing the splash video.
                    MediaItem media_item = new MediaItem(txtMovie.Text);
                    job.MediaItems.Add(media_item);

                    // Use the original size.
                    media_item.OutputFormat.VideoProfile.Size =
                        media_item.OriginalVideoSize;

                    // Set the quality.
                    double gain;
                    if (trkGain.Value <= 0)
                        gain = (10.0 + trkGain.Value) / 10.0;
                    else
                        gain = trkGain.Value;
                    Console.WriteLine("Gain: " + gain);
                    media_item.AudioGainLevel = gain;

                    // Set the output directory.
                    FileInfo file_info = new FileInfo(sfdMerged.FileName);
                    job.OutputDirectory = file_info.DirectoryName;

                    // Set the output file name.
                    media_item.OutputFileName = file_info.Name;

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

            Cursor = Cursors.Default;
            prgEncode.Visible = false;
        }

        // Display progress.
        private void job_EncodeProgress(object sender, EncodeProgressEventArgs e)
        {
            prgEncode.Value = (int)e.Progress;
            Refresh();
        }

        private void trkGain_Scroll(object sender, EventArgs e)
        {
            txtQuality.Text = trkGain.Value.ToString();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_change_video_gain_Form1));
            this.txtQuality = new System.Windows.Forms.TextBox();
            this.prgEncode = new System.Windows.Forms.ProgressBar();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMovie = new System.Windows.Forms.Button();
            this.txtMovie = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trkGain = new System.Windows.Forms.TrackBar();
            this.ofdMovie = new System.Windows.Forms.OpenFileDialog();
            this.sfdMerged = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.trkGain)).BeginInit();
            this.SuspendLayout();
            // 
            // txtQuality
            // 
            this.txtQuality.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuality.Location = new System.Drawing.Point(341, 40);
            this.txtQuality.Name = "txtQuality";
            this.txtQuality.ReadOnly = true;
            this.txtQuality.Size = new System.Drawing.Size(31, 20);
            this.txtQuality.TabIndex = 29;
            this.txtQuality.Text = "0";
            this.txtQuality.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // prgEncode
            // 
            this.prgEncode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.prgEncode.Location = new System.Drawing.Point(12, 102);
            this.prgEncode.Name = "prgEncode";
            this.prgEncode.Size = new System.Drawing.Size(360, 12);
            this.prgEncode.TabIndex = 27;
            this.prgEncode.Visible = false;
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCreate.Enabled = false;
            this.btnCreate.Location = new System.Drawing.Point(162, 77);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 26;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Gain:";
            // 
            // btnMovie
            // 
            this.btnMovie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMovie.Image = ((System.Drawing.Image)(resources.GetObject("btnMovie.Image")));
            this.btnMovie.Location = new System.Drawing.Point(354, 9);
            this.btnMovie.Name = "btnMovie";
            this.btnMovie.Size = new System.Drawing.Size(18, 18);
            this.btnMovie.TabIndex = 24;
            this.btnMovie.UseVisualStyleBackColor = true;
            this.btnMovie.Click += new System.EventHandler(this.btnMovie_Click);
            // 
            // txtMovie
            // 
            this.txtMovie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMovie.Location = new System.Drawing.Point(60, 8);
            this.txtMovie.Name = "txtMovie";
            this.txtMovie.Size = new System.Drawing.Size(275, 20);
            this.txtMovie.TabIndex = 23;
            this.txtMovie.TextChanged += new System.EventHandler(this.txtMovie_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Movie:";
            // 
            // trkGain
            // 
            this.trkGain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trkGain.Location = new System.Drawing.Point(60, 40);
            this.trkGain.Minimum = -10;
            this.trkGain.Name = "trkGain";
            this.trkGain.Size = new System.Drawing.Size(275, 45);
            this.trkGain.TabIndex = 28;
            this.trkGain.Scroll += new System.EventHandler(this.trkGain_Scroll);
            // 
            // ofdMovie
            // 
            this.ofdMovie.Filter = "Movie Files|*.wmv;*.avi|All Files|*.*";
            // 
            // sfdMerged
            // 
            this.sfdMerged.Filter = "Video Files|*.wmv;*.avi|All Files|*.*";
            // 
            // howto_change_video_gain_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 122);
            this.Controls.Add(this.txtQuality);
            this.Controls.Add(this.prgEncode);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnMovie);
            this.Controls.Add(this.txtMovie);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trkGain);
            this.Name = "howto_change_video_gain_Form1";
            this.Text = "howto_change_video_gain";
            ((System.ComponentModel.ISupportInitialize)(this.trkGain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtQuality;
        private System.Windows.Forms.ProgressBar prgEncode;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMovie;
        private System.Windows.Forms.TextBox txtMovie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trkGain;
        private System.Windows.Forms.OpenFileDialog ofdMovie;
        private System.Windows.Forms.SaveFileDialog sfdMerged;
    }
}

