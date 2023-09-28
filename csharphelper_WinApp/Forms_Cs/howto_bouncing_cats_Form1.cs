using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

using howto_bouncing_cats;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_bouncing_cats_Form1:Form
  { 


        public howto_bouncing_cats_Form1()
        {
            InitializeComponent();
        }

        private List<ImageSprite> Sprites =
            new List<ImageSprite>();

        private void howto_bouncing_cats_Form1_Load(object sender, EventArgs e)
        {
            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                float angle = rand.Next(-360, 360);
                float dangle = rand.Next(-180, 180);
                float scale = rand.Next(2, 5) / 20f;
                Bitmap bm = ResizeImage(Properties.Resources.cat, scale);
                float rx = bm.Width / 2f;
                float ry = bm.Height / 2f;
                PointF center = new PointF(
                    rand.Next((int)rx, picCanvas.ClientSize.Width - (int)rx),
                    rand.Next((int)ry, picCanvas.ClientSize.Height - (int)ry));
                float vx = rand.Next(10, 50);
                if (rand.Next(0, 2) == 1) vx = -vx;
                float vy = rand.Next(10, 50);
                if (rand.Next(0, 2) == 1) vy = -vy;
                PointF velocity = new PointF(vx, vy);

                Sprites.Add(new ImageSprite(angle, dangle, center, velocity, bm));                    
            }

            LastTime = DateTime.Now;
            tmrFrame.Enabled = true;
        }

        private Bitmap ResizeImage(Bitmap bm, float scale)
        {
            int width = (int)(bm.Width * scale);
            int height = (int)(bm.Height * scale);
            Bitmap result_bm = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(result_bm))
            {
                PointF[] dest_points =
                {
                    new PointF(0, 0),
                    new PointF(width, 0),
                    new PointF(0, height),
                };
                RectangleF src_rect = new RectangleF(
                    0, 0,
                    Properties.Resources.cat.Width,
                    Properties.Resources.cat.Height);
                gr.DrawImage(Properties.Resources.cat,
                    dest_points, src_rect, GraphicsUnit.Pixel);
            }
            return result_bm;
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.High;
            foreach (ImageSprite sprite in Sprites)
            {
                sprite.Draw(e.Graphics);
            }
        }

        private DateTime LastTime;

        private void tmrFrame_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            float elapsed = (float)(now - LastTime).TotalSeconds;

            foreach (ImageSprite sprite in Sprites)
            {
                sprite.Move(picCanvas.Bounds, elapsed);
            }
            LastTime = now;
            picCanvas.Refresh();
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
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.tmrFrame = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Image = Properties.Resources.stars;
            this.picCanvas.Location = new System.Drawing.Point(12, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(460, 337);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // tmrFrame
            // 
            this.tmrFrame.Interval = 50;
            this.tmrFrame.Tick += new System.EventHandler(this.tmrFrame_Tick);
            // 
            // howto_bouncing_cats_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_bouncing_cats_Form1";
            this.Text = "howto_bouncing_cats";
            this.Load += new System.EventHandler(this.howto_bouncing_cats_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Timer tmrFrame;
    }
}

