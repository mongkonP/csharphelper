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
     public partial class howto_primes_fractal3_Form1:Form
  { 


        public howto_primes_fractal3_Form1()
        {
            InitializeComponent();
        }

        // Draw the fractal.
        private void btnDraw_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Refresh();

            // Generate the points.
            int num_points = int.Parse(txtNumPoints.Text);
            Point[] points = new Point[num_points];
            Dictionary<Point, int> hits = new Dictionary<Point, int>();
            Point current_point = new Point(0, 0);
            int prime = 7;
            for (long i = 0; i < num_points; i++)
            {
                // Find the next prime.
                while (!IsPrime(prime)) prime += 2;

                // Use this prime.
                switch (prime % 5)
                {
                    case 1:
                        current_point.Y--;
                        break;
                    case 2:
                        current_point.X++;
                        break;
                    case 3:
                        current_point.Y++;
                        break;
                    case 4:
                        current_point.X--;
                        break;
                }
                points[i] = current_point;
                int count = 0;
                if (hits.ContainsKey(current_point))
                    count = hits[current_point];
                hits[current_point] = count + 1;

                // Move to the next possible prime.
                prime += 2;
            }

            // Draw the points.
            const int width = 500;
            Bitmap bm = new Bitmap(width, width);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(Color.Black);

                // Get the largest and smallest coordinates.
                var x_query =
                    from Point point in points
                    select point.X;
                int[] xs = x_query.ToArray();
                int xmin = xs.Min();
                int xmax = xs.Max();
                int wid = xmax - xmin;

                var y_query =
                    from Point point in points
                    select point.Y;
                int[] ys = y_query.ToArray();
                int ymin = ys.Min();
                int ymax = ys.Max();
                int hgt = ymax - ymin;

                float scale = width / Math.Max(wid, hgt);

                // Get the largest hit count.
                int max_hit = hits.Values.ToArray().Max();

                // Scale and translate.
                gr.TranslateTransform(-xmin, -ymin);
                gr.ScaleTransform(scale, scale, MatrixOrder.Append);

                using (Pen thin_pen = new Pen(Color.Black, 0))
                {
                    // Draw the lines.
                    for (int i = 1; i < num_points; i++)
                    {
                        // Set the pen color.
                        thin_pen.Color = MapRainbowColor(hits[points[i]], 1, max_hit);
                        gr.DrawLine(thin_pen, points[i - 1], points[i]);
                    }

                    // Draw the axes.
                    thin_pen.Color = Color.Blue;
                    gr.DrawLine(thin_pen, xmin, 0, xmax, 0);
                    gr.DrawLine(thin_pen, 0, ymin, 0, ymax);
                }
            }
            picFractal.Image = bm;
            picFractal.Visible = true;

            Cursor = Cursors.Default;
        }

        // Return true if the value is prime.
        // For speed, asssume value > 2 and value is odd.
        private bool IsPrime(long value)
        {
            long stop_at = (long)Math.Sqrt(value);
            for (long factor = 3; factor <= stop_at; factor += 2)
            {
                if (value % factor == 0) return false;
            }
            return true;
        }

        // Save the file.
        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            if (sfdFractal.ShowDialog() == DialogResult.OK)
            {
                SaveImage(picFractal.Image, sfdFractal.FileName);
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

        // Map a value to a rainbow color.
        private Color MapRainbowColor(float value, float red_value, float blue_value)
        {
            // Convert into a value between 0 and 1023.
            int int_value = (int)(1023 * (value - red_value) / (blue_value - red_value));

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
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.sfdFractal = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picFractal = new System.Windows.Forms.PictureBox();
            this.txtNumPoints = new System.Windows.Forms.TextBox();
            this.btnDraw = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFractal)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(534, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileSave});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSave.Size = new System.Drawing.Size(163, 22);
            this.mnuFileSave.Text = "Save &As...";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "# Points:";
            // 
            // sfdFractal
            // 
            this.sfdFractal.Filter = "Graphics Files|*.bmp;*.jpg;*.gif;*.png|All Files|*.*";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.picFractal);
            this.panel1.Location = new System.Drawing.Point(12, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 512);
            this.panel1.TabIndex = 0;
            // 
            // picFractal
            // 
            this.picFractal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picFractal.Location = new System.Drawing.Point(0, 0);
            this.picFractal.Name = "picFractal";
            this.picFractal.Size = new System.Drawing.Size(100, 100);
            this.picFractal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picFractal.TabIndex = 0;
            this.picFractal.TabStop = false;
            this.picFractal.Visible = false;
            // 
            // txtNumPoints
            // 
            this.txtNumPoints.Location = new System.Drawing.Point(67, 29);
            this.txtNumPoints.Name = "txtNumPoints";
            this.txtNumPoints.Size = new System.Drawing.Size(68, 20);
            this.txtNumPoints.TabIndex = 1;
            this.txtNumPoints.Text = "10000";
            this.txtNumPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(153, 27);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 8;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // howto_primes_fractal3_Form1
            // 
            this.AcceptButton = this.btnDraw;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 591);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.txtNumPoints);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_primes_fractal3_Form1";
            this.Text = "howto_primes_fractal3";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFractal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog sfdFractal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picFractal;
        private System.Windows.Forms.TextBox txtNumPoints;
        private System.Windows.Forms.Button btnDraw;

    }
}

