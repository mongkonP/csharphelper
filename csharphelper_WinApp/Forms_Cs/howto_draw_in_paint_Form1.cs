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
     public partial class howto_draw_in_paint_Form1:Form
  { 


        public howto_draw_in_paint_Form1()
        {
            InitializeComponent();
        }

        // Redraw on resize.
        private void howto_draw_in_paint_Form1_Load(object sender, EventArgs e)
        {
            ResizeRedraw = true;
        }

        // Draw an ellipse.
        private void howto_draw_in_paint_Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(10, 10,
                this.ClientSize.Width - 20,
                this.ClientSize.Height - 20);
            e.Graphics.FillEllipse(Brushes.Yellow, rect);
            using (Pen thick_pen = new Pen(Color.Red, 5))
            {
                e.Graphics.DrawEllipse(thick_pen, rect);
            }
        }

        // Draw an ellipse on the PictureBox.
        private void picEllipse_Resize(object sender, EventArgs e)
        {
            picEllipse.Refresh();
        }
        private void picEllipse_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(10, 10,
                picEllipse.ClientSize.Width - 20,
                picEllipse.ClientSize.Height - 20);
            e.Graphics.FillEllipse(Brushes.Pink, rect);
            using (Pen thick_pen = new Pen(Color.Blue, 5))
            {
                e.Graphics.DrawEllipse(thick_pen, rect);
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
            this.picEllipse = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picEllipse)).BeginInit();
            this.SuspendLayout();
            // 
            // picEllipse
            // 
            this.picEllipse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picEllipse.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picEllipse.Location = new System.Drawing.Point(52, 56);
            this.picEllipse.Name = "picEllipse";
            this.picEllipse.Size = new System.Drawing.Size(180, 86);
            this.picEllipse.TabIndex = 0;
            this.picEllipse.TabStop = false;
            this.picEllipse.Resize += new System.EventHandler(this.picEllipse_Resize);
            this.picEllipse.Paint += new System.Windows.Forms.PaintEventHandler(this.picEllipse_Paint);
            // 
            // howto_draw_in_paint_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 199);
            this.Controls.Add(this.picEllipse);
            this.Name = "howto_draw_in_paint_Form1";
            this.Text = "howto_draw_in_paint";
            this.Load += new System.EventHandler(this.howto_draw_in_paint_Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.howto_draw_in_paint_Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.picEllipse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picEllipse;
    }
}

