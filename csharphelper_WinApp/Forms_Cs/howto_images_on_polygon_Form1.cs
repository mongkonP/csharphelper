using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_images_on_polygon_Form1:Form
  { 


        public howto_images_on_polygon_Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap fg_image = new Bitmap(txtFgImage.Text);
                Bitmap bg_image = new Bitmap(txtBgImage.Text);
                int width = int.Parse(txtWidth.Text);
                int height = int.Parse(txtHeight.Text);
                int fg_width = int.Parse(txtFgWidth.Text);
                int radius = int.Parse(txtRadius.Text);
                int num_images = int.Parse(txtNumImages.Text);

                // Scale the foreground image.
                float scale = fg_width / (float)fg_image.Width;
                int fg_height = (int)(fg_image.Height * scale);
                fg_image = new Bitmap(fg_image, new Size(fg_width, fg_height));

                // Draw the final result.
                Bitmap bm = new Bitmap(width, height);
                using (Graphics gr = Graphics.FromImage(bm))
                {
                    gr.InterpolationMode = InterpolationMode.High;
                    gr.DrawImage(bg_image, 0, 0);
                    int cx = width / 2;
                    int cy = height / 2;
                    int rx = fg_width / 2;
                    int ry = fg_height / 2;
                    RectangleF src_rect =
                        new RectangleF(0, 0, fg_width, fg_height);

                    double theta = -Math.PI / 2;
                    double dtheta = 2 * Math.PI / num_images;
                    for (int i = 0; i < num_images; i++)
                    {
                        float x = (float)(radius * Math.Cos(theta));
                        float y = (float)(radius * Math.Sin(theta));
                        PointF[] dest_points =
                        {
                            new PointF(cx + x - rx, cy + y - ry),
                            new PointF(cx + x + rx, cy + y - ry),
                            new PointF(cx + x - rx, cy + y + ry),
                        };
                        gr.DrawImage(fg_image, dest_points, src_rect, GraphicsUnit.Pixel);
                        theta += dtheta;
                    }

                    // Redraw the left side of the first image.
                    src_rect =
                        new RectangleF(0, 0, fg_width / 2f, fg_height);

                    theta = -Math.PI / 2;
                    {
                        float x = (float)(radius * Math.Cos(theta));
                        float y = (float)(radius * Math.Sin(theta));
                        PointF[] dest_points =
                        {
                            new PointF(cx + x - rx, cy + y - ry),
                            new PointF(cx + x, cy + y - ry),
                            new PointF(cx + x - rx, cy + y + ry),
                        };
                        gr.DrawImage(fg_image, dest_points, src_rect, GraphicsUnit.Pixel);
                    }
                }
                picResult.Image = bm;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuFileForegroundImage_Click(object sender, EventArgs e)
        {
            ofdImage.FileName = txtFgImage.Text;
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                txtFgImage.Text = ofdImage.FileName;
            }
        }

        private void mnuFileBackgroundImage_Click(object sender, EventArgs e)
        {
            ofdImage.FileName = txtBgImage.Text;
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                txtBgImage.Text = ofdImage.FileName;
            }
        }

        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (sfdResult.ShowDialog() == DialogResult.OK)
            {
                SaveImage(picResult.Image, sfdResult.FileName);
            }
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

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
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
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBgImage = new System.Windows.Forms.TextBox();
            this.txtFgImage = new System.Windows.Forms.TextBox();
            this.picResult = new System.Windows.Forms.PictureBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtFgWidth = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRadius = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumImages = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileForegroundImage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileBackgroundImage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdImage = new System.Windows.Forms.OpenFileDialog();
            this.sfdResult = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Final Size:";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(72, 79);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(39, 20);
            this.txtWidth.TabIndex = 2;
            this.txtWidth.Text = "400";
            this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "x";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(135, 79);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(39, 20);
            this.txtHeight.TabIndex = 3;
            this.txtHeight.Text = "400";
            this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bg Image:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Fg Image:";
            // 
            // txtBgImage
            // 
            this.txtBgImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBgImage.Location = new System.Drawing.Point(72, 27);
            this.txtBgImage.Name = "txtBgImage";
            this.txtBgImage.Size = new System.Drawing.Size(228, 20);
            this.txtBgImage.TabIndex = 0;
            this.txtBgImage.Text = "stars.jpg";
            // 
            // txtFgImage
            // 
            this.txtFgImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFgImage.Location = new System.Drawing.Point(72, 53);
            this.txtFgImage.Name = "txtFgImage";
            this.txtFgImage.Size = new System.Drawing.Size(228, 20);
            this.txtFgImage.TabIndex = 1;
            this.txtFgImage.Text = "cake.png";
            // 
            // picResult
            // 
            this.picResult.Location = new System.Drawing.Point(12, 183);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(72, 63);
            this.picResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picResult.TabIndex = 8;
            this.picResult.TabStop = false;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(225, 118);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 7;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtFgWidth
            // 
            this.txtFgWidth.Location = new System.Drawing.Point(72, 105);
            this.txtFgWidth.Name = "txtFgWidth";
            this.txtFgWidth.Size = new System.Drawing.Size(39, 20);
            this.txtFgWidth.TabIndex = 4;
            this.txtFgWidth.Text = "150";
            this.txtFgWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Fg Width:";
            // 
            // txtRadius
            // 
            this.txtRadius.Location = new System.Drawing.Point(72, 131);
            this.txtRadius.Name = "txtRadius";
            this.txtRadius.Size = new System.Drawing.Size(39, 20);
            this.txtRadius.TabIndex = 5;
            this.txtRadius.Text = "100";
            this.txtRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Radius:";
            // 
            // txtNumImages
            // 
            this.txtNumImages.Location = new System.Drawing.Point(72, 157);
            this.txtNumImages.Name = "txtNumImages";
            this.txtNumImages.Size = new System.Drawing.Size(39, 20);
            this.txtNumImages.TabIndex = 6;
            this.txtNumImages.Text = "6";
            this.txtNumImages.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "# Images:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(312, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileForegroundImage,
            this.mnuFileBackgroundImage,
            this.mnuFileSaveAs,
            this.toolStripMenuItem1,
            this.mnuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuFileForegroundImage
            // 
            this.mnuFileForegroundImage.Name = "mnuFileForegroundImage";
            this.mnuFileForegroundImage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.mnuFileForegroundImage.Size = new System.Drawing.Size(224, 22);
            this.mnuFileForegroundImage.Text = "&Foreground Image...";
            this.mnuFileForegroundImage.Click += new System.EventHandler(this.mnuFileForegroundImage_Click);
            // 
            // mnuFileBackgroundImage
            // 
            this.mnuFileBackgroundImage.Name = "mnuFileBackgroundImage";
            this.mnuFileBackgroundImage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.mnuFileBackgroundImage.Size = new System.Drawing.Size(224, 22);
            this.mnuFileBackgroundImage.Text = "&Background Image...";
            this.mnuFileBackgroundImage.Click += new System.EventHandler(this.mnuFileBackgroundImage_Click);
            // 
            // mnuFileSaveAs
            // 
            this.mnuFileSaveAs.Name = "mnuFileSaveAs";
            this.mnuFileSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSaveAs.Size = new System.Drawing.Size(224, 22);
            this.mnuFileSaveAs.Text = "&Save As...";
            this.mnuFileSaveAs.Click += new System.EventHandler(this.mnuFileSaveAs_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(221, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(224, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // ofdImage
            // 
            this.ofdImage.DefaultExt = "png";
            this.ofdImage.Filter = "Picture Files|*.bmp;*.jpg;*.gif;*.png;*.tif|All Files|*.*";
            // 
            // sfdResult
            // 
            this.sfdResult.DefaultExt = "png";
            this.sfdResult.Filter = "Picture Files|*.bmp;*.jpg;*.gif;*.png;*.tif|All Files|*.*";
            // 
            // howto_images_on_polygon_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 364);
            this.Controls.Add(this.txtNumImages);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRadius);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFgWidth);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.picResult);
            this.Controls.Add(this.txtFgImage);
            this.Controls.Add(this.txtBgImage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_images_on_polygon_Form1";
            this.Text = "howto_images_on_polygon";
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBgImage;
        private System.Windows.Forms.TextBox txtFgImage;
        private System.Windows.Forms.PictureBox picResult;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtFgWidth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRadius;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNumImages;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileForegroundImage;
        private System.Windows.Forms.ToolStripMenuItem mnuFileBackgroundImage;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.OpenFileDialog ofdImage;
        private System.Windows.Forms.SaveFileDialog sfdResult;
    }
}

