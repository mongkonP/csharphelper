using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_display_animated_gif_Form1:Form
  { 


        public howto_display_animated_gif_Form1()
        {
            InitializeComponent();
        }

        // Switch GIFs.
        bool ButtonShowingPuppy = false;
        private void btnGif_Click(object sender, EventArgs e)
        {
            ButtonShowingPuppy = !ButtonShowingPuppy;
            if (ButtonShowingPuppy)
            {
                btnGif.Image = Properties.Resources.puppy;
            }
            else
            {
                btnGif.Image = Properties.Resources.under_construction;
            }
        }

        // Switch GIFs, loading from files.
        bool PictureBoxShowingPuppy = false;
        private void picGif_Click(object sender, EventArgs e)
        {
            PictureBoxShowingPuppy = !PictureBoxShowingPuppy;
            if (PictureBoxShowingPuppy)
            {
                picGif.Image =Properties.Resources.puppy;
            }
            else
            {
                picGif.Image = Properties.Resources.under_construction;
            }
        }

        // Switch GIFs.
        bool LabelShowingAlien = false;
        private void lblGif_Click(object sender, EventArgs e)
        {
            string filename = Path.GetFullPath(
                Path.Combine(Application.StartupPath, @"..\..\"));

            LabelShowingAlien = !LabelShowingAlien;
            if (LabelShowingAlien)
            {
                lblGif.Image = Image.FromFile(filename + "alien.gif");
            }
            else
            {
                lblGif.Image = Image.FromFile(filename + "under_construction.gif");
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
            this.lblGif = new System.Windows.Forms.Label();
            this.picGif = new System.Windows.Forms.PictureBox();
            this.btnGif = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picGif)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGif
            // 
            this.lblGif.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGif.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGif.Image = Properties.Resources.under_construction;
            this.lblGif.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblGif.Location = new System.Drawing.Point(12, 98);
            this.lblGif.Name = "lblGif";
            this.lblGif.Size = new System.Drawing.Size(247, 64);
            this.lblGif.TabIndex = 2;
            this.lblGif.Text = "Label";
            this.lblGif.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGif.Click += new System.EventHandler(this.lblGif_Click);
            // 
            // picGif
            // 
            this.picGif.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGif.Image = Properties.Resources.under_construction;
            this.picGif.Location = new System.Drawing.Point(147, 12);
            this.picGif.Name = "picGif";
            this.picGif.Size = new System.Drawing.Size(57, 63);
            this.picGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picGif.TabIndex = 1;
            this.picGif.TabStop = false;
            this.picGif.Click += new System.EventHandler(this.picGif_Click);
            // 
            // btnGif
            // 
            this.btnGif.Image = Properties.Resources.under_construction;
            this.btnGif.Location = new System.Drawing.Point(12, 12);
            this.btnGif.Name = "btnGif";
            this.btnGif.Size = new System.Drawing.Size(115, 74);
            this.btnGif.TabIndex = 0;
            this.btnGif.UseVisualStyleBackColor = true;
            this.btnGif.Click += new System.EventHandler(this.btnGif_Click);
            // 
            // howto_display_animated_gif_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 172);
            this.Controls.Add(this.lblGif);
            this.Controls.Add(this.picGif);
            this.Controls.Add(this.btnGif);
            this.Name = "howto_display_animated_gif_Form1";
            this.Text = "howto_display_animated_gif";
            ((System.ComponentModel.ISupportInitialize)(this.picGif)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGif;
        private System.Windows.Forms.PictureBox picGif;
        private System.Windows.Forms.Label lblGif;
    }
}

