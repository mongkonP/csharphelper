using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Globalization;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_use_progressbar_Form1:Form
  { 


        public howto_use_progressbar_Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            long max = long.Parse(txtMax.Text, NumberStyles.Any);
            long tenth = max / 10;
            long leftover = max - 9 * tenth;
            prgCount.Show();
            for (int round = 0; round < 9; round++)
            {
                prgCount.Value = round * 10;
                for (long i = 0; i < tenth; i++) { }
            }
            prgCount.Value = 90;
            for (long i = 0; i < leftover; i++) { }
            prgCount.Value = 100;
            tmrHideProgressBar.Enabled = true;
        }

        private void tmrHideProgressBar_Tick(object sender, EventArgs e)
        {
            prgCount.Hide();
            tmrHideProgressBar.Enabled = false;
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
            this.btnGo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.prgCount = new System.Windows.Forms.ProgressBar();
            this.tmrHideProgressBar = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(217, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Count To:";
            // 
            // txtMax
            // 
            this.txtMax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMax.Location = new System.Drawing.Point(72, 14);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(120, 20);
            this.txtMax.TabIndex = 2;
            this.txtMax.Text = "1,000,000,000";
            this.txtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // prgCount
            // 
            this.prgCount.Location = new System.Drawing.Point(12, 63);
            this.prgCount.Name = "prgCount";
            this.prgCount.Size = new System.Drawing.Size(280, 23);
            this.prgCount.TabIndex = 4;
            this.prgCount.Visible = false;
            // 
            // tmrHideProgressBar
            // 
            this.tmrHideProgressBar.Interval = 500;
            this.tmrHideProgressBar.Tick += new System.EventHandler(this.tmrHideProgressBar_Tick);
            // 
            // howto_use_progressbar_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 98);
            this.Controls.Add(this.prgCount);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGo);
            this.Name = "howto_use_progressbar_Form1";
            this.Text = "howto_use_progressbar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.ProgressBar prgCount;
        private System.Windows.Forms.Timer tmrHideProgressBar;
    }
}

