using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_measure_elapsed_time_Form1:Form
  { 


        public howto_measure_elapsed_time_Form1()
        {
            InitializeComponent();
        }

        private DateTime StartTime, StopTime;
        Stopwatch StopWatch;
        Stopwatch TotalWatch = new Stopwatch();

        private void howto_measure_elapsed_time_Form1_Load(object sender, EventArgs e)
        {
            txtFrequency.Text = Stopwatch.Frequency.ToString();
            txtNsPerTick.Text = (1000000000 / Stopwatch.Frequency).ToString();
            txtIsHighRes.Text = Stopwatch.IsHighResolution.ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            txtElapsed1.Clear();
            txtElapsed2.Clear();
            txtElapsed3.Clear();

            StopWatch = Stopwatch.StartNew();
            TotalWatch.Start();
            StartTime = DateTime.Now;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopTime = DateTime.Now;
            StopWatch.Stop();
            TotalWatch.Stop();

            TimeSpan elapsed = StopTime.Subtract(StartTime);
            txtElapsed1.Text = elapsed.TotalSeconds.ToString("0.000000");

            txtElapsed2.Text = StopWatch.Elapsed.TotalSeconds.ToString("0.000000");

            txtElapsed3.Text = TotalWatch.Elapsed.TotalSeconds.ToString("0.000000");

            btnStart.Enabled = true;
            btnStop.Enabled = false;
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
            this.txtElapsed1 = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtElapsed2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtElapsed3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIsHighRes = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFrequency = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNsPerTick = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtElapsed1
            // 
            this.txtElapsed1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtElapsed1.Location = new System.Drawing.Point(156, 53);
            this.txtElapsed1.Name = "txtElapsed1";
            this.txtElapsed1.ReadOnly = true;
            this.txtElapsed1.Size = new System.Drawing.Size(115, 20);
            this.txtElapsed1.TabIndex = 5;
            this.txtElapsed1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(187, 14);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStart.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStart.Location = new System.Drawing.Point(85, 14);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "DateTime:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Stopwatch:";
            // 
            // txtElapsed2
            // 
            this.txtElapsed2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtElapsed2.Location = new System.Drawing.Point(156, 79);
            this.txtElapsed2.Name = "txtElapsed2";
            this.txtElapsed2.ReadOnly = true;
            this.txtElapsed2.Size = new System.Drawing.Size(115, 20);
            this.txtElapsed2.TabIndex = 7;
            this.txtElapsed2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Total:";
            // 
            // txtElapsed3
            // 
            this.txtElapsed3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtElapsed3.Location = new System.Drawing.Point(156, 105);
            this.txtElapsed3.Name = "txtElapsed3";
            this.txtElapsed3.ReadOnly = true;
            this.txtElapsed3.Size = new System.Drawing.Size(115, 20);
            this.txtElapsed3.TabIndex = 9;
            this.txtElapsed3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Is High Res:";
            // 
            // txtIsHighRes
            // 
            this.txtIsHighRes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIsHighRes.Location = new System.Drawing.Point(156, 201);
            this.txtIsHighRes.Name = "txtIsHighRes";
            this.txtIsHighRes.ReadOnly = true;
            this.txtIsHighRes.Size = new System.Drawing.Size(115, 20);
            this.txtIsHighRes.TabIndex = 13;
            this.txtIsHighRes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Ticks/Sec:";
            // 
            // txtFrequency
            // 
            this.txtFrequency.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFrequency.Location = new System.Drawing.Point(156, 149);
            this.txtFrequency.Name = "txtFrequency";
            this.txtFrequency.ReadOnly = true;
            this.txtFrequency.Size = new System.Drawing.Size(115, 20);
            this.txtFrequency.TabIndex = 11;
            this.txtFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(85, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "ns/Tick:";
            // 
            // txtNsPerTick
            // 
            this.txtNsPerTick.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNsPerTick.Location = new System.Drawing.Point(156, 175);
            this.txtNsPerTick.Name = "txtNsPerTick";
            this.txtNsPerTick.ReadOnly = true;
            this.txtNsPerTick.Size = new System.Drawing.Size(115, 20);
            this.txtNsPerTick.TabIndex = 15;
            this.txtNsPerTick.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // howto_measure_elapsed_time_Form1
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnStop;
            this.ClientSize = new System.Drawing.Size(346, 234);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNsPerTick);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIsHighRes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFrequency);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtElapsed3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtElapsed2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtElapsed1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "howto_measure_elapsed_time_Form1";
            this.Text = "howto_measure_elapsed_time";
            this.Load += new System.EventHandler(this.howto_measure_elapsed_time_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtElapsed1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtElapsed2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtElapsed3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIsHighRes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFrequency;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNsPerTick;

    }
}

