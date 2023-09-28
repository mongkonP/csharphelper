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
     public partial class howto_captcha_Form1:Form
  { 


        public howto_captcha_Form1()
        {
            InitializeComponent();
        }

        private Random Rand = new Random();

        private void cmdDraw_Click(object sender, EventArgs e)
        {
            string txt = txtSource.Text;
            Bitmap bm = MakeCaptchaImge(txt,
                50, 70,
                picCaptcha.ClientSize.Width,
                picCaptcha.ClientSize.Height);
            picCaptcha.Image = bm;
        }

        // Make a captcha image for the text.
        private Bitmap MakeCaptchaImge(string txt, int min_size, int max_size, int wid, int hgt)
        {
            // Make the bitmap and associated Graphics object.
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.Clear(Color.White);

                // See how much room is available for each character.
                int ch_wid = (int)(wid / txt.Length);

                // Draw each character.
                for (int i = 0; i < txt.Length; i++)
                {
                    float font_size = Rand.Next(min_size, max_size);
                    using (Font the_font = new Font("Times New Roman", font_size, FontStyle.Bold))
                    {
                        DrawCharacter(txt.Substring(i, 1), gr,
                            the_font, i * ch_wid, ch_wid, wid, hgt);
                    }
                }
            }

            return bm;
        }

        // Draw a deformed character at this position.
        private int PreviousAngle = 0;
        private void DrawCharacter(string txt, Graphics gr,
            Font the_font, int X, int ch_wid, int wid, int hgt)
        {
            // Center the text.
            using (StringFormat string_format = new StringFormat())
            {
                string_format.Alignment = StringAlignment.Center;
                string_format.LineAlignment = StringAlignment.Center;
                RectangleF rectf = new RectangleF(X, 0, ch_wid, hgt);

                // Convert the text into a path.
                using (GraphicsPath graphics_path = new GraphicsPath())
                {
                    graphics_path.AddString(txt,
                        the_font.FontFamily, (int)(Font.Style),
                        the_font.Size, rectf, string_format);

                    // Make random warping parameters.
                    float x1 = (float)(X + Rand.Next(ch_wid) / 2);
                    float y1 = (float)(Rand.Next(hgt) / 2);
                    float x2 = (float)(X + ch_wid / 2 + Rand.Next(ch_wid) / 2);
                    float y2 = (float)(hgt / 2 + Rand.Next(hgt) / 2);
                    PointF[] pts = {
                    new PointF(
                        (float)(X + Rand.Next(ch_wid) / 4),
                        (float)(Rand.Next(hgt) / 4)),
                    new PointF(
                        (float)(X + ch_wid - Rand.Next(ch_wid) / 4),
                        (float)(Rand.Next(hgt) / 4)),
                    new PointF(
                        (float)(X + Rand.Next(ch_wid) / 4),
                        (float)(hgt - Rand.Next(hgt) / 4)),
                    new PointF(
                        (float)(X + ch_wid - Rand.Next(ch_wid) / 4),
                        (float)(hgt - Rand.Next(hgt) / 4))
                };
                    Matrix mat = new Matrix();
                    graphics_path.Warp(pts, rectf, mat,
                        WarpMode.Perspective, 0);

                    // Rotate a bit randomly.
                    float dx = (float)(X + ch_wid / 2);
                    float dy = (float)(hgt / 2);
                    gr.TranslateTransform(-dx, -dy, MatrixOrder.Append);
                    int angle = PreviousAngle;
                    do
                    {
                        angle = Rand.Next(-30, 30);
                    } while (Math.Abs(angle - PreviousAngle) < 20);
                    PreviousAngle = angle;
                    gr.RotateTransform(angle, MatrixOrder.Append);
                    gr.TranslateTransform(dx, dy, MatrixOrder.Append);

                    // Draw the text.
                    gr.FillPath(Brushes.Blue, graphics_path);
                    gr.ResetTransform();
                }
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
            this.cmdDraw = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.picCaptcha = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCaptcha)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdDraw
            // 
            this.cmdDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDraw.Location = new System.Drawing.Point(208, 12);
            this.cmdDraw.Name = "cmdDraw";
            this.cmdDraw.Size = new System.Drawing.Size(64, 24);
            this.cmdDraw.TabIndex = 11;
            this.cmdDraw.Text = "Draw";
            this.cmdDraw.Click += new System.EventHandler(this.cmdDraw_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 18);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(31, 13);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "Text:";
            // 
            // txtSource
            // 
            this.txtSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSource.Location = new System.Drawing.Point(48, 15);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(154, 20);
            this.txtSource.TabIndex = 9;
            this.txtSource.Text = "CSharpHelper";
            // 
            // picCaptcha
            // 
            this.picCaptcha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCaptcha.BackColor = System.Drawing.Color.White;
            this.picCaptcha.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCaptcha.Location = new System.Drawing.Point(12, 41);
            this.picCaptcha.Name = "picCaptcha";
            this.picCaptcha.Size = new System.Drawing.Size(260, 111);
            this.picCaptcha.TabIndex = 8;
            this.picCaptcha.TabStop = false;
            // 
            // howto_captcha_Form1
            // 
            this.AcceptButton = this.cmdDraw;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 164);
            this.Controls.Add(this.cmdDraw);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.picCaptcha);
            this.Name = "howto_captcha_Form1";
            this.Text = "howto_captcha";
            ((System.ComponentModel.ISupportInitialize)(this.picCaptcha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button cmdDraw;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtSource;
        internal System.Windows.Forms.PictureBox picCaptcha;
    }
}

