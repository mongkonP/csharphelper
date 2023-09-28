using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;

 

using howto_bitmap32;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_bitmap32_Form1:Form
  { 


        public howto_bitmap32_Form1()
        {
            InitializeComponent();
        }

        // Display the initial image.
        private void howto_bitmap32_Form1_Load(object sender, EventArgs e)
        {
            picVisible.Image = picHidden.Image.Clone() as Image;
        }

        // Display the original image.
        private void btnReset_Click(object sender, EventArgs e)
        {
            picVisible.Image = picHidden.Image.Clone() as Image;
            lblElapsed.Text = "";
        }

        private int NUM_TRIALS = 5;

        // Invert the image without Lockbits.
        private void btnNoLockBits_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(picHidden.Image);
            Cursor = Cursors.WaitCursor;
            Stopwatch watch = new Stopwatch();
            watch.Start();

            for (int trial = 0; trial < NUM_TRIALS; trial++)
            {
                for (int Y = 0; Y < bm.Height; Y++)
                {
                    for (int X = 0; X < bm.Width; X++)
                    {
                        Color clr = bm.GetPixel(X, Y);
                        clr = Color.FromArgb(
                            255 - clr.R,
                            255 - clr.G,
                            255 - clr.B);
                        bm.SetPixel(X, Y, clr);
                    }
                }
            }
            picVisible.Image = bm;
            watch.Stop();
            Cursor = Cursors.Default;

            lblElapsed.Text =
                watch.Elapsed.TotalSeconds.ToString("0.000000") +
                " seconds";
        }

        // Invert the image using Lockbits.
        private void btnLockBits_Click(object sender, EventArgs e)
        {
            const byte BYTE_255 = 255;
            Bitmap bm = new Bitmap(picHidden.Image);
            Cursor = Cursors.WaitCursor;
            Stopwatch watch = new Stopwatch();
            watch.Start();

            for (int trial = 0; trial < NUM_TRIALS; trial++)
            {
                // Make a Bitmap24 object.
                Bitmap32 bm32 = new Bitmap32(bm);

                // Lock the bitmap.
                bm32.LockBitmap();

                // Invert the pixels.
                byte red, green, blue, alpha;
                for (int y = 0; y < bm32.Height; y++)
                {
                    for (int x = 0; x < bm32.Width; x++)
                    {
                        bm32.GetPixel(x, y, out red, out green, out blue, out alpha);
                        red = (byte)(BYTE_255 - red);
                        green = (byte)(BYTE_255 - green);
                        blue = (byte)(BYTE_255 - blue);
                        bm32.SetPixel(x, y, red, green, blue, alpha);
                    }
                }

                // Unlock the bitmap.
                bm32.UnlockBitmap();
            }
            picVisible.Image = bm;

            watch.Stop();
            Cursor = Cursors.Default;

            lblElapsed.Text =
                watch.Elapsed.TotalSeconds.ToString("0.000000") +
                " seconds";
        }

        private void btnQuarter_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(picHidden.Image);
            Cursor = Cursors.WaitCursor;
            Stopwatch watch = new Stopwatch();
            watch.Start();

            // Make a Bitmap24 object.
            Bitmap32 bm32 = new Bitmap32(bm);

            // Lock the bitmap.
            bm32.LockBitmap();

            // Invert the pixels.
            int xmid = bm32.Width / 2;
            int ymid = bm32.Height / 2;
            for (int y = 0; y < ymid; y++)
            {
                for (int x = 0; x < xmid; x++)
                {
                    bm32.SetGreen(x, y, 0);
                    bm32.SetBlue(x, y, 0);
                    bm32.SetAlpha(x, y, 220);
                }
            }
            for (int y = ymid; y < bm32.Height; y++)
            {
                for (int x = 0; x < xmid; x++)
                {
                    bm32.SetRed(x, y, 0);
                    bm32.SetGreen(x, y, 0);
                    bm32.SetAlpha(x, y, 220);
                }
            }
            for (int y = 0; y < ymid; y++)
            {
                for (int x = xmid; x < bm32.Width; x++)
                {
                    bm32.SetRed(x, y, 0);
                    bm32.SetBlue(x, y, 0);
                    bm32.SetAlpha(x, y, 220);
                }
            }
            byte red, green, blue, alpha;
            for (int y = ymid; y < bm32.Height; y++)
            {
                for (int x = xmid; x < bm32.Width; x++)
                {
                    red = (byte)(255 - bm32.GetRed(x, y));
                    green = (byte)(255 - bm32.GetGreen(x, y));
                    blue = (byte)(255 - bm32.GetBlue(x, y));
                    alpha = 220;
                    bm32.SetPixel(x, y, red, green, blue, alpha);
                }
            }

            // Unlock the bitmap.
            bm32.UnlockBitmap();

            // Make a new bitmap.
            Bitmap final_bm = new Bitmap(picHidden.Image);
            using (Graphics gr = Graphics.FromImage(final_bm))
            {
                // Draw an ellispe in the center.
                gr.Clear(Color.Black);
                gr.FillEllipse(Brushes.White,
                    new Rectangle((int)(bm.Width * 0.2), (int)(bm.Height * 0.2),
                        (int)(bm.Width * 0.6), (int)(bm.Height * 0.6)));

                // Copy the quartered bitmap onto this one.
                gr.DrawImage(bm, 0, 0);
            }

            // Display the result.
            picVisible.Image = final_bm;

            watch.Stop();
            Cursor = Cursors.Default;

            lblElapsed.Text =
                watch.Elapsed.TotalSeconds.ToString("0.000000") +
                " seconds";
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
            this.picHidden = new System.Windows.Forms.PictureBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnLockBits = new System.Windows.Forms.Button();
            this.btnNoLockBits = new System.Windows.Forms.Button();
            this.picVisible = new System.Windows.Forms.PictureBox();
            this.lblElapsed = new System.Windows.Forms.Label();
            this.btnQuarter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picHidden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVisible)).BeginInit();
            this.SuspendLayout();
            // 
            // picHidden
            // 
            this.picHidden.Image = Properties.Resources.wpf_prog_ref_big;
            this.picHidden.Location = new System.Drawing.Point(184, 113);
            this.picHidden.Name = "picHidden";
            this.picHidden.Size = new System.Drawing.Size(446, 577);
            this.picHidden.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picHidden.TabIndex = 1;
            this.picHidden.TabStop = false;
            this.picHidden.Visible = false;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(12, 12);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(80, 24);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnLockBits
            // 
            this.btnLockBits.Location = new System.Drawing.Point(184, 12);
            this.btnLockBits.Name = "btnLockBits";
            this.btnLockBits.Size = new System.Drawing.Size(80, 24);
            this.btnLockBits.TabIndex = 5;
            this.btnLockBits.Text = "Lock Bits";
            this.btnLockBits.Click += new System.EventHandler(this.btnLockBits_Click);
            // 
            // btnNoLockBits
            // 
            this.btnNoLockBits.Location = new System.Drawing.Point(98, 12);
            this.btnNoLockBits.Name = "btnNoLockBits";
            this.btnNoLockBits.Size = new System.Drawing.Size(80, 24);
            this.btnNoLockBits.TabIndex = 4;
            this.btnNoLockBits.Text = "No Lock Bits";
            this.btnNoLockBits.Click += new System.EventHandler(this.btnNoLockBits_Click);
            // 
            // picVisible
            // 
            this.picVisible.Location = new System.Drawing.Point(12, 42);
            this.picVisible.Name = "picVisible";
            this.picVisible.Size = new System.Drawing.Size(446, 577);
            this.picVisible.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picVisible.TabIndex = 6;
            this.picVisible.TabStop = false;
            // 
            // lblElapsed
            // 
            this.lblElapsed.AutoSize = true;
            this.lblElapsed.Location = new System.Drawing.Point(12, 622);
            this.lblElapsed.Name = "lblElapsed";
            this.lblElapsed.Size = new System.Drawing.Size(0, 13);
            this.lblElapsed.TabIndex = 7;
            // 
            // btnQuarter
            // 
            this.btnQuarter.Location = new System.Drawing.Point(270, 12);
            this.btnQuarter.Name = "btnQuarter";
            this.btnQuarter.Size = new System.Drawing.Size(80, 24);
            this.btnQuarter.TabIndex = 8;
            this.btnQuarter.Text = "Quarter";
            this.btnQuarter.Click += new System.EventHandler(this.btnQuarter_Click);
            // 
            // howto_bitmap32_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 647);
            this.Controls.Add(this.btnQuarter);
            this.Controls.Add(this.lblElapsed);
            this.Controls.Add(this.picVisible);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnLockBits);
            this.Controls.Add(this.btnNoLockBits);
            this.Controls.Add(this.picHidden);
            this.Name = "howto_bitmap32_Form1";
            this.Text = "howto_bitmap32";
            this.Load += new System.EventHandler(this.howto_bitmap32_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picHidden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVisible)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox picHidden;
        internal System.Windows.Forms.Button btnReset;
        internal System.Windows.Forms.Button btnLockBits;
        internal System.Windows.Forms.Button btnNoLockBits;
        internal System.Windows.Forms.PictureBox picVisible;
        private System.Windows.Forms.Label lblElapsed;
        internal System.Windows.Forms.Button btnQuarter;
    }
}

