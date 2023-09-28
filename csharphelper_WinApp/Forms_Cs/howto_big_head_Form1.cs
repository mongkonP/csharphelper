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
     public partial class howto_big_head_Form1:Form
  { 


        public howto_big_head_Form1()
        {
            InitializeComponent();
        }

        private Bitmap BmHead, BmBody, BmCombined;
        private PointF Chin, Origin;

        private void howto_big_head_Form1_Load(object sender, EventArgs e)
        {
            // The body is scaled by 0.5 so the head looks big.
            const float BodyScale = 0.5f;

            // Make the body image.
            Bitmap bm_body = (Bitmap)picBody.Image;
            int body_wid = (int)(bm_body.Width * BodyScale);
            int body_hgt = (int)(bm_body.Height * BodyScale);
            BmBody = new Bitmap(body_wid, body_hgt);
            using (Graphics gr = Graphics.FromImage(BmBody))
            {
                Point[] dest_points =
                {
                    new Point(0, 0),
                    new Point(body_wid, 0),
                    new Point(0, body_hgt),
                };
                gr.DrawImage(bm_body, dest_points);
            }

            // Make the head image, using the upper left
            // corner's color as the transparent color.
            BmHead = (Bitmap)picHead.Image;
            Color transparent = BmHead.GetPixel(0, 0);
            BmHead.MakeTransparent(transparent);

            // The tip of chin is at (273, 383) in scaled coordinates.
            Chin = new PointF(273 * BodyScale, 383 * BodyScale);

            // Origin is where we need to draw the upper left
            // corner of the head to place it on the tip of the chin.
            Origin = new PointF(
                Chin.X - BmHead.Width / 2,
                Chin.Y - BmHead.Height + 15);

            // Make the combined image.
            BmCombined = (Bitmap)BmBody.Clone();
            using (Graphics gr = Graphics.FromImage(BmCombined))
            {
                gr.DrawImage(BmHead, Origin);
            }
            picBigHead.Image = BmCombined;

            // Size the form to fit.
            ClientSize = new Size(
                picBigHead.Right + picBigHead.Left,
                picBigHead.Bottom + picBigHead.Top);
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
            this.picBigHead = new System.Windows.Forms.PictureBox();
            this.picHead = new System.Windows.Forms.PictureBox();
            this.picBody = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBigHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBody)).BeginInit();
            this.SuspendLayout();
            // 
            // picBigHead
            // 
            this.picBigHead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBigHead.Location = new System.Drawing.Point(12, 12);
            this.picBigHead.Name = "picBigHead";
            this.picBigHead.Size = new System.Drawing.Size(183, 270);
            this.picBigHead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBigHead.TabIndex = 5;
            this.picBigHead.TabStop = false;
            // 
            // picHead
            // 
            this.picHead.Image = Properties.Resources.Donald_Trump_Head;
            this.picHead.Location = new System.Drawing.Point(201, 12);
            this.picHead.Name = "picHead";
            this.picHead.Size = new System.Drawing.Size(161, 202);
            this.picHead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picHead.TabIndex = 4;
            this.picHead.TabStop = false;
            this.picHead.Visible = false;
            // 
            // picBody
            // 
            this.picBody.Image = Properties.Resources.Donald_Trump_Body;
            this.picBody.Location = new System.Drawing.Point(92, 25);
            this.picBody.Name = "picBody";
            this.picBody.Size = new System.Drawing.Size(517, 600);
            this.picBody.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBody.TabIndex = 3;
            this.picBody.TabStop = false;
            this.picBody.Visible = false;
            // 
            // howto_big_head_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.picBigHead);
            this.Controls.Add(this.picHead);
            this.Controls.Add(this.picBody);
            this.Name = "howto_big_head_Form1";
            this.Text = "howto_big_head";
            this.Load += new System.EventHandler(this.howto_big_head_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBigHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBody)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBigHead;
        private System.Windows.Forms.PictureBox picHead;
        private System.Windows.Forms.PictureBox picBody;
    }
}

