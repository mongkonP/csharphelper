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
     public partial class howto_image_spiral_Form1:Form
  { 


        public howto_image_spiral_Form1()
        {
            InitializeComponent();
        }

        private Bitmap BaseImage = Properties.Resources.cat;
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
                txtWidth.Text = BgImage.Width.ToString();
                txtHeight.Text = BgImage.Height.ToString();
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

        // If we have a background and base image, make the spiral.
        private void MakeSpiral()
        {
            // Get the parameters.
            int width, height, num_spirals;
            float scale, A, B, dtheta;
            if (ParametersInvalid(out width, out height,
                out scale, out A, out B, out dtheta, out num_spirals)) return;

            // Size the result PictureBox and the form.
            picResult.ClientSize = new Size(width, height);
            int wid = Math.Min(panScroll.Left + picResult.Width + panScroll.Left, 800);
            int hgt = Math.Min(panScroll.Top + picResult.Width + panScroll.Left, 800);
            if (wid < ClientSize.Width) wid = ClientSize.Width;
            if (hgt < ClientSize.Height) hgt = ClientSize.Height;
            ClientSize = new Size(wid, hgt);

            // Make the result bitmap.
            Bitmap bm = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                if (BgImage != null)
                {
                    // Draw the background image.
                    using (Brush brush = new TextureBrush(BgImage))
                    {
                        gr.FillRectangle(brush, 0, 0, width, height);
                    }
                }
                else
                {
                    // Fill the background with the background color.
                    gr.Clear(BgColor);
                }

                // Draw the spiral.
                DrawImageSpiral(gr, BaseImage, width, height,
                    scale, A, B, dtheta, num_spirals);
            }

            // Display the result.
            picResult.Image = bm;
        }

        // Get the parameters. If any of the parameters is
        // missing or invalid, tell the user and return true.
        private bool ParametersInvalid(
            out int width, out int height,
            out float scale, out float A, out float B,
            out float dtheta, out int num_spirals)
        {
            width = 0;
            height = 0;
            scale = 0;
            A = 0;
            B = 0;
            num_spirals = 0;
            dtheta = 0;

            if (!int.TryParse(txtWidth.Text, out width) || (width <= 0))
            {
                MessageBox.Show("Please enter a width greater than zero.");
                txtWidth.Focus();
                return true;
            }

            if (!int.TryParse(txtHeight.Text, out height) || (height <= 0))
            {
                MessageBox.Show("Please enter a height greater than zero.");
                txtHeight.Focus();
                return true;
            }

            if (!float.TryParse(txtScale.Text, out scale) ||
                (Math.Abs(scale) <= 0.01))
            {
                MessageBox.Show("Please enter a non-zero scale.");
                txtScale.Focus();
                return true;
            }

            // Make sure we have a base image.
            if (BaseImage == null)
            {
                MessageBox.Show("Please select a base image.");
                return true;
            }

            // Get the spiral parameters.
            if (!float.TryParse(txtA.Text, out A))
            {
                MessageBox.Show("Please enter parameter A.");
                return true;
            }

            if (!float.TryParse(txtB.Text, out B))
            {
                MessageBox.Show("Please enter parameter B.");
                return true;
            }

            if (!float.TryParse(txtDtheta.Text, out dtheta))
            {
                MessageBox.Show("Please enter parameter DTheta.");
                return true;
            }
            // Convert from degrees to radians.
            dtheta *= (float)(Math.PI / 180);

            if (!int.TryParse(txtNumSpirals.Text, out num_spirals) || num_spirals <= 0)
            {
                MessageBox.Show("Please enter a number if spirals greater than zero.");
                return true;
            }

            return false;
        }

        // Draw the spiral of images.
        private void DrawImageSpiral(Graphics gr, Bitmap image,
            int width, int height, float scale, float A, float B,
            float dtheta, int num_spirals)
        {
            // Find the maximum distance to the rectangle's corners.
            PointF center = new PointF(width / 2, height / 2);
            float max_r = (float)Math.Sqrt(
                center.X * center.X + center.Y * center.Y) +
                BaseImage.Height;

            // Draw the spirals.
            float start_angle = 0;
            float d_start = (float)(2 * Math.PI / num_spirals);
            for (int i = 0; i < num_spirals; i++)
            {
                List<PointF> points =
                    GetSpiralPoints(center, A, B, start_angle, dtheta, max_r);

                foreach (PointF point in points)
                {
                    float dist = Distance(center, point);
                    float r = dist / 2;
                    DrawImageAt(gr, center, point, r, scale);
                }

                start_angle += d_start;
            }
        }

        private float Distance(PointF point1, PointF point2)
        {
            float dx = point1.X - point2.X;
            float dy = point1.Y - point2.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        // Draw the base image at the indicated point
        // appropriately scaled and rotated.
        private void DrawImageAt(Graphics gr, PointF center,
            PointF point, float r, float image_scale)
        {
            float dx = point.X - center.X;
            float dy = point.Y - center.Y;
            float angle = (float)(Math.Atan2(dy, dx) * 180 / Math.PI) + 90;
            float sx = r / BaseImage.Width * image_scale;
            float sy = r / BaseImage.Height * image_scale;
            float scale = Math.Min(sx, sy);
            GraphicsState state = gr.Save();
            gr.ResetTransform();
            gr.ScaleTransform(scale, scale);
            gr.RotateTransform(angle, MatrixOrder.Append);
            gr.TranslateTransform(point.X, point.Y, MatrixOrder.Append);

            PointF[] dest_points =
            {
                new PointF(-BaseImage.Width / 2, -BaseImage.Height / 2),
                new PointF(BaseImage.Width / 2, -BaseImage.Height / 2),
                new PointF(-BaseImage.Width / 2, BaseImage.Height / 2),
            };
            RectangleF src_rect = new RectangleF(0, 0, BaseImage.Width, BaseImage.Height);

            if (chkDarken.Checked)
            {
                float radius = Math.Min(center.X, center.Y) / 3f;
                float dark_scale = r / radius + 0.2f;
                if (dark_scale > 1) dark_scale = 1;
                Bitmap bm = AdjustBrightness(BaseImage, dark_scale);
                gr.DrawImage(bm, dest_points, src_rect, GraphicsUnit.Pixel);
            }
            else
            {
                gr.DrawImage(BaseImage, dest_points, src_rect, GraphicsUnit.Pixel);
            }

            gr.Restore(state);
        }


        // Return points that define a spiral.
        // See http://csharphelper.com/blog/2018/11/draw-a-logarithmic-spiral-in-c/
        private List<PointF> GetSpiralPoints(
            PointF center, float A, float B,
            float angle_offset, float dtheta, float max_r)
        {
            // Get the points.
            List<PointF> points = new List<PointF>();
            float min_theta = (float)(Math.Log(0.1 / A) / B);
            for (float theta = min_theta; ; theta += dtheta)
            {
                // Calculate r.
                float r = (float)(A * Math.Exp(B * theta));

                // Convert to Cartesian coordinates.
                float x, y;
                PolarToCartesian(r, theta + angle_offset, out x, out y);

                // Center.
                x += center.X;
                y += center.Y;

                // Create the point.
                points.Add(new PointF((float)x, (float)y));

                // If we have gone far enough, stop.
                if (r > max_r) break;
            }
            return points;
        }

        private void PolarToCartesian(float r, float theta, out float x, out float y)
        {
            x = (float)(r * Math.Cos(theta));
            y = (float)(r * Math.Sin(theta));
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
            MakeSpiral();
            Cursor = Cursors.Default;
        }

        // Adjust the image's brightness.
        // See http://csharphelper.com/blog/2014/10/use-an-imageattributes-object-to-adjust-an-images-brightness-in-c/
        private Bitmap AdjustBrightness(Image image, float brightness)
        {
            // Make the ColorMatrix.
            float b = brightness;
            ColorMatrix cm = new ColorMatrix(new float[][]
            {
                new float[] {b, 0, 0, 0, 0},
                new float[] {0, b, 0, 0, 0},
                new float[] {0, 0, b, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {0, 0, 0, 0, 1},
            });
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(cm);

            // Draw the image onto the new bitmap while applying
            // the new ColorMatrix.
            Point[] points =
            {
                new Point(0, 0),
                new Point(image.Width, 0),
                new Point(0, image.Height),
            };
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

            // Make the result bitmap.
            Bitmap bm = new Bitmap(image.Width, image.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawImage(image, points, rect,
                    GraphicsUnit.Pixel, attributes);
            }

            // Return the result.
            return bm;
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileBackgroundColor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileBackgroundImage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdImage = new System.Windows.Forms.OpenFileDialog();
            this.sfdImage = new System.Windows.Forms.SaveFileDialog();
            this.cdBackgroundColor = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumSpirals = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDraw = new System.Windows.Forms.Button();
            this.picResult = new System.Windows.Forms.PictureBox();
            this.txtScale = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panScroll = new System.Windows.Forms.Panel();
            this.chkDarken = new System.Windows.Forms.CheckBox();
            this.txtDtheta = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            this.panScroll.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(402, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
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
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(221, 22);
            this.mnuFileOpen.Text = "&Open...";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileBackgroundColor
            // 
            this.mnuFileBackgroundColor.Image = Properties.Resources.white;
            this.mnuFileBackgroundColor.Name = "mnuFileBackgroundColor";
            this.mnuFileBackgroundColor.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuFileBackgroundColor.Size = new System.Drawing.Size(221, 22);
            this.mnuFileBackgroundColor.Text = "Background &Color...";
            this.mnuFileBackgroundColor.Click += new System.EventHandler(this.mnuFileBackgroundColor_Click);
            // 
            // mnuFileBackgroundImage
            // 
            this.mnuFileBackgroundImage.Name = "mnuFileBackgroundImage";
            this.mnuFileBackgroundImage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.mnuFileBackgroundImage.Size = new System.Drawing.Size(221, 22);
            this.mnuFileBackgroundImage.Text = "Background &Image...";
            this.mnuFileBackgroundImage.Click += new System.EventHandler(this.mnuFileBackgroundImage_Click);
            // 
            // mnuFileSaveAs
            // 
            this.mnuFileSaveAs.Name = "mnuFileSaveAs";
            this.mnuFileSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSaveAs.Size = new System.Drawing.Size(221, 22);
            this.mnuFileSaveAs.Text = "&Save As,,,";
            this.mnuFileSaveAs.Click += new System.EventHandler(this.mnuFileSaveAs_Click);
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
            // ofdImage
            // 
            this.ofdImage.DefaultExt = "png";
            this.ofdImage.Filter = "Picture files|*.bmp;*.jpg;*.gif;*.png;*.tif|All FIles|*.*";
            // 
            // sfdImage
            // 
            this.sfdImage.DefaultExt = "png";
            this.sfdImage.Filter = "Picture files|*.bmp;*.jpg;*.gif;*.png;*.tif|All FIles|*.*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Width:";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(70, 27);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(50, 20);
            this.txtWidth.TabIndex = 0;
            this.txtWidth.Text = "200";
            this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(203, 27);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(50, 20);
            this.txtHeight.TabIndex = 1;
            this.txtHeight.Text = "200";
            this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Height:";
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(203, 53);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(50, 20);
            this.txtB.TabIndex = 4;
            this.txtB.Text = "0.2";
            this.txtB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "B:";
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(70, 53);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(50, 20);
            this.txtA.TabIndex = 3;
            this.txtA.Text = "5";
            this.txtA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "A:";
            // 
            // txtNumSpirals
            // 
            this.txtNumSpirals.Location = new System.Drawing.Point(70, 79);
            this.txtNumSpirals.Name = "txtNumSpirals";
            this.txtNumSpirals.Size = new System.Drawing.Size(50, 20);
            this.txtNumSpirals.TabIndex = 5;
            this.txtNumSpirals.Text = "2";
            this.txtNumSpirals.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "# Spirals:";
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(306, 76);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 8;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
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
            // txtScale
            // 
            this.txtScale.Location = new System.Drawing.Point(203, 79);
            this.txtScale.Name = "txtScale";
            this.txtScale.Size = new System.Drawing.Size(50, 20);
            this.txtScale.TabIndex = 6;
            this.txtScale.Text = "1";
            this.txtScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(156, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Scale:";
            // 
            // panScroll
            // 
            this.panScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panScroll.AutoScroll = true;
            this.panScroll.Controls.Add(this.picResult);
            this.panScroll.Location = new System.Drawing.Point(12, 105);
            this.panScroll.Name = "panScroll";
            this.panScroll.Size = new System.Drawing.Size(378, 218);
            this.panScroll.TabIndex = 15;
            // 
            // chkDarken
            // 
            this.chkDarken.AutoSize = true;
            this.chkDarken.Location = new System.Drawing.Point(312, 55);
            this.chkDarken.Name = "chkDarken";
            this.chkDarken.Size = new System.Drawing.Size(61, 17);
            this.chkDarken.TabIndex = 7;
            this.chkDarken.Text = "Darken";
            this.chkDarken.UseVisualStyleBackColor = true;
            // 
            // txtDtheta
            // 
            this.txtDtheta.Location = new System.Drawing.Point(341, 27);
            this.txtDtheta.Name = "txtDtheta";
            this.txtDtheta.Size = new System.Drawing.Size(50, 20);
            this.txtDtheta.TabIndex = 2;
            this.txtDtheta.Text = "30";
            this.txtDtheta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(289, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "DTheta:";
            // 
            // howto_image_spiral_Form1
            // 
            this.AcceptButton = this.btnDraw;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 335);
            this.Controls.Add(this.txtDtheta);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkDarken);
            this.Controls.Add(this.panScroll);
            this.Controls.Add(this.txtScale);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.txtNumSpirals);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_image_spiral_Form1";
            this.Text = "howto_image_spiral";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            this.panScroll.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem mnuFileBackgroundImage;
        private System.Windows.Forms.OpenFileDialog ofdImage;
        private System.Windows.Forms.SaveFileDialog sfdImage;
        private System.Windows.Forms.ToolStripMenuItem mnuFileBackgroundColor;
        private System.Windows.Forms.PictureBox picResult;
        private System.Windows.Forms.ColorDialog cdBackgroundColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumSpirals;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.TextBox txtScale;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panScroll;
        private System.Windows.Forms.CheckBox chkDarken;
        private System.Windows.Forms.TextBox txtDtheta;
        private System.Windows.Forms.Label label7;
    }
}

