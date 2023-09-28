using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_battery_notify;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_battery_notify_Form1:Form
  { 


        public howto_battery_notify_Form1()
        {
            InitializeComponent();
        }

        // The last displayed charge percent.
        private int Percent = -1;

        // Hide the form.
        private void howto_battery_notify_Form1_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            Size = new Size(0, 0);
            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;
            Hide();

            ShowStatus();
        }

        private void tmrCheckStatus_Tick(object sender, EventArgs e)
        {
            ShowStatus();
        }

        // Update the battery status.
        private void ShowStatus()
        {
            // Get the current charge percent.
            PowerStatus status = SystemInformation.PowerStatus;
            int percent = (int)(status.BatteryLifePercent * 100);

            // If the percent is unchanged, do nothing.
            if (Percent == percent) return;
            Percent = percent;

            // Display the status in the NotifyIcon's text.
            niBatteryStatus.Text = percent.ToString() +
                "% " + status.PowerLineStatus.ToString();

            // Change the icon.
            // Draw the battery image.
            int wid = picIcon.ClientSize.Width / 2;
            int hgt = picIcon.ClientSize.Height;
            Bitmap battery_bm = BatteryStuff.DrawBattery(
                percent / 100f,
                wid, hgt,
                Color.Transparent, Color.Black,
                Color.Lime, Color.White,
                true);

            // Convert the battery image into a square icon.
            Bitmap square_bm = new Bitmap(hgt, hgt);
            using (Graphics gr = Graphics.FromImage(square_bm))
            {
                gr.Clear(Color.Transparent);
                Point[] dest =
                {
                    new Point((int)(0.5 * wid), 0),
                    new Point((int)(1.5 * wid), 0),
                    new Point((int)(0.5 * wid), hgt),
                };
                Rectangle source = new Rectangle(0, 0, wid, hgt);
                gr.DrawImage(battery_bm,
                    dest, source, GraphicsUnit.Pixel);
            }
            picIcon.Image = square_bm;

            // Convert the bitmap into an icon.
            Icon icon = Icon.FromHandle(square_bm.GetHicon());
            niBatteryStatus.Icon = icon;
        }

        private void ctxExit_Click(object sender, EventArgs e)
        {
            Close();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howto_battery_notify_Form1));
            this.niBatteryStatus = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctxNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrCheckStatus = new System.Windows.Forms.Timer(this.components);
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.ctxNotify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // niBatteryStatus
            // 
            this.niBatteryStatus.ContextMenuStrip = this.ctxNotify;
            this.niBatteryStatus.Icon = ((System.Drawing.Icon)(resources.GetObject("niBatteryStatus.Icon")));
            this.niBatteryStatus.Text = "Battery status";
            this.niBatteryStatus.Visible = true;
            // 
            // ctxNotify
            // 
            this.ctxNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxExit});
            this.ctxNotify.Name = "ctxNotify";
            this.ctxNotify.Size = new System.Drawing.Size(93, 26);
            // 
            // ctxExit
            // 
            this.ctxExit.Name = "ctxExit";
            this.ctxExit.Size = new System.Drawing.Size(92, 22);
            this.ctxExit.Text = "E&xit";
            this.ctxExit.Click += new System.EventHandler(this.ctxExit_Click);
            // 
            // tmrCheckStatus
            // 
            this.tmrCheckStatus.Enabled = true;
            this.tmrCheckStatus.Interval = 5000;
            this.tmrCheckStatus.Tick += new System.EventHandler(this.tmrCheckStatus_Tick);
            // 
            // picIcon
            // 
            this.picIcon.Location = new System.Drawing.Point(12, 12);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(16, 16);
            this.picIcon.TabIndex = 1;
            this.picIcon.TabStop = false;
            // 
            // howto_battery_notify_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.picIcon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "howto_battery_notify_Form1";
            this.Text = "howto_battery_notify";
            this.Load += new System.EventHandler(this.howto_battery_notify_Form1_Load);
            this.ctxNotify.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon niBatteryStatus;
        private System.Windows.Forms.Timer tmrCheckStatus;
        private System.Windows.Forms.ContextMenuStrip ctxNotify;
        private System.Windows.Forms.ToolStripMenuItem ctxExit;
        private System.Windows.Forms.PictureBox picIcon;
    }
}

