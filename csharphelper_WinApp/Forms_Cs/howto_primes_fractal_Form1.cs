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
     public partial class howto_primes_fractal_Form1:Form
  { 


        public howto_primes_fractal_Form1()
        {
            InitializeComponent();
        }

        private const int Wid = 800;
        private const int Hgt = 800;
        private const int XOff = 150;
        private const int YOff = 200;
        private int[,] Hits = new int[Wid, Hgt];
        private Point CurrentPoint = new Point(0, 0);
        private long CurrentPrime = 1;

        // Start or stop.
        private bool Running = false;
        private void mnuFileStart_Click(object sender, EventArgs e)
        {
            if (mnuFileStart.Text == "&Start")
            {
                // Start.
                Running = true;
                mnuFileStart.Text = "&Stop";
                picFractal.Visible = true;

                DrawFractal();
                
                // Clean up after we finish running.
                mnuFileStart.Enabled = true;
                mnuFileStart.Text = "&Start";
            }
            else
            {
                // Stop.
                Running = false;
                mnuFileStart.Enabled = false;
            }
        }

        // Add points to the fractal.
        private int NumPoints = 0;
        private void DrawFractal()
        {
            const int points_per_loop = 10000;
            while (Running)
            {
                // Generate a bunch of points.
                for (int i = 0; i < points_per_loop; i++)
                {
                    // Find the next prime.
                    CurrentPrime = FindNextPrime(CurrentPrime);

                    // See which kind of prime it is.
                    switch (CurrentPrime % 5)
                    {
                        case 1:
                            CurrentPoint.Y--;
                            break;
                        case 2:
                            CurrentPoint.X++;
                            break;
                        case 3:
                            CurrentPoint.Y++;
                            break;
                        case 4:
                            CurrentPoint.X--;
                            break;
                    }

                    // Record the hit.
                    int ix = CurrentPoint.X + XOff;
                    int iy = CurrentPoint.Y + YOff;
                    if (ix >= 0 && iy >= 0 && ix < Wid && iy < Hgt)
                    {
                        Hits[ix, iy]++;
                    }
                }

                // Build the image.
                BuildImage();

                // Display the point count.
                NumPoints += points_per_loop;
                lblNumPoints.Text = NumPoints.ToString();
                lblPrime.Text = CurrentPrime.ToString();

                // Process button clicks if there were any.
                Application.DoEvents();
            }
        }

        // Find the next prime after this one.
        private long FindNextPrime(long value)
        {
            // Cheat a little for speed.
            //if (value == 1) return 2;
            //if (value == 2) return 3;
            for (long i = value + 2; ; i += 2)
            {
                if (IsPrime(i)) return i;
            }
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

        // Build and display the image.
        private void BuildImage()
        {
            Bitmap bm = new Bitmap(Wid, Hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                // Clear.
                gr.Clear(Color.Black);

                // Find the largest hit value.
                var max_query =
                    from int count in Hits
                    select count;
                float max = (float)max_query.Max();

                // Plot the hits.
                for (int x = 0; x < Wid; x++)
                    for (int y = 0; y < Hgt; y++)
                        if (Hits[x, y] > 0)
                            bm.SetPixel(x, y, MapRainbowColor(Hits[x, y], 1, max));

                // Draw the axes.
                gr.DrawLine(Pens.Blue, XOff, 0, XOff, Hgt);
                gr.DrawLine(Pens.Blue, 0, YOff, Wid, YOff);
            }

            // Display the result.
            picFractal.Image = bm;
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

        // Stop running.
        private void howto_primes_fractal_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Running = false;
        }

        // Save the file.
        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            if (sfdFractal.ShowDialog() == DialogResult.OK)
            {
                Bitmap bm = picFractal.Image as Bitmap;
                SaveImage(bm, sfdFractal.FileName);
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
            this.mnuFileStart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.lblNumPoints = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPrime = new System.Windows.Forms.Label();
            this.sfdFractal = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picFractal = new System.Windows.Forms.PictureBox();
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
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileStart,
            this.mnuFileSave});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuFileStart
            // 
            this.mnuFileStart.Name = "mnuFileStart";
            this.mnuFileStart.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuFileStart.Size = new System.Drawing.Size(163, 22);
            this.mnuFileStart.Text = "&Start";
            this.mnuFileStart.Click += new System.EventHandler(this.mnuFileStart_Click);
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSave.Size = new System.Drawing.Size(163, 22);
            this.mnuFileSave.Text = "Save &As...";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // lblNumPoints
            // 
            this.lblNumPoints.AutoSize = true;
            this.lblNumPoints.Location = new System.Drawing.Point(67, 24);
            this.lblNumPoints.Name = "lblNumPoints";
            this.lblNumPoints.Size = new System.Drawing.Size(0, 13);
            this.lblNumPoints.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "# Points:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Prime:";
            // 
            // lblPrime
            // 
            this.lblPrime.AutoSize = true;
            this.lblPrime.Location = new System.Drawing.Point(313, 25);
            this.lblPrime.Name = "lblPrime";
            this.lblPrime.Size = new System.Drawing.Size(0, 13);
            this.lblPrime.TabIndex = 5;
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
            this.panel1.Location = new System.Drawing.Point(12, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 511);
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
            // howto_primes_fractal_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 564);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPrime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNumPoints);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_primes_fractal_Form1";
            this.Text = "howto_primes_fractal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_primes_fractal_Form1_FormClosing);
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
        private System.Windows.Forms.ToolStripMenuItem mnuFileStart;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private System.Windows.Forms.Label lblNumPoints;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPrime;
        private System.Windows.Forms.SaveFileDialog sfdFractal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picFractal;

    }
}

