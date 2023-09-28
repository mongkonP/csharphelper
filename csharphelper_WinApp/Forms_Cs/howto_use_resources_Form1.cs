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
     public partial class howto_use_resources_Form1:Form
  { 


        public howto_use_resources_Form1()
        {
            InitializeComponent();
        }

        private void radMercury_CheckedChanged(object sender, EventArgs e)
        {
            picPlanet.Image = Properties.Resources.Mercury;
        }

        private void radVenus_CheckedChanged(object sender, EventArgs e)
        {
            picPlanet.Image = Properties.Resources.Venus;
        }

        private void radEarth_CheckedChanged(object sender, EventArgs e)
        {
            picPlanet.Image = Properties.Resources.Earth;
        }

        private void radMars_CheckedChanged(object sender, EventArgs e)
        {
            picPlanet.Image = Properties.Resources.Mars;
        }

        private void radJupiter_CheckedChanged(object sender, EventArgs e)
        {
            picPlanet.Image = Properties.Resources.Jupiter;
        }

        private void radSaturn_CheckedChanged(object sender, EventArgs e)
        {
            picPlanet.Image = Properties.Resources.Saturn;
        }

        private void radUranus_CheckedChanged(object sender, EventArgs e)
        {
            picPlanet.Image = Properties.Resources.Uranus;
        }

        private void radNeptune_CheckedChanged(object sender, EventArgs e)
        {
            picPlanet.Image = Properties.Resources.Neptune;
        }

        private void radPulto_CheckedChanged(object sender, EventArgs e)
        {
            picPlanet.Image = Properties.Resources.Pluto;
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
            this.radMercury = new System.Windows.Forms.RadioButton();
            this.radVenus = new System.Windows.Forms.RadioButton();
            this.radMars = new System.Windows.Forms.RadioButton();
            this.radEarth = new System.Windows.Forms.RadioButton();
            this.radNeptune = new System.Windows.Forms.RadioButton();
            this.radUranus = new System.Windows.Forms.RadioButton();
            this.radSaturn = new System.Windows.Forms.RadioButton();
            this.radJupiter = new System.Windows.Forms.RadioButton();
            this.radPulto = new System.Windows.Forms.RadioButton();
            this.picPlanet = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPlanet)).BeginInit();
            this.SuspendLayout();
            // 
            // radMercury
            // 
            this.radMercury.AutoSize = true;
            this.radMercury.Location = new System.Drawing.Point(12, 12);
            this.radMercury.Name = "radMercury";
            this.radMercury.Size = new System.Drawing.Size(63, 17);
            this.radMercury.TabIndex = 0;
            this.radMercury.TabStop = true;
            this.radMercury.Text = "Mercury";
            this.radMercury.UseVisualStyleBackColor = true;
            this.radMercury.CheckedChanged += new System.EventHandler(this.radMercury_CheckedChanged);
            // 
            // radVenus
            // 
            this.radVenus.AutoSize = true;
            this.radVenus.Location = new System.Drawing.Point(12, 35);
            this.radVenus.Name = "radVenus";
            this.radVenus.Size = new System.Drawing.Size(55, 17);
            this.radVenus.TabIndex = 1;
            this.radVenus.TabStop = true;
            this.radVenus.Text = "Venus";
            this.radVenus.UseVisualStyleBackColor = true;
            this.radVenus.CheckedChanged += new System.EventHandler(this.radVenus_CheckedChanged);
            // 
            // radMars
            // 
            this.radMars.AutoSize = true;
            this.radMars.Location = new System.Drawing.Point(12, 81);
            this.radMars.Name = "radMars";
            this.radMars.Size = new System.Drawing.Size(48, 17);
            this.radMars.TabIndex = 3;
            this.radMars.TabStop = true;
            this.radMars.Text = "Mars";
            this.radMars.UseVisualStyleBackColor = true;
            this.radMars.CheckedChanged += new System.EventHandler(this.radMars_CheckedChanged);
            // 
            // radEarth
            // 
            this.radEarth.AutoSize = true;
            this.radEarth.Location = new System.Drawing.Point(12, 58);
            this.radEarth.Name = "radEarth";
            this.radEarth.Size = new System.Drawing.Size(50, 17);
            this.radEarth.TabIndex = 2;
            this.radEarth.TabStop = true;
            this.radEarth.Text = "Earth";
            this.radEarth.UseVisualStyleBackColor = true;
            this.radEarth.CheckedChanged += new System.EventHandler(this.radEarth_CheckedChanged);
            // 
            // radNeptune
            // 
            this.radNeptune.AutoSize = true;
            this.radNeptune.Location = new System.Drawing.Point(12, 173);
            this.radNeptune.Name = "radNeptune";
            this.radNeptune.Size = new System.Drawing.Size(66, 17);
            this.radNeptune.TabIndex = 7;
            this.radNeptune.TabStop = true;
            this.radNeptune.Text = "Neptune";
            this.radNeptune.UseVisualStyleBackColor = true;
            this.radNeptune.CheckedChanged += new System.EventHandler(this.radNeptune_CheckedChanged);
            // 
            // radUranus
            // 
            this.radUranus.AutoSize = true;
            this.radUranus.Location = new System.Drawing.Point(12, 150);
            this.radUranus.Name = "radUranus";
            this.radUranus.Size = new System.Drawing.Size(59, 17);
            this.radUranus.TabIndex = 6;
            this.radUranus.TabStop = true;
            this.radUranus.Text = "Uranus";
            this.radUranus.UseVisualStyleBackColor = true;
            this.radUranus.CheckedChanged += new System.EventHandler(this.radUranus_CheckedChanged);
            // 
            // radSaturn
            // 
            this.radSaturn.AutoSize = true;
            this.radSaturn.Location = new System.Drawing.Point(12, 127);
            this.radSaturn.Name = "radSaturn";
            this.radSaturn.Size = new System.Drawing.Size(56, 17);
            this.radSaturn.TabIndex = 5;
            this.radSaturn.TabStop = true;
            this.radSaturn.Text = "Saturn";
            this.radSaturn.UseVisualStyleBackColor = true;
            this.radSaturn.CheckedChanged += new System.EventHandler(this.radSaturn_CheckedChanged);
            // 
            // radJupiter
            // 
            this.radJupiter.AutoSize = true;
            this.radJupiter.Location = new System.Drawing.Point(12, 104);
            this.radJupiter.Name = "radJupiter";
            this.radJupiter.Size = new System.Drawing.Size(56, 17);
            this.radJupiter.TabIndex = 4;
            this.radJupiter.TabStop = true;
            this.radJupiter.Text = "Jupiter";
            this.radJupiter.UseVisualStyleBackColor = true;
            this.radJupiter.CheckedChanged += new System.EventHandler(this.radJupiter_CheckedChanged);
            // 
            // radPulto
            // 
            this.radPulto.AutoSize = true;
            this.radPulto.Location = new System.Drawing.Point(12, 196);
            this.radPulto.Name = "radPulto";
            this.radPulto.Size = new System.Drawing.Size(49, 17);
            this.radPulto.TabIndex = 8;
            this.radPulto.TabStop = true;
            this.radPulto.Text = "Pluto";
            this.radPulto.UseVisualStyleBackColor = true;
            this.radPulto.CheckedChanged += new System.EventHandler(this.radPulto_CheckedChanged);
            // 
            // picPlanet
            // 
            this.picPlanet.Location = new System.Drawing.Point(81, 12);
            this.picPlanet.Name = "picPlanet";
            this.picPlanet.Size = new System.Drawing.Size(191, 200);
            this.picPlanet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPlanet.TabIndex = 9;
            this.picPlanet.TabStop = false;
            // 
            // howto_use_resources_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 224);
            this.Controls.Add(this.picPlanet);
            this.Controls.Add(this.radPulto);
            this.Controls.Add(this.radNeptune);
            this.Controls.Add(this.radUranus);
            this.Controls.Add(this.radSaturn);
            this.Controls.Add(this.radJupiter);
            this.Controls.Add(this.radMars);
            this.Controls.Add(this.radEarth);
            this.Controls.Add(this.radVenus);
            this.Controls.Add(this.radMercury);
            this.Name = "howto_use_resources_Form1";
            this.Text = "howto_use_resources";
            ((System.ComponentModel.ISupportInitialize)(this.picPlanet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radMercury;
        private System.Windows.Forms.RadioButton radVenus;
        private System.Windows.Forms.RadioButton radMars;
        private System.Windows.Forms.RadioButton radEarth;
        private System.Windows.Forms.RadioButton radNeptune;
        private System.Windows.Forms.RadioButton radUranus;
        private System.Windows.Forms.RadioButton radSaturn;
        private System.Windows.Forms.RadioButton radJupiter;
        private System.Windows.Forms.RadioButton radPulto;
        private System.Windows.Forms.PictureBox picPlanet;
    }
}

