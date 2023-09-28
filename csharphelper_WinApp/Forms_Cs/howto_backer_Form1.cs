using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Imaging;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_backer_Form1:Form
  { 


        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SystemParametersInfo(uint uiAction, uint uiParam, String pvParam, uint fWinIni);

        private const uint SPI_SETDESKWALLPAPER = 0x14;
        private const uint SPIF_UPDATEINIFILE = 0x1;
        private const uint SPIF_SENDWININICHANGE = 0x2;

        public howto_backer_Form1()
        {
            InitializeComponent();
        }

        // The list of files we will pick from.
        private List<string> FileNames = new List<string>();

        // Get ready.
        private void howto_backer_Form1_Load(object sender, EventArgs e)
        {
            // Restore the previous settings.
            if (Properties.Settings.Default.PictureDirectory == "")
                txtDirectory.Text = Application.StartupPath;
            else
                txtDirectory.Text = Properties.Settings.Default.PictureDirectory;
            chkUpdateRegistry.Checked = Properties.Settings.Default.UpdateRegistry;
            Location = Properties.Settings.Default.Location;
            Size = Properties.Settings.Default.Size;
            txtDelay.Text = Properties.Settings.Default.Delay.ToString();

            // Give the ellipsis button's image a transparent background.
            MakeButtonTransparent(btnPickDirectory);
        }

        // Save settings.
        private void howto_backer_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        // Give the button a transparent background.
        private void MakeButtonTransparent(Button btn)
        {
            Bitmap bm = (Bitmap)btn.Image;
            bm.MakeTransparent(bm.GetPixel(0, 0));
            btn.Image = bm;
        }

        // See: Search for files that match multiple patterns in C#
        //      http://csharphelper.com/blog/2015/06/find-files-that-match-multiple-patterns-in-c/
        // Search for files matching the patterns.
        private List<string> FindFiles(string dir_name, string patterns, bool search_subdirectories)
        {
            // Make the result list.
            List<string> files = new List<string>();

            // Get the patterns.
            string[] pattern_array = patterns.Split(';');

            // Search.
            SearchOption search_option = SearchOption.TopDirectoryOnly;
            if (search_subdirectories) search_option = SearchOption.AllDirectories;
            foreach (string pattern in pattern_array)
            {
                foreach (string filename in Directory.GetFiles(dir_name, pattern, search_option))
                {
                    if (!files.Contains(filename)) files.Add(filename);
                }
            }

            // Sort.
            files.Sort();

            // Return the result.
            return files;
        }

        // Apply the current settings.
        private void btnApply_Click(object sender, EventArgs e)
        {
            // Save the current settings.
            SaveSettings();

            // Load the list of files.
            if (Directory.Exists(txtDirectory.Text))
                FileNames = FindFiles(txtDirectory.Text,
                    "*.bmp;*.png;*.jpg;*.tif;*.gif", false);
            else
                FileNames = new List<string>();

            // Set the Timer's Interval.
            int delay = int.Parse(txtDelay.Text);
            tmrNewImage.Interval = 1000 * delay;
            tmrNewImage.Enabled = (FileNames.Count > 0);

            // Display the first picture.
            if (tmrNewImage.Enabled) ChangeDesktopPicture();
        }

        // Save the current settings.
        private void SaveSettings()
        {
            Properties.Settings.Default.PictureDirectory = txtDirectory.Text;
            Properties.Settings.Default.UpdateRegistry = chkUpdateRegistry.Checked;
            Properties.Settings.Default.Location = Location;
            Properties.Settings.Default.Size = Size;

            int delay;
            if (!int.TryParse(txtDelay.Text, out delay)) delay = 120;
            if (delay < 0) delay = 120;
            txtDelay.Text = delay.ToString();
            Properties.Settings.Default.Delay = delay;

            Properties.Settings.Default.Save();
        }

        // Display a random image.
        private Random Rand = new Random();
        private void tmrNewImage_Tick(object sender, EventArgs e)
        {
            ChangeDesktopPicture();
        }

        // Display a random image.
        private void ChangeDesktopPicture()
        {
            // Repeat until we succeed or run out of files.
            for (; ; )
            {
                // Pick a random image.
                int file_num = Rand.Next(FileNames.Count);

                // Try to use that image.
                try
                {
                    DisplayPicture(FileNames[file_num], chkUpdateRegistry.Checked);
                    break;
                }
                catch
                {
                    // This file doesn't work. Remove it from the list.
                    FileNames.RemoveAt(file_num);

                    // If there are no more files, stop trying.
                    if (FileNames.Count == 0)
                    {
                        tmrNewImage.Enabled = false;
                        break;
                    }
                }
            }
        }

        // Display the file on the desktop.
        private void DisplayPicture(string file_name, bool update_registry)
        {
            // If we should update the registry,
            // set the appropriate flags.
            uint flags = 0;
            if (update_registry)
                flags = SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE;

            // Set the desktop background to this file.
            if (!SystemParametersInfo(SPI_SETDESKWALLPAPER,
                0, file_name, flags))
            {
                MessageBox.Show("SystemParametersInfo failed.",
                    "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        // Let the user select a picture directory.
        private void btnPickDirectory_Click(object sender, EventArgs e)
        {
            fbdDirectory.SelectedPath = txtDirectory.Text;
            if (fbdDirectory.ShowDialog() == DialogResult.OK)
                txtDirectory.Text = fbdDirectory.SelectedPath;
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
            this.label2 = new System.Windows.Forms.Label();
            this.tmrNewImage = new System.Windows.Forms.Timer(this.components);
            this.txtDelay = new System.Windows.Forms.TextBox();
            this.chkUpdateRegistry = new System.Windows.Forms.CheckBox();
            this.fbdDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPickDirectory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Delay (sec):";
            // 
            // tmrNewImage
            // 
            this.tmrNewImage.Interval = 120000;
            this.tmrNewImage.Tick += new System.EventHandler(this.tmrNewImage_Tick);
            // 
            // txtDelay
            // 
            this.txtDelay.Location = new System.Drawing.Point(81, 37);
            this.txtDelay.Name = "txtDelay";
            this.txtDelay.Size = new System.Drawing.Size(40, 20);
            this.txtDelay.TabIndex = 8;
            this.txtDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkUpdateRegistry
            // 
            this.chkUpdateRegistry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkUpdateRegistry.AutoSize = true;
            this.chkUpdateRegistry.Location = new System.Drawing.Point(241, 39);
            this.chkUpdateRegistry.Name = "chkUpdateRegistry";
            this.chkUpdateRegistry.Size = new System.Drawing.Size(102, 17);
            this.chkUpdateRegistry.TabIndex = 9;
            this.chkUpdateRegistry.Text = "Update Registry";
            this.chkUpdateRegistry.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnApply.Location = new System.Drawing.Point(155, 77);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 11;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Location = new System.Drawing.Point(81, 11);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(262, 20);
            this.txtDirectory.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Directory:";
            // 
            // btnPickDirectory
            // 
            this.btnPickDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickDirectory.BackColor = System.Drawing.Color.Transparent;
            this.btnPickDirectory.Image = Properties.Resources.Ellipsis;
            this.btnPickDirectory.Location = new System.Drawing.Point(349, 9);
            this.btnPickDirectory.Name = "btnPickDirectory";
            this.btnPickDirectory.Size = new System.Drawing.Size(23, 23);
            this.btnPickDirectory.TabIndex = 7;
            this.btnPickDirectory.UseVisualStyleBackColor = false;
            this.btnPickDirectory.Click += new System.EventHandler(this.btnPickDirectory_Click);
            // 
            // howto_backer_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 111);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDelay);
            this.Controls.Add(this.chkUpdateRegistry);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnPickDirectory);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.label1);
            this.Name = "howto_backer_Form1";
            this.Text = "howto_backer";
            this.Load += new System.EventHandler(this.howto_backer_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer tmrNewImage;
        private System.Windows.Forms.TextBox txtDelay;
        private System.Windows.Forms.CheckBox chkUpdateRegistry;
        private System.Windows.Forms.FolderBrowserDialog fbdDirectory;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnPickDirectory;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Label label1;
    }
}

