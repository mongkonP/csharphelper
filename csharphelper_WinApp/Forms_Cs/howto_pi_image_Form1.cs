//#define SHOW_GEOMETRY

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
     public partial class howto_pi_image_Form1:Form
  { 


        public howto_pi_image_Form1()
        {
            InitializeComponent();
        }

        // See:
        // 10 stunning images show the beauty hidden in pi
        // https://www.washingtonpost.com/news/wonk/wp/2015/03/14/10-stunning-images-show-the-beauty-hidden-in-pi

        // Note that this program's version of the file Pi.txt
        // contains 1 million digits and does not have the decimal point.
        // https://www.angio.net/pi/digits.html

        // The digits of pi.
        private int NumDigits;
        private int[] Digits;

        // The image.
        private Bitmap PiPicture = null;

        // Load the digits of pi.
        private void howto_pi_image_Form1_Load(object sender, EventArgs e)
        {
            int asc_0 = (int)'0';
            string pi = File.ReadAllText("Pi1million.txt");
            NumDigits = pi.Length;
            Digits = new int[NumDigits];
            for (int i = 0; i < NumDigits; i++)
            {
                Digits[i] = (int)pi[i] - asc_0;
            }
        }

        // Save the image.
        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (sfdSaveAs.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SaveImage(PiPicture, sfdSaveAs.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
        
        // Draw the image.
        private void btnDraw_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            PiPicture = DrawImage(picPi.ClientRectangle);
            picPi.Image = PiPicture;
            mnuFileSaveAs.Enabled = true;

            Cursor = Cursors.Default;
        }

        // Make a bitmap holding the Pi image.
        private Bitmap DrawImage(Rectangle rect)
        {
            // Point math.
            int wid = rect.Width;
            int hgt = rect.Height;
            double theta = -Math.PI / 2;
            const double dtheta = Math.PI / 5.0;
            float[] dx = new float[10];
            float[] dy = new float[10];
            const double move_distance = 10;
            for (int i = 0; i < 10; i++)
            {
                dx[i] = (float)(move_distance * Math.Cos(theta));
                dy[i] = (float)(move_distance * Math.Sin(theta));
                theta += dtheta;
            }

            // Get the number of points we will visit.
            int num_points = int.Parse(txtNumMoves.Text);
            if (num_points > NumDigits)
            {
                num_points = NumDigits;
                txtNumMoves.Text = num_points.ToString();
            }
            else if (num_points < 1)
            {
                num_points = 1;
                txtNumMoves.Text = num_points.ToString();
            }

            // Find the bounds.
            float x = 0;
            float y = 0;
            float wxmin = x;
            float wxmax = x;
            float wymin = y;
            float wymax = y;
            for (int i = 0; i < num_points; i++)
            {
                int digit = Digits[i];
                x += dx[digit];
                y += dy[digit];
                if (wxmin > x) wxmin = x;
                if (wxmax < x) wxmax = x;
                if (wymin > y) wymin = y;
                if (wymax < y) wymax = y;
            }

            // Draw the image.
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                // Scale to fit without distortion.
                // See "Map drawing coordinates without distortion in C#"
                // http://csharphelper.com/blog/2016/02/map-drawing-coordinates-without-distortion-in-c/
                RectangleF world_rect = new RectangleF(
                    wxmin, wymin, wxmax - wxmin, wymax - wymin);
                const float margin = 5;
                RectangleF device_rect = new RectangleF(
                    margin, margin, wid - 2 * margin, hgt - 2 * margin);
                SetTransformationWithoutDisortion(gr,
                    world_rect, device_rect, false, false);
                
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.Clear(Color.Black);

                using (Pen pen = new Pen(Color.White, 0))
                {
                    PointF last_point = new PointF(0, 0);
                    for (int i = 0; i < num_points; i++)
                    {
                        int digit = Digits[i];
                        PointF new_point = new PointF(
                            last_point.X + dx[digit],
                            last_point.Y + dy[digit]);
                        pen.Color = MapRainbowColor(i, 0, num_points);
                        gr.DrawLine(pen, last_point, new_point);

                        last_point = new_point;
                    }
                }

#if SHOW_GEOMETRY
                // Mark the data.
                // Get 2 pixels in world coordinates.
                Matrix inverse = gr.Transform;
                inverse.Invert();
                PointF[] pts = { new PointF(2, 0) };
                inverse.TransformVectors(pts);
                float thickness = pts[0].X;
                using (Pen pen = new Pen(Color.Yellow, thickness))
                {
                    // Draw a circle at the starting point.
                    float dist = thickness * 3;
                    gr.DrawEllipse(pen,
                        -dist / 2, -dist / 2, dist, dist);

                    // Outline the world coordinates.
                    pen.Color = Color.Yellow;
                    gr.DrawRectangle(pen, wxmin, wymin,
                        wxmax - wxmin, wymax - wymin);
                }
#endif
            }
            return bm;
        }

        // Map a value to a rainbow color.
        private Color MapRainbowColor(
            float value, float red_value, float blue_value)
        {
            // Convert into a value between 0 and 1023.
            int int_value = (int)(1023 * (value - red_value) /
                (blue_value - red_value));

            // Map different color bands.
            if (int_value < 256)
            {
                // Red to yellow. (255, 0, 0) to (255, 255, 0).
                return Color.FromArgb(255, int_value, 0);
            }
            else if (int_value < 512)
            {
                // Yellow to green. (255, 255, 0) to (0, 255, 0).
                int_value -= 256;
                return Color.FromArgb(255 - int_value, 255, 0);
            }
            else if (int_value < 768)
            {
                // Green to aqua. (0, 255, 0) to (0, 255, 255).
                int_value -= 512;
                return Color.FromArgb(0, 255, int_value);
            }
            else
            {
                // Aqua to blue. (0, 255, 255) to (0, 0, 255).
                int_value -= 768;
                return Color.FromArgb(0, 255 - int_value, 255);
            }
        }

        // Map from world coordinates to device coordinates
        // without distortion.
        private void SetTransformationWithoutDisortion(Graphics gr,
            RectangleF world_rect, RectangleF device_rect,
            bool invert_x, bool invert_y)
        {
            // Get the aspect ratios.
            float world_aspect = world_rect.Width / world_rect.Height;
            float device_aspect = device_rect.Width / device_rect.Height;

            // Asjust the world rectangle to maintain the aspect ratio.
            float world_cx = world_rect.X + world_rect.Width / 2f;
            float world_cy = world_rect.Y + world_rect.Height / 2f;
            if (world_aspect > device_aspect)
            {
                // The world coordinates are too short and width.
                // Make them taller.
                float world_height = world_rect.Width / device_aspect;
                world_rect = new RectangleF(
                    world_rect.Left,
                    world_cy - world_height / 2f,
                    world_rect.Width,
                    world_height);
            }
            else
            {
                // The world coordinates are too tall and thin.
                // Make them wider.
                float world_width = device_aspect * world_rect.Height;
                world_rect = new RectangleF(
                    world_cx - world_width / 2f,
                    world_rect.Top,
                    world_width,
                    world_rect.Height);
            }

            // Map the new world coordinates into the device coordinates.
            SetTransformation(gr, world_rect, device_rect,
                invert_x, invert_y);
        }

        // Map from world coordinates to device coordinates.
        private void SetTransformation(Graphics gr,
            RectangleF world_rect, RectangleF device_rect,
            bool invert_x, bool invert_y)
        {
            PointF[] device_points =
            {
                new PointF(device_rect.Left, device_rect.Top),      // Upper left.
                new PointF(device_rect.Right, device_rect.Top),     // Upper right.
                new PointF(device_rect.Left, device_rect.Bottom),   // Lower left.
            };

            if (invert_x)
            {
                device_points[0].X = device_rect.Right;
                device_points[1].X = device_rect.Left;
                device_points[2].X = device_rect.Right;
            }
            if (invert_y)
            {
                device_points[0].Y = device_rect.Bottom;
                device_points[1].Y = device_rect.Bottom;
                device_points[2].Y = device_rect.Top;
            }

            gr.Transform = new Matrix(world_rect, device_points);
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
            this.btnDraw = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdSaveAs = new System.Windows.Forms.SaveFileDialog();
            this.picPi = new System.Windows.Forms.PictureBox();
            this.txtNumMoves = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPi)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDraw
            // 
            this.btnDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDraw.Location = new System.Drawing.Point(305, 27);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 1;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(384, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileSaveAs});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
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
            // sfdSaveAs
            // 
            this.sfdSaveAs.DefaultExt = "png";
            this.sfdSaveAs.Filter = "Picture files|*.bmp;*.jpg;*.gif;*.png;*.tif|All Files|*.*";
            // 
            // picPi
            // 
            this.picPi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picPi.BackColor = System.Drawing.Color.Black;
            this.picPi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPi.Location = new System.Drawing.Point(2, 56);
            this.picPi.Name = "picPi";
            this.picPi.Size = new System.Drawing.Size(380, 380);
            this.picPi.TabIndex = 2;
            this.picPi.TabStop = false;
            // 
            // txtNumMoves
            // 
            this.txtNumMoves.Location = new System.Drawing.Point(67, 29);
            this.txtNumMoves.Name = "txtNumMoves";
            this.txtNumMoves.Size = new System.Drawing.Size(54, 20);
            this.txtNumMoves.TabIndex = 0;
            this.txtNumMoves.Text = "10000";
            this.txtNumMoves.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "# Points:";
            // 
            // howto_pi_image_Form1
            // 
            this.AcceptButton = this.btnDraw;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 438);
            this.Controls.Add(this.txtNumMoves);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picPi);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_pi_image_Form1";
            this.Text = "howto_pi_image";
            this.Load += new System.EventHandler(this.howto_pi_image_Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        private System.Windows.Forms.SaveFileDialog sfdSaveAs;
        private System.Windows.Forms.PictureBox picPi;
        private System.Windows.Forms.TextBox txtNumMoves;
        private System.Windows.Forms.Label label2;
    }
}

