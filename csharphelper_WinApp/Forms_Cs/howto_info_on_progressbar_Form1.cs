using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Text;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_info_on_progressbar_Form1:Form
  { 


        public howto_info_on_progressbar_Form1()
        {
            InitializeComponent();
        }

        private int ProgressMinimum = 0;
        private int ProgressMaximum = 100;
        private int ProgressValue = 0;

        private void btnGo_Click(object sender, EventArgs e)
        {
            ProgressValue = 0;
            picProgress.Refresh();
            tmrWork.Enabled = true;
        }

        private void tmrWork_Tick(object sender, EventArgs e)
        {
            ProgressValue += 4;
            if (ProgressValue > ProgressMaximum)
            {
                ProgressValue = 0;
                tmrWork.Enabled = false;
            }
            picProgress.Refresh();
        }

        // Show the progress.
        private void picProgress_Paint(object sender, PaintEventArgs e)
        {
            // Clear the background.
            e.Graphics.Clear(picProgress.BackColor);

            // Draw the progress bar.
            float fraction =
                (float)(ProgressValue - ProgressMinimum) /
                (ProgressMaximum - ProgressMinimum);
            int wid = (int)(fraction * picProgress.ClientSize.Width);
            e.Graphics.FillRectangle(
                Brushes.LightGreen, 0, 0, wid,
                picProgress.ClientSize.Height);

            // Draw the text.
            e.Graphics.TextRenderingHint =
                TextRenderingHint.AntiAliasGridFit;
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                int percent = (int)(fraction * 100);
                e.Graphics.DrawString(
                    percent.ToString() + "%",
                    this.Font, Brushes.Black,
                    picProgress.ClientRectangle, sf);
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
            this.btnGo = new System.Windows.Forms.Button();
            this.tmrWork = new System.Windows.Forms.Timer(this.components);
            this.picProgress = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGo.Location = new System.Drawing.Point(125, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // tmrWork
            // 
            this.tmrWork.Tick += new System.EventHandler(this.tmrWork_Tick);
            // 
            // picProgress
            // 
            this.picProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picProgress.BackColor = System.Drawing.Color.White;
            this.picProgress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picProgress.Location = new System.Drawing.Point(12, 61);
            this.picProgress.Name = "picProgress";
            this.picProgress.Size = new System.Drawing.Size(301, 24);
            this.picProgress.TabIndex = 3;
            this.picProgress.TabStop = false;
            this.picProgress.Paint += new System.Windows.Forms.PaintEventHandler(this.picProgress_Paint);
            // 
            // howto_info_on_progressbar_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 97);
            this.Controls.Add(this.picProgress);
            this.Controls.Add(this.btnGo);
            this.Name = "howto_info_on_progressbar_Form1";
            this.Text = "howto_info_on_progressbar";
            ((System.ComponentModel.ISupportInitialize)(this.picProgress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Timer tmrWork;
        private System.Windows.Forms.PictureBox picProgress;
    }
}

