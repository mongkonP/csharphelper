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
     public partial class howto_increment_speed_Form1:Form
  { 


        public howto_increment_speed_Form1()
        {
            InitializeComponent();
        }

        // Perform the trials.
        private void btnGo_Click(object sender, EventArgs e)
        {
            long num_trials = long.Parse(txtNumTrials.Text);
            lblXPlus1.Text = "";
            lblXIncr.Text = "";
            lblPlusEquals1.Text = "";
            lblPlus3.Text = "";
            lblPlusEquals3.Text = "";
            Cursor = Cursors.WaitCursor;
            Refresh();

            long x;
            Stopwatch watch = new Stopwatch();

            // Trials using x = x + 1.
            x = 1;
            watch.Start();
            for (long i = 0; i < num_trials; i++)
            {
                x = x + 1;
            }
            watch.Stop();
            lblXPlus1.Text = watch.Elapsed.TotalSeconds.ToString("0.00") + " seconds";
            lblXPlus1.Refresh();

            // Trials using x++.
            x = 1;
            watch.Reset();
            watch.Start();
            for (long i = 0; i < num_trials; i++)
            {
                x++;
            }
            watch.Stop();
            lblXIncr.Text = watch.Elapsed.TotalSeconds.ToString("0.00") + " seconds";
            lblXIncr.Refresh();

            // Trials using x += 1.
            x = 1;
            watch.Reset();
            watch.Start();
            for (long i = 0; i < num_trials; i++)
            {
                x += 1;
            }
            watch.Stop();
            lblPlusEquals1.Text = watch.Elapsed.TotalSeconds.ToString("0.00") + " seconds";
            lblPlusEquals1.Refresh();

            // Trials using x = x + 3.
            x = 1;
            watch.Reset();
            watch.Start();
            for (long i = 0; i < num_trials; i++)
            {
                x = x + 3;
            }
            watch.Stop();
            lblPlus3.Text = watch.Elapsed.TotalSeconds.ToString("0.00") + " seconds";
            lblPlus3.Refresh();

            // Trials using x += 3.
            x = 1;
            watch.Reset();
            watch.Start();
            for (long i = 0; i < num_trials; i++)
            {
                x += 3;
            }
            watch.Stop();
            lblPlusEquals3.Text = watch.Elapsed.TotalSeconds.ToString("0.00") + " seconds";
            lblPlusEquals3.Refresh();

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
            this.lblPlusEquals3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPlus3 = new System.Windows.Forms.Label();
            this.lblXIncr = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblXPlus1 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtNumTrials = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPlusEquals1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPlusEquals3
            // 
            this.lblPlusEquals3.Location = new System.Drawing.Point(65, 159);
            this.lblPlusEquals3.Name = "lblPlusEquals3";
            this.lblPlusEquals3.Size = new System.Drawing.Size(100, 13);
            this.lblPlusEquals3.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "x += 3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "x = x + 3";
            // 
            // lblPlus3
            // 
            this.lblPlus3.Location = new System.Drawing.Point(65, 134);
            this.lblPlus3.Name = "lblPlus3";
            this.lblPlus3.Size = new System.Drawing.Size(100, 13);
            this.lblPlus3.TabIndex = 10;
            // 
            // lblXIncr
            // 
            this.lblXIncr.Location = new System.Drawing.Point(65, 84);
            this.lblXIncr.Name = "lblXIncr";
            this.lblXIncr.Size = new System.Drawing.Size(100, 13);
            this.lblXIncr.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "x++";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "x = x + 1";
            // 
            // lblXPlus1
            // 
            this.lblXPlus1.Location = new System.Drawing.Point(65, 59);
            this.lblXPlus1.Name = "lblXPlus1";
            this.lblXPlus1.Size = new System.Drawing.Size(100, 13);
            this.lblXPlus1.TabIndex = 4;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(227, 16);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtNumTrials
            // 
            this.txtNumTrials.Location = new System.Drawing.Point(68, 19);
            this.txtNumTrials.Name = "txtNumTrials";
            this.txtNumTrials.Size = new System.Drawing.Size(96, 20);
            this.txtNumTrials.TabIndex = 1;
            this.txtNumTrials.Text = "500000000";
            this.txtNumTrials.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "# Trials:";
            // 
            // lblPlusEquals1
            // 
            this.lblPlusEquals1.Location = new System.Drawing.Point(65, 109);
            this.lblPlusEquals1.Name = "lblPlusEquals1";
            this.lblPlusEquals1.Size = new System.Drawing.Size(100, 13);
            this.lblPlusEquals1.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "x += 1";
            // 
            // howto_increment_speed_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 189);
            this.Controls.Add(this.lblPlusEquals1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblPlusEquals3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblPlus3);
            this.Controls.Add(this.lblXIncr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblXPlus1);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtNumTrials);
            this.Controls.Add(this.label1);
            this.Name = "howto_increment_speed_Form1";
            this.Text = "howto_increment_speed";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlusEquals3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPlus3;
        private System.Windows.Forms.Label lblXIncr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblXPlus1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtNumTrials;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPlusEquals1;
        private System.Windows.Forms.Label label7;
    }
}

