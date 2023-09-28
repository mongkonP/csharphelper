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
     public partial class howto_time_checked_Form1:Form
  { 


        public howto_time_checked_Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            txtChecked.Clear();
            txtUnchecked.Clear();
            Cursor = Cursors.WaitCursor;
            Refresh();

            int num_trials = int.Parse(txtNumTrials.Text);
            Stopwatch watch = new Stopwatch();

            watch.Start();
            checked
            {
                for (int i = 0; i < num_trials; i++)
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        int k = i - j;
                    }
                }
            }
            watch.Stop();
            txtChecked.Text =
                watch.Elapsed.TotalSeconds.ToString("0.00") +
                " seconds";
            txtChecked.Refresh();

            watch.Reset();
            watch.Start();
            unchecked
            {
                for (int i = 0; i < num_trials; i++)
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        int k = i - j;
                    }
                }
            }
            watch.Stop();
            txtUnchecked.Text =
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtChecked = new System.Windows.Forms.TextBox();
            this.txtUnchecked = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.txtNumTrials.Size = new System.Drawing.Size(76, 20);
            this.txtNumTrials.TabIndex = 1;
            this.txtNumTrials.Text = "100000";
            this.txtNumTrials.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(197, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Checked:";
            // 
            // txtChecked
            // 
            this.txtChecked.Location = new System.Drawing.Point(84, 72);
            this.txtChecked.Name = "txtChecked";
            this.txtChecked.ReadOnly = true;
            this.txtChecked.Size = new System.Drawing.Size(100, 20);
            this.txtChecked.TabIndex = 4;
            // 
            // txtUnchecked
            // 
            this.txtUnchecked.Location = new System.Drawing.Point(84, 98);
            this.txtUnchecked.Name = "txtUnchecked";
            this.txtUnchecked.ReadOnly = true;
            this.txtUnchecked.Size = new System.Drawing.Size(100, 20);
            this.txtUnchecked.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Unchecked:";
            // 
            // howto_time_checked_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 131);
            this.Controls.Add(this.txtUnchecked);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtChecked);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtNumTrials);
            this.Controls.Add(this.label1);
            this.Name = "howto_time_checked_Form1";
            this.Text = "howto_time_checked";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumTrials;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtChecked;
        private System.Windows.Forms.TextBox txtUnchecked;
        private System.Windows.Forms.Label label3;
    }
}

