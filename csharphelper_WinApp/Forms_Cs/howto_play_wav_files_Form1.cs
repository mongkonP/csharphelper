using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Media;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_play_wav_files_Form1:Form
  { 


        public howto_play_wav_files_Form1()
        {
            InitializeComponent();
        }

        // The player making the current sound.
        private SoundPlayer Player = null;

        // Turn on the appropriate wav file.
        private void radNo_Click(object sender, EventArgs e)
        {
            PlayWav(null, false);
        }

        private void radBees_Click(object sender, EventArgs e)
        {
            PlayWav("Bees.wav", true);
        }

        private void radChicks_Click(object sender, EventArgs e)
        {
            PlayWav("Chicks.wav", true);
        }

        private void radDog_Click(object sender, EventArgs e)
        {
            PlayWav("Dog.wav", false);
        }

        private void radFrog_Click(object sender, EventArgs e)
        {
            PlayWav("Frog.wav", false);
        }

        // Dispose of the current player and
        // play the indicated WAV file.
        private void PlayWav(string filename, bool play_looping)
        {
            // Stop the player if it is running.
            if (Player != null)
            {
                Player.Stop();
                Player.Dispose();
                Player = null;
            }

            // If we have no file name, we're done.
            if (filename == null) return;
            if (filename.Length == 0) return;

            // Make the new player for the WAV file.
            Player = new SoundPlayer(filename);

            // Play.
            if (play_looping)
                Player.PlayLooping();
            else
                Player.Play();
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
            this.radNo = new System.Windows.Forms.RadioButton();
            this.radFrog = new System.Windows.Forms.RadioButton();
            this.radDog = new System.Windows.Forms.RadioButton();
            this.radChicks = new System.Windows.Forms.RadioButton();
            this.radBees = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // radNo
            // 
            this.radNo.Image = Properties.Resources.No;
            this.radNo.Location = new System.Drawing.Point(12, 19);
            this.radNo.Name = "radNo";
            this.radNo.Size = new System.Drawing.Size(100, 93);
            this.radNo.TabIndex = 0;
            this.radNo.TabStop = true;
            this.radNo.UseVisualStyleBackColor = true;
            this.radNo.Click += new System.EventHandler(this.radNo_Click);
            // 
            // radFrog
            // 
            this.radFrog.AutoSize = true;
            this.radFrog.Image = Properties.Resources.Frog;
            this.radFrog.Location = new System.Drawing.Point(188, 136);
            this.radFrog.Name = "radFrog";
            this.radFrog.Size = new System.Drawing.Size(112, 66);
            this.radFrog.TabIndex = 4;
            this.radFrog.TabStop = true;
            this.radFrog.UseVisualStyleBackColor = true;
            this.radFrog.Click += new System.EventHandler(this.radFrog_Click);
            // 
            // radDog
            // 
            this.radDog.AutoSize = true;
            this.radDog.Image = Properties.Resources.Dog;
            this.radDog.Location = new System.Drawing.Point(63, 122);
            this.radDog.Name = "radDog";
            this.radDog.Size = new System.Drawing.Size(104, 94);
            this.radDog.TabIndex = 3;
            this.radDog.TabStop = true;
            this.radDog.UseVisualStyleBackColor = true;
            this.radDog.Click += new System.EventHandler(this.radDog_Click);
            // 
            // radChicks
            // 
            this.radChicks.AutoSize = true;
            this.radChicks.Image = Properties.Resources.Chicks;
            this.radChicks.Location = new System.Drawing.Point(238, 12);
            this.radChicks.Name = "radChicks";
            this.radChicks.Size = new System.Drawing.Size(114, 106);
            this.radChicks.TabIndex = 2;
            this.radChicks.TabStop = true;
            this.radChicks.UseVisualStyleBackColor = true;
            this.radChicks.Click += new System.EventHandler(this.radChicks_Click);
            // 
            // radBees
            // 
            this.radBees.AutoSize = true;
            this.radBees.Image = Properties.Resources.Bees;
            this.radBees.Location = new System.Drawing.Point(118, 15);
            this.radBees.Name = "radBees";
            this.radBees.Size = new System.Drawing.Size(114, 101);
            this.radBees.TabIndex = 1;
            this.radBees.TabStop = true;
            this.radBees.UseVisualStyleBackColor = true;
            this.radBees.Click += new System.EventHandler(this.radBees_Click);
            // 
            // howto_play_wav_files_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 224);
            this.Controls.Add(this.radNo);
            this.Controls.Add(this.radFrog);
            this.Controls.Add(this.radDog);
            this.Controls.Add(this.radChicks);
            this.Controls.Add(this.radBees);
            this.Name = "howto_play_wav_files_Form1";
            this.Text = "howto_play_wav_files";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radBees;
        private System.Windows.Forms.RadioButton radChicks;
        private System.Windows.Forms.RadioButton radFrog;
        private System.Windows.Forms.RadioButton radDog;
        private System.Windows.Forms.RadioButton radNo;
    }
}

