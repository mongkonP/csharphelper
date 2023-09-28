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
     public partial class howto_countdown_timer_Form1:Form
  { 


        public howto_countdown_timer_Form1()
        {
            InitializeComponent();
        }

        // Initialize information about the event.
        private const string EventName = "End of the World";
        private DateTime EventDate = DateTime.Now + new TimeSpan(1, 13, 42, 59);
        private void howto_countdown_timer_Form1_Load(object sender, EventArgs e)
        {
            lblEvent.Text = EventName;
            this.Text = EventName + " at " + EventDate.ToString();
            this.ClientSize = new Size(lblEvent.Bounds.Right, lblEvent.Bounds.Bottom);
            tmrCheckTime.Enabled = true;
        }

        // Update the countdown.
        private void tmrCheckTime_Tick(object sender, EventArgs e)
        {
            TimeSpan remaining = EventDate - DateTime.Now;
            if (remaining.TotalSeconds < 1)
            {
                tmrCheckTime.Enabled = false;
                this.WindowState = FormWindowState.Maximized;
                this.TopMost = true;

                foreach (Control ctl in this.Controls)
                {
                    if (ctl == lblEvent)
                    {
                        ctl.Location = new Point(
                            (this.ClientSize.Width - ctl.Width) / 2,
                            (this.ClientSize.Height - ctl.Height) / 2);
                    }
                    else
                    {
                        ctl.Visible = false;
                    }
                }

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
            this.Label1 = new System.Windows.Forms.Label();
            this.lblEvent = new System.Windows.Forms.Label();
            this.lblHours = new System.Windows.Forms.Label();
            this.lblDays = new System.Windows.Forms.Label();
            this.tmrCheckTime = new System.Windows.Forms.Timer(this.components);
            this.lblSeconds = new System.Windows.Forms.Label();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.Color.Red;
            this.Label1.Location = new System.Drawing.Point(4, 189);
            this.Label1.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(107, 46);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "Until";
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.ForeColor = System.Drawing.Color.Red;
            this.lblEvent.Location = new System.Drawing.Point(102, 189);
            this.lblEvent.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(167, 46);
            this.lblEvent.TabIndex = 10;
            this.lblEvent.Text = "<event>";
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.ForeColor = System.Drawing.Color.Blue;
            this.lblHours.Location = new System.Drawing.Point(4, 50);
            this.lblHours.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(183, 46);
            this.lblHours.TabIndex = 7;
            this.lblHours.Text = "24 hours";
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.ForeColor = System.Drawing.Color.Blue;
            this.lblDays.Location = new System.Drawing.Point(4, 4);
            this.lblDays.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(165, 46);
            this.lblDays.TabIndex = 6;
            this.lblDays.Text = "10 days";
            // 
            // tmrCheckTime
            // 
            this.tmrCheckTime.Interval = 500;
            this.tmrCheckTime.Tick += new System.EventHandler(this.tmrCheckTime_Tick);
            // 
            // lblSeconds
            // 
            this.lblSeconds.AutoSize = true;
            this.lblSeconds.ForeColor = System.Drawing.Color.Blue;
            this.lblSeconds.Location = new System.Drawing.Point(4, 143);
            this.lblSeconds.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(234, 46);
            this.lblSeconds.TabIndex = 9;
            this.lblSeconds.Text = "59 seconds";
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.ForeColor = System.Drawing.Color.Blue;
            this.lblMinutes.Location = new System.Drawing.Point(4, 97);
            this.lblMinutes.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(225, 46);
            this.lblMinutes.TabIndex = 8;
            this.lblMinutes.Text = "59 minutes";
            // 
            // howto_countdown_timer_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(24F, 46F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 237);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lblEvent);
            this.Controls.Add(this.lblHours);
            this.Controls.Add(this.lblDays);
            this.Controls.Add(this.lblSeconds);
            this.Controls.Add(this.lblMinutes);
            this.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.Name = "howto_countdown_timer_Form1";
            this.Text = "howto_countdown_timer";
            this.Load += new System.EventHandler(this.howto_countdown_timer_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label lblEvent;
        internal System.Windows.Forms.Label lblHours;
        internal System.Windows.Forms.Label lblDays;
        internal System.Windows.Forms.Timer tmrCheckTime;
        internal System.Windows.Forms.Label lblSeconds;
        internal System.Windows.Forms.Label lblMinutes;
    }
}

