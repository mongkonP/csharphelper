using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

// Set the "Copy to Output Directory" property for
// the image files to "Copy if Newer."

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_read_emf_Form1:Form
  { 


        public howto_read_emf_Form1()
        {
            InitializeComponent();
        }

        private void howto_read_emf_Form1_Load(object sender, EventArgs e)
        {
            Metafile mf1 = (Metafile)Metafile.FromFile("test.emf");
            picMetafile1.Image = mf1;
            picMetafile1Stretched.Image = mf1;

            Metafile mf2 = (Metafile)Metafile.FromFile("Volleyball.wmf");
            picMetafile2.Image = mf2;
            picMetafile2Stretched.Image = mf2;
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
            this.picMetafile1Stretched = new System.Windows.Forms.PictureBox();
            this.picMetafile1 = new System.Windows.Forms.PictureBox();
            this.picMetafile2 = new System.Windows.Forms.PictureBox();
            this.picMetafile2Stretched = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picMetafile1Stretched)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMetafile1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMetafile2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMetafile2Stretched)).BeginInit();
            this.SuspendLayout();
            // 
            // picMetafile1Stretched
            // 
            this.picMetafile1Stretched.Location = new System.Drawing.Point(12, 128);
            this.picMetafile1Stretched.Name = "picMetafile1Stretched";
            this.picMetafile1Stretched.Size = new System.Drawing.Size(226, 110);
            this.picMetafile1Stretched.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMetafile1Stretched.TabIndex = 5;
            this.picMetafile1Stretched.TabStop = false;
            // 
            // picMetafile1
            // 
            this.picMetafile1.Location = new System.Drawing.Point(12, 12);
            this.picMetafile1.Name = "picMetafile1";
            this.picMetafile1.Size = new System.Drawing.Size(110, 110);
            this.picMetafile1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMetafile1.TabIndex = 3;
            this.picMetafile1.TabStop = false;
            // 
            // picMetafile2
            // 
            this.picMetafile2.Location = new System.Drawing.Point(128, 12);
            this.picMetafile2.Name = "picMetafile2";
            this.picMetafile2.Size = new System.Drawing.Size(110, 110);
            this.picMetafile2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMetafile2.TabIndex = 6;
            this.picMetafile2.TabStop = false;
            // 
            // picMetafile2Stretched
            // 
            this.picMetafile2Stretched.Location = new System.Drawing.Point(12, 244);
            this.picMetafile2Stretched.Name = "picMetafile2Stretched";
            this.picMetafile2Stretched.Size = new System.Drawing.Size(226, 110);
            this.picMetafile2Stretched.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMetafile2Stretched.TabIndex = 7;
            this.picMetafile2Stretched.TabStop = false;
            // 
            // howto_read_emf_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 366);
            this.Controls.Add(this.picMetafile2Stretched);
            this.Controls.Add(this.picMetafile2);
            this.Controls.Add(this.picMetafile1Stretched);
            this.Controls.Add(this.picMetafile1);
            this.Name = "howto_read_emf_Form1";
            this.Text = "howto_read_emf";
            this.Load += new System.EventHandler(this.howto_read_emf_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMetafile1Stretched)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMetafile1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMetafile2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMetafile2Stretched)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picMetafile1Stretched;
        private System.Windows.Forms.PictureBox picMetafile1;
        private System.Windows.Forms.PictureBox picMetafile2;
        private System.Windows.Forms.PictureBox picMetafile2Stretched;
    }
}

