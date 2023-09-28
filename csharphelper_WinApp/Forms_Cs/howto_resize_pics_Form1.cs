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
     public partial class howto_resize_pics_Form1:Form
  { 


        public howto_resize_pics_Form1()
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
            float scale = float.Parse(txtScale.Text);
            if (scale == 0)
            {
                MessageBox.Show("Scale must not be zero.",
                    "Invalid Scale", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
                        Bitmap bm = new Bitmap(file_info.FullName);
                        picWorking.Image = bm;
                        this.Text = "howto_2005_resize_pics - " +
                            file_info.Name;
                        Application.DoEvents();

                        Rectangle from_rect =
                            new Rectangle(0, 0, bm.Width, bm.Height);

                        int wid2 = (int)Math.Round(scale * bm.Width);
                        int hgt2 = (int)Math.Round(scale * bm.Height);
                        Bitmap bm2 = new Bitmap(wid2, hgt2);
                        Rectangle dest_rect = new Rectangle(0, 0, wid2, hgt2);
                        using (Graphics gr = Graphics.FromImage(bm2))
                        {
                            gr.InterpolationMode =
                                InterpolationMode.HighQualityBicubic;
                            gr.DrawImage(bm, dest_rect, from_rect,
                                GraphicsUnit.Pixel);
                        }

                        string new_name = file_info.FullName;
                        new_name = new_name.Substring(0,
                            new_name.Length - ext.Length);
                        new_name += "_s" + ext;
                        SaveImage(bm2, new_name);
                    } // if it's a graphic extension
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
            this.Text = "howto_resize_pics";
            this.Cursor = Cursors.Default;
        }

        // Restore parameters.
        private void howto_resize_pics_Form1_Load(object sender, EventArgs e)
        {
            this.SetBounds(
                Properties.Settings.Default.Left,
                Properties.Settings.Default.Top,
                Properties.Settings.Default.Width,
                Properties.Settings.Default.Height);

            txtDirectory.Text = Properties.Settings.Default.Directory;
            if (txtDirectory.Text.Length == 0) txtDirectory.Text = Application.StartupPath;
            txtScale.Text = Properties.Settings.Default.Scale;
        }

        // Save parameters.
        private void howto_resize_pics_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Left = this.Left;
            Properties.Settings.Default.Top = this.Top;
            Properties.Settings.Default.Width = this.Width;
            Properties.Settings.Default.Height = this.Height;

            Properties.Settings.Default.Directory = txtDirectory.Text;
            Properties.Settings.Default.Scale = txtScale.Text;

            Properties.Settings.Default.Save();
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
            this.picWorking = new System.Windows.Forms.PictureBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtScale = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnPickDirectory = new System.Windows.Forms.Button();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.fbdDirectory = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picWorking)).BeginInit();
            this.SuspendLayout();
            // 
            // picWorking
            // 
            this.picWorking.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picWorking.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picWorking.Location = new System.Drawing.Point(15, 86);
            this.picWorking.Name = "picWorking";
            this.picWorking.Size = new System.Drawing.Size(457, 266);
            this.picWorking.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picWorking.TabIndex = 13;
            this.picWorking.TabStop = false;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(204, 48);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 12;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtScale
            // 
            this.txtScale.Location = new System.Drawing.Point(70, 50);
            this.txtScale.Name = "txtScale";
            this.txtScale.Size = new System.Drawing.Size(48, 20);
            this.txtScale.TabIndex = 11;
            this.txtScale.Text = "0.25";
            this.txtScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(12, 50);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(37, 13);
            this.Label2.TabIndex = 10;
            this.Label2.Text = "Scale:";
            // 
            // btnPickDirectory
            // 
            this.btnPickDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickDirectory.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPickDirectory.Location = new System.Drawing.Point(443, 12);
            this.btnPickDirectory.Name = "btnPickDirectory";
            this.btnPickDirectory.Size = new System.Drawing.Size(32, 24);
            this.btnPickDirectory.TabIndex = 9;
            this.btnPickDirectory.Text = "...";
            this.btnPickDirectory.UseVisualStyleBackColor = true;
            this.btnPickDirectory.Click += new System.EventHandler(this.btnPickDirectory_Click);
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Location = new System.Drawing.Point(70, 15);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(367, 20);
            this.txtDirectory.TabIndex = 8;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 18);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(52, 13);
            this.Label1.TabIndex = 7;
            this.Label1.Text = "Directory:";
            // 
            // howto_resize_pics_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 364);
            this.Controls.Add(this.picWorking);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtScale);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.btnPickDirectory);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.Label1);
            this.Name = "howto_resize_pics_Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "howto_resize_pics";
            this.Load += new System.EventHandler(this.howto_resize_pics_Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_resize_pics_Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picWorking)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox picWorking;
        internal System.Windows.Forms.Button btnGo;
        internal System.Windows.Forms.TextBox txtScale;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button btnPickDirectory;
        internal System.Windows.Forms.TextBox txtDirectory;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.FolderBrowserDialog fbdDirectory;
    }
}

