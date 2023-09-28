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
     public partial class howto_maketransparent_Form1:Form
  { 


        public howto_maketransparent_Form1()
        {
            InitializeComponent();
        }

        // The images.
        private Bitmap SmileBitmap, FrownBitmap;

        // Make the images' backgrounds transparent.
        private void howto_maketransparent_Form1_Load(object sender, EventArgs e)
        {
            SmileBitmap = Properties.Resources.smile;
            SmileBitmap.MakeTransparent(SmileBitmap.GetPixel(0, 0));

            FrownBitmap = Properties.Resources.Frown;
            FrownBitmap.MakeTransparent(FrownBitmap.GetPixel(0, 0));
        }

        // Draw the two images overlapping.
        private void howto_maketransparent_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(FrownBitmap, 30, 30);
            e.Graphics.DrawImage(SmileBitmap, 95, 85);
            e.Graphics.DrawImage(FrownBitmap, 160, 30);
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
            this.SuspendLayout();
            // 
            // howto_maketransparent_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 239);
            this.Name = "howto_maketransparent_Form1";
            this.Text = "howto_maketransparent";
            this.Load += new System.EventHandler(this.howto_maketransparent_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_maketransparent_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

