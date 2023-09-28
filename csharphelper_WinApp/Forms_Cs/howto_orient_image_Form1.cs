using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;//@

 

using howto_orient_image;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_orient_image_Form1:Form
  { 


        public howto_orient_image_Form1()
        {
            InitializeComponent();
        }

        // Restore the saved file name.
        private void howto_orient_image_Form1_Load(object sender, EventArgs e)
        {
            txtFile.Text = Properties.Settings.Default.Filename;
        }

        // Save the current file name.
        private void howto_orient_image_Form1_FormClosing(object sender, FormClosingEventArgs e)
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
                picOriented.Image = null;
            }
        }

        // Open the file and read its orientation information.
        private void btnOpen_Click(object sender, EventArgs e)
        {
            // Open the file.
            using (Bitmap bm = new Bitmap(txtFile.Text))
            {
                // Display the original image.
                Bitmap original_bm = new Bitmap(bm);
                picOriginal.Image = original_bm;

                // Display the image property oriented.
                // Note: If you use new Bitmap(bm) to make the copy,
                //       then the EXIF properties are lost. Clone instead.
                Bitmap oriented_bm = (Bitmap)bm.Clone();
                ExifStuff.OrientImage(oriented_bm);
                picOriented.Image = oriented_bm;
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
            this.picOriented = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnPickFile = new System.Windows.Forms.Button();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picOriented)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            this.SuspendLayout();
            // 
            // picOriented
            // 
            this.picOriented.Location = new System.Drawing.Point(196, 95);
            this.picOriented.Name = "picOriented";
            this.picOriented.Size = new System.Drawing.Size(175, 175);
            this.picOriented.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picOriented.TabIndex = 16;
            this.picOriented.TabStop = false;
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOpen.Location = new System.Drawing.Point(155, 39);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 15;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnPickFile
            // 
            this.btnPickFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickFile.Image = Properties.Resources.Ellipsis;
            this.btnPickFile.Location = new System.Drawing.Point(345, 11);
            this.btnPickFile.Name = "btnPickFile";
            this.btnPickFile.Size = new System.Drawing.Size(27, 23);
            this.btnPickFile.TabIndex = 14;
            this.btnPickFile.TabStop = false;
            this.btnPickFile.UseVisualStyleBackColor = true;
            this.btnPickFile.Click += new System.EventHandler(this.btnPickFile_Click);
            // 
            // ofdFile
            // 
            this.ofdFile.FileName = "openFileDialog1";
            this.ofdFile.Filter = "JPGs|*.jpg|Image Files|*.bmp;*.jpg;*.gif;*.exif;*.png;*.tif|All Files|*.*";
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(44, 13);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(295, 20);
            this.txtFile.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "File:";
            // 
            // picOriginal
            // 
            this.picOriginal.Location = new System.Drawing.Point(15, 95);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(175, 175);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picOriginal.TabIndex = 17;
            this.picOriginal.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(15, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 19);
            this.label2.TabIndex = 18;
            this.label2.Text = "Original";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(193, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 19);
            this.label3.TabIndex = 19;
            this.label3.Text = "Oriented";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_orient_image_Form1
            // 
            this.AcceptButton = this.btnOpen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 284);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picOriginal);
            this.Controls.Add(this.picOriented);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnPickFile);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label1);
            this.Name = "howto_orient_image_Form1";
            this.Text = "howto_orient_image";
            this.Load += new System.EventHandler(this.howto_orient_image_Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_orient_image_Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picOriented)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picOriented;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnPickFile;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

