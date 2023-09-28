using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_pixel_offset_mode_Form1:Form
  { 


        public howto_pixel_offset_mode_Form1()
        {
            InitializeComponent();
        }

        private void howto_pixel_offset_mode_Form1_Load(object sender, EventArgs e)
        {
            cboMode.SelectedIndex = 0;
        }

        // Use the selected mode.
        private void cboMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            PixelOffsetMode mode = PixelOffsetMode.Default;
            switch (cboMode.Text)
            {
                case "Half":
                    mode = PixelOffsetMode.Half;
                    break;
                case "HighQuality":
                    mode = PixelOffsetMode.HighQuality;
                    break;
                case "HighSpeed":
                    mode = PixelOffsetMode.HighSpeed;
                    break;
                case "None":
                    mode = PixelOffsetMode.None;
                    break;
            }

            // Make the scaled image.
            picScaled.Image = MakeScaledImage(
                picOriginal.Image, 20, mode);
        }

        // Return a scaled version of the input image.
        private Bitmap MakeScaledImage(Image image,
            int scale, PixelOffsetMode mode)
        {
            int wid = scale * image.Width;
            int hgt = scale * image.Height;
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(Color.Yellow);

                Rectangle src_rect = new Rectangle(0, 0,
                    image.Width, image.Height);
                Rectangle dest_rect = new Rectangle(0, 0,
                    wid, hgt);
                gr.PixelOffsetMode = mode;
                gr.InterpolationMode = InterpolationMode.NearestNeighbor;
                gr.DrawImage(image, dest_rect, src_rect, GraphicsUnit.Pixel);
            }

            return bm;
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboMode = new System.Windows.Forms.ComboBox();
            this.picScaled = new System.Windows.Forms.PictureBox();
            this.picOriginal = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picScaled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "PixelOffsetMode";
            // 
            // cboMode
            // 
            this.cboMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMode.FormattingEnabled = true;
            this.cboMode.Items.AddRange(new object[] {
            "None",
            "Default",
            "Half",
            "HighQuality",
            "HighSpeed"});
            this.cboMode.Location = new System.Drawing.Point(99, 12);
            this.cboMode.Name = "cboMode";
            this.cboMode.Size = new System.Drawing.Size(121, 21);
            this.cboMode.TabIndex = 3;
            this.cboMode.SelectedIndexChanged += new System.EventHandler(this.cboMode_SelectedIndexChanged);
            // 
            // picScaled
            // 
            this.picScaled.Location = new System.Drawing.Point(29, 45);
            this.picScaled.Name = "picScaled";
            this.picScaled.Size = new System.Drawing.Size(76, 68);
            this.picScaled.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picScaled.TabIndex = 1;
            this.picScaled.TabStop = false;
            // 
            // picOriginal
            // 
            this.picOriginal.Image = Properties.Resources.triangle;
            this.picOriginal.Location = new System.Drawing.Point(12, 45);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(11, 6);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picOriginal.TabIndex = 0;
            this.picOriginal.TabStop = false;
            // 
            // howto_pixel_offset_mode_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 181);
            this.Controls.Add(this.cboMode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picScaled);
            this.Controls.Add(this.picOriginal);
            this.Name = "howto_pixel_offset_mode_Form1";
            this.Text = "howto_pixel_offset_mode";
            this.Load += new System.EventHandler(this.howto_pixel_offset_mode_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picScaled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.PictureBox picScaled;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMode;
    }
}

