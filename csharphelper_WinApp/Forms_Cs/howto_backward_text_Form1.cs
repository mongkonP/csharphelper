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
     public partial class howto_backward_text_Form1:Form
  { 


        public howto_backward_text_Form1()
        {
            InitializeComponent();
        }

        private void howto_backward_text_Form1_Load(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(280, 100);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.TextRenderingHint =
                    System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                gr.ScaleTransform(-1, 1);
                using (Font the_font = new Font("Comic Sans MS", 40))
                {
                    gr.DrawString("Backward", the_font, Brushes.Black, -280, 0);
                    picBackward.Image = bm;
                }
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
            this.picBackward = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBackward)).BeginInit();
            this.SuspendLayout();
            // 
            // picBackward
            // 
            this.picBackward.Location = new System.Drawing.Point(0, 0);
            this.picBackward.Name = "picBackward";
            this.picBackward.Size = new System.Drawing.Size(100, 50);
            this.picBackward.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBackward.TabIndex = 0;
            this.picBackward.TabStop = false;
            // 
            // howto_backward_text_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 116);
            this.Controls.Add(this.picBackward);
            this.Name = "howto_backward_text_Form1";
            this.Text = "howto_backward_text";
            this.Load += new System.EventHandler(this.howto_backward_text_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBackward)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBackward;
    }
}

