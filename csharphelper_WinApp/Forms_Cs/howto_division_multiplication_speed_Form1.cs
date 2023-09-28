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
     public partial class howto_division_multiplication_speed_Form1:Form
  { 


        public howto_division_multiplication_speed_Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            txtTimeMult.Clear();
            txtTimeDiv.Clear();
            txtTimeAdd.Clear();
            txtTimeSubtract.Clear();
            Cursor = Cursors.WaitCursor;

            Stopwatch watch = new Stopwatch();
            int num_trials = int.Parse(txtNumTrials.Text);
            float x = 13, y, z;

            y = 1 / 7f;
            watch.Start();
            for (int i = 0; i < num_trials; i++)
            {
                z = x * y;
            }
            watch.Stop();
            txtTimeMult.Text = watch.Elapsed.TotalSeconds.ToString("0.00") + " secs";

            y = 7f;
            watch.Reset();
            watch.Start();
            for (int i = 0; i < num_trials; i++)
            {
                z = x / y;
            }
            watch.Stop();
            txtTimeDiv.Text =watch.Elapsed.TotalSeconds.ToString("0.00") + " secs";

            watch.Reset();
            watch.Start();
            for (int i = 0; i < num_trials; i++)
            {
                z = x + y;
            }
            watch.Stop();
            txtTimeAdd.Text = watch.Elapsed.TotalSeconds.ToString("0.00") + " secs";

            watch.Reset();
            watch.Start();
            for (int i = 0; i < num_trials; i++)
            {
                z = x - y;
            }
            watch.Stop();
            txtTimeSubtract.Text = watch.Elapsed.TotalSeconds.ToString("0.00") + " secs";

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
            this.txtTimeSubtract = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTimeAdd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTimeDiv = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTimeMult = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtNumTrials = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTimeSubtract
            // 
            this.txtTimeSubtract.Location = new System.Drawing.Point(63, 129);
            this.txtTimeSubtract.Name = "txtTimeSubtract";
            this.txtTimeSubtract.ReadOnly = true;
            this.txtTimeSubtract.Size = new System.Drawing.Size(100, 20);
            this.txtTimeSubtract.TabIndex = 17;
            this.txtTimeSubtract.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "-";
            // 
            // txtTimeAdd
            // 
            this.txtTimeAdd.Location = new System.Drawing.Point(63, 103);
            this.txtTimeAdd.Name = "txtTimeAdd";
            this.txtTimeAdd.ReadOnly = true;
            this.txtTimeAdd.Size = new System.Drawing.Size(100, 20);
            this.txtTimeAdd.TabIndex = 16;
            this.txtTimeAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "+";
            // 
            // txtTimeDiv
            // 
            this.txtTimeDiv.Location = new System.Drawing.Point(63, 77);
            this.txtTimeDiv.Name = "txtTimeDiv";
            this.txtTimeDiv.ReadOnly = true;
            this.txtTimeDiv.Size = new System.Drawing.Size(100, 20);
            this.txtTimeDiv.TabIndex = 15;
            this.txtTimeDiv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "/";
            // 
            // txtTimeMult
            // 
            this.txtTimeMult.Location = new System.Drawing.Point(63, 51);
            this.txtTimeMult.Name = "txtTimeMult";
            this.txtTimeMult.ReadOnly = true;
            this.txtTimeMult.Size = new System.Drawing.Size(100, 20);
            this.txtTimeMult.TabIndex = 13;
            this.txtTimeMult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "*";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(182, 13);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 12;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtNumTrials
            // 
            this.txtNumTrials.Location = new System.Drawing.Point(63, 15);
            this.txtNumTrials.Name = "txtNumTrials";
            this.txtNumTrials.Size = new System.Drawing.Size(100, 20);
            this.txtNumTrials.TabIndex = 10;
            this.txtNumTrials.Text = "100000000";
            this.txtNumTrials.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "# Trials:";
            // 
            // howto_division_multiplication_speed_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 161);
            this.Controls.Add(this.txtTimeSubtract);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTimeAdd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTimeDiv);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTimeMult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtNumTrials);
            this.Controls.Add(this.label1);
            this.Name = "howto_division_multiplication_speed_Form1";
            this.Text = "howto_division_multiplication_speed";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTimeSubtract;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTimeAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTimeDiv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTimeMult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtNumTrials;
        private System.Windows.Forms.Label label1;
    }
}

