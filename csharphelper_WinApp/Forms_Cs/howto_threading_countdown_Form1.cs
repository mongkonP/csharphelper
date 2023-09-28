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
     public partial class howto_threading_countdown_Form1:Form
  { 


        public howto_threading_countdown_Form1()
        {
            InitializeComponent();
        }

        // The timer.
        System.Threading.Timer TheTimer = null;

        // Initialize information about the event.
        private DateTime EventDate = new DateTime(2017, 4, 1);

        private void howto_threading_countdown_Form1_Load(object sender, EventArgs e)
        {
            // Make the timer start now and tick every 500 ms.
            TheTimer = new System.Threading.Timer(
                this.Tick, null, 0, 500);
        }

        // The timer ticked.
        public void Tick(object info)
        {
            this.Invoke((Action)this.UpdateCountdown);
        }

        // Update the countdown on the UI thread.
        private void UpdateCountdown()
        {
            TimeSpan remaining = EventDate - DateTime.Now;
            if (remaining.TotalSeconds < 1)
            {
                TheTimer.Dispose();
                this.WindowState = FormWindowState.Maximized;
                this.TopMost = true;

                foreach (Control ctl in this.Controls)
                    ctl.Visible = (ctl == lblFinished);

                using (SoundPlayer player = new SoundPlayer(
                    Properties.Resources.tada))
                {
                    player.Play();
                }
            }
            else
            {
                lblDays.Text = remaining.Days + " days";
                lblHours.Text = remaining.Hours + " hours";
                lblMinutes.Text = remaining.Minutes + " minutes";
                lblSeconds.Text = remaining.Seconds + " seconds";
            }
        }

        // Stop the timer.
        private void howto_threading_countdown_Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TheTimer != null) TheTimer.Dispose();
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
            this.Label1 = new System.Windows.Forms.Label();
            this.lblFinished = new System.Windows.Forms.Label();
            this.lblHours = new System.Windows.Forms.Label();
            this.lblDays = new System.Windows.Forms.Label();
            this.lblSeconds = new System.Windows.Forms.Label();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.Color.Red;
            this.Label1.Location = new System.Drawing.Point(21, 194);
            this.Label1.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(346, 46);
            this.Label1.TabIndex = 17;
            this.Label1.Text = "Until doomsday...";
            // 
            // lblFinished
            // 
            this.lblFinished.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFinished.Font = new System.Drawing.Font("Arial", 100F, System.Drawing.FontStyle.Bold);
            this.lblFinished.ForeColor = System.Drawing.Color.Red;
            this.lblFinished.Location = new System.Drawing.Point(0, 0);
            this.lblFinished.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.lblFinished.Name = "lblFinished";
            this.lblFinished.Size = new System.Drawing.Size(384, 251);
            this.lblFinished.TabIndex = 16;
            this.lblFinished.Text = "Doomsday has arrived!";
            this.lblFinished.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFinished.Visible = false;
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.ForeColor = System.Drawing.Color.Blue;
            this.lblHours.Location = new System.Drawing.Point(21, 55);
            this.lblHours.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(183, 46);
            this.lblHours.TabIndex = 13;
            this.lblHours.Text = "24 hours";
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.ForeColor = System.Drawing.Color.Blue;
            this.lblDays.Location = new System.Drawing.Point(21, 9);
            this.lblDays.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(165, 46);
            this.lblDays.TabIndex = 12;
            this.lblDays.Text = "10 days";
            // 
            // lblSeconds
            // 
            this.lblSeconds.AutoSize = true;
            this.lblSeconds.ForeColor = System.Drawing.Color.Blue;
            this.lblSeconds.Location = new System.Drawing.Point(21, 148);
            this.lblSeconds.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(234, 46);
            this.lblSeconds.TabIndex = 15;
            this.lblSeconds.Text = "59 seconds";
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.ForeColor = System.Drawing.Color.Blue;
            this.lblMinutes.Location = new System.Drawing.Point(21, 102);
            this.lblMinutes.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(225, 46);
            this.lblMinutes.TabIndex = 14;
            this.lblMinutes.Text = "59 minutes";
            // 
            // howto_threading_countdown_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(24F, 46F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 251);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lblHours);
            this.Controls.Add(this.lblDays);
            this.Controls.Add(this.lblSeconds);
            this.Controls.Add(this.lblMinutes);
            this.Controls.Add(this.lblFinished);
            this.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.Name = "howto_threading_countdown_Form1";
            this.Text = "howto_threading_countdown";
            this.Load += new System.EventHandler(this.howto_threading_countdown_Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.howto_threading_countdown_Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label lblFinished;
        internal System.Windows.Forms.Label lblHours;
        internal System.Windows.Forms.Label lblDays;
        internal System.Windows.Forms.Label lblSeconds;
        internal System.Windows.Forms.Label lblMinutes;
    }
}

