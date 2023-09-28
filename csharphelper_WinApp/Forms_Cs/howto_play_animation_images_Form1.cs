using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_play_animation_images_Form1:Form
  { 


        public howto_play_animation_images_Form1()
        {
            InitializeComponent();
        }

        // The frame images.
        private Bitmap[] Frames;

        // The index of the current frame.
        private int FrameNum = 0;

        // Load the images.
        private void howto_play_animation_images_Form1_Load(object sender, EventArgs e)
        {
            // Load the frames.
            Frames = new Bitmap[18];
            for (int i = 0; i < 18; i++)
            {
                Frames[i] = new Bitmap("Frame" + i + ".png");
            }

            // Display the first frame.
            picFrame.Image = Frames[FrameNum];

            // Size the form to fit.
            ClientSize = new Size(
                picFrame.Right + picFrame.Left,
                picFrame.Bottom + picFrame.Left);
        }

        // Set the delay per frame.
        private void hscrFps_Scroll(object sender, ScrollEventArgs e)
        {
            tmrNextFrame.Interval = 1000 / hscrFps.Value;
            lblFps.Text = hscrFps.Value.ToString();
        }

        // Start or stop the animation.
        private void btnStartStop_Click(object sender, EventArgs e)
        {
            tmrNextFrame.Enabled = !tmrNextFrame.Enabled;
            if (tmrNextFrame.Enabled) btnStartStop.Text = "Stop";
            else btnStartStop.Text = "Start";
        }

        // Display the next image.
        private void tmrNextFrame_Tick(object sender, EventArgs e)
        {
            FrameNum = ++FrameNum % Frames.Length;
            picFrame.Image = Frames[FrameNum];
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
            this.picFrame = new System.Windows.Forms.PictureBox();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tmrNextFrame = new System.Windows.Forms.Timer(this.components);
            this.lblFps = new System.Windows.Forms.Label();
            this.hscrFps = new System.Windows.Forms.HScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.picFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // picFrame
            // 
            this.picFrame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFrame.Location = new System.Drawing.Point(12, 58);
            this.picFrame.Name = "picFrame";
            this.picFrame.Size = new System.Drawing.Size(100, 50);
            this.picFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picFrame.TabIndex = 9;
            this.picFrame.TabStop = false;
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(12, 29);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(75, 23);
            this.btnStartStop.TabIndex = 8;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "FPS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tmrNextFrame
            // 
            this.tmrNextFrame.Interval = 20;
            this.tmrNextFrame.Tick += new System.EventHandler(this.tmrNextFrame_Tick);
            // 
            // lblFps
            // 
            this.lblFps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFps.Location = new System.Drawing.Point(286, 9);
            this.lblFps.Name = "lblFps";
            this.lblFps.Size = new System.Drawing.Size(30, 17);
            this.lblFps.TabIndex = 7;
            this.lblFps.Text = "50";
            this.lblFps.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hscrFps
            // 
            this.hscrFps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hscrFps.Location = new System.Drawing.Point(42, 9);
            this.hscrFps.Maximum = 109;
            this.hscrFps.Minimum = 1;
            this.hscrFps.Name = "hscrFps";
            this.hscrFps.Size = new System.Drawing.Size(241, 17);
            this.hscrFps.TabIndex = 5;
            this.hscrFps.Value = 50;
            this.hscrFps.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hscrFps_Scroll);
            // 
            // howto_play_animation_images_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 210);
            this.Controls.Add(this.picFrame);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFps);
            this.Controls.Add(this.hscrFps);
            this.Name = "howto_play_animation_images_Form1";
            this.Text = "howto_play_animation_images";
            this.Load += new System.EventHandler(this.howto_play_animation_images_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picFrame;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer tmrNextFrame;
        private System.Windows.Forms.Label lblFps;
        private System.Windows.Forms.HScrollBar hscrFps;
    }
}

