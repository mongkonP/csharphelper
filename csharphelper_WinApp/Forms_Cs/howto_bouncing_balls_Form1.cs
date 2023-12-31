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
     public partial class howto_bouncing_balls_Form1:Form
  { 


        public howto_bouncing_balls_Form1()
        {
            InitializeComponent();
        }

        // Some drawing parameters.
        private Rectangle[] BallLocation;
        private Point[] BallVelocity;
        private Size FormSize;

        // Initialize some random stuff.
        private void howto_bouncing_balls_Form1_Load(object sender, EventArgs e)
        {
            // Make random balls.
            Random rand = new Random();
            const int num_balls = 10;
            BallLocation = new Rectangle[num_balls];
            BallVelocity = new Point[num_balls];
            for (int i = 0; i < num_balls; i++)
            {
                int width = rand.Next(10, 40);
                BallLocation[i] = new Rectangle(
                    rand.Next(0, ClientSize.Width - 2 * width),
                    rand.Next(0, ClientSize.Height - 2 * width),
                    width, width);
                int vx = rand.Next(2, 10);
                int vy = rand.Next(2, 10);
                if (rand.Next(0, 2) == 0) vx = -vx;
                if (rand.Next(0, 2) == 0) vy = -vy;
                BallVelocity[i] = new Point(vx, vy);
            }

            // Save the form's size.
            FormSize = ClientSize;

            // Use double buffering to reduce flicker.
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);
            this.UpdateStyles();
        }

        // Move the balls and refresh.
        private void tmrMoveBall_Tick(object sender, EventArgs e)
        {
            for (int ball_num = 0; ball_num < BallLocation.Length; ball_num++)
            {
                // Move the ball.
                int new_x = BallLocation[ball_num].X + BallVelocity[ball_num].X;
                int new_y = BallLocation[ball_num].Y + BallVelocity[ball_num].Y;
                if (new_x < 0)
                {
                    BallVelocity[ball_num].X = -BallVelocity[ball_num].X;
                    Boing();
                }
                else if (new_x + BallLocation[ball_num].Width > FormSize.Width)
                {
                    BallVelocity[ball_num].X = -BallVelocity[ball_num].X;
                    Boing();
                }
                if (new_y < 0)
                {
                    BallVelocity[ball_num].Y = -BallVelocity[ball_num].Y;
                    Boing();
                }
                else if (new_y + BallLocation[ball_num].Height > FormSize.Height)
                {
                    BallVelocity[ball_num].Y = -BallVelocity[ball_num].Y;
                    Boing();
                }

                BallLocation[ball_num] = new Rectangle(
                    new_x, new_y,
                    BallLocation[ball_num].Width,
                    BallLocation[ball_num].Height);
            }

            Refresh();
        }

        // Draw the ball at its current location.
        private void howto_bouncing_balls_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(BackColor);
            for (int i = 0; i < BallLocation.Length; i++)
            {
                e.Graphics.FillEllipse(Brushes.Blue, BallLocation[i]);
                e.Graphics.DrawEllipse(Pens.Black, BallLocation[i]);
            }
        }

        // Force all threads to end.
        private void howto_bouncing_balls_Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        // Play the boing sound file resource.
        private static void Boing()
        {
            using (SoundPlayer player = new SoundPlayer(
                Properties.Resources.boing))
            {
                player.Play();
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
            this.components = new System.ComponentModel.Container();
            this.tmrMoveBall = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrMoveBall
            // 
            this.tmrMoveBall.Enabled = true;
            this.tmrMoveBall.Interval = 50;
            this.tmrMoveBall.Tick += new System.EventHandler(this.tmrMoveBall_Tick);
            // 
            // howto_bouncing_balls_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 267);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "howto_bouncing_balls_Form1";
            this.Text = "howto_bouncing_balls";
            this.Load += new System.EventHandler(this.howto_bouncing_balls_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_bouncing_balls_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrMoveBall;
    }
}

