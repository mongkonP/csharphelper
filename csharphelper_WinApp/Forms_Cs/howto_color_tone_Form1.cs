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
     public partial class howto_color_tone_Form1:Form
  { 


        public howto_color_tone_Form1()
        {
            InitializeComponent();
        }

        // Display the image converted to sepia tone.
        private void howto_color_tone_Form1_Load(object sender, EventArgs e)
        {
            scrRed.Value = 128;
            scrGreen.Value = 128;
            scrBlue.Value = 128;
            scrBright.Value = 128;
            picColor.BackColor = Color.FromArgb(scrRed.Value, scrGreen.Value, scrBlue.Value);
            ColorPicture();
        }

        // Adjust the target color and redraw.
        private void scrColorComponent_Scroll(object sender, ScrollEventArgs e)
        {
            picColor.BackColor = Color.FromArgb(scrRed.Value, scrGreen.Value, scrBlue.Value);
            ColorPicture();
        }

        // Color the picture.
        private void ColorPicture()
        {
            picToned.Image = ToColorTone(picOriginal.Image, picColor.BackColor);
        }

        // Convert an image to sepia tone.
        private Bitmap ToColorTone(Image image, Color color)
        {
            float scale = scrBright.Value / 128f;

            float r = color.R / 255f * scale;
            float g = color.G / 255f * scale;
            float b = color.B / 255f * scale;

            // Make the ColorMatrix.
            ColorMatrix cm = new ColorMatrix(new float[][]
            {
                new float[] {r, 0, 0, 0, 0},
                new float[] {0, g, 0, 0, 0},
                new float[] {0, 0, b, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {0, 0, 0, 0, 1}
            });
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(cm);

            // Draw the image onto the new bitmap while applying the new ColorMatrix.
            Point[] points =
            {
                new Point(0, 0),
                new Point(image.Width - 1, 0),
                new Point(0, image.Height - 1),
            };
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

            // Make the result bitmap.
            Bitmap bm = new Bitmap(image.Width, image.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawImage(image, points, rect, GraphicsUnit.Pixel, attributes);
            }

            // Return the result.
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
            this.picToned = new System.Windows.Forms.PictureBox();
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picColor = new System.Windows.Forms.PictureBox();
            this.scrRed = new System.Windows.Forms.HScrollBar();
            this.scrGreen = new System.Windows.Forms.HScrollBar();
            this.label2 = new System.Windows.Forms.Label();
            this.scrBlue = new System.Windows.Forms.HScrollBar();
            this.label3 = new System.Windows.Forms.Label();
            this.scrBright = new System.Windows.Forms.HScrollBar();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picToned)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).BeginInit();
            this.SuspendLayout();
            // 
            // picToned
            // 
            this.picToned.Location = new System.Drawing.Point(318, 84);
            this.picToned.Name = "picToned";
            this.picToned.Size = new System.Drawing.Size(300, 400);
            this.picToned.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picToned.TabIndex = 4;
            this.picToned.TabStop = false;
            // 
            // picOriginal
            // 
            this.picOriginal.Image = Properties.Resources.JackOLanterns;
            this.picOriginal.Location = new System.Drawing.Point(12, 84);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(300, 400);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picOriginal.TabIndex = 3;
            this.picOriginal.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Red:";
            // 
            // picColor
            // 
            this.picColor.BackColor = System.Drawing.Color.LightBlue;
            this.picColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picColor.Location = new System.Drawing.Point(318, 12);
            this.picColor.Name = "picColor";
            this.picColor.Size = new System.Drawing.Size(68, 68);
            this.picColor.TabIndex = 6;
            this.picColor.TabStop = false;
            // 
            // scrRed
            // 
            this.scrRed.Location = new System.Drawing.Point(54, 12);
            this.scrRed.Maximum = 264;
            this.scrRed.Name = "scrRed";
            this.scrRed.Size = new System.Drawing.Size(258, 14);
            this.scrRed.TabIndex = 7;
            this.scrRed.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrColorComponent_Scroll);
            // 
            // scrGreen
            // 
            this.scrGreen.Location = new System.Drawing.Point(54, 31);
            this.scrGreen.Maximum = 264;
            this.scrGreen.Name = "scrGreen";
            this.scrGreen.Size = new System.Drawing.Size(258, 14);
            this.scrGreen.TabIndex = 9;
            this.scrGreen.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrColorComponent_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Green:";
            // 
            // scrBlue
            // 
            this.scrBlue.Location = new System.Drawing.Point(54, 50);
            this.scrBlue.Maximum = 264;
            this.scrBlue.Name = "scrBlue";
            this.scrBlue.Size = new System.Drawing.Size(258, 14);
            this.scrBlue.TabIndex = 11;
            this.scrBlue.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrColorComponent_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Blue:";
            // 
            // scrBright
            // 
            this.scrBright.Location = new System.Drawing.Point(54, 67);
            this.scrBright.Maximum = 264;
            this.scrBright.Name = "scrBright";
            this.scrBright.Size = new System.Drawing.Size(258, 14);
            this.scrBright.TabIndex = 13;
            this.scrBright.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrColorComponent_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Bright:";
            // 
            // howto_color_tone_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 497);
            this.Controls.Add(this.scrBright);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.scrBlue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.scrGreen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.scrRed);
            this.Controls.Add(this.picColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picToned);
            this.Controls.Add(this.picOriginal);
            this.Name = "howto_color_tone_Form1";
            this.Text = "howto_color_tone";
            this.Load += new System.EventHandler(this.howto_color_tone_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picToned)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picToned;
        private System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picColor;
        private System.Windows.Forms.HScrollBar scrRed;
        private System.Windows.Forms.HScrollBar scrGreen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.HScrollBar scrBlue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.HScrollBar scrBright;
        private System.Windows.Forms.Label label4;
    }
}

