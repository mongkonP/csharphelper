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
     public partial class howto_warp_drawimage_Form1:Form
  { 


        public howto_warp_drawimage_Form1()
        {
            InitializeComponent();
        }

        private void howto_warp_drawimage_Form1_Load(object sender, EventArgs e)
        {
            // Get the source bitmap.
            using (Bitmap bm_source = new Bitmap(picSource.Image))
            {
                // Make an array of points defining the
                // transformed image's corners.
                int wid = bm_source.Width;
                int hgt = bm_source.Height;
                PointF[] corners = 
                {
                    new PointF(wid * 0.5f, 0),
                    new PointF(0, hgt * 0.4f),
                    new PointF(wid, hgt * 0.6f)
                };

                // Make a bitmap for the result.
                Bitmap bm_dest = new Bitmap(
                    (int)bm_source.Width,
                    (int)bm_source.Height);

                // Make a Graphics object for the result Bitmap.
                using (Graphics gr_dest = Graphics.FromImage(bm_dest))
                {
                    gr_dest.Clear(Color.LightGreen);

                    // Copy the source image into the destination bitmap.
                    gr_dest.DrawImage(bm_source, corners);
                }

                // Display the result.
                picDest.Image = bm_dest;
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
            this.picSource = new System.Windows.Forms.PictureBox();
            this.picDest = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDest)).BeginInit();
            this.SuspendLayout();
            // 
            // picSource
            // 
            this.picSource.Image = Properties.Resources.Dog;
            this.picSource.Location = new System.Drawing.Point(4, 4);
            this.picSource.Name = "picSource";
            this.picSource.Size = new System.Drawing.Size(309, 203);
            this.picSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSource.TabIndex = 11;
            this.picSource.TabStop = false;
            // 
            // picDest
            // 
            this.picDest.BackColor = System.Drawing.Color.Aqua;
            this.picDest.Location = new System.Drawing.Point(4, 213);
            this.picDest.Name = "picDest";
            this.picDest.Size = new System.Drawing.Size(309, 203);
            this.picDest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picDest.TabIndex = 10;
            this.picDest.TabStop = false;
            // 
            // howto_warp_drawimage_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 421);
            this.Controls.Add(this.picSource);
            this.Controls.Add(this.picDest);
            this.Name = "howto_warp_drawimage_Form1";
            this.Text = "howto_warp_drawimage";
            this.Load += new System.EventHandler(this.howto_warp_drawimage_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox picDest;
        private System.Windows.Forms.PictureBox picSource;
    }
}

