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
using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_image_circle_Form1:Form
  { 


        public howto_image_circle_Form1()
        {
            InitializeComponent();
        }

        private Bitmap BaseImage = Properties.Resources.cake;
        private Bitmap BgImage = null;
        private Color BgColor = Color.White;

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                BaseImage = LoadBitmapUnlocked(ofdImage.FileName);
            }
        }

        private void mnuFileBackgroundColor_Click(object sender, EventArgs e)
        {
            cdBackgroundColor.Color = BgColor;
            if (cdBackgroundColor.ShowDialog() == DialogResult.OK)
            {
                BgColor = cdBackgroundColor.Color;
                Bitmap bm = new Bitmap(16, 16);
                using (Graphics gr = Graphics.FromImage(bm))
                {
                    gr.Clear(BgColor);
                    gr.DrawRectangle(Pens.Black, 0, 0, 15, 15);
                }
                mnuFileBackgroundColor.Image = bm;
                BgImage = null;
            }
        }

        private void mnuFileBackgroundImage_Click(object sender, EventArgs e)
        {
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                BgImage = LoadBitmapUnlocked(ofdImage.FileName);
                txtPicWidth.Text = BgImage.Width.ToString();
                txtPicHeight.Text = BgImage.Height.ToString();
            }
        }

        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (sfdImage.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SaveImage(picResult.Image, sfdImage.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // If we have a background and base image, make the circle.
        private void MakeCircle()
        {
            // Get the parameters.
            int pic_width, pic_height, img_width, img_height, num_images;
            double offset_multiple, initial_rotation, radius;
            if (ParametersInvalid(
                out pic_width, out pic_height,
                out img_width, out img_height,
                out offset_multiple, out initial_rotation,
                out num_images, out radius))
                    return;

            // Size the result PictureBox and the form.
            picResult.ClientSize = new Size(pic_width, pic_height);
            int wid = Math.Min(panScroll.Left + picResult.Width + panScroll.Left, 800);
            int hgt = Math.Min(panScroll.Top + picResult.Width + panScroll.Left, 800);
            if (wid < ClientSize.Width) wid = ClientSize.Width;
            if (hgt < ClientSize.Height) hgt = ClientSize.Height;
            ClientSize = new Size(wid, hgt);

            // Make the result bitmap.
            Bitmap bm = new Bitmap(pic_width, pic_height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.InterpolationMode = InterpolationMode.High;
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                if (BgImage != null)
                {
                    // Draw the background image.
                    using (Brush brush = new TextureBrush(BgImage))
                    {
                        gr.FillRectangle(brush, 0, 0, pic_width, pic_height);
                    }
                }
                else
                {
                    // Fill the background with the background color.
                    gr.Clear(BgColor);
                }

                // Draw the circle.
                DrawImageCircle(gr, BaseImage,
                    pic_width, pic_height,
                    img_width, img_height,
                    offset_multiple, initial_rotation,
                    num_images, radius);
            }

            // Display the result.
            picResult.Image = bm;
        }

        // Get the parameters. If any of the parameters is
        // missing or invalid, tell the user and return true.
        private bool ParametersInvalid(
            out int pic_width, out int pic_height,
            out int img_width, out int img_height,
            out double theta_offset, out double initial_rotation,
            out int num_images, out double radius)
        {
            pic_width = 0;
            pic_height = 0;
            img_width = 0;
            img_height = 0;
            theta_offset = 0;
            initial_rotation = 0;
            num_images = 6;
            radius = 100;

            if (!int.TryParse(txtPicWidth.Text, out pic_width) || (pic_width <= 0))
            {
                MessageBox.Show("Picture width must be greater than zero.");
                txtPicWidth.Focus();
                return true;
            }
            if (!int.TryParse(txtPicHeight.Text, out pic_height) || (pic_height <= 0))
            {
                MessageBox.Show("Picture width must be greater than zero.");
                txtPicHeight.Focus();
                return true;
            }
            if (!int.TryParse(txtImgWidth.Text, out img_width) || (img_width <= 0))
            {
                MessageBox.Show("Image width must be greater than zero.");
                txtImgWidth.Focus();
                return true;
            }
            if (!int.TryParse(txtImgHeight.Text, out img_height) || (img_height <= 0))
            {
                MessageBox.Show("Image width must be greater than zero.");
                txtImgHeight.Focus();
                return true;
            }
            if (!double.TryParse(txtOffsetMultiple.Text, out theta_offset))
            {
                MessageBox.Show("Theta offset must be a number.");
                txtOffsetMultiple.Focus();
                return true;
            }
            if (!double.TryParse(txtInitialRotation.Text, out initial_rotation))
            {
                MessageBox.Show("Initial rotation must be a number.");
                txtInitialRotation.Focus();
                return true;
            }
            if (!int.TryParse(txtNumImages.Text, out num_images) || (num_images < 1))
            {
                MessageBox.Show("Number of images must be at least one.");
                txtNumImages.Focus();
                return true;
            }
            if (!double.TryParse(txtRadius.Text, out radius) || (radius < 0))
            {
                MessageBox.Show("Radius must be at least zero.");
                txtNumImages.Focus();
                return true;
            }

            return false;
        }

        // Draw the circle of images.
        private void DrawImageCircle(Graphics gr,
            Bitmap image,
            int pic_width, int pic_height,
            int img_width, int img_height,
            double offset_multiple,
            double initial_rotation,
            int num_images, double radius)
        {
            GraphicsState state = gr.Save();

            // Get the picture's center.
            float cx = pic_width / 2f;
            float cy = pic_height / 2f;

            // Adjust the image size to preserve aspect ratio.
            double scale_x = (double)img_width / image.Width;
            double scale_y = (double)img_width / image.Height;
            double scale = Math.Min(scale_x, scale_y);
            img_width = (int)(image.Width * scale);
            img_height = (int)(image.Height * scale);

            // Get the image's source rectangle.
            RectangleF src_rect = new RectangleF(
                0, 0, image.Width, image.Height);

            // Make destination points to center the image at the origin.
            PointF[] dest_points =
            {
                new PointF(-img_width / 2f, -img_height / 2f),
                new PointF( img_width / 2f, -img_height / 2f),
                new PointF(-img_width / 2f,  img_height / 2f),
            };

            // Loop through the images.
            double dtheta = 360 / num_images;
            double theta = dtheta * offset_multiple;
            double angle = initial_rotation + theta;
            for (int i = 0; i < num_images; i++)
            {
                // Get the point where the image's center should be drawn.
                double x = cx + radius * Math.Cos(theta * Math.PI / 180);
                double y = cy + radius * Math.Sin(theta * Math.PI / 180);
                PointF point = new PointF((float)x,(float)y);

                // Rotate and then translate to (x, y).
                gr.ResetTransform();
                gr.RotateTransform((float)angle);
                gr.TranslateTransform((float)x, (float)y, MatrixOrder.Append);

                // Draw the image.
                gr.DrawImage(image, dest_points, src_rect, GraphicsUnit.Pixel);

                theta += dtheta;
                angle += dtheta;
            }

            gr.Restore(state);
        }

        // Load a bitmap without locking it.
        private Bitmap LoadBitmapUnlocked(string file_name)
        {
            try
            {
                using (Bitmap bm = new Bitmap(file_name))
                {
                    return new Bitmap(bm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        // Save the file with the appropriate format.
        public void SaveImage(Image image, string filename)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            MakeCircle();
            Cursor = Cursors.Default;
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
            this.txtNumImages = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panScroll = new System.Windows.Forms.Panel();
            this.picResult = new System.Windows.Forms.PictureBox();
            this.btnDraw = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPicHeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileBackgroundImage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileBackgroundColor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.txtPicWidth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cdBackgroundColor = new System.Windows.Forms.ColorDialog();
            this.sfdImage = new System.Windows.Forms.SaveFileDialog();
            this.ofdImage = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label8 = new System.Windows.Forms.Label();
            this.txtImgHeight = new System.Windows.Forms.TextBox();
            this.txtImgWidth = new System.Windows.Forms.TextBox();
            this.txtOffsetMultiple = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtInitialRotation = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRadius = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panScroll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNumImages
            // 
            this.txtNumImages.Location = new System.Drawing.Point(428, 49);
            this.txtNumImages.Name = "txtNumImages";
            this.txtNumImages.Size = new System.Drawing.Size(50, 20);
            this.txtNumImages.TabIndex = 21;
            this.txtNumImages.Text = "10";
            this.txtNumImages.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(368, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "# Images:";
            // 
            // panScroll
            // 
            this.panScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panScroll.AutoScroll = true;
            this.panScroll.Controls.Add(this.picResult);
            this.panScroll.Location = new System.Drawing.Point(12, 130);
            this.panScroll.Name = "panScroll";
            this.panScroll.Size = new System.Drawing.Size(466, 309);
            this.panScroll.TabIndex = 34;
            // 
            // picResult
            // 
            this.picResult.BackColor = System.Drawing.Color.White;
            this.picResult.Location = new System.Drawing.Point(0, 0);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(200, 200);
            this.picResult.TabIndex = 1;
            this.picResult.TabStop = false;
            // 
            // btnDraw
            // 
            this.btnDraw.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDraw.Location = new System.Drawing.Point(246, 101);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 30;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Picture:";
            // 
            // txtPicHeight
            // 
            this.txtPicHeight.Location = new System.Drawing.Point(117, 49);
            this.txtPicHeight.Name = "txtPicHeight";
            this.txtPicHeight.Size = new System.Drawing.Size(50, 20);
            this.txtPicHeight.TabIndex = 20;
            this.txtPicHeight.Text = "400";
            this.txtPicHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(114, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Height";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mnuFileSaveAs
            // 
            this.mnuFileSaveAs.Name = "mnuFileSaveAs";
            this.mnuFileSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSaveAs.Size = new System.Drawing.Size(221, 22);
            this.mnuFileSaveAs.Text = "&Save As,,,";
            this.mnuFileSaveAs.Click += new System.EventHandler(this.mnuFileSaveAs_Click);
            // 
            // mnuFileBackgroundImage
            // 
            this.mnuFileBackgroundImage.Name = "mnuFileBackgroundImage";
            this.mnuFileBackgroundImage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.mnuFileBackgroundImage.Size = new System.Drawing.Size(221, 22);
            this.mnuFileBackgroundImage.Text = "Background &Image...";
            this.mnuFileBackgroundImage.Click += new System.EventHandler(this.mnuFileBackgroundImage_Click);
            // 
            // mnuFileBackgroundColor
            // 
            this.mnuFileBackgroundColor.Name = "mnuFileBackgroundColor";
            this.mnuFileBackgroundColor.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuFileBackgroundColor.Size = new System.Drawing.Size(221, 22);
            this.mnuFileBackgroundColor.Text = "Background &Color...";
            this.mnuFileBackgroundColor.Click += new System.EventHandler(this.mnuFileBackgroundColor_Click);
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(221, 22);
            this.mnuFileOpen.Text = "&Open...";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.mnuFileBackgroundColor,
            this.mnuFileBackgroundImage,
            this.mnuFileSaveAs,
            this.toolStripMenuItem1,
            this.mnuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(218, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(221, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // txtPicWidth
            // 
            this.txtPicWidth.Location = new System.Drawing.Point(61, 49);
            this.txtPicWidth.Name = "txtPicWidth";
            this.txtPicWidth.Size = new System.Drawing.Size(50, 20);
            this.txtPicWidth.TabIndex = 18;
            this.txtPicWidth.Text = "400";
            this.txtPicWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(61, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Width";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sfdImage
            // 
            this.sfdImage.DefaultExt = "png";
            this.sfdImage.Filter = "Picture files|*.bmp;*.jpg;*.gif;*.png;*.tif|All FIles|*.*";
            // 
            // ofdImage
            // 
            this.ofdImage.DefaultExt = "png";
            this.ofdImage.Filter = "Picture files|*.bmp;*.jpg;*.gif;*.png;*.tif|All FIles|*.*";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(490, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Image:";
            // 
            // txtImgHeight
            // 
            this.txtImgHeight.Location = new System.Drawing.Point(117, 75);
            this.txtImgHeight.Name = "txtImgHeight";
            this.txtImgHeight.Size = new System.Drawing.Size(50, 20);
            this.txtImgHeight.TabIndex = 38;
            this.txtImgHeight.Text = "50";
            this.txtImgHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtImgWidth
            // 
            this.txtImgWidth.Location = new System.Drawing.Point(61, 75);
            this.txtImgWidth.Name = "txtImgWidth";
            this.txtImgWidth.Size = new System.Drawing.Size(50, 20);
            this.txtImgWidth.TabIndex = 37;
            this.txtImgWidth.Text = "50";
            this.txtImgWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtOffsetMultiple
            // 
            this.txtOffsetMultiple.Location = new System.Drawing.Point(283, 49);
            this.txtOffsetMultiple.Name = "txtOffsetMultiple";
            this.txtOffsetMultiple.Size = new System.Drawing.Size(50, 20);
            this.txtOffsetMultiple.TabIndex = 39;
            this.txtOffsetMultiple.Text = "0";
            this.txtOffsetMultiple.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(200, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 40;
            this.label9.Text = "Offset Multiple:";
            // 
            // txtInitialRotation
            // 
            this.txtInitialRotation.Location = new System.Drawing.Point(283, 75);
            this.txtInitialRotation.Name = "txtInitialRotation";
            this.txtInitialRotation.Size = new System.Drawing.Size(50, 20);
            this.txtInitialRotation.TabIndex = 41;
            this.txtInitialRotation.Text = "90";
            this.txtInitialRotation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(200, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 42;
            this.label10.Text = "Initial Rotation:";
            // 
            // txtRadius
            // 
            this.txtRadius.Location = new System.Drawing.Point(428, 75);
            this.txtRadius.Name = "txtRadius";
            this.txtRadius.Size = new System.Drawing.Size(50, 20);
            this.txtRadius.TabIndex = 43;
            this.txtRadius.Text = "100";
            this.txtRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(368, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Radius:";
            // 
            // howto_image_circle_Form1
            // 
            this.AcceptButton = this.btnDraw;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 445);
            this.Controls.Add(this.txtRadius);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInitialRotation);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtOffsetMultiple);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtImgHeight);
            this.Controls.Add(this.txtImgWidth);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNumImages);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panScroll);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPicHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPicWidth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "howto_image_circle_Form1";
            this.Text = "howto_image_circle";
            this.panScroll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumImages;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panScroll;
        private System.Windows.Forms.PictureBox picResult;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPicHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        private System.Windows.Forms.ToolStripMenuItem mnuFileBackgroundImage;
        private System.Windows.Forms.ToolStripMenuItem mnuFileBackgroundColor;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.TextBox txtPicWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog cdBackgroundColor;
        private System.Windows.Forms.SaveFileDialog sfdImage;
        private System.Windows.Forms.OpenFileDialog ofdImage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtImgHeight;
        private System.Windows.Forms.TextBox txtImgWidth;
        private System.Windows.Forms.TextBox txtOffsetMultiple;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtInitialRotation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRadius;
        private System.Windows.Forms.Label label3;
    }
}

