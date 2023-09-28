using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Drawing.Imaging;

 

using howto_directory_to_grayscale;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_directory_to_grayscale_Form1:Form
  { 


        public howto_directory_to_grayscale_Form1()
        {
            InitializeComponent();
        }

        private void btnGrayscale_Click(object sender, EventArgs e)
        {
            ConvertFiles(txtDirectory.Text, false, chkIncludeSubdirectories.Checked);
        }

        private void btnAverage_Click(object sender, EventArgs e)
        {
            ConvertFiles(txtDirectory.Text, true, chkIncludeSubdirectories.Checked);
        }

        // Convert the files in the selected directory.
        private void ConvertFiles(string directory, bool use_average, bool include_subdirectories)
        {
            Cursor = Cursors.WaitCursor;

            // Get the search option.
            SearchOption search_option;
            if (include_subdirectories)
            {
                search_option = SearchOption.AllDirectories;
            }
            else
            {
                search_option = SearchOption.TopDirectoryOnly;
            }

            // Look for graphic files.
            string[] patterns = { "*.png", "*.bmp", "*.jpg", "*.jpeg", "*.gif" };
            foreach (string pattern in patterns)
            {
                // Find the matching files.
                foreach (string filename in Directory.GetFiles(directory, pattern, search_option))
                {
                    // Process the file.
                    lblFilename.Text = filename;
                    lblFilename.Refresh();
                    ConvertFile(filename, use_average);
                }
            }

            Cursor = Cursors.Default;
            lblFilename.Text = "";
        }

        // Convert a file.
        private void ConvertFile(string filename, bool use_average)
        {
            // Load the file.
            using (Bitmap bm = LoadBitmapWithoutLocking(filename))
            {
                // Convert the image.
                ConvertBitmapToGrayscale(bm, use_average);

                // Save the file.
                SaveBitmapUsingExtension(bm, filename);
            }
        }

        // Convert the Bitmap to grayscale.
        private void ConvertBitmapToGrayscale(Bitmap bm, bool use_average)
        {
            // Make a Bitmap24 object.
            Bitmap32 bm32 = new Bitmap32(bm);

            // Lock the bitmap.
            bm32.LockBitmap();

            // Process the pixels.
            for (int x = 0; x < bm.Width; x++)
            {
                for (int y = 0; y < bm.Height; y++)
                {
                    byte r = bm32.GetRed(x, y);
                    byte g = bm32.GetGreen(x, y);
                    byte b = bm32.GetBlue(x, y);
                    byte gray = (use_average ?
                        (byte)((r + g + b) / 3) :
                        (byte)(0.3 * r + 0.5 * g + 0.2 * b));
                    bm32.SetPixel(x, y, gray, gray, gray, 255);
                }
            }

            // Unlock the bitmap.
            bm32.UnlockBitmap();
        }

        // Save the file with the appropriate format.
        // Throw a NotSupportedException if the file
        // has an unknown extension.
        public void SaveBitmapUsingExtension(Bitmap bm, string filename)
        {
            string extension = Path.GetExtension(filename);
            switch (extension.ToLower())
            {
                case ".bmp":
                    bm.Save(filename, ImageFormat.Bmp);
                    break;
                case ".exif":
                    bm.Save(filename, ImageFormat.Exif);
                    break;
                case ".gif":
                    bm.Save(filename, ImageFormat.Gif);
                    break;
                case ".jpg":
                case ".jpeg":
                    bm.Save(filename, ImageFormat.Jpeg);
                    break;
                case ".png":
                    bm.Save(filename, ImageFormat.Png);
                    break;
                case ".tif":
                case ".tiff":
                    bm.Save(filename, ImageFormat.Tiff);
                    break;
                default:
                    throw new NotSupportedException(
                        "Unknown file extension " + extension);
            }
        }

        // Load a Bitmap without locking its file.
        // The caller must dispose of the Bitmap if desired.
        private Bitmap LoadBitmapWithoutLocking(string filename)
        {
            Bitmap result;
            using (Bitmap bm = new Bitmap(filename))
            {
                result = new Bitmap(bm.Width, bm.Height);
                using (Graphics gr = Graphics.FromImage(result))
                {
                    gr.DrawImage(bm, 0, 0);
                }
            }

            return result;
        }

        // Restore the saved directory.
        private void howto_directory_to_grayscale_Form1_Load(object sender, EventArgs e)
        {
            txtDirectory.Text = Properties.Settings.Default.Directory;
        }

        // Save the current directory.
        private void howto_directory_to_grayscale_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Directory = txtDirectory.Text;
            Properties.Settings.Default.Save();
        }

        // Display the folder browser dialog.
        private void btnPickDirectory_Click(object sender, EventArgs e)
        {
            fbdDirectory.SelectedPath = txtDirectory.Text;
            if (fbdDirectory.ShowDialog() == DialogResult.OK)
            {
                txtDirectory.Text = fbdDirectory.SelectedPath;
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.btnGrayscale = new System.Windows.Forms.Button();
            this.btnAverage = new System.Windows.Forms.Button();
            this.chkIncludeSubdirectories = new System.Windows.Forms.CheckBox();
            this.lblFilename = new System.Windows.Forms.Label();
            this.btnPickDirectory = new System.Windows.Forms.Button();
            this.fbdDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Directory:";
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Location = new System.Drawing.Point(70, 15);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(269, 20);
            this.txtDirectory.TabIndex = 1;
            // 
            // btnGrayscale
            // 
            this.btnGrayscale.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGrayscale.Location = new System.Drawing.Point(109, 74);
            this.btnGrayscale.Name = "btnGrayscale";
            this.btnGrayscale.Size = new System.Drawing.Size(75, 23);
            this.btnGrayscale.TabIndex = 2;
            this.btnGrayscale.Text = "Grayscale";
            this.btnGrayscale.UseVisualStyleBackColor = true;
            this.btnGrayscale.Click += new System.EventHandler(this.btnGrayscale_Click);
            // 
            // btnAverage
            // 
            this.btnAverage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAverage.Location = new System.Drawing.Point(200, 74);
            this.btnAverage.Name = "btnAverage";
            this.btnAverage.Size = new System.Drawing.Size(75, 23);
            this.btnAverage.TabIndex = 3;
            this.btnAverage.Text = "Average";
            this.btnAverage.UseVisualStyleBackColor = true;
            this.btnAverage.Click += new System.EventHandler(this.btnAverage_Click);
            // 
            // chkIncludeSubdirectories
            // 
            this.chkIncludeSubdirectories.AutoSize = true;
            this.chkIncludeSubdirectories.Location = new System.Drawing.Point(15, 41);
            this.chkIncludeSubdirectories.Name = "chkIncludeSubdirectories";
            this.chkIncludeSubdirectories.Size = new System.Drawing.Size(131, 17);
            this.chkIncludeSubdirectories.TabIndex = 4;
            this.chkIncludeSubdirectories.Text = "Include Subdirectories";
            this.chkIncludeSubdirectories.UseVisualStyleBackColor = true;
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Location = new System.Drawing.Point(12, 114);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(0, 13);
            this.lblFilename.TabIndex = 5;
            // 
            // btnPickDirectory
            // 
            this.btnPickDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPickDirectory.Image = Properties.Resources.Ellipsis;
            this.btnPickDirectory.Location = new System.Drawing.Point(345, 12);
            this.btnPickDirectory.Name = "btnPickDirectory";
            this.btnPickDirectory.Size = new System.Drawing.Size(27, 23);
            this.btnPickDirectory.TabIndex = 6;
            this.btnPickDirectory.UseVisualStyleBackColor = true;
            this.btnPickDirectory.Click += new System.EventHandler(this.btnPickDirectory_Click);
            // 
            // howto_directory_to_grayscale_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 136);
            this.Controls.Add(this.btnPickDirectory);
            this.Controls.Add(this.lblFilename);
            this.Controls.Add(this.chkIncludeSubdirectories);
            this.Controls.Add(this.btnAverage);
            this.Controls.Add(this.btnGrayscale);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.label1);
            this.Name = "howto_directory_to_grayscale_Form1";
            this.Text = "howto_directory_to_grayscale";
            this.Load += new System.EventHandler(this.howto_directory_to_grayscale_Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_directory_to_grayscale_Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Button btnGrayscale;
        private System.Windows.Forms.Button btnAverage;
        private System.Windows.Forms.CheckBox chkIncludeSubdirectories;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.Button btnPickDirectory;
        private System.Windows.Forms.FolderBrowserDialog fbdDirectory;
    }
}

