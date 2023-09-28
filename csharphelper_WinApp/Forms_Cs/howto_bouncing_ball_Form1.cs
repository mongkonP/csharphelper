using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Media;
using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_bouncing_ball_Form1:Form
  { 


        public howto_bouncing_ball_Form1()
        {
            InitializeComponent();
        }

        // Some drawing parameters.
        private const int BallWidth = 50;
        private const int BallHeight = 50;
        private int BallX, BallY;   // Position.
        private int BallVx, BallVy; // Velocity.

        // Initialize some random stuff.
        private void howto_bouncing_ball_Form1_Load(object sender, EventArgs e)
        {
            // Pick a random start position and velocity.
            Random rnd = new Random();
            BallVx = rnd.Next(1, 4);
            BallVy = rnd.Next(1, 4);
            BallX = rnd.Next(0, ClientSize.Width - BallWidth);
            BallY = rnd.Next(0, ClientSize.Height - BallHeight);

            // Use double buffering to reduce flicker.
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);
            this.UpdateStyles();
        }

        // Update the ball's position, bouncing if necessary.
        private void tmrMoveBall_Tick(object sender, EventArgs e)
        {
            BallX += BallVx;
            if (BallX < 0)
            {
                BallVx = -BallVx;
                Boing();
            } else if (BallX + BallWidth > ClientSize.Width)
            {
                BallVx = -BallVx;
                Boing();
            }

            BallY += BallVy;
            if (BallY < 0)
            {
                BallVy = -BallVy;
                Boing();
            } else if (BallY + BallHeight > ClientSize.Height)
            {
                BallVy = -BallVy;
                Boing();
            }

            Refresh();
        }

        // Play the boing sound file resource.
        private void Boing()
        {
            using (SoundPlayer player = new SoundPlayer(
                Properties.Resources.boing))
            {
                player.Play();
            }
        }

        // Draw the ball at its current location.
        private void howto_bouncing_ball_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(BackColor);
            e.Graphics.FillEllipse(Brushes.Blue, BallX, BallY, BallWidth, BallHeight);
            e.Graphics.DrawEllipse(Pens.Black, BallX, BallY, BallWidth, BallHeight);
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
            this.tmrMoveBall = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrMoveBall
            // 
            this.tmrMoveBall.Enabled = true;
            this.tmrMoveBall.Interval = 10;
            this.tmrMoveBall.Tick += new System.EventHandler(this.tmrMoveBall_Tick);
            // 
            // howto_bouncing_ball_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 270);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "howto_bouncing_ball_Form1";
            this.Text = "howto_bouncing_ball";
            this.Load += new System.EventHandler(this.howto_bouncing_ball_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_bouncing_ball_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Timer tmrMoveBall;
    }
}

