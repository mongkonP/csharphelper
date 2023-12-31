using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

 

using howto_read_exif_orientation;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_read_exif_orientation_Form1:Form
  { 


        public howto_read_exif_orientation_Form1()
        {
            InitializeComponent();
        }

        // Restore the saved file name.
        private void howto_read_exif_orientation_Form1_Load(object sender, EventArgs e)
        {
            txtFile.Text = Properties.Settings.Default.Filename;
        }

        // Save the current file name.
        private void howto_read_exif_orientation_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Filename = txtFile.Text;
            Properties.Settings.Default.Save();
        }

        // Let the user select a file.
        private void btnPickFile_Click(object sender, EventArgs e)
        {
            ofdFile.FileName = txtFile.Text;
            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = ofdFile.FileName;
                picOriginal.Image = null;
                picOrientation.Image = null;
                lblOrientation.Text = "";
            }
        }

        // Open the file and read its orientation information.
        private void btnOpen_Click(object sender, EventArgs e)
        {
            // Open the file.
            Bitmap bm = new Bitmap(txtFile.Text);
            picOriginal.Image = bm;

            // Get the PropertyItems property from image.
            ExifStuff.ExifOrientations orientation =
                ExifStuff.ImageOrientation(bm);
            lblOrientation.Text = orientation.ToString();
            picOrientation.Image = ExifStuff.OrientationImage(orientation);
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
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.picOrientation = new System.Windows.Forms.PictureBox();
            this.lblOrientation = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnPickFile = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOrientation)).BeginInit();
            this.SuspendLayout();
            // 
            // picOriginal
            // 
            this.picOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picOriginal.Location = new System.Drawing.Point(198, 75);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(64, 64);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picOriginal.TabIndex = 20;
            this.picOriginal.TabStop = false;
            // 
            // ofdFile
            // 
            this.ofdFile.FileName = "openFileDialog1";
            this.ofdFile.Filter = "JPGs|*.jpg|Image Files|*.bmp;*.jpg;*.gif;*.exif;*.png;*.tif|All Files|*.*";
            // 
            // picOrientation
            // 
            this.picOrientation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picOrientation.Location = new System.Drawing.Point(268, 75);
            this.picOrientation.Name = "picOrientation";
            this.picOrientation.Size = new System.Drawing.Size(64, 64);
            this.picOrientation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picOrientation.TabIndex = 19;
            this.picOrientation.TabStop = false;
            // 
            // lblOrientation
            // 
            this.lblOrientation.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrientation.Location = new System.Drawing.Point(12, 76);
            this.lblOrientation.Name = "lblOrientation";
            this.lblOrientation.Size = new System.Drawing.Size(120, 64);
            this.lblOrientation.TabIndex = 18;
            this.lblOrientation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOpen.Location = new System.Drawing.Point(135, 39);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 17;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnPickFile
            // 
            this.btnPickFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickFile.Image = Properties.Resources.Ellipsis;
            this.btnPickFile.Location = new System.Drawing.Point(305, 11);
            this.btnPickFile.Name = "btnPickFile";
            this.btnPickFile.Size = new System.Drawing.Size(27, 23);
            this.btnPickFile.TabIndex = 16;
            this.btnPickFile.TabStop = false;
            this.btnPickFile.UseVisualStyleBackColor = true;
            this.btnPickFile.Click += new System.EventHandler(this.btnPickFile_Click);
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(44, 13);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(255, 20);
            this.txtFile.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "File:";
            // 
            // howto_read_exif_orientation_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 150);
            this.Controls.Add(this.picOriginal);
            this.Controls.Add(this.picOrientation);
            this.Controls.Add(this.lblOrientation);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnPickFile);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label1);
            this.Name = "howto_read_exif_orientation_Form1";
            this.Text = "howto_read_exif_orientation";
            this.Load += new System.EventHandler(this.howto_read_exif_orientation_Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_read_exif_orientation_Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOrientation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.PictureBox picOrientation;
        private System.Windows.Forms.Label lblOrientation;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnPickFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label1;
    }
}

