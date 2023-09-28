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
     public partial class howto_stopwatch_Form1:Form
  { 


        public howto_stopwatch_Form1()
        {
            InitializeComponent();
        }

        // Start or stop the stopwatch.
        private DateTime StartTime;
        private void btnStart_Click(object sender, EventArgs e)
        {
            tmrClock.Enabled = !tmrClock.Enabled;
            btnStart.Text = tmrClock.Enabled ? "Stop" : "Start";
            StartTime = DateTime.Now;
        }

        // Display the new elapsed time.
        private void tmrClock_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - StartTime;

            // Start with the days if greater than 0.
            string text = "";
            if (elapsed.Days > 0)
                text += elapsed.Days.ToString() + ".";
            
            // Convert milliseconds into tenths of seconds.
            int tenths = elapsed.Milliseconds / 100;

            // Compose the rest of the elapsed time.
            text +=
                elapsed.Hours.ToString("00") + ":" +
                elapsed.Minutes.ToString("00") + ":" +
                elapsed.Seconds.ToString("00") + "." +
                tenths.ToString("0");

            lblElapsed.Text = text;
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
            this.lblElapsed = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblElapsed
            // 
            this.lblElapsed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblElapsed.Font = new System.Drawing.Font("Times New Roman", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElapsed.Location = new System.Drawing.Point(12, 37);
            this.lblElapsed.Name = "lblElapsed";
            this.lblElapsed.Size = new System.Drawing.Size(290, 74);
            this.lblElapsed.TabIndex = 3;
            this.lblElapsed.Text = "00:00:00.0";
            this.lblElapsed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStart.Location = new System.Drawing.Point(120, 11);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tmrClock
            // 
            this.tmrClock.Tick += new System.EventHandler(this.tmrClock_Tick);
            // 
            // howto_stopwatch_Form1
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 121);
            this.Controls.Add(this.lblElapsed);
            this.Controls.Add(this.btnStart);
            this.Name = "howto_stopwatch_Form1";
            this.Text = "howto_stopwatch";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblElapsed;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer tmrClock;
    }
}

