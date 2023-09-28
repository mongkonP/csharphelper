using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_resize_pics_to_size_Form1:Form
  { 


        public howto_resize_pics_to_size_Form1()
        {
            InitializeComponent();
        }

        // Let the user browse for the directory.
        private void btnPickDirectory_Click(object sender, EventArgs e)
        {
            try
            {
                fbdDirectory.SelectedPath = txtDirectory.Text;
            }
            catch
            {
            }

            if (fbdDirectory.ShowDialog() == DialogResult.OK)
            {
                txtDirectory.Text = fbdDirectory.SelectedPath;
            }
        }

        // Process the files in the selected directory.
        private void btnGo_Click(object sender, EventArgs e)
        {
            // See which values we will set.
            bool set_width = chkSetWidth.Checked;
            bool set_height = chkSetHeight.Checked;

            if (!set_width && !set_height)
            {
                MessageBox.Show("You must set at least one of the width and height.",
                    "No Boxes Checked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the new width and height values.
            int new_width = 0;
            int new_height = 0;
            int.TryParse(txtNewWidth.Text, out new_width);
            int.TryParse(txtNewHeight.Text, out new_height);

            if (set_width && (new_width < 1))
            {
                MessageBox.Show("The new width must be at least 1.",
                    "Invalid Width", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (set_height && (new_height < 1))
            {
                MessageBox.Show("The new height must be at least 1.",
                    "Invalid Height", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            this.Refresh();

            DirectoryInfo dir_info = new DirectoryInfo(txtDirectory.Text);
            foreach (FileInfo file_info in dir_info.GetFiles())
            {
                try
                {
                    string ext = file_info.Extension.ToLower();
                    if ((ext == ".bmp") || (ext == ".gif") ||
                        (ext == ".jpg") || (ext == ".jpeg") ||
                        (ext == ".png"))
                    {
                        using (Bitmap bm = new Bitmap(file_info.FullName))
                        {
                            picWorking.Image = bm;
                            picWorking.Refresh();

                            Bitmap bm2 = ResizeBitmap(bm,
                                set_width, set_height,
                                new_width, new_height);

                            string new_name = file_info.FullName;
                            new_name = new_name.Substring(0,
                                new_name.Length - ext.Length);
                            new_name += "_s" + ext;
                            SaveImage(bm2, new_name);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error processing file '" +
                        file_info.Name + "'\n" + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            } // foreach file_info

            picWorking.Image = null;
            this.Text = "howto_resize_pics2";
            this.Cursor = Cursors.Default;
        }

        // Resize a bitmap to the given dimensions.
        // If one dimension is omitted, scale the image uniformly.
        private Bitmap ResizeBitmap(Bitmap bm,
            bool set_width, bool set_height,
            int new_width, int new_height)
        {
            Rectangle from_rect =
                new Rectangle(0, 0, bm.Width, bm.Height);

            // Calculate the image's new width and height.
            int wid2, hgt2;
            if (set_width)
                wid2 = new_width;
            else
                wid2 = bm.Width * new_height / bm.Height;
            if (set_height)
                hgt2 = new_height;
            else
                hgt2 = bm.Height * new_width / bm.Width;

            // Make the new image.
            Bitmap bm2 = new Bitmap(wid2, hgt2);

            // Draw the original image onto the new bitmap.
            Rectangle dest_rect = new Rectangle(0, 0, wid2, hgt2);
            using (Graphics gr = Graphics.FromImage(bm2))
            {
                gr.InterpolationMode =
                    InterpolationMode.HighQualityBicubic;
                gr.DrawImage(bm, dest_rect, from_rect,
                    GraphicsUnit.Pixel);
            }

            return bm2;
        }

        // Save the file with the appropriate format.
        public void SaveImage(Image image, string filename)
        {
            string extension = Path.GetExtension(filename);
            switch (extension.ToLower())
            {
                case ".bmp":
                    image.Save(filename, ImageFormat.Bmp);
                    break;
                case ".exif":
                    image.Save(filename, ImageFormat.Exif);
                    break;
                case ".gif":
                    image.Save(filename, ImageFormat.Gif);
                    break;
                case ".jpg":
                case ".jpeg":
                    image.Save(filename, ImageFormat.Jpeg);
                    break;
                case ".png":
                    image.Save(filename, ImageFormat.Png);
                    break;
                case ".tif":
                case ".tiff":
                    image.Save(filename, ImageFormat.Tiff);
                    break;
                default:
                    throw new NotSupportedException(
                        "Unknown file extension " + extension);
            }
        }

        private void howto_resize_pics_to_size_Form1_Load(object sender, EventArgs e)
        {
            txtDirectory.Text = Application.StartupPath;
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
            this.chkSetHeight = new System.Windows.Forms.CheckBox();
            this.chkSetWidth = new System.Windows.Forms.CheckBox();
            this.txtNewHeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fbdDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.picWorking = new System.Windows.Forms.PictureBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtNewWidth = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnPickDirectory = new System.Windows.Forms.Button();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picWorking)).BeginInit();
            this.SuspendLayout();
            // 
            // chkSetHeight
            // 
            this.chkSetHeight.AutoSize = true;
            this.chkSetHeight.Checked = true;
            this.chkSetHeight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSetHeight.Location = new System.Drawing.Point(151, 69);
            this.chkSetHeight.Name = "chkSetHeight";
            this.chkSetHeight.Size = new System.Drawing.Size(76, 17);
            this.chkSetHeight.TabIndex = 5;
            this.chkSetHeight.Text = "Set Height";
            this.chkSetHeight.UseVisualStyleBackColor = true;
            // 
            // chkSetWidth
            // 
            this.chkSetWidth.AutoSize = true;
            this.chkSetWidth.Location = new System.Drawing.Point(151, 43);
            this.chkSetWidth.Name = "chkSetWidth";
            this.chkSetWidth.Size = new System.Drawing.Size(73, 17);
            this.chkSetWidth.TabIndex = 3;
            this.chkSetWidth.Text = "Set Width";
            this.chkSetWidth.UseVisualStyleBackColor = true;
            // 
            // txtNewHeight
            // 
            this.txtNewHeight.Location = new System.Drawing.Point(83, 67);
            this.txtNewHeight.Name = "txtNewHeight";
            this.txtNewHeight.Size = new System.Drawing.Size(48, 20);
            this.txtNewHeight.TabIndex = 4;
            this.txtNewHeight.Text = "256";
            this.txtNewHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "New Height:";
            // 
            // picWorking
            // 
            this.picWorking.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picWorking.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picWorking.Location = new System.Drawing.Point(14, 93);
            this.picWorking.Name = "picWorking";
            this.picWorking.Size = new System.Drawing.Size(307, 206);
            this.picWorking.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picWorking.TabIndex = 24;
            this.picWorking.TabStop = false;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(233, 52);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtNewWidth
            // 
            this.txtNewWidth.Location = new System.Drawing.Point(83, 41);
            this.txtNewWidth.Name = "txtNewWidth";
            this.txtNewWidth.Size = new System.Drawing.Size(48, 20);
            this.txtNewWidth.TabIndex = 2;
            this.txtNewWidth.Text = "256";
            this.txtNewWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(11, 44);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(63, 13);
            this.Label2.TabIndex = 21;
            this.Label2.Text = "New Width:";
            // 
            // btnPickDirectory
            // 
            this.btnPickDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickDirectory.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPickDirectory.Location = new System.Drawing.Point(292, 12);
            this.btnPickDirectory.Name = "btnPickDirectory";
            this.btnPickDirectory.Size = new System.Drawing.Size(32, 24);
            this.btnPickDirectory.TabIndex = 1;
            this.btnPickDirectory.Text = "...";
            this.btnPickDirectory.UseVisualStyleBackColor = true;
            this.btnPickDirectory.Click += new System.EventHandler(this.btnPickDirectory_Click);
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Location = new System.Drawing.Point(83, 15);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(203, 20);
            this.txtDirectory.TabIndex = 0;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(11, 18);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(52, 13);
            this.Label1.TabIndex = 18;
            this.Label1.Text = "Directory:";
            // 
            // howto_resize_pics_to_size_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 311);
            this.Controls.Add(this.chkSetHeight);
            this.Controls.Add(this.chkSetWidth);
            this.Controls.Add(this.txtNewHeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picWorking);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtNewWidth);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.btnPickDirectory);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.Label1);
            this.Name = "howto_resize_pics_to_size_Form1";
            this.Text = "howto_resize_pics_to_size";
            this.Load += new System.EventHandler(this.howto_resize_pics_to_size_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picWorking)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSetHeight;
        private System.Windows.Forms.CheckBox chkSetWidth;
        internal System.Windows.Forms.TextBox txtNewHeight;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.FolderBrowserDialog fbdDirectory;
        internal System.Windows.Forms.PictureBox picWorking;
        internal System.Windows.Forms.Button btnGo;
        internal System.Windows.Forms.TextBox txtNewWidth;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button btnPickDirectory;
        internal System.Windows.Forms.TextBox txtDirectory;
        internal System.Windows.Forms.Label Label1;
    }
}

