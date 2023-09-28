using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Enable the timer at design time.

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_show_gmt_Form1:Form
  { 


        public howto_show_gmt_Form1()
        {
            InitializeComponent();
        }

        // Update the clocks.
        private void tmrClock_Tick(object sender, EventArgs e)
        {
            // Display the local time.
            DateTime now = DateTime.Now;
            lblLocalTime.Text = now.ToLongTimeString();
            lblLocalDate.Text = now.ToShortDateString();

            // Display the GMT time.
            DateTimeOffset local_offset = new DateTimeOffset(now);
            DateTimeOffset utc_offset = local_offset.ToUniversalTime();
            lblGmtTime.Text = utc_offset.DateTime.ToLongTimeString();
            lblGmtDate.Text = utc_offset.DateTime.ToShortDateString();
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
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.lblGmtTime = new System.Windows.Forms.Label();
            this.lblGmtDate = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLocalTime = new System.Windows.Forms.Label();
            this.lblLocalDate = new System.Windows.Forms.Label();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrClock
            // 
            this.tmrClock.Enabled = true;
            this.tmrClock.Interval = 500;
            this.tmrClock.Tick += new System.EventHandler(this.tmrClock_Tick);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox2.Controls.Add(this.lblGmtTime);
            this.GroupBox2.Controls.Add(this.lblGmtDate);
            this.GroupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox2.ForeColor = System.Drawing.Color.Blue;
            this.GroupBox2.Location = new System.Drawing.Point(12, 112);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(260, 94);
            this.GroupBox2.TabIndex = 13;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "GMT";
            // 
            // lblGmtTime
            // 
            this.lblGmtTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGmtTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGmtTime.ForeColor = System.Drawing.Color.Black;
            this.lblGmtTime.Location = new System.Drawing.Point(17, 22);
            this.lblGmtTime.Name = "lblGmtTime";
            this.lblGmtTime.Size = new System.Drawing.Size(237, 37);
            this.lblGmtTime.TabIndex = 5;
            this.lblGmtTime.Text = "00:00:00 AM";
            this.lblGmtTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGmtDate
            // 
            this.lblGmtDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGmtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGmtDate.ForeColor = System.Drawing.Color.Black;
            this.lblGmtDate.Location = new System.Drawing.Point(17, 59);
            this.lblGmtDate.Name = "lblGmtDate";
            this.lblGmtDate.Size = new System.Drawing.Size(237, 29);
            this.lblGmtDate.TabIndex = 9;
            this.lblGmtDate.Text = "12/25/20";
            this.lblGmtDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.Controls.Add(this.lblLocalTime);
            this.GroupBox1.Controls.Add(this.lblLocalDate);
            this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.ForeColor = System.Drawing.Color.Blue;
            this.GroupBox1.Location = new System.Drawing.Point(12, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(260, 94);
            this.GroupBox1.TabIndex = 12;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Local";
            // 
            // lblLocalTime
            // 
            this.lblLocalTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLocalTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalTime.ForeColor = System.Drawing.Color.Black;
            this.lblLocalTime.Location = new System.Drawing.Point(17, 22);
            this.lblLocalTime.Name = "lblLocalTime";
            this.lblLocalTime.Size = new System.Drawing.Size(237, 37);
            this.lblLocalTime.TabIndex = 5;
            this.lblLocalTime.Text = "00:00:00 AM";
            this.lblLocalTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLocalDate
            // 
            this.lblLocalDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLocalDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalDate.ForeColor = System.Drawing.Color.Black;
            this.lblLocalDate.Location = new System.Drawing.Point(17, 59);
            this.lblLocalDate.Name = "lblLocalDate";
            this.lblLocalDate.Size = new System.Drawing.Size(237, 29);
            this.lblLocalDate.TabIndex = 9;
            this.lblLocalDate.Text = "12/25/20";
            this.lblLocalDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // howto_show_gmt_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 217);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Name = "howto_show_gmt_Form1";
            this.Text = "howto_show_gmt";
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrClock;
        internal System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.Label lblGmtTime;
        private System.Windows.Forms.Label lblGmtDate;
        internal System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.Label lblLocalTime;
        private System.Windows.Forms.Label lblLocalDate;
    }
}

