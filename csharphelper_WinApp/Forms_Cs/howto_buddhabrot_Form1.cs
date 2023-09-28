using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Imaging;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_buddhabrot_Form1:Form
  { 


        public howto_buddhabrot_Form1()
        {
            InitializeComponent();
        }

        private const double Wxmin = -1.5;
        private const double Wxmax = 1.5;
        private const double Wymin = -1.5;
        private const double Wymax = 1.5;

        private Bitmap BrotBitmap = null;
        private bool IsDrawing = false;
        private Random Rand = new Random();

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            if (sfdBrot.ShowDialog() == DialogResult.OK)
            {
                string file_name = sfdBrot.FileName;
                if (!file_name.Contains(".")) file_name += ".bmp";
                string ext = file_name.Substring(file_name.LastIndexOf(".")).ToLower();

                switch (ext)
                {
                    case ".bmp":
                        BrotBitmap.Save(file_name, ImageFormat.Bmp);
                        break;
                    case ".bmgif":
                        BrotBitmap.Save(file_name, ImageFormat.Gif);
                        break;
                    case ".jpg":
                    case ".jpeg":
                        BrotBitmap.Save(file_name, ImageFormat.Jpeg);
                        break;
                    case ".png":
                        BrotBitmap.Save(file_name, ImageFormat.Png);
                        break;
                    case ".tif":
                    case ".tiff":
                        BrotBitmap.Save(file_name, ImageFormat.Tiff);
                        break;
                    default:
                        MessageBox.Show("Unknown file type " + ext);
                        break;
                }
            }
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (btnDraw.Text == "Draw")
            {
                btnDraw.Text = "Stop";
                DrawBrot();
            }

            IsDrawing = false;
            btnDraw.Text = "Draw";
        }

        // Draw the Buddhabrot until stopped or
        // we plot the desired number of points.
        private void DrawBrot()
        {
            // Get parameters.
            int wid = int.Parse(txtWidth.Text);
            int hgt = int.Parse(txtHeight.Text);
            int cut_r = int.Parse(txtRedCutoff.Text);
            int cut_g = int.Parse(txtGreenCutoff.Text);
            int cut_b = int.Parse(txtBlueCutoff.Text);
            int stop_after = int.Parse(txtStopAfter.Text);
            int draw_every = int.Parse(txtDrawEvery.Text);

            if ((wid <= 0) || (hgt <= 0))
            {
                MessageBox.Show("Invalid parameter", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Make hit count arrays.
            int[,] hit_r = new int[wid, hgt];
            int[,] hit_g = new int[wid, hgt];
            int[,] hit_b = new int[wid, hgt];

            // Make the bitmap.
            BrotBitmap = new Bitmap(wid, hgt);
            picCanvas.Image = BrotBitmap;
            this.ClientSize = new Size(
                picCanvas.Left + picCanvas.Width + 8,
                System.Math.Max(
                    btnDraw.Top + btnDraw.Height,
                    picCanvas.Top + picCanvas.Height) + 8);
            mnuFileSave.Enabled = true;

            // Start drawing.
            DateTime start_time = DateTime.Now;
            DateTime stop_time;
            TimeSpan elapsed;
            IsDrawing = true;

            // Build the hit counts.
            double dx = (Wxmax - Wxmin) / hgt;
            double dy = (Wymax - Wymin) / wid;
            int max_r = 0, max_g = 0, max_b = 0, hits = 0, total_hits = 0;

            while (total_hits < stop_after)
            {
                double cx = Wxmin + Rand.NextDouble() * (Wxmax - Wxmin);
                double cy = Wymin + Rand.NextDouble() * (Wymax - Wymin);
                double dd = cx * cx + cy * cy;
                if (dd < 1)
                {
                    DrawPoint(cx, cy, wid, hgt, dx, dy,
                        ref max_r, hit_r, cut_r, ref hits);
                }
                else if (dd < 2)
                {
                    DrawPoint(cx, cy, wid, hgt, dx, dy,
                        ref max_g, hit_g, cut_g, ref hits);
                }
                else
                {
                    DrawPoint(cx, cy, wid, hgt, dx, dy,
                        ref max_b, hit_b, cut_b, ref hits);
                }

                if (hits >= draw_every)
                {
                    total_hits += hits;
                    hits = 0;
                    DisplayBrot(wid, hgt, max_r, max_g, max_b, hit_r, hit_g, hit_b);

                    stop_time = DateTime.Now;
                    elapsed = stop_time.Subtract(start_time);
                    this.Text = elapsed.TotalSeconds.ToString("0.00") +
                        " sec, " + total_hits.ToString() + " hits";

                    Application.DoEvents();
                    if (!IsDrawing) break;
                }
            }
        }

        // Plot one point.
        private void DrawPoint(double cx, double cy, int wid, int hgt, double dx, double dy, ref int max_hits, int[,] hits, int cutoff, ref int num_hits)
        {
            const double ESCAPING = 4;

            // Zet Z0.
            double x, xx, y, yy;
            x = cx;
            y = cy;
            xx = x * x;
            yy = y * y;

            // Iterate.
            for (int i = 1; i <= cutoff; i++)
            {
                y = 2 * x * y + cy;
                x = xx - yy + cx;
                xx = x * x;
                yy = y * y;
                if (xx + yy >= ESCAPING) break;
            }

            // See if we escaped.
            if (xx + yy >= ESCAPING)
            {
                // Plot.
                x = cx;
                y = cy;
                xx = x * x;
                yy = y * y;

                // Iterate.
                for (int i = 1; i <= cutoff; i++)
                {
                    int ix = (int)Math.Round((x - Wxmin) / dx);
                    int iy = (int)Math.Round((y - Wymin) / dy);
                    if ((ix >= 0) && (ix < hgt) && (iy >= 0) && (iy < wid))
                    {
                        hits[iy, ix] += 1;
                        if (max_hits < hits[iy, ix]) max_hits = hits[iy, ix];
                    }
                    else
                    {
                        break;
                    }

                    y = 2 * x * y + cy;
                    x = xx - yy + cx;
                    xx = x * x;
                    yy = y * y;
                    if (xx + yy >= ESCAPING) break;
                }

                num_hits += 1;
            }
        }

        // Draw the current image.
        private void DisplayBrot(int wid, int hgt, int max_r, int max_g, int max_b, int[,] hit_r, int[,] hit_g, int[,] hit_b)
        {
            using (Graphics gr = Graphics.FromImage(BrotBitmap))
            {
                gr.Clear(Color.Black);
            }

            double scale_r = 255 * 2.5 / max_r;
            double scale_g = 255 * 2.5 / max_g;
            double scale_b = 255 * 2.5 / max_b;

            for (int y = 0; y < hgt; y++)
            {
                for (int x = 0; x < wid; x++)
                {
                    int r = (int)Math.Round(hit_r[x, y] * scale_r);
                    if (r > 255) r = 255;
                    int g = (int)Math.Round(hit_g[x, y] * scale_g);
                    if (g > 255) g = 255;
                    int b = (int)Math.Round(hit_b[x, y] * scale_b);
                    if (b > 255) b = 255;

                    BrotBitmap.SetPixel(x, y, Color.FromArgb(255, r, g, b));
                }
            }

            picCanvas.Refresh();
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
            this.MainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.MenuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuFileSave = new System.Windows.Forms.MenuItem();
            this.sfdBrot = new System.Windows.Forms.SaveFileDialog();
            this.txtDrawEvery = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtStopAfter = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.btnDraw = new System.Windows.Forms.Button();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.txtBlueCutoff = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtGreenCutoff = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtRedCutoff = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu1
            // 
            this.MainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem1});
            // 
            // MenuItem1
            // 
            this.MenuItem1.Index = 0;
            this.MenuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFileSave});
            this.MenuItem1.Text = "&File";
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Enabled = false;
            this.mnuFileSave.Index = 0;
            this.mnuFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.mnuFileSave.Text = "&Save...";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // sfdBrot
            // 
            this.sfdBrot.Filter = "Bitmaps|*.bmp|JPEGs|*.jpeg;*.jpg|GIFs|*.gif|All Files|*.*";
            // 
            // txtDrawEvery
            // 
            this.txtDrawEvery.Location = new System.Drawing.Point(92, 172);
            this.txtDrawEvery.Name = "txtDrawEvery";
            this.txtDrawEvery.Size = new System.Drawing.Size(72, 20);
            this.txtDrawEvery.TabIndex = 45;
            this.txtDrawEvery.Text = "100000";
            this.txtDrawEvery.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(12, 172);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(65, 13);
            this.Label7.TabIndex = 44;
            this.Label7.Text = "Draw Every:";
            // 
            // txtStopAfter
            // 
            this.txtStopAfter.Location = new System.Drawing.Point(92, 148);
            this.txtStopAfter.Name = "txtStopAfter";
            this.txtStopAfter.Size = new System.Drawing.Size(72, 20);
            this.txtStopAfter.TabIndex = 43;
            this.txtStopAfter.Text = "10000000";
            this.txtStopAfter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(12, 148);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(57, 13);
            this.Label6.TabIndex = 42;
            this.Label6.Text = "Stop After:";
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(28, 212);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 41;
            this.btnDraw.Text = "Draw";
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // picCanvas
            // 
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(172, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(24, 24);
            this.picCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picCanvas.TabIndex = 40;
            this.picCanvas.TabStop = false;
            // 
            // txtBlueCutoff
            // 
            this.txtBlueCutoff.Location = new System.Drawing.Point(92, 116);
            this.txtBlueCutoff.Name = "txtBlueCutoff";
            this.txtBlueCutoff.Size = new System.Drawing.Size(72, 20);
            this.txtBlueCutoff.TabIndex = 39;
            this.txtBlueCutoff.Text = "50";
            this.txtBlueCutoff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(12, 116);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(62, 13);
            this.Label5.TabIndex = 38;
            this.Label5.Text = "Blue Cutoff:";
            // 
            // txtGreenCutoff
            // 
            this.txtGreenCutoff.Location = new System.Drawing.Point(92, 92);
            this.txtGreenCutoff.Name = "txtGreenCutoff";
            this.txtGreenCutoff.Size = new System.Drawing.Size(72, 20);
            this.txtGreenCutoff.TabIndex = 37;
            this.txtGreenCutoff.Text = "250";
            this.txtGreenCutoff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(12, 92);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(70, 13);
            this.Label3.TabIndex = 36;
            this.Label3.Text = "Green Cutoff:";
            // 
            // txtRedCutoff
            // 
            this.txtRedCutoff.Location = new System.Drawing.Point(92, 68);
            this.txtRedCutoff.Name = "txtRedCutoff";
            this.txtRedCutoff.Size = new System.Drawing.Size(72, 20);
            this.txtRedCutoff.TabIndex = 35;
            this.txtRedCutoff.Text = "1250";
            this.txtRedCutoff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(12, 68);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(61, 13);
            this.Label4.TabIndex = 34;
            this.Label4.Text = "Red Cutoff:";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(92, 36);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(72, 20);
            this.txtHeight.TabIndex = 33;
            this.txtHeight.Text = "200";
            this.txtHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(12, 36);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(41, 13);
            this.Label2.TabIndex = 32;
            this.Label2.Text = "Height:";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(92, 12);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(72, 20);
            this.txtWidth.TabIndex = 31;
            this.txtWidth.Text = "200";
            this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 12);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(38, 13);
            this.Label1.TabIndex = 30;
            this.Label1.Text = "Width:";
            // 
            // howto_buddhabrot_Form1
            // 
            this.AcceptButton = this.btnDraw;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.txtDrawEvery);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.txtStopAfter);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.txtBlueCutoff);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.txtGreenCutoff);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtRedCutoff);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.Label1);
            this.Menu = this.MainMenu1;
            this.Name = "howto_buddhabrot_Form1";
            this.Text = "howto_buddhabrot";
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.MainMenu MainMenu1;
        internal System.Windows.Forms.MenuItem MenuItem1;
        internal System.Windows.Forms.MenuItem mnuFileSave;
        internal System.Windows.Forms.SaveFileDialog sfdBrot;
        internal System.Windows.Forms.TextBox txtDrawEvery;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox txtStopAfter;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Button btnDraw;
        internal System.Windows.Forms.PictureBox picCanvas;
        internal System.Windows.Forms.TextBox txtBlueCutoff;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtGreenCutoff;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtRedCutoff;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtHeight;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtWidth;
        internal System.Windows.Forms.Label Label1;
    }
}

