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
using System.Diagnostics;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_show_picture_thumbnails_Form1:Form
  { 


        [DllImport("Shlwapi.dll", CharSet = CharSet.Auto)]
        public static extern Int32 StrFormatByteSize(
            long fileSize,
            [MarshalAs(UnmanagedType.LPTStr)] StringBuilder buffer,
            int bufferSize);

        public howto_show_picture_thumbnails_Form1()
        {
            InitializeComponent();
        }

        // Start with the startup path selected.
        private void howto_show_picture_thumbnails_Form1_Load(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "..\\..");
            DirectoryInfo dir_info = new DirectoryInfo(path);
            txtDirectory.Text = dir_info.FullName;
        }

        // Let the user select a folder.
        private void btnPickDirectory_Click(object sender, EventArgs e)
        {
            fbdDirectory.SelectedPath = txtDirectory.Text;
            if (fbdDirectory.ShowDialog() == DialogResult.OK)
            {
                txtDirectory.Text = fbdDirectory.SelectedPath;
            }
        }

        // PictureBoxes we use to display thumbnails.
        private List<PictureBox> PictureBoxes = new List<PictureBox>();

        // Thumbnail sizes.
        private const int ThumbWidth = 100;
        private const int ThumbHeight = 100;

        // Display thumbnails for the selected directory.
        private void txtDirectory_TextChanged(object sender, EventArgs e)
        {
            // Delete the old PictureBoxes.
            foreach (PictureBox pic in PictureBoxes)
            {
                pic.DoubleClick -= PictureBox_DoubleClick;
                pic.Dispose();
            }
            flpThumbnails.Controls.Clear();
            PictureBoxes = new List<PictureBox>();

            // If the directory doesn't exist, do nothing else.
            if (!Directory.Exists(txtDirectory.Text)) return;

            // Get the names of the files in the directory.
            List<string> filenames = new List<string>();
            string[] patterns = { "*.png", "*.gif", "*.jpg", "*.bmp", "*.tif" };
            foreach (string pattern in patterns)
            {
                filenames.AddRange(Directory.GetFiles(txtDirectory.Text,
                    pattern, SearchOption.TopDirectoryOnly));
            }
            filenames.Sort();

            // Load the files.
            foreach (string filename in filenames)
            {
                // Load the picture into a PictureBox.
                PictureBox pic = new PictureBox();

                pic.ClientSize = new Size(ThumbWidth, ThumbHeight);
                pic.Image = new Bitmap(filename);

                // If the image is too big, zoom.
                if ((pic.Image.Width > ThumbWidth) ||
                    (pic.Image.Height > ThumbHeight))
                {
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pic.SizeMode = PictureBoxSizeMode.CenterImage;
                }

                // Add the DoubleClick event handler.
                pic.DoubleClick += PictureBox_DoubleClick;
                
                // Add a tooltip.
                FileInfo file_info = new FileInfo(filename);
                tipPicture.SetToolTip(pic, file_info.Name +
                    "\nCreated: " + file_info.CreationTime.ToShortDateString() +
                    "\n(" + pic.Image.Width + " x " + pic.Image.Height + ") " +
                    ToFileSizeApi(file_info.Length));
                pic.Tag = file_info;

                // Add the PictureBox to the FlowLayoutPanel.
                pic.Parent = flpThumbnails;
            }
        }

        // Return a file size created by the StrFormatByteSize API function.
        public static string ToFileSizeApi(long file_size)
        {
            StringBuilder sb = new StringBuilder(20);
            StrFormatByteSize(file_size, sb, 20);
            return sb.ToString();
        }

        // Open the file.
        private void PictureBox_DoubleClick(object sender, EventArgs e)
        {
            // Get the file's information.
            PictureBox pic = sender as PictureBox;
            FileInfo file_into = pic.Tag as FileInfo;

            // "Start" the file.
            Process.Start(file_into.FullName);
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
            this.flpThumbnails = new System.Windows.Forms.FlowLayoutPanel();
            this.fbdDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.tipPicture = new System.Windows.Forms.ToolTip(this.components);
            this.btnPickDirectory = new System.Windows.Forms.Button();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flpThumbnails
            // 
            this.flpThumbnails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flpThumbnails.AutoScroll = true;
            this.flpThumbnails.BackColor = System.Drawing.Color.LightGreen;
            this.flpThumbnails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flpThumbnails.Location = new System.Drawing.Point(12, 39);
            this.flpThumbnails.Name = "flpThumbnails";
            this.flpThumbnails.Size = new System.Drawing.Size(342, 214);
            this.flpThumbnails.TabIndex = 7;
            // 
            // btnPickDirectory
            // 
            this.btnPickDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickDirectory.BackgroundImage = Properties.Resources.Ellipsis;
            this.btnPickDirectory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPickDirectory.Location = new System.Drawing.Point(328, 11);
            this.btnPickDirectory.Name = "btnPickDirectory";
            this.btnPickDirectory.Size = new System.Drawing.Size(26, 23);
            this.btnPickDirectory.TabIndex = 6;
            this.btnPickDirectory.UseVisualStyleBackColor = true;
            this.btnPickDirectory.Click += new System.EventHandler(this.btnPickDirectory_Click);
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Location = new System.Drawing.Point(70, 13);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(252, 20);
            this.txtDirectory.TabIndex = 5;
            this.txtDirectory.TextChanged += new System.EventHandler(this.txtDirectory_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Directory:";
            // 
            // howto_show_picture_thumbnails_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 264);
            this.Controls.Add(this.flpThumbnails);
            this.Controls.Add(this.btnPickDirectory);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.label1);
            this.Name = "howto_show_picture_thumbnails_Form1";
            this.Text = "howto_show_picture_thumbnails";
            this.Load += new System.EventHandler(this.howto_show_picture_thumbnails_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpThumbnails;
        private System.Windows.Forms.FolderBrowserDialog fbdDirectory;
        private System.Windows.Forms.ToolTip tipPicture;
        private System.Windows.Forms.Button btnPickDirectory;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Label label1;
    }
}

