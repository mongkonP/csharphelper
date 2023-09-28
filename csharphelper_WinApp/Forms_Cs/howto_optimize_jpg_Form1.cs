using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Imaging;
using System.IO;

 

using howto_optimize_jpg;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_optimize_jpg_Form1:Form
  { 


        public howto_optimize_jpg_Form1()
        {
            InitializeComponent();
        }

        private Image OriginalImage = null;

        // Select the default compression level.
        private void howto_optimize_jpg_Form1_Load(object sender, EventArgs e)
        {
            cboCI.Text = "100";
        }

        // Open a file.
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdPicture.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    // Load the file.
                    OriginalImage = LoadBitmapUnlocked(ofdPicture.FileName);

                    // Save at compression 100.
                    string file_name = Application.StartupPath + "\\__temp.jpg";
                    SaveJpg(OriginalImage, file_name, 100);

                    // See how big the file is.
                    FileInfo file_info = new FileInfo(file_name);
                    lbl100.Text = file_info.Length.ToFileSizeApi();

                    // Display the file at the selected compression.
                    ShowImageSample();
                    mnuFileSaveAs.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading file //" +
                        ofdPicture.FileName + "//\n" + ex.Message,
                        "Load Error", MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                }
            }
        }

        // Save the file with the selected compression level.
        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (OriginalImage == null) return;

            if (sfdPicture.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OriginalImage.Save(sfdPicture.FileName, ImageFormat.Jpeg);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving file //" +
                        sfdPicture.FileName + "//\n" + ex.Message,
                        "Save Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        // Display a sample that uses the selected compression index.
        private void cboCI_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCI.Text = cboCI.Text;
            ShowImageSample();
        }

        // Display a sample that uses the selected compression index.
        private void ShowImageSample()
        {
            if (OriginalImage == null) return;

            // Free the PictureBox's current image.
            if (picImage.Image != null)
            {
                picImage.Image.Dispose();
                picImage.Image = null;
            }

            // Save the image with the selected compression level.
            long compression = long.Parse(cboCI.Text);
            string file_name = Application.StartupPath + "\\__temp.jpg";
            SaveJpg(OriginalImage, file_name, compression);

            // Display the result without locking the file.
            picImage.Image = LoadBitmapUnlocked(file_name);

            // See how big the file is.
            FileInfo file_info = new FileInfo(file_name);
            lblFileSize.Text = file_info.Length.ToFileSizeApi();
        }

        // Return an ImageCodecInfo object for this mime type.
        private ImageCodecInfo GetEncoderInfo(string mime_type)
        {
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
            for (int i = 0; i <= encoders.Length; i++)
            {
                if (encoders[i].MimeType == mime_type) return encoders[i];
            }
            return null;
        }

        // Save the file with a specific compression level.
        private void SaveJpg(Image image, string file_name, long compression)
        {
            try
            {
                EncoderParameters encoder_params = new EncoderParameters(1);
                encoder_params.Param[0] = new EncoderParameter(
                    System.Drawing.Imaging.Encoder.Quality, compression);

                ImageCodecInfo image_codec_info = GetEncoderInfo("image/jpeg");
                File.Delete(file_name);
                image.Save(file_name, image_codec_info, encoder_params);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving file '" + file_name +
                    "'\nTry a different file name.\n" + ex.Message,
                    "Save Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Load a bitmap without locking it.
        private Bitmap LoadBitmapUnlocked(string file_name)
        {
            using (Bitmap bm = new Bitmap(file_name))
            {
                return new Bitmap(bm);
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
            this.lblFileSize = new System.Windows.Forms.Label();
            this.lblCI = new System.Windows.Forms.Label();
            this.lbl100 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.cboCI = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdPicture = new System.Windows.Forms.OpenFileDialog();
            this.sfdPicture = new System.Windows.Forms.SaveFileDialog();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFileSize
            // 
            this.lblFileSize.AutoSize = true;
            this.lblFileSize.Location = new System.Drawing.Point(139, 91);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(0, 13);
            this.lblFileSize.TabIndex = 17;
            // 
            // lblCI
            // 
            this.lblCI.AutoSize = true;
            this.lblCI.Location = new System.Drawing.Point(91, 91);
            this.lblCI.Name = "lblCI";
            this.lblCI.Size = new System.Drawing.Size(27, 13);
            this.lblCI.TabIndex = 16;
            this.lblCI.Text = "lblCI";
            // 
            // lbl100
            // 
            this.lbl100.AutoSize = true;
            this.lbl100.Location = new System.Drawing.Point(139, 67);
            this.lbl100.Name = "lbl100";
            this.lbl100.Size = new System.Drawing.Size(0, 13);
            this.lbl100.TabIndex = 15;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(12, 91);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(80, 13);
            this.Label3.TabIndex = 14;
            this.Label3.Text = "File Size at CI =";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(12, 67);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(101, 13);
            this.Label2.TabIndex = 13;
            this.Label2.Text = "File Size at CI = 100";
            // 
            // cboCI
            // 
            this.cboCI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCI.Items.AddRange(new object[] {
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
            this.cboCI.Location = new System.Drawing.Point(185, 30);
            this.cboCI.Name = "cboCI";
            this.cboCI.Size = new System.Drawing.Size(48, 21);
            this.cboCI.TabIndex = 9;
            this.cboCI.SelectedIndexChanged += new System.EventHandler(this.cboCI_SelectedIndexChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 33);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(138, 13);
            this.Label1.TabIndex = 12;
            this.Label1.Text = "JPG Compression Index (CI)";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(431, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.mnuFileSaveAs});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(163, 22);
            this.mnuFileOpen.Text = "&Open...";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSaveAs
            // 
            this.mnuFileSaveAs.Enabled = false;
            this.mnuFileSaveAs.Name = "mnuFileSaveAs";
            this.mnuFileSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSaveAs.Size = new System.Drawing.Size(163, 22);
            this.mnuFileSaveAs.Text = "&Save As...";
            this.mnuFileSaveAs.Click += new System.EventHandler(this.mnuFileSaveAs_Click);
            // 
            // ofdPicture
            // 
            this.ofdPicture.Filter = "Graphic Files|*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.tif;*.tiff|All Files|*.*";
            // 
            // sfdPicture
            // 
            this.sfdPicture.Filter = " Graphic Files|*.bmp,*.gif,*.jpg,*.jpeg,*.png,*.tif,*.tiff|All Files|*.*";
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(0, 0);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(62, 54);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImage.TabIndex = 19;
            this.picImage.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.picImage);
            this.panel1.Location = new System.Drawing.Point(12, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 402);
            this.panel1.TabIndex = 20;
            // 
            // howto_optimize_jpg_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 521);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblFileSize);
            this.Controls.Add(this.lblCI);
            this.Controls.Add(this.lbl100);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.cboCI);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_optimize_jpg_Form1";
            this.Text = "howto_optimize_jpg";
            this.Load += new System.EventHandler(this.howto_optimize_jpg_Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblFileSize;
        internal System.Windows.Forms.Label lblCI;
        internal System.Windows.Forms.Label lbl100;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox cboCI;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        private System.Windows.Forms.OpenFileDialog ofdPicture;
        private System.Windows.Forms.SaveFileDialog sfdPicture;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Panel panel1;
    }
}

