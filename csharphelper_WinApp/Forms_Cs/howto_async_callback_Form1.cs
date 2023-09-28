using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting.Messaging;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_async_callback_Form1:Form
  { 


        public howto_async_callback_Form1()
        {
            InitializeComponent();
        }

        // Display the original images.
        private Bitmap[] Images =
        {
            Properties.Resources.Dog,
            Properties.Resources.geodesic,
            Properties.Resources.interview_puzzles,
            Properties.Resources.banner
        };
        private void howto_async_callback_Form1_Load(object sender, EventArgs e)
        {
            DisplayOriginalImages();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            DisplayOriginalImages();
        }
        private void DisplayOriginalImages()
        {
            pictureBox1.Image = Images[0];
            pictureBox2.Image = Images[1];
            pictureBox3.Image = Images[2];
            pictureBox4.Image = Images[3];
        }

        // Emboss the images synchronously.
        private DateTime StartTime;
        private int NumPending;
        private void btnSync_Click(object sender, EventArgs e)
        {
            lblElapsedTime.Text = "";
            DisplayOriginalImages();
            btnReset.Enabled = false;
            btnSync.Enabled = false;
            btnAsync.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            DateTime start_time = DateTime.Now;

            // Emboss the images.
            pictureBox1.Image = Emboss(Images[0]);
            pictureBox1.Refresh();

            pictureBox2.Image = Emboss(Images[1]);
            pictureBox2.Refresh();

            pictureBox3.Image = Emboss(Images[2]);
            pictureBox3.Refresh();

            pictureBox4.Image = Emboss(Images[3]);
            pictureBox4.Refresh();

            // Display the elapsed time.
            DateTime stop_time = DateTime.Now;
            TimeSpan elapsed_time = stop_time - start_time;
            lblElapsedTime.Text = elapsed_time.TotalSeconds.ToString("0.00") + " seconds";
            btnReset.Enabled = true;
            btnSync.Enabled = true;
            btnAsync.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        // Make a delegate representing the Emboss extension method.
        private delegate Bitmap EmbossDelegate(Bitmap bm);

        // Emboss the images asynchronously.
        private void btnAsync_Click(object sender, EventArgs e)
        {
            lblElapsedTime.Text = "";
            DisplayOriginalImages();
            this.Cursor = Cursors.WaitCursor;
            btnReset.Enabled = false;
            btnSync.Enabled = false;
            btnAsync.Enabled = false;
            Application.DoEvents();

            StartTime = DateTime.Now;

            // Copy the images.
            NumPending += 4;
            Bitmap bm1 = (Bitmap)Images[0].Clone();
            Bitmap bm2 = (Bitmap)Images[1].Clone();
            Bitmap bm3 = (Bitmap)Images[2].Clone();
            Bitmap bm4 = (Bitmap)Images[3].Clone();

            // Start the threads.
            EmbossDelegate caller = Emboss;
            caller.BeginInvoke(bm1, ImageCallback, pictureBox1);
            caller.BeginInvoke(bm2, ImageCallback, pictureBox2);
            caller.BeginInvoke(bm3, ImageCallback, pictureBox3);
            caller.BeginInvoke(bm4, ImageCallback, pictureBox4);
        }

        // The callback that executes when the asynchronous method finishes.
        private void ImageCallback(IAsyncResult ar)
        {
            AsyncResult result = ar as AsyncResult;
            EmbossDelegate caller = result.AsyncDelegate as EmbossDelegate;

            // Get the parameter we passed to the callback.
            PictureBox pic = result.AsyncState as PictureBox;

            // Get the method's return value.
            Bitmap bm = caller.EndInvoke(result);

            // Display the picture on the UI thread.
            DisplayPictureDelegate displayer = DisplayPicture;
            this.Invoke(displayer, bm, pic);
        }

        // Display a picture on the UI thread.
        private delegate void DisplayPictureDelegate(Bitmap bm, PictureBox pic);
        private void DisplayPicture(Bitmap bm, PictureBox pic)
        {
            // Set the Image property.
            pic.Image = bm;

            // If this is the last PictureBox, display the elapsed time.
            NumPending--;
            if (NumPending == 0)
            {
                DateTime stop_time = DateTime.Now;
                TimeSpan elapsed_time = stop_time - StartTime;
                lblElapsedTime.Text = elapsed_time.TotalSeconds.ToString("0.00") + " seconds";
                btnReset.Enabled = true;
                btnSync.Enabled = true;
                btnAsync.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        // Perform an embossing transformation on the bitmap.
        public static Bitmap Emboss(Bitmap bm)
        {
            int[,] kernel =
            {
                {-1, 0, 0},
                {0, 0, 0},
                {0, 0, 1}
            };
            int weight = 1;
            return ApplyFilter(bm, kernel, weight);
        }

        // Apply a filter to the Bitmap.
        public static Bitmap ApplyFilter(Bitmap bm, int[,] kernel, int weight)
        {
            Bitmap new_bm = new Bitmap(bm.Width, bm.Height);
            int kernel_width = kernel.GetUpperBound(0) + 1;
            int kernel_height = kernel.GetUpperBound(1) + 1;
            int half_width = kernel_width / 2;
            int half_height = kernel_height / 2;

            for (int x = half_width; x <= bm.Width - 1 - half_width; x++)
            {
                for (int y = half_height; y <= bm.Height - 1 - half_height; y++)
                {
                    int r = 0, g = 0, b = 0;
                    for (int dx = 0; dx < kernel_width; dx++)
                    {
                        for (int dy = 0; dy < kernel_height; dy++)
                        {
                            Color clr = bm.GetPixel(
                                x + dx - 1,
                                y + dy - 1);
                            r += clr.R * kernel[dx, dy];
                            g += clr.G * kernel[dx, dy];
                            b += clr.B * kernel[dx, dy];
                        }
                    }

                    r = (int)(127 + r / weight);
                    g = (int)(127 + g / weight);
                    b = (int)(127 + b / weight);
                    if (r < 0) r = 0;
                    if (g < 0) g = 0;
                    if (b < 0) b = 0;
                    if (r > 255) r = 255;
                    if (g > 255) g = 255;
                    if (b > 255) b = 255;
                    new_bm.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            return new_bm;
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblElapsedTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnAsync = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSync = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(229, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(220, 163);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Location = new System.Drawing.Point(3, 172);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(220, 163);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 163);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblElapsedTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 399);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(476, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblElapsedTime
            // 
            this.lblElapsedTime.Name = "lblElapsedTime";
            this.lblElapsedTime.Size = new System.Drawing.Size(0, 17);
            // 
            // btnAsync
            // 
            this.btnAsync.Location = new System.Drawing.Point(224, 6);
            this.btnAsync.Name = "btnAsync";
            this.btnAsync.Size = new System.Drawing.Size(100, 40);
            this.btnAsync.TabIndex = 12;
            this.btnAsync.Text = "Emboss Asynchronously";
            this.btnAsync.UseVisualStyleBackColor = true;
            this.btnAsync.Click += new System.EventHandler(this.btnAsync_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox4.Location = new System.Drawing.Point(229, 172);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(220, 163);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox4, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 52);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(452, 338);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(118, 6);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(100, 40);
            this.btnSync.TabIndex = 11;
            this.btnSync.Text = "Emboss Synchronously";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(12, 6);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 40);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // howto_async_callback_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 421);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnAsync);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.btnReset);
            this.Name = "howto_async_callback_Form1";
            this.Text = "howto_async_callback";
            this.Load += new System.EventHandler(this.howto_async_callback_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblElapsedTime;
        private System.Windows.Forms.Button btnAsync;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Button btnReset;
    }
}

