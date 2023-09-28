using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_draw_on_bitmap_Form1:Form
  { 


        public howto_draw_on_bitmap_Form1()
        {
            InitializeComponent();
        }

        // Make and display a Bitmap.
        private void howto_draw_on_bitmap_Form1_Load(object sender, EventArgs e)
        {
            picDrawing.SizeMode = PictureBoxSizeMode.AutoSize;
            picDrawing.Location = new Point(0, 0);

            Bitmap bm = new Bitmap(280, 110);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle rect = new Rectangle(10, 10, 260, 90);
                gr.FillEllipse(Brushes.LightGreen, rect);
                using (Pen thick_pen = new Pen(Color.Blue, 5))
                {
                    gr.DrawEllipse(thick_pen, rect);
                }
            }

            picDrawing.Image = bm;
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
            this.picDrawing = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDrawing)).BeginInit();
            this.SuspendLayout();
            // 
            // picDrawing
            // 
            this.picDrawing.Location = new System.Drawing.Point(12, 12);
            this.picDrawing.Name = "picDrawing";
            this.picDrawing.Size = new System.Drawing.Size(260, 90);
            this.picDrawing.TabIndex = 0;
            this.picDrawing.TabStop = false;
            // 
            // howto_draw_on_bitmap_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 114);
            this.Controls.Add(this.picDrawing);
            this.Name = "howto_draw_on_bitmap_Form1";
            this.Text = "howto_draw_on_bitmap";
            this.Load += new System.EventHandler(this.howto_draw_on_bitmap_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picDrawing)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picDrawing;
    }
}

