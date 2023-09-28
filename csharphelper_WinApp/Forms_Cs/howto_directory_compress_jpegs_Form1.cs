using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

 

using howto_directory_compress_jpegs;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_directory_compress_jpegs_Form1:Form
  { 


        public howto_directory_compress_jpegs_Form1()
        {
            InitializeComponent();
        }

        // Restore saved settings.
        private void howto_directory_compress_jpegs_Form1_Load(object sender, EventArgs e)
        {
            txtFolder.Text = Properties.Settings.Default.StartPath;
            cboCompressionLevel.Text = Properties.Settings.Default.Level;
            txtMaxFileSize.Text = Properties.Settings.Default.MaxSizeKb;
        }

        // Save the settings.
        private void howto_directory_compress_jpegs_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.StartPath = txtFolder.Text;
            Properties.Settings.Default.Level = cboCompressionLevel.Text;
            Properties.Settings.Default.MaxSizeKb = txtMaxFileSize.Text;
            Properties.Settings.Default.Save();
        }

        // Let the user select a folder.
        private void btnPickFolder_Click(object sender, EventArgs e)
        {
            fbdFolder.SelectedPath = txtFolder.Text;
            if (fbdFolder.ShowDialog() == DialogResult.OK)
            {
                txtFolder.Text = fbdFolder.SelectedPath;
            }
        }

        // Compress the files.
        private void btnGo_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            txtFilesProcessed.Clear();
            txtOriginalTotalSize.Clear();
            txtFinalTotalSize.Clear();

            // Get the compression parameters.
            bool set_level = radSetCompressionLevel.Checked;
            int level = 100;
            long max_size = 1024;
            if (set_level)
            {
                level = int.Parse(cboCompressionLevel.Text);
            }
            else
            {
                max_size = 1024 * long.Parse(txtMaxFileSize.Text);
            }

            // Track file sizes.
            long original_size = 0, final_size = 0;
            int num_files = 0;

            // Loop through the directory's JPEGs.
            string dir_name = txtFolder.Text;
            foreach (string file_name in Directory.GetFiles(dir_name, "*.jp*g"))
            {
                // Process this file.
                try
                {
                    // Update the original size.
                    long file_size = new FileInfo(file_name).Length;
                    original_size += file_size;
                    txtOriginalTotalSize.Text = original_size.ToFileSizeApi();

                    if (set_level)
                    {
                        // Save the file at the desired level.
                        using (Bitmap bm = ImageStuff.LoadBitmap(file_name))
                        {
                            ImageStuff.SaveJpg(bm, file_name, level);
                        }
                    }
                    else
                    {
                        // Save the file with no more than the desired size.
                        if (file_size > max_size)
                        {
                            using (Bitmap bm = ImageStuff.LoadBitmap(file_name))
                            {
                                ImageStuff.SaveJpgAtFileSize(bm, file_name, max_size);
                            }
                        }
                    }

                    // Update the final size.
                    final_size += new FileInfo(file_name).Length;
                    txtFinalTotalSize.Text = final_size.ToFileSizeApi();
                    num_files++;
                    txtFilesProcessed.Text = num_files.ToString();

                    txtFilesProcessed.Refresh();
                    txtOriginalTotalSize.Refresh();
                    txtFinalTotalSize.Refresh();

                    if (num_files % 10 == 0) Application.DoEvents();
                }
                catch (Exception ex)
                {
                    // Display the error message and give the user a chance to stop.
                    if (MessageBox.Show("Error compressing file " +
                        file_name + "\n" + ex.Message + "\nDo you want to continue?",
                        "Error", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Error) == DialogResult.No)
                    {
                        break;
                    }
                }
            }
            Cursor = Cursors.Default;
        }

        // Enable the Go button.
        private void txtFolder_TextChanged(object sender, EventArgs e)
        {
            btnGo.Enabled = true;
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
            this.txtFilesProcessed = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFinalTotalSize = new System.Windows.Forms.TextBox();
            this.txtOriginalTotalSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtMaxFileSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPickFolder = new System.Windows.Forms.Button();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.fbdFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCompressionLevel = new System.Windows.Forms.ComboBox();
            this.radSetMaxFileSize = new System.Windows.Forms.RadioButton();
            this.radSetCompressionLevel = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // txtFilesProcessed
            // 
            this.txtFilesProcessed.Location = new System.Drawing.Point(113, 169);
            this.txtFilesProcessed.Name = "txtFilesProcessed";
            this.txtFilesProcessed.ReadOnly = true;
            this.txtFilesProcessed.Size = new System.Drawing.Size(100, 20);
            this.txtFilesProcessed.TabIndex = 51;
            this.txtFilesProcessed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Files Processed:";
            // 
            // txtFinalTotalSize
            // 
            this.txtFinalTotalSize.Location = new System.Drawing.Point(113, 221);
            this.txtFinalTotalSize.Name = "txtFinalTotalSize";
            this.txtFinalTotalSize.ReadOnly = true;
            this.txtFinalTotalSize.Size = new System.Drawing.Size(100, 20);
            this.txtFinalTotalSize.TabIndex = 53;
            this.txtFinalTotalSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtOriginalTotalSize
            // 
            this.txtOriginalTotalSize.Location = new System.Drawing.Point(113, 195);
            this.txtOriginalTotalSize.Name = "txtOriginalTotalSize";
            this.txtOriginalTotalSize.ReadOnly = true;
            this.txtOriginalTotalSize.Size = new System.Drawing.Size(100, 20);
            this.txtOriginalTotalSize.TabIndex = 52;
            this.txtOriginalTotalSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "Final Total Size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 57;
            this.label3.Text = "Original Total Size:";
            // 
            // btnGo
            // 
            this.btnGo.Enabled = false;
            this.btnGo.Location = new System.Drawing.Point(148, 123);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 50;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtMaxFileSize
            // 
            this.txtMaxFileSize.Location = new System.Drawing.Point(158, 84);
            this.txtMaxFileSize.Name = "txtMaxFileSize";
            this.txtMaxFileSize.Size = new System.Drawing.Size(55, 20);
            this.txtMaxFileSize.TabIndex = 49;
            this.txtMaxFileSize.Text = "1000";
            this.txtMaxFileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Directory:";
            // 
            // btnPickFolder
            // 
            this.btnPickFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickFolder.Image = Properties.Resources.Ellipsis;
            this.btnPickFolder.Location = new System.Drawing.Point(322, 10);
            this.btnPickFolder.Name = "btnPickFolder";
            this.btnPickFolder.Size = new System.Drawing.Size(25, 23);
            this.btnPickFolder.TabIndex = 46;
            this.btnPickFolder.UseVisualStyleBackColor = true;
            this.btnPickFolder.Click += new System.EventHandler(this.btnPickFolder_Click);
            // 
            // txtFolder
            // 
            this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolder.Location = new System.Drawing.Point(71, 12);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(245, 20);
            this.txtFolder.TabIndex = 45;
            this.txtFolder.TextChanged += new System.EventHandler(this.txtFolder_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 56;
            this.label2.Text = "kb";
            // 
            // cboCompressionLevel
            // 
            this.cboCompressionLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompressionLevel.FormattingEnabled = true;
            this.cboCompressionLevel.Items.AddRange(new object[] {
            "100",
            "95",
            "90",
            "85",
            "80",
            "75",
            "70",
            "65",
            "60",
            "55",
            "50",
            "45",
            "40",
            "35",
            "30",
            "25",
            "20",
            "15",
            "10",
            "5"});
            this.cboCompressionLevel.Location = new System.Drawing.Point(158, 57);
            this.cboCompressionLevel.Name = "cboCompressionLevel";
            this.cboCompressionLevel.Size = new System.Drawing.Size(55, 21);
            this.cboCompressionLevel.TabIndex = 47;
            // 
            // radSetMaxFileSize
            // 
            this.radSetMaxFileSize.AutoSize = true;
            this.radSetMaxFileSize.Checked = true;
            this.radSetMaxFileSize.Location = new System.Drawing.Point(16, 85);
            this.radSetMaxFileSize.Name = "radSetMaxFileSize";
            this.radSetMaxFileSize.Size = new System.Drawing.Size(109, 17);
            this.radSetMaxFileSize.TabIndex = 55;
            this.radSetMaxFileSize.TabStop = true;
            this.radSetMaxFileSize.Text = "Set Max File Size:";
            this.radSetMaxFileSize.UseVisualStyleBackColor = true;
            // 
            // radSetCompressionLevel
            // 
            this.radSetCompressionLevel.AutoSize = true;
            this.radSetCompressionLevel.Location = new System.Drawing.Point(16, 58);
            this.radSetCompressionLevel.Name = "radSetCompressionLevel";
            this.radSetCompressionLevel.Size = new System.Drawing.Size(136, 17);
            this.radSetCompressionLevel.TabIndex = 54;
            this.radSetCompressionLevel.Text = "Set Compression Level:";
            this.radSetCompressionLevel.UseVisualStyleBackColor = true;
            // 
            // howto_directory_compress_jpegs_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 250);
            this.Controls.Add(this.txtFilesProcessed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFinalTotalSize);
            this.Controls.Add(this.txtOriginalTotalSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtMaxFileSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPickFolder);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboCompressionLevel);
            this.Controls.Add(this.radSetMaxFileSize);
            this.Controls.Add(this.radSetCompressionLevel);
            this.Name = "howto_directory_compress_jpegs_Form1";
            this.Text = "howto_directory_compress_jpegs";
            this.Load += new System.EventHandler(this.howto_directory_compress_jpegs_Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_directory_compress_jpegs_Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilesProcessed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFinalTotalSize;
        private System.Windows.Forms.TextBox txtOriginalTotalSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtMaxFileSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPickFolder;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.FolderBrowserDialog fbdFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCompressionLevel;
        private System.Windows.Forms.RadioButton radSetMaxFileSize;
        private System.Windows.Forms.RadioButton radSetCompressionLevel;
    }
}

