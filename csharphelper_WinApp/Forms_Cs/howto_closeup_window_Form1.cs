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
     public partial class howto_closeup_window_Form1:Form
  { 


        public howto_closeup_window_Form1()
        {
            InitializeComponent();
        }

        // Save the original image.
        private Bitmap OriginalImage, ShadedImage;
        private int SmallWidth, SmallHeight;
        private float ScaleX, ScaleY;
        private void howto_closeup_window_Form1_Load(object sender, EventArgs e)
        {
            OriginalImage = picWhole.Image as Bitmap;
            picCloseup.Image = OriginalImage;
            picCloseup.SizeMode = PictureBoxSizeMode.AutoSize;

            // Make a shaded version of the image.
            ShadedImage = new Bitmap(OriginalImage);
            using (Graphics gr = Graphics.FromImage(ShadedImage))
            {
                using (Brush br = new SolidBrush(Color.FromArgb(128, 255, 255, 255)))
                {
                    Rectangle rect = new Rectangle(0, 0, ShadedImage.Width, ShadedImage.Height);
                    gr.FillRectangle(br, rect);
                }
            }

            // Get scale factors to map from big scale to small scale.
            ScaleX = (float)panCloseup.ClientSize.Width / OriginalImage.Width;
            ScaleY = (float)panCloseup.ClientSize.Height / OriginalImage.Height;

            // See how big the closeup is on the small scale.
            SmallWidth = (int)(ScaleX * picWhole.ClientSize.Width);
            SmallHeight = (int)(ScaleY * picWhole.ClientSize.Height);
        }

        // Go to the Astronomy Picture of the Day web site.
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://antwrp.gsfc.nasa.gov/apod/ap090628.html");
        }

        // Display a closeup of this area.
        private Rectangle ViewingRectangle;
        private void picWhole_MouseMove(object sender, MouseEventArgs e)
        {
            // Position picCloseup inside its parent Panel.
            float x = (float)e.X / picWhole.ClientSize.Width * OriginalImage.Width - (float)panCloseup.ClientSize.Width / 2;
            float y = (float)e.Y / picWhole.ClientSize.Height * OriginalImage.Height - (float)panCloseup.ClientSize.Height / 2;
            if (x < 0) x = 0;
            if (y < 0) y = 0;
            if (x > OriginalImage.Width - panCloseup.ClientSize.Width)
                x = OriginalImage.Width - panCloseup.ClientSize.Width;
            if (y > OriginalImage.Height - panCloseup.ClientSize.Height)
                y = OriginalImage.Height - panCloseup.ClientSize.Height;
            picCloseup.Location = new Point(-(int)x, -(int)y);

            // Record the position we are viewing.
            ViewingRectangle = new Rectangle((int)x, (int)y,
                panCloseup.ClientSize.Width, 
                panCloseup.ClientSize.Height);

            // Draw the closeup area.
            picWhole.Invalidate();
        }

        // Draw the viewing area.
        private void picWhole_Paint(object sender, PaintEventArgs e)
        {
            // Scale so we can draw in the full scale coordinates.
            e.Graphics.ScaleTransform(ScaleX, ScaleY);

            // Draw the viewing area using the original image.
            e.Graphics.DrawImage(OriginalImage, ViewingRectangle, 
                ViewingRectangle, GraphicsUnit.Pixel);
            //e.Graphics.DrawRectangle(Pens.Red, ViewingRectangle);
        }

        // Use the shaded background image.
        private void picWhole_MouseEnter(object sender, EventArgs e)
        {
            picWhole.Image = ShadedImage;
            panCloseup.Visible = true;
        }

        // Use the regular image.
        private void picWhole_MouseLeave(object sender, EventArgs e)
        {
            picWhole.Image = OriginalImage;
            panCloseup.Visible = false;
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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.panCloseup = new System.Windows.Forms.Panel();
            this.picCloseup = new System.Windows.Forms.PictureBox();
            this.picWhole = new System.Windows.Forms.PictureBox();
            this.panCloseup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCloseup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWhole)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(110, 28);
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.linkLabel1.Location = new System.Drawing.Point(12, 325);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(532, 42);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "This is a picture of Saturn\'s moon Encaledus taken by the Casinni spacecraft. For" +
                " more information, visit the Astronomy Picture of the Day web site.";
            this.linkLabel1.UseCompatibleTextRendering = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(394, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Move the mouse over the picture on the left to see a closeup.";
            // 
            // panCloseup
            // 
            this.panCloseup.Controls.Add(this.picCloseup);
            this.panCloseup.Location = new System.Drawing.Point(268, 12);
            this.panCloseup.Name = "panCloseup";
            this.panCloseup.Size = new System.Drawing.Size(250, 250);
            this.panCloseup.TabIndex = 4;
            this.panCloseup.Visible = false;
            // 
            // picCloseup
            // 
            this.picCloseup.Location = new System.Drawing.Point(3, 3);
            this.picCloseup.Name = "picCloseup";
            this.picCloseup.Size = new System.Drawing.Size(189, 196);
            this.picCloseup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCloseup.TabIndex = 1;
            this.picCloseup.TabStop = false;
            // 
            // picWhole
            // 
            this.picWhole.Image = Properties.Resources.enceladus_cassini;
            this.picWhole.Location = new System.Drawing.Point(12, 12);
            this.picWhole.Name = "picWhole";
            this.picWhole.Size = new System.Drawing.Size(250, 250);
            this.picWhole.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picWhole.TabIndex = 0;
            this.picWhole.TabStop = false;
            this.picWhole.MouseLeave += new System.EventHandler(this.picWhole_MouseLeave);
            this.picWhole.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picWhole_MouseMove);
            this.picWhole.Paint += new System.Windows.Forms.PaintEventHandler(this.picWhole_Paint);
            this.picWhole.MouseEnter += new System.EventHandler(this.picWhole_MouseEnter);
            // 
            // howto_closeup_window_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 374);
            this.Controls.Add(this.panCloseup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.picWhole);
            this.Name = "howto_closeup_window_Form1";
            this.Text = "howto_closeup_window";
            this.Load += new System.EventHandler(this.howto_closeup_window_Form1_Load);
            this.panCloseup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCloseup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWhole)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picWhole;
        private System.Windows.Forms.PictureBox picCloseup;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panCloseup;
    }
}

