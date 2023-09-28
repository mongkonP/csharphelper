using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_image_hash_Form1:Form
  { 


        public howto_image_hash_Form1()
        {
            InitializeComponent();
        }

        // Compare the images.
        private void btnCompare_Click(object sender, EventArgs e)
        {
            string hash_code1 = ProcessImage(picImage1.Image as Bitmap,
                picShrunk1, picMonochrome1, txtHashCode1);
            string hash_code2 = ProcessImage(picImage2.Image as Bitmap,
                picShrunk2, picMonochrome2, txtHashCode2);

            // Display the difference and score.
            string difference = "";
            int score = 0;
            for (int i = 0; i < hash_code1.Length; i++)
            {
                if (hash_code1[i] == hash_code2[i])
                {
                    difference += " ";
                }
                else
                {
                    difference += "X";
                    score++;
                }
            }
            txtDifference.Text = difference;
            txtScore.Text = score.ToString();
            float percent = (hash_code1.Length - score) / (float)hash_code1.Length;
            txtPercent.Text = percent.ToString("P");
        }

        private string ProcessImage(Bitmap original_bm,
            PictureBox pic_shrunk, PictureBox pic_monochrome,
            TextBox txt_hashcode)
        {
            // Shrink the original image and display the result.
            Bitmap shrunk_bm = ScaleTo(original_bm, 9, 9,
                InterpolationMode.High);
            pic_shrunk.Image = ScaleTo(shrunk_bm, 90, 90,
                InterpolationMode.NearestNeighbor);

            // Convert to grayscale and display the result.
            Bitmap grayscale_bm = ToMonochrome(shrunk_bm);
            pic_monochrome.Image = ScaleTo(grayscale_bm, 90, 90,
                InterpolationMode.NearestNeighbor);

            // Calculate the hash code.
            string hash_code = GetHashCode(grayscale_bm);
            txt_hashcode.Text = hash_code;

            return hash_code;
        }

        // Scale an image.
        private Bitmap ScaleTo(Bitmap bm, int wid, int hgt,
            InterpolationMode interpolation_mode)
        {
            Bitmap new_bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(new_bm))
            {
                RectangleF source_rect = new RectangleF(-0.5f, -0.5f, bm.Width, bm.Height);
                Rectangle dest_rect = new Rectangle(0, 0, wid, hgt);
                gr.InterpolationMode = interpolation_mode;
                gr.DrawImage(bm, dest_rect, source_rect, GraphicsUnit.Pixel);
            }
            return new_bm;
        }

        // Convert an image to monochrome.
        private Bitmap ToMonochrome(Image image)
        {
            // Make the ColorMatrix.
            ColorMatrix cm = new ColorMatrix(new float[][]
            {
                new float[] {0.299f, 0.299f, 0.299f, 0, 0},
                new float[] {0.587f, 0.587f, 0.587f, 0, 0},
                new float[] {0.114f, 0.114f, 0.114f, 0, 0},
                new float[] { 0, 0, 0, 1, 0},
                new float[] { 0, 0, 0, 0, 1}
            });
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(cm);

            // Draw the image onto the new bitmap while
            // applying the new ColorMatrix.
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

        // Return the hashcode for this 9x9 image.
        private string GetHashCode(Bitmap bm)
        {
            string row_hash = "";
            for (int r = 0; r < 8; r++)
                for (int c = 0; c < 8; c++)
                    if (bm.GetPixel(c + 1, r).R >= bm.GetPixel(c, r).R)
                        row_hash += "1";
                    else
                        row_hash += "0";

            string col_hash = "";
            for (int c = 0; c < 8; c++)
                for (int r = 0; r < 8; r++)
                    if (bm.GetPixel(c, r + 1).R >= bm.GetPixel(c, r).R)
                        col_hash += "1";
                    else
                        col_hash += "0";

            return row_hash + "," + col_hash;
        }

        private void btnLoadImage1_Click(object sender, EventArgs e)
        {
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                picImage1.Image = LoadBitmapUnlocked(ofdImage.FileName);
            }
        }

        private void btnLoadImage2_Click(object sender, EventArgs e)
        {
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                picImage2.Image = LoadBitmapUnlocked(ofdImage.FileName);
            }
        }

        // Load a bitmap without locking it.
        private Bitmap LoadBitmapUnlocked(string file_name)
        {
            using (Bitmap bm = new Bitmap(file_name))
            {
                return new Bitmap(bm);
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
            this.btnCompare = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHashCode1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.picMonochrome2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picImage1 = new System.Windows.Forms.PictureBox();
            this.picMonochrome1 = new System.Windows.Forms.PictureBox();
            this.picShrunk1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picImage2 = new System.Windows.Forms.PictureBox();
            this.picShrunk2 = new System.Windows.Forms.PictureBox();
            this.txtHashCode2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDifference = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLoadImage1 = new System.Windows.Forms.Button();
            this.btnLoadImage2 = new System.Windows.Forms.Button();
            this.ofdImage = new System.Windows.Forms.OpenFileDialog();
            this.txtPercent = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMonochrome2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMonochrome1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShrunk1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShrunk2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCompare
            // 
            this.btnCompare.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCompare.Location = new System.Drawing.Point(180, 12);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(75, 23);
            this.btnCompare.TabIndex = 0;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 436);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hash Code 1:";
            // 
            // txtHashCode1
            // 
            this.txtHashCode1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHashCode1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHashCode1.Location = new System.Drawing.Point(87, 433);
            this.txtHashCode1.Name = "txtHashCode1";
            this.txtHashCode1.ReadOnly = true;
            this.txtHashCode1.Size = new System.Drawing.Size(335, 20);
            this.txtHashCode1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnLoadImage2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnLoadImage1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.picMonochrome2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.picMonochrome1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.picShrunk1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.picShrunk2, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(410, 386);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // picMonochrome2
            // 
            this.picMonochrome2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMonochrome2.Location = new System.Drawing.Point(208, 293);
            this.picMonochrome2.Name = "picMonochrome2";
            this.picMonochrome2.Size = new System.Drawing.Size(90, 90);
            this.picMonochrome2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMonochrome2.TabIndex = 6;
            this.picMonochrome2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.picImage1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(199, 158);
            this.panel1.TabIndex = 4;
            // 
            // picImage1
            // 
            this.picImage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage1.Image = Properties.Resources.interview_puzzles_80_100;
            this.picImage1.Location = new System.Drawing.Point(0, 0);
            this.picImage1.Name = "picImage1";
            this.picImage1.Size = new System.Drawing.Size(82, 102);
            this.picImage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImage1.TabIndex = 0;
            this.picImage1.TabStop = false;
            // 
            // picMonochrome1
            // 
            this.picMonochrome1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMonochrome1.Location = new System.Drawing.Point(3, 293);
            this.picMonochrome1.Name = "picMonochrome1";
            this.picMonochrome1.Size = new System.Drawing.Size(90, 90);
            this.picMonochrome1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picMonochrome1.TabIndex = 2;
            this.picMonochrome1.TabStop = false;
            // 
            // picShrunk1
            // 
            this.picShrunk1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picShrunk1.Location = new System.Drawing.Point(3, 197);
            this.picShrunk1.Name = "picShrunk1";
            this.picShrunk1.Size = new System.Drawing.Size(90, 90);
            this.picShrunk1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picShrunk1.TabIndex = 1;
            this.picShrunk1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.picImage2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(208, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(199, 158);
            this.panel2.TabIndex = 3;
            // 
            // picImage2
            // 
            this.picImage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage2.Image = Properties.Resources.wpf3d_244_300;
            this.picImage2.Location = new System.Drawing.Point(0, 0);
            this.picImage2.Name = "picImage2";
            this.picImage2.Size = new System.Drawing.Size(246, 302);
            this.picImage2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImage2.TabIndex = 1;
            this.picImage2.TabStop = false;
            // 
            // picShrunk2
            // 
            this.picShrunk2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picShrunk2.Location = new System.Drawing.Point(208, 197);
            this.picShrunk2.Name = "picShrunk2";
            this.picShrunk2.Size = new System.Drawing.Size(90, 90);
            this.picShrunk2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picShrunk2.TabIndex = 5;
            this.picShrunk2.TabStop = false;
            // 
            // txtHashCode2
            // 
            this.txtHashCode2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHashCode2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHashCode2.Location = new System.Drawing.Point(87, 459);
            this.txtHashCode2.Name = "txtHashCode2";
            this.txtHashCode2.ReadOnly = true;
            this.txtHashCode2.Size = new System.Drawing.Size(335, 20);
            this.txtHashCode2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 462);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Hash Code 2:";
            // 
            // txtDifference
            // 
            this.txtDifference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDifference.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDifference.Location = new System.Drawing.Point(87, 485);
            this.txtDifference.Name = "txtDifference";
            this.txtDifference.ReadOnly = true;
            this.txtDifference.Size = new System.Drawing.Size(335, 20);
            this.txtDifference.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 488);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Difference:";
            // 
            // txtScore
            // 
            this.txtScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtScore.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore.Location = new System.Drawing.Point(87, 511);
            this.txtScore.Name = "txtScore";
            this.txtScore.ReadOnly = true;
            this.txtScore.Size = new System.Drawing.Size(52, 20);
            this.txtScore.TabIndex = 4;
            this.txtScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 514);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Score:";
            // 
            // btnLoadImage1
            // 
            this.btnLoadImage1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLoadImage1.Location = new System.Drawing.Point(65, 3);
            this.btnLoadImage1.Name = "btnLoadImage1";
            this.btnLoadImage1.Size = new System.Drawing.Size(75, 23);
            this.btnLoadImage1.TabIndex = 0;
            this.btnLoadImage1.Text = "Load Image";
            this.btnLoadImage1.UseVisualStyleBackColor = true;
            this.btnLoadImage1.Click += new System.EventHandler(this.btnLoadImage1_Click);
            // 
            // btnLoadImage2
            // 
            this.btnLoadImage2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLoadImage2.Location = new System.Drawing.Point(270, 3);
            this.btnLoadImage2.Name = "btnLoadImage2";
            this.btnLoadImage2.Size = new System.Drawing.Size(75, 23);
            this.btnLoadImage2.TabIndex = 1;
            this.btnLoadImage2.Text = "Load Image";
            this.btnLoadImage2.UseVisualStyleBackColor = true;
            this.btnLoadImage2.Click += new System.EventHandler(this.btnLoadImage2_Click);
            // 
            // ofdImage
            // 
            this.ofdImage.FileName = "openFileDialog1";
            this.ofdImage.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif";
            // 
            // txtPercent
            // 
            this.txtPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPercent.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPercent.Location = new System.Drawing.Point(145, 511);
            this.txtPercent.Name = "txtPercent";
            this.txtPercent.ReadOnly = true;
            this.txtPercent.Size = new System.Drawing.Size(52, 20);
            this.txtPercent.TabIndex = 5;
            this.txtPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // howto_image_hash_Form1
            // 
            this.AcceptButton = this.btnCompare;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 543);
            this.Controls.Add(this.txtPercent);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDifference);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHashCode2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.txtHashCode1);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.label1);
            this.Name = "howto_image_hash_Form1";
            this.Text = "howto_image_hash";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMonochrome2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMonochrome1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShrunk1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShrunk2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picImage1;
        private System.Windows.Forms.PictureBox picShrunk1;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.PictureBox picMonochrome1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHashCode1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picImage2;
        private System.Windows.Forms.PictureBox picMonochrome2;
        private System.Windows.Forms.PictureBox picShrunk2;
        private System.Windows.Forms.TextBox txtHashCode2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDifference;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLoadImage2;
        private System.Windows.Forms.Button btnLoadImage1;
        private System.Windows.Forms.OpenFileDialog ofdImage;
        private System.Windows.Forms.TextBox txtPercent;
    }
}

