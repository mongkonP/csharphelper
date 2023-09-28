using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Text;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_captcha2_Form1:Form
  { 


        public howto_captcha2_Form1()
        {
            InitializeComponent();
        }

        private void cmdDraw_Click(object sender, EventArgs e)
        {
            string txt = txtSource.Text;
            using (Font the_font = new Font("Times New Roman", 30))
            {
                picCaptcha.Image = MakeCaptchaImage2(txt,
                    picCaptcha.ClientSize.Width,
                    picCaptcha.ClientSize.Height,
                    the_font, Brushes.Blue);
            }
        }

        private Random Rand = new Random();

        // Draw the words with letters overlapping each other.
        private Bitmap MakeCaptchaImage2(string txt, int wid, int hgt, Font the_font, Brush the_brush)
        {
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                int x = 0;
                foreach (char ch in txt.ToCharArray())
                {
                    SizeF ch_size = gr.MeasureString(ch.ToString(), the_font);
                    int y = (int)(Rand.NextDouble() * (hgt - ch_size.Height));
                    gr.DrawString(ch.ToString(), the_font, the_brush, x, y);
                    x += (int)(ch_size.Width * 0.35);
                }
            }

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
            this.cmdDraw.TabIndex = 15;
            this.cmdDraw.Text = "Draw";
            this.cmdDraw.Click += new System.EventHandler(this.cmdDraw_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 18);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(31, 13);
            this.Label1.TabIndex = 14;
            this.Label1.Text = "Text:";
            // 
            // txtSource
            // 
            this.txtSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSource.Location = new System.Drawing.Point(49, 15);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(153, 20);
            this.txtSource.TabIndex = 13;
            this.txtSource.Text = "CSharpHelper";
            // 
            // picCaptcha
            // 
            this.picCaptcha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCaptcha.BackColor = System.Drawing.Color.White;
            this.picCaptcha.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCaptcha.Location = new System.Drawing.Point(12, 42);
            this.picCaptcha.Name = "picCaptcha";
            this.picCaptcha.Size = new System.Drawing.Size(260, 75);
            this.picCaptcha.TabIndex = 12;
            this.picCaptcha.TabStop = false;
            // 
            // howto_captcha2_Form1
            // 
            this.AcceptButton = this.cmdDraw;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 129);
            this.Controls.Add(this.cmdDraw);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.picCaptcha);
            this.Name = "howto_captcha2_Form1";
            this.Text = "howto_captcha2";
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

