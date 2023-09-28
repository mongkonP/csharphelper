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
     public partial class howto_transparent_antialiasing_Form1:Form
  { 


        public howto_transparent_antialiasing_Form1()
        {
            InitializeComponent();
        }

        private Bitmap FgOnWhite, FgOnTransparent;

        // Draw the smiley bitmaps with transparent backgrounds.
        private void howto_transparent_antialiasing_Form1_Load(object sender, EventArgs e)
        {
            int wid = pictureBox1.ClientSize.Width;
            int hgt = pictureBox1.ClientSize.Height;

            // Draw with a white background.
            FgOnWhite = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(FgOnWhite))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.Clear(Color.White);
                DrawSmiley(gr, pictureBox1.ClientRectangle, 10);

                // Make the white pixels transparent.
                FgOnWhite.MakeTransparent(Color.White);
            }

            // Draw with a transparent background.
            FgOnTransparent = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(FgOnTransparent))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.Clear(Color.Transparent);
                DrawSmiley(gr, pictureBox1.ClientRectangle, 10);
            }
        }

        // Draw a smiley face in the rectangle.
        private void DrawSmiley(Graphics gr,
            Rectangle rect, int wid)
        {
            rect.Inflate(-4, -4);
            using (Pen pen = new Pen(Color.Black, wid))
            {
                // Face.
                Rectangle r = new Rectangle(
                    rect.Left + wid / 2, rect.Top + wid / 2,
                    rect.Width - wid, rect.Height - wid);
                gr.FillEllipse(Brushes.Yellow, r);
                gr.DrawEllipse(pen, r);

                // Smile.
                pen.Width /= 2;
                r.Inflate(-30, -30);
                gr.DrawArc(pen, r, 10, 160);

                // Left eye.
                int eye_wid = (int)(rect.Width * 0.2);
                int eye_hgt = (int)(rect.Height * 0.25);
                Rectangle eye_r = new Rectangle(
                    (int)(rect.Left + rect.Width * 0.25),
                    (int)(rect.Top + rect.Height * 0.20),
                    eye_wid, eye_hgt);
                gr.FillEllipse(Brushes.LightBlue, eye_r);
                gr.DrawEllipse(pen, eye_r);
                Rectangle pupil_r = new Rectangle(
                    eye_r.Left + eye_wid / 2,
                    eye_r.Top + eye_hgt / 4,
                    eye_wid / 2, eye_hgt / 2);
                gr.FillEllipse(Brushes.Black, pupil_r);
                gr.DrawEllipse(pen, pupil_r);

                // Right eye.
                eye_r = new Rectangle(
                    (int)(rect.Right - rect.Width * 0.25) - eye_wid,
                    (int)(rect.Top + rect.Height * 0.20),
                    eye_wid, eye_hgt);
                gr.FillEllipse(Brushes.LightBlue, eye_r);
                gr.DrawEllipse(pen, eye_r);
                pupil_r = new Rectangle(
                    eye_r.Left + eye_wid / 2,
                    eye_r.Top + eye_hgt / 4,
                    eye_wid / 2, eye_hgt / 2);
                gr.FillEllipse(Brushes.Black, pupil_r);
                gr.DrawEllipse(pen, pupil_r);

                // Nose.
                Rectangle nose_r = new Rectangle(
                    (int)(rect.Left + rect.Width / 2) - eye_wid / 2,
                    (int)(rect.Top + rect.Height * 0.45),
                    eye_wid, eye_wid);
                gr.FillEllipse(Brushes.LightGreen, nose_r);
                gr.DrawEllipse(pen, nose_r);
            }
        }

        // Draw the smiley face on the control.
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Blue);
            e.Graphics.DrawImage(FgOnWhite, 0, 0);
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Blue);
            e.Graphics.DrawImage(FgOnTransparent, 0, 0);
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 180);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(198, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(180, 180);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
            // 
            // howto_transparent_antialiasing_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 201);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "howto_transparent_antialiasing_Form1";
            this.Text = "howto_transparent_antialiasing";
            this.Load += new System.EventHandler(this.howto_transparent_antialiasing_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

