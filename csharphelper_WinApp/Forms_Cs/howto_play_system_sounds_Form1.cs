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
     public partial class howto_play_system_sounds_Form1:Form
  { 


        public howto_play_system_sounds_Form1()
        {
            InitializeComponent();
        }

        private void btnAsterisk_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void btnBeep_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
        }

        private void btnExclamation_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Exclamation.Play();
        }

        private void btnHand_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Hand.Play();
        }

        private void btnQuestion_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Question.Play();
        }

        private void btnConsoleBeep_Click(object sender, EventArgs e)
        {
            Console.Beep();
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
            this.btnAsterisk = new System.Windows.Forms.Button();
            this.btnBeep = new System.Windows.Forms.Button();
            this.btnHand = new System.Windows.Forms.Button();
            this.btnExclamation = new System.Windows.Forms.Button();
            this.btnConsoleBeep = new System.Windows.Forms.Button();
            this.btnQuestion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAsterisk
            // 
            this.btnAsterisk.Location = new System.Drawing.Point(12, 12);
            this.btnAsterisk.Name = "btnAsterisk";
            this.btnAsterisk.Size = new System.Drawing.Size(90, 30);
            this.btnAsterisk.TabIndex = 0;
            this.btnAsterisk.Text = "Asterisk";
            this.btnAsterisk.UseVisualStyleBackColor = true;
            this.btnAsterisk.Click += new System.EventHandler(this.btnAsterisk_Click);
            // 
            // btnBeep
            // 
            this.btnBeep.Location = new System.Drawing.Point(12, 48);
            this.btnBeep.Name = "btnBeep";
            this.btnBeep.Size = new System.Drawing.Size(90, 30);
            this.btnBeep.TabIndex = 1;
            this.btnBeep.Text = "Beep";
            this.btnBeep.UseVisualStyleBackColor = true;
            this.btnBeep.Click += new System.EventHandler(this.btnBeep_Click);
            // 
            // btnHand
            // 
            this.btnHand.Location = new System.Drawing.Point(12, 120);
            this.btnHand.Name = "btnHand";
            this.btnHand.Size = new System.Drawing.Size(90, 30);
            this.btnHand.TabIndex = 3;
            this.btnHand.Text = "Hand";
            this.btnHand.UseVisualStyleBackColor = true;
            this.btnHand.Click += new System.EventHandler(this.btnHand_Click);
            // 
            // btnExclamation
            // 
            this.btnExclamation.Location = new System.Drawing.Point(12, 84);
            this.btnExclamation.Name = "btnExclamation";
            this.btnExclamation.Size = new System.Drawing.Size(90, 30);
            this.btnExclamation.TabIndex = 2;
            this.btnExclamation.Text = "Exclamation";
            this.btnExclamation.UseVisualStyleBackColor = true;
            this.btnExclamation.Click += new System.EventHandler(this.btnExclamation_Click);
            // 
            // btnConsoleBeep
            // 
            this.btnConsoleBeep.Location = new System.Drawing.Point(182, 12);
            this.btnConsoleBeep.Name = "btnConsoleBeep";
            this.btnConsoleBeep.Size = new System.Drawing.Size(90, 30);
            this.btnConsoleBeep.TabIndex = 5;
            this.btnConsoleBeep.Text = "Console.Beep";
            this.btnConsoleBeep.UseVisualStyleBackColor = true;
            this.btnConsoleBeep.Click += new System.EventHandler(this.btnConsoleBeep_Click);
            // 
            // btnQuestion
            // 
            this.btnQuestion.Location = new System.Drawing.Point(12, 156);
            this.btnQuestion.Name = "btnQuestion";
            this.btnQuestion.Size = new System.Drawing.Size(90, 30);
            this.btnQuestion.TabIndex = 4;
            this.btnQuestion.Text = "Question";
            this.btnQuestion.UseVisualStyleBackColor = true;
            this.btnQuestion.Click += new System.EventHandler(this.btnQuestion_Click);
            // 
            // howto_play_system_sounds_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 198);
            this.Controls.Add(this.btnConsoleBeep);
            this.Controls.Add(this.btnQuestion);
            this.Controls.Add(this.btnHand);
            this.Controls.Add(this.btnExclamation);
            this.Controls.Add(this.btnBeep);
            this.Controls.Add(this.btnAsterisk);
            this.Name = "howto_play_system_sounds_Form1";
            this.Text = "howto_play_system_sounds";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAsterisk;
        private System.Windows.Forms.Button btnBeep;
        private System.Windows.Forms.Button btnHand;
        private System.Windows.Forms.Button btnExclamation;
        private System.Windows.Forms.Button btnConsoleBeep;
        private System.Windows.Forms.Button btnQuestion;
    }
}

