using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

using howto_vector_sprites;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_vector_sprites_Form1:Form
  { 


        public howto_vector_sprites_Form1()
        {
            InitializeComponent();
        }

        // Some drawing parameters.
        private BallSprite[] Sprites;
        private Size FormSize;

        private void howto_vector_sprites_Form1_Load(object sender, EventArgs e)
        {
            // Make random balls.
            Random rand = new Random();
            const int num_balls = 10;
            Sprites = new BallSprite[num_balls];
            for (int i = 0; i < num_balls; i++)
            {
                Sprites[i] = new BallSprite(10, 40,
                    ClientSize.Width, ClientSize.Height,
                    2, 10);
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
            foreach (BallSprite sprite in Sprites) sprite.Move();
            Refresh();
        }

        // Redraw.
        private void howto_vector_sprites_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(BackColor);
            foreach (BallSprite sprite in Sprites) sprite.Draw(e.Graphics);
        }

        // Force all threads to end.
        private void howto_vector_sprites_Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
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
            // howto_vector_sprites_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 167);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "howto_vector_sprites_Form1";
            this.Text = "howto_vector_sprites";
            this.Load += new System.EventHandler(this.howto_vector_sprites_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_vector_sprites_Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrMoveBall;
    }
}

