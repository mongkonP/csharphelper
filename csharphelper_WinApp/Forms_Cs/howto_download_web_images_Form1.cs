using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Add a reference to Microsoft.mshtml.
using mshtml;
using System.IO;
using System.Net;
using System.Drawing.Imaging;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_download_web_images_Form1:Form
  { 


        public howto_download_web_images_Form1()
        {
            InitializeComponent();
        }

        // Navigate to the entered URL.
        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                wbrWebSite.Navigate(txtUrl.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error navigating to web site " +
                    txtUrl.Text + '\n' + ex.Message,
                    "Navigation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Show the images from the URL.
        private bool Running = false;
        private void btnListImages_Click(object sender, EventArgs e)
        {
            if (btnListImages.Text == "List Images")
            {
                this.Cursor = Cursors.WaitCursor;
                btnListImages.Text = "Stop";
                btnGo.Enabled = false;
                btnSaveImages.Enabled = false;
                Application.DoEvents();

                // Remove old images.
                for (int i = flpPictures.Controls.Count - 1; i >= 0; i--)
                {
                    flpPictures.Controls[i].Parent = null;
                }

                // List the images on this page.
                HtmlDocument doc = wbrWebSite.Document;
                Running = true;
                foreach (HtmlElement element in doc.Images)
                {
                    mshtml.HTMLImg dom_element = (mshtml.HTMLImg)element.DomElement;
                    string src = dom_element.src;

                    PictureBox pic = new PictureBox();
                    pic.BorderStyle = BorderStyle.Fixed3D;
                    pic.Image = GetPicture(src);
                    SetPictureBoxSize(pic);
                    pic.Parent = flpPictures;
                    pic.Tag = src;
                    tipFileName.SetToolTip(pic, src);

                    pic.Click += pic_Click;

                    Application.DoEvents();

                    if (!Running) break;
                }
                Running = false;

                btnListImages.Text = "List Images";
                btnGo.Enabled = true;
                btnSaveImages.Enabled = true;
                this.Cursor = Cursors.Default;
            }
            else
            {
                Running = false;
            }
        }

        // Set the PictureBox to AutoSize if it's reasonably small
        // or give it a maximum size if it's too big.
        private void SetPictureBoxSize(PictureBox pic)
        {
            const int max_width = 300;
            const int max_height = 300;
            if ((pic.Image.Width <= max_width) &&
                (pic.Image.Height <= max_height))
            {
                // It's small enough.
                pic.SizeMode = PictureBoxSizeMode.AutoSize;
            }
            else
            {
                // Restrict its size.
                float w_scale = max_width / (float)pic.Image.Width;
                float h_scale = max_height / (float)pic.Image.Height;
                float scale = Math.Min(w_scale, h_scale);
                pic.SizeMode = PictureBoxSizeMode.Zoom;
                pic.Size = new Size(
                    (int)(scale * pic.Image.Width),
                    (int)(scale * pic.Image.Height));
            }
        }

        // Get the picture at a given URL.
        private Image GetPicture(string url)
        {
            try
            {
                url = url.Trim();
                if (!url.ToLower().StartsWith("http://")) url = "http://" + url;
                WebClient web_client = new WebClient();
                MemoryStream image_stream = new MemoryStream(web_client.DownloadData(url));
                return Image.FromStream(image_stream);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error downloading picture " +
                    url + '\n' + ex.Message,
                    "Download Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            return null;
        }

        // Remove the clicked PictureBox.
        private void pic_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            pic.Parent = null;
        }

        // Stop. This may take a little while as pending downloads complete.
        private void howto_download_web_images_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Running = false;
        }

        // Set the initial save directory.
        private void howto_download_web_images_Form1_Load(object sender, EventArgs e)
        {
            txtDirectory.Text = Path.Combine(
                Application.StartupPath, "Images");
        }

        // Save the images that have not been removed.
        private void btnSaveImages_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            // Get the directory path and make sure the directory exists.
            string dir_name = txtDirectory.Text;
            if (!dir_name.EndsWith(@"\")) dir_name += @"\";
            Directory.CreateDirectory(dir_name);

            foreach (PictureBox pic in flpPictures.Controls)
            {
                Bitmap bm = (Bitmap)pic.Image;
                string filename = dir_name + Path.GetFileName(pic.Tag.ToString());
                SaveImage(bm, filename);
            }

            Cursor = Cursors.Default;
            System.Media.SystemSounds.Beep.Play();
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
            this.components = new System.ComponentModel.Container();
            this.wbrWebSite = new System.Windows.Forms.WebBrowser();
            this.tipFileName = new System.Windows.Forms.ToolTip(this.components);
            this.btnSaveImages = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.flpPictures = new System.Windows.Forms.FlowLayoutPanel();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnListImages = new System.Windows.Forms.Button();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // wbrWebSite
            // 
            this.wbrWebSite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wbrWebSite.Location = new System.Drawing.Point(8, 40);
            this.wbrWebSite.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbrWebSite.Name = "wbrWebSite";
            this.wbrWebSite.Size = new System.Drawing.Size(352, 484);
            this.wbrWebSite.TabIndex = 0;
            this.wbrWebSite.Url = new System.Uri("http://www.csharphelper.com/articles.html", System.UriKind.Absolute);
            // 
            // btnSaveImages
            // 
            this.btnSaveImages.Location = new System.Drawing.Point(88, 8);
            this.btnSaveImages.Name = "btnSaveImages";
            this.btnSaveImages.Size = new System.Drawing.Size(80, 23);
            this.btnSaveImages.TabIndex = 4;
            this.btnSaveImages.Text = "Save Images";
            this.btnSaveImages.UseVisualStyleBackColor = true;
            this.btnSaveImages.Click += new System.EventHandler(this.btnSaveImages_Click);
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(328, 8);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(32, 24);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Location = new System.Drawing.Point(176, 8);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(280, 20);
            this.txtDirectory.TabIndex = 6;
            // 
            // flpPictures
            // 
            this.flpPictures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flpPictures.AutoScroll = true;
            this.flpPictures.Location = new System.Drawing.Point(0, 40);
            this.flpPictures.Name = "flpPictures";
            this.flpPictures.Size = new System.Drawing.Size(464, 488);
            this.flpPictures.TabIndex = 7;
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Location = new System.Drawing.Point(8, 8);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(312, 20);
            this.txtUrl.TabIndex = 1;
            this.txtUrl.Text = "http://www.csharphelper.com/articles.html";
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.BackColor = System.Drawing.Color.Cyan;
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SplitContainer1.Panel1.Controls.Add(this.wbrWebSite);
            this.SplitContainer1.Panel1.Controls.Add(this.btnGo);
            this.SplitContainer1.Panel1.Controls.Add(this.txtUrl);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SplitContainer1.Panel2.Controls.Add(this.flpPictures);
            this.SplitContainer1.Panel2.Controls.Add(this.txtDirectory);
            this.SplitContainer1.Panel2.Controls.Add(this.btnSaveImages);
            this.SplitContainer1.Panel2.Controls.Add(this.btnListImages);
            this.SplitContainer1.Size = new System.Drawing.Size(828, 526);
            this.SplitContainer1.SplitterDistance = 362;
            this.SplitContainer1.TabIndex = 5;
            // 
            // btnListImages
            // 
            this.btnListImages.Location = new System.Drawing.Point(0, 8);
            this.btnListImages.Name = "btnListImages";
            this.btnListImages.Size = new System.Drawing.Size(80, 23);
            this.btnListImages.TabIndex = 3;
            this.btnListImages.Text = "List Images";
            this.btnListImages.UseVisualStyleBackColor = true;
            this.btnListImages.Click += new System.EventHandler(this.btnListImages_Click);
            // 
            // howto_download_web_images_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 526);
            this.Controls.Add(this.SplitContainer1);
            this.Name = "howto_download_web_images_Form1";
            this.Text = "howto_download_web_images";
            this.Load += new System.EventHandler(this.howto_download_web_images_Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_download_web_images_Form1_FormClosing);
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel1.PerformLayout();
            this.SplitContainer1.Panel2.ResumeLayout(false);
            this.SplitContainer1.Panel2.PerformLayout();
            this.SplitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.WebBrowser wbrWebSite;
        internal System.Windows.Forms.ToolTip tipFileName;
        internal System.Windows.Forms.Button btnSaveImages;
        internal System.Windows.Forms.Button btnGo;
        internal System.Windows.Forms.TextBox txtDirectory;
        internal System.Windows.Forms.FlowLayoutPanel flpPictures;
        internal System.Windows.Forms.TextBox txtUrl;
        internal System.Windows.Forms.SplitContainer SplitContainer1;
        internal System.Windows.Forms.Button btnListImages;
    }
}

