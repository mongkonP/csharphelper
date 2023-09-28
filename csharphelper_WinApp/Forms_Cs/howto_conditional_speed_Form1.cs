using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Globalization;
using System.Diagnostics;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_conditional_speed_Form1:Form
  { 


        public howto_conditional_speed_Form1()
        {
            InitializeComponent();
        }

        // Perform the trials.
        private void btnGo_Click(object sender, EventArgs e)
        {
            long num_trials = long.Parse(txtNumTrials.Text, NumberStyles.Any);
            lblIfTime.Text = "";
            lblConditionalTime.Text = "";
            Cursor = Cursors.WaitCursor;
            Refresh();

            Stopwatch watch = new Stopwatch();
            long x;

            // Trials using if.
            x = 1;
            watch.Start();
            for (long i = 0; i < num_trials; i++)
            {
                if (x % 2 == 0) x = x + 1;
                else x = x + 3;
            }
            watch.Stop();
            lblIfTime.Text =
                watch.Elapsed.TotalSeconds.ToString("0.00") +
                " seconds";
            Refresh();

            // Trials using ?:.
            x = 1;
            watch.Reset();
            watch.Start();
            for (long i = 0; i < num_trials; i++)
            {
                x = (x % 2 == 0) ? x + 1 : x + 3;
            }
            watch.Stop();
            lblConditionalTime.Text =
                watch.Elapsed.TotalSeconds.ToString("0.00") +
                " seconds";

            Cursor = Cursors.Default;
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumTrials = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblIfTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblConditionalTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "# Trials:";
            // 
            // txtNumTrials
            // 
            this.txtNumTrials.Location = new System.Drawing.Point(63, 14);
            this.txtNumTrials.Name = "txtNumTrials";
            this.txtNumTrials.Size = new System.Drawing.Size(102, 20);
            this.txtNumTrials.TabIndex = 1;
            this.txtNumTrials.Text = "100,000,000";
            this.txtNumTrials.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(217, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblIfTime
            // 
            this.lblIfTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIfTime.AutoSize = true;
            this.lblIfTime.Location = new System.Drawing.Point(60, 55);
            this.lblIfTime.Name = "lblIfTime";
            this.lblIfTime.Size = new System.Drawing.Size(0, 13);
            this.lblIfTime.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "If";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = ":?";
            // 
            // lblConditionalTime
            // 
            this.lblConditionalTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblConditionalTime.AutoSize = true;
            this.lblConditionalTime.Location = new System.Drawing.Point(60, 79);
            this.lblConditionalTime.Name = "lblConditionalTime";
            this.lblConditionalTime.Size = new System.Drawing.Size(0, 13);
            this.lblConditionalTime.TabIndex = 6;
            // 
            // howto_conditional_speed_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 101);
            this.Controls.Add(this.lblConditionalTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblIfTime);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtNumTrials);
            this.Controls.Add(this.label1);
            this.Name = "howto_conditional_speed_Form1";
            this.Text = "howto_conditional_speed";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumTrials;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblIfTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblConditionalTime;
    }
}

