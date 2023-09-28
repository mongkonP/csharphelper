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
     public partial class howto_bobblehead_Form1:Form
  { 


        public howto_bobblehead_Form1()
        {
            InitializeComponent();
        }

        private Bitmap BmHead, BmBody, BmCombined;
        private PointF Chin, Origin;
        private float Ar, Aa, Fr, Fa;
        private float T = 0;
        private const float Dampen = 0.95f;

        private void howto_bobblehead_Form1_Load(object sender, EventArgs e)
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

            // Draw the head.
            DrawHead(0, 0);

            // Size the form to fit.
            ClientSize = new Size(
                picBobble.Right + picBobble.Left,
                picBobble.Bottom + picBobble.Top);
        }

        // Start bobbling.
        private Random Rand = new Random();
        private void picBobble_Click(object sender, EventArgs e)
        {
            Ar = Rand.Next(10, 20);
            if (Rand.Next(0, 2) == 0) Ar = -Ar;
            Aa = Rand.Next(10, 20);
            if (Rand.Next(0, 2) == 0) Aa = -Aa;
            Fr = Rand.Next(7, 15) / 10f;
            Fa = Rand.Next(7, 15) / 10f;

            T = 0;
            tmrBobble.Enabled = true;
        }

        // A*Cos(2*pi*f*t)
        private void tmrBobble_Tick(object sender, EventArgs e)
        {
            float r = (float)(Ar * Math.Cos(2 * Math.PI * Fr * T));
            float theta = (float)(Aa * Math.Cos(2 * Math.PI * Fa * T));
            DrawHead(r, theta);

            T += 0.1f;
            Ar *= Dampen;
            Aa *= Dampen;

            if ((Math.Abs(Ar) < 0.1) && (Math.Abs(Aa) < 0.1f))
                tmrBobble.Enabled = false;
        }

        // Draw the head at the indicated position.
        private void DrawHead(float r, float theta)
        {
            BmCombined = (Bitmap)BmBody.Clone();
            using (Graphics gr = Graphics.FromImage(BmCombined))
            {
                gr.TranslateTransform(-Chin.X, -Chin.Y, MatrixOrder.Append);
                gr.RotateTransform(theta, MatrixOrder.Append);
                gr.TranslateTransform(0, r, MatrixOrder.Append);
                gr.TranslateTransform(Chin.X, Chin.Y, MatrixOrder.Append);

                gr.DrawImage(BmHead, Origin);
            }
            picBobble.Image = BmCombined;
            picBobble.Refresh();
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
            this.components = new System.ComponentModel.Container();
            this.picBobble = new System.Windows.Forms.PictureBox();
            this.picHead = new System.Windows.Forms.PictureBox();
            this.picBody = new System.Windows.Forms.PictureBox();
            this.tmrBobble = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picBobble)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBody)).BeginInit();
            this.SuspendLayout();
            // 
            // picBobble
            // 
            this.picBobble.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBobble.Location = new System.Drawing.Point(12, 12);
            this.picBobble.Name = "picBobble";
            this.picBobble.Size = new System.Drawing.Size(183, 270);
            this.picBobble.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBobble.TabIndex = 2;
            this.picBobble.TabStop = false;
            this.picBobble.Click += new System.EventHandler(this.picBobble_Click);
            // 
            // picHead
            // 
            this.picHead.Image = Properties.Resources.Donald_Trump_Head;
            this.picHead.Location = new System.Drawing.Point(201, 12);
            this.picHead.Name = "picHead";
            this.picHead.Size = new System.Drawing.Size(161, 202);
            this.picHead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picHead.TabIndex = 1;
            this.picHead.TabStop = false;
            this.picHead.Visible = false;
            // 
            // picBody
            // 
            this.picBody.Image = Properties.Resources.Donald_Trump;
            this.picBody.Location = new System.Drawing.Point(84, 39);
            this.picBody.Name = "picBody";
            this.picBody.Size = new System.Drawing.Size(517, 600);
            this.picBody.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBody.TabIndex = 0;
            this.picBody.TabStop = false;
            this.picBody.Visible = false;
            // 
            // tmrBobble
            // 
            this.tmrBobble.Interval = 50;
            this.tmrBobble.Tick += new System.EventHandler(this.tmrBobble_Tick);
            // 
            // howto_bobblehead_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.picHead);
            this.Controls.Add(this.picBody);
            this.Controls.Add(this.picBobble);
            this.Name = "howto_bobblehead_Form1";
            this.Text = "howto_bobblehead";
            this.Load += new System.EventHandler(this.howto_bobblehead_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBobble)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBody)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBody;
        private System.Windows.Forms.PictureBox picHead;
        private System.Windows.Forms.PictureBox picBobble;
        private System.Windows.Forms.Timer tmrBobble;
    }
}

