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
     public partial class howto_play_tone_Form1:Form
  { 


        public howto_play_tone_Form1()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            int freq = int.Parse(txtFrequency.Text);
            int duration = int.Parse(txtDuration.Text);

            System.Console.Beep(freq, duration);
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
            this.btnPlay = new System.Windows.Forms.Button();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtFrequency = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(188, 17);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 9;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(108, 33);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(64, 20);
            this.txtDuration.TabIndex = 8;
            this.txtDuration.Text = "500";
            this.txtDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(12, 33);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(69, 13);
            this.Label2.TabIndex = 7;
            this.Label2.Text = "Duration (ms)";
            // 
            // txtFrequency
            // 
            this.txtFrequency.Location = new System.Drawing.Point(108, 9);
            this.txtFrequency.Name = "txtFrequency";
            this.txtFrequency.Size = new System.Drawing.Size(64, 20);
            this.txtFrequency.TabIndex = 6;
            this.txtFrequency.Text = "1000";
            this.txtFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(79, 13);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "Frequency (Hz)";
            // 
            // howto_play_tone_Form1
            // 
            this.AcceptButton = this.btnPlay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 64);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtFrequency);
            this.Controls.Add(this.Label1);
            this.Name = "howto_play_tone_Form1";
            this.Text = "howto_play_tone";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnPlay;
        internal System.Windows.Forms.TextBox txtDuration;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtFrequency;
        internal System.Windows.Forms.Label Label1;
    }
}

