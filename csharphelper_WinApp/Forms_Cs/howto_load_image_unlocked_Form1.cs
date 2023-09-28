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
     public partial class howto_load_image_unlocked_Form1:Form
  { 


        public howto_load_image_unlocked_Form1()
        {
            InitializeComponent();
        }

        // Load the image normally.
        private void btnLoadNormally_Click(object sender, EventArgs e)
        {
            if (picSample.Image != null) picSample.Image.Dispose();
            picSample.Image = new Bitmap("essential_algs_75.jpg");
        }

        // Load the bitmap without locking it.
        private void btnLoadUnlocked_Click(object sender, EventArgs e)
        {
            if (picSample.Image != null) picSample.Image.Dispose();
            picSample.Image = LoadBitmapUnlocked("essential_algs_75.jpg");
        }

        // Load a bitmap without locking it.
        private Bitmap LoadBitmapUnlocked(string file_name)
        {
            using (Bitmap bm = new Bitmap(file_name))
            {
                return new Bitmap(bm);
            }
        }

        // Open the book's web page.
        private void picSample_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.csharphelper.com/algorithms.html");
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
            this.Label1 = new System.Windows.Forms.Label();
            this.picSample = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoadNormally = new System.Windows.Forms.Button();
            this.btnLoadUnlocked = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picSample)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label1.Location = new System.Drawing.Point(0, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(339, 21);
            this.Label1.TabIndex = 12;
            this.Label1.Text = "Click Load Locked and try to rename the file.";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picSample
            // 
            this.picSample.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picSample.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSample.Location = new System.Drawing.Point(57, 78);
            this.picSample.Name = "picSample";
            this.picSample.Size = new System.Drawing.Size(222, 275);
            this.picSample.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSample.TabIndex = 11;
            this.picSample.TabStop = false;
            this.picSample.Click += new System.EventHandler(this.picSample_Click);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(339, 23);
            this.label2.TabIndex = 15;
            this.label2.Text = "Then try again with the Load Unlocked button.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLoadNormally
            // 
            this.btnLoadNormally.Location = new System.Drawing.Point(57, 47);
            this.btnLoadNormally.Name = "btnLoadNormally";
            this.btnLoadNormally.Size = new System.Drawing.Size(100, 25);
            this.btnLoadNormally.TabIndex = 16;
            this.btnLoadNormally.Text = "Load Normally";
            this.btnLoadNormally.UseVisualStyleBackColor = true;
            this.btnLoadNormally.Click += new System.EventHandler(this.btnLoadNormally_Click);
            // 
            // btnLoadUnlocked
            // 
            this.btnLoadUnlocked.Location = new System.Drawing.Point(179, 47);
            this.btnLoadUnlocked.Name = "btnLoadUnlocked";
            this.btnLoadUnlocked.Size = new System.Drawing.Size(100, 25);
            this.btnLoadUnlocked.TabIndex = 17;
            this.btnLoadUnlocked.Text = "Load Unlocked";
            this.btnLoadUnlocked.UseVisualStyleBackColor = true;
            this.btnLoadUnlocked.Click += new System.EventHandler(this.btnLoadUnlocked_Click);
            // 
            // howto_load_image_unlocked_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 373);
            this.Controls.Add(this.btnLoadUnlocked);
            this.Controls.Add(this.btnLoadNormally);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.picSample);
            this.Name = "howto_load_image_unlocked_Form1";
            this.Text = "howto_load_image_unlocked";
            ((System.ComponentModel.ISupportInitialize)(this.picSample)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.PictureBox picSample;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoadNormally;
        private System.Windows.Forms.Button btnLoadUnlocked;
    }
}

