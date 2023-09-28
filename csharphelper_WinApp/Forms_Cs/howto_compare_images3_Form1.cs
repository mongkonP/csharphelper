using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_compare_images3_Form1:Form
  { 


        public howto_compare_images3_Form1()
        {
            InitializeComponent();
        }

        private void btnFile1_Click(object sender, EventArgs e)
        {
            dlgSelectFile.FileName = txtFile1.Text;
            if (dlgSelectFile.ShowDialog() == DialogResult.OK)
            {
                txtFile1.Text = dlgSelectFile.FileName;
                try
                {
                    Bitmap bm = new Bitmap(txtFile1.Text);
                    picImage1.Image = (Bitmap)bm.Clone();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                btnGo.Enabled = (
                    (picImage1.Image != null) &&
                    (picImage2.Image != null));
            }
        }

        private void btnFile2_Click(object sender, EventArgs e)
        {
            dlgSelectFile.FileName = txtFile2.Text;
            if (dlgSelectFile.ShowDialog() == DialogResult.OK)
            {
                txtFile2.Text = dlgSelectFile.FileName;
                try
                {
                    Bitmap bm = new Bitmap(txtFile2.Text);
                    picImage2.Image = (Bitmap)bm.Clone();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                btnGo.Enabled = (
                    (picImage1.Image != null) &&
                    (picImage2.Image != null));
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            // Load the images.
            Bitmap bm1 = (Bitmap)picImage1.Image;
            Bitmap bm2 = (Bitmap)picImage2.Image;

            // Make a difference image.
            int wid = Math.Min(bm1.Width, bm2.Width);
            int hgt = Math.Min(bm1.Height, bm2.Height);

            // Get the differences.
            int[,] diffs = new int[wid, hgt];
            int max_diff = 0;
            for (int x = 0; x < wid; x++)
            {
                for (int y = 0; y < hgt; y++)
                {
                    // Calculate the pixels' difference.
                    Color color1 = bm1.GetPixel(x, y);
                    Color color2 = bm2.GetPixel(x, y);
                    diffs[x, y] = (int)(
                        Math.Abs(color1.R - color2.R) +
                        Math.Abs(color1.G - color2.G) +
                        Math.Abs(color1.B - color2.B));
                    if (diffs[x, y] > max_diff)
                        max_diff = diffs[x, y];
                }
            }
            //max_diff = 255;

            // Create the difference image.
            Bitmap bm3 = new Bitmap(wid, hgt);
            for (int x = 0; x < wid; x++)
            {
                for (int y = 0; y < hgt; y++)
                {
                    int clr = 255 - (int)(255.0 / max_diff * diffs[x, y]);
                    bm3.SetPixel(x, y, Color.FromArgb(clr, clr, clr));
                }
            }

            // Display the result.
            picResult.Image = bm3;

            this.Cursor = Cursors.Default;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_compare_images3_Form1));
            this.btnFile2 = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnFile1 = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtFile1 = new System.Windows.Forms.TextBox();
            this.picResult = new System.Windows.Forms.PictureBox();
            this.dlgSelectFile = new System.Windows.Forms.OpenFileDialog();
            this.txtFile2 = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.picImage1 = new System.Windows.Forms.PictureBox();
            this.picImage2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFile2
            // 
            this.btnFile2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFile2.Image = ((System.Drawing.Image)(resources.GetObject("btnFile2.Image")));
            this.btnFile2.Location = new System.Drawing.Point(284, 42);
            this.btnFile2.Name = "btnFile2";
            this.btnFile2.Size = new System.Drawing.Size(24, 20);
            this.btnFile2.TabIndex = 3;
            this.btnFile2.UseVisualStyleBackColor = false;
            this.btnFile2.Click += new System.EventHandler(this.btnFile2_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(12, 45);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(32, 13);
            this.Label2.TabIndex = 14;
            this.Label2.Text = "File 2";
            // 
            // btnFile1
            // 
            this.btnFile1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFile1.Image = ((System.Drawing.Image)(resources.GetObject("btnFile1.Image")));
            this.btnFile1.Location = new System.Drawing.Point(284, 16);
            this.btnFile1.Name = "btnFile1";
            this.btnFile1.Size = new System.Drawing.Size(24, 20);
            this.btnFile1.TabIndex = 1;
            this.btnFile1.UseVisualStyleBackColor = false;
            this.btnFile1.Click += new System.EventHandler(this.btnFile1_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 19);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(32, 13);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "File 1";
            // 
            // txtFile1
            // 
            this.txtFile1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile1.Location = new System.Drawing.Point(50, 16);
            this.txtFile1.Name = "txtFile1";
            this.txtFile1.Size = new System.Drawing.Size(228, 20);
            this.txtFile1.TabIndex = 0;
            // 
            // picResult
            // 
            this.picResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picResult.Location = new System.Drawing.Point(127, 3);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(56, 50);
            this.picResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picResult.TabIndex = 0;
            this.picResult.TabStop = false;
            // 
            // dlgSelectFile
            // 
            this.dlgSelectFile.Filter = "Graphics Files|*.bmp;*.gif;*.jpg;*.jpeg;*.ico;*.png;*.tif;*.tiff|All Files|*.*";
            this.dlgSelectFile.Title = "Select File";
            // 
            // txtFile2
            // 
            this.txtFile2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile2.Location = new System.Drawing.Point(50, 42);
            this.txtFile2.Name = "txtFile2";
            this.txtFile2.Size = new System.Drawing.Size(228, 20);
            this.txtFile2.TabIndex = 2;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGo.Enabled = false;
            this.btnGo.Location = new System.Drawing.Point(136, 68);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(48, 23);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.picImage1);
            this.flowLayoutPanel1.Controls.Add(this.picImage2);
            this.flowLayoutPanel1.Controls.Add(this.picResult);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 97);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(296, 107);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // picImage1
            // 
            this.picImage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage1.Location = new System.Drawing.Point(3, 3);
            this.picImage1.Name = "picImage1";
            this.picImage1.Size = new System.Drawing.Size(56, 50);
            this.picImage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImage1.TabIndex = 1;
            this.picImage1.TabStop = false;
            // 
            // picImage2
            // 
            this.picImage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage2.Location = new System.Drawing.Point(65, 3);
            this.picImage2.Name = "picImage2";
            this.picImage2.Size = new System.Drawing.Size(56, 50);
            this.picImage2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImage2.TabIndex = 2;
            this.picImage2.TabStop = false;
            // 
            // howto_compare_images3_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 216);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnFile2);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.btnFile1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtFile1);
            this.Controls.Add(this.txtFile2);
            this.Controls.Add(this.btnGo);
            this.Name = "howto_compare_images3_Form1";
            this.Text = "howto_compare_images";
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnFile2;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button btnFile1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtFile1;
        internal System.Windows.Forms.PictureBox picResult;
        internal System.Windows.Forms.OpenFileDialog dlgSelectFile;
        internal System.Windows.Forms.TextBox txtFile2;
        internal System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        internal System.Windows.Forms.PictureBox picImage1;
        internal System.Windows.Forms.PictureBox picImage2;
    }
}

