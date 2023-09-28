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

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_combine_pictures_Form1:Form
  { 


        public howto_combine_pictures_Form1()
        {
            InitializeComponent();
        }

        private void howto_combine_pictures_Form1_Load(object sender, EventArgs e)
        {
            txtSourceDir.Text = Application.StartupPath + @"\Pictures";
            txtOutputFile.Text = Application.StartupPath + @"\Combined.jpg";
        }

        private void btnBrowseSourceDir_Click(object sender, EventArgs e)
        {
            fbdSource.SelectedPath = txtSourceDir.Text;
            if (fbdSource.ShowDialog() == DialogResult.OK)
                txtSourceDir.Text = fbdSource.SelectedPath;
        }

        private void btnBrowseOutputFile_Click(object sender, EventArgs e)
        {
            sfdCombined.FileName = txtOutputFile.Text;
            if (sfdCombined.ShowDialog() == DialogResult.OK)
                txtOutputFile.Text = sfdCombined.FileName;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            // Get the picture files in the source directory.
            List<string> files = new List<string>();
            foreach (string filename in Directory.GetFiles(txtSourceDir.Text))
            {
                int pos = filename.LastIndexOf('.');
                string extension = filename.Substring(pos).ToLower();
                if ((extension == ".bmp") ||
                    (extension == ".jpg") ||
                    (extension == ".jpeg") ||
                    (extension == ".png") ||
                    (extension == ".tif") ||
                    (extension == ".tiff") ||
                    (extension == ".gif"))
                        files.Add(filename);
            }

            int num_images = files.Count;
            if (num_images == 0)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Selected 0 files");
                return;
            }

            // Load the images.
            Bitmap[] images = new Bitmap[files.Count];
            for (int i = 0; i < num_images; i++)
                images[i] = new Bitmap(files[i]);

            // Find the largest width and height.
            int max_wid = 0;
            int max_hgt = 0;
            for (int i = 0; i < num_images; i++)
            {
                if (max_wid < images[i].Width) max_wid = images[i].Width;
                if (max_hgt < images[i].Height) max_hgt = images[i].Height;
            }

            // Make the result bitmap.
            int margin = int.Parse(txtMargin.Text);
            int num_cols = int.Parse(txtNumCols.Text);
            int num_rows = (int)Math.Ceiling(num_images / (float)num_cols);
            int wid = max_wid * num_cols + margin * (num_cols - 1);
            int hgt = max_hgt * num_rows + margin * (num_rows - 1);
            Bitmap bm = new Bitmap(wid, hgt);

            // Place the images on it.
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(picBackground.BackColor);

                int x = 0;
                int y = 0;
                for (int i = 0; i < num_images; i++)
                {
                    gr.DrawImage(images[i], x, y);
                    x += max_wid + margin;
                    if (x >= wid)
                    {
                        y += max_hgt + margin;
                        x = 0;
                    }
                }
            }

            // Save the result.
            SaveImage(bm, txtOutputFile.Text);

            Cursor = Cursors.Default;
            MessageBox.Show("Done");
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

        private void picBackground_Click(object sender, EventArgs e)
        {
            cdBackground.Color = picBackground.BackColor;
            if (cdBackground.ShowDialog() == DialogResult.OK)
                picBackground.BackColor = cdBackground.Color;
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
            this.txtSourceDir = new System.Windows.Forms.TextBox();
            this.btnBrowseSourceDir = new System.Windows.Forms.Button();
            this.btnBrowseOutputFile = new System.Windows.Forms.Button();
            this.txtOutputFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumCols = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtMargin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.sfdCombined = new System.Windows.Forms.SaveFileDialog();
            this.fbdSource = new System.Windows.Forms.FolderBrowserDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.picBackground = new System.Windows.Forms.PictureBox();
            this.cdBackground = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source Dir:";
            // 
            // txtSourceDir
            // 
            this.txtSourceDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourceDir.Location = new System.Drawing.Point(86, 14);
            this.txtSourceDir.Name = "txtSourceDir";
            this.txtSourceDir.Size = new System.Drawing.Size(202, 20);
            this.txtSourceDir.TabIndex = 1;
            // 
            // btnBrowseSourceDir
            // 
            this.btnBrowseSourceDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseSourceDir.Image = Properties.Resources.EllipsisTransparent;
            this.btnBrowseSourceDir.Location = new System.Drawing.Point(294, 12);
            this.btnBrowseSourceDir.Name = "btnBrowseSourceDir";
            this.btnBrowseSourceDir.Size = new System.Drawing.Size(28, 23);
            this.btnBrowseSourceDir.TabIndex = 2;
            this.btnBrowseSourceDir.UseVisualStyleBackColor = true;
            this.btnBrowseSourceDir.Click += new System.EventHandler(this.btnBrowseSourceDir_Click);
            // 
            // btnBrowseOutputFile
            // 
            this.btnBrowseOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseOutputFile.Image = Properties.Resources.EllipsisTransparent;
            this.btnBrowseOutputFile.Location = new System.Drawing.Point(294, 38);
            this.btnBrowseOutputFile.Name = "btnBrowseOutputFile";
            this.btnBrowseOutputFile.Size = new System.Drawing.Size(28, 23);
            this.btnBrowseOutputFile.TabIndex = 5;
            this.btnBrowseOutputFile.UseVisualStyleBackColor = true;
            this.btnBrowseOutputFile.Click += new System.EventHandler(this.btnBrowseOutputFile_Click);
            // 
            // txtOutputFile
            // 
            this.txtOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputFile.Location = new System.Drawing.Point(86, 40);
            this.txtOutputFile.Name = "txtOutputFile";
            this.txtOutputFile.Size = new System.Drawing.Size(202, 20);
            this.txtOutputFile.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output File:";
            // 
            // txtNumCols
            // 
            this.txtNumCols.Location = new System.Drawing.Point(86, 66);
            this.txtNumCols.Name = "txtNumCols";
            this.txtNumCols.Size = new System.Drawing.Size(42, 20);
            this.txtNumCols.TabIndex = 7;
            this.txtNumCols.Text = "3";
            this.txtNumCols.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "# Columns:";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGo.Location = new System.Drawing.Point(130, 155);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 8;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtMargin
            // 
            this.txtMargin.Location = new System.Drawing.Point(86, 92);
            this.txtMargin.Name = "txtMargin";
            this.txtMargin.Size = new System.Drawing.Size(42, 20);
            this.txtMargin.TabIndex = 10;
            this.txtMargin.Text = "10";
            this.txtMargin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Margin:";
            // 
            // sfdCombined
            // 
            this.sfdCombined.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|Bitmaps|*.bmp|PNG files|*.png|JPEG file" +
                "s|*.jpg|GIF files|*.gif|TIFF files|*.tif|All files|*.*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Background:";
            // 
            // picBackground
            // 
            this.picBackground.BackColor = System.Drawing.Color.White;
            this.picBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBackground.Location = new System.Drawing.Point(86, 118);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(42, 20);
            this.picBackground.TabIndex = 12;
            this.picBackground.TabStop = false;
            this.picBackground.Click += new System.EventHandler(this.picBackground_Click);
            // 
            // howto_combine_pictures_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 190);
            this.Controls.Add(this.picBackground);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMargin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtNumCols);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBrowseOutputFile);
            this.Controls.Add(this.txtOutputFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowseSourceDir);
            this.Controls.Add(this.txtSourceDir);
            this.Controls.Add(this.label1);
            this.Name = "howto_combine_pictures_Form1";
            this.Text = "howto_combine_pictures";
            this.Load += new System.EventHandler(this.howto_combine_pictures_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSourceDir;
        private System.Windows.Forms.Button btnBrowseSourceDir;
        private System.Windows.Forms.Button btnBrowseOutputFile;
        private System.Windows.Forms.TextBox txtOutputFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumCols;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtMargin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SaveFileDialog sfdCombined;
        private System.Windows.Forms.FolderBrowserDialog fbdSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picBackground;
        private System.Windows.Forms.ColorDialog cdBackground;
    }
}

