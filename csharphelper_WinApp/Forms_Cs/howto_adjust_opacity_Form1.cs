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
     public partial class howto_adjust_opacity_Form1:Form
  { 


        public howto_adjust_opacity_Form1()
        {
            InitializeComponent();
        }

        // The loaded image.
        private Bitmap OriginalImage = null;

        // The adjusted image.
        private Bitmap AdjustedImage = null;

        // The selected opacity.
        private float OpacityValue = 0.75f;

        // Load a picture.
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                OriginalImage = new Bitmap(ofdImage.FileName);
                ShowImage();
                picSample.Visible = true;
                mnuFileSave.Enabled = true;
            }
        }

        // Save the adjusted image.
        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            if (sfdImage.ShowDialog() == DialogResult.OK)
            {
                AdjustedImage.Save(sfdImage.FileName, ImageFormat.Png);
            }
        }

        // Draw the loaded image with the selected opacity.
        private void ShowImage()
        {
            // Make sure we have an input picture.
            if (OriginalImage == null) return;

            // Create a sample image.
            // Make a background image.
            Bitmap sample_bm =
                MakeCheckerboard(
                    OriginalImage.Width,
                    OriginalImage.Height, 64);

            // Draw the adjusted omage over the checkerboard.
            AdjustedImage = SetOpacity(OriginalImage, OpacityValue);
            using (Graphics gr = Graphics.FromImage(sample_bm))
            {
                gr.DrawImage(AdjustedImage, 0, 0);
            }

            picSample.Image = sample_bm;
        }

        // Make a checkerboard bitmap.
        private Bitmap MakeCheckerboard(int width, int height, int size)
        {
            int num_rows = height / size + 1;
            int num_cols = width / size + 1;
            Bitmap bm = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                for (int r = 0; r < num_rows; r++)
                {
                    for (int c = 0; c < num_cols; c++)
                    {
                        Rectangle rect = new Rectangle(
                            c * size, r * size, size, size);
                        if ((r + c) % 2 == 0)
                            gr.FillRectangle(Brushes.Blue, rect);
                        else
                            gr.FillRectangle(Brushes.Yellow, rect);
                    }
                }
            }
            return bm;
        }

        // Set the image's opacity.
        private Bitmap SetOpacity(Bitmap input_bm, float opacity)
        {
            // Make the new bitmap.
            Bitmap output_bm = new Bitmap(
                input_bm.Width, input_bm.Height);

            // Make an associated Grpahics object.
            using (Graphics gr = Graphics.FromImage(output_bm))
            {
                // Make a ColorMatrix with the opacity.
                ColorMatrix color_matrix = new ColorMatrix();
                color_matrix.Matrix33 = opacity;

                // Make the ImageAttributes object.
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(color_matrix,
                    ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                // Draw the input biitmap onto the Graphcis object.
                Rectangle rect = new Rectangle(0, 0,
                    output_bm.Width, output_bm.Height);

                gr.DrawImage(input_bm, rect,
                    0, 0, input_bm.Width, input_bm.Height,
                    GraphicsUnit.Pixel, attributes);
            }
            return output_bm;
        }

        // Change the opacity.
        private void scrOpacity_Scroll(object sender, ScrollEventArgs e)
        {
            OpacityValue = (scrOpacity.Value / 100f);
            lblOpacity.Text = OpacityValue.ToString("0.00");
            ShowImage();
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
            this.picSample = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ofdImage = new System.Windows.Forms.OpenFileDialog();
            this.sfdImage = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.scrOpacity = new System.Windows.Forms.HScrollBar();
            this.lblOpacity = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picSample)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picSample
            // 
            this.picSample.BackColor = System.Drawing.Color.White;
            this.picSample.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picSample.Location = new System.Drawing.Point(0, 0);
            this.picSample.Name = "picSample";
            this.picSample.Size = new System.Drawing.Size(258, 186);
            this.picSample.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSample.TabIndex = 0;
            this.picSample.TabStop = false;
            this.picSample.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Opacity:";
            // 
            // ofdImage
            // 
            this.ofdImage.Filter = "Image Files|*.bmp;*.jpg;*.gif;*.png;*.tif";
            // 
            // sfdImage
            // 
            this.sfdImage.DefaultExt = "png";
            this.sfdImage.Filter = "PNG Files|*.png";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fIleToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(432, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fIleToolStripMenuItem
            // 
            this.fIleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.mnuFileSave});
            this.fIleToolStripMenuItem.Name = "fIleToolStripMenuItem";
            this.fIleToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fIleToolStripMenuItem.Text = "&FIle";
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(155, 22);
            this.mnuFileOpen.Text = "&Open...";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Enabled = false;
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSave.Size = new System.Drawing.Size(155, 22);
            this.mnuFileSave.Text = "&Save...";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // scrOpacity
            // 
            this.scrOpacity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scrOpacity.Location = new System.Drawing.Point(61, 30);
            this.scrOpacity.Maximum = 109;
            this.scrOpacity.Name = "scrOpacity";
            this.scrOpacity.Size = new System.Drawing.Size(325, 20);
            this.scrOpacity.TabIndex = 4;
            this.scrOpacity.Value = 75;
            this.scrOpacity.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrOpacity_Scroll);
            // 
            // lblOpacity
            // 
            this.lblOpacity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOpacity.Location = new System.Drawing.Point(389, 30);
            this.lblOpacity.Name = "lblOpacity";
            this.lblOpacity.Size = new System.Drawing.Size(31, 20);
            this.lblOpacity.TabIndex = 5;
            this.lblOpacity.Text = "0.75";
            this.lblOpacity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.picSample);
            this.panel1.Location = new System.Drawing.Point(12, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(408, 280);
            this.panel1.TabIndex = 6;
            // 
            // howto_adjust_opacity_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 345);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblOpacity);
            this.Controls.Add(this.scrOpacity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "howto_adjust_opacity_Form1";
            this.Text = "howto_adjust_opacity";
            ((System.ComponentModel.ISupportInitialize)(this.picSample)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picSample;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog ofdImage;
        private System.Windows.Forms.SaveFileDialog sfdImage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fIleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private System.Windows.Forms.HScrollBar scrOpacity;
        private System.Windows.Forms.Label lblOpacity;
        private System.Windows.Forms.Panel panel1;
    }
}

